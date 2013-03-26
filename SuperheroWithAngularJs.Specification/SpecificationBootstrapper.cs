using Nancy.TinyIoc;
using Raven.Client.Embedded;
using SuperheroWithAngularJs.Server;

namespace SuperheroWithAngularJs.Specification
{
    public class SpecificationBootstrapper : ServerBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var store = new EmbeddableDocumentStore() { RunInMemory = true }.Initialize();

            store.Initialize();

            container.Register(store);
        }
    }
}
