using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E7C RID: 24188
	[NullableContext(1)]
	[Nullable(0)]
	public class VisionAssembleInputView : CommonInputViewBase
	{
		// Token: 0x0603CD5C RID: 249180 RVA: 0x00F71854 File Offset: 0x00F6FA54
		public VisionAssembleInputView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CD5D RID: 249181 RVA: 0x00F7185D File Offset: 0x00F6FA5D
		protected override void OnAddEventListener()
		{
			base.OnAddEventListener();
		}

		// Token: 0x0603CD5E RID: 249182 RVA: 0x00F71865 File Offset: 0x00F6FA65
		protected override void OnRemoveEventListener()
		{
			base.OnRemoveEventListener();
		}

		// Token: 0x0603CD5F RID: 249183 RVA: 0x00F7186D File Offset: 0x00F6FA6D
		protected override int GetMaxLimit()
		{
			return 20;
		}

		// Token: 0x0603CD60 RID: 249184 RVA: 0x00F71871 File Offset: 0x00F6FA71
		protected override void InitExtraParam()
		{
			this.RefreshUi();
		}

		// Token: 0x0603CD61 RID: 249185 RVA: 0x00F71879 File Offset: 0x00F6FA79
		protected override void RefreshDuplicateName(string inputText)
		{
			this.RefreshUi();
		}

		// Token: 0x0603CD62 RID: 249186 RVA: 0x00F71881 File Offset: 0x00F6FA81
		protected override bool IsAllowMultiLine()
		{
			return false;
		}

		// Token: 0x0603CD63 RID: 249187 RVA: 0x00F71884 File Offset: 0x00F6FA84
		private void RefreshUi()
		{
			bool flag = this.InputText.Text != this.InputData.InputText;
			bool flag2 = StringUtils.GetStringRealCount(this.InputText.Text) > this.GetMaxLimit();
			this.ConfirmButton.SetSelfInteractive(flag && !flag2);
		}
	}
}
