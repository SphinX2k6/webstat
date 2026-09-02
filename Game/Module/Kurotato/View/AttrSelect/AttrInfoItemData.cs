using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005AD0 RID: 23248
	[NullableContext(1)]
	[Nullable(0)]
	internal class AttrInfoItemData : IMultiTemplateGridData<IKurotatoAttrDisplay, AttrInfoItem>, IMultiTemplateGridData
	{
		// Token: 0x170095A3 RID: 38307
		// (get) Token: 0x0603AC86 RID: 240774 RVA: 0x00EE84ED File Offset: 0x00EE66ED
		// (set) Token: 0x0603AC87 RID: 240775 RVA: 0x00EE84F5 File Offset: 0x00EE66F5
		public IKurotatoAttrDisplay Data { get; set; }

		// Token: 0x170095A4 RID: 38308
		// (get) Token: 0x0603AC88 RID: 240776 RVA: 0x00EE84FE File Offset: 0x00EE66FE
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x0603AC89 RID: 240777 RVA: 0x00EE8506 File Offset: 0x00EE6706
		public AttrInfoItemData(IKurotatoAttrDisplay data)
		{
			this.Data = data;
		}

		// Token: 0x0603AC8A RID: 240778 RVA: 0x00EE8515 File Offset: 0x00EE6715
		public int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x0603AC8B RID: 240779 RVA: 0x00EE8518 File Offset: 0x00EE6718
		public ISyncGridProxy CreateProxy()
		{
			return new AttrInfoItem();
		}
	}
}
