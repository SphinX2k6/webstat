using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063C6 RID: 25542
	[NullableContext(1)]
	public interface IRoverlikeEventOpenParam
	{
		// Token: 0x17009DA5 RID: 40357
		// (get) Token: 0x0604022A RID: 262698
		// (set) Token: 0x0604022B RID: 262699
		int EventIncId { get; set; }

		// Token: 0x17009DA6 RID: 40358
		// (get) Token: 0x0604022C RID: 262700
		// (set) Token: 0x0604022D RID: 262701
		List<int> ChoiceList { get; set; }
	}
}
