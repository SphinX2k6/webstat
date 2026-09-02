using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004216 RID: 16918
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EPositionDatumTarget.EPositionDatumTarget")]
	public enum EPositionDatumTarget : byte
	{
		// Token: 0x0401918A RID: 102794
		User,
		// Token: 0x0401918B RID: 102795
		Skill,
		// Token: 0x0401918C RID: 102796
		Blackboard,
		// Token: 0x0401918D RID: 102797
		EPositionDatumTarget_MAX
	}
}
