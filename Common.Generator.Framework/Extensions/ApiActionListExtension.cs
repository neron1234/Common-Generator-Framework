using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ApiActionListExtension
    {
        /// <summary>
        /// Retrieve ViewModels from all api actions parameters and return types.
        /// </summary>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionViewModelsId(this ApiActionList apiActions)
        {
            if (apiActions.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                if (apiAction.Parameters.AsEnumerable() != null)
                {
                    if (apiAction.ReturnType != null
                        && apiAction.ReturnType.Id != null
                        && !viewModels.AsEnumerable().Contains(apiAction.ReturnType.Id.ToPascalCase()))
                        viewModels.Add(apiAction.ReturnType.Id.ToPascalCase());

                    viewModels.Union(apiAction.Parameters.AsEnumerable().GetApiParametersViewModelsId());
                }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from all api actions parameters and return types.
        /// </summary>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionViewModelsEntities(this ApiActionList apiActions)
        {
            if (apiActions.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                if (apiAction.Parameters.AsEnumerable() != null)
                {
                    if (apiAction.ReturnType != null
                        && apiAction.ReturnType.Id != null
                        && !viewModels.AsEnumerable().Contains(apiAction.ReturnType))
                        viewModels.Add(apiAction.ReturnType);

                    viewModels.Union(apiAction.Parameters.AsEnumerable().GetApiParametersViewModelsEntities());
                }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from api actions parameters and return
        /// type for a specific layout action.
        /// </summary>
        /// <param name="layoutAction">A layout action.</param>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionViewModelsId(this ApiActionList apiActions, string layoutAction)
        {
            if (apiActions.AsEnumerable() == null || layoutAction == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                if (apiAction.Id.ToLower().Equals(layoutAction.ToLower())
                    && apiAction.Parameters.AsEnumerable() != null)
                {
                    if (apiAction.ReturnType != null
                        && apiAction.ReturnType.Id != null
                        && !viewModels.AsEnumerable().Contains(apiAction.ReturnType.Id.ToPascalCase()))
                        viewModels.Add(apiAction.ReturnType.Id.ToPascalCase());

                    viewModels.Union(apiAction.Parameters.AsEnumerable().GetApiParametersViewModelsId());
                }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from api actions parameters and return
        /// type for a specific layout action.
        /// </summary>
        /// <param name="layoutAction">A layout action.</param>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionViewModelsEntities(
            this ApiActionList apiActions, string layoutAction)
        {
            if (apiActions.AsEnumerable() == null || layoutAction == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                if (apiAction.Id.ToLower().Equals(layoutAction.ToLower())
                    && apiAction.Parameters.AsEnumerable() != null)
                {
                    if (apiAction.ReturnType != null
                        && apiAction.ReturnType.Id != null
                        && !viewModels.AsEnumerable().Contains(apiAction.ReturnType))
                        viewModels.Add(apiAction.ReturnType);

                    viewModels.Union(apiAction.Parameters.AsEnumerable().GetApiParametersViewModelsEntities());
                }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api action parameters.
        /// </summary>
        /// <param name="apiParameters">A list of ApiParameterInfo.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiParametersViewModelsId(this IEnumerable<ApiParameterInfo> apiParameters)
        {
            if (apiParameters.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            foreach (ApiParameterInfo apiActionParameter in apiParameters.AsEnumerable())
                if (apiActionParameter.IsModel()
                    && !viewModels.AsEnumerable()
                                  .Contains(apiActionParameter.TypeScriptType().ToPascalCase()))
                    viewModels.Add(apiActionParameter.TypeScriptType().ToPascalCase());

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api action parameters.
        /// </summary>
        /// <param name="apiParameters">A list of ApiParameterInfo.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiParametersViewModelsEntities(
            this IEnumerable<ApiParameterInfo> apiParameters)
        {
            if (apiParameters.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            foreach (ApiParameterInfo apiActionParameter in apiParameters.AsEnumerable())
                if (apiActionParameter.IsModel()
                    && !viewModels.AsEnumerable()
                                  .Contains(apiActionParameter.DataModel))
                    viewModels.Add(apiActionParameter.DataModel);

            return viewModels;
        }
    }
}
