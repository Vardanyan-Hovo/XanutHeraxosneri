using Microsoft.EntityFrameworkCore;
using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data.Repositorys
{
    public class RepositoryApranq : Iapranq
    {
        private readonly ApplicationDbContext Db;
        public RepositoryApranq(ApplicationDbContext _db)
        {
            Db = _db;   
        }

        public IEnumerable<Apranq> Apranqner => Db.ApranqnerDb.Include(s=>s.categoryA);
        public IEnumerable<Apranq> IsFavorit => Db
            .ApranqnerDb.Where(c => c.IsFavorit).Include(c=>c.categoryA);

        public IEnumerable<Apranq> IsAvalible =>Db.ApranqnerDb.Where(c=>c.Available>0);


        public async Task<IEnumerable<Apranq>> GetAllApranq()
        {
            return await Db.ApranqnerDb.ToListAsync();
        }

       public async Task<Apranq> AddApranq(Apranq a)
        {
            if(a.categoryA!=null)
              Db.Entry(a.categoryA).State=EntityState.Unchanged;
            if (a == null)
                return null;

            await Db.ApranqnerDb.AddAsync(a);
            await Db.SaveChangesAsync();

            var result=await SearchAprancId(a.Id);
            return result;
        }
        public async Task <bool>AddCart(Cart c)
        {
            if (c != null)
            { 
               foreach(var s in IsAvalible)
                {
                    if(s.Id ==c.Apranq.Id )
                    {
                        await Db.cartsDb.AddAsync(c);
                        return true;
                    }
                }
             }


            return false;
        }

        public async Task<Apranq> SearchAprancId(int Idapranq)
        {
            if (Idapranq <= 0)
            {
                return null;
            }
            var result = await Db.ApranqnerDb//.Include(d=>d.categoryA)
                .FirstOrDefaultAsync(p => p.Id == Idapranq);
            
            return result;
        }

        public async Task DeleteApranc(int AprancId)
        {
            if(AprancId >0)
            {
                var z = await SearchAprancId(AprancId);
                if(z!=null)
                {
                    Db.ApranqnerDb.Remove(z);
                    await Db.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Apranq>> CategoriSearchID(int CategoryId)
        {
            if(CategoryId<=0)
            {
                return null;
            }
          
            return await Db.ApranqnerDb.Where(c => c.idCategory == CategoryId).ToListAsync();
        }


        public async Task<Apranq> updateApranq(Apranq z)
        {
            var x = await SearchAprancId(z.Id);
            if(x!=null)
            {
                x.Apranctime = DateTime.Now;
                x.IsFavorit = z.IsFavorit;
                x.Available = z.Available;
                x.Longdesc = z.Longdesc;
                x.img=z.img;
                x.Price = z.Price;
                x.Name = z.Name;
                x.Desc = z.Desc;
                x.categoryA = z.categoryA;
                x.idCategory = z.idCategory;
                Db.ApranqnerDb.Update(x);
                 await Db.SaveChangesAsync();
                return await SearchAprancId(x.Id);
            }
            return null;
            
        }


        public  async Task<IEnumerable<Apranq>> search(string? categoryname, string? modelname)
        {

            IQueryable<Apranq> result = Db.ApranqnerDb;

            if(modelname != null)
                {
               result=Db.ApranqnerDb.Where(c => c.Name.Contains(modelname)); 
                }
            if(categoryname != null)
               {
              result=Db.ApranqnerDb.Where(c=>c.categoryA.Name.Contains(categoryname));
               }
            if (result != null)
                return await result.Include(e=>e.categoryA).ToListAsync();

            return null;
        }
    
    }
}