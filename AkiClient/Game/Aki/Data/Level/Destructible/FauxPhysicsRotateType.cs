using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Level.Destructible
{
	// Token: 0x02003E7F RID: 15999
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Destructible/FauxPhysicsRotateType.FauxPhysicsRotateType")]
	public enum FauxPhysicsRotateType : byte
	{
		// Token: 0x04014C69 RID: 85097
		AxisRotate,
		// Token: 0x04014C6A RID: 85098
		FreeRotate,
		// Token: 0x04014C6B RID: 85099
		ConeRotate,
		// Token: 0x04014C6C RID: 85100
		FauxPhysicsRotateType_MAX
	}
}
