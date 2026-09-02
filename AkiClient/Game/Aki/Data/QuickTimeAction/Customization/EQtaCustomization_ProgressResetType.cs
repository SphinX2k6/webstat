using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E28 RID: 15912
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/EQtaCustomization_ProgressResetType.EQtaCustomization_ProgressResetType")]
	public enum EQtaCustomization_ProgressResetType : byte
	{
		// Token: 0x0401480F RID: 83983
		停止,
		// Token: 0x04014810 RID: 83984
		重置,
		// Token: 0x04014811 RID: 83985
		倒转,
		// Token: 0x04014812 RID: 83986
		结束,
		// Token: 0x04014813 RID: 83987
		EQtaCustomization_MAX
	}
}
