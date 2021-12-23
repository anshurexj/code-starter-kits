using System.Collections.Generic;
using BowlingBall.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
	/* Summary: 
     * Author: Anshuman Jha
     * 
     * Unit testing GameScore.cs class file using MSTest 
    */

	[TestClass]
	public class GameScoreTests
	{
		private GameScore score;
		private List<int> rolls;
		private List<IFrame> frames;

		//This will execute before test cases are executed for Initialization.

		[TestInitialize]
		public void Initialize()
		{
			score  = new GameScore();
			rolls  = new List<int>();
			frames = new List<IFrame>();

			for (int i = 1; i <= 10; i++)
			{
				var individual_frame = new Frame
				{
					Index = i,
					RollingBall = new List<int>()
				};
				frames.Add(individual_frame);
			}
		}

		//This will execute post test cases are executed for cleanup activity.

		[TestCleanup]
		public void Cleanup()
		{
			score = null;
			rolls = null;
			frames = null;
		}


		[TestMethod]
		public void CheckScore_OpenFrames_ExpectedPass()
		{
			/*
			 * Type of Test: Positive
			 * Check if Final Game Score is Correct with 10 Frames * 2 Balls in each, All Open  
			 */

			rolls.Add(1); rolls.Add(2); //3
			rolls.Add(3); rolls.Add(4); //7
			rolls.Add(5); rolls.Add(1); //6
			rolls.Add(1); rolls.Add(1); //2
			rolls.Add(2); rolls.Add(5); //7
			rolls.Add(1); rolls.Add(2); //3
			rolls.Add(3); rolls.Add(4); //7
			rolls.Add(5); rolls.Add(1); //6
			rolls.Add(1); rolls.Add(1); //2
			rolls.Add(2); rolls.Add(5); //7 = 50

			Assert.AreEqual(50, score.FinalGameScore(frames, rolls));
		}

		[TestMethod]
		public void CheckScore_SpareFrames_ExpectedPass()
		{
			/*
		     * Type of Test: Positive
		     * Check if Final Game Score is Correct with 10 Frames * 2 Balls in each, All Spare.  
			 */

			rolls.Add(4); rolls.Add(6);			       //10  + 2 
			rolls.Add(2); rolls.Add(8);			       //12  + 1 + 10		
			rolls.Add(1); rolls.Add(9);			       //23  + 4 + 10
			rolls.Add(4); rolls.Add(6);			       //37  + 2 + 10
			rolls.Add(2); rolls.Add(8);			       //49  + 1 + 10
			rolls.Add(1); rolls.Add(9);			       //60  + 4 + 10
			rolls.Add(4); rolls.Add(6);			       //74  + 2 + 10
			rolls.Add(2); rolls.Add(8);			       //86  + 1 + 10
			rolls.Add(1); rolls.Add(9);                //97  + 1 + 10
			rolls.Add(1); rolls.Add(9); rolls.Add(4);  //108 + 4 + 10 = 122
			
			Assert.AreEqual(122, score.FinalGameScore(frames, rolls));
		}

		[TestMethod]
		public void CheckScore_StrikeFrames_ExpectedPass()
		{
			/*
		     * Type of Test: Positive
		     * Check if Final Game Score is Correct with 10 Frames * 1 Balls in each, All Strike.  
			 */

			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);
			rolls.Add(10);

			Assert.AreEqual(300, score.FinalGameScore(frames, rolls));
		}

		[TestMethod]
		public void CheckScore_RandomFrames_LastOpen_ExpectedPass()
		{
			/*
		     * Type of Test: Positive
		     * Check if Final Game Score is Correct with random frames and last as Open  
			 */

			rolls.Add(10);                //10  + 9  + 1	  
			rolls.Add(9); rolls.Add(1);	  //20  + 10 + 10 	  
			rolls.Add(10);                //40  + 10 + 10 + 5 
			rolls.Add(10);                //65  + 10 + 5 + 5  
			rolls.Add(5); rolls.Add(5);   //85  + 10 + 7 	  
			rolls.Add(7); rolls.Add(2);   //102 + 9			  
			rolls.Add(10);                //111 + 10 + 9 + 0  
			rolls.Add(9); rolls.Add(0);   //130 + 9 		  
			rolls.Add(8); rolls.Add(2);   //139 + 10 + 5 	  
			rolls.Add(5); rolls.Add(4);   //154 + 9           = 163

			Assert.AreEqual(163, score.FinalGameScore(frames, rolls));
		}

		[TestMethod]
		public void CheckScore_RandomFrames_LastSpare_ThenStrike_ExpectedPass()
		{
			/*
		     * Type of Test: Positive
		     * Check if Final Game Score is Correct with random frames and in last Frame Spare then Strike  
			 */

			rolls.Add(10);                              //10  + 9  + 1	  
			rolls.Add(9); rolls.Add(1);                 //20  + 10 + 10 	  
			rolls.Add(10);                              //40  + 10 + 10 + 5 
			rolls.Add(10);                              //65  + 10 + 5 + 5  
			rolls.Add(5); rolls.Add(5);                 //85  + 10 + 7 	  
			rolls.Add(7); rolls.Add(2);                 //102 + 9			  
			rolls.Add(10);                              //111 + 10 + 9 + 0  
			rolls.Add(9); rolls.Add(0);                 //130 + 9 		  
			rolls.Add(8); rolls.Add(2);                 //139 + 10 + 5 	  
			rolls.Add(5); rolls.Add(5); rolls.Add(10);  //154 + 10 + 10  = 174

			Assert.AreEqual(174, score.FinalGameScore(frames, rolls));
		}

		[TestMethod]
		public void CheckScore_RandomFrames_LastStrike_ThenStrike_ExpectedPass()
		{
			/*
		     * Type of Test: Positive
		     * Check if Final Game Score is Correct with random frames and in last frame Strike then Strike  
			 */

			rolls.Add(10);                                //10  + 9  + 1	  
			rolls.Add(9); rolls.Add(1);                   //20  + 10 + 10 	  
			rolls.Add(10);                                //40  + 10 + 10 + 5 
			rolls.Add(10);                                //65  + 10 + 5 + 5  
			rolls.Add(5); rolls.Add(5);                   //85  + 10 + 7 	  
			rolls.Add(7); rolls.Add(2);                   //102 + 9			  
			rolls.Add(10);                                //111 + 10 + 9 + 0  
			rolls.Add(9); rolls.Add(0);                   //130 + 9 		  
			rolls.Add(8); rolls.Add(2);                   //139 + 10 + 10 	  
			rolls.Add(10); rolls.Add(10); rolls.Add(10);  //159 + 10 + 10 + 10  = 189

			Assert.AreEqual(189, score.FinalGameScore(frames, rolls));
		}
	}
}
