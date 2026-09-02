using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ECE RID: 20174
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseGroupData
	{
		// Token: 0x0401E185 RID: 123269
		public int GroupId;

		// Token: 0x0401E186 RID: 123270
		public List<int> SubStageIds = new List<int>();

		// Token: 0x0401E187 RID: 123271
		public Action<int> OnClickSubLevel = delegate(int _)
		{
		};

		// Token: 0x0401E188 RID: 123272
		public Func<int, bool> IsSelectedGetter = (int _) => false;
	}
}
