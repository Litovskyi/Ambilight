using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ambilight.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;



        public static class Events
        {
            public const string GetAll = Base + "/events";

            public const string Get = Base + "/events{eventId}";

            public const string Update = Base + "/events{eventId}";

            public const string Delete = Base + "/events{eventId}";

            public const string Create = Base + "/events";
            
        }
    }
}
