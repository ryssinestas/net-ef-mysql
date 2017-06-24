using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Project.Data.Mappings;

namespace Project.Data
{
    public class BaseContext<T> : DbContext where T : class
    {
        public DbSet<T> DbSet
        {
            get;
            set;
        }
        public BaseContext(): base("MyContext")
        {
            //Inicializa a base de dados
            Database.SetInitializer<BaseContext<T>>(null);
            base.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Carrega todos os mapeamentos que possuem IMapping como interface
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                select x).ToList();

            //Busca por todos os mapeamentos a serem adicionados no EF
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }
        }

        public virtual void ChangeObjectState(object model, EntityState state)
        {
            //Troca de estado do objeto, facilitando alterações e exclusões
            ((IObjectContextAdapter)this)
                          .ObjectContext
                          .ObjectStateManager
                          .ChangeObjectState(model, state);
        }

        public virtual int Save(T model)
        {
            this.DbSet.Add(model);
            return this.SaveChanges();
        }

        public virtual int Update(T model)
        {
            var entry = this.Entry(model);
            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(model);

            this.ChangeObjectState(model, EntityState.Modified);
            return this.SaveChanges();
        }

        public virtual void Delete(T model)
        {
            var entry = this.Entry(model);
            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(model);

            this.ChangeObjectState(model, EntityState.Deleted);
            this.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return this.DbSet.Where(expression);
        }

        public IEnumerable<T> OrderBy(Expression<Func<T, bool>> expression)
        {
            return this.DbSet.OrderBy(expression);
        }
    }
}
