using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F6 RID: 17142
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraClimb.EFightCameraClimb")]
	public enum EFightCameraClimb : byte
	{
		// Token: 0x04019869 RID: 104553
		None,
		// Token: 0x0401986A RID: 104554
		退出攀爬淡出时间,
		// Token: 0x0401986B RID: 104555
		无操作等待时间,
		// Token: 0x0401986C RID: 104556
		持续移动进入修正时间,
		// Token: 0x0401986D RID: 104557
		镜头角度插值速度,
		// Token: 0x0401986E RID: 104558
		角色移动基准速度,
		// Token: 0x0401986F RID: 104559
		进入攀爬增加臂长,
		// Token: 0x04019870 RID: 104560
		进入攀爬修正时间,
		// Token: 0x04019871 RID: 104561
		进入攀爬淡出系数,
		// Token: 0x04019872 RID: 104562
		攀爬基准臂长,
		// Token: 0x04019873 RID: 104563
		臂长插值速度,
		// Token: 0x04019874 RID: 104564
		镜头预期朝向与角色移动方向夹角,
		// Token: 0x04019875 RID: 104565
		镜头预期朝向俯视角压缩倍率,
		// Token: 0x04019876 RID: 104566
		镜头预期朝向仰视角压缩倍率,
		// Token: 0x04019877 RID: 104567
		镜头预期朝向和角色面朝方向夹角合法范围,
		// Token: 0x04019878 RID: 104568
		输入粘滞时间,
		// Token: 0x04019879 RID: 104569
		登顶镜头插值速度,
		// Token: 0x0401987A RID: 104570
		登顶镜头预期Pitch,
		// Token: 0x0401987B RID: 104571
		大跨度输入角度阈值,
		// Token: 0x0401987C RID: 104572
		大跨度输入角度延迟响应时间,
		// Token: 0x0401987D RID: 104573
		停止输入延迟响应时间,
		// Token: 0x0401987E RID: 104574
		EFightCameraClimb_MAX
	}
}
