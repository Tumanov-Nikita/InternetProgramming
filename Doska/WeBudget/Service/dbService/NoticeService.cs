using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service
{
	public class NoticeService : IDoska
	{
        DoskaContext db = new DoskaContext();
        public  void Delete(int id)
        {
            Notice b = db.Notices.Find(id);
            if (b != null)
            {
                db.Notices.Remove(b);
                db.SaveChanges();
            }
        }

        public  void Edit (BaseEntity baseEntity)
        {
            db.Entry((Notice)baseEntity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public  void Create(BaseEntity baseEntity)
        {
            db.Notices.Add((Notice)baseEntity);
            db.SaveChanges();
        }

        public  BaseEntity findById(int? id)
        {
            Notice Notice = db.Notices.Find(id);
            return Notice;
        }

        public  List<BaseEntity> getList()
        {
            List<BaseEntity> baseentity = new List<BaseEntity>();
            List<Notice> Notice = db.Notices.ToList();
            for (int i = 0; i < Notice.Count; i++)
            {
                baseentity.Add(Notice[i]);
            }
            return baseentity;
        }    
    }
}
