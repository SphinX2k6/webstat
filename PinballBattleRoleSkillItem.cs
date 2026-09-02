using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D5A RID: 7514
[NullableContext(2)]
[Nullable(0)]
public class PinballBattleRoleSkillItem : UiPanelBase, IStaticVariableResetter
{
	// Token: 0x0600DD69 RID: 56681 RVA: 0x003B8288 File Offset: 0x003B6488
	static PinballBattleRoleSkillItem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PinballBattleRoleSkillItem.CreateStaticDefaultValue), new Action(PinballBattleRoleSkillItem.ResetStaticDefaultValue));
	}

	// Token: 0x0600DD6A RID: 56682 RVA: 0x003B82A7 File Offset: 0x003B64A7
	public static void CreateStaticDefaultValue()
	{
		PinballBattleRoleSkillItem.ChargeBarRange = new float[]
		{
			0.552f,
			0.882f
		};
	}

	// Token: 0x0600DD6B RID: 56683 RVA: 0x003B82C4 File Offset: 0x003B64C4
	public static void ResetStaticDefaultValue()
	{
		PinballBattleRoleSkillItem.ChargeBarRange = null;
	}

	// Token: 0x0600DD6C RID: 56684 RVA: 0x003B82CC File Offset: 0x003B64CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 18;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
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
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnSkillClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600DD6D RID: 56685 RVA: 0x003B858C File Offset: 0x003B678C
	protected override void OnStart()
	{
		this.TexHpBar = base.GetTexture(15);
		this.ChargeBar = base.GetSprite(12);
		this.BuffLayout = new GenericLayout<PinballBattleBuffItem, IBuffView>(base.GetLayoutBase(8), () => new PinballBattleBuffItem(), null, false, true);
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnPinballRoleStateChange, new Action<int, bool>(this.OnRoleStateChange));
	}

	// Token: 0x0600DD6E RID: 56686 RVA: 0x003B8616 File Offset: 0x003B6816
	protected override void OnBeforeDestroy()
	{
		this.ClearDelegate();
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballRoleStateChange, new Action<int, bool>(this.OnRoleStateChange));
	}

	// Token: 0x0600DD6F RID: 56687 RVA: 0x003B864C File Offset: 0x003B684C
	public void Refresh(int roleId)
	{
		this.RoleId = roleId;
		if (roleId == -1)
		{
			this.ClearDelegate();
			this.OwnerEntity = null;
			this.RefreshPerformanceByState(PinballBattleRoleSkillItem.EState.None);
			return;
		}
		PinballRoleConfig value = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(roleId).Value;
		base.SetTextureShowUntilLoaded(value.Icon, base.GetTexture(0), null);
		this.SetSpriteByPath(value.RoleSkillIcon, base.GetSprite(16), false, null, null);
		this.SetSpriteByPath(value.RoleSkillIcon, base.GetSprite(17), false, null, null);
		PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
		object obj;
		if (pinballBattleSubModel == null)
		{
			obj = null;
		}
		else
		{
			KscEntityHandle kscEntityByRoleId = pinballBattleSubModel.GetKscEntityByRoleId(roleId);
			obj = ((kscEntityByRoleId != null) ? kscEntityByRoleId.KscEntity : null);
		}
		AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = obj as AKSC_Shape2D_Entity_Player;
		if (aksc_Shape2D_Entity_Player == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PinballBattle;
			ELogAuthor author = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("找不到角色id对应的实体！RoleId：");
			defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.OwnerEntity = aksc_Shape2D_Entity_Player;
		UKSC_SkillComp skillComp = aksc_Shape2D_Entity_Player.GetSkillComp();
		if (skillComp == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.PinballBattle;
			ELogAuthor author2 = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
			defaultInterpolatedStringHandler.AppendLiteral("找不到角色id对应的技能组件！RoleId：");
			defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
			instance2.Warn(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
		if (attrSet_ == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.PinballBattle;
			ELogAuthor author3 = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("找不到角色id对应的属性集！RoleId：");
			defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
			instance3.Warn(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.BindAttrDelegate(attrSet_);
		this.UpdateHpChange();
		this.UpdateChargeChange();
		this.RefreshPerformance();
		this.BindBuffDelegate(skillComp);
		this.RefreshBuff();
	}

	// Token: 0x0600DD70 RID: 56688 RVA: 0x003B881A File Offset: 0x003B6A1A
	private void OnRoleStateChange(int roleId, bool isAlive)
	{
		if (this.RoleId == roleId)
		{
			this.RefreshPerformance();
		}
	}

	// Token: 0x0600DD71 RID: 56689 RVA: 0x003B882C File Offset: 0x003B6A2C
	private void OnSkillClick()
	{
		if (Singleton<Time>.Instance.ServerTimeStamp - this.LastSkillClickTime < 500.0)
		{
			return;
		}
		UKSC_AttrSet ownerAttrSet = this.OwnerAttrSet;
		int? num;
		if (ownerAttrSet == null)
		{
			num = null;
		}
		else
		{
			TMap<EKSC_AttrType, int> attrs_ = ownerAttrSet.Attrs_;
			num = ((attrs_ != null) ? attrs_.GetValueOrNull(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.CurChargeType) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		UKSC_AttrSet ownerAttrSet2 = this.OwnerAttrSet;
		int? num3;
		if (ownerAttrSet2 == null)
		{
			num3 = null;
		}
		else
		{
			TMap<EKSC_AttrType, int> attrs_2 = ownerAttrSet2.Attrs_;
			num3 = ((attrs_2 != null) ? attrs_2.GetValueOrNull(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.MaxChargeType) : null);
		}
		num2 = num3;
		int valueOrDefault2 = num2.GetValueOrDefault();
		if (valueOrDefault < valueOrDefault2)
		{
			return;
		}
		PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
		if (pinballBattleSubController != null)
		{
			PinballBattleLaunchPhaseController launchPhaseController = pinballBattleSubController.LaunchPhaseController;
			if (launchPhaseController == null || !launchPhaseController.IsActive())
			{
				PinballBattleSubModel model = pinballBattleSubController.GetModel();
				if (model.GetRoleSlotIndex(this.RoleId) == null)
				{
					return;
				}
				KscEntityHandle kscEntityByRoleId = model.GetKscEntityByRoleId(this.RoleId);
				AKSC_Shape2D_Entity_Player aksc_Shape2D_Entity_Player = ((kscEntityByRoleId != null) ? kscEntityByRoleId.KscEntity : null) as AKSC_Shape2D_Entity_Player;
				if (aksc_Shape2D_Entity_Player == null || !aksc_Shape2D_Entity_Player.IsPlayerAlive)
				{
					return;
				}
				Action<int> onSkillClickCallback = this.OnSkillClickCallback;
				if (onSkillClickCallback == null)
				{
					return;
				}
				onSkillClickCallback(this.RoleId);
				return;
			}
		}
	}

	// Token: 0x0600DD72 RID: 56690 RVA: 0x003B895F File Offset: 0x003B6B5F
	public void StartClickCooldown()
	{
		this.LastSkillClickTime = Singleton<Time>.Instance.ServerTimeStamp;
	}

	// Token: 0x0600DD73 RID: 56691 RVA: 0x003B8971 File Offset: 0x003B6B71
	public void ClearDelegate()
	{
		this.UnBindAttrDelegate();
		this.UnBindBuffDelegate();
	}

	// Token: 0x0600DD74 RID: 56692 RVA: 0x003B8980 File Offset: 0x003B6B80
	[NullableContext(1)]
	public void BindAttrDelegate(UKSC_AttrSet attrSet)
	{
		this.UnBindAttrDelegate();
		this.OwnerAttrSet = attrSet;
		this.ChargeDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnChargeChange));
		UKSC_AttrSet ownerAttrSet = this.OwnerAttrSet;
		if (ownerAttrSet != null)
		{
			ownerAttrSet.AssignAttrListen(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.CurChargeType, this.ChargeDelegate);
		}
		UKSC_AttrSet ownerAttrSet2 = this.OwnerAttrSet;
		if (ownerAttrSet2 != null)
		{
			ownerAttrSet2.AssignAttrListen(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.MaxChargeType, this.ChargeDelegate);
		}
		this.HpDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnHpChange));
		UKSC_AttrSet ownerAttrSet3 = this.OwnerAttrSet;
		if (ownerAttrSet3 != null)
		{
			ownerAttrSet3.AssignAttrListen(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.CurHpType, this.HpDelegate);
		}
		UKSC_AttrSet ownerAttrSet4 = this.OwnerAttrSet;
		if (ownerAttrSet4 == null)
		{
			return;
		}
		ownerAttrSet4.AssignAttrListen(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.MaxHpType, this.HpDelegate);
	}

	// Token: 0x0600DD75 RID: 56693 RVA: 0x003B8A38 File Offset: 0x003B6C38
	public void UnBindAttrDelegate()
	{
		if (this.OwnerAttrSet == null)
		{
			return;
		}
		UKSC_AttrSet ownerAttrSet = this.OwnerAttrSet;
		if (ownerAttrSet != null)
		{
			ownerAttrSet.RemoveAttrListen(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.CurChargeType, this.ChargeDelegate);
		}
		UKSC_AttrSet ownerAttrSet2 = this.OwnerAttrSet;
		if (ownerAttrSet2 != null)
		{
			ownerAttrSet2.RemoveAttrListen(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.MaxChargeType, this.ChargeDelegate);
		}
		UKSC_AttrSet ownerAttrSet3 = this.OwnerAttrSet;
		if (ownerAttrSet3 != null)
		{
			ownerAttrSet3.RemoveAttrListen(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.CurHpType, this.HpDelegate);
		}
		UKSC_AttrSet ownerAttrSet4 = this.OwnerAttrSet;
		if (ownerAttrSet4 != null)
		{
			ownerAttrSet4.RemoveAttrListen(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.MaxHpType, this.HpDelegate);
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnChargeChange));
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnHpChange));
		this.ChargeDelegate = null;
		this.HpDelegate = null;
		this.OwnerAttrSet = null;
	}

	// Token: 0x0600DD76 RID: 56694 RVA: 0x003B8AF5 File Offset: 0x003B6CF5
	private void OnChargeChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateChargeChange();
		this.RefreshPerformance();
	}

	// Token: 0x0600DD77 RID: 56695 RVA: 0x003B8B03 File Offset: 0x003B6D03
	private void OnHpChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateHpChange();
		this.RefreshPerformance();
	}

	// Token: 0x0600DD78 RID: 56696 RVA: 0x003B8B14 File Offset: 0x003B6D14
	private void UpdateChargeChange()
	{
		UKSC_AttrSet ownerAttrSet = this.OwnerAttrSet;
		int? num;
		if (ownerAttrSet == null)
		{
			num = null;
		}
		else
		{
			TMap<EKSC_AttrType, int> attrs_ = ownerAttrSet.Attrs_;
			num = ((attrs_ != null) ? attrs_.GetValueOrNull(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.CurChargeType) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		UKSC_AttrSet ownerAttrSet2 = this.OwnerAttrSet;
		int? num3;
		if (ownerAttrSet2 == null)
		{
			num3 = null;
		}
		else
		{
			TMap<EKSC_AttrType, int> attrs_2 = ownerAttrSet2.Attrs_;
			num3 = ((attrs_2 != null) ? attrs_2.GetValueOrNull(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.MaxChargeType) : null);
		}
		num2 = num3;
		int valueOrDefault2 = num2.GetValueOrDefault();
		UUISprite chargeBar = this.ChargeBar;
		if (chargeBar != null)
		{
			chargeBar.SetFillAmount(Singleton<MathUtils>.Instance.Lerp(PinballBattleRoleSkillItem.ChargeBarRange[0], PinballBattleRoleSkillItem.ChargeBarRange[1], (float)valueOrDefault / (float)valueOrDefault2));
		}
		if (valueOrDefault < valueOrDefault2)
		{
			this.IsPlayedChargeTips = false;
			return;
		}
		if (!this.IsPlayedChargeTips)
		{
			this.IsPlayedChargeTips = true;
			PinballController instance = ControllerBase<PinballController>.Instance;
			if (instance != null)
			{
				instance.ShowRoleSkillMaxTips(this.RoleId);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPinballRoleChargeMax, this.RoleId);
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "PinballRoleChargeMax");
		}
	}

	// Token: 0x0600DD79 RID: 56697 RVA: 0x003B8C24 File Offset: 0x003B6E24
	private void UpdateHpChange()
	{
		UKSC_AttrSet ownerAttrSet = this.OwnerAttrSet;
		int? num;
		if (ownerAttrSet == null)
		{
			num = null;
		}
		else
		{
			TMap<EKSC_AttrType, int> attrs_ = ownerAttrSet.Attrs_;
			num = ((attrs_ != null) ? attrs_.GetValueOrNull(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.CurHpType) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		UKSC_AttrSet ownerAttrSet2 = this.OwnerAttrSet;
		int? num3;
		if (ownerAttrSet2 == null)
		{
			num3 = null;
		}
		else
		{
			TMap<EKSC_AttrType, int> attrs_2 = ownerAttrSet2.Attrs_;
			num3 = ((attrs_2 != null) ? attrs_2.GetValueOrNull(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.MaxHpType) : null);
		}
		num2 = num3;
		int valueOrDefault2 = num2.GetValueOrDefault();
		UUITexture texHpBar = this.TexHpBar;
		if (texHpBar == null)
		{
			return;
		}
		texHpBar.SetCustomMaterialScalarParameter(this.NamePercent.Value, (float)valueOrDefault / (float)valueOrDefault2);
	}

	// Token: 0x0600DD7A RID: 56698 RVA: 0x003B8CCC File Offset: 0x003B6ECC
	[NullableContext(1)]
	private void BindBuffDelegate(UKSC_SkillComp skillComp)
	{
		this.UnBindBuffDelegate();
		this.OwnerSkillComp = skillComp;
		TMap<UKSC_DA_Buff, int> tmap = new TMap<UKSC_DA_Buff, int>();
		skillComp.GetAllBuffs(ref tmap);
		List<IBuffView> list = new List<IBuffView>(tmap.Num());
		foreach (KeyValuePair<UKSC_DA_Buff, int> keyValuePair in tmap)
		{
			UKSC_DA_Buff uksc_DA_Buff;
			int num;
			keyValuePair.Deconstruct(out uksc_DA_Buff, out num);
			UKSC_DA_Buff buffDa = uksc_DA_Buff;
			int buffCount = num;
			int? buffId = this.GetBuffId(buffDa);
			if (buffId != null)
			{
				PinballModel instance = ModelBase<PinballModel>.Instance;
				BuffView buffView = (instance != null) ? instance.CreateBuffView(buffId.Value, buffCount) : null;
				if (buffView != null)
				{
					list.Add(buffView);
				}
			}
		}
		this.SetBuffViewList(list);
		skillComp.OnKSCBuffChange.Add(new Action<UKSC_DA_Buff, int>(this.OnBuffChange));
	}

	// Token: 0x0600DD7B RID: 56699 RVA: 0x003B8DA0 File Offset: 0x003B6FA0
	private void UnBindBuffDelegate()
	{
		if (this.OwnerSkillComp == null)
		{
			return;
		}
		this.OwnerSkillComp.OnKSCBuffChange.Remove(new Action<UKSC_DA_Buff, int>(this.OnBuffChange));
	}

	// Token: 0x0600DD7C RID: 56700 RVA: 0x003B8DC7 File Offset: 0x003B6FC7
	[NullableContext(1)]
	private void SetBuffViewList(List<IBuffView> buffIds)
	{
		this.CurBuffViewList = buffIds;
	}

	// Token: 0x0600DD7D RID: 56701 RVA: 0x003B8DD0 File Offset: 0x003B6FD0
	public void RefreshBuff()
	{
		if (this.CurBuffViewList == null)
		{
			return;
		}
		List<IBuffView> buffViewList = ModelBase<PinballModel>.Instance.GetBuffViewList(this.CurBuffViewList, 4);
		this.BuffLayout.RefreshByData(buffViewList, null, false);
		UUIItem item = base.GetItem(10);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.CurBuffViewList.Count > 4);
	}

	// Token: 0x0600DD7E RID: 56702 RVA: 0x003B8E28 File Offset: 0x003B7028
	private void OnBuffChange(UKSC_DA_Buff buffDa, int count)
	{
		if (this.CurBuffViewList == null)
		{
			this.CurBuffViewList = new List<IBuffView>();
		}
		if (buffDa == null)
		{
			return;
		}
		int? buffId = this.GetBuffId(buffDa);
		if (buffId == null)
		{
			return;
		}
		int num = this.CurBuffViewList.FindIndex((IBuffView buffView) => buffView.BuffId == buffId.Value);
		if (count == 0)
		{
			if (num != -1)
			{
				this.CurBuffViewList = this.CurBuffViewList.FindAll((IBuffView buffView) => buffView.BuffId != buffId.Value);
			}
		}
		else if (num != -1)
		{
			this.CurBuffViewList[num].BuffCount = count;
		}
		else
		{
			PinballModel instance = ModelBase<PinballModel>.Instance;
			BuffView buffView2 = (instance != null) ? instance.CreateBuffView(buffId.Value, count) : null;
			if (buffView2 == null)
			{
				return;
			}
			List<IBuffView> curBuffViewList = this.CurBuffViewList;
			if (curBuffViewList != null)
			{
				curBuffViewList.Add(buffView2);
			}
		}
		this.RefreshBuff();
	}

	// Token: 0x0600DD7F RID: 56703 RVA: 0x003B8F00 File Offset: 0x003B7100
	[NullableContext(1)]
	private int? GetBuffId(UKSC_DA_Buff buffDa)
	{
		UKuroSimpleCombatSubsystem kscSubsystem = Singleton<KscEnv>.Instance.KscSubsystem;
		bool flag;
		int value;
		if (kscSubsystem == null)
		{
			flag = false;
		}
		else
		{
			UKSC_World kscworld = kscSubsystem.GetKSCWorld();
			flag = ((kscworld != null) ? new bool?(kscworld.LoadedBuffDa.TryGetValue(buffDa, out value)) : null).GetValueOrDefault();
		}
		if (!flag)
		{
			return null;
		}
		return new int?(value);
	}

	// Token: 0x0600DD80 RID: 56704 RVA: 0x003B8F60 File Offset: 0x003B7160
	public void RefreshPerformance()
	{
		if (this.OwnerAttrSet == null)
		{
			return;
		}
		int valueOrDefault = this.OwnerAttrSet.Attrs_.GetValueOrNull(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.CurChargeType).GetValueOrDefault();
		int valueOrDefault2 = this.OwnerAttrSet.Attrs_.GetValueOrNull(<PinballBattleRoleSkillItem>F2B9D668857B11D15F56F95A08D06E81EDFF02635C7EED07F6FF5DC92CC3E9422__RoleSkillConst.MaxChargeType).GetValueOrDefault();
		if (this.OwnerEntity != null && !this.OwnerEntity.IsPlayerAlive)
		{
			this.RefreshPerformanceByState(PinballBattleRoleSkillItem.EState.Dead);
			return;
		}
		if (valueOrDefault2 > 0 && valueOrDefault >= valueOrDefault2)
		{
			this.RefreshPerformanceByState(PinballBattleRoleSkillItem.EState.Charge);
			return;
		}
		this.RefreshPerformanceByState(PinballBattleRoleSkillItem.EState.Normal);
	}

	// Token: 0x0600DD81 RID: 56705 RVA: 0x003B8FE8 File Offset: 0x003B71E8
	private void RefreshPerformanceByState(PinballBattleRoleSkillItem.EState state)
	{
		PinballBattleRoleSkillItem.EState? curState = this.CurState;
		if (curState.GetValueOrDefault() == state & curState != null)
		{
			return;
		}
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			item.SetUIActive(state == PinballBattleRoleSkillItem.EState.None);
		}
		UUIItem item2 = base.GetItem(14);
		if (item2 != null)
		{
			item2.SetUIActive(state > PinballBattleRoleSkillItem.EState.None);
		}
		if (state == PinballBattleRoleSkillItem.EState.None)
		{
			return;
		}
		UUIItem item3 = base.GetItem(2);
		if (item3 != null)
		{
			item3.SetUIActive(state == PinballBattleRoleSkillItem.EState.Dead);
		}
		UUIItem item4 = base.GetItem(4);
		if (item4 != null)
		{
			item4.SetUIActive(state == PinballBattleRoleSkillItem.EState.Normal || state == PinballBattleRoleSkillItem.EState.Charge);
		}
		UUIItem item5 = base.GetItem(6);
		if (item5 != null)
		{
			item5.SetUIActive(state == PinballBattleRoleSkillItem.EState.Charge);
		}
		UUIItem item6 = base.GetItem(3);
		if (item6 != null)
		{
			item6.SetUIActive(state == PinballBattleRoleSkillItem.EState.Dead);
		}
		UUIItem item7 = base.GetItem(5);
		if (item7 != null)
		{
			item7.SetUIActive(state == PinballBattleRoleSkillItem.EState.Normal);
		}
		UUIItem item8 = base.GetItem(7);
		if (item8 != null)
		{
			item8.SetUIActive(state == PinballBattleRoleSkillItem.EState.Charge);
		}
		UUILayoutBase layoutBase = base.GetLayoutBase(8);
		if (layoutBase != null)
		{
			layoutBase.RootUIComp.Get().SetUIActive(state != PinballBattleRoleSkillItem.EState.Dead);
		}
		UUITexture texHpBar = this.TexHpBar;
		if (texHpBar != null)
		{
			texHpBar.SetUIActive(state != PinballBattleRoleSkillItem.EState.Dead);
		}
		UUISprite chargeBar = this.ChargeBar;
		if (chargeBar != null)
		{
			chargeBar.SetUIActive(state != PinballBattleRoleSkillItem.EState.Dead);
		}
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			texture.SetIsGray(state == PinballBattleRoleSkillItem.EState.Dead);
		}
		this.RefreshAnimation(state);
		this.CurState = new PinballBattleRoleSkillItem.EState?(state);
	}

	// Token: 0x0600DD82 RID: 56706 RVA: 0x003B9150 File Offset: 0x003B7350
	private void RefreshAnimation(PinballBattleRoleSkillItem.EState newState)
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopPlayingSequence(false, true);
		}
		if (newState != PinballBattleRoleSkillItem.EState.Charge)
		{
			if (this.CurState.GetValueOrDefault() == PinballBattleRoleSkillItem.EState.Charge)
			{
				LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
				if (seqPlayer2 == null)
				{
					return;
				}
				seqPlayer2.PlayOrReplaySequenceByName("Charge_Out", false, null);
			}
			return;
		}
		LevelSequencePlayer seqPlayer3 = this.SeqPlayer;
		if (seqPlayer3 == null)
		{
			return;
		}
		seqPlayer3.PlayOrReplaySequenceByName("Charge_Done", false, null);
	}

	// Token: 0x04006A42 RID: 27202
	private static float[] ChargeBarRange;

	// Token: 0x04006A43 RID: 27203
	private const int INVALID_VALUE = -1;

	// Token: 0x04006A44 RID: 27204
	private int RoleId = -1;

	// Token: 0x04006A45 RID: 27205
	private UUITexture TexHpBar;

	// Token: 0x04006A46 RID: 27206
	private UUISprite ChargeBar;

	// Token: 0x04006A47 RID: 27207
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<PinballBattleBuffItem, IBuffView> BuffLayout;

	// Token: 0x04006A48 RID: 27208
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04006A49 RID: 27209
	private AKSC_Shape2D_Entity_Player OwnerEntity;

	// Token: 0x04006A4A RID: 27210
	private UKSC_SkillComp OwnerSkillComp;

	// Token: 0x04006A4B RID: 27211
	private UKSC_AttrSet OwnerAttrSet;

	// Token: 0x04006A4C RID: 27212
	private bool IsPlayedChargeTips;

	// Token: 0x04006A4D RID: 27213
	private PinballBattleRoleSkillItem.EState? CurState;

	// Token: 0x04006A4E RID: 27214
	private FOnKSCAttrChange ChargeDelegate;

	// Token: 0x04006A4F RID: 27215
	private FOnKSCAttrChange HpDelegate;

	// Token: 0x04006A50 RID: 27216
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IBuffView> CurBuffViewList;

	// Token: 0x04006A51 RID: 27217
	private readonly FName? NamePercent = FNameUtil.GetDynamicFName("percent");

	// Token: 0x04006A52 RID: 27218
	public Action<int> OnSkillClickCallback;

	// Token: 0x04006A53 RID: 27219
	private double LastSkillClickTime;

	// Token: 0x020080E8 RID: 33000
	[NullableContext(0)]
	private enum EState
	{
		// Token: 0x0402BD5B RID: 179547
		None,
		// Token: 0x0402BD5C RID: 179548
		Normal,
		// Token: 0x0402BD5D RID: 179549
		Charge,
		// Token: 0x0402BD5E RID: 179550
		Dead
	}
}
