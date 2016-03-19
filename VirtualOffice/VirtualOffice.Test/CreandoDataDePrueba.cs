using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMLib.RapidPrototyping.Generators;
using NUnit.Framework;
using Ploeh.AutoFixture;
using VirtualOffice.Repositorios.DDDContext;
using VirtualOffice.Repositorios.Dominio;

namespace VirtualOffice.Test
{
    [TestFixture]
    public class CreandoDataDePrueba
    {
        [Test]
        public void CreandoData()
        {
            var numbers = new Random(-1);
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
                .ToList().ForEach(b => fixture.Behaviors.Remove(b));

            WordGenerator generator = new WordGenerator();
            LoremIpsumGenerator loremIpsumGenerator = new LoremIpsumGenerator();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
            var clientes = fixture.Build<Cliente>()
                .Without(p => p.Reservas)
                .With(p=>p.Nombre,loremIpsumGenerator.Next(1, 1))
                .With(p => p.NombreUsuario, generator.Next()+Guid.NewGuid().ToString())
                .With(p => p.ContactoCargo, generator.Next())
                .With(p => p.ContactoNombre, generator.Next())
                //.With(p => p.Direccion, loremIpsumGenerator.Next(1,1))
                .CreateMany(100);

            var context = new EFVirtualOfficeRepository();


            foreach (var cliente in clientes)
            {
                context.ClienteRepository.Add(cliente);
                
            }
            
            context.Commit();
        }

    }
}
