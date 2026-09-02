using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006658 RID: 26200
	[NullableContext(1)]
	[Nullable(0)]
	public static class MultiMotorDefine
	{
		// Token: 0x04024947 RID: 149831
		public static readonly Dictionary<int, string> MultiMotorRankSprite = new Dictionary<int, string>
		{
			{
				1,
				"SP_RaceRank1"
			},
			{
				2,
				"SP_RaceRank2"
			},
			{
				3,
				"SP_RaceRank3"
			}
		};

		// Token: 0x04024948 RID: 149832
		public static readonly Dictionary<int, string> MultiMotorBattleRankSprite = new Dictionary<int, string>
		{
			{
				1,
				"SP_IconGamePlayRank1st"
			},
			{
				2,
				"SP_IconGamePlayRank2nd"
			},
			{
				3,
				"SP_IconGamePlayRank3rd"
			}
		};

		// Token: 0x04024949 RID: 149833
		public static readonly Dictionary<int, string> MultiMotorFinishItem1RankColor = new Dictionary<int, string>
		{
			{
				1,
				"FFF7B3"
			},
			{
				2,
				"A9E7FC"
			},
			{
				3,
				"EFBD82"
			}
		};

		// Token: 0x0402494A RID: 149834
		public static readonly Dictionary<int, string> MultiMotorFinishItem2RankColor = new Dictionary<int, string>
		{
			{
				1,
				"F4CA37"
			},
			{
				2,
				"31A0B4"
			},
			{
				3,
				"AE783F"
			}
		};

		// Token: 0x0402494B RID: 149835
		public static readonly Dictionary<int, string> MultiMotorFinishItem3RankColor = new Dictionary<int, string>
		{
			{
				1,
				"FDEF55"
			},
			{
				2,
				"82D8E4"
			},
			{
				3,
				"DE9C5C"
			}
		};

		// Token: 0x0402494C RID: 149836
		public static readonly Dictionary<int, string> MultiMotorNameRankColor = new Dictionary<int, string>
		{
			{
				1,
				"F7F2CB"
			},
			{
				2,
				"D2F2F2"
			},
			{
				3,
				"FBE3D4"
			}
		};

		// Token: 0x0402494D RID: 149837
		public static readonly Dictionary<int, string> MultiMotorFinishNiagaraColor = new Dictionary<int, string>
		{
			{
				1,
				"B2973F"
			},
			{
				2,
				"12A9B2"
			},
			{
				3,
				"B2844E"
			}
		};

		// Token: 0x0402494E RID: 149838
		public static readonly Dictionary<int, string> MultiMotorFinishNiagaraLineColor = new Dictionary<int, string>
		{
			{
				1,
				"FFF29B"
			},
			{
				2,
				"77DDE4"
			},
			{
				3,
				"E4B593"
			}
		};

		// Token: 0x0402494F RID: 149839
		public static readonly Dictionary<int, EMultiMotorBroadcastGroup> MultiMotorRankToBroadcastGroup = new Dictionary<int, EMultiMotorBroadcastGroup>
		{
			{
				1,
				EMultiMotorBroadcastGroup.ChampionPassLine
			},
			{
				2,
				EMultiMotorBroadcastGroup.RunnerUpPassLine
			},
			{
				3,
				EMultiMotorBroadcastGroup.ThirdPlacePassLine
			}
		};

		// Token: 0x04024950 RID: 149840
		public const string MultiMotorSelfNameColor = "#000000FF";
	}
}
