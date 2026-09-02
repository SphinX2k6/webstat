using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200496F RID: 18799
	public class FollowDefine
	{
		// Token: 0x0401C4BF RID: 115903
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<int, int> PlayerFollowerPriority = new Dictionary<int, int>
		{
			{
				1,
				100
			},
			{
				2,
				98
			},
			{
				3,
				99
			},
			{
				666,
				97
			},
			{
				4,
				99999
			}
		};

		// Token: 0x0401C4C0 RID: 115904
		public const int PRIORITY_VEHICLE = 103;

		// Token: 0x0401C4C1 RID: 115905
		public const int WAIT_FOLLOWER_TIME = 90000;
	}
}
