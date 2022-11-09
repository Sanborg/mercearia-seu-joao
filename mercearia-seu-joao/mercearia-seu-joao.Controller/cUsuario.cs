using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cUsuario
{
    public static Usuario BuscarDadosUsuario(string email, string senha)
    {
        return ConsultasUsuario.Login(email, senha);
    }
}

