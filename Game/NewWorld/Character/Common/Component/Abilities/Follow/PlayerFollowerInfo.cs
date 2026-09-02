using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004970 RID: 18800
	public class PlayerFollowerInfo
	{
		// Token: 0x06031279 RID: 201337 RVA: 0x00C3DD97 File Offset: 0x00C3BF97
		public PlayerFollowerInfo(long creatureDataId, int? priority = 0)
		{
		}

		// Token: 0x0603127A RID: 201338 RVA: 0x00C3DDB3 File Offset: 0x00C3BFB3
		[NullableContext(1)]
		public static int Compare(PlayerFollowerInfo a, PlayerFollowerInfo b)
		{
			return a.Priority - b.Priority;
		}

		// Token: 0x0401C4C2 RID: 115906
		public long CreatureDataId = creatureDataId;

		// Token: 0x0401C4C3 RID: 115907
		public int Priority = priority.GetValueOrDefault();
	}
}
