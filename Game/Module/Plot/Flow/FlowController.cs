using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Core.Framework;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x020053FC RID: 21500
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class FlowController : ControllerWithAssistantBase<FlowController>
	{
		// Token: 0x17008E07 RID: 36359
		// (get) Token: 0x06036E48 RID: 224840 RVA: 0x00DEC2D3 File Offset: 0x00DEA4D3
		protected override bool IsTickEvenPausedInternal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06036E49 RID: 224841 RVA: 0x00DEC2D6 File Offset: 0x00DEA4D6
		protected override bool OnInit()
		{
			bool result = base.OnInit();
			FlowNetworks.Register();
			return result;
		}

		// Token: 0x06036E4A RID: 224842 RVA: 0x00DEC2E3 File Offset: 0x00DEA4E3
		protected override bool OnClear()
		{
			FlowNetworks.UnRegister();
			return base.OnClear();
		}

		// Token: 0x06036E4B RID: 224843 RVA: 0x00DEC2F0 File Offset: 0x00DEA4F0
		protected override void RegisterAssistant()
		{
			base.AddAssistant(0, new FlowServerNotifyCenter());
			base.AddAssistant(1, new FlowActionCenter());
			base.AddAssistant(2, new FlowActionRunner());
			base.AddAssistant(3, new FlowLaunchCenter());
		}

		// Token: 0x06036E4C RID: 224844 RVA: 0x00DEC324 File Offset: 0x00DEA524
		[return: Nullable(2)]
		private T GetAssistant<T>(FlowController.EAssistantType type) where T : class
		{
			if (this.Assistants == null)
			{
				return default(T);
			}
			ControllerAssistantBase controllerAssistantBase;
			if (this.Assistants.TryGetValue((int)type, out controllerAssistantBase))
			{
				return controllerAssistantBase as T;
			}
			return default(T);
		}

		// Token: 0x06036E4D RID: 224845 RVA: 0x00DEC368 File Offset: 0x00DEA568
		public void StartNotify(FlowStartNotify notify)
		{
			FlowServerNotifyCenter assistant = this.GetAssistant<FlowServerNotifyCenter>(FlowController.EAssistantType.ServerNotifyCenter);
			if (assistant == null)
			{
				return;
			}
			assistant.HandleFlowStartNotify(notify);
		}

		// Token: 0x06036E4E RID: 224846 RVA: 0x00DEC37C File Offset: 0x00DEA57C
		public void EndNotify(FlowEndNotify notify)
		{
			FlowServerNotifyCenter assistant = this.GetAssistant<FlowServerNotifyCenter>(FlowController.EAssistantType.ServerNotifyCenter);
			if (assistant == null)
			{
				return;
			}
			assistant.HandleFlowEndNotify(notify);
		}

		// Token: 0x06036E4F RID: 224847 RVA: 0x00DEC390 File Offset: 0x00DEA590
		public void SkipBlackScreenNotify(FlowServerSkipNotify notify)
		{
			FlowServerNotifyCenter assistant = this.GetAssistant<FlowServerNotifyCenter>(FlowController.EAssistantType.ServerNotifyCenter);
			if (assistant == null)
			{
				return;
			}
			assistant.HandleFlowSkipBlackScreenNotify(notify);
		}

		// Token: 0x06036E50 RID: 224848 RVA: 0x00DEC3A4 File Offset: 0x00DEA5A4
		public void ClearOnLeaveOnlineWorld()
		{
		}

		// Token: 0x06036E51 RID: 224849 RVA: 0x00DEC3A6 File Offset: 0x00DEA5A6
		[NullableContext(2)]
		public FlowAction GetFlowAction(EAction type)
		{
			FlowActionCenter assistant = this.GetAssistant<FlowActionCenter>(FlowController.EAssistantType.ActionCenter);
			if (assistant == null)
			{
				return null;
			}
			return assistant.GetFlowAction(type);
		}

		// Token: 0x06036E52 RID: 224850 RVA: 0x00DEC3BB File Offset: 0x00DEA5BB
		public void ExecuteActions(List<ActionInfo> actions, FlowContext context, Action callback)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.ExecuteActions(actions, context, callback);
		}

		// Token: 0x06036E53 RID: 224851 RVA: 0x00DEC3D1 File Offset: 0x00DEA5D1
		public void FinishFlow(string reason, long? incId = null, bool isServerEnd = false)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.FinishFlow(reason, incId, isServerEnd);
		}

		// Token: 0x06036E54 RID: 224852 RVA: 0x00DEC3E7 File Offset: 0x00DEA5E7
		public bool HasFlow(string flowListName, int flowId, int flowStateId)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			return assistant != null && assistant.HasFlow(flowListName, flowId, flowStateId);
		}

		// Token: 0x06036E55 RID: 224853 RVA: 0x00DEC3FE File Offset: 0x00DEA5FE
		public void BackgroundFlow(string reason, bool useFade = true, bool isServerEnd = false, bool stopAtNoSkipSetPlotMode = false)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.BackgroundActions(reason, useFade, isServerEnd, stopAtNoSkipSetPlotMode);
		}

		// Token: 0x06036E56 RID: 224854 RVA: 0x00DEC416 File Offset: 0x00DEA616
		public void RunNextAction()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.ExecuteNextAction();
		}

		// Token: 0x06036E57 RID: 224855 RVA: 0x00DEC429 File Offset: 0x00DEA629
		public void FinishFlowByGm()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.ForceFinishActionsByGm();
		}

		// Token: 0x06036E58 RID: 224856 RVA: 0x00DEC43C File Offset: 0x00DEA63C
		public EAction? GetCurFlowAction()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return null;
			}
			return assistant.GetCurActionName();
		}

		// Token: 0x06036E59 RID: 224857 RVA: 0x00DEC463 File Offset: 0x00DEA663
		public bool IsInShowTalk()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			return assistant != null && assistant.IsInShowTalk();
		}

		// Token: 0x06036E5A RID: 224858 RVA: 0x00DEC477 File Offset: 0x00DEA677
		public void ExecuteSubActions([Nullable(new byte[]
		{
			2,
			1
		})] List<ActionInfo> actions, Action<bool> callback, bool append = false)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.ExecuteSubActions(actions, callback, append);
		}

		// Token: 0x06036E5B RID: 224859 RVA: 0x00DEC48D File Offset: 0x00DEA68D
		[NullableContext(2)]
		public global::Vector GetInteractPoint()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return null;
			}
			return assistant.GetInteractPoint();
		}

		// Token: 0x06036E5C RID: 224860 RVA: 0x00DEC4A1 File Offset: 0x00DEA6A1
		[NullableContext(2)]
		public IInteractCameraOffsetConfig GetCameraOffsetConfig()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return null;
			}
			return assistant.GetCameraOffsetConfig();
		}

		// Token: 0x06036E5D RID: 224861 RVA: 0x00DEC4B5 File Offset: 0x00DEA6B5
		public void AddActionNext(ActionInfo actionInfo)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.AddActionNext(actionInfo);
		}

		// Token: 0x06036E5E RID: 224862 RVA: 0x00DEC4C9 File Offset: 0x00DEA6C9
		[NullableContext(2)]
		public int GetRecommendedOption(ITalkItem talkItem = null)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return 0;
			}
			return assistant.GetOptionToSelect(talkItem);
		}

		// Token: 0x06036E5F RID: 224863 RVA: 0x00DEC4DE File Offset: 0x00DEA6DE
		public void SelectOption(int talkId, int index)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.RecordOption(talkId, index);
		}

		// Token: 0x06036E60 RID: 224864 RVA: 0x00DEC4F3 File Offset: 0x00DEA6F3
		public void RecordTalkItem(ITalkItem talkItem)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.RecordTalkItem(talkItem);
		}

		// Token: 0x06036E61 RID: 224865 RVA: 0x00DEC508 File Offset: 0x00DEA708
		public PlotReviewViewData CreatePlotReviewViewData()
		{
			List<PlotReviewItemData> list = new List<PlotReviewItemData>();
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			List<TalkRecord> list2 = (assistant != null) ? assistant.GetTalkHistory() : null;
			if (list2 != null && list2.Count > 0)
			{
				foreach (TalkRecord talkRecord in list2)
				{
					if (talkRecord.IsOption)
					{
						PlotReviewOptionItemData data = new PlotReviewOptionItemData
						{
							TalkItem = talkRecord.TalkItem,
							OptionIndex = talkRecord.OptionIndex.GetValueOrDefault()
						};
						PlotReviewItemData item = new PlotReviewItemData
						{
							Type = EPlotReviewItemType.Option,
							Data = data
						};
						list.Add(item);
					}
					else
					{
						PlotReviewTalkItemData data2 = new PlotReviewTalkItemData
						{
							TalkItem = talkRecord.TalkItem,
							IsPlaying = false
						};
						PlotReviewItemData item2 = new PlotReviewItemData
						{
							Type = EPlotReviewItemType.Talk,
							Data = data2
						};
						list.Add(item2);
					}
				}
			}
			return new PlotReviewViewData
			{
				PlotReviewItemDataList = list
			};
		}

		// Token: 0x06036E62 RID: 224866 RVA: 0x00DEC618 File Offset: 0x00DEA818
		public bool OpenPlotReviewView()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			List<TalkRecord> list = (assistant != null) ? assistant.GetTalkHistory() : null;
			if (list == null || list.Count == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PlotView_001", Array.Empty<object>());
				return false;
			}
			PlotReviewViewData param = this.CreatePlotReviewViewData();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PlotReviewView, param, null);
			return true;
		}

		// Token: 0x17008E08 RID: 36360
		// (get) Token: 0x06036E63 RID: 224867 RVA: 0x00DEC673 File Offset: 0x00DEA873
		public FlowSequence FlowSequence
		{
			get
			{
				return this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner).FlowSequence;
			}
		}

		// Token: 0x17008E09 RID: 36361
		// (get) Token: 0x06036E64 RID: 224868 RVA: 0x00DEC681 File Offset: 0x00DEA881
		public FlowShowTalk FlowShowTalk
		{
			get
			{
				return this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner).FlowShowTalk;
			}
		}

		// Token: 0x06036E65 RID: 224869 RVA: 0x00DEC68F File Offset: 0x00DEA88F
		public void EnableSkip(bool enable)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.EnableSkip(enable);
		}

		// Token: 0x06036E66 RID: 224870 RVA: 0x00DEC6A3 File Offset: 0x00DEA8A3
		public bool IsSkipEnabled()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			return assistant != null && assistant.IsSkipEnabled();
		}

		// Token: 0x06036E67 RID: 224871 RVA: 0x00DEC6B7 File Offset: 0x00DEA8B7
		public bool CheckCanSkipTmp()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			return assistant != null && assistant.CheckCanSkipTmp();
		}

		// Token: 0x06036E68 RID: 224872 RVA: 0x00DEC6CB File Offset: 0x00DEA8CB
		public void CountDownSkip(bool enable)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.TriggerCountDownSkip(enable);
		}

		// Token: 0x06036E69 RID: 224873 RVA: 0x00DEC6DF File Offset: 0x00DEA8DF
		public void CheckDisableInput(EPlotLevel? level = null)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.HandleInputBeforePlay(level);
		}

		// Token: 0x06036E6A RID: 224874 RVA: 0x00DEC6F3 File Offset: 0x00DEA8F3
		[NullableContext(2)]
		public ActionInfo GetNextAction(bool bCheckSubAction = true)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return null;
			}
			return assistant.GetNextAction(bCheckSubAction);
		}

		// Token: 0x06036E6B RID: 224875 RVA: 0x00DEC708 File Offset: 0x00DEA908
		public void LogError(string text, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.LogError(text, pairs);
		}

		// Token: 0x06036E6C RID: 224876 RVA: 0x00DEC71D File Offset: 0x00DEA91D
		public long GetFlowIncId()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return 0L;
			}
			return assistant.GetFlowIncId();
		}

		// Token: 0x06036E6D RID: 224877 RVA: 0x00DEC732 File Offset: 0x00DEA932
		public void RequestPosition(IVector location, IRotator rotation)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.RequestPosition(location, rotation);
		}

		// Token: 0x06036E6E RID: 224878 RVA: 0x00DEC747 File Offset: 0x00DEA947
		public bool CheckViewControlBeginForC()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			return assistant != null && assistant.CheckViewControlBeginForC();
		}

		// Token: 0x06036E6F RID: 224879 RVA: 0x00DEC75B File Offset: 0x00DEA95B
		public List<ActionParams> GetNameAction(EAction name)
		{
			return this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner).GetNameAction(name);
		}

		// Token: 0x06036E70 RID: 224880 RVA: 0x00DEC76A File Offset: 0x00DEA96A
		public string GetFlowName()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			return ((assistant != null) ? assistant.GetFlowName() : null) ?? string.Empty;
		}

		// Token: 0x06036E71 RID: 224881 RVA: 0x00DEC788 File Offset: 0x00DEA988
		public bool HasPendingShowTalkOrSequenceDataAction()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			return assistant != null && assistant.HasPendingShowTalkOrSequenceDataAction();
		}

		// Token: 0x06036E72 RID: 224882 RVA: 0x00DEC79C File Offset: 0x00DEA99C
		public bool CollectSeamlessFinalize(ESeamlessFinalizeFlag flag)
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			return assistant != null && assistant.CollectSeamlessFinalize(flag);
		}

		// Token: 0x06036E73 RID: 224883 RVA: 0x00DEC7B1 File Offset: 0x00DEA9B1
		public void RunDeferredSeamlessFinalizeOnPlotEnd()
		{
			FlowActionRunner assistant = this.GetAssistant<FlowActionRunner>(FlowController.EAssistantType.ActionRunner);
			if (assistant == null)
			{
				return;
			}
			assistant.RunDeferredSeamlessFinalizeOnPlotEnd();
		}

		// Token: 0x06036E74 RID: 224884 RVA: 0x00DEC7C4 File Offset: 0x00DEA9C4
		public void StartFlowByRes(string res)
		{
		}

		// Token: 0x06036E75 RID: 224885 RVA: 0x00DEC7C8 File Offset: 0x00DEA9C8
		[NullableContext(2)]
		public long StartFlow([Nullable(1)] string flowListName, int flowId, int stateId, GeneralContext context = null, long flowIncId = 0L, bool isServerNotify = false, bool isAsync = false, bool isSkip = false, global::Vector pos = null)
		{
			FlowLaunchCenter assistant = this.GetAssistant<FlowLaunchCenter>(FlowController.EAssistantType.LaunchCenter);
			if (assistant == null)
			{
				return 0L;
			}
			return assistant.StartFlow(flowListName, flowId, stateId, context, flowIncId, isServerNotify, isAsync, null, false, isSkip, pos, null, false);
		}

		// Token: 0x06036E76 RID: 224886 RVA: 0x00DEC7FC File Offset: 0x00DEA9FC
		public long StartFlowForView(string flowListName, int flowId, int stateId, UiParam uiParam, bool canBeAbandoned = true)
		{
			FlowLaunchCenter assistant = this.GetAssistant<FlowLaunchCenter>(FlowController.EAssistantType.LaunchCenter);
			if (assistant == null)
			{
				return 0L;
			}
			return assistant.StartFlow(flowListName, flowId, stateId, null, 0L, false, false, uiParam, canBeAbandoned, false, null, null, false);
		}

		// Token: 0x06036E77 RID: 224887 RVA: 0x00DEC82C File Offset: 0x00DEAA2C
		[NullableContext(2)]
		public long StartFlowForCallback([Nullable(1)] string flowListName, int flowId, int stateId, Action callback, GeneralContext context = null, long flowIncId = 0L, bool isServerNotify = false, bool isAsync = false, bool isSkip = false, global::Vector pos = null)
		{
			return this.GetAssistant<FlowLaunchCenter>(FlowController.EAssistantType.LaunchCenter).StartFlow(flowListName, flowId, stateId, context, flowIncId, isServerNotify, isAsync, null, false, isSkip, pos, callback, false);
		}

		// Token: 0x06036E78 RID: 224888 RVA: 0x00DEC85C File Offset: 0x00DEAA5C
		public void StartFlowForTeleportTransition(string flowListName, int flowId, int stateId, [Nullable(2)] Action callback = null)
		{
			this.GetAssistant<FlowLaunchCenter>(FlowController.EAssistantType.LaunchCenter).StartFlow(flowListName, flowId, stateId, null, 0L, false, false, null, false, false, null, callback, true);
		}

		// Token: 0x06036E79 RID: 224889 RVA: 0x00DEC885 File Offset: 0x00DEAA85
		public void StartPlotNetworkPending()
		{
			FlowLaunchCenter assistant = this.GetAssistant<FlowLaunchCenter>(FlowController.EAssistantType.LaunchCenter);
			if (assistant == null)
			{
				return;
			}
			assistant.StartPlotNetworkPending();
		}

		// Token: 0x06036E7A RID: 224890 RVA: 0x00DEC898 File Offset: 0x00DEAA98
		protected override void OnTick(float delta)
		{
			FlowLaunchCenter assistant = this.GetAssistant<FlowLaunchCenter>(FlowController.EAssistantType.LaunchCenter);
			if (assistant == null)
			{
				return;
			}
			assistant.Tick(delta);
		}

		// Token: 0x0401F986 RID: 129414
		public const int LOCAL_FLOWINCID = -1;

		// Token: 0x0200B390 RID: 45968
		[NullableContext(0)]
		private enum EAssistantType
		{
			// Token: 0x040379F7 RID: 227831
			ServerNotifyCenter,
			// Token: 0x040379F8 RID: 227832
			ActionCenter,
			// Token: 0x040379F9 RID: 227833
			ActionRunner,
			// Token: 0x040379FA RID: 227834
			LaunchCenter
		}
	}
}
