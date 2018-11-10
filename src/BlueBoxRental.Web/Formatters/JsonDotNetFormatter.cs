using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlueBoxRental.Web.Formatters
{
    public class JsonDotNetFormatter : MediaTypeFormatter
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings();

        public JsonDotNetFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedEncodings.Add(System.Text.Encoding.UTF8);
        }

        public JsonDotNetFormatter(JsonSerializerSettings jsonSerializerSettings) : this()
        {
            _jsonSerializerSettings = jsonSerializerSettings ?? new JsonSerializerSettings();
        }

        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content,
            IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                // Create a serializer 
                JsonSerializer serializer = JsonSerializer.Create(_jsonSerializerSettings);
                StreamReader streamReader = new StreamReader(readStream, Encoding.UTF8);
                JsonTextReader jsonTextReader = new JsonTextReader(streamReader);

                return serializer.Deserialize(jsonTextReader, type);
            });
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                // Create a serializer
                JsonSerializer serializer = JsonSerializer.Create(_jsonSerializerSettings);
                StreamWriter streamWriter = new StreamWriter(writeStream, Encoding.UTF8);
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter) { CloseOutput = false })
                {
                    serializer.Serialize(jsonTextWriter, value, type);
                    jsonTextWriter.Flush();
                }
            });
        }
    }
}
