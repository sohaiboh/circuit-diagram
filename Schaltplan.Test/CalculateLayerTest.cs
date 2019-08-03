using NUnit.Framework;
using Schaltplan.Framework.BauElement;
using Schaltplan.Framework.BauElement.Bauelementeklassen;
using Schaltplan.Framework.Gemeric;

namespace Schaltplan.Test
{
    public class CalculateLayerTest
    {
        [Test]
        public void WhenCalculatingSeriesCircuit_ThenTotalResistanceIsFound()
        {
            var circuit = new schaltplan();

            // Add elements to the circuit
            // 1. Battery
            var battery = new SpannungQuelle {V = 230};
            var resistor1 = new Widerstand {R = 100};
            var resistor2 = new Widerstand {R = 100};

            var connectionBatteryToResistor = new Connection(battery, resistor1);
            var connectionResistorToResistor = new Connection(resistor1, resistor2);
            var connectionResistorToBattery = new Connection(resistor2, battery);

            circuit.bauelements.Add(battery);
            circuit.bauelements.Add(resistor1);
            circuit.bauelements.Add(resistor2);
            circuit.connections.Add(connectionBatteryToResistor);
            circuit.connections.Add(connectionResistorToResistor);
            circuit.connections.Add(connectionResistorToBattery);

            var summe = 0.1;
            circuit.prepare();

            summe = circuit.CalculateLayerResistance(battery);

            Assert.That(summe, Is.EqualTo(200));
        }



        [Test]
        public void WhenFindingAllChildResistorElementsInParallel_ThenResistorsFound()
        {
            var circuit = new schaltplan();

            // Add elements to the circuit
            // 1. Battery
            var battery = new SpannungQuelle { V = 230 };
            var resistor1 = new Widerstand { R = 100 };
            var resistor2 = new Widerstand { R = 100 };

            var connectionBatteryToResistor1 = new Connection(battery, resistor1);
            var connectionBatteryToResistor2 = new Connection(battery, resistor2);
            var connectionResistor1ToBattery = new Connection(resistor1, battery);
            var connectionResistor2ToBattery = new Connection(resistor2, battery);

            circuit.bauelements.Add(battery);
            circuit.bauelements.Add(resistor1);
            circuit.bauelements.Add(resistor2);
            circuit.connections.Add(connectionBatteryToResistor1);
            circuit.connections.Add(connectionBatteryToResistor2);
            circuit.connections.Add(connectionResistor1ToBattery);
            circuit.connections.Add(connectionResistor2ToBattery);

            circuit.prepare();

            var childElementList = circuit.LoadAllConnectionSameStartElement(circuit, battery);

            Assert.That(childElementList.Count, Is.EqualTo(2));
        }


        [Test]
        public void WhenCalculatingParallelCircuit_ThenTotalResistanceIsFound()
        {
            var circuit = new schaltplan();

            // Add elements to the circuit
            // 1. Battery
            var battery = new SpannungQuelle { V = 230 };
            var resistor1 = new Widerstand { R = 100 };
            var resistor2 = new Widerstand { R = 100 };

            var connectionBatteryToResistor1 = new Connection(battery, resistor1);
            var connectionBatteryToResistor2 = new Connection(battery, resistor2);
            var connectionResistor1ToBattery = new Connection(resistor1, battery);
            var connectionResistor2ToBattery = new Connection(resistor2, battery);

            circuit.bauelements.Add(battery);
            circuit.bauelements.Add(resistor1);
            circuit.bauelements.Add(resistor2);
            circuit.connections.Add(connectionBatteryToResistor1);
            circuit.connections.Add(connectionBatteryToResistor2);
            circuit.connections.Add(connectionResistor1ToBattery);
            circuit.connections.Add(connectionResistor2ToBattery);

            var summe = 0.1;

            circuit.prepare();

            summe = circuit.CalculateLayerResistance(battery);

            Assert.That(summe, Is.EqualTo(50));
        }

