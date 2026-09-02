using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005ACE RID: 23246
	[NullableContext(1)]
	[Nullable(0)]
	internal class WeaponAttrInfoItemData : IMultiTemplateGridData<IKurotatoAttrDisplay, WeaponAttrInfoItem>, IMultiTemplateGridData
	{
		// Token: 0x170095A1 RID: 38305
		// (get) Token: 0x0603AC7D RID: 240765 RVA: 0x00EE8409 File Offset: 0x00EE6609
		// (set) Token: 0x0603AC7E RID: 240766 RVA: 0x00EE8411 File Offset: 0x00EE6611
		public IKurotatoAttrDisplay Data { get; set; }

		// Token: 0x170095A2 RID: 38306
		// (get) Token: 0x0603AC7F RID: 240767 RVA: 0x00EE841A File Offset: 0x00EE661A
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x0603AC80 RID: 240768 RVA: 0x00EE8422 File Offset: 0x00EE6622
		public WeaponAttrInfoItemData(IKurotatoAttrDisplay data)
		{
			this.Data = data;
		}

		// Token: 0x0603AC81 RID: 240769 RVA: 0x00EE8431 File Offset: 0x00EE6631
		public int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x0603AC82 RID: 240770 RVA: 0x00EE8434 File Offset: 0x00EE6634
		public ISyncGridProxy CreateProxy()
		{
			return new WeaponAttrInfoItem();
		}
	}
}
