using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Domains
{
    public class TipoUsuarioDomain
    {
        /// <summary>
        /// Id que identifica o tipo do usuário
        /// </summary>
        public int idtiposUsuarios { get; set; }
        /// <summary>
        /// titulo do usuário
        /// </summary>
        public string titulo { get; set; }
    }
}
