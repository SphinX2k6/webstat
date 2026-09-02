using System;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005062 RID: 20578
	public class StarItemData : IStarItemData
	{
		// Token: 0x17008B68 RID: 35688
		// (get) Token: 0x06034FFB RID: 217083 RVA: 0x00D4AA40 File Offset: 0x00D48C40
		// (set) Token: 0x06034FFC RID: 217084 RVA: 0x00D4AA48 File Offset: 0x00D48C48
		public bool StarOnActive { get; set; }

		// Token: 0x17008B69 RID: 35689
		// (get) Token: 0x06034FFD RID: 217085 RVA: 0x00D4AA51 File Offset: 0x00D48C51
		// (set) Token: 0x06034FFE RID: 217086 RVA: 0x00D4AA59 File Offset: 0x00D48C59
		public bool StarOffActive { get; set; }

		// Token: 0x17008B6A RID: 35690
		// (get) Token: 0x06034FFF RID: 217087 RVA: 0x00D4AA62 File Offset: 0x00D48C62
		// (set) Token: 0x06035000 RID: 217088 RVA: 0x00D4AA6A File Offset: 0x00D48C6A
		public bool StarNextActive { get; set; }

		// Token: 0x17008B6B RID: 35691
		// (get) Token: 0x06035001 RID: 217089 RVA: 0x00D4AA73 File Offset: 0x00D48C73
		// (set) Token: 0x06035002 RID: 217090 RVA: 0x00D4AA7B File Offset: 0x00D48C7B
		public bool StarLoopActive { get; set; }

		// Token: 0x17008B6C RID: 35692
		// (get) Token: 0x06035003 RID: 217091 RVA: 0x00D4AA84 File Offset: 0x00D48C84
		// (set) Token: 0x06035004 RID: 217092 RVA: 0x00D4AA8C File Offset: 0x00D48C8C
		public bool PlayLoopSequence { get; set; }

		// Token: 0x17008B6D RID: 35693
		// (get) Token: 0x06035005 RID: 217093 RVA: 0x00D4AA95 File Offset: 0x00D48C95
		// (set) Token: 0x06035006 RID: 217094 RVA: 0x00D4AA9D File Offset: 0x00D48C9D
		public bool PlayActivateSequence { get; set; }
	}
}
