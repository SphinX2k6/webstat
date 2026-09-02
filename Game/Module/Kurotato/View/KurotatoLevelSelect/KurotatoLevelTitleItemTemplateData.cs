using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect
{
	// Token: 0x02005AB4 RID: 23220
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class KurotatoLevelTitleItemTemplateData : MultiTemplateGridDataBase<KurotatoLevelTitleItemData, KurotatoLevelTitleItem>
	{
		// Token: 0x0603AB81 RID: 240513 RVA: 0x00EE2C3A File Offset: 0x00EE0E3A
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x0603AB82 RID: 240514 RVA: 0x00EE2C3D File Offset: 0x00EE0E3D
		public override KurotatoLevelTitleItem CreateProxy()
		{
			return new KurotatoLevelTitleItem();
		}
	}
}
