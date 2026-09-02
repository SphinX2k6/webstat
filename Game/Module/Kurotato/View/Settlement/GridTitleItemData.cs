using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A7D RID: 23165
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	internal class GridTitleItemData : MultiTemplateGridDataBase<GridTitleItemDataInner, GridTitleItem>
	{
		// Token: 0x0603A9ED RID: 240109 RVA: 0x00ED9BF8 File Offset: 0x00ED7DF8
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x0603A9EE RID: 240110 RVA: 0x00ED9BFB File Offset: 0x00ED7DFB
		public override GridTitleItem CreateProxy()
		{
			return new GridTitleItem();
		}
	}
}
