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

        // Cadastros
        public void CadastrarCliente(Cliente cliente)
        {
            MySqlCommand query = new MySqlCommand("INSERT INTO tbCliente values(@cliNome, @cliCpf, @cliNasc, @cliEmail, @cliCelular, @cliEndereco);", con.ConectarBD());
                query.Parameters.Add("@cliNome", MySqlDbType.VarChar).Value = cliente.CliNome;
                query.Parameters.Add("@cliCpf", MySqlDbType.VarChar).Value = cliente.CliCpf;
                query.Parameters.Add("@cliNasc", MySqlDbType.DateTime).Value = cliente.CliNasc;
                query.Parameters.Add("@cliEmail", MySqlDbType.VarChar).Value = cliente.CliEmail;
                query.Parameters.Add("@cliCelular", MySqlDbType.VarChar).Value = cliente.CliCelular;
                query.Parameters.Add("@cliEndereco", MySqlDbType.VarChar).Value = cliente.CliEndereco;
            query.ExecuteNonQuery();
            con.DesconectarBD();
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            MySqlCommand query = new MySqlCommand("INSERT INTO tbFuncionario values(default, @funcNome, @funcCpf, @funcRg, @funcNasc, @funcEndereco, @funcCelular, @funcEmail, @funcCargo);", con.ConectarBD());
                query.Parameters.Add("@funcNome", MySqlDbType.VarChar).Value = funcionario.FuncNome;
                query.Parameters.Add("@funcCpf", MySqlDbType.VarChar).Value = funcionario.FuncCpf;
                query.Parameters.Add("@funcRg", MySqlDbType.VarChar).Value = funcionario.FuncRg;
                query.Parameters.Add("@funcNasc", MySqlDbType.DateTime).Value = funcionario.FuncNasc;
                query.Parameters.Add("@funcEndereco", MySqlDbType.VarChar).Value = funcionario.FuncEndereco;
                query.Parameters.Add("@funcCelular", MySqlDbType.VarChar).Value = funcionario.FuncCelular;
                query.Parameters.Add("@funcEmail", MySqlDbType.VarChar).Value = funcionario.FuncEmail;
                query.Parameters.Add("@funcCargo", MySqlDbType.VarChar).Value = funcionario.FuncCargo;
            query.ExecuteNonQuery();
            con.DesconectarBD();
        }

        public void CadastrarJogo(Jogo jogo)
        {
            MySqlCommand query = new MySqlCommand("INSERT INTO tbJogo values(default, @jogoNome, @jogoVersao, @jogoDesenvolvedora, @jogoGenero, @jogoFaixaEtaria, @jogoPlataforma, @jogoAnoLancamento, @jogoSinopse);", con.ConectarBD());
                query.Parameters.Add("@jogoNome", MySqlDbType.VarChar).Value = jogo.JogoNome;
                query.Parameters.Add("@jogoVersao", MySqlDbType.VarChar).Value = jogo.JogoVersao;
                query.Parameters.Add("@jogoDesenvolvedora", MySqlDbType.VarChar).Value = jogo.JogoDesenvolvedora;
                query.Parameters.Add("@jogoGenero", MySqlDbType.VarChar).Value = jogo.JogoGenero;
                query.Parameters.Add("@jogoFaixaEtaria", MySqlDbType.Int16).Value = jogo.JogoFaixaEtaria;
                query.Parameters.Add("@jogoPlataforma", MySqlDbType.VarChar).Value = jogo.JogoPlataforma;
                query.Parameters.Add("@jogoAnoLancamento", MySqlDbType.Int16).Value = jogo.JogoAnoLancamento;
                query.Parameters.Add("@jogoSinopse", MySqlDbType.VarChar).Value = jogo.JogoSinopse;
            query.ExecuteNonQuery();
            con.DesconectarBD();
        }

        // Buscar por código
        public Cliente BuscarClienteByCpf(int cpf)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM tbCliente WHERE Cpf = @cliCpf;", con.ConectarBD());
                query.Parameters.Add("@cliCpf", MySqlDbType.VarChar).Value = cpf;
            var DadosClienteByCpf = query.ExecuteReader();
            return ListarClientes(DadosClienteByCpf).FirstOrDefault();
        }

        public Funcionario BuscarFuncionarioByCod(int cod)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM tbFuncionario WHERE CodFunc = @funcCod;", con.ConectarBD());
                query.Parameters.Add("funcCod", MySqlDbType.Int64).Value = cod;
            var DadosFuncionarioByCod = query.ExecuteReader();
            return ListarFuncionarios(DadosFuncionarioByCod).FirstOrDefault();
        }

        public Jogo BuscarJogoByCod(int cod)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM tbJogo WHERE CodJogo = @jogoCod;", con.ConectarBD());
                query.Parameters.Add("jogoCod", MySqlDbType.Int64).Value = cod;
            var DadosJogoByCod = query.ExecuteReader();
            return ListarJogos(DadosJogoByCod).FirstOrDefault();
        }

        // Buscar todos
        public List<Cliente> BuscarTodosClientes()
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM tbCliente;", con.ConectarBD());
            var DadosTodosClientes = query.ExecuteReader();
            return ListarClientes(DadosTodosClientes);
        }

        public List<Funcionario> BuscarTodosFuncionarios()
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM tbFuncionario", con.ConectarBD());
            var DadosTodosFuncionarios = query.ExecuteReader();
            return ListarFuncionarios(DadosTodosFuncionarios);
        }

        public List<Jogo> BuscarTodosJogos()
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM tbJogo", con.ConectarBD());
            var DadosTodosJogos = query.ExecuteReader();
            return ListarJogos(DadosTodosJogos);
        }

        // Listar todos
        public List<Cliente> ListarClientes(MySqlDataReader dados)
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

        public List<Funcionario> ListarFuncionarios(MySqlDataReader dados)
        {
            var FuncionarioByCod = new List<Funcionario>();
            while (dados.Read())
            {
                var FuncionarioTemp = new Funcionario()
                {
                    FuncCod = Convert.ToUInt16(dados["CodFunc"]),
                    FuncNome = dados["Nome"].ToString(),
                    FuncCpf = dados["Cpf"].ToString(),
                    FuncRg = dados["Rg"].ToString(),
                    FuncNasc = DateTime.Parse(dados["Nasc"].ToString()),
                    FuncEndereco = dados["Endereco"].ToString(),
                    FuncCelular = dados["Celular"].ToString(),
                    FuncEmail = dados["Email"].ToString(),
                    FuncCargo = dados["Cargo"].ToString()
                };
                FuncionarioByCod.Add(FuncionarioTemp);
            }

            dados.Close();
            return FuncionarioByCod;
        }
        public List<Jogo> ListarJogos(MySqlDataReader dados)
        {
            var JogoByCod = new List<Jogo>();
            while (dados.Read())
            {
                var JogoTemp = new Jogo()
                {
                    JogoCod = Convert.ToUInt16(dados["CodJogo"]),
                    JogoNome = dados["Nome"].ToString(),
                    JogoVersao = dados["Versao"].ToString(),
                    JogoDesenvolvedora = dados["Desenvolvedora"].ToString(),
                    JogoGenero = dados["Genero"].ToString(),
                    JogoFaixaEtaria = Convert.ToByte(dados["FaixaEtaria"]),
                    JogoPlataforma = dados["Plataforma"].ToString(),
                    JogoAnoLancamento = Convert.ToInt32(dados["AnoLancamento"]),
                    JogoSinopse = dados["Sinopse"].ToString()
                };
                JogoByCod.Add(JogoTemp);
            }

            dados.Close();
            return JogoByCod;
        }
    }
}