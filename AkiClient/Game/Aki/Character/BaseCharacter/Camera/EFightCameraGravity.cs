using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042FB RID: 17147
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraGravity.EFightCameraGravity")]
	public enum EFightCameraGravity : byte
	{
		// Token: 0x04019940 RID: 104768
		None,
		// Token: 0x04019941 RID: 104769
		开启过渡到指定重力方向,
		// Token: 0x04019942 RID: 104770
		过渡角速度,
		// Token: 0x04019943 RID: 104771
		EFightCameraGravity_MAX
	}
}
