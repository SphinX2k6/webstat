using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.NPC.Animal
{
	// Token: 0x020040F4 RID: 16628
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/EAnimalEcologicalState.EAnimalEcologicalState")]
	public enum EAnimalEcologicalState : byte
	{
		// Token: 0x040188D0 RID: 100560
		None,
		// Token: 0x040188D1 RID: 100561
		空闲,
		// Token: 0x040188D2 RID: 100562
		警觉,
		// Token: 0x040188D3 RID: 100563
		受击,
		// Token: 0x040188D4 RID: 100564
		起飞,
		// Token: 0x040188D5 RID: 100565
		交互,
		// Token: 0x040188D6 RID: 100566
		系统UI,
		// Token: 0x040188D7 RID: 100567
		EAnimalEcologicalState_MAX
	}
}
