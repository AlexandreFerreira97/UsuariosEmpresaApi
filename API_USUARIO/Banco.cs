using System.Data.SQLite;

namespace API_USUARIO
{
    public class Banco
    {
        private static SQLiteConnection conexao;
        private static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source = C:\\Users\\Windows10\\Desktop\\Projeto_BD\\BD\\BD_USUARIO.db");
            return conexao;
        }
        public static void Inserir(Usuario usuario)
        {
            var conn = ConexaoBanco();
            try
            {
                using (var cmd = new SQLiteCommand("INSERT INTO Pessoas (Nome,Email,Telefone,CPF) VALUES (@nome,@Email,@Telefone,@CPF)", conn))
                {
                    conn.Open();
                    cmd.Parameters.Add(new SQLiteParameter("@nome", usuario.Nome));
                    cmd.Parameters.Add(new SQLiteParameter("@Email", usuario.Email));
                    cmd.Parameters.Add(new SQLiteParameter("@Telefone", usuario.Telefone));
                    cmd.Parameters.Add(new SQLiteParameter("@CPF", usuario.CPF));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Usuario> GetUsuarios()
        {
            var usuarios = new List<Usuario>();
            var conn = ConexaoBanco();
            try
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM Pessoas", conn))
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario { Nome = reader["Nome"].ToString(), Email = reader["Email"].ToString(), Telefone = reader["Telefone"].ToString(), CPF = reader["CPF"].ToString() });
                        }
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(Usuario usuario)
        {
            var conn = ConexaoBanco();
            try
            {
                if (usuario.CPF != null)
                {
                    using (var cmd = new SQLiteCommand("UPDATE Pessoas Set Nome = @Nome, Email = @Email, Telefone = @Telefone, CPF = @CPF WHERE CPF = @CPF", conn))
                    {
                        conn.Open();
                        cmd.Parameters.Add(new SQLiteParameter("@Nome", usuario.Nome));
                        cmd.Parameters.Add(new SQLiteParameter("@Email", usuario.Email));
                        cmd.Parameters.Add(new SQLiteParameter("@Telefone", usuario.Telefone));
                        cmd.Parameters.Add(new SQLiteParameter("@CPF", usuario.CPF));
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    Console.WriteLine("CPF INVÁLIDO.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Deletar(string cpf)
        {
            var conn = ConexaoBanco();

            try
            {
                using (var cmd = new SQLiteCommand("DELETE FROM Pessoas Where CPF = @CPF", conn))
                {
                    conn.Open();
                    cmd.Parameters.Add(new SQLiteParameter("@CPF", cpf));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string BuscaID(string cpf)
        {
            var conn = ConexaoBanco();
            try
            {
                using (var cmd = new SQLiteCommand($"SELECT * FROM Pessoas where CPF = @CPF", conn))
                {
                    conn.Open();
                    cmd.Parameters.Contains(new SQLiteParameter("@CPF", cpf));
                    cmd.ExecuteNonQuery();
                    return cpf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
