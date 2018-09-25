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
            if (smartApp == null)
                throw new ArgumentNullException();

            if (smartApp.Version != null)
                return smartApp.Version.Major + "."
                       + smartApp.Version.Minor + "."
                       + smartApp.Version.Release;
            return "0.0.0";
        }

        /// <summary>
        /// Check if there is at least one menu in the application.
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A boolean.</returns>
        public static bool HasMenu(this SmartAppInfo smartApp)
        {
            if (smartApp == null)
                throw new ArgumentNullException();

            if (smartApp.Concerns.AsEnumerable() != null)
                return smartApp.Concerns.HasMenu();

            return false;
        }

        /// <summary>
        /// Helper to retrieve the root Layout from the manifest.
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A tuple of a LayoutInfo with his associated ConcernInfo.</returns>
        public static Tuple<LayoutInfo, ConcernInfo> GetRootLayout(this SmartAppInfo smartApp)
        {
            if (smartApp == null)
                throw new ArgumentNullException();

            if (smartApp.Concerns.AsEnumerable() != null)
                foreach (ConcernInfo concern in smartApp.Concerns.AsEnumerable())
                {
                    if (concern.Layouts.AsEnumerable() != null)
                        foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                            if (layout.IsRoot)
                                return new Tuple<LayoutInfo, ConcernInfo>(layout, concern);
                }
            return null;
        }

        /// <summary>
        /// Retrieve used Models inside the application (Layouts and Apis parameters references models)
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetModels(this SmartAppInfo smartApp)
        {
            if (smartApp == null)
                throw new ArgumentNullException();

            List<EntityInfo> specifiedModels = new List<EntityInfo>();
            List<EntityInfo> usedModels = new List<EntityInfo>();

            if (smartApp.Version != null
                && smartApp.DataModel != null
                && smartApp.DataModel.Entities.AsEnumerable() != null
                && smartApp.Concerns.AsEnumerable() != null)
            {
                // Search for references in layout's datamodels
                if (smartApp.Concerns.AsEnumerable() != null)
                    specifiedModels = specifiedModels.AsEnumerable()
                                                     .Union(smartApp.Concerns.GetConcernListDirectReferences().AsEnumerable())
                                                     .ToList();

                // Search for references in api's datamodels
                if (smartApp.Api.AsEnumerable() != null)
                    specifiedModels = specifiedModels.AsEnumerable()
                                                     .Union(smartApp.Api.GetApiListDirectReferences().AsEnumerable())
                                                     .ToList();

                // Get indirect references.
                foreach (EntityInfo entity in specifiedModels.AsEnumerable())
                    if (entity.Id != null)
                    {
                        usedModels = usedModels.AsEnumerable()
                                               .Union(entity.GetEntityIndirectReferences().AsEnumerable())
                                               .ToList();
                    }

                usedModels = usedModels.AsEnumerable()
                                       .Union(specifiedModels.AsEnumerable())
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
            if (smartApp == null)
                throw new ArgumentNullException();

            List<EntityInfo> usedViewModels = new List<EntityInfo>();
            if (smartApp.Version != null
                && smartApp.Api.AsEnumerable() != null)
                usedViewModels = usedViewModels.AsEnumerable()
                                               .Union(smartApp.Api.GetApiListViewModelsEntities().AsEnumerable())
                                               .ToList();

            return usedViewModels;
        }

        /// <summary>
        /// Retrieve layouts from the application.
        /// </summary>
        /// <param name="smartApp">A SmartAppInfo object.</param>
        /// <returns>A LayoutList.</returns>
        public static LayoutList GetLayouts(this SmartAppInfo smartApp)
        {
            if (smartApp == null)
                throw new ArgumentNullException();

            LayoutList layouts = new LayoutList();

            if (smartApp.Version != null
                && smartApp.Concerns != null)
                layouts = layouts.AsEnumerable()
                                 .Union(smartApp.Concerns.GetLayouts().AsEnumerable())
                                 .ToLayoutList();

            return layouts;
        }
    }
}
