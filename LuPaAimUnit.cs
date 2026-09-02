using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FB0 RID: 8112
public class LuPaAimUnit : HudUnitBase
{
	// Token: 0x0600F414 RID: 62484 RVA: 0x0042C370 File Offset: 0x0042A570
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F415 RID: 62485 RVA: 0x0042C45D File Offset: 0x0042A65D
	protected override void OnStart()
	{
		base.InitTweenAnim(3);
		base.InitTweenAnim(4);
		base.InitTweenAnim(5);
	}

	// Token: 0x0600F416 RID: 62486 RVA: 0x0042C474 File Offset: 0x0042A674
	protected override void OnBeforeShow()
	{
		base.StopTweenAnim(4);
		base.PlayTweenAnim(3);
	}

	// Token: 0x0600F417 RID: 62487 RVA: 0x0042C484 File Offset: 0x0042A684
	protected override UniTask OnBeforeHideAsync()
	{
		LuPaAimUnit.<OnBeforeHideAsync>d__10 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<LuPaAimUnit.<OnBeforeHideAsync>d__10>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F418 RID: 62488 RVA: 0x0042C4C7 File Offset: 0x0042A6C7
	private void OnCloseAnimTimerEnd()
	{
		this.CloseTimer = null;
		this.Promise.SetResult();
		this.Promise = null;
	}

	// Token: 0x0600F419 RID: 62489 RVA: 0x0042C4E2 File Offset: 0x0042A6E2
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

	// Token: 0x0600F41A RID: 62490 RVA: 0x0042C516 File Offset: 0x0042A716
	public void SetTargetVisible(bool visible)
	{
		this.TargetVisible = visible;
		base.SetVisible(visible, 0);
	}

	// Token: 0x0600F41B RID: 62491 RVA: 0x0042C527 File Offset: 0x0042A727
	public bool GetTargetVisible()
	{
		return this.TargetVisible;
	}

	// Token: 0x0600F41C RID: 62492 RVA: 0x0042C52F File Offset: 0x0042A72F
	public override void SetActive(bool visibility)
	{
		if (visibility && !this.TargetVisible)
		{
			return;
		}
		base.SetActive(visibility);
	}

	// Token: 0x0600F41D RID: 62493 RVA: 0x0042C544 File Offset: 0x0042A744
	public void SetProgress(float percent)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetFillAmount(percent);
	}

	// Token: 0x0600F41E RID: 62494 RVA: 0x0042C558 File Offset: 0x0042A758
	public void SetLockState(bool hasTarget)
	{
		if (this.LockState == hasTarget && this.IsInitLockState)
		{
			return;
		}
		this.LockState = hasTarget;
		base.GetItem(1).SetUIActive(!hasTarget);
		base.GetItem(2).SetUIActive(hasTarget);
		if (!this.IsInitLockState)
		{
			this.IsInitLockState = true;
		}
		if (base.IsShowOrShowing)
		{
			base.PlayTweenAnim(5);
		}
	}

	// Token: 0x04007569 RID: 30057
	private const int CLOSE_ANIM_TIME = 100;

	// Token: 0x0400756A RID: 30058
	private bool TargetVisible;

	// Token: 0x0400756B RID: 30059
	private bool IsInitLockState;

	// Token: 0x0400756C RID: 30060
	private bool LockState;

	// Token: 0x0400756D RID: 30061
	[Nullable(2)]
	private TimerHandle CloseTimer;

	// Token: 0x0400756E RID: 30062
	[Nullable(2)]
	private CustomPromise Promise;

	// Token: 0x0200833B RID: 33595
	private enum EChildType
	{
		// Token: 0x0402C81B RID: 182299
		ProgressSprite,
		// Token: 0x0402C81C RID: 182300
		StateItem1,
		// Token: 0x0402C81D RID: 182301
		StateItem2,
		// Token: 0x0402C81E RID: 182302
		AniStart,
		// Token: 0x0402C81F RID: 182303
		AniClose,
		// Token: 0x0402C820 RID: 182304
		AniSwitch
	}
}
