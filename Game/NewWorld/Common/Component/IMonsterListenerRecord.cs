using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048BA RID: 18618
	internal class IMonsterListenerRecord
	{
		// Token: 0x0401BE59 RID: 114265
		public int EmotionId;

		// Token: 0x0401BE5A RID: 114266
		public bool Once;

		// Token: 0x0401BE5B RID: 114267
		[Nullable(1)]
		public HashSet<int> TagIds = new HashSet<int>();
	}
}
