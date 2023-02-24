using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass()]
    public class RoleServiceTests
    {
        private QueroJobsContext _context;
        private IRoleService _roleService;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange = Organiza e gera os dados que serão testados
            var builder = new DbContextOptionsBuilder<QueroJobsContext>();
            builder.UseInMemoryDatabase("QueroJobs");
            var options = builder.Options;
            _context = new QueroJobsContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var roles = new List<Role>
            {
                new Role { Id = 1, RoleName = "Desenvolvedor de Softwares" },
                new Role { Id = 2, RoleName = "Engenheiro de Software" },
                new Role { Id = 3, RoleName = "Designer UX/UI" },
                new Role { Id = 4, RoleName = "DBA" },
                new Role { Id = 5, RoleName = "Gerente de redes" },
                new Role { Id = 6, RoleName = "Gerente de segurança" },
                new Role { Id = 7, RoleName = "Gerente de infraestrutura" }
            };
            _context.AddRange(roles);
            _context.SaveChanges();

            _roleService = new RoleService(_context);
        }


        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _roleService.Create(new Role()
            {
                Id = 8,
                RoleName = "Analista de suporte"
            }).Wait();

            // Assert
            Assert.AreEqual(8, _roleService.GetAll().Result.Count());
            var role = _roleService.Get(8).Result;
            Assert.IsNotNull(role);
            Assert.AreEqual(role.RoleName, "Analista de suporte");

        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            var countRoles = _roleService.GetAll().Result.Count();
            _roleService.Delete(2).Wait();

            // Assert
            Assert.AreEqual(_roleService.GetAll().Result.Count(), countRoles - 1);
            var roles = _roleService.Get(2).Result;
            Assert.IsNull(roles);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Act
            var role = _roleService.Get(1).Result;
            role.RoleName = "Pedreiro";
            _roleService.Edit(role);

            // Assert
            role = _roleService.Get(1).Result;
            Assert.IsNotNull(role);
            Assert.IsInstanceOfType(role, typeof(Role));
            Assert.AreEqual(role.RoleName, "Pedreiro");
        }

        [TestMethod()]
        public void GetTest()
        {
            // Act = Ação que obtem o resultado
            var role = _roleService.Get(1).Result;

            // Assert = Verifica se o resultado é igual o esperado
            Assert.IsNotNull(role);
            Assert.IsInstanceOfType(role, typeof(Role));
            Assert.AreEqual(role.RoleName, "Desenvolvedor de Softwares");
            Assert.AreEqual(role.Id, 1);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act = Ação que obtem o resultado
            var rolesList = _roleService.GetAll().Result;

            // Assert = Verifica se o resultado é igual o esperado
            Assert.IsNotNull(rolesList);
            Assert.IsInstanceOfType(rolesList, typeof(IEnumerable<Role>));
            Assert.AreEqual(rolesList.First().RoleName, "Desenvolvedor de Softwares");
            Assert.AreEqual(rolesList.First().Id, 1);
        }
    }
}