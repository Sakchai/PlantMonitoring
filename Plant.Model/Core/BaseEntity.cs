using System;

namespace Plant.Model
{
    public abstract partial class BaseEntity
    {
        public virtual int Id {get; set;}

        /// <summary>
        /// Get key for caching the entity
        /// </summary>
        public string EntityCacheKey => GetEntityCacheKey(GetType(), Id);

        /// <summary>
        /// Get key for caching the entity
        /// </summary>
        /// <param name="entityType">Entity type</param>
        /// <param name="id">Entity id</param>
        /// <returns>Key for caching the entity</returns>
        public static string GetEntityCacheKey(Type entityType, object id)
        {
            return string.Format("Plant.{0}.id-{1}", entityType.Name, id);
        }

    }
}