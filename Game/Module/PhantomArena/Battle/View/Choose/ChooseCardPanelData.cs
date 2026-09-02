using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Choose
{
	// Token: 0x020055CF RID: 21967
	[NullableContext(1)]
	[Nullable(0)]
	public class ChooseCardPanelData : IChooseCardPanelData
	{
		// Token: 0x17008FF0 RID: 36848
		// (get) Token: 0x06037F66 RID: 229222 RVA: 0x00E2CC20 File Offset: 0x00E2AE20
		// (set) Token: 0x06037F67 RID: 229223 RVA: 0x00E2CC28 File Offset: 0x00E2AE28
		public Func<List<int>, UniTask> ConfirmFunc { get; set; }

		// Token: 0x17008FF1 RID: 36849
		// (get) Token: 0x06037F68 RID: 229224 RVA: 0x00E2CC31 File Offset: 0x00E2AE31
		// (set) Token: 0x06037F69 RID: 229225 RVA: 0x00E2CC39 File Offset: 0x00E2AE39
		public int LimitCount { get; set; }

		// Token: 0x17008FF2 RID: 36850
		// (get) Token: 0x06037F6A RID: 229226 RVA: 0x00E2CC42 File Offset: 0x00E2AE42
		// (set) Token: 0x06037F6B RID: 229227 RVA: 0x00E2CC4A File Offset: 0x00E2AE4A
		public List<PhantomCardData> CardDataList { get; set; }

		// Token: 0x17008FF3 RID: 36851
		// (get) Token: 0x06037F6C RID: 229228 RVA: 0x00E2CC53 File Offset: 0x00E2AE53
		// (set) Token: 0x06037F6D RID: 229229 RVA: 0x00E2CC5B File Offset: 0x00E2AE5B
		public EBvbPlayerOperationType? GuideType { get; set; }
	}
}
