using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053CC RID: 21452
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotTextCommonLogic : IStaticVariableResetter
	{
		// Token: 0x17008DB4 RID: 36276
		// (get) Token: 0x06036B37 RID: 224055 RVA: 0x00DDC8FA File Offset: 0x00DDAAFA
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public PlotOptionItem[] Options
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				GenericLayout<PlotOptionItem, object> optionLayout = this.OptionLayout;
				List<PlotOptionItem> list = (optionLayout != null) ? optionLayout.GetLayoutItemList() : null;
				if (list == null)
				{
					return null;
				}
				return list.ToArray();
			}
		}

		// Token: 0x17008DB5 RID: 36277
		// (get) Token: 0x06036B38 RID: 224056 RVA: 0x00DDC919 File Offset: 0x00DDAB19
		public bool HasOptions
		{
			get
			{
				return this.CurrentContent != null && this.CurrentContent.Options != null && this.CurrentContent.Options.Count != 0;
			}
		}

		// Token: 0x17008DB6 RID: 36278
		// (get) Token: 0x06036B39 RID: 224057 RVA: 0x00DDC948 File Offset: 0x00DDAB48
		public PawnInteractController InteractController
		{
			get
			{
				PlotView plotView = this.Parent as PlotView;
				if (plotView != null)
				{
					return plotView.InteractController;
				}
				return null;
			}
		}

		// Token: 0x06036B3A RID: 224058 RVA: 0x00DDC96C File Offset: 0x00DDAB6C
		public PlotTextCommonLogic([Nullable(1)] UUIItem plotItem, [Nullable(1)] UUIText npcName, [Nullable(1)] UUIText npcTitle, [Nullable(1)] UUIText plotContent, [Nullable(1)] UUIItem lineItem, UUIScrollViewComponent textScrollView = null, ISimulatePlot parent = null, UUILayoutBase layOutBase = null, UUIItem optionItemBase = null, UUISliderComponent optionLimitBar = null, UiBehaviorLevelSequence uiViewSequence = null, UUIItem blockOption = null, UUIItem optionAdjustItem = null, UUIItem importantList = null, UUITexture importantOptionTipsIcon = null, UUIText importantOptionTipsText = null, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] Action<string, UUITexture> setTextureByPathDelegate = null, UUISliderComponent autoSelectTimeBar = null, Action refreshAutoPlayButtonDelegate = null, UUIItem pnlLayoutTwo = null)
		{
			this.PlotItem = plotItem;
			this.NpcName = npcName;
			this.NpcTitle = npcTitle;
			this.PlotContent = plotContent;
			this.LineItem = lineItem;
			this.TextScrollView = textScrollView;
			this.Parent = parent;
			this.LayOutBase = layOutBase;
			this.OptionItemBase = optionItemBase;
			this.OptionLimitBar = optionLimitBar;
			this.AutoSelectTimeBar = autoSelectTimeBar;
			this.UiViewSequence = uiViewSequence;
			this.BlockOption = blockOption;
			this.OptionAdjustItem = optionAdjustItem;
			this.PnlLayoutTwo = pnlLayoutTwo;
			this.PlotItem.SetUIActive(false);
			this.LineItem.SetUIActive(false);
			this.SubtitleAnimation = (this.PlotContent.GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			this.SubtitleAnimDataComp = (this.PlotContent.GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation);
			this.CurLang = Singleton<LanguageSystem>.Instance.PackageAudio;
			UUIScrollViewComponent textScrollView2 = this.TextScrollView;
			float? num;
			if (textScrollView2 == null)
			{
				num = null;
			}
			else
			{
				UUIItem uuiitem = textScrollView2.RootUIComp.Get();
				num = ((uuiitem != null) ? new float?(uuiitem.GetHeight()) : null);
			}
			float? num2 = num;
			this.TextScrollViewPrefabHeight = num2.GetValueOrDefault(174f);
			this.IsOptionShow = false;
			UUISliderComponent optionLimitBar2 = this.OptionLimitBar;
			if (optionLimitBar2 != null)
			{
				optionLimitBar2.GetRootComponent().SetUIActive(false);
			}
			UUISliderComponent autoSelectTimeBar2 = this.AutoSelectTimeBar;
			if (autoSelectTimeBar2 != null)
			{
				autoSelectTimeBar2.GetRootComponent().SetUIActive(false);
			}
			UUIItem blockOption2 = this.BlockOption;
			if (blockOption2 != null)
			{
				blockOption2.SetUIActive(false);
			}
			if (this.LayOutBase != null && this.OptionItemBase != null)
			{
				this.OptionItemBase.SetUIActive(false);
				this.LayOutBase.RootUIComp.Get().SetAlpha(1f);
				this.OptionLayout = new GenericLayout<PlotOptionItem, object>(this.LayOutBase, new Func<PlotOptionItem>(this.InitOptionItem), this.OptionItemBase.GetOwner() as AUIBaseActor, false, true);
				this.OptionLayout.SetActive(false);
			}
			UUIItem pnlLayoutTwo2 = this.PnlLayoutTwo;
			if (pnlLayoutTwo2 != null)
			{
				pnlLayoutTwo2.SetUIActive(false);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 != null)
			{
				uiViewSequence2.AddSequenceFinishEvent("ChoiceClose", new Action<string>(this.OptionsLayoutHide), false);
			}
			this.NeedSelectedState = (this.Parent is PlotView);
			this.AutoSelectOptionComponent.Init(new PlotAutoSelectOptionComponentContext
			{
				OptionLimitBar = this.OptionLimitBar,
				AutoSelectTimeBar = this.AutoSelectTimeBar,
				ImportantList = importantList,
				ImportantOptionTipsIcon = importantOptionTipsIcon,
				ImportantOptionTipsText = importantOptionTipsText,
				GetCurrentContentDelegate = (() => this.CurrentContent),
				GetSelectedOptionDelegate = (() => this.SelectedPlotOptionItem),
				GetOptionItemsDelegate = (() => this.Options),
				GetAudioRemainingTimeDelegate = new Func<float>(this.GetCurrentAudioRemainingTime),
				GetAutoSelectExtraWaitTimeDelegate = new Func<float>(this.GetAutoSelectExtraWaitTime),
				SelectOptionByIndexDelegate = new Action<int>(this.SelectOptionByIndex),
				SetTextureByPathDelegate = setTextureByPathDelegate,
				RefreshAutoPlayButtonDelegate = refreshAutoPlayButtonDelegate
			});
		}

		// Token: 0x06036B3B RID: 224059 RVA: 0x00DDCCDC File Offset: 0x00DDAEDC
		[NullableContext(1)]
		private void OptionsLayoutHide(string _)
		{
			if (this.IsOptionShow)
			{
				return;
			}
			GenericLayout<PlotOptionItem, object> optionLayout = this.OptionLayout;
			if (optionLayout != null)
			{
				optionLayout.SetActive(false);
			}
			UUIItem pnlLayoutTwo = this.PnlLayoutTwo;
			if (pnlLayoutTwo != null)
			{
				pnlLayoutTwo.SetUIActive(false);
			}
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

		// Token: 0x06036B3C RID: 224060 RVA: 0x00DDCD44 File Offset: 0x00DDAF44
		public void OnBeforeHide()
		{
			this.ClearPlotContent(false);
			TimerHandle blockOptionTimer = this.BlockOptionTimer;
			if (blockOptionTimer != null)
			{
				blockOptionTimer.Remove();
			}
			this.BlockOptionTimer = null;
			this.AutoSelectOptionComponent.Clear();
			GenericLayout<PlotOptionItem, object> optionLayout = this.OptionLayout;
			if (optionLayout != null)
			{
				optionLayout.SetActive(false);
			}
			UUIItem pnlLayoutTwo = this.PnlLayoutTwo;
			if (pnlLayoutTwo == null)
			{
				return;
			}
			pnlLayoutTwo.SetUIActive(false);
		}

		// Token: 0x06036B3D RID: 224061 RVA: 0x00DDCDA0 File Offset: 0x00DDAFA0
		public void Clear()
		{
			this.RemoveSubtitleAnimationTimer();
			this.ClearCurPlayAudio();
			if (ModelBase<PlotModel>.Instance.IsShowingHeadIcon)
			{
				ModelBase<PlotModel>.Instance.IsShowingHeadIcon = false;
				PlotPortraitItem portraitItem = this.PortraitItem;
				if (portraitItem != null)
				{
					portraitItem.Destroy(null);
				}
				this.PortraitItem = null;
			}
			TimerHandle scrollStartTimer = this.ScrollStartTimer;
			if (scrollStartTimer != null)
			{
				scrollStartTimer.Remove();
			}
			this.ScrollStartTimer = null;
			this.RemoveTextAnimTimer();
			this.AutoSelectOptionComponent.Clear();
			this.HandleAkEvent(false);
			this.LastEndAkEvent = null;
		}

		// Token: 0x06036B3E RID: 224062 RVA: 0x00DDCE21 File Offset: 0x00DDB021
		[NullableContext(1)]
		private PlotOptionItem InitOptionItem()
		{
			PlotOptionItem plotOptionItem = new PlotOptionItem(this.Parent);
			plotOptionItem.BindOnHover(new Action<PlotOptionItem>(this.OnPlotOptionItemHover));
			plotOptionItem.BindOnUnHover(new Action<PlotOptionItem>(this.OnPlotOptionItemUnHover));
			return plotOptionItem;
		}

		// Token: 0x06036B3F RID: 224063 RVA: 0x00DDCE52 File Offset: 0x00DDB052
		[NullableContext(1)]
		private void OnPlotOptionItemUnHover(PlotOptionItem plotOptionItem)
		{
			if (this.NeedSelectedState)
			{
				return;
			}
			plotOptionItem.SetSelectedDisplay(false);
		}

		// Token: 0x06036B40 RID: 224064 RVA: 0x00DDCE64 File Offset: 0x00DDB064
		[NullableContext(1)]
		private void OnPlotOptionItemHover(PlotOptionItem plotOptionItem)
		{
			PlotOptionItem selectedPlotOptionItem = this.SelectedPlotOptionItem;
			if (selectedPlotOptionItem != null)
			{
				selectedPlotOptionItem.SetSelectedDisplay(false);
			}
			this.SelectedPlotOptionItem = plotOptionItem;
			plotOptionItem.SetSelectedDisplay(true);
			this.AutoSelectOptionComponent.OnSelectedOptionChanged();
		}

		// Token: 0x06036B41 RID: 224065 RVA: 0x00DDCE94 File Offset: 0x00DDB094
		public void ShowOptions()
		{
			if (!this.HasOptions)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.OptionEnable = true;
			this.SetOptionsShow(true);
			this.CurOption.Clear();
			this.CurOption.AddRange(this.FilterOption(this.CurrentContent.Options));
			this.OptionLayout.RefreshByData(this.CurOption.Cast<object>().ToList<object>(), delegate
			{
				this.HandleOptionState();
				this.AutoSelectOptionComponent.OnOptionsShow();
			}, false);
		}

		// Token: 0x06036B42 RID: 224066 RVA: 0x00DDCF0B File Offset: 0x00DDB10B
		public void ClearOptions()
		{
			this.CurOption.Clear();
			this.SetOptionsShow(false);
			this.SelectedPlotOptionItem = null;
			this.AutoSelectOptionComponent.Clear();
		}

		// Token: 0x06036B43 RID: 224067 RVA: 0x00DDCF31 File Offset: 0x00DDB131
		public void OnAutoPlayStateChanged()
		{
			this.AutoSelectOptionComponent.OnAutoPlayStateChanged();
		}

		// Token: 0x06036B44 RID: 224068 RVA: 0x00DDCF3E File Offset: 0x00DDB13E
		public void OnImmersiveInputStateChange()
		{
			this.AutoSelectOptionComponent.OnImmersiveInputStateChange();
		}

		// Token: 0x06036B45 RID: 224069 RVA: 0x00DDCF4C File Offset: 0x00DDB14C
		private void HandleOptionState()
		{
			if (!this.NeedSelectedState)
			{
				return;
			}
			PlotOptionItem selectedPlotOptionItem = this.SelectedPlotOptionItem;
			if (selectedPlotOptionItem != null)
			{
				selectedPlotOptionItem.SetSelectedDisplay(false);
			}
			this.SelectedPlotOptionItem = PlotAutoSelectOptionComponent.GetDefaultSelectedOptionItem(this.GetDisplayOptionItems(), this.CurrentContent);
			if (this.SelectedPlotOptionItem != null)
			{
				this.SelectedPlotOptionItem.SetSelectedDisplay(true);
				this.AutoSelectOptionComponent.OnSelectedOptionChanged();
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.SelectedPlotOptionItem.GetToggleItem().GetRootComponent(), true, false, false);
			}
		}

		// Token: 0x06036B46 RID: 224070 RVA: 0x00DDCFC8 File Offset: 0x00DDB1C8
		[NullableContext(1)]
		private PlotOptionItem[] GetDisplayOptionItems()
		{
			List<PlotOptionItem> list = new List<PlotOptionItem>();
			int displayGridEndIndex = this.OptionLayout.GetDisplayGridEndIndex();
			for (int i = 0; i <= displayGridEndIndex; i++)
			{
				PlotOptionItem layoutItemByIndex = this.OptionLayout.GetLayoutItemByIndex(i);
				if (layoutItemByIndex != null)
				{
					list.Add(layoutItemByIndex);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06036B47 RID: 224071 RVA: 0x00DDD010 File Offset: 0x00DDB210
		public void SetOptionsShow(bool value)
		{
			if (value == this.IsOptionShow)
			{
				return;
			}
			this.IsOptionShow = value;
			if (value)
			{
				this.OptionLayout.SetActive(true);
				UUIItem pnlLayoutTwo = this.PnlLayoutTwo;
				if (pnlLayoutTwo != null)
				{
					pnlLayoutTwo.SetUIActive(true);
				}
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlaySequence("ChoiceStart", false, null);
				}
				if (this.BlockOption != null)
				{
					this.BlockOption.SetUIActive(true);
					this.BlockOptionTimer = TimerSystem.Instance.Delay(delegate(float _)
					{
						this.BlockOption.SetUIActive(false);
						this.BlockOptionTimer = null;
					}, ModelBase<PlotModel>.Instance.PlotGlobalConfig.ProtectOptionTime, null, null, true, 1f);
					return;
				}
			}
			else
			{
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				if (uiViewSequence2 != null)
				{
					uiViewSequence2.PlaySequence("ChoiceClose", false, null);
				}
				if (this.BlockOption != null)
				{
					this.BlockOption.SetUIActive(false);
					TimerHandle blockOptionTimer = this.BlockOptionTimer;
					if (blockOptionTimer != null)
					{
						blockOptionTimer.Remove();
					}
					this.BlockOptionTimer = null;
				}
			}
		}

		// Token: 0x06036B48 RID: 224072 RVA: 0x00DDD10C File Offset: 0x00DDB30C
		[NullableContext(1)]
		private List<PlotOption> FilterOption(List<ITalkOption> options)
		{
			List<PlotOption> list = new List<PlotOption>();
			for (int i = 0; i < options.Count; i++)
			{
				ITalkOption talkOption = options[i];
				bool flag = ModelBase<PlotModel>.Instance.CheckOptionCondition(talkOption, i, this.CurrentContent);
				if (flag || talkOption.OptionLockTip != null)
				{
					PlotOption item = new PlotOption
					{
						Config = talkOption,
						ConditionCheck = flag,
						OnClick = new Action(this.OnOptionSelected)
					};
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06036B49 RID: 224073 RVA: 0x00DDD186 File Offset: 0x00DDB386
		private void OnOptionSelected()
		{
			this.AutoSelectOptionComponent.OnOptionSelected();
		}

		// Token: 0x06036B4A RID: 224074 RVA: 0x00DDD194 File Offset: 0x00DDB394
		private void SelectOptionByIndex(int optionIndex)
		{
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				ControllerBase<SequenceController>.Instance.SelectOption(optionIndex, this.CurrentContent.Id);
				return;
			}
			ITalkOption talkOption = this.CurrentContent.Options[optionIndex];
			ControllerBase<FlowController>.Instance.FlowShowTalk.SelectOption(optionIndex, talkOption.Actions);
		}

		// Token: 0x06036B4B RID: 224075 RVA: 0x00DDD1EC File Offset: 0x00DDB3EC
		public void InitInteractOptions()
		{
			if (this.InteractController == null)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.OptionEnable = true;
			this.SetOptionsShow(true);
			List<CommonInteractOption> showOptions = this.InteractController.ShowOptions;
			this.OptionLayout.RefreshByData(showOptions.Cast<object>().ToList<object>(), new Action(this.HandleOptionState), false);
		}

		// Token: 0x06036B4C RID: 224076 RVA: 0x00DDD244 File Offset: 0x00DDB444
		[NullableContext(1)]
		public void UpdatePlotSubtitle(ITalkItem inPlotSubtitleInfo)
		{
			bool flag = false;
			if (inPlotSubtitleInfo.Type.GetValueOrDefault() == ETalkItemType.SystemOption)
			{
				flag = (inPlotSubtitleInfo as ITalkItemSystemOption).OptionConfig.KeepPreTalkItem.GetValueOrDefault();
			}
			if (!flag)
			{
				this.ClearPlotContent(false);
			}
			this.IsInteraction = false;
			this.PlaySubtitle(inPlotSubtitleInfo);
		}

		// Token: 0x06036B4D RID: 224077 RVA: 0x00DDD298 File Offset: 0x00DDB498
		public void ClearPlotContent(bool keepCurrentContent = false)
		{
			UUIScrollViewComponent textScrollView = this.TextScrollView;
			if (textScrollView != null)
			{
				textScrollView.SetScrollProgress(0f);
			}
			this.HandleAkEvent(false);
			this.Talker = null;
			this.IsPause = false;
			this.IsSubmit = false;
			this.IsAudioEnd = false;
			this.AnimOffset = 1f;
			this.RemoveSubtitleAnimationTimer();
			this.ClearCurPlayAudio();
			this.RemoveTextAnimTimer();
			TimerHandle scrollStartTimer = this.ScrollStartTimer;
			if (scrollStartTimer != null)
			{
				scrollStartTimer.Remove();
			}
			this.ScrollStartTimer = null;
			if (!keepCurrentContent)
			{
				this.CurrentContent = null;
			}
		}

		// Token: 0x06036B4E RID: 224078 RVA: 0x00DDD323 File Offset: 0x00DDB523
		static PlotTextCommonLogic()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PlotTextCommonLogic.CreateStaticDefaultValue), new Action(PlotTextCommonLogic.ResetStaticDefaultValue));
		}

		// Token: 0x06036B4F RID: 224079 RVA: 0x00DDD342 File Offset: 0x00DDB542
		public static void CreateStaticDefaultValue()
		{
			PlotTextCommonLogic.CallbackEnableId = 0;
		}

		// Token: 0x06036B50 RID: 224080 RVA: 0x00DDD34A File Offset: 0x00DDB54A
		public static void ResetStaticDefaultValue()
		{
			PlotTextCommonLogic.CallbackEnableId = 0;
		}

		// Token: 0x06036B51 RID: 224081 RVA: 0x00DDD354 File Offset: 0x00DDB554
		private unsafe bool PlayTone(bool hasSubtitle = true)
		{
			if (this.IsAudioEnd)
			{
				return false;
			}
			if (this.CurrentContent.UniversalTone != null)
			{
				IUniversalTone universalTone = this.CurrentContent.UniversalTone;
				int? num = (universalTone.TimberId != null) ? universalTone.TimberId : ((this.Talker != null) ? new int?(this.Talker.GetValueOrDefault().TimberId) : null);
				int universalToneId = universalTone.UniversalToneId;
				if (num != null)
				{
					Interjection? config = ConfigInterjectionByTimberIdAndUniversalToneId.GetConfig(num.Value, universalToneId, true);
					if (config != null)
					{
						this.PlayTalkInterjection(config.Value, hasSubtitle);
						return true;
					}
				}
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "通用语气配置无法获取，策划检查配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("timberId", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("universalToneId", universalToneId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return false;
		}

		// Token: 0x06036B52 RID: 224082 RVA: 0x00DDD466 File Offset: 0x00DDB666
		private void HandleAkEvent(bool isStart)
		{
			if (isStart)
			{
				this.PlayAkEvent(this.CurrentContent.TalkAkEvent);
				this.LastEndAkEvent = this.CurrentContent.TalkEndAkEvent;
				return;
			}
			this.PlayAkEvent(this.LastEndAkEvent);
			this.LastEndAkEvent = null;
		}

		// Token: 0x06036B53 RID: 224083 RVA: 0x00DDD4A4 File Offset: 0x00DDB6A4
		private void PlayAkEvent(IPostAkEventType config)
		{
			if (config == null)
			{
				return;
			}
			string text = "";
			switch (config.Type)
			{
			case EPostAkEvent.Global:
				text = ((IPostAkEventGlobal)config).AkEvent;
				break;
			case EPostAkEvent.Target:
				text = ((IPostAkEventTargeted)config).AkEvent;
				break;
			case EPostAkEvent.Map:
				text = ((IPostAkEventMap)config).AkEvent;
				break;
			case EPostAkEvent.MusicSubtitle:
				text = ((IPostAkEventMusicSubtitle)config).AkEvent;
				break;
			}
			text = Singleton<AudioSystem>.Instance.parseAudioEventPath(text);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (config.Type == EPostAkEvent.Global)
			{
				Singleton<AudioSystem>.Instance.PostEvent(text);
				return;
			}
			if (config.Type == EPostAkEvent.Target)
			{
				int entityId = ((IPostAkEventTargeted)config).EntityId;
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId);
				if (entityByPbDataId == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Event;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "实体不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				BaseActorComponent component = entityByPbDataId.Entity.GetComponent<BaseActorComponent>();
				AActor aactor = (component != null) ? component.Owner : null;
				if (aactor == null || !aactor.IsValid())
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.Event;
					ELogAuthor author2 = ELogAuthor.FZX;
					string message2 = "未能获取到该实体对应的有效Actor";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entityId);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				Singleton<AudioSystem>.Instance.PostEvent(text, aactor, null);
			}
		}

		// Token: 0x06036B54 RID: 224084 RVA: 0x00DDD600 File Offset: 0x00DDB800
		private bool PlayTalkAudio()
		{
			if (this.IsAudioEnd)
			{
				return false;
			}
			if (this.CurLang != Singleton<LanguageSystem>.Instance.PackageAudio)
			{
				this.CurLang = Singleton<LanguageSystem>.Instance.PackageAudio;
				this.ClearCurPlayAudio();
			}
			if (this.PlotPlayEventResult != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs(new int?(this.BREAK_TIME), null, null)));
				this.HandlePlotLogic(null, null);
				return true;
			}
			if (this.WaitAudioLoadTimer != null)
			{
				this.WaitAudioLoadTimer.Resume();
				return true;
			}
			PlotAudio? plotAudio = this.CurrentContent.PlayVoice.GetValueOrDefault() ? ConfigPlotAudioById.GetConfig(this.CurrentContent.TidTalk, true) : null;
			if (plotAudio == null)
			{
				return false;
			}
			float extraDuration = (plotAudio.Value.TailTime < 0) ? ModelBase<PlotModel>.Instance.PlotGlobalConfig.AudioEndDelay : ((float)plotAudio.Value.TailTime);
			ExternalSourceSetting? config = ConfigExternalSourceSettingById.GetConfig(plotAudio.Value.ExternalSourceSetting, true);
			string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(plotAudio.Value);
			string @event = Singleton<AudioSystem>.Instance.parseAudioEventPath(config.Value.SubtitleEvent);
			PlotTextCommonLogic.CallbackEnableId++;
			int id = PlotTextCommonLogic.CallbackEnableId;
			AActor target = null;
			this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent(@event, target, new PostEventArgs?(new PostEventArgs
			{
				ExternalSourceName = config.Value.SubtitleSrc,
				ExternalSourceMediaName = externalSourcesMediaName,
				CallbackMask = new ECallbackMask?(ECallbackMask.Duration),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (id != PlotTextCommonLogic.CallbackEnableId)
					{
						return;
					}
					if (callbackType == EAkCallbackType.EndOfEvent)
					{
						this.IsAudioEnd = true;
						this.PlotPlayEventResult = 0;
						this.ResetAudioRemainingTime();
						PlotTextCommonLogic.CallbackEnableId++;
						return;
					}
					if (callbackType == EAkCallbackType.Duration)
					{
						this.PlayDelayTime = new float?(((UAkDurationCallbackInfo)callbackInfo).Duration + extraDuration);
						this.SetAudioRemainingTime(this.PlayDelayTime.Value);
						this.RemoveWaitAudioLoadTimer();
						ModelBase<PlotModel>.Instance.PlotTemplate.HandleMouthAnim(this.CurrentContent);
						if (!this.IsPause)
						{
							this.HandlePlotLogic(null, null);
						}
					}
				}
			}));
			this.WaitAudioLoadTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.FZX, "[PlotTextLogic] 加载剧情音频超时，直接显示剧情文本", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ClearCurPlayAudio();
				this.PlayDelayTime = null;
				this.HandlePlotLogic(null, null);
			}, (float)this.MAX_LOAD_AUDIO_TIME, null, null, true, 1f);
			return true;
		}

		// Token: 0x06036B55 RID: 224085 RVA: 0x00DDD824 File Offset: 0x00DDBA24
		private unsafe void PlayTalkInterjection(Interjection config, bool hasSubtitle)
		{
			if (this.WaitAudioLoadTimer != null)
			{
				this.WaitAudioLoadTimer.Resume();
				return;
			}
			if (this.CurLang != Singleton<LanguageSystem>.Instance.PackageAudio)
			{
				this.CurLang = Singleton<LanguageSystem>.Instance.PackageAudio;
				this.ClearCurPlayAudio();
			}
			if (this.PlotPlayEventResult != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs(new int?(this.BREAK_TIME), null, null)));
				if (hasSubtitle)
				{
					this.HandlePlotLogic(null, null);
				}
				return;
			}
			string eventName = Singleton<AudioSystem>.Instance.parseAudioEventPath(config.AkEvent);
			int id = PlotTextCommonLogic.CallbackEnableId;
			AActor target = null;
			this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent(eventName, target, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.Duration),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (id != PlotTextCommonLogic.CallbackEnableId)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.Plot;
						ELogAuthor author = ELogAuthor.FZX;
						string message = "[PlotViewHud] 废弃的音频回调";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("eventName", eventName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("type", callbackType);
						instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
						return;
					}
					if (callbackType == EAkCallbackType.EndOfEvent)
					{
						this.IsAudioEnd = true;
						this.PlotPlayEventResult = 0;
						this.ResetAudioRemainingTime();
						PlotTextCommonLogic.CallbackEnableId++;
						return;
					}
					if (callbackType == EAkCallbackType.Duration)
					{
						this.PlayDelayTime = new float?(((UAkDurationCallbackInfo)callbackInfo).Duration);
						this.SetAudioRemainingTime(this.PlayDelayTime.Value);
						this.RemoveWaitAudioLoadTimer();
						if (!this.IsPause & hasSubtitle)
						{
							this.HandlePlotLogic(null, null);
						}
					}
				}
			}));
			if (hasSubtitle)
			{
				this.WaitAudioLoadTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.CFT, "加载通用语气音频超时，直接显示剧情文本", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.ClearCurPlayAudio();
					this.PlayDelayTime = null;
					this.HandlePlotLogic(null, null);
				}, (float)this.MAX_LOAD_AUDIO_TIME, null, null, true, 1f);
			}
		}

		// Token: 0x06036B56 RID: 224086 RVA: 0x00DDD980 File Offset: 0x00DDBB80
		public void ClearCurPlayAudio()
		{
			this.RemoveWaitAudioLoadTimer();
			PlotTextCommonLogic.CallbackEnableId++;
			Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs(new int?(0), null, null)));
			this.PlotPlayEventResult = 0;
			this.ResetAudioRemainingTime();
		}

		// Token: 0x06036B57 RID: 224087 RVA: 0x00DDD9D7 File Offset: 0x00DDBBD7
		private void RemoveWaitAudioLoadTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.WaitAudioLoadTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.WaitAudioLoadTimer);
			}
			this.WaitAudioLoadTimer = null;
		}

		// Token: 0x06036B58 RID: 224088 RVA: 0x00DDDA03 File Offset: 0x00DDBC03
		private void SetAudioRemainingTime(float duration)
		{
			this.AudioDuration = duration;
			this.AudioEndTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + (double)duration;
		}

		// Token: 0x06036B59 RID: 224089 RVA: 0x00DDDA1F File Offset: 0x00DDBC1F
		private void ResetAudioRemainingTime()
		{
			this.AudioDuration = 0f;
			this.AudioEndTime = 0.0;
		}

		// Token: 0x06036B5A RID: 224090 RVA: 0x00DDDA3C File Offset: 0x00DDBC3C
		private float GetCurrentAudioRemainingTime()
		{
			if (this.IsAudioEnd || this.PlotPlayEventResult == 0 || this.AudioDuration <= 0f)
			{
				return 0f;
			}
			int? sourcePlayPosition = Singleton<AudioSystem>.Instance.GetSourcePlayPosition(this.PlotPlayEventResult, false);
			if (sourcePlayPosition != null)
			{
				return Math.Max(0f, this.AudioDuration - (float)sourcePlayPosition.Value);
			}
			return Math.Max(0f, (float)(this.AudioEndTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp()));
		}

		// Token: 0x06036B5B RID: 224091 RVA: 0x00DDDAC0 File Offset: 0x00DDBCC0
		private float GetAutoSelectExtraWaitTime()
		{
			if (this.Parent is PlotView && ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC && this.CurrentContent.PlayVoice.GetValueOrDefault())
			{
				return (float)this.LEVEL_C_PLOT_VIEW_AUTO_SELECT_EXTRA_WAIT_TIME;
			}
			return 0f;
		}

		// Token: 0x06036B5C RID: 224092 RVA: 0x00DDDB14 File Offset: 0x00DDBD14
		public unsafe void PlaySubtitle(ITalkItem inPlotSubtitleInfo)
		{
			this.CurrentContent = inPlotSubtitleInfo;
			this.HandleAkEvent(true);
			if (this.CurrentContent.Type.GetValueOrDefault() == ETalkItemType.Option || this.CurrentContent.Type.GetValueOrDefault() == ETalkItemType.SystemOption)
			{
				this.ClearCurPlayAudio();
				this.PlayTone(false);
				return;
			}
			ICaptionParam captionParams = this.CurrentContent.CaptionParams;
			if (this.CurrentContent.WhoId != null)
			{
				this.Talker = ConfigSpeakerById.GetConfig(this.CurrentContent.WhoId.Value, true);
			}
			if (captionParams != null && captionParams.StartTime == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "配置了字幕参数的无法播放语音";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("textId", (inPlotSubtitleInfo != null) ? inPlotSubtitleInfo.TidTalk : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("id", (inPlotSubtitleInfo != null) ? new int?(inPlotSubtitleInfo.Id) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("param", (inPlotSubtitleInfo != null) ? inPlotSubtitleInfo.CaptionParams : null);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.HandlePlotLogic(captionParams.TotalTime, captionParams.IntervalTime);
				return;
			}
			if (this.PlayTalkAudio() || this.PlayTone(true))
			{
				return;
			}
			this.HandlePlotLogic(null, null);
		}

		// Token: 0x06036B5D RID: 224093 RVA: 0x00DDDCA4 File Offset: 0x00DDBEA4
		public void PauseSubtitle()
		{
			if (this.CurrentContent == null)
			{
				return;
			}
			this.IsPause = true;
			if (this.WaitAudioLoadTimer != null)
			{
				this.WaitAudioLoadTimer.Pause();
				return;
			}
			if (this.PlotPlayEventResult != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs(new int?(this.BREAK_TIME), null, null)));
			}
			TimerHandle scrollStartTimer = this.ScrollStartTimer;
			if (scrollStartTimer != null)
			{
				scrollStartTimer.Remove();
			}
			this.ScrollStartTimer = null;
			this.RemoveTextAnimTimer();
			if (this.SubtitleAnimationTimer != null)
			{
				this.AnimOffset = this.SubtitleAnimDataComp.GetSelectorOffset();
				this.SubtitleAnimation.Stop();
				this.SubtitleAnimationTimer.Pause();
			}
		}

		// Token: 0x06036B5E RID: 224094 RVA: 0x00DDDD5D File Offset: 0x00DDBF5D
		[NullableContext(1)]
		public void ResumeSubtitle(ITalkItem config)
		{
			this.IsPause = false;
			this.PlaySubtitle(config);
		}

		// Token: 0x06036B5F RID: 224095 RVA: 0x00DDDD6D File Offset: 0x00DDBF6D
		private void HandlePlotLogic(float? captionTotalTime = null, float? captionIntervalTime = null)
		{
			this.HandlePlotTitle();
			this.HandlePlotContent();
			this.HandlePlotContentAnim(captionTotalTime, captionIntervalTime);
			this.ScrollStartTimer = TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				this.ScrollStartTimer = TimerSystem.GameplayTimeInstance.Next(delegate(float _)
				{
					this.HandlePlotContentScroll();
				}, null, null);
			}, null, null);
		}

		// Token: 0x06036B60 RID: 224096 RVA: 0x00DDDDA4 File Offset: 0x00DDBFA4
		private void HandlePlotTitle()
		{
			this.PlotItem.SetUIActive(true);
			if (ModelBase<PlotModel>.Instance.PlotConfig.SubtitleLevel.GetValueOrDefault() == EPlotLevel.LevelC && ModelBase<PlotModel>.Instance.IsUseNewLevelBStyle())
			{
				this.NpcName.SetUIActive(false);
				this.NpcTitle.SetUIActive(false);
				this.LineItem.SetUIActive(false);
				return;
			}
			if (this.CurrentContent.Type != null)
			{
				ETalkItemType? type = this.CurrentContent.Type;
				ETalkItemType etalkItemType = ETalkItemType.Talk;
				if (!(type.GetValueOrDefault() == etalkItemType & type != null))
				{
					this.LineItem.SetUIActive(false);
					this.NpcName.SetUIActive(false);
					this.NpcTitle.SetUIActive(false);
					return;
				}
			}
			ITalkItemDialog talkItemDialog = this.CurrentContent as ITalkItemDialog;
			if (talkItemDialog != null && talkItemDialog.Style != null && talkItemDialog.Style.Type == ETalkItemStyle.InnerVoice)
			{
				this.LineItem.SetUIActive(false);
				this.NpcName.SetUIActive(false);
				this.NpcTitle.SetUIActive(false);
				return;
			}
			this.LineItem.SetUIActive(true);
			string configTextByTable = Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(this.Talker.Value.Id));
			if (!StringUtils.IsEmpty(configTextByTable))
			{
				this.NpcName.SetUIActive(true);
				this.NpcName.SetText(configTextByTable, true);
			}
			else
			{
				this.NpcName.SetUIActive(false);
			}
			string configTextByTable2 = Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerTitle, new int?(this.Talker.Value.Id));
			if (!StringUtils.IsEmpty(configTextByTable2))
			{
				this.NpcTitle.SetUIActive(true);
				this.NpcTitle.SetText(configTextByTable2, true);
				return;
			}
			this.NpcTitle.SetUIActive(false);
		}

		// Token: 0x06036B61 RID: 224097 RVA: 0x00DDDF60 File Offset: 0x00DDC160
		private void HandlePlotContent()
		{
			if (this.CurrentContent.Type.GetValueOrDefault() == ETalkItemType.NoTextItem)
			{
				this.PlotContent.SetUIActive(false);
				return;
			}
			this.PlotContent.SetUIActive(true);
			string text = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(this.CurrentContent.TidTalk);
			if (StringUtils.IsEmpty(text))
			{
				FlowController instance = ControllerBase<FlowController>.Instance;
				string text2 = "字幕为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", this.CurrentContent.TidTalk);
				instance.LogError(text2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				text = this.CurrentContent.TidTalk;
			}
			bool needClear = ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelD;
			text = ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(text, needClear);
			this.PlotContent.SetGameRichText(true);
			this.PlotContent.SetText(text, true);
		}

		// Token: 0x06036B62 RID: 224098 RVA: 0x00DDE038 File Offset: 0x00DDC238
		private void HandlePlotContentScroll()
		{
			this.ScrollStartTimer = null;
			this.RemoveTextAnimTimer();
			if (this.TextScrollView == null)
			{
				return;
			}
			float y = this.PlotContent.GetTextRenderSize().Y;
			UUIItem uuiitem = this.TextScrollView.RootUIComp.Get();
			float num = (uuiitem != null) ? uuiitem.GetHeight() : this.TextScrollViewPrefabHeight;
			UUIItem optionAdjustItem = this.OptionAdjustItem;
			if (optionAdjustItem != null)
			{
				optionAdjustItem.SetHeight(num + (float)this.OPTIONHEIGHT_OFFSET);
			}
			if (y <= num)
			{
				return;
			}
			float textAnimSpeed = this.GetTextAnimSpeed();
			int num2 = ConfigCommonParamById.GetIntConfig("PlotAutoScrollDelayCharNum") ?? this.DEFAULT_AUTO_SCROLL_DELAY_CHAR_NUM;
			int displayCharLength = this.PlotContent.GetDisplayCharLength();
			if (displayCharLength <= num2)
			{
				num2 = this.PlotContent.GetRenderLineCharNum(0);
			}
			num2 = Math.Min(num2, Math.Max(displayCharLength - 1, 1));
			float interval = (float)num2 / textAnimSpeed * 1000f;
			int num3 = Math.Max(displayCharLength - num2, 1);
			this.ScrollTotalTime = (float)num3 / textAnimSpeed * 1000f;
			this.DelayTextScrollAnimTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.StartAutoScrollAnim();
			}, interval, null, null, true, 1f);
		}

		// Token: 0x06036B63 RID: 224099 RVA: 0x00DDE158 File Offset: 0x00DDC358
		private float GetTextAnimSpeed()
		{
			if (this.IsInteraction)
			{
				return ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedInteraction;
			}
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				return ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelC;
			}
			return ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelD;
		}

		// Token: 0x06036B64 RID: 224100 RVA: 0x00DDE1B4 File Offset: 0x00DDC3B4
		private void StartAutoScrollAnim()
		{
			this.CurrentAnimTime = 0f;
			int intervalTime = 100;
			this.TextScrollAnimTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				float num = this.CurrentAnimTime / this.ScrollTotalTime;
				UUIScrollViewComponent textScrollView = this.TextScrollView;
				if (textScrollView != null)
				{
					textScrollView.SetScrollProgress(num);
				}
				if (num >= 1f && TimerSystem.GameplayTimeInstance.Has(this.TextScrollAnimTimer))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.TextScrollAnimTimer);
				}
				this.CurrentAnimTime += (float)intervalTime;
			}, (float)intervalTime, 1f, null, null, true);
		}

		// Token: 0x06036B65 RID: 224101 RVA: 0x00DDE20C File Offset: 0x00DDC40C
		private void RemoveTextAnimTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TextScrollAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TextScrollAnimTimer);
			}
			if (TimerSystem.GameplayTimeInstance.Has(this.DelayTextScrollAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayTextScrollAnimTimer);
			}
			this.TextScrollAnimTimer = null;
			this.DelayTextScrollAnimTimer = null;
		}

		// Token: 0x06036B66 RID: 224102 RVA: 0x00DDE270 File Offset: 0x00DDC470
		private void HandlePlotContentAnim(float? captionTotalTime = null, float? captionIntervalTime = null)
		{
			if (this.SubtitleAnimation == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YSQ, "找不到字幕动画组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.HandleSubtitleAnimFinished();
				return;
			}
			if (this.SubtitleAnimationTimer != null)
			{
				this.SubtitleAnimationTimer.Resume();
				(this.SubtitleAnimation.GetPlayTween() as ULGUIPlayTween_Float).from = this.AnimOffset;
				this.SubtitleAnimation.GetPlayTween().duration *= this.AnimOffset;
				this.SubtitleAnimation.Play();
				return;
			}
			if (this.IsSubmit)
			{
				this.SubtitleAnimDataComp.SetSelectorOffset(0f);
				return;
			}
			int displayCharLength = this.PlotContent.GetDisplayCharLength();
			this.SubtitleAnimation.Stop();
			float num;
			if (captionTotalTime != null)
			{
				num = captionTotalTime.Value;
			}
			else if (this.IsInteraction)
			{
				num = (float)displayCharLength / ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedInteraction;
			}
			else if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				num = (float)displayCharLength / ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelC;
			}
			else
			{
				num = (float)displayCharLength / ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelD;
			}
			this.SubtitleAnimDataComp.SetSelectorOffset(1f);
			this.SubtitleAnimation.GetPlayTween().duration = num;
			this.SubtitleAnimation.Play();
			this.IsTextAnimPlaying = true;
			num *= 1000f;
			if (captionIntervalTime != null)
			{
				this.PlayDelayTime = new float?(captionIntervalTime.Value * 1000f);
			}
			else if (this.PlayDelayTime != null)
			{
				this.PlayDelayTime = new float?(this.PlayDelayTime.Value - num);
			}
			else
			{
				this.PlayDelayTime = new float?(0f);
			}
			this.WaitSubtitleAnimationFinish(num);
		}

		// Token: 0x06036B67 RID: 224103 RVA: 0x00DDE444 File Offset: 0x00DDC644
		private void WaitSubtitleAnimationFinish(float duration)
		{
			this.RemoveSubtitleAnimationTimer();
			float interval = Math.Max(duration, 20f);
			this.SubtitleAnimationTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.HandleSubtitleAnimFinished();
			}, interval, null, null, true, 1f);
		}

		// Token: 0x06036B68 RID: 224104 RVA: 0x00DDE488 File Offset: 0x00DDC688
		private void RemoveSubtitleAnimationTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.SubtitleAnimationTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.SubtitleAnimationTimer);
			}
			this.SubtitleAnimationTimer = null;
		}

		// Token: 0x06036B69 RID: 224105 RVA: 0x00DDE4B4 File Offset: 0x00DDC6B4
		private void HandleSubtitleAnimFinished()
		{
			(this.SubtitleAnimation.GetPlayTween() as ULGUIPlayTween_Float).from = 1f;
			this.RemoveSubtitleAnimationTimer();
			this.IsTextAnimPlaying = false;
			this.IsSubmit = true;
			Action plotContentAnimFinishCallback = this.PlotContentAnimFinishCallback;
			if (plotContentAnimFinishCallback == null)
			{
				return;
			}
			plotContentAnimFinishCallback();
		}

		// Token: 0x06036B6A RID: 224106 RVA: 0x00DDE4F4 File Offset: 0x00DDC6F4
		[NullableContext(1)]
		public void SetPlotContentAnimFinishCallback(Action callback)
		{
			this.PlotContentAnimFinishCallback = callback;
		}

		// Token: 0x06036B6B RID: 224107 RVA: 0x00DDE4FD File Offset: 0x00DDC6FD
		public void ForceSkipPlotContentAnim()
		{
			this.SubtitleAnimation.Stop();
			this.SubtitleAnimDataComp.SetSelectorOffset(0f);
			this.RemoveTextAnimTimer();
			UUIScrollViewComponent textScrollView = this.TextScrollView;
			if (textScrollView != null)
			{
				textScrollView.SetScrollProgress(1f);
			}
			this.HandleSubtitleAnimFinished();
		}

		// Token: 0x06036B6C RID: 224108 RVA: 0x00DDE53C File Offset: 0x00DDC73C
		public float GetPlotContentAnimDuration()
		{
			return this.SubtitleAnimation.GetPlayTween().duration;
		}

		// Token: 0x06036B6D RID: 224109 RVA: 0x00DDE550 File Offset: 0x00DDC750
		public void HandlePortraitVisible([Nullable(1)] UUIItem rootItem, SetHeadIconVisible headIconInfo, Action callback)
		{
			if (headIconInfo == null || callback == null)
			{
				return;
			}
			if (headIconInfo.Visible && !ModelBase<PlotModel>.Instance.IsShowingHeadIcon)
			{
				ModelBase<PlotModel>.Instance.IsShowingHeadIcon = true;
				this.PortraitItem = new PlotPortraitItem();
				this.PortraitItem.OpenAsync(rootItem, headIconInfo.HeadStyleConfig).ContinueWith(callback);
				return;
			}
			if (headIconInfo.Visible && ModelBase<PlotModel>.Instance.IsShowingHeadIcon)
			{
				this.PortraitItem.CloseAsync().Forget();
				this.PortraitItem = new PlotPortraitItem();
				this.PortraitItem.OpenAsync(rootItem, headIconInfo.HeadStyleConfig).ContinueWith(callback);
				return;
			}
			if (!headIconInfo.Visible && ModelBase<PlotModel>.Instance.IsShowingHeadIcon)
			{
				ModelBase<PlotModel>.Instance.IsShowingHeadIcon = false;
				this.PortraitItem.CloseAsync().ContinueWith(callback);
				this.PortraitItem = null;
				return;
			}
			callback();
		}

		// Token: 0x06036B6E RID: 224110 RVA: 0x00DDE630 File Offset: 0x00DDC830
		public UniTask DestroyPortraitItem()
		{
			PlotTextCommonLogic.<DestroyPortraitItem>d__118 <DestroyPortraitItem>d__;
			<DestroyPortraitItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DestroyPortraitItem>d__.<>4__this = this;
			<DestroyPortraitItem>d__.<>1__state = -1;
			<DestroyPortraitItem>d__.<>t__builder.Start<PlotTextCommonLogic.<DestroyPortraitItem>d__118>(ref <DestroyPortraitItem>d__);
			return <DestroyPortraitItem>d__.<>t__builder.Task;
		}

		// Token: 0x06036B6F RID: 224111 RVA: 0x00DDE673 File Offset: 0x00DDC873
		public void OnTick(float delta)
		{
			this.AutoSelectOptionComponent.OnTick(delta, this.MuteTimeLimitedOption);
		}

		// Token: 0x0401F824 RID: 129060
		private int OPTIONHEIGHT_OFFSET = 265;

		// Token: 0x0401F825 RID: 129061
		private int DEFAULT_AUTO_SCROLL_DELAY_CHAR_NUM = 25;

		// Token: 0x0401F826 RID: 129062
		private int LEVEL_C_PLOT_VIEW_AUTO_SELECT_EXTRA_WAIT_TIME = 3000;

		// Token: 0x0401F827 RID: 129063
		private int BREAK_TIME = 1000;

		// Token: 0x0401F828 RID: 129064
		private int MAX_LOAD_AUDIO_TIME = 3000;

		// Token: 0x0401F829 RID: 129065
		public const int PLAY_FLAG = 8;

		// Token: 0x0401F82A RID: 129066
		public ITalkItem CurrentContent;

		// Token: 0x0401F82B RID: 129067
		[Nullable(1)]
		private string CurLang = "";

		// Token: 0x0401F82C RID: 129068
		private readonly float TextScrollViewPrefabHeight;

		// Token: 0x0401F82D RID: 129069
		private IPostAkEventType LastEndAkEvent;

		// Token: 0x0401F82E RID: 129070
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private readonly GenericLayout<PlotOptionItem, object> OptionLayout;

		// Token: 0x0401F82F RID: 129071
		private PlotOptionItem SelectedPlotOptionItem;

		// Token: 0x0401F830 RID: 129072
		private bool IsOptionShow;

		// Token: 0x0401F831 RID: 129073
		[Nullable(1)]
		public readonly List<PlotOption> CurOption = new List<PlotOption>();

		// Token: 0x0401F832 RID: 129074
		private TimerHandle BlockOptionTimer;

		// Token: 0x0401F833 RID: 129075
		[Nullable(1)]
		private readonly PlotAutoSelectOptionComponent AutoSelectOptionComponent = new PlotAutoSelectOptionComponent();

		// Token: 0x0401F834 RID: 129076
		private float OptionLimitTime;

		// Token: 0x0401F835 RID: 129077
		private float OptionLimitTimeDuration;

		// Token: 0x0401F836 RID: 129078
		private int TimeoutOptionIndex = -1;

		// Token: 0x0401F837 RID: 129079
		private bool HasTimeLimitedOption;

		// Token: 0x0401F838 RID: 129080
		public bool MuteTimeLimitedOption;

		// Token: 0x0401F839 RID: 129081
		private readonly bool NeedSelectedState;

		// Token: 0x0401F83A RID: 129082
		[Nullable(1)]
		protected readonly UUIItem PlotItem;

		// Token: 0x0401F83B RID: 129083
		[Nullable(1)]
		protected readonly UUIText NpcName;

		// Token: 0x0401F83C RID: 129084
		[Nullable(1)]
		protected readonly UUIText NpcTitle;

		// Token: 0x0401F83D RID: 129085
		[Nullable(1)]
		protected readonly UUIText PlotContent;

		// Token: 0x0401F83E RID: 129086
		[Nullable(1)]
		protected readonly UUIItem LineItem;

		// Token: 0x0401F83F RID: 129087
		protected readonly UUIScrollViewComponent TextScrollView;

		// Token: 0x0401F840 RID: 129088
		protected readonly ISimulatePlot Parent;

		// Token: 0x0401F841 RID: 129089
		protected readonly UUILayoutBase LayOutBase;

		// Token: 0x0401F842 RID: 129090
		protected readonly UUIItem OptionItemBase;

		// Token: 0x0401F843 RID: 129091
		protected readonly UUISliderComponent OptionLimitBar;

		// Token: 0x0401F844 RID: 129092
		protected readonly UUISliderComponent AutoSelectTimeBar;

		// Token: 0x0401F845 RID: 129093
		protected readonly UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x0401F846 RID: 129094
		protected readonly UUIItem BlockOption;

		// Token: 0x0401F847 RID: 129095
		protected readonly UUIItem OptionAdjustItem;

		// Token: 0x0401F848 RID: 129096
		protected readonly UUIItem PnlLayoutTwo;

		// Token: 0x0401F849 RID: 129097
		private readonly ULGUIPlayTweenComponent SubtitleAnimation;

		// Token: 0x0401F84A RID: 129098
		private readonly UUIEffectTextAnimation SubtitleAnimDataComp;

		// Token: 0x0401F84B RID: 129099
		public float? PlayDelayTime;

		// Token: 0x0401F84C RID: 129100
		private TimerHandle WaitAudioLoadTimer;

		// Token: 0x0401F84D RID: 129101
		private int PlotPlayEventResult;

		// Token: 0x0401F84E RID: 129102
		private float AudioDuration;

		// Token: 0x0401F84F RID: 129103
		private double AudioEndTime;

		// Token: 0x0401F850 RID: 129104
		private static int CallbackEnableId;

		// Token: 0x0401F851 RID: 129105
		private Speaker? Talker;

		// Token: 0x0401F852 RID: 129106
		private float AnimOffset = 1f;

		// Token: 0x0401F853 RID: 129107
		private bool IsPause;

		// Token: 0x0401F854 RID: 129108
		private bool IsSubmit;

		// Token: 0x0401F855 RID: 129109
		private bool IsAudioEnd;

		// Token: 0x0401F856 RID: 129110
		private TimerHandle ScrollStartTimer;

		// Token: 0x0401F857 RID: 129111
		private float ScrollTotalTime;

		// Token: 0x0401F858 RID: 129112
		private float CurrentAnimTime;

		// Token: 0x0401F859 RID: 129113
		private TimerHandle TextScrollAnimTimer;

		// Token: 0x0401F85A RID: 129114
		private TimerHandle DelayTextScrollAnimTimer;

		// Token: 0x0401F85B RID: 129115
		public TimerHandle SubtitleAnimationTimer;

		// Token: 0x0401F85C RID: 129116
		public bool IsInteraction;

		// Token: 0x0401F85D RID: 129117
		public bool IsTextAnimPlaying;

		// Token: 0x0401F85E RID: 129118
		private Action PlotContentAnimFinishCallback;

		// Token: 0x0401F85F RID: 129119
		private PlotPortraitItem PortraitItem;
	}
}
