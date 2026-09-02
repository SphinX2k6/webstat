using System;
using System.Runtime.CompilerServices;

// Token: 0x020022AE RID: 8878
[NullableContext(1)]
[Nullable(0)]
public class MotorTechTreeNode
{
	// Token: 0x06010C63 RID: 68707 RVA: 0x00497F31 File Offset: 0x00496131
	public MotorTechTreeNode(int nodeId, int treeType, int[] preNodeIds)
	{
		this.NodeId = nodeId;
		this.TreeType = treeType;
		this.PreNodeIds = preNodeIds;
	}

	// Token: 0x170014B7 RID: 5303
	// (get) Token: 0x06010C64 RID: 68708 RVA: 0x00497F55 File Offset: 0x00496155
	// (set) Token: 0x06010C65 RID: 68709 RVA: 0x00497F5D File Offset: 0x0049615D
	public int NodeId { get; set; }

	// Token: 0x170014B8 RID: 5304
	// (get) Token: 0x06010C66 RID: 68710 RVA: 0x00497F66 File Offset: 0x00496166
	// (set) Token: 0x06010C67 RID: 68711 RVA: 0x00497F6E File Offset: 0x0049616E
	public int TreeType { get; set; }

	// Token: 0x170014B9 RID: 5305
	// (get) Token: 0x06010C68 RID: 68712 RVA: 0x00497F77 File Offset: 0x00496177
	// (set) Token: 0x06010C69 RID: 68713 RVA: 0x00497F7F File Offset: 0x0049617F
	public int[] PreNodeIds { get; set; }

	// Token: 0x170014BA RID: 5306
	// (get) Token: 0x06010C6A RID: 68714 RVA: 0x00497F88 File Offset: 0x00496188
	// (set) Token: 0x06010C6B RID: 68715 RVA: 0x00497F90 File Offset: 0x00496190
	public int NodeLevel { get; set; }

	// Token: 0x170014BB RID: 5307
	// (get) Token: 0x06010C6C RID: 68716 RVA: 0x00497F99 File Offset: 0x00496199
	// (set) Token: 0x06010C6D RID: 68717 RVA: 0x00497FA1 File Offset: 0x004961A1
	public int CurrentValue { get; set; }

	// Token: 0x170014BC RID: 5308
	// (get) Token: 0x06010C6E RID: 68718 RVA: 0x00497FAA File Offset: 0x004961AA
	// (set) Token: 0x06010C6F RID: 68719 RVA: 0x00497FB2 File Offset: 0x004961B2
	public int TargetValue { get; set; }

	// Token: 0x170014BD RID: 5309
	// (get) Token: 0x06010C70 RID: 68720 RVA: 0x00497FBB File Offset: 0x004961BB
	// (set) Token: 0x06010C71 RID: 68721 RVA: 0x00497FC3 File Offset: 0x004961C3
	public EMotorTechTreeNodeStatus Status { get; set; } = EMotorTechTreeNodeStatus.Lock;
}
