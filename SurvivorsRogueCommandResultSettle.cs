using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02002AED RID: 10989
public class SurvivorsRogueCommandResultSettle : SurvivorsRogueCommandBase
{
	// Token: 0x06015F9C RID: 90012 RVA: 0x00619B1D File Offset: 0x00617D1D
	public SurvivorsRogueCommandResultSettle(ESurvivorsRogueCommandType type) : base(type)
	{
	}

	// Token: 0x06015F9D RID: 90013 RVA: 0x00619B28 File Offset: 0x00617D28
	[NullableContext(1)]
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[Settle] Reason: ");
		ResultView viewInfo = this.GetViewInfo();
		defaultInterpolatedStringHandler.AppendFormatted<int?>((viewInfo != null) ? new int?(viewInfo.Reason) : null);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015F9E RID: 90014 RVA: 0x00619B78 File Offset: 0x00617D78
	protected override void OnUpdate()
	{
	}

	// Token: 0x06015F9F RID: 90015 RVA: 0x00619B7A File Offset: 0x00617D7A
	protected override void Back2Fore()
	{
	}

	// Token: 0x06015FA0 RID: 90016 RVA: 0x00619B7C File Offset: 0x00617D7C
	protected override void Fore2Back()
	{
	}

	// Token: 0x06015FA1 RID: 90017 RVA: 0x00619B80 File Offset: 0x00617D80
	protected override void OnStartExecute()
	{
		ResultView viewInfo = this.GetViewInfo();
		if (viewInfo != null && viewInfo.Reason == 1)
		{
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("SurvivorsDeathDelaySettleTime").GetValueOrDefault(3000);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("SurvivorsRogueSettleView.DelayOpen", true);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				base.OpenView(EUiViewName.SurvivorsRogueSettleView, false);
				Singleton<UiLayer>.Instance.SetShowMaskLayer("SurvivorsRogueSettleView.DelayOpen", false);
			}, (float)valueOrDefault, null, null, true, 1f);
			return;
		}
		base.OpenView(EUiViewName.SurvivorsRogueSettleView, false);
	}

	// Token: 0x06015FA2 RID: 90018 RVA: 0x00619BFA File Offset: 0x00617DFA
	protected override void OnExecute()
	{
	}

	// Token: 0x06015FA3 RID: 90019 RVA: 0x00619BFC File Offset: 0x00617DFC
	protected override void OnFinish()
	{
	}

	// Token: 0x06015FA4 RID: 90020 RVA: 0x00619BFE File Offset: 0x00617DFE
	protected override void OnDelete()
	{
	}

	// Token: 0x06015FA5 RID: 90021 RVA: 0x00619C00 File Offset: 0x00617E00
	[NullableContext(2)]
	public ResultView GetViewInfo()
	{
		return this.Data.ResultView;
	}

	// Token: 0x0400A8D5 RID: 43221
	private const int TIME_DEATH_DELAY = 3000;

	// Token: 0x02008E4D RID: 36429
	private static class EResultSettleReason
	{
		// Token: 0x0402FDCE RID: 196046
		public const int EarlyExit = 0;

		// Token: 0x0402FDCF RID: 196047
		public const int PlayerDeath = 1;

		// Token: 0x0402FDD0 RID: 196048
		public const int SuccessPass = 2;

		// Token: 0x0402FDD1 RID: 196049
		public const int OutSettle = 3;
	}
}
