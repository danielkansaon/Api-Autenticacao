using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api_Autenticacao.Controllers.v1
{
    [Route("/publico/v1/credencial")]
    public class CredencialController : ControllerBase
    {
        #region Propriedades
        private static List<usuario> _usuarios = null;
        private static List<usuario> Usuarios
        {
            get
            {
                if (_usuarios == null)
                    _usuarios = new List<usuario>() { new usuario() { Login = "admin", Senha = "123" } };

                return _usuarios;
            }
        }
        #endregion

        /// <summary>
        /// Realiza uma autenticação
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("autenticacao")]
        public ActionResult Post([FromBody] usuario user)
        {
            if (Usuarios.Exists(x => x.Login == user.Login && x.Senha == user.Senha))            
                return Ok(true);

            return Unauthorized();
        }
    }
}