using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005AD2 RID: 23250
	[NullableContext(1)]
	[Nullable(0)]
	internal class DesItemData : IMultiTemplateGridData<string, DesItem>, IMultiTemplateGridData
	{
		// Token: 0x170095A5 RID: 38309
		// (get) Token: 0x0603AC90 RID: 240784 RVA: 0x00EE85BB File Offset: 0x00EE67BB
		// (set) Token: 0x0603AC91 RID: 240785 RVA: 0x00EE85C3 File Offset: 0x00EE67C3
		public string Data { get; set; }

		// Token: 0x170095A6 RID: 38310
		// (get) Token: 0x0603AC92 RID: 240786 RVA: 0x00EE85CC File Offset: 0x00EE67CC
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x0603AC93 RID: 240787 RVA: 0x00EE85D4 File Offset: 0x00EE67D4
		public DesItemData(string data)
		{
			this.Data = data;
		}

		// Token: 0x0603AC94 RID: 240788 RVA: 0x00EE85E3 File Offset: 0x00EE67E3
		public int GetTemplateIndex()
		{
			return 2;
		}

		// Token: 0x0603AC95 RID: 240789 RVA: 0x00EE85E6 File Offset: 0x00EE67E6
		public ISyncGridProxy CreateProxy()
		{
			return new DesItem();
		}
	}
}
