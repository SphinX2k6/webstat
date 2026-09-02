using System;
using System.Runtime.CompilerServices;

// Token: 0x020025FE RID: 9726
public class OverPowerData : PowerData
{
	// Token: 0x0601310C RID: 78092 RVA: 0x00548F6C File Offset: 0x0054716C
	protected override bool GetIfCanRequestNewPower()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		PowerData powerDataById = ModelBase<PowerModel>.Instance.GetPowerDataById(5);
		return this.NextRecoverTime > 0.0 && serverTime >= this.NextRecoverTime && ControllerBase<PowerController>.Instance.GetIfCanRequestNewPower() && serverTime - this.CurrentRequestNewPowerTime > 1.0 && ModelBase<FunctionModel>.Instance.IsOpen(10066) && powerDataById.CheckPowerIfMax();
	}

	// Token: 0x0601310D RID: 78093 RVA: 0x00548FE2 File Offset: 0x005471E2
	public override EPowerRecoveryMode GetPowerRecoveryMode()
	{
		if (base.CheckPowerIfMax())
		{
			return EPowerRecoveryMode.Full;
		}
		if (!ModelBase<PowerModel>.Instance.GetPowerDataById(5).CheckPowerIfMax())
		{
			return EPowerRecoveryMode.Stop;
		}
		return EPowerRecoveryMode.Update;
	}

	// Token: 0x0601310E RID: 78094 RVA: 0x00549003 File Offset: 0x00547203
	[NullableContext(1)]
	public override string GetPowerCurrencyShowTextId()
	{
		return "PowerNumTips";
	}

	// Token: 0x0601310F RID: 78095 RVA: 0x0054900A File Offset: 0x0054720A
	public override int GetPowerLimit()
	{
		return ConfigBase<PowerConfig>.Instance.GetOverPowerLimit();
	}

	// Token: 0x06013110 RID: 78096 RVA: 0x00549016 File Offset: 0x00547216
	public override int GetPowerIncreaseTimeSpan()
	{
		return ConfigBase<PowerConfig>.Instance.GetOverPowerRecoverTimeSpan();
	}

	// Token: 0x06013111 RID: 78097 RVA: 0x00549022 File Offset: 0x00547222
	public override bool IfNeedShowMax()
	{
		return true;
	}
}
