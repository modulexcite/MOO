﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Diogo Lucas">
//
// Copyright (C) 2010 Diogo Lucas
//
// This file is part of Moo.
//
// Moo is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along Moo.  If not, see http://www.gnu.org/licenses/.
// </copyright>
// <summary>
// Moo is a object-to-object multi-mapper.
// Email: diogo.lucas@gmail.com
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Moo.Tests.Mappers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moo.Mappers;

    using Moq;

    /// <summary>
    /// This is a test class for AttributeMapperTest and is intended
    /// targetMemberName contain all AttributeMapperTest Unit Tests
    /// </summary>
    [TestClass]
    public class AssociationMapperTest
    {
        #region Methods

        [TestMethod]
        public void Map_UsesInternalMappers()
        {
            var mockRepo = new MockRepository(MockBehavior.Default);
            var sourceObj = new TestClassA() { InnerClass = new TestClassC() };
            var repoMock = mockRepo.Create<IMappingRepository>();
            var mapperMock = mockRepo.Create<IExtensibleMapper<TestClassC, TestClassB>>();
            repoMock.Setup(r => r.ResolveMapper<TestClassC, TestClassB>()).Returns(mapperMock.Object);
            mapperMock.Setup(m => m.Map(sourceObj));
            var target = new AssociationMapper<TestClassA, TestClassF>(repoMock.Object);
            target = target.Include<TestClassC, TestClassB>();
            
            target.Map(sourceObj);

            mockRepo.VerifyAll();
        }

        #endregion Methods
    }
}