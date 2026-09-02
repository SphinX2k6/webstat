using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A17 RID: 27159
	public class ActionPlotInterludeAction : ActionParams
	{
		// Token: 0x040257ED RID: 153581
		public float FadeInTime;

		// Token: 0x040257EE RID: 153582
		public float FadeOutTime;

		// Token: 0x040257EF RID: 153583
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> ActionList;
	}
}
