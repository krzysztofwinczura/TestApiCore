using NUnit.Framework;
using System;
using WebApplicationApi.BL;

namespace WebApplicationApi.Test
{
    [TestFixture]
    public class Tests
    {
        private Actions _actions;
        private string[] _st;

        [SetUp]
        public void Setup()
        {
            _actions = new Actions();
        }

        [TestCase("1", "2", "3")]
        [TestCase("2", "3", "5")]
        public void TestAdditionM(string f1, string f2, string res)
        {
            var resAdd = _actions.Addition(f1, f2);
            Assert.AreEqual(res, resAdd);
        }

        [TestCase("1", "12")]
        public void TestAdditionList(string f1, string res)
        {
            _st = new[] { "1", "2", "8" };
            var resAdd = _actions.Addition(f1, _st);
            Assert.AreEqual(res, resAdd);
        }

        [TestCase("1", "2", "-1")]
        [TestCase("2", "3", "-1")]
        public void TestSubtractionM(string f1, string f2, string res)
        {
            var resAdd = _actions.Subtraction(f1, f2);
            Assert.AreEqual(res, resAdd);
        }

        [TestCase("1", "-10")]
        public void TestSubtractionList(string f1, string res)
        {
            _st = new[] { "1", "2", "8" };
            var resAdd = _actions.Subtraction(f1, _st);
            Assert.AreEqual(res, resAdd);
        }

        [TestCase("8", "2", "4")]
        [TestCase("6", "3", "2")]
        public void TestMDivisionM(string f1, string f2, string res)
        {
            var resAdd = _actions.Division(f1, f2);
            Assert.AreEqual(res, resAdd);
        }

        [TestCase("1", "0,0625")]
        public void TestMDivisionList(string f1, string res)
        {
            _st = new[] { "1", "2", "8" };
            var resAdd = _actions.Division(f1, _st);
            Assert.AreEqual(res, resAdd);
        }

        [TestCase("8", "2", "16")]
        [TestCase("6", "3", "18")]
        public void TestMMultiplicationM(string f1, string f2, string res)
        {
            var resAdd = _actions.Multiplication(f1, f2);
            Assert.AreEqual(res, resAdd);
        }

        [TestCase("1", "16")]
        public void TestMMultiplicationList(string f1, string res)
        {
            _st = new[] { "1", "2", "8" };
            var resAdd = _actions.Multiplication(f1, _st);
            Assert.AreEqual(res, resAdd);
        }

        [TestCase("10;20;30", "15;20;25", "3")]
        public void TestCurveApproximationM(string f1, string f2, string res)
        {
            Assert.Catch<ArgumentException>(() => _actions.CurveApproximation(f1, f2));
        }

        [TestCase("10;20;30", "15;20;25", "3")]
        public void TestCurveInterpolationM(string f1, string f2, string res)
        {
            Assert.Catch<NotImplementedException>(() => _actions.CurveInterpolation(f1, f2));
        }
    }
}