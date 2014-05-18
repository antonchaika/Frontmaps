using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JsonConverter = FrontMaps.Utils.JsonConverter;

namespace FrontMaps.Models
{
    public class GeoActionResult : JsonResult
    {
        private readonly JsonConverter jsonConverter = new JsonConverter();

        public GeoActionResult(object data)
        {
            this.Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                response.Write(jsonConverter.Serialize(Data));
            }
        }
    }
}