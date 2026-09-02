using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB7 RID: 20151
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefensePhantomConfig : ITowerDefensePhantomConfig
	{
		// Token: 0x17008973 RID: 35187
		// (get) Token: 0x060340F2 RID: 213234 RVA: 0x00D0488A File Offset: 0x00D02A8A
		// (set) Token: 0x060340F3 RID: 213235 RVA: 0x00D04892 File Offset: 0x00D02A92
		public int Id { get; set; }

		// Token: 0x17008974 RID: 35188
		// (get) Token: 0x060340F4 RID: 213236 RVA: 0x00D0489B File Offset: 0x00D02A9B
		// (set) Token: 0x060340F5 RID: 213237 RVA: 0x00D048A3 File Offset: 0x00D02AA3
		public int PhantomItemId { get; set; }

		// Token: 0x17008975 RID: 35189
		// (get) Token: 0x060340F6 RID: 213238 RVA: 0x00D048AC File Offset: 0x00D02AAC
		// (set) Token: 0x060340F7 RID: 213239 RVA: 0x00D048B4 File Offset: 0x00D02AB4
		public int ActivityId { get; set; }

		// Token: 0x17008976 RID: 35190
		// (get) Token: 0x060340F8 RID: 213240 RVA: 0x00D048BD File Offset: 0x00D02ABD
		// (set) Token: 0x060340F9 RID: 213241 RVA: 0x00D048C5 File Offset: 0x00D02AC5
		public string PhantomNameTextId { get; set; }

		// Token: 0x17008977 RID: 35191
		// (get) Token: 0x060340FA RID: 213242 RVA: 0x00D048CE File Offset: 0x00D02ACE
		// (set) Token: 0x060340FB RID: 213243 RVA: 0x00D048D6 File Offset: 0x00D02AD6
		public string PhantomTypeTextId { get; set; }

		// Token: 0x17008978 RID: 35192
		// (get) Token: 0x060340FC RID: 213244 RVA: 0x00D048DF File Offset: 0x00D02ADF
		// (set) Token: 0x060340FD RID: 213245 RVA: 0x00D048E7 File Offset: 0x00D02AE7
		public string TypeIconPath { get; set; }

		// Token: 0x17008979 RID: 35193
		// (get) Token: 0x060340FE RID: 213246 RVA: 0x00D048F0 File Offset: 0x00D02AF0
		// (set) Token: 0x060340FF RID: 213247 RVA: 0x00D048F8 File Offset: 0x00D02AF8
		public string MarkResourceId { get; set; }

		// Token: 0x1700897A RID: 35194
		// (get) Token: 0x06034100 RID: 213248 RVA: 0x00D04901 File Offset: 0x00D02B01
		// (set) Token: 0x06034101 RID: 213249 RVA: 0x00D04909 File Offset: 0x00D02B09
		public int MaxLevel { get; set; }

		// Token: 0x1700897B RID: 35195
		// (get) Token: 0x06034102 RID: 213250 RVA: 0x00D04912 File Offset: 0x00D02B12
		// (set) Token: 0x06034103 RID: 213251 RVA: 0x00D0491A File Offset: 0x00D02B1A
		public List<ITowerDefensePhantomConfigSkillData> SkillDataList { get; set; }
	}
}
