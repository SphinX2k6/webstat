using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004324 RID: 17188
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/EMovieCameraSwitchType.EMovieCameraSwitchType")]
	public enum EMovieCameraSwitchType : byte
	{
		// Token: 0x04019B4C RID: 105292
		随机切换,
		// Token: 0x04019B4D RID: 105293
		顺序切换,
		// Token: 0x04019B4E RID: 105294
		初始随机,
		// Token: 0x04019B4F RID: 105295
		EMovieCameraSwitchType_MAX
	}
}
