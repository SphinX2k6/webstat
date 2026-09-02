using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FAA RID: 8106
[NullableContext(2)]
[Nullable(0)]
public class FollowShootAutoAimUnit : HudUnitBase
{
	// Token: 0x0600F3C5 RID: 62405 RVA: 0x0042B18C File Offset: 0x0042938C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F3C6 RID: 62406 RVA: 0x0042B29A File Offset: 0x0042949A
	protected override void OnStart()
	{
		this.TargetItem = base.GetItem(0);
		this.RingAimItem = base.GetItem(6);
		this.IsTargetItemActive = false;
		this.TargetItem.SetUIActive(false);
		this.InitAllTweenAnim();
		this.IsActive = true;
	}

	// Token: 0x0600F3C7 RID: 62407 RVA: 0x0042B2D6 File Offset: 0x004294D6
	protected override void OnAfterShow()
	{
		base.StopTweenAnim(2);
		base.PlayTweenAnim(1);
	}

	// Token: 0x0600F3C8 RID: 62408 RVA: 0x0042B2E8 File Offset: 0x004294E8
	protected override UniTask OnBeforeHideAsync()
	{
		FollowShootAutoAimUnit.<OnBeforeHideAsync>d__11 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<FollowShootAutoAimUnit.<OnBeforeHideAsync>d__11>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F3C9 RID: 62409 RVA: 0x0042B32B File Offset: 0x0042952B
	protected override void OnBeforeDestroy()
	{
		this.TargetItem = null;
		this.DestroyCloseAnimTimer();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F3CA RID: 62410 RVA: 0x0042B340 File Offset: 0x00429540
	public void SetTargetItemOffset(float x, float y)
	{
		if (this.TargetItem == null)
		{
			return;
		}
		this.TargetItem.SetAnchorOffsetX(x);
		this.TargetItem.SetAnchorOffsetY(y);
	}

	// Token: 0x0600F3CB RID: 62411 RVA: 0x0042B364 File Offset: 0x00429564
	public void SetTargetAimVisible(bool isVisible, bool isTargetChanged)
	{
		if (this.TargetItem == null)
		{
			return;
		}
		if (this.IsTargetItemActive == isVisible)
		{
			return;
		}
		this.IsTargetItemActive = isVisible;
		this.TargetItem.SetUIActive(isVisible);
		if (isVisible)
		{
			this.TargetItem.SetUIActive(true);
			this.PlayStartAimAnim();
			this.PlayLoopAimAnim();
			return;
		}
		this.StopLoopAimAnim();
		this.PlayCloseAimAnim();
	}

	// Token: 0x0600F3CC RID: 62412 RVA: 0x0042B3BF File Offset: 0x004295BF
	public void SetRingAimVisible(bool isVisible)
	{
		if (this.RingAimItem == null)
		{
			return;
		}
		this.RingAimItem.SetUIActive(isVisible);
	}

	// Token: 0x0600F3CD RID: 62413 RVA: 0x0042B3D6 File Offset: 0x004295D6
	private void DestroyCloseAnimTimer()
	{
		if (this.CloseAnimTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseAnimTimer);
			this.CloseAnimTimer = null;
		}
		if (this.CloseAnimPromise != null)
		{
			this.CloseAnimPromise.SetResult();
			this.CloseAnimPromise = null;
		}
	}

	// Token: 0x0600F3CE RID: 62414 RVA: 0x0042B412 File Offset: 0x00429612
	private void InitAllTweenAnim()
	{
		base.InitTweenAnim(1);
		base.InitTweenAnim(2);
		base.InitTweenAnim(3);
		base.InitTweenAnim(4);
		base.InitTweenAnim(5);
	}

	// Token: 0x0600F3CF RID: 62415 RVA: 0x0042B437 File Offset: 0x00429637
	public void PlayStartAimAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.PlayTweenAnim(3);
	}

	// Token: 0x0600F3D0 RID: 62416 RVA: 0x0042B449 File Offset: 0x00429649
	public void PlayCloseAimAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.PlayTweenAnim(4);
	}

	// Token: 0x0600F3D1 RID: 62417 RVA: 0x0042B45B File Offset: 0x0042965B
	public void PlayLoopAimAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.PlayTweenAnim(5);
	}

	// Token: 0x0600F3D2 RID: 62418 RVA: 0x0042B46D File Offset: 0x0042966D
	public void StopLoopAimAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.StopTweenAnim(5);
	}

	// Token: 0x04007548 RID: 30024
	private const int CLOSE_ANIM_TIME = 200;

	// Token: 0x04007549 RID: 30025
	private UUIItem TargetItem;

	// Token: 0x0400754A RID: 30026
	private TimerHandle CloseAnimTimer;

	// Token: 0x0400754B RID: 30027
	private CustomPromise CloseAnimPromise;

	// Token: 0x0400754C RID: 30028
	private bool IsActive;

	// Token: 0x0400754D RID: 30029
	private bool IsTargetItemActive;

	// Token: 0x0400754E RID: 30030
	private UUIItem RingAimItem;

	// Token: 0x0200832C RID: 33580
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C7D9 RID: 182233
		TargetItem,
		// Token: 0x0402C7DA RID: 182234
		AnimStart,
		// Token: 0x0402C7DB RID: 182235
		AnimClose,
		// Token: 0x0402C7DC RID: 182236
		AnimStartAim,
		// Token: 0x0402C7DD RID: 182237
		AnimCloseAim,
		// Token: 0x0402C7DE RID: 182238
		AnimLoopAim,
		// Token: 0x0402C7DF RID: 182239
		RingAim
	}
}
