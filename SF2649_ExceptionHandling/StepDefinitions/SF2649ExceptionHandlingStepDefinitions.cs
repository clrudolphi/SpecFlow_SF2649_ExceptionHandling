using System;
using TechTalk.SpecFlow;

namespace SF2649_ExceptionHandling.StepDefinitions
{
    [Binding]
    public class SF2649ExceptionHandlingStepDefinitions
    {
        private ExceptionTypes _typeOfExceptionToThrow;
        private Thrower thrower;

        public SF2649ExceptionHandlingStepDefinitions(Thrower thrower)
        {
            this.thrower = thrower ?? throw new ArgumentNullException(nameof(thrower));
        }

        [Given(@"A normal exception")]
        public void GivenANormalException()
        {
            _typeOfExceptionToThrow = ExceptionTypes.Normal;
        }

        [When(@"thrown from a non-Async step definition")]
        public void WhenThrownFromANon_AsyncStepDefinition()
        {
            thrower.SyncThrow(_typeOfExceptionToThrow);
        }

        [Then(@"stack trace and messages are properly preserved")]
        public void ThenStackTraceAndMessagesAreProperlyPreserved()
        {
            
        }

        [Given(@"A normal exception with an inner exception")]
        public void GivenANormalExceptionWithAnInnerException()
        {
            _typeOfExceptionToThrow = ExceptionTypes.NormalWithInner;
        }

        [When(@"thrown from an Async step definition")]
        public async Task WhenThrownFromAnAsyncStepDefinition()
        {
            await thrower.AsyncThrow(_typeOfExceptionToThrow);
        }

        [Given(@"An aggregate exception")]
        public void GivenAnAggregateException()
        {
            _typeOfExceptionToThrow= ExceptionTypes.Aggregate;
        }

        [Given(@"An aggregate exception with no Inner Exception")]
        public void GivenAnAggregateExceptionWithNoInnerException()
        {
            _typeOfExceptionToThrow = ExceptionTypes.AggregateWithoutInner;
        }

    }

    public class Thrower
    {
        internal async Task AsyncThrow(ExceptionTypes typeOfExceptionToThrow)
        {
            await Task.Run(() => ConstructAndThrowSync(typeOfExceptionToThrow));
        }

        internal void SyncThrow(ExceptionTypes typeOfExceptionToThrow)
        {
            ConstructAndThrowSync(typeOfExceptionToThrow);
        }

        private void ConstructAndThrowSync(ExceptionTypes typeOfExceptionToThrow)
        {
            switch (typeOfExceptionToThrow)
            {
                case ExceptionTypes.NormalWithInner:
                    var x1 = new Exception("This is the message from the Inner Exception");
                    throw new Exception("Normal Exception (with InnerException)", x1);

                case ExceptionTypes.Aggregate:
                    var x2 = new Exception("This Exception embedded in the AggregateException");
                    throw new AggregateException("AggregateEx message (with Inner Exception)", x2 );

                case ExceptionTypes.AggregateWithoutInner:
                    throw new AggregateException("AggregateEx (without Inners)");

                case ExceptionTypes.Normal:
                    throw new Exception("Normal Exception message (No InnerException expected).");
            }

        }
    }

    public enum ExceptionTypes
    {
        Normal, 
        NormalWithInner, 
        Aggregate,
        AggregateWithoutInner
    }
}
