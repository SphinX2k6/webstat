using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FCB RID: 20427
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainProxy
	{
		// Token: 0x06034ABB RID: 215739 RVA: 0x00D34C8C File Offset: 0x00D32E8C
		public SheriffMainProxy(int gameplayId)
		{
			this.GameplayId = gameplayId;
			SheriffAnomaly? anomalyConfigByQuestionId = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigByQuestionId(this.GameplayId);
			this.AnomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(anomalyConfigByQuestionId.Value.Id);
		}

		// Token: 0x06034ABC RID: 215740 RVA: 0x00D34D1B File Offset: 0x00D32F1B
		public void InitData()
		{
			this.InitQuestionConfig();
		}

		// Token: 0x06034ABD RID: 215741 RVA: 0x00D34D24 File Offset: 0x00D32F24
		public void InitGameDataOnBegin()
		{
			this.QuestionIds.Clear();
			this.QuestionIds.Add(this.FirstQuestionId);
			this.CurQuestionIndex = 0;
			this.ClueRecordsMap.Clear();
			this.EndingConfigCache = null;
			this.BackFromDetailClue = false;
			this.NeedHintToggle = false;
		}

		// Token: 0x06034ABE RID: 215742 RVA: 0x00D34D74 File Offset: 0x00D32F74
		protected void InitQuestionConfig()
		{
			SheriffQuestionMainCsv value = ConfigBase<SheriffConfig>.Instance.GetQuestionMainById(this.GameplayId).Value;
			if (value.QuestionConfigs.Length == 0)
			{
				return;
			}
			int num = 0;
			using (List<ISheriffQuestionJsonConfig>.Enumerator enumerator = Json.Decode<List<ISheriffQuestionJsonConfig>>(value.QuestionConfigs, null).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ISheriffQuestionJsonConfig sheriffQuestionJsonConfig = enumerator.Current;
					this.QuestionConfigRecord[sheriffQuestionJsonConfig.QuestionId] = sheriffQuestionJsonConfig;
					if (this.FirstQuestionId == 0)
					{
						this.FirstQuestionId = sheriffQuestionJsonConfig.QuestionId;
					}
					if (num == 0)
					{
						num = sheriffQuestionJsonConfig.QuestionId;
					}
				}
				goto IL_14A;
			}
			IL_9A:
			ISheriffQuestionJsonConfig sheriffQuestionJsonConfig2;
			if (!this.QuestionConfigRecord.TryGetValue(num, out sheriffQuestionJsonConfig2))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffQuestion questionConfig Error";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				goto IL_15A;
			}
			this.QuestionCount++;
			if (sheriffQuestionJsonConfig2.ResultConfigs.Count == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Sheriff;
				ELogAuthor author2 = ELogAuthor.WHJ;
				string message2 = "SheriffQuestion ResultConfigs Error";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", sheriffQuestionJsonConfig2.QuestionId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				goto IL_15A;
			}
			num = sheriffQuestionJsonConfig2.ResultConfigs[0].NextQuestionId.GetValueOrDefault();
			IL_14A:
			if (num != 0 && this.QuestionCount < 10)
			{
				goto IL_9A;
			}
			IL_15A:
			if (this.QuestionCount > 10)
			{
				Singleton<Log>.Instance.Error(ELogModule.Sheriff, ELogAuthor.WHJ, "SheriffQuestion Config Error, QuestionCount > 10", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06034ABF RID: 215743 RVA: 0x00D34F18 File Offset: 0x00D33118
		public int GetCurQuestionIndex()
		{
			return this.CurQuestionIndex;
		}

		// Token: 0x06034AC0 RID: 215744 RVA: 0x00D34F20 File Offset: 0x00D33120
		public int GetQuestionIdByIndex(int index)
		{
			return this.QuestionIds[index];
		}

		// Token: 0x06034AC1 RID: 215745 RVA: 0x00D34F2E File Offset: 0x00D3312E
		public int GetQuestionDataLength()
		{
			return this.QuestionCount;
		}

		// Token: 0x06034AC2 RID: 215746 RVA: 0x00D34F38 File Offset: 0x00D33138
		public List<int> GetClueRecords(int questionIndex)
		{
			List<int> result;
			if (!this.ClueRecordsMap.TryGetValue(questionIndex, out result))
			{
				return new List<int>();
			}
			return result;
		}

		// Token: 0x06034AC3 RID: 215747 RVA: 0x00D34F5C File Offset: 0x00D3315C
		public void SetClueRecords(int questionIndex, List<int> clueIds)
		{
			this.ClueRecordsMap[questionIndex] = clueIds;
			Action onClueRecordsCallback = this.OnClueRecordsCallback;
			if (onClueRecordsCallback == null)
			{
				return;
			}
			onClueRecordsCallback();
		}

		// Token: 0x06034AC4 RID: 215748 RVA: 0x00D34F7B File Offset: 0x00D3317B
		public List<int> GetQuestionList()
		{
			return this.QuestionIds;
		}

		// Token: 0x06034AC5 RID: 215749 RVA: 0x00D34F83 File Offset: 0x00D33183
		public void ClickClueDetail(int clueIndex)
		{
			this.NeedRemainHoverItem = true;
			this.ConfirmClueIndex = this.GamepadHoverIndex;
			this.CurrentClickedClueIndex = clueIndex;
			Action onCheckClueDetailCallback = this.OnCheckClueDetailCallback;
			if (onCheckClueDetailCallback == null)
			{
				return;
			}
			onCheckClueDetailCallback();
		}

		// Token: 0x06034AC6 RID: 215750 RVA: 0x00D34FAF File Offset: 0x00D331AF
		public void OnHoverClue(int index)
		{
			this.GamepadHoverIndex = index;
		}

		// Token: 0x06034AC7 RID: 215751 RVA: 0x00D34FB8 File Offset: 0x00D331B8
		public void CloseClueDetail()
		{
			this.BackFromDetailClue = true;
			Action onBackFromDetailClueCallback = this.OnBackFromDetailClueCallback;
			if (onBackFromDetailClueCallback == null)
			{
				return;
			}
			onBackFromDetailClueCallback();
		}

		// Token: 0x06034AC8 RID: 215752 RVA: 0x00D34FD1 File Offset: 0x00D331D1
		public SheriffAnomalyInfo GetAnomalyInfo()
		{
			return this.AnomalyInfo;
		}

		// Token: 0x06034AC9 RID: 215753 RVA: 0x00D34FDC File Offset: 0x00D331DC
		public int GetCurrentClueLength()
		{
			int id = this.QuestionIds[this.CurQuestionIndex];
			return ConfigBase<SheriffConfig>.Instance.GetQuestionById(id).Value.NeedClueCount;
		}

		// Token: 0x06034ACA RID: 215754 RVA: 0x00D35018 File Offset: 0x00D33218
		public void SetConclusionKey(string key)
		{
			int questionIdByIndex = this.GetQuestionIdByIndex(this.CurQuestionIndex);
			this.ConclusionKeyMap[questionIdByIndex] = key;
		}

		// Token: 0x06034ACB RID: 215755 RVA: 0x00D35040 File Offset: 0x00D33240
		public string GetConclusionKey(int questionId)
		{
			string result;
			if (!this.ConclusionKeyMap.TryGetValue(questionId, out result))
			{
				return "";
			}
			return result;
		}

		// Token: 0x06034ACC RID: 215756 RVA: 0x00D35064 File Offset: 0x00D33264
		public ISheriffQuestionJsonConfig GetQuestionConfig(int questionId)
		{
			return this.QuestionConfigRecord[questionId];
		}

		// Token: 0x06034ACD RID: 215757 RVA: 0x00D35074 File Offset: 0x00D33274
		public List<string> GetBeforeDialogStateId()
		{
			int questionIdByIndex = this.GetQuestionIdByIndex(this.CurQuestionIndex);
			return ConfigBase<SheriffConfig>.Instance.GetQuestionById(questionIdByIndex).Value.EnterFlowStateId().ToList<string>();
		}

		// Token: 0x06034ACE RID: 215758 RVA: 0x00D350B0 File Offset: 0x00D332B0
		[NullableContext(2)]
		public void DoAfterAnalysisClueLogic(bool isReset, ISheriffQuestionResultJsonConfig config = null)
		{
			this.SetNeedHintToggle(false);
			if (isReset)
			{
				this.NeedRemainHoverItem = true;
				this.ConfirmClueIndex = this.GamepadHoverIndex;
				this.ClueRecordsMap.Remove(this.GetCurQuestionIndex());
				Action<bool> onAnalysisClueEndCallback = this.OnAnalysisClueEndCallback;
				if (onAnalysisClueEndCallback == null)
				{
					return;
				}
				onAnalysisClueEndCallback(false);
				return;
			}
			else if (config != null && config.EndingId != null)
			{
				this.EndingConfigCache = config;
				Action onConclusionInfoCallback = this.OnConclusionInfoCallback;
				if (onConclusionInfoCallback == null)
				{
					return;
				}
				onConclusionInfoCallback();
				return;
			}
			else
			{
				this.QuestionIds.Add(config.NextQuestionId.Value);
				this.CurQuestionIndex++;
				Action<bool> onAnalysisClueEndCallback2 = this.OnAnalysisClueEndCallback;
				if (onAnalysisClueEndCallback2 == null)
				{
					return;
				}
				onAnalysisClueEndCallback2(true);
				return;
			}
		}

		// Token: 0x06034ACF RID: 215759 RVA: 0x00D35164 File Offset: 0x00D33364
		public void RestartGameplay()
		{
			this.InitGameDataOnBegin();
			Action<bool> onAnalysisClueEndCallback = this.OnAnalysisClueEndCallback;
			if (onAnalysisClueEndCallback == null)
			{
				return;
			}
			onAnalysisClueEndCallback(true);
		}

		// Token: 0x06034AD0 RID: 215760 RVA: 0x00D3517D File Offset: 0x00D3337D
		public void CloseGameplay()
		{
			Action onGameplayAllEndCallback = this.OnGameplayAllEndCallback;
			if (onGameplayAllEndCallback == null)
			{
				return;
			}
			onGameplayAllEndCallback();
		}

		// Token: 0x06034AD1 RID: 215761 RVA: 0x00D3518F File Offset: 0x00D3338F
		public void ReplaySelectClueDialog()
		{
			Action onClickedReplayDialog = this.OnClickedReplayDialog;
			if (onClickedReplayDialog == null)
			{
				return;
			}
			onClickedReplayDialog();
		}

		// Token: 0x06034AD2 RID: 215762 RVA: 0x00D351A4 File Offset: 0x00D333A4
		[NullableContext(0)]
		public UniTask<bool> RequestConfirm()
		{
			SheriffMainProxy.<RequestConfirm>d__49 <RequestConfirm>d__;
			<RequestConfirm>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestConfirm>d__.<>4__this = this;
			<RequestConfirm>d__.<>1__state = -1;
			<RequestConfirm>d__.<>t__builder.Start<SheriffMainProxy.<RequestConfirm>d__49>(ref <RequestConfirm>d__);
			return <RequestConfirm>d__.<>t__builder.Task;
		}

		// Token: 0x06034AD3 RID: 215763 RVA: 0x00D351E8 File Offset: 0x00D333E8
		public bool CheckNeedHintButton()
		{
			int questionIdByIndex = this.GetQuestionIdByIndex(this.GetCurQuestionIndex());
			SheriffQuestionCsv value = ConfigBase<SheriffConfig>.Instance.GetQuestionById(questionIdByIndex).Value;
			int num;
			bool flag = (this.FailureCountMap.TryGetValue(questionIdByIndex, out num) ? num : 0) >= value.SoftPityCount;
			bool flag2 = true;
			foreach (int item in value.SoftPityClueIds())
			{
				if (!this.AnomalyInfo.ClueIds.Contains(item))
				{
					flag2 = false;
					break;
				}
			}
			return flag && flag2;
		}

		// Token: 0x06034AD4 RID: 215764 RVA: 0x00D3527C File Offset: 0x00D3347C
		public void SetFailureCount()
		{
			int questionIdByIndex = this.GetQuestionIdByIndex(this.GetCurQuestionIndex());
			int num2;
			int num = this.FailureCountMap.TryGetValue(questionIdByIndex, out num2) ? num2 : 0;
			this.FailureCountMap[questionIdByIndex] = num + 1;
		}

		// Token: 0x06034AD5 RID: 215765 RVA: 0x00D352BA File Offset: 0x00D334BA
		public bool CheckNeedHintToggle()
		{
			return this.NeedHintToggle;
		}

		// Token: 0x06034AD6 RID: 215766 RVA: 0x00D352C2 File Offset: 0x00D334C2
		public void SetNeedHintToggle(bool needHintToggle)
		{
			this.NeedHintToggle = needHintToggle;
		}

		// Token: 0x06034AD7 RID: 215767 RVA: 0x00D352CC File Offset: 0x00D334CC
		public bool CheckIsHinting(int clueId)
		{
			if (clueId <= 0)
			{
				return false;
			}
			if (!this.CheckNeedHintToggle())
			{
				return false;
			}
			int questionIdByIndex = this.GetQuestionIdByIndex(this.GetCurQuestionIndex());
			return ConfigBase<SheriffConfig>.Instance.GetQuestionById(questionIdByIndex).Value.SoftPityClueIds().Contains(clueId);
		}

		// Token: 0x06034AD8 RID: 215768 RVA: 0x00D35317 File Offset: 0x00D33517
		public void RefreshHintToggleState()
		{
			Action onClueHintStateChangeCallback = this.OnClueHintStateChangeCallback;
			if (onClueHintStateChangeCallback == null)
			{
				return;
			}
			onClueHintStateChangeCallback();
		}

		// Token: 0x06034AD9 RID: 215769 RVA: 0x00D35329 File Offset: 0x00D33529
		public void RefreshHintButtonEnable(bool isCurIndex)
		{
			Action<bool> onRefreshHintButton = this.OnRefreshHintButton;
			if (onRefreshHintButton == null)
			{
				return;
			}
			onRefreshHintButton(isCurIndex);
		}

		// Token: 0x0401E5D4 RID: 124372
		[Nullable(2)]
		public Action OnClueRecordsCallback;

		// Token: 0x0401E5D5 RID: 124373
		[Nullable(2)]
		public Action<bool> OnAnalysisClueEndCallback;

		// Token: 0x0401E5D6 RID: 124374
		[Nullable(2)]
		public Action OnBackFromDetailClueCallback;

		// Token: 0x0401E5D7 RID: 124375
		[Nullable(2)]
		public Action OnCheckClueDetailCallback;

		// Token: 0x0401E5D8 RID: 124376
		[Nullable(2)]
		public Action OnConclusionInfoCallback;

		// Token: 0x0401E5D9 RID: 124377
		[Nullable(2)]
		public Action OnGameplayAllEndCallback;

		// Token: 0x0401E5DA RID: 124378
		[Nullable(2)]
		public Action OnClueHintStateChangeCallback;

		// Token: 0x0401E5DB RID: 124379
		[Nullable(2)]
		public Action OnClickedReplayDialog;

		// Token: 0x0401E5DC RID: 124380
		[Nullable(2)]
		public Action<bool> OnRefreshHintButton;

		// Token: 0x0401E5DD RID: 124381
		public int CurrentClickedClueIndex;

		// Token: 0x0401E5DE RID: 124382
		public bool BackFromDetailClue;

		// Token: 0x0401E5DF RID: 124383
		protected int CurQuestionIndex;

		// Token: 0x0401E5E0 RID: 124384
		protected int QuestionCount;

		// Token: 0x0401E5E1 RID: 124385
		public bool NeedRemainHoverItem;

		// Token: 0x0401E5E2 RID: 124386
		public int GamepadHoverIndex = -1;

		// Token: 0x0401E5E3 RID: 124387
		public int ConfirmClueIndex = -1;

		// Token: 0x0401E5E4 RID: 124388
		protected List<int> QuestionIds = new List<int>();

		// Token: 0x0401E5E5 RID: 124389
		protected Dictionary<int, ISheriffQuestionJsonConfig> QuestionConfigRecord = new Dictionary<int, ISheriffQuestionJsonConfig>();

		// Token: 0x0401E5E6 RID: 124390
		protected Dictionary<int, List<int>> ClueRecordsMap = new Dictionary<int, List<int>>();

		// Token: 0x0401E5E7 RID: 124391
		protected SheriffAnomalyInfo AnomalyInfo;

		// Token: 0x0401E5E8 RID: 124392
		protected Dictionary<int, string> ConclusionKeyMap = new Dictionary<int, string>();

		// Token: 0x0401E5E9 RID: 124393
		protected int FirstQuestionId;

		// Token: 0x0401E5EA RID: 124394
		[Nullable(2)]
		protected ISheriffQuestionResultJsonConfig EndingConfigCache;

		// Token: 0x0401E5EB RID: 124395
		protected Dictionary<int, int> FailureCountMap = new Dictionary<int, int>();

		// Token: 0x0401E5EC RID: 124396
		protected bool NeedHintToggle;

		// Token: 0x0401E5ED RID: 124397
		protected int GameplayId;
	}
}
