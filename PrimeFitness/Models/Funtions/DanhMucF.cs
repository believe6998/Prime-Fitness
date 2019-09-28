using PrimeFitness.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeFitness.Models.Funtions
{
    public class DanhMucF
    {
        private PrimeFitnessDbContext context;

        public DanhMucF()
        {
            context = new PrimeFitnessDbContext();
        }

        // Trả về All record
        public IQueryable<DanhMuc> DSDanhMuc
        {
            get { return context.DanhMucs; }
        }
        // Trả về một đối tượng  khi biết Khóa
        public DanhMuc FindEntity(string id)
        {
            DanhMuc dbEntry = context.DanhMucs.Find(id);
            return dbEntry;
        }
    }
}