using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004322 RID: 17186
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/EMovieCameraSequenceSettingBindTargetType.EMovieCameraSequenceSettingBindTargetType")]
	public enum EMovieCameraSequenceSettingBindTargetType : byte
	{
		// Token: 0x04019B42 RID: 105282
		绑定到目标身上,
		// Token: 0x04019B43 RID: 105283
		根据目标位置放置到世界,
		// Token: 0x04019B44 RID: 105284
		放置到世界,
		// Token: 0x04019B45 RID: 105285
		EMovieCameraSequenceSettingBindTargetType_MAX
	}
}
