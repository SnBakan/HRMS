using HRMS.DAL;
using HRMS.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.Service.Auth
{
    public class AuthService
    {
        private readonly IAuthRepository _repo;

        public AuthService(IAuthRepository repo)
        {
            _repo = repo;
        }

        public (UserDto user, List<UserRole> roles) Login(string username, string password)
        {
            var user = _repo.GetUserByUsername(username);

            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            if (!user.IsActive)
                throw new Exception("Kullanıcı pasif durumda.");

            var ok = _repo.ValidatePassword(user.UserId, password);
            if (!ok)
                throw new Exception("Şifre hatalı.");

            var roleDtos = _repo.GetRolesByUserId(user.UserId);

            var roles = roleDtos
                .Select(r => ParseRoleKey(r.RoleKey))
                .Distinct()
                .ToList();

            if (roles.Count == 0)
                throw new Exception("Kullanıcının rolü yok.");

            return (user, roles);
        }

        private UserRole ParseRoleKey(string roleKey)
        {
            // DB’de rRoleKey: Owner / Manager / Employee olmalı
            if (Enum.TryParse<UserRole>(roleKey, ignoreCase: true, out var role))
                return role;

            throw new Exception($"Tanımsız rol anahtarı: {roleKey}");
        }
    }
}
