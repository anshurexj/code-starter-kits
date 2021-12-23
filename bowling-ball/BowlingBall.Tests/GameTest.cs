using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    /* Summary: 
     * Author: Anshuman Jha
     * 
     * Unit testing Game.cs class file using MSTest 
     */

	[TestClass]
	public class GameTest
	{
        private Game game;

        //This will execute before test cases are executed for Initialization.
        
        [TestInitialize]
		public void Initialize()
		{
			game = new Game();
		}

        //This will execute post test cases are executed for cleanup activity.
        
        [TestCleanup]
		public void Cleanup()
		{
			game = null;
		}

        [TestMethod]
        public void CheckScore_NoPins_RightScore_ExpectedPass()
        {
            /*
			 * Type of Test: Positive
			 * Check if GetScore method returns correct score when all are No Pins.  
			 */

            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0
            game.Roll(0); game.Roll(0);          //0

            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void CheckScore_ExtraRolls_RightScore_ExpectedPass()
        {
            /*
			 * Type of Test: Positive
			 * Check if GetScore method returns correct score when there are additional rolls. 
			 * As per requirement check for valid role should not be there.
			 */

            game.Roll(10);                               //10  + 9  + 1	  
            game.Roll(9); game.Roll(1);                 //20  + 10 + 10 	  
            game.Roll(10);                              //40  + 10 + 10 + 5 
            game.Roll(10);                              //65  + 10 + 5 + 5  
            game.Roll(5); game.Roll(5);                 //85  + 10 + 7 	  
            game.Roll(7); game.Roll(2);                 //102 + 9			  
            game.Roll(10);                              //111 + 10 + 9 + 0  
            game.Roll(9); game.Roll(0);                 //130 + 9 		  
            game.Roll(8); game.Roll(2);                 //139 + 10 + 5 	  
            game.Roll(5); game.Roll(5); game.Roll(10);  //154 + 10 + 10  = 174

            game.Roll(5);game.Roll(5);                  //174 + 5  + 5   = 184

            Assert.AreEqual(174, game.GetScore());
        }

        [TestMethod]
        public void CheckScore_LastSpare_LastStrike_ExpectedPass()
        {
            /*
			 * Type of Test: Positive
			 * Check if GetScore method returns correct score when in last 3 Balls make a Spare and Strike.
			 */

            game.Roll(10);                              //10  + 9  + 1	  
            game.Roll(9); game.Roll(1);                 //20  + 10 + 10 	  
            game.Roll(10);                              //40  + 10 + 10 + 5 
            game.Roll(10);                              //65  + 10 + 5 + 5  
            game.Roll(5); game.Roll(5);                 //85  + 10 + 7 	  
            game.Roll(7); game.Roll(2);                 //102 + 9			  
            game.Roll(10);                              //111 + 10 + 9 + 0  
            game.Roll(9); game.Roll(0);                 //130 + 9 		  
            game.Roll(8); game.Roll(2);                 //139 + 10 + 5 	  
            game.Roll(5); game.Roll(5); game.Roll(10);  //154 + 10 + 10  = 174

            Assert.AreEqual(174, game.GetScore());
        }

        [TestMethod]
        public void CheckScore_LastSpare_LastNoStrike_ExpectedPass()
        {
            /*
			 * Type of Test: Positive
			 * Check if GetScore method returns correct score when in last 3 Balls are make a Spare but No Strike.
			 */

            game.Roll(10);                              //10  + 9  + 1	  
            game.Roll(9); game.Roll(1);                 //20  + 10 + 10 	  
            game.Roll(10);                              //40  + 10 + 10 + 5 
            game.Roll(10);                              //65  + 10 + 5 + 5  
            game.Roll(5); game.Roll(5);                 //85  + 10 + 7 	  
            game.Roll(7); game.Roll(2);                 //102 + 9			  
            game.Roll(10);                              //111 + 10 + 9 + 0  
            game.Roll(9); game.Roll(0);                 //130 + 9 		  
            game.Roll(8); game.Roll(2);                 //139 + 10 + 5 	  
            game.Roll(5); game.Roll(5); game.Roll(5);   //154 + 10 + 5  = 169

            Assert.AreEqual(169, game.GetScore());
        }

        [TestMethod]
        public void CheckScore_RandomPin_OpenFrame_ExpectedPass()
        {
            /*
			 * Type of Test: Positive
			 * Check if GetScore method returns correct score when all are Open Frame.
			 */

            game.Roll(1); game.Roll(2); //3
            game.Roll(3); game.Roll(4); //7
            game.Roll(5); game.Roll(1); //6
            game.Roll(1); game.Roll(1); //2
            game.Roll(2); game.Roll(5); //7
            game.Roll(1); game.Roll(2); //3
            game.Roll(3); game.Roll(4); //7
            game.Roll(5); game.Roll(1); //6
            game.Roll(1); game.Roll(1); //2
            game.Roll(2); game.Roll(5); //7 = 50

            Assert.AreEqual(50, game.GetScore());
        }

        [TestMethod]
        public void CheckScore_2Spare_RandomPins_ExpectedPass()
        { 
             /*
			 * Type of Test: Positive
			 * Check if GetScore method returns correct score when first 2 are Spare.
			 */

            game.Roll(7); game.Roll(3);          //7 + 3 + 2
            game.Roll(2); game.Roll(8);          //12 + 2 + 8 + 0 
            game.Roll(0); game.Roll(0);          //22
            game.Roll(0); game.Roll(0);          //22
            game.Roll(0); game.Roll(0);

            game.Roll(0); game.Roll(0);          //22
            game.Roll(0); game.Roll(0);          //22
            game.Roll(0); game.Roll(0);          //22
            game.Roll(0); game.Roll(0);          //22
            game.Roll(0); game.Roll(0);          //22

            Assert.AreEqual(22, game.GetScore());
        }

        [TestMethod]
        public void CheckScore_1Strike_RandomPins_ExpectedPass()
        {
             /*
			 * Type of Test: Positive
			 * Check if GetScore method returns correct score when first is Strike.
			 */

            game.Roll(10);                       //10 + 5 + 2
            game.Roll(5); game.Roll(2);          //17 + 5 + 2
            game.Roll(4); game.Roll(2);          //24 + 4 + 2 = 30
            game.Roll(0); game.Roll(0);          //30
            game.Roll(0); game.Roll(0);          //30
            game.Roll(0); game.Roll(0);          //30
            game.Roll(0); game.Roll(0);          //30
            game.Roll(0); game.Roll(0);          //30
            game.Roll(0); game.Roll(0);          //30
            game.Roll(0); game.Roll(0);          //30

            Assert.AreEqual(30, game.GetScore());
        }

    }
}
