using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x020044FE RID: 17662
	public class HotFixBtnUiItem : LaunchComponentsAction
	{
		// Token: 0x0602E8CA RID: 190666 RVA: 0x00B07729 File Offset: 0x00B05929
		protected override void OnStart()
		{
			base.GetButton(0).OnClickCallBack.Bind(new Action(this.OnClickCallback));
		}

		// Token: 0x0602E8CB RID: 190667 RVA: 0x00B07748 File Offset: 0x00B05948
		protected override void OnBeforeDestroy()
		{
			if (this.Callback != null)
			{
				this.Callback = null;
			}
			base.GetButton(0).OnClickCallBack.Unbind();
		}

		// Token: 0x0602E8CC RID: 190668 RVA: 0x00B0776A File Offset: 0x00B0596A
		[NullableContext(1)]
		public void SetText([Nullable(2)] string tableId, params string[] args)
		{
			HotFixManager.SetLocalText(base.GetText(1), tableId, args);
		}

		// Token: 0x0602E8CD RID: 190669 RVA: 0x00B0777A File Offset: 0x00B0597A
		[NullableContext(1)]
		public void BindClickCallback(Action callback)
		{
			this.Callback = callback;
		}

		// Token: 0x0602E8CE RID: 190670 RVA: 0x00B07783 File Offset: 0x00B05983
		protected void OnClickCallback()
		{
			if (this.Callback != null)
			{
				this.Callback();
			}
		}

		// Token: 0x0401A724 RID: 108324
		[Nullable(2)]
		public Action Callback;

		// Token: 0x0200A714 RID: 42772
		private static class EComponents
		{
			// Token: 0x04033DA0 RID: 212384
			public const int Button = 0;

			// Token: 0x04033DA1 RID: 212385
			public const int Text = 1;

			// Token: 0x04033DA2 RID: 212386
			public const int RedDot = 2;
		}
	}
}
