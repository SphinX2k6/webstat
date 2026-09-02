using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004231 RID: 16945
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EVelocityCurveType.EVelocityCurveType")]
	public enum EVelocityCurveType : byte
	{
		// Token: 0x04019251 RID: 102993
		None,
		// Token: 0x04019252 RID: 102994
		Convex,
		// Token: 0x04019253 RID: 102995
		LinearityDown,
		// Token: 0x04019254 RID: 102996
		Concave,
		// Token: 0x04019255 RID: 102997
		EVelocityCurveType_MAX
	}
}
