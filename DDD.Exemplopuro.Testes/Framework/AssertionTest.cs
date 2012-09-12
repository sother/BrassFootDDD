using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.ExemploPuro.Framework;
using DDD.Exemplopuro.Domain;
using System.Reflection;

namespace DDD.Exemplopuro.Testes.Framework
{
    [TestFixture]
    public class AssertionTest
    {
        [Test]
        public void iniciar_assertion_com_sucesso()
        {
            Assertion assertion = new Assertion();

            Assert.NotNull(assertion);
        }

        #region ContainsAssertion

        [Test]
        [ExpectedException(ExpectedMessage = "Objeto não existe.")]
        public void contains_assertion_e_nao_existe_deve_retornar_execao()
        {

            Assertion.ContainsAssertion<object>(new List<object>(), new object(), "Objeto não existe.").Validate();

        }

        [Test]
        public void contains_assertion_com_sucesso()
        {
            var objetos = new List<object>();
            var objeto = new object();
            objetos.Add(objeto);
            Assert.IsTrue(Assertion.ContainsAssertion<object>(objetos, objeto, "Objeto não existe.").IsValid());

        }

        #endregion

        #region Equals

        [Test]
        [ExpectedException(ExpectedMessage = "Objeto é diferente.")]
        public void equals_e_diferente_retornar_execao()
        {
            Assertion.Equals(new List<object>(), new object(), "Objeto é diferente.").Validate();
        }

        [Test]
        public void equals_com_sucesso()
        {
            object objeto = new object();
            Assert.IsTrue(Assertion.Equals(objeto, objeto, "Objeto é diferente.").IsValid());
        }

        #endregion

        #region EqualsOrGreaterThan
        [Test]
        [ExpectedException(ExpectedMessage = "menor que.")]
        public void equals_or_greater_than_e_menor_que_deve_retornar_execao()
        {
            Assertion.EqualsOrGreaterThan(1, 4, "menor que.").Validate();
        }

        [Test]
        public void equals_or_greater_than_e_igual_que_com_sucesso()
        {
            Assert.IsTrue(Assertion.EqualsOrGreaterThan(1, 1, "menor que.").IsValid());
        }

        [Test]
        public void equals_or_greater_than_e_maior_que_com_sucesso()
        {
            Assert.IsTrue(Assertion.EqualsOrGreaterThan(2, 1, "menor que.").IsValid());
        }
        #endregion

        #region EqualsOrLessThan
        [Test]
        [ExpectedException(ExpectedMessage = "maior que.")]
        public void equals_or_less_than_e_maior_que_deve_retornar_execao()
        {
            Assertion.EqualsOrLessThan(4, 1, "maior que.").Validate();
        }

        [Test]
        public void equals_or_less_than_e_igual_com_sucesso()
        {
            Assert.IsTrue(Assertion.EqualsOrLessThan(1, 1, "menor que.").IsValid());
        }

        [Test]
        public void equals_or_less_than_e_menor_que_com_sucesso()
        {
            Assert.IsTrue(Assertion.EqualsOrLessThan(0, 1, "menor que.").IsValid());
        }
        #endregion

        #region GreaterThan
        [Test]
        public void greater_than_e_maior_que_com_sucesso()
        {
            Assert.IsTrue(Assertion.GreaterThan(4, 1, "maior que.").IsValid());
        }

        [Test]
        [ExpectedException(ExpectedMessage = "igual.")]
        public void greater_than_e_igual_que_deve_retornar_execao()
        {
            Assertion.GreaterThan(1, 1, "igual.").Validate();
        }

        [Test]
        [ExpectedException(ExpectedMessage = "menor que.")]
        public void greater_than_e_menor_que_deve_retornar_execao()
        {
            Assertion.GreaterThan(0, 1, "menor que.").Validate();
        }
        #endregion

        #region InRange

        [Test]
        [ExpectedException(ExpectedMessage = "maior que.")]
        public void in_range_e_fora_deve_retornar_execao()
        {
            Assertion.InRange(4, 1, 1, "maior que.").Validate();
        }

        [Test]
        public void in_range_e_dentro_com_sucesso()
        {
            Assert.IsTrue(Assertion.InRange(2, 1, 3, "maior que.").IsValid());
        }
        #endregion

        #region IsFalse

        [Test]
        [ExpectedException(ExpectedMessage = "verdadeiro.")]
        public void is_false_e_true_deve_retornar_execao()
        {
            Assertion.IsFalse(true, "verdadeiro.").Validate();
        }

        [Test]
        public void is_false_com_sucesso()
        {
            Assert.IsTrue(Assertion.IsFalse(false, "verdadeiro.").IsValid());
        }

        #endregion

        #region IsTrue

        [Test]
        [ExpectedException(ExpectedMessage = "falso.")]
        public void is_true_e_false_deve_retornar_execao()
        {
            Assertion.IsTrue(false, "falso.").Validate();
        }

        [Test]
        public void is_true_com_sucesso()
        {
            Assert.IsTrue(Assertion.IsTrue(true, "verdadeiro.").IsValid());
        }

        #endregion

        #region LambdaAssertion
        private bool verdadeiro()
        {
            return true;
        }

        private bool falso()
        {
            return false;
        }

