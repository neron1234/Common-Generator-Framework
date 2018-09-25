using Mobioos.Foundation.Jade.Models;
using System;
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
            if (entity == null)
                throw new ArgumentNullException();

            List<PropertyInfo> result = new List<PropertyInfo>();

            if (entity.BaseEntity != null)
                foreach (PropertyInfo property in entity.BaseEntity.GetLinkedProperties().AsEnumerable())
                    result.Add(property);

            if (entity.Properties.AsEnumerable() != null)
                foreach (PropertyInfo property in entity.Properties.AsEnumerable())
                    result.Add(property);

            if (entity.References.AsEnumerable() != null)
                foreach (ReferenceInfo reference in entity.References.AsEnumerable())
                    if (reference.Target != null
                        && !reference.Target.IsAbstract
                        && !reference.IsCollection)
                    {
                        if (reference.Target.IsEnum)
                            result.Add(reference);
                        else
                            foreach (PropertyInfo property in reference.Target.GetLinkedProperties().AsEnumerable())
                                result.Add(property);
                    }
                    else
                        result.Add(reference);
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
            if (entity == null)
                throw new ArgumentNullException();

            List<PropertyInfo> result = new List<PropertyInfo>();

            if (entity.BaseEntity != null)
                foreach (PropertyInfo property in entity.BaseEntity.GetProperties().AsEnumerable())
                    result.Add(property);

            if (entity.Properties.AsEnumerable() != null)
                foreach (PropertyInfo property in entity.Properties.AsEnumerable())
                    result.Add(property);

            if (entity.References.AsEnumerable() != null)
                foreach (ReferenceInfo reference in entity.References.AsEnumerable())
                    result.Add(reference);

            return result;
        }

        /// <summary>
        /// Retrieve all direct references from an entity.
        /// </summary>
        /// <param name="entity">An EntityInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetEntityDirectReferences(this EntityInfo entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (entity != null
                && entity.References.AsEnumerable() != null)
                foreach (ReferenceInfo reference in entity.References.AsEnumerable())
                    if (reference.Target != null
                        && !directReferences.AsEnumerable().Contains(reference.Target))
                        directReferences.Add(reference.Target);

            return directReferences;
        }

        /// <summary>
        /// Retrieve all indirect references from an entity.
        /// </summary>
        /// <param name="entity">An EntityInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetEntityIndirectReferences(this EntityInfo entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            List<EntityInfo> allIndirectReferences = new List<EntityInfo>();

            foreach (PropertyInfo property in entity.GetLinkedProperties().AsEnumerable())
                allIndirectReferences = allIndirectReferences.AsEnumerable()
                                                             .Union(property.GetIndirectReferences().AsEnumerable())
                                                             .ToList();

            return allIndirectReferences;
        }
    }
}
