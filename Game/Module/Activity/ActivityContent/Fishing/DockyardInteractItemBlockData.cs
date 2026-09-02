using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067AE RID: 26542
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractItemBlockData
	{
		// Token: 0x06042303 RID: 271107 RVA: 0x010FA754 File Offset: 0x010F8954
		public DockyardInteractItemBlockData(DockyardItemBlockOriginalData data)
		{
			this.Rotate = 0;
			this.Pos = new PanelPos
			{
				RowIndex = -1,
				ColIndex = -1
			};
			this.Data = data;
		}

		// Token: 0x04024DEF RID: 151023
		public int Rotate;

		// Token: 0x04024DF0 RID: 151024
		public IPanelPos Pos;

		// Token: 0x04024DF1 RID: 151025
		public DockyardItemBlockOriginalData Data;
	}
}
