using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004323 RID: 17187
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/EMovieCameraSequenceSettingFollowTargetType.EMovieCameraSequenceSettingFollowTargetType")]
	public enum EMovieCameraSequenceSettingFollowTargetType : byte
	{
		// Token: 0x04019B47 RID: 105287
		俯仰跟随,
		// Token: 0x04019B48 RID: 105288
		偏航跟随,
		// Token: 0x04019B49 RID: 105289
		俯仰_偏航跟随,
		// Token: 0x04019B4A RID: 105290
		EMovieCameraSequenceSettingFollowTargetType_MAX
	}
}
