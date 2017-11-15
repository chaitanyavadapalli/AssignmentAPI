using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myapp1.Models
{
    public class searchmodel
    {

      private  string fname;

        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }

        private string lname;

        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }
        private string dob;

        public string Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        private string appid;

        public string Appid
        {
            get { return appid; }
            set { appid = value; }
        }

    }
}