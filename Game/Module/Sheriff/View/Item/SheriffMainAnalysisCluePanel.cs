using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE2 RID: 20450
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainAnalysisCluePanel : UiTabViewBase
	{
		// Token: 0x06034BA9 RID: 215977 RVA: 0x00D39F1C File Offset: 0x00D3811C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034BAA RID: 215978 RVA: 0x00D39FC8 File Offset: 0x00D381C8
		protected override UniTask OnBeforeStartAsync()
		{
			SheriffMainAnalysisCluePanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SheriffMainAnalysisCluePanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034BAB RID: 215979 RVA: 0x00D3A00C File Offset: 0x00D3820C
		protected override void OnBeforeShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
			}
			int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
			List<int> clueRecords = this.Proxy.GetClueRecords(curQuestionIndex);
			for (int i = 0; i < clueRecords.Count; i++)
			{
				this.ClueItemList[i].Refresh(new int?(clueRecords[i]));
			}
			for (int j = clueRecords.Count; j < 3; j++)
			{
				this.ClueItemList[j].Refresh(null);
			}
			this.RefreshClueState();
			this.RefreshDialogPanel();
			this.RefreshDialog();
			this.LogReport();
		}

		// Token: 0x06034BAC RID: 215980 RVA: 0x00D3A0CC File Offset: 0x00D382CC
		protected void LogReport()
		{
			SheriffReasoningCompleteEvent sheriffReasoningCompleteEvent = new SheriffReasoningCompleteEvent();
			sheriffReasoningCompleteEvent.i_quest_id = this.Proxy.GetAnomalyInfo().AnomalyId;
			int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
			sheriffReasoningCompleteEvent.i_question_id = this.Proxy.GetQuestionIdByIndex(curQuestionIndex);
			sheriffReasoningCompleteEvent.i_result_id = ((this.ClueState != EClueState.Success) ? 1 : 0);
			List<int> clueRecords = this.Proxy.GetClueRecords(curQuestionIndex);
			sheriffReasoningCompleteEvent.o_clue_id = clueRecords;
			ControllerBase<LogReportController>.Instance.LogReport(sheriffReasoningCompleteEvent);
		}

		// Token: 0x06034BAD RID: 215981 RVA: 0x00D3A144 File Offset: 0x00D38344
		protected void RefreshClueState()
		{
			this.QuestionAnalysisConfig = null;
			int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
			int questionIdByIndex = this.Proxy.GetQuestionIdByIndex(curQuestionIndex);
			ISheriffQuestionJsonConfig questionConfig = this.Proxy.GetQuestionConfig(questionIdByIndex);
			List<int> clueRecords = this.Proxy.GetClueRecords(curQuestionIndex);
			foreach (ISheriffQuestionResultJsonConfig sheriffQuestionResultJsonConfig in questionConfig.ResultConfigs)
			{
				bool flag = true;
				foreach (int item in sheriffQuestionResultJsonConfig.ClueCombination)
				{
					if (!clueRecords.Contains(item))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.QuestionAnalysisConfig = sheriffQuestionResultJsonConfig;
					break;
				}
			}
			if (this.QuestionAnalysisConfig != null)
			{
				this.ClueState = EClueState.Success;
				this.GetTalkList(this.QuestionAnalysisConfig.ReasoningStateId);
				if (this.QuestionAnalysisConfig.NextQuestionId != null)
				{
					this.DialogPanel.SetNextQuestionIdOrEnding(this.QuestionAnalysisConfig);
					return;
				}
				if (this.QuestionAnalysisConfig.EndingId != null)
				{
					this.DialogPanel.SetNextQuestionIdOrEnding(this.QuestionAnalysisConfig);
					return;
				}
			}
			else
			{
				this.ClueState = EClueState.Fail;
				this.Proxy.SetFailureCount();
				this.GetTalkList(ConfigBase<SheriffConfig>.Instance.GetQuestionById(questionIdByIndex).Value.FailResultDesc().ToList<string>());
			}
		}

		// Token: 0x06034BAE RID: 215982 RVA: 0x00D3A2D4 File Offset: 0x00D384D4
		private void GetTalkList(List<string> stateIds)
		{
			this.CurTalkIndex = 0;
			this.TalkList.Clear();
			foreach (ActionInfo actionInfo in ConfigBase<FlowConfig>.Instance.GetFlowStateActions(stateIds[0], int.Parse(stateIds[1]), int.Parse(stateIds[2])))
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					foreach (ITalkItem talkItem in (actionInfo.Params as ShowTalk).TalkItems)
					{
						this.TalkList.Add(talkItem.TidTalk ?? "");
					}
				}
			}
		}

		// Token: 0x06034BAF RID: 215983 RVA: 0x00D3A3C0 File Offset: 0x00D385C0
		protected void RefreshDialogPanel()
		{
			if (this.ClueState != EClueState.Success)
			{
				int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
				int questionIdByIndex = this.Proxy.GetQuestionIdByIndex(curQuestionIndex);
				SheriffMainAnalysisClueDialogPanel dialogPanel = this.DialogPanel;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
				defaultInterpolatedStringHandler.AppendLiteral("ReasoningQuestion_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(questionIdByIndex);
				defaultInterpolatedStringHandler.AppendLiteral("_QuestionDesc");
				dialogPanel.RefreshTitleText(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			this.DialogPanel.RefreshDialogPanel(this.ClueState);
		}

		// Token: 0x06034BB0 RID: 215984 RVA: 0x00D3A43C File Offset: 0x00D3863C
		private void RefreshDialog()
		{
			if (this.CurTalkIndex < this.TalkList.Count)
			{
				this.DialogPanel.RefreshDialogText(this.TalkList[this.CurTalkIndex]);
				this.CurTalkIndex++;
				return;
			}
			if (this.ClueState == EClueState.Success)
			{
				this.ClueState = EClueState.Conclusion;
				this.GetTalkList(this.QuestionAnalysisConfig.ResultDesc);
				this.CurTalkIndex = 0;
				SheriffMainAnalysisClueDialogPanel dialogPanel = this.DialogPanel;
				ISheriffQuestionResultJsonConfig questionAnalysisConfig = this.QuestionAnalysisConfig;
				dialogPanel.RefreshNextBtnText(questionAnalysisConfig != null && questionAnalysisConfig.EndingId != null);
				this.DialogPanel.RefreshDialogPanel(EClueState.Conclusion);
				int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
				int questionIdByIndex = this.Proxy.GetQuestionIdByIndex(curQuestionIndex);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
				defaultInterpolatedStringHandler.AppendLiteral("ReasoningQuestion_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(questionIdByIndex);
				defaultInterpolatedStringHandler.AppendLiteral("_QuestionDesc");
				string text = defaultInterpolatedStringHandler.ToStringAndClear();
				this.DialogPanel.RefreshTitleText(text);
				this.Proxy.SetConclusionKey(this.TalkList[this.CurTalkIndex]);
				this.DialogPanel.RefreshDialogText(this.TalkList[this.CurTalkIndex]);
				return;
			}
			EClueState clueState = this.ClueState;
		}

		// Token: 0x0401E625 RID: 124453
		protected EClueState ClueState;

		// Token: 0x0401E626 RID: 124454
		[Nullable(2)]
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E627 RID: 124455
		protected List<SheriffMainAnalysisClueItem> ClueItemList = new List<SheriffMainAnalysisClueItem>();

		// Token: 0x0401E628 RID: 124456
		[Nullable(2)]
		protected ISheriffQuestionResultJsonConfig QuestionAnalysisConfig;

		// Token: 0x0401E629 RID: 124457
		[Nullable(2)]
		protected SheriffMainAnalysisClueDialogPanel DialogPanel;

		// Token: 0x0401E62A RID: 124458
		protected List<string> TalkList = new List<string>();

		// Token: 0x0401E62B RID: 124459
		protected int CurTalkIndex;

		// Token: 0x0200AFBC RID: 44988
		[NullableContext(0)]
		private static class EDefine
		{
			// Token: 0x04036879 RID: 223353
			public const int TogSkyEyeClue1 = 0;

			// Token: 0x0403687A RID: 223354
			public const int TogSkyEyeClue2 = 1;

			// Token: 0x0403687B RID: 223355
			public const int TogSkyEyeClue3 = 2;

			// Token: 0x0403687C RID: 223356
			public const int DialogItem = 3;
		}
	}
}
