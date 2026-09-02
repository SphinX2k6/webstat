using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FBD RID: 8125
[NullableContext(1)]
[Nullable(0)]
public class FlyStrengthItem : StrengthItemBase
{
	// Token: 0x0600F4C5 RID: 62661 RVA: 0x0042FEED File Offset: 0x0042E0ED
	protected override string GetResourceId()
	{
		return "UiItem_EnergyFly";
	}

	// Token: 0x0600F4C6 RID: 62662 RVA: 0x0042FEF4 File Offset: 0x0042E0F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F4C7 RID: 62663 RVA: 0x00430048 File Offset: 0x0042E248
	protected override void OnStart()
	{
		for (int i = 0; i < 3; i++)
		{
			this.AddSingleStrengthItem(i == 0);
		}
		this.LowEndurancePercent = (float)ConfigCommonParamById.GetIntConfig("LowEndurancePercent").GetValueOrDefault() / 10000f;
		this.SingleStrengthValue = (float)ConfigCommonParamById.GetIntConfig("FlySingleStrengthValue").GetValueOrDefault();
		this.MaxSingleStrengthItemCount = ConfigCommonParamById.GetIntConfig("FlyMaxSingleStrengthItemCount").GetValueOrDefault(1);
		this.TailSpeed = (float)ConfigCommonParamById.GetIntConfig("FlyTailSpeed").GetValueOrDefault() * (float)Singleton<TimeUtil>.Instance.Millisecond;
		base.InitTweenAnim(7);
		base.InitTweenAnim(8);
		base.OnStart();
		this.RefreshStrengthPercent(true);
	}

