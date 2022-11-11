using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class Produto
{
    public int id { get; set; }
    public string nome { get; set; }
    public int quantidade { get; set; }
    public int precoUnitario { get; set; }
    public string fornecedor { get; set; }
    public DateTime dataHoraInclusao { get; set; }
    public DateTime dataHoraExclusao { get; set; }

}
