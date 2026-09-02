using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DC5 RID: 24005
	public class ReviveCooldownData
	{
		// Token: 0x04021F93 RID: 139155
		public int Index = -1;

		// Token: 0x04021F94 RID: 139156
		public double RemainMilliseconds;

		// Token: 0x04021F95 RID: 139157
		[Nullable(2)]
		public TimerHandle TimerHandle;

		// Token: 0x04021F96 RID: 139158
		public double LastServerStopTimeStamp;
	}
}
