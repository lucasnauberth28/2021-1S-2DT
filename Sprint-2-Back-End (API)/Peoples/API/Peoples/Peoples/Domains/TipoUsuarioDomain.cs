﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples.Domains
{
    public class TipoUsuarioDomain
    {
            public int idTipoUsuario { get; set; }
            [Required(ErrorMessage = "Permissão do usuário obrigatória!")]
            public string permissao { get; set; }
        }
}