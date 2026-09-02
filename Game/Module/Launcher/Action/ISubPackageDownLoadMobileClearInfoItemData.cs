using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A8B RID: 19083
	[NullableContext(2)]
	public interface ISubPackageDownLoadMobileClearInfoItemData : IHotFixLayoutData
	{
		// Token: 0x170084A9 RID: 33961
		// (get) Token: 0x06031C9C RID: 203932
		// (set) Token: 0x06031C9D RID: 203933
		ESubPackageDownLoadPackageType Type { get; set; }

		// Token: 0x170084AA RID: 33962
		// (get) Token: 0x06031C9E RID: 203934
		// (set) Token: 0x06031C9F RID: 203935
		int? SceneId { get; set; }

		// Token: 0x170084AB RID: 33963
		// (get) Token: 0x06031CA0 RID: 203936
		// (set) Token: 0x06031CA1 RID: 203937
		bool? HaveVideoCanClear { get; set; }

		// Token: 0x170084AC RID: 33964
		// (get) Token: 0x06031CA2 RID: 203938
		// (set) Token: 0x06031CA3 RID: 203939
		string VoiceLanguageCode { get; set; }
	}
}
