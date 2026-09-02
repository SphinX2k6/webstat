using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.RollBlock
{
	// Token: 0x02006B1F RID: 27423
	[NullableContext(1)]
	[Nullable(0)]
	public class RollBlockDefind
	{
		// Token: 0x06043C3F RID: 277567 RVA: 0x01180607 File Offset: 0x0117E807
		public static bool isRbBlockIdleState([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<RbBlockIdlePbState, RbJumpMovement, RbRollMovement> state)
		{
			return state.IsT1;
		}

		// Token: 0x06043C40 RID: 277568 RVA: 0x01180610 File Offset: 0x0117E810
		public static bool isRbBlockRollState([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<RbBlockIdlePbState, RbJumpMovement, RbRollMovement> state)
		{
			if (!state.IsT3)
			{
				return false;
			}
			RbRollMovement asT = state.AsT3;
			if (asT == null)
			{
				return false;
			}
			RbGridDirection direction = asT.Direction;
			return true;
		}

		// Token: 0x06043C41 RID: 277569 RVA: 0x01180631 File Offset: 0x0117E831
		public static bool isRbBlockJumpState([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<RbBlockIdlePbState, RbJumpMovement, RbRollMovement> state)
		{
			if (!state.IsT2)
			{
				return false;
			}
			RbJumpMovement asT = state.AsT2;
			if (asT == null)
			{
				return false;
			}
			RbGridDirection direction = asT.Direction;
			return true;
		}

		// Token: 0x06043C42 RID: 277570 RVA: 0x01180652 File Offset: 0x0117E852
		public static bool isRbBreakableObstacleInfo([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<RbBreakableObstaclePbType, RbLaserEmitterPbType> info)
		{
			if (info.IsT1)
			{
				RbBreakableObstaclePbType asT = info.AsT1;
				return ((asT != null) ? asT.LinkPoints : null) != null;
			}
			return false;
		}

		// Token: 0x04025E4D RID: 155213
		public const int RB_HALF_HEIGHT = 50;

		// Token: 0x04025E4E RID: 155214
		public static readonly FName RB_SEQ_BINDING_TAG = new FName("Cube");

		// Token: 0x04025E4F RID: 155215
		public const string RB_JUMP_SEQ_PATH = "/Game/Aki/Data/Gameplay/RollBlock/Sequence/RollBlockJump.RollBlockJump";

		// Token: 0x04025E50 RID: 155216
		public const string RB_CONFIG_DA_PATH = "/Game/Aki/Data/Gameplay/RollBlock/DA_RollBlockSetting.DA_RollBlockSetting";

		// Token: 0x04025E51 RID: 155217
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, RbGridDirection> Input2RbGridDirection = new Dictionary<string, RbGridDirection>
		{
			{
				"向前移动",
				RbGridDirection.RbForward
			},
			{
				"向后移动",
				RbGridDirection.RbBackward
			},
			{
				"向左移动",
				RbGridDirection.RbLeft
			},
			{
				"向右移动",
				RbGridDirection.RbRight
			}
		};

		// Token: 0x04025E52 RID: 155218
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<RbGridDirection, string> RbGridDirection2Input = new Dictionary<RbGridDirection, string>
		{
			{
				RbGridDirection.RbForward,
				"向前移动"
			},
			{
				RbGridDirection.RbBackward,
				"向后移动"
			},
			{
				RbGridDirection.RbLeft,
				"向左移动"
			},
			{
				RbGridDirection.RbRight,
				"向右移动"
			}
		};
	}
}
