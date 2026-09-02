using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.BattleViewDynamicUI
{
	// Token: 0x02006131 RID: 24881
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleViewDynamicUIConfig
	{
		// Token: 0x0402343A RID: 144442
		public string ResourceId = string.Empty;

		// Token: 0x0402343B RID: 144443
		public EBattleViewChildType ChildType;

		// Token: 0x0402343C RID: 144444
		public Func<BattleViewDynamicUiBase> CreateUi;
	}
}
