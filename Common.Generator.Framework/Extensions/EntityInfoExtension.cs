using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class EntityInfoExtension
    {
        /// <summary>
        /// Retrieve all properties from an entity.
        /// It is going higher in the inheritance.
        /// It is going through entity references if it is not
        /// an abstract class and not a collection.
        /// </summary>
        /// <param name="entity">An entity.</param>
        /// <returns>A list of PropertyInfo.</returns>
        public static List<PropertyInfo> GetLinkedProperties(this EntityInfo entity)
        {
            var result = new List<PropertyInfo>();

            if (!entity.IsValid())
            {
                return result;
            }

            var propertyComparer = new PropertyInfoComparer();
            var referenceComparer = new ReferenceInfoComparer();

            if (entity.BaseEntity.IsValid())
            {
                foreach (var property in entity.BaseEntity.GetLinkedProperties())
                {
                    if (property.IsValid()
                        && !result.Any(item =>
                            propertyComparer.Equals(
                                item,
                                property)))
                    {
                        result.Add(property);
                    }
                }
            }

            if (entity.Properties != null)
            {
                foreach (var property in entity.Properties)
                {
                    if (property.IsValid()
                        && !result.Any(item =>
                            propertyComparer.Equals(
                                item,
                                property)))
                    {
                        result.Add(property);
                    }
                }
            }

            if (entity.References != null)
            {
                foreach (var reference in entity.References)
                {
                    if (reference.IsValid()
                        && reference.Target.IsValid()
                        && !reference.Target.IsAbstract
                        && !reference.IsCollection)
                    {
                        if (reference.Target.IsEnum
                            && !result.Any(item =>
                                referenceComparer.Equals(
                                    item,
                                    reference)))
                        {
                            result.Add(reference);

                        }
                        else
                        {
                            foreach (var property in reference.Target.GetLinkedProperties())
                            {
                                if (property.IsValid()
                                    && !result.Any(item =>
                                        propertyComparer.Equals(
                                            item,
                                            property)))
                                {
                                    result.Add(property);
                                }
                            }
                        }
                    }
                    else if (reference.IsValid()
                             && !result.Any(item =>
                                referenceComparer.Equals(
                                    item,
                                    reference)))
                    {
                        result.Add(reference);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieve properties from an entity.
        /// It is going higher in the inheritance.
        /// It is not going through entity references.
        /// </summary>
        /// <param name="entity">An entity.</param>
        /// <returns>A list of PropertyInfo.</returns>
        public static List<PropertyInfo> GetProperties(this EntityInfo entity)
        {
            var result = new List<PropertyInfo>();

            if (!entity.IsValid())
            {
                return result;
            }

            var propertyComparer = new PropertyInfoComparer();
            var referenceComparer = new ReferenceInfoComparer();

            if (entity.BaseEntity.IsValid())
            {
                foreach (var property in entity.BaseEntity.GetProperties())
                {
                    if (property.IsValid()
                        && !result.Any(item =>
                            propertyComparer.Equals(
                                item,
                                property)))
                    {
                        result.Add(property);
                    }
                }
            }

            if (entity.Properties != null)
            {
                foreach (var property in entity.Properties)
                {
                    if (property.IsValid()
                        && !result.Any(item =>
                            propertyComparer.Equals(
                                item,
                                property)))
                    {
                        result.Add(property);
                    }
                }
            }

            if (entity.References != null)
            {
                foreach (var reference in entity.References)
                {
                    if (reference.IsValid()
                        && !result.Any(item =>
                            referenceComparer.Equals(
                                item,
                                reference)))
                    {
                            result.Add(reference);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieve all direct references from an entity.
        /// </summary>
        /// <param name="entity">An EntityInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetEntityDirectReferences(this EntityInfo entity)
        {
            var directReferences = new List<EntityInfo>();

            if (!entity.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            if (entity.References != null)
            {
                foreach (var reference in entity.References)
                {
                    if (reference.Target.IsValid()
                        && !directReferences.Any(item =>
                            entityComparer.Equals(
                                item,
                                reference.Target)))
                    {
                        directReferences.Add(reference.Target);
                    }
                }
            }

            return directReferences;
        }

        /// <summary>
        /// Retrieve all indirect references from an entity.
        /// </summary>
        /// <param name="entity">An EntityInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetEntityIndirectReferences(this EntityInfo entity)
        {
            var allIndirectReferences = new List<EntityInfo>();

            if (!entity.IsValid())
            {
                return allIndirectReferences;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var property in entity.GetLinkedProperties())
            {
                if (property.IsValid())
                {
                    allIndirectReferences = allIndirectReferences
                        .Union(
                            property.GetIndirectReferences(),
                            entityComparer)
                        .ToList();
                }
            }

            return allIndirectReferences;
        }

        public static bool IsInherited(
            this EntityInfo entity,
            SchemaArray<EntityInfo> entities)
        {
            var entityComparer = new EntityInfoComparer();

            return entities
                .Where(e =>
                    e.IsValid()
                    && e.BaseEntity.IsValid()
                    && entityComparer.Equals(
                        entity,
                        e.BaseEntity))
                .Any();
        }

        public static IDictionary<string, string> ModelPropertiesTypes(this EntityInfo entity)
        {
            var propertyTypes = new Dictionary<string, string>();

            if (!entity.IsValid())
            {
                return propertyTypes;
            }

            foreach (var property in entity.GetProperties())
            {
                var subType = property
                    .ModelProperty
                    .Split('.')[0];

                if (!propertyTypes.ContainsKey(subType)
                    && !string.IsNullOrEmpty(subType))
                {
                    propertyTypes.Add(
                        subType,
                        property.Id);
                }
            }

            return propertyTypes;
        }

        public static bool IsValid(this EntityInfo entity)
        {
            if (entity == null
                || !entity.Id.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
