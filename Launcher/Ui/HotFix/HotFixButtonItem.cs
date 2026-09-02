using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x020044FF RID: 17663
	public class HotFixButtonItem : LaunchComponentsAction
	{
		// Token: 0x0602E8D0 RID: 190672 RVA: 0x00B077A0 File Offset: 0x00B059A0
		protected override void OnStart()
		{
			base.GetButton(0).OnClickCallBack.Bind(new Action(this.OnClickCallback));
		}

		// Token: 0x0602E8D1 RID: 190673 RVA: 0x00B077BF File Offset: 0x00B059BF
		protected override void OnBeforeDestroy()
		{
			if (this.Callback != null)
			{
				this.Callback = null;
			}
			base.GetButton(0).OnClickCallBack.Unbind();
		}

		// Token: 0x0602E8D2 RID: 190674 RVA: 0x00B077E1 File Offset: 0x00B059E1
		[NullableContext(1)]
		public void BindClickCallback(Action callback)
		{
			this.Callback = callback;
		}

		// Token: 0x0602E8D3 RID: 190675 RVA: 0x00B077EA File Offset: 0x00B059EA
		private void OnClickCallback()
		{
			if (this.Callback != null)
			{
				this.Callback();
			}
		}

		// Token: 0x0602E8D4 RID: 190676 RVA: 0x00B077FF File Offset: 0x00B059FF
		[NullableContext(2)]
		public void SetLocalText(string tableId)
		{
			HotFixManager.SetLocalText(base.GetText(1), tableId, Array.Empty<string>());
		}

		// Token: 0x0602E8D5 RID: 190677 RVA: 0x00B07813 File Offset: 0x00B05A13
		public void SetEnableClick(bool state)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(state);
		}

		// Token: 0x0401A725 RID: 108325
		[Nullable(2)]
		public Action Callback = delegate()
		{
		};

		// Token: 0x0200A715 RID: 42773
		private class EComponents
		{
			// Token: 0x04033DA3 RID: 212387
			public const int Button = 0;

			// Token: 0x04033DA4 RID: 212388
			public const int Text = 1;

			// Token: 0x04033DA5 RID: 212389
			public const int Icon = 2;
		}
	}
}
