using System;
using System.Runtime.CompilerServices;

// Token: 0x02001053 RID: 4179
[NullableContext(1)]
[Nullable(0)]
public class FurnitureCameraContext : IFurnitureCameraContext
{
	// Token: 0x17000899 RID: 2201
	// (get) Token: 0x06006CBF RID: 27839 RVA: 0x001C5DAE File Offset: 0x001C3FAE
	// (set) Token: 0x06006CC0 RID: 27840 RVA: 0x001C5DB6 File Offset: 0x001C3FB6
	public Vector Pos { get; set; }

	// Token: 0x1700089A RID: 2202
	// (get) Token: 0x06006CC1 RID: 27841 RVA: 0x001C5DBF File Offset: 0x001C3FBF
	// (set) Token: 0x06006CC2 RID: 27842 RVA: 0x001C5DC7 File Offset: 0x001C3FC7
	public Rotator Rot { get; set; }

	// Token: 0x1700089B RID: 2203
	// (get) Token: 0x06006CC3 RID: 27843 RVA: 0x001C5DD0 File Offset: 0x001C3FD0
	// (set) Token: 0x06006CC4 RID: 27844 RVA: 0x001C5DD8 File Offset: 0x001C3FD8
	public float Fov { get; set; }
}
