using System;
using System.Collections.Generic;
using System.Web;

namespace Model
{
    /// <summary>
    /// ManagerModel 的摘要说明
    /// </summary>
    public class ManagerModel
    {
        private int manager_ID;

        public int Manager_ID
        {
            get { return manager_ID; }
            set { manager_ID = value; }
        }

        private string manager_Name;

        public string Manager_Name
        {
            get { return manager_Name; }
            set { manager_Name = value; }
        }

        private string manager_Pwd;

        public string Manager_Pwd
        {
            get { return manager_Pwd; }
            set { manager_Pwd = value; }
        }
    }

}
