using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052C9 RID: 21193
	[NullableContext(1)]
	[Nullable(0)]
	public class CfgLazyConditionGroup
	{
		// Token: 0x0401F1F8 RID: 127480
		public List<CfgLazyConditionBase> ConditionGroup = new List<CfgLazyConditionBase>();

		// Token: 0x0401F1F9 RID: 127481
		public string ConditionFormula = string.Empty;

		// Token: 0x0401F1FA RID: 127482
		public int PayloadId;
	}
}
