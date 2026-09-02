using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Discard
{
	// Token: 0x020055CA RID: 21962
	[NullableContext(1)]
	[Nullable(0)]
	public class DiscardCardPanelData : IDiscardCardPanelData
	{
		// Token: 0x17008FE6 RID: 36838
		// (get) Token: 0x06037F24 RID: 229156 RVA: 0x00E2C1B4 File Offset: 0x00E2A3B4
		// (set) Token: 0x06037F25 RID: 229157 RVA: 0x00E2C1BC File Offset: 0x00E2A3BC
		public Func<List<int>, UniTask> ConfirmFunc { get; set; }

		// Token: 0x17008FE7 RID: 36839
		// (get) Token: 0x06037F26 RID: 229158 RVA: 0x00E2C1C5 File Offset: 0x00E2A3C5
		// (set) Token: 0x06037F27 RID: 229159 RVA: 0x00E2C1CD File Offset: 0x00E2A3CD
		public int LimitCount { get; set; }

		// Token: 0x17008FE8 RID: 36840
		// (get) Token: 0x06037F28 RID: 229160 RVA: 0x00E2C1D6 File Offset: 0x00E2A3D6
		// (set) Token: 0x06037F29 RID: 229161 RVA: 0x00E2C1DE File Offset: 0x00E2A3DE
		public List<PhantomCardData> CardDataList { get; set; }

		// Token: 0x17008FE9 RID: 36841
		// (get) Token: 0x06037F2A RID: 229162 RVA: 0x00E2C1E7 File Offset: 0x00E2A3E7
		// (set) Token: 0x06037F2B RID: 229163 RVA: 0x00E2C1EF File Offset: 0x00E2A3EF
		public string TitleTips { get; set; }

		// Token: 0x17008FEA RID: 36842
		// (get) Token: 0x06037F2C RID: 229164 RVA: 0x00E2C1F8 File Offset: 0x00E2A3F8
		// (set) Token: 0x06037F2D RID: 229165 RVA: 0x00E2C200 File Offset: 0x00E2A400
		public string SelectedTips { get; set; }

		// Token: 0x17008FEB RID: 36843
		// (get) Token: 0x06037F2E RID: 229166 RVA: 0x00E2C209 File Offset: 0x00E2A409
		// (set) Token: 0x06037F2F RID: 229167 RVA: 0x00E2C211 File Offset: 0x00E2A411
		public EBvbPlayerOperationType? GuideType { get; set; }
	}
}
