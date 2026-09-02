using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x0200660C RID: 26124
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballMonsterMultiTemplateGridData : IMultiTemplateGridData<IPinballItemSyncMonsterGridViewData, PinballItemSyncMonsterGridView>, IMultiTemplateGridData
	{
		// Token: 0x17009F41 RID: 40769
		// (get) Token: 0x0604146C RID: 267372 RVA: 0x010BF598 File Offset: 0x010BD798
		// (set) Token: 0x0604146D RID: 267373 RVA: 0x010BF5A0 File Offset: 0x010BD7A0
		public IPinballItemSyncMonsterGridViewData Data { get; set; }

		// Token: 0x17009F42 RID: 40770
		// (get) Token: 0x0604146E RID: 267374 RVA: 0x010BF5A9 File Offset: 0x010BD7A9
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x0604146F RID: 267375 RVA: 0x010BF5B1 File Offset: 0x010BD7B1
		public PinballMonsterMultiTemplateGridData(IPinballItemSyncMonsterGridViewData data)
		{
			this.Data = data;
		}

		// Token: 0x06041470 RID: 267376 RVA: 0x010BF5C0 File Offset: 0x010BD7C0
		public int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x06041471 RID: 267377 RVA: 0x010BF5C3 File Offset: 0x010BD7C3
		public PinballItemSyncMonsterGridView CreateProxy()
		{
			PinballItemSyncMonsterGridView pinballItemSyncMonsterGridView = new PinballItemSyncMonsterGridView();
			pinballItemSyncMonsterGridView.BindOnStateChangeCallback(new Action<IPinballItemToggleCallback>(this.OnStateChange));
			return pinballItemSyncMonsterGridView;
		}

		// Token: 0x06041472 RID: 267378 RVA: 0x010BF5DC File Offset: 0x010BD7DC
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}

		// Token: 0x06041473 RID: 267379 RVA: 0x010BF5E4 File Offset: 0x010BD7E4
		private void OnStateChange(IPinballItemToggleCallback callbackParameter)
		{
			this.Data.OnStateChangeDelegate(callbackParameter);
		}
	}
}
