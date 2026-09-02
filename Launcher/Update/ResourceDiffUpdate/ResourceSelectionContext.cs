using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate
{
	// Token: 0x020044D7 RID: 17623
	[NullableContext(1)]
	[Nullable(0)]
	public class ResourceSelectionContext
	{
		// Token: 0x0401A690 RID: 108176
		public List<int> ActiveQuestIds = new List<int>();

		// Token: 0x0401A691 RID: 108177
		public readonly HashSet<int> FinishedQuests = new HashSet<int>();

		// Token: 0x0401A692 RID: 108178
		public List<int> CurrentBlockIds = new List<int>();

		// Token: 0x0401A693 RID: 108179
		public int Gender = -1;

		// Token: 0x0401A694 RID: 108180
		public List<ResourcePackagePositionData> Positions = new List<ResourcePackagePositionData>();
	}
}
