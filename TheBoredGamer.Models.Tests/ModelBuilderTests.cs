using TheBoredGamer.Models.BoardGameGeek;
using Xunit;

namespace TheBoredGamer.Models.Tests
{
    public class ModelBuilderTests
    {
        [Fact]
        public void ItemMapsToGameCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Description = "test",
                Id = "123",
                Image = "test.jpg",
                Thumbnail = "thumb.jpg",
                Type = "type"
            };

            //act
            var game = modelBuilder.GetGameFromItem(item);

            //assert
            Assert.Equal("test", game.Description);
            Assert.Equal(123, game.BoardGameGeekId);
            Assert.Equal("test.jpg", game.Image);
            Assert.Equal("thumb.jpg", game.Thumbnail);
        }
    }
}
