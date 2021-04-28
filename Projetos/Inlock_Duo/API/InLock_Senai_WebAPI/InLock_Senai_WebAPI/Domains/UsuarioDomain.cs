using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Domains
{
    public class UsuarioDomain
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public int idUsuario { get; set; }
        /// <summary>
        /// Email do usuário
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// senha do usuário
        /// </summary>
        public string senha { get; set; }
        /// <summary>
        /// Id do tipo de usuário
        /// </summary>
        public int idTiposUsuario { get; set; }
    }
}
