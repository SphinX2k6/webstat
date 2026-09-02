using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Manager
{
	// Token: 0x020069F0 RID: 27120
	public static class ControllerDefine
	{
		// Token: 0x06043356 RID: 275286 RVA: 0x01146334 File Offset: 0x01144534
		public static bool CheckCombatDebugDrawControllerTick()
		{
			return !Singleton<Info>.Instance.IsBuildShipping;
		}

		// Token: 0x06043357 RID: 275287 RVA: 0x01146343 File Offset: 0x01144543
		public static bool CheckCrashCollectionControllerTick()
		{
			return !Singleton<Info>.Instance.IsBuildShipping;
		}
	}
}
