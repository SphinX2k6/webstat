using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F2 RID: 17138
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ECameraModifyConditionType.ECameraModifyConditionType")]
	public enum ECameraModifyConditionType : byte
	{
		// Token: 0x0401982C RID: 104492
		角色拥有Tag,
		// Token: 0x0401982D RID: 104493
		锁定目标拥有Tag,
		// Token: 0x0401982E RID: 104494
		臂长范围,
		// Token: 0x0401982F RID: 104495
		锁定目标处于镜头左边,
		// Token: 0x04019830 RID: 104496
		与锁定目标相对高度,
		// Token: 0x04019831 RID: 104497
		与锁定目标的相对Yaw,
		// Token: 0x04019832 RID: 104498
		当前pitch范围,
		// Token: 0x04019833 RID: 104499
		与锁定目标的距离,
		// Token: 0x04019834 RID: 104500
		范围阻挡检测,
		// Token: 0x04019835 RID: 104501
		相机位于锁定目标连线轴的左侧,
		// Token: 0x04019836 RID: 104502
		相机位于锁定目标连线轴的右侧,
		// Token: 0x04019837 RID: 104503
		与角色的相对Yaw,
		// Token: 0x04019838 RID: 104504
		ECameraModifyConditionType_MAX
	}
}
