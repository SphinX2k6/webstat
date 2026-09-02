using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB1 RID: 20145
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefensePhantomIconItemData : ITowerDefensePhantomIconItemData
	{
		// Token: 0x17008953 RID: 35155
		// (get) Token: 0x060340AF RID: 213167 RVA: 0x00D04784 File Offset: 0x00D02984
		// (set) Token: 0x060340B0 RID: 213168 RVA: 0x00D0478C File Offset: 0x00D0298C
		public int ConfigId { get; set; }

		// Token: 0x17008954 RID: 35156
		// (get) Token: 0x060340B1 RID: 213169 RVA: 0x00D04795 File Offset: 0x00D02995
		// (set) Token: 0x060340B2 RID: 213170 RVA: 0x00D0479D File Offset: 0x00D0299D
		public string HexColorPath { get; set; }

		// Token: 0x17008955 RID: 35157
		// (get) Token: 0x060340B3 RID: 213171 RVA: 0x00D047A6 File Offset: 0x00D029A6
		// (set) Token: 0x060340B4 RID: 213172 RVA: 0x00D047AE File Offset: 0x00D029AE
		public bool IsLocked { get; set; }

		// Token: 0x17008956 RID: 35158
		// (get) Token: 0x060340B5 RID: 213173 RVA: 0x00D047B7 File Offset: 0x00D029B7
		// (set) Token: 0x060340B6 RID: 213174 RVA: 0x00D047BF File Offset: 0x00D029BF
		public bool IsChosen { get; set; }

		// Token: 0x17008957 RID: 35159
		// (get) Token: 0x060340B7 RID: 213175 RVA: 0x00D047C8 File Offset: 0x00D029C8
		// (set) Token: 0x060340B8 RID: 213176 RVA: 0x00D047D0 File Offset: 0x00D029D0
		public bool IsOccupied { get; set; }
	}
}
