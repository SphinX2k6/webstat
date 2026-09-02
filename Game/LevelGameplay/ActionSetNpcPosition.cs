using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A15 RID: 27157
	public class ActionSetNpcPosition : ActionParams
	{
		// Token: 0x040257E6 RID: 153574
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<EntityPositionData> EntityData;

		// Token: 0x040257E7 RID: 153575
		public bool IsCenterPosition = true;
	}
}
