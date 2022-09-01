using Sten_saks_papir.Models;
using Sten_saks_papir.Repo;
using System.Collections.Generic;
using Xunit;

namespace Sten_saks_papir_tests
{
    public class UnitTest1
    {
        PlayerRepo _r = new PlayerRepo();
        MatchRepo _m = new MatchRepo();

        [Fact]
        public void ReadAllPlayers()
        {
            // Arrange + act
            _r.Save(new Player() { Name = "John", Option = "Sten" });
            _r.Save(new Player() { Name = "Jane", Option = "Saks" });
            _r.Save(new Player() { Name = "Taylor", Option = "Papir" });


            Assert.Equal(3, _r.ReadAllPlayers().Count);
        }

        [Fact]
        public void FindPlayer()
        {
            // Arrange
            _r.Save(new Player
            {
                Name = "John",
                Option = "Sten",
                IsAlone = true,
            });

            // Act
            Player player = _r.FindPlayer("John");

            // Assert
            Assert.Equal("John", player.Name);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            Player player = new Player
            {
                Name = "John",
                IsAlone = true
            };

            _r.Save(player);

            // Act
            _r.Update(player, "Sten");
            string Option = _r.FindPlayer("John").Option;

            // Assert
            Assert.Equal("Sten", Option);
        }

        [Fact]
        public void Computer()
        {
            // Arrange + Act
            Player Computer = _r.Computer();

            // Assert
            Assert.True(Computer.IsAlone);
        }
    }

    public class MatchRepoTest
    {
        MatchRepo _m = new MatchRepo();

        [Fact]
        public void ReadAllMatches()
        {
            // Arrange + act
            _m.Save(
                new Match
                { 
                    Id = "Test-1",  
                    Player1 = new Player
                    {
                        Name = "John"
                    },
                    Player2 = new Player
                    {
                        Name = "Jane"
                    }
                });

            // Assert
            Assert.Single(_m.ReadAllMatches());
        }

        [Fact]
        public void FindMatch()
        {
            // Arrange
            _m.Save(
                new Match
                {
                    Id = "Test-1",
                    Player1 = new Player
                    {
                        Name = "John"
                    },
                    Player2 = new Player
                    {
                        Name = "Jane"
                    }
                });

            // Act
            Match match = _m.FindMatch("Test-1");

            // Assert
            Assert.Equal("Test-1", match.Id);
        }

        // Create match
        [Fact]
        public void Save()
        {
            // Arrange + act
            _m.Save(
                new Match
                {
                    Id = "Test-1",
                    Player1 = new Player
                    {
                        Name = "John"
                    },
                    Player2 = new Player
                    {
                        Name = "Jane"
                    }
                });

            // Assert
            Assert.Single(_m.ReadAllMatches());
        }
    }
}
