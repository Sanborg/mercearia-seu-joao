﻿using System;
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
    public int preco_unitario { get; set; }
    public string fornecedor { get; set; }

}
