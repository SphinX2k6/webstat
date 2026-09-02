using System;
using System.Runtime.CompilerServices;

// Token: 0x0200215E RID: 8542
[NullableContext(1)]
[Nullable(0)]
public class LinkageSwitchModuleEvent : PlayerCommonLogData
{
	// Token: 0x170013B6 RID: 5046
	// (get) Token: 0x06010417 RID: 66583 RVA: 0x00475E35 File Offset: 0x00474035
	// (set) Token: 0x06010418 RID: 66584 RVA: 0x00475E3D File Offset: 0x0047403D
	public override string event_id { get; set; } = "1058";

	// Token: 0x04007E9F RID: 32415
	public int i_activity_id;

	// Token: 0x04007EA0 RID: 32416
	public int i_activity_type;

	// Token: 0x04007EA1 RID: 32417
	public int i_id;

	// Token: 0x04007EA2 RID: 32418
	public int i_if_finish;
}
