using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059BA RID: 22970
	public class ComposeViewOpenData
	{
		// Token: 0x04020FB2 RID: 135090
		public EComposeListType Type = EComposeListType.Purification;

		// Token: 0x04020FB3 RID: 135091
		[Nullable(2)]
		public ISelectedData SelectData;

		// Token: 0x04020FB4 RID: 135092
		public EUiViewName? SkipSourceView;
	}
}
