using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E75 RID: 24181
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckRenameInputView : CommonInputViewBase
	{
		// Token: 0x0603CD1E RID: 249118 RVA: 0x00F7115C File Offset: 0x00F6F35C
		public DeckRenameInputView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CD1F RID: 249119 RVA: 0x00F71165 File Offset: 0x00F6F365
		protected override int GetMinLimit()
		{
			return ConfigCommonParamById.GetIntArrayConfig("GroupNameLimit")[0];
		}

		// Token: 0x0603CD20 RID: 249120 RVA: 0x00F71177 File Offset: 0x00F6F377
		protected override int GetMaxLimit()
		{
			return ConfigCommonParamById.GetIntArrayConfig("GroupNameLimit")[1];
		}

		// Token: 0x0603CD21 RID: 249121 RVA: 0x00F71189 File Offset: 0x00F6F389
		protected override void InitExtraParam()
		{
			this.RefreshUi();
		}

		// Token: 0x0603CD22 RID: 249122 RVA: 0x00F71191 File Offset: 0x00F6F391
		protected override void RefreshDuplicateName(string inputText)
		{
			this.RefreshUi();
		}

		// Token: 0x0603CD23 RID: 249123 RVA: 0x00F71199 File Offset: 0x00F6F399
		protected override bool IsAllowMultiLine()
		{
			return false;
		}

		// Token: 0x0603CD24 RID: 249124 RVA: 0x00F7119C File Offset: 0x00F6F39C
		private void RefreshUi()
		{
			bool flag = this.InputText.Text != this.InputData.InputText;
			bool flag2 = StringUtils.GetStringRealCount(this.InputText.Text) > this.GetMaxLimit();
			this.ConfirmButton.SetSelfInteractive(flag && !flag2);
		}
	}
}
