using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ECF RID: 20175
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseSubLevelData
	{
		// Token: 0x0401E189 RID: 123273
		public int StageId;

		// Token: 0x0401E18A RID: 123274
		public Action<int> OnClickCb = delegate(int _)
		{
		};

		// Token: 0x0401E18B RID: 123275
		public Func<int, bool> IsSelectedGetter = (int _) => false;
	}
}
