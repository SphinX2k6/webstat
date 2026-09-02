using System;
using System.Runtime.CompilerServices;

// Token: 0x020022B5 RID: 8885
[NullableContext(2)]
[Nullable(0)]
public class MotorTechLevelPoint : IMotorTechLevelPoint
{
	// Token: 0x170014D0 RID: 5328
	// (get) Token: 0x06010C9A RID: 68762 RVA: 0x004980FC File Offset: 0x004962FC
	// (set) Token: 0x06010C9B RID: 68763 RVA: 0x00498104 File Offset: 0x00496304
	public string Title { get; set; }

	// Token: 0x170014D1 RID: 5329
	// (get) Token: 0x06010C9C RID: 68764 RVA: 0x0049810D File Offset: 0x0049630D
	// (set) Token: 0x06010C9D RID: 68765 RVA: 0x00498115 File Offset: 0x00496315
	public string Desc { get; set; }

	// Token: 0x170014D2 RID: 5330
	// (get) Token: 0x06010C9E RID: 68766 RVA: 0x0049811E File Offset: 0x0049631E
	// (set) Token: 0x06010C9F RID: 68767 RVA: 0x00498126 File Offset: 0x00496326
	public int TargetLevel { get; set; }

	// Token: 0x170014D3 RID: 5331
	// (get) Token: 0x06010CA0 RID: 68768 RVA: 0x0049812F File Offset: 0x0049632F
	// (set) Token: 0x06010CA1 RID: 68769 RVA: 0x00498137 File Offset: 0x00496337
	public int CurLevel { get; set; }
}
