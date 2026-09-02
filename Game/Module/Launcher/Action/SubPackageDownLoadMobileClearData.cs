using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A8A RID: 19082
	[NullableContext(2)]
	[Nullable(0)]
	public class SubPackageDownLoadMobileClearData : ISubPackageDownLoadMobileClearData, IHotFixLayoutData
	{
		// Token: 0x170084A4 RID: 33956
		// (get) Token: 0x06031C91 RID: 203921 RVA: 0x00C77DE1 File Offset: 0x00C75FE1
		// (set) Token: 0x06031C92 RID: 203922 RVA: 0x00C77DE9 File Offset: 0x00C75FE9
		public int? Index { get; set; }

		// Token: 0x170084A5 RID: 33957
		// (get) Token: 0x06031C93 RID: 203923 RVA: 0x00C77DF2 File Offset: 0x00C75FF2
		// (set) Token: 0x06031C94 RID: 203924 RVA: 0x00C77DFA File Offset: 0x00C75FFA
		public int TitleId { get; set; }

		// Token: 0x170084A6 RID: 33958
		// (get) Token: 0x06031C95 RID: 203925 RVA: 0x00C77E03 File Offset: 0x00C76003
		// (set) Token: 0x06031C96 RID: 203926 RVA: 0x00C77E0B File Offset: 0x00C7600B
		public List<int> SceneIdList { get; set; }

		// Token: 0x170084A7 RID: 33959
		// (get) Token: 0x06031C97 RID: 203927 RVA: 0x00C77E14 File Offset: 0x00C76014
		// (set) Token: 0x06031C98 RID: 203928 RVA: 0x00C77E1C File Offset: 0x00C7601C
		public bool? HaveVideoCanClear { get; set; }

		// Token: 0x170084A8 RID: 33960
		// (get) Token: 0x06031C99 RID: 203929 RVA: 0x00C77E25 File Offset: 0x00C76025
		// (set) Token: 0x06031C9A RID: 203930 RVA: 0x00C77E2D File Offset: 0x00C7602D
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> VoiceLanguageCodeList { [return: Nullable(new byte[]
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
