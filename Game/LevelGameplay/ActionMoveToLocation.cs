using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A13 RID: 27155
	public class ActionMoveToLocation : ActionParams
	{
		// Token: 0x040257DE RID: 153566
		[Nullable(2)]
		public Vector ToLocation;

		// Token: 0x040257DF RID: 153567
		public int MoveState;

		// Token: 0x040257E0 RID: 153568
		public bool IsNavigation;

		// Token: 0x040257E1 RID: 153569
		public bool IsFly;

		// Token: 0x040257E2 RID: 153570
		public bool DebugMode;

		// Token: 0x040257E3 RID: 153571
		public float MoveSpeed;
	}
}
