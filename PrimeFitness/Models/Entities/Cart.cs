using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeFitness.Models.Entities
{
    [Serializable]
    public class CartItem
    {
        public GoiTap Goitap { get; set; }
        public int Quantity { set; get; }
    }

    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(GoiTap gt, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Goitap.MaGT == gt.MaGT)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    Goitap = gt,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
                if (line.Quantity <= 0)
                {
                    lineCollection.RemoveAll(l => l.Goitap.MaGT == gt.MaGT);
                }
            }
        }
        public void UpdateItem(GoiTap gt, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Goitap.MaGT == gt.MaGT)
                .FirstOrDefault();

            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.Goitap.MaGT == gt.MaGT);
                }
            }
        }
        public void RemoveLine(GoiTap gt)
        {
            lineCollection.RemoveAll(l => l.Goitap.MaGT == gt.MaGT);
        }

        public double? ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Goitap.GiaGT * e.Quantity);

        }
        public int? ComputeTotalProduct()
        {
            return lineCollection.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }

    }
}