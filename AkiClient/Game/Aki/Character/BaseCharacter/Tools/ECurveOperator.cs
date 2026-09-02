using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools
{
	// Token: 0x0200428F RID: 17039
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/ECurveOperator.ECurveOperator")]
	public enum ECurveOperator : byte
	{
		// Token: 0x040195F0 RID: 103920
		ShowPosIn3Curves,
		// Token: 0x040195F1 RID: 103921
		Remove3Curves,
		// Token: 0x040195F2 RID: 103922
		RemoveAll,
		// Token: 0x040195F3 RID: 103923
		ECurveOperator_MAX
	}
}
