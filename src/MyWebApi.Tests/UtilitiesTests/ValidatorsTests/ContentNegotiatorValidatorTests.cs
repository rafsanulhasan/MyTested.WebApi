﻿// MyWebApi - ASP.NET Web API Fluent Testing Framework
// Copyright (C) 2015 Ivaylo Kenov.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/.

namespace MyWebApi.Tests.UtilitiesTests.ValidatorsTests
{
    using System;
    using System.Net.Http.Formatting;
    using System.Web.Http.Results;
    using NUnit.Framework;
    using Setups;
    using Setups.Common;
    using Setups.Controllers;
    using Utilities.Validators;

    [TestFixture]
    public class ContentNegotiatorValidatorTests
    {
        [Test]
        public void ValidateContentNegotiatorShouldNotThrowExceptionIfContentValidatorIsCorrect()
        {
            var actionResultWithContentNegotiator = new OkNegotiatedContentResult<int>(5, MyWebApi.Controller<WebApiController>().AndProvideTheController());

            ContentNegotiatorValidator.ValidateContentNegotiator(
                actionResultWithContentNegotiator,
                new DefaultContentNegotiator(),
                TestObjectFactory.GetFailingValidationAction());
        }

        [Test]
        [ExpectedException(
            typeof(NullReferenceException),
            ExpectedMessage = "IContentNegotiator to be CustomContentNegotiator instead received DefaultContentNegotiator")]
        public void ValidateContentNegotiatorShouldThrowExceptionIfContentValidatorIsNotCorrect()
        {
            var actionResultWithContentNegotiator = new OkNegotiatedContentResult<int>(5, MyWebApi.Controller<WebApiController>().AndProvideTheController());

            ContentNegotiatorValidator.ValidateContentNegotiator(
                actionResultWithContentNegotiator,
                new CustomContentNegotiator(),
                TestObjectFactory.GetFailingValidationAction());
        }
    }
}
