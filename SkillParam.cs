using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003114 RID: 12564
[NullableContext(2)]
[Nullable(0)]
public class SkillParam : ISkillParam
{
	// Token: 0x1700233A RID: 9018
	// (get) Token: 0x06019FA5 RID: 106405 RVA: 0x0079A3B1 File Offset: 0x007985B1
	// (set) Token: 0x06019FA6 RID: 106406 RVA: 0x0079A3B9 File Offset: 0x007985B9
	public Entity Target { get; set; }

	// Token: 0x1700233B RID: 9019
	// (get) Token: 0x06019FA7 RID: 106407 RVA: 0x0079A3C2 File Offset: 0x007985C2
	// (set) Token: 0x06019FA8 RID: 106408 RVA: 0x0079A3CA File Offset: 0x007985CA
	public AActor TargetActor { get; set; }

	// Token: 0x1700233C RID: 9020
	// (get) Token: 0x06019FA9 RID: 106409 RVA: 0x0079A3D3 File Offset: 0x007985D3
	// (set) Token: 0x06019FAA RID: 106410 RVA: 0x0079A3DB File Offset: 0x007985DB
	public string SocketName { get; set; }

	// Token: 0x1700233D RID: 9021
	// (get) Token: 0x06019FAB RID: 106411 RVA: 0x0079A3E4 File Offset: 0x007985E4
	// (set) Token: 0x06019FAC RID: 106412 RVA: 0x0079A3EC File Offset: 0x007985EC
	public long? ContextId { get; set; }

	// Token: 0x1700233E RID: 9022
	// (get) Token: 0x06019FAD RID: 106413 RVA: 0x0079A3F5 File Offset: 0x007985F5
	// (set) Token: 0x06019FAE RID: 106414 RVA: 0x0079A3FD File Offset: 0x007985FD
	public string Reason { get; set; }

	// Token: 0x1700233F RID: 9023
	// (get) Token: 0x06019FAF RID: 106415 RVA: 0x0079A406 File Offset: 0x00798606
	// (set) Token: 0x06019FB0 RID: 106416 RVA: 0x0079A40E File Offset: 0x0079860E
	public int? MontageIndex { get; set; }

	// Token: 0x17002340 RID: 9024
	// (get) Token: 0x06019FB1 RID: 106417 RVA: 0x0079A417 File Offset: 0x00798617
	// (set) Token: 0x06019FB2 RID: 106418 RVA: 0x0079A41F File Offset: 0x0079861F
	public bool? CheckMultiSkill { get; set; }

	// Token: 0x17002341 RID: 9025
	// (get) Token: 0x06019FB3 RID: 106419 RVA: 0x0079A428 File Offset: 0x00798628
	// (set) Token: 0x06019FB4 RID: 106420 RVA: 0x0079A430 File Offset: 0x00798630
	public int? NextSkillId { get; set; }

	// Token: 0x17002342 RID: 9026
	// (get) Token: 0x06019FB5 RID: 106421 RVA: 0x0079A439 File Offset: 0x00798639
	// (set) Token: 0x06019FB6 RID: 106422 RVA: 0x0079A441 File Offset: 0x00798641
	public bool? IsAsync { get; set; }

	// Token: 0x17002343 RID: 9027
	// (get) Token: 0x06019FB7 RID: 106423 RVA: 0x0079A44A File Offset: 0x0079864A
	// (set) Token: 0x06019FB8 RID: 106424 RVA: 0x0079A452 File Offset: 0x00798652
	public FVectorDouble? ExtraTargetLocation { get; set; }
}
