using System;
using SecurePasswordsDataAccess.Data;
using SecurePasswordsDataAccess.Databases;

namespace SecurePasswords
{
    public class SerivceModule
    {
        private readonly IDataAccess _dataAccess;
        private readonly IDataHandler _dataHandler;

        public SerivceModule(IDataAccess dataAccess, IDataHandler dataHandler)
        {
            this._dataAccess = dataAccess;
            this._dataHandler = dataHandler;
        }
        public void Run(String[] args)
        {
            var a = _dataAccess;
            var b = _dataHandler;
        }
    }
}