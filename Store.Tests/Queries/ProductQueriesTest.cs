using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTest
    {

        private IList<Product> _products;

        public ProductQueriesTest()
        {
            _products = new List<Product>();
            _products.Add(new Product("Produto 01", 10, true));
            _products.Add(new Product("Produto 02", 10, true));
            _products.Add(new Product("Produto 03", 10, true));
            _products.Add(new Product("Produto 04", 10, false));
            _products.Add(new Product("Produto 05", 10, false));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_devo_retornar_3()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_devo_retornar_2()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetInativeProducts());
            Assert.AreEqual(result.Count(), 2);
        }
    }
}