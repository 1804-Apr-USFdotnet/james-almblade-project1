namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RRRavesDBEntities db;

        public UnitOfWork(RRRavesDBEntities context)
        {
            db = context;
            RestaurantRepo = new RestaurantRepository(context);
            ReviewRepo = new ReviewRepository(context);
        }

        public IRestaurantRepository RestaurantRepo { get; private set; }
        public IReviewRepository ReviewRepo { get; private set; }

        public int Complete()
        {
            return db.SaveChanges();
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion
    }
}
