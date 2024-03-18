/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 04 -  Loyalty Card Scheme
*  Date     :  	5th October 2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*  Version  :   0.0.1
************************************************************************************************************/
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.UnitOfWork;

namespace ZR.Business.Services
{
    public class ServiceManager : IDisposable
    {

        private UnitOfWork _UnitOfWork;
        private readonly Dictionary<Type, IService> _Services = new Dictionary<Type, IService>();


        public ServiceManager()
        {
            _UnitOfWork = new UnitOfWork();
        }




        public void RefreshConnection()
        {
            _UnitOfWork.RefreshConnection();


            _UnitOfWork = new UnitOfWork();

            _Services.Clear();
        }
        public int Services => _Services.Count;



        public T Service<T>() where T : IService
        {
            if (_Services.ContainsKey(typeof(T)))
            {
                return (T)_Services[typeof(T)];
            }

            T? service = ServiceFactory.GetService<T>(_UnitOfWork);
            _Services.Add(typeof(T), service);
            return service;
        }


        public void Remove<T>() where T : IService
        {
            if (_Services.ContainsKey(typeof(T)))
            {
                _Services[typeof(T)].Dispose();
                _Services.Remove(typeof(T));
            }
        }

        public void Dispose()
        {

            foreach (KeyValuePair<Type, IService> service in _Services)
            {
                service.Value.Dispose();
            }


            _Services.Clear();


            _UnitOfWork.Dispose();
        }
    }
}
