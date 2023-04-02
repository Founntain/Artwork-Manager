﻿namespace ArtworkManager.Data.Entities;

public class BaseEntity
{
    public ulong Id { get; set; }
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;
}