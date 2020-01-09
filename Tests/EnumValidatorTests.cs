using EnumValidator;
using FluentAssertions;
using NUnit.Framework;
using Tests.Enums;

namespace Tests
{
    [TestFixture]
    public class EnumValidatorTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void ClassicEnum_ValidValues(int value)
        {
            var enumValue = (ClassicEnum) value;
            enumValue.IsValid().Should().BeTrue();
        }
        
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(666)]
        public void ClassicEnum_InvalidValues(int value)
        {
            var enumValue = (ClassicEnum) value;
            enumValue.IsValid().Should().BeFalse();
        }
    }
}