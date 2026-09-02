using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004304 RID: 17156
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraType.EFightCameraType")]
	public enum EFightCameraType : byte
	{
		// Token: 0x0401999F RID: 104863
		基础镜头,
		// Token: 0x040199A0 RID: 104864
		战斗镜头,
		// Token: 0x040199A1 RID: 104865
		子镜头,
		// Token: 0x040199A2 RID: 104866
		锁定目标镜头,
		// Token: 0x040199A3 RID: 104867
		伴随目标镜头,
		// Token: 0x040199A4 RID: 104868
		EFightCameraType_MAX
	}
}
