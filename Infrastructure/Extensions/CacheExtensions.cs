﻿using Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwl(this IMemoryCache cache, Guid tokenId, JwtDto jwt)
            => cache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtDto>(GetJwtKey(tokenId));

        public static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}
