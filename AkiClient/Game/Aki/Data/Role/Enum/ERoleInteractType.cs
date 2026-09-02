using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Role.Enum
{
	// Token: 0x02003E12 RID: 15890
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Role/Enum/ERoleInteractType.ERoleInteractType")]
	public enum ERoleInteractType : byte
	{
		// Token: 0x04014774 RID: 83828
		SitDown,
		// Token: 0x04014775 RID: 83829
		Bounce,
		// Token: 0x04014776 RID: 83830
		Catapult,
		// Token: 0x04014777 RID: 83831
		Manipulate,
		// Token: 0x04014778 RID: 83832
		ERoleInteractType_MAX
	}
}
