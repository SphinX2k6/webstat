using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064B3 RID: 25779
	[NullableContext(2)]
	[Nullable(0)]
	public class AreaLayoutItemData
	{
		// Token: 0x060409B8 RID: 264632 RVA: 0x0108F9E2 File Offset: 0x0108DBE2
		public AreaLayoutItemData(bool isTitle, RoadBookAreaData areaData = null, ActivityTaskData taskData = null)
		{
			this.IsTitle = isTitle;
			this.AreaData = areaData;
			this.TaskData = taskData;
		}

		// Token: 0x040242E4 RID: 148196
		public bool IsTitle;

		// Token: 0x040242E5 RID: 148197
		public RoadBookAreaData AreaData;

		// Token: 0x040242E6 RID: 148198
		public ActivityTaskData TaskData;

		// Token: 0x040242E7 RID: 148199
		public float? ExtraHeight;
	}
}
