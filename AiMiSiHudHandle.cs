using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;

// Token: 0x02001F8B RID: 8075
[NullableContext(1)]
[Nullable(0)]
public class AiMiSiHudHandle : HudUnitHandleBase
{
	// Token: 0x0600F1F0 RID: 61936 RVA: 0x004215FE File Offset: 0x0041F7FE
	protected override void OnInitialize()
	{
		base.OnInitialize();
		this.RefreshCurRole();
		base.NewHudUnit<AiMiSiHudUnit>(typeof(AiMiSiHudUnit), "UiItem_AimisiHUD", false, false).ContinueWith(delegate(AiMiSiHudUnit aimUnit)
		{
			this.HudUnit = aimUnit;
			if (this.HudUnit == null)
			{
				return;
			}
			this.HudUnit.InitData(this.Data);
			this.RefreshHudVisible();
			this.RefreshSprintAttribute();
			this.RefreshHp();
		});
	}

	// Token: 0x0600F1F1 RID: 61937 RVA: 0x00421635 File Offset: 0x0041F835
	protected override void OnDestroyed()
	{
		if (this.HudUnit != null)
		{
			base.DestroyHudUnit(this.HudUnit);
			this.HudUnit = null;
		}
		this.ClearCurRoleData();
	}

	// Token: 0x0600F1F2 RID: 61938 RVA: 0x00421658 File Offset: 0x0041F858
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
	}

	// Token: 0x0600F1F3 RID: 61939 RVA: 0x00421676 File Offset: 0x0041F876
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
	}

	// Token: 0x0600F1F4 RID: 61940 RVA: 0x00421694 File Offset: 0x0041F894
	private void OnChangeRole(int newEntityId, int oldEntityId)
	{
		this.RefreshCurRole();
		this.RefreshHudVisible();
		this.RefreshSprintAttribute();
		this.RefreshHp();
	}

	// Token: 0x0600F1F5 RID: 61941 RVA: 0x004216B0 File Offset: 0x0041F8B0
	private void RefreshCurRole()
	{
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData != null)
		{
			BattleUiRoleData battleUiRoleData = curRoleData;
			if (battleUiRoleData.RoleConfig != null && battleUiRoleData.RoleConfig.GetValueOrDefault().Id == 1210)
			{
				this.RoleData = curRoleData;
				this.TagComponent = curRoleData.GameplayTagComponent;
				this.Data.IsForeground = true;
				if (this.TagComponent != null)
				{
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.主控机甲"], new Action<int, bool>(this.OnMechanismTagChanged));
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.事件.可触发合击"], new Action<int, bool>(this.OnJointTagChanged));
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.事件.强化合击可释放"], new Action<int, bool>(this.OnSpecialJointTagChanged));
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.冲刺移动"], new Action<int, bool>(this.OnSprintTagChanged));
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"], new Action<int, bool>(this.OnFightTagChanged));
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.Common.双模式.模式1"], new Action<int, bool>(this.OnModeTagChanged));
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.机制标记.悬浮贴地中标记"], new Action<int, bool>(this.OnAirTagChanged));
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.解锁炮大招前置条件"], new Action<int, bool>(this.OnUltraBuffTagChanged));
					this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.空冲刺能量惩罚"], new Action<int, bool>(this.OnEmptyEnduranceTagChanged));
					this.Data.IsMechanism = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.主控机甲"]);
					this.Data.IsJoint = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.事件.可触发合击"]);
					this.Data.IsSpecialJoint = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.事件.强化合击可释放"]);
					this.Data.IsSprint = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.冲刺移动"]);
					this.Data.InFight = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]);
					this.Data.IsModeOne = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.双模式.模式1"]);
					this.Data.InAir = !this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.机制标记.悬浮贴地中标记"]);
					this.Data.IsUltraBuff = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.解锁炮大招前置条件"]);
					this.Data.EmptyEndurance = this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.空冲刺能量惩罚"]);
					AiMiSiHudUnit hudUnit = this.HudUnit;
					if (hudUnit != null)
					{
						hudUnit.RefreshModeIcon();
					}
				}
				else
				{
					this.Data.IsMechanism = false;
					this.Data.IsJoint = false;
					this.Data.IsSpecialJoint = false;
					this.Data.IsSprint = false;
					this.Data.InFight = false;
					this.Data.IsModeOne = false;
					this.Data.InAir = false;
					this.Data.IsUltraBuff = false;
					this.Data.EmptyEndurance = false;
				}
				BattleUiRoleData roleData = this.RoleData;
				bool flag;
				if (roleData == null)
				{
					flag = false;
				}
				else
				{
					EntityHandle entityHandle = roleData.EntityHandle;
					flag = ((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault();
				}
				if (flag)
				{
					Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation, HitContext>(this.RoleData.EntityHandle.Entity, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnBeHit));
				}
				BattleUiRoleData roleData2 = this.RoleData;
				BaseAttributeComponent baseAttributeComponent = (roleData2 != null) ? roleData2.AttributeComponent : null;
				if (baseAttributeComponent != null)
				{
					baseAttributeComponent.AddListener(EAttributeType.SpecialEnergy5, new Action<EAttributeType, float, float>(this.OnSprintAttributeChanged), null);
				}
				if (baseAttributeComponent != null)
				{
					baseAttributeComponent.AddListener(EAttributeType.SpecialEnergy5Max, new Action<EAttributeType, float, float>(this.OnSprintAttributeChanged), null);
				}
				if (baseAttributeComponent != null)
				{
					baseAttributeComponent.AddListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHpChanged), null);
				}
				if (baseAttributeComponent != null)
				{
					baseAttributeComponent.AddListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHpChanged), null);
				}
				AiMiSiHudUnit hudUnit2 = this.HudUnit;
				if (hudUnit2 == null)
				{
					return;
				}
				hudUnit2.MarkDataDirty();
				return;
			}
		}
		this.ClearCurRoleData();
		this.Data.IsForeground = false;
		AiMiSiHudUnit hudUnit3 = this.HudUnit;
		if (hudUnit3 == null)
		{
			return;
		}
		hudUnit3.MarkDataDirty();
	}

	// Token: 0x0600F1F6 RID: 61942 RVA: 0x00421B24 File Offset: 0x0041FD24
	private void ClearCurRoleData()
	{
		if (this.RoleData != null)
		{
			EntityHandle entityHandle = this.RoleData.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation, HitContext>(this.RoleData.EntityHandle.Entity, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnBeHit));
				BaseAttributeComponent attributeComponent = this.RoleData.AttributeComponent;
				if (attributeComponent != null)
				{
					attributeComponent.RemoveListener(EAttributeType.SpecialEnergy5, new Action<EAttributeType, float, float>(this.OnSprintAttributeChanged));
				}
				if (attributeComponent != null)
				{
					attributeComponent.RemoveListener(EAttributeType.SpecialEnergy5Max, new Action<EAttributeType, float, float>(this.OnSprintAttributeChanged));
				}
				if (attributeComponent != null)
				{
					attributeComponent.RemoveListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHpChanged));
				}
				if (attributeComponent != null)
				{
					attributeComponent.RemoveListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHpChanged));
				}
			}
			this.RoleData = null;
		}
		this.TagComponent = null;
		foreach (ITagTask tagTask in this.TagTaskList)
		{
			tagTask.EndTask();
		}
		this.TagTaskList.Clear();
	}

	// Token: 0x0600F1F7 RID: 61943 RVA: 0x00421C54 File Offset: 0x0041FE54
	private void RefreshHudVisible()
	{
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.SetTargetVisible(this.RoleData != null);
	}

	// Token: 0x0600F1F8 RID: 61944 RVA: 0x00421C6F File Offset: 0x0041FE6F
	private void OnMechanismTagChanged(int tagId, bool tagExist)
	{
		this.Data.IsMechanism = tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.MarkDataDirty();
	}

	// Token: 0x0600F1F9 RID: 61945 RVA: 0x00421C8D File Offset: 0x0041FE8D
	private void OnJointTagChanged(int tagId, bool tagExist)
	{
		this.Data.IsJoint = tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.MarkDataDirty();
	}

	// Token: 0x0600F1FA RID: 61946 RVA: 0x00421CAB File Offset: 0x0041FEAB
	private void OnSpecialJointTagChanged(int tagId, bool tagExist)
	{
		this.Data.IsSpecialJoint = tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.MarkDataDirty();
	}

	// Token: 0x0600F1FB RID: 61947 RVA: 0x00421CC9 File Offset: 0x0041FEC9
	private void OnSprintTagChanged(int tagId, bool tagExist)
	{
		this.Data.IsSprint = tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.MarkDataDirty();
	}

	// Token: 0x0600F1FC RID: 61948 RVA: 0x00421CE7 File Offset: 0x0041FEE7
	private void OnFightTagChanged(int tagId, bool tagExist)
	{
		this.Data.InFight = tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.MarkDataDirty();
	}

	// Token: 0x0600F1FD RID: 61949 RVA: 0x00421D05 File Offset: 0x0041FF05
	private void OnModeTagChanged(int tagId, bool tagExist)
	{
		this.Data.IsModeOne = tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.RefreshModeIcon();
	}

	// Token: 0x0600F1FE RID: 61950 RVA: 0x00421D23 File Offset: 0x0041FF23
	private void OnAirTagChanged(int tagId, bool tagExist)
	{
		this.Data.InAir = !tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.MarkDataDirty();
	}

	// Token: 0x0600F1FF RID: 61951 RVA: 0x00421D44 File Offset: 0x0041FF44
	private void OnUltraBuffTagChanged(int tagId, bool tagExist)
	{
		this.Data.IsUltraBuff = tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.MarkDataDirty();
	}

	// Token: 0x0600F200 RID: 61952 RVA: 0x00421D62 File Offset: 0x0041FF62
	private void OnEmptyEnduranceTagChanged(int tagId, bool tagExist)
	{
		this.Data.EmptyEndurance = tagExist;
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.MarkDataDirty();
	}

	// Token: 0x0600F201 RID: 61953 RVA: 0x00421D80 File Offset: 0x0041FF80
	private void OnBeHit(global::HitInformation hitData, HitContext hitContext)
	{
		AiMiSiHudUnit hudUnit = this.HudUnit;
		if (hudUnit == null)
		{
			return;
		}
		hudUnit.OnHurt();
	}

	// Token: 0x0600F202 RID: 61954 RVA: 0x00421D92 File Offset: 0x0041FF92
	private void OnSprintAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		this.RefreshSprintAttribute();
	}

	// Token: 0x0600F203 RID: 61955 RVA: 0x00421D9A File Offset: 0x0041FF9A
	private void OnHpChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		this.RefreshHp();
	}

	// Token: 0x0600F204 RID: 61956 RVA: 0x00421DA4 File Offset: 0x0041FFA4
	private void RefreshSprintAttribute()
	{
		if (this.HudUnit == null)
		{
			return;
		}
		BattleUiRoleData roleData = this.RoleData;
		BaseAttributeComponent baseAttributeComponent = (roleData != null) ? roleData.AttributeComponent : null;
		if (baseAttributeComponent != null)
		{
			float enduranceProgress = 0f;
			float currentValue = baseAttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy5);
			float currentValue2 = baseAttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy5Max);
			if (currentValue2 > 0f)
			{
				enduranceProgress = currentValue / currentValue2;
			}
			this.HudUnit.SetEnduranceProgress(enduranceProgress);
		}
	}

	// Token: 0x0600F205 RID: 61957 RVA: 0x00421E00 File Offset: 0x00420000
	private void RefreshHp()
	{
		if (this.HudUnit == null)
		{
			return;
		}
		float hpPercent = 0f;
		BattleUiRoleData roleData = this.RoleData;
		BaseAttributeComponent baseAttributeComponent = (roleData != null) ? roleData.AttributeComponent : null;
		if (baseAttributeComponent != null)
		{
			float currentValue = baseAttributeComponent.GetCurrentValue(EAttributeType.Life);
			float currentValue2 = baseAttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
			if (currentValue2 > 0f)
			{
				hpPercent = currentValue / currentValue2;
			}
		}
		this.HudUnit.SetHpPercent(hpPercent);
	}

	// Token: 0x0600F206 RID: 61958 RVA: 0x00421E5C File Offset: 0x0042005C
	private void ListenForTagAddOrRemove(int tagId, Action<int, bool> callback)
	{
		if (this.TagComponent == null)
		{
			return;
		}
		ITagTask tagTask = this.TagComponent.ListenForTagAddOrRemove(new int?(tagId), new BaseTagComponent.TTagSwitchedCallback(callback.Invoke), null);
		if (tagTask != null)
		{
			this.TagTaskList.Add(tagTask);
		}
	}

	// Token: 0x0600F207 RID: 61959 RVA: 0x00421EA0 File Offset: 0x004200A0
	public override void OnInputControllerChanged(EInputControllerType last, EInputControllerType now)
	{
		if (this.HudUnit == null)
		{
			return;
		}
		if (last != now && (last == EInputControllerType.Touch || now == EInputControllerType.Touch))
		{
			this.HudUnit.RefreshKeyNode();
			this.HudUnit.RefreshRotateMachineSpeed();
		}
	}

	// Token: 0x04007433 RID: 29747
	[Nullable(2)]
	private AiMiSiHudUnit HudUnit;

	// Token: 0x04007434 RID: 29748
	[Nullable(2)]
	private BattleUiRoleData RoleData;

	// Token: 0x04007435 RID: 29749
	[Nullable(2)]
	private BaseTagComponent TagComponent;

	// Token: 0x04007436 RID: 29750
	private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

	// Token: 0x04007437 RID: 29751
	private readonly AiMiSiHudData Data = new AiMiSiHudData();
}
