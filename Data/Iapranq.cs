using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data
{
    public interface Iapranq
    {
        public IEnumerable<Apranq> Apranqner { get; }
        public IEnumerable<Apranq> IsFavorit { get; }
        public IEnumerable<Apranq> IsAvalible { get; }
        public Task<Apranq> SearchAprancId(int Idapranq);
        public Task<IEnumerable<Apranq>> CategoriSearchID(int CategoryId);
        public Task<Apranq> AddApranq(Apranq a);
        public Task DeleteApranc(int AprancId);
        public Task<bool> AddCart(Cart c);
        public Task<IEnumerable<Apranq>> GetAllApranq();
        public Task<Apranq> updateApranq(Apranq z);
        public Task<IEnumerable<Apranq> >search(string categoryname, string? modelname);



    }
}
