using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005358 RID: 21336
	public class PlotStateInfo
	{
		// Token: 0x060366F4 RID: 222964 RVA: 0x00DBB872 File Offset: 0x00DB9A72
		public PlotStateInfo()
		{
			this.StateMap = new Dictionary<int, PlayFlow>();
		}

		// Token: 0x060366F5 RID: 222965 RVA: 0x00DBB885 File Offset: 0x00DB9A85
		public void Reset()
		{
			this.StateMap.Clear();
		}

		// Token: 0x0401F4D5 RID: 128213
		[Nullable(1)]
		public Dictionary<int, PlayFlow> StateMap;
	}
}
