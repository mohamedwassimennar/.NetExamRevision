﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Client
    {
        [Key]
        public int Identifiant { get; set; }
        [Required(ErrorMessage ="Login obligatoire")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Photo { get; set; }
        public virtual Conseiller Conseiller { get; set; }
        public int ConseillerFk { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
