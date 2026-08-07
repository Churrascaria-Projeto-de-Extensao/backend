using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace backend.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }

        public string Email { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    }
}
