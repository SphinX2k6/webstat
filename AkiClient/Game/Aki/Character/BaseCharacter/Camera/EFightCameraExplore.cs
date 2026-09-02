using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F9 RID: 17145
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraExplore.EFightCameraExplore")]
	public enum EFightCameraExplore : byte
	{
		// Token: 0x04019909 RID: 104713
		None,
		// Token: 0x0401990A RID: 104714
		修正角度Min,
		// Token: 0x0401990B RID: 104715
		修正角度Max,
		// Token: 0x0401990C RID: 104716
		InRangeMin,
		// Token: 0x0401990D RID: 104717
		InRangeMax,
		// Token: 0x0401990E RID: 104718
		OutRangeMin,
		// Token: 0x0401990F RID: 104719
		OutRangeMax,
		// Token: 0x04019910 RID: 104720
		摄像机合法角度_移动方向_,
		// Token: 0x04019911 RID: 104721
		移动方向合法角度_看向点方向_,
		// Token: 0x04019912 RID: 104722
		EFightCameraExplore_MAX
	}
}
