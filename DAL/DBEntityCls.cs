
       

namespace DAL
{
       using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Data.Entity;
        using System.Data.Entity.Infrastructure;
        using System.Data.Entity.Core.Objects;
       // using System.Data.EntityClient;
    using System.Data.SqlClient; 
   public sealed class  DBEntityCls 
    {
       public void setConnectionDB(){

           string providerName = "System.Data.SqlClient";
           string serverName = @"AHMEDHOME-PC\MSSQLSERVER2012";
           string databaseName = "PharmaERP";

           // Initialize the connection string builder for the 
           // underlying provider.
           SqlConnectionStringBuilder sqlBuilder =
               new SqlConnectionStringBuilder();

           // Set the properties for the data source.
           sqlBuilder.DataSource = serverName;
           sqlBuilder.InitialCatalog = databaseName;
           sqlBuilder.IntegratedSecurity = true;

           // Build the SqlConnection connection string.
           string providerString = sqlBuilder.ToString();

           // Initialize the EntityConnectionStringBuilder.
           EntityConnectionStringBuilder entityBuilder =
               new EntityConnectionStringBuilder();

           //Set the provider name.
           entityBuilder.Provider = providerName;

           // Set the provider-specific connection string.
           entityBuilder.ProviderConnectionString = providerString;

           // Set the Metadata location.
           entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
                                res://*/AdventureWorksModel.ssdl|
                                res://*/AdventureWorksModel.msl";
           Console.WriteLine(entityBuilder.ToString());

           using (EntityConnection conn =
               new EntityConnection(entityBuilder.ToString()))
           {
               conn.Open();
               Console.WriteLine("Just testing the connection.");
               conn.Close();
           }
       }

       }
        


    }
   


