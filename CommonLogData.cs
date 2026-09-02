using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200210E RID: 8462
[NullableContext(1)]
[Nullable(0)]
public class CommonLogData
{
	// Token: 0x17001370 RID: 4976
	// (get) Token: 0x06010335 RID: 66357 RVA: 0x00474BB6 File Offset: 0x00472DB6
	// (set) Token: 0x06010336 RID: 66358 RVA: 0x00474BBE File Offset: 0x00472DBE
	public virtual string event_id { get; set; } = "";

	// Token: 0x06010337 RID: 66359 RVA: 0x00474BC8 File Offset: 0x00472DC8
	public CommonLogData()
	{
		this.event_uuid = UKismetGuidLibrary.NewGuid().ToString();
	}

	// Token: 0x04007C68 RID: 31848
	public string event_uuid = "";

	// Token: 0x04007C69 RID: 31849
	public string client_version = "";

	// Token: 0x04007C6A RID: 31850
	public string project_id = "Aki";

	// Token: 0x04007C6B RID: 31851
	public string platform = "";
}
