using System;
using TheBoredGamer.Models;
using TheBoredGamer.Models.BoardGameGeek;

namespace TheBoredGamer.DAL
{
    public class Repository
    {
        private readonly ModelBuilder _modelBuilder = new ModelBuilder();

        public void SaveItems(Items items)
        {
            var game = _modelBuilder.GetGameFromItem(items.Item);


        }
    }
}
