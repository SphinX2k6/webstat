using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FC6 RID: 8134
[NullableContext(1)]
[Nullable(0)]
public class StrengthItem : StrengthItemBase
{
	// Token: 0x0600F544 RID: 62788 RVA: 0x004327B1 File Offset: 0x004309B1
	protected virtual int ResolveChildType(int name)
	{
		return name;
	}

	// Token: 0x0600F545 RID: 62789 RVA: 0x004327B4 File Offset: 0x004309B4
	[NullableContext(2)]
	protected new UUIItem GetItem(int name)
	{
		return base.GetItem(this.ResolveChildType(name));
	}

	// Token: 0x0600F546 RID: 62790 RVA: 0x004327C3 File Offset: 0x004309C3
	[NullableContext(2)]
	protected new UUISprite GetSprite(int name)
	{
		return base.GetSprite(this.ResolveChildType(name));
	}

	// Token: 0x0600F547 RID: 62791 RVA: 0x004327D4 File Offset: 0x004309D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 22;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F548 RID: 62792 RVA: 0x00432AE0 File Offset: 0x00430CE0
	protected override UniTask OnBeforeStartAsync()
	{
		StrengthItem.<OnBeforeStartAsync>d__47 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<StrengthItem.<OnBeforeStartAsync>d__47>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F549 RID: 62793 RVA: 0x00432B24 File Offset: 0x00430D24
	protected override void OnStart()
	{
		this.RootItem.SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
		this.RootItem.SetPivot(new FVector2D(0.5f, 0.5f));
		this.RootItem.SetAnchorOffset(Vector2D.ZeroVector);
		for (int i = 0; i < 5; i++)
		{
			this.AddSingleStrengthItem(i == 0);
		}
		for (int j = 0; j < 1; j++)
		{
			this.AddTemporarySingleStrengthItem(j == 0);
		}
		this.LowEndurancePercent = (float)ConfigCommonParamById.GetIntConfig("LowEndurancePercent").GetValueOrDefault() / 10000f;
		this.SingleStrengthValue = (float)ConfigCommonParamById.GetIntConfig("SingleStrengthValue").GetValueOrDefault();
		this.MaxSingleStrengthItemCount = ConfigCommonParamById.GetIntConfig("MaxSingleStrengthItemCount").GetValueOrDefault(1);
		this.SingleTemporaryStrengthValue = (float)ConfigCommonParamById.GetIntConfig("SingleTemporaryStrengthValue").GetValueOrDefault();
		this.CurrentTemporaryStrengthPercent = 0f;
		this.TargetTemporaryStrengthPercent = 0f;
		this.StrengthVisible = false;
		this.InitUi();
		this.InitAllTweenAnim();
		this.RefreshStrengthPercent();
		this.RefreshTemporaryPercent();
		this.RefreshTemporaryVisible();
		this.RefreshSingleStrengthItemRotation();
		this.RefreshAutoMovingSetting(true);
		this.RefreshAutoMoving();
		this.RefreshVisible();
		base.OnStart();
	}

	// Token: 0x0600F54A RID: 62794 RVA: 0x00432C5A File Offset: 0x00430E5A
	protected virtual void InitUi()
	{
		UUIItem item = this.GetItem(1);
		if (item != null)
		{
			item.SetAlpha(0f);
		}
		UUIItem item2 = this.GetItem(11);
		if (item2 == null)
		{
			return;
		}
		item2.SetAlpha(0f);
	}

	// Token: 0x0600F54B RID: 62795 RVA: 0x00432C8A File Offset: 0x00430E8A
	protected override void OnBeforeDestroy()
	{
		this.IsTemporaryVisible = false;
		this.IsStarted = false;
		this.DestroyCloseAnimTimer();
		this.DestroyFullAnimTimer();
		this.DestroyTempCloseAnimTimer();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F54C RID: 62796 RVA: 0x00432CB4 File Offset: 0x00430EB4
	protected override void OnAddEvents()
	{
		if (Singleton<EventSystem>.Instance.Has<bool>(EEventName.AutoMovingSettingChanged, new Action<bool>(this.AutoMovingSettingChanged)))
		{
			this.OnRemoveEvents();
		}
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.AutoMovingSettingChanged, new Action<bool>(this.AutoMovingSettingChanged));
		ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.Strength, new TValueListener(this.OnStrengthChanged), null);
		ControllerBase<FormationAttributeController>.Instance.AddMaxListener(EFormationAttributeId.Strength, new TValueListener(this.OnStrengthMaxChanged), null);
	}

