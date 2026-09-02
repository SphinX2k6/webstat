using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005953 RID: 22867
	[NullableContext(1)]
	public interface IRogueTipsData
	{
		// Token: 0x17009458 RID: 37976
		// (get) Token: 0x06039F8E RID: 237454
		// (set) Token: 0x06039F8F RID: 237455
		string TextId { get; set; }

		// Token: 0x17009459 RID: 37977
		// (get) Token: 0x06039F90 RID: 237456
		// (set) Token: 0x06039F91 RID: 237457
		string[] TextParam { get; set; }

		// Token: 0x1700945A RID: 37978
		// (get) Token: 0x06039F92 RID: 237458
		// (set) Token: 0x06039F93 RID: 237459
		[Nullable(2)]
		Action FinishCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
