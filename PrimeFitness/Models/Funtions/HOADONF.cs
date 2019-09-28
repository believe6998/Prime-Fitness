using PrimeFitness.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeFitness.Models.Funtions
{
    public class HOADONF
    {
        private PrimeFitnessDbContext context;

        public HOADONF()
        {
            context = new PrimeFitnessDbContext();
        }

        // Trả về All record
        public IQueryable<HoaDon> DSHOADON
        {
            get { return context.HoaDons; }
        }
        // Trả về một đối tượng  khi biết Khóa
        public HoaDon FindEntity(int MaHD)
        {
            HoaDon dbEntry = context.HoaDons.Find(MaHD);
            return dbEntry;
        }
        // Thêm một đối tượng
        public int Insert(HoaDon model)
        {
            HoaDon dbEntry = context.HoaDons.Find(model.MaHD);

            context.HoaDons.Add(model);

            context.SaveChanges();

            return model.MaHD;
        }

        // Sửa một đối tượng
        public bool Update(HoaDon model)
        {
            HoaDon dbEntry = context.HoaDons.Find(model.MaHD);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.TenKH = model.TenKH;
            dbEntry.SoDienThoaiKH = model.SoDienThoaiKH;


            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return true;
        }

        // Xóa một đối tượng
        public bool Delete(int MaHD)
        {
            HoaDon dbEntry = context.HoaDons.Find(MaHD);
            if (dbEntry == null)
            {
                return false;
            }
            context.HoaDons.Remove(dbEntry);

            context.SaveChanges();
            return true;
        }
    }
}