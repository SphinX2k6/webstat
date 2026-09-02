using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C06 RID: 23558
	public class InstanceDetectionDynamicData
	{
		// Token: 0x040218B7 RID: 137399
		public bool IsSelect;

		// Token: 0x040218B8 RID: 137400
		public bool IsOnlyOneGrid;

		// Token: 0x040218B9 RID: 137401
		public bool IsShow = true;

		// Token: 0x040218BA RID: 137402
		public int InstanceSeriesTitle;

		// Token: 0x040218BB RID: 137403
		public int InstanceGirdId;

		// Token: 0x040218BC RID: 137404
		public EInstanceDetectionExtraType ExtraType;

		// Token: 0x040218BD RID: 137405
		[Nullable(1)]
		public string ExtraText = string.Empty;
	}
}
