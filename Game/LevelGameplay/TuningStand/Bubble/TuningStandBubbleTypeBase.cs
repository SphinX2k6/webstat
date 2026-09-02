using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A8B RID: 27275
	[NullableContext(1)]
	[Nullable(0)]
	public class TuningStandBubbleTypeBase
	{
		// Token: 0x06043759 RID: 276313 RVA: 0x01161418 File Offset: 0x0115F618
		public bool GetCanInterruptBySelf()
		{
			return this.CanInterruptBySelf;
		}

		// Token: 0x0604375A RID: 276314 RVA: 0x01161420 File Offset: 0x0115F620
		public virtual bool TryStartBubble(bool canPlay)
		{
			return false;
		}

		// Token: 0x0604375B RID: 276315 RVA: 0x01161424 File Offset: 0x0115F624
		public unsafe void Init(PlayFlow playFlow)
		{
			this.PlayFlow = playFlow;
			List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(playFlow.FlowListName, playFlow.FlowId, playFlow.StateId);
			if (flowStateActions == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "找不到对应的剧本配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowListName", playFlow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowId", playFlow.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StateId", playFlow.StateId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			foreach (ActionInfo actionInfo in flowStateActions)
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					ShowTalk showTalk = actionInfo.Params as ShowTalk;
					if (showTalk != null)
					{
						foreach (ITalkItem talkData in showTalk.TalkItems)
						{
							ITuningStandBubbleData tuningStandBubbleData = this.CreateBubbleData(talkData);
							if (tuningStandBubbleData != null)
							{
								this.TalkList.Add(tuningStandBubbleData);
							}
						}
					}
				}
			}
			if (this.TalkList.Count == 0)
			{
				this.PlayFlow = null;
			}
		}

		// Token: 0x0604375C RID: 276316 RVA: 0x011615A4 File Offset: 0x0115F7A4
		public void Interrupted()
		{
			if (this.TimerHandle != null)
			{
				if (TimerSystem.GameplayTimeInstance.Has(this.TimerHandle))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				}
				this.TimerHandle = null;
			}
		}

		// Token: 0x0604375D RID: 276317 RVA: 0x011615D8 File Offset: 0x0115F7D8
		protected void OnBubbleEnd()
		{
			Singleton<EventSystem>.Instance.Emit<ETuningStandBubbleTriggerType>(EEventName.TuningStandBubbleEnd, this.BubbleType);
		}

		// Token: 0x0604375E RID: 276318 RVA: 0x011615F0 File Offset: 0x0115F7F0
		public void Destroy()
		{
			this.Interrupted();
			this.PlayFlow = null;
		}

		// Token: 0x0604375F RID: 276319 RVA: 0x01161600 File Offset: 0x0115F800
		[return: Nullable(2)]
		protected ITuningStandBubbleData CreateBubbleData(ITalkItem talkData)
		{
			TuningStandBubbleData tuningStandBubbleData = new TuningStandBubbleData
			{
				WaitTime = 0f
			};
			if (talkData.WaitTime != null && talkData.WaitTime.Value > 0f)
			{
				tuningStandBubbleData.WaitTime = talkData.WaitTime.Value;
			}
			ValueTuple<bool, bool, string> talkData2 = this.GetTalkData(talkData);
			bool item = talkData2.Item1;
			bool item2 = talkData2.Item2;
			string item3 = talkData2.Item3;
			if (!item)
			{
				return null;
			}
			if (item2)
			{
				tuningStandBubbleData.MainRoleTex = item3;
				tuningStandBubbleData.MainRoleTalk = talkData.TidTalk;
			}
			else
			{
				tuningStandBubbleData.FloroTex = item3;
				tuningStandBubbleData.FloroTalk = talkData.TidTalk;
			}
			if (tuningStandBubbleData.WaitTime == 0f)
			{
				tuningStandBubbleData.WaitTime = this.RemainTime;
			}
			return tuningStandBubbleData;
		}

		// Token: 0x06043760 RID: 276320 RVA: 0x011616C0 File Offset: 0x0115F8C0
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected ValueTuple<bool, bool, string> GetTalkData(ITalkItem talkData)
		{
			Speaker? config = ConfigSpeakerById.GetConfig(talkData.WhoId.GetValueOrDefault(-1), true);
			if (config == null)
			{
				return new ValueTuple<bool, bool, string>(false, false, "");
			}
			bool flag = talkData.Name != "FLL";
			string headIconAsset = config.Value.HeadIconAsset;
			if (flag)
			{
				EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
				if ((playerGender == EPlayerGender.Female && talkData.Name == "M") || (playerGender == EPlayerGender.Male && talkData.Name == "F"))
				{
					return new ValueTuple<bool, bool, string>(false, false, "");
				}
			}
			return new ValueTuple<bool, bool, string>(true, flag, headIconAsset);
		}

		// Token: 0x06043761 RID: 276321 RVA: 0x0116176C File Offset: 0x0115F96C
		protected void UpdateBubble()
		{
			if (this.CurIndex >= this.TalkList.Count)
			{
				this.OnBubbleEnd();
				return;
			}
			ITuningStandBubbleData tuningStandBubbleData = this.TalkList[this.CurIndex];
			this.CurIndex++;
			Singleton<EventSystem>.Instance.Emit<ITuningStandBubbleData>(EEventName.TuningStandBubbleUpdate, tuningStandBubbleData);
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.UpdateBubble();
			}, (float)((long)(tuningStandBubbleData.WaitTime * 1000f)), null, null, true, 1f);
		}

		// Token: 0x04025AD0 RID: 154320
		protected bool CanInterruptBySelf;

		// Token: 0x04025AD1 RID: 154321
		[Nullable(2)]
		protected PlayFlow PlayFlow;

		// Token: 0x04025AD2 RID: 154322
		protected ETuningStandBubbleTriggerType BubbleType;

		// Token: 0x04025AD3 RID: 154323
		protected List<ITuningStandBubbleData> TalkList = new List<ITuningStandBubbleData>();

		// Token: 0x04025AD4 RID: 154324
		[Nullable(2)]
		protected TimerHandle TimerHandle;

		// Token: 0x04025AD5 RID: 154325
		protected int CurIndex;

		// Token: 0x04025AD6 RID: 154326
		protected float RemainTime = 2f;
	}
}
