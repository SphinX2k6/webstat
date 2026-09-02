using System;
using System.Runtime.CompilerServices;

// Token: 0x0200116E RID: 4462
[NullableContext(2)]
[Nullable(0)]
public class ActivityFunctionAreaParams : IActivityFunctionAreaParams
{
	// Token: 0x170009D9 RID: 2521
	// (get) Token: 0x0600757C RID: 30076 RVA: 0x001ECF5E File Offset: 0x001EB15E
	// (set) Token: 0x0600757D RID: 30077 RVA: 0x001ECF66 File Offset: 0x001EB166
	public string UnlockBtnTextId { get; set; }

	// Token: 0x170009DA RID: 2522
	// (get) Token: 0x0600757E RID: 30078 RVA: 0x001ECF6F File Offset: 0x001EB16F
	// (set) Token: 0x0600757F RID: 30079 RVA: 0x001ECF77 File Offset: 0x001EB177
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] UnlockBtnTextArgs { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170009DB RID: 2523
	// (get) Token: 0x06007580 RID: 30080 RVA: 0x001ECF80 File Offset: 0x001EB180
	// (set) Token: 0x06007581 RID: 30081 RVA: 0x001ECF88 File Offset: 0x001EB188
	public Action UnlockBtnFunction { get; set; }

	// Token: 0x170009DC RID: 2524
	// (get) Token: 0x06007582 RID: 30082 RVA: 0x001ECF91 File Offset: 0x001EB191
	// (set) Token: 0x06007583 RID: 30083 RVA: 0x001ECF99 File Offset: 0x001EB199
	public Func<bool> BeforePreOpenCheck { get; set; }
}
