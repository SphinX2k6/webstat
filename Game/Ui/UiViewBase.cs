using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049B9 RID: 18873
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class UiViewBase : UiPanelBase
	{
		// Token: 0x06031555 RID: 202069 RVA: 0x00C47A0C File Offset: 0x00C45C0C
		protected UiViewBase(UiViewInfo viewInfo)
		{
			this.ViewInfo = viewInfo;
			this.MaskTag = ((viewInfo != null) ? viewInfo.Name.ToString() : null) + this.ComponentId.ToString();
			this.MemoryTag = Singleton<UiConfig>.Instance.GetMemoryTag(viewInfo.Name);
		}

		// Token: 0x1700841A RID: 33818
		// (get) Token: 0x06031556 RID: 202070 RVA: 0x00C47A8A File Offset: 0x00C45C8A
		public bool IsQueueView
		{
			get
			{
				return this.ViewInfo.SortIndex >= 0;
			}
		}

		// Token: 0x06031557 RID: 202071 RVA: 0x00C47A9D File Offset: 0x00C45C9D
		[NullableContext(2)]
		public override CustomPromise GetClosePromiseImplement()
		{
			return this.ClosePromise;
		}

		// Token: 0x06031558 RID: 202072 RVA: 0x00C47AA5 File Offset: 0x00C45CA5
		protected virtual void OnAddEventListener()
		{
		}

		// Token: 0x06031559 RID: 202073 RVA: 0x00C47AA7 File Offset: 0x00C45CA7
		protected virtual void OnRemoveEventListener()
		{
		}

		// Token: 0x0603155A RID: 202074 RVA: 0x00C47AA9 File Offset: 0x00C45CA9
		protected virtual UniTask OnPlayingStartSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603155B RID: 202075 RVA: 0x00C47AB0 File Offset: 0x00C45CB0
		protected virtual void OnAfterPlayStartSequence()
		{
		}

		// Token: 0x0603155C RID: 202076 RVA: 0x00C47AB2 File Offset: 0x00C45CB2
		protected virtual void OnBeforePlayCloseSequence()
		{
		}

		// Token: 0x0603155D RID: 202077 RVA: 0x00C47AB4 File Offset: 0x00C45CB4
		protected virtual UniTask OnPlayingCloseSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603155E RID: 202078 RVA: 0x00C47ABB File Offset: 0x00C45CBB
		protected virtual UniTask OnPlayingHideSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603155F RID: 202079 RVA: 0x00C47AC2 File Offset: 0x00C45CC2
		protected virtual bool OnCheckIfNeedScene()
		{
			return true;
		}

		// Token: 0x06031560 RID: 202080 RVA: 0x00C47AC5 File Offset: 0x00C45CC5
		protected virtual void OnHandleLoadScene()
		{
		}

		// Token: 0x06031561 RID: 202081 RVA: 0x00C47AC8 File Offset: 0x00C45CC8
		protected virtual UniTask HandlePostLoadSceneAsync(bool isSceneLoad)
		{
			UiViewBase.<HandlePostLoadSceneAsync>d__35 <HandlePostLoadSceneAsync>d__;
			<HandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandlePostLoadSceneAsync>d__.<>4__this = this;
			<HandlePostLoadSceneAsync>d__.isSceneLoad = isSceneLoad;
			<HandlePostLoadSceneAsync>d__.<>1__state = -1;
			<HandlePostLoadSceneAsync>d__.<>t__builder.Start<UiViewBase.<HandlePostLoadSceneAsync>d__35>(ref <HandlePostLoadSceneAsync>d__);
			return <HandlePostLoadSceneAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031562 RID: 202082 RVA: 0x00C47B13 File Offset: 0x00C45D13
		protected virtual UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06031563 RID: 202083 RVA: 0x00C47B1A File Offset: 0x00C45D1A
		protected virtual void OnHandlePostLoadScene(bool isSceneLoad)
		{
		}

		// Token: 0x06031564 RID: 202084 RVA: 0x00C47B1C File Offset: 0x00C45D1C
		protected virtual void OnHandleReleaseScene()
		{
		}

		// Token: 0x06031565 RID: 202085 RVA: 0x00C47B20 File Offset: 0x00C45D20
		protected UniTask HandlePreReleaseSceneAsync(bool isSceneRelease)
		{
			UiViewBase.<HandlePreReleaseSceneAsync>d__39 <HandlePreReleaseSceneAsync>d__;
			<HandlePreReleaseSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandlePreReleaseSceneAsync>d__.<>4__this = this;
			<HandlePreReleaseSceneAsync>d__.isSceneRelease = isSceneRelease;
			<HandlePreReleaseSceneAsync>d__.<>1__state = -1;
			<HandlePreReleaseSceneAsync>d__.<>t__builder.Start<UiViewBase.<HandlePreReleaseSceneAsync>d__39>(ref <HandlePreReleaseSceneAsync>d__);
			return <HandlePreReleaseSceneAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031566 RID: 202086 RVA: 0x00C47B6B File Offset: 0x00C45D6B
		protected virtual UniTask OnHandlePreReleaseSceneAsync(bool isSceneRelease)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06031567 RID: 202087 RVA: 0x00C47B72 File Offset: 0x00C45D72
		public virtual void CloseSelf()
		{
			this.CloseMeAsync().ContinueWith(delegate(bool result)
			{
				if (!result)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiCore;
					ELogAuthor author = ELogAuthor.TL;
					string message = "[CloseMe]流程执行异常";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewInfo.Name);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			});
		}

		// Token: 0x06031568 RID: 202088 RVA: 0x00C47B8C File Offset: 0x00C45D8C
		[NullableContext(2)]
		public void CloseMe(Action<bool> callback = null)
		{
			this.CloseMeAsync().ContinueWith(delegate(bool result)
			{
				if (result)
				{
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(true);
					return;
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiCore;
					ELogAuthor author = ELogAuthor.TL;
					string message = "[CloseMe]流程执行异常";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewInfo.Name);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(false);
					return;
				}
			});
		}

		// Token: 0x06031569 RID: 202089 RVA: 0x00C47BC8 File Offset: 0x00C45DC8
		[NullableContext(0)]
		public override UniTask<bool> CloseMeAsync()
		{
			UiViewBase.<CloseMeAsync>d__43 <CloseMeAsync>d__;
			<CloseMeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseMeAsync>d__.<>4__this = this;
			<CloseMeAsync>d__.<>1__state = -1;
			<CloseMeAsync>d__.<>t__builder.Start<UiViewBase.<CloseMeAsync>d__43>(ref <CloseMeAsync>d__);
			return <CloseMeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603156A RID: 202090 RVA: 0x00C47C0B File Offset: 0x00C45E0B
		public int GetViewId()
		{
			return this.ComponentId;
		}

		// Token: 0x0603156B RID: 202091 RVA: 0x00C47C14 File Offset: 0x00C45E14
		protected void PlaySequence(string sequenceName, [Nullable(2)] Action onStop = null, bool blockClick = false)
		{
			this.PlaySequenceAsync(sequenceName, blockClick, false, null).ContinueWith(delegate()
			{
				Action onStop2 = onStop;
				if (onStop2 == null)
				{
					return;
				}
				onStop2();
			});
		}

		// Token: 0x0603156C RID: 202092 RVA: 0x00C47C54 File Offset: 0x00C45E54
		protected UniTask PlaySequenceAsync(string sequenceName, bool blockClick = false, bool playReverse = false, float? playRate = null)
		{
			UiViewBase.<PlaySequenceAsync>d__46 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.blockClick = blockClick;
			<PlaySequenceAsync>d__.playReverse = playReverse;
			<PlaySequenceAsync>d__.playRate = playRate;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<UiViewBase.<PlaySequenceAsync>d__46>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603156D RID: 202093 RVA: 0x00C47CB8 File Offset: 0x00C45EB8
		protected void PlayOrReplaySequence(string sequenceName, bool blockClick = false, int? playRate = null)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			int? num = playRate;
			uiViewSequence.PlayOrReplaySequenceByName(sequenceName, blockClick, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
		}

		// Token: 0x0603156E RID: 202094 RVA: 0x00C47CF5 File Offset: 0x00C45EF5
		[NullableContext(2)]
		protected void SetAudioEvent(string audioEvent)
		{
			this.AudioEvent = audioEvent;
		}

		// Token: 0x0603156F RID: 202095 RVA: 0x00C47CFE File Offset: 0x00C45EFE
		protected virtual void RegisterUiBehavior()
		{
			this.InitUiViewSequenceBehavior();
			this.RegisterUiBlur();
			this.RegisterUiAudio();
			this.RegisterUiBehaviorHomeBtn();
		}

		// Token: 0x06031570 RID: 202096 RVA: 0x00C47D18 File Offset: 0x00C45F18
		private void PlayViewSequence(string sequenceName, [Nullable(2)] Action onStop = null)
		{
			this.PlaySequence(sequenceName, onStop, (this.ViewInfo.Type & (ELayerType.Normal | ELayerType.Plot | ELayerType.Pop)) > (ELayerType)0);
		}

		// Token: 0x06031571 RID: 202097 RVA: 0x00C47D34 File Offset: 0x00C45F34
		private UniTask PlayViewSequenceAsync(string sequenceName)
		{
			UiViewBase.<PlayViewSequenceAsync>d__51 <PlayViewSequenceAsync>d__;
			<PlayViewSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayViewSequenceAsync>d__.<>4__this = this;
			<PlayViewSequenceAsync>d__.sequenceName = sequenceName;
			<PlayViewSequenceAsync>d__.<>1__state = -1;
			<PlayViewSequenceAsync>d__.<>t__builder.Start<UiViewBase.<PlayViewSequenceAsync>d__51>(ref <PlayViewSequenceAsync>d__);
			return <PlayViewSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031572 RID: 202098 RVA: 0x00C47D7F File Offset: 0x00C45F7F
		public void PauseCurrentSequence()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PauseSequence();
		}

		// Token: 0x06031573 RID: 202099 RVA: 0x00C47D91 File Offset: 0x00C45F91
		public void ResumeCurrentSequence()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.ResumeSequence();
		}

		// Token: 0x06031574 RID: 202100 RVA: 0x00C47DA3 File Offset: 0x00C45FA3
		private void InitUiViewSequenceBehavior()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			this.UiViewSequence.SetSequenceName(this.OpenParam as UiViewData);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x06031575 RID: 202101 RVA: 0x00C47DD4 File Offset: 0x00C45FD4
		private void RegisterUiBlur()
		{
			UiBehaviourUiBlur uiBehaviourUiBlur = new UiBehaviourUiBlur();
			this.UiBlurBehaviour = uiBehaviourUiBlur;
			uiBehaviourUiBlur.SetCurrentLayer(this.ViewInfo.Type);
			uiBehaviourUiBlur.SetViewInfo(this);
			base.AddUiBehavior(uiBehaviourUiBlur);
		}

		// Token: 0x06031576 RID: 202102 RVA: 0x00C47E10 File Offset: 0x00C46010
		private void RegisterUiAudio()
		{
			UiBehaviorAudio behavior = new UiBehaviorAudio(this);
			base.AddUiBehavior(behavior);
		}

		// Token: 0x06031577 RID: 202103 RVA: 0x00C47E2C File Offset: 0x00C4602C
		private void RegisterUiBehaviorHomeBtn()
		{
			UiBehaviourHomeBtn uiBehaviourHomeBtn = new UiBehaviourHomeBtn();
			this.UiBehaviourHomeBtn = uiBehaviourHomeBtn;
			uiBehaviourHomeBtn.SetViewInfo(this);
			base.AddUiBehavior(uiBehaviourHomeBtn);
		}

		// Token: 0x06031578 RID: 202104 RVA: 0x00C47E54 File Offset: 0x00C46054
		[NullableContext(2)]
		public UUIViewAudioEffectComponent GetUiAudioComponent()
		{
			AActor aactor = (this.ChildPopView != null) ? this.ChildPopView.GetPopViewRootActor() : this.RootActor;
			if (aactor == null || !aactor.IsValid())
			{
				return null;
			}
			return aactor.GetComponentByClass(UUIViewAudioEffectComponent.StaticClass()) as UUIViewAudioEffectComponent;
		}

		// Token: 0x06031579 RID: 202105 RVA: 0x00C47E9F File Offset: 0x00C4609F
		public string GetLoopAudioEvent()
		{
			return this.OnGetLoopAudioEvent();
		}

		// Token: 0x0603157A RID: 202106 RVA: 0x00C47EA7 File Offset: 0x00C460A7
		public void RefreshUiBlurBehaviour()
		{
			UiBehaviourUiBlur uiBlurBehaviour = this.UiBlurBehaviour;
			if (uiBlurBehaviour == null)
			{
				return;
			}
			uiBlurBehaviour.RefreshBlur();
		}

		// Token: 0x0603157B RID: 202107 RVA: 0x00C47EB9 File Offset: 0x00C460B9
		public UUIItem GetBlurRootItem()
		{
			return this.OnGetBlurRootItem();
		}

		// Token: 0x0603157C RID: 202108 RVA: 0x00C47EC1 File Offset: 0x00C460C1
		protected virtual UUIItem OnGetBlurRootItem()
		{
			return this.RootItem;
		}

		// Token: 0x0603157D RID: 202109 RVA: 0x00C47EC9 File Offset: 0x00C460C9
		public virtual bool GetLoopAudioEventSwitch()
		{
			return true;
		}

		// Token: 0x0603157E RID: 202110 RVA: 0x00C47ECC File Offset: 0x00C460CC
		[NullableContext(2)]
		private UUIItem GetLayerRoot()
		{
			if (this.IsPreOpening)
			{
				return Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Pool);
			}
			ELayerType layer = this.GetLayer();
			if (layer == ELayerType.Float)
			{
				UiFloatConfig? uiFloatConfig = ConfigBase<UiViewConfig>.Instance.GetUiFloatConfig(this.ViewInfo.Name);
				if (uiFloatConfig != null)
				{
					if (uiFloatConfig.Value.OnlyShowInMain)
					{
						return Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.BattleFloat, uiFloatConfig.Value.RootItemIndex);
					}
					return Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.Float, uiFloatConfig.Value.RootItemIndex);
				}
			}
			else if (layer == ELayerType.Loading)
			{
				return Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.Loading, 0);
			}
			return Singleton<UiLayer>.Instance.GetLayerRootUiItem(layer);
		}

		// Token: 0x0603157F RID: 202111 RVA: 0x00C47F90 File Offset: 0x00C46190
		public void InitRootActorLoadInfo()
		{
			UiViewInfo viewInfo = this.ViewInfo;
			base.SetRootActorLoadInfoByPath(viewInfo.UiPath, this.GetLayerRoot(), viewInfo.SourceType == ESourceType.UiActorPool, viewInfo.IsPermanent);
		}

		// Token: 0x06031580 RID: 202112 RVA: 0x00C47FC5 File Offset: 0x00C461C5
		protected virtual void OnBeforeCreateImplementImplement()
		{
		}

		// Token: 0x06031581 RID: 202113 RVA: 0x00C47FC7 File Offset: 0x00C461C7
		protected override void OnBeforeCreateImplement()
		{
			this.RegisterUiBehavior();
			this.OnBeforeCreateImplementImplement();
		}

		// Token: 0x06031582 RID: 202114 RVA: 0x00C47FD8 File Offset: 0x00C461D8
		protected override void OnAfterCreateImplement()
		{
			if (this.IsExistInLeaveLevel || Singleton<UiManager>.Instance.IsLockOpen)
			{
				Singleton<Log>.Instance.Info(ELogModule.UiCore, ELogAuthor.XXJ, "场景切换过程中, 设置无缝加载标记", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.SetViewPermanent();
			}
		}

		// Token: 0x06031583 RID: 202115 RVA: 0x00C4801C File Offset: 0x00C4621C
		private void SetViewPermanent()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCore;
			ELogAuthor author = ELogAuthor.TL;
			string message = "SetViewPermanent";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewInfo.Name);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<LguiUtil>.Instance.SetActorIsPermanent(base.GetOriginalActor(), true, true);
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			childPopView.SetViewPermanent();
		}

		// Token: 0x06031584 RID: 202116 RVA: 0x00C48084 File Offset: 0x00C46284
		protected override UniTask OnCreateAsyncImplementImplement()
		{
			UiViewBase.<OnCreateAsyncImplementImplement>d__70 <OnCreateAsyncImplementImplement>d__;
			<OnCreateAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsyncImplementImplement>d__.<>1__state = -1;
			<OnCreateAsyncImplementImplement>d__.<>t__builder.Start<UiViewBase.<OnCreateAsyncImplementImplement>d__70>(ref <OnCreateAsyncImplementImplement>d__);
			return <OnCreateAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031585 RID: 202117 RVA: 0x00C480BF File Offset: 0x00C462BF
		protected virtual void OnStartImplementImplement()
		{
		}

		// Token: 0x06031586 RID: 202118 RVA: 0x00C480C4 File Offset: 0x00C462C4
		protected override void OnStartImplement()
		{
			this.SetAudioEvent(this.ViewInfo.AudioEvent);
			this.LastUiSceneRendering = ULGUIBPLibrary.GetWorldUISceneRendering(base.GetRootActor());
			this.FirstShow = true;
			Singleton<EventSystem>.Instance.Emit<EUiViewName>(EEventName.OnViewLoadCompleted, this.ViewInfo.Name);
			Singleton<EventSystem>.Instance.Emit<EUiViewName, UiViewBase>(EEventName.OnViewDone, this.ViewInfo.Name, this);
			this.UiViewSequence.AddSequenceStartEvent(this.UiViewSequence.StartSequenceName.ToString(), delegate(string arg1)
			{
				this.SkipAnimViewFlow = false;
				TimerSystem.Instance.Next(delegate(float arg)
				{
					ControllerBase<InputDistributeController>.Instance.BindActions(this.ViewInfo.SkipAnimActions, new TInputHandle<InputDistributeDefine.EActionType>(this.InterruptOpSkipAnim));
				}, null, null);
			});
			this.UiViewSequence.AddSequenceFinishEvent(this.UiViewSequence.StartSequenceName.ToString(), delegate(string arg1)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActions(this.ViewInfo.SkipAnimActions, new TInputHandle<InputDistributeDefine.EActionType>(this.InterruptOpSkipAnim));
			}, false);
			this.OnStartImplementImplement();
		}

		// Token: 0x06031587 RID: 202119 RVA: 0x00C48180 File Offset: 0x00C46380
		protected virtual void OnBeforeShowImplementImplement()
		{
		}

		// Token: 0x06031588 RID: 202120 RVA: 0x00C48184 File Offset: 0x00C46384
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			UiViewBase.<OnBeforeShowAsyncImplement>d__74 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<UiViewBase.<OnBeforeShowAsyncImplement>d__74>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031589 RID: 202121 RVA: 0x00C481C7 File Offset: 0x00C463C7
		protected virtual UniTask OnBeforeShowAsyncImplementImplement()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603158A RID: 202122 RVA: 0x00C481D0 File Offset: 0x00C463D0
		private UniTask OnBeforeShowAsync()
		{
			UiViewBase.<OnBeforeShowAsync>d__76 <OnBeforeShowAsync>d__;
			<OnBeforeShowAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsync>d__.<>4__this = this;
			<OnBeforeShowAsync>d__.<>1__state = -1;
			<OnBeforeShowAsync>d__.<>t__builder.Start<UiViewBase.<OnBeforeShowAsync>d__76>(ref <OnBeforeShowAsync>d__);
			return <OnBeforeShowAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603158B RID: 202123 RVA: 0x00C48213 File Offset: 0x00C46413
		protected override void OnBeforeShowImplement()
		{
			this.OnAddEventListener();
			this.OnBeforeShowImplementImplement();
			this.ApplyPerformanceLimit();
		}

		// Token: 0x0603158C RID: 202124 RVA: 0x00C48228 File Offset: 0x00C46428
		protected override UniTask OnShowAsyncImplementImplement()
		{
			UiViewBase.<OnShowAsyncImplementImplement>d__78 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<UiViewBase.<OnShowAsyncImplementImplement>d__78>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603158D RID: 202125 RVA: 0x00C4826C File Offset: 0x00C4646C
		private void InterruptOpSkipAnim(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification ii)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			this.SkipAnimViewFlow = true;
			if (this.UiViewSequence.HasSequenceNameInPlaying(this.UiViewSequence.StartSequenceName.ToString()))
			{
				this.UiViewSequence.StopSequenceByKey(this.UiViewSequence.StartSequenceName.ToString(), true, true);
			}
			ControllerBase<InputDistributeController>.Instance.UnBindActions(this.ViewInfo.SkipAnimActions, new TInputHandle<InputDistributeDefine.EActionType>(this.InterruptOpSkipAnim));
		}

		// Token: 0x0603158E RID: 202126 RVA: 0x00C482E0 File Offset: 0x00C464E0
		public void TryEmitInterruptOpExitView()
		{
			if (this.SkipAnimViewFlow)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "跳过界面动画Start流程,关闭界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewInfo.Name);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<UiNavigationNewController>.Instance.HotKeyCloseView();
				this.SkipAnimViewFlow = false;
			}
		}

		// Token: 0x0603158F RID: 202127 RVA: 0x00C4833C File Offset: 0x00C4653C
		protected override void OnShowAsyncImplementImplementCompatible()
		{
			if (this.ViewInfo.IsFullScreen)
			{
				ULGUIBPLibrary.SetIsFullScreenUIRendering(base.GetRootActor(), true);
			}
			this.LoadScene();
			if (this.FirstShow)
			{
				this.PlayViewSequence(this.UiViewSequence.StartSequenceName, null);
				this.OnAfterPlayStartSequence();
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlaySequencePurely("AutoLoop", false, false);
				}
				this.FirstShow = false;
				return;
			}
			this.PlayViewSequence(this.UiViewSequence.ShowSequenceName, null);
		}

		// Token: 0x06031590 RID: 202128 RVA: 0x00C483BC File Offset: 0x00C465BC
		protected override void OnAfterShowImplement()
		{
			CustomPromise<bool> openPromise = this.OpenPromise;
			if (openPromise != null)
			{
				openPromise.SetResult(true);
			}
			CustomPromise showPromise = this.ShowPromise;
			if (showPromise != null)
			{
				showPromise.SetResult();
			}
			this.HandleAllLoadingFinishOperation();
			Singleton<EventSystem>.Instance.Emit<EUiViewName, UiViewBase>(EEventName.OnViewShow, this.ViewInfo.Name, this);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCore;
			ELogAuthor author = ELogAuthor.TZJ;
			string message = "界面显示完成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewInfo.Name);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031591 RID: 202129 RVA: 0x00C48444 File Offset: 0x00C46644
		protected unsafe override void HandleCacheShowActionFailIfIsPair()
		{
			if (this.FirstShow)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "界面在首次打开时已经执行了Hide逻辑,Show逻辑不生效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ViewName", this.ViewInfo.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentId", this.ComponentId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				CustomPromise<bool> openPromise = this.OpenPromise;
				if (openPromise == null)
				{
					return;
				}
				openPromise.SetResult(true);
			}
		}

		// Token: 0x06031592 RID: 202130 RVA: 0x00C484D8 File Offset: 0x00C466D8
		protected override UniTask OnHideAsyncImplementImplement()
		{
			UiViewBase.<OnHideAsyncImplementImplement>d__84 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<UiViewBase.<OnHideAsyncImplementImplement>d__84>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031593 RID: 202131 RVA: 0x00C4851C File Offset: 0x00C4671C
		protected override void OnHideAsyncImplementImplementCompatible()
		{
			this.CancelPerformanceSeqLimit();
			if (this.ViewInfo.IsFullScreen)
			{
				ULGUIBPLibrary.SetIsFullScreenUIRendering(base.GetRootActor(), this.LastUiSceneRendering);
			}
			if (this.LastHide)
			{
				this.LastHide = false;
				this.OnBeforePlayCloseSequence();
				this.PlayViewSequence(this.UiViewSequence.CloseSequenceName, null);
			}
			else
			{
				this.PlayViewSequence(this.UiViewSequence.HideSequenceName, null);
			}
			this.ReleaseScene();
		}

		// Token: 0x06031594 RID: 202132 RVA: 0x00C4858F File Offset: 0x00C4678F
		protected virtual void OnAfterHideImplementImplement()
		{
		}

		// Token: 0x06031595 RID: 202133 RVA: 0x00C48591 File Offset: 0x00C46791
		protected override void OnAfterHideImplement()
		{
			this.OnAfterHideImplementImplement();
			this.OnRemoveEventListener();
			Singleton<EventSystem>.Instance.Emit<EUiViewName>(EEventName.OnViewHidden, this.ViewInfo.Name);
			this.CancelPerformanceLimit();
			CustomPromise hidePromise = this.HidePromise;
			if (hidePromise == null)
			{
				return;
			}
			hidePromise.SetResult();
		}

		// Token: 0x06031596 RID: 202134 RVA: 0x00C485D0 File Offset: 0x00C467D0
		protected override UniTask OnDestroyAsyncImplementImplement()
		{
			UiViewBase.<OnDestroyAsyncImplementImplement>d__88 <OnDestroyAsyncImplementImplement>d__;
			<OnDestroyAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnDestroyAsyncImplementImplement>d__.<>4__this = this;
			<OnDestroyAsyncImplementImplement>d__.<>1__state = -1;
			<OnDestroyAsyncImplementImplement>d__.<>t__builder.Start<UiViewBase.<OnDestroyAsyncImplementImplement>d__88>(ref <OnDestroyAsyncImplementImplement>d__);
			return <OnDestroyAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031597 RID: 202135 RVA: 0x00C48613 File Offset: 0x00C46813
		protected override void OnDestroyAsyncImplementImplementCompatible()
		{
			this.ChildPopView = null;
			this.ResetOperationQueue();
			Singleton<UiManager>.Instance.RemoveView(this.GetViewId());
		}

		// Token: 0x06031598 RID: 202136 RVA: 0x00C48634 File Offset: 0x00C46834
		protected override void OnAfterDestroyImplement()
		{
			CustomPromise closePromise = this.ClosePromise;
			if (closePromise != null)
			{
				closePromise.SetResult();
			}
			Singleton<EventSystem>.Instance.Emit<EUiViewName, int>(EEventName.CloseView, this.ViewInfo.Name, this.GetViewId());
			if (this.ViewInfo.NeedGc)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "执行Force GC";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewInfo.Name);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<WorldController>.Instance.ManuallyGarbageCollection(EGarbageCollectionReason.CloseUiView);
				ControllerBase<WorldController>.Instance.ForceGarbageCollection(false);
			}
		}

		// Token: 0x06031599 RID: 202137 RVA: 0x00C486C9 File Offset: 0x00C468C9
		public void AddChildViewById(int childViewId)
		{
			base.AddChild(Singleton<UiManager>.Instance.GetView(childViewId));
		}

		// Token: 0x0603159A RID: 202138 RVA: 0x00C486DC File Offset: 0x00C468DC
		private UniTask PlayViewCloseSequenceAsync()
		{
			UiViewBase.<PlayViewCloseSequenceAsync>d__92 <PlayViewCloseSequenceAsync>d__;
			<PlayViewCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayViewCloseSequenceAsync>d__.<>4__this = this;
			<PlayViewCloseSequenceAsync>d__.<>1__state = -1;
			<PlayViewCloseSequenceAsync>d__.<>t__builder.Start<UiViewBase.<PlayViewCloseSequenceAsync>d__92>(ref <PlayViewCloseSequenceAsync>d__);
			return <PlayViewCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603159B RID: 202139 RVA: 0x00C48720 File Offset: 0x00C46920
		private UniTask PlayViewHideSequenceAsync()
		{
			UiViewBase.<PlayViewHideSequenceAsync>d__93 <PlayViewHideSequenceAsync>d__;
			<PlayViewHideSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayViewHideSequenceAsync>d__.<>4__this = this;
			<PlayViewHideSequenceAsync>d__.<>1__state = -1;
			<PlayViewHideSequenceAsync>d__.<>t__builder.Start<UiViewBase.<PlayViewHideSequenceAsync>d__93>(ref <PlayViewHideSequenceAsync>d__);
			return <PlayViewHideSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603159C RID: 202140 RVA: 0x00C48763 File Offset: 0x00C46963
		protected void DeleteCloseSequence()
		{
			this.UiViewSequence.CloseSequenceName = "Close";
		}

		// Token: 0x0603159D RID: 202141 RVA: 0x00C48775 File Offset: 0x00C46975
		public ELayerType GetLayer()
		{
			return this.OnGetLayer();
		}

		// Token: 0x0603159E RID: 202142 RVA: 0x00C4877D File Offset: 0x00C4697D
		protected virtual ELayerType OnGetLayer()
		{
			return this.ViewInfo.Type;
		}

		// Token: 0x0603159F RID: 202143 RVA: 0x00C4878A File Offset: 0x00C4698A
		public float GetTimeDilation()
		{
			return this.OnGetTimeDilation();
		}

		// Token: 0x060315A0 RID: 202144 RVA: 0x00C48792 File Offset: 0x00C46992
		protected virtual float OnGetTimeDilation()
		{
			return this.ViewInfo.TimeDilation;
		}

		// Token: 0x060315A1 RID: 202145 RVA: 0x00C4879F File Offset: 0x00C4699F
		protected virtual string OnGetLoopAudioEvent()
		{
			return this.ViewInfo.LoopAudioEvent;
		}

		// Token: 0x060315A2 RID: 202146 RVA: 0x00C487AC File Offset: 0x00C469AC
		public void SetLoadingFinishOperation(Action finishOperation)
		{
			this.OperationQueue.Push(finishOperation);
		}

		// Token: 0x060315A3 RID: 202147 RVA: 0x00C487BA File Offset: 0x00C469BA
		public void HandleAllLoadingFinishOperation()
		{
			while (this.OperationQueue.Size > 0)
			{
				Action action = this.OperationQueue.Pop();
				if (action != null)
				{
					action();
				}
			}
		}

		// Token: 0x060315A4 RID: 202148 RVA: 0x00C487E2 File Offset: 0x00C469E2
		public void ResetOperationQueue()
		{
			this.OperationQueue.Clear();
		}

		// Token: 0x060315A5 RID: 202149 RVA: 0x00C487EF File Offset: 0x00C469EF
		public virtual string GetBlackScreenTypeOnOpenViewLoadScene()
		{
			return "Start";
		}

		// Token: 0x060315A6 RID: 202150 RVA: 0x00C487F6 File Offset: 0x00C469F6
		public virtual string GetBlackScreenTypeOnShowViewLoadScene()
		{
			return "Start";
		}

		// Token: 0x060315A7 RID: 202151 RVA: 0x00C487FD File Offset: 0x00C469FD
		public bool WillLoadScene()
		{
			return !this.SkipLoadScene && !string.IsNullOrEmpty(this.ViewInfo.SceneId) && this.OnCheckIfNeedScene() && Singleton<UiSceneManager>.Instance.CurUiSceneId != this.ViewInfo.SceneId;
		}

		// Token: 0x060315A8 RID: 202152 RVA: 0x00C4883D File Offset: 0x00C46A3D
		public bool WillReleaseScene()
		{
			return !this.SkipReleaseScene && this.SceneLoaded;
		}

		// Token: 0x060315A9 RID: 202153 RVA: 0x00C48850 File Offset: 0x00C46A50
		public virtual UniTask LoadScene()
		{
			UiViewBase.<LoadScene>d__111 <LoadScene>d__;
			<LoadScene>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadScene>d__.<>4__this = this;
			<LoadScene>d__.<>1__state = -1;
			<LoadScene>d__.<>t__builder.Start<UiViewBase.<LoadScene>d__111>(ref <LoadScene>d__);
			return <LoadScene>d__.<>t__builder.Task;
		}

		// Token: 0x060315AA RID: 202154 RVA: 0x00C48894 File Offset: 0x00C46A94
		public virtual UniTask ReleaseScene()
		{
			UiViewBase.<ReleaseScene>d__112 <ReleaseScene>d__;
			<ReleaseScene>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ReleaseScene>d__.<>4__this = this;
			<ReleaseScene>d__.<>1__state = -1;
			<ReleaseScene>d__.<>t__builder.Start<UiViewBase.<ReleaseScene>d__112>(ref <ReleaseScene>d__);
			return <ReleaseScene>d__.<>t__builder.Task;
		}

		// Token: 0x060315AB RID: 202155 RVA: 0x00C488D7 File Offset: 0x00C46AD7
		public void OnPreOpen()
		{
			this.IsPreOpening = true;
			this.PreOpeningTimerId = TimerSystem.Instance.Delay(delegate(float delta)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[PreOpeningTimerId] 预打开界面超时未调用打开, 自动销毁界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewInfo.Name);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.Destroy(null);
				Singleton<UiManager>.Instance.RemovePreOpenView(this.GetViewId());
				this.PreOpeningTimerId = null;
			}, 60000f, null, null, true, 1f);
		}

		// Token: 0x060315AC RID: 202156 RVA: 0x00C4890C File Offset: 0x00C46B0C
		public void OnOpenAfterPreOpened()
		{
			this.IsPreOpening = false;
			if (TimerSystem.Instance.Has(this.PreOpeningTimerId))
			{
				TimerSystem.Instance.Remove(this.PreOpeningTimerId);
			}
			this.PreOpeningTimerId = null;
			if (this.GetOriginalItem() != null)
			{
				this.GetOriginalItem().SetUIParent(this.GetLayerRoot(), false);
			}
		}

		// Token: 0x060315AD RID: 202157 RVA: 0x00C48964 File Offset: 0x00C46B64
		public void SetParentUiItem(UUIItem parentUiItem)
		{
			if (this.ParentUiItem == parentUiItem)
			{
				return;
			}
			this.ParentUiItem = parentUiItem;
			UUIItem rootItem = base.GetRootItem();
			if (rootItem != null)
			{
				rootItem.SetUIParent(this.ParentUiItem, false);
			}
		}

		// Token: 0x060315AE RID: 202158 RVA: 0x00C4899C File Offset: 0x00C46B9C
		public UniTask ClearAsync()
		{
			UiViewBase.<ClearAsync>d__116 <ClearAsync>d__;
			<ClearAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearAsync>d__.<>4__this = this;
			<ClearAsync>d__.<>1__state = -1;
			<ClearAsync>d__.<>t__builder.Start<UiViewBase.<ClearAsync>d__116>(ref <ClearAsync>d__);
			return <ClearAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060315AF RID: 202159 RVA: 0x00C489E0 File Offset: 0x00C46BE0
		private bool GetCacheWorldFrame()
		{
			switch (this.ViewInfo.LockWorldRender)
			{
			case EViewLockWorldRenderType.Default:
				return this.ViewInfo.Type == ELayerType.Normal && string.IsNullOrEmpty(this.ViewInfo.SceneId);
			case EViewLockWorldRenderType.ForceLock:
				return true;
			case EViewLockWorldRenderType.Ignore:
				return false;
			default:
				return false;
			}
		}

		// Token: 0x060315B0 RID: 202160 RVA: 0x00C48A34 File Offset: 0x00C46C34
		public void ApplyPerformanceLimit()
		{
			bool cacheWorldFrame = this.GetCacheWorldFrame();
			if (!cacheWorldFrame && !this.ViewInfo.LockFrameRate)
			{
				return;
			}
			Singleton<GameSettingsDeviceRender>.Instance.ApplyPerformanceLimit(this.ViewInfo.Name.ToString(), cacheWorldFrame, this.ViewInfo.LockFrameRate);
		}

		// Token: 0x060315B1 RID: 202161 RVA: 0x00C48A88 File Offset: 0x00C46C88
		public void CancelPerformanceLimit()
		{
			Singleton<GameSettingsDeviceRender>.Instance.CancelPerformanceLimit(this.ViewInfo.Name.ToString());
		}

		// Token: 0x060315B2 RID: 202162 RVA: 0x00C48AB8 File Offset: 0x00C46CB8
		public void ApplyPerformanceSeqLimit()
		{
			bool flag = this.ViewInfo.LockWorldRender == EViewLockWorldRenderType.SeqLock;
			if (!flag && !this.ViewInfo.LockFrameRate)
			{
				return;
			}
			Singleton<GameSettingsDeviceRender>.Instance.ApplyPerformanceLimit(this.ViewInfo.Name.ToString() + "_Seq", flag, this.ViewInfo.LockFrameRate);
		}

		// Token: 0x060315B3 RID: 202163 RVA: 0x00C48B20 File Offset: 0x00C46D20
		public void CancelPerformanceSeqLimit()
		{
			Singleton<GameSettingsDeviceRender>.Instance.CancelPerformanceLimit(this.ViewInfo.Name.ToString() + "_Seq");
		}

		// Token: 0x0401C585 RID: 116101
		public readonly UiViewInfo ViewInfo;

		// Token: 0x0401C586 RID: 116102
		[Nullable(2)]
		public IUiPopFrameInterface ChildPopView;

		// Token: 0x0401C587 RID: 116103
		[Nullable(2)]
		public UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x0401C588 RID: 116104
		[Nullable(2)]
		protected UiBehaviourUiBlur UiBlurBehaviour;

		// Token: 0x0401C589 RID: 116105
		[Nullable(2)]
		protected UiBehaviourHomeBtn UiBehaviourHomeBtn;

		// Token: 0x0401C58A RID: 116106
		[Nullable(2)]
		protected string AudioEvent;

		// Token: 0x0401C58B RID: 116107
		private bool FirstShow = true;

		// Token: 0x0401C58C RID: 116108
		public bool LastHide;

		// Token: 0x0401C58D RID: 116109
		protected PlayResult PlayEventResult = new PlayResult();

		// Token: 0x0401C58E RID: 116110
		private bool LastUiSceneRendering;

		// Token: 0x0401C58F RID: 116111
		public bool IsPreOpening;

		// Token: 0x0401C590 RID: 116112
		public bool IsDestroyByClear;

		// Token: 0x0401C591 RID: 116113
		[Nullable(2)]
		private TimerHandle PreOpeningTimerId;

		// Token: 0x0401C592 RID: 116114
		public bool IsExistInLeaveLevel;

		// Token: 0x0401C593 RID: 116115
		[Nullable(2)]
		public CustomPromise<bool> OpenPromise;

		// Token: 0x0401C594 RID: 116116
		[Nullable(2)]
		public CustomPromise ClosePromise;

		// Token: 0x0401C595 RID: 116117
		[Nullable(2)]
		public CustomPromise ShowPromise;

		// Token: 0x0401C596 RID: 116118
		[Nullable(2)]
		public CustomPromise HidePromise;

		// Token: 0x0401C597 RID: 116119
		[Nullable(2)]
		public CustomPromise LoadScenePromise;

		// Token: 0x0401C598 RID: 116120
		private bool SkipAnimViewFlow;

		// Token: 0x0401C599 RID: 116121
		public readonly string MaskTag;

		// Token: 0x0401C59A RID: 116122
		private readonly Queue<Action> OperationQueue = new Queue<Action>(4);

		// Token: 0x0401C59B RID: 116123
		public bool SkipLoadScene;

		// Token: 0x0401C59C RID: 116124
		public bool SkipReleaseScene;

		// Token: 0x0401C59D RID: 116125
		public bool SceneLoaded;

		// Token: 0x0401C59E RID: 116126
		public bool SkipRemoveBlackScreen;
	}
}
