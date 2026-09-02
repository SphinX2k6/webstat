using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005786 RID: 22406
	[NullableContext(1)]
	[Nullable(0)]
	public class MenuDetailPopData
	{
		// Token: 0x0402075D RID: 132957
		public string Title = "";

		// Token: 0x0402075E RID: 132958
		public string Description = "";

		// Token: 0x0402075F RID: 132959
		public bool IsMulti;

		// Token: 0x04020760 RID: 132960
		public List<MenuDetailPopItemData> ItemList = new List<MenuDetailPopItemData>();
	}
}
