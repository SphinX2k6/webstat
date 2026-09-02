using System;
using System.Runtime.CompilerServices;

// Token: 0x020013DC RID: 5084
public class BusinessTipsCurrencyItem : CommonCurrencyItem
{
	// Token: 0x06008C8B RID: 35979 RVA: 0x0024F1F4 File Offset: 0x0024D3F4
	public override void AddEventListener()
	{
	}

	// Token: 0x06008C8C RID: 35980 RVA: 0x0024F1F6 File Offset: 0x0024D3F6
	public override void RemoveEventListener()
	{
	}

	// Token: 0x06008C8D RID: 35981 RVA: 0x0024F1F8 File Offset: 0x0024D3F8
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.RemoveTimer();
	}

	// Token: 0x06008C8E RID: 35982 RVA: 0x0024F208 File Offset: 0x0024D408
	public void PlayReduceTweener(int curValue, int targetValue)
	{
		if (this.RefreshTimer != null)
		{
			this.RemoveTimer();
		}
		float curTime = 0f;
		int lastValue = curValue;
		float tweenTime = 1000f;
		this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
		{
			curTime = Math.Min(curTime + delta, tweenTime);
			int lastValue;
			lastValue += (int)Math.Floor((double)((float)(targetValue - lastValue) * (delta / tweenTime)) * Random.Shared.NextDouble());
			lastValue = lastValue;
			this.RefreshCountText(lastValue.ToString());
			if (curTime >= tweenTime)
			{
				this.RefreshCountText(targetValue.ToString());
				this.RemoveTimer();
			}
		}, 20f, 1f, null, null, true);
	}

	// Token: 0x06008C8F RID: 35983 RVA: 0x0024F27D File Offset: 0x0024D47D
	private void RemoveTimer()
	{
		if (this.RefreshTimer == null)
		{
			return;
		}
		if (TimerSystem.GameplayTimeInstance.Has(this.RefreshTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}
	}

	// Token: 0x0400417D RID: 16765
	[Nullable(2)]
	private TimerHandle RefreshTimer;
}
