﻿namespace MyWebApi.Builders.And
{
    using System.Web.Http;

    using Actions;
    using Contracts.And;

    public class AndContinuityTestBuilder<TActionResult> : ActionResultTestBuilder<TActionResult>,
        IAndContinuityTestBuilder<TActionResult>
    {
        public AndContinuityTestBuilder(ApiController controller, string actionName, TActionResult actionResult)
            : base(controller, actionName, actionResult)
        {
        }
    }
}
