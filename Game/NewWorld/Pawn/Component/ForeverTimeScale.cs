using System;

namespace CSharpScript.Game.NewWorld.Pawn.Component
{
	// Token: 0x020048B5 RID: 18613
	public class ForeverTimeScale
	{
		// Token: 0x0603084C RID: 198732 RVA: 0x00BE9972 File Offset: 0x00BE7B72
		public ForeverTimeScale(int priority, float timeDilation, ETimeScaleSourceType sourceType, ETimeScaleSourceGroup sourceTypeGroup, int id)
		{
		}

		// Token: 0x170082BD RID: 33469
		// (get) Token: 0x0603084D RID: 198733 RVA: 0x00BE999F File Offset: 0x00BE7B9F
		public double EndTime
		{
			get
			{
				return -1.0;
			}
		}

		// Token: 0x0401BE2D RID: 114221
		public readonly int Priority = priority;

		// Token: 0x0401BE2E RID: 114222
		public readonly float TimeDilation = timeDilation;

		// Token: 0x0401BE2F RID: 114223
		public readonly ETimeScaleSourceType SourceType = sourceType;

		// Token: 0x0401BE30 RID: 114224
		public readonly ETimeScaleSourceGroup SourceTypeGroup = sourceTypeGroup;

		// Token: 0x0401BE31 RID: 114225
		public readonly int Id = id;

		// Token: 0x0401BE32 RID: 114226
		public bool MarkDelete;
	}
}
