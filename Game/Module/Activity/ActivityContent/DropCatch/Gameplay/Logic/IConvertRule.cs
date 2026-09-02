using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006935 RID: 26933
	public class IConvertRule
	{
		// Token: 0x040253F7 RID: 152567
		[Nullable(1)]
		public HashSet<int> SourceItemIds = new HashSet<int>();

		// Token: 0x040253F8 RID: 152568
		public int TargetItemId;

		// Token: 0x040253F9 RID: 152569
		public double Duration;
	}
}
