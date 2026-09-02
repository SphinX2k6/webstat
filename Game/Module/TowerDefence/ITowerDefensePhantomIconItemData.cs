using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB0 RID: 20144
	[NullableContext(1)]
	public interface ITowerDefensePhantomIconItemData
	{
		// Token: 0x1700894E RID: 35150
		// (get) Token: 0x060340A5 RID: 213157
		// (set) Token: 0x060340A6 RID: 213158
		int ConfigId { get; set; }

		// Token: 0x1700894F RID: 35151
		// (get) Token: 0x060340A7 RID: 213159
		// (set) Token: 0x060340A8 RID: 213160
		string HexColorPath { get; set; }

		// Token: 0x17008950 RID: 35152
		// (get) Token: 0x060340A9 RID: 213161
		// (set) Token: 0x060340AA RID: 213162
		bool IsLocked { get; set; }

		// Token: 0x17008951 RID: 35153
		// (get) Token: 0x060340AB RID: 213163
		// (set) Token: 0x060340AC RID: 213164
		bool IsChosen { get; set; }

		// Token: 0x17008952 RID: 35154
		// (get) Token: 0x060340AD RID: 213165
		// (set) Token: 0x060340AE RID: 213166
		bool IsOccupied { get; set; }
	}
}
