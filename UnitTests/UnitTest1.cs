using Parcial2;
namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void BikeCanBeCreated()
        {
            Engine engine = new Engine(1.0, 1.0);
            Muffler muffler = new Muffler(1.0, 1.0);
            FrontWheel frontWheel = new FrontWheel(1.0, 1.0, 1.0, 1.0);
            BackWheel backWheel = new BackWheel(1.0, 1.0, 1.0, 1.0);

            Bike bikeWithChassis = new Bike(engine, muffler, frontWheel, backWheel, new Chassis());
            Bike bikeWithoutChassis = new Bike(engine, muffler, frontWheel, backWheel, null);

            Assert.IsNotNull(bikeWithChassis);
            Assert.IsNotNull(bikeWithoutChassis);
        }

        [Test]
        public void BikesCanBeUsed()
        {

        }

        [Test]
        public void PartCanBeAdded()
        {

        }

        [Test]
        public void PartsModifyParameters()
        {

        }

        [Test]
        public void MaxParameterValueOnConstructor()
        {

        }
    }
}