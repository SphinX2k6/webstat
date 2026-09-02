using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FAE RID: 8110
public class LockExecutionUnit : HudUnitBase
{
	// Token: 0x0600F3FE RID: 62462 RVA: 0x0042C048 File Offset: 0x0042A248
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F3FF RID: 62463 RVA: 0x0042C0D2 File Offset: 0x0042A2D2
	protected override void OnStart()
	{
		this.RootItem.SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
		base.InitTweenAnim(0);
		base.InitTweenAnim(1);
		base.InitTweenAnim(2);
	}

	// Token: 0x0600F400 RID: 62464 RVA: 0x0042C0F6 File Offset: 0x0042A2F6
	public void TryShow()
	{
		if (!base.IsShowOrShowing)
		{
			base.Show(null);
		}
	}

	// Token: 0x0600F401 RID: 62465 RVA: 0x0042C107 File Offset: 0x0042A307
	protected override void OnAfterShow()
	{
		base.StopTweenAnim(2);
		base.PlayTweenAnim(0);
		base.PlayTweenAnim(1);
	}

	// Token: 0x0600F402 RID: 62466 RVA: 0x0042C11E File Offset: 0x0042A31E
	public void TryHide(bool playCloseAnim)
	{
		this.PlayCloseAnim = playCloseAnim;
		if (!base.IsHideOrHiding)
		{
			base.Hide(null);
		}
	}

	// Token: 0x0600F403 RID: 62467 RVA: 0x0042C138 File Offset: 0x0042A338
	protected override UniTask OnBeforeHideAsync()
	{
		LockExecutionUnit.<OnBeforeHideAsync>d__10 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<LockExecutionUnit.<OnBeforeHideAsync>d__10>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F404 RID: 62468 RVA: 0x0042C17B File Offset: 0x0042A37B
	private void OnCloseAnimTimerEnd()
	{
		this.CloseTimer = null;
		this.Promise.SetResult();
		this.Promise = null;
	}

	// Token: 0x0600F405 RID: 62469 RVA: 0x0042C196 File Offset: 0x0042A396
	protected override void OnBeforeDestroy()
	{
		if (this.CloseTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseTimer);
			this.CloseTimer = null;
			this.Promise.SetResult();
		}
	}

	// Token: 0x04007562 RID: 30050
	private const int CLOSE_ANIM_TIME = 200;

	// Token: 0x04007563 RID: 30051
	[Nullable(2)]
	private TimerHandle CloseTimer;

	// Token: 0x04007564 RID: 30052
	private bool PlayCloseAnim;

	// Token: 0x04007565 RID: 30053
	[Nullable(2)]
	private CustomPromise Promise;

	// Token: 0x02008336 RID: 33590
	private enum EChildType
	{
		// Token: 0x0402C808 RID: 182280
		AnimStart,
		// Token: 0x0402C809 RID: 182281
		AnimLoop,
		// Token: 0x0402C80A RID: 182282
		AnimClose
	}
}
