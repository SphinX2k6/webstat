using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042FF RID: 17151
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraModify.EFightCameraModify")]
	public enum EFightCameraModify : byte
	{
		// Token: 0x0401997B RID: 104827
		None,
		// Token: 0x0401997C RID: 104828
		臂长还原过渡速度,
		// Token: 0x0401997D RID: 104829
		臂偏移还原过渡速度,
		// Token: 0x0401997E RID: 104830
		旋转还原过渡速度,
		// Token: 0x0401997F RID: 104831
		Fov还原过渡速度,
		// Token: 0x04019980 RID: 104832
		臂偏移原点还原过渡速度,
		// Token: 0x04019981 RID: 104833
		EFightCameraModify_MAX
	}
}
