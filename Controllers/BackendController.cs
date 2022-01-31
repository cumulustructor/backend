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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("NewResource")]
        public dynamic NewResource(string Cloud, string ResourceName)
        {
            string ClassId = "";
            switch (Cloud.ToLower())
            {
                case "azure":
                    ClassId = "MCD.Azure.Resources.Resource, schema";
                break;
            }
            dynamic ClassResource = null;
            Type CloudClass = Type.GetType(ClassId);
            Type ClassType = (from i in CloudClass.Assembly.ExportedTypes
                              where i.Namespace == CloudClass.Namespace && i.Name.ToLower() == ResourceName.ToLower()
                              select i).First();
            ClassResource = Activator.CreateInstance(ClassType);
            return ClassResource;
        }
    }
}