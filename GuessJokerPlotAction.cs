using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

// Token: 0x020010DF RID: 4319
public class GuessJokerPlotAction : GuessJokerActionBase
{
	// Token: 0x0600708E RID: 28814 RVA: 0x001D643C File Offset: 0x001D463C
	public unsafe GuessJokerPlotAction(EGuessJokerPlayerType playerType, EGuessJokerPlotTiming timing, int? extraParam = null)
	{
		this.TimingInternal = timing;
		this.PlayerTypeInternal = playerType;
		GuessJokerPlotConfig? plotConfig = GuessJokerUtils.GetPlotConfig(playerType, timing, extraParam);
		if (plotConfig == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJokerPlotAction Fail：PlotConfig is undefined";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("playerType", playerType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("timing", timing);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("extraParam", extraParam);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.Done = true;
			return;
		}
		GuessJokerAIPlotConfig? jokerAiPlotConfig = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiPlotConfig(playerType, timing, extraParam.GetValueOrDefault());
		if (jokerAiPlotConfig == null)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.GuessJokerCard;
			ELogAuthor author2 = ELogAuthor.LRC;
			string message2 = "GuessJokerPlotAction Fail：AiPlotConfig is undefined";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("playerType", playerType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("timing", timing);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.Done = true;
			return;
		}
		ITalkItemDialog talkItemDialog = null;
		List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(plotConfig.Value.FlowListName, plotConfig.Value.FlowId, plotConfig.Value.StateId);
		if (flowStateActions != null)
		{
			ActionInfo actionInfo = null;
			for (int i = 0; i < flowStateActions.Count; i++)
			{
				if (flowStateActions[i].Name == EAction.ShowTalk)
				{
					actionInfo = flowStateActions[i];
					break;
				}
			}
			if (actionInfo != null)
			{
				ITalkItem talkItem = ((ShowTalk)actionInfo.Params).TalkItems[0];
				ETalkItemType? type = talkItem.Type;
				ETalkItemType etalkItemType = ETalkItemType.Talk;
				if (type.GetValueOrDefault() == etalkItemType & type != null)
				{
					talkItemDialog = (ITalkItemDialog)talkItem;
				}
			}
		}
		if (talkItemDialog == null)
		{
			this.Done = true;
			return;
		}
		this.TalkData = talkItemDialog;
		this.PlotConfig = plotConfig;
		this.AiPlotConfig = jokerAiPlotConfig;
	}

