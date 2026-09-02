using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058C5 RID: 22725
	[NullableContext(1)]
	public interface IBoxMark
	{
		// Token: 0x06039B2C RID: 236332
		string GetTitleText();

		// Token: 0x06039B2D RID: 236333
		string GetDescText();

		// Token: 0x1700934A RID: 37706
		// (get) Token: 0x06039B2E RID: 236334
		string IconPath { get; }
	}
}
