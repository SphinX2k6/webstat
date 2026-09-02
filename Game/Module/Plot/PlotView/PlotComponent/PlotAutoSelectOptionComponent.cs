using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053E0 RID: 21472
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotAutoSelectOptionComponent
	{
		// Token: 0x06036D16 RID: 224534 RVA: 0x00DE6E24 File Offset: 0x00DE5024
		[NullableContext(1)]
		public void Init(IPlotAutoSelectOptionComponentContext context)
		{
			this.OptionLimitBar = context.OptionLimitBar;
			this.AutoSelectTimeBar = context.AutoSelectTimeBar;
			this.ImportantList = context.ImportantList;
			this.ImportantOptionTipsIcon = context.ImportantOptionTipsIcon;
			this.ImportantOptionTipsText = context.ImportantOptionTipsText;
			this.GetCurrentContentDelegate = context.GetCurrentContentDelegate;
			this.GetSelectedOptionDelegate = context.GetSelectedOptionDelegate;
			this.GetOptionItemsDelegate = context.GetOptionItemsDelegate;
			this.GetAudioRemainingTimeDelegate = context.GetAudioRemainingTimeDelegate;
			this.GetAutoSelectExtraWaitTimeDelegate = context.GetAutoSelectExtraWaitTimeDelegate;
			this.SelectOptionByIndexDelegate = context.SelectOptionByIndexDelegate;
			this.SetTextureByPathDelegate = context.SetTextureByPathDelegate;
			this.RefreshAutoPlayButtonDelegate = context.RefreshAutoPlayButtonDelegate;
			this.Clear();
		}

		// Token: 0x06036D17 RID: 224535 RVA: 0x00DE6ED4 File Offset: 0x00DE50D4
		public static PlotOptionItem GetDefaultSelectedOptionItem([Nullable(new byte[]
		{
			2,
			1
		})] PlotOptionItem[] optionItems, ITalkItem content)
		{
			if (optionItems == null || optionItems.Length == 0)
			{
				return null;
			}
			List<PlotOptionItem> list = new List<PlotOptionItem>();
			foreach (PlotOptionItem plotOptionItem in optionItems)
			{
				if (plotOptionItem.GetActive())
				{
					list.Add(plotOptionItem);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			foreach (PlotOptionItem plotOptionItem2 in list)
			{
				if (!plotOptionItem2.CheckToggleGray())
				{
					return plotOptionItem2;
				}
			}
			list.Sort((PlotOptionItem a, PlotOptionItem b) => a.OptionIndex - b.OptionIndex);
			int num = (content != null) ? Math.Max(0, ControllerBase<FlowController>.Instance.GetRecommendedOption(content)) : list[0].OptionIndex;
			foreach (PlotOptionItem plotOptionItem3 in list)
			{
				if (plotOptionItem3.OptionIndex >= num)
				{
					return plotOptionItem3;
				}
			}
			return list[0];
		}

		// Token: 0x06036D18 RID: 224536 RVA: 0x00DE7008 File Offset: 0x00DE5208
		public void Clear()
		{
			this.IsOptionShowing = false;
			this.ResetCountdown(true);
			this.HideImportantTips();
		}

		// Token: 0x06036D19 RID: 224537 RVA: 0x00DE7020 File Offset: 0x00DE5220
		public void OnOptionsShow()
		{
			this.IsOptionShowing = true;
			this.ResetCountdown(true);
			this.HideImportantTips();
			Func<ITalkItem> getCurrentContentDelegate = this.GetCurrentContentDelegate;
			ITalkItem talkItem = (getCurrentContentDelegate != null) ? getCurrentContentDelegate() : null;
			if (((talkItem != null) ? talkItem.Options : null) == null || talkItem.Options.Count == 0)
			{
				return;
			}
			if (this.TryStartTimeLimitCountdown(talkItem))
			{
				return;
			}
			if (this.TryShowDisableAutoSelectTips(talkItem))
			{
				return;
			}
			this.TryStartAutoSelectCountdown(talkItem);
		}

		// Token: 0x06036D1A RID: 224538 RVA: 0x00DE708C File Offset: 0x00DE528C
		public void OnOptionSelected()
		{
			this.IsOptionShowing = false;
			this.FinishCountdown(false);
			this.RefreshImmersiveMousePause();
		}

		// Token: 0x06036D1B RID: 224539 RVA: 0x00DE70A4 File Offset: 0x00DE52A4
		public void OnAutoPlayStateChanged()
		{
			if (!this.IsOptionShowing)
			{
				return;
			}
			this.RefreshImmersiveMousePause();
			if (this.CountdownMode == PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.TimeLimit)
			{
				return;
			}
			this.ResetCountdown(true);
			this.HideImportantTips();
			Func<ITalkItem> getCurrentContentDelegate = this.GetCurrentContentDelegate;
			ITalkItem talkItem = (getCurrentContentDelegate != null) ? getCurrentContentDelegate() : null;
			if (talkItem == null)
			{
				return;
			}
			if (talkItem.TimeLimitOptionGroup != null)
			{
				return;
			}
			if (this.TryShowDisableAutoSelectTips(talkItem))
			{
				return;
			}
			this.TryStartAutoSelectCountdown(talkItem);
		}

		// Token: 0x06036D1C RID: 224540 RVA: 0x00DE7109 File Offset: 0x00DE5309
		public void OnImmersiveInputStateChange()
		{
			this.RefreshImmersiveMousePause();
		}

		// Token: 0x06036D1D RID: 224541 RVA: 0x00DE7114 File Offset: 0x00DE5314
		public void OnSelectedOptionChanged()
		{
			if (this.CountdownMode != PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.AutoSelect)
			{
				return;
			}
			Func<ITalkItem> getCurrentContentDelegate = this.GetCurrentContentDelegate;
			ITalkItem talkItem = (getCurrentContentDelegate != null) ? getCurrentContentDelegate() : null;
			if (talkItem == null)
			{
				return;
			}
			this.TryRefreshAutoSelectCountdownOption(talkItem);
		}

		// Token: 0x06036D1E RID: 224542 RVA: 0x00DE714C File Offset: 0x00DE534C
		public void OnTick(float delta, bool isMute)
		{
			if (this.CountdownMode == PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.None || isMute)
			{
				return;
			}
			this.OptionLimitTimeDuration += delta;
			this.RefreshAutoSelectCountdownByAudioRemaining();
			UUISliderComponent currentCountdownBar = this.GetCurrentCountdownBar();
			if (currentCountdownBar != null)
			{
				currentCountdownBar.SetValue(Math.Max(0f, 1f - this.OptionLimitTimeDuration / this.OptionLimitTime), true);
			}
			if (this.OptionLimitTimeDuration >= this.OptionLimitTime)
			{
				this.FinishCountdown(true);
			}
		}

		// Token: 0x06036D1F RID: 224543 RVA: 0x00DE71C0 File Offset: 0x00DE53C0
		[NullableContext(1)]
		private unsafe bool TryStartTimeLimitCountdown(ITalkItem content)
		{
			if (content.TimeLimitOptionGroup == null)
			{
				return false;
			}
			if (content.TimeLimitOptionGroup.Style.Type != ETimeLimitOptionGroupStyle.Default)
			{
				return false;
			}
			ITimeLimitOptionGroupDefault style = content.TimeLimitOptionGroup.Style;
			if (style.TimeLimit <= 0f || style.TimeoutOptionIndex >= content.Options.Count || style.TimeoutOptionIndex < 0)
			{
				ControllerBase<FlowController>.Instance.LogError("限时选项配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotAutoSelectOption] 限时选项配置错误";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", content.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("timeoutOptionIndex", style.TimeoutOptionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("timeLimit", style.TimeLimit);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			this.StartCountdown(PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.TimeLimit, style.TimeoutOptionIndex, style.TimeLimit * 1000f);
			return true;
		}

		// Token: 0x06036D20 RID: 224544 RVA: 0x00DE72E0 File Offset: 0x00DE54E0
		[NullableContext(1)]
		private bool TryShowDisableAutoSelectTips(ITalkItem content)
		{
			ITalkItemDisableAutoSelectOptionGroup disableAutoSelectConfig = this.GetDisableAutoSelectConfig(content);
			if (disableAutoSelectConfig == null)
			{
				return false;
			}
			this.ShowImportantTips(disableAutoSelectConfig);
			return true;
		}

		// Token: 0x06036D21 RID: 224545 RVA: 0x00DE7304 File Offset: 0x00DE5504
		[NullableContext(1)]
		private bool TryStartAutoSelectCountdown(ITalkItem content)
		{
			if (!this.IsAutoSelectEnabled(content))
			{
				return false;
			}
			PlotOptionItem autoSelectOptionItem = this.GetAutoSelectOptionItem(content);
			if (autoSelectOptionItem == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotAutoSelectOption] 找不到可自动选择的选项";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", content.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			float autoSelectOptionCharPerSec = ModelBase<PlotModel>.Instance.PlotGlobalConfig.AutoSelectOptionCharPerSec;
			if (autoSelectOptionCharPerSec <= 0f)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Plot;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "[PlotAutoSelectOption] 自动选择选项速度配置错误";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AutoSelectOptionCharPerSec", autoSelectOptionCharPerSec);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			float val = Math.Max((float)this.GetTotalDisplayCharLengthOfVisibleOptions() / autoSelectOptionCharPerSec * 1000f, 3000f);
			float audioRemainingTime = this.GetAudioRemainingTime();
			float autoSelectExtraWaitTime = this.GetAutoSelectExtraWaitTime();
			float limitTime = Math.Max(val, audioRemainingTime) + autoSelectExtraWaitTime;
			this.StartCountdown(PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.AutoSelect, autoSelectOptionItem.OptionIndex, limitTime);
			return true;
		}

		// Token: 0x06036D22 RID: 224546 RVA: 0x00DE73E4 File Offset: 0x00DE55E4
		[NullableContext(1)]
		private bool TryRefreshAutoSelectCountdownOption(ITalkItem content)
		{
			if (!this.IsAutoSelectEnabled(content))
			{
				return false;
			}
			PlotOptionItem autoSelectOptionItem = this.GetAutoSelectOptionItem(content);
			if (autoSelectOptionItem == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotAutoSelectOption] 找不到可自动选择的选项";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", content.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.CountdownOptionIndex = autoSelectOptionItem.OptionIndex;
			return true;
		}

		// Token: 0x06036D23 RID: 224547 RVA: 0x00DE7448 File Offset: 0x00DE5648
		private void StartCountdown(PlotAutoSelectOptionComponent.EPlotOptionCountdownMode mode, int optionIndex, float limitTime)
		{
			this.HideImportantTips();
			this.HideCountdownBars();
			this.CountdownMode = mode;
			this.CountdownOptionIndex = optionIndex;
			this.OptionLimitTime = limitTime;
			this.OptionLimitTimeDuration = 0f;
			UUISliderComponent countdownBar = this.GetCountdownBar(mode);
			if (countdownBar != null)
			{
				countdownBar.GetRootComponent().SetUIActive(true);
			}
			if (countdownBar != null)
			{
				countdownBar.SetValue(1f, true);
			}
			this.RefreshImmersiveMousePause();
		}

		// Token: 0x06036D24 RID: 224548 RVA: 0x00DE74B4 File Offset: 0x00DE56B4
		private void FinishCountdown(bool needSelect)
		{
			if (this.CountdownMode == PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.None)
			{
				return;
			}
			PlotAutoSelectOptionComponent.EPlotOptionCountdownMode countdownMode = this.CountdownMode;
			int countdownOptionIndex = this.CountdownOptionIndex;
			Func<ITalkItem> getCurrentContentDelegate = this.GetCurrentContentDelegate;
			ITalkItem content = (getCurrentContentDelegate != null) ? getCurrentContentDelegate() : null;
			this.ResetCountdown(true);
			bool flag = false;
			if (needSelect)
			{
				if (countdownMode == PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.AutoSelect)
				{
					PlotOptionItem plotOptionItem = null;
					Func<PlotOptionItem[]> getOptionItemsDelegate = this.GetOptionItemsDelegate;
					PlotOptionItem[] array = (getOptionItemsDelegate != null) ? getOptionItemsDelegate() : null;
					if (array != null)
					{
						foreach (PlotOptionItem plotOptionItem2 in array)
						{
							if (plotOptionItem2.OptionIndex == countdownOptionIndex)
							{
								plotOptionItem = plotOptionItem2;
								break;
							}
						}
					}
					if (plotOptionItem != null)
					{
						if (!plotOptionItem.IsOptionConditionSatisfied())
						{
							this.PauseAutoSelectByLockedOption(content, countdownOptionIndex);
						}
						else
						{
							plotOptionItem.OptionClick(new bool?(true));
							flag = true;
						}
					}
					else if (this.IsConfiguredOptionLocked(content, countdownOptionIndex))
					{
						this.PauseAutoSelectByLockedOption(content, countdownOptionIndex);
					}
					else
					{
						Action<int> selectOptionByIndexDelegate = this.SelectOptionByIndexDelegate;
						if (selectOptionByIndexDelegate != null)
						{
							selectOptionByIndexDelegate(countdownOptionIndex);
						}
						flag = true;
					}
				}
				else
				{
					this.SelectTimeLimitOption(countdownOptionIndex);
					flag = true;
				}
				if (flag)
				{
					this.IsOptionShowing = false;
					this.RefreshImmersiveMousePause();
				}
			}
		}

		// Token: 0x06036D25 RID: 224549 RVA: 0x00DE75B8 File Offset: 0x00DE57B8
		private void SelectTimeLimitOption(int optionIndex)
		{
			PlotOptionItem plotOptionItem = null;
			Func<PlotOptionItem[]> getOptionItemsDelegate = this.GetOptionItemsDelegate;
			PlotOptionItem[] array = (getOptionItemsDelegate != null) ? getOptionItemsDelegate() : null;
			if (array != null)
			{
				foreach (PlotOptionItem plotOptionItem2 in array)
				{
					if (plotOptionItem2.OptionIndex == optionIndex)
					{
						plotOptionItem = plotOptionItem2;
						break;
					}
				}
			}
			if (plotOptionItem != null)
			{
				plotOptionItem.OptionClick(new bool?(true));
				return;
			}
			Func<ITalkItem> getCurrentContentDelegate = this.GetCurrentContentDelegate;
			ITalkItem talkItem = (getCurrentContentDelegate != null) ? getCurrentContentDelegate() : null;
			if (talkItem == null)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.MarkGrayOption(talkItem.Id, optionIndex);
			Action<int> selectOptionByIndexDelegate = this.SelectOptionByIndexDelegate;
			if (selectOptionByIndexDelegate == null)
			{
				return;
			}
			selectOptionByIndexDelegate(optionIndex);
		}

		// Token: 0x06036D26 RID: 224550 RVA: 0x00DE764F File Offset: 0x00DE584F
		private void ResetCountdown(bool hideBar)
		{
			this.CountdownMode = PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.None;
			this.OptionLimitTime = 0f;
			this.OptionLimitTimeDuration = 0f;
			this.CountdownOptionIndex = -1;
			if (hideBar)
			{
				this.HideCountdownBars();
			}
			this.RefreshImmersiveMousePause();
		}

		// Token: 0x06036D27 RID: 224551 RVA: 0x00DE7684 File Offset: 0x00DE5884
		private UUISliderComponent GetCurrentCountdownBar()
		{
			return this.GetCountdownBar(this.CountdownMode);
		}

		// Token: 0x06036D28 RID: 224552 RVA: 0x00DE7692 File Offset: 0x00DE5892
		private UUISliderComponent GetCountdownBar(PlotAutoSelectOptionComponent.EPlotOptionCountdownMode mode)
		{
			if (mode == PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.AutoSelect)
			{
				return this.AutoSelectTimeBar ?? this.OptionLimitBar;
			}
			return this.OptionLimitBar;
		}

		// Token: 0x06036D29 RID: 224553 RVA: 0x00DE76AF File Offset: 0x00DE58AF
		private void HideCountdownBars()
		{
			UUISliderComponent optionLimitBar = this.OptionLimitBar;
			if (optionLimitBar != null)
			{
				optionLimitBar.GetRootComponent().SetUIActive(false);
			}
			UUISliderComponent autoSelectTimeBar = this.AutoSelectTimeBar;
			if (autoSelectTimeBar == null)
			{
				return;
			}
			autoSelectTimeBar.GetRootComponent().SetUIActive(false);
		}

		// Token: 0x06036D2A RID: 224554 RVA: 0x00DE76E0 File Offset: 0x00DE58E0
		private void RefreshImmersiveMousePause()
		{
			bool flag = this.ShouldPauseImmersiveMouseForAutoOption();
			if (this.IsImmersiveMousePaused == flag)
			{
				return;
			}
			this.IsImmersiveMousePaused = flag;
			if (flag)
			{
				Singleton<InputManager>.Instance.PauseImmersiveMouseMode(EImmersiveMouseModeReason.PlotAutoSelectOptionHover, true, true, true);
				return;
			}
			Singleton<InputManager>.Instance.ResumeImmersiveMouseMode(EImmersiveMouseModeReason.PlotAutoSelectOptionHover);
		}

		// Token: 0x06036D2B RID: 224555 RVA: 0x00DE772A File Offset: 0x00DE592A
		private bool ShouldPauseImmersiveMouseForAutoOption()
		{
			return this.IsOptionShowing && ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState == EAutoPlayState.Auto && Singleton<InputManager>.Instance.GetImmersiveInputWakeState() && this.HasVisibleOptionItem();
		}

		// Token: 0x06036D2C RID: 224556 RVA: 0x00DE775C File Offset: 0x00DE595C
		private bool HasVisibleOptionItem()
		{
			Func<PlotOptionItem[]> getOptionItemsDelegate = this.GetOptionItemsDelegate;
			PlotOptionItem[] array = (getOptionItemsDelegate != null) ? getOptionItemsDelegate() : null;
			if (array == null)
			{
				return false;
			}
			PlotOptionItem[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].GetActive())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06036D2D RID: 224557 RVA: 0x00DE77A0 File Offset: 0x00DE59A0
		private int GetTotalDisplayCharLengthOfVisibleOptions()
		{
			Func<PlotOptionItem[]> getOptionItemsDelegate = this.GetOptionItemsDelegate;
			PlotOptionItem[] array = (getOptionItemsDelegate != null) ? getOptionItemsDelegate() : null;
			if (array == null || array.Length == 0)
			{
				return 0;
			}
			int num = 0;
			foreach (PlotOptionItem plotOptionItem in array)
			{
				if (plotOptionItem.GetActive())
				{
					num += plotOptionItem.GetDisplayCharLength();
				}
			}
			return num;
		}

		// Token: 0x06036D2E RID: 224558 RVA: 0x00DE77F4 File Offset: 0x00DE59F4
		private float GetAudioRemainingTime()
		{
			float val = 0f;
			Func<float> getAudioRemainingTimeDelegate = this.GetAudioRemainingTimeDelegate;
			return Math.Max(val, (getAudioRemainingTimeDelegate != null) ? getAudioRemainingTimeDelegate() : 0f);
		}

		// Token: 0x06036D2F RID: 224559 RVA: 0x00DE7816 File Offset: 0x00DE5A16
		private float GetAutoSelectExtraWaitTime()
		{
			float val = 0f;
			Func<float> getAutoSelectExtraWaitTimeDelegate = this.GetAutoSelectExtraWaitTimeDelegate;
			return Math.Max(val, (getAutoSelectExtraWaitTimeDelegate != null) ? getAutoSelectExtraWaitTimeDelegate() : 0f);
		}

		// Token: 0x06036D30 RID: 224560 RVA: 0x00DE7838 File Offset: 0x00DE5A38
		private void RefreshAutoSelectCountdownByAudioRemaining()
		{
			if (this.CountdownMode != PlotAutoSelectOptionComponent.EPlotOptionCountdownMode.AutoSelect)
			{
				return;
			}
			float audioRemainingTime = this.GetAudioRemainingTime();
			if (audioRemainingTime <= 0f)
			{
				return;
			}
			float num = this.OptionLimitTime - this.OptionLimitTimeDuration;
			float num2 = audioRemainingTime + this.GetAutoSelectExtraWaitTime();
			if (num2 <= num)
			{
				return;
			}
			this.OptionLimitTime = this.OptionLimitTimeDuration + num2;
		}

		// Token: 0x06036D31 RID: 224561 RVA: 0x00DE788C File Offset: 0x00DE5A8C
		private PlotOptionItem GetAutoSelectOptionItem(ITalkItem content)
		{
			Func<PlotOptionItem> getSelectedOptionDelegate = this.GetSelectedOptionDelegate;
			PlotOptionItem plotOptionItem = (getSelectedOptionDelegate != null) ? getSelectedOptionDelegate() : null;
			if (plotOptionItem != null && plotOptionItem.GetActive() && !plotOptionItem.CheckToggleGray())
			{
				return plotOptionItem;
			}
			Func<PlotOptionItem[]> getOptionItemsDelegate = this.GetOptionItemsDelegate;
			return PlotAutoSelectOptionComponent.GetDefaultSelectedOptionItem((getOptionItemsDelegate != null) ? getOptionItemsDelegate() : null, content);
		}

		// Token: 0x06036D32 RID: 224562 RVA: 0x00DE78DC File Offset: 0x00DE5ADC
		private bool IsConfiguredOptionLocked(ITalkItem content, int optionIndex)
		{
			if (((content != null) ? content.Options : null) == null || optionIndex < 0 || optionIndex >= content.Options.Count)
			{
				return false;
			}
			ITalkOption option = content.Options[optionIndex];
			return !ModelBase<PlotModel>.Instance.CheckOptionCondition(option, optionIndex, content);
		}

		// Token: 0x06036D33 RID: 224563 RVA: 0x00DE7928 File Offset: 0x00DE5B28
		private void PauseAutoSelectByLockedOption(ITalkItem content, int optionIndex)
		{
			PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
			plotConfig.AutoPlayState = EAutoPlayState.Manual;
			plotConfig.AutoPlayStateCache = EAutoPlayState.Manual;
			this.ResetCountdown(true);
			this.HideImportantTips();
			Action refreshAutoPlayButtonDelegate = this.RefreshAutoPlayButtonDelegate;
			if (refreshAutoPlayButtonDelegate != null)
			{
				refreshAutoPlayButtonDelegate();
			}
			ITalkOption talkOption = null;
			if (((content != null) ? content.Options : null) != null && optionIndex >= 0 && optionIndex < content.Options.Count)
			{
				talkOption = content.Options[optionIndex];
			}
			string text;
			if (talkOption != null)
			{
				IOptionLockTip optionLockTip = talkOption.OptionLockTip;
				if (((optionLockTip != null) ? optionLockTip.TidHintText : null) != null)
				{
					text = Singleton<PublicUtil>.Instance.GetConfigTextByKey(talkOption.OptionLockTip.TidHintText);
					goto IL_AE;
				}
			}
			text = (ConfigMultiTextLang.GetLocalTextNew("LockedOptionPauseAutoSelection", null) ?? "LockedOptionPauseAutoSelection");
			IL_AE:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(text);
		}

		// Token: 0x06036D34 RID: 224564 RVA: 0x00DE79F0 File Offset: 0x00DE5BF0
		[NullableContext(1)]
		private bool IsAutoSelectEnabled(ITalkItem content)
		{
			return ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState == EAutoPlayState.Auto && content.Type.GetValueOrDefault() != ETalkItemType.SystemOption;
		}

		// Token: 0x06036D35 RID: 224565 RVA: 0x00DE7A28 File Offset: 0x00DE5C28
		[NullableContext(1)]
		[return: Nullable(2)]
		private ITalkItemDisableAutoSelectOptionGroup GetDisableAutoSelectConfig(ITalkItem content)
		{
			ITalkItemDialog talkItemDialog = content as ITalkItemDialog;
			if (talkItemDialog != null)
			{
				ITalkItemAutoPlayConfig autoPlayConfig = talkItemDialog.AutoPlayConfig;
				if (autoPlayConfig == null)
				{
					return null;
				}
				return autoPlayConfig.DisableAutoSelectOptionGroup;
			}
			else
			{
				ITalkItemOption talkItemOption = content as ITalkItemOption;
				if (talkItemOption == null)
				{
					return null;
				}
				ITalkItemAutoPlayConfig autoPlayConfig2 = talkItemOption.AutoPlayConfig;
				if (autoPlayConfig2 == null)
				{
					return null;
				}
				return autoPlayConfig2.DisableAutoSelectOptionGroup;
			}
		}

		// Token: 0x06036D36 RID: 224566 RVA: 0x00DE7A70 File Offset: 0x00DE5C70
		[NullableContext(1)]
		private void ShowImportantTips(ITalkItemDisableAutoSelectOptionGroup config)
		{
			string text = StringUtils.IsEmpty(config.TextKey) ? "ImportantSelectionDefault" : config.TextKey;
			UUIText importantOptionTipsText = this.ImportantOptionTipsText;
			if (importantOptionTipsText != null)
			{
				importantOptionTipsText.SetText(ConfigMultiTextLang.GetLocalTextNew(text, null) ?? text, true);
			}
			int? iconId = config.IconId;
			string text2;
			if (iconId != null)
			{
				int valueOrDefault = iconId.GetValueOrDefault();
				if (valueOrDefault != 0)
				{
					TalkOptionIcon? talkOptionIcon;
					text2 = (((ConfigTalkOptionIconById.GetConfig(valueOrDefault, true) != null) ? talkOptionIcon.GetValueOrDefault().Icon : null) ?? "/Game/Aki/UI/UIResources/Common/Image/InteractionIcon/T_InteractionExclamation.T_InteractionExclamation");
					goto IL_89;
				}
			}
			text2 = "/Game/Aki/UI/UIResources/Common/Image/InteractionIcon/T_InteractionExclamation.T_InteractionExclamation";
			IL_89:
			string arg = text2;
			if (this.ImportantOptionTipsIcon != null)
			{
				Action<string, UUITexture> setTextureByPathDelegate = this.SetTextureByPathDelegate;
				if (setTextureByPathDelegate != null)
				{
					setTextureByPathDelegate(arg, this.ImportantOptionTipsIcon);
				}
			}
			UUIItem importantList = this.ImportantList;
			if (importantList == null)
			{
				return;
			}
			importantList.SetUIActive(true);
		}

		// Token: 0x06036D37 RID: 224567 RVA: 0x00DE7B38 File Offset: 0x00DE5D38
		private void HideImportantTips()
		{
			UUIItem importantList = this.ImportantList;
			if (importantList == null)
			{
				return;
			}
			importantList.SetUIActive(false);
		}

		// Token: 0x0401F8FE RID: 129278
		private const int INVALID_OPTION_INDEX = -1;

		// Token: 0x0401F8FF RID: 129279
		private const float MIN_AUTO_SELECT_WAIT_TIME = 3000f;

		// Token: 0x0401F900 RID: 129280
		[Nullable(1)]
		private const string DEFAULT_IMPORTANT_TEXT_KEY = "ImportantSelectionDefault";

		// Token: 0x0401F901 RID: 129281
		[Nullable(1)]
		private const string DEFAULT_IMPORTANT_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Image/InteractionIcon/T_InteractionExclamation.T_InteractionExclamation";

		// Token: 0x0401F902 RID: 129282
		[Nullable(1)]
		private const string LOCKED_OPTION_TIPS_TEXT_ID = "LockedOptionPauseAutoSelection";

		// Token: 0x0401F903 RID: 129283
		private UUISliderComponent OptionLimitBar;

		// Token: 0x0401F904 RID: 129284
		private UUISliderComponent AutoSelectTimeBar;

		// Token: 0x0401F905 RID: 129285
		private UUIItem ImportantList;

		// Token: 0x0401F906 RID: 129286
		private UUITexture ImportantOptionTipsIcon;

		// Token: 0x0401F907 RID: 129287
		private UUIText ImportantOptionTipsText;

		// Token: 0x0401F908 RID: 129288
		private Func<ITalkItem> GetCurrentContentDelegate;

		// Token: 0x0401F909 RID: 129289
		private Func<PlotOptionItem> GetSelectedOptionDelegate;

		// Token: 0x0401F90A RID: 129290
		[Nullable(new byte[]
		{
			2,
			2,
			1
		})]
		private Func<PlotOptionItem[]> GetOptionItemsDelegate;

		// Token: 0x0401F90B RID: 129291
		private Func<float> GetAudioRemainingTimeDelegate;

		// Token: 0x0401F90C RID: 129292
		private Func<float> GetAutoSelectExtraWaitTimeDelegate;

		// Token: 0x0401F90D RID: 129293
		private Action<int> SelectOptionByIndexDelegate;

		// Token: 0x0401F90E RID: 129294
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<string, UUITexture> SetTextureByPathDelegate;

		// Token: 0x0401F90F RID: 129295
		private Action RefreshAutoPlayButtonDelegate;

		// Token: 0x0401F910 RID: 129296
		private PlotAutoSelectOptionComponent.EPlotOptionCountdownMode CountdownMode;

		// Token: 0x0401F911 RID: 129297
		private float OptionLimitTime;

		// Token: 0x0401F912 RID: 129298
		private float OptionLimitTimeDuration;

		// Token: 0x0401F913 RID: 129299
		private int CountdownOptionIndex = -1;

		// Token: 0x0401F914 RID: 129300
		private bool IsOptionShowing;

		// Token: 0x0401F915 RID: 129301
		private bool IsImmersiveMousePaused;

		// Token: 0x0200B388 RID: 45960
		[NullableContext(0)]
		private enum EPlotOptionCountdownMode
		{
			// Token: 0x040379A3 RID: 227747
			None,
			// Token: 0x040379A4 RID: 227748
			TimeLimit,
			// Token: 0x040379A5 RID: 227749
			AutoSelect
		}
	}
}
