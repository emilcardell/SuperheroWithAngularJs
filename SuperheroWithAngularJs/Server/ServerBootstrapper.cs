using Nancy;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using Nancy.Conventions;

namespace SuperheroWithAngularJs.Server
{
    public class ServerBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Application"));

        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var store = new DocumentStore()
            {
                ConnectionStringName = "RavenDB"
            };

            store.Initialize();

            container.Register<IDocumentStore>(store);
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            var store = container.Resolve<IDocumentStore>();
            var documentSession = store.OpenSession();

            container.Register<IDocumentSession>(documentSession);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            pipelines.AfterRequest.AddItemToEndOfPipeline(
                (ctx) =>
                {
                    var documentSession = container.Resolve<IDocumentSession>();

                    if (ctx.Response.StatusCode != HttpStatusCode.InternalServerError)
                    {
                        documentSession.SaveChanges();
                    }

                    documentSession.Dispose();
                });
        }

    }
}