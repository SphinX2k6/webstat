using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200685F RID: 26719
	[NullableContext(1)]
	[Nullable(0)]
	public class HexData : IHexData
	{
		// Token: 0x1700A19F RID: 41375
		// (get) Token: 0x06042989 RID: 272777 RVA: 0x01117E24 File Offset: 0x01116024
		// (set) Token: 0x0604298A RID: 272778 RVA: 0x01117E2C File Offset: 0x0111602C
		public IHexPos HexPos { get; set; }

		// Token: 0x1700A1A0 RID: 41376
		// (get) Token: 0x0604298B RID: 272779 RVA: 0x01117E35 File Offset: 0x01116035
		// (set) Token: 0x0604298C RID: 272780 RVA: 0x01117E3D File Offset: 0x0111603D
		public EncircleHexType Type { get; set; }

		// Token: 0x1700A1A1 RID: 41377
		// (get) Token: 0x0604298D RID: 272781 RVA: 0x01117E46 File Offset: 0x01116046
		// (set) Token: 0x0604298E RID: 272782 RVA: 0x01117E4E File Offset: 0x0111604E
		public int MapId { get; set; }
	}
}
