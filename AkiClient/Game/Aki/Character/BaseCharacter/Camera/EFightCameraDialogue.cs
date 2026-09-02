using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F8 RID: 17144
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraDialogue.EFightCameraDialogue")]
	public enum EFightCameraDialogue : byte
	{
		// Token: 0x040198FA RID: 104698
		None,
		// Token: 0x040198FB RID: 104699
		淡入系数,
		// Token: 0x040198FC RID: 104700
		淡入时间,
		// Token: 0x040198FD RID: 104701
		淡出速率,
		// Token: 0x040198FE RID: 104702
		检查旋转角度,
		// Token: 0x040198FF RID: 104703
		检查最小俯仰角,
		// Token: 0x04019900 RID: 104704
		检查最大俯仰角,
		// Token: 0x04019901 RID: 104705
		调整旋转角度,
		// Token: 0x04019902 RID: 104706
		调整最小俯仰角,
		// Token: 0x04019903 RID: 104707
		调整最大俯仰角,
		// Token: 0x04019904 RID: 104708
		中心点偏移比例,
		// Token: 0x04019905 RID: 104709
		中心点最大偏移距离,
		// Token: 0x04019906 RID: 104710
		对话镜头臂长,
		// Token: 0x04019907 RID: 104711
		EFightCameraDialogue_MAX
	}
}
