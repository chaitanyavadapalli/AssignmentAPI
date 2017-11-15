using ClassLibrary1;
using Myapp1.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Myapp1.Controllers
{
    public class FamilydetailsController : ApiController
    {
       


        public HttpResponseMessage Post(JObject obj)
        {
            string s = obj.ToString();
            JObject uploadData = JObject.Parse(s);
            var array = uploadData.SelectToken("obj");
            int fid = 0;
            IconceptdbEntities e = new IconceptdbEntities();
            var f = (from e1 in e.familidetails
                     select e1);
            
                int max = 0;
                foreach (familidetail fd in f)
                {
                    if (int.Parse(fd.familyid) > max)
                    {
                        max = int.Parse(fd.familyid);
                    }
                }
                fid = max + 1;

            int memid = 1;
            foreach (var i in array)
            {
                familidetail f1 = new familidetail();
                f1.familyid = fid.ToString();
                f1.memberid = memid;
                f1.firstname = i["fname"].ToString();
                f1.middlename = i["mname"].ToString();
                f1.lastname = i["lname"].ToString();
                f1.city = i["city"].ToString();
                f1.dob = DateTime.Parse(i["dob"].ToString());
                f1.gender = i["gender"].ToString();
                e.familidetails.Add(f1);
                e.SaveChanges();
                memid++;
            }

            return Request.CreateResponse(HttpStatusCode.OK, fid.ToString());

        }
        [HttpGet]
        public IEnumerable<familidetail> Get([FromUri] JObject obj)
        {
            String [] s1 = HttpUtility.UrlDecode((Convert.ToString(Request.RequestUri))).Split('=');
            JObject j = JObject.Parse(s1[1]);
            var array = j.SelectToken("obj");
            IconceptdbEntities e = new IconceptdbEntities();
            foreach (var i in array)
            {
                var fname = i["fname"].ToString();
                var lname = i["lname"].ToString();
                var dob = i["dob"].ToString();
                var appid = i["appid"].ToString();
                if(dob!="Invalid Date"&&fname!=""&&lname!=""&&appid!="")
                {
                    var d = DateTime.Parse(dob);
                    var f = (from e1 in e.familidetails
                             where e1.familyid==appid&&e1.firstname==fname&&e1.lastname==lname&&e1.dob==d
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;

                }
                else if (fname != "" && lname != "" && appid != "")
                {
                    var f = (from e1 in e.familidetails
                             where e1.familyid == appid && e1.firstname == fname && e1.lastname == lname
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(lname != "" && appid != ""&&dob!="")
                {
                    var d = DateTime.Parse(dob);
                    var f = (from e1 in e.familidetails
                             where e1.familyid == appid && e1.lastname == lname && e1.dob == d
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(fname != "" && lname != ""&&dob!="")
                {
                    var d = DateTime.Parse(dob);
                    var f = (from e1 in e.familidetails
                             where e1.firstname==fname&& e1.lastname == lname && e1.dob == d
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(fname != "" && appid != ""&&dob!="")
                {
                    var d = DateTime.Parse(dob);
                    var f = (from e1 in e.familidetails
                             where e1.familyid == appid && e1.firstname == fname && e1.dob == d
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(fname!=""&&lname!="")
                {
                    var f = (from e1 in e.familidetails
                             where e1.lastname== lname && e1.firstname == fname
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(lname!=""&&dob!="")
                {
                    var d = DateTime.Parse(dob);
                    var f = (from e1 in e.familidetails
                             where e1.lastname == lname && e1.dob == d
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(appid!=""&&dob!="")
                {
                    var d = DateTime.Parse(dob);
                    var f = (from e1 in e.familidetails
                             where e1.familyid == appid && e1.dob == d
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(appid!=""&&fname!="")
                {

                    var f = (from e1 in e.familidetails
                             where e1.familyid == appid && e1.firstname==fname
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(appid!=""&&lname!="")
                {
                    var f = (from e1 in e.familidetails
                             where e1.familyid == appid && e1.lastname == lname
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if (fname!= "" && dob != "")
                {
                    var d = DateTime.Parse(dob);
                    var f = (from e1 in e.familidetails
                             where e1.firstname == fname && e1.dob == d
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(fname!="")
                {
                    var f = (from e1 in e.familidetails
                             where e1.firstname == fname
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(lname!="")
                {
                    var f = (from e1 in e.familidetails
                             where e1.lastname == lname
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(dob!="")
                {

                    var v = DateTime.Parse(dob);
                    var f = (from e1 in e.familidetails
                             where  e1.dob==v
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach(familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                else if(appid!="")
                {
                    var f = (from e1 in e.familidetails
                             where e1.familyid==appid
                             select e1
                             );
                    List<familidetail> l = new List<familidetail>();
                    foreach (familidetail t in f)
                    {
                        l.Add(t);
                    }
                    return l;
                }
                //else if(appid!=""&&fname!="")
                //{
                //    var f = (from e1 in e.familidetails
                //             where e1.familyid == appid && e1.firstname==
                //             select e1
                //             );
                //    return Request.CreateResponse(HttpStatusCode.OK, f);
                //}



            }
            return null;

        }
        public HttpResponseMessage Put([FromUri]JObject obj)
        {


            String[] s1 = HttpUtility.UrlDecode((Convert.ToString(Request.RequestUri))).Split('=');
            JObject j = JObject.Parse(s1[1]);
            var array = j.SelectToken("obj");
            string fid=array[0]["fid"].ToString();

            int mid = int.Parse(array[0]["mid"].ToString());

            IconceptdbEntities i = new IconceptdbEntities();

            familidetail t=(from e1 in i.familidetails
                  where e1.familyid==fid && e1.memberid==mid
                  select e1).First();
            t.firstname = array[0]["fname"].ToString();
            t.middlename = array[0]["mname"].ToString();
            t.lastname = array[0]["lname"].ToString();
            t.city = array[0]["city"].ToString();
            t.dob = DateTime.Parse(array[0]["dob"].ToString());
            t.gender = array[0]["gender"].ToString();
            i.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Record Modified");

        }
        public HttpResponseMessage Delete([FromUri] JObject obj)
        {
            String[] s1 = HttpUtility.UrlDecode((Convert.ToString(Request.RequestUri))).Split('=');
            JObject j = JObject.Parse(s1[1]);
            var array = j.SelectToken("obj");
            string fid = array[0]["fid"].ToString();

            int mid = int.Parse(array[0]["mid"].ToString());

            IconceptdbEntities i = new IconceptdbEntities();

            familidetail t = (from e1 in i.familidetails
                              where e1.familyid == fid && e1.memberid == mid
                              select e1).First();
            i.familidetails.Remove(t);
            i.SaveChanges();         
            return Request.CreateResponse(HttpStatusCode.OK, "Record Deleted");

        }





    }
}
