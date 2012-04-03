using System;
using System.IO;
using Lokad.Cqrs.AtomicStorage;
using ProtoBuf;

namespace Lokad.Cqrs.Feature.AtomicStorage
{
    public sealed class TestStrategy : IDocumentStrategy
    {
        public string GetEntityBucket<TEntity>()
        {
            return typeof(TEntity).Name.ToLowerInvariant();
        }

        public string GetEntityLocation(Type entity, object key)
        {
            return key.ToString();
        }

        public void Serialize<TEntity>(TEntity entity, Stream stream)
        {
            Serializer.Serialize(stream, entity);
        }

        public TEntity Deserialize<TEntity>(Stream stream)
        {
            return Serializer.Deserialize<TEntity>(stream);
        }
    }
}