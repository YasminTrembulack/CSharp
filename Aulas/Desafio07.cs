// int dictColumn(string line , string col){
//     var formatted_line = line.Replace("\"", "");
//     string[] array_line = formatted_line.Split(";");
//     var index = 0;
//     foreach (string item in array_line){
//         if(item == col)
//             return index;
//         index++;
//     }
//     return -1;
// }
// // IEnumerable<string> getLine(){
// //     using var reader = new StreamReader("./srag.csv");
// //     string line = " ";
// //     while(line is not null){
// //         line = reader.ReadLine();
// //         yield return line;
// //     }
// // }

// (double , double) statusVacinado(){
//     using var reader = new StreamReader("./INFLUD21-01-05-2023.csv");
//     string line = reader.ReadLine();

//     double total_vacinado = 0;
//     double total_nao_vacinado = 0;
//     double obito_vacinado = 0;
//     double obito_nao_vacinado = 0;

//     int index_vacina = dictColumn(line,"VACINA_COV");
//     int index_obito = dictColumn(line,"EVOLUCAO");
//     int index_doenca = dictColumn(line,"CLASSI_FIN");

//     while(line is not null){
//         string[] array_line = [];
//         array_line = line.Split(";");

//         var vacinado = array_line[index_vacina];
//         var status = array_line[index_obito];
//         var doenca = array_line[index_doenca];

//         if (doenca == "5")
//         {
//             if (vacinado == "1")
//             {
//                 total_vacinado += 1;
//                 if (status == "2") obito_vacinado += 1;
//             }
//             else
//             {
//                 total_nao_vacinado += 1;
//                 if (status == "2") obito_nao_vacinado += 1;
//             }
//         }
                 
//         line = reader.ReadLine();
//     }
//     return(obito_nao_vacinado/ total_nao_vacinado * 100, obito_vacinado/ total_vacinado * 100);
// }

// var result = statusVacinado();

// Console.WriteLine("Pessoas que sobreviveram: "+ Math.Round(result.Item1, 2) + "%");
// Console.WriteLine("Pessoas que morreram: "+ Math.Round(result.Item2, 2) + "%");
