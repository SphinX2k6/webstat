using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200510B RID: 20747
	[NullableContext(1)]
	public interface IRoguelikeCharacterSelectOpenParam
	{
		// Token: 0x17008C4D RID: 35917
		// (get) Token: 0x06035759 RID: 218969
		// (set) Token: 0x0603575A RID: 218970
		int Index { get; set; }

		// Token: 0x17008C4E RID: 35918
		// (get) Token: 0x0603575B RID: 218971
		// (set) Token: 0x0603575C RID: 218972
		List<int> RoomIdList { get; set; }
	}
}
