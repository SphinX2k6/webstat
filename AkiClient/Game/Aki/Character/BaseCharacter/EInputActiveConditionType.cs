using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004209 RID: 16905
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EInputActiveConditionType.EInputActiveConditionType")]
	public enum EInputActiveConditionType : byte
	{
		// Token: 0x0401913C RID: 102716
		施法者标签检测,
		// Token: 0x0401913D RID: 102717
		施法者属性检测,
		// Token: 0x0401913E RID: 102718
		EInputActiveConditionType_MAX
	}
}
