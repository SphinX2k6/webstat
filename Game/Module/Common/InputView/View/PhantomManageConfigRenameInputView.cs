using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E76 RID: 24182
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomManageConfigRenameInputView : CommonInputViewBase
	{
		// Token: 0x0603CD25 RID: 249125 RVA: 0x00F711F3 File Offset: 0x00F6F3F3
		public PhantomManageConfigRenameInputView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CD26 RID: 249126 RVA: 0x00F711FC File Offset: 0x00F6F3FC
		protected override int GetMaxLimit()
		{
			return ConfigCommonParamById.GetIntConfig("PhantomSettingNameLength").GetValueOrDefault(20);
		}

		// Token: 0x0603CD27 RID: 249127 RVA: 0x00F7121D File Offset: 0x00F6F41D
		protected override void InitExtraParam()
		{
			this.RefreshUi();
		}

		// Token: 0x0603CD28 RID: 249128 RVA: 0x00F71225 File Offset: 0x00F6F425
		protected override void RefreshDuplicateName(string inputText)
		{
			this.RefreshUi();
		}

		// Token: 0x0603CD29 RID: 249129 RVA: 0x00F7122D File Offset: 0x00F6F42D
		protected override bool IsAllowMultiLine()
		{
			return false;
		}

		// Token: 0x0603CD2A RID: 249130 RVA: 0x00F71230 File Offset: 0x00F6F430
		private void RefreshUi()
		{
			bool flag = this.InputText.Text != this.InputData.InputText;
			bool flag2 = StringUtils.GetStringRealCount(this.InputText.Text) > this.GetMaxLimit();
			this.ConfirmButton.SetSelfInteractive(flag && !flag2);
		}
	}
}
