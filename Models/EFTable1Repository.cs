using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// references

namespace WebApplication2.Models
{


    public class EFTable1Repository : Table1Repository
    {

        // repository for CRUD with Table1 in SQL Server db

        // db connection moved here from Table1Controller
        Model1 db = new Model1();

        public IQueryable<Table1> Table1 { get { return db.Table1; } } 

        public void Delete(Table1 table1)
        {
            db.Table1.Remove(table1);
            db.SaveChanges();
        }

        public Table1 Save(Table1 table1)
        {
            if (table1.Price == 0)
            {
                db.Table1.Add(table1);
            }
            else
            {
                db.Entry(table1).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return table1;
        }
    }
}