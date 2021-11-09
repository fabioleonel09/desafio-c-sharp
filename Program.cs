using System;
//Bibliotecas inseridas
using System.Collections.Generic;
using System.Linq;

namespace controleFuncionarios
{
    public class Program
    {
        
        static List<Registro> listaRegistros; //define a lista para os registros
        
        static void Main(string[] args)
        {
            Registro[] listaRegistros = new Registro[14]; //instancia a base de dados

            listaRegistros[0] = new Registro { Data = new DateTime(2019, 10, 1), Hora = DateTime.MinValue.Hour.ToString("08"), Minuto = DateTime.MinValue.Minute.ToString("01"), Funcionario = "João" }; 
            listaRegistros[1] = new Registro { Data = new DateTime(2019, 10, 1), Hora = DateTime.MinValue.Hour.ToString("07"), Minuto = DateTime.MinValue.Minute.ToString("56"), Funcionario = "Maria" }; 
            listaRegistros[2] = new Registro { Data = new DateTime(2019, 10, 1), Hora = DateTime.MinValue.Hour.ToString("12"), Minuto = DateTime.MinValue.Minute.ToString("02"), Funcionario = "João" }; 
            listaRegistros[3] = new Registro { Data = new DateTime(2019, 10, 1), Hora = DateTime.MinValue.Hour.ToString("12"), Minuto = DateTime.MinValue.Minute.ToString("01"), Funcionario = "Maria" }; 
            listaRegistros[4] = new Registro { Data = new DateTime(2019, 10, 1), Hora = DateTime.MinValue.Hour.ToString("13"), Minuto = DateTime.MinValue.Minute.ToString("01"), Funcionario = "João" }; 
            listaRegistros[5] = new Registro { Data = new DateTime(2019, 10, 1), Hora = DateTime.MinValue.Hour.ToString("12"), Minuto = DateTime.MinValue.Minute.ToString("59"), Funcionario = "Maria" }; 
            listaRegistros[6] = new Registro { Data = new DateTime(2019, 10, 1), Hora = DateTime.MinValue.Hour.ToString("18"), Minuto = DateTime.MinValue.Minute.ToString("02"), Funcionario = "João" }; 
            listaRegistros[7] = new Registro { Data = new DateTime(2019, 10, 1), Hora = DateTime.MinValue.Hour.ToString("17"), Minuto = DateTime.MinValue.Minute.ToString("58"), Funcionario = "Maria" }; 
            listaRegistros[8] = new Registro { Data = new DateTime(2019, 10, 2), Hora = DateTime.MinValue.Hour.ToString("08"), Minuto = DateTime.MinValue.Minute.ToString("09"), Funcionario = "João" }; 
            listaRegistros[9] = new Registro { Data = new DateTime(2019, 10, 2), Hora = DateTime.MinValue.Hour.ToString("12"), Minuto = DateTime.MinValue.Minute.ToString("01"), Funcionario = "João" }; 
            listaRegistros[10] = new Registro { Data = new DateTime(2019, 10, 2), Hora = DateTime.MinValue.Hour.ToString("12"), Minuto = DateTime.MinValue.Minute.ToString("54"), Funcionario = "João" }; 
            listaRegistros[11] = new Registro { Data = new DateTime(2019, 10, 2), Hora = DateTime.MinValue.Hour.ToString("12"), Minuto = DateTime.MinValue.Minute.ToString("58"), Funcionario = "Maria" }; 
            listaRegistros[12] = new Registro { Data = new DateTime(2019, 10, 2), Hora = DateTime.MinValue.Hour.ToString("18"), Minuto = DateTime.MinValue.Minute.ToString("02"), Funcionario = "João" }; 
            listaRegistros[13] = new Registro { Data = new DateTime(2019, 10, 2), Hora = DateTime.MinValue.Hour.ToString("18"), Minuto = DateTime.MinValue.Minute.ToString("30"), Funcionario = "Maria" };

            Console.WriteLine("********************************************************************");
            Console.WriteLine("                  % SISTEMA DE CONTROLE DE PONTO %                  ");
            Console.WriteLine("********************************************************************");
            Console.WriteLine("====================================================================");
            Console.WriteLine("\n Criando novo Array:"); //printa na tela o título
            Console.WriteLine("====================================================================");

            Registro[] ListaArray = listaRegistros.ToArray(); //cria um novo array

            foreach (Registro r in ListaArray.OrderBy(r => r.Funcionario)) //cria as condições para o loop e ordena por nome do funcionário
            {   
                //printa na tela a base de dados apenas organizada por nomes de funcionários

                Console.WriteLine(" Funcionário: " + r.Funcionario + ", data: " + r.Data.ToShortDateString() + ", horário: " + r.Hora + ":" + r.Minuto + ".");         
            }

            //aqui estão as condições para os cálculos de horas dos funcionários
            Console.WriteLine("====================================================================");
            Console.WriteLine("\n Total de horas trabalhadas: ");//printa na tela o título
            Console.WriteLine("====================================================================");

            // *** PARA O FUNCIONÁRIO JOÃO, 01/10/2019 ***

            //para as horas
            // hora de entrada 
            TimeSpan HorarioEntradaManha = TimeSpan.FromHours(8);

            // hora de saida
            TimeSpan HorarioSaidaManha = TimeSpan.FromHours(12);
            
            //total na manhã
            var JornadaTrabalhoManha = HorarioSaidaManha.Subtract(HorarioEntradaManha);

            // hora de entrada 
            TimeSpan HorarioEntradaTarde = TimeSpan.FromHours(13);

            // hora de saida
            TimeSpan HorarioSaidaTarde = TimeSpan.FromHours(18);

            //total na tarde
            var JornadaTrabalhoTarde = HorarioSaidaTarde.Subtract(HorarioEntradaTarde);

            //total de horas trabalhadas neste dia
            var JornadaTrabalhoTotalHoras = JornadaTrabalhoManha + JornadaTrabalhoTarde;
            
            //para os minutos
            // minutos de entrada 
            TimeSpan MinutoEntradaManha = TimeSpan.FromMinutes(1);

            // minutos de saida
            TimeSpan MinutoSaidaManha = TimeSpan.FromMinutes(2);

            //total na manhã
            var JornadaTrabalhoManhaMinutos = MinutoSaidaManha.Subtract(MinutoEntradaManha);

            // minutos de entrada na tarde
            TimeSpan MinutoEntradaTarde = TimeSpan.FromMinutes(1);

            // hora de saida
            TimeSpan MinutoSaidaTarde = TimeSpan.FromMinutes(2);

            //total minutos na tarde
            var JornadaTrabalhoTardeMinutos = MinutoSaidaTarde.Subtract(MinutoEntradaTarde);

            //total de minutos trabalhados neste dia
            var JornadaTrabalhoTotalMinutos = JornadaTrabalhoManhaMinutos + JornadaTrabalhoTardeMinutos;

            //printa na tela o resultado para o funcionário 'João', dia 01/10/2019
            if (JornadaTrabalhoTotalMinutos.Minutes < 0) //caso o cálculo dê negativo nos minutos
            {
                Console.WriteLine(" Funcionário: João, data: 01/10/2019, total = " + Convert.ToString(JornadaTrabalhoTotalHoras.TotalHours) + " horas e 0 minutos.");
            }
            else
            {
                Console.WriteLine(" Funcionário: João, data: 01/10/2019, total = " + Convert.ToString(JornadaTrabalhoTotalHoras.TotalHours) + " horas e " + Convert.ToString(JornadaTrabalhoTotalMinutos.Minutes) + " minutos.");
            }
            

            // *** PARA O FUNCIONÁRIO JOÃO, 02/10/2019 ***

            //para as horas
            // hora de entrada 
            TimeSpan HorarioEntradaManha1 = TimeSpan.FromHours(8);

            // hora de saida
            TimeSpan HorarioSaidaManha1 = TimeSpan.FromHours(12);

            //total na manhã
            var JornadaTrabalhoManha1 = HorarioSaidaManha1.Subtract(HorarioEntradaManha1);

            // hora de entrada 
            TimeSpan HorarioEntradaTarde1 = TimeSpan.FromHours(12);

            // hora de saida
            TimeSpan HorarioSaidaTarde1 = TimeSpan.FromHours(18);

            //total na tarde
            var JornadaTrabalhoTarde1 = HorarioSaidaTarde1.Subtract(HorarioEntradaTarde1);

            //total de horas trabalhadas neste dia
            var JornadaTrabalhoTotalHoras1 = JornadaTrabalhoManha1 + JornadaTrabalhoTarde1;

            //para os minutos
            // minutos de entrada 
            TimeSpan MinutoEntradaManha1 = TimeSpan.FromMinutes(9);

            // minutos de saida
            TimeSpan MinutoSaidaManha1 = TimeSpan.FromMinutes(1);

            //total na manhã
            var JornadaTrabalhoManhaMinutos1 = MinutoSaidaManha1.Subtract(MinutoEntradaManha1);

            // minutos de entrada na tarde
            TimeSpan MinutoEntradaTarde1 = TimeSpan.FromMinutes(54);

            // hora de saida
            TimeSpan MinutoSaidaTarde1 = TimeSpan.FromMinutes(2);

            //total minutos na tarde
            var JornadaTrabalhoTardeMinutos1 = MinutoSaidaTarde1.Subtract(MinutoEntradaTarde1);

            //total de minutos trabalhados neste dia
            var JornadaTrabalhoTotalMinutos1 = JornadaTrabalhoManhaMinutos1 + JornadaTrabalhoTardeMinutos1;

            //printa na tela o resultado para o funcionário 'João', dia 01/10/2019
            if (JornadaTrabalhoTotalMinutos1.Minutes < 0) //caso o cálculo dê negativo nos minutos
            {
                Console.WriteLine(" Funcionário: João, data: 02/10/2019, total = " + Convert.ToString(JornadaTrabalhoTotalHoras1.TotalHours) + " horas e 0 minutos.");
            }
            else
            {
                Console.WriteLine(" Funcionário: João, data: 02/10/2019, total = " + Convert.ToString(JornadaTrabalhoTotalHoras1.TotalHours) + " horas e " + Convert.ToString(JornadaTrabalhoTotalMinutos1.Minutes) + " minutos.");
            }
            
            // *** PARA A FUNCIONÁRIA MARIA, 01/10/2019 ***

            //para as horas
            // hora de entrada 
            TimeSpan HorarioEntradaManha2 = TimeSpan.FromHours(7);

            // hora de saida
            TimeSpan HorarioSaidaManha2 = TimeSpan.FromHours(12);

            //total na manhã
            var JornadaTrabalhoManha2 = HorarioSaidaManha2.Subtract(HorarioEntradaManha2);

            // hora de entrada 
            TimeSpan HorarioEntradaTarde2 = TimeSpan.FromHours(12);

            // hora de saida
            TimeSpan HorarioSaidaTarde2 = TimeSpan.FromHours(17);

            //total na tarde
            var JornadaTrabalhoTarde2 = HorarioSaidaTarde2.Subtract(HorarioEntradaTarde2);

            //total de horas trabalhadas neste dia
            var JornadaTrabalhoTotalHoras2 = JornadaTrabalhoManha2 + JornadaTrabalhoTarde2;

            //para os minutos
            // minutos de entrada 
            TimeSpan MinutoEntradaManha2 = TimeSpan.FromMinutes(56);

            // minutos de saida
            TimeSpan MinutoSaidaManha2 = TimeSpan.FromMinutes(1);

            //total na manhã
            var JornadaTrabalhoManhaMinutos2 = MinutoSaidaManha2.Subtract(MinutoEntradaManha2);

            // minutos de entrada na tarde
            TimeSpan MinutoEntradaTarde2 = TimeSpan.FromMinutes(59);

            // hora de saida
            TimeSpan MinutoSaidaTarde2 = TimeSpan.FromMinutes(58);

            //total minutos na tarde
            var JornadaTrabalhoTardeMinutos2 = MinutoSaidaTarde2.Subtract(MinutoEntradaTarde2);

            //total de minutos trabalhados neste dia
            var JornadaTrabalhoTotalMinutos2 = JornadaTrabalhoManhaMinutos2 + JornadaTrabalhoTardeMinutos2;

            //printa na tela o resultado para a funcionária 'Maria', dia 01/10/2019
            if (JornadaTrabalhoManhaMinutos2.Minutes < 0)//caso o cálculo dê negativo nos minutos
            {
                Console.WriteLine(" Funcionário: Maria, data: 01/10/2019, total = " + Convert.ToString(JornadaTrabalhoTotalHoras2.TotalHours) + " horas e 0 minutos.");
            }
            else
            {
                Console.WriteLine(" Funcionário: Maria, data: 01/10/2019, total = " + Convert.ToString(JornadaTrabalhoTotalHoras2.TotalHours) + " horas e " + Convert.ToString(JornadaTrabalhoTotalMinutos2.Minutes) + " minutos.");
            }

            // *** PARA A FUNCIONÁRIA MARIA, 02/10/2019 ***

            //para as horas
            // hora de entrada 
            TimeSpan HorarioEntradaTarde3 = TimeSpan.FromHours(12);

            // hora de saida
            TimeSpan HorarioSaidaTarde3 = TimeSpan.FromHours(18);

            //total na tarde
            var JornadaTrabalhoTarde3 = HorarioSaidaTarde3.Subtract(HorarioEntradaTarde3);

            //total de horas trabalhadas neste dia, somente à tarde
            var JornadaTrabalhoTotalHoras3 = JornadaTrabalhoTarde3;

            //para os minutos
            // minutos de entrada na tarde
            TimeSpan MinutoEntradaTarde3 = TimeSpan.FromMinutes(58);

            // hora de saida
            TimeSpan MinutoSaidaTarde3 = TimeSpan.FromMinutes(30);

            //total minutos na tarde
            var JornadaTrabalhoTardeMinutos3 = MinutoSaidaTarde3.Subtract(MinutoEntradaTarde3);

            //total de minutos trabalhados neste dia
            var JornadaTrabalhoTotalMinutos3 = JornadaTrabalhoTardeMinutos3;

            //printa na tela o resultado para a funcionária 'Maria', dia 02/10/2019
            if (JornadaTrabalhoTotalMinutos3.Minutes < 0)//caso o cálculo dê negativo nos minutos
            {
                Console.WriteLine(" Funcionário: Maria, data: 02/10/2019, total = " + Convert.ToString(JornadaTrabalhoTotalHoras3.TotalHours) + " horas e 0 minutos.");
            }
            else
            {
                Console.WriteLine(" Funcionário: Maria, data: 01/10/2019, total = " + Convert.ToString(JornadaTrabalhoTotalHoras3.TotalHours) + " horas e " + Convert.ToString(JornadaTrabalhoTotalMinutos3.Minutes) + " minutos.");
            }
            Console.WriteLine("====================================================================");
            Console.ReadKey();
        }
    }
}
