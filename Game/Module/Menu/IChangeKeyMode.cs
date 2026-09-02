using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005762 RID: 22370
	[NullableContext(1)]
	public interface IChangeKeyMode
	{
		// Token: 0x17009183 RID: 37251
		// (get) Token: 0x06038EDD RID: 233181
		// (set) Token: 0x06038EDE RID: 233182
		string TitleName { get; set; }

		// Token: 0x17009184 RID: 37252
		// (get) Token: 0x06038EDF RID: 233183
		// (set) Token: 0x06038EE0 RID: 233184
		int DefaultGroupIndex { get; set; }

		// Token: 0x17009185 RID: 37253
		// (get) Token: 0x06038EE1 RID: 233185
		// (set) Token: 0x06038EE2 RID: 233186
		IChangeKeyModeGroup[] ChangeKeyModeGroupList { get; set; }

		// Token: 0x17009186 RID: 37254
		// (get) Token: 0x06038EE3 RID: 233187
		// (set) Token: 0x06038EE4 RID: 233188
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<Dictionary<int, int>> OnConfirmCallback { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
