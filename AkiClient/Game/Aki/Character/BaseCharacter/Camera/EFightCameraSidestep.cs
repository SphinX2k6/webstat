using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004300 RID: 17152
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraSidestep.EFightCameraSidestep")]
	public enum EFightCameraSidestep : byte
	{
		// Token: 0x04019983 RID: 104835
		None,
		// Token: 0x04019984 RID: 104836
		旋转角速度插值速率,
		// Token: 0x04019985 RID: 104837
		俯仰角插值速率,
		// Token: 0x04019986 RID: 104838
		相机俯角偏移,
		// Token: 0x04019987 RID: 104839
		最大俯角,
		// Token: 0x04019988 RID: 104840
		最大仰角,
		// Token: 0x04019989 RID: 104841
		俯仰修正时间阈值,
		// Token: 0x0401998A RID: 104842
		俯仰角加速度,
		// Token: 0x0401998B RID: 104843
		自动偏转最大角速度,
		// Token: 0x0401998C RID: 104844
		移动输入恢复臂长目标值下限,
		// Token: 0x0401998D RID: 104845
		移动输入恢复臂长目标值上限,
		// Token: 0x0401998E RID: 104846
		移动输入恢复臂长最小速度,
		// Token: 0x0401998F RID: 104847
		移动输入恢复臂长最大速度,
		// Token: 0x04019990 RID: 104848
		移动输入恢复臂长与目标臂长最大差值,
		// Token: 0x04019991 RID: 104849
		EFightCameraSidestep_MAX
	}
}
