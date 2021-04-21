namespace SecurePasswordsDataAccess.Databases
{
    using System.Collections.Generic;
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName, 
            bool isStoredProcedure = false);

        void SaveData<T>(string sqlStatement, T parameters, string connectionStringName,
            bool isStoredProcedure = false);
    }
}