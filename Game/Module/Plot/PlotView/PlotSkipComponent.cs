using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053CA RID: 21450
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotSkipComponent
	{
		// Token: 0x06036B1F RID: 224031 RVA: 0x00DDC200 File Offset: 0x00DDA400
		public PlotSkipComponent([Nullable(1)] UUIButtonComponent skipButton, Action skipCallback = null, Action clickCallback = null, UiViewBase attachParent = null, Action cancelCallback = null, EUiBehaviourPopType? customConfirmBoxPopType = null, string customConfirmBoxResourceId = null)
		{
			this.SkipButton = skipButton;
			this.SkipItem = skipButton.RootUIComp.Get();
			this.SkipCallback = skipCallback;
			this.ClickCallback = clickCallback;
			this.CancelCallback = cancelCallback;
			this.AttachParent = attachParent;
			this.CustomConfirmBoxPopType = customConfirmBoxPopType;
			this.CustomConfirmBoxResourceId = customConfirmBoxResourceId;
			this.IsActive = false;
			this.SummaryText = null;
			this.SkipButton.OnClickCallBack.Bind(new Action(this.OnSkipButtonClick));
			this.ToggleText = ConfigBase<TextConfig>.Instance.GetTextById("PlotSkipConfirmToggle");
			if (string.IsNullOrEmpty(this.ToggleText))
			{
				ControllerBase<FlowController>.Instance.LogError("剧情跳过二次确认框读不到Toggle文本 \"PlotSkipConfirmToggle\"", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ToggleText = "";
			}
		}

		// Token: 0x06036B20 RID: 224032 RVA: 0x00DDC2DC File Offset: 0x00DDA4DC
		public void OnClear()
		{
			this.IsActive = false;
			this.LockName = null;
			UUIButtonComponent skipButton = this.SkipButton;
			if (skipButton != null)
			{
				skipButton.OnClickCallBack.Unbind();
			}
			this.SkipButton = null;
			this.SkipItem = null;
			this.AttachParent = null;
			this.SummaryText = null;
			this.SkipCallback = null;
			this.ClickCallback = null;
			this.CancelCallback = null;
			if (this.IsConfirmBoxShowing)
			{
				this.IsConfirmBoxShowing = false;
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
			}
		}

		// Token: 0x06036B21 RID: 224033 RVA: 0x00DDC357 File Offset: 0x00DDA557
		public void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.EnableSkipPlot, new Action<bool>(this.EnableSkipButton));
		}

		// Token: 0x06036B22 RID: 224034 RVA: 0x00DDC375 File Offset: 0x00DDA575
		public void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.EnableSkipPlot, new Action<bool>(this.EnableSkipButton));
		}

		// Token: 0x06036B23 RID: 224035 RVA: 0x00DDC394 File Offset: 0x00DDA594
		public void AddSummary(IShowTalkOutline config)
		{
			if (config == null || StringUtils.IsEmpty(config.TidOutline))
			{
				return;
			}
			string flowConfigLocalText = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(config.TidOutline);
			this.SummaryText = ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(flowConfigLocalText, false);
		}

		// Token: 0x06036B24 RID: 224036 RVA: 0x00DDC3DA File Offset: 0x00DDA5DA
		public bool IsSkipButtonEnabled()
		{
			return this.IsActive;
		}

		// Token: 0x06036B25 RID: 224037 RVA: 0x00DDC3E4 File Offset: 0x00DDA5E4
		[NullableContext(1)]
		public unsafe void LockSkipButton(string lockName)
		{
			if (this.LockName != null && this.LockName != lockName)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "跳过按钮已被其他lock锁定, 本次锁定忽略";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("curLock", this.LockName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("newLock", lockName);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.LockName = null;
			this.EnableSkipButton(false);
			this.LockName = lockName;
		}

		// Token: 0x06036B26 RID: 224038 RVA: 0x00DDC478 File Offset: 0x00DDA678
		[NullableContext(1)]
		public unsafe void UnlockSkipButton(string lockName)
		{
			if (this.LockName == null)
			{
				return;
			}
			if (this.LockName != lockName)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "跳过按钮解锁lock不匹配, 忽略";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("curLock", this.LockName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("unlock", lockName);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.LockName = null;
		}

		// Token: 0x06036B27 RID: 224039 RVA: 0x00DDC4FC File Offset: 0x00DDA6FC
		public void ClearSkipLock()
		{
			this.LockName = null;
		}

		// Token: 0x06036B28 RID: 224040 RVA: 0x00DDC508 File Offset: 0x00DDA708
		public void EnableSkipButton(bool enable)
		{
			if (this.LockName != null)
			{
				return;
			}
			if (enable && !ModelBase<PlotModel>.Instance.PlotConfig.CanSkip)
			{
				return;
			}
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
			UUIItem skipItem = this.SkipItem;
			if (skipItem != null)
			{
				skipItem.SetUIActive(flag);
			}
			if (!this.IsActive)
			{
				if (this.IsConfirmBoxShowing)
				{
					this.IsConfirmBoxShowing = false;
					ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
					Action cancelCallback = this.CancelCallback;
					if (cancelCallback == null)
					{
						return;
					}
					cancelCallback();
					return;
				}
				else if (this.IsSummaryViewShowing)
				{
					this.IsSummaryViewShowing = false;
					Singleton<UiManager>.Instance.CloseView(EUiViewName.SummaryPopView, null);
					Action cancelCallback2 = this.CancelCallback;
					if (cancelCallback2 == null)
					{
						return;
					}
					cancelCallback2();
				}
			}
		}

		// Token: 0x06036B29 RID: 224041 RVA: 0x00DDC5D4 File Offset: 0x00DDA7D4
		private void HideSkipButtonAfterConfirm()
		{
			this.IsActive = false;
			UUIItem skipItem = this.SkipItem;
			if (skipItem == null)
			{
				return;
			}
			skipItem.SetUIActive(false);
		}

		// Token: 0x06036B2A RID: 224042 RVA: 0x00DDC5F0 File Offset: 0x00DDA7F0
		private void OnSkipButtonClick()
		{
			if (!this.IsActive)
			{
				return;
			}
			Action clickCallback = this.ClickCallback;
			if (clickCallback != null)
			{
				clickCallback();
			}
			if (!StringUtils.IsEmpty(this.SummaryText))
			{
				SummaryData param = new SummaryData
				{
					Text = this.SummaryText,
					ConfirmFunc = delegate
					{
						if (!this.IsActive)
						{
							return;
						}
						this.IsSummaryViewShowing = false;
						this.HideSkipButtonAfterConfirm();
						Action skipCallback2 = this.SkipCallback;
						if (skipCallback2 == null)
						{
							return;
						}
						skipCallback2();
					},
					CancelFunc = delegate
					{
						if (!this.IsActive)
						{
							return;
						}
						this.IsSummaryViewShowing = false;
						Action cancelCallback = this.CancelCallback;
						if (cancelCallback == null)
						{
							return;
						}
						cancelCallback();
					}
				};
				this.IsSummaryViewShowing = true;
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SummaryPopView, param, null);
				return;
			}
			if (ModelBase<PlotModel>.Instance.PlotConfig.IsSkipConfirmBoxShow)
			{
				this.IsSkipConfirmBoxShowTmp = true;
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SkipPlot);
				if (this.CustomConfirmBoxPopType != null)
				{
					confirmBoxDataNew.CustomPopType = this.CustomConfirmBoxPopType;
				}
				if (!string.IsNullOrEmpty(this.CustomConfirmBoxResourceId))
				{
					confirmBoxDataNew.CustomResourceId = this.CustomConfirmBoxResourceId;
				}
				confirmBoxDataNew.HasToggle = true;
				confirmBoxDataNew.ToggleText = this.ToggleText;
				confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.OnToggle));
				confirmBoxDataNew.AttachView = this.AttachParent;
				confirmBoxDataNew.FunctionMap.Add(1, delegate
				{
					if (!this.IsActive)
					{
						return;
					}
					this.IsConfirmBoxShowing = false;
					Action cancelCallback = this.CancelCallback;
					if (cancelCallback == null)
					{
						return;
					}
					cancelCallback();
				});
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					if (!this.IsActive)
					{
						return;
					}
					ModelBase<PlotModel>.Instance.PlotConfig.IsSkipConfirmBoxShow = this.IsSkipConfirmBoxShowTmp;
					this.IsConfirmBoxShowing = false;
					this.HideSkipButtonAfterConfirm();
					Action skipCallback2 = this.SkipCallback;
					if (skipCallback2 == null)
					{
						return;
					}
					skipCallback2();
				});
				this.IsConfirmBoxShowing = ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			Action skipCallback = this.SkipCallback;
			if (skipCallback == null)
			{
				return;
			}
			skipCallback();
		}

		// Token: 0x06036B2B RID: 224043 RVA: 0x00DDC74E File Offset: 0x00DDA94E
		private void OnToggle(bool isSelectOn)
		{
			if (!this.IsActive)
			{
				return;
			}
			this.IsSkipConfirmBoxShowTmp = !isSelectOn;
		}

		// Token: 0x06036B2C RID: 224044 RVA: 0x00DDC763 File Offset: 0x00DDA963
		public void UpdateImmersiveInputWakeState(bool isWake)
		{
			if (isWake && !this.ImmersiveInputWakeState && this.IsActive)
			{
				UUIItem skipItem = this.SkipItem;
				if (skipItem != null)
				{
					skipItem.SetUIActive(true);
				}
			}
			this.ImmersiveInputWakeState = isWake;
		}

		// Token: 0x0401F811 RID: 129041
		private bool IsActive;

		// Token: 0x0401F812 RID: 129042
		private UUIItem SkipItem;

		// Token: 0x0401F813 RID: 129043
		private UUIButtonComponent SkipButton;

		// Token: 0x0401F814 RID: 129044
		private Action SkipCallback;

		// Token: 0x0401F815 RID: 129045
		private Action ClickCallback;

		// Token: 0x0401F816 RID: 129046
		private Action CancelCallback;

		// Token: 0x0401F817 RID: 129047
		private readonly string ToggleText;

		// Token: 0x0401F818 RID: 129048
		private bool IsSkipConfirmBoxShowTmp = true;

		// Token: 0x0401F819 RID: 129049
		private UiViewBase AttachParent;

		// Token: 0x0401F81A RID: 129050
		private string SummaryText;

		// Token: 0x0401F81B RID: 129051
		private bool IsConfirmBoxShowing;

		// Token: 0x0401F81C RID: 129052
		private bool IsSummaryViewShowing;

		// Token: 0x0401F81D RID: 129053
		private bool ImmersiveInputWakeState = true;

		// Token: 0x0401F81E RID: 129054
		private readonly EUiBehaviourPopType? CustomConfirmBoxPopType;

		// Token: 0x0401F81F RID: 129055
		private readonly string CustomConfirmBoxResourceId;

		// Token: 0x0401F820 RID: 129056
		private string LockName;
	}
}
