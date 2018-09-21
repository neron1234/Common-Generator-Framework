﻿using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ApiListExtension
    {
        /// <summary>
        /// Retrieve ViewModels from a list of api.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiListViewModelsId(this ApiList apis)
        {
            if (apis == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            foreach (ApiInfo api in apis.AsEnumerable())
                viewModels.Union(api.GetApiViewModelsId());

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api in function of a layout action.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <param name="layoutAction">A layout action name.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiListViewModelsId(this ApiList apis, string layoutAction)
        {
            if (apis == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            foreach (ApiInfo api in apis.AsEnumerable())
                viewModels.Union(api.GetApiViewModelsId(layoutAction));

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiListViewModelsEntities(this ApiList apis)
        {
            if (apis == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            foreach (ApiInfo api in apis.AsEnumerable())
                viewModels.Union(api.GetApiViewModelsEntities());

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api in function of a layout action.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <param name="layoutAction">A layout action name.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiListViewModelsEntities(this ApiList apis, string layoutAction)
        {
            if (apis == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            foreach (ApiInfo api in apis.AsEnumerable())
                viewModels.Union(api.GetApiViewModelsEntities(layoutAction));

            return viewModels;
        }
    }
}