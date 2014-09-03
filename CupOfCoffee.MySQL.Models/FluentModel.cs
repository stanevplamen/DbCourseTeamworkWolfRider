#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace CupOfCoffee.MySQL.Models	
{
	public partial class MySqlModel : OpenAccessContext, IMySqlModelUnitOfWork
	{
        private static string connectionStringName = @"DbConnectionString";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = new MySqlModelMetadataSource();
		
		public MySqlModel()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public MySqlModel(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public MySqlModel(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public MySqlModel(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public MySqlModel(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }

        public IQueryable<ProductReport> Reports
        {
            get
            {
                return this.GetAll<ProductReport>();
            }
        }
			
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "mysql";
            backend.ProviderName = "MySql.Data.MySqlClient";
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}
		
		/// <summary>
		/// Allows you to customize the BackendConfiguration of MySqlModel.
		/// </summary>
		/// <param name="config">The BackendConfiguration of MySqlModel.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface IMySqlModelUnitOfWork : IUnitOfWork
	{
	}
}
#pragma warning restore 1591
