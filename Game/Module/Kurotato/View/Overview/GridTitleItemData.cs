using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005AA4 RID: 23204
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	internal class GridTitleItemData : MultiTemplateGridDataBase<GridTitleItemDataInner, GridTitleItem>
	{
		// Token: 0x0603AB33 RID: 240435 RVA: 0x00EE0E70 File Offset: 0x00EDF070
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x0603AB34 RID: 240436 RVA: 0x00EE0E73 File Offset: 0x00EDF073
		public override GridTitleItem CreateProxy()
		{
			return new GridTitleItem();
		}
	}
}
