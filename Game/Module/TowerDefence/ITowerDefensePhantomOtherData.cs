using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB2 RID: 20146
	[NullableContext(1)]
	public interface ITowerDefensePhantomOtherData
	{
		// Token: 0x17008958 RID: 35160
		// (get) Token: 0x060340BA RID: 213178
		// (set) Token: 0x060340BB RID: 213179
		string NameTextId { get; set; }

		// Token: 0x17008959 RID: 35161
		// (get) Token: 0x060340BC RID: 213180
		// (set) Token: 0x060340BD RID: 213181
		string TypeTextId { get; set; }

		// Token: 0x1700895A RID: 35162
		// (get) Token: 0x060340BE RID: 213182
		// (set) Token: 0x060340BF RID: 213183
		string TypeIconPath { get; set; }

		// Token: 0x1700895B RID: 35163
		// (get) Token: 0x060340C0 RID: 213184
		// (set) Token: 0x060340C1 RID: 213185
		bool IsLocked { get; set; }
	}
}
