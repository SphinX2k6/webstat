using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DE8 RID: 19944
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseLevelTargetItemData : ITrapDefenseLevelTargetItemData
	{
		// Token: 0x17008892 RID: 34962
		// (get) Token: 0x0603397C RID: 211324 RVA: 0x00CE4A65 File Offset: 0x00CE2C65
		// (set) Token: 0x0603397D RID: 211325 RVA: 0x00CE4A6D File Offset: 0x00CE2C6D
		public ITrapDefenseLevelTargetInfo Info { get; set; }

		// Token: 0x17008893 RID: 34963
		// (get) Token: 0x0603397E RID: 211326 RVA: 0x00CE4A76 File Offset: 0x00CE2C76
		// (set) Token: 0x0603397F RID: 211327 RVA: 0x00CE4A7E File Offset: 0x00CE2C7E
		public int TargetValue { get; set; }

		// Token: 0x17008894 RID: 34964
		// (get) Token: 0x06033980 RID: 211328 RVA: 0x00CE4A87 File Offset: 0x00CE2C87
		// (set) Token: 0x06033981 RID: 211329 RVA: 0x00CE4A8F File Offset: 0x00CE2C8F
		public int TargetStar { get; set; }

		// Token: 0x17008895 RID: 34965
		// (get) Token: 0x06033982 RID: 211330 RVA: 0x00CE4A98 File Offset: 0x00CE2C98
		// (set) Token: 0x06033983 RID: 211331 RVA: 0x00CE4AA0 File Offset: 0x00CE2CA0
		public bool IsFinish { get; set; }
	}
}
