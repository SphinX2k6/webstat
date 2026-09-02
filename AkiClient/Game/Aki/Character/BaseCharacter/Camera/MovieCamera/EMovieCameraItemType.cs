using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004320 RID: 17184
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/EMovieCameraItemType.EMovieCameraItemType")]
	public enum EMovieCameraItemType : byte
	{
		// Token: 0x04019B3A RID: 105274
		None,
		// Token: 0x04019B3B RID: 105275
		战斗子镜头,
		// Token: 0x04019B3C RID: 105276
		Sequence镜头,
		// Token: 0x04019B3D RID: 105277
		EMovieCameraItemType_MAX
	}
}
