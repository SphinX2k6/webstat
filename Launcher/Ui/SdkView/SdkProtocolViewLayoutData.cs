using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Ui.SdkView
{
	// Token: 0x020044FC RID: 17660
	[NullableContext(1)]
	[Nullable(0)]
	public class SdkProtocolViewLayoutData
	{
		// Token: 0x0602E8C4 RID: 190660 RVA: 0x00B074F3 File Offset: 0x00B056F3
		public static SdkProtocolViewLayoutData CreateLayoutData(string textId, string keyShortCut, Action<SdkProtocolView> clickCallBack)
		{
			return new SdkProtocolViewLayoutData
			{
				TextId = textId,
				KeyShortCut = keyShortCut,
				ClickCallBack = clickCallBack
			};
		}

		// Token: 0x0401A71C RID: 108316
		public string TextId = "";

		// Token: 0x0401A71D RID: 108317
		public string KeyShortCut = "";

		// Token: 0x0401A71E RID: 108318
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<SdkProtocolView> ClickCallBack;
	}
}
