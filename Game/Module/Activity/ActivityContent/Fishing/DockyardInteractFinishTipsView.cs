using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067C9 RID: 26569
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractFinishTipsView : UiViewBase
	{
		// Token: 0x06042493 RID: 271507 RVA: 0x01100A52 File Offset: 0x010FEC52
		public DockyardInteractFinishTipsView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042494 RID: 271508 RVA: 0x01100A5B File Offset: 0x010FEC5B
		protected override void OnRegisterComponent()
		{
			this.Vm = (this.OpenParam as DockyardInteractFinishTipsViewModel);
		}

		// Token: 0x06042495 RID: 271509 RVA: 0x01100A6E File Offset: 0x010FEC6E
		protected override void OnAfterPlayStartSequence()
		{
			Action closeCallback = this.Vm.CloseCallback;
			if (closeCallback != null)
			{
				closeCallback();
			}
			base.CloseMe(null);
		}

		// Token: 0x04024E80 RID: 151168
		private DockyardInteractFinishTipsViewModel Vm;
	}
}
