using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051D1 RID: 20945
	public struct FetterData : IFetterData
	{
		// Token: 0x17008C97 RID: 35991
		// (get) Token: 0x06035D27 RID: 220455 RVA: 0x00D8A77A File Offset: 0x00D8897A
		// (set) Token: 0x06035D28 RID: 220456 RVA: 0x00D8A782 File Offset: 0x00D88982
		public int Id { readonly get; set; }

		// Token: 0x17008C98 RID: 35992
		// (get) Token: 0x06035D29 RID: 220457 RVA: 0x00D8A78B File Offset: 0x00D8898B
		// (set) Token: 0x06035D2A RID: 220458 RVA: 0x00D8A793 File Offset: 0x00D88993
		public int Lv { readonly get; set; }

		// Token: 0x17008C99 RID: 35993
		// (get) Token: 0x06035D2B RID: 220459 RVA: 0x00D8A79C File Offset: 0x00D8899C
		// (set) Token: 0x06035D2C RID: 220460 RVA: 0x00D8A7A4 File Offset: 0x00D889A4
		public int Star { readonly get; set; }

		// Token: 0x17008C9A RID: 35994
		// (get) Token: 0x06035D2D RID: 220461 RVA: 0x00D8A7AD File Offset: 0x00D889AD
		// (set) Token: 0x06035D2E RID: 220462 RVA: 0x00D8A7B5 File Offset: 0x00D889B5
		public bool IsLevelUp { readonly get; set; }
	}
}
