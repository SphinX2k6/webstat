using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.LevelConditions;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053B0 RID: 21424
	[NullableContext(1)]
	[Nullable(0)]
	public class ChatPopView : UiViewBase
	{
		// Token: 0x06036A20 RID: 223776 RVA: 0x00DD6590 File Offset: 0x00DD4790
		public ChatPopView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06036A21 RID: 223777 RVA: 0x00DD65B0 File Offset: 0x00DD47B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036A22 RID: 223778 RVA: 0x00DD663C File Offset: 0x00DD483C
		protected override void OnStart()
		{
			this.ChatLayout = new GenericLayout<ChatItemGrid, ChatItemData>(base.GetVerticalLayout(2), new Func<ChatItemGrid>(this.CreateChatItem), null, false, true);
			ChatPopViewData chatPopViewData = this.OpenParam as ChatPopViewData;
			if (chatPopViewData == null)
			{
				return;
			}
			if (chatPopViewData.ParentViewId != null)
			{
				UiViewBase view = Singleton<UiManager>.Instance.GetView(chatPopViewData.ParentViewId.Value);
				if (view != null)
				{
					view.AddChild(this);
				}
			}
			if (chatPopViewData.FlowId != null)
			{
				this.LoadFlowData(chatPopViewData.FlowId);
			}
			this.OnAllShownCallback = chatPopViewData.OnAllShownCallback;
			this.ConditionId = chatPopViewData.Condition;
			if (this.ConditionId > 0)
			{
				this.RegisterCondition();
				return;
			}
			this.StartPlay();
		}

		// Token: 0x06036A23 RID: 223779 RVA: 0x00DD66EC File Offset: 0x00DD48EC
		private void RegisterCondition()
		{
			this.IsWaitingCondition = true;
			this.ConditionCallback = new ConditionPassCallback(new TConditionPassCallback(this.OnConditionPass), null);
			if (!Singleton<LevelConditionRegistry>.Instance.RegisterConditionGroup(this.ConditionId, this.ConditionCallback))
			{
				this.IsWaitingCondition = false;
				this.ConditionCallback = null;
				this.StartPlay();
			}
		}

		// Token: 0x06036A24 RID: 223780 RVA: 0x00DD6744 File Offset: 0x00DD4944
		private void OnConditionPass([Nullable(new byte[]
		{
			2,
			1
		})] object[] parameters)
		{
			if (!this.IsWaitingCondition)
			{
				return;
			}
			this.UnRegisterCondition();
			this.StartPlay();
		}

		// Token: 0x06036A25 RID: 223781 RVA: 0x00DD675B File Offset: 0x00DD495B
		private void UnRegisterCondition()
		{
			if (!this.IsWaitingCondition)
			{
				return;
			}
			this.IsWaitingCondition = false;
			if (this.ConditionCallback != null)
			{
				Singleton<LevelConditionRegistry>.Instance.UnRegisterConditionGroup(this.ConditionId, this.ConditionCallback);
				this.ConditionCallback = null;
			}
		}

		// Token: 0x06036A26 RID: 223782 RVA: 0x00DD6792 File Offset: 0x00DD4992
		private void StartPlay()
		{
			if (this.IsPlaying)
			{
				return;
			}
			this.IsPlaying = true;
			this.ShowNextTalk();
		}

		// Token: 0x06036A27 RID: 223783 RVA: 0x00DD67AC File Offset: 0x00DD49AC
		public void LoadFlowData(List<string> flowId)
		{
			this.AllTalkItems.Clear();
			this.DisplayedItems.Clear();
			this.CurrentTalkIndex = 0;
			List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(flowId[0], int.Parse(flowId[1]), int.Parse(flowId[2]));
			if (flowStateActions == null)
			{
				return;
			}
			foreach (ActionInfo actionInfo in flowStateActions)
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					foreach (ITalkItem talkItem in ((ShowTalk)actionInfo.Params).TalkItems)
					{
						Speaker? speaker = (talkItem.WhoId != null) ? ConfigSpeakerById.GetConfig(talkItem.WhoId.Value, true) : null;
						string name = (speaker != null) ? (Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(speaker.Value.Id)) ?? "") : "";
						string icon = (talkItem.WhoId.GetValueOrDefault() == 750088) ? ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? "/Game/Aki/UI/UIResources/Common/Image/IconRoleHead256/T_IconRoleHead256_4_a_UI.T_IconRoleHead256_4_a_UI" : "/Game/Aki/UI/UIResources/Common/Image/IconRoleHead256/T_IconRoleHead256_5_a_UI.T_IconRoleHead256_5_a_UI") : (((speaker != null) ? speaker.GetValueOrDefault().HeadIconAsset : null) ?? "");
						string text = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkItem.TidTalk ?? "") ?? "";
						if (!StringUtils.IsEmpty(text))
						{
							this.AllTalkItems.Add(new ChatItemData
							{
								Icon = icon,
								Name = name,
								Message = text,
								Time = "",
								TidTalk = talkItem.TidTalk
							});
						}
					}
				}
			}
		}

		// Token: 0x06036A28 RID: 223784 RVA: 0x00DD69F0 File Offset: 0x00DD4BF0
		public bool ShowNextTalk()
		{
			if (this.CurrentTalkIndex >= this.AllTalkItems.Count)
			{
				return false;
			}
			foreach (ChatItemData chatItemData in this.DisplayedItems)
			{
				chatItemData.IsCompleted = true;
			}
			ChatItemData chatItemData2 = this.AllTalkItems[this.CurrentTalkIndex];
			chatItemData2.IsCompleted = false;
			this.DisplayedItems.Add(chatItemData2);
			if (this.DisplayedItems.Count > 2)
			{
				this.DisplayedItems.RemoveRange(0, this.DisplayedItems.Count - 2);
			}
			this.UpdateDisplayedItemModes();
			this.CurrentTalkIndex++;
			this.ChatLayout.RefreshByData(this.DisplayedItems, new Action(this.ScrollToBottom), false);
			this.PlayVoiceForItem(chatItemData2);
			return true;
		}

		// Token: 0x06036A29 RID: 223785 RVA: 0x00DD6ADC File Offset: 0x00DD4CDC
		private void UpdateDisplayedItemModes()
		{
			int num = this.DisplayedItems.Count - 1;
			for (int i = 0; i < this.DisplayedItems.Count; i++)
			{
				ChatItemData chatItemData = this.DisplayedItems[i];
				int num2 = num - i;
				if (num2 == 0)
				{
					chatItemData.DisplayMode = new ChatItemDisplayMode?(ChatItemDisplayMode.Start);
					chatItemData.IsCompleted = false;
				}
				else if (num2 == 1)
				{
					chatItemData.DisplayMode = new ChatItemDisplayMode?(ChatItemDisplayMode.GreyOnly);
					chatItemData.IsCompleted = true;
				}
				else
				{
					chatItemData.DisplayMode = new ChatItemDisplayMode?(ChatItemDisplayMode.Close);
					chatItemData.IsCompleted = true;
				}
			}
		}

		// Token: 0x06036A2A RID: 223786 RVA: 0x00DD6B64 File Offset: 0x00DD4D64
		private unsafe void PlayVoiceForItem(ChatItemData item)
		{
			ChatPopView.<>c__DisplayClass29_0 CS$<>8__locals1 = new ChatPopView.<>c__DisplayClass29_0();
			CS$<>8__locals1.<>4__this = this;
			this.StopCurrentAudio();
			string tidTalk = item.TidTalk;
			if (tidTalk == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Log, ELogAuthor.SWC, "[ChatPopView] 无TidTalk，跳过语音", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.OnVoiceFinished();
				return;
			}
			PlotAudio? config = ConfigPlotAudioById.GetConfig(tidTalk, true);
			if (config == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Log;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "[ChatPopView] 无语音配置，跳过语音";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tidTalk", tidTalk);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.OnVoiceFinished();
				return;
			}
			ChatPopView.<>c__DisplayClass29_0 CS$<>8__locals2 = CS$<>8__locals1;
			int num = this.DialogVersion + 1;
			this.DialogVersion = num;
			CS$<>8__locals2.currentVersion = num;
			string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(config.Value);
			this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent("play_vo_caccona_gal", null, new PostEventArgs?(new PostEventArgs
			{
				ExternalSourceName = "external_caccona_gal_voice",
				ExternalSourceMediaName = externalSourcesMediaName,
				CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType == EAkCallbackType.EndOfEvent)
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Plot;
						ELogAuthor author2 = ELogAuthor.SWC;
						string message2 = "[ChatPopView] [Error_CALLBACK] EAkCallbackType.EndOfEvent";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("DialogVersion", CS$<>8__locals1.<>4__this.DialogVersion);
						instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
					else if (callbackType == EAkCallbackType.Duration)
					{
						global::Log instance3 = Singleton<global::Log>.Instance;
						ELogModule module3 = ELogModule.Plot;
						ELogAuthor author3 = ELogAuthor.SWC;
						string message3 = "[ChatPopView] [Error_CALLBACK] EAkCallbackType.Duration";
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("DialogVersion", CS$<>8__locals1.<>4__this.DialogVersion);
						instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					}
					if (CS$<>8__locals1.currentVersion != CS$<>8__locals1.<>4__this.DialogVersion)
					{
						global::Log instance4 = Singleton<global::Log>.Instance;
						ELogModule module4 = ELogModule.Plot;
						ELogAuthor author4 = ELogAuthor.SWC;
						string message4 = "[ChatPopView] [Error_CALLBACK] DialogVersion Not Matched";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DialogVersion", CS$<>8__locals1.<>4__this.DialogVersion);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentVersion", CS$<>8__locals1.currentVersion);
						instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						return;
					}
					if (callbackType == EAkCallbackType.EndOfEvent)
					{
						CS$<>8__locals1.<>4__this.ClearVoiceCallbackTimeoutTimer();
						CS$<>8__locals1.<>4__this.PlotPlayEventResult = 0;
						CS$<>8__locals1.<>4__this.OnVoiceFinished();
					}
				}
			}));
			this.StartVoiceCallbackTimeout(CS$<>8__locals1.currentVersion);
		}

		// Token: 0x06036A2B RID: 223787 RVA: 0x00DD6C80 File Offset: 0x00DD4E80
		private void OnVoiceFinished()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			if (!this.ShowNextTalk())
			{
				this.DelayOnAllTalkFinished();
			}
		}

		// Token: 0x06036A2C RID: 223788 RVA: 0x00DD6C99 File Offset: 0x00DD4E99
		private void DelayOnAllTalkFinished()
		{
			this.ClearOnAllTalkFinishedTimer();
			this.OnAllTalkFinishedTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.OnAllTalkFinishedTimer = null;
				this.OnAllTalkFinished();
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x06036A2D RID: 223789 RVA: 0x00DD6CCA File Offset: 0x00DD4ECA
		private void OnAllTalkFinished()
		{
			this.IsPlaying = false;
			Action onAllShownCallback = this.OnAllShownCallback;
			if (onAllShownCallback != null)
			{
				onAllShownCallback();
			}
			base.CloseMe(null);
		}

		// Token: 0x06036A2E RID: 223790 RVA: 0x00DD6CEB File Offset: 0x00DD4EEB
		public bool HasMoreTalks()
		{
			return this.CurrentTalkIndex < this.AllTalkItems.Count;
		}

		// Token: 0x06036A2F RID: 223791 RVA: 0x00DD6D00 File Offset: 0x00DD4F00
		public int GetRemainingTalkCount()
		{
			return this.AllTalkItems.Count - this.CurrentTalkIndex;
		}

		// Token: 0x06036A30 RID: 223792 RVA: 0x00DD6D14 File Offset: 0x00DD4F14
		private void StopCurrentAudio()
		{
			this.DialogVersion++;
			this.ClearVoiceCallbackTimeoutTimer();
			Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
			this.PlotPlayEventResult = 0;
		}

		// Token: 0x06036A31 RID: 223793 RVA: 0x00DD6D68 File Offset: 0x00DD4F68
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			this.UnRegisterCondition();
			this.StopCurrentAudio();
			this.ClearOnAllTalkFinishedTimer();
			this.ClearVoiceCallbackTimeoutTimer();
		}

		// Token: 0x06036A32 RID: 223794 RVA: 0x00DD6D88 File Offset: 0x00DD4F88
		private void ClearOnAllTalkFinishedTimer()
		{
			if (this.OnAllTalkFinishedTimer != null)
			{
				TimerSystem.Instance.Remove(this.OnAllTalkFinishedTimer);
				this.OnAllTalkFinishedTimer = null;
			}
		}

		// Token: 0x06036A33 RID: 223795 RVA: 0x00DD6DAC File Offset: 0x00DD4FAC
		private void StartVoiceCallbackTimeout(int currentVersion)
		{
			this.ClearVoiceCallbackTimeoutTimer();
			this.VoiceCallbackTimeoutTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.VoiceCallbackTimeoutTimer = null;
				if (currentVersion != this.DialogVersion)
				{
					return;
				}
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "[ChatPopView] [Error_CALLBACK] Voice callback timeout, auto continue";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DialogVersion", this.DialogVersion);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.PlotPlayEventResult = 0;
				this.OnVoiceFinished();
			}, 10000f, null, null, true, 1f);
		}

		// Token: 0x06036A34 RID: 223796 RVA: 0x00DD6DFC File Offset: 0x00DD4FFC
		private void ClearVoiceCallbackTimeoutTimer()
		{
			if (this.VoiceCallbackTimeoutTimer != null)
			{
				TimerSystem.Instance.Remove(this.VoiceCallbackTimeoutTimer);
				this.VoiceCallbackTimeoutTimer = null;
			}
		}

		// Token: 0x06036A35 RID: 223797 RVA: 0x00DD6E20 File Offset: 0x00DD5020
		private void ScrollToBottom()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(0);
			if (scrollViewWithScrollbar == null)
			{
				return;
			}
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(2);
			UUIItem uuiitem = (verticalLayout != null) ? verticalLayout.RootUIComp.Get() : null;
			TArray<UUIItem> tarray = (uuiitem != null) ? uuiitem.GetAttachUIChildren() : null;
			int num = (tarray != null) ? tarray.Num() : 0;
			if (num <= 0)
			{
				return;
			}
			UUIItem attachUIChild = uuiitem.GetAttachUIChild(num - 1);
			if (attachUIChild == null)
			{
				return;
			}
			scrollViewWithScrollbar.ScrollToBottomLater(attachUIChild, false);
		}

		// Token: 0x06036A36 RID: 223798 RVA: 0x00DD6E8A File Offset: 0x00DD508A
		private ChatItemGrid CreateChatItem()
		{
			return new ChatItemGrid();
		}

		// Token: 0x0401F77D RID: 128893
		private const int MAX_CHAT_ITEM_COUNT = 2;

		// Token: 0x0401F77E RID: 128894
		private const int ON_ALL_TALK_FINISHED_DELAY_MS = 2000;

		// Token: 0x0401F77F RID: 128895
		private const int VOICE_CALLBACK_TIMEOUT_MS = 10000;

		// Token: 0x0401F780 RID: 128896
		private const string PROTAGONIST_ICON_FEMALE = "/Game/Aki/UI/UIResources/Common/Image/IconRoleHead256/T_IconRoleHead256_5_a_UI.T_IconRoleHead256_5_a_UI";

		// Token: 0x0401F781 RID: 128897
		private const string PROTAGONIST_ICON_MALE = "/Game/Aki/UI/UIResources/Common/Image/IconRoleHead256/T_IconRoleHead256_4_a_UI.T_IconRoleHead256_4_a_UI";

		// Token: 0x0401F782 RID: 128898
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<ChatItemGrid, ChatItemData> ChatLayout;

		// Token: 0x0401F783 RID: 128899
		private readonly List<ChatItemData> AllTalkItems = new List<ChatItemData>();

		// Token: 0x0401F784 RID: 128900
		private readonly List<ChatItemData> DisplayedItems = new List<ChatItemData>();

		// Token: 0x0401F785 RID: 128901
		private int CurrentTalkIndex;

		// Token: 0x0401F786 RID: 128902
		private bool IsPlaying;

		// Token: 0x0401F787 RID: 128903
		private bool IsWaitingCondition;

		// Token: 0x0401F788 RID: 128904
		[Nullable(2)]
		private Action OnAllShownCallback;

		// Token: 0x0401F789 RID: 128905
		private int ConditionId;

		// Token: 0x0401F78A RID: 128906
		[Nullable(2)]
		private ConditionPassCallback ConditionCallback;

		// Token: 0x0401F78B RID: 128907
		private int PlotPlayEventResult;

		// Token: 0x0401F78C RID: 128908
		private int DialogVersion;

		// Token: 0x0401F78D RID: 128909
		[Nullable(2)]
		private TimerHandle OnAllTalkFinishedTimer;

		// Token: 0x0401F78E RID: 128910
		[Nullable(2)]
		private TimerHandle VoiceCallbackTimeoutTimer;

		// Token: 0x0200B313 RID: 45843
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x040377AF RID: 227247
			public const int ScrollPanel = 0;

			// Token: 0x040377B0 RID: 227248
			public const int ChatItem = 1;

			// Token: 0x040377B1 RID: 227249
			public const int Content = 2;
		}
	}
}
