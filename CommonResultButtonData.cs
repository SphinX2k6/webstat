using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A0D RID: 6669
[NullableContext(1)]
[Nullable(0)]
public class CommonResultButtonData
{
	// Token: 0x0600BF2B RID: 48939 RVA: 0x00329346 File Offset: 0x00327546
	public Action<int, CommonResultButton> GetButtonTimerCallBack()
	{
		return this.ButtonTimerCallBack;
	}

	// Token: 0x0600BF2C RID: 48940 RVA: 0x0032934E File Offset: 0x0032754E
	public Action GetButtonClickCallBack()
	{
		return this.ButtonClickCallBack;
	}

	// Token: 0x0600BF2D RID: 48941 RVA: 0x00329356 File Offset: 0x00327556
	public Action<CommonResultButton> GetButtonRefreshCallBack()
	{
		return this.ButtonRefreshCallBack;
	}

	// Token: 0x0600BF2E RID: 48942 RVA: 0x0032935E File Offset: 0x0032755E
	public void SetTimerCallBack(Action<int, CommonResultButton> call)
	{
		this.ButtonTimerCallBack = call;
	}

	// Token: 0x0600BF2F RID: 48943 RVA: 0x00329367 File Offset: 0x00327567
	public void SetClickCallBack(Action call)
	{
		this.ButtonClickCallBack = call;
	}

	// Token: 0x0600BF30 RID: 48944 RVA: 0x00329370 File Offset: 0x00327570
	public void SetRefreshCallBack(Action<CommonResultButton> call)
	{
		this.ButtonRefreshCallBack = call;
	}

	// Token: 0x040059D7 RID: 22999
	private Action<int, CommonResultButton> ButtonTimerCallBack = delegate(int hasRunTime, CommonResultButton button)
	{
	};

	// Token: 0x040059D8 RID: 23000
	private Action ButtonClickCallBack = delegate()
	{
	};

	// Token: 0x040059D9 RID: 23001
	private Action<CommonResultButton> ButtonRefreshCallBack = delegate(CommonResultButton button)
	{
	};
}
