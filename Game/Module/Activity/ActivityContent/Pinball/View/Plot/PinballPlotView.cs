using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Avg;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065EB RID: 26091
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballPlotView : UiTickViewBase, IPlotAvgPerformHandler
	{
		// Token: 0x060412B4 RID: 266932 RVA: 0x010B790B File Offset: 0x010B5B0B
		public PinballPlotView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17009F1C RID: 40732
		// (get) Token: 0x060412B5 RID: 266933 RVA: 0x010B7914 File Offset: 0x010B5B14
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected ITalkOption[] CurrentOptions
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				if (this.CurrentContent == null)
				{
					return null;
				}
				List<ITalkOption> options = this.CurrentContent.Options;
				if (options == null)
				{
					return null;
				}
				return options.ToArray();
			}
		}

		// Token: 0x17009F1D RID: 40733
		// (get) Token: 0x060412B6 RID: 266934 RVA: 0x010B7938 File Offset: 0x010B5B38
		protected bool HasOptions
		{
			get
			{
				ITalkOption[] currentOptions = this.CurrentOptions;
				return currentOptions != null && currentOptions.Length != 0;
			}
		}

		// Token: 0x060412B7 RID: 266935 RVA: 0x010B7958 File Offset: 0x010B5B58
		protected unsafe override void OnRegisterComponent()
		{
			int num = 29;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnNextButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnContinueButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060412B8 RID: 266936 RVA: 0x010B7DB4 File Offset: 0x010B5FB4
		protected override UniTask OnBeforeStartAsync()
		{
			PinballPlotView.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballPlotView.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060412B9 RID: 266937 RVA: 0x010B7DF8 File Offset: 0x010B5FF8
		protected override void OnStart()
		{
			UUILayoutBase layoutBase = base.GetLayoutBase(20);
			this.OptionLayout = new GenericLayout<PinballPlotOptionItem, IPinballPlotOptionItemData>(layoutBase, new Func<PinballPlotOptionItem>(this.CreateOptionItem), null, false, true);
			this.InitSkipComponent();
			this.InitDialogTextWriterComponent();
			this.InitCenterTextWriterComponent();
			this.InitTextScrollComponent();
			this.InitOptionComponent();
			this.InitWaitingProxyComponent();
			this.InitWaitingItemSeqPlayer();
			this.InitAutoPlayComponent();
			base.GetItem(7).SetUIActive(false);
			base.GetItem(25).SetUIActive(false);
			this.UiViewSequence.AddSequenceFinishEvent("Scene_Out", delegate(string _)
			{
				this.OnSceneOutSeqEnd();
			}, false);
			this.UiViewSequence.StartSequenceName = "Switch_In";
			this.UiViewSequence.CloseSequenceName = "Switch_Out";
			this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
		}

		// Token: 0x060412BA RID: 266938 RVA: 0x010B7ECD File Offset: 0x010B60CD
		private void OnEventSequence(string sequenceName, string eventName)
		{
			if (eventName == "Switch_In")
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPinballBattleViewSwitchIn);
			}
		}

		// Token: 0x060412BB RID: 266939 RVA: 0x010B7EEC File Offset: 0x010B60EC
		private void OnSceneOutSeqEnd()
		{
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x060412BC RID: 266940 RVA: 0x010B7EFC File Offset: 0x010B60FC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PlotConfigChanged, new Action(this.UpdateByPlotConfig));
			Singleton<EventSystem>.Instance.Add<ShowTalk>(EEventName.PlotStartShowTalk, new Action<ShowTalk>(this.OnShowTalkStart));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.HidePlotUi, new Action<bool>(this.HideAll));
			Singleton<EventSystem>.Instance.Add(EEventName.ShowPlotSubtitleOptions, new Action(this.ShowOptions));
			Singleton<EventSystem>.Instance.Add<ITalkItem>(EEventName.UpdatePlotSubtitle, new Action<ITalkItem>(this.PlayTalk));
			this.SkipComp.AddEventListener();
		}

		// Token: 0x060412BD RID: 266941 RVA: 0x010B7FBC File Offset: 0x010B61BC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotConfigChanged, new Action(this.UpdateByPlotConfig));
			Singleton<EventSystem>.Instance.Remove<ShowTalk>(EEventName.PlotStartShowTalk, new Action<ShowTalk>(this.OnShowTalkStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.HidePlotUi, new Action<bool>(this.HideAll));
			Singleton<EventSystem>.Instance.Remove(EEventName.ShowPlotSubtitleOptions, new Action(this.ShowOptions));
			Singleton<EventSystem>.Instance.Remove<ITalkItem>(EEventName.UpdatePlotSubtitle, new Action<ITalkItem>(this.PlayTalk));
			this.SkipComp.RemoveEventListener();
		}

		// Token: 0x060412BE RID: 266942 RVA: 0x010B807C File Offset: 0x010B627C
		protected override void OnAfterShow()
		{
			Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, true);
		}

		// Token: 0x060412BF RID: 266943 RVA: 0x010B809A File Offset: 0x010B629A
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, false);
		}

		// Token: 0x060412C0 RID: 266944 RVA: 0x010B80B8 File Offset: 0x010B62B8
		protected override void OnBeforeDestroy()
		{
			this.TextScrollComponent.Clear();
			this.DialogTextWriterComponent.Clear();
			this.CenterTextWriterComponent.Clear();
			this.WaitingProxyComponent.Clear();
			this.AutoPlayComponent.Clear();
			foreach (PinballAvgCharacter pinballAvgCharacter in this.AvgCharacterMap.Values)
			{
				pinballAvgCharacter.Destroy();
			}
			this.AvgCharacterMap.Clear();
		}

		// Token: 0x060412C1 RID: 266945 RVA: 0x010B8150 File Offset: 0x010B6350
		private void InitSkipComponent()
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
			this.SkipComp = new PlotSkipComponent(base.GetButton(2), new Action(this.OnSkip), new Action(this.OnSkipPop), null, new Action(this.OnSkipCancel), new EUiBehaviourPopType?(EUiBehaviourPopType.PinballSmall), "UiItem_ComConfirmPopup");
			this.SkipComp.EnableSkipButton(false);
		}

		// Token: 0x060412C2 RID: 266946 RVA: 0x010B81C8 File Offset: 0x010B63C8
		private void InitTextScrollComponent()
		{
			PlotTextScrollComponentContext context = new PlotTextScrollComponentContext
			{
				TextComponent = base.GetText(10),
				TextScrollView = base.GetScrollView(9)
			};
			this.TextScrollComponent.Init(context);
		}

		// Token: 0x060412C3 RID: 266947 RVA: 0x010B8204 File Offset: 0x010B6404
		private void InitDialogTextWriterComponent()
		{
			UUIText text = base.GetText(10);
			AActor owner = text.GetOwner();
			UUIEffectTextAnimation textAnimComp = owner.GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation;
			ULGUIPlayTweenComponent tweenComp = owner.GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent;
			PlotTextWriterComponentContext context = new PlotTextWriterComponentContext
			{
				TextComponent = text,
				TextAnimComp = textAnimComp,
				TweenComp = tweenComp,
				OnAnimCompleteDelegate = new Action(this.OnTextWriterEnd),
				OnStopDelegate = new Action(this.OnTextWriterEnd)
			};
			this.DialogTextWriterComponent.Init(context);
		}

		// Token: 0x060412C4 RID: 266948 RVA: 0x010B8298 File Offset: 0x010B6498
		private void InitCenterTextWriterComponent()
		{
			UUIText text = base.GetText(26);
			AActor owner = text.GetOwner();
			UUIEffectTextAnimation textAnimComp = owner.GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation;
			ULGUIPlayTweenComponent tweenComp = owner.GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent;
			PlotTextWriterComponentContext context = new PlotTextWriterComponentContext
			{
				TextComponent = text,
				TextAnimComp = textAnimComp,
				TweenComp = tweenComp,
				OnAnimCompleteDelegate = new Action(this.OnTextWriterEnd),
				OnStopDelegate = new Action(this.OnTextWriterEnd)
			};
			this.CenterTextWriterComponent.Init(context);
		}

		// Token: 0x060412C5 RID: 266949 RVA: 0x010B832C File Offset: 0x010B652C
		private void InitOptionComponent()
		{
			PlotOptionComponentContext context = new PlotOptionComponentContext
			{
				OptionsRefreshDelegate = new Action<ITalkOption[]>(this.OnRefreshOptions),
				OptionsShowDelegate = new Action(this.OnOptionsShow),
				OptionsHideDelegate = new Action(this.OnOptionsHide)
			};
			this.OptionComponent.Init(context);
		}

		// Token: 0x060412C6 RID: 266950 RVA: 0x010B8384 File Offset: 0x010B6584
		private void InitWaitingProxyComponent()
		{
			PlotWaitingProxyComponentContext context = new PlotWaitingProxyComponentContext
			{
				OnWaitingStartDelegate = new Action(this.OnWaitingStart),
				OnWaitingCompleteDelegate = new Action(this.OnWaitingComplete),
				OnWaitingCancelDelegate = new Action(this.OnWaitingCancel)
			};
			this.WaitingProxyComponent.Init(context);
		}

		// Token: 0x060412C7 RID: 266951 RVA: 0x010B83D9 File Offset: 0x010B65D9
		private void InitWaitingItemSeqPlayer()
		{
			this.WaitingItemSeqPlayer = new LevelSequencePlayer(base.GetItem(23));
		}

		// Token: 0x060412C8 RID: 266952 RVA: 0x010B83F0 File Offset: 0x010B65F0
		private void InitAutoPlayComponent()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			PlotAutoPlayComponentContext context = new PlotAutoPlayComponentContext
			{
				Toggle = extendToggle,
				WaitTime = PlotComponentUtils.GetAutoPlayEndWaitTime(false),
				AutoInSeqName = "Auto_In",
				AutoOutSeqName = "Auto_Out",
				CheckTalkFinishedDelegate = new Func<bool>(this.CheckTalkFinished),
				ContinueToNextTalkDelegate = new Action(this.ContinueToNextTalk)
			};
			this.AutoPlayComponent.Init(context);
		}

		// Token: 0x060412C9 RID: 266953 RVA: 0x010B8464 File Offset: 0x010B6664
		protected override void OnTick(float delta)
		{
			this.WaitingProxyComponent.OnTick(delta);
		}

		// Token: 0x060412CA RID: 266954 RVA: 0x010B8474 File Offset: 0x010B6674
		private void UpdateByPlotConfig()
		{
			this.SkipComp.EnableSkipButton(false);
			bool canPause = ModelBase<PlotModel>.Instance.PlotConfig.CanPause;
			this.AutoPlayComponent.SetToggleActive(canPause);
			this.AutoPlayComponent.UpdateAutoPlayToggle();
		}

		// Token: 0x060412CB RID: 266955 RVA: 0x010B84B4 File Offset: 0x010B66B4
		private void OnShowTalkStart(ShowTalk inShowTalk)
		{
			PlotSkipComponent skipComp = this.SkipComp;
			if (skipComp == null)
			{
				return;
			}
			skipComp.AddSummary(inShowTalk.TalkOutline);
		}

		// Token: 0x060412CC RID: 266956 RVA: 0x010B84CC File Offset: 0x010B66CC
		private void PlayTalk(ITalkItem talkItem)
		{
			this.ClearTalk();
			this.CurrentContent = talkItem;
			this.HandleTextLogic();
		}

		// Token: 0x060412CD RID: 266957 RVA: 0x010B84E4 File Offset: 0x010B66E4
		private void HandleTextLogic()
		{
			if (this.CurrentContent == null)
			{
				return;
			}
			ITalkItem currentContent = this.CurrentContent;
			bool flag = currentContent.Type.GetValueOrDefault() == ETalkItemType.AvgCenterText;
			bool flag2 = base.GetItem(7).IsUIActiveSelf();
			if (flag && flag2)
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlaySequence("Scene_Out", false, null);
				}
			}
			else if (!flag && !flag2)
			{
				base.GetItem(7).SetUIActive(true);
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				if (uiViewSequence2 != null)
				{
					uiViewSequence2.PlaySequence("Scene_In", false, null);
				}
			}
			base.GetItem(25).SetUIActive(flag);
			if (flag)
			{
				this.HandleAvgCenterText(currentContent);
				return;
			}
			int? whoId = currentContent.WhoId;
			AvgTalkerConfig? avgTalkerConfig = null;
			if (whoId != null && whoId.Value != 0)
			{
				avgTalkerConfig = PlotAvgUtils.GetAvgTalkerConfigByTalkerId(whoId.Value);
			}
			if (avgTalkerConfig != null)
			{
				base.GetItem(24).SetUIActive(true);
				string configIdByTable = Singleton<PublicUtil>.Instance.GetConfigIdByTable(ETableText.SpeakerName, new int?(whoId.Value));
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), configIdByTable, Array.Empty<object>());
			}
			else
			{
				base.GetItem(24).SetUIActive(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), currentContent.TidTalk, Array.Empty<object>());
			UUIText textComponent = this.DialogTextWriterComponent.GetTextComponent();
			if (textComponent == null)
			{
				return;
			}
			float textWriterAnimSpeed = PlotComponentUtils.GetTextWriterAnimSpeed(false);
			float textScrollDelayCharNum = PlotComponentUtils.GetTextScrollDelayCharNum();
			float textWriterAnimDuration = PlotComponentUtils.GetTextWriterAnimDuration(currentContent, textComponent, textWriterAnimSpeed);
			this.DialogTextWriterComponent.SetPlayDuration(textWriterAnimDuration);
			this.DialogTextWriterComponent.Play();
			this.TextScrollComponent.SetDelayCharNum(textScrollDelayCharNum);
			this.TextScrollComponent.SetCharReadSpeed(textWriterAnimSpeed);
			this.TextScrollComponent.PlayNextFrame();
			float talkWaitTime = PlotComponentUtils.GetTalkWaitTime(currentContent);
			this.WaitingProxyComponent.Wait(talkWaitTime);
			HashSet<int> speakerList = this.HandleAvgCharacterActions(currentContent, whoId, avgTalkerConfig);
			this.UpdateTalkerSpeakState(speakerList);
			this.PlotTextAkComponent.PlayTalkItemStartEvent(currentContent);
		}

		// Token: 0x060412CE RID: 266958 RVA: 0x010B86DC File Offset: 0x010B68DC
		private void HandleAvgCenterText(ITalkItem talkItem)
		{
			UUIText textComponent = this.CenterTextWriterComponent.GetTextComponent();
			if (textComponent == null)
			{
				return;
			}
			string tidTalk = talkItem.TidTalk;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(26), tidTalk, Array.Empty<object>());
			float textWriterAnimSpeed = PlotComponentUtils.GetTextWriterAnimSpeed(false);
			float textWriterAnimDuration = PlotComponentUtils.GetTextWriterAnimDuration(talkItem, textComponent, textWriterAnimSpeed);
			this.CenterTextWriterComponent.SetPlayDuration(textWriterAnimDuration);
			this.CenterTextWriterComponent.Play();
		}

		// Token: 0x060412CF RID: 266959 RVA: 0x010B8740 File Offset: 0x010B6940
		private HashSet<int> HandleAvgCharacterActions(ITalkItem talkItem, int? whoId, AvgTalkerConfig? avgTalkerConfig)
		{
			HashSet<int> hashSet = new HashSet<int>();
			ETalkItemType? type = talkItem.Type;
			if (type != null)
			{
				switch (type.GetValueOrDefault())
				{
				case ETalkItemType.AvgTalk:
					this.HandleAvgTalk((ITalkItemAvgTalk)talkItem, whoId, avgTalkerConfig, hashSet);
					break;
				case ETalkItemType.AvgEnter:
					this.HandleAvgEnter((ITalkItemAvgEnter)talkItem, hashSet);
					break;
				case ETalkItemType.AvgExit:
					this.HandleAvgExit((ITalkItemAvgExit)talkItem);
					break;
				}
			}
			return hashSet;
		}

		// Token: 0x060412D0 RID: 266960 RVA: 0x010B87B0 File Offset: 0x010B69B0
		private void HandleAvgTalk(ITalkItemAvgTalk avgTalkItem, int? whoId, AvgTalkerConfig? avgTalkerConfig, HashSet<int> speakerSet)
		{
			EAvgRolePosition positionConfig = avgTalkItem.PositionConfig;
			if (whoId == null || whoId.Value == 0 || avgTalkerConfig == null)
			{
				return;
			}
			if (avgTalkerConfig.Value.IsGroup)
			{
				this.HandleGroupDialog(avgTalkItem, speakerSet);
				return;
			}
			ITalkItemAvgRoleConfig avgRoleConfig = avgTalkItem.AvgRoleConfig;
			EAvgRoleAnimationType animationType = avgRoleConfig.AnimationType;
			bool valueOrDefault = avgRoleConfig.IsAnimationLoop.GetValueOrDefault(true);
			this.HandleSingleDialog(whoId.Value, positionConfig, animationType, valueOrDefault, speakerSet);
		}

		// Token: 0x060412D1 RID: 266961 RVA: 0x010B882C File Offset: 0x010B6A2C
		private void HandleGroupDialog(ITalkItemAvgTalk avgTalkItem, HashSet<int> speakerSet)
		{
			List<ActionInfo> actions = avgTalkItem.Actions;
			if (actions == null || actions.Count == 0)
			{
				return;
			}
			foreach (ActionInfo actionInfo in actions)
			{
				if (actionInfo.Name == EAction.AvgPlayRoleAction)
				{
					foreach (IAvgPlayRoleActionItem avgPlayRoleActionItem in ((AvgPlayRoleAction)actionInfo.Params).RoleActionList)
					{
						if (avgPlayRoleActionItem.ActionType == EAvgPlayRoleActionType.GroupDialog)
						{
							AvgTalkerEnterActionContext context = new AvgTalkerEnterActionContext
							{
								CharacterId = avgPlayRoleActionItem.RoleId,
								Position = avgPlayRoleActionItem.PositionConfig.Value,
								AnimationType = avgPlayRoleActionItem.AnimationType,
								IsLoop = avgPlayRoleActionItem.IsAnimationLoop.GetValueOrDefault(true)
							};
							ModelBase<PlotModel>.Instance.PlotAvg.AvgCharacterEnterOrChangeAnim(context).Forget();
							speakerSet.Add(avgPlayRoleActionItem.RoleId);
						}
					}
				}
			}
		}

		// Token: 0x060412D2 RID: 266962 RVA: 0x010B8964 File Offset: 0x010B6B64
		private void HandleSingleDialog(int whoId, EAvgRolePosition positionConfig, EAvgRoleAnimationType animationType, bool isLoop, HashSet<int> speakerSet)
		{
			speakerSet.Add(whoId);
			AvgTalkerEnterActionContext context = new AvgTalkerEnterActionContext
			{
				CharacterId = whoId,
				Position = positionConfig,
				AnimationType = animationType,
				IsLoop = isLoop
			};
			ModelBase<PlotModel>.Instance.PlotAvg.AvgCharacterEnterOrChangeAnim(context).Forget();
		}

		// Token: 0x060412D3 RID: 266963 RVA: 0x010B89B4 File Offset: 0x010B6BB4
		private void HandleAvgEnter(ITalkItemAvgEnter avgTalkItem, HashSet<int> speakerSet)
		{
			int? whoId = avgTalkItem.WhoId;
			if (whoId == null || whoId.Value == 0)
			{
				return;
			}
			speakerSet.Add(whoId.Value);
			ITalkItemAvgRoleConfig avgRoleConfig = avgTalkItem.AvgRoleConfig;
			EAvgRoleAnimationType animationType = avgRoleConfig.AnimationType;
			bool valueOrDefault = avgRoleConfig.IsAnimationLoop.GetValueOrDefault();
			AvgTalkerEnterActionContext context = new AvgTalkerEnterActionContext
			{
				CharacterId = whoId.Value,
				Position = avgTalkItem.PositionConfig,
				AnimationType = animationType,
				IsLoop = valueOrDefault
			};
			ModelBase<PlotModel>.Instance.PlotAvg.AvgCharacterEnterAsync(context).Forget<bool>();
		}

		// Token: 0x060412D4 RID: 266964 RVA: 0x010B8A48 File Offset: 0x010B6C48
		private void HandleAvgExit(ITalkItemAvgExit avgTalkItem)
		{
			int? whoId = avgTalkItem.WhoId;
			if (whoId == null || whoId.Value == 0)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.PlotAvg.AvgCharacterExitAsync(whoId.Value).Forget<bool>();
		}

		// Token: 0x060412D5 RID: 266965 RVA: 0x010B8A8C File Offset: 0x010B6C8C
		private void ClearTalk()
		{
			if (this.CurrentContent != null)
			{
				this.PlotTextAkComponent.PlayTalkItemEndEvent(this.CurrentContent);
			}
			this.CurrentContent = null;
			this.TextScrollComponent.Stop();
			this.OptionComponent.HideOptions();
			this.DialogTextWriterComponent.Stop();
			this.CenterTextWriterComponent.Stop();
			this.WaitingProxyComponent.Cancel();
		}

		// Token: 0x060412D6 RID: 266966 RVA: 0x010B8AF0 File Offset: 0x010B6CF0
		private void TryContinue()
		{
			if (this.CurrentContent == null)
			{
				return;
			}
			if (this.WaitingProxyComponent.GetIsWaiting())
			{
				return;
			}
			if (this.CenterTextWriterComponent.GetIsPlaying())
			{
				this.CenterTextWriterComponent.JumpToEnd();
				return;
			}
			if (this.DialogTextWriterComponent.GetIsPlaying() || this.TextScrollComponent.GetIsPlaying())
			{
				this.JumpToEnd();
				return;
			}
			this.ContinueInternal();
		}

		// Token: 0x060412D7 RID: 266967 RVA: 0x010B8B54 File Offset: 0x010B6D54
		private void ContinueInternal()
		{
			ControllerBase<FlowController>.Instance.FlowShowTalk.SubmitSubtitle(this.CurrentContent);
		}

		// Token: 0x060412D8 RID: 266968 RVA: 0x010B8B6B File Offset: 0x010B6D6B
		private void JumpToEnd()
		{
			this.DialogTextWriterComponent.JumpToEnd();
			this.TextScrollComponent.JumpToEnd();
		}

		// Token: 0x060412D9 RID: 266969 RVA: 0x010B8B84 File Offset: 0x010B6D84
		public void ShowOptions()
		{
			if (this.CurrentContent == null || this.CurrentContent.Options == null || this.CurrentContent.Options.Count == 0)
			{
				return;
			}
			this.OptionComponent.ShowOptions();
			PlotOptionComponent optionComponent = this.OptionComponent;
			List<ITalkOption> options = this.CurrentContent.Options;
			optionComponent.RefreshOptions((options != null) ? options.ToArray() : null);
		}

		// Token: 0x060412DA RID: 266970 RVA: 0x010B8BE6 File Offset: 0x010B6DE6
		private void ClearPlotSubtitle()
		{
			this.CurrentContent = null;
			this.ClearPlotView();
		}

		// Token: 0x060412DB RID: 266971 RVA: 0x010B8BF5 File Offset: 0x010B6DF5
		private void ClearPlotView()
		{
			this.TextScrollComponent.Clear();
		}

		// Token: 0x060412DC RID: 266972 RVA: 0x010B8C02 File Offset: 0x010B6E02
		private void HideAll(bool isHidden)
		{
		}

		// Token: 0x060412DD RID: 266973 RVA: 0x010B8C04 File Offset: 0x010B6E04
		private void BuildOptionItemDataList(ITalkOption[] options)
		{
			this.OptionItemDataList.Clear();
			for (int i = 0; i < options.Length; i++)
			{
				ITalkOption talkOption = options[i];
				if (talkOption != null)
				{
					PinballPlotOptionItemData item = new PinballPlotOptionItemData
					{
						OptionIndex = i,
						OptionText = new TableTextArgNew(talkOption.TidTalkOption, Array.Empty<object>()),
						OptionDelegate = new Action<int>(this.OnOptionClick)
					};
					this.OptionItemDataList.Add(item);
				}
			}
		}

		// Token: 0x060412DE RID: 266974 RVA: 0x010B8C72 File Offset: 0x010B6E72
		private void SetOptionRootItemActive(bool active)
		{
			base.GetItem(22).SetUIActive(active);
		}

		// Token: 0x060412DF RID: 266975 RVA: 0x010B8C82 File Offset: 0x010B6E82
		private void OnRefreshOptions(ITalkOption[] options)
		{
			this.BuildOptionItemDataList(options);
			this.OptionLayout.RefreshByData(this.OptionItemDataList, null, false);
		}

		// Token: 0x060412E0 RID: 266976 RVA: 0x010B8C9E File Offset: 0x010B6E9E
		private void OnOptionsShow()
		{
			this.SetOptionRootItemActive(true);
		}

		// Token: 0x060412E1 RID: 266977 RVA: 0x010B8CA7 File Offset: 0x010B6EA7
		private void OnOptionsHide()
		{
			this.SetOptionRootItemActive(false);
		}

		// Token: 0x060412E2 RID: 266978 RVA: 0x010B8CB0 File Offset: 0x010B6EB0
		private void OnOptionClick(int optionIndex)
		{
			this.OptionComponent.SelectOption(optionIndex);
		}

		// Token: 0x060412E3 RID: 266979 RVA: 0x010B8CBE File Offset: 0x010B6EBE
		private void OnSelectionItemClick(int optionIndex)
		{
			this.OptionComponent.SelectOption(optionIndex);
		}

		// Token: 0x060412E4 RID: 266980 RVA: 0x010B8CCC File Offset: 0x010B6ECC
		protected void SetContinueArrowActive(bool active)
		{
			ModelBase<PlotModel>.Instance.CanClick = active;
			base.GetSprite(11).SetUIActive(active);
			if (active)
			{
				this.UiViewSequence.PlayOrReplaySequenceByName("Page", false, null);
				return;
			}
			this.UiViewSequence.StopSequenceByKey("Page", false, false);
		}

		// Token: 0x060412E5 RID: 266981 RVA: 0x010B8D24 File Offset: 0x010B6F24
		private void ShowWaiting()
		{
			base.GetItem(23).SetUIActive(true);
			this.WaitingItemSeqPlayer.PlayOrReplaySequenceByName("Progressing", false, null);
			this.SetContinueArrowActive(false);
		}

		// Token: 0x060412E6 RID: 266982 RVA: 0x010B8D60 File Offset: 0x010B6F60
		private void HideWaiting()
		{
			base.GetItem(23).SetUIActive(false);
			this.WaitingItemSeqPlayer.StopSequenceByKey("Progressing", false, false);
			this.SetContinueArrowActive(true);
		}

		// Token: 0x060412E7 RID: 266983 RVA: 0x010B8D89 File Offset: 0x010B6F89
		private void OnWaitingStart()
		{
			this.ShowWaiting();
		}

		// Token: 0x060412E8 RID: 266984 RVA: 0x010B8D91 File Offset: 0x010B6F91
		private void OnWaitingComplete()
		{
			this.HideWaiting();
			this.AutoPlayComponent.TryDelayPlayNextTalk();
		}

		// Token: 0x060412E9 RID: 266985 RVA: 0x010B8DA5 File Offset: 0x010B6FA5
		private void OnWaitingCancel()
		{
			this.HideWaiting();
		}

		// Token: 0x060412EA RID: 266986 RVA: 0x010B8DAD File Offset: 0x010B6FAD
		private PinballPlotOptionItem CreateOptionItem()
		{
			return new PinballPlotOptionItem();
		}

		// Token: 0x060412EB RID: 266987 RVA: 0x010B8DB4 File Offset: 0x010B6FB4
		private void OnSkip()
		{
			ControllerBase<FlowController>.Instance.BackgroundFlow("UI点击跳过(PlotSubtitleView)", true, false, false);
		}

		// Token: 0x060412EC RID: 266988 RVA: 0x010B8DC8 File Offset: 0x010B6FC8
		private void OnSkipPop()
		{
			this.AutoPlayComponent.MuteAutoPlay(true);
		}

		// Token: 0x060412ED RID: 266989 RVA: 0x010B8DD6 File Offset: 0x010B6FD6
		private void OnSkipCancel()
		{
			this.AutoPlayComponent.MuteAutoPlay(false);
		}

		// Token: 0x060412EE RID: 266990 RVA: 0x010B8DE4 File Offset: 0x010B6FE4
		private void OnNextButtonClick()
		{
			this.TryContinue();
		}

		// Token: 0x060412EF RID: 266991 RVA: 0x010B8DEC File Offset: 0x010B6FEC
		private void OnContinueButtonClick()
		{
			this.TryContinue();
		}

		// Token: 0x060412F0 RID: 266992 RVA: 0x010B8DF4 File Offset: 0x010B6FF4
		private bool CheckTalkFinished()
		{
			return !this.TextScrollComponent.GetIsPlaying() && !this.DialogTextWriterComponent.GetIsPlaying() && !this.CenterTextWriterComponent.GetIsPlaying() && !this.WaitingProxyComponent.GetIsWaiting();
		}

		// Token: 0x060412F1 RID: 266993 RVA: 0x010B8E2D File Offset: 0x010B702D
		private void ContinueToNextTalk()
		{
			this.ContinueInternal();
		}

		// Token: 0x060412F2 RID: 266994 RVA: 0x010B8E35 File Offset: 0x010B7035
		private void OnTextWriterEnd()
		{
			this.AutoPlayComponent.TryDelayPlayNextTalk();
		}

		// Token: 0x060412F3 RID: 266995 RVA: 0x010B8E44 File Offset: 0x010B7044
		public UniTask PlayCharacterEnterPerformAsync(AvgTalkerEnterActionContext context)
		{
			PinballPlotView.<PlayCharacterEnterPerformAsync>d__82 <PlayCharacterEnterPerformAsync>d__;
			<PlayCharacterEnterPerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCharacterEnterPerformAsync>d__.<>4__this = this;
			<PlayCharacterEnterPerformAsync>d__.context = context;
			<PlayCharacterEnterPerformAsync>d__.<>1__state = -1;
			<PlayCharacterEnterPerformAsync>d__.<>t__builder.Start<PinballPlotView.<PlayCharacterEnterPerformAsync>d__82>(ref <PlayCharacterEnterPerformAsync>d__);
			return <PlayCharacterEnterPerformAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060412F4 RID: 266996 RVA: 0x010B8E90 File Offset: 0x010B7090
		public UniTask PlayCharacterExitPerformAsync(int characterId)
		{
			PinballPlotView.<PlayCharacterExitPerformAsync>d__83 <PlayCharacterExitPerformAsync>d__;
			<PlayCharacterExitPerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCharacterExitPerformAsync>d__.<>4__this = this;
			<PlayCharacterExitPerformAsync>d__.characterId = characterId;
			<PlayCharacterExitPerformAsync>d__.<>1__state = -1;
			<PlayCharacterExitPerformAsync>d__.<>t__builder.Start<PinballPlotView.<PlayCharacterExitPerformAsync>d__83>(ref <PlayCharacterExitPerformAsync>d__);
			return <PlayCharacterExitPerformAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060412F5 RID: 266997 RVA: 0x010B8EDC File Offset: 0x010B70DC
		public UniTask PlayCharacterMovePerformAsync(AvgTalkerMoveActionContext context)
		{
			PinballPlotView.<PlayCharacterMovePerformAsync>d__84 <PlayCharacterMovePerformAsync>d__;
			<PlayCharacterMovePerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCharacterMovePerformAsync>d__.<>4__this = this;
			<PlayCharacterMovePerformAsync>d__.context = context;
			<PlayCharacterMovePerformAsync>d__.<>1__state = -1;
			<PlayCharacterMovePerformAsync>d__.<>t__builder.Start<PinballPlotView.<PlayCharacterMovePerformAsync>d__84>(ref <PlayCharacterMovePerformAsync>d__);
			return <PlayCharacterMovePerformAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060412F6 RID: 266998 RVA: 0x010B8F28 File Offset: 0x010B7128
		public void ChangeCharacterAnim(int characterId, EAvgRoleAnimationType animationType, bool isLoop)
		{
			PinballAvgCharacter pinballAvgCharacter;
			if (!this.AvgCharacterMap.TryGetValue(characterId, out pinballAvgCharacter))
			{
				return;
			}
			PlotAvgCharacter character = ModelBase<PlotModel>.Instance.PlotAvg.GetCharacter(characterId);
			if (character == null)
			{
				return;
			}
			pinballAvgCharacter.PlayAnimation(character.Direction, animationType, isLoop);
		}

		// Token: 0x060412F7 RID: 266999 RVA: 0x010B8F6C File Offset: 0x010B716C
		private void UpdateTalkerSpeakState(HashSet<int> speakerList)
		{
			foreach (KeyValuePair<int, PinballAvgCharacter> keyValuePair in this.AvgCharacterMap)
			{
				keyValuePair.Value.UpdateSpeakStatus(speakerList.Contains(keyValuePair.Key));
			}
		}

		// Token: 0x040247E3 RID: 149475
		[Nullable(2)]
		protected ITalkItem CurrentContent;

		// Token: 0x040247E4 RID: 149476
		protected List<IPinballPlotOptionItemData> OptionItemDataList;

		// Token: 0x040247E5 RID: 149477
		protected List<IPinballPlotSelectionItemData> SelectionItemDataList;

		// Token: 0x040247E6 RID: 149478
		protected Dictionary<int, PinballAvgCharacter> AvgCharacterMap;

		// Token: 0x040247E7 RID: 149479
		protected Dictionary<EAvgRolePosition, UUIItem> PosItemMap;

		// Token: 0x040247E8 RID: 149480
		protected List<PinballPlotSelectionItem> SelectionItemList;

		// Token: 0x040247E9 RID: 149481
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<PinballPlotOptionItem, IPinballPlotOptionItemData> OptionLayout;

		// Token: 0x040247EA RID: 149482
		protected PlotTextScrollComponent TextScrollComponent;

		// Token: 0x040247EB RID: 149483
		protected PlotOptionComponent OptionComponent;

		// Token: 0x040247EC RID: 149484
		protected PlotTextWriterComponent DialogTextWriterComponent;

		// Token: 0x040247ED RID: 149485
		protected PlotTextWriterComponent CenterTextWriterComponent;

		// Token: 0x040247EE RID: 149486
		protected PlotWaitingProxyComponent WaitingProxyComponent;

		// Token: 0x040247EF RID: 149487
		protected PlotAutoPlayComponent AutoPlayComponent;

		// Token: 0x040247F0 RID: 149488
		protected PlotTextAudioComponent PlotTextAkComponent;

		// Token: 0x040247F1 RID: 149489
		[Nullable(2)]
		protected PlotSkipComponent SkipComp;

		// Token: 0x040247F2 RID: 149490
		[Nullable(2)]
		protected LevelSequencePlayer WaitingItemSeqPlayer;

		// Token: 0x0200C5F0 RID: 50672
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CEC2 RID: 249538
			CaptionItem,
			// Token: 0x0403CEC3 RID: 249539
			AutoPlayToggle,
			// Token: 0x0403CEC4 RID: 249540
			SkipButton,
			// Token: 0x0403CEC5 RID: 249541
			SelectionItemA,
			// Token: 0x0403CEC6 RID: 249542
			SelectionItemB,
			// Token: 0x0403CEC7 RID: 249543
			SelectionItemC,
			// Token: 0x0403CEC8 RID: 249544
			NextButton,
			// Token: 0x0403CEC9 RID: 249545
			ContentRootItem,
			// Token: 0x0403CECA RID: 249546
			SpeakerNameText,
			// Token: 0x0403CECB RID: 249547
			DialogScrollView,
			// Token: 0x0403CECC RID: 249548
			DialogText,
			// Token: 0x0403CECD RID: 249549
			ContinueArrowSprite,
			// Token: 0x0403CECE RID: 249550
			ContinueButton,
			// Token: 0x0403CECF RID: 249551
			SpineRootItem,
			// Token: 0x0403CED0 RID: 249552
			LeftPosItemA,
			// Token: 0x0403CED1 RID: 249553
			LeftPosItemB,
			// Token: 0x0403CED2 RID: 249554
			CenterPosItem,
			// Token: 0x0403CED3 RID: 249555
			RightPosItemB,
			// Token: 0x0403CED4 RID: 249556
			RightPosItemA,
			// Token: 0x0403CED5 RID: 249557
			SpineTemplateItem,
			// Token: 0x0403CED6 RID: 249558
			OptionLayout,
			// Token: 0x0403CED7 RID: 249559
			OptionItem,
			// Token: 0x0403CED8 RID: 249560
			OptionRootItem,
			// Token: 0x0403CED9 RID: 249561
			WaitingItem,
			// Token: 0x0403CEDA RID: 249562
			SpeakerNameRootItem,
			// Token: 0x0403CEDB RID: 249563
			BlackScreenRootItem,
			// Token: 0x0403CEDC RID: 249564
			CenterText,
			// Token: 0x0403CEDD RID: 249565
			BgTexture,
			// Token: 0x0403CEDE RID: 249566
			DecorationTexture
		}
	}
}
