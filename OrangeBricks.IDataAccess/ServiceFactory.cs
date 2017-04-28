using System;
using Microsoft.Practices.Unity;

namespace OrangeBricks.IDataAccess
{
	[Serializable]
	public class ServiceFactory : IServiceFactory
	{
		private UnityContainer _container;

		#region Singleton Implementation

		private static AmbientSingleton<IServiceFactory> _singleton;

		static ServiceFactory()
		{
			_singleton = new AmbientSingleton<IServiceFactory>(new ServiceFactory());
		}

		public static IServiceFactory Instance
		{
			get { return _singleton.Value; }
			set { _singleton.Value = value; }
		}

		private ServiceFactory()
		{
		}
		public ServiceFactory(UnityContainer container)
		{
			_container = container;
		}

		#endregion

		#region IServiceFactory Implementation
		
		public T GetService<T>()
		{
			if (_container == null)
				throw new ArgumentNullException("Container not defined.");

			try
			{
				return _container.Resolve<T>();
			}
			catch (ResolutionFailedException)
			{
				// TODO: Log
				throw;
			}
		}

		#endregion

		public static void SetDefault(IServiceFactory defaultValue)
		{
			_singleton.SetDefaultValue(defaultValue);
		}
	}
}