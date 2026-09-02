using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005756 RID: 22358
	[NullableContext(1)]
	public interface IRepeatKeyInfo
	{
		// Token: 0x17009161 RID: 37217
		// (get) Token: 0x06038E94 RID: 233108
		// (set) Token: 0x06038E95 RID: 233109
		EInputControllerType InputControllerType { get; set; }

		// Token: 0x17009162 RID: 37218
		// (get) Token: 0x06038E96 RID: 233110
		// (set) Token: 0x06038E97 RID: 233111
		KeySettingRowData CurrentKeySettingRowData { get; set; }

		// Token: 0x17009163 RID: 37219
		// (get) Token: 0x06038E98 RID: 233112
		// (set) Token: 0x06038E99 RID: 233113
		KeySettingRowData RepeatKeySettingRowData { get; set; }

		// Token: 0x17009164 RID: 37220
		// (get) Token: 0x06038E9A RID: 233114
		// (set) Token: 0x06038E9B RID: 233115
		[Nullable(2)]
		Action<bool> OnCloseCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
