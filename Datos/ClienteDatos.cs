using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteDatos : Entity
    {
        public ClienteDatos()
        {

        }

        public List<Cliente> obtenerClienteById(int id)
        {
            List<Cliente> lstClientes = new List<Cliente>();
            string consulta = "SELECT * FROM Clientes where id_cliente = " + id.ToString();
            DataTable tabla = conexion.executeQuery(ConfigurationManager.ConnectionStrings["sqlConn"].ToString(), consulta);
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Cliente cliente = Mapear(tabla.Rows[i]);
                lstClientes.Add(cliente);
            }

            return lstClientes;
        }

        public Cliente Mapear(DataRow pCliente)
        {
            Cliente cliente = new Cliente();
            cliente.id_cliente = Convert.ToInt32(pCliente["id_cliente"].ToString());
            cliente.tipo_doc = Convert.ToInt32(pCliente["tipo_doc"].ToString());
            cliente.nro_doc = pCliente["nro_documento"].ToString();

            return cliente;
        }
    }
}
