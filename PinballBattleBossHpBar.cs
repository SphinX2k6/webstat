using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D4E RID: 7502
[NullableContext(2)]
[Nullable(0)]
public class PinballBattleBossHpBar : UiPanelBase
{
	// Token: 0x0600DD10 RID: 56592 RVA: 0x003B6800 File Offset: 0x003B4A00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DD11 RID: 56593 RVA: 0x003B68AC File Offset: 0x003B4AAC
	protected override void OnStart()
	{
		this.HpBar = base.GetSprite(0);
		UUISprite hpBar = this.HpBar;
		this.HpBarMaxAnchorOffsetX = ((hpBar != null) ? hpBar.GetWidth() : 0f);
		this.ShieldBar = base.GetSprite(1);
		UUISprite shieldBar = this.ShieldBar;
		this.ShieldBarMaxAnchorOffsetX = ((shieldBar != null) ? shieldBar.GetWidth() : 0f);
	}

	// Token: 0x0600DD12 RID: 56594 RVA: 0x003B690B File Offset: 0x003B4B0B
	protected override void OnBeforeDestroy()
	{
		this.ClearDelegate();
		LguiFloatTween hpBarTween = this.HpBarTween;
		if (hpBarTween != null)
		{
			hpBarTween.Destroy();
		}
		LguiFloatTween shieldBarTween = this.ShieldBarTween;
		if (shieldBarTween == null)
		{
			return;
		}
		shieldBarTween.Destroy();
	}

	// Token: 0x0600DD13 RID: 56595 RVA: 0x003B6934 File Offset: 0x003B4B34
	private float CalculateHpBarAnchorOffsetX(float hpPercent)
	{
		return Singleton<MathUtils>.Instance.Lerp(-this.HpBarMaxAnchorOffsetX, 0f, hpPercent);
	}

	// Token: 0x0600DD14 RID: 56596 RVA: 0x003B6950 File Offset: 0x003B4B50
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

	// Token: 0x0600DD15 RID: 56597 RVA: 0x003B69BC File Offset: 0x003B4BBC
	[NullableContext(1)]
	public void Refresh(FKSC_HeadHpContext hpContext)
	{
		EKSC_HeadHpContextType actionType = hpContext.ActionType;
		if (actionType > EKSC_HeadHpContextType.Update)
		{
			if (actionType != EKSC_HeadHpContextType.Remove)
			{
				return;
			}
			this.UnInit(hpContext.EntityId);
		}
		else if (this.EntityId == 0)
		{
			this.Init(hpContext.EntityId);
			return;
		}
	}

