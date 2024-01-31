using MockingDemo_IsoFrameworks;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingDemoTests
{
    //1. install nugets including nsubsitute
    //2. add reference to other project
    [TestFixture]
    public class LogAnalyserTests
    {
        [TestCase("small.txt")]
		[TestCase("123")]
		[TestCase("txt")]
		[TestCase("a")]
		public void Analyse_NameTooSmall_LogError(string name) //1. naming convention
		{
			//Arrange
			ILogger mockLogger = Substitute.For<ILogger>(); //2. need fake object (mock object), which
															// fakes logging the errors,
															// doesn't exist yet -> NSubsitute 

			//3. need to create an instance LogAnlayser class and incject mock
			LogAnalyser myAnalyser = new LogAnalyser(mockLogger); //inject dependency in our production code

			//Act
			myAnalyser.minNameLength = 10; //set minimal length
			myAnalyser.Analyse(name);

			//Assert

			//need to check if error was logged
			mockLogger.Received().LogError(Arg.Any<string>());  //Need to check that ILogger.LogError was called
																//correctly from our unit under test
			//4. need to create Interface to make it compile
			// - add ILogger interface
			// - add constructor
			// - add properties

			//5. make unit test pass

			//6. TDD approach - do we need to add more functionality? Yes. RQ2 Mock and Stub
			//7. paramtise it
		}

		[Test]
		public void Analyse_LoggerThrowsException_ReportToWebservice()
		{
			//Arrange

			//stub throws exception
			ILogger stubLogger = Substitute.For<ILogger>();

			//mock which we will ask if received exception
			IWebservice mockWebservice = Substitute.For<IWebservice>(); 
			LogAnalyser myAnalyser = new LogAnalyser(stubLogger, mockWebservice);

			//extra arrange
			stubLogger  //call log error with any string -> throw an exception
				.When(x => x.LogError(Arg.Any<string>()))
				.Do(y => { throw new Exception("fake exception"); });

			//Act
			myAnalyser.minNameLength = 10;
			myAnalyser.Analyse("heiya.txt");

			//Assert

			//assertion is against the mock
			mockWebservice.Received().Write(Arg.Any<string>());

			//1. Add new IWebservice
			//2. Add additional constructor
			//3. compiles but fails unit test --> fix
			//4. try-catch block
			//5. Maybe test for actual exception message, but OK for now
		}
	}
}
