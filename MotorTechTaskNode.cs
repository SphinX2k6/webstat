using System;
using System.Runtime.CompilerServices;

// Token: 0x020022B1 RID: 8881
[NullableContext(1)]
[Nullable(0)]
public class MotorTechTaskNode
{
	// Token: 0x170014C0 RID: 5312
	// (get) Token: 0x06010C77 RID: 68727 RVA: 0x00498002 File Offset: 0x00496202
	// (set) Token: 0x06010C78 RID: 68728 RVA: 0x0049800A File Offset: 0x0049620A
	public int TaskId { get; set; }

	// Token: 0x170014C1 RID: 5313
	// (get) Token: 0x06010C79 RID: 68729 RVA: 0x00498013 File Offset: 0x00496213
	// (set) Token: 0x06010C7A RID: 68730 RVA: 0x0049801B File Offset: 0x0049621B
	public int TreeType { get; set; }

	// Token: 0x170014C2 RID: 5314
	// (get) Token: 0x06010C7B RID: 68731 RVA: 0x00498024 File Offset: 0x00496224
	// (set) Token: 0x06010C7C RID: 68732 RVA: 0x0049802C File Offset: 0x0049622C
	public EMotorTechTaskType Type { get; set; }

	// Token: 0x170014C3 RID: 5315
	// (get) Token: 0x06010C7D RID: 68733 RVA: 0x00498035 File Offset: 0x00496235
	// (set) Token: 0x06010C7E RID: 68734 RVA: 0x0049803D File Offset: 0x0049623D
	public long StartTime { get; set; }

	// Token: 0x170014C4 RID: 5316
	// (get) Token: 0x06010C7F RID: 68735 RVA: 0x00498046 File Offset: 0x00496246
	// (set) Token: 0x06010C80 RID: 68736 RVA: 0x0049804E File Offset: 0x0049624E
	public long EndTime { get; set; }

	// Token: 0x170014C5 RID: 5317
	// (get) Token: 0x06010C81 RID: 68737 RVA: 0x00498057 File Offset: 0x00496257
	// (set) Token: 0x06010C82 RID: 68738 RVA: 0x0049805F File Offset: 0x0049625F
	public MotorTechTaskProcess ProcessInfo { get; set; } = new MotorTechTaskProcess();

	// Token: 0x170014C6 RID: 5318
	// (get) Token: 0x06010C83 RID: 68739 RVA: 0x00498068 File Offset: 0x00496268
	// (set) Token: 0x06010C84 RID: 68740 RVA: 0x00498070 File Offset: 0x00496270
	public MotorTechTaskReward RewardInfo { get; set; } = new MotorTechTaskReward();
}
