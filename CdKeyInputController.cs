using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200182C RID: 6188
[Nullable(new byte[]
{
	0,
	1
})]
public class CdKeyInputController : UiControllerBase<CdKeyInputController>
{
	// Token: 0x0600B0AC RID: 45228 RVA: 0x002F2BFC File Offset: 0x002F0DFC
	private void StartCdKeyUseCoolDown()
	{
		this.CdKeyCdFlag = true;
		this.CdKeyCdCountTime = 0f;
		this.CdKeyCdTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnCdKeyUseCdRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
	}

	// Token: 0x0600B0AD RID: 45229 RVA: 0x002F2C4A File Offset: 0x002F0E4A
	private void OnCdKeyUseCdRefresh(float delta)
	{
		this.CdKeyCdCountTime += delta;
		if (this.CdKeyCdCountTime >= 5000f)
		{
			this.ResetCdKeyUseTimer();
		}
	}

	// Token: 0x0600B0AE RID: 45230 RVA: 0x002F2C6D File Offset: 0x002F0E6D
	private void ResetCdKeyUseTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.CdKeyCdTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CdKeyCdTimerId);
		}
		this.CdKeyCdFlag = false;
		this.CdKeyCdCountTime = 0f;
		this.CdKeyCdTimerId = null;
	}

	// Token: 0x0600B0AF RID: 45231 RVA: 0x002F2CAB File Offset: 0x002F0EAB
	protected override bool OnClear()
	{
		this.ResetCdKeyUseTimer();
		return true;
	}

	// Token: 0x0600B0B0 RID: 45232 RVA: 0x002F2CB4 File Offset: 0x002F0EB4
	public bool CheckInCdKeyUseCd()
	{
		return this.CdKeyCdFlag;
	}

	// Token: 0x0600B0B1 RID: 45233 RVA: 0x002F2CBC File Offset: 0x002F0EBC
	public static int GetCdKeyUseCd()
	{
		double val = Math.Ceiling((double)((5000f - ControllerBase<CdKeyInputController>.Instance.CdKeyCdCountTime) / (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
		return (int)Math.Max(1.0, val);
	}

	// Token: 0x0600B0B2 RID: 45234 RVA: 0x002F2D00 File Offset: 0x002F0F00
	public UniTask<ErrorCode?> RequestCdKey([Nullable(1)] string cdKeyString)
	{
		CdKeyInputController.<RequestCdKey>d__10 <RequestCdKey>d__;
		<RequestCdKey>d__.<>t__builder = AsyncUniTaskMethodBuilder<ErrorCode?>.Create();
		<RequestCdKey>d__.<>4__this = this;
		<RequestCdKey>d__.cdKeyString = cdKeyString;
		<RequestCdKey>d__.<>1__state = -1;
		<RequestCdKey>d__.<>t__builder.Start<CdKeyInputController.<RequestCdKey>d__10>(ref <RequestCdKey>d__);
		return <RequestCdKey>d__.<>t__builder.Task;
	}

	// Token: 0x040053A8 RID: 21416
	private const int CDKEY_USE_INTERVAL = 5000;

	// Token: 0x040053A9 RID: 21417
	[Nullable(2)]
	private TimerHandle CdKeyCdTimerId;

	// Token: 0x040053AA RID: 21418
	private bool CdKeyCdFlag;

	// Token: 0x040053AB RID: 21419
	private float CdKeyCdCountTime;
}
