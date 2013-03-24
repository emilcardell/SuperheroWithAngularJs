using Nancy;
using Nancy.TinyIoc;
using Raven.Client;
using Raven.Client.Embedded;
using SuperheroWithAngularJs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroWithAngularJs.Specification
{
    public class SpecificationBootstrapper : ServerBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var store = new EmbeddableDocumentStore() { RunInMemory = true }.Initialize();

            store.Initialize();

            container.Register<IDocumentStore>(store);
        }
    }
}
