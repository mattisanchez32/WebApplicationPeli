﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationPeli.Models
{
	public class Actor
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Foto { get; set; }
	}
}