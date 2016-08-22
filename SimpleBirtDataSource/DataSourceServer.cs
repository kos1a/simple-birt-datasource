using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StandardLibrary.WCF;
using System.IO;

namespace SimpleBirtDataSource
{
    public class DataSourceServer : IDataSourceServer
    {

        public static SortedList<string, byte[]> dataCache = new SortedList<string, byte[]>();

        public Stream Get(string Uid)
        {
            lock (dataCache)
            {
                var result = new MemoryStream(dataCache[Uid]);
                return result;
            }
        }

        public GenericResponse<string> Put(GenericRequest<string> request)
        {
            GenericResponse<string> retVal = new GenericResponse<string>("");
            string key = Guid.NewGuid().ToString("N0");
            retVal.data = key;
            byte[] fileContent = Convert.FromBase64String(request.Data);

            lock (dataCache)
            {
                dataCache.Add(key, fileContent);
                retVal.aux = string.Format("Total number of files in cache: {0}", dataCache.Count);
                retVal.isOk = true;
            }

            return retVal;
        }
    }
}
