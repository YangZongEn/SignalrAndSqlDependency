using ProgressBarTest.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ProgressBarTest.Models
{
    public class NotificationService
    {
        static readonly string connString = @"Data Source=192.168.100.163;Initial Catalog=NotificationTest;user id=sa;password=Aa123456;";
        internal static SqlCommand command = null;
        internal static SqlDependency dependency = null;

        public static string GetNotification()
        {
            try
            {
                var messages = new List<ProgressBar>();
                using (var connection = new SqlConnection(connString)){
                    connection.Open();

                    using (command = new SqlCommand(@"SELECT [Id], [message], [percent] FROM [dbo].[ProgressBar] where id = 1", connection))
                    {
                        command.Notification = null;

                        if(dependency == null)
                        {
                            dependency = new SqlDependency(command);
                            dependency.OnChange += new OnChangeEventHandler(dependency_Onchange);
                        }
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                        }

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new ProgressBar
                            {
                                Id = (int)reader["Id"],
                                message = (string)reader["message"],
                                percent = (int)reader["percent"]
                            });
                        }
                    }
                }

                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(messages);
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static void dependency_Onchange(object sender, SqlNotificationEventArgs e)
        {
            if(dependency != null)
            {
                dependency.OnChange -= dependency_Onchange;
                dependency = null;
            }
            if(e.Type == SqlNotificationType.Change)
            {
                MyNewHub.Send();
            }
        }
    }
}