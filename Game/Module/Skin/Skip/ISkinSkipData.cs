using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Skin.Skip
{
	// Token: 0x02004F6F RID: 20335
	[NullableContext(1)]
	public interface ISkinSkipData
	{
		// Token: 0x17008A3D RID: 35389
		// (get) Token: 0x06034719 RID: 214809
		// (set) Token: 0x0603471A RID: 214810
		int Id { get; set; }

		// Token: 0x17008A3E RID: 35390
		// (get) Token: 0x0603471B RID: 214811
		// (set) Token: 0x0603471C RID: 214812
		int ConfigId { get; set; }

		// Token: 0x17008A3F RID: 35391
		// (get) Token: 0x0603471D RID: 214813
		// (set) Token: 0x0603471E RID: 214814
		ESkinSkipType Type { get; set; }

		// Token: 0x17008A40 RID: 35392
		// (get) Token: 0x0603471F RID: 214815
		// (set) Token: 0x06034720 RID: 214816
		string Text { get; set; }

		// Token: 0x17008A41 RID: 35393
		// (get) Token: 0x06034721 RID: 214817
		// (set) Token: 0x06034722 RID: 214818
		int SortIndex { get; set; }
	}
}
