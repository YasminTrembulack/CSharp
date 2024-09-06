// using System;
// using System.Linq.Expressions;
// using System.Collections.Generic;

// using static System.Linq.Expressions.Expression;
// // Lambda(Throw(Constant(new Exception()))).Compile().DynamicInvoke();

// var a = Expression.Parameter(typeof(int),"a");
// var b = Expression.Parameter(typeof(int),"b");
// var func = Expression.Lambda(
//         Expression.Multiply(a, b),
//         [ a, b ]
//     ).Compile();

// Console.WriteLine(func.DynamicInvoke(2, 3));

// DB<Cliente> data = new();
// List<Cliente> query = data.Where( c => c.Nome == "Lore");

// public static class MyExtensionClass
// {
//     public static List<T> Where<T>(
//         this DB<T> db,
//         Expression<Func<T, bool>> expression)
//     {
//         var body = expression.Body;
//         string condition = toSqlWhere(body);
//         string query =
//             $"""
//             select * from {typeof(T).Name}
//                 where {condition}
//             """;
//         Console.WriteLine(query);

//         return execute<T>(query);
//     }

//     public static List<T> Join<T>(
//         this DB<T> db,
//         Expression<Func<T, bool>> expression)
//     {
//         string query =
//             $"""
//             select * from 
//                 where 
//             """;
//         return execute<T>(query);
//     }

//     static string toSqlWhere(Expression exp) =>
//         (exp, exp.NodeType) switch
//         {
//             (BinaryExpression bin, ExpressionType.And or ExpressionType.AndAlso) =>
//                 $"{toSqlWhere(bin.Left)} and {toSqlWhere(bin.Right)}",

//             (BinaryExpression bin, ExpressionType.Equal) =>
//                 $"{toSqlWhere(bin.Left)} = {toSqlWhere(bin.Right)}",

//             (BinaryExpression bin, ExpressionType.GreaterThan) =>
//                 $"{toSqlWhere(bin.Left)} > {toSqlWhere(bin.Right)}",

//             (BinaryExpression bin, ExpressionType.LessThan) =>
//                 $"{toSqlWhere(bin.Left)} < {toSqlWhere(bin.Right)}",

//             (BinaryExpression bin, ExpressionType.GreaterThanOrEqual) =>
//                 $"{toSqlWhere(bin.Left)} >= {toSqlWhere(bin.Right)}",

//             (BinaryExpression bin, ExpressionType.LessThanOrEqual) =>
//                 $"{toSqlWhere(bin.Left)} <= {toSqlWhere(bin.Right)}",
            
//             (MemberExpression mem, ExpressionType.MemberAccess) =>
//                 mem.Member.Name,
            
//             (ConstantExpression cexp, ExpressionType.Constant) =>
//                 cexp.Value is string s ? $"'{s}'" : cexp.Value.ToString(),
            
//             _ => throw new Exception($"Invalid expression type {exp.NodeType} ({exp.GetType()})")
//         };

//     static List<T> execute<T>(string sql) => [];
// }

// public record DB<T>;

// public record Cliente(int Id, string Nome);