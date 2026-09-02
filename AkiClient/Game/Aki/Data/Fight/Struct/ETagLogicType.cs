using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003EC6 RID: 16070
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/ETagLogicType.ETagLogicType")]
	public enum ETagLogicType : byte
	{
		// Token: 0x04014F59 RID: 85849
		All,
		// Token: 0x04014F5A RID: 85850
		Any,
		// Token: 0x04014F5B RID: 85851
		ETagLogicType_MAX
	}
}
