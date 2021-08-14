using System;
using MongoDB.Bson;

namespace Commander.API.Models
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}