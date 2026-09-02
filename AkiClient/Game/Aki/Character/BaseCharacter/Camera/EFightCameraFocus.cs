using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042FA RID: 17146
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraFocus.EFightCameraFocus")]
	public enum EFightCameraFocus : byte
	{
		// Token: 0x04019914 RID: 104724
		None,
		// Token: 0x04019915 RID: 104725
		臂旋转Yaw过渡最小速度,
		// Token: 0x04019916 RID: 104726
		臂旋转Yaw过渡最大速度,
		// Token: 0x04019917 RID: 104727
		臂旋转Yaw过渡与目标Yaw角度最大差值,
		// Token: 0x04019918 RID: 104728
		强锁定_启动左右对峙,
		// Token: 0x04019919 RID: 104729
		强锁定_左右对峙_交换角度,
		// Token: 0x0401991A RID: 104730
		强锁定_左右对峙_交换冷却,
		// Token: 0x0401991B RID: 104731
		软锁定_镜头偏角最小值,
		// Token: 0x0401991C RID: 104732
		软锁定_镜头偏角最大值,
		// Token: 0x0401991D RID: 104733
		软锁定_锁定时相机臂偏移Y,
		// Token: 0x0401991E RID: 104734
		强锁定_锁定时相机臂偏移Y,
		// Token: 0x0401991F RID: 104735
		强锁定_输入灵敏度Yaw,
		// Token: 0x04019920 RID: 104736
		强锁定_输入灵敏度Pitch,
		// Token: 0x04019921 RID: 104737
		强锁定_输入灵敏度Yaw_手柄,
		// Token: 0x04019922 RID: 104738
		强锁定_输入灵敏度Pitch_手柄,
		// Token: 0x04019923 RID: 104739
		强锁定_切换目标_输入衰减律,
		// Token: 0x04019924 RID: 104740
		强锁定_切换目标_角度系数,
		// Token: 0x04019925 RID: 104741
		强锁定_切换目标_距离系数,
		// Token: 0x04019926 RID: 104742
		强锁定_镜头偏角最小值,
		// Token: 0x04019927 RID: 104743
		强锁定_镜头偏角最大值,
		// Token: 0x04019928 RID: 104744
		强锁定_镜头俯仰角最小值,
		// Token: 0x04019929 RID: 104745
		强锁定_镜头俯仰角最大值,
		// Token: 0x0401992A RID: 104746
		软锁定_镜头Yaw输入解锁速度,
		// Token: 0x0401992B RID: 104747
		软锁定_镜头Pitch输入解锁速度,
		// Token: 0x0401992C RID: 104748
		软锁定_输入灵敏度Yaw,
		// Token: 0x0401992D RID: 104749
		软锁定_输入灵敏度Pitch,
		// Token: 0x0401992E RID: 104750
		软锁定_输入灵敏度Yaw_手柄,
		// Token: 0x0401992F RID: 104751
		软锁定_输入灵敏度Pitch_手柄,
		// Token: 0x04019930 RID: 104752
		臂旋转过渡速度最小系数_目标距离_,
		// Token: 0x04019931 RID: 104753
		臂旋转过渡速度最大系数_目标距离_,
		// Token: 0x04019932 RID: 104754
		臂旋转过渡速度最大距离_目标距离_,
		// Token: 0x04019933 RID: 104755
		臂旋转过渡速度最小距离_目标距离_,
		// Token: 0x04019934 RID: 104756
		强锁定_切换目标_启动速度,
		// Token: 0x04019935 RID: 104757
		强锁定_切换目标_启动速度_手柄,
		// Token: 0x04019936 RID: 104758
		臂旋转Pitch过渡最小速度,
		// Token: 0x04019937 RID: 104759
		臂旋转Pitch过渡最大速度,
		// Token: 0x04019938 RID: 104760
		臂旋转Pitch过渡与目标Pitch角度最大差值,
		// Token: 0x04019939 RID: 104761
		软锁定_镜头输入缓冲时间,
		// Token: 0x0401993A RID: 104762
		软锁定_镜头Yaw输入启动速度,
		// Token: 0x0401993B RID: 104763
		软锁定_镜头Pitch输入启动速度,
		// Token: 0x0401993C RID: 104764
		强锁定_左右对峙_启动距离阈值,
		// Token: 0x0401993D RID: 104765
		强锁定_左右对峙_锁定方向,
		// Token: 0x0401993E RID: 104766
		EFightCameraFocus_MAX
	}
}
