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
        
        [TestCase(2)]
        [TestCase(69)]
        [TestCase(666)]
        public void SpecificEnum_ValidValues(int value)
        {
            var enumValue = (SpecificEnum) value;
            enumValue.IsValid().Should().BeTrue();
        }
        
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(7)]
        public void SpecificEnum_InvalidValues(int value)
        {
            var enumValue = (SpecificEnum) value;
            enumValue.IsValid().Should().BeFalse();
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FlagsEnum_ValidValues(int value)
        {
            var enumValue = (FlagsEnum) value;
            enumValue.IsValid().Should().BeTrue();
        }
        
        [TestCase(666)]
        [TestCase(-1)]
        [TestCase(8)]
        public void FlagsEnum_InvalidValues(int value)
        {
            var enumValue = (FlagsEnum) value;
            enumValue.IsValid().Should().BeFalse();
        }
    }
}