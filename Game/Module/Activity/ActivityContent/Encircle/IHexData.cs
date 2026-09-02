using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200685E RID: 26718
	[NullableContext(1)]
	public interface IHexData
	{
		// Token: 0x1700A19C RID: 41372
		// (get) Token: 0x06042983 RID: 272771
		// (set) Token: 0x06042984 RID: 272772
		IHexPos HexPos { get; set; }

		// Token: 0x1700A19D RID: 41373
		// (get) Token: 0x06042985 RID: 272773
		// (set) Token: 0x06042986 RID: 272774
		EncircleHexType Type { get; set; }

		// Token: 0x1700A19E RID: 41374
		// (get) Token: 0x06042987 RID: 272775
		// (set) Token: 0x06042988 RID: 272776
		int MapId { get; set; }
	}
}
