using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005433 RID: 21555
	[NullableContext(1)]
	[Nullable(0)]
	public class SetEntityVisibleActionRecord : ActionRecord
	{
		// Token: 0x06036F8E RID: 225166 RVA: 0x00DF41CA File Offset: 0x00DF23CA
		public SetEntityVisibleActionRecord(ActionInfo actionInfo, Dictionary<int, int> entityStateTagIdMap)
		{
			base.ActionInfo = actionInfo;
			this.EntityStateTagIdMap = entityStateTagIdMap;
		}

		// Token: 0x0401FA04 RID: 129540
		public Dictionary<int, int> EntityStateTagIdMap;
	}
}
