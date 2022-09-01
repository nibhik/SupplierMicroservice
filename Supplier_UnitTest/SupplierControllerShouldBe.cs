using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using System.Threading.Tasks;
using NUnit.Framework;
using Supplier.Controllers;
using Moq;
using Supplier;
using Supplier.Model;
using Supplier.Repository;
using SupplierMicroservice;

namespace SupplierMicroTest
{

    public class SupplierControllerShould
    {

        [Test]
        public void CreateNew_SupplierData_VieConstructor()
        {
            //Arrange
            int supplierId = 1;
            string sname = "nikita";
            string semail = "nicky@gmail";
            string sphone = "9874663215";
            string slocation = " Pune";
            int feed = 9;


            //Act

            var department = new Supplier_data(supplierId, sname, semail, sphone, slocation, feed);

            //Assert
            Assert.That(department, Is.Not.Null);
            Assert.That(department, Is.InstanceOf<Supplier_data>());
            Assert.That(department.supplier_id, Is.EqualTo(supplierId));
            Assert.That(department.name, Is.EqualTo(sname));
            Assert.That(department.email, Is.EqualTo(semail));
            Assert.That(department.phone, Is.EqualTo(sphone));
            Assert.That(department.location, Is.EqualTo(slocation));
            Assert.That(department.feedback, Is.EqualTo(feed));
        }


        [Test]
        public void CreateNew_SupplierPart_VieConstructor()
        {
            //Arrange
            int Id = 1;
            int Partid = 1;
            string partName = "motor";
            int Quantity = 50;
            int timePeriod = 5;
            int Sid = 1;


            //Act

            var department = new Supplier_Part(Id, Partid, partName, Quantity, timePeriod, Sid);

            //Assert
            Assert.That(department, Is.Not.Null);
            Assert.That(department, Is.InstanceOf<Supplier_Part>());
            Assert.That(department.id, Is.EqualTo(Id));
            Assert.That(department.partid, Is.EqualTo(Partid));
            Assert.That(department.partname, Is.EqualTo(partName));
            Assert.That(department.quantity, Is.EqualTo(Quantity));
            Assert.That(department.timeperiod, Is.EqualTo(timePeriod));
            Assert.That(department.sid, Is.EqualTo(Sid));
        }

        List<Supplier_data> dtls;

        [SetUp]
        public void Setup()
        {
            dtls = new List<Supplier_data>();
            {
                new Supplier_data()
                {
                    supplier_id = 2,
                    name = "Name1",
                    email = "email1@gmail.com",
                    phone = "1234567890",
                    location = "Location1",
                    feedback = 5
                };
            }


        }


        //[TestCase(2)]
        //public async Task GetSupplierOfPart_SupplierDetails(int id)
        //{
        //    var mock = new Mock<ISupplierRepo<Supplier_data>>();

        //    mock.Setup(p => p.GetSupplierOfPart(id)).ReturnsAsync(dtls);
        //    //PlantRepo pro = new PlantRepo();

        //    //Part a = await pro.ViewStockInHand(PartId);

        //    List<Supplier_data> a = await mock.Object.GetSupplierOfPart(id);
        //    Assert.IsNotNull(a);
        //}

        // [Test]
        //public async Task UpdateFeedback_Supplier(Supplier_data request)
        //{
        //    var mock = new Mock<ISupplierRepo<Supplier_data>>();

        //    mock.Setup(p => p.UpdateFeedback(request)).ReturnsAsync(dtls);
        //    //PlantRepo pro = new PlantRepo();

        //    //Part a = await pro.ViewStockInHand(PartId);

        //    List<Supplier_data> a = await mock.Object.UpdateFeedback(request);
        //    Assert.IsNotNull(a);
        //}
        //    [Test]

        //public async Task UpdateFeedback_Status()
        //{
        //    //var supplierObj = new Supplier_data
        //}

        //public async Task GetSupplierPartById( int id)
        //{
        //    //var controller = new SupplierController();

        //   var rep =  new Mock<ISupplierRepo>();

        //        rep.Setup(m => m.SaveAsync()).ReturnAsync(1);
        //    //PlantRepo pro = new PlantRepo();

        //    //Part a = await pro.ViewStockInHand(PartId);

        //    List<Supplier> a = await mock.Object.GetSupplierOfPart(PartId);
        //    Assert.IsNotNull(a);
        //}

        //[Test]

        //public async Task GetAllSuppliers()
        //{
        //    var testSupplier = GetAllSupplier();
        //    var controller = new SupplierController(testSupplier);

        //    var result = controller.GetAllSupplier();
        //    Assert.AreEqual(testSupplier.Count, result.count);
        //}

        //private MyContext GetAllSupplier()
        //{
        //    var testSupplier = new List<Supplier_data>();
        //    testSupplier.Add(new Supplier_data)
        //}

    }
}
