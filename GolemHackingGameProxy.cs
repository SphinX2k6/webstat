using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;

// Token: 0x020010BE RID: 4286
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingGameProxy
{
	// Token: 0x06006F73 RID: 28531 RVA: 0x001CFBD0 File Offset: 0x001CDDD0
	public GolemHackingGameProxy(int configId)
	{
		this.ConfigId = configId;
	}

	// Token: 0x06006F74 RID: 28532 RVA: 0x001CFC30 File Offset: 0x001CDE30
	public void Init()
	{
		DaemonHackConfigCsv value = ConfigBase<GolemHackingConfig>.Instance.GetPlayConfig(this.ConfigId).Value;
		this.MaxTime = (double)value.CountDown;
		this.MaxLength = value.CodeBufferSize;
		for (int i = 0; i < value.TargetCodesLength; i++)
		{
			List<string> item = new List<string>(value.TargetCodes(i).Split(' ', StringSplitOptions.None));
			this.TargetCode.Add(item);
		}
		this.TryTimeMax = value.FailThreshold;
		GolemHackingJsonConfig golemHackingJsonConfig = Json.Parse<GolemHackingJsonConfig>(value.CodeMatrix, null);
		if (golemHackingJsonConfig != null)
		{
			this.Size = golemHackingJsonConfig.MatrixSize;
			for (int j = 0; j < golemHackingJsonConfig.PresetCodes.Count; j++)
			{
				GolemHackingGridJsonConfig golemHackingGridJsonConfig = golemHackingJsonConfig.PresetCodes[j];
				GolemHackingGridInfo item2 = new GolemHackingGridInfo
				{
					Code = golemHackingGridJsonConfig.Code,
					Index = j,
					IsUsed = false,
					IsHovering = false
				};
				if (golemHackingGridJsonConfig.IsCorrect.GetValueOrDefault() && golemHackingGridJsonConfig.Order != null && golemHackingGridJsonConfig.Order.Value > 0)
				{
					if (golemHackingGridJsonConfig.Order.Value > this.OfficialAnswer.Count)
					{
						for (int k = this.OfficialAnswer.Count; k < golemHackingGridJsonConfig.Order.Value; k++)
						{
							this.OfficialAnswer.Add(0);
						}
					}
					this.OfficialAnswer[golemHackingGridJsonConfig.Order.Value - 1] = j;
				}
				this.InfoList.Add(item2);
			}
		}
	}

	// Token: 0x06006F75 RID: 28533 RVA: 0x001CFDE8 File Offset: 0x001CDFE8
	public void Reset()
	{
		this.ResetCount++;
		this.IsRestart = true;
		this.CurGridGroup = 0;
		this.IsCurRow = true;
		foreach (GolemHackingGridInfo golemHackingGridInfo in this.InfoList)
		{
			golemHackingGridInfo.IsUsed = false;
		}
		this.CurAnswerIndexList.Clear();
		this.CurTime = 0.0;
		this.TryTimesAdd();
		Action resetMatrixCallback = this.ResetMatrixCallback;
		if (resetMatrixCallback != null)
		{
			resetMatrixCallback();
		}
		Action resetCodeCallback = this.ResetCodeCallback;
		if (resetCodeCallback != null)
		{
			resetCodeCallback();
		}
		this.CurTime = 0.0;
	}

	// Token: 0x06006F76 RID: 28534 RVA: 0x001CFEB0 File Offset: 0x001CE0B0
	protected void TryTimesAdd()
	{
		if (this.AddTryTime() >= this.TryTimeMax && !this.HasBroadcastTryTime)
		{
			this.HasBroadcastTryTime = true;
		}
	}

	// Token: 0x06006F77 RID: 28535 RVA: 0x001CFECF File Offset: 0x001CE0CF
	public int GetPadSize()
	{
		return this.Size;
	}

	// Token: 0x06006F78 RID: 28536 RVA: 0x001CFED7 File Offset: 0x001CE0D7
	public bool GetNeedTick()
	{
		return this.MaxTime > 0.0;
	}

	// Token: 0x06006F79 RID: 28537 RVA: 0x001CFEEA File Offset: 0x001CE0EA
	public double GetMaxTime()
	{
		return this.MaxTime;
	}

	// Token: 0x06006F7A RID: 28538 RVA: 0x001CFEF2 File Offset: 0x001CE0F2
	public int GetMaxLength()
	{
		return this.MaxLength;
	}

	// Token: 0x06006F7B RID: 28539 RVA: 0x001CFEFA File Offset: 0x001CE0FA
	public List<GolemHackingTipsGirdInfo> GetHelpTipsInfo()
	{
		if (this.HelpTipsInfo.Count == 0 && this.OnGetHelpTips != null)
		{
			this.HelpTipsInfo = this.OnGetHelpTips();
		}
		return this.HelpTipsInfo;
	}

	// Token: 0x06006F7C RID: 28540 RVA: 0x001CFF28 File Offset: 0x001CE128
	public List<List<GolemHackingGridInfo>> GetGridInfoMatrix()
	{
		List<List<GolemHackingGridInfo>> list = new List<List<GolemHackingGridInfo>>();
		for (int i = 0; i < this.Size; i++)
		{
			list.Add(new List<GolemHackingGridInfo>());
		}
		for (int j = 0; j < this.InfoList.Count; j++)
		{
			list[j % this.Size].Add(this.InfoList[j]);
		}
		return list;
	}

	// Token: 0x06006F7D RID: 28541 RVA: 0x001CFF90 File Offset: 0x001CE190
	[NullableContext(0)]
	public ValueTuple<int, bool> OnClickedGrid(int grid)
	{
		this.IsCurRow = !this.IsCurRow;
		int num = 0;
		if (this.IsCurRow)
		{
			num = grid / this.Size;
		}
		else
		{
			num = grid % this.Size;
		}
		if (this.CurAnswerIndexList.Count == 0 && this.GetNeedTick())
		{
			Action startMatrixTickCallback = this.StartMatrixTickCallback;
			if (startMatrixTickCallback != null)
			{
				startMatrixTickCallback();
			}
		}
		this.CurAnswerIndexList.Add(grid);
		List<string> list = new List<string>();
		foreach (int index in this.CurAnswerIndexList)
		{
			GolemHackingGridInfo golemHackingGridInfo = this.InfoList[index];
			list.Add(golemHackingGridInfo.Code);
		}
		this.DoEnterLogic(list);
		this.CurGridGroup = num;
		return new ValueTuple<int, bool>(num, this.IsCurRow);
	}

	// Token: 0x06006F7E RID: 28542 RVA: 0x001D0078 File Offset: 0x001CE278
	private void DoEnterLogic(List<string> codeList)
	{
		List<GolemHackingCodeEnterResult> list = this.RefreshCodePanelResult(codeList);
		int num = 0;
		int num2 = 0;
		foreach (GolemHackingCodeEnterResult golemHackingCodeEnterResult in list)
		{
			num += ((golemHackingCodeEnterResult.State == EGolemHackingBarState.Success) ? 1 : 0);
			num2 += ((golemHackingCodeEnterResult.State == EGolemHackingBarState.Fail) ? 1 : 0);
		}
		if (num == list.Count)
		{
			this.LogReport(EGolemHackingReportType.Success, true);
			this.OnOneTurnEndBeforeAnim(true);
		}
		else if (num2 > 0)
		{
			this.FailCount++;
			this.OnOneTurnEndBeforeAnim(false);
		}
		if (this.EnterCodeCallback != null)
		{
			List<string> list2 = new List<string>();
			foreach (int index in this.CurAnswerIndexList)
			{
				GolemHackingGridInfo golemHackingGridInfo = this.InfoList[index];
				list2.Add(golemHackingGridInfo.Code);
			}
			this.EnterCodeCallback(list2, list);
		}
		this.OnUnHoveredMatrixGrid();
	}

	// Token: 0x06006F7F RID: 28543 RVA: 0x001D0198 File Offset: 0x001CE398
	protected void OnOneTurnEndBeforeAnim(bool isSuccess)
	{
		this.CacheResult = isSuccess;
		Action stopMatrixTickCallback = this.StopMatrixTickCallback;
		if (stopMatrixTickCallback == null)
		{
			return;
		}
		stopMatrixTickCallback();
	}

	// Token: 0x06006F80 RID: 28544 RVA: 0x001D01B1 File Offset: 0x001CE3B1
	public void OnOneTurnEndAfterAnim()
	{
		this.OnOneTurnEnd(this.CacheResult);
	}

	// Token: 0x06006F81 RID: 28545 RVA: 0x001D01C0 File Offset: 0x001CE3C0
	protected void OnOneTurnEnd(bool isSuccess)
	{
		Action action = delegate()
		{
			this.Reset();
		};
		GolemHackingResultInfo param = new GolemHackingResultInfo
		{
			IsSuccess = isSuccess,
			CloseCallback = (isSuccess ? this.OnGameplaySuccessCallback : action)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GolemHackingResultPop, param, null);
	}

	// Token: 0x06006F82 RID: 28546 RVA: 0x001D020A File Offset: 0x001CE40A
	public void InitCodePanelInfo()
	{
		this.DoEnterLogic(new List<string>());
	}

	// Token: 0x06006F83 RID: 28547 RVA: 0x001D0217 File Offset: 0x001CE417
	public bool NeedHelpBtn()
	{
		return this.GetTryTime() >= this.TryTimeMax;
	}

	// Token: 0x06006F84 RID: 28548 RVA: 0x001D022C File Offset: 0x001CE42C
	public int GetTryTime()
	{
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.GolemCrack) as ServerStorageMap;
		int? num = (serverStorageMap != null) ? serverStorageMap.Get(this.ConfigId) : null;
		if (num == null)
		{
			serverStorageMap.Set(this.ConfigId, 0);
			return 0;
		}
		return num.Value;
	}

	// Token: 0x06006F85 RID: 28549 RVA: 0x001D0288 File Offset: 0x001CE488
	public int AddTryTime()
	{
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.GolemCrack) as ServerStorageMap;
		int num = ((serverStorageMap != null) ? serverStorageMap.Get(this.ConfigId) : null).GetValueOrDefault() + 1;
		serverStorageMap.Set(this.ConfigId, num);
		return num;
	}

	// Token: 0x06006F86 RID: 28550 RVA: 0x001D02DC File Offset: 0x001CE4DC
	private List<GolemHackingCodeEnterResult> RefreshCodePanelResult(List<string> inputList)
	{
		List<GolemHackingCodeEnterResult> list = new List<GolemHackingCodeEnterResult>();
		foreach (List<string> codeList in this.TargetCode)
		{
			list.Add(this.RefreshSingleCode(codeList, inputList));
		}
		return list;
	}

	// Token: 0x06006F87 RID: 28551 RVA: 0x001D0340 File Offset: 0x001CE540
	private GolemHackingCodeEnterResult RefreshSingleCode(List<string> codeList, List<string> inputList)
	{
		GolemHackingCodeEnterResult golemHackingCodeEnterResult = new GolemHackingCodeEnterResult
		{
			Code = new List<GolemHackingCodeGridInfo>(),
			State = EGolemHackingBarState.Default
		};
		int count = codeList.Count;
		int count2 = inputList.Count;
		int num = -1;
		for (int i = 0; i < count2; i++)
		{
			int count3 = Math.Min(count, count2 - i);
			List<string> range = inputList.GetRange(i, count3);
			List<string> range2 = codeList.GetRange(0, Math.Min(range.Count, count));
			bool flag = true;
			for (int j = 0; j < range.Count; j++)
			{
				if (range[j] != range2[j])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				num = i;
				break;
			}
		}
		int maxLength = this.GetMaxLength();
		num = ((num == -1) ? count2 : num);
		if (num + count <= count2)
		{
			golemHackingCodeEnterResult.State = EGolemHackingBarState.Success;
		}
		else
		{
			golemHackingCodeEnterResult.State = ((num + count <= maxLength) ? EGolemHackingBarState.Default : EGolemHackingBarState.Fail);
		}
		for (int k = 0; k < Math.Min(num, maxLength - count); k++)
		{
			GolemHackingCodeGridInfo item = new GolemHackingCodeGridInfo
			{
				Code = "",
				Correct = false,
				BarState = golemHackingCodeEnterResult.State,
				AnimIndex = 0
			};
			golemHackingCodeEnterResult.Code.Add(item);
		}
		foreach (string text in codeList)
		{
			string a = (golemHackingCodeEnterResult.Code.Count < count2) ? inputList[golemHackingCodeEnterResult.Code.Count] : null;
			GolemHackingCodeGridInfo item2 = new GolemHackingCodeGridInfo
			{
				Code = text,
				Correct = (a == text && golemHackingCodeEnterResult.State != EGolemHackingBarState.Fail),
				BarState = golemHackingCodeEnterResult.State,
				AnimIndex = 0
			};
			golemHackingCodeEnterResult.Code.Add(item2);
		}
		return golemHackingCodeEnterResult;
	}

	// Token: 0x06006F88 RID: 28552 RVA: 0x001D052C File Offset: 0x001CE72C
	[NullableContext(0)]
	public ValueTuple<int, bool> GetIndexPos(int index)
	{
		return new ValueTuple<int, bool>(this.IsCurRow ? (index % this.Size) : (index / this.Size), this.IsCurRow);
	}

	// Token: 0x06006F89 RID: 28553 RVA: 0x001D0554 File Offset: 0x001CE754
	public int GetIndexDistance(int index)
	{
		int num = index / this.Size;
		int num2 = index % this.Size;
		return num + num2;
	}

	// Token: 0x06006F8A RID: 28554 RVA: 0x001D0574 File Offset: 0x001CE774
	public void SetCanInteractive(bool value)
	{
		this.CanInteract = value;
	}

	// Token: 0x06006F8B RID: 28555 RVA: 0x001D0580 File Offset: 0x001CE780
	public bool CheckCanInteractive()
	{
		bool flag = this.CanInteract && this.CurAnswerIndexList.Count < this.MaxLength;
		return (this.MaxTime <= 0.0 || this.CurTime < this.MaxTime) && flag;
	}

	// Token: 0x06006F8C RID: 28556 RVA: 0x001D05D0 File Offset: 0x001CE7D0
	public bool CheckMatrixBtnSelfInteractive(int index)
	{
		return (this.IsCurRow ? (index / this.Size) : (index % this.Size)) == this.CurGridGroup;
	}

	// Token: 0x06006F8D RID: 28557 RVA: 0x001D05F4 File Offset: 0x001CE7F4
	public bool CheckCodeBtnSelfInteractive(int index)
	{
		return index == this.CurAnswerIndexList.Count;
	}

	// Token: 0x06006F8E RID: 28558 RVA: 0x001D0604 File Offset: 0x001CE804
	[NullableContext(0)]
	public ValueTuple<double, double> AddCurrentTime(double delta)
	{
		double num = delta * Singleton<TimeUtil>.Instance.Millisecond;
		this.CurTime = Math.Min(this.MaxTime, this.CurTime + num);
		double num2 = this.MaxTime - this.CurTime;
		if (num2 <= 0.0)
		{
			this.OnOneTurnEnd(false);
		}
		return new ValueTuple<double, double>(num2, this.MaxTime);
	}

	// Token: 0x06006F8F RID: 28559 RVA: 0x001D0664 File Offset: 0x001CE864
	public int GetRealHoverIndex(int indexFake, bool needCache)
	{
		int num = this.IsCurRow ? (indexFake / this.Size) : (indexFake % this.Size);
		int num2 = (this.CurGridGroup - num) * (this.IsCurRow ? this.Size : 1);
		return indexFake + num2;
	}

	// Token: 0x06006F90 RID: 28560 RVA: 0x001D06AC File Offset: 0x001CE8AC
	public void OnHoveredMatrixGrid(int index)
	{
		if (this.HoverMatrixCallback == null)
		{
			return;
		}
		int realHoverIndex = this.GetRealHoverIndex(index, false);
		GolemHackingGridInfo golemHackingGridInfo = this.InfoList[realHoverIndex];
		int count = this.CurAnswerIndexList.Count;
		if (count >= this.GetMaxLength())
		{
			return;
		}
		this.HoverMatrixCallback(count, golemHackingGridInfo.IsUsed ? "" : golemHackingGridInfo.Code);
	}

	// Token: 0x06006F91 RID: 28561 RVA: 0x001D070F File Offset: 0x001CE90F
	public void OnUnHoveredMatrixGrid()
	{
		Action unHoverMatrixCallback = this.UnHoverMatrixCallback;
		if (unHoverMatrixCallback == null)
		{
			return;
		}
		unHoverMatrixCallback();
	}

	// Token: 0x06006F92 RID: 28562 RVA: 0x001D0721 File Offset: 0x001CE921
	public void OnHoveredCodeGrid(string value)
	{
		Action<string> hoverCodeCallback = this.HoverCodeCallback;
		if (hoverCodeCallback == null)
		{
			return;
		}
		hoverCodeCallback(value);
	}

	// Token: 0x06006F93 RID: 28563 RVA: 0x001D0734 File Offset: 0x001CE934
	public void OnUnHoveredCodeGrid()
	{
		Action unHoverCodeCallback = this.UnHoverCodeCallback;
		if (unHoverCodeCallback == null)
		{
			return;
		}
		unHoverCodeCallback();
	}

	// Token: 0x06006F94 RID: 28564 RVA: 0x001D0748 File Offset: 0x001CE948
	public void LogReport(EGolemHackingReportType reportType, bool isSuccess)
	{
		if (!ControllerBase<GolemHackingController>.Instance.IsActivityOpen)
		{
			return;
		}
		GolemHackingEndEvent golemHackingEndEvent = new GolemHackingEndEvent();
		golemHackingEndEvent.i_id = ControllerBase<GolemHackingController>.Instance.CacheLevelId;
		golemHackingEndEvent.i_result = (int)reportType;
		golemHackingEndEvent.s_trace_id = ControllerBase<GolemHackingController>.Instance.ActivityOpenTime.ToString();
		double num = Singleton<TimeUtil>.Instance.GetServerTime() - (double)ControllerBase<GolemHackingController>.Instance.ActivityOpenTime;
		golemHackingEndEvent.i_total_duration = (int)num;
		Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.GolemHackingActivityLevelTime, null) ?? new Dictionary<int, int>();
		if (isSuccess)
		{
			int num2;
			if (!dictionary.TryGetValue(golemHackingEndEvent.i_id, out num2) || num2 == 0 || num2 > (int)num)
			{
				golemHackingEndEvent.i_pass_time = (int)num;
				dictionary[golemHackingEndEvent.i_id] = (int)num;
				LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.GolemHackingActivityLevelTime, dictionary);
			}
			else
			{
				golemHackingEndEvent.i_pass_time = num2;
			}
		}
		else
		{
			int num3;
			golemHackingEndEvent.i_pass_time = (dictionary.TryGetValue(golemHackingEndEvent.i_id, out num3) ? num3 : 0);
		}
		bool flag = ControllerBase<GolemHackingController>.Instance.GetActivityData().GetLevelInfo(golemHackingEndEvent.i_id).State == GolemCrackState.GolemCrackFinished;
		golemHackingEndEvent.i_first_pass = ((!flag) ? 1 : 0);
		golemHackingEndEvent.i_recount = this.ResetCount;
		golemHackingEndEvent.i_false_count = this.FailCount;
		golemHackingEndEvent.i_count = this.CurAnswerIndexList.Count;
		golemHackingEndEvent.o_path = this.CurAnswerIndexList;
		ControllerBase<LogReportController>.Instance.LogReport(golemHackingEndEvent);
	}

	// Token: 0x0400357D RID: 13693
	protected int Size = 3;

	// Token: 0x0400357E RID: 13694
	protected int MaxLength;

	// Token: 0x0400357F RID: 13695
	protected int CurGridGroup;

	// Token: 0x04003580 RID: 13696
	protected bool IsCurRow = true;

	// Token: 0x04003581 RID: 13697
	protected List<GolemHackingGridInfo> InfoList = new List<GolemHackingGridInfo>();

	// Token: 0x04003582 RID: 13698
	protected List<List<string>> TargetCode = new List<List<string>>();

	// Token: 0x04003583 RID: 13699
	protected int TryTimeMax;

	// Token: 0x04003584 RID: 13700
	protected double CurTime;

	// Token: 0x04003585 RID: 13701
	protected double MaxTime;

	// Token: 0x04003586 RID: 13702
	protected bool CanInteract;

	// Token: 0x04003587 RID: 13703
	protected List<int> CurAnswerIndexList = new List<int>();

	// Token: 0x04003588 RID: 13704
	public List<int> OfficialAnswer = new List<int>();

	// Token: 0x04003589 RID: 13705
	public List<GolemHackingTipsGirdInfo> HelpTipsInfo = new List<GolemHackingTipsGirdInfo>();

	// Token: 0x0400358A RID: 13706
	protected int ConfigId;

	// Token: 0x0400358B RID: 13707
	protected bool HasBroadcastTryTime;

	// Token: 0x0400358C RID: 13708
	public bool IsRestart;

	// Token: 0x0400358D RID: 13709
	public int ResetCount;

	// Token: 0x0400358E RID: 13710
	public int FailCount;

	// Token: 0x0400358F RID: 13711
	protected bool CacheResult;

	// Token: 0x04003590 RID: 13712
	public bool IsCodePressing;

	// Token: 0x04003591 RID: 13713
	public bool IsMatrixPressing;

	// Token: 0x04003592 RID: 13714
	public double MatrixPressingTime;

	// Token: 0x04003593 RID: 13715
	[Nullable(2)]
	public Action ResetMatrixCallback;

	// Token: 0x04003594 RID: 13716
	[Nullable(2)]
	public Action StartMatrixTickCallback;

	// Token: 0x04003595 RID: 13717
	[Nullable(2)]
	public Action StopMatrixTickCallback;

	// Token: 0x04003596 RID: 13718
	[Nullable(2)]
	public Action ResetCodeCallback;

	// Token: 0x04003597 RID: 13719
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, string> HoverMatrixCallback;

	// Token: 0x04003598 RID: 13720
	[Nullable(2)]
	public Action UnHoverMatrixCallback;

	// Token: 0x04003599 RID: 13721
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})]
	public Action<List<string>, List<GolemHackingCodeEnterResult>> EnterCodeCallback;

	// Token: 0x0400359A RID: 13722
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<string> HoverCodeCallback;

	// Token: 0x0400359B RID: 13723
	[Nullable(2)]
	public Action UnHoverCodeCallback;

	// Token: 0x0400359C RID: 13724
	[Nullable(2)]
	public Action OnGameplaySuccessCallback;

	// Token: 0x0400359D RID: 13725
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Func<List<GolemHackingTipsGirdInfo>> OnGetHelpTips;
}
