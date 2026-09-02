using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005AA8 RID: 23208
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class OverviewEmptyGridData : MultiTemplateGridDataBase<int, EmptyGrid>
	{
		// Token: 0x0603AB43 RID: 240451 RVA: 0x00EE10DA File Offset: 0x00EDF2DA
		public override int GetTemplateIndex()
		{
			return 2;
		}

		// Token: 0x0603AB44 RID: 240452 RVA: 0x00EE10DD File Offset: 0x00EDF2DD
		public override EmptyGrid CreateProxy()
		{
			return new EmptyGrid();
		}
	}
}
