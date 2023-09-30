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

            // Escenario 2: Una moto sin motor no debe ser utilizable.
            Bike bikeWithoutEngine = new Bike(null, muffler, frontWheel, backWheel, chassis);

            Assert.IsFalse(bikeWithoutEngine.CanBeUsedInRace());

            // Escenario 3: Una moto sin una llanta no debe ser utilizable.
            Bike bikeWithoutFrontWheel = new Bike(engine, muffler, null, backWheel, chassis);

            Assert.IsFalse(bikeWithoutFrontWheel.CanBeUsedInRace());

            // Escenario 4: Una moto sin mofle no debe ser utilizable.
            Bike bikeWithoutMuffler = new Bike(engine, null, frontWheel, backWheel, chassis);

            Assert.IsFalse(bikeWithoutMuffler.CanBeUsedInRace());
        }

        [Test]
        public void PartCanBeAdded()
        {
            Engine engine = new Engine(1.0, 1.0);
            Muffler muffler = new Muffler(1.0, 1.0);
            FrontWheel frontWheel = new FrontWheel(1.0, 1.0, 1.0, 1.0);
            BackWheel backWheel = new BackWheel(1.0, 1.0, 1.0, 1.0);
            Chassis chassis = new Chassis();
            // Escenario 1: Una moto sin llanta delantera puede equiparse con una llanta delantera sin problemas.
            Bike bikeWithoutFrontWheel = new Bike(engine, muffler, null, backWheel, chassis);
            FrontWheel newFrontWheel = new FrontWheel(1.0, 1.0, 1.0, 1.0);

            Assert.DoesNotThrow(() => bikeWithoutFrontWheel.AddPart(newFrontWheel));

            // Escenario 2: Una moto con llanta trasera puede equiparse con una llanta trasera nueva reemplazando la anterior.
            Bike bikeWithBackWheel = new Bike(engine, muffler, frontWheel, backWheel, chassis);
            BackWheel newBackWheel = new BackWheel(1.0, 1.0, 1.0, 1.0);

            Assert.DoesNotThrow(() => bikeWithBackWheel.AddPart(newBackWheel));

            // Escenario 3: Una moto sin mofle puede equiparse con un mofle.
            Bike bikeWithoutMuffler = new Bike(engine, null, frontWheel, backWheel, chassis);
            Muffler newMuffler = new Muffler(1.0, 1.0);

            Assert.DoesNotThrow(() => bikeWithoutMuffler.AddPart(newMuffler));

            // Escenario 4: Intentar reemplazar el chasis.
            Bike bikeWithChassis = new Bike(engine, muffler, frontWheel, backWheel, chassis);
            Chassis newChassis = new Chassis();

            Assert.Throws<InvalidOperationException>(() =>
            {
                bikeWithChassis.AddChassis(newChassis);
            });
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