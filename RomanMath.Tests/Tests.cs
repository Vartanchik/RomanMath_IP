using NUnit.Framework;
using RomanMath.Impl;
using System;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Expression_IsNull()
		{
			Assert.Throws<ArgumentException>(() => Service.Evaluate(null));
		}

		[Test]
		public void Expression_IsEmpty()
		{
			Assert.Throws<ArgumentException>(() => Service.Evaluate(""));
		}

		[Test]
		public void Expression_HasWhitespace()
		{
			Assert.Throws<ArgumentException>(() => Service.Evaluate("IV +II-V"));
		}

		[Test]
		public void Expression_HasDevider()
		{
			Assert.Throws<ArgumentException>(() => Service.Evaluate("IV/II-V"));
		}

		[Test]
		public void Expression_HasArabicNumber()
		{
			Assert.Throws<ArgumentException>(() => Service.Evaluate("IV/II-V5"));
		}

		[Test]
		public void Success_1()
		{
			var result = Service.Evaluate("IV+II-V");
			Assert.AreEqual(1, result);
		}

		[Test]
		public void Success_1035()
		{
			var result = Service.Evaluate("M+XL-V");
			Assert.AreEqual(1035, result);
		}

		[Test]
		public void Success_85()
		{
			var result = Service.Evaluate("LXX+XX-V");
			Assert.AreEqual(85, result);
		}
	}
}