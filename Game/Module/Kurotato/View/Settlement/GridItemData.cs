using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A80 RID: 23168
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	internal class GridItemData : MultiTemplateGridDataBase<GridItemCellData, GridItem>
	{
		// Token: 0x0603A9FA RID: 240122 RVA: 0x00ED9D76 File Offset: 0x00ED7F76
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x0603A9FB RID: 240123 RVA: 0x00ED9D79 File Offset: 0x00ED7F79
		public override GridItem CreateProxy()
		{
			return new GridItem();
		}
	}
}
