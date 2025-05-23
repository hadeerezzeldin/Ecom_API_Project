using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Sharing
{
    public class EmailStringBody
    {

        public static string  send(string email, string token ,  string component , string message)
        {
            string encodeToken = Uri.EscapeDataString(token);
            return $@"
                <html>
                    <head>
                        <meta charset='utf-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Verification Email</title>
                    </head>
                    <body>
                        <h2>{message}</h2>
                        <a class='btn btn-primary d-block' href='http://localhost:4200/component?email={email}&token={encodeToken}'>{message}</a>
                    </body>
                </html>
                ";
        }
    }
}
