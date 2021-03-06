﻿using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class PropertyInfoExtension
    {
        /// <summary>
        /// Transform Mobioos types to C# types.
        /// </summary>
        /// <param name="property">A Mobioos entity property.</param>
        /// <returns>A C# type in string.</returns>
        public static string CSharpType(this PropertyInfo property)
        {
            if (!property.IsValid())
            {
                return null;
            }

            return property.Type.CSharpType();
        }

        /// <summary>
        /// Transform Mobioos types to TypeScript types.
        /// </summary>
        /// <param name="property">A Mobioos entity property.</param>
        /// <returns>A TypeScript type in string.</returns>
        public static string TypeScriptType(this PropertyInfo property)
        {
            if (!property.IsValid())
            {
                return null;
            }

            return property.Type.TypeScriptType();
        }

        /// <summary>
        /// Check if the given type is a primitive type.
        /// </summary>
        /// <param name="property">A PropertyInfo object.</param>
        /// <returns>A boolean.</returns>
        public static bool IsPrimitiveType(this PropertyInfo property)
        {
            if (!property.IsValid())
            {
                return false;
            }

            return property.Type.IsPrimitiveType();
        }

        /// <summary>
        /// Check if the given type is an enum.
        /// An enum can't be a model or a primitive type, so, no need
        /// to double check.
        /// </summary>
        /// <param name="property">A PropertyInfo object.</param>
        /// <returns>A boolean.</returns>
        public static bool IsEnum(this PropertyInfo property)
        {
            if (!property.IsValid())
            {
                return false;
            }

            if (!property.IsPrimitiveType()
                && property.Target.IsValid()
                && property.Target.IsEnum)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the given type is a model.
        /// A model can be an enum, this is why we
        /// verify if it's not an enum.
        /// </summary>
        /// <param name="property">A PropertyInfo object.</param>
        /// <returns>A boolean.</returns>
        public static bool IsModel(this PropertyInfo property)
        {
            if (!property.IsValid())
            {
                return false;
            }

            if (!property.IsPrimitiveType()
                && !property.IsEnum())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieve indirect references from a property.
        /// This case happen when a model is used but
        /// not directly inside the modelization (Layouts, Apis)
        /// </summary>
        /// <param name="property">A PropertyInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetIndirectReferences(this PropertyInfo property)
        {
            var indirectReferences = new List<EntityInfo>();

            if (!property.IsValid())
            {
                return indirectReferences;
            }

            var entityComparer = new EntityInfoComparer();

            if (property.Parent.IsValid()
                && !indirectReferences.Any(item =>
                    entityComparer.Equals(
                        item,
                        (EntityInfo)property.Parent)))
            {
                indirectReferences.Add((EntityInfo)property.Parent);
            }

            if (property.Target.IsValid()
                && !indirectReferences.Any(item =>
                    entityComparer.Equals(
                        item,
                        property.Target)))
            {
                indirectReferences.Add(property.Target);
            }

            return indirectReferences;
        }

        public static bool IsValid(this PropertyInfo property)
        {
            if (property == null
                || !property.Id.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
