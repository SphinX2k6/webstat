using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006862 RID: 26722
	[NullableContext(1)]
	public interface IEncircleArgs
	{
		// Token: 0x1700A1A4 RID: 41380
		// (get) Token: 0x06042995 RID: 272789
		// (set) Token: 0x06042996 RID: 272790
		Dictionary<int, IHexData> Hexes { get; set; }

		// Token: 0x1700A1A5 RID: 41381
		// (get) Token: 0x06042997 RID: 272791
		// (set) Token: 0x06042998 RID: 272792
		int Height { get; set; }

		// Token: 0x1700A1A6 RID: 41382
		// (get) Token: 0x06042999 RID: 272793
		// (set) Token: 0x0604299A RID: 272794
		int Width { get; set; }
	}
}