	// Token: 0x0600708F RID: 28815 RVA: 0x001D6660 File Offset: 0x001D4860
	protected override void OnStart()
	{
		if (this.TalkData == null)
		{
			this.Done = true;
			return;
		}
		if (this.DelayTime > 0f)
		{
			this.IsDelayed = true;
			this.DelayElapsed = 0f;
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.SetLastUsedPlotId(this.AiPlotId, this.PlotId);
		this.StartActualPlayback();
	}

	// Token: 0x06007090 RID: 28816 RVA: 0x001D66BC File Offset: 0x001D48BC
	protected override void OnTick(float delta)
	{
		if (this.IsDelayed)
		{
			this.DelayElapsed += delta;
			if (this.DelayElapsed >= this.DelayTime)
			{
				this.IsDelayed = false;
				this.DelayElapsed = 0f;
				ModelBase<GuessJokerGamePlayModel>.Instance.SetLastUsedPlotId(this.AiPlotId, this.PlotId);
				this.StartActualPlayback();
			}
		}
	}

	// Token: 0x06007091 RID: 28817 RVA: 0x001D671C File Offset: 0x001D491C
	private void StartActualPlayback()
	{
		if (this.TalkData == null)
		{
			this.Done = true;
			return;
		}
		GuessJokerDialogLogic activeDialogLogic = ModelBase<GuessJokerGamePlayModel>.Instance.GetActiveDialogLogic();
		if (activeDialogLogic != null)
		{
			activeDialogLogic.PlayDialog(this.TalkData, delegate
			{
				this.Done = true;
			});
			return;
		}
		Singleton<global::Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJokerPlotAction：未找到活跃的对话逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.Done = true;
	}

	// Token: 0x1700090D RID: 2317
	// (get) Token: 0x06007092 RID: 28818 RVA: 0x001D6786 File Offset: 0x001D4986
	public EGuessJokerPlotTiming Timing
	{
		get
		{
			return this.TimingInternal;
		}
	}

	// Token: 0x1700090E RID: 2318
	// (get) Token: 0x06007093 RID: 28819 RVA: 0x001D678E File Offset: 0x001D498E
	public EGuessJokerPlayerType PlayerType
	{
		get
		{
			return this.PlayerTypeInternal;
		}
	}

	// Token: 0x1700090F RID: 2319
	// (get) Token: 0x06007094 RID: 28820 RVA: 0x001D6798 File Offset: 0x001D4998
	public int AiPlotId
	{
		get
		{
			if (this.AiPlotConfig == null)
			{
				return 0;
			}
			return this.AiPlotConfig.GetValueOrDefault().Id;
		}
	}

	// Token: 0x17000910 RID: 2320
	// (get) Token: 0x06007095 RID: 28821 RVA: 0x001D67C4 File Offset: 0x001D49C4
	public int PlotId
	{
		get
		{
			if (this.PlotConfig == null)
			{
				return 0;
			}
			return this.PlotConfig.GetValueOrDefault().Id;
		}
	}

	// Token: 0x17000911 RID: 2321
	// (get) Token: 0x06007096 RID: 28822 RVA: 0x001D67F0 File Offset: 0x001D49F0
	public float DelayTime
	{
		get
		{
			return (float)((this.AiPlotConfig != null) ? this.AiPlotConfig.GetValueOrDefault().DelayTime : 0);
		}
	}

	// Token: 0x17000912 RID: 2322
	// (get) Token: 0x06007097 RID: 28823 RVA: 0x001D6820 File Offset: 0x001D4A20
	public bool CanHardCut
	{
		get
		{
			return this.AiPlotConfig != null && this.AiPlotConfig.GetValueOrDefault().CanHardCut;
		}
	}

	// Token: 0x17000913 RID: 2323
	// (get) Token: 0x06007098 RID: 28824 RVA: 0x001D684C File Offset: 0x001D4A4C
	public float WaitDeleteTime
	{
		get
		{
			return (float)((this.AiPlotConfig != null) ? this.AiPlotConfig.GetValueOrDefault().WaitDeleteTime : 0);
		}
	}

	// Token: 0x17000914 RID: 2324
	// (get) Token: 0x06007099 RID: 28825 RVA: 0x001D687C File Offset: 0x001D4A7C
	public float Cd
	{
		get
		{
			return (float)((this.AiPlotConfig != null) ? this.AiPlotConfig.GetValueOrDefault().Cd : 0);
		}
	}

	// Token: 0x17000915 RID: 2325
	// (get) Token: 0x0600709A RID: 28826 RVA: 0x001D68A9 File Offset: 0x001D4AA9
	public bool IsInDelay
	{
		get
		{
			return this.IsDelayed;
		}
	}

	// Token: 0x0600709B RID: 28827 RVA: 0x001D68B4 File Offset: 0x001D4AB4
	protected override void OnFinish()
	{
		GuessJokerDialogLogic activeDialogLogic = ModelBase<GuessJokerGamePlayModel>.Instance.GetActiveDialogLogic();
		if (activeDialogLogic != null)
		{
			activeDialogLogic.Clear();
		}
		this.IsDelayed = false;
		this.DelayElapsed = 0f;
		this.PlotConfig = null;
		this.TalkData = null;
		this.AiPlotConfig = null;
	}

	// Token: 0x04003624 RID: 13860
	[Nullable(2)]
	private ITalkItemDialog TalkData;

	// Token: 0x04003625 RID: 13861
	private GuessJokerPlotConfig? PlotConfig;

	// Token: 0x04003626 RID: 13862
	private GuessJokerAIPlotConfig? AiPlotConfig;

	// Token: 0x04003627 RID: 13863
	private readonly EGuessJokerPlotTiming TimingInternal;

	// Token: 0x04003628 RID: 13864
	private readonly EGuessJokerPlayerType PlayerTypeInternal;

	// Token: 0x04003629 RID: 13865
	private bool IsDelayed;

	// Token: 0x0400362A RID: 13866
	private float DelayElapsed;
}
