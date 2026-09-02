using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB6 RID: 20150
	[NullableContext(1)]
	public interface ITowerDefensePhantomConfig
	{
		// Token: 0x1700896A RID: 35178
		// (get) Token: 0x060340E0 RID: 213216
		// (set) Token: 0x060340E1 RID: 213217
		int Id { get; set; }

		// Token: 0x1700896B RID: 35179
		// (get) Token: 0x060340E2 RID: 213218
		// (set) Token: 0x060340E3 RID: 213219
		int PhantomItemId { get; set; }

		// Token: 0x1700896C RID: 35180
		// (get) Token: 0x060340E4 RID: 213220
		// (set) Token: 0x060340E5 RID: 213221
		int ActivityId { get; set; }

		// Token: 0x1700896D RID: 35181
		// (get) Token: 0x060340E6 RID: 213222
		// (set) Token: 0x060340E7 RID: 213223
		string PhantomNameTextId { get; set; }

		// Token: 0x1700896E RID: 35182
		// (get) Token: 0x060340E8 RID: 213224
		// (set) Token: 0x060340E9 RID: 213225
		string PhantomTypeTextId { get; set; }

		// Token: 0x1700896F RID: 35183
		// (get) Token: 0x060340EA RID: 213226
		// (set) Token: 0x060340EB RID: 213227
		string TypeIconPath { get; set; }

		// Token: 0x17008970 RID: 35184
		// (get) Token: 0x060340EC RID: 213228
		// (set) Token: 0x060340ED RID: 213229
		string MarkResourceId { get; set; }

		// Token: 0x17008971 RID: 35185
		// (get) Token: 0x060340EE RID: 213230
		// (set) Token: 0x060340EF RID: 213231
		int MaxLevel { get; set; }

		// Token: 0x17008972 RID: 35186
		// (get) Token: 0x060340F0 RID: 213232
		// (set) Token: 0x060340F1 RID: 213233
		List<ITowerDefensePhantomConfigSkillData> SkillDataList { get; set; }
	}
}
