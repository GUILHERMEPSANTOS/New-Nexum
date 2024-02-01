using Microsoft.AspNetCore.Http.HttpResults;
using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Core.DomainObjects
{
    public static class DomainErrors
    {
        public static class UrlErrors
        {
            public static readonly Error Empty = new(
                "Url.Empty",
                "Url is empty"
                , ErrorType.Validation);


            public static readonly Error InvalidFormat = new(
                "Url.InvalidFormat",
                "Invalid URL format."
                , ErrorType.Validation);
        }
    }
}
