using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Birthday.View
{
	// Token: 0x02005F12 RID: 24338
	[NullableContext(1)]
	[Nullable(0)]
	public class BirthdayLetterView : UiTickViewBase, IUiViewResource
	{
		// Token: 0x0603D1E7 RID: 250343 RVA: 0x00F8705E File Offset: 0x00F8525E
		public BirthdayLetterView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D1E8 RID: 250344 RVA: 0x00F87084 File Offset: 0x00F85284
		public string GetExtraResourceId([Nullable(2)] object param = null)
		{
			BirthdayInfo birthdayInfo = param as BirthdayInfo;
			if (birthdayInfo == null)
			{
				return "";
			}
			return ModelBase<BirthdayModel>.Instance.GetLetterViewResource(birthdayInfo.Year);
		}

		// Token: 0x0603D1E9 RID: 250345 RVA: 0x00F870B4 File Offset: 0x00F852B4
		protected override string OnGetLoopAudioEvent()
		{
			BirthdayInfo birthdayInfo = this.OpenParam as BirthdayInfo;
			if (birthdayInfo == null)
			{
				return base.OnGetLoopAudioEvent();
			}
			string letterViewBgm = ModelBase<BirthdayModel>.Instance.GetLetterViewBgm(birthdayInfo.Year);
			if (StringUtils.IsBlank(letterViewBgm))
			{
				return base.OnGetLoopAudioEvent();
			}
			return letterViewBgm;
		}

		// Token: 0x0603D1EA RID: 250346 RVA: 0x00F870F8 File Offset: 0x00F852F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISizeControlByOther));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBackBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickGiftBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickPhotoBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickResetBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D1EB RID: 250347 RVA: 0x00F87378 File Offset: 0x00F85578
		protected override UniTask OnBeforeStartAsync()
		{
			BirthdayLetterView.<OnBeforeStartAsync>d__24 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BirthdayLetterView.<OnBeforeStartAsync>d__24>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D1EC RID: 250348 RVA: 0x00F873BC File Offset: 0x00F855BC
		protected override void OnBeforeShow()
		{
			this.IsFirstOpen = BirthdayController.TryBirthDayRewardRequest(this.Year);
			int? selectedRoleId = ModelBase<BirthdayModel>.Instance.GetSelectedRoleId(this.Year);
			if (this.BirthdayInfo.TriggerType != BirthdayDefine.ETriggerType.Natural && selectedRoleId != null)
			{
				int? num = selectedRoleId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					goto IL_64;
				}
			}
			BirthdayController.TrySelectBirthDayCardRoleRequest(this.RoleId, this.Year);
			IL_64:
			this.LoadRoleModel();
			this.BirthdayLetterInterval = ConfigCommonParamById.GetIntConfig("BirthdayEnvelopeInterval").Value;
			Singleton<AudioSystem>.Instance.SetState("mute_nature_voice", ERoleMuteAudioState.Mute, true);
			DateTime birthdayDate = ModelBase<BirthdayModel>.Instance.GetBirthdayDate(this.Year);
			int month = birthdayDate.Month;
			int day = birthdayDate.Day;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "BirthdayLetterTime", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.Year,
				month,
				day
			}));
			this.RewardId = ConfigBirthDayByYear.GetConfig(this.Year, true).Value.BirthDayReward;
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.RewardId);
			this.GiftScrollView.RefreshByData(dropPackagePreviewItemList, null, false);
			this.RefreshRoleInfo();
		}

		// Token: 0x0603D1ED RID: 250349 RVA: 0x00F87514 File Offset: 0x00F85714
		private void RefreshRoleInfo()
		{
			if (this.EventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.EventHandle, EAudioActionType.Stop, null);
				this.EventHandle = 0;
			}
			RoleBirthday? config = ConfigRoleBirthdayById.GetConfig(this.RoleId, true);
			if (config == null)
			{
				return;
			}
			this.SceneCameraId = config.Value.SceneCameraId;
			this.CardCameraId = config.Value.CardCameraId;
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId).Value.Name, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "BirthdayLetterTitle", new <>z__ReadOnlySingleElementList<object>(localTextNew));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), config.Value.CardTextKey, Array.Empty<object>());
			this.EventHandle = Singleton<AudioSystem>.Instance.PostEvent(config.Value.VoiceEvent, null, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?((ECallbackMask)9),
				CallbackHandler = delegate
				{
					bool durationHandled = false;
					return delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
					{
						if (callbackType == EAkCallbackType.Duration)
						{
							durationHandled = true;
							UAkDurationCallbackInfo uakDurationCallbackInfo = callbackInfo as UAkDurationCallbackInfo;
							this.ShowLetterContent(uakDurationCallbackInfo.Duration / 1000f);
							return;
						}
						if (callbackType == EAkCallbackType.EndOfEvent)
						{
							if (durationHandled)
							{
								return;
							}
							float valueOrDefault = ConfigCommonParamById.GetFloatConfig("BirthdayLetterDefaultDuration").GetValueOrDefault(10f);
							this.ShowLetterContent(valueOrDefault);
						}
					};
				}()
			}));
		}

		// Token: 0x0603D1EE RID: 250350 RVA: 0x00F8764C File Offset: 0x00F8584C
		private void ShowLetterContent(float voiceDuration)
		{
			this.InitText(voiceDuration);
			this.ShowLetterPanel();
			base.GetUiSizeControlByOther(11).MinHeight = (int)Math.Ceiling((double)(base.GetScrollViewWithScrollbar(12).RootUIComp.Get().Height / 60f)) * 60;
		}

		// Token: 0x0603D1EF RID: 250351 RVA: 0x00F8769D File Offset: 0x00F8589D
		private void LoadRoleModel()
		{
			UiModelBase model = this.UiSceneRoleActor.Model;
			UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
			if (uiModelActorComponent == null)
			{
				return;
			}
			uiModelActorComponent.SetTransformByTag("RoleCase");
		}

		// Token: 0x0603D1F0 RID: 250352 RVA: 0x00F876C8 File Offset: 0x00F858C8
		private void ShowLetterPanel()
		{
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(this.CardCameraId, true, true, "1001", false, null, null);
			UiModelBase model = this.UiSceneRoleActor.Model;
			UiRoleStateMachineComponent uiRoleStateMachineComponent = (model != null) ? model.CheckGetComponent<UiRoleStateMachineComponent>() : null;
			if (uiRoleStateMachineComponent != null)
			{
				uiRoleStateMachineComponent.SetState(EPerformanceRoleState.Resonance, false, false, false);
			}
			this.IsLetterShow = true;
		}

		// Token: 0x0603D1F1 RID: 250353 RVA: 0x00F87728 File Offset: 0x00F85928
		private void InitText(float voiceDuration)
		{
			if (this.TextPlayTweenEndCbWrapper != null)
			{
				ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
				if (textPlayTweenComp != null)
				{
					ULGUIPlayTween playTween = textPlayTweenComp.GetPlayTween();
					if (playTween != null)
					{
						playTween.UnregisterOnComplete(this.TextPlayTweenEndCbWrapper);
					}
				}
				this.TextPlayTweenEndCbWrapper = null;
			}
			if (this.TextPlayTweenEndCb != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnTweenEnd));
				this.TextPlayTweenEndCb = null;
			}
			this.TextAnimDataComp = (base.GetText(6).GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation);
			this.TextPlayTweenComp = (base.GetText(6).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			UUIEffectTextAnimation textAnimDataComp = this.TextAnimDataComp;
			if (textAnimDataComp != null)
			{
				textAnimDataComp.SetSelectorOffset(1f);
			}
			this.TextPlayTweenEndCb = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(new Action(this.OnTweenEnd));
			this.TextPlayTweenEndCbWrapper = this.TextPlayTweenComp.GetPlayTween().RegisterOnComplete(this.TextPlayTweenEndCb);
			this.VoiceDuration = voiceDuration;
			base.GetText(6).SetUIActive(false);
			this.ShowText();
		}

		// Token: 0x0603D1F2 RID: 250354 RVA: 0x00F8783C File Offset: 0x00F85A3C
		private void ShowText()
		{
			base.GetText(6).SetUIActive(true);
			if (this.TextPlayTweenComp != null)
			{
				this.TextAnimDataComp.SetSelectorOffset(1f);
				this.TextPlayTweenComp.GetPlayTween().duration = this.VoiceDuration + ModelBase<BirthdayModel>.Instance.GetPlayTimeOffset();
				this.TextPlayTweenComp.Play();
			}
		}

		// Token: 0x0603D1F3 RID: 250355 RVA: 0x00F8789A File Offset: 0x00F85A9A
		private BirthdayRewardItem CreatePropItem()
		{
			return new BirthdayRewardItem();
		}

		// Token: 0x0603D1F4 RID: 250356 RVA: 0x00F878A4 File Offset: 0x00F85AA4
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnBirthRoleChange, new Action<int>(this.OnBirthRoleChange));
			if (this.TextPlayTweenEndCbWrapper != null)
			{
				ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
				if (textPlayTweenComp != null)
				{
					ULGUIPlayTween playTween = textPlayTweenComp.GetPlayTween();
					if (playTween != null)
					{
						playTween.UnregisterOnComplete(this.TextPlayTweenEndCbWrapper);
					}
				}
				this.TextPlayTweenEndCbWrapper = null;
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnTweenEnd));
			this.TextPlayTweenEndCb = null;
			if (this.UiSceneRoleActor != null)
			{
				Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.UiSceneRoleActor);
				this.UiSceneRoleActor = null;
			}
			Singleton<AudioSystem>.Instance.SetState("mute_nature_voice", ERoleMuteAudioState.None, true);
		}

		// Token: 0x0603D1F5 RID: 250357 RVA: 0x00F87958 File Offset: 0x00F85B58
		private void OnClickBackBtn()
		{
			if (this.LastClickTimeStamp != 0 && Singleton<TimeUtil>.Instance.GetServerTimeStamp() - (double)this.LastClickTimeStamp < (double)this.BirthdayLetterInterval)
			{
				return;
			}
			this.LastClickTimeStamp = (int)Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			if (this.IsLetterShow)
			{
				Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(this.SceneCameraId, true, true, "1001", false, null, null);
				UiModelBase model = this.UiSceneRoleActor.Model;
				UiRoleStateMachineComponent uiRoleStateMachineComponent = (model != null) ? model.CheckGetComponent<UiRoleStateMachineComponent>() : null;
				if (uiRoleStateMachineComponent != null)
				{
					uiRoleStateMachineComponent.SetState(EPerformanceRoleState.Attribute_Perform, false, false, false);
				}
				base.PlaySequence("WindowClose", null, false);
				this.IsLetterShow = false;
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(ModelBase<BirthdayModel>.Instance.GetLetterExitConfirmId(this.BirthdayInfo.Year));
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				this.CloseBirthdayLetterView();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603D1F6 RID: 250358 RVA: 0x00F87A40 File Offset: 0x00F85C40
		public void CloseBirthdayLetterView()
		{
			base.CloseMe(null);
			if (this.EventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.EventHandle, EAudioActionType.Stop, null);
			}
			if (this.IsFirstOpen)
			{
				List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.RewardId);
				List<RewardItemData> list = new List<RewardItemData>();
				foreach (TItem titem in dropPackagePreviewItemList)
				{
					RewardItemData item = new RewardItemData(titem.ItemData.ItemId, titem.Count, null, EDropItemType.Normal);
					list.Add(item);
				}
				Action onCloseCallback = delegate()
				{
					ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.Birthday);
				};
				ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1009, list, onCloseCallback);
				return;
			}
			ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.Birthday);
		}

		// Token: 0x0603D1F7 RID: 250359 RVA: 0x00F87B3C File Offset: 0x00F85D3C
		private void OnClickGiftBtn()
		{
			if (this.LastClickTimeStamp != 0 && Singleton<TimeUtil>.Instance.GetServerTimeStamp() - (double)this.LastClickTimeStamp < (double)this.BirthdayLetterInterval)
			{
				return;
			}
			this.LastClickTimeStamp = (int)Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			this.ShowLetterPanel();
			base.PlaySequence("WindowOpen", null, false);
		}

		// Token: 0x0603D1F8 RID: 250360 RVA: 0x00F87B94 File Offset: 0x00F85D94
		private void OnClickPhotoBtn()
		{
			ControllerBase<PhotographController>.Instance.ScreenShot(new PhotoSaveViewParam
			{
				ScreenShot = true,
				PrepareFullScreenShot = false,
				IsHiddenBattleView = true,
				HandBookPhotoData = null,
				GachaData = null,
				FragmentMemory = null,
				RoleSkinData = null,
				ShareId = 7
			});
		}

		// Token: 0x0603D1F9 RID: 250361 RVA: 0x00F87BE8 File Offset: 0x00F85DE8
		private void OnClickResetBtn()
		{
			Singleton<UiManager>.Instance.OpenViewWithLayer(EUiViewName.BirthdayRoleSelectView, ELayerType.Pop, new BirthdayInfo(BirthdayDefine.ETriggerType.ReSelect, this.Year, null), null);
		}

		// Token: 0x0603D1FA RID: 250362 RVA: 0x00F87C1C File Offset: 0x00F85E1C
		private void OnTweenEnd()
		{
			this.TextPlayTweenComp.Stop();
			this.TextAnimDataComp.SetSelectorOffset(0f);
		}

		// Token: 0x0603D1FB RID: 250363 RVA: 0x00F87C3C File Offset: 0x00F85E3C
		private void OnBirthRoleChange(int roleId)
		{
			this.RoleId = roleId;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleId, true);
			int? num = (roleDataById != null) ? new int?(roleDataById.GetRoleSkinId()) : null;
			if (num == null)
			{
				num = new int?(ConfigRoleInfoById.GetConfig(this.RoleId, true).Value.SkinId);
			}
			ControllerBase<RoleController>.Instance.OnSelectedRoleChangeByConfig(roleId, num.Value, null);
			base.PlaySequence("WindowOpen", null, false);
			this.RefreshRoleInfo();
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(12);
			if (scrollViewWithScrollbar == null)
			{
				return;
			}
			scrollViewWithScrollbar.SetScrollValue(Vector2D.ZeroVector);
		}

		// Token: 0x04022467 RID: 140391
		private const int HEIGHT_PER_LINE = 60;

		// Token: 0x04022468 RID: 140392
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<BirthdayRewardItem, TItem> GiftScrollView;

		// Token: 0x04022469 RID: 140393
		[Nullable(2)]
		private TsUiSceneRoleActor UiSceneRoleActor;

		// Token: 0x0402246A RID: 140394
		private int RoleId;

		// Token: 0x0402246B RID: 140395
		private int Year;

		// Token: 0x0402246C RID: 140396
		private bool IsLetterShow = true;

		// Token: 0x0402246D RID: 140397
		private string SceneCameraId = "";

		// Token: 0x0402246E RID: 140398
		private string CardCameraId = "";

		// Token: 0x0402246F RID: 140399
		private bool IsFirstOpen;

		// Token: 0x04022470 RID: 140400
		private int RewardId;

		// Token: 0x04022471 RID: 140401
		private int EventHandle;

		// Token: 0x04022472 RID: 140402
		[Nullable(2)]
		private UUIEffectTextAnimation TextAnimDataComp;

		// Token: 0x04022473 RID: 140403
		[Nullable(2)]
		private ULGUIPlayTweenComponent TextPlayTweenComp;

		// Token: 0x04022474 RID: 140404
		[Nullable(2)]
		private FLGUIPlayTweenCompleteDynamicDelegate TextPlayTweenEndCb;

		// Token: 0x04022475 RID: 140405
		[Nullable(2)]
		private FLGUIDelegateHandleWrapper TextPlayTweenEndCbWrapper;

		// Token: 0x04022476 RID: 140406
		private float VoiceDuration;

		// Token: 0x04022477 RID: 140407
		private int LastClickTimeStamp;

		// Token: 0x04022478 RID: 140408
		private int BirthdayLetterInterval;

		// Token: 0x04022479 RID: 140409
		private BirthdayInfo BirthdayInfo;

		// Token: 0x0200BF12 RID: 48914
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403AD00 RID: 240896
			public const int ButtonBack = 0;

			// Token: 0x0403AD01 RID: 240897
			public const int ItemButtonPanel = 1;

			// Token: 0x0403AD02 RID: 240898
			public const int ItemLetterPanel = 2;

			// Token: 0x0403AD03 RID: 240899
			public const int ButtonPhoto = 3;

			// Token: 0x0403AD04 RID: 240900
			public const int ButtonGift = 4;

			// Token: 0x0403AD05 RID: 240901
			public const int TextTitle = 5;

			// Token: 0x0403AD06 RID: 240902
			public const int TextBless = 6;

			// Token: 0x0403AD07 RID: 240903
			public const int ScrollViewGift = 7;

			// Token: 0x0403AD08 RID: 240904
			public const int ItemGift = 8;

			// Token: 0x0403AD09 RID: 240905
			public const int TextTime = 9;

			// Token: 0x0403AD0A RID: 240906
			public const int BtnReSelect = 10;

			// Token: 0x0403AD0B RID: 240907
			public const int SpriteLine = 11;

			// Token: 0x0403AD0C RID: 240908
			public const int SVInfo = 12;
		}
	}
}