        [Test]
        public void WhenCalculatingParallelCircuitWithSeriesFollowing_ThenTotalResistanceIsFound()
        {
            var circuit = new schaltplan();

            // Add elements to the circuit
            // 1. Battery
            var battery = new SpannungQuelle { V = 230 };
            var resistor1 = new Widerstand { R = 100 };
            var resistor2 = new Widerstand { R = 100 };
            var resistor3 = new Widerstand { R = 100 };

            var connectionBatteryToResistor1 = new Connection(battery, resistor1);
            var connectionBatteryToResistor2 = new Connection(battery, resistor2);
            var connectionResistor1ToResistor3 = new Connection(resistor1, resistor3);
            var connectionResistor2ToResistor3 = new Connection(resistor2, resistor3);
            var connectionResistor3ToBattery = new Connection(resistor3, battery);

            circuit.bauelements.Add(battery);
            circuit.bauelements.Add(resistor1);
            circuit.bauelements.Add(resistor2);
            circuit.connections.Add(connectionBatteryToResistor1);
            circuit.connections.Add(connectionBatteryToResistor2);
            circuit.connections.Add(connectionResistor1ToResistor3);
            circuit.connections.Add(connectionResistor2ToResistor3);
            circuit.connections.Add(connectionResistor3ToBattery);

            var summe = 0.1;

            circuit.prepare();

            summe = circuit.CalculateLayerResistance(battery);

            Assert.That(summe, Is.EqualTo(150));
        }


        [Test]
        public void WhenCalculatingSeriesCircuitWithParallelFollowing_ThenTotalResistanceIsFound()
        {
            var circuit = new schaltplan();

            // Add elements to the circuit
            // 1. Battery
            var battery = new SpannungQuelle { V = 230 };
            var resistor1 = new Widerstand { R = 100 };
            var resistor2 = new Widerstand { R = 100 };
            var resistor3 = new Widerstand { R = 100 };

            var connectionBatteryToResistor1 = new Connection(battery, resistor1);
            var connectionResistor1ToResistor2 = new Connection(resistor1, resistor2);
            var connectionResistor1ToResistor3 = new Connection(resistor1, resistor3);
            var connectionResistor2ToBattery = new Connection(resistor2, battery);
            var connectionResistor3ToBattery = new Connection(resistor3, battery);

            circuit.bauelements.Add(battery);
            circuit.bauelements.Add(resistor1);
            circuit.bauelements.Add(resistor2);
            circuit.connections.Add(connectionBatteryToResistor1);
            circuit.connections.Add(connectionResistor1ToResistor2);
            circuit.connections.Add(connectionResistor1ToResistor3);
            circuit.connections.Add(connectionResistor2ToBattery);
            circuit.connections.Add(connectionResistor3ToBattery);

            var summe = 0.1;

            circuit.prepare();

            summe = circuit.CalculateLayerResistance(battery);

            Assert.That(summe, Is.EqualTo(150));
        }

        [Test]
        public void WhenCalculatingSeriesCircuitWithParallelFollowingWithDiodeInside_ThenTotalResistanceIsFound()
        {
            var circuit = new schaltplan();

            // Add elements to the circuit
            // 1. Battery
            var battery = new SpannungQuelle { V = 230 };
            var resistor1 = new Widerstand { R = 100 };
            var resistor2 = new Widerstand { R = 100 };
            var resistor3 = new Widerstand { R = 100 };
            var diode = new Diode();

            var connectionBatteryToResistor1 = new Connection(battery, resistor1);
            var connectionResistor1ToDiode = new Connection(resistor1, diode);
            var connectionDiodeToResistor2 = new Connection(resistor1, resistor2);
            var connectionDiodeToResistor3 = new Connection(resistor1, resistor3);
            var connectionResistor2ToBattery = new Connection(resistor2, battery);
            var connectionResistor3ToBattery = new Connection(resistor3, battery);

            circuit.bauelements.Add(battery);
            circuit.bauelements.Add(resistor1);
            circuit.bauelements.Add(resistor2);
            circuit.connections.Add(connectionBatteryToResistor1);
            circuit.connections.Add(connectionResistor1ToDiode);
            circuit.connections.Add(connectionDiodeToResistor2);
            circuit.connections.Add(connectionDiodeToResistor3);
            circuit.connections.Add(connectionResistor2ToBattery);
            circuit.connections.Add(connectionResistor3ToBattery);

            var summe = 0.1;

            circuit.prepare();

            summe = circuit.CalculateLayerResistance(battery);

            Assert.That(summe, Is.EqualTo(150));
        }

    }
}
