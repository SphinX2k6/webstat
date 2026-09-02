using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E18 RID: 28184
	[NullableContext(1)]
	[Nullable(0)]
	public class ActiveTaskInfo
	{
		// Token: 0x1700A365 RID: 41829
		// (get) Token: 0x060446A2 RID: 280226 RVA: 0x011C58DB File Offset: 0x011C3ADB
		// (set) Token: 0x060446A3 RID: 280227 RVA: 0x011C58E3 File Offset: 0x011C3AE3
		public LevelAiPlanInstance PlanInstance { get; set; }

		// Token: 0x1700A366 RID: 41830
		// (get) Token: 0x060446A4 RID: 280228 RVA: 0x011C58EC File Offset: 0x011C3AEC
		// (set) Token: 0x060446A5 RID: 280229 RVA: 0x011C58F4 File Offset: 0x011C3AF4
		public LevelAiPlanStepId PlanStepId { get; set; }
	}
}
