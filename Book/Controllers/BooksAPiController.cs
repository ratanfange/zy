using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Book.Logic;
using Newtonsoft.Json;

namespace Book.Controllers
{
    public class BooksAPiController : ApiController
    {
        private BookLogic logic = new BookLogic();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// get book list
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetBookList")]
        public HttpResponseMessage GetBookList()
        {
            var list = logic.GetBooks();
            var json = JsonConvert.SerializeObject(list);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, json);
        }

        // POST api/<controller>
        //public string Post([FromBody]string value)
        //{
        //    var list = logic.GetBooks(value);
        //    return "value";
        //}

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}