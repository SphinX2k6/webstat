using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F4 RID: 17140
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraAdjust.EFightCameraAdjust")]
	public enum EFightCameraAdjust : byte
	{
		// Token: 0x0401983E RID: 104510
		None,
		// Token: 0x0401983F RID: 104511
		摄像机最小Pitch_目标比角色矮_,
		// Token: 0x04019840 RID: 104512
		摄像机最大Pitch_目标比角色矮_,
		// Token: 0x04019841 RID: 104513
		摄像机最小Pitch_目标比角色高_,
		// Token: 0x04019842 RID: 104514
		摄像机最大Pitch_目标比角色高_,
		// Token: 0x04019843 RID: 104515
		近距离范围,
		// Token: 0x04019844 RID: 104516
		近距离修正最小角度,
		// Token: 0x04019845 RID: 104517
		近距离修正最大角度,
		// Token: 0x04019846 RID: 104518
		远距离修正最小角度,
		// Token: 0x04019847 RID: 104519
		远距离修正最大角度,
		// Token: 0x04019848 RID: 104520
		检测屏幕内MinX,
		// Token: 0x04019849 RID: 104521
		检测屏幕内MaxX,
		// Token: 0x0401984A RID: 104522
		检测屏幕内MinY,
		// Token: 0x0401984B RID: 104523
		检测屏幕内MaxY,
		// Token: 0x0401984C RID: 104524
		技能修正过渡时间,
		// Token: 0x0401984D RID: 104525
		EFightCameraAdjust_MAX
	}
}
