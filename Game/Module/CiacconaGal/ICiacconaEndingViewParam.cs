using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED6 RID: 24278
	[NullableContext(1)]
	public interface ICiacconaEndingViewParam
	{
		// Token: 0x170099ED RID: 39405
		// (get) Token: 0x0603D01A RID: 249882
		// (set) Token: 0x0603D01B RID: 249883
		CiacconaGalEndingData EndingData { get; set; }

		// Token: 0x170099EE RID: 39406
		// (get) Token: 0x0603D01C RID: 249884
		// (set) Token: 0x0603D01D RID: 249885
		[Nullable(2)]
		string LabelTextId { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
