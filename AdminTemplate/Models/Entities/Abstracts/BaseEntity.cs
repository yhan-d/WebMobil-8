﻿namespace AdminTemplate.Models.Entities.Abstracts
{
    public abstract class BaseEntity<T> where T : IEquatable<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string CreatedUser { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string? UpdatedUser { get; set; }

    }
}
