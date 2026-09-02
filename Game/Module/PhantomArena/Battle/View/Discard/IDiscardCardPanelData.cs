using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Discard
{
	// Token: 0x020055C9 RID: 21961
	[NullableContext(1)]
	public interface IDiscardCardPanelData
	{
		// Token: 0x17008FE0 RID: 36832
		// (get) Token: 0x06037F18 RID: 229144
		// (set) Token: 0x06037F19 RID: 229145
		Func<List<int>, UniTask> ConfirmFunc { get; set; }

		// Token: 0x17008FE1 RID: 36833
		// (get) Token: 0x06037F1A RID: 229146
		// (set) Token: 0x06037F1B RID: 229147
		int LimitCount { get; set; }

		// Token: 0x17008FE2 RID: 36834
		// (get) Token: 0x06037F1C RID: 229148
		// (set) Token: 0x06037F1D RID: 229149
		List<PhantomCardData> CardDataList { get; set; }

		// Token: 0x17008FE3 RID: 36835
		// (get) Token: 0x06037F1E RID: 229150
		// (set) Token: 0x06037F1F RID: 229151
		string TitleTips { get; set; }

		// Token: 0x17008FE4 RID: 36836
		// (get) Token: 0x06037F20 RID: 229152
		// (set) Token: 0x06037F21 RID: 229153
		string SelectedTips { get; set; }

		// Token: 0x17008FE5 RID: 36837
		// (get) Token: 0x06037F22 RID: 229154
		// (set) Token: 0x06037F23 RID: 229155
		EBvbPlayerOperationType? GuideType { get; set; }
	}
}
