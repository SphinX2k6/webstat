using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002237 RID: 8759
public interface IExploreToolResponse
{
	// Token: 0x1700145D RID: 5213
	// (get) Token: 0x060108A2 RID: 67746
	// (set) Token: 0x060108A3 RID: 67747
	ERouletteExploreId PhantomSkillId { get; set; }

	// Token: 0x1700145E RID: 5214
	// (get) Token: 0x060108A4 RID: 67748
	// (set) Token: 0x060108A5 RID: 67749
	[Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		1
	})]
	OneOf<AddTemporaryTeleportResponse, AddTreasureBoxSlotResponse, CheckUseSoundBoxSkillResponse, UseSoundBoxSkillResponse> Content { [return: Nullable(new byte[]
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
}