	// Token: 0x0600F4C8 RID: 62664 RVA: 0x004300FD File Offset: 0x0042E2FD
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		base.StopTweenAnim(8);
		base.PlayTweenAnim(7);
	}

	// Token: 0x0600F4C9 RID: 62665 RVA: 0x00430114 File Offset: 0x0042E314
	protected override UniTask OnBeforeHideAsync()
	{
		FlyStrengthItem.<OnBeforeHideAsync>d__28 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<FlyStrengthItem.<OnBeforeHideAsync>d__28>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F4CA RID: 62666 RVA: 0x00430157 File Offset: 0x0042E357
	protected override void OnBeforeDestroy()
	{
		this.DestroyCloseAnimTimer();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F4CB RID: 62667 RVA: 0x00430165 File Offset: 0x0042E365
	public override void Tick(float delta)
	{
		if (!base.GetUiVisible())
		{
			return;
		}
		if (this.TailStrengthCurrentValue <= this.StrengthCurrentValue)
		{
			return;
		}
		this.TailStrengthCurrentValue -= delta * this.TailSpeed;
		this.UpdateTailProgress();
	}

	// Token: 0x0600F4CC RID: 62668 RVA: 0x0043019A File Offset: 0x0042E39A
	protected override void OnAddEvents()
	{
		ControllerBase<FormationAttributeController>.Instance.AddValueListener(this.StrengthAttributeId, new TValueListener(this.OnStrengthChanged), null);
		ControllerBase<FormationAttributeController>.Instance.AddMaxListener(this.StrengthAttributeId, new TValueListener(this.OnStrengthMaxChanged), null);
	}

	// Token: 0x0600F4CD RID: 62669 RVA: 0x004301D6 File Offset: 0x0042E3D6
	protected override void OnRemoveEvents()
	{
		ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(this.StrengthAttributeId, new TValueListener(this.OnStrengthChanged));
		ControllerBase<FormationAttributeController>.Instance.RemoveMaxListener(this.StrengthAttributeId, new TValueListener(this.OnStrengthMaxChanged));
	}

	// Token: 0x0600F4CE RID: 62670 RVA: 0x00430210 File Offset: 0x0042E410
	protected override void OnAddEntityEvents()
	{
		if (this.RoleData == null)
		{
			return;
		}
		BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
		if (gameplayTagComponent == null)
		{
			return;
		}
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.XA"]), new Action<int, bool>(this.OnFlyTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力显示"]), new Action<int, bool>(this.OnFlyStrengthTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.XA.冲刺"]), new Action<int, bool>(this.OnSpeedUpTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力冲刺"]), new Action<int, bool>(this.OnBaseSpeedUpTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力锁定"]), new Action<int, bool>(this.OnLockTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力隐藏"]), new Action<int, bool>(this.OnHideTagChanged));
	}

	// Token: 0x0600F4CF RID: 62671 RVA: 0x00430320 File Offset: 0x0042E520
	protected override void OnRefreshRoleData()
	{
		if (this.RoleData == null)
		{
			return;
		}
		BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
		this.IsFlyTag = (gameplayTagComponent != null && gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.XA"]));
		BaseTagComponent gameplayTagComponent2 = this.RoleData.GameplayTagComponent;
		this.IsFlyStrengthTag = (gameplayTagComponent2 != null && gameplayTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力显示"]));
		BaseTagComponent gameplayTagComponent3 = this.RoleData.GameplayTagComponent;
		this.IsSpeedUpTag = (gameplayTagComponent3 != null && gameplayTagComponent3.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.XA.冲刺"]));
		BaseTagComponent gameplayTagComponent4 = this.RoleData.GameplayTagComponent;
		this.IsBaseSpeedUpTag = (gameplayTagComponent4 != null && gameplayTagComponent4.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力冲刺"]));
		BaseTagComponent gameplayTagComponent5 = this.RoleData.GameplayTagComponent;
		this.IsLock = (gameplayTagComponent5 != null && gameplayTagComponent5.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力锁定"]));
		BaseTagComponent gameplayTagComponent6 = this.RoleData.GameplayTagComponent;
		this.IsHideTag = (gameplayTagComponent6 != null && gameplayTagComponent6.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.翱翔体力隐藏"]));
		this.IsFlying = (this.IsFlyTag || this.IsFlyStrengthTag);
		this.IsSpeedUp = (this.IsSpeedUpTag || this.IsBaseSpeedUpTag);
		this.RefreshSpeedUp();
		this.RefreshLockState();
		this.RefreshVisible();
	}

	// Token: 0x0600F4D0 RID: 62672 RVA: 0x0043047E File Offset: 0x0042E67E
	protected override void OnEnableStrengthItem(bool b)
	{
		this.RefreshVisible();
	}

	// Token: 0x0600F4D1 RID: 62673 RVA: 0x00430486 File Offset: 0x0042E686
	private void OnStrengthChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
	{
		this.RefreshStrengthPercent(false);
	}

	// Token: 0x0600F4D2 RID: 62674 RVA: 0x0043048F File Offset: 0x0042E68F
	private void OnStrengthMaxChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
	{
		this.RefreshStrengthPercent(false);
	}

	// Token: 0x0600F4D3 RID: 62675 RVA: 0x00430498 File Offset: 0x0042E698
	protected void OnFlyTagChanged(int tagId, bool tagExists)
	{
		this.IsFlyTag = tagExists;
		if (this.IsFlying != (this.IsFlyTag || this.IsFlyStrengthTag))
		{
			this.IsFlying = !this.IsFlying;
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F4D4 RID: 62676 RVA: 0x004304CF File Offset: 0x0042E6CF
	protected void OnFlyStrengthTagChanged(int tagId, bool tagExists)
	{
		this.IsFlyStrengthTag = tagExists;
		if (this.IsFlying != (this.IsFlyTag || this.IsFlyStrengthTag))
		{
			this.IsFlying = !this.IsFlying;
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F4D5 RID: 62677 RVA: 0x00430506 File Offset: 0x0042E706
	protected void OnSpeedUpTagChanged(int tagId, bool tagExists)
	{
		this.IsSpeedUpTag = tagExists;
		if (this.IsSpeedUp != (this.IsSpeedUpTag || this.IsBaseSpeedUpTag))
		{
			this.IsSpeedUp = !this.IsSpeedUp;
			this.RefreshSpeedUp();
		}
	}

	// Token: 0x0600F4D6 RID: 62678 RVA: 0x0043053D File Offset: 0x0042E73D
	protected void OnBaseSpeedUpTagChanged(int tagId, bool tagExists)
	{
		this.IsBaseSpeedUpTag = tagExists;
		if (this.IsSpeedUp != (this.IsFlyTag || this.IsBaseSpeedUpTag))
		{
			this.IsSpeedUp = !this.IsSpeedUp;
			this.RefreshSpeedUp();
		}
	}

	// Token: 0x0600F4D7 RID: 62679 RVA: 0x00430574 File Offset: 0x0042E774
	protected void OnLockTagChanged(int tagId, bool tagExists)
	{
		if (this.IsLock != tagExists)
		{
			this.IsLock = tagExists;
			this.RefreshLockState();
		}
	}

	// Token: 0x0600F4D8 RID: 62680 RVA: 0x0043058C File Offset: 0x0042E78C
	protected void OnHideTagChanged(int tagId, bool tagExists)
	{
		if (this.IsHideTag != tagExists)
		{
			this.IsHideTag = tagExists;
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F4D9 RID: 62681 RVA: 0x004305A4 File Offset: 0x0042E7A4
	private UUIItem AddSingleStrengthItem(bool isFirst = false)
	{
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		UUIItem uuiitem;
		if (isFirst)
		{
			uuiitem = item2;
		}
		else
		{
			uuiitem = (Singleton<LguiUtil>.Instance.DuplicateActor(item2.GetOwner(), item).GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
		}
		this.StrengthSingleLineActorList.Add(uuiitem);
		return uuiitem;
	}

	// Token: 0x0600F4DA RID: 62682 RVA: 0x004305FC File Offset: 0x0042E7FC
	private void RefreshStrengthPercent(bool bForce = false)
	{
		float value = ControllerBase<FormationAttributeController>.Instance.GetValue(this.StrengthAttributeId);
		float max = ControllerBase<FormationAttributeController>.Instance.GetMax(this.StrengthAttributeId);
		bool flag = value != this.StrengthCurrentValue;
		if (flag)
		{
			this.StrengthCurrentValue = value;
			if (this.IsSpeedUp && this.TailStrengthCurrentValue < this.StrengthCurrentValue)
			{
				this.TailStrengthCurrentValue = this.StrengthCurrentValue;
			}
		}
		if (max != this.MaxStrengthCurrentValue)
		{
			flag = true;
			this.MaxStrengthCurrentValue = max;
			this.RefreshSingleStrengthItemVisible(max);
		}
		if (flag)
		{
			base.GetSprite(1).SetFillAmount(value / max);
		}
		this.RefreshStrengthState(bForce);
	}

	// Token: 0x0600F4DB RID: 62683 RVA: 0x00430698 File Offset: 0x0042E898
	private void RefreshSingleStrengthItemVisible(float maxStrength)
	{
		int num = (int)Math.Floor((double)(maxStrength / this.SingleStrengthValue));
		if (num > this.MaxSingleStrengthItemCount)
		{
			num = this.MaxSingleStrengthItemCount;
		}
		for (int i = 0; i < this.StrengthSingleLineActorList.Count; i++)
		{
			UUIItem uuiitem = this.StrengthSingleLineActorList[i];
			bool flag = i < num;
			if (uuiitem.IsUIActiveSelf() != flag)
			{
				uuiitem.SetUIActive(flag);
			}
		}
		this.RefreshSingleStrengthItemRotation();
	}

	// Token: 0x0600F4DC RID: 62684 RVA: 0x00430704 File Offset: 0x0042E904
	private void RefreshSingleStrengthItemRotation()
	{
		int num = (int)Math.Floor((double)(this.MaxStrengthCurrentValue / this.SingleStrengthValue));
		if (num > this.MaxSingleStrengthItemCount)
		{
			num = this.MaxSingleStrengthItemCount;
		}
		float num2 = 360f / (float)num;
		float num3 = 0f;
		for (int i = 0; i < num; i++)
		{
			UUIItem uuiitem = (this.StrengthSingleLineActorList.Count > i) ? this.StrengthSingleLineActorList[i] : null;
			if (uuiitem == null)
			{
				uuiitem = this.AddSingleStrengthItem(false);
			}
			UUIItem uuiitem2 = uuiitem;
			FRotator frotator = new FRotator(0f, num3, 0f);
			uuiitem2.SetUIRelativeRotation(frotator);
			num3 += num2;
		}
	}

	// Token: 0x0600F4DD RID: 62685 RVA: 0x0043079C File Offset: 0x0042E99C
	private void RefreshStrengthState(bool bForce = false)
	{
		float strengthCurrentValue = this.StrengthCurrentValue;
		float maxStrengthCurrentValue = this.MaxStrengthCurrentValue;
		bool bNormal = strengthCurrentValue / maxStrengthCurrentValue > this.LowEndurancePercent;
		this.SetNormal(bNormal, bForce);
		bool flag = strengthCurrentValue >= maxStrengthCurrentValue;
		if (this.IsFullState != flag || bForce)
		{
			this.IsFullState = flag;
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F4DE RID: 62686 RVA: 0x004307F0 File Offset: 0x0042E9F0
	private void SetNormal(bool bNormal, bool bForce = false)
	{
		if (this.IsNormalState == bNormal && !bForce)
		{
			return;
		}
		this.IsNormalState = bNormal;
		UUISprite sprite = base.GetSprite(1);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = !bNormal;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		UUISprite sprite2 = base.GetSprite(2);
		UUIItem uuiitem2 = sprite2;
		bool bUseChangeColor2 = !bNormal;
		fcolor = new FColor?(sprite2.changeColor);
		uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
	}

	// Token: 0x0600F4DF RID: 62687 RVA: 0x00430854 File Offset: 0x0042EA54
	protected void RefreshVisible()
	{
		bool active = !this.IsHideTag && (this.IsFlying || !this.IsFullState) && this.IsEnableStrengthItem;
		this.SetActive(active);
	}

	// Token: 0x0600F4E0 RID: 62688 RVA: 0x0043088C File Offset: 0x0042EA8C
	protected void RefreshSpeedUp()
	{
		UUISprite sprite = base.GetSprite(0);
		UUIItem item = base.GetItem(5);
		if (!this.IsSpeedUp)
		{
			this.TailStrengthCurrentValue = 0f;
			sprite.SetUIActive(false);
			item.SetUIActive(false);
			return;
		}
		if (this.TailStrengthCurrentValue == 0f)
		{
			this.TailStrengthCurrentValue = this.StrengthCurrentValue;
		}
		this.UpdateTailProgress();
		sprite.SetUIActive(true);
		item.SetUIActive(true);
	}

	// Token: 0x0600F4E1 RID: 62689 RVA: 0x004308F8 File Offset: 0x0042EAF8
	private void UpdateTailProgress()
	{
		UUISprite sprite = base.GetSprite(0);
		UUIItem item = base.GetItem(5);
		sprite.SetFillAmount(this.TailStrengthCurrentValue / this.MaxStrengthCurrentValue);
		float inYaw = 360f * (this.StrengthCurrentValue / this.MaxStrengthCurrentValue);
		UUIItem uuiitem = item;
		FRotator frotator = new FRotator(0f, inYaw, 0f);
		uuiitem.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0600F4E2 RID: 62690 RVA: 0x00430953 File Offset: 0x0042EB53
	protected void RefreshLockState()
	{
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.IsLock);
	}

	// Token: 0x0600F4E3 RID: 62691 RVA: 0x0043096C File Offset: 0x0042EB6C
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

	// Token: 0x04007613 RID: 30227
	private const int CLOSE_ANIM_TIME = 250;

	// Token: 0x04007614 RID: 30228
	private const int PRELOAD_SINGLE_STRENGTH_ITEM_COUNT = 3;

	// Token: 0x04007615 RID: 30229
	protected EFormationAttributeId StrengthAttributeId = EFormationAttributeId.SoarStrength;

	// Token: 0x04007616 RID: 30230
	private bool IsNormalState = true;

	// Token: 0x04007617 RID: 30231
	private bool IsFullState = true;

	// Token: 0x04007618 RID: 30232
	protected bool IsFlying;

	// Token: 0x04007619 RID: 30233
	protected bool IsSpeedUp;

	// Token: 0x0400761A RID: 30234
	protected bool IsLock;

	// Token: 0x0400761B RID: 30235
	protected bool IsHideTag;

	// Token: 0x0400761C RID: 30236
	private bool IsFlyTag;

	// Token: 0x0400761D RID: 30237
	private bool IsFlyStrengthTag;

	// Token: 0x0400761E RID: 30238
	private bool IsSpeedUpTag;

	// Token: 0x0400761F RID: 30239
	private bool IsBaseSpeedUpTag;

	// Token: 0x04007620 RID: 30240
	private float LowEndurancePercent;

	// Token: 0x04007621 RID: 30241
	private float SingleStrengthValue;

	// Token: 0x04007622 RID: 30242
	private int MaxSingleStrengthItemCount = 1;

	// Token: 0x04007623 RID: 30243
	private float TailSpeed = 0.1f;

	// Token: 0x04007624 RID: 30244
	private readonly List<UUIItem> StrengthSingleLineActorList = new List<UUIItem>();

	// Token: 0x04007625 RID: 30245
	private float StrengthCurrentValue;

	// Token: 0x04007626 RID: 30246
	private float MaxStrengthCurrentValue;

	// Token: 0x04007627 RID: 30247
	private float TailStrengthCurrentValue;

	// Token: 0x04007628 RID: 30248
	[Nullable(2)]
	private TimerHandle CloseAnimTimer;

	// Token: 0x04007629 RID: 30249
	[Nullable(2)]
	private CustomPromise CloseAnimPromise;

	// Token: 0x0400762A RID: 30250
	[StaticVariableRuleIgnore]
	private static readonly Stat CloseAnimTimerStat = Stat.Create("StrengthCloseAnim", "", "");
}
