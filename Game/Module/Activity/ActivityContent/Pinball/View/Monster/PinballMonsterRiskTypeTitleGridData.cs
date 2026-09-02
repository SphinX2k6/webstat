using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Monster
{
	// Token: 0x020065ED RID: 26093
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballMonsterRiskTypeTitleGridData : IMultiTemplateGridData<PinballMonsterRiskType, PinballMonsterRiskTypeTitleItem>, IMultiTemplateGridData
	{
		// Token: 0x17009F1E RID: 40734
		// (get) Token: 0x0604130D RID: 267021 RVA: 0x010B9B0A File Offset: 0x010B7D0A
		// (set) Token: 0x0604130E RID: 267022 RVA: 0x010B9B12 File Offset: 0x010B7D12
		public PinballMonsterRiskType Data { get; set; }

		// Token: 0x17009F1F RID: 40735
		// (get) Token: 0x0604130F RID: 267023 RVA: 0x010B9B1B File Offset: 0x010B7D1B
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x06041310 RID: 267024 RVA: 0x010B9B28 File Offset: 0x010B7D28
		public PinballMonsterRiskTypeTitleGridData(PinballMonsterRiskType data)
		{
			this.Data = data;
		}

		// Token: 0x06041311 RID: 267025 RVA: 0x010B9B37 File Offset: 0x010B7D37
		public int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x06041312 RID: 267026 RVA: 0x010B9B3A File Offset: 0x010B7D3A
		public PinballMonsterRiskTypeTitleItem CreateProxy()
		{
			return new PinballMonsterRiskTypeTitleItem();
		}

		// Token: 0x06041313 RID: 267027 RVA: 0x010B9B41 File Offset: 0x010B7D41
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}
	}
}
