using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FB3 RID: 8115
[NullableContext(1)]
[Nullable(0)]
public class MigrationStrengthUnit : HudUnitBase
{
	// Token: 0x0600F452 RID: 62546 RVA: 0x0042D22D File Offset: 0x0042B42D
	public void InitData(int strengthLineCount)
	{
		this.StrengthItemCount = strengthLineCount;
		this.RefreshSingleStrengthItemRotation(this.StrengthItemCount);
		this.RefreshSingleStrengthItemVisible(this.StrengthItemCount);
	}

	// Token: 0x0600F453 RID: 62547 RVA: 0x0042D250 File Offset: 0x0042B450
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F454 RID: 62548 RVA: 0x0042D3E8 File Offset: 0x0042B5E8
	protected override void OnStart()
	{
		this.RootItem.SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
		for (int i = 0; i < 4; i++)
		{
			this.AddSingleStrengthItem(i == 0);
		}
		base.GetTexture(2).SetUIActive(false);
		this.SetNormal(true);
		this.InitAllTweenAnim();
	}

	// Token: 0x0600F455 RID: 62549 RVA: 0x0042D433 File Offset: 0x0042B633
	protected override void OnAfterShow()
	{
		this.PlayStartAnim();
	}

	// Token: 0x0600F456 RID: 62550 RVA: 0x0042D43C File Offset: 0x0042B63C
	protected override UniTask OnBeforeHideAsync()
	{
		MigrationStrengthUnit.<OnBeforeHideAsync>d__34 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<MigrationStrengthUnit.<OnBeforeHideAsync>d__34>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F457 RID: 62551 RVA: 0x0042D47F File Offset: 0x0042B67F
	protected override void OnBeforeDestroy()
	{
		this.RefreshEntity(null);
		this.DestroyCloseAnimTimer();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F458 RID: 62552 RVA: 0x0042D494 File Offset: 0x0042B694
	public void SetNormal(bool bNormal)
	{
		if (this.IsNormalState == bNormal)
		{
			return;
		}
		this.IsNormalState = bNormal;
		base.GetTexture(0).SetUIActive(bNormal);
		base.GetTexture(1).SetUIActive(!bNormal);
		int num = (!this.IsNormalState) ? 1 : 0;
		base.GetTexture(3).SetColor(MigrationStrengthUnit.BarColor[num]);
		foreach (UUISprite uuisprite in this.StrengthSingleLineSpriteList)
		{
			uuisprite.SetColor(MigrationStrengthUnit.LineColor[num]);
		}
	}

	// Token: 0x0600F459 RID: 62553 RVA: 0x0042D540 File Offset: 0x0042B740
	private void RefreshSingleStrengthItemRotation(int count)
	{
		float num = 360f / (float)count;
		float num2 = 0f;
		for (int i = 0; i < count; i++)
		{
			UUIItem uuiitem = (i < this.StrengthSingleLineActorList.Count) ? this.GetSingleStrengthItem(i) : null;
			if (uuiitem == null)
			{
				uuiitem = this.AddSingleStrengthItem(false);
			}
			this.RotationCache.Yaw = num2;
			uuiitem.SetUIRelativeRotation(this.RotationCache);
			num2 += num;
		}
	}

	// Token: 0x0600F45A RID: 62554 RVA: 0x0042D5A8 File Offset: 0x0042B7A8
	private void RefreshSingleStrengthItemVisible(int count)
	{
		for (int i = 0; i < this.StrengthSingleLineActorList.Count; i++)
		{
			UUIItem uuiitem = this.StrengthSingleLineActorList[i];
			bool flag = i < count;
			if (uuiitem.IsUIActiveSelf() != flag)
			{
				uuiitem.SetUIActive(flag);
			}
		}
	}

	// Token: 0x0600F45B RID: 62555 RVA: 0x0042D5F0 File Offset: 0x0042B7F0
	private UUIItem AddSingleStrengthItem(bool isFirst = false)
	{
		UUIItem item = base.GetItem(4);
		UUIItem item2 = base.GetItem(5);
		UUIItem uuiitem;
		if (isFirst)
		{
			uuiitem = item2;
		}
		else
		{
			uuiitem = (Singleton<LguiUtil>.Instance.DuplicateActor(item2.GetOwner(), item).GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
		}
		UUISprite item3 = uuiitem.GetAttachUIChild(0).GetOwner().GetComponentByClass(UUISprite.StaticClass()) as UUISprite;
		this.StrengthSingleLineActorList.Add(uuiitem);
		this.StrengthSingleLineSpriteList.Add(item3);
		return uuiitem;
	}

	// Token: 0x0600F45C RID: 62556 RVA: 0x0042D676 File Offset: 0x0042B876
	private UUIItem GetSingleStrengthItem(int index)
	{
		return this.StrengthSingleLineActorList[index];
	}

	// Token: 0x0600F45D RID: 62557 RVA: 0x0042D684 File Offset: 0x0042B884
	[NullableContext(2)]
	public void RefreshEntity(BattleUiRoleData roleData)
	{
		if (roleData == null)
		{
			this.EntityHandle = null;
			this.ActorComponent = null;
			return;
		}
		this.EntityHandle = roleData.EntityHandle;
		this.ActorComponent = roleData.EntityHandle.Entity.GetComponent<CharacterActorComponent>();
	}

	// Token: 0x0600F45E RID: 62558 RVA: 0x0042D6BC File Offset: 0x0042B8BC
	public void SetStrengthPercent(float strength, float maxStrength)
	{
		float num = (maxStrength <= 0f) ? 0f : (strength / maxStrength);
		if (this.TargetStrengthPercent == num)
		{
			return;
		}
		if (this.CurStrengthPercent < num && this.TargetStrengthPercent != -1f)
		{
			this.RecoverPercentAnimSpeed = (num - this.CurStrengthPercent) / 250f;
		}
		else
		{
			this.CurStrengthPercent = num;
			this.RecoverPercentAnimSpeed = 0f;
			base.GetTexture(3).SetFillAmount(this.CurStrengthPercent);
		}
		this.TargetStrengthPercent = num;
		this.SetNormal(num >= 0.2f);
	}

	// Token: 0x0600F45F RID: 62559 RVA: 0x0042D750 File Offset: 0x0042B950
	public void SetRecoverState(bool isRecover)
	{
		if (this.IsRecover == isRecover)
		{
			return;
		}
		this.IsRecover = isRecover;
		UUITexture texture = base.GetTexture(2);
		if (isRecover)
		{
			this.RecoverAnimState = 1;
			this.PlayRecoverInAnim();
			this.RecoverBottomLimitPercent = this.CurStrengthPercent;
			this.RotationCache.Yaw = 360f * this.RecoverBottomLimitPercent;
			texture.SetUIRelativeRotation(this.RotationCache);
			base.GetTexture(6).SetUIRelativeRotation(this.RotationCache);
			texture.SetUIActive(true);
			return;
		}
		this.RecoverAnimState = 0;
		this.PlayRecoverOutAnim();
		texture.SetUIActive(false);
	}

	// Token: 0x0600F460 RID: 62560 RVA: 0x0042D7E4 File Offset: 0x0042B9E4
	public void TickRecoverAnim(float delta)
	{
		if (this.TargetStrengthPercent > this.CurStrengthPercent)
		{
			this.CurStrengthPercent += delta * this.RecoverPercentAnimSpeed;
			this.CurStrengthPercent = Math.Min(this.CurStrengthPercent, this.TargetStrengthPercent);
			base.GetTexture(3).SetFillAmount(this.CurStrengthPercent);
		}
		if (this.RecoverAnimState == 1)
		{
			float fillAmount = this.CurStrengthPercent - this.RecoverBottomLimitPercent;
			base.GetTexture(6).SetFillAmount(fillAmount);
			base.GetTexture(2).SetFillAmount(fillAmount);
			if (this.CurStrengthPercent == this.TargetStrengthPercent)
			{
				this.RecoverAnimState = 2;
				this.RecoverAnimStayTime = 1400f;
				return;
			}
		}
		else if (this.RecoverAnimState == 2)
		{
			this.RecoverAnimStayTime -= delta;
			if (this.RecoverAnimStayTime <= 0f)
			{
				this.RecoverAnimState = 3;
				return;
			}
		}
		else if (this.RecoverAnimState == 3)
		{
			this.RecoverBottomLimitPercent += delta * this.RecoverPercentAnimSpeed;
			if (this.RecoverBottomLimitPercent >= this.CurStrengthPercent)
			{
				this.RecoverBottomLimitPercent = this.CurStrengthPercent;
				this.RecoverAnimState = 0;
			}
			this.RotationCache.Yaw = 360f * this.RecoverBottomLimitPercent;
			float fillAmount2 = this.CurStrengthPercent - this.RecoverBottomLimitPercent;
			UUITexture texture = base.GetTexture(2);
			UUITexture texture2 = base.GetTexture(6);
			texture.SetUIRelativeRotation(this.RotationCache);
			texture2.SetUIRelativeRotation(this.RotationCache);
			texture.SetFillAmount(fillAmount2);
			texture2.SetFillAmount(fillAmount2);
		}
	}

	// Token: 0x0600F461 RID: 62561 RVA: 0x0042D95C File Offset: 0x0042BB5C
	public void RefreshTargetPosition(float delta)
	{
		if (!base.GetActive())
		{
			return;
		}
		if (this.ActorComponent == null)
		{
			return;
		}
		TsBaseCharacter actor = this.ActorComponent.Actor;
		if (actor == null || !actor.IsValid())
		{
			return;
		}
		FVectorDouble actorLocation = this.ActorComponent.ActorLocation;
		if (!HudUnitUtils.PositionUtil.ProjectWorldToScreen(actorLocation, this.ScreenPos))
		{
			return;
		}
		float num = (float)this.ScreenPos.X;
		float num2 = (float)this.ScreenPos.Y;
		if (this.OffsetX == 0f && this.OffsetY == 0f)
		{
			this.OffsetX = num;
			this.OffsetY = num2;
			base.SetAnchorOffset(this.OffsetX, this.OffsetY);
			return;
		}
		this.SpeedX = this.GetSpeed(delta, num, this.OffsetX, this.SpeedX);
		this.SpeedY = this.GetSpeed(delta, num2, this.OffsetY, this.SpeedY);
		float num3 = this.SpeedX * delta;
		float num4 = this.SpeedY * delta;
		if (num3 < 0.5f && num3 > -0.5f && num4 < 0.5f && num4 > -0.5f)
		{
			return;
		}
		this.OffsetX += num3;
		this.OffsetY += num4;
		base.SetAnchorOffset(this.OffsetX, this.OffsetY);
	}

	// Token: 0x0600F462 RID: 62562 RVA: 0x0042DAA8 File Offset: 0x0042BCA8
	private float GetSpeed(float delta, float target, float cur, float lastSpeed)
	{
		float num = target - cur;
		bool flag = false;
		if (num < 0f)
		{
			num = -num;
			flag = true;
		}
		if (num < 1f)
		{
			return 0f;
		}
		float num2;
		if (delta >= 200f)
		{
			num2 = num / delta;
		}
		else
		{
			num2 = num / 200f;
		}
		if (flag)
		{
			num2 = -num2;
		}
		return Singleton<MathUtils>.Instance.Lerp(lastSpeed, num2, 0.5f);
	}

	// Token: 0x0600F463 RID: 62563 RVA: 0x0042DB0A File Offset: 0x0042BD0A
	private void InitAllTweenAnim()
	{
		base.InitTweenAnim(7);
		base.InitTweenAnim(8);
		base.InitTweenAnim(9);
		base.InitTweenAnim(10);
	}

	// Token: 0x0600F464 RID: 62564 RVA: 0x0042DB2A File Offset: 0x0042BD2A
	private void PlayStartAnim()
	{
		base.PlayTweenAnim(7);
	}

	// Token: 0x0600F465 RID: 62565 RVA: 0x0042DB34 File Offset: 0x0042BD34
	private UniTask PlayCloseAnim()
	{
		MigrationStrengthUnit.<PlayCloseAnim>d__49 <PlayCloseAnim>d__;
		<PlayCloseAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseAnim>d__.<>4__this = this;
		<PlayCloseAnim>d__.<>1__state = -1;
		<PlayCloseAnim>d__.<>t__builder.Start<MigrationStrengthUnit.<PlayCloseAnim>d__49>(ref <PlayCloseAnim>d__);
		return <PlayCloseAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600F466 RID: 62566 RVA: 0x0042DB77 File Offset: 0x0042BD77
	private void DestroyCloseAnimTimer()
	{
		if (this.CloseAnimTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseAnimTimer);
			this.CloseAnimTimer = null;
		}
	}

	// Token: 0x0600F467 RID: 62567 RVA: 0x0042DB99 File Offset: 0x0042BD99
	private void PlayRecoverInAnim()
	{
		base.StopTweenAnim(10);
		base.PlayTweenAnim(9);
	}

	// Token: 0x0600F468 RID: 62568 RVA: 0x0042DBAB File Offset: 0x0042BDAB
	private void PlayRecoverOutAnim()
	{
		base.StopTweenAnim(9);
		base.PlayTweenAnim(10);
	}

	// Token: 0x04007589 RID: 30089
	private const float NORMAL_PERCENT = 0.2f;

	// Token: 0x0400758A RID: 30090
	private const int PRELOAD_SINGLE_STRENGTH_ITEM_COUNT = 4;

	// Token: 0x0400758B RID: 30091
	private const float MAX_DELTA_TIME = 200f;

	// Token: 0x0400758C RID: 30092
	private const float MIN_DELTA_OFFSET = 0.5f;

	// Token: 0x0400758D RID: 30093
	private const float RECOVER_ANIM_TIME = 250f;

	// Token: 0x0400758E RID: 30094
	private const float RECOVER_STAY_TIME = 1400f;

	// Token: 0x0400758F RID: 30095
	private const float CLOSE_ANIM_TIME = 250f;

	// Token: 0x04007590 RID: 30096
	private readonly Vector2D ScreenPos = new Vector2D();

	// Token: 0x04007591 RID: 30097
	private readonly List<UUIItem> StrengthSingleLineActorList = new List<UUIItem>();

	// Token: 0x04007592 RID: 30098
	private readonly List<UUISprite> StrengthSingleLineSpriteList = new List<UUISprite>();

	// Token: 0x04007593 RID: 30099
	private FRotator RotationCache = new FRotator(0f, 0f, 0f);

	// Token: 0x04007594 RID: 30100
	[StaticVariableRuleIgnore]
	private static readonly FColor[] BarColor = new FColor[]
	{
		FColor.FromHex("#3db9cb"),
		FColor.FromHex("#cb3d55")
	};

	// Token: 0x04007595 RID: 30101
	[StaticVariableRuleIgnore]
	private static readonly FColor[] LineColor = new FColor[]
	{
		FColor.FromHex("#234063"),
		FColor.FromHex("#633323")
	};

	// Token: 0x04007596 RID: 30102
	[Nullable(2)]
	public EntityHandle EntityHandle;

	// Token: 0x04007597 RID: 30103
	[Nullable(2)]
	public CharacterActorComponent ActorComponent;

	// Token: 0x04007598 RID: 30104
	private float TargetStrengthPercent = -1f;

	// Token: 0x04007599 RID: 30105
	private float CurStrengthPercent;

	// Token: 0x0400759A RID: 30106
	private bool IsRecover;

	// Token: 0x0400759B RID: 30107
	private int RecoverAnimState;

	// Token: 0x0400759C RID: 30108
	private float RecoverAnimStayTime;

	// Token: 0x0400759D RID: 30109
	private float RecoverPercentAnimSpeed;

	// Token: 0x0400759E RID: 30110
	private float RecoverBottomLimitPercent;

	// Token: 0x0400759F RID: 30111
	private int StrengthItemCount = 1;

	// Token: 0x040075A0 RID: 30112
	private bool IsNormalState;

	// Token: 0x040075A1 RID: 30113
	private float OffsetX;

	// Token: 0x040075A2 RID: 30114
	private float OffsetY;

	// Token: 0x040075A3 RID: 30115
	private float SpeedX;

	// Token: 0x040075A4 RID: 30116
	private float SpeedY;

	// Token: 0x040075A5 RID: 30117
	[Nullable(2)]
	private TimerHandle CloseAnimTimer;

	// Token: 0x02008341 RID: 33601
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C843 RID: 182339
		BgTextureNormal,
		// Token: 0x0402C844 RID: 182340
		BgTextureLow,
		// Token: 0x0402C845 RID: 182341
		EffectTexture,
		// Token: 0x0402C846 RID: 182342
		BarTexture,
		// Token: 0x0402C847 RID: 182343
		StrengthLineItem,
		// Token: 0x0402C848 RID: 182344
		StrengthSingleLineItem,
		// Token: 0x0402C849 RID: 182345
		LightTexture,
		// Token: 0x0402C84A RID: 182346
		AnimStart,
		// Token: 0x0402C84B RID: 182347
		AnimClose,
		// Token: 0x0402C84C RID: 182348
		AnimRecoverIn,
		// Token: 0x0402C84D RID: 182349
		AnimRecoverOut
	}
}
