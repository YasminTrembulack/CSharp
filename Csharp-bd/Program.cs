using System.Data;
using System.Data.SqlClient;
SqlConnectionStringBuilder stringConnectionBuilder = new SqlConnectionStringBuilder();
stringConnectionBuilder.DataSource = @"CA-C-0064W\SQLEXPRESS"; // Nome do servidor
stringConnectionBuilder.InitialCatalog = "example"; // Nome do banco
stringConnectionBuilder.IntegratedSecurity = true;

string stringConnection = stringConnectionBuilder.ConnectionString;
Console.WriteLine(stringConnection);
SqlConnection conn = new SqlConnection(stringConnection);
conn.Open();

// SqlCommand comm = new SqlCommand("insert Cliente values ('Trevis', '123', CONVERT(DATETIME, '03/27/2024'));");
// comm.Connection = conn;
// comm.ExecuteNonQuery();

Console.WriteLine("Nome: ");
string nome = Console.ReadLine();
Console.WriteLine("Senha: ");
string senha = Console.ReadLine();

SqlCommand query = new SqlCommand($"SELECT * FROM Cliente WHERE Nome = @Nome AND Senha = @Senha;");
query.Connection = conn;

query.Parameters.Add(new SqlParameter("@Nome", nome));
query.Parameters.Add(new SqlParameter("@Senha", senha));

var reader = query.ExecuteReader();

query.Parameters.Clear();

DataTable result = new();
result.Load(reader);

if(result.Rows.Count > 0)
    Console.WriteLine($"Usuário {result.Rows[0].ItemArray[1]} Logado");
else
    Console.WriteLine($"Usuário ou Senha não encontardo...");

conn.Close();