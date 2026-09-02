using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F2 RID: 16882
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EConcomitantDurationType.EConcomitantDurationType")]
	public enum EConcomitantDurationType : byte
	{
		// Token: 0x04019096 RID: 102550
		永久持续,
		// Token: 0x04019097 RID: 102551
		蒙太奇结束消失,
		// Token: 0x04019098 RID: 102552
		固定时间,
		// Token: 0x04019099 RID: 102553
		帧事件结束时消失,
		// Token: 0x0401909A RID: 102554
		EConcomitantDurationType_MAX
	}
}
