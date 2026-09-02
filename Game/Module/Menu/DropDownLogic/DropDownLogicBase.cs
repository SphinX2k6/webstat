using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.DropDownLogic
{
	// Token: 0x020057D0 RID: 22480
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class DropDownLogicBase
	{
		// Token: 0x06039243 RID: 234051
		public abstract IReadOnlyList<object> GetDropDownDataList();

		// Token: 0x06039244 RID: 234052
		public abstract TableTextArgNew GetDataTextId(object data, MenuData menuData);

		// Token: 0x06039245 RID: 234053
		public abstract void TriggerSelectChange(object data, MenuData menuData);

		// Token: 0x06039246 RID: 234054
		public abstract int GetDefaultIndex(MenuData menuData);
	}
}