        [Test]
        public void lambda_asertion_com_sucesso()
        {
            Func<bool> funcao = new Func<bool>(verdadeiro);
            Assert.IsTrue(Assertion.LambdaAssertion(funcao, "verdadeiro.").IsValid());
        }

        [Test]
        [ExpectedException(ExpectedMessage = "falso.")]
        public void lambda_asertion_e_falso_deve_retornar_execao()
        {
            Func<bool> funcao = new Func<bool>(falso);
            Assertion.LambdaAssertion(funcao, "falso.").Validate();
        }
        #endregion

        #region LessThan

        [Test]
        public void less_than_e_menor_com_sucesso()
        {
            Assert.IsTrue(Assertion.LessThan(1, 4, "maior que.").IsValid());
        }

        [Test]
        [ExpectedException(ExpectedMessage = "igual.")]
        public void less_than_e_igual_que_deve_retornar_execao()
        {
            Assertion.LessThan(1, 1, "igual.").Validate();
        }

        [Test]
        [ExpectedException(ExpectedMessage = "menor que.")]
        public void greater_than_e_maior_que_deve_retornar_execao()
        {
            Assertion.LessThan(4, 1, "menor que.").Validate();
        }

        #endregion

        #region NotNull

        [Test]
        [ExpectedException(ExpectedMessage = "nulo.")]
        public void not_null_e_nulo_deve_retornar_execao()
        {
            Assertion.NotNull(null, "nulo.").Validate();
        }

        [Test]
        public void not_null_com_sucesso()
        {
            Assert.IsTrue(Assertion.NotNull(new object(), "nulo.").IsValid());
        }

        #endregion

        #region Null

        [Test]
        [ExpectedException(ExpectedMessage = "não nulo.")]
        public void null_e__nao_nulo_deve_retornar_execao()
        {
            Assertion.Null(new object(), "não nulo.").Validate();
        }

        [Test]
        public void null_com_sucesso()
        {
            Assert.IsTrue(Assertion.Null(null, "nulo.").IsValid());
        }

        #endregion

        #region ReferencesEquals

        [Test]
        public void reference_equals_deve_ser_verdadeiro()
        {
            object objeto = new object();
            Assert.IsTrue(Assertion.ReferenceEquals(objeto, objeto));
        }

        [Test]
        public void reference_equals_e_diferente_deve_ser_falso()
        {
            Assert.IsFalse(Assertion.ReferenceEquals(new object(), new object()));
        }

        #endregion

        #region andAssertion
        [Test]
        public void and_deve_retornar_instancia_do_tipo_and_assertion()
        {
            Assertion assert = new Assertion();
            IAssertion assertAnd = assert.and(assert);

            Assert.IsTrue(assertAnd.GetType() == typeof(andAssertion));
        }
        #endregion

        #region AndAssertion
        [Test]
        public void AND_deve_retornar_instancia_do_tipo_and_assertion()
        {
            Assertion assert = new Assertion();
            IAssertion assertAnd = assert.AND(assert);

            Assert.IsTrue(assertAnd.GetType() == typeof(AndAssertion));
        }
        #endregion

        #region DoValidation

        [Test]
        public void do_validation_com_sucesso()
        {
            List<string> lista = new List<string>();
            lista.Add("item");
            Assertion assert = new Assertion();

            var specification = typeof(Assertion).GetProperty("Specification", BindingFlags.Public | BindingFlags.Instance);
            specification.SetValue(assert, CompositeSpecification.Null(new object()), new object[] { });

            var mesagem = typeof(Assertion).GetProperty("Message", BindingFlags.Public | BindingFlags.Instance);
            mesagem.SetValue(assert, "item", new object[] { });

            assert.DoValidation(lista);
            Assert.IsTrue(lista.Count == 2);
        }
        #endregion

        #region Equals
        [Test]
        public void assert_equals_e_falso()
        {
            Assertion assertion = new Assertion();
            Assert.IsFalse(assertion.Equals(new object()));
        }

        #endregion

        #region is_valid
        [Test]
        public void is_valid_e_verdadeiro()
        {
            Assertion assertion = new Assertion();

            var specification = typeof(Assertion).GetProperty("Specification", BindingFlags.Public | BindingFlags.Instance);
            specification.SetValue(assertion, CompositeSpecification.Null(null), new object[] { });

            Assert.IsTrue(assertion.IsValid());
        }
        #endregion

        #region isAssagnablefrom
        [Test]
        public void not_assertion_com_sucesso()
        {
            Assertion assertion = new Assertion();

            var not = assertion.Not();

            Assert.IsAssignableFrom<NotAssertion>(not);
        }


        [Test]
        public void or_assertion_com_sucesso()
        {
            Assertion assertion = new Assertion();

            var or = assertion.or(assertion);

            Assert.IsAssignableFrom<orAssertion>(or);
        }
        [Test]
        public void OR_assertion_com_sucesso()
        {
            Assertion assertion = new Assertion();

            var OR = assertion.OR(assertion);

            Assert.IsAssignableFrom<OrAssertion>(OR);
        }


        #endregion

        #region HttpContext
        [Test]
        public void nao_existe_http_context()
        {
            Assertion assert = new Assertion();
            var httpContext = typeof(Assertion).GetProperty("HasHttpContext", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.IsFalse((bool)httpContext.GetValue(assert, new object[] { }));
        }
        #endregion
    }
}
