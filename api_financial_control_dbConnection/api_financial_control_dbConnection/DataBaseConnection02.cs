using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace api_financial_control_dbConnection
{
    public class DataBaseConnection02
    {
        /*private SqlConnection conexao;

        public void conectar()
        {
            conexao = new SqlConnection("server=127.0.0.1 ; database=bdfutebolsociety ; uid='root' ; pwd=''");

            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Impossível estabelecer conexão. " + ex.Message);
            }
        }

        public Dictionary<int, AtletaFS> getAtletas()
        {
            Dictionary<int, AtletaFS> listAtletas = new Dictionary<int, AtletaFS>();
            AtletaFS atleta = new AtletaFS();

            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "SELECT ID, NOME, DATAINCLUSAO, NASCIMENTO, POSICAO, CONTATO, EMAIL, ATIVO, INATIVO, FOTO, HABILIDADE, PARTICIPACAO, NOTATECNICA, DEFESA, ATAQUE FROM BDFUTEBOLSOCIETY.TBATLETAS ORDER BY NOME;";
                    MySqlDataReader resultado = query.ExecuteReader();

                    while (resultado.Read())
                    {
                        atleta = new AtletaFS();

                        atleta.setId((int)resultado["id"]);
                        atleta.setNome((string)resultado["nome"]);
                        atleta.setDataInclusao((string)resultado["datainclusao"]);
                        atleta.setNascimento((string)resultado["nascimento"]);
                        atleta.setPosicao((string)resultado["posicao"]);
                        atleta.setContato((string)resultado["contato"]);
                        atleta.setEmail((string)resultado["email"]);
                        //atleta.setFoto((System.Byte)resultado["foto"]);

                        try{
                            byte[] data = (byte[])resultado["foto"];
                            MemoryStream ms = new MemoryStream(data);
                            atleta.setFoto(Image.FromStream(ms));
                        }catch{ 
                        
                        }

                        atleta.setHabilidade((double)resultado["habilidade"]);
                        atleta.setParticipacao((double)resultado["participacao"]);
                        atleta.setNotaTecnica((double)resultado["notatecnica"]);
                        atleta.setDefesa((string)resultado["defesa"]);
                        atleta.setAtaque((string)resultado["ataque"]);
                        atleta.setAtivo((string)resultado["ativo"]);
                        atleta.setInativo((string)resultado["inativo"]);

                        listAtletas.Add(atleta.getId(), atleta);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }

            return listAtletas;
        }
        public List<string> getSimulacoes()
        {
            List<string> listSimulacoes = new List<string>();

            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "SELECT ID, NOME, TIME, ATLETAS FROM BDFUTEBOLSOCIETY.TBSIMULACOES GROUP BY NOME;";
                    MySqlDataReader resultado = query.ExecuteReader();

                    while (resultado.Read())
                    {
                        listSimulacoes.Add(resultado["nome"].ToString());
                    }
                    return listSimulacoes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            return listSimulacoes;
        }
        public List<List<int>> getSimulacaoTimesIds(string pNomeSimulacao)
        {
            int cont = 0;

            List<List<int>> listTimes = new List<List<int>>();
            List<int> listIDs = new List<int>();
            AtletaFS atleta = new AtletaFS();

            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "SELECT ID, NOME, TIME, ATLETAS FROM BDFUTEBOLSOCIETY.TBSIMULACOES WHERE NOME=@nome ORDER BY ID;";
                    query.Parameters.AddWithValue("@nome", pNomeSimulacao);
                    MySqlDataReader resultado = query.ExecuteReader();

                    while (resultado.Read())
                    {
                        string[] atletas = resultado["atletas"].ToString().Split(',');
                        listIDs = new List<int>();

                        foreach (string id in atletas) {
                            listIDs.Add(int.Parse(id));
                            
                        }
                        listTimes.Add(listIDs);
                        cont++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            return listTimes;
        }
        public void setAtleta(AtletaFS atleta)
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "INSERT INTO " +
                        "tbatletas" +
                        "(ID, " +
                        "NOME, " +
                        "DATAINCLUSAO, " +
                        "NASCIMENTO, " +
                        "POSICAO, " +
                        "CONTATO, " +
                        "EMAIL, " +
                        "ATIVO, " +
                        "INATIVO, " +
                        "FOTO, " +
                        "HABILIDADE, " +
                        "PARTICIPACAO, " +
                        "NOTATECNICA, " +
                        "DEFESA, " +
                        "ATAQUE) " +
                        "VALUES" +
                        "(@id, " +
                        "@nome, " +
                        "@datainclusao, " +
                        "@nascimento, " +
                        "@posicao, " +
                        "@contato, " +
                        "@email, " +
                        "@ativo, " +
                        "@inativo, " +
                        "@foto, " +
                        "@habilidade, " +
                        "@participacao, " +
                        "@notatecnica, " +
                        "@defesa, " +
                        "@ataque);";

                    query.Parameters.AddWithValue("@id", atleta.getId());
                    query.Parameters.AddWithValue("@nome", atleta.getNome());
                    query.Parameters.AddWithValue("@datainclusao", atleta.getDataInclusao());
                    query.Parameters.AddWithValue("@nascimento", atleta.getNascimento());
                    query.Parameters.AddWithValue("@posicao", atleta.getPosicao());
                    query.Parameters.AddWithValue("@contato", atleta.getContato());
                    query.Parameters.AddWithValue("@email", atleta.getEmail());
                    query.Parameters.AddWithValue("@ativo", atleta.getAtivo());
                    query.Parameters.AddWithValue("@inativo", atleta.getInativo());
                    ///query.Parameters.AddWithValue("@foto", atleta.getFoto());

                    if (atleta.getFoto() != null)
                    {
                        try
                        {
                            using (var ms = new MemoryStream())
                            {
                                atleta.getFoto().Save(ms, atleta.getFoto().RawFormat);
                                query.Parameters.AddWithValue("@foto", ms.ToArray());
                            }
                        }
                        catch
                        {

                        }
                    }
                    else {
                        query.Parameters.AddWithValue("@foto", null);
                    }

                    query.Parameters.AddWithValue("@habilidade", atleta.getHabilidade());
                    query.Parameters.AddWithValue("@participacao", atleta.getParticipacao());
                    query.Parameters.AddWithValue("@notatecnica", atleta.getNotaTecnica());
                    query.Parameters.AddWithValue("@defesa", atleta.getDefesa());
                    query.Parameters.AddWithValue("@ataque", atleta.getAtaque());
                    query.ExecuteNonQuery();
                    query.Dispose();

                    MessageBox.Show("Atleta " + atleta.getNome() + " cadastrado com sucesso.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
        }
        public void setSimulacao(int id, string pNomeCamp, string pTxTime, string pTxAtletas)
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "INSERT INTO " +
                        "tbsimulacoes" +
                        "(ID, " +
                        "NOME, " +
                        "TIME, " +
                        "ATLETAS) " +
                        "VALUES" +
                        "(@id, " +
                        "@nome, " +
                        "@time, " +
                        "@atletas); ";

                    query.Parameters.AddWithValue("@id", id);
                    query.Parameters.AddWithValue("@nome", pNomeCamp);
                    query.Parameters.AddWithValue("@time", pTxTime);
                    query.Parameters.AddWithValue("@atletas", pTxAtletas);
                    query.ExecuteNonQuery();
                    query.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
        }
        public void excluiAtleta(AtletaFS atleta)
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand query = new MySqlCommand();
                query.Connection = conexao;
                query.CommandText = "DELETE FROM TBATLETAS WHERE ID=@Id";
                query.Parameters.AddWithValue("@Id", atleta.getId());

                try
                {
                    int i = query.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Registro excluído com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
        }
        public void excluiSimulacao(string nomeCampeoanato)
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand query = new MySqlCommand();
                query.Connection = conexao;
                query.CommandText = "DELETE FROM BDFUTEBOLSOCIETY.TBSIMULACOES WHERE NOME=@nome;";
                query.Parameters.AddWithValue("@nome", nomeCampeoanato);

                try
                {
                    int i = query.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
        }
        public void atualizaAtleta(AtletaFS atleta)
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand query = new MySqlCommand();
                query.Connection = conexao;
                query.CommandText = "UPDATE BDFUTEBOLSOCIETY.TBATLETAS " +
                    "SET " +
                    "NOME=@nome, " +
                    "DATAINCLUSAO=@datainclusao, " +
                    "NASCIMENTO=@nascimento, " +
                    "POSICAO=@posicao, " +
                    "CONTATO=@contato, " +
                    "EMAIL=@email, " +
                    "ATIVO=@ativo, " +
                    "INATIVO=@inativo, " +
                    "FOTO=@foto, " +
                    "HABILIDADE=@habilidade, " +
                    "PARTICIPACAO=@participacao, " +
                    "NOTATECNICA=@notatecnica, " +
                    "DEFESA=@defesa, " +
                    "ATAQUE=@ataque " +
                    "WHERE " +
                    "ID=@id; ";

                query.Parameters.AddWithValue("@nome", atleta.getNome());
                query.Parameters.AddWithValue("@datainclusao", atleta.getDataInclusao());
                query.Parameters.AddWithValue("@nascimento", atleta.getNascimento());
                query.Parameters.AddWithValue("@posicao", atleta.getPosicao());
                query.Parameters.AddWithValue("@contato", atleta.getContato());
                query.Parameters.AddWithValue("@email", atleta.getEmail());
                query.Parameters.AddWithValue("@ativo", atleta.getAtivo());
                query.Parameters.AddWithValue("@inativo", atleta.getInativo());
                //query.Parameters.AddWithValue("@foto", atleta.getFoto());

                if (atleta.getFoto() != null)
                {
                    try
                    {
                        using (var ms = new MemoryStream())
                        {
                            atleta.getFoto().Save(ms, atleta.getFoto().RawFormat);
                            query.Parameters.AddWithValue("@foto", ms.ToArray());
                        }
                    }
                    catch
                    {

                    }
                }
                else {
                    query.Parameters.AddWithValue("@foto", null);
                }

                query.Parameters.AddWithValue("@habilidade", atleta.getHabilidade());
                query.Parameters.AddWithValue("@participacao", atleta.getParticipacao());
                query.Parameters.AddWithValue("@notatecnica", atleta.getNotaTecnica());
                query.Parameters.AddWithValue("@defesa", atleta.getDefesa());
                query.Parameters.AddWithValue("@ataque", atleta.getAtaque());
                query.Parameters.AddWithValue("@id", atleta.getId());

                try
                {
                    int i = query.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Registro atualizado com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
        }
        public int idLivre()
        {
            List<int> listIDs = new List<int>();
            int idVago = 0;

            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "SELECT ID FROM BDFUTEBOLSOCIETY.TBATLETAS ORDER BY ID;";
                    MySqlDataReader resultado = query.ExecuteReader();

                    while (resultado.Read())
                    {
                        listIDs.Add((int)resultado["id"]);
                    }

                    for (int cont = 0; cont <= listIDs.Count; cont++)
                    {

                        if (!listIDs.Contains(cont))
                        {

                            idVago = cont;
                            break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            return idVago;
        }
        public int idLivreSimulacoes()
        {
            List<int> listIDs = new List<int>();
            int idVago = 0;

            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "SELECT ID FROM BDFUTEBOLSOCIETY.TBSIMULACOES ORDER BY ID;";
                    MySqlDataReader resultado = query.ExecuteReader();

                    while (resultado.Read())
                    {
                        listIDs.Add((int)resultado["id"]);
                    }

                    for (int cont = 0; cont <= listIDs.Count; cont++)
                    {
                        if (!listIDs.Contains(cont))
                        {
                            idVago = cont;
                            break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            return idVago;
        }
        public int getIdByAtleta(string nomeAtleta)
        {
            int id = 0;
            string atleta = "";

            if (nomeAtleta.Contains(":"))
            {
                atleta = nomeAtleta.Substring(6);
            }
            else {
                atleta = nomeAtleta;
            }

            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "SELECT ID, NOME FROM BDFUTEBOLSOCIETY.TBATLETAS WHERE NOME=@nome ORDER BY ID;";
                    query.Parameters.AddWithValue("@nome", atleta);
                    MySqlDataReader resultado = query.ExecuteReader();

                    while (resultado.Read()) { 
                        if (resultado["NOME"].ToString().Contains(atleta)) {
                            id = (int)resultado["ID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            return id;
        }
        public Boolean contemAtleta (AtletaFS atleta){
            
            Boolean contemAtl = false;

            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "SELECT ID, NOME FROM BDFUTEBOLSOCIETY.TBATLETAS ORDER BY ID;";
                    MySqlDataReader resultado = query.ExecuteReader();

                    while (resultado.Read())
                    {
                        if (resultado["NOME"].ToString().Contains(atleta.getNome()))
                        {
                            contemAtl = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            return contemAtl;
        }
        public Boolean contemSimulacao(string nomeCampeonato)
        {

            Boolean contemSimul = false;

            if (conexao.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    MySqlCommand query = new MySqlCommand();
                    query.Connection = conexao;
                    query.CommandText = "SELECT ID, NOME FROM BDFUTEBOLSOCIETY.TBSIMULACOES ORDER BY ID;";
                    MySqlDataReader resultado = query.ExecuteReader();

                    while (resultado.Read())
                    {
                        if (resultado["NOME"].ToString().Contains(nomeCampeonato))
                        {
                            contemSimul = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            return contemSimul;
        }
        public void ativaTodosAtletas() {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand query = new MySqlCommand();
                query.Connection = conexao;
                query.CommandText = "UPDATE BDFUTEBOLSOCIETY.TBATLETAS " +
                    "SET " +
                    "ATIVO='True', " +
                    "INATIVO='False' " +
                    " WHERE ID >= '0'; ";
                try
                {
                    query.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
        }
        public void desativaTodosAtletas()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                MySqlCommand query = new MySqlCommand();
                query.Connection = conexao;
                query.CommandText = "UPDATE BDFUTEBOLSOCIETY.TBATLETAS " +
                    "SET " +
                    "ATIVO='False', " +
                    "INATIVO='True' " +
                    " WHERE ID >= '0'; ";
                try
                {
                    query.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }

        }*/

    }
}
