using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004303 RID: 17155
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraSplineMove.EFightCameraSplineMove")]
	public enum EFightCameraSplineMove : byte
	{
		// Token: 0x04019999 RID: 104857
		摄像机臂长,
		// Token: 0x0401999A RID: 104858
		摄像机偏移,
		// Token: 0x0401999B RID: 104859
		Fov,
		// Token: 0x0401999C RID: 104860
		观察角度,
		// Token: 0x0401999D RID: 104861
		EFightCameraSplineMove_MAX
	}
}
