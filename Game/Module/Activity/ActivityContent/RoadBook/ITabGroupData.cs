using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064BC RID: 25788
	[NullableContext(1)]
	public interface ITabGroupData
	{
		// Token: 0x17009E60 RID: 40544
		// (get) Token: 0x060409EB RID: 264683
		// (set) Token: 0x060409EC RID: 264684
		List<MotorChallengePlayData> TabDataList { get; set; }

		// Token: 0x17009E61 RID: 40545
		// (get) Token: 0x060409ED RID: 264685
		// (set) Token: 0x060409EE RID: 264686
		[Nullable(2)]
		string GroupTitleId { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
