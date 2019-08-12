using MyFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstApi.Controllers
{
    public class UserPerfilController : ApiController
    {
        private ApiContext db = new ApiContext();

        [HttpPost]
        public IHttpActionResult CreateUserAndPerfil([FromBody]Perfil perfil)
        {
            var dbTransaction = db.Database.BeginTransaction();

            try
            {
                Perfil usertransaction = new Perfil();
            }
            catch(Exception)
            {

            }

            return CreatedAtRoute("DefaultApi", new { id = perfil.Id }, perfil); ;
        }
    }
}
