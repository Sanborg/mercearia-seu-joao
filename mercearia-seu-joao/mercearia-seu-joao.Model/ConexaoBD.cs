﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ConexaoBD
{

    public static MySqlConnectionStringBuilder Conexao
    {
        get
        {
            return new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "",
                Database = "bd_mercearia_seu_joao"
            };
        }
        private set { }
    }






}
