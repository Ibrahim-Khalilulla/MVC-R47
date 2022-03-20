using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_R47.Filters
{
    public class CompressAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Analyze the list of acceptable encodings
            var preferredEncoding = GetPreferredEncoding(filterContext.HttpContext.Request);
            // Compress the response accordingly
            var response = filterContext.HttpContext.Response;
            response.AppendHeader("Content-encoding", preferredEncoding.ToString());
            if (preferredEncoding == CompressionScheme.Gzip)
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
            if (preferredEncoding == CompressionScheme.Deflate)
                response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
            return;
        }

        private CompressionScheme GetPreferredEncoding(HttpRequestBase request)
        {
            var acceptableEncoding = request.Headers["Accept-Encoding"].ToLower();

            if (acceptableEncoding.Contains("gzip"))
                return CompressionScheme.Gzip;
            if (acceptableEncoding.Contains("deflate"))
                return CompressionScheme.Deflate;
            return CompressionScheme.Identity;
        }
        enum CompressionScheme
        {
            Gzip = 0,
            Deflate = 1,
            Identity = 2
        }

    }
}