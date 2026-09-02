using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A8C RID: 19084
	[NullableContext(2)]
	[Nullable(0)]
	public class SubPackageDownLoadMobileClearInfoItemData : ISubPackageDownLoadMobileClearInfoItemData, IHotFixLayoutData
	{
		// Token: 0x170084AD RID: 33965
		// (get) Token: 0x06031CA4 RID: 203940 RVA: 0x00C77E3E File Offset: 0x00C7603E
		// (set) Token: 0x06031CA5 RID: 203941 RVA: 0x00C77E46 File Offset: 0x00C76046
		public int? Index { get; set; }

		// Token: 0x170084AE RID: 33966
		// (get) Token: 0x06031CA6 RID: 203942 RVA: 0x00C77E4F File Offset: 0x00C7604F
		// (set) Token: 0x06031CA7 RID: 203943 RVA: 0x00C77E57 File Offset: 0x00C76057
		public ESubPackageDownLoadPackageType Type { get; set; }

		// Token: 0x170084AF RID: 33967
		// (get) Token: 0x06031CA8 RID: 203944 RVA: 0x00C77E60 File Offset: 0x00C76060
		// (set) Token: 0x06031CA9 RID: 203945 RVA: 0x00C77E68 File Offset: 0x00C76068
		public int? SceneId { get; set; }

		// Token: 0x170084B0 RID: 33968
		// (get) Token: 0x06031CAA RID: 203946 RVA: 0x00C77E71 File Offset: 0x00C76071
		// (set) Token: 0x06031CAB RID: 203947 RVA: 0x00C77E79 File Offset: 0x00C76079
		public bool? HaveVideoCanClear { get; set; }

		// Token: 0x170084B1 RID: 33969
		// (get) Token: 0x06031CAC RID: 203948 RVA: 0x00C77E82 File Offset: 0x00C76082
		// (set) Token: 0x06031CAD RID: 203949 RVA: 0x00C77E8A File Offset: 0x00C7608A
		public string VoiceLanguageCode { get; set; }
	}
}
