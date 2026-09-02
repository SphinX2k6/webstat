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

// Token: 0x02001FC5 RID: 8133
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleStrengthItem : StrengthItemBase
{
	// Token: 0x0600F51D RID: 62749 RVA: 0x0043199F File Offset: 0x0042FB9F
	protected override string GetResourceId()
	{
		return "UiItem_EnergyRide";
	}

	// Token: 0x0600F51E RID: 62750 RVA: 0x004319A8 File Offset: 0x0042FBA8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F51F RID: 62751 RVA: 0x00431B40 File Offset: 0x0042FD40
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleStrengthItem.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleStrengthItem.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F520 RID: 62752 RVA: 0x00431B84 File Offset: 0x0042FD84
	protected override void OnStart()
	{
		for (int i = 0; i < 3; i++)
		{
			this.AddSingleStrengthItem(i == 0);
		}
		this.LowEndurancePercent = (float)ConfigCommonParamById.GetIntConfig("LowEndurancePercent").GetValueOrDefault() / 10000f;
		this.SingleStrengthValue = (float)ConfigCommonParamById.GetIntConfig("MotorcycleSingleStrengthValue").GetValueOrDefault();
		this.MaxSingleStrengthItemCount = ConfigCommonParamById.GetIntConfig("MotorcycleMaxSingleStrengthItemCount").GetValueOrDefault(1);
		base.InitTweenAnim(7);
		base.InitTweenAnim(8);
		base.OnStart();
		this.CurBarVisible = false;
		base.GetItem(9).SetAlpha(0f);
		this.RefreshAutoMovingSetting(true);
		this.RefreshAutoMovingTag();
		this.RefreshAutoMoving(true);
		this.RefreshStrengthPercent(true);
	}

	// Token: 0x0600F521 RID: 62753 RVA: 0x00431C44 File Offset: 0x0042FE44
	protected override UniTask OnBeforeHideAsync()
	{
		MotorcycleStrengthItem.<OnBeforeHideAsync>d__24 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<MotorcycleStrengthItem.<OnBeforeHideAsync>d__24>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F522 RID: 62754 RVA: 0x00431C87 File Offset: 0x0042FE87
	protected override void OnBeforeDestroy()
	{
		this.DestroyCloseAnimTimer();
		this.DestroyAutoMoving();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F523 RID: 62755 RVA: 0x00431C9C File Offset: 0x0042FE9C
	protected override void OnAddEvents()
	{
		ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthChanged), null);
		ControllerBase<FormationAttributeController>.Instance.AddMaxListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthMaxChanged), null);
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.MotorcycleAutoAcceleratorSettingChanged, new Action<bool>(this.AutoMovingSettingChanged));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.MotorcycleAutoNitrogenSettingChanged, new Action<bool>(this.AutoMovingSettingChanged));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
	}

	// Token: 0x0600F524 RID: 62756 RVA: 0x00431D30 File Offset: 0x0042FF30
	protected override void OnRemoveEvents()
	{
		ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthChanged));
		ControllerBase<FormationAttributeController>.Instance.RemoveMaxListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthMaxChanged));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.MotorcycleAutoAcceleratorSettingChanged, new Action<bool>(this.AutoMovingSettingChanged));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.MotorcycleAutoNitrogenSettingChanged, new Action<bool>(this.AutoMovingSettingChanged));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
	}

	// Token: 0x0600F525 RID: 62757 RVA: 0x00431DC4 File Offset: 0x0042FFC4
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
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.驾驶期间"]), new Action<int, bool>(this.OnMotorcycleTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.氮气.无限氮气"]), new Action<int, bool>(this.OnLockTagChanged));
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.隐藏氮气条"]), new Action<int, bool>(this.OnHideTagChanged));
	}

	// Token: 0x0600F526 RID: 62758 RVA: 0x00431E60 File Offset: 0x00430060
	protected override void OnRefreshRoleData()
	{
		if (this.RoleData == null)
		{
			return;
		}
		BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
		this.IsDriving = (gameplayTagComponent != null && gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.驾驶期间"]));
		BaseTagComponent gameplayTagComponent2 = this.RoleData.GameplayTagComponent;
		this.IsLock = (gameplayTagComponent2 != null && gameplayTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.氮气.无限氮气"]));
		BaseTagComponent gameplayTagComponent3 = this.RoleData.GameplayTagComponent;
		this.IsHideTag = (gameplayTagComponent3 != null && gameplayTagComponent3.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.隐藏氮气条"]));
		this.RefreshLockState();
		this.RefreshVisible();
	}

	// Token: 0x0600F527 RID: 62759 RVA: 0x00431F06 File Offset: 0x00430106
	private void OnStrengthChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
	{
		this.RefreshStrengthPercent(false);
	}

	// Token: 0x0600F528 RID: 62760 RVA: 0x00431F0F File Offset: 0x0043010F
	private void OnStrengthMaxChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
	{
		this.RefreshStrengthPercent(false);
	}

	// Token: 0x0600F529 RID: 62761 RVA: 0x00431F18 File Offset: 0x00430118
	private void OnMotorcycleTagChanged(int tagId, bool tagExists)
	{
		if (this.IsDriving != tagExists)
		{
			this.IsDriving = tagExists;
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F52A RID: 62762 RVA: 0x00431F30 File Offset: 0x00430130
	private void OnLockTagChanged(int tagId, bool tagExists)
	{
		if (this.IsLock != tagExists)
		{
			this.IsLock = tagExists;
			this.RefreshLockState();
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F52B RID: 62763 RVA: 0x00431F4E File Offset: 0x0043014E
	private void OnHideTagChanged(int tagId, bool tagExists)
	{
		if (this.IsHideTag != tagExists)
		{
			this.IsHideTag = tagExists;
			this.RefreshVisible();
		}
	}

	// Token: 0x0600F52C RID: 62764 RVA: 0x00431F68 File Offset: 0x00430168
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

	// Token: 0x0600F52D RID: 62765 RVA: 0x00431FC0 File Offset: 0x004301C0
	private void RefreshStrengthPercent(bool bForce = false)
	{
		float value = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.MotorcycleStrength);
		float max = ControllerBase<FormationAttributeController>.Instance.GetMax(EFormationAttributeId.MotorcycleStrength);
		bool flag = value != this.StrengthCurrentValue;
		if (flag)
		{
			this.StrengthCurrentValue = value;
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

	// Token: 0x0600F52E RID: 62766 RVA: 0x00432030 File Offset: 0x00430230
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

	// Token: 0x0600F52F RID: 62767 RVA: 0x0043209C File Offset: 0x0043029C
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
			this.RotationCache.Yaw = num3;
			uuiitem.SetUIRelativeRotation(this.RotationCache);
			num3 += num2;
		}
	}

	// Token: 0x0600F530 RID: 62768 RVA: 0x00432134 File Offset: 0x00430334
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

	// Token: 0x0600F531 RID: 62769 RVA: 0x00432188 File Offset: 0x00430388
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

	// Token: 0x0600F532 RID: 62770 RVA: 0x004321EC File Offset: 0x004303EC
	private void RefreshVisible()
	{
		bool flag = !this.IsHideTag && (this.IsLock || (this.IsDriving && !this.IsFullState));
		bool flag2 = !this.IsHideTag && this.AutoMovingItem.GetTargetVisible();
		bool flag3 = flag || flag2;
		if (this.TargetActive != flag3)
		{
			this.SetActive(flag3);
		}
		if (this.CurBarVisible && !flag)
		{
			this.CurBarVisible = false;
			base.StopTweenAnim(7);
			base.PlayTweenAnim(8);
			return;
		}
		if (!this.CurBarVisible && flag)
		{
			this.CurBarVisible = true;
			base.StopTweenAnim(8);
			base.PlayTweenAnim(7);
		}
	}

	// Token: 0x0600F533 RID: 62771 RVA: 0x00432292 File Offset: 0x00430492
	private void RefreshLockState()
	{
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.IsLock);
	}

	// Token: 0x0600F534 RID: 62772 RVA: 0x004322AB File Offset: 0x004304AB
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

	// Token: 0x0600F535 RID: 62773 RVA: 0x004322E7 File Offset: 0x004304E7
	public override void Tick(float delta)
	{
		this.RefreshAutoMoving(false);
	}

	// Token: 0x0600F536 RID: 62774 RVA: 0x004322F0 File Offset: 0x004304F0
	private void AutoMovingSettingChanged(bool enable)
	{
		this.RefreshAutoMovingSetting(false);
		this.RefreshAutoMovingTag();
		this.RefreshAutoMoving(false);
	}

	// Token: 0x0600F537 RID: 62775 RVA: 0x00432306 File Offset: 0x00430506
	private void OnMotorcycleStateChanged(bool bEnable)
	{
		this.RefreshAutoMovingTag();
		this.RefreshAutoMoving(false);
	}

	// Token: 0x0600F538 RID: 62776 RVA: 0x00432318 File Offset: 0x00430518
	private void RefreshAutoMovingSetting(bool isStart = false)
	{
		BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
		if (this.AutoAcceleratorSettingEnable == motorcycleData.AutoAcceleratorSettingEnable && this.AutoNitrogenSettingEnable == motorcycleData.AutoNitrogenSettingEnable)
		{
			return;
		}
		this.AutoAcceleratorSettingEnable = motorcycleData.AutoAcceleratorSettingEnable;
		this.AutoNitrogenSettingEnable = motorcycleData.AutoNitrogenSettingEnable;
		if (!this.AutoAcceleratorSettingEnable && !this.AutoNitrogenSettingEnable)
		{
			this.SetAutoMovingState(EMotorcycleAutoMovingState.None, 0f, isStart);
		}
	}

	// Token: 0x0600F539 RID: 62777 RVA: 0x00432384 File Offset: 0x00430584
	private void RefreshAutoMovingTag()
	{
		this.MotorcycleEntityHandle = null;
		this.ClearMotorcycleTagTask();
		if (!this.AutoAcceleratorSettingEnable && !this.AutoNitrogenSettingEnable)
		{
			return;
		}
		BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
		if (!motorcycleData.IsDriving)
		{
			return;
		}
		this.MotorcycleEntityHandle = motorcycleData.MotorcycleEntityHandle;
		EntityHandle motorcycleEntityHandle = this.MotorcycleEntityHandle;
		if (motorcycleEntityHandle == null || !motorcycleEntityHandle.Valid)
		{
			this.MotorcycleTagComponent = null;
			return;
		}
		this.MotorcycleTagComponent = this.MotorcycleEntityHandle.Entity.GetComponent<BaseTagComponent>();
		this.HasAutoAcceleratorTag = this.MotorcycleTagComponent.HasTag(MotorcycleStrengthItem.autoAcceleratorTagId);
		this.HasAutoNitrogenTag = this.MotorcycleTagComponent.HasTag(MotorcycleStrengthItem.autoNitrogenTagId);
		this.ListenForMotorcycleTagAddOrRemove(this.MotorcycleTagComponent, new int?(MotorcycleStrengthItem.autoAcceleratorTagId), new Action<int, bool>(this.OnAutoAcceleratorTagChange));
		this.ListenForMotorcycleTagAddOrRemove(this.MotorcycleTagComponent, new int?(MotorcycleStrengthItem.autoNitrogenTagId), new Action<int, bool>(this.OnAutoNitrogenTagChange));
	}

	// Token: 0x0600F53A RID: 62778 RVA: 0x00432474 File Offset: 0x00430674
	protected void ListenForMotorcycleTagAddOrRemove(BaseTagComponent tagComponent, int? tagId, Action<int, bool> callback)
	{
		ITagTask tagTask = tagComponent.ListenForTagAddOrRemove(tagId, new BaseTagComponent.TTagSwitchedCallback(callback.Invoke), null);
		if (tagTask != null)
		{
			this.MotorcycleTagTaskList.Add(tagTask);
		}
	}

	// Token: 0x0600F53B RID: 62779 RVA: 0x004324A8 File Offset: 0x004306A8
	protected void ClearMotorcycleTagTask()
	{
		foreach (ITagTask tagTask in this.MotorcycleTagTaskList)
		{
			tagTask.EndTask();
		}
		this.MotorcycleTagTaskList.Clear();
	}

	// Token: 0x0600F53C RID: 62780 RVA: 0x00432504 File Offset: 0x00430704
	private void OnAutoAcceleratorTagChange(int tagId, bool tagExists)
	{
		this.HasAutoAcceleratorTag = tagExists;
		this.RefreshAutoMoving(false);
	}

	// Token: 0x0600F53D RID: 62781 RVA: 0x00432514 File Offset: 0x00430714
	private void OnAutoNitrogenTagChange(int tagId, bool tagExists)
	{
		this.HasAutoNitrogenTag = tagExists;
		this.RefreshAutoMoving(false);
	}

	// Token: 0x0600F53E RID: 62782 RVA: 0x00432524 File Offset: 0x00430724
	private void RefreshAutoMoving(bool isStart = false)
	{
		if (!this.AutoAcceleratorSettingEnable && !this.AutoNitrogenSettingEnable)
		{
			return;
		}
		EntityHandle motorcycleEntityHandle = this.MotorcycleEntityHandle;
		MotorcycleInputComponent motorcycleInputComponent;
		if (motorcycleEntityHandle == null)
		{
			motorcycleInputComponent = null;
		}
		else
		{
			WorldEntity entity = motorcycleEntityHandle.Entity;
			motorcycleInputComponent = ((entity != null) ? entity.GetComponent<MotorcycleInputComponent>() : null);
		}
		MotorcycleInputComponent motorcycleInputComponent2 = motorcycleInputComponent;
		if (motorcycleInputComponent2 == null)
		{
			return;
		}
		if (this.AutoNitrogenSettingEnable)
		{
			if (this.HasAutoNitrogenTag)
			{
				this.SetAutoMovingState(EMotorcycleAutoMovingState.AutoNitrogen, 1f, isStart);
				return;
			}
			MotorcycleInputComponent.NitroBoostInfo nitroBoostInfo = motorcycleInputComponent2.GetNitroBoostInfo();
			if (nitroBoostInfo != null)
			{
				double duration = nitroBoostInfo.GetDuration();
				double currentTime = nitroBoostInfo.GetCurrentTime();
				if (currentTime > 0.0)
				{
					this.SetAutoMovingState(EMotorcycleAutoMovingState.Nitrogen, (float)(currentTime / duration), isStart);
					return;
				}
			}
		}
		if (this.AutoAcceleratorSettingEnable)
		{
			if (this.HasAutoAcceleratorTag)
			{
				this.SetAutoMovingState(EMotorcycleAutoMovingState.AutoAccelerator, 1f, isStart);
				return;
			}
			MotorcycleInputComponent.HoldThrottleInfo holdThrottleInfo = motorcycleInputComponent2.GetHoldThrottleInfo();
			if (holdThrottleInfo != null)
			{
				double duration2 = holdThrottleInfo.GetDuration();
				double currentTime2 = holdThrottleInfo.GetCurrentTime();
				if (currentTime2 > 0.0)
				{
					this.SetAutoMovingState(EMotorcycleAutoMovingState.Accelerator, (float)currentTime2 / (float)duration2, isStart);
					return;
				}
			}
		}
		this.SetAutoMovingState(EMotorcycleAutoMovingState.None, 0f, isStart);
	}

	// Token: 0x0600F53F RID: 62783 RVA: 0x0043261C File Offset: 0x0043081C
	private void SetAutoMovingState(EMotorcycleAutoMovingState state, float percent = 0f, bool isStart = false)
	{
		if (this.AutoMovingItem == null)
		{
			return;
		}
		if (this.AutoMovingState == state)
		{
			if (this.AutoMovingState == EMotorcycleAutoMovingState.Nitrogen)
			{
				this.AutoMovingItem.SetPercentNitrogen(percent);
				return;
			}
			if (this.AutoMovingState == EMotorcycleAutoMovingState.Accelerator)
			{
				this.AutoMovingItem.SetPercentAccelerator(percent);
			}
			return;
		}
		else
		{
			this.AutoMovingState = state;
			if (state == EMotorcycleAutoMovingState.None)
			{
				this.AutoMovingItem.SetVisible(false);
				if (!isStart)
				{
					this.RefreshVisible();
				}
				return;
			}
			this.AutoMovingItem.SetVisible(true);
			bool flag = state == EMotorcycleAutoMovingState.AutoNitrogen || state == EMotorcycleAutoMovingState.Nitrogen;
			this.AutoMovingItem.SetNitrogen(flag);
			if (flag)
			{
				this.AutoMovingItem.SetPercentNitrogen(percent);
			}
			else
			{
				this.AutoMovingItem.SetPercentAccelerator(percent);
			}
			if (!isStart)
			{
				this.RefreshVisible();
			}
			return;
		}
	}

	// Token: 0x0600F540 RID: 62784 RVA: 0x004326D1 File Offset: 0x004308D1
	private void DestroyAutoMoving()
	{
		this.ClearMotorcycleTagTask();
		this.MotorcycleEntityHandle = null;
		this.MotorcycleTagComponent = null;
	}

	// Token: 0x0400766F RID: 30319
	private const int CLOSE_ANIM_TIME = 250;

	// Token: 0x04007670 RID: 30320
	private const int PRELOAD_SINGLE_STRENGTH_ITEM_COUNT = 3;

	// Token: 0x04007671 RID: 30321
	private static readonly int autoAcceleratorTagId = GameplayTagDefine.EGameplayTagId["载具.摩托.移动.油门维持"];

	// Token: 0x04007672 RID: 30322
	private static readonly int autoNitrogenTagId = GameplayTagDefine.EGameplayTagId["载具.摩托.移动.氮气维持"];

	// Token: 0x04007673 RID: 30323
	private bool IsNormalState = true;

	// Token: 0x04007674 RID: 30324
	private bool IsFullState = true;

	// Token: 0x04007675 RID: 30325
	private bool IsDriving;

	// Token: 0x04007676 RID: 30326
	private bool IsLock;

	// Token: 0x04007677 RID: 30327
	private bool IsHideTag;

	// Token: 0x04007678 RID: 30328
	private float LowEndurancePercent;

	// Token: 0x04007679 RID: 30329
	private float SingleStrengthValue;

	// Token: 0x0400767A RID: 30330
	private int MaxSingleStrengthItemCount = 1;

	// Token: 0x0400767B RID: 30331
	private readonly List<UUIItem> StrengthSingleLineActorList = new List<UUIItem>();

	// Token: 0x0400767C RID: 30332
	private float StrengthCurrentValue;

	// Token: 0x0400767D RID: 30333
	private float MaxStrengthCurrentValue;

	// Token: 0x0400767E RID: 30334
	private FRotator RotationCache = new FRotator(0f, 0f, 0f);

	// Token: 0x0400767F RID: 30335
	private bool CurBarVisible;

	// Token: 0x04007680 RID: 30336
	[Nullable(2)]
	private TimerHandle CloseAnimTimer;

	// Token: 0x04007681 RID: 30337
	[Nullable(2)]
	private CustomPromise CloseAnimPromise;

	// Token: 0x04007682 RID: 30338
	[StaticVariableRuleIgnore]
	private static readonly Stat CloseAnimTimerStat = Stat.Create("MotorcycleStrengthCloseAnim", "", "");

	// Token: 0x04007683 RID: 30339
	private bool AutoAcceleratorSettingEnable;

	// Token: 0x04007684 RID: 30340
	private bool AutoNitrogenSettingEnable;

	// Token: 0x04007685 RID: 30341
	[Nullable(2)]
	private MotorcycleAutoMovingItem AutoMovingItem;

	// Token: 0x04007686 RID: 30342
	private EMotorcycleAutoMovingState AutoMovingState;

	// Token: 0x04007687 RID: 30343
	[Nullable(2)]
	private EntityHandle MotorcycleEntityHandle;

	// Token: 0x04007688 RID: 30344
	[Nullable(2)]
	private BaseTagComponent MotorcycleTagComponent;

	// Token: 0x04007689 RID: 30345
	private bool HasAutoAcceleratorTag;

	// Token: 0x0400768A RID: 30346
	private bool HasAutoNitrogenTag;

	// Token: 0x0400768B RID: 30347
	protected readonly List<ITagTask> MotorcycleTagTaskList = new List<ITagTask>();
}
