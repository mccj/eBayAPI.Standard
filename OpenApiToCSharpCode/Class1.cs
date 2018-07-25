using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenApiToCSharpCode
{
    public class Class1
    {
        public OpenApi2 GetOpenApi2(string jsonDoc)
        {
            var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(jsonDoc);
            var openApi = new OpenApi2
            {
                BasePath = jsonObj.Value<string>("basePath"),
                Host = jsonObj.Value<string>("host"),
                Swagger = jsonObj.Value<string>("swagger"),
                Schemes = jsonObj["schemes"]?.ToObject<string[]>(),
                Consumes = jsonObj["consumes"]?.ToObject<string[]>(),
                Produces = jsonObj["produces"]?.ToObject<string[]>(),
                Info = jsonObj["info"]?.ToObject<Info>(),
                Tags = jsonObj["tags"]?.ToObject<InfoTag[]>(),
                ExternalDocs = jsonObj["externalDocs"]?.ToObject<ExternalDoc>(),
                SecurityDefinitions = jsonObj["securityDefinitions"]?.ToObject<SecurityDefinitions>(),
                Paths = jsonObj["paths"]?.OfType<Newtonsoft.Json.Linq.JProperty>().Select(f => new Path
                {
                    Url = f.Name,
                    Methods = f.Value.OfType<Newtonsoft.Json.Linq.JProperty>().Select(f_ => new Method
                    {
                        Name = f_.Name,
                        Tags = f_.Value["tags"]?.ToObject<string[]>(),
                        Consumes = f_.Value["consumes"]?.ToObject<string[]>(),
                        Produces = f_.Value["produces"]?.ToObject<string[]>(),
                        Security = f_.Value["security"]?.OfType<Newtonsoft.Json.Linq.JObject>().SelectMany(f1 => f1.OfType<Newtonsoft.Json.Linq.JProperty>()).Select(f1 => new MethodSecurity
                        {
                            Name = f1.Name,
                            Urls = f1.Value?.ToObject<string[]>()
                        }).ToArray(),
                        Schemes = f_.Value["schemes"]?.ToObject<string[]>(),
                        Deprecated = f_.Value["deprecated"]?.ToObject<bool>(),
                        Summary = f_.Value.Value<string>("summary"),
                        Description = f_.Value.Value<string>("description"),
                        OperationId = f_.Value.Value<string>("operationId"),
                        ExternalDocs = f_.Value["externalDocs"]?.ToObject<ExternalDoc>(),
                        Parameters = f_.Value["parameters"]?.Select(f1 => new Parameter
                        {
                            Name = f1.Value<string>("name"),
                            In = f1.Value<string>("in"),
                            Description = f1.Value<string>("description"),
                            Required = f1.Value<bool>("required"),
                            Type = f1.Value<string>("type"),
                            CollectionFormat = f1.Value<string>("collectionFormat"),
                            //Items = f1["items"]?.ToObject<Items>()
                            Schema = new Schema
                            {
                                Ref = f1["schema"]?.Value<string>("$ref"),
                                Type = f1["schema"]?.Value<string>("type"),
                                Items = new Items
                                {
                                    CollectionFormat = f1["schema"]?["items"]?.Value<string>("collectionFormat"),
                                    Default = f1["schema"]?["items"]?.Value<string>("default"),
                                    Enum = f1["schema"]?["items"]?["enum"]?.ToObject<string[]>(),
                                    Format = f1["schema"]?["items"]?.Value<string>("format"),
                                    Ref = f1["schema"]?["items"]?.Value<string>("$ref"),
                                    Type = f1["schema"]?["items"]?.Value<string>("type")
                                }
                            },
                            Items = new Items
                            {
                                CollectionFormat = f1["items"]?.Value<string>("collectionFormat"),
                                Default = f1["items"]?.Value<string>("default"),
                                Enum = f1["items"]?["enum"]?.ToObject<string[]>(),
                                Format = f1["items"]?.Value<string>("format"),
                                Ref = f1["items"]?.Value<string>("$ref"),
                                Type = f1["items"]?.Value<string>("type")
                            }
                        }).ToArray(),
                        Responses = f_.Value["responses"].OfType<Newtonsoft.Json.Linq.JProperty>().Select(f1 => new Response
                        {
                            Code = f1.Name,
                            Description = f1.Value.Value<string>("description"),
                            Schema = new Schema
                            {
                                Ref = f1.Value["schema"]?.Value<string>("$ref"),
                                Type = f1.Value["schema"]?.Value<string>("type"),
                                Items = new Items
                                {
                                    CollectionFormat = f1.Value["schema"]?["items"]?.Value<string>("collectionFormat"),
                                    Default = f1.Value["schema"]?["items"]?.Value<string>("default"),
                                    Enum = f1.Value["schema"]?["items"]?["enum"]?.ToObject<string[]>(),
                                    Format = f1.Value["schema"]?["items"]?.Value<string>("format"),
                                    Ref = f1.Value["schema"]?["items"]?.Value<string>("$ref"),
                                    Type = f1.Value["schema"]?["items"]?.Value<string>("type")
                                }
                            }
                        }).ToArray()
                    }).ToArray(),
                }).ToArray(),
                Definitions = jsonObj["definitions"]?.OfType<Newtonsoft.Json.Linq.JProperty>().Select(f => new Definition
                {
                    Name = f.Name,
                    Type = f.Value.Value<string>("type"),
                    Description = f.Value.Value<string>("description"),
                    Properties = f.Value["properties"].OfType<Newtonsoft.Json.Linq.JProperty>().Select(f1 => new Property
                    {
                        Name = f1.Name,
                        Type = f1.Value.Value<string>("type"),
                        Ref = f1.Value.Value<string>("$ref"),
                        Description = f1.Value.Value<string>("description"),
                        Enum = f1.Value["enum"]?.ToObject<string[]>(),
                        Xml = f1.Value["xml"]?.ToObject<Xml>(),
                        //Items = f1.Value["items"]?.ToObject<Items>()
                        Items = new Items
                        {
                            CollectionFormat = f1.Value["items"]?.Value<string>("collectionFormat"),
                            Default = f1.Value["items"]?.Value<string>("default"),
                            Enum = f1.Value["items"]?["enum"]?.ToObject<string[]>(),
                            Format = f1.Value["items"]?.Value<string>("format"),
                            Ref = f1.Value["items"]?.Value<string>("$ref"),
                            Type = f1.Value["items"]?.Value<string>("type")
                        }
                    }).ToArray()
                }).ToArray()
            };
            return openApi;
        }
        public string GetClientCode(System.Tuple<string, string, string, string>[] doc, string ns, string clientName)
        {
            return string.Join("\r\n", new[] {
                $"namespace {ns} {{",
        $"public partial class {clientName}{{",
            string.Join("\r\n",  doc.Select(f=>$"public {f.Item1}.{f.Item2} {f.Item3} {{ get; set; }} = new {f.Item1}.{f.Item2}(\"{f.Item4}\");")),
            "private void Setting(Action<Api.Client.ApiBase> execute){",
                  string.Join("\r\n",  doc.Select(f=>$"execute({f.Item3});")),
            "}",
        "}",
    "}"
});
        }
        public string GetMethodCode(OpenApi2 openApi, string ns, string className)
        {
            var 缩进 = "\t";
            var ddddddd = string.Format("public class {0} : Api.Client.ApiBase{{\r\n" +
            //"public {0}() : base() {{ }}",
            "public {0}(Api.Client.ApiClient apiClient = null) : base(apiClient) {{ }}\r\n" +
            "public {0}(string basePath) : base(basePath) {{ }}\r\n" +
                "{1}\r\n}}", className, 缩进 + string.Join("\r\n" + 缩进, openApi.Paths.SelectMany(f => f.Methods.Select(f1 => new { Url = f.Url, Method = f1 })).OrderBy(f => f.Method.OperationId).Select(f => string.Join("\r\n", new[] {

                    "/// <summary>",
                缩进+$"///  {f.Method?.Description}",
                缩进+"/// </summary>",
                缩进+string.Join("\r\n"+缩进, f.Method?.Parameters?.Select(f1=>$"/// <param name=\"{f1.Name.小驼峰命名()}\">{f1.Description}</param> ")),
                缩进+$"/// <returns>{getType(f.Method?.Responses?.FirstOrDefault(f1=>f1.Code=="200")?.Schema)}</returns>",
                    缩进+$"public {getType(f.Method?.Responses?.FirstOrDefault(f1=>f1.Code=="200")?.Schema)} {f.Method?.OperationId?.大驼峰命名()}({string.Join(",", f.Method?.Parameters?.OrderBy(f1=>f1.Required,new 数组义排序<bool>(new[]{ true,false}))?.ThenBy(f1=>f1.In,new 数组义排序<string>(new[]{ "header", "path", "body", "query","formData" }))?.ThenBy(f1=>f1.Name).Select(f1=>$"{(f1.Schema?.Type !=null?getType(f1.Schema):getType(f1.Type,f1.Schema?.Ref,f1.Items,true,"Models."))} {f1.Name.小驼峰命名()}"+(f1.Required?"":" = null")))}){{",
                    string.Join("\r\n",f.Method?.Parameters?.Where(f1=>f1.Required).Select(f1=>$"// verify the required parameter '{f1.Name.小驼峰命名()}' is set\r\nif ({f1.Name.小驼峰命名()} == null) throw new Api.Client.ApiException(400, \"Missing required parameter '{f1.Name.小驼峰命名()}' when calling {f.Method?.OperationId.大驼峰命名()}\");")),
                    "",
                    缩进+缩进+$"var path = \"{f.Url}\";",
                    缩进+缩进+"path = path.Replace(\"{format}\", \"json\");",
                    缩进+缩进+string.Join("\r\n"+缩进+缩进,f.Method?.Parameters?.Where(f1=>f1.In=="path").Select(f1=>$"path = path.Replace(\"{{\" + \"{f1.Name}\" + \"}}\", ApiClient.ParameterToString({f1.Name.小驼峰命名()}));")),
                    "",
                    缩进+缩进+"var queryParams = new Dictionary<String, String>();",
                    缩进+缩进+"var headerParams = new Dictionary<String, String>();",
                    缩进+缩进+"var formParams = new Dictionary<String, String>();",
                    缩进+缩进+"var fileParams = new Dictionary<String, FileParameter>();",
                    缩进+缩进+"String postBody = null;",
                    "",
                    缩进+缩进+string.Join("\r\n"+缩进+缩进,f.Method?.Parameters?.Where(f1=>f1.In=="body").Select(f1=>$"postBody = ApiClient.Serialize({f1.Name.小驼峰命名()}); // http {f1.Name.小驼峰命名()} (model) parameter")),
                    缩进+缩进+string.Join("\r\n"+缩进+缩进,f.Method?.Parameters?.Where(f1=>f1.In=="query").Select(f1=>$"if ({f1.Name.小驼峰命名()} != null) queryParams.Add(\"{f1.Name}\", ApiClient.ParameterToString({f1.Name.小驼峰命名()})); // query parameter")),
                    缩进+缩进+string.Join("\r\n"+缩进+缩进,f.Method?.Parameters?.Where(f1=>f1.In=="header").Select(f1=>$"if ({f1.Name.小驼峰命名()} != null) headerParams.Add(\"{f1.Name}\", ApiClient.ParameterToString({f1.Name.小驼峰命名()})); // header parameter")),
                    缩进+缩进+string.Join("\r\n"+缩进+缩进,f.Method?.Parameters?.Where(f1=>f1.In=="formData"&&f1.Type!="type").Select(f1=>$"if ({f1.Name.小驼峰命名()} != null) formParams.Add(\"{f1.Name}\", ApiClient.ParameterToString({f1.Name.小驼峰命名()})); // form parameter")),
                    缩进+缩进+string.Join("\r\n"+缩进+缩进,f.Method?.Parameters?.Where(f1=>f1.In=="formData"&&f1.Type=="type").Select(f1=>$"if ({f1.Name.小驼峰命名()} != null) fileParams.Add(\"{f1.Name}\", ApiClient.ParameterToFile({f1.Name.小驼峰命名()})); // file parameter")),
                    "",
                    缩进+缩进+"// authentication setting, if any",
                    缩进+缩进+$"var authSettings = new String[] {{ {(f.Method?.Security?.Length>0?("\""+string.Join("\",\"", f.Method?.Security?.Select(ff=>ff.Name))+"\""):"")}}};",
                    "",
                    缩进+缩进+"// make the HTTP request",
                    缩进+缩进+$"var response = (IRestResponse)ApiClient.CallApi(path, Method.{f.Method?.Name?.ToUpper()}, queryParams, postBody, headerParams, formParams, fileParams, authSettings);",
                    "",
                    缩进+缩进+"if (((int)response.StatusCode) >= 400)",
                    缩进+缩进+$"    throw new Api.Client.ApiException((int)response.StatusCode, \"Error calling {f.Method?.OperationId?.大驼峰命名()}: \" + response.Content, response.Content);",
                    缩进+缩进+"else if (((int)response.StatusCode) == 0)",
                    缩进+缩进+$"    throw new Api.Client.ApiException((int)response.StatusCode, \"Error calling {f.Method?.OperationId?.大驼峰命名()}: \" + response.ErrorMessage, response.ErrorMessage);",
                    "",
                    缩进+缩进+$"return {(f.Method?.Responses?.FirstOrDefault(f1=>f1.Code=="200")!=null?$"({getType(f.Method?.Responses?.FirstOrDefault(f1=>f1.Code=="200")?.Schema)}) ApiClient.Deserialize(response.Content, typeof({getType(f.Method?.Responses?.FirstOrDefault(f1=>f1.Code=="200")?.Schema)}), response.Headers)":"")};",
                    缩进+"}"
            }))));
            return $"namespace {ns} {{\r\n" + ddddddd + "\r\n}";
        }
        public string GetModelCode(OpenApi2 openApi, string ns)
        {
            var 缩进 = "\t";
            var ddddddd =
                缩进 + string.Join("\r\n" + 缩进, openApi.Definitions.Select(f => string.Join("\r\n" + 缩进, new[] {
                        "/// <summary>",
                        $"/// {f.Description}",
                        "/// </summary>",
                        "[DataContract]",
                        $"public class {f.Name} {{",
                       缩进+string.Join("\r\n"+ 缩进+ 缩进,  f.Properties.Select(f1=>string.Join("\r\n"+ 缩进+ 缩进, new[]{
                            "/// <summary>",
                            $"/// {f1.Description}",
                            "/// </summary>",
                            $"/// <value>{f1.Description}</value>",
                            $"[DataMember(Name=\"{f1.Name}\", EmitDefaultValue=false)]",
                            $"[JsonProperty(PropertyName = \"{f1.Name}\")]",
                            $"public {getType(f1.Type,f1.Ref,f1.Items,true)} {重命名属性名称(f1.Name.大驼峰命名(),f.Name)} {{ get; set; }}"
            }))),

                          缩进+"/// <summary>",
                          缩进+"/// Get the string presentation of the object",
                          缩进+"/// </summary>",
                          缩进+"/// <returns>String presentation of the object</returns>",
                缩进+"public override string ToString() {",
                缩进+缩进+"var sb = new StringBuilder();",
                缩进+缩进+"sb.Append(\"class CategoryDistribution {\\n\");",
                              缩进+缩进+string.Join("\r\n"+缩进+缩进+缩进,  f.Properties.Select(f1=>
                              $"sb.Append(\"  {重命名属性名称(f1.Name.大驼峰命名(),f.Name)}: \").Append({重命名属性名称(f1.Name.大驼峰命名(),f.Name)}).Append(\"\\n\");"
                              )),
                缩进+缩进+"sb.Append(\"}\\n\");",
                缩进+缩进+"return sb.ToString();",
                缩进+"}",

                          缩进+"/// <summary>",
                          缩进+"/// Get the JSON string presentation of the object",
                          缩进+"/// </summary>",
                          缩进+"/// <returns>JSON string presentation of the object</returns>",
                    缩进+"public string ToJson() {",
                    缩进+缩进+"return JsonConvert.SerializeObject(this, Formatting.Indented);",
                    缩进+"}",

                    $"}}"
            })));
            return $"namespace {ns}.Models {{\r\n" + ddddddd + "\r\n}";
        }
        private System.Collections.Generic.Dictionary<string, string> GetMarkdownFile(OpenApi2 openApi, string ns)
        {
            var ddd = openApi.Definitions.Select(f => new
            {
                Name = f.Name,
                内容 = string.Join("\r\n", new[] {
                        $"# {ns}.Models.{f.Name}",
                        "## Properties",
                        "",
        "Name | Type | Description | Notes",
        "------------ | ------------- | ------------- | -------------",
        string.Join("\r\n", f.Properties.Select(f1=>$"**{f1.Name}** | **{f1.Type}** | {f1.Description} | [optional] ")),
        "",
        "[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)"
                    })
            }).ToArray(); ;
            return ddd.ToDictionary(f => f.Name, f => f.内容);
        }
        private string 重命名属性名称(string 属性名称, string 类名称)
        {
            if (属性名称.Trim().Equals(类名称.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return "_" + 属性名称;
            }
            else
            {
                return 属性名称;
            }
        }
        private string getType(Schema schema)
        {
            if (schema == null)
            {
                return "void";
            }
            return getType(schema.Type, schema.Ref, schema.Items, true, "Models.");
        }
        private string getType(string type, string _ref, Items items, bool iss, string 模块命名空间 = null)
        {
            if (string.IsNullOrWhiteSpace(type) && string.IsNullOrWhiteSpace(_ref))
            {
                return "void";
            }
            switch (type)
            {
                case null:
                case "":
                    return 模块命名空间 + _ref.Replace("#/definitions/", "");
                case "integer":
                    return "int" + (iss ? "?" : "");
                case "boolean":
                    return "bool" + (iss ? "?" : "");
                case "file":
                    return "System.IO.Stream";
                case "array":
                    return (!string.IsNullOrWhiteSpace(items?.Type) ? items.Type + "[]" : 模块命名空间 + items.Ref.Replace("#/definitions/", "") + "[]");
                default:
                    return type;
            }
        }
        public class 数组义排序<T> : IComparer<T>
        {
            Dictionary<T, int> d = null;
            public 数组义排序(T[] ts)
            {// new[] { "query", "path" }
                d = new Dictionary<T, int>();
                for (int i = 0; i < ts.Length; i++)
                {
                    d.Add(ts[i], i);
                }
            }
            public int Compare(T x, T y)
            {
                return d[x] - d[y];
            }
        }
    }
}
