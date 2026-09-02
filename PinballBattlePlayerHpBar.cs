using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.KuroSimpleCombat.PB;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D74 RID: 7540
[NullableContext(2)]
[Nullable(0)]
public class PinballBattlePlayerHpBar : PinballBattleHeadStateUiBase
{
	// Token: 0x17001174 RID: 4468
	// (get) Token: 0x0600DDC1 RID: 56769 RVA: 0x003B9DDE File Offset: 0x003B7FDE
	private PinballBattleSubController SubController
	{
		get
		{
			return ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
		}
	}

	// Token: 0x0600DDC2 RID: 56770 RVA: 0x003B9DF0 File Offset: 0x003B7FF0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DDC3 RID: 56771 RVA: 0x003B9F20 File Offset: 0x003B8120
	protected override UniTask OnBeforeStartAsync()
	{
		PinballBattlePlayerHpBar.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PinballBattlePlayerHpBar.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DDC4 RID: 56772 RVA: 0x003B9F64 File Offset: 0x003B8164
	protected override void OnStart()
	{
		this.HpBar = base.GetSprite(4);
		this.ShieldBar = base.GetSprite(3);
		UUISprite hpBar = this.HpBar;
		this.HpBarMaxAnchorOffsetX = ((hpBar != null) ? hpBar.GetWidth() : 0f);
		FRotator frotator = new FRotator(180f, 0f, 0f);
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIRelativeRotation(frotator);
		}
		Singleton<EventSystem>.Instance.Add(EEventName.OnPinballRoleChargeMax, new Action<int>(this.OnRoleChargeMax));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPinballRoleUseSkill, new Action<int>(this.OnRoleUseSkill));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnPinballRoleStateChange, new Action<int, bool>(this.OnRoleStateChange));
		base.OnStart();
	}

	// Token: 0x0600DDC5 RID: 56773 RVA: 0x003BA02C File Offset: 0x003B822C
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballRoleChargeMax, new Action<int>(this.OnRoleChargeMax));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballRoleUseSkill, new Action<int>(this.OnRoleUseSkill));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.OnPinballRoleStateChange, new Action<int, bool>(this.OnRoleStateChange));
		LguiFloatTween hpBarTween = this.HpBarTween;
		if (hpBarTween != null)
		{
			hpBarTween.Destroy();
		}
		LguiFloatTween shieldBarTween = this.ShieldBarTween;
		if (shieldBarTween != null)
		{
			shieldBarTween.Destroy();
		}
		this.UnBindShieldDelegate();
	}

	// Token: 0x0600DDC6 RID: 56774 RVA: 0x003BA0BC File Offset: 0x003B82BC
	[NullableContext(1)]
	protected override void OnUpdateByHeadInfo(FKSC_HeadHpContext headInfo)
	{
		if (this.RoleId == null)
		{
			PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
			this.RoleId = pinballBattleSubModel.GetRoleIdByEntityId(headInfo.EntityId);
			KscEntityHandle kscEntityHandle;
			pinballBattleSubModel.KscEntities.TryGetValue(headInfo.EntityId, out kscEntityHandle);
			UKSC_AttrSet uksc_AttrSet;
			if (kscEntityHandle == null)
			{
				uksc_AttrSet = null;
			}
			else
			{
				AKSC_Entity kscEntity = kscEntityHandle.KscEntity;
				if (kscEntity == null)
				{
					uksc_AttrSet = null;
				}
				else
				{
					UKSC_SkillComp skillComp_ = kscEntity.SkillComp_;
					uksc_AttrSet = ((skillComp_ != null) ? skillComp_.AttrSet_ : null);
				}
			}
			UKSC_AttrSet uksc_AttrSet2 = uksc_AttrSet;
			this.OwnerAttrSet = uksc_AttrSet2;
			if (uksc_AttrSet2 != null)
			{
				this.BindShieldDelegate(uksc_AttrSet2);
			}
		}
		base.UpdateHeadStateLocation(headInfo.Location);
		float hpPercent = (float)headInfo.CurHp / (float)headInfo.MaxHp;
		float targetAnchorOffsetX = this.CalculateHpBarAnchorOffsetX(hpPercent);
		this.PlayHpBarTween(targetAnchorOffsetX, 0.3f);
	}

	// Token: 0x0600DDC7 RID: 56775 RVA: 0x003BA176 File Offset: 0x003B8376
	private float CalculateHpBarAnchorOffsetX(float hpPercent)
	{
		return Singleton<MathUtils>.Instance.Lerp(-this.HpBarMaxAnchorOffsetX, -2f, hpPercent);
	}

	// Token: 0x0600DDC8 RID: 56776 RVA: 0x003BA190 File Offset: 0x003B8390
	private void PlayHpBarTween(float targetAnchorOffsetX, float duration = 0.3f)
	{
		if (this.HpBar == null)
		{
			return;
		}
		if (this.HpBarTween == null)
		{
			this.HpBarTween = new LguiFloatTween();
		}
		float anchorOffsetX = this.HpBar.GetAnchorOffsetX();
		if (Math.Abs(anchorOffsetX - targetAnchorOffsetX) < 0.01f)
		{
			return;
		}
		this.HpBarTween.BindUpdateTween(delegate(float value)
		{
			UUISprite hpBar = this.HpBar;
			if (hpBar == null)
			{
				return;
			}
			hpBar.SetAnchorOffsetX(value);
		});
		this.HpBarTween.PlayTween(anchorOffsetX, targetAnchorOffsetX, duration, null);
	}

	// Token: 0x0600DDC9 RID: 56777 RVA: 0x003BA1FC File Offset: 0x003B83FC
	[NullableContext(1)]
	public void BindShieldDelegate(UKSC_AttrSet attrSet)
	{
		this.UnBindShieldDelegate();
		this.DelegateShieldChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnShieldChange));
		attrSet.AssignAttrListen(EKSC_AttrType.Shield, this.DelegateShieldChange);
		attrSet.AssignAttrListen(EKSC_AttrType.ShieldMax, this.DelegateShieldChange);
		this.UpdateShieldBar(true);
	}

	// Token: 0x0600DDCA RID: 56778 RVA: 0x003BA248 File Offset: 0x003B8448
	public void UnBindShieldDelegate()
	{
		if (this.OwnerAttrSet != null)
		{
			this.OwnerAttrSet.RemoveAttrListen(EKSC_AttrType.Shield, this.DelegateShieldChange);
			this.OwnerAttrSet.RemoveAttrListen(EKSC_AttrType.ShieldMax, this.DelegateShieldChange);
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnShieldChange));
			this.DelegateShieldChange = null;
		}
	}

	// Token: 0x0600DDCB RID: 56779 RVA: 0x003BA29A File Offset: 0x003B849A
	private void OnShieldChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateShieldBar(false);
	}

	// Token: 0x0600DDCC RID: 56780 RVA: 0x003BA2A4 File Offset: 0x003B84A4
	private void PlayShieldBarTween(float targetFillAmount, float duration = 0.3f)
	{
		if (this.ShieldBar == null)
		{
			return;
		}
		if (this.ShieldBarTween == null)
		{
			this.ShieldBarTween = new LguiFloatTween();
		}
		float fillAmount = this.ShieldBar.GetFillAmount();
		if (Math.Abs(fillAmount - targetFillAmount) < 0.001f)
		{
			return;
		}
		this.ShieldBarTween.BindUpdateTween(delegate(float value)
		{
			UUISprite shieldBar = this.ShieldBar;
			if (shieldBar == null)
			{
				return;
			}
			shieldBar.SetFillAmount(value);
		});
		this.ShieldBarTween.PlayTween(fillAmount, targetFillAmount, duration, null);
	}

	// Token: 0x0600DDCD RID: 56781 RVA: 0x003BA310 File Offset: 0x003B8510
	private void UpdateShieldBar(bool disableTween = false)
	{
		if (this.OwnerAttrSet == null || this.ShieldBar == null)
		{
			return;
		}
		TMap<EKSC_AttrType, int> attrs_ = this.OwnerAttrSet.Attrs_;
		float valueOrDefault = (float)((attrs_ != null) ? attrs_.GetValueOrNull(EKSC_AttrType.Shield) : null).GetValueOrDefault();
		TMap<EKSC_AttrType, int> attrs_2 = this.OwnerAttrSet.Attrs_;
		int valueOrDefault2 = ((attrs_2 != null) ? attrs_2.GetValueOrNull(EKSC_AttrType.ShieldMax) : null).GetValueOrDefault(1);
		float num = valueOrDefault / (float)valueOrDefault2;
		if (disableTween)
		{
			this.ShieldBar.SetFillAmount(num);
			return;
		}
		this.PlayShieldBarTween(num, 0.3f);
	}

	// Token: 0x0600DDCE RID: 56782 RVA: 0x003BA3A4 File Offset: 0x003B85A4
	private void OnRoleStateChange(int roleId, bool isAlive)
	{
		int? roleId2 = this.RoleId;
		if (roleId2.GetValueOrDefault() == roleId & roleId2 != null)
		{
			base.SetUiActive(isAlive);
		}
	}

	// Token: 0x0600DDCF RID: 56783 RVA: 0x003BA3D8 File Offset: 0x003B85D8
	private void OnRoleChargeMax(int roleId)
	{
		int? roleId2 = this.RoleId;
		if (roleId2.GetValueOrDefault() == roleId & roleId2 != null)
		{
			PinballBattleSubController subController = this.SubController;
			if (subController == null)
			{
				return;
			}
			subController.AddRoleChargeMaxEffectBuff(roleId);
		}
	}

	// Token: 0x0600DDD0 RID: 56784 RVA: 0x003BA414 File Offset: 0x003B8614
	private void OnRoleUseSkill(int roleId)
	{
		int? roleId2 = this.RoleId;
		if (roleId2.GetValueOrDefault() == roleId & roleId2 != null)
		{
			PinballBattleSubController subController = this.SubController;
			if (subController == null)
			{
				return;
			}
			subController.RemoveRoleChargeMaxEffectBuff(roleId);
		}
	}

	// Token: 0x04006A7F RID: 27263
	private const int HP_BAR_DEFAULT_OFFSET_X = -2;

	// Token: 0x04006A80 RID: 27264
	private const EKSC_AttrType CurShieldType = EKSC_AttrType.Shield;

	// Token: 0x04006A81 RID: 27265
	private const EKSC_AttrType MaxShieldType = EKSC_AttrType.ShieldMax;

	// Token: 0x04006A82 RID: 27266
	private int? RoleId;

	// Token: 0x04006A83 RID: 27267
	private UUISprite HpBar;

	// Token: 0x04006A84 RID: 27268
	private UUISprite ShieldBar;

	// Token: 0x04006A85 RID: 27269
	private float HpBarMaxAnchorOffsetX;

	// Token: 0x04006A86 RID: 27270
	private LguiFloatTween HpBarTween;

	// Token: 0x04006A87 RID: 27271
	private LguiFloatTween ShieldBarTween;

	// Token: 0x04006A88 RID: 27272
	private UKSC_AttrSet OwnerAttrSet;

	// Token: 0x04006A89 RID: 27273
	private FOnKSCAttrChange DelegateShieldChange;
}
