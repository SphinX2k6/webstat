using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006610 RID: 26128
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponMultiTemplateGridData : IMultiTemplateGridData<IPinballItemSyncWeaponGridViewData, PinballItemSyncWeaponGridView>, IMultiTemplateGridData
	{
		// Token: 0x17009F52 RID: 40786
		// (get) Token: 0x0604149C RID: 267420 RVA: 0x010BF776 File Offset: 0x010BD976
		// (set) Token: 0x0604149D RID: 267421 RVA: 0x010BF77E File Offset: 0x010BD97E
		public IPinballItemSyncWeaponGridViewData Data { get; set; }

		// Token: 0x17009F53 RID: 40787
		// (get) Token: 0x0604149E RID: 267422 RVA: 0x010BF787 File Offset: 0x010BD987
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x0604149F RID: 267423 RVA: 0x010BF78F File Offset: 0x010BD98F
		public PinballWeaponMultiTemplateGridData(IPinballItemSyncWeaponGridViewData data)
		{
			this.Data = data;
		}

		// Token: 0x060414A0 RID: 267424 RVA: 0x010BF79E File Offset: 0x010BD99E
		public int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x060414A1 RID: 267425 RVA: 0x010BF7A1 File Offset: 0x010BD9A1
		public PinballItemSyncWeaponGridView CreateProxy()
		{
			PinballItemSyncWeaponGridView pinballItemSyncWeaponGridView = new PinballItemSyncWeaponGridView();
			pinballItemSyncWeaponGridView.BindOnStateChangeCallback(new Action<IPinballItemToggleCallback>(this.OnStateChange));
			return pinballItemSyncWeaponGridView;
		}

		// Token: 0x060414A2 RID: 267426 RVA: 0x010BF7BA File Offset: 0x010BD9BA
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}

		// Token: 0x060414A3 RID: 267427 RVA: 0x010BF7C2 File Offset: 0x010BD9C2
		private void OnStateChange(IPinballItemToggleCallback callbackParameter)
		{
			this.Data.OnStateChangeDelegate(callbackParameter);
		}
	}
}
