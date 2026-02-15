using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace E_Ticaret_Otomasyonu
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-TAHVRBC\SQLEXPRESS;Initial Catalog=E_Ticaret_Otomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
                

        }

    }
}
