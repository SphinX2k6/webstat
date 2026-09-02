using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005760 RID: 22368
	[NullableContext(1)]
	public interface IChangeKeyModeGroup
	{
		// Token: 0x1700917D RID: 37245
		// (get) Token: 0x06038ED0 RID: 233168
		// (set) Token: 0x06038ED1 RID: 233169
		string GroupName { get; set; }

		// Token: 0x1700917E RID: 37246
		// (get) Token: 0x06038ED2 RID: 233170
		// (set) Token: 0x06038ED3 RID: 233171
		int DefaultKeyModeRowIndex { get; set; }

		// Token: 0x1700917F RID: 37247
		// (get) Token: 0x06038ED4 RID: 233172
		// (set) Token: 0x06038ED5 RID: 233173
		IChangeKeyModeRow[] ChangeKeyModeRowList { get; set; }
	}
}
