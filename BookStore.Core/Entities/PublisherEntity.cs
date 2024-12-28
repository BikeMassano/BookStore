﻿using BookStore.Core.Common;

namespace BookStore.Core.Entities
{
    public class PublisherEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<BookEntity>? Books { get; set; } = [];
    }
}
