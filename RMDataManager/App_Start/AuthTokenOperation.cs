using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace RMDataManager.App_Start
{
	public class AuthTokenOperation : IDocumentFilter
	{
		/// <summary>
		/// Add new route to Swagger.After this implementation go to swagger config file
		/// </summary>
		/// <param name="swaggerDoc">Add one new Route</param>
		/// <param name="schemaRegistry"></param>
		/// <param name="apiExplorer"></param>
		public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
		{
			swaggerDoc.paths.Add("/token", new PathItem
			{
                //Type of command i.e. Get, Post, Put, Delete
				post = new Operation
				{
					//In which category we have to put the URL/route to
					tags = new List<string> { "Auth" },
					consumes = new List<string>
					{
						"application/x-www-urlencoded"
					},
					//Defination of 3 parameters
					parameters = new List<Parameter> {
						new Parameter
						{
							type="string",
							name="grant_type",
							required=true,
							@in="formData",
							@default="password"
							
						},
						new Parameter
						{
							type="string",
							name="username",
							required=false,
							@in="formData"
						},
						new Parameter
						{
							type="string",
							name="password",
							required=false,
							@in="formData"
						}
					}
				}

			});
		}
	}
}