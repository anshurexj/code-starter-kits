using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingBall.BusinessLogic;

namespace BowlingBall.Tests
{
	/* Summary: 
     * Author: Anshuman Jha
     * 
     * Unit testing GameFrame.cs class file using MSTest 
    */

	[TestClass]
	public class GameFrameTests
	{
		private GameFrame gameFrame;

		//This will execute before test cases are executed for Initialization.

		[TestInitialize]
		public void Initialize()
		{
			gameFrame = new GameFrame();
		}

		//This will execute post test cases are executed for cleanup activity.

		[TestCleanup]
		public void Cleanup() 
		{
			gameFrame = null;
		}

		[TestMethod]
		[DataRow(5)]
		[DataRow(10)]
		[DataRow(12)]
		public void CheckFrame_RightInput_ExpectedPass(int frame_count)
		{
			/*
			 * Type of Test: Positive
			 * Check if GetAllFrames method returns correct number of frames. 
			 */

			Assert.AreEqual(gameFrame.GetAllFrames(frame_count).Count,frame_count);
		}

		[TestMethod]
		[DataRow(2,3)]
		[DataRow(3,4)]
		[DataRow(4,null)]
		public void CheckFrame_RightInput_ExpectedFail(int frame_count, int result_frame_count)
		{
			/*
             * Type of Test: Negative
             * Check if GetAllFrames method returns correct number of frames. 
             */

			Assert.AreNotEqual(gameFrame.GetAllFrames(frame_count).Count, result_frame_count);
		}

	}
}
