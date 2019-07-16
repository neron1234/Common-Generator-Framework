using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class SmartAppInfoExtension
    {
        /// <summary>
        /// Retrieve a 3-digit version.
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A 3-digit version in string.</returns>
        public static string GetVersion(this SmartAppInfo smartApp)
        {
            if (!smartApp.IsValid())
            {
                return null;
            }

            if (smartApp.Version.IsValid())
            {
                return $"{smartApp.Version.Major}.{smartApp.Version.Minor}.{smartApp.Version.Release}";
            }

            return null;
        }

        /// <summary>
        /// Check if there is at least one menu in the application.
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A boolean.</returns>
        public static bool HasMenu(this SmartAppInfo smartApp)
        {
            if (!smartApp.IsValid())
            {
                return false;
            }

            if (smartApp.Concerns.IsValid())
            {
                return smartApp.Concerns.HasMenu();
            }

            return false;
        }

        /// <summary>
        /// Helper to retrieve the root Layout from the manifest.
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A tuple of a LayoutInfo with his associated ConcernInfo.</returns>
        public static Tuple<LayoutInfo, ConcernInfo> GetRootLayout(this SmartAppInfo smartApp)
        {
            if (!smartApp.IsValid())
            {
                return null;
            }

            if (smartApp.Concerns.IsValid())
            {
                foreach (var concern in smartApp.Concerns)
                {
                    if (concern.IsValid()
                        && concern.Layouts.IsValid())
                    {
                        foreach (var layout in concern.Layouts)
                        {
                            if (layout.IsValid()
                                && layout.IsRoot)
                            {
                                return new Tuple<LayoutInfo, ConcernInfo>(
                                    layout,
                                    concern);
                            }
                        }
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// Retrieve all entity models.
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        public static SchemaArray<EntityInfo> GetModels(this SmartAppInfo smartApp)
        {
            var models = new SchemaArray<EntityInfo>();

            if (!smartApp.IsValid())
            {
                return models;
            }

            if (smartApp.DataModel.IsValid())
            {
                models = smartApp.DataModel.Entities;
            }

            return models;
        }

        /// <summary>
        /// Retrieve used Models inside the application (Layouts and Apis parameters references models)
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetUsedModels(this SmartAppInfo smartApp)
        {
            var usedModels = new List<EntityInfo>();
            var specifiedModels = new List<EntityInfo>();

            if (!smartApp.IsValid())
            {
                return usedModels;
            }

            var entityComparer = new EntityInfoComparer();

            if (smartApp.Version.IsValid()
                && smartApp.DataModel.IsValid()
                && smartApp.Concerns.IsValid()
                && smartApp.Api.IsValid())
            {
                specifiedModels = specifiedModels
                    .Union(
                        smartApp.Concerns.GetConcernListDirectReferences(),
                        entityComparer)
                    .ToList();

                specifiedModels = specifiedModels
                    .Union(
                        smartApp.Api.GetApiListDirectReferences(),
                        entityComparer)
                    .ToList();

                foreach (var entity in specifiedModels)
                {
                    if (entity.IsValid())
                    {
                        usedModels = usedModels
                            .Union(
                                entity.GetEntityIndirectReferences(),
                                entityComparer)
                            .ToList();
                    }
                }

                usedModels = usedModels
                    .Union(
                        specifiedModels,
                        entityComparer)
                    .ToList();
            }

            return usedModels;
        }

        /// <summary>
        /// Retrieve used ViewModels inside the application (Apis parameters models).
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetViewModels(this SmartAppInfo smartApp)
        {
            var usedViewModels = new List<EntityInfo>();

            if (!smartApp.IsValid())
            {
                return usedViewModels;
            }

            var entityComparer = new EntityInfoComparer();

            if (smartApp.Version.IsValid()
                && smartApp.Api.IsValid())
            {
                usedViewModels = usedViewModels
                    .Union(
                        smartApp.Api.GetApiListViewModelsEntities(),
                        entityComparer)
                    .ToList();
            }

            return usedViewModels;
        }

        /// <summary>
        /// Retrieve layouts from the application.
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A LayoutList.</returns>
        public static LayoutList GetLayouts(this SmartAppInfo smartApp)
        {
            var layouts = new LayoutList();

            if (!smartApp.IsValid())
            {
                return layouts;
            }

            var layoutComparer = new LayoutInfoComparer();

            if (smartApp.Version.IsValid()
                && smartApp.Concerns.IsValid())
            {
                var listToRetrieve = smartApp.Concerns.GetLayouts();

                layouts = layouts
                    .Union(
                        listToRetrieve,
                        layoutComparer)
                    .ToLayoutList();
            }

            return layouts;
        }

        public static bool IsValid(this SmartAppInfo smartApp)
        {
            if (smartApp == null
                || !smartApp.Id.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
