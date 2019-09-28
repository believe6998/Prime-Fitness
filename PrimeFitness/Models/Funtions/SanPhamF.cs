using PrimeFitness.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeFitness.Models.Funtions
{
    public class SanPhamF
    {
        private PrimeFitnessDbContext context;

        public SanPhamF()
        {
            context = new PrimeFitnessDbContext();
        }

        // Trả về All record
        public IQueryable<GoiTap> DSSanPham
        {
            get { return context.GoiTaps; }
        }

        public GoiTap FindEntity(string id)
        {
            GoiTap dbEntry = context.GoiTaps.Find(id);
            return dbEntry;
        }
    }
}