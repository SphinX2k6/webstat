using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004308 RID: 17160
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFreeCameraLimit.EFreeCameraLimit")]
	public enum EFreeCameraLimit : byte
	{
		// Token: 0x040199B6 RID: 104886
		None,
		// Token: 0x040199B7 RID: 104887
		世界X轴偏移上界,
		// Token: 0x040199B8 RID: 104888
		世界X轴偏移下界,
		// Token: 0x040199B9 RID: 104889
		世界Y轴偏移上界,
		// Token: 0x040199BA RID: 104890
		世界Y轴偏移下界,
		// Token: 0x040199BB RID: 104891
		世界Z轴偏移上界,
		// Token: 0x040199BC RID: 104892
		世界Z轴偏移下界,
		// Token: 0x040199BD RID: 104893
		最小FOV,
		// Token: 0x040199BE RID: 104894
		最大FOV,
		// Token: 0x040199BF RID: 104895
		Yaw限制Min,
		// Token: 0x040199C0 RID: 104896
		Yaw限制Max,
		// Token: 0x040199C1 RID: 104897
		Pitch限制Min,
		// Token: 0x040199C2 RID: 104898
		Pitch限制Max,
		// Token: 0x040199C3 RID: 104899
		EFreeCameraLimit_MAX
	}
}
