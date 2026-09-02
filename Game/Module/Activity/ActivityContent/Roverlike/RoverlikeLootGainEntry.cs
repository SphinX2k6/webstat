using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A4 RID: 25508
	public class RoverlikeLootGainEntry : RoverlikeGainEntry
	{
		// Token: 0x060400DA RID: 262362 RVA: 0x0106B094 File Offset: 0x01069294
		[NullableContext(1)]
		public RoverlikeLootGainEntry(RoverRogueGainEntry proto) : base(proto)
		{
			RoverRogueLootInfo lootInfo = proto.LootInfo;
			if (lootInfo == null)
			{
				return;
			}
			this.LootRoomPassedCounter = lootInfo.LootRoomPassedCounter;
			this.LootLv = lootInfo.LootLv;
			this.Unlock = lootInfo.Unlock;
			this.Progress = lootInfo.Progress;
			this.Target = lootInfo.Target;
		}

		// Token: 0x04023F62 RID: 147298
		public int LootRoomPassedCounter;

		// Token: 0x04023F63 RID: 147299
		public int LootLv;

		// Token: 0x04023F64 RID: 147300
		public bool Unlock;

		// Token: 0x04023F65 RID: 147301
		public int Progress;

		// Token: 0x04023F66 RID: 147302
		public int Target;

		// Token: 0x04023F67 RID: 147303
		public bool IsEquipped;
	}
}
