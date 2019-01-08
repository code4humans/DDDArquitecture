using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using Unity;

namespace Utilities.IoC
{
    public static class ModuleLoader
    {
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var directoryCatalog = new DirectoryCatalog(path, pattern);
            var importDefinition = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(directoryCatalog);
                    using (var compositionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = compositionContainer.GetExports(importDefinition);
                        IEnumerable<IModule> modules = exports.Select(export => export.Value as IModule).Where(m => m != null);
                        var register = new RegisterModules(container);
                        foreach (IModule module in modules)
                        {
                            module.Initialize(register);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }
                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }

        }
        private static ImportDefinition BuildImportDefinition()
        {
            return
                new ImportDefinition(def => true, typeof(IModule).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }
}
