using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058C7 RID: 22727
	public interface IMarkShowState
	{
		// Token: 0x17009357 RID: 37719
		// (get) Token: 0x06039B47 RID: 236359
		// (set) Token: 0x06039B48 RID: 236360
		int Id { get; set; }

		// Token: 0x17009358 RID: 37720
		// (get) Token: 0x06039B49 RID: 236361
		// (set) Token: 0x06039B4A RID: 236362
		bool NeedFocus { get; set; }

		// Token: 0x17009359 RID: 37721
		// (get) Token: 0x06039B4B RID: 236363
		// (set) Token: 0x06039B4C RID: 236364
		MapMarkShowFlag ShowFlag { get; set; }
	}
}
