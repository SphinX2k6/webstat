using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042FE RID: 17150
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraInput.EFightCameraInput")]
	public enum EFightCameraInput : byte
	{
		// Token: 0x0401995C RID: 104796
		None,
		// Token: 0x0401995D RID: 104797
		滚轮轴影响臂长系数,
		// Token: 0x0401995E RID: 104798
		镜头输入缓冲系数最小值,
		// Token: 0x0401995F RID: 104799
		镜头输入缓冲系数最大值,
		// Token: 0x04019960 RID: 104800
		镜头输入缓冲系数输入极值,
		// Token: 0x04019961 RID: 104801
		镜头输入速率Min,
		// Token: 0x04019962 RID: 104802
		镜头输入速率Max,
		// Token: 0x04019963 RID: 104803
		镜头Yaw灵敏度系数最小值,
		// Token: 0x04019964 RID: 104804
		镜头Yaw灵敏度系数最大值,
		// Token: 0x04019965 RID: 104805
		镜头Yaw灵敏度系数输入极值,
		// Token: 0x04019966 RID: 104806
		镜头Pitch灵敏度系数最小值,
		// Token: 0x04019967 RID: 104807
		镜头Pitch灵敏度系数最大值,
		// Token: 0x04019968 RID: 104808
		镜头Pitch灵敏度系数输入极值,
		// Token: 0x04019969 RID: 104809
		倍化手柄输入倍率,
		// Token: 0x0401996A RID: 104810
		辅助瞄准中心速度,
		// Token: 0x0401996B RID: 104811
		辅助瞄准边缘速度,
		// Token: 0x0401996C RID: 104812
		辅助瞄准最远距离,
		// Token: 0x0401996D RID: 104813
		辅助瞄准阻尼系数,
		// Token: 0x0401996E RID: 104814
		进入瞄准模式时长,
		// Token: 0x0401996F RID: 104815
		进入瞄准模式速度初始值,
		// Token: 0x04019970 RID: 104816
		进入瞄准模式速度结束值,
		// Token: 0x04019971 RID: 104817
		镜头输入缓冲系数最小值_手柄_,
		// Token: 0x04019972 RID: 104818
		镜头输入缓冲系数最大值_手柄_,
		// Token: 0x04019973 RID: 104819
		镜头输入缓冲系数输入极值_手柄_,
		// Token: 0x04019974 RID: 104820
		滚轮轴影响臂长系数_手柄,
		// Token: 0x04019975 RID: 104821
		特定镜头Yaw灵敏度,
		// Token: 0x04019976 RID: 104822
		特定镜头Pitch灵敏度,
		// Token: 0x04019977 RID: 104823
		特定瞄准镜头Yaw灵敏度,
		// Token: 0x04019978 RID: 104824
		特定瞄准镜头Pitch灵敏度,
		// Token: 0x04019979 RID: 104825
		EFightCameraInput_MAX
	}
}
