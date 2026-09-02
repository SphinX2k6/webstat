using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FB2 RID: 8114
[NullableContext(2)]
[Nullable(0)]
public class ManipulateCursorUnit : HudUnitBase
{
	// Token: 0x0600F436 RID: 62518 RVA: 0x0042C9E4 File Offset: 0x0042ABE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(13, typeof(UUIItem)));
		}
	}

	// Token: 0x0600F437 RID: 62519 RVA: 0x0042CBE8 File Offset: 0x0042ADE8
	protected override UniTask OnBeforeStartAsync()
	{
		ManipulateCursorUnit.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ManipulateCursorUnit.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F438 RID: 62520 RVA: 0x0042CC2C File Offset: 0x0042AE2C
	protected override void OnBeforeDestroy()
	{
		this.DestroyCloseTimer();
		if (!string.IsNullOrEmpty(this.IconPath) && this.DefaultIconSpriteData != null && this.IconSprite != null)
		{
			this.IconSprite.SetSprite(this.DefaultIconSpriteData, false);
		}
		this.IconPath = null;
		this.DefaultIconSpriteData = null;
		this.IconSprite = null;
		this.ThrowSprite = null;
		this.ArrowItem = null;
		if (this.KeyItem != null)
		{
			this.KeyItem.Destroy(null);
			this.KeyItem = null;
		}
		this.ProcessItem = null;
		this.ProcessSprite = null;
		this.CloseAnimCallback = null;
		if (this.LoadHandleId != 0)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandleId);
			this.LoadHandleId = 0;
		}
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F439 RID: 62521 RVA: 0x0042CCE8 File Offset: 0x0042AEE8
	[NullableContext(1)]
	public void Refresh(bool isInScreen, Vector2D position, bool isCastTarget)
	{
		this.UpdateProcess();
		this.RotatorCache.Yaw = (float)(Math.Atan2(position.Y, position.X) * 57.2957763671875 - 90.0);
		this.RotatorCache.Roll = 0f;
		this.RotatorCache.Pitch = 0f;
		bool flag = !isInScreen;
		if (this.ArrowItem.IsUIActiveInHierarchy() != flag)
		{
			this.ArrowItem.SetUIActive(flag);
		}
		if (flag)
		{
			this.ArrowItem.SetUIRelativeRotation(this.RotatorCache);
		}
		base.SetAnchorOffset((float)position.X, (float)position.Y);
		this.SetIsCastTarget(isCastTarget);
	}

	// Token: 0x0600F43A RID: 62522 RVA: 0x0042CD9C File Offset: 0x0042AF9C
	private void SetIsCastTarget(bool isCastTarget)
	{
		if (this.IsCastTarget == isCastTarget)
		{
			return;
		}
		this.IsCastTarget = isCastTarget;
		if (Singleton<Info>.Instance.OperationType != EOperationType.Desktop)
		{
			this.IconSprite.SetUIActive(!isCastTarget);
			this.ThrowSprite.SetUIActive(isCastTarget);
			return;
		}
		if (isCastTarget)
		{
			this.SetKeyAction("攻击");
			return;
		}
		this.SetKeyAction("幻象1");
	}

	// Token: 0x0600F43B RID: 62523 RVA: 0x0042CE00 File Offset: 0x0042B000
	public void SetIconPath(string iconPath)
	{
		if (this.IconSprite == null)
		{
			return;
		}
		if (this.IconPath == iconPath)
		{
			return;
		}
		if (this.IconPath == null && this.DefaultIconSpriteData == null)
		{
			this.DefaultIconSpriteData = this.IconSprite.GetSprite();
		}
		this.IconPath = iconPath;
		if (this.LoadHandleId != 0)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandleId);
			this.LoadHandleId = 0;
		}
		if (iconPath == null)
		{
			this.IconSprite.SetSprite(this.DefaultIconSpriteData, false);
			this.IconSprite.SetUIActive(true);
			return;
		}
		this.IconSprite.SetUIActive(false);
		this.LoadHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(iconPath, delegate([Nullable(2)] ULGUISpriteData_BaseObject spriteData, string _)
		{
			if (this.IconSprite == null || this.IconPath != iconPath || spriteData == null)
			{
				return;
			}
			this.IconSprite.SetSprite(spriteData, false);
			this.IconSprite.SetUIActive(true);
		}, ResourceSystem.EResourceLoadPriority.BattleUi, this.MemoryTag);
	}

	// Token: 0x0600F43C RID: 62524 RVA: 0x0042CEE7 File Offset: 0x0042B0E7
	[NullableContext(1)]
	public void SetKeyAction(string actionName)
	{
		CombineKeyItem keyItem = this.KeyItem;
		if (keyItem == null)
		{
			return;
		}
		keyItem.RefreshAction(actionName);
	}

	// Token: 0x0600F43D RID: 62525 RVA: 0x0042CEFC File Offset: 0x0042B0FC
	public void StartProcess(float totalSeconds)
	{
		UUIItem processItem = this.ProcessItem;
		if (processItem != null)
		{
			processItem.SetUIActive(true);
		}
		this.SetProcess(0f);
		if (totalSeconds > 0f)
		{
			this.ProcessSpeed = 1f / (totalSeconds * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		}
		else
		{
			this.ProcessSpeed = 0f;
		}
		this.StartProcessTime = Singleton<Time>.Instance.WorldTime;
	}

	// Token: 0x0600F43E RID: 62526 RVA: 0x0042CF64 File Offset: 0x0042B164
	public void EndProcess(bool resetProcess)
	{
		this.StopProcessAnim();
		this.ProcessSpeed = 0f;
		if (resetProcess)
		{
			this.SetProcess(0f);
		}
	}

	// Token: 0x0600F43F RID: 62527 RVA: 0x0042CF88 File Offset: 0x0042B188
	private void UpdateProcess()
	{
		if (this.ProcessSpeed <= 0f)
		{
			return;
		}
		float process = MathF.Min((float)((Singleton<Time>.Instance.WorldTime - this.StartProcessTime) * (double)this.ProcessSpeed), 1f);
		this.SetProcess(process);
	}

	// Token: 0x0600F440 RID: 62528 RVA: 0x0042CFCF File Offset: 0x0042B1CF
	private void SetProcess(float percent)
	{
		UUISprite processSprite = this.ProcessSprite;
		if (processSprite == null)
		{
			return;
		}
		processSprite.SetFillAmount(percent);
	}

	// Token: 0x0600F441 RID: 62529 RVA: 0x0042CFE2 File Offset: 0x0042B1E2
	public void PlayActivateEffect()
	{
		UUINiagara uiNiagara = base.GetUiNiagara(6);
		uiNiagara.SetUIActive(true);
		uiNiagara.ActivateSystem(true);
	}

	// Token: 0x0600F442 RID: 62530 RVA: 0x0042CFF8 File Offset: 0x0042B1F8
	private void InitAllTweenAnim()
	{
		base.InitTweenAnim(7);
		base.InitTweenAnim(8);
		base.InitTweenAnim(9);
		base.InitTweenAnim(10);
		base.InitTweenAnim(12);
	}

	// Token: 0x0600F443 RID: 62531 RVA: 0x0042D020 File Offset: 0x0042B220
	public void Appear()
	{
		this.IsActive = true;
		this.DestroyCloseTimer();
		if (base.InAsyncLoading())
		{
			return;
		}
		UUISprite iconSprite = this.IconSprite;
		if (iconSprite != null)
		{
			iconSprite.SetAlpha(1f);
		}
		UUISprite throwSprite = this.ThrowSprite;
		if (throwSprite != null)
		{
			throwSprite.SetAlpha(1f);
		}
		UUIItem arrowItem = this.ArrowItem;
		if (arrowItem == null)
		{
			return;
		}
		arrowItem.SetAlpha(1f);
	}

	// Token: 0x0600F444 RID: 62532 RVA: 0x0042D084 File Offset: 0x0042B284
	public void PlayStartAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.PlayTweenAnim(7);
	}

	// Token: 0x0600F445 RID: 62533 RVA: 0x0042D096 File Offset: 0x0042B296
	public void PlayCompleteAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.PlayTweenAnim(9);
	}

	// Token: 0x0600F446 RID: 62534 RVA: 0x0042D0A9 File Offset: 0x0042B2A9
	public void PlayInterruptedAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.PlayTweenAnim(10);
	}

	// Token: 0x0600F447 RID: 62535 RVA: 0x0042D0BC File Offset: 0x0042B2BC
	public void PlayProcessAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.PlayTweenAnim(8);
	}

	// Token: 0x0600F448 RID: 62536 RVA: 0x0042D0CE File Offset: 0x0042B2CE
	public void StopProcessAnim()
	{
		if (!this.IsActive)
		{
			return;
		}
		base.StopTweenAnim(8);
	}

	// Token: 0x0600F449 RID: 62537 RVA: 0x0042D0E0 File Offset: 0x0042B2E0
	public void PlayCloseAnim(float delay)
	{
		if (!this.IsActive)
		{
			return;
		}
		this.IsActive = false;
		this.DestroyCloseTimer();
		if (base.InAsyncLoading())
		{
			Action closeAnimCallback = this.CloseAnimCallback;
			if (closeAnimCallback == null)
			{
				return;
			}
			closeAnimCallback();
			return;
		}
		else
		{
			if (delay > 20f)
			{
				this.CloseTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.OnCloseTimerEnd();
				}, (float)((int)delay), null, null, true, 1f);
				return;
			}
			this.OnCloseAnimTimerEnd();
			return;
		}
	}

	// Token: 0x0600F44A RID: 62538 RVA: 0x0042D154 File Offset: 0x0042B354
	private void OnCloseTimerEnd()
	{
		this.CloseTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.OnCloseAnimTimerEnd();
		}, 300f, null, null, true, 1f);
		UUIItem processItem = this.ProcessItem;
		if (processItem != null)
		{
			processItem.SetUIActive(false);
		}
		base.PlayTweenAnim(12);
	}

	// Token: 0x0600F44B RID: 62539 RVA: 0x0042D1A4 File Offset: 0x0042B3A4
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

	// Token: 0x0600F44C RID: 62540 RVA: 0x0042D1BD File Offset: 0x0042B3BD
	public void StopCloseAnim()
	{
		this.DestroyCloseTimer();
		UUIItem processItem = this.ProcessItem;
		if (processItem != null)
		{
			processItem.SetUIActive(false);
		}
		base.StopTweenAnim(12);
	}

	// Token: 0x0600F44D RID: 62541 RVA: 0x0042D1DF File Offset: 0x0042B3DF
	private void DestroyCloseTimer()
	{
		if (this.CloseTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseTimer);
			this.CloseTimer = null;
		}
	}

	// Token: 0x0600F44E RID: 62542 RVA: 0x0042D201 File Offset: 0x0042B401
	[NullableContext(1)]
	public void SetCloseAnimCallback(Action closeAnimCallback)
	{
		this.CloseAnimCallback = closeAnimCallback;
	}

	// Token: 0x04007577 RID: 30071
	private const int CLOSE_ANIM_TIME = 300;

	// Token: 0x04007578 RID: 30072
	private const float RAD_2_DEG = 57.295776f;

	// Token: 0x04007579 RID: 30073
	private FRotator RotatorCache = new FRotator();

	// Token: 0x0400757A RID: 30074
	private UUISprite IconSprite;

	// Token: 0x0400757B RID: 30075
	private UUISprite ThrowSprite;

	// Token: 0x0400757C RID: 30076
	private UUIItem ArrowItem;

	// Token: 0x0400757D RID: 30077
	private CombineKeyItem KeyItem;

	// Token: 0x0400757E RID: 30078
	private UUIItem ProcessItem;

	// Token: 0x0400757F RID: 30079
	private UUISprite ProcessSprite;

	// Token: 0x04007580 RID: 30080
	private TimerHandle CloseTimer;

	// Token: 0x04007581 RID: 30081
	private Action CloseAnimCallback;

	// Token: 0x04007582 RID: 30082
	private bool IsActive;

	// Token: 0x04007583 RID: 30083
	private float ProcessSpeed;

	// Token: 0x04007584 RID: 30084
	private double StartProcessTime;

	// Token: 0x04007585 RID: 30085
	private bool IsCastTarget;

	// Token: 0x04007586 RID: 30086
	private string IconPath;

	// Token: 0x04007587 RID: 30087
	private ULGUISpriteData_BaseObject DefaultIconSpriteData;

	// Token: 0x04007588 RID: 30088
	private int LoadHandleId;

	// Token: 0x0200833E RID: 33598
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C82E RID: 182318
		IconSprite,
		// Token: 0x0402C82F RID: 182319
		ThrowSprite,
		// Token: 0x0402C830 RID: 182320
		ArrowItem,
		// Token: 0x0402C831 RID: 182321
		ProcessItem,
		// Token: 0x0402C832 RID: 182322
		ProcessSprite,
		// Token: 0x0402C833 RID: 182323
		LockNode,
		// Token: 0x0402C834 RID: 182324
		ActivateEffect,
		// Token: 0x0402C835 RID: 182325
		AnimStart,
		// Token: 0x0402C836 RID: 182326
		AnimProcess,
		// Token: 0x0402C837 RID: 182327
		AnimComplete,
		// Token: 0x0402C838 RID: 182328
		AnimInterrupted,
		// Token: 0x0402C839 RID: 182329
		AnimBanned,
		// Token: 0x0402C83A RID: 182330
		AnimClose,
		// Token: 0x0402C83B RID: 182331
		KeyItem
	}
}
