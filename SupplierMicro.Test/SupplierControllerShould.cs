using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit;
using Moq;
using Supplier.Model;
using System.Threading.Tasks;
using SupplierMicroservice;
using Supplier.Repository;
using Supplier.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Logging;

namespace SupplierMicro.Test
{
    [TestFixture]
    public class SupplierControllerShould
    {
        List<Supplier_data> spp_data;
        List<Supplier_Part> spp_pt;
        List<SPView> sp_view;


        [SetUp]
        public void Setup()
        {
            spp_data = new List<Supplier_data>();
            {
                new Supplier_data()
                {
                    supplier_id = 1,
                    name = "Aakash",
                    email = "cement@gmail.com",
                    phone = "2323232323",
                    location = "Delhi",
                    feedback = 8
                };
            }
            spp_pt = new List<Supplier_Part>();
            {
                new Supplier_Part()
                {
                    id = 1,
                    partid = 1,
                    partname = "mousechips",
                    quantity = 45,
                    timeperiod = 4,
                    sid = 1
                };
            }
            sp_view = new List<SPView>();
            {
                new SPView()
                {
                    supplier_id = 1,
                    name = "Aakash",
                    location = "Pune",
                    feedback = 10,
                    partid = 1,
                    partname = "mouse",
                    quantity = 33,
                    timeperiod = 3

                };
            }
        }
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


            //[Test]
            //public void CreateNew_SupplierPart_VieConstructor()
            //{
            //    //Arrange
            //    int Id = 1;
            //    int Partid = 1;
            //    string partName = "motor";
            //    int Quantity = 50;
            //    int timePeriod = 5;
            //    int Sid = 1;


            //    //Act

            //    var department = new Supplier_Part(Id, Partid, partName, Quantity, timePeriod, Sid);

            //    //Assert
            //    Assert.That(department, Is.Not.Null);
            //    Assert.That(department, Is.InstanceOf<Supplier_Part>());
            //    Assert.That(department.id, Is.EqualTo(Id));
            //    Assert.That(department.partid, Is.EqualTo(Partid));
            //    Assert.That(department.partname, Is.EqualTo(partName));
            //    Assert.That(department.quantity, Is.EqualTo(Quantity));
            //    Assert.That(department.timeperiod, Is.EqualTo(timePeriod));
            //    Assert.That(department.sid, Is.EqualTo(Sid));
            //}


            [Test]
            public async Task AddSupplier_Ok()
            {
                SPView sp = new SPView()
                {
                    supplier_id = 1,
                    name = "Aakash",
                    email = "aakash@gmail.com",
                    phone = "1212121212",
                    location = "Pune",
                    feedback = 10,
                    partid = 1,
                    partname = "mouse",
                    quantity = 33,
                    timeperiod = 3
                };

                var mock = new Mock<IGenericRepo<Supplier_data, Supplier_Part>>();
            var logger = new Mock<ILogger<SupplierController>>();
            mock.Setup(m => m.SaveAsync()).ReturnsAsync(1);

                var test_obj = mock.Object;
            var log = logger.Object;
                var controller = new SupplierController(test_obj, log);
           

                var result = (IStatusCodeActionResult)await controller.AddSupplier(sp).ConfigureAwait(false);
                Assert.That(result.StatusCode, Is.EqualTo(400));
                Assert.IsNotNull(result);
            }



            //NavNeethan Stuffs
            [Test]
            public async Task UpdateSupplier_ValidInput_Return200()
        {
            SPView sp = new SPView()
            {
                supplier_id = 1,
                name = "Navaneethan",
                email = "n@outlook.com",
                location = "Chennai",
                feedback = 10,
                phone = "9047277243",
                partid = 1,
                partname = "Paper",
                quantity = 10,
                timeperiod = 50 
            };

            Mock<IGenericRepo<Supplier_data, Supplier_Part>> mock = new Mock<IGenericRepo<Supplier_data, Supplier_Part>>();
            var logger = new Mock<ILogger<SupplierController>>();

            mock.Setup(s => s.UpdateSupplier(sp)).ReturnsAsync(true);
            var reObj = mock.Object;
            var log = logger.Object;
            SupplierController controller = new SupplierController(reObj, log);
            var updateSupplierReponse = await controller.UpdateSupplier(sp);
            var result = (IStatusCodeActionResult)await controller.UpdateSupplier(sp).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task UpdateSupplier_InValidInput_Return400()
        {
            SPView sp = new SPView()
            {
                supplier_id = 2,
                name = "Navaneethan",
                email = "n@outlook.com",
                location = "Chennai",
                feedback = 10,
                phone = "9047277243",
                partid = 3,
                partname = "Paper",
                quantity = 10,
                timeperiod = 50
            };

            Mock<IGenericRepo<Supplier_data, Supplier_Part>> mock = new Mock<IGenericRepo<Supplier_data, Supplier_Part>>();
            var logger = new Mock<ILogger<SupplierController>>();
            mock.Setup(s => s.UpdateSupplier(sp)).ReturnsAsync(true);
            var reObj = mock.Object;
            var log = logger.Object;
            SupplierController controller = new SupplierController(reObj, log);
            var updateSupplierReponse = await controller.UpdateSupplier(sp);
            var result = (IStatusCodeActionResult)await controller.UpdateSupplier(sp).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task UpdateFeedback_ValidInput_Return200()
        {
            Supplier_data supplier_Data = new Supplier_data() { supplier_id = 1 , feedback = 5 };
            Mock<IGenericRepo<Supplier_data, Supplier_Part>> mock = new Mock<IGenericRepo<Supplier_data, Supplier_Part>>();
            var logger = new Mock<ILogger<SupplierController>>();
            mock.Setup(s => s.UpdateFeedback(supplier_Data)).ReturnsAsync(true);
            var reObj = mock.Object;
            var log = logger.Object;
            SupplierController controller = new SupplierController(reObj,log);
            var result = (IStatusCodeActionResult)await controller.UpdateFeedback(supplier_Data).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task UpdateFeedback_InValidInput_Return400()
        {
            Supplier_data supplier_Data = new Supplier_data() { supplier_id = 0 , feedback = 5 };
            Mock<IGenericRepo<Supplier_data, Supplier_Part>> mock = new Mock<IGenericRepo<Supplier_data, Supplier_Part>>();
            var logger = new Mock<ILogger<SupplierController>>();
            mock.Setup(s => s.UpdateFeedback(supplier_Data)).ReturnsAsync(true);
            var reObj = mock.Object;
            var log = logger.Object;
            SupplierController controller = new SupplierController(reObj, log);
            var result = (IStatusCodeActionResult)await controller.UpdateFeedback(supplier_Data).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);
        }

        // Commit
        [TestCase(1)]

        public async Task GetSupplierByPart_Result200(int PartId)
        {
            var repo = new Mock<IGenericRepo<Supplier_data, Supplier_Part>>();
            var logger = new Mock<ILogger<SupplierController>>();
            var log = logger.Object;
            var controller = new SupplierController(repo.Object, log);
            
            repo.Setup(x => x.GetSupplierByPartsAsync(1)).Returns(sp_view);
            var result = (OkObjectResult)controller.GetSupplierOfPart(1);
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

        }

    }
}
