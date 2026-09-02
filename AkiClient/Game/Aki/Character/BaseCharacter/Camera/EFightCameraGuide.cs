using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042FC RID: 17148
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraGuide.EFightCameraGuide")]
	public enum EFightCameraGuide : byte
	{
		// Token: 0x04019945 RID: 104773
		None,
		// Token: 0x04019946 RID: 104774
		修正角度Min,
		// Token: 0x04019947 RID: 104775
		修正角度Max,
		// Token: 0x04019948 RID: 104776
		额外臂长系数_目标水平距离_,
		// Token: 0x04019949 RID: 104777
		额外臂长系数_目标高度差_,
		// Token: 0x0401994A RID: 104778
		额外臂长限制,
		// Token: 0x0401994B RID: 104779
		额外臂水平偏移系数_目标水平距离_,
		// Token: 0x0401994C RID: 104780
		额外臂水平偏移上限,
		// Token: 0x0401994D RID: 104781
		额外臂垂直偏移系数_目标高度差_,
		// Token: 0x0401994E RID: 104782
		额外臂垂直偏移上限,
		// Token: 0x0401994F RID: 104783
		InRangeMin,
		// Token: 0x04019950 RID: 104784
		InRangeMax,
		// Token: 0x04019951 RID: 104785
		OutRangeMin,
		// Token: 0x04019952 RID: 104786
		OutRangeMax,
		// Token: 0x04019953 RID: 104787
		CameraPitchMin,
		// Token: 0x04019954 RID: 104788
		CameraPitchMax,
		// Token: 0x04019955 RID: 104789
		CameraPitchOffset,
		// Token: 0x04019956 RID: 104790
		NearerRange,
		// Token: 0x04019957 RID: 104791
		EFightCameraGuide_MAX
	}
}
