using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B31 RID: 19249
	[NullableContext(1)]
	public interface IMapMarkRangeInfo
	{
		// Token: 0x17008604 RID: 34308
		// (get) Token: 0x06032396 RID: 205718
		// (set) Token: 0x06032397 RID: 205719
		Vector2D Position { get; set; }

		// Token: 0x17008605 RID: 34309
		// (get) Token: 0x06032398 RID: 205720
		// (set) Token: 0x06032399 RID: 205721
		int? MapId { get; set; }

		// Token: 0x17008606 RID: 34310
		// (get) Token: 0x0603239A RID: 205722
		// (set) Token: 0x0603239B RID: 205723
		EMapGravityDirection? Gravity { get; set; }

		// Token: 0x17008607 RID: 34311
		// (get) Token: 0x0603239C RID: 205724
		// (set) Token: 0x0603239D RID: 205725
		float? Width { get; set; }

		// Token: 0x17008608 RID: 34312
		// (get) Token: 0x0603239E RID: 205726
		// (set) Token: 0x0603239F RID: 205727
		float? Height { get; set; }
	}
}
