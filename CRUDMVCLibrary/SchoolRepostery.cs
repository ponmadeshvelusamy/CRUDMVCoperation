using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMVCLibrary
{
    public  class SchoolRepostery
    {
        SqlConnection connobj;
        IConfiguration configur;
        public SchoolRepostery(IConfiguration configo)
        {
            configur = configo;
            var configoobj = configur.GetConnectionString("DbConnection");
            connobj=new SqlConnection(configoobj);
        }
        public void Schoolin(Schoolmodel refer)
        {
            try
            {

                var Insert = $"exec Inserting '{refer.SchoolName}',{refer.ContactNo},'{refer.Email}','{refer.Address}',{refer.Pincode}";
                connobj.Open();
                connobj.Execute(Insert);
                connobj.Close();
            }
            catch (SqlException )
            {
                throw;
            }
            catch(Exception )
            {
                throw;
            }
        }
        public IEnumerable<Schoolmodel> Showall()
        {
            try
            {
                var Showall = $"select * from SchoolDetails";
                connobj.Open();
                var result = connobj.Query<Schoolmodel>(Showall);
                connobj.Close();
                return result;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Schoolmodel> getbyID(long SchoolID)
        {
            try
            {
                var search = $"exec serachDetails {SchoolID}";
                connobj.Open();
                var data = connobj.Query<Schoolmodel>(search);
                connobj.Close();
                return data;
            }
            catch (SqlException )
            {

                throw;
            }
            catch( Exception )
            {
                throw;
            }            
        }
        public void Update(Schoolmodel objname)
        {
            try
            {
                var Edit = ($"exec EditorUpdate {objname.SchoolID},'{objname.SchoolName}',{objname.ContactNo},'{objname.Email}','{objname.Address}',{objname.Pincode}");
                connobj.Open();
                connobj.Execute(Edit);
                connobj.Close();
            }
            catch(SqlException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void Delete(long Schoolid)
        {
            try
            {
                var delete =($"exec DeleteDetails {Schoolid}");
                connobj.Open();
                connobj.Execute(delete);
                connobj.Close();
            }
            catch( SqlException )
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
