using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006863 RID: 26723
	[NullableContext(1)]
	[Nullable(0)]
	public class EncircleArgs : IEncircleArgs
	{
		// Token: 0x1700A1A7 RID: 41383
		// (get) Token: 0x0604299B RID: 272795 RVA: 0x01117E78 File Offset: 0x01116078
		// (set) Token: 0x0604299C RID: 272796 RVA: 0x01117E80 File Offset: 0x01116080
		public Dictionary<int, IHexData> Hexes { get; set; }

		// Token: 0x1700A1A8 RID: 41384
		// (get) Token: 0x0604299D RID: 272797 RVA: 0x01117E89 File Offset: 0x01116089
		// (set) Token: 0x0604299E RID: 272798 RVA: 0x01117E91 File Offset: 0x01116091
		public int Height { get; set; }

		// Token: 0x1700A1A9 RID: 41385
		// (get) Token: 0x0604299F RID: 272799 RVA: 0x01117E9A File Offset: 0x0111609A
		// (set) Token: 0x060429A0 RID: 272800 RVA: 0x01117EA2 File Offset: 0x011160A2
		public int Width { get; set; }
	}
}
