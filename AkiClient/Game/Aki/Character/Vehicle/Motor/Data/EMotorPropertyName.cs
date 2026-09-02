using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data
{
	// Token: 0x02003FA9 RID: 16297
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/EMotorPropertyName.EMotorPropertyName")]
	public enum EMotorPropertyName : byte
	{
		// Token: 0x04015A3D RID: 88637
		冲刺相关配置_全部_,
		// Token: 0x04015A3E RID: 88638
		加减速配置_全部_,
		// Token: 0x04015A3F RID: 88639
		重力标量,
		// Token: 0x04015A40 RID: 88640
		平衡配置_全部_,
		// Token: 0x04015A41 RID: 88641
		速度相关,
		// Token: 0x04015A42 RID: 88642
		动力相关,
		// Token: 0x04015A43 RID: 88643
		转向性能相关,
		// Token: 0x04015A44 RID: 88644
		倒车性能相关,
		// Token: 0x04015A45 RID: 88645
		前后轮刹车摩擦力,
		// Token: 0x04015A46 RID: 88646
		翱翔配置_全部_,
		// Token: 0x04015A47 RID: 88647
		新版漂移配置_全部_,
		// Token: 0x04015A48 RID: 88648
		EMotorPropertyName_MAX
	}
}
