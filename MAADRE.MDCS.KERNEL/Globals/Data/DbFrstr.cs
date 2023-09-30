using Google.Cloud.Firestore;
using MAADRE.MDCSI.KERNEL.Globals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Data
{
    public class DbFrstr
    {
        public FirestoreDb db;// = FirestoreDb.Create("fb-maadre-db");

        public DbFrstr(string id)
        {
            db = FirestoreDb.Create(id);
        }
        public async void AddItem()
        {
            CollectionReference cr = db.Collection("betterware");
            // cr.AddAsync(new { Id = Guid.NewGuid().ToString(), Name = "Articulo 1", Description = "dessdsd", Address="Source", Type="mytipe" });
        }
        public async Task<IEnumerable<Item>> GetItemCollection()
        {
            CollectionReference cr = db.Collection("betterware");
            QuerySnapshot docs = await cr.GetSnapshotAsync();

            var lst = new List<Item>();
            foreach (var doc in docs.Documents)
            {
                lst.Add(new Item
                {
                    Id = doc.Id,
                    Name = doc.GetValue<string>("Name"),
                    Description = doc.GetValue<string>("Description"),
                    Type = doc.GetValue<string>("Type")
                });
            }

            return await Task.FromResult(lst);
        }
    }
}
