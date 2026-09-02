using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067F7 RID: 26615
	[NullableContext(1)]
	public interface IRequestHandleIn
	{
		// Token: 0x1700A12F RID: 41263
		// (get) Token: 0x060425A4 RID: 271780
		// (set) Token: 0x060425A5 RID: 271781
		int InteractId { get; set; }

		// Token: 0x1700A130 RID: 41264
		// (get) Token: 0x060425A6 RID: 271782
		// (set) Token: 0x060425A7 RID: 271783
		List<FishingItemInfo> LeftDataList { get; set; }

		// Token: 0x1700A131 RID: 41265
		// (get) Token: 0x060425A8 RID: 271784
		// (set) Token: 0x060425A9 RID: 271785
		List<FishingItemInfo> RightDataList { get; set; }

		// Token: 0x1700A132 RID: 41266
		// (get) Token: 0x060425AA RID: 271786
		// (set) Token: 0x060425AB RID: 271787
		int? RemoveIncId { get; set; }

		// Token: 0x1700A133 RID: 41267
		// (get) Token: 0x060425AC RID: 271788
		// (set) Token: 0x060425AD RID: 271789
		int ActionIncId { get; set; }

		// Token: 0x1700A134 RID: 41268
		// (get) Token: 0x060425AE RID: 271790
		// (set) Token: 0x060425AF RID: 271791
		[Nullable(2)]
		Action<bool, bool> Callback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
