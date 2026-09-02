using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020025FD RID: 9725
[NullableContext(1)]
[Nullable(0)]
public class PowerData
{
	// Token: 0x060130FA RID: 78074 RVA: 0x00548C5C File Offset: 0x00546E5C
	public void Phrase(int itemId, int power, double lastUpdateTime)
	{
		this.ItemId = itemId;
		this.ChangePower(power);
		int num = (this.GetPowerLimit() - power) * this.GetPowerIncreaseTimeSpan();
		this.FinishUpdateTime = lastUpdateTime + (double)num;
		this.NextRecoverTime = lastUpdateTime + (double)this.GetPowerIncreaseTimeSpan();
	}

	// Token: 0x060130FB RID: 78075 RVA: 0x00548CA2 File Offset: 0x00546EA2
	public void CheckPowerUpdate()
	{
		if (this.NeedUpdateFlag && this.GetIfCanRequestNewPower())
		{
			this.OnCheckPowerUpdate();
		}
	}

	// Token: 0x060130FC RID: 78076 RVA: 0x00548CBC File Offset: 0x00546EBC
	protected virtual bool GetIfCanRequestNewPower()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return this.NextRecoverTime > 0.0 && serverTime >= this.NextRecoverTime && ControllerBase<PowerController>.Instance.GetIfCanRequestNewPower() && serverTime - this.CurrentRequestNewPowerTime > 1.0;
	}

	// Token: 0x060130FD RID: 78077 RVA: 0x00548D0F File Offset: 0x00546F0F
	protected void RequestNewPowerDataAndCacheRequestTime()
	{
		ControllerBase<PowerController>.Instance.SendUpdatePowerRequest(new int[]
		{
			this.ItemId
		});
		this.CurrentRequestNewPowerTime = Singleton<TimeUtil>.Instance.GetServerTime();
	}

	// Token: 0x060130FE RID: 78078 RVA: 0x00548D3A File Offset: 0x00546F3A
	protected void OnCheckPowerUpdate()
	{
		this.RequestNewPowerDataAndCacheRequestTime();
	}

	// Token: 0x060130FF RID: 78079 RVA: 0x00548D42 File Offset: 0x00546F42
	public virtual EPowerRecoveryMode GetPowerRecoveryMode()
	{
		if (!this.NeedUpdateFlag)
		{
			return EPowerRecoveryMode.Full;
		}
		return EPowerRecoveryMode.Update;
	}

	// Token: 0x06013100 RID: 78080 RVA: 0x00548D4F File Offset: 0x00546F4F
	private void ChangePower(int power)
	{
		this.CurrentPower = power;
		this.NeedUpdateFlag = !this.CheckPowerIfMax();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPowerChanged);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPowerChangedWithId, this.ItemId);
	}

	// Token: 0x06013101 RID: 78081 RVA: 0x00548D8D File Offset: 0x00546F8D
	public int GetCurrentPower()
	{
		return this.CurrentPower;
	}

	// Token: 0x06013102 RID: 78082 RVA: 0x00548D95 File Offset: 0x00546F95
	public bool CheckPowerIfMax()
	{
		return this.CurrentPower >= this.GetPowerLimit();
	}

	// Token: 0x06013103 RID: 78083 RVA: 0x00548DA8 File Offset: 0x00546FA8
	public double GetResetTime()
	{
		return this.ResetTime;
	}

	// Token: 0x06013104 RID: 78084 RVA: 0x00548DB0 File Offset: 0x00546FB0
	public bool GetNeedUpdateFlag()
	{
		return this.NeedUpdateFlag;
	}

	// Token: 0x06013105 RID: 78085 RVA: 0x00548DB8 File Offset: 0x00546FB8
	public virtual string GetPowerCurrencyShowTextId()
	{
		return "Text_ItemShow_Text";
	}

	// Token: 0x06013106 RID: 78086 RVA: 0x00548DBF File Offset: 0x00546FBF
	public virtual bool IfNeedShowMax()
	{
		return false;
	}

	// Token: 0x06013107 RID: 78087 RVA: 0x00548DC2 File Offset: 0x00546FC2
	public virtual int GetPowerLimit()
	{
		return ConfigBase<PowerConfig>.Instance.GetPowerNaturalLimit();
	}

	// Token: 0x06013108 RID: 78088 RVA: 0x00548DCE File Offset: 0x00546FCE
	public virtual int GetPowerIncreaseTimeSpan()
	{
		return ConfigBase<PowerConfig>.Instance.GetPowerIncreaseSpan();
	}

	// Token: 0x06013109 RID: 78089 RVA: 0x00548DDC File Offset: 0x00546FDC
	public string GetNextTimerRecoverText()
	{
		double num = this.NextRecoverTime - Singleton<TimeUtil>.Instance.GetServerTime();
		num = ((num < 0.0) ? 0.0 : num);
		double num2 = num / Singleton<TimeUtil>.Instance.Minute;
		double num3 = num % Singleton<TimeUtil>.Instance.Minute;
		int num4 = (int)Math.Truncate(num2);
		num3 = Math.Truncate(num3);
		return num4.ToString().PadLeft(2, '0') + ":" + ((int)num3).ToString().PadLeft(2, '0');
	}

	// Token: 0x0601310A RID: 78090 RVA: 0x00548E68 File Offset: 0x00547068
	public string GetFullRecoverText()
	{
		double num = this.FinishUpdateTime - Singleton<TimeUtil>.Instance.GetServerTime();
		num = ((num < 0.0) ? 0.0 : num);
		double num2 = num / Singleton<TimeUtil>.Instance.Hour;
		double num3 = num % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute;
		double num4 = num % Singleton<TimeUtil>.Instance.Minute;
		num2 = Math.Truncate(num2);
		num3 = Math.Truncate(num3);
		num4 = Math.Truncate(num4);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
		defaultInterpolatedStringHandler.AppendFormatted(((int)num2).ToString().PadLeft(2, '0'));
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(((int)num3).ToString().PadLeft(2, '0'));
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(((int)num4).ToString().PadLeft(2, '0'));
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x040094B8 RID: 38072
	protected int ItemId;

	// Token: 0x040094B9 RID: 38073
	protected int CurrentPower;

	// Token: 0x040094BA RID: 38074
	protected double FinishUpdateTime;

	// Token: 0x040094BB RID: 38075
	protected bool NeedUpdateFlag;

	// Token: 0x040094BC RID: 38076
	protected int CurrentRecoverMode;

	// Token: 0x040094BD RID: 38077
	protected double NextRecoverTime;

	// Token: 0x040094BE RID: 38078
	protected double ResetTime;

	// Token: 0x040094BF RID: 38079
	protected double CurrentRequestNewPowerTime;

	// Token: 0x040094C0 RID: 38080
	protected int LastTickCountDown = -1;
}
