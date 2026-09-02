using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FA8 RID: 24488
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class TrackingDisplayRuleBase
	{
		// Token: 0x17009A5F RID: 39519
		// (get) Token: 0x0603D892 RID: 252050
		public abstract EMissionRuleId Id { get; }

		// Token: 0x17009A60 RID: 39520
		// (get) Token: 0x0603D893 RID: 252051
		public abstract bool Enabled { get; }

		// Token: 0x17009A61 RID: 39521
		// (get) Token: 0x0603D894 RID: 252052
		public abstract int Priority { get; }

		// Token: 0x0603D895 RID: 252053
		public abstract EMissionItemView? CustomTypeCheck(IMissionItemViewShowData showData, ETreeTextExpressReason? reason = null);

		// Token: 0x0603D896 RID: 252054
		public abstract void SortShowData(List<IMissionItemViewShowData> showData);
	}
}
