﻿namespace WebListTask.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public bool Completada { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
