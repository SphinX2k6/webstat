using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FAF RID: 8111
public class LockPredictedUnit : HudUnitBase
{
	// Token: 0x0600F408 RID: 62472 RVA: 0x0042C1D4 File Offset: 0x0042A3D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F409 RID: 62473 RVA: 0x0042C27F File Offset: 0x0042A47F
	protected override void OnStart()
	{
		base.InitTweenAnim(2);
		base.InitTweenAnim(3);
	}

	// Token: 0x0600F40A RID: 62474 RVA: 0x0042C28F File Offset: 0x0042A48F
	protected override void OnAfterShow()
	{
		this.PlayStartAnim();
	}

	// Token: 0x0600F40B RID: 62475 RVA: 0x0042C298 File Offset: 0x0042A498
	protected override UniTask OnBeforeHideAsync()
	{
		LockPredictedUnit.<OnBeforeHideAsync>d__8 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<LockPredictedUnit.<OnBeforeHideAsync>d__8>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F40C RID: 62476 RVA: 0x0042C2DB File Offset: 0x0042A4DB
	private void OnCloseAnimTimerEnd()
	{
		this.CloseTimer = null;
		this.Promise.SetResult();
		this.Promise = null;
	}

	// Token: 0x0600F40D RID: 62477 RVA: 0x0042C2F6 File Offset: 0x0042A4F6
	protected override void OnBeforeDestroy()
	{
		if (this.CloseTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseTimer);
			this.CloseTimer = null;
			this.Promise.SetResult();
			this.Promise = null;
		}
	}

	// Token: 0x0600F40E RID: 62478 RVA: 0x0042C32A File Offset: 0x0042A52A
	public void Activate()
	{
		base.SetVisible(true, 0);
	}

	// Token: 0x0600F40F RID: 62479 RVA: 0x0042C334 File Offset: 0x0042A534
	public void Deactivate()
	{
		base.SetVisible(false, 0);
	}

	// Token: 0x0600F410 RID: 62480 RVA: 0x0042C33E File Offset: 0x0042A53E
	private void PlayStartAnim()
	{
		base.StopTweenAnim(3);
		base.PlayTweenAnim(2);
	}

	// Token: 0x0600F411 RID: 62481 RVA: 0x0042C34E File Offset: 0x0042A54E
	private void PlayCloseAnim()
	{
		base.StopTweenAnim(2);
		base.PlayTweenAnim(3);
	}

	// Token: 0x04007566 RID: 30054
	private const int CLOSE_ANIM_TIME = 200;

	// Token: 0x04007567 RID: 30055
	[Nullable(2)]
	private TimerHandle CloseTimer;

	// Token: 0x04007568 RID: 30056
	[Nullable(2)]
	private CustomPromise Promise;

	// Token: 0x02008338 RID: 33592
	private enum EChildType
	{
		// Token: 0x0402C810 RID: 182288
		Arrow,
		// Token: 0x0402C811 RID: 182289
		CenterPoint,
		// Token: 0x0402C812 RID: 182290
		AnimStart,
		// Token: 0x0402C813 RID: 182291
		AnimClose
	}

	// Token: 0x02008339 RID: 33593
	private enum EVisibleReason
	{
		// Token: 0x0402C815 RID: 182293
		Default
	}
}
