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
            // Una moto con todas sus partes debe ser utilizable.
            Engine engine = new Engine(1.0, 1.0);
            Muffler muffler = new Muffler(1.0, 1.0);
            FrontWheel frontWheel = new FrontWheel(1.0, 1.0, 1.0, 1.0);
            BackWheel backWheel = new BackWheel(1.0, 1.0, 1.0, 1.0);
            Chassis chassis = new Chassis();

            Bike bikeWithAllParts = new Bike(engine, muffler, frontWheel, backWheel, chassis);

            Assert.IsTrue(bikeWithAllParts.CanBeUsedInRace());

            //Una moto sin motor debe lanzar una excepción.
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Bike(null, muffler, frontWheel, backWheel, chassis);
            });

            //Una moto sin una llanta debe lanzar una excepción.
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Bike(engine, muffler, null, backWheel, chassis);
            });

            //Una moto sin mofle debe lanzar una excepción.
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Bike(engine, null, frontWheel, backWheel, chassis);
            });
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