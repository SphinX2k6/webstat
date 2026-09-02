using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemDeliver
{
	// Token: 0x02005B6D RID: 23405
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ItemDeliverModel : ModelBase<ItemDeliverModel>
	{
		// Token: 0x0603B2F6 RID: 242422 RVA: 0x00EF9D74 File Offset: 0x00EF7F74
		protected override bool OnClear()
		{
			this.ItemDeliverData = null;
			return true;
		}

		// Token: 0x0603B2F7 RID: 242423 RVA: 0x00EF9D7E File Offset: 0x00EF7F7E
		public void SetItemDeliverData(DeliverData itemDeliverData)
		{
			this.ItemDeliverData = itemDeliverData;
		}

		// Token: 0x0603B2F8 RID: 242424 RVA: 0x00EF9D87 File Offset: 0x00EF7F87
		[NullableContext(1)]
		public DeliverData GetItemDeliverData()
		{
			return this.ItemDeliverData;
		}

		// Token: 0x040215C7 RID: 136647
		private DeliverData ItemDeliverData;
	}
}
