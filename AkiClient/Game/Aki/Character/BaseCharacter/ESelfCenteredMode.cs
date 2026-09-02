using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004219 RID: 16921
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESelfCenteredMode.ESelfCenteredMode")]
	public enum ESelfCenteredMode : byte
	{
		// Token: 0x04019199 RID: 102809
		None,
		// Token: 0x0401919A RID: 102810
		Blueprint,
		// Token: 0x0401919B RID: 102811
		Gameplay,
		// Token: 0x0401919C RID: 102812
		LevelEvent,
		// Token: 0x0401919D RID: 102813
		GM,
		// Token: 0x0401919E RID: 102814
		Skill,
		// Token: 0x0401919F RID: 102815
		ESelfCenteredMode_MAX
	}
}
