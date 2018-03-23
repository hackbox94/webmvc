
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace WEBAPIServices
{

    public class WebApiServices<T> 
    {
        public HttpClient webclient = new HttpClient();
 
        public WebApiServices()
        {
            webclient.BaseAddress = new Uri("http://localhost:6833/api/");
            webclient.DefaultRequestHeaders.Clear();
            webclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
  
        }


        public List<T> GetData()
        {
            string node = typeof(T).Name;
            HttpResponseMessage response = webclient.GetAsync(node).Result;
            return response.Content.ReadAsJsonAsync<List<T>>().Result;
        }
        public T GetData(int id)
        {
            HttpResponseMessage response = webclient.GetAsync(typeof(T).Name + "/"+id.ToString()).Result;
            return response.Content.ReadAsJsonAsync<T>().Result;
        }
        public List<T> GetData(string nodedata)
        {
   
            HttpResponseMessage response = webclient.GetAsync(nodedata).Result;
            return response.Content.ReadAsJsonAsync<List<T>>().Result;

        }

        public bool PostData( T data)
        {
            HttpResponseMessage response = webclient.PostAsJsonAsync(typeof(T).Name, data).Result;
            return response.IsSuccessStatusCode;
        }
        public bool PostData(string nodedata, T data)
        {
            HttpResponseMessage response = webclient.PostAsJsonAsync(nodedata, data).Result;
            return response.IsSuccessStatusCode;
        }
        public bool PutData(string nodedata, T data)
        {
            HttpResponseMessage response = webclient.PutAsJsonAsync(nodedata, data).Result;
            return response.IsSuccessStatusCode;
        }
        private NameValueCollection ObjectToCollection(object objects)
        {

            NameValueCollection parameter = new NameValueCollection();


            Type type = objects.GetType();

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance |
                                                            BindingFlags.DeclaredOnly |
                                                            BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(objects, null) == null)
                {
                    parameter.Add(property.Name.ToString(), "");
                }
                else
                {
                    if (property.GetValue(objects, null).ToString() != "removeProp")
                    {
                        parameter.Add(property.Name.ToString(), property.GetValue(objects, null).ToString());
                    }
                }
            }

            return parameter;
        }
        public bool PutData(T data)
        {
            NameValueCollection parameter = ObjectToCollection(data);
            string node = typeof(T).Name + "/" +parameter[typeof(T).Name+"ID"];
            HttpResponseMessage response = webclient.PutAsJsonAsync(node, data).Result;
            return response.IsSuccessStatusCode;
        }
        public bool DeleteData(string nodedata, T data)
        {
            HttpResponseMessage response = webclient.DeleteAsync(nodedata).Result;
            return response.IsSuccessStatusCode;
        }
        public bool DeleteData(T data)
        {
            NameValueCollection parameter = ObjectToCollection(data);
            string node = typeof(T).Name + "/" + parameter[typeof(T).Name + "ID"];
            HttpResponseMessage response = webclient.DeleteAsync(node).Result;
            return response.IsSuccessStatusCode;
        }
    }
}
