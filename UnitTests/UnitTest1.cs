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
            // Arrange
            var bike = new Bike(null, null, null, null, null); // Crea una moto sin partes

            // Act & Assert
            Assert.AreEqual(0.0, bike.Speed, "Speed debe ser 0.0 al crear la moto sin motor.");
            Assert.AreEqual(0.0, bike.Acceleration, "Acceleration debe ser 0.0 al crear la moto sin alguna llanta.");
            Assert.AreEqual(0.0, bike.Handling, "Handling debe ser 0.0 al crear la moto sin llantas.");
            Assert.AreEqual(0.0, bike.Grip, "Grip debe ser 0.0 al crear la moto sin llantas.");

            // Agregar partes con modificación de parámetros 0.
            bike.AddPart(new Muffler(0.0, 0.0)); // Agrega una parte sin modificar parámetros
            bike.AddPart(new Engine(0.0, 0.0));
            bike.AddPart(new FrontWheel(0.0, 0.0, 0.0, 0.0));
            bike.AddPart(new BackWheel(0.0, 0.0, 0.0, 0.0));            

            // Act & Assert
            Assert.AreEqual(1.0, bike.Speed, "Speed no debe cambiar cuando se agrega una parte sin modificarlo.");
            Assert.AreEqual(1.0, bike.Acceleration, "Acceleration no debe cambiar cuando se agrega una parte sin modificarlo.");
            Assert.AreEqual(1.0, bike.Handling, "Handling no debe cambiar cuando se agrega una parte sin modificarlo.");
            Assert.AreEqual(1.0, bike.Grip, "Grip no debe cambiar cuando se agrega una parte sin modificarlo.");

            // Agregar partes con modificaciones de parámetros
            bike.AddPart(new Muffler(1.0, 0.8)); // Agrega una parte que modifica los parámetros

            // Act & Assert
            Assert.AreEqual(1.0, bike.Speed, "Speed no debe cambiar cuando se agrega una parte que modifica otros parámetros.");
            Assert.AreEqual(1.0, bike.Acceleration, "Acceleration no debe cambiar cuando se agrega una parte que modifica otros parámetros.");
            Assert.AreEqual(1.2, bike.Handling, "Handling debe cambiar cuando se agrega una parte que modifica Handling.");
            Assert.AreEqual(0.8, bike.Grip, "Grip debe cambiar cuando se agrega una parte que modifica Grip.");

            // Agregar más partes
            bike.AddPart(new FrontWheel(0.3, 0.1, 0.5, 0.4)); // Agrega otra parte que modifica los parámetros

            // Act & Assert
            Assert.AreEqual(1.0, bike.Speed, "Speed no debe cambiar cuando se agregan partes que modifican otros parámetros.");
            Assert.AreEqual(1.1, bike.Acceleration, "Acceleration debe cambiar cuando se agregan partes que modifican Acceleration.");
            Assert.AreEqual(1.7, bike.Handling, "Handling debe cambiar cuando se agregan partes que modifican Handling.");
            Assert.AreEqual(1.2, bike.Grip, "Grip debe cambiar cuando se agregan partes que modifican Grip.");

            // Verificar que todos los parámetros estén dentro de los límites
            Assert.IsTrue(bike.Speed >= 1.0 && bike.Speed <= 5.0, "Speed debe estar dentro de los límites.");
            Assert.IsTrue(bike.Acceleration >= 1.0 && bike.Acceleration <= 5.0, "Acceleration debe estar dentro de los límites.");
            Assert.IsTrue(bike.Handling >= 1.0 && bike.Handling <= 5.0, "Handling debe estar dentro de los límites.");
            Assert.IsTrue(bike.Grip >= 1.0 && bike.Grip <= 5.0, "Grip debe estar dentro de los límites.");
        }

        [Test]
        public void MaxParameterValueOnConstructor()
        {

        }
    }
}