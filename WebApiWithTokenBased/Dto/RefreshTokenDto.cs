﻿namespace WebApiWithTokenBased.Dto
{
    public record class RefreshTokenDto
    {
        public string? RefreshToken { get; init; }

    }
}
