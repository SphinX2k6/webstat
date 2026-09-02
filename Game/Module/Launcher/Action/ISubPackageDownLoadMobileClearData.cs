using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A89 RID: 19081
	[NullableContext(2)]
	public interface ISubPackageDownLoadMobileClearData : IHotFixLayoutData
	{
		// Token: 0x170084A0 RID: 33952
		// (get) Token: 0x06031C89 RID: 203913
		// (set) Token: 0x06031C8A RID: 203914
		int TitleId { get; set; }

		// Token: 0x170084A1 RID: 33953
		// (get) Token: 0x06031C8B RID: 203915
		// (set) Token: 0x06031C8C RID: 203916
		List<int> SceneIdList { get; set; }

		// Token: 0x170084A2 RID: 33954
		// (get) Token: 0x06031C8D RID: 203917
		// (set) Token: 0x06031C8E RID: 203918
		bool? HaveVideoCanClear { get; set; }

		// Token: 0x170084A3 RID: 33955
		// (get) Token: 0x06031C8F RID: 203919
		// (set) Token: 0x06031C90 RID: 203920
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<string> VoiceLanguageCodeList { [return: Nullable(new byte[]
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
