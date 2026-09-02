using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DCB RID: 19915
	[NullableContext(2)]
	public interface ITrapDefenseDevelopOpenParam
	{
		// Token: 0x1700883E RID: 34878
		// (get) Token: 0x060338DB RID: 211163
		// (set) Token: 0x060338DC RID: 211164
		bool IsInDungeon { get; set; }

		// Token: 0x1700883F RID: 34879
		// (get) Token: 0x060338DD RID: 211165
		// (set) Token: 0x060338DE RID: 211166
		int SelectedIndex { get; set; }

		// Token: 0x17008840 RID: 34880
		// (get) Token: 0x060338DF RID: 211167
		// (set) Token: 0x060338E0 RID: 211168
		TrapDefenseLevelData LevelData { get; set; }
	}
}
