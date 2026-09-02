using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.ResetPlayer
{
	// Token: 0x02006B2C RID: 27436
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ResetPlayerModel : ModelBase<ResetPlayerModel>
	{
		// Token: 0x04025E97 RID: 155287
		public bool IsReseting;

		// Token: 0x04025E98 RID: 155288
		public HashSet<int> CueHandleSet = new HashSet<int>();

		// Token: 0x04025E99 RID: 155289
		[Nullable(2)]
		public EntityHandle DisableMoveEntityHandle;
	}
}