	// Token: 0x0600F54D RID: 62797 RVA: 0x00432D30 File Offset: 0x00430F30
	protected override void OnRemoveEvents()
	{
		if (Singleton<EventSystem>.Instance.Has<bool>(EEventName.AutoMovingSettingChanged, new Action<bool>(this.AutoMovingSettingChanged)))
		{
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.AutoMovingSettingChanged, new Action<bool>(this.AutoMovingSettingChanged));
		}
		ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.Strength, new TValueListener(this.OnStrengthChanged));
		ControllerBase<FormationAttributeController>.Instance.RemoveMaxListener(EFormationAttributeId.Strength, new TValueListener(this.OnStrengthMaxChanged));
	}

	// Token: 0x0600F54E RID: 62798 RVA: 0x00432DA4 File Offset: 0x00430FA4
	protected override void OnAddEntityEvents()
	{
		BattleUiRoleData roleData = this.RoleData;
		BaseTagComponent baseTagComponent = (roleData != null) ? roleData.GameplayTagComponent : null;
		if (baseTagComponent == null)
		{
			return;
		}
		base.ListenForTagAddOrRemove(baseTagComponent, new int?(GameplayTagDefine.EGameplayTagId["功能.人物属性.体力增益"]), new Action<int, bool>(this.OnStrengthBuff));
		base.ListenForTagAddOrRemove(baseTagComponent, new int?(GameplayTagDefine.EGameplayTagId["功能.人物属性.体力减益"]), new Action<int, bool>(this.OnStrengthDeBuff));
		base.ListenForTagAddOrRemove(baseTagComponent, new int?(GameplayTagDefine.EGameplayTagId["功能.人物属性.体力禁用"]), new Action<int, bool>(this.OnStrengthDisable));
		base.ListenForTagAddOrRemove(baseTagComponent, new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFFID.体力恢复"]), new Action<int, bool>(this.OnStrengthRecover));
		base.ListenForTagAddOrRemove(baseTagComponent, new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.保持持续奔跑"]), new Action<int, bool>(this.OnEnterAutoMoving));
	}

	// Token: 0x0600F54F RID: 62799 RVA: 0x00432E8C File Offset: 0x0043108C
	protected override void OnRefreshRoleData()
	{
		if (this.RoleData == null)
		{
			return;
		}
		this.RefreshBuffState();
		this.RefreshEnableState();
		this.RefreshTemporaryVisible();
		BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
		this.HasAutoMovingTag = (gameplayTagComponent != null && gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.保持持续奔跑"]));
	}

	// Token: 0x0600F550 RID: 62800 RVA: 0x00432EE0 File Offset: 0x004310E0
	protected override void OnEnableStrengthItem(bool b)
	{
		if (b)
		{
			this.OnAddEvents();
			this.RefreshStrengthPercent();
			this.RefreshTemporaryPercent();
			this.RefreshStrengthState();
			this.RefreshTemporaryVisible();
			this.RefreshSingleStrengthItemRotation();
			this.RefreshAutoMovingSetting(true);
			this.RefreshAutoMoving();
			this.RefreshVisible();
			return;
		}
		this.OnRemoveEvents();
		this.RefreshVisible();
	}

	// Token: 0x0600F551 RID: 62801 RVA: 0x00432F34 File Offset: 0x00431134
	public override void Tick(float delta)
	{
		this.LerpTemporaryPercent(delta);
		this.RefreshAutoMoving();
	}

	// Token: 0x0600F552 RID: 62802 RVA: 0x00432F43 File Offset: 0x00431143
	private void AutoMovingSettingChanged(bool enable)
	{
		this.RefreshAutoMovingSetting(false);
		this.RefreshAutoMoving();
	}

	// Token: 0x0600F553 RID: 62803 RVA: 0x00432F54 File Offset: 0x00431154
	private void RefreshStrengthPercent()
	{
		this.StrengthCurrentValue = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength);
		this.MaxStrengthBaseValue = ControllerBase<FormationAttributeController>.Instance.GetBaseMax(EFormationAttributeId.Strength);
		this.MaxStrengthCurrentValue = ControllerBase<FormationAttributeController>.Instance.GetMax(EFormationAttributeId.Strength);
		this.SetStrengthPercent(this.StrengthCurrentValue, this.MaxStrengthBaseValue);
	}

	// Token: 0x0600F554 RID: 62804 RVA: 0x00432FA8 File Offset: 0x004311A8
	private void RefreshSingleStrengthItemRotation()
	{
		float maxStrength = this.MaxStrengthCurrentValue - this.MaxStrengthBaseValue;
		this.RefreshSingleStrengthItemRotationInner(this.MaxStrengthBaseValue);
		this.RefreshSingleTemporaryStrengthItemRotation(maxStrength);
		this.RefreshSingleTemporaryStrengthItemVisible(maxStrength);
	}

	// Token: 0x0600F555 RID: 62805 RVA: 0x00432FE0 File Offset: 0x004311E0
	private void RefreshStrengthState()
	{
		if (this.CanRefreshTemporaryStrength())
		{
			if (this.GetTemporaryStrength() > 0f)
			{
				this.SetTemporaryVisible(true);
				this.PlayTemporaryAnim(true);
			}
			else
			{
				this.PlayTemporaryAnim(false);
			}
		}
		else
		{
			this.SetTemporaryVisible(false);
		}
		if (this.StrengthCurrentValue >= this.MaxStrengthCurrentValue)
		{
			if (this.StrengthState == StrengthItem.EState.Full)
			{
				return;
			}
			this.StrengthState = StrengthItem.EState.Full;
			this.SetNone(false);
			this.StopNoneAnim();
			this.SetNormal(true);
			this.PlayFullAnim();
			return;
		}
		else if (this.StrengthCurrentValue <= 0f)
		{
			if (this.StrengthState == StrengthItem.EState.None)
			{
				return;
			}
			this.StrengthState = StrengthItem.EState.None;
			this.SetNone(true);
			this.PlayNoneAnim();
			return;
		}
		else
		{
			bool flag = this.StrengthCurrentValue / this.MaxStrengthCurrentValue > this.LowEndurancePercent;
			StrengthItem.EState estate = flag ? StrengthItem.EState.Normal : StrengthItem.EState.Low;
			if (this.StrengthState == estate)
			{
				return;
			}
			this.StrengthState = estate;
			this.SetNone(false);
			this.StopNoneAnim();
			this.SetNormal(flag);
			this.StrengthVisible = true;
			this.RefreshVisible();
			this.PlayStartAnim();
			return;
		}
	}

	// Token: 0x0600F556 RID: 62806 RVA: 0x004330DD File Offset: 0x004312DD
	private void OnStrengthChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
	{
		this.RefreshStrengthPercent();
		this.RefreshTemporaryPercent();
		this.RefreshStrengthState();
	}

	// Token: 0x0600F557 RID: 62807 RVA: 0x004330F1 File Offset: 0x004312F1
	private void OnStrengthMaxChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
	{
		this.RefreshStrengthPercent();
		this.RefreshSingleStrengthItemRotation();
	}

	// Token: 0x0600F558 RID: 62808 RVA: 0x004330FF File Offset: 0x004312FF
	private void OnStrengthBuff(int tagId, bool tagExists)
	{
		this.SetBuff(tagExists ? StrengthItem.EStrengthBuffType.Buff : StrengthItem.EStrengthBuffType.None);
	}

	// Token: 0x0600F559 RID: 62809 RVA: 0x0043310E File Offset: 0x0043130E
	private void OnStrengthDeBuff(int tagId, bool tagExists)
	{
		this.SetBuff(tagExists ? StrengthItem.EStrengthBuffType.DeBuff : StrengthItem.EStrengthBuffType.None);
	}

	// Token: 0x0600F55A RID: 62810 RVA: 0x0043311D File Offset: 0x0043131D
	private void OnStrengthDisable(int tagId, bool tagExists)
	{
		this.SetEnable(!tagExists);
	}

	// Token: 0x0600F55B RID: 62811 RVA: 0x00433129 File Offset: 0x00431329
	private void OnStrengthRecover(int tagId, bool tagExists)
	{
		this.PlayPickUpAnim();
	}

	// Token: 0x0600F55C RID: 62812 RVA: 0x00433131 File Offset: 0x00431331
	private void OnEnterAutoMoving(int tagId, bool tagExists)
	{
		this.HasAutoMovingTag = tagExists;
	}

	// Token: 0x0600F55D RID: 62813 RVA: 0x0043313C File Offset: 0x0043133C
	protected virtual void SetNormal(bool bNormal)
	{
		if (this.IsNormalState == bNormal)
		{
			return;
		}
		this.IsNormalState = bNormal;
		UUIItem item = this.GetItem(0);
		UUIItem item2 = this.GetItem(1);
		if (item.IsUIActiveSelf() == bNormal)
		{
			item.SetUIActive(!bNormal);
		}
		if (item.IsUIActiveSelf() != bNormal)
		{
			item2.SetUIActive(bNormal);
		}
	}

	// Token: 0x0600F55E RID: 62814 RVA: 0x00433190 File Offset: 0x00431390
	private void SetBuff(StrengthItem.EStrengthBuffType buffType)
	{
		if (this.BuffType == buffType)
		{
			return;
		}
		this.BuffType = buffType;
		UUIItem item = this.GetItem(4);
		UUIItem item2 = this.GetItem(5);
		switch (buffType)
		{
		case StrengthItem.EStrengthBuffType.None:
			if (item.IsUIActiveSelf())
			{
				item.SetUIActive(false);
			}
			if (item2.IsUIActiveSelf())
			{
				item2.SetUIActive(false);
				return;
			}
			break;
		case StrengthItem.EStrengthBuffType.Buff:
			if (!item.IsUIActiveSelf())
			{
				item.SetUIActive(true);
			}
			if (item2.IsUIActiveSelf())
			{
				item2.SetUIActive(false);
				return;
			}
			break;
		case StrengthItem.EStrengthBuffType.DeBuff:
			if (item.IsUIActiveSelf())
			{
				item.SetUIActive(false);
			}
			if (!item2.IsUIActiveSelf())
			{
				item2.SetUIActive(true);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x0600F55F RID: 62815 RVA: 0x00433230 File Offset: 0x00431430
	protected void SetEnable(bool bEnable)
	{
		UUIItem item = this.GetItem(6);
		if (item.IsUIActiveSelf() != bEnable)
		{
			return;
		}
		item.SetUIActive(!bEnable);
	}

	// Token: 0x0600F560 RID: 62816 RVA: 0x0043325C File Offset: 0x0043145C
	protected void SetNone(bool bNone)
	{
		UUIItem item = this.GetItem(2);
		if (item.IsUIActiveSelf() == bNone)
		{
			return;
		}
		item.SetUIActive(bNone);
	}

	// Token: 0x0600F561 RID: 62817 RVA: 0x00433284 File Offset: 0x00431484
	protected bool SetStrengthPercent(float strength, float maxStrength)
	{
		if (this.Strength == strength)
		{
			return false;
		}
		this.Strength = strength;
		float fillAmount = (maxStrength <= 0f) ? 0f : (strength / maxStrength);
		this.GetSprite(8).SetFillAmount(fillAmount);
		this.GetSprite(7).SetFillAmount(fillAmount);
		this.RefreshSingleStrengthItemVisible(maxStrength);
		return true;
	}

	// Token: 0x0600F562 RID: 62818 RVA: 0x004332D8 File Offset: 0x004314D8
	private void RefreshSingleStrengthItemRotationInner(float maxStrength)
	{
		int num = (int)Math.Floor((double)(maxStrength / this.SingleStrengthValue));
		if (num > this.MaxSingleStrengthItemCount)
		{
			num = this.MaxSingleStrengthItemCount;
		}
		float num2 = 360f / (float)num;
		float num3 = 0f;
		for (int i = 0; i < num; i++)
		{
			UUIItem uuiitem = (i < this.StrengthSingleLineActorList.Count) ? this.StrengthSingleLineActorList[i] : this.AddSingleStrengthItem(false);
			this.RotationCache.Yaw = num3;
			uuiitem.SetUIRelativeRotation(this.RotationCache);
			num3 += num2;
		}
	}

	// Token: 0x0600F563 RID: 62819 RVA: 0x00433360 File Offset: 0x00431560
	private void RefreshSingleStrengthItemVisible(float maxStrength)
	{
		int num = (int)Math.Floor((double)(maxStrength / this.SingleStrengthValue));
		if (num > this.MaxSingleStrengthItemCount)
		{
			num = this.MaxSingleStrengthItemCount;
		}
		for (int i = 0; i < this.StrengthSingleLineActorList.Count; i++)
		{
			bool flag = i < num;
			UUIItem uuiitem = this.StrengthSingleLineActorList[i];
			if (uuiitem.IsUIActiveSelf() != flag)
			{
				uuiitem.SetUIActive(flag);
			}
		}
	}

	// Token: 0x0600F564 RID: 62820 RVA: 0x004333C8 File Offset: 0x004315C8
	private UUIItem AddSingleStrengthItem(bool isFirst = false)
	{
		UUIItem item = this.GetItem(11);
		UUIItem item2 = this.GetItem(10);
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

	// Token: 0x0600F565 RID: 62821 RVA: 0x00433424 File Offset: 0x00431624
	private void RefreshBuffState()
	{
		BattleUiRoleData roleData = this.RoleData;
		bool flag;
		if (roleData == null)
		{
			flag = false;
		}
		else
		{
			BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
			flag = ((gameplayTagComponent != null) ? new bool?(gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.人物属性.体力增益"])) : null).GetValueOrDefault();
		}
		if (flag)
		{
			this.SetBuff(StrengthItem.EStrengthBuffType.Buff);
			return;
		}
		BattleUiRoleData roleData2 = this.RoleData;
		bool flag2;
		if (roleData2 == null)
		{
			flag2 = false;
		}
		else
		{
			BaseTagComponent gameplayTagComponent2 = roleData2.GameplayTagComponent;
			flag2 = ((gameplayTagComponent2 != null) ? new bool?(gameplayTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["功能.人物属性.体力减益"])) : null).GetValueOrDefault();
		}
		if (flag2)
		{
			this.SetBuff(StrengthItem.EStrengthBuffType.DeBuff);
			return;
		}
		this.SetBuff(StrengthItem.EStrengthBuffType.None);
	}

	// Token: 0x0600F566 RID: 62822 RVA: 0x004334D0 File Offset: 0x004316D0
	private void RefreshEnableState()
	{
		BattleUiRoleData roleData = this.RoleData;
		bool? flag;
		if (roleData == null)
		{
			flag = null;
		}
		else
		{
			BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
			flag = ((gameplayTagComponent != null) ? new bool?(gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.人物属性.体力禁用"])) : null);
		}
		bool? flag2 = flag;
		bool valueOrDefault = flag2.GetValueOrDefault();
		this.SetEnable(!valueOrDefault);
	}

	// Token: 0x0600F567 RID: 62823 RVA: 0x00433534 File Offset: 0x00431734
	private void RefreshTemporaryPercent()
	{
		if (!this.CanRefreshTemporaryStrength())
		{
			return;
		}
		float strength = this.StrengthCurrentValue - this.MaxStrengthBaseValue;
		float maxStrength = this.MaxStrengthCurrentValue - this.MaxStrengthBaseValue;
		this.SetTemporaryStrengthPercent(strength, maxStrength);
	}

	// Token: 0x0600F568 RID: 62824 RVA: 0x0043356E File Offset: 0x0043176E
	private void RefreshTemporaryVisible()
	{
		this.PlayTemporaryAnim(this.CanRefreshTemporaryStrength());
	}

	// Token: 0x0600F569 RID: 62825 RVA: 0x0043357C File Offset: 0x0043177C
	private bool CanRefreshTemporaryStrength()
	{
		return this.GetTemporaryStrength() > 0f || this.MaxStrengthCurrentValue > this.MaxStrengthBaseValue;
	}

	// Token: 0x0600F56A RID: 62826 RVA: 0x0043359B File Offset: 0x0043179B
	private float GetTemporaryStrength()
	{
		return this.StrengthCurrentValue - this.MaxStrengthBaseValue;
	}

	// Token: 0x0600F56B RID: 62827 RVA: 0x004335AC File Offset: 0x004317AC
	private void SetTemporaryVisible(bool bVisible)
	{
		UUIItem item = this.GetItem(3);
		if (item.IsUIActiveSelf() != bVisible)
		{
			item.SetUIActive(bVisible);
		}
	}

	// Token: 0x0600F56C RID: 62828 RVA: 0x004335D1 File Offset: 0x004317D1
	private void PlayTemporaryAnim(bool bVisible)
	{
		if (this.IsTemporaryVisible == bVisible)
		{
			return;
		}
		this.IsTemporaryVisible = bVisible;
		if (bVisible)
		{
			this.StopTemporaryCloseAnim();
			this.PlayTemporaryStartAnim();
			return;
		}
		this.StopTemporaryStartAnim();
		this.PlayTemporaryCloseAnim();
	}

	// Token: 0x0600F56D RID: 62829 RVA: 0x00433600 File Offset: 0x00431800
	private void SetTemporaryStrengthPercent(float strength, float maxStrength)
	{
		if (this.TemporaryStrength == strength)
		{
			return;
		}
		this.TargetTemporaryStrengthPercent = ((maxStrength <= 0f) ? 0f : (strength / maxStrength));
		this.TemporaryStrength = strength;
		this.RefreshSingleTemporaryStrengthItemVisible(maxStrength);
	}

	// Token: 0x0600F56E RID: 62830 RVA: 0x00433634 File Offset: 0x00431834
	private void RefreshSingleTemporaryStrengthItemRotation(float maxStrength)
	{
		int num = (int)Math.Floor((double)(maxStrength / this.SingleTemporaryStrengthValue));
		if (num > this.MaxSingleStrengthItemCount)
		{
			num = this.MaxSingleStrengthItemCount;
		}
		float num2 = 360f / (float)num;
		float num3 = 0f;
		for (int i = 0; i < num; i++)
		{
			UUIItem uuiitem = (i < this.TemporaryStrengthSingleLineActorList.Count) ? this.TemporaryStrengthSingleLineActorList[i] : this.AddTemporarySingleStrengthItem(false);
			this.RotationCache.Yaw = num3;
			uuiitem.SetUIRelativeRotation(this.RotationCache);
			num3 += num2;
		}
	}

	// Token: 0x0600F56F RID: 62831 RVA: 0x004336BC File Offset: 0x004318BC
	private void RefreshSingleTemporaryStrengthItemVisible(float maxStrength)
	{
		int num = (int)Math.Floor((double)(maxStrength / this.SingleTemporaryStrengthValue));
		if (num > this.MaxSingleStrengthItemCount)
		{
			num = this.MaxSingleStrengthItemCount;
		}
		for (int i = 0; i < this.TemporaryStrengthSingleLineActorList.Count; i++)
		{
			bool flag = i < num;
			UUIItem uuiitem = this.TemporaryStrengthSingleLineActorList[i];
			if (uuiitem.IsUIActiveSelf() != flag)
			{
				uuiitem.SetUIActive(flag);
			}
		}
	}

	// Token: 0x0600F570 RID: 62832 RVA: 0x00433724 File Offset: 0x00431924
	private UUIItem AddTemporarySingleStrengthItem(bool isFirst = false)
	{
		UUIItem item = this.GetItem(13);
		UUIItem item2 = this.GetItem(12);
		UUIItem uuiitem;
		if (isFirst)
		{
			uuiitem = item2;
		}
		else
		{
			uuiitem = (Singleton<LguiUtil>.Instance.DuplicateActor(item2.GetOwner(), item).GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
		}
		this.TemporaryStrengthSingleLineActorList.Add(uuiitem);
		return uuiitem;
	}

	// Token: 0x0600F571 RID: 62833 RVA: 0x00433780 File Offset: 0x00431980
	private void LerpTemporaryPercent(float delta)
	{
		if (!base.GetActive() || this.CurrentTemporaryStrengthPercent == this.TargetTemporaryStrengthPercent)
		{
			return;
		}
		this.LerpTime += delta;
		this.CurrentTemporaryStrengthPercent = Singleton<MathUtils>.Instance.Lerp(this.CurrentTemporaryStrengthPercent, this.TargetTemporaryStrengthPercent, this.LerpTime / 300f);
		this.GetSprite(9).SetFillAmount(this.CurrentTemporaryStrengthPercent);
		if (this.LerpTime >= 300f)
		{
			this.LerpTime = 0f;
		}
	}

	// Token: 0x0600F572 RID: 62834 RVA: 0x00433806 File Offset: 0x00431A06
	private void InitAllTweenAnim()
	{
		base.InitTweenAnim(14);
		base.InitTweenAnim(15);
		base.InitTweenAnim(16);
		base.InitTweenAnim(17);
		base.InitTweenAnim(18);
		base.InitTweenAnim(19);
		base.InitTweenAnim(20);
	}

	// Token: 0x0600F573 RID: 62835 RVA: 0x00433840 File Offset: 0x00431A40
	private void PlayFullAnim()
	{
		base.PlayTweenAnim(16);
		this.DestroyFullAnimTimer();
		this.FullAnimTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.FullAnimTimer = null;
			this.PlayCloseAnim();
			if (this.GetItem(3).IsUIActiveSelf())
			{
				this.PlayTemporaryCloseAnim();
			}
		}, 300f, StrengthItem.FullAnimTimerStat, null, true, 1f);
		this.IsTemporaryVisible = false;
		this.IsStarted = false;
	}

	// Token: 0x0600F574 RID: 62836 RVA: 0x00433896 File Offset: 0x00431A96
	private void StopFullAnim()
	{
		this.DestroyFullAnimTimer();
		base.StopTweenAnim(16);
	}

	// Token: 0x0600F575 RID: 62837 RVA: 0x004338A6 File Offset: 0x00431AA6
	private void DestroyFullAnimTimer()
	{
		if (this.FullAnimTimer != null)
		{
			TimerSystem.Instance.Remove(this.FullAnimTimer);
			this.FullAnimTimer = null;
		}
	}

	// Token: 0x0600F576 RID: 62838 RVA: 0x004338C8 File Offset: 0x00431AC8
	private void PlayStartAnim()
	{
		if (this.IsStarted)
		{
			return;
		}
		this.StopFullAnim();
		this.StopCloseAnim();
		base.PlayTweenAnim(14);
		this.IsStarted = true;
	}

	// Token: 0x0600F577 RID: 62839 RVA: 0x004338EE File Offset: 0x00431AEE
	private void PlayNoneAnim()
	{
		base.PlayTweenAnim(17);
	}

	// Token: 0x0600F578 RID: 62840 RVA: 0x004338F8 File Offset: 0x00431AF8
	private void StopNoneAnim()
	{
		base.StopTweenAnim(17);
	}

	// Token: 0x0600F579 RID: 62841 RVA: 0x00433904 File Offset: 0x00431B04
	private void PlayCloseAnim()
	{
		base.PlayTweenAnim(15);
		this.DestroyCloseAnimTimer();
		this.CloseAnimTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.CloseAnimTimer = null;
			this.StrengthVisible = false;
			this.RefreshVisible();
		}, 250f, StrengthItem.CloseAnimTimerStat, null, true, 1f);
		this.IsStarted = false;
	}

	// Token: 0x0600F57A RID: 62842 RVA: 0x00433953 File Offset: 0x00431B53
	private void StopCloseAnim()
	{
		this.DestroyCloseAnimTimer();
		base.StopTweenAnim(15);
	}

	// Token: 0x0600F57B RID: 62843 RVA: 0x00433963 File Offset: 0x00431B63
	private void DestroyCloseAnimTimer()
	{
		if (this.CloseAnimTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseAnimTimer);
			this.CloseAnimTimer = null;
		}
	}

	// Token: 0x0600F57C RID: 62844 RVA: 0x00433985 File Offset: 0x00431B85
	private void PlayTemporaryStartAnim()
	{
		base.PlayTweenAnim(19);
	}

	// Token: 0x0600F57D RID: 62845 RVA: 0x0043398F File Offset: 0x00431B8F
	private void StopTemporaryStartAnim()
	{
		base.StopTweenAnim(19);
	}

	// Token: 0x0600F57E RID: 62846 RVA: 0x00433999 File Offset: 0x00431B99
	private void PlayTemporaryCloseAnim()
	{
		base.PlayTweenAnim(20);
		this.DestroyTempCloseAnimTimer();
		this.TempCloseAnimTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.TempCloseAnimTimer = null;
			this.SetTemporaryVisible(false);
			this.IsTemporaryVisible = false;
		}, 330f, StrengthItem.TempCloseAnimTimerStat, null, true, 1f);
	}

	// Token: 0x0600F57F RID: 62847 RVA: 0x004339D6 File Offset: 0x00431BD6
	private void StopTemporaryCloseAnim()
	{
		this.DestroyTempCloseAnimTimer();
		base.StopTweenAnim(20);
	}

	// Token: 0x0600F580 RID: 62848 RVA: 0x004339E6 File Offset: 0x00431BE6
	private void DestroyTempCloseAnimTimer()
	{
		if (this.TempCloseAnimTimer != null)
		{
			TimerSystem.Instance.Remove(this.TempCloseAnimTimer);
			this.TempCloseAnimTimer = null;
		}
	}

	// Token: 0x0600F581 RID: 62849 RVA: 0x00433A08 File Offset: 0x00431C08
	private void PlayPickUpAnim()
	{
		base.PlayTweenAnim(18);
	}

	// Token: 0x0600F582 RID: 62850 RVA: 0x00433A12 File Offset: 0x00431C12
	private void RefreshVisible()
	{
		this.SetActive((this.StrengthVisible || this.AutoMovingVisible) && this.IsEnableStrengthItem);
	}

	// Token: 0x0600F583 RID: 62851 RVA: 0x00433A34 File Offset: 0x00431C34
	private void RefreshAutoMovingSetting(bool isStart = false)
	{
		BattleUiFormationData formationData = ModelBase<BattleUiModel>.Instance.FormationData;
		bool flag = formationData != null && formationData.AutoMovingSettingEnable;
		if (this.AutoMovingSettingEnable == flag)
		{
			return;
		}
		if (flag)
		{
			this.AutoMovingProgressAnimTime = ConfigCommonParamById.GetIntConfig("ConstantSprintProgressAnimTime").GetValueOrDefault(1000);
		}
		else
		{
			AutoMovingItem autoMovingItem = this.AutoMovingItem;
			if (autoMovingItem != null)
			{
				autoMovingItem.SetVisible(false);
			}
		}
		this.AutoMovingSettingEnable = flag;
		this.AutoMovingVisible = flag;
		if (!isStart)
		{
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F584 RID: 62852 RVA: 0x00433AB0 File Offset: 0x00431CB0
	private void RefreshAutoMoving()
	{
		if (!this.AutoMovingSettingEnable)
		{
			return;
		}
		BattleUiRoleData roleData = this.RoleData;
		CharacterInputComponent characterInputComponent;
		if (roleData == null)
		{
			characterInputComponent = null;
		}
		else
		{
			EntityHandle entityHandle = roleData.EntityHandle;
			if (entityHandle == null)
			{
				characterInputComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				characterInputComponent = ((entity != null) ? entity.GetComponent<CharacterInputComponent>() : null);
			}
		}
		CharacterInputComponent characterInputComponent2 = characterInputComponent;
		if (characterInputComponent2 == null)
		{
			return;
		}
		if (this.HasAutoMovingTag)
		{
			this.SetAutoMovingState(StrengthItem.EAutoMovingState.AutoMoving, 1f);
			return;
		}
		InputContinuously autoMovingConfig = characterInputComponent2.GetAutoMovingConfig();
		float num = Math.Max(0f, autoMovingConfig.GetDuration() - autoMovingConfig.GetCurrentTime());
		if (num > (float)this.AutoMovingProgressAnimTime)
		{
			this.SetAutoMovingState(StrengthItem.EAutoMovingState.None, 0f);
			return;
		}
		float percent = 1f - num / (float)this.AutoMovingProgressAnimTime;
		this.SetAutoMovingState(StrengthItem.EAutoMovingState.Moving, percent);
	}

	// Token: 0x0600F585 RID: 62853 RVA: 0x00433B58 File Offset: 0x00431D58
	private void SetAutoMovingState(StrengthItem.EAutoMovingState state, float percent = 0f)
	{
		if (this.AutoMovingItem == null)
		{
			return;
		}
		if (this.AutoMovingState == state)
		{
			if (this.AutoMovingState == StrengthItem.EAutoMovingState.Moving)
			{
				this.AutoMovingItem.SetPercent(percent);
			}
			return;
		}
		this.AutoMovingState = state;
		this.AutoMovingItem.SetVisible(state > StrengthItem.EAutoMovingState.None);
		this.AutoMovingItem.SetPercent(percent);
		this.AutoMovingItem.SetChangeColor(state == StrengthItem.EAutoMovingState.AutoMoving);
	}

	// Token: 0x0400768C RID: 30348
	private const int PRELOAD_SINGLE_STRENGTH_ITEM_COUNT = 5;

	// Token: 0x0400768D RID: 30349
	private const int PRELOAD_SINGLE_TEMPORARY_STRENGTH_ITEM_COUNT = 1;

	// Token: 0x0400768E RID: 30350
	private const float TEMPORARY_STRENGTH_LERP_TIME = 300f;

	// Token: 0x0400768F RID: 30351
	private const float CLOSE_ANIM_TIME = 250f;

	// Token: 0x04007690 RID: 30352
	private const float FULL_ANIM_TIME = 300f;

	// Token: 0x04007691 RID: 30353
	private const float TEMP_CLOSE_ANIM_TIME = 330f;

	// Token: 0x04007692 RID: 30354
	protected bool IsNormalState = true;

	// Token: 0x04007693 RID: 30355
	private StrengthItem.EState StrengthState;

	// Token: 0x04007694 RID: 30356
	private StrengthItem.EStrengthBuffType BuffType;

	// Token: 0x04007695 RID: 30357
	private readonly List<UUIItem> StrengthSingleLineActorList = new List<UUIItem>();

	// Token: 0x04007696 RID: 30358
	private readonly List<UUIItem> TemporaryStrengthSingleLineActorList = new List<UUIItem>();

	// Token: 0x04007697 RID: 30359
	private FRotator RotationCache = new FRotator(0f, 0f, 0f);

	// Token: 0x04007698 RID: 30360
	private float Strength;

	// Token: 0x04007699 RID: 30361
	private float TemporaryStrength;

	// Token: 0x0400769A RID: 30362
	private float SingleStrengthValue;

	// Token: 0x0400769B RID: 30363
	private int MaxSingleStrengthItemCount = 1;

	// Token: 0x0400769C RID: 30364
	private float SingleTemporaryStrengthValue;

	// Token: 0x0400769D RID: 30365
	private float LerpTime;

	// Token: 0x0400769E RID: 30366
	private float CurrentTemporaryStrengthPercent;

	// Token: 0x0400769F RID: 30367
	private float TargetTemporaryStrengthPercent;

	// Token: 0x040076A0 RID: 30368
	private bool IsTemporaryVisible;

	// Token: 0x040076A1 RID: 30369
	private bool IsStarted;

	// Token: 0x040076A2 RID: 30370
	[Nullable(2)]
	private TimerHandle CloseAnimTimer;

	// Token: 0x040076A3 RID: 30371
	[Nullable(2)]
	private TimerHandle FullAnimTimer;

	// Token: 0x040076A4 RID: 30372
	[Nullable(2)]
	private TimerHandle TempCloseAnimTimer;

	// Token: 0x040076A5 RID: 30373
	[StaticVariableRuleIgnore]
	private static readonly Stat CloseAnimTimerStat = Stat.Create("StrengthCloseAnim", "", "");

	// Token: 0x040076A6 RID: 30374
	[StaticVariableRuleIgnore]
	private static readonly Stat FullAnimTimerStat = Stat.Create("StrengthFullAnim", "", "");

	// Token: 0x040076A7 RID: 30375
	[StaticVariableRuleIgnore]
	private static readonly Stat TempCloseAnimTimerStat = Stat.Create("StrengthTempCloseAnim", "", "");

	// Token: 0x040076A8 RID: 30376
	private float StrengthCurrentValue;

	// Token: 0x040076A9 RID: 30377
	private float MaxStrengthBaseValue;

	// Token: 0x040076AA RID: 30378
	private float MaxStrengthCurrentValue;

	// Token: 0x040076AB RID: 30379
	private float LowEndurancePercent;

	// Token: 0x040076AC RID: 30380
	private bool AutoMovingSettingEnable;

	// Token: 0x040076AD RID: 30381
	private int AutoMovingProgressAnimTime = 1000;

	// Token: 0x040076AE RID: 30382
	[Nullable(2)]
	private AutoMovingItem AutoMovingItem;

	// Token: 0x040076AF RID: 30383
	private StrengthItem.EAutoMovingState AutoMovingState;

	// Token: 0x040076B0 RID: 30384
	private bool HasAutoMovingTag;

	// Token: 0x040076B1 RID: 30385
	private bool StrengthVisible;

	// Token: 0x040076B2 RID: 30386
	private bool AutoMovingVisible;

	// Token: 0x02008351 RID: 33617
	[NullableContext(0)]
	public enum EChildType
	{
		// Token: 0x0402C88F RID: 182415
		LowItem,
		// Token: 0x0402C890 RID: 182416
		NormalItem,
		// Token: 0x0402C891 RID: 182417
		NoneItem,
		// Token: 0x0402C892 RID: 182418
		TemporaryItem,
		// Token: 0x0402C893 RID: 182419
		BuffItem,
		// Token: 0x0402C894 RID: 182420
		DeBuffItem,
		// Token: 0x0402C895 RID: 182421
		DisableItem,
		// Token: 0x0402C896 RID: 182422
		LowBarSprite,
		// Token: 0x0402C897 RID: 182423
		NormalBarSprite,
		// Token: 0x0402C898 RID: 182424
		TemporaryBarSprite,
		// Token: 0x0402C899 RID: 182425
		StrengthSingleLineItem,
		// Token: 0x0402C89A RID: 182426
		StrengthLineItem,
		// Token: 0x0402C89B RID: 182427
		TemporarySingleLineItem,
		// Token: 0x0402C89C RID: 182428
		TemporaryLineItem,
		// Token: 0x0402C89D RID: 182429
		AnimStart,
		// Token: 0x0402C89E RID: 182430
		AnimClose,
		// Token: 0x0402C89F RID: 182431
		AnimFull,
		// Token: 0x0402C8A0 RID: 182432
		AnimNone,
		// Token: 0x0402C8A1 RID: 182433
		AnimPickUp,
		// Token: 0x0402C8A2 RID: 182434
		AnimTempStart,
		// Token: 0x0402C8A3 RID: 182435
		AnimTempClose,
		// Token: 0x0402C8A4 RID: 182436
		AutoMovingItem
	}

	// Token: 0x02008352 RID: 33618
	[NullableContext(0)]
	private enum EState
	{
		// Token: 0x0402C8A6 RID: 182438
		Full,
		// Token: 0x0402C8A7 RID: 182439
		Normal,
		// Token: 0x0402C8A8 RID: 182440
		Low,
		// Token: 0x0402C8A9 RID: 182441
		None
	}

	// Token: 0x02008353 RID: 33619
	[NullableContext(0)]
	private enum EAutoMovingState
	{
		// Token: 0x0402C8AB RID: 182443
		None,
		// Token: 0x0402C8AC RID: 182444
		Moving,
		// Token: 0x0402C8AD RID: 182445
		AutoMoving
	}

	// Token: 0x02008354 RID: 33620
	[NullableContext(0)]
	private enum EStrengthBuffType
	{
		// Token: 0x0402C8AF RID: 182447
		None,
		// Token: 0x0402C8B0 RID: 182448
		Buff,
		// Token: 0x0402C8B1 RID: 182449
		DeBuff
	}
}
