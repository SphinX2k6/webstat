using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F04 RID: 24324
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BossPilingBuffTitleItemData : MultiTemplateGridDataBase<int, BossPilingBuffTitleItem>
	{
		// Token: 0x0603D1A2 RID: 250274 RVA: 0x00F8519D File Offset: 0x00F8339D
		public BossPilingBuffTitleItemData(int data)
		{
			base.Data = data;
		}

		// Token: 0x0603D1A3 RID: 250275 RVA: 0x00F851AC File Offset: 0x00F833AC
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x0603D1A4 RID: 250276 RVA: 0x00F851AF File Offset: 0x00F833AF
		public override BossPilingBuffTitleItem CreateProxy()
		{
			return new BossPilingBuffTitleItem();
		}
	}
}
