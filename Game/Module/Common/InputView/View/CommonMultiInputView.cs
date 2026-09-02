using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E73 RID: 24179
	public class CommonMultiInputView : CommonInputViewBase
	{
		// Token: 0x0603CD18 RID: 249112 RVA: 0x00F7112E File Offset: 0x00F6F32E
		[NullableContext(1)]
		public CommonMultiInputView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CD19 RID: 249113 RVA: 0x00F71137 File Offset: 0x00F6F337
		protected override int GetMaxLimit()
		{
			return 40;
		}

		// Token: 0x0603CD1A RID: 249114 RVA: 0x00F7113B File Offset: 0x00F6F33B
		protected override bool IsAllowMultiLine()
		{
			return !Singleton<Info>.Instance.IsIosPlatform();
		}
	}
}
