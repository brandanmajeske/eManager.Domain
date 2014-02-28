using eManager.Domain;
using eManager.Web.Infrastructure;
using StructureMap;
namespace eManager.Web.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });

                            x.For<IDepartmentDataSource>().HttpContextScoped().Use<DepartmentDb>();
                        });
            return ObjectFactory.Container;
        }
    }
}