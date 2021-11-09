using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleFuncionarios
{
    public class Registro
    {
        //modificação da classe
        public Registro() { }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Minuto { get; set; }
        public string Funcionario { get; set; }

        public Registro (DateTime data, string hora, string minuto, string funcionario)
        {
            this.Data = data;
            this.Hora = hora;
            this.Minuto = minuto;
            this.Funcionario = funcionario;
        }
    }
}
