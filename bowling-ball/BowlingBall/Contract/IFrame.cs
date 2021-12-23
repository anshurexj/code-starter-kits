using BowlingBall.Common;
using System.Collections.Generic;

namespace BowlingBall.Contract
{

	/* Summary
	 * Author: Anshuman Jha
	 * 
	 * Syntactical contract of an individual frame.
  
       i>   Index to be used in creating frames for game play and trackig each frame.

       ii>  RollingBall property for different rolls. 

            Value scored by individual roll can be max 10 excluding any bonus.
          
       iii> BonusScore property for a frame to check if bonus marks if Strike or Spare.

       iv>  FrameScore method for a frame score calculation.

       v>   GetFrameType method to check type if Strike/Spare/Open.

     */

	public interface IFrame
	{
		int Index {get;set;}		

		List<int> RollingBall {get;set;}

		int BonusScore {get;set;}

		int FrameScore();		

		FrameType GetFrameType();
	}
}