	// Token: 0x0600DD16 RID: 56598 RVA: 0x003B69FC File Offset: 0x003B4BFC
	private void Init(int entityId)
	{
		PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
		KscEntityHandle kscEntityHandle2;
		KscEntityHandle kscEntityHandle = (pinballBattleSubModel != null && pinballBattleSubModel.KscEntities.TryGetValue(entityId, out kscEntityHandle2)) ? kscEntityHandle2 : null;
		AKSC_Entity aksc_Entity = (kscEntityHandle != null) ? kscEntityHandle.KscEntity : null;
		if (aksc_Entity == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PinballBattle, ELogAuthor.LJ, "未根据ksc实体id找到指定Ksc实体，无法绑定Boss血条！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.EntityId = entityId;
		UKSC_SkillComp skillComp_ = aksc_Entity.SkillComp_;
		this.OwnerAttrSet = ((skillComp_ != null) ? skillComp_.AttrSet_ : null);
		base.SetUiActive(true);
		if (this.OwnerAttrSet != null)
		{
			this.BindHpDelegate(this.OwnerAttrSet);
			this.BindShieldDelegate(this.OwnerAttrSet);
		}
	}

	// Token: 0x0600DD17 RID: 56599 RVA: 0x003B6AA8 File Offset: 0x003B4CA8
	private void UnInit(int entityId)
	{
		if (entityId != this.EntityId)
		{
			return;
		}
		this.ClearDelegate();
		this.EntityId = 0;
		this.OwnerAttrSet = null;
		base.SetUiActive(false);
	}

	// Token: 0x0600DD18 RID: 56600 RVA: 0x003B6ACF File Offset: 0x003B4CCF
	private void ClearDelegate()
	{
		this.UnBindHpDelegate();
		this.UnBindShieldDelegate();
	}

	// Token: 0x0600DD19 RID: 56601 RVA: 0x003B6AE0 File Offset: 0x003B4CE0
	[NullableContext(1)]
	public void BindHpDelegate(UKSC_AttrSet attrSet)
	{
		this.UnBindHpDelegate();
		this.DelegateHpChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnHpChange));
		attrSet.AssignAttrListen(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.CurHpType, this.DelegateHpChange);
		attrSet.AssignAttrListen(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.MaxHpType, this.DelegateHpChange);
		this.UpdateHpBar(true);
	}

	// Token: 0x0600DD1A RID: 56602 RVA: 0x003B6B34 File Offset: 0x003B4D34
	public void UnBindHpDelegate()
	{
		if (this.OwnerAttrSet != null)
		{
			this.OwnerAttrSet.RemoveAttrListen(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.CurHpType, this.DelegateHpChange);
			this.OwnerAttrSet.RemoveAttrListen(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.MaxHpType, this.DelegateHpChange);
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnHpChange));
			this.DelegateHpChange = null;
		}
	}

	// Token: 0x0600DD1B RID: 56603 RVA: 0x003B6B8D File Offset: 0x003B4D8D
	private void OnHpChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateHpBar(false);
	}

	// Token: 0x0600DD1C RID: 56604 RVA: 0x003B6B98 File Offset: 0x003B4D98
	private void UpdateHpBar(bool disableTween = false)
	{
		if (this.OwnerAttrSet == null || this.HpBar == null)
		{
			return;
		}
		TMap<EKSC_AttrType, int> attrs_ = this.OwnerAttrSet.Attrs_;
		float valueOrDefault = (float)((attrs_ != null) ? attrs_.GetValueOrNull(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.CurHpType) : null).GetValueOrDefault();
		TMap<EKSC_AttrType, int> attrs_2 = this.OwnerAttrSet.Attrs_;
		int valueOrDefault2 = ((attrs_2 != null) ? attrs_2.GetValueOrNull(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.MaxHpType) : null).GetValueOrDefault(1);
		float hpPercent = valueOrDefault / (float)valueOrDefault2;
		float num = this.CalculateHpBarAnchorOffsetX(hpPercent);
		if (disableTween)
		{
			this.HpBar.SetAnchorOffsetX(num);
			return;
		}
		this.PlayHpBarTween(num, 0.3f);
	}

	// Token: 0x0600DD1D RID: 56605 RVA: 0x003B6C3C File Offset: 0x003B4E3C
	[NullableContext(1)]
	public void BindShieldDelegate(UKSC_AttrSet attrSet)
	{
		this.UnBindShieldDelegate();
		this.DelegateShieldChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnShieldChange));
		attrSet.AssignAttrListen(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.CurShieldType, this.DelegateShieldChange);
		attrSet.AssignAttrListen(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.MaxShieldType, this.DelegateShieldChange);
		this.UpdateShieldBar(true);
	}

	// Token: 0x0600DD1E RID: 56606 RVA: 0x003B6C90 File Offset: 0x003B4E90
	public void UnBindShieldDelegate()
	{
		if (this.OwnerAttrSet != null)
		{
			this.OwnerAttrSet.RemoveAttrListen(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.CurShieldType, this.DelegateShieldChange);
			this.OwnerAttrSet.RemoveAttrListen(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.MaxShieldType, this.DelegateShieldChange);
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnShieldChange));
			this.DelegateShieldChange = null;
		}
	}

	// Token: 0x0600DD1F RID: 56607 RVA: 0x003B6CE9 File Offset: 0x003B4EE9
	private void OnShieldChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateShieldBar(false);
	}

	// Token: 0x0600DD20 RID: 56608 RVA: 0x003B6CF2 File Offset: 0x003B4EF2
	private float CalculateShieldBarAnchorOffsetX(float shieldPercent)
	{
		return Singleton<MathUtils>.Instance.Lerp(-this.ShieldBarMaxAnchorOffsetX, 0f, shieldPercent);
	}

	// Token: 0x0600DD21 RID: 56609 RVA: 0x003B6D0C File Offset: 0x003B4F0C
	private void PlayShieldBarTween(float targetAnchorOffsetX, float duration = 0.3f)
	{
		if (this.ShieldBar == null)
		{
			return;
		}
		if (this.ShieldBarTween == null)
		{
			this.ShieldBarTween = new LguiFloatTween();
		}
		float anchorOffsetX = this.ShieldBar.GetAnchorOffsetX();
		if (Math.Abs(anchorOffsetX - targetAnchorOffsetX) < 0.01f)
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
			shieldBar.SetAnchorOffsetX(value);
		});
		this.ShieldBarTween.PlayTween(anchorOffsetX, targetAnchorOffsetX, duration, null);
	}

	// Token: 0x0600DD22 RID: 56610 RVA: 0x003B6D78 File Offset: 0x003B4F78
	private void UpdateShieldBar(bool disableTween = false)
	{
		if (this.OwnerAttrSet == null || this.ShieldBar == null)
		{
			return;
		}
		TMap<EKSC_AttrType, int> attrs_ = this.OwnerAttrSet.Attrs_;
		float valueOrDefault = (float)((attrs_ != null) ? attrs_.GetValueOrNull(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.CurShieldType) : null).GetValueOrDefault();
		TMap<EKSC_AttrType, int> attrs_2 = this.OwnerAttrSet.Attrs_;
		int valueOrDefault2 = ((attrs_2 != null) ? attrs_2.GetValueOrNull(<PinballBattleBossHpBar>F2F5904401B812D9C930B2E50A897BB018708F57D82CD8DEB82D7DCCDD090A761__BossHpConst.MaxShieldType) : null).GetValueOrDefault(1);
		float shieldPercent = valueOrDefault / (float)valueOrDefault2;
		float num = this.CalculateShieldBarAnchorOffsetX(shieldPercent);
		if (disableTween)
		{
			this.ShieldBar.SetAnchorOffsetX(num);
			return;
		}
		this.PlayShieldBarTween(num, 0.3f);
	}

	// Token: 0x040069EB RID: 27115
	private int EntityId;

	// Token: 0x040069EC RID: 27116
	private UKSC_AttrSet OwnerAttrSet;

	// Token: 0x040069ED RID: 27117
	private UUISprite HpBar;

	// Token: 0x040069EE RID: 27118
	private UUISprite ShieldBar;

	// Token: 0x040069EF RID: 27119
	private float HpBarMaxAnchorOffsetX;

	// Token: 0x040069F0 RID: 27120
	private LguiFloatTween HpBarTween;

	// Token: 0x040069F1 RID: 27121
	private float ShieldBarMaxAnchorOffsetX;

	// Token: 0x040069F2 RID: 27122
	private LguiFloatTween ShieldBarTween;

	// Token: 0x040069F3 RID: 27123
	private FOnKSCAttrChange DelegateHpChange;

	// Token: 0x040069F4 RID: 27124
	private FOnKSCAttrChange DelegateShieldChange;
}
