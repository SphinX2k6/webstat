using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FC0 RID: 8128
[NullableContext(1)]
[Nullable(0)]
public class FlyStrengthItemForQingXiao : StrengthItemBase
{
	// Token: 0x0600F4EE RID: 62702 RVA: 0x00430C15 File Offset: 0x0042EE15
	protected override string GetResourceId()
	{
		return "UiItem_EnergyFly";
	}

	// Token: 0x0600F4EF RID: 62703 RVA: 0x00430C1C File Offset: 0x0042EE1C
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

	// Token: 0x0600F4F0 RID: 62704 RVA: 0x00430D70 File Offset: 0x0042EF70
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

	// Token: 0x0600F4F1 RID: 62705 RVA: 0x00430E25 File Offset: 0x0042F025
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		base.StopTweenAnim(8);
		base.PlayTweenAnim(7);
	}

	// Token: 0x0600F4F2 RID: 62706 RVA: 0x00430E3C File Offset: 0x0042F03C
	protected override UniTask OnBeforeHideAsync()
	{
		FlyStrengthItemForQingXiao.<OnBeforeHideAsync>d__24 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<FlyStrengthItemForQingXiao.<OnBeforeHideAsync>d__24>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F4F3 RID: 62707 RVA: 0x00430E7F File Offset: 0x0042F07F
	protected override void OnBeforeDestroy()
	{
		this.DestroyCloseAnimTimer();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F4F4 RID: 62708 RVA: 0x00430E8D File Offset: 0x0042F08D
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

	// Token: 0x0600F4F5 RID: 62709 RVA: 0x00430EC4 File Offset: 0x0042F0C4
	protected override void OnAddEntityEvents()
	{
		if (this.RoleData == null)
		{
			return;
		}
		BattleUiRoleData roleData = this.RoleData;
		if (roleData.RoleConfig == null || roleData.RoleConfig.GetValueOrDefault().Id != 1413)
		{
			return;
		}
		BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
		if (gameplayTagComponent == null)
		{
			return;
		}
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.御剑飞行能量.显示"]), new Action<int, bool>(this.OnFlyStrengthTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.御剑飞行能量.冲刺"]), new Action<int, bool>(this.OnBaseSpeedUpTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.御剑飞行能量.锁定"]), new Action<int, bool>(this.OnLockTagChanged));
		base.ListenForAttributeChanged(this.StrengthAttributeId, new Action<EAttributeType, float, float>(this.OnStrengthChanged));
		base.ListenForAttributeChanged(this.MaxStrengthAttributeId, new Action<EAttributeType, float, float>(this.OnStrengthMaxChanged));
	}

	// Token: 0x0600F4F6 RID: 62710 RVA: 0x00430FC0 File Offset: 0x0042F1C0
	protected override void OnRefreshRoleData()
	{
		if (this.RoleData == null)
		{
			return;
		}
		BattleUiRoleData roleData = this.RoleData;
		if (roleData.RoleConfig == null || roleData.RoleConfig.GetValueOrDefault().Id != 1413)
		{
			this.IsFlying = false;
			this.IsFullState = true;
			this.RefreshVisible();
			return;
		}
		BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
		this.IsFlying = (gameplayTagComponent != null && gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.御剑飞行能量.显示"]));
		BaseTagComponent gameplayTagComponent2 = this.RoleData.GameplayTagComponent;
		this.IsSpeedUp = (gameplayTagComponent2 != null && gameplayTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.御剑飞行能量.冲刺"]));
		BaseTagComponent gameplayTagComponent3 = this.RoleData.GameplayTagComponent;
		this.IsLock = (gameplayTagComponent3 != null && gameplayTagComponent3.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.御剑飞行能量.锁定"]));
		this.RefreshSpeedUp();
		this.RefreshLockState();
		this.RefreshVisible();
		this.RefreshStrengthPercent(false);
	}

	// Token: 0x0600F4F7 RID: 62711 RVA: 0x004310B8 File Offset: 0x0042F2B8
	protected override void OnEnableStrengthItem(bool b)
	{
		this.RefreshVisible();
	}

	// Token: 0x0600F4F8 RID: 62712 RVA: 0x004310C0 File Offset: 0x0042F2C0
	private void OnStrengthChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		this.RefreshStrengthPercent(false);
	}

	// Token: 0x0600F4F9 RID: 62713 RVA: 0x004310C9 File Offset: 0x0042F2C9
	private void OnStrengthMaxChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		this.RefreshStrengthPercent(false);
	}

	// Token: 0x0600F4FA RID: 62714 RVA: 0x004310D2 File Offset: 0x0042F2D2
	protected void OnFlyStrengthTagChanged(int tagId, bool tagExists)
	{
		if (this.IsFlying != tagExists)
		{
			this.IsFlying = tagExists;
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F4FB RID: 62715 RVA: 0x004310EA File Offset: 0x0042F2EA
	protected void OnBaseSpeedUpTagChanged(int tagId, bool tagExists)
	{
		if (this.IsSpeedUp != tagExists)
		{
			this.IsSpeedUp = tagExists;
			this.RefreshSpeedUp();
		}
	}

	// Token: 0x0600F4FC RID: 62716 RVA: 0x00431102 File Offset: 0x0042F302
	protected void OnLockTagChanged(int tagId, bool tagExists)
	{
		if (this.IsLock != tagExists)
		{
			this.IsLock = tagExists;
			this.RefreshLockState();
		}
	}

	// Token: 0x0600F4FD RID: 62717 RVA: 0x0043111C File Offset: 0x0042F31C
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

	// Token: 0x0600F4FE RID: 62718 RVA: 0x00431174 File Offset: 0x0042F374
	private void RefreshStrengthPercent(bool bForce = false)
	{
		BattleUiRoleData roleData = this.RoleData;
		BaseAttributeComponent baseAttributeComponent = (roleData != null) ? roleData.AttributeComponent : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		float currentValue = baseAttributeComponent.GetCurrentValue(this.StrengthAttributeId);
		float currentValue2 = baseAttributeComponent.GetCurrentValue(this.MaxStrengthAttributeId);
		bool flag = currentValue != this.StrengthCurrentValue;
		if (flag)
		{
			this.StrengthCurrentValue = currentValue;
			if (this.IsSpeedUp && this.TailStrengthCurrentValue < this.StrengthCurrentValue)
			{
				this.TailStrengthCurrentValue = this.StrengthCurrentValue;
			}
		}
		if (currentValue2 != this.MaxStrengthCurrentValue)
		{
			flag = true;
			this.MaxStrengthCurrentValue = currentValue2;
			this.RefreshSingleStrengthItemVisible(currentValue2);
		}
		if (flag)
		{
			base.GetSprite(1).SetFillAmount(currentValue / currentValue2);
		}
		this.RefreshStrengthState(bForce);
	}

	// Token: 0x0600F4FF RID: 62719 RVA: 0x00431220 File Offset: 0x0042F420
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

	// Token: 0x0600F500 RID: 62720 RVA: 0x0043128C File Offset: 0x0042F48C
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

	// Token: 0x0600F501 RID: 62721 RVA: 0x00431324 File Offset: 0x0042F524
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

	// Token: 0x0600F502 RID: 62722 RVA: 0x00431378 File Offset: 0x0042F578
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

	// Token: 0x0600F503 RID: 62723 RVA: 0x004313DC File Offset: 0x0042F5DC
	protected void RefreshVisible()
	{
		bool flag = (this.IsFlying || !this.IsFullState) && this.IsEnableStrengthItem;
		if (this.TargetActive != flag)
		{
			this.SetActive(flag);
		}
	}

	// Token: 0x0600F504 RID: 62724 RVA: 0x00431414 File Offset: 0x0042F614
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

	// Token: 0x0600F505 RID: 62725 RVA: 0x00431480 File Offset: 0x0042F680
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

	// Token: 0x0600F506 RID: 62726 RVA: 0x004314DB File Offset: 0x0042F6DB
	protected void RefreshLockState()
	{
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.IsLock);
	}

	// Token: 0x0600F507 RID: 62727 RVA: 0x004314F4 File Offset: 0x0042F6F4
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

	// Token: 0x04007635 RID: 30261
	private const int CLOSE_ANIM_TIME = 250;

	// Token: 0x04007636 RID: 30262
	private const int PRELOAD_SINGLE_STRENGTH_ITEM_COUNT = 3;

	// Token: 0x04007637 RID: 30263
	protected EAttributeType StrengthAttributeId = EAttributeType.SpecialEnergy3;

	// Token: 0x04007638 RID: 30264
	protected EAttributeType MaxStrengthAttributeId = EAttributeType.SpecialEnergy3Max;

	// Token: 0x04007639 RID: 30265
	private bool IsNormalState = true;

	// Token: 0x0400763A RID: 30266
	private bool IsFullState = true;

	// Token: 0x0400763B RID: 30267
	protected bool IsFlying;

	// Token: 0x0400763C RID: 30268
	protected bool IsSpeedUp;

	// Token: 0x0400763D RID: 30269
	protected bool IsLock;

	// Token: 0x0400763E RID: 30270
	private float LowEndurancePercent;

	// Token: 0x0400763F RID: 30271
	private float SingleStrengthValue;

	// Token: 0x04007640 RID: 30272
	private int MaxSingleStrengthItemCount = 1;

	// Token: 0x04007641 RID: 30273
	private float TailSpeed = 0.1f;

	// Token: 0x04007642 RID: 30274
	private readonly List<UUIItem> StrengthSingleLineActorList = new List<UUIItem>();

	// Token: 0x04007643 RID: 30275
	private float StrengthCurrentValue;

	// Token: 0x04007644 RID: 30276
	private float MaxStrengthCurrentValue;

	// Token: 0x04007645 RID: 30277
	private float TailStrengthCurrentValue;

	// Token: 0x04007646 RID: 30278
	[Nullable(2)]
	private TimerHandle CloseAnimTimer;

	// Token: 0x04007647 RID: 30279
	[Nullable(2)]
	private CustomPromise CloseAnimPromise;

	// Token: 0x04007648 RID: 30280
	[StaticVariableRuleIgnore]
	private static readonly Stat CloseAnimTimerStat = Stat.Create("StrengthCloseAnim", "", "");
}
