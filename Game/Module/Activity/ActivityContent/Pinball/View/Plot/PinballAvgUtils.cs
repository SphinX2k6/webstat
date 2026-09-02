using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Avg;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065E1 RID: 26081
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballAvgUtils
	{
		// Token: 0x06041286 RID: 266886 RVA: 0x010B7340 File Offset: 0x010B5540
		public static string GetSpineAnimation(EPlotAvgCharacterSpineDirection direction, EAvgRoleAnimationType animationType)
		{
			if (direction != EPlotAvgCharacterSpineDirection.Left)
			{
				if (direction != EPlotAvgCharacterSpineDirection.Right)
				{
					return "Idle_Fight_B";
				}
				switch (animationType)
				{
				case EAvgRoleAnimationType.Idle:
					return "Idle_Fight";
				case EAvgRoleAnimationType.Victory:
					return "victor";
				case EAvgRoleAnimationType.TouchFeedback:
					return "touch";
				case EAvgRoleAnimationType.Skill:
					return "Burst01";
				case EAvgRoleAnimationType.HumanToBall:
					return "dead";
				case EAvgRoleAnimationType.BallToHuman:
					return "revive";
				case EAvgRoleAnimationType.AvgPlaySkill:
					return "Burst02";
				default:
					return "Idle_Fight";
				}
			}
			else
			{
				switch (animationType)
				{
				case EAvgRoleAnimationType.Idle:
					return "Idle_Fight_B";
				case EAvgRoleAnimationType.Victory:
					return "victor_B";
				case EAvgRoleAnimationType.TouchFeedback:
					return "touch_B";
				default:
					return "Idle_Fight_B";
				}
			}
		}

		// Token: 0x06041287 RID: 266887 RVA: 0x010B73E0 File Offset: 0x010B55E0
		public static string GetSpineAnimationAkEvent(string animation)
		{
			if (animation == "victor_B" || animation == "victor")
			{
				return "play_ui_catapultstory_avg_role_win";
			}
			if (animation == "touch_B" || animation == "touch")
			{
				return "play_ui_catapultstory_avg_role_touch";
			}
			if (animation == "dead")
			{
				return "play_ui_catapultstory_avg_role_marble";
			}
			if (animation == "revive")
			{
				return "play_ui_catapultstory_avg_role_people";
			}
			if (animation == "Burst01" || animation == "Burst02")
			{
				return "play_ui_catapultstory_avg_role_skill";
			}
			return "";
		}

		// Token: 0x06041288 RID: 266888 RVA: 0x010B7478 File Offset: 0x010B5678
		public static string GetMoveAkEvent(float moveSpeed)
		{
			if (moveSpeed < 313f)
			{
				return "play_ui_catapultstory_avg_role_move_slow";
			}
			return "play_ui_catapultstory_avg_role_move_fast";
		}
	}
}
