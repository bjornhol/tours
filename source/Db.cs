using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace Tours
{
    public static class Db
    {
        private static IDocumentStore _store;

        public static IDocumentStore Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new EmbeddableDocumentStore() { ConnectionStringName = "Local" };
                }

                return _store.Initialize();
            }
        }
    }
}