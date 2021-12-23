using BowlingBall.Common;
using System.Collections.Generic;
using System.Linq;
namespace BowlingBall.Contract
{
	/* Summary
	 * Author: Anshuman Jha
	 * 
	 * Class Implementing the syntactical contract of an GameScore.
     */
	public class GameScore : IGameScore
	{
		public int FinalGameScore(List<IFrame> frames, List<int> rolls)
		{
			int gameScore = 0;

			int ball_id = 0;
			int current = 0;

			//For 1st time its Open by Default, for rest it will store previous state.

			FrameType prev_frame_type = FrameType.Open;   

			foreach (var frame in frames) //Iterate over each frame
			{
				//Add Score of 1st Ball in List of Rolling Balls under each Frame

				frame.RollingBall.Add(rolls[ball_id]);

				
				if (prev_frame_type == FrameType.Strike)
				{
					//Logic for Bonus on Strike = Pins in Next 2 Ball

					frames[current - 1].BonusScore = frames[current - 1].BonusScore + rolls[ball_id] + rolls[ball_id + 1];
				}
				else if (prev_frame_type == FrameType.Spare)
				{
					//Logic for Bonus on Spare = Pins in Next 1 Ball

					frames[current - 1].BonusScore = frames[current - 1].BonusScore + rolls[ball_id];
				}


				if (rolls[ball_id] == 10) 
				{
					//Strike is made so frame state is changed.
					//Player gets 1 Ball which has been considered on top for adding.
					//Frame is done so ball id moved by 1 place.

					prev_frame_type = FrameType.Strike;

					ball_id = ball_id + 1;
				}
				else if(rolls[ball_id] + rolls[ball_id + 1] == 10)
                {
					//Spare is made so frame state is changed.
					//Player gets 2 balls in Frame, 1st is considered on top 2nd considered here.
					//Frame is done so ball id moved by 2 place.

					frame.RollingBall.Add(rolls[ball_id + 1]);  
					
					prev_frame_type = FrameType.Spare;

					ball_id = ball_id + 2;
				}
				else
                {
					//Open Frame is made so frame state is changed.
					//Player gets 2 balls in Frame, 1st is considered on top 2nd considered here.
					//Frame is done so ball id moved by 2 place.

					frame.RollingBall.Add(rolls[ball_id + 1]);

					prev_frame_type = FrameType.Open;

					ball_id += 2;
				}

				current = current + 1;

			}

			//Additional Logic just for Last Frame

			//10 Frames where there and normal processing is done for 10th frame, based on current == 10.
			//ball_id < rolls.Count means its a bonus ball after 10th frame either 1 or 2.

			if (frames.Count == 10 && current == 10 && ball_id < rolls.Count) 
			{
				if (prev_frame_type == FrameType.Strike) //10th frame 1st ball you made strike
				{
					frames[current - 1].BonusScore = frames[current - 1].BonusScore + rolls[ball_id];     //Register 10th Frame 1st Bonus Ball.
					frames[current - 1].BonusScore = frames[current - 1].BonusScore + rolls[ball_id + 1]; //Register 10th Frame 2nd Bonus Ball.
				}
				else //10th frame you made Spare
				{   
					frames[current - 1].BonusScore = frames[current - 1].BonusScore + rolls[ball_id];    //Register 10th Frame 1st Bonus Ball. 
				}
			}

			//Final Total Score Calculate.

			foreach(var frame in frames)
            {
				gameScore = gameScore + frame.FrameScore();
			}

			return gameScore;
		}
	}
}
