using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrimeFitness.Models.Entities;

namespace PrimeFitness.Models.Funtions
{
    public class NguoiDungF
    {
        private PrimeFitnessDbContext context;

        public Account Login(string username, string pass)
        {
            var result = context.NguoiDungs.Where(a => a.UserName.Equals(username) &&
                                                       a.Password.Equals(pass)).FirstOrDefault();
            Account t = null;
            if (result != null)
            {
                t = new Account();
                t.UserName = result.UserName;
                t.Password = result.Password;

            }
            return t;
        }

        public NguoiDungF()
        {
            context = new PrimeFitnessDbContext();
        }
        // Trả về All record
        public IQueryable<NguoiDung> DSNguoiDung
        {
            get { return context.NguoiDungs; }
        }
        // Trả về một đối tượng  khi biết Khóa

        public NguoiDung FindEntity(string id)
        {
            NguoiDung dbEntry = context.NguoiDungs.Find(id);
            return dbEntry;
        }
        // Thêm một đối tượng
        public bool Insert(NguoiDung model)
        {
            NguoiDung dbEntry = context.NguoiDungs.Find(model.UserName);

            if (dbEntry != null)
            {
                return false;

            }
            context.NguoiDungs.Add(model);
            context.SaveChanges();

            return true;
        }

        // Sửa 1 đối tượng
        public bool Update(NguoiDung model)
        {
            NguoiDung dbEntry = context.NguoiDungs.Find(model.UserName);

            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.Password = model.Password;
            dbEntry.HoTen = model.HoTen;

            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return true;
        }
        // Xóa một đối tượng
        public bool Delete(string id)
        {
            NguoiDung dbEntry = context.NguoiDungs.Find(id);
            if (dbEntry == null)
            {
                return false;
            }
            context.NguoiDungs.Remove(dbEntry);

            context.SaveChanges();
            return true;
        }
    }
}