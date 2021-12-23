using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BowlingBall.Common;
using BowlingBall.Contract;

namespace BowlingBall.Tests
{
	/* Summary: 
     * Author: Anshuman Jha
     * 
     * Unit testing Frame.cs class file using MSTest 
     */

	[TestClass]	
	public class FrameTests
	{
		private IFrame frame;

		//This will execute before test cases are executed for Initialization.

		[TestInitialize]
		public void Initialize()
		{
            frame = new Frame
            {
                RollingBall = new List<int>()
            };
        }

		//This will execute post test cases are executed for cleanup activity.

		[TestCleanup]
		public void Cleanup()
		{
			frame = null;
		}

		[TestMethod]
		[DataRow(8, 1, 9)]
		[DataRow(6, 2, 8)]
		[DataRow(6, 1, 7)]
		[DataRow(3, 3, 6)]
		[DataRow(2, 3, 5)]
		public void CheckScore_OpenFrame_RightScore_ExpectedPass(int roll_1, int roll_2, int result)
		{
			/*
			 * Type of Test: Positive
			 * Check if FrameScore method returns correct score for single frame, when it is Open Frame.  
			 */

			frame.RollingBall.Add(roll_1);
			frame.RollingBall.Add(roll_2);
			Assert.AreEqual(result, frame.FrameScore());			
		}

		[TestMethod]
		[DataRow(8, 1, 7)]
		[DataRow(6, 2, 5)]
		[DataRow(1, null, 4)]
		[DataRow(null, 1, 2)]
		public void CheckScore_OpenFrame_WrongScore_ExpectedFail(int roll_1, int roll_2, int result)
		{           
			/*
			 * Type of Test: Negative
			 * Check if FrameScore method returns correct score for single frame, when it is Open Frame.
			 * Also checks if code breaks for null.
			 */
			frame.RollingBall.Add(roll_1);
			frame.RollingBall.Add(roll_2);
			Assert.AreNotEqual(result, frame.FrameScore());
		}

		[TestMethod]
		[DataRow(8, 2, 7, 17)] 
		[DataRow(5, 5, 4, 14)]
		[DataRow(5, 5, 9, 19)]
		[DataRow(3, 7, 3, 13)]
		public void CheckScore_Spare_RightBonus_ExpectedPass(int roll_1, int roll_2, int bonus, int result)
		{
			/*
			 * Type of Test: Positive
			 * Check if FrameScore method returns correct score for frame, when there is bonus 
			 */
			frame.RollingBall.Add(roll_1);
			frame.RollingBall.Add(roll_2);
			frame.BonusScore = bonus;
			Assert.AreEqual(result, frame.FrameScore());
		}

		[TestMethod]
		[DataRow(8, 2, null, 17)]
		[DataRow(5, null, 3, 14)]
		[DataRow(null, 5, 2, 19)]
		[DataRow(3, 7, 1, 13)]
		public void CheckScore_Spare_WrongBonus_ExpectedFail(int roll_1, int roll_2, int bonus, int result)
		{
			/*
			 * Type of Test: Negative
			 * Check if FrameScore method returns correct score for frame, when there is bonus
			 * Also checks for null handeling.
			 */
			frame.RollingBall.Add(roll_1);
			frame.RollingBall.Add(roll_2);
			frame.BonusScore = bonus;
			Assert.AreNotEqual(result, frame.FrameScore());
		}

		[TestMethod]
		[DataRow(3, 7)]
		[DataRow(2, 8)]
		[DataRow(1, 9)]
		[DataRow(5, 5)]
		[DataRow(6, 4)]
		public void CheckFrame_Spare_RightInput_ExpectedPass(int roll_1, int roll_2)
		{
			/*
			 * Type of Test: Positive
			 * Check if GetFrameType method returns correct frame, when it is Spare based on Input
			 */
			frame.RollingBall.Add(roll_1);
			frame.RollingBall.Add(roll_2);
			Assert.AreEqual(FrameType.Spare, frame.GetFrameType());
		}

		[TestMethod]
		[DataRow(2, 7)]
		[DataRow(1, 8)]
		[DataRow(1, 6)]
		[DataRow(5, 2)]
		[DataRow(6, 1)]
		public void CheckFrame_Spare_WrongInput_ExpectedFail(int roll_1, int roll_2)
		{
			/*
			 * Type of Test: Negative
			 * Check if GetFrameType method returns correct frame, when it is Not Spare based on Input
			 */
			frame.RollingBall.Add(roll_1);
			frame.RollingBall.Add(roll_2);
			Assert.AreNotEqual(FrameType.Spare, frame.GetFrameType());
		}

		[TestMethod]
		public void CheckFrame_Strike_RightInput_ExpectedPass()
		{
			/*
			 * Type of Test: Positive
			 * Check if GetFrameType method returns correct frame, when it is Strike based on Input
			 */
			frame.RollingBall.Add(10);
			Assert.AreEqual(FrameType.Strike, frame.GetFrameType());
		}

		[TestMethod]
		[DataRow(5, null)]
		[DataRow(null, 1)]
		public void CheckFrame_Strike_WrongInput_ExpectedFail(int roll_1, int roll_2)
		{
			/*
			 * Type of Test: Negative
			 * Check if GetFrameType method returns correct frame, when it is Not Strike based on Input
			 */
			frame.RollingBall.Add(roll_1);
			frame.RollingBall.Add(roll_2);
			Assert.AreNotEqual(FrameType.Strike, frame.GetFrameType());
		}

		[TestMethod]
		[DataRow(3, 2)]
		[DataRow(2, 4)]
		[DataRow(1, 5)]
		[DataRow(5, 2)]
		[DataRow(6, 3)]
		public void CheckFrame_Open_RightInput_ExpectedPass(int roll_1, int roll_2)
		{
			/*
			 * Type of Test: Positive
			 * Check if GetFrameType method returns correct frame, when it is Open based on Input
			 */
			frame.RollingBall.Add(roll_1);
			frame.RollingBall.Add(roll_2);
			Assert.AreEqual(FrameType.Open, frame.GetFrameType());
		}

		[TestMethod]
		public void CheckFrame_Open_WrongInput_ExpectedFail()
		{
			/*
			 * Type of Test: Negative
			 * Check if GetFrameType method returns correct frame, when it is Strike based on Input
			 */
			frame.RollingBall.Add(10);
			Assert.AreNotEqual(FrameType.Open, frame.GetFrameType());
		}

	}
}
