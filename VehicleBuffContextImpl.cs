using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E3B RID: 11835
[NullableContext(1)]
[Nullable(0)]
public class VehicleBuffContextImpl : TsVehicleBlueprintFunctionLibrary.IVehicleBuffContext
{
	// Token: 0x17002074 RID: 8308
	// (get) Token: 0x06018441 RID: 99393 RVA: 0x006C7C28 File Offset: 0x006C5E28
	// (set) Token: 0x06018442 RID: 99394 RVA: 0x006C7C30 File Offset: 0x006C5E30
	public int EntityId { get; set; }

	// Token: 0x17002075 RID: 8309
	// (get) Token: 0x06018443 RID: 99395 RVA: 0x006C7C39 File Offset: 0x006C5E39
	// (set) Token: 0x06018444 RID: 99396 RVA: 0x006C7C41 File Offset: 0x006C5E41
	public long BuffId { get; set; }

	// Token: 0x17002076 RID: 8310
	// (get) Token: 0x06018445 RID: 99397 RVA: 0x006C7C4A File Offset: 0x006C5E4A
	// (set) Token: 0x06018446 RID: 99398 RVA: 0x006C7C52 File Offset: 0x006C5E52
	public string SkillId { get; set; } = "";
}
