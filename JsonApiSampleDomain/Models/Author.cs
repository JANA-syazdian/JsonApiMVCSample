using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JsonApiSampleDomain.Model
{
	public class Author
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Course> Courses { get; set; }
			= new List<Course>();
	}

	public class HomeDocument
	{
		public string Message { get; set; }
		public string Version { get; set; }
	}
}
