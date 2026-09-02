using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D9 RID: 16857
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAnsRotateDetectionType.EAnsRotateDetectionType")]
	public enum EAnsRotateDetectionType : byte
	{
		// Token: 0x04018FDF RID: 102367
		持续旋转,
		// Token: 0x04018FE0 RID: 102368
		单次旋转,
		// Token: 0x04018FE1 RID: 102369
		动态单次旋转,
		// Token: 0x04018FE2 RID: 102370
		EAnsRotateDetectionType_MAX
	}
}
