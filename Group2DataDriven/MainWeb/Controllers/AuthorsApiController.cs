using BusinessLayer;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainWeb.Controllers
{
    public class AuthorsApiController : ApiController
    {
        // GET: api/AuthorsApi
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/AuthorsApi/5
        public AuthorViewModel Get(int id)
        {
            using (var authorProvider = new AuthorProvider(ConfigurationManager.ConnectionStrings["scifi-database"].ConnectionString))
            {
                var author = authorProvider.LoadAuthor(id, true);
                return AuthorViewModel.FromModel(author);
            }
        }

        // POST: api/AuthorsApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AuthorsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AuthorsApi/5
        public void Delete(int id)
        {
        }
    }
}
