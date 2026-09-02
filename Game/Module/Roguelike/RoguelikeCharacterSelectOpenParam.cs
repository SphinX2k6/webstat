using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200510C RID: 20748
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeCharacterSelectOpenParam : IRoguelikeCharacterSelectOpenParam
	{
		// Token: 0x17008C4F RID: 35919
		// (get) Token: 0x0603575D RID: 218973 RVA: 0x00D6B306 File Offset: 0x00D69506
		// (set) Token: 0x0603575E RID: 218974 RVA: 0x00D6B30E File Offset: 0x00D6950E
		public int Index { get; set; }

		// Token: 0x17008C50 RID: 35920
		// (get) Token: 0x0603575F RID: 218975 RVA: 0x00D6B317 File Offset: 0x00D69517
		// (set) Token: 0x06035760 RID: 218976 RVA: 0x00D6B31F File Offset: 0x00D6951F
		public List<int> RoomIdList { get; set; }
	}
}
