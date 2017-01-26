using System;
using NUnit.Framework;
using Mapper.Test.TestDataClasses;
using MapperProject.Mapper;
using MapperProject.FuncFactory.Mapping;
using System.Collections.Generic;

namespace Mapper.Test
{
    [TestFixture]
    class MapperUnitTest
    {
        private static readonly Source Source = new Source();

        [Test]
        public void Mapping_WhenValueTypesAreSame_ShouldMappingOnSameFields()
        {
            var mapper = new DTOMapper(new MappingFuncFactory());
            string expected = "test";
            Source.SameType = expected;

            var mappingResult = mapper.Map<Source, Destination>(Source);
            string actual = mappingResult.SameType;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Mapping_WhenValueTypesCanConvert_ShouldMappingOnSameFields()
        {
            var mapper = new DTOMapper(new MappingFuncFactory());
            var expected = 10;
            Source.CanConvert = expected;

            var mappingResult = mapper.Map<Source, Destination>(Source);
            var actual = mappingResult.CanConvert;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Mapping_WhenValueTypesCanNotConvert_ShouldNotMappingFieldWithSuchNameReturnZero()
        {
            var mapper = new DTOMapper(new MappingFuncFactory());
            Source.CanNotConvert = 10;

            var mappingResult = mapper.Map<Source, Destination>(Source);
            var expected = 0;
            var actual = mappingResult.CanNotConvert;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Mapping_WhenRefTypesAreEqual_ShouldMappingOnSameFields()
        {
            List<string> expected = new List<string>()
            {
                "test1",
                "test2"
            };

            var mapper = new DTOMapper(new MappingFuncFactory());
            Source.SameRefType = expected;

            var mappingResult = mapper.Map<Source, Destination>(Source);
            var actual = mappingResult.SameRefType;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Mapping_WhenFieldsWithSameNamesButDifferentTypes_ShouldNotMappingOnSameFields()
        {
            var mapper = new DTOMapper(new MappingFuncFactory());
            var expected = 10;
            Source.NotSameType = expected;

            var mappingResult = mapper.Map<Source, Destination>(Source);
            string actual = mappingResult.NotSameType;

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void Mapping_WhenDestinationFieldHaveNotSetter_ShouldNotMappingOnSameFields()
        {
            var mapper = new DTOMapper(new MappingFuncFactory());
            var expected = 10;
            Source.DestFieldWithoutSetter = expected;

            var mappingResult = mapper.Map<Source, Destination>(Source);
            var actual = mappingResult.DestFieldWithoutSetter;

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void Mapping_WhenNoSuchPropertyInDest_ShouldNotMappingOnDestField()
        {
            var mapper = new DTOMapper(new MappingFuncFactory());
            var expected = 10;
            Source.NoSuchPropertyInDestination = expected;

            var mappingResult = mapper.Map<Source, Destination>(Source);
            var actual = mappingResult.NoSuchPropertyInSource;

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void Mapping_WhenUseCacheForGettingMappingFunc_ShouldMappingOnSameFields_SawLogs()
        {
            var mapper = new DTOMapper(new MappingFuncFactory());
            var expected = 10;
            Source.CanConvert = expected;

            var mappingResult = mapper.Map<Source, Destination>(Source);
            var actual = mappingResult.CanConvert;

            Assert.AreEqual(expected, actual);

            //mapper = new DTOMapper(new MappingFuncFactory());
            Source.CanConvert = expected;

            mappingResult = mapper.Map<Source, Destination>(Source);
            actual = mappingResult.CanConvert;

            Assert.AreEqual(expected, actual);
        }
    }
}
