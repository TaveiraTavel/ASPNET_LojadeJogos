using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web02LojadeJogos.Models;
using MySql.Data.MySqlClient;

namespace Web02LojadeJogos.Repositorio
{
    public class Acoes
    {
        Conexao con = new Conexao();
        MySqlCommand query = new MySqlCommand();

        public void CadastrarCliente(Cliente cliente)
        {
            MySqlCommand query = new MySqlCommand("CALL CadastrarCliente(@cliNome, @cliCpf, @cliNasc, @cliEmail, @cliCelular, @cliEndereco)", con.ConectarBD());
                query.Parameters.Add("@cliNome", MySqlDbType.VarChar).Value = cliente.CliNome;
                query.Parameters.Add("@cliCpf", MySqlDbType.VarChar).Value = cliente.CliCpf;
                query.Parameters.Add("@cliNasc", MySqlDbType.VarChar).Value = cliente.CliNasc;
                query.Parameters.Add("@cliEmail", MySqlDbType.VarChar).Value = cliente.CliEmail;
                query.Parameters.Add("@cliCelular", MySqlDbType.VarChar).Value = cliente.CliCelular;
                query.Parameters.Add("@cliEndereco", MySqlDbType.VarChar).Value = cliente.CliEndereco;
            query.ExecuteNonQuery();
            con.DesconectarBD();
        }

        public Cliente BuscarClienteByCpf(int cpf)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM vwCliente WHERE Cpf = @cliCpf", con.ConectarBD());
            query.Parameters.Add("@cliCpf", MySqlDbType.VarChar).Value = cpf;
            var DadosClienteByCpf = query.ExecuteReader();
            return ListarClienteByCpf(DadosClienteByCpf).FirstOrDefault();
        }
        
        public List<Cliente> ListarClienteByCpf(MySqlDataReader dados)
        {
            var ClienteByCpf = new List<Cliente>();
            while (dados.Read())
            {
                var ClienteTemp = new Cliente()
                {
                    CliNome = dados["Nome"].ToString(),
                    CliCpf = dados["Cpf"].ToString(),
                    CliNasc = DateTime.Parse(dados["Nasc"].ToString()),
                    CliEmail = dados["Email"].ToString(),
                    CliCelular = dados["Celular"].ToString(),
                    CliEndereco = dados["Endereco"].ToString()
                };
                ClienteByCpf.Add(ClienteTemp);
            }

            dados.Close();
            return ClienteByCpf;
        }

        public List<Cliente> BuscarTodosClientes()
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM vwCliente", con.ConectarBD());
            var DadosTodosClientes = query.ExecuteReader();
            return ListarTodosClientes(DadosTodosClientes);
        }

        public List<Cliente> ListarTodosClientes(MySqlDataReader dados)
        {
            var TodosClientes = new List<Cliente>();
            while (dados.Read())
            {
                var ClienteTemp = new Cliente()
                {
                    CliNome = dados["Nome"].ToString(),
                    CliCpf = dados["Cpf"].ToString(),
                    CliNasc = DateTime.Parse(dados["Nasc"].ToString()),
                    CliEmail = dados["Email"].ToString(),
                    CliCelular = dados["Celular"].ToString(),
                    CliEndereco = dados["Endereco"].ToString()
                };
                TodosClientes.Add(ClienteTemp);
            }

            dados.Close();
            return TodosClientes;
        }
    }
}