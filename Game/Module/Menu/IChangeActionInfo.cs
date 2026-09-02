using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005758 RID: 22360
	[NullableContext(1)]
	public interface IChangeActionInfo
	{
		// Token: 0x17009169 RID: 37225
		// (get) Token: 0x06038EA5 RID: 233125
		// (set) Token: 0x06038EA6 RID: 233126
		EInputControllerType InputControllerType { get; set; }

		// Token: 0x1700916A RID: 37226
		// (get) Token: 0x06038EA7 RID: 233127
		// (set) Token: 0x06038EA8 RID: 233128
		KeySettingRowData KeySettingRowData { get; set; }

		// Token: 0x1700916B RID: 37227
		// (get) Token: 0x06038EA9 RID: 233129
		// (set) Token: 0x06038EAA RID: 233130
		Action<bool> OnConfirmCallback { get; set; }
	}
}
