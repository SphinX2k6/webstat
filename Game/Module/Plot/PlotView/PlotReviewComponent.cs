using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053C2 RID: 21442
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotReviewComponent
	{
		// Token: 0x06036AE3 RID: 223971 RVA: 0x00DDB39C File Offset: 0x00DD959C
		[NullableContext(1)]
		public PlotReviewComponent(UUIButtonComponent reviewButton, Action clickCallback)
		{
			this.PlotReviewButton = reviewButton;
			this.PlotReviewItem = reviewButton.RootUIComp;
			this.ClickCallback = clickCallback;
			this.PlotReviewButton.OnClickCallBack.Bind(new Action(this.OnReviewButtonClick));
			this.IsActive = false;
		}

		// Token: 0x06036AE4 RID: 223972 RVA: 0x00DDB3F8 File Offset: 0x00DD95F8
		public void OnClear()
		{
			this.IsActive = false;
			this.ClickCallback = null;
			UUIButtonComponent plotReviewButton = this.PlotReviewButton;
			if (plotReviewButton == null)
			{
				return;
			}
			plotReviewButton.OnClickCallBack.Unbind();
		}

		// Token: 0x06036AE5 RID: 223973 RVA: 0x00DDB41D File Offset: 0x00DD961D
		public bool IsReviewButtonEnabled()
		{
			return this.IsActive;
		}

		// Token: 0x06036AE6 RID: 223974 RVA: 0x00DDB428 File Offset: 0x00DD9628
		public void EnableReviewButton(bool enable)
		{
			if (this.IsActive == enable)
			{
				return;
			}
			this.IsActive = enable;
			bool flag = this.IsActive;
			if (flag && Singleton<InputManager>.Instance.IsImmersiveMouseModeEnabled())
			{
				flag = this.ImmersiveInputWakeState;
			}
			UUIItem plotReviewItem = this.PlotReviewItem;
			if (plotReviewItem == null)
			{
				return;
			}
			plotReviewItem.SetUIActive(flag);
		}

		// Token: 0x06036AE7 RID: 223975 RVA: 0x00DDB474 File Offset: 0x00DD9674
		private void OnReviewButtonClick()
		{
			if (!this.IsActive)
			{
				return;
			}
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}

		// Token: 0x06036AE8 RID: 223976 RVA: 0x00DDB48F File Offset: 0x00DD968F
		public void UpdateImmersiveInputWakeState(bool isWake)
		{
			if (isWake && !this.ImmersiveInputWakeState && this.IsActive)
			{
				this.PlotReviewItem.SetUIActive(true);
			}
			this.ImmersiveInputWakeState = isWake;
		}

		// Token: 0x0401F7F6 RID: 129014
		private bool IsActive;

		// Token: 0x0401F7F7 RID: 129015
		private readonly UUIItem PlotReviewItem;

		// Token: 0x0401F7F8 RID: 129016
		private readonly UUIButtonComponent PlotReviewButton;

		// Token: 0x0401F7F9 RID: 129017
		private Action ClickCallback;

		// Token: 0x0401F7FA RID: 129018
		private bool ImmersiveInputWakeState = true;
	}
}
