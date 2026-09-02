using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;

// Token: 0x0200260F RID: 9743
[NullableContext(2)]
[Nullable(0)]
public class CommonQteContinuousClickContext : CommonQteContextBase
{
	// Token: 0x060131B4 RID: 78260 RVA: 0x0054BDA1 File Offset: 0x00549FA1
	public CommonQteContinuousClickContext()
	{
		this.Type = new ECommonQteContextType?(ECommonQteContextType.SingleButtonContinuousClick);
	}

	// Token: 0x060131B5 RID: 78261 RVA: 0x0054BDC0 File Offset: 0x00549FC0
	[NullableContext(1)]
	protected override void OnSetConfig(SCommonQte config)
	{
		SCommonQte_ContinuousClick continuousClickConfig = config.BaseConfig.ContinuousClickConfig;
		this.CurrentEnergyPercent = continuousClickConfig.InitialEnergyPercent;
		this.TargetEnergyPercentCurrent = this.CurrentEnergyPercent;
		this.TargetEnergyPercent = continuousClickConfig.TargetEnergyPercent;
		this.DeltaEnergyPercentPerMs = continuousClickConfig.DeltaEnergyPercentPerSecond * (float)Singleton<TimeUtil>.Instance.Millisecond;
		this.EnergyInterpSpeedPerMs = continuousClickConfig.InterpSpeedForEnergyPercent * (float)Singleton<TimeUtil>.Instance.Millisecond;
		this.DeltaEnergyPercentPerResponse = continuousClickConfig.DeltaEnergyPercentPerClick;
		this.MaxComboInterval = ((continuousClickConfig.MaxComboInterval < 0f) ? continuousClickConfig.MaxComboInterval : Math.Max(0f, continuousClickConfig.MaxComboInterval * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
		this.ProgressOnBegin = continuousClickConfig.ProgressOnBegin;
		this.IsComboTiming = false;
		this.CurrentComboInterval = 0f;
	}

	// Token: 0x060131B6 RID: 78262 RVA: 0x0054BE90 File Offset: 0x0054A090
	protected override void OnResponse()
	{
		if (this.Config == null)
		{
			return;
		}
		if (!base.IsPending() && !base.IsPendingSuccess())
		{
			return;
		}
		if (base.IsPending())
		{
			if (this.IsComboTiming)
			{
				this.CurrentComboInterval = 0f;
			}
			this.TargetEnergyPercentCurrent += this.DeltaEnergyPercentPerResponse;
			ControllerBase<CommonQteController>.Instance.PlayExtraEffect(this.HandleId);
			ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventResponse, this.UiActor);
			Singleton<AudioSystem>.Instance.SetRtpcValue("perform_qte_progress_default", this.GetProgress(), new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = this.UiActor
			}));
		}
		this.CheckQteConditionAndDoSuccess();
	}

	// Token: 0x060131B7 RID: 78263 RVA: 0x0054BF57 File Offset: 0x0054A157
	protected override void OnQtePendingSuccess()
	{
		ControllerBase<CommonQteController>.Instance.WaitQteEnd(this.HandleId);
	}

	// Token: 0x060131B8 RID: 78264 RVA: 0x0054BF6C File Offset: 0x0054A16C
	public override bool CheckQteConditionMatch()
	{
		bool flag = this.DeltaEnergyPercentPerResponse > 0f && this.CurrentEnergyPercent >= this.TargetEnergyPercent;
		bool flag2 = this.DeltaEnergyPercentPerResponse < 0f && this.CurrentEnergyPercent <= this.TargetEnergyPercent;
		return flag || flag2;
	}

	// Token: 0x060131B9 RID: 78265 RVA: 0x0054BFC0 File Offset: 0x0054A1C0
	protected override void OnUpdateTime(float delta)
	{
		if (this.Config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonQte;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "Context中获取不到Config";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QteId", this.QteId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<CommonQteController>.Instance.StopCurrentQte();
			return;
		}
		this.PassTime += delta;
		if (base.IsPending() && this.IsComboTiming && this.MaxComboInterval >= 0f)
		{
			this.CurrentComboInterval += delta;
			if (this.CurrentComboInterval > this.MaxComboInterval)
			{
				base.QteFail();
				return;
			}
		}
		float currentEnergyPercent = this.CurrentEnergyPercent;
		if (base.IsPending())
		{
			this.TargetEnergyPercentCurrent = Singleton<MathUtils>.Instance.Clamp(this.TargetEnergyPercentCurrent + this.DeltaEnergyPercentPerMs * delta, 0f, 100f);
		}
		if (this.EnergyInterpSpeedPerMs > 0f)
		{
			this.CurrentEnergyPercent = Singleton<MathUtils>.Instance.InterpConstantTo(this.CurrentEnergyPercent, this.TargetEnergyPercentCurrent, delta, this.EnergyInterpSpeedPerMs);
		}
		else
		{
			this.CurrentEnergyPercent = this.TargetEnergyPercentCurrent;
		}
		bool flag = currentEnergyPercent != this.CurrentEnergyPercent;
		if (this.CheckQteConditionAndDoSuccess())
		{
			return;
		}
		if (!this.IsPermanent && this.PassTime > this.Duration)
		{
			base.QteFail();
		}
		if (base.IsPending() && flag)
		{
			Singleton<AudioSystem>.Instance.SetRtpcValue("perform_qte_progress_default", this.GetProgress(), new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = this.UiActor
			}));
		}
	}

	// Token: 0x060131BA RID: 78266 RVA: 0x0054C14C File Offset: 0x0054A34C
	protected override string OnGetAction(int? index = null)
	{
		if (this.Config == null)
		{
			return null;
		}
		SCommonQteButton uiconfig = this.Config.BaseConfig.ContinuousClickConfig.UIConfig;
		return CommonQteContextBase.GetQteActionNameByActionId((uiconfig.ActionId > 0) ? uiconfig.ActionId : ((int)uiconfig.Action), new int?(this.QteId));
	}

	// Token: 0x060131BB RID: 78267 RVA: 0x0054C1AB File Offset: 0x0054A3AB
	[PreserveBaseOverrides]
	protected new virtual SCommonQte_ContinuousClick OnGetUiConfig()
	{
		if (this.Config == null)
		{
			return null;
		}
		return this.Config.BaseConfig.ContinuousClickConfig;
	}

	// Token: 0x060131BC RID: 78268 RVA: 0x0054C1CD File Offset: 0x0054A3CD
	public override bool IsAttachToActor()
	{
		SCommonQte config = this.Config;
		return config != null && config.BaseConfig.ContinuousClickConfig.IsAttachToActor;
	}

	// Token: 0x060131BD RID: 78269 RVA: 0x0054C1EC File Offset: 0x0054A3EC
	public override SCommonQte_Attach? GetAttachConfig()
	{
		SCommonQte config = this.Config;
		if (config == null)
		{
			return null;
		}
		return new SCommonQte_Attach?(config.BaseConfig.ContinuousClickConfig.AttachConfig);
	}

	// Token: 0x060131BE RID: 78270 RVA: 0x0054C221 File Offset: 0x0054A421
	public override float GetProgress()
	{
		if (this.TargetEnergyPercent > 0f)
		{
			return this.CurrentEnergyPercent / this.TargetEnergyPercent;
		}
		return 0f;
	}

	// Token: 0x060131BF RID: 78271 RVA: 0x0054C243 File Offset: 0x0054A443
	public void StartComboTiming()
	{
		this.IsComboTiming = true;
		this.CurrentComboInterval = 0f;
	}

	// Token: 0x04009519 RID: 38169
	public float CurrentEnergyPercent;

	// Token: 0x0400951A RID: 38170
	public float TargetEnergyPercent = -1f;

	// Token: 0x0400951B RID: 38171
	public float DeltaEnergyPercentPerResponse;

	// Token: 0x0400951C RID: 38172
	public float DeltaEnergyPercentPerMs;

	// Token: 0x0400951D RID: 38173
	public float EnergyInterpSpeedPerMs;

	// Token: 0x0400951E RID: 38174
	private float TargetEnergyPercentCurrent;

	// Token: 0x0400951F RID: 38175
	public float MaxComboInterval;

	// Token: 0x04009520 RID: 38176
	public bool ProgressOnBegin;

	// Token: 0x04009521 RID: 38177
	private bool IsComboTiming;

	// Token: 0x04009522 RID: 38178
	private float CurrentComboInterval;
}
