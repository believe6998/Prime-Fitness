using PrimeFitness.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeFitness.Models.Funtions
{
    public class CHITIETHDF
    {
        private PrimeFitnessDbContext context;

        public CHITIETHDF()
        {
            context = new PrimeFitnessDbContext();
        }

        // Trả về danh muc
        public IQueryable<CTHD> DSCHITIETHD
        {
            get { return context.CTHDs; }
        }

        // Trả về một đối tượng danh mục, khi biết Khóa


        // Thêm một đối tượng
        public bool Insert(CTHD model)
        {
            CTHD dbEntry = context.CTHDs.Find(model.MaHD, model.MaGT);

            if (dbEntry != null)
            {
                return false;

            }
            context.CTHDs.Add(model);
            context.SaveChanges();

            return true;
        }

        // Sửa một đối tượng
        public bool Update(CTHD model)
        {
            CTHD dbEntry = context.CTHDs.Find(model.MaHD, model.MaGT);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.SoLuong = model.SoLuong;
            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return true;
        }

        // Xóa một đối tượng
        public bool Delete(int MaDM)
        {
            CTHD dbEntry = context.CTHDs.Find(MaDM);
            if (dbEntry == null)
            {
                return false;
            }
            context.CTHDs.Remove(dbEntry);

            context.SaveChanges();
            return true;
        }
    }
}