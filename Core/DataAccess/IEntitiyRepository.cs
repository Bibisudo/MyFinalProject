using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{ //generic constraint - generic sınıfı kısıtlama. T referans tipi olsun diye bir sınır getiriyorum mesela.
    //: class -> referans tip olsun demek. 
    // IEntity: IEntity olabilir ya da IEntitiy'yi implemente eden bir nesne olabilir.
    // new'lenebilir olmalı. IEntity'i koyduğunda IEntity, category, customer ve product geliyor ancak IEntity gelsin istemiyor o yüzden new() koyuyor ki Interfaceler newlenemediği için IEntity gelmesin. (çakallık)
    public interface IEntitiyRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filterın null olması filtre vermeyedebilirsin demek.
        T Get(Expression<Func<T, bool>> filter); //tek bir data getirmek için.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        // List<T> GetAllByCategory(int categoryId);//ürünleri categoryid'ye göre filtrele demek.
        //Expression yazınca buna ihtiyaç kalmadı. Expression bizim linqli filtreler yazabilmemizi sağlıyor.
    }
}
