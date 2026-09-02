using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F5 RID: 17141
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraAuto.EFightCameraAuto")]
	public enum EFightCameraAuto : byte
	{
		// Token: 0x0401984F RID: 104527
		None,
		// Token: 0x04019850 RID: 104528
		目标比角色更靠近镜头时额外臂长,
		// Token: 0x04019851 RID: 104529
		额外臂长最小增量_目标距离_,
		// Token: 0x04019852 RID: 104530
		额外臂长最大增量_目标距离_,
		// Token: 0x04019853 RID: 104531
		额外臂长最大距离_目标距离_,
		// Token: 0x04019854 RID: 104532
		额外臂长最小增量_目标高度_,
		// Token: 0x04019855 RID: 104533
		角色屏幕高度参考,
		// Token: 0x04019856 RID: 104534
		额外臂垂直偏移系数_角色屏幕高度与参考值差_,
		// Token: 0x04019857 RID: 104535
		额外臂长最大增量_目标高度_,
		// Token: 0x04019858 RID: 104536
		额外臂长最大距离_目标高度_,
		// Token: 0x04019859 RID: 104537
		额外臂水平偏移最小偏移_目标距离_,
		// Token: 0x0401985A RID: 104538
		臂长过渡速度,
		// Token: 0x0401985B RID: 104539
		臂偏移过渡速度,
		// Token: 0x0401985C RID: 104540
		检测屏幕内MinX_外_,
		// Token: 0x0401985D RID: 104541
		检测屏幕内MaxX_外_,
		// Token: 0x0401985E RID: 104542
		检测屏幕内MinY_外_,
		// Token: 0x0401985F RID: 104543
		检测屏幕内MaxY_外_,
		// Token: 0x04019860 RID: 104544
		额外臂水平偏移最大偏移_目标距离_,
		// Token: 0x04019861 RID: 104545
		额外臂水平偏移最大距离_目标距离_,
		// Token: 0x04019862 RID: 104546
		额外臂垂直偏移最小偏移_目标高度差_,
		// Token: 0x04019863 RID: 104547
		额外臂垂直偏移最大偏移_目标高度差_,
		// Token: 0x04019864 RID: 104548
		额外臂垂直偏移与目标最大高度差_目标高度差_,
		// Token: 0x04019865 RID: 104549
		额外臂垂直偏移速度,
		// Token: 0x04019866 RID: 104550
		额外臂垂直偏移与目标最小高度差_目标高度差_,
		// Token: 0x04019867 RID: 104551
		EFightCameraAuto_MAX
	}
}
