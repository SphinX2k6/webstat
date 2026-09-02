using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D9B RID: 23963
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkDungeonToggleItemParams : IDreamLinkDungeonToggleItemParams
	{
		// Token: 0x170098AD RID: 39085
		// (get) Token: 0x0603C578 RID: 247160 RVA: 0x00F504D3 File Offset: 0x00F4E6D3
		// (set) Token: 0x0603C579 RID: 247161 RVA: 0x00F504DB File Offset: 0x00F4E6DB
		public string TextureBgPath { get; set; }

		// Token: 0x170098AE RID: 39086
		// (get) Token: 0x0603C57A RID: 247162 RVA: 0x00F504E4 File Offset: 0x00F4E6E4
		// (set) Token: 0x0603C57B RID: 247163 RVA: 0x00F504EC File Offset: 0x00F4E6EC
		public string TextureLightPath { get; set; }

		// Token: 0x170098AF RID: 39087
		// (get) Token: 0x0603C57C RID: 247164 RVA: 0x00F504F5 File Offset: 0x00F4E6F5
		// (set) Token: 0x0603C57D RID: 247165 RVA: 0x00F504FD File Offset: 0x00F4E6FD
		public string EffectColor { get; set; }
	}
}
