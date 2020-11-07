using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookSystem
{
    public class LinqOperations
    {
        DataTable dataTable; 
        
        /// <summary>
        /// UC1_createDataTable
        /// </summary>
        public void createDataTable()
        {
            dataTable = new DataTable();
        }

    }
}
