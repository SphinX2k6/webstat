using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon
{
	// Token: 0x02004389 RID: 17289
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/EInteractionItemType.EInteractionItemType")]
	public enum EInteractionItemType : byte
	{
		// Token: 0x04019E44 RID: 106052
		主目标,
		// Token: 0x04019E45 RID: 106053
		椅子,
		// Token: 0x04019E46 RID: 106054
		信息板,
		// Token: 0x04019E47 RID: 106055
		桌子,
		// Token: 0x04019E48 RID: 106056
		垃圾桶,
		// Token: 0x04019E49 RID: 106057
		自动贩售机,
		// Token: 0x04019E4A RID: 106058
		坏掉的车,
		// Token: 0x04019E4B RID: 106059
		能交谈的人01,
		// Token: 0x04019E4C RID: 106060
		能交谈的人02,
		// Token: 0x04019E4D RID: 106061
		能交谈的人03,
		// Token: 0x04019E4E RID: 106062
		能交谈的人04,
		// Token: 0x04019E4F RID: 106063
		EInteractionItemType_MAX
	}
}
