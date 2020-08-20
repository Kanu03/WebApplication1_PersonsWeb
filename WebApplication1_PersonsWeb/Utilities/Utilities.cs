using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WebApplication1_Persons;
using PersonsModels;

namespace WebApplication1_PersonsWeb.Utilities
{
	public class Common
	{
		private string _ApiAddress = "";

		public string ApiAddress
		{
			set
			{
				_ApiAddress = value;
			}
			get
			{
				return _ApiAddress;
			}
		}

		#region Constructor

		public Common()
		{
			//ApiAddress = ConfigurationManager.AppSettings["HiSpaceServiceURL"].ToString();
			//ApiAddress = "https://localhost:44339/api/";
		}

		#endregion Constructor

		#region Singleton Object

		private static readonly object padlock = new object();
		private static Common instance = null;

		public static Common Instance
		{
			get
			{
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new Common();
						}
					}
				}
				return instance;
			}
		}

		#endregion Singleton Object

		#region API Methods
		

		#region Common Controller
		public string ApiCommonControllerName
		{
			get
			{
				return ApiAddress + "Common/";
			}
		}

		public string ApiCommonGetAllPropertyLocationSearch = "GetAllPropertyLocationSearch";

		#endregion Common Controller

		#region Persons Controller

		public string ApiPersonsControllerName
		{
			get
			{
				return ApiAddress + "Persons/";
			}
		}

		public string ApiPersonsGetPersons = "GetPersons";
		public string ApiPersonsAddPerson = "AddPerson/";
		public string ApiPersonsUpdatePerson = "UpdatePerson/";
		public string ApiPersonsDeletePerson = "DeletePerson/";

		#endregion Persons Controller

		#endregion API Methods




	}
}