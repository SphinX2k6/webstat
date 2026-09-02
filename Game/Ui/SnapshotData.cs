using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049B4 RID: 18868
	[NullableContext(1)]
	[Nullable(0)]
	public class SnapshotData
	{
		// Token: 0x0401C56F RID: 116079
		public int? InTimeFlowViewId;

		// Token: 0x0401C570 RID: 116080
		[Nullable(2)]
		public UiViewInfoForTimeDilation CacheTimeDilationData;

		// Token: 0x0401C571 RID: 116081
		[Nullable(2)]
		public UiViewInfoForTimeDilation TimeDilationData;

		// Token: 0x0401C572 RID: 116082
		public HashSet<string> CacheTimeDilationTagSet = new HashSet<string>();

		// Token: 0x0401C573 RID: 116083
		public HashSet<string> WaitSetTimeDilationTagSet = new HashSet<string>();

		// Token: 0x0401C574 RID: 116084
		public List<int> ViewIdList = new List<int>();

		// Token: 0x0401C575 RID: 116085
		public Dictionary<int, UiViewInfoForTimeDilation> TimeDilationMap = new Dictionary<int, UiViewInfoForTimeDilation>();
	}
}
