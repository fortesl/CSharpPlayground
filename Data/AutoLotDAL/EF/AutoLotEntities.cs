namespace AutoLotDAL.EF
{
    using AutoLotDAL.Interception;
    using AutoLotDAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;

    public partial class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger DatabaseLogger =
          new DatabaseLogger("sqllog.txt", true);
        public AutoLotEntities() : base("name=AutoLotConnection")
        {
            //DbInterception.Add(new ConsoleWriterInterceptor());
            DatabaseLogger.StartLogging();
            DbInterception.Add(DatabaseLogger);

            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;
        }

        private void OnSavingChanges(object sender, EventArgs e)
        {
            //Sender is of type ObjectContext.  Can get current and original values, and
            //cancel/modify the save operation as desired.
            var context = sender as ObjectContext;
            if (context == null) return;
            foreach (ObjectStateEntry item in
              context.ObjectStateManager.GetObjectStateEntries(
                EntityState.Modified | EntityState.Added))
            {
                //Do something important here
                if ((item.Entity as Inventory) != null)
                {
                    var entity = (Inventory)item.Entity;
                    if (entity.Color == "Red")
                    {
                        item.RejectPropertyChanges(nameof(entity.Color));
                    }
                }
            }
        }

        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);

        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);
        }
    }
}
