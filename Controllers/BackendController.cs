using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MCD;

namespace backend.Controllers
{
    [ApiController]
    public class BackendController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("NewDesignDocument")]
        public MCD.DesignDocument NewDesignDocument(string Cloud)
        {
            MCD.DesignDocument DesignDocument = new();
            switch (Cloud.ToLower())
            {
                case "azure":
                    DesignDocument.Platform.Azure = new()
                    {
                        DeploymentLanguage = "",
                        Tenant = new()
                        {
                            displayName = "",
                            id = "",
                            domains = null,
                            Subscriptions = new()
                            {
                                new()
                                {
                                    displayName = "",
                                    id = "",
                                    Resources = new()
                                }
                            }
                        }
                    };
                    break;
            }
            return DesignDocument;
        }
    }
}