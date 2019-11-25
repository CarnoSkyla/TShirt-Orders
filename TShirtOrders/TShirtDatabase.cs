using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TShirtOrders
{
    public class TShirtDatabase
    {
        readonly SQLiteAsyncConnection database;
        public TShirtDatabase(string dbPath)
        {
            
             
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TShirt>().Wait();
            database.CreateTableAsync<TShirtStockItem>().Wait();

            SeedDatabase();
        }

        public Task<int> InsertTShirtOrder(TShirt tshirt)
        {

            return database.InsertAsync(tshirt);
        }

        public Task<int> DeleteTShirtOrder(TShirt tshirt)
        {

            return database.DeleteAsync(tshirt);
        }

        public Task<int> UpDateTShirtOrder(TShirt tshirt)
        {

            return database.UpdateAsync(tshirt);
        }


        public Task<List<TShirt>> GetTShirtOrder()
        {

            return database.Table<TShirt>().ToListAsync();

        }

        public Task<List<TShirtStockItem>> GetShirtStockItems()
        {

            return database.Table<TShirtStockItem>().ToListAsync();

        }

        public Task<List<TShirt>> GetUnSubmittedOrders()
        {

            return database.Table<TShirt>().Where(x => x.Status == false).ToListAsync();

        }


        
        public async void SeedDatabase()
        {
            var recordCount = await database.Table<TShirtStockItem>().CountAsync();

            if (recordCount == 0)
            {
                var stockItem = new TShirtStockItem();

                stockItem.Image = "relay.jpg";
                stockItem.ShirtName =  "Relay";

                await database.InsertAsync(stockItem);

                stockItem = new TShirtStockItem();

                stockItem.Image = "fabiani.jpg";
                stockItem.ShirtName = "Fabiani";

                await database.InsertAsync(stockItem);

                stockItem = new TShirtStockItem();
                stockItem.Image = "kappa.jpg";
                stockItem.ShirtName = "Kappa";

                await database.InsertAsync(stockItem);

                stockItem = new TShirtStockItem();
                stockItem.Image = "jordan.jpg";
                stockItem.ShirtName = "Nike Jordan";


                await database.InsertAsync(stockItem);


                stockItem = new TShirtStockItem();
                stockItem.Image = "uzzi.jpg";
                stockItem.ShirtName = "Uzzi";


                await database.InsertAsync(stockItem);

                stockItem = new TShirtStockItem();
                stockItem.Image = "hemisphere.jpg";
                stockItem.ShirtName = "Hemisphere";


                await database.InsertAsync(stockItem);
            }
        }
     
    }
}
