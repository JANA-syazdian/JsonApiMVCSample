using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;
using JsonApiMVCSample.Framework;
using JsonApiSampleDomain.Model;
using JsonApiSampleDomain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonApiMVCSample.Controllers
{
	[ApiController]
	[Route("authors")]
	public class HomeController : ControllerBase
	{
		AuthorCorseRepo _repository;
		protected IApiServiceContext ApiServiceContext { get; }
		public HomeController(IApiServiceContext apiServiceContext)
        {
			_repository = new AuthorCorseRepo();
			this.ApiServiceContext = apiServiceContext;

		}
		[HttpGet]
		public ActionResult<IEnumerable<Author>> GetAuthors()
		{
			var apiEntryPoint = new HomeDocument
			{
				Message = @"Entry point into the Blogging Hypermedia API powered by JsonApiFramework [Server]." + " " +
							 "Implements the JSON API 1.0 specification.",
				Version = "1.0"

			};

			var authorsFromRepo = _repository.GetAuthors();
			var courses = _repository.GetCourses1();
			var currentRequestUri = this.GetCurrentRequestUri();

			using var documentContext = this.ApiServiceContext.CreateApiDocumentContext();
			var document = documentContext
				.NewDocument(currentRequestUri)
					.ResourceCollection(authorsFromRepo)
						.Relationships()
							.Relationship("author")
				.RelationshipEnd()
			.RelationshipsEnd()
			 .Relationships()
							.AddRelationship("course", new[] { Keywords.Related }) 
				.RelationshipsEnd()
			.ResourceCollectionEnd()
				.WriteDocument();


			// Convert document to JSON and output to the console.
			var jsonSerializerSettings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				Converters = new List<JsonConverter> { new StringEnumConverter() }
			};
			var json = document.ToJson(jsonSerializerSettings);

			return Ok(json);
		}
	}
}
