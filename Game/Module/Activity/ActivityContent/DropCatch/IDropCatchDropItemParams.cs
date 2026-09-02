using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068A9 RID: 26793
	public class IDropCatchDropItemParams
	{
		// Token: 0x04025233 RID: 152115
		public int InstanceId;

		// Token: 0x04025234 RID: 152116
		public int ItemId;

		// Token: 0x04025235 RID: 152117
		public double PosX;

		// Token: 0x04025236 RID: 152118
		public double PosY;

		// Token: 0x04025237 RID: 152119
		[Nullable(1)]
		public IGameplayLogicContext Context;
	}
}
