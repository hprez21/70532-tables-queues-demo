using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesQueuesDemo.Entities;

namespace TablesQueuesDemo
{
    class Program
    {
        #region Tables
        //    static void Main(string[] args)
        //    {
        //        var table =
        //            GetTable("students");

        //        //var student1 =
        //        //    new Student("Héctor Pérez",
        //        //    new DateTime(1990, 11, 2),
        //        //    5,
        //        //    'A');

        //        //var student2 =
        //        //    new Student("Emma Watson",
        //        //    new DateTime(1994, 5, 12),
        //        //    8,
        //        //    'B');

        //        //var student3 =
        //        //    new Student("Regina de Coss",
        //        //    new DateTime(1994, 5, 5),
        //        //    5,
        //        //    'A');

        //        //CreateStudent(table, student1);
        //        //CreateStudent(table, student2);
        //        //CreateStudent(table, student3);

        //        //var student =
        //        //    GetStudent(table, "5A", "H21119905A");

        //        //Console.WriteLine(student.Name);

        //        //GetAllStudents(table);

        //        //var student =
        //        //    GetStudent(table, "5A", "H21119905A");

        //        //DeleteStudent(table, student);

        //        //GetAllStudents(table);

        //        TableBatchOperation batch =
        //            new TableBatchOperation();

        //        var student1 =
        //            new Student("Alvin Aston",
        //            new DateTime(1990, 11, 2),
        //            5,
        //            'A');

        //        var student2 =
        //            new Student("Brando Marlon",
        //            new DateTime(1994, 5, 12),
        //            5,
        //            'A');

        //        var student3 =
        //            new Student("Carlos Chávez",
        //            new DateTime(1994, 5, 5),
        //            5,
        //            'A');

        //        batch.Insert(student1);
        //        batch.Insert(student2);
        //        batch.Insert(student3);

        //        table.ExecuteBatch(batch);

        //        GetAllStudents(table);

        //        Console
        //            .WriteLine("Operación completada con éxito");
        //        Console.ReadLine();
        //    }

        //    static CloudTable GetTable(string tableName)
        //    {
        //        var storageAccount =
        //            CloudStorageAccount
        //            .Parse(CloudConfigurationManager
        //            .GetSetting("StorageData"));

        //        CloudTableClient tableClient =
        //            storageAccount.CreateCloudTableClient();

        //        CloudTable table = tableClient
        //            .GetTableReference(tableName);

        //        table.CreateIfNotExists();

        //        return table;
        //    }

        //    static void CreateStudent(CloudTable table,
        //        Student student)
        //    {
        //        TableOperation insert =
        //            TableOperation.Insert(student);

        //        table.Execute(insert);
        //    }

        //    static Student GetStudent(CloudTable table,
        //        string partitionKey, string rowKey)
        //    {
        //        TableOperation retrieve =
        //            TableOperation
        //            .Retrieve<Student>(partitionKey, rowKey);

        //        var result = table.Execute(retrieve);

        //        return (Student)result.Result;
        //    }


        //    static void GetAllStudents(CloudTable table)
        //    {
        //        TableQuery<Student> query =
        //            new TableQuery<Student>()
        //            .Where(TableQuery.GenerateFilterCondition("PartitionKey", 
        //            QueryComparisons.Equal, "5A"));

        //        foreach(var student in table.ExecuteQuery(query))
        //        {
        //            Console.WriteLine($"{student.Name}, {student.BirthDay}");
        //        }
        //    }

        //    static void UpdateStudent(CloudTable table,
        //        Student student)
        //    {
        //        TableOperation update =
        //            TableOperation.Replace(student);

        //        table.Execute(update);
        //    }

        //    static void DeleteStudent(CloudTable table,
        //        Student student)
        //    {
        //        TableOperation delete =
        //            TableOperation.Delete(student);

        //        table.Execute(delete);
        //    }
        //}
        #endregion


        static void Main(string[] args)
        {
            var queue = GetQueue("pendientes");

            //CloudQueueMessage message =
            //    new CloudQueueMessage("Actualizar servidor");

            //var time =
            //    new TimeSpan(8, 0, 0);

            //queue.AddMessage(message, time);

            //CloudQueueMessage message =
            //    queue.GetMessage();
            ////Operaciones correspondientes
            //Console.WriteLine(message.AsString);

            //queue.DeleteMessage(message);

            for(int i = 0; i<20; i++)
            {
                CloudQueueMessage message =
                    new CloudQueueMessage($"Hola {i}");
                queue.AddMessage(message);
            }

            foreach (CloudQueueMessage message 
                in queue.GetMessages(20, TimeSpan.FromMinutes(5)))
            {
                Console.WriteLine(message.AsString);
                queue.DeleteMessage(message);
            }

            Console.WriteLine("Operación fue exitosa");
            Console.ReadLine();
        }

        static CloudQueue GetQueue(string queueName)
        {
            var storageAccount =
                CloudStorageAccount
                .Parse(CloudConfigurationManager
                .GetSetting("StorageData"));

            CloudQueueClient queueClient =
                storageAccount.CreateCloudQueueClient();

            CloudQueue queue =
                queueClient.GetQueueReference(queueName);

            queue.CreateIfNotExists();

            return queue;
        }

    }
}
