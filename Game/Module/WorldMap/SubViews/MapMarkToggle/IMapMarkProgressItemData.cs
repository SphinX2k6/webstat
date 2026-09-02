using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle
{
	// Token: 0x02004B9D RID: 19357
	[NullableContext(1)]
	public interface IMapMarkProgressItemData
	{
		// Token: 0x170086D9 RID: 34521
		// (get) Token: 0x060328B2 RID: 207026
		// (set) Token: 0x060328B3 RID: 207027
		string NameId { get; set; }

		// Token: 0x170086DA RID: 34522
		// (get) Token: 0x060328B4 RID: 207028
		// (set) Token: 0x060328B5 RID: 207029
		float Progress { get; set; }

		// Token: 0x170086DB RID: 34523
		// (get) Token: 0x060328B6 RID: 207030
		// (set) Token: 0x060328B7 RID: 207031
		float ProgressMax { get; set; }

		// Token: 0x170086DC RID: 34524
		// (get) Token: 0x060328B8 RID: 207032
		// (set) Token: 0x060328B9 RID: 207033
		float ProgressMin { get; set; }

		// Token: 0x170086DD RID: 34525
		// (get) Token: 0x060328BA RID: 207034
		// (set) Token: 0x060328BB RID: 207035
		[Nullable(2)]
		Action<float> SetProgressCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
