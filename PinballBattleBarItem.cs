using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D4B RID: 7499
[NullableContext(2)]
[Nullable(0)]
public class PinballBattleBarItem : UiPanelBase, IStaticVariableResetter
{
	// Token: 0x0600DCFA RID: 56570 RVA: 0x003B621C File Offset: 0x003B441C
	static PinballBattleBarItem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PinballBattleBarItem.CreateStaticDefaultValue), new Action(PinballBattleBarItem.ResetStaticDefaultValue));
	}

	// Token: 0x0600DCFB RID: 56571 RVA: 0x003B623B File Offset: 0x003B443B
	public static void CreateStaticDefaultValue()
	{
		PinballBattleBarItem.CurBarChargeType = EKSC_AttrType.SpecialEnergy3;
		PinballBattleBarItem.MaxBarChargeType = EKSC_AttrType.SpecialEnergy3Max;
		PinballBattleBarItem.LevelCompList = new int[]
		{
			0,
			1,
			2,
			3
		};
	}

	// Token: 0x0600DCFC RID: 56572 RVA: 0x003B6261 File Offset: 0x003B4461
	public static void ResetStaticDefaultValue()
	{
		PinballBattleBarItem.CurBarChargeType = EKSC_AttrType.EAttributeType_None;
		PinballBattleBarItem.MaxBarChargeType = EKSC_AttrType.EAttributeType_None;
		PinballBattleBarItem.LevelCompList = null;
	}

	// Token: 0x0600DCFD RID: 56573 RVA: 0x003B6278 File Offset: 0x003B4478
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DCFE RID: 56574 RVA: 0x003B6323 File Offset: 0x003B4523
	protected override void OnStart()
	{
		this.TryBindTeamEntity();
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPinballEntityCreated, new Action<int>(this.OnEntityCreated));
	}

	// Token: 0x0600DCFF RID: 56575 RVA: 0x003B6347 File Offset: 0x003B4547
	protected override void OnBeforeDestroy()
	{
		this.UnBindAttrDelegate();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballEntityCreated, new Action<int>(this.OnEntityCreated));
	}

	// Token: 0x0600DD00 RID: 56576 RVA: 0x003B636B File Offset: 0x003B456B
	private void OnEntityCreated(int entityId)
	{
		if (entityId == 10001)
		{
			this.TryBindTeamEntity();
		}
	}

	// Token: 0x0600DD01 RID: 56577 RVA: 0x003B637C File Offset: 0x003B457C
	private void TryBindTeamEntity()
	{
		AKSC_Shape2D_Entity_TeamPlayer kscTeamPlayer = (ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController).KscTeamPlayer;
		if (kscTeamPlayer != null)
		{
			UKSC_SkillComp skillComp_ = kscTeamPlayer.SkillComp_;
			int? num;
			if (skillComp_ == null)
			{
				num = null;
			}
			else
			{
				UKSC_AttrSet attrSet_ = skillComp_.AttrSet_;
				if (attrSet_ == null)
				{
					num = null;
				}
				else
				{
					TMap<EKSC_AttrType, int> attrs_ = attrSet_.Attrs_;
					num = ((attrs_ != null) ? attrs_.GetValueOrNull(PinballBattleBarItem.MaxBarChargeType) : null);
				}
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			int num3 = 3;
			List<float> list = new List<float>();
			for (int i = 0; i <= num3; i++)
			{
				list.Add((float)(i * valueOrDefault / num3));
			}
			this.Init(kscTeamPlayer, list);
		}
	}

	// Token: 0x0600DD02 RID: 56578 RVA: 0x003B6428 File Offset: 0x003B4628
	[NullableContext(1)]
	public void Init(AKSC_Entity kscEntity, List<float> barLevelChargeRequestList)
	{
		this.BarLevelChargeRequestList.Clear();
		foreach (float item in barLevelChargeRequestList)
		{
			this.BarLevelChargeRequestList.Add(item);
		}
		UKSC_SkillComp skillComp = kscEntity.GetSkillComp();
		UKSC_AttrSet uksc_AttrSet = (skillComp != null) ? skillComp.AttrSet_ : null;
		if (uksc_AttrSet == null)
		{
			return;
		}
		TMap<EKSC_AttrType, int> attrs_ = uksc_AttrSet.Attrs_;
		int valueOrDefault = ((attrs_ != null) ? attrs_.GetValueOrNull(PinballBattleBarItem.CurBarChargeType) : null).GetValueOrDefault();
		int curLevel;
		float percent;
		this.GetBarLevelAndPercent((float)valueOrDefault, out curLevel, out percent);
		this.SetProgress(curLevel, percent);
		this.BindAttrDelegate(uksc_AttrSet);
	}

	// Token: 0x0600DD03 RID: 56579 RVA: 0x003B64E8 File Offset: 0x003B46E8
	[NullableContext(1)]
	public void BindAttrDelegate(UKSC_AttrSet attrSet)
	{
		this.UnBindAttrDelegate();
		this.DelegateAttrChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnBarChargeChange));
		this.DelegateMaxAttrChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnBarMaxChargeChange));
		attrSet.AssignAttrListen(PinballBattleBarItem.CurBarChargeType, this.DelegateAttrChange);
		attrSet.AssignAttrListen(PinballBattleBarItem.MaxBarChargeType, this.DelegateMaxAttrChange);
		this.OwnerAttrSet = attrSet;
	}

	// Token: 0x0600DD04 RID: 56580 RVA: 0x003B6554 File Offset: 0x003B4754
	public void UnBindAttrDelegate()
	{
		if (this.OwnerAttrSet != null)
		{
			if (this.DelegateAttrChange != null)
			{
				this.OwnerAttrSet.RemoveAttrListen(PinballBattleBarItem.CurBarChargeType, this.DelegateAttrChange);
			}
			if (this.DelegateMaxAttrChange != null)
			{
				this.OwnerAttrSet.RemoveAttrListen(PinballBattleBarItem.MaxBarChargeType, this.DelegateMaxAttrChange);
			}
			this.DelegateAttrChange = null;
			this.DelegateMaxAttrChange = null;
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnBarChargeChange));
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnBarMaxChargeChange));
			this.OwnerAttrSet = null;
		}
	}

	// Token: 0x0600DD05 RID: 56581 RVA: 0x003B65DC File Offset: 0x003B47DC
	private void OnBarChargeChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateBarChargeDisplay();
	}

	// Token: 0x0600DD06 RID: 56582 RVA: 0x003B65E4 File Offset: 0x003B47E4
	private void OnBarMaxChargeChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateBarChargeDisplay();
	}

	// Token: 0x0600DD07 RID: 56583 RVA: 0x003B65EC File Offset: 0x003B47EC
	private void UpdateBarChargeDisplay()
	{
		if (this.OwnerAttrSet == null)
		{
			return;
		}
		TMap<EKSC_AttrType, int> attrs_ = this.OwnerAttrSet.Attrs_;
		int valueOrDefault = ((attrs_ != null) ? attrs_.GetValueOrNull(PinballBattleBarItem.CurBarChargeType) : null).GetValueOrDefault();
		int curLevel;
		float percent;
		this.GetBarLevelAndPercent((float)valueOrDefault, out curLevel, out percent);
		this.SetProgress(curLevel, percent);
	}

	// Token: 0x0600DD08 RID: 56584 RVA: 0x003B6643 File Offset: 0x003B4843
	private void SetProgress(int curLevel, float percent)
	{
		if (this.CurLevel != -1 && this.CurLevel != curLevel)
		{
			this.ClearPreviousProgress();
		}
		this.CurLevel = curLevel;
		this.SetLevelFillAmount(curLevel, 1f);
		if (curLevel < this.GetMaxBarLevel())
		{
			this.SetLevelFillAmount(curLevel + 1, percent);
		}
	}

	// Token: 0x0600DD09 RID: 56585 RVA: 0x003B6683 File Offset: 0x003B4883
	private void ClearPreviousProgress()
	{
		this.SetLevelFillAmount(this.CurLevel, 0f);
		if (this.CurLevel < this.GetMaxBarLevel())
		{
			this.SetLevelFillAmount(this.CurLevel + 1, 0f);
		}
	}

	// Token: 0x0600DD0A RID: 56586 RVA: 0x003B66B7 File Offset: 0x003B48B7
	private void SetLevelFillAmount(int level, float amount)
	{
		if (level < 0 || level >= PinballBattleBarItem.LevelCompList.Length)
		{
			return;
		}
		UUITexture texture = base.GetTexture(PinballBattleBarItem.LevelCompList[level]);
		if (texture == null)
		{
			return;
		}
		texture.SetFillAmount(amount);
	}

	// Token: 0x0600DD0B RID: 56587 RVA: 0x003B66E0 File Offset: 0x003B48E0
	private int GetMaxBarLevel()
	{
		return this.BarLevelChargeRequestList.Count;
	}

	// Token: 0x0600DD0C RID: 56588 RVA: 0x003B66F0 File Offset: 0x003B48F0
	public void GetBarLevelAndPercent(float newValue, out int curLevel, out float percentToNextLevel)
	{
		curLevel = 0;
		foreach (float num in this.BarLevelChargeRequestList)
		{
			if (newValue < num)
			{
				break;
			}
			curLevel++;
		}
		curLevel = Math.Min(curLevel, this.GetMaxBarLevel());
		percentToNextLevel = 0f;
		if (curLevel < this.GetMaxBarLevel() && curLevel < this.BarLevelChargeRequestList.Count)
		{
			float num2 = (curLevel > 0) ? this.BarLevelChargeRequestList[curLevel - 1] : 0f;
			float num3 = this.BarLevelChargeRequestList[curLevel];
			float num4 = newValue - num2;
			float num5 = num3 - num2;
			percentToNextLevel = ((num5 > 0f) ? (num4 / num5) : 0f);
		}
	}

	// Token: 0x040069DA RID: 27098
	private static EKSC_AttrType CurBarChargeType;

	// Token: 0x040069DB RID: 27099
	private static EKSC_AttrType MaxBarChargeType;

	// Token: 0x040069DC RID: 27100
	private static int[] LevelCompList;

	// Token: 0x040069DD RID: 27101
	private int CurLevel = -1;

	// Token: 0x040069DE RID: 27102
	private UKSC_AttrSet OwnerAttrSet;

	// Token: 0x040069DF RID: 27103
	[Nullable(1)]
	private readonly List<float> BarLevelChargeRequestList = new List<float>();

	// Token: 0x040069E0 RID: 27104
	private FOnKSCAttrChange DelegateAttrChange;

	// Token: 0x040069E1 RID: 27105
	private FOnKSCAttrChange DelegateMaxAttrChange;
}
