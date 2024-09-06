using System;
using System.Linq.Expressions;
using System.Collections.Generic;

using static System.Linq.Expressions.Expression;
using Microsoft.VisualBasic;
using System.Data.Common;

// var a = Expression.Parameter(typeof(int),"a");
// var b = Expression.Parameter(typeof(int),"b");
// var func = Expression.Lambda(
//         Expression.Multiply(a, b),
//         [ a, b ]
//     ).Compile();

// Console.WriteLine(func.DynamicInvoke(2, 3));

Table<Cliente> dataCliente = new();
Table<Telefone> dataTelefone = new();
Table<Endereco> dataEndereco = new();
Table<Carro> dataCarro = new();

List<DB> listTables = [dataTelefone, dataEndereco, dataCarro];

List<Cliente> queryA = dataCliente.Where( c => c.Nome == "Lore");
List<Cliente> queryB = dataCliente.Join(listTables, (a, b) => a.Id == b.Id);

public static class MyExtensionClass
{
    static List<T> Execute<T>(string sql) => [];
    public static List<T> Where<T>(
        this Table<T> db,
        Expression<Func<T, bool>> expression)
    {
        var body = expression.Body;
        string condition = toSql(body);
        string query =
            $"""
            select * from {typeof(T).Name}
                where {condition}
            """;
        // Console.WriteLine(query);

        return Execute<T>(query);
    }

    public static List<T> Join<T>(
        this Table<T> table, 
        List<DB> listTables,
        Expression<Func<T, T, bool>> expression)
    {
        var body = expression.Body;

        List<string> list = [];

        list.Add(table.GetType().GetGenericArguments()[0].FullName[..1].ToLower());
    
        
        string query = $"select * from {typeof(T).Name} as {list[0]}";
        string joins = "";

        foreach (var item in listTables)
        {
            Type tableType = item.GetType();
            Type[] genericArguments = tableType.GetGenericArguments();
            string genericType = genericArguments[0].FullName;

            for (int i = 1; i < 4; i++)
            {
                string type = genericType[..i].ToLower();
                if (!list.Contains(type))
                {
                   list.Add(type);
                   break; 
                }
            }
            
            string condition = toSqlJ(body, [list[0], list[^1]]);

            joins += $"""

                join {genericType} as {list[^1]}
                        on {condition}
            """;
        }
        
        Console.WriteLine(query+joins);

        return Execute<T>(query);
    }

    static string toSql(Expression exp) =>
    (exp, exp.NodeType) switch
    {
        (BinaryExpression bin, ExpressionType.And or ExpressionType.AndAlso) =>
            $"{toSql(bin.Left)} and {toSql(bin.Right)}",

        (BinaryExpression bin, ExpressionType.Equal) =>
            $"{toSql(bin.Left)} = {toSql(bin.Right)}",

        (BinaryExpression bin, ExpressionType.GreaterThan) =>
            $"{toSql(bin.Left)} > {toSql(bin.Right)}",

        (BinaryExpression bin, ExpressionType.LessThan) =>
            $"{toSql(bin.Left)} < {toSql(bin.Right)}",

        (BinaryExpression bin, ExpressionType.GreaterThanOrEqual) =>
            $"{toSql(bin.Left)} >= {toSql(bin.Right)}",

        (BinaryExpression bin, ExpressionType.LessThanOrEqual) =>
            $"{toSql(bin.Left)} <= {toSql(bin.Right)}",
        
        (MemberExpression mem, ExpressionType.MemberAccess) =>
            mem.Member.Name,
        
        (ConstantExpression cexp, ExpressionType.Constant) =>
            cexp.Value is string s ? $"'{s}'" : cexp.Value.ToString(),
        
        _ => throw new Exception($"Invalid expression type {exp.NodeType} ({exp.GetType()})")
    };

    static string toSqlJ(Expression exp, List<string> parameters) =>
    (exp, exp.NodeType) switch
    {
        (BinaryExpression bin, ExpressionType.Equal) =>
            $"{parameters[0]}.{toSqlJ(bin.Left, parameters)} = {parameters[^1]}.{toSqlJ(bin.Right, parameters)}",
        
        (MemberExpression mem, ExpressionType.MemberAccess) => 
            mem.Member.Name,
        
        (ConstantExpression cexp, ExpressionType.Constant) =>
            cexp.Value is string s ? $"'{s}'" : cexp.Value.ToString(),
        
        _ => throw new Exception($"Invalid expression type {exp.NodeType} ({exp.GetType()})")
    };
}


public interface DB {}
public record Table<T> : DB;// Record base com uma propriedade comum
public record Cliente(int Id, string Nome); // Herda de EntidadeBase
public record Telefone(int Id, string Numero); // Herda de EntidadeBase
public record Endereco(int Id, string Numero); // Herda de EntidadeBase
public record Carro(int Id, string Nome); // Herda de EntidadeBase

