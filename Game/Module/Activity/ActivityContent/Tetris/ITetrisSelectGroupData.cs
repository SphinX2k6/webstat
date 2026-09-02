using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200629D RID: 25245
	[NullableContext(1)]
	public interface ITetrisSelectGroupData
	{
		// Token: 0x17009C69 RID: 40041
		// (get) Token: 0x0603F897 RID: 260247
		// (set) Token: 0x0603F898 RID: 260248
		int GroupId { get; set; }

		// Token: 0x17009C6A RID: 40042
		// (get) Token: 0x0603F899 RID: 260249
		// (set) Token: 0x0603F89A RID: 260250
		List<int> ChallengeIds { get; set; }
	}
}
