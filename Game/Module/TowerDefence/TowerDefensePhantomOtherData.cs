using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB3 RID: 20147
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefensePhantomOtherData : ITowerDefensePhantomOtherData
	{
		// Token: 0x1700895C RID: 35164
		// (get) Token: 0x060340C2 RID: 213186 RVA: 0x00D047E1 File Offset: 0x00D029E1
		// (set) Token: 0x060340C3 RID: 213187 RVA: 0x00D047E9 File Offset: 0x00D029E9
		public string NameTextId { get; set; }

		// Token: 0x1700895D RID: 35165
		// (get) Token: 0x060340C4 RID: 213188 RVA: 0x00D047F2 File Offset: 0x00D029F2
		// (set) Token: 0x060340C5 RID: 213189 RVA: 0x00D047FA File Offset: 0x00D029FA
		public string TypeTextId { get; set; }

		// Token: 0x1700895E RID: 35166
		// (get) Token: 0x060340C6 RID: 213190 RVA: 0x00D04803 File Offset: 0x00D02A03
		// (set) Token: 0x060340C7 RID: 213191 RVA: 0x00D0480B File Offset: 0x00D02A0B
		public string TypeIconPath { get; set; }

		// Token: 0x1700895F RID: 35167
		// (get) Token: 0x060340C8 RID: 213192 RVA: 0x00D04814 File Offset: 0x00D02A14
		// (set) Token: 0x060340C9 RID: 213193 RVA: 0x00D0481C File Offset: 0x00D02A1C
		public bool IsLocked { get; set; }
	}
}
