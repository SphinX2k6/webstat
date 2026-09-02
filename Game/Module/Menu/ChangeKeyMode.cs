using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005763 RID: 22371
	[NullableContext(1)]
	[Nullable(0)]
	public class ChangeKeyMode : IChangeKeyMode
	{
		// Token: 0x17009187 RID: 37255
		// (get) Token: 0x06038EE5 RID: 233189 RVA: 0x00E6C8CE File Offset: 0x00E6AACE
		// (set) Token: 0x06038EE6 RID: 233190 RVA: 0x00E6C8D6 File Offset: 0x00E6AAD6
		public string TitleName { get; set; } = "";

		// Token: 0x17009188 RID: 37256
		// (get) Token: 0x06038EE7 RID: 233191 RVA: 0x00E6C8DF File Offset: 0x00E6AADF
		// (set) Token: 0x06038EE8 RID: 233192 RVA: 0x00E6C8E7 File Offset: 0x00E6AAE7
		public int DefaultGroupIndex { get; set; }

		// Token: 0x17009189 RID: 37257
		// (get) Token: 0x06038EE9 RID: 233193 RVA: 0x00E6C8F0 File Offset: 0x00E6AAF0
		// (set) Token: 0x06038EEA RID: 233194 RVA: 0x00E6C8F8 File Offset: 0x00E6AAF8
		public IChangeKeyModeGroup[] ChangeKeyModeGroupList { get; set; } = new IChangeKeyModeGroup[0];

		// Token: 0x1700918A RID: 37258
		// (get) Token: 0x06038EEB RID: 233195 RVA: 0x00E6C901 File Offset: 0x00E6AB01
		// (set) Token: 0x06038EEC RID: 233196 RVA: 0x00E6C909 File Offset: 0x00E6AB09
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<Dictionary<int, int>> OnConfirmCallback { [return: Nullable(new byte[]
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
