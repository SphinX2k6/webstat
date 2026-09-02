using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D75 RID: 15733
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/ECharacterControllerApplyType.ECharacterControllerApplyType")]
	public enum ECharacterControllerApplyType : byte
	{
		// Token: 0x04013E8F RID: 81551
		ModifyProperty,
		// Token: 0x04013E90 RID: 81552
		ReplaceMaterial,
		// Token: 0x04013E91 RID: 81553
		ReplaceBaseMaterial,
		// Token: 0x04013E92 RID: 81554
		ECharacterControllerApplyType_MAX
	}
}
