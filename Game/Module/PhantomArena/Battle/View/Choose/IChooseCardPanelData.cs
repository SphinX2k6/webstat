using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Choose
{
	// Token: 0x020055CE RID: 21966
	[NullableContext(1)]
	public interface IChooseCardPanelData
	{
		// Token: 0x17008FEC RID: 36844
		// (get) Token: 0x06037F5E RID: 229214
		// (set) Token: 0x06037F5F RID: 229215
		Func<List<int>, UniTask> ConfirmFunc { get; set; }

		// Token: 0x17008FED RID: 36845
		// (get) Token: 0x06037F60 RID: 229216
		// (set) Token: 0x06037F61 RID: 229217
		int LimitCount { get; set; }

		// Token: 0x17008FEE RID: 36846
		// (get) Token: 0x06037F62 RID: 229218
		// (set) Token: 0x06037F63 RID: 229219
		List<PhantomCardData> CardDataList { get; set; }

		// Token: 0x17008FEF RID: 36847
		// (get) Token: 0x06037F64 RID: 229220
		// (set) Token: 0x06037F65 RID: 229221
		EBvbPlayerOperationType? GuideType { get; set; }
	}
}
