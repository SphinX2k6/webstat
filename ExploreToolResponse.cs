using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002238 RID: 8760
public class ExploreToolResponse : IExploreToolResponse
{
	// Token: 0x1700145F RID: 5215
	// (get) Token: 0x060108A6 RID: 67750 RVA: 0x004866C3 File Offset: 0x004848C3
	// (set) Token: 0x060108A7 RID: 67751 RVA: 0x004866CB File Offset: 0x004848CB
	public ERouletteExploreId PhantomSkillId { get; set; }

	// Token: 0x17001460 RID: 5216
	// (get) Token: 0x060108A8 RID: 67752 RVA: 0x004866D4 File Offset: 0x004848D4
	// (set) Token: 0x060108A9 RID: 67753 RVA: 0x004866DC File Offset: 0x004848DC
	[Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		1
	})]
	public OneOf<AddTemporaryTeleportResponse, AddTreasureBoxSlotResponse, CheckUseSoundBoxSkillResponse, UseSoundBoxSkillResponse> Content { [return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		1
	})] set; }

	// Token: 0x060108AA RID: 67754 RVA: 0x004866E8 File Offset: 0x004848E8
	public ErrorCode GetErrorCode()
	{
		return this.Content.Match<ErrorCode>((AddTemporaryTeleportResponse t1) => t1.Code, (AddTreasureBoxSlotResponse t2) => t2.Code, (CheckUseSoundBoxSkillResponse t3) => t3.Code, (UseSoundBoxSkillResponse t4) => t4.Code);
	}
}
