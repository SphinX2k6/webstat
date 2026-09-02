using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200541B RID: 21531
	[NullableContext(1)]
	[Nullable(0)]
	public class DestroyEntityActionRecord : ActionRecord
	{
		// Token: 0x06036F34 RID: 225076 RVA: 0x00DF2ADD File Offset: 0x00DF0CDD
		public DestroyEntityActionRecord(ActionInfo actionInfo, Dictionary<int, int> entityStateTagIdMap)
		{
			base.ActionInfo = actionInfo;
			this.EntityStateTagIdMap = entityStateTagIdMap;
		}

		// Token: 0x0401FA00 RID: 129536
		public Dictionary<int, int> EntityStateTagIdMap;
	}
}
