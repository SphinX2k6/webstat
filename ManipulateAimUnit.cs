using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001FB1 RID: 8113
[NullableContext(2)]
[Nullable(0)]
public class ManipulateAimUnit : HudUnitBase
{
	// Token: 0x0600F421 RID: 62497 RVA: 0x0042C5CC File Offset: 0x0042A7CC
	protected unsafe override void OnRegisterComponent()
	{
		if (this.ResourceId == "UiView_Sight")
		{
			this.ExistAnim = true;
		}
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		if (this.ExistAnim)
		{
			num2 = 7;
			List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
			num = 0;
			*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list2;
		}
	}

	// Token: 0x0600F422 RID: 62498 RVA: 0x0042C75A File Offset: 0x0042A95A
	protected override void OnStart()
	{
		this.TargetItem = base.GetItem(0);
		this.WeaknessItem = base.GetItem(1);
		this.IsTargetItemActive = false;
		this.TargetItem.SetUIActive(false);
		this.InitAllTweenAnim();
		this.PlayStartAnim();
	}

	// Token: 0x0600F423 RID: 62499 RVA: 0x0042C795 File Offset: 0x0042A995
	protected override void OnBeforeDestroy()
	{
		this.TargetItem = null;
		this.WeaknessItem = null;
		this.CloseAnimCallback = null;
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F424 RID: 62500 RVA: 0x0042C7B2 File Offset: 0x0042A9B2
	public void SetTargetItemOffset(float x, float y)
	{
		if (this.TargetItem == null)
		{
			return;
		}
		this.TargetItem.SetAnchorOffsetX(x);
		this.TargetItem.SetAnchorOffsetY(y);
	}

	// Token: 0x0600F425 RID: 62501 RVA: 0x0042C7D8 File Offset: 0x0042A9D8
	public void SetTargetAimVisible(bool isVisible)
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
		if (!this.ExistAnim)
		{
			this.TargetItem.SetUIActive(isVisible);
			return;
		}
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

	// Token: 0x0600F426 RID: 62502 RVA: 0x0042C83C File Offset: 0x0042AA3C
	public void SetIsWeakness(bool isWeakness)
	{
		if (this.WeaknessItem == null)
		{
			return;
		}
		if (this.WeaknessItem.IsUIActiveSelf() == isWeakness)
		{
			return;
		}
		this.WeaknessItem.SetUIActive(isWeakness);
	}

	// Token: 0x0600F427 RID: 62503 RVA: 0x0042C862 File Offset: 0x0042AA62
	private void InitAllTweenAnim()
	{
		if (!this.ExistAnim)
		{
			return;
		}
		base.InitTweenAnim(2);
		base.InitTweenAnim(3);
		base.InitTweenAnim(4);
		base.InitTweenAnim(5);
		base.InitTweenAnim(6);
	}

	// Token: 0x0600F428 RID: 62504 RVA: 0x0042C890 File Offset: 0x0042AA90
	public void PlayStartAnim()
	{
		this.IsActive = true;
		this.StopCloseAnim();
		this.TryPlayTweenAnim(2);
	}

	// Token: 0x0600F429 RID: 62505 RVA: 0x0042C8A8 File Offset: 0x0042AAA8
	public void PlayCloseAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		this.IsActive = false;
		this.DestroyCloseTimer();
		if (!base.InAsyncLoading())
		{
			this.CloseTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.OnCloseAnimTimerEnd();
			}, 200f, null, null, true, 1f);
			this.TryPlayTweenAnim(3);
			return;
		}
		Action closeAnimCallback = this.CloseAnimCallback;
		if (closeAnimCallback == null)
		{
			return;
		}
		closeAnimCallback();
	}

	// Token: 0x0600F42A RID: 62506 RVA: 0x0042C914 File Offset: 0x0042AB14
	private void OnCloseAnimTimerEnd()
	{
		this.CloseTimer = null;
		Action closeAnimCallback = this.CloseAnimCallback;
		if (closeAnimCallback == null)
		{
			return;
		}
		closeAnimCallback();
	}

	// Token: 0x0600F42B RID: 62507 RVA: 0x0042C92D File Offset: 0x0042AB2D
	public void StopCloseAnim()
	{
		this.DestroyCloseTimer();
		this.TryStopTweenAnim(3);
	}

	// Token: 0x0600F42C RID: 62508 RVA: 0x0042C93C File Offset: 0x0042AB3C
	private void DestroyCloseTimer()
	{
		if (this.CloseTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseTimer);
			this.CloseTimer = null;
		}
	}

	// Token: 0x0600F42D RID: 62509 RVA: 0x0042C95E File Offset: 0x0042AB5E
	[NullableContext(1)]
	public void SetCloseAnimCallback(Action closeAnimCallback)
	{
		this.CloseAnimCallback = closeAnimCallback;
	}

	// Token: 0x0600F42E RID: 62510 RVA: 0x0042C967 File Offset: 0x0042AB67
	public void PlayStartAimAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		this.TryPlayTweenAnim(4);
	}

	// Token: 0x0600F42F RID: 62511 RVA: 0x0042C979 File Offset: 0x0042AB79
	public void PlayCloseAimAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		this.TryPlayTweenAnim(5);
	}

	// Token: 0x0600F430 RID: 62512 RVA: 0x0042C98B File Offset: 0x0042AB8B
	public void PlayLoopAimAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		this.TryPlayTweenAnim(6);
	}

	// Token: 0x0600F431 RID: 62513 RVA: 0x0042C99D File Offset: 0x0042AB9D
	public void StopLoopAimAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		this.TryStopTweenAnim(6);
	}

	// Token: 0x0600F432 RID: 62514 RVA: 0x0042C9AF File Offset: 0x0042ABAF
	private void TryPlayTweenAnim(int componentType)
	{
		if (!this.ExistAnim)
		{
			return;
		}
		base.PlayTweenAnim(componentType);
	}

	// Token: 0x0600F433 RID: 62515 RVA: 0x0042C9C1 File Offset: 0x0042ABC1
	private void TryStopTweenAnim(int componentType)
	{
		if (!this.ExistAnim)
		{
			return;
		}
		base.StopTweenAnim(componentType);
	}

	// Token: 0x0400756F RID: 30063
	private const int CLOSE_ANIM_TIME = 200;

	// Token: 0x04007570 RID: 30064
	private UUIItem TargetItem;

	// Token: 0x04007571 RID: 30065
	private UUIItem WeaknessItem;

	// Token: 0x04007572 RID: 30066
	private bool ExistAnim;

	// Token: 0x04007573 RID: 30067
	private TimerHandle CloseTimer;

	// Token: 0x04007574 RID: 30068
	private Action CloseAnimCallback;

	// Token: 0x04007575 RID: 30069
	private bool IsActive;

	// Token: 0x04007576 RID: 30070
	private bool IsTargetItemActive;

	// Token: 0x0200833D RID: 33597
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C826 RID: 182310
		TargetItem,
		// Token: 0x0402C827 RID: 182311
		WeaknessItem,
		// Token: 0x0402C828 RID: 182312
		AnimStart,
		// Token: 0x0402C829 RID: 182313
		AnimClose,
		// Token: 0x0402C82A RID: 182314
		AnimStartAim,
		// Token: 0x0402C82B RID: 182315
		AnimCloseAim,
		// Token: 0x0402C82C RID: 182316
		AnimLoopAim
	}
}
