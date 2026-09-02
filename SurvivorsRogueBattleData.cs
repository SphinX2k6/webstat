using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.SkillButtonUi;

// Token: 0x02002AF4 RID: 10996
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueBattleData : ISkillButtonUiEventInterface
{
	// Token: 0x06015FCE RID: 90062 RVA: 0x0061A409 File Offset: 0x00618609
	public static SurvivorsRogueBattleData Create()
	{
		return new SurvivorsRogueBattleData();
	}

	// Token: 0x06015FCF RID: 90063 RVA: 0x0061A410 File Offset: 0x00618610
	public void InitBattleSkillData()
	{
		this.BattleSkillData["技能1"] = this.CreateSkillData(220003, "技能1");
		this.BattleSkillData["闪避"] = this.CreateSkillData(100001, "闪避");
	}

	// Token: 0x06015FD0 RID: 90064 RVA: 0x0061A45D File Offset: 0x0061865D
	private SurvivorsRogueBattleSkillData CreateSkillData(int skillId, string actionName)
	{
		SurvivorsRogueBattleSkillData survivorsRogueBattleSkillData = new SurvivorsRogueBattleSkillData(skillId);
		survivorsRogueBattleSkillData.InitData(actionName);
		return survivorsRogueBattleSkillData;
	}

	// Token: 0x06015FD1 RID: 90065 RVA: 0x0061A46C File Offset: 0x0061866C
	[return: Nullable(2)]
	public SurvivorsRogueBattleSkillData GetBattleSkillData(string actionName)
	{
		SurvivorsRogueBattleSkillData result;
		if (!this.BattleSkillData.TryGetValue(actionName, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06015FD2 RID: 90066 RVA: 0x0061A48C File Offset: 0x0061868C
	public void Clear()
	{
		BehaviorTreeUpdateDelegateProxy behaviorDelegate = this.BehaviorDelegate;
		if (behaviorDelegate != null)
		{
			behaviorDelegate.Clear();
		}
		this.BattleSkillData.Clear();
	}

	// Token: 0x06015FD3 RID: 90067 RVA: 0x0061A4AA File Offset: 0x006186AA
	public bool IsCoinEfficiencyEnhance()
	{
		return true;
	}

	// Token: 0x06015FD4 RID: 90068 RVA: 0x0061A4B0 File Offset: 0x006186B0
	public void SetBehaviorTreeVar(Dictionary<string, string> variableKeyNames)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (KeyValuePair<string, string> keyValuePair in variableKeyNames)
		{
			dictionary[keyValuePair.Key] = keyValuePair.Value;
		}
		this.BehaviorDelegate.SetBehaviorTreeVarRelation(dictionary);
	}

	// Token: 0x06015FD5 RID: 90069 RVA: 0x0061A520 File Offset: 0x00618720
	[NullableContext(2)]
	public VarDefinePb GetBehaviorTreeVar(ESurvivorsRougeSystemVarType varType)
	{
		return this.BehaviorDelegate.GetBehaviorTreeVar(varType.ToEnumString());
	}

	// Token: 0x06015FD6 RID: 90070 RVA: 0x0061A533 File Offset: 0x00618733
	public int GetBehaviorTreeVarToNumber(ESurvivorsRougeSystemVarType varType)
	{
		return (int)this.BehaviorDelegate.GetBehaviorTreeVarToNumber(varType.ToEnumString());
	}

	// Token: 0x06015FD7 RID: 90071 RVA: 0x0061A547 File Offset: 0x00618747
	public int GetCurrencyCount()
	{
		return this.GetBehaviorTreeVarToNumber(ESurvivorsRougeSystemVarType.Gold);
	}

	// Token: 0x06015FD8 RID: 90072 RVA: 0x0061A550 File Offset: 0x00618750
	public int GetBatch()
	{
		return this.GetBehaviorTreeVarToNumber(ESurvivorsRougeSystemVarType.Batch);
	}

	// Token: 0x06015FD9 RID: 90073 RVA: 0x0061A559 File Offset: 0x00618759
	public int GetMaxBatch()
	{
		return this.GetBehaviorTreeVarToNumber(ESurvivorsRougeSystemVarType.MaxBatch);
	}

	// Token: 0x06015FDA RID: 90074 RVA: 0x0061A562 File Offset: 0x00618762
	public int GetChestCount()
	{
		return this.GetBehaviorTreeVarToNumber(ESurvivorsRougeSystemVarType.TreasureBoxCount);
	}

	// Token: 0x06015FDB RID: 90075 RVA: 0x0061A56B File Offset: 0x0061876B
	public int GetComboKillCount()
	{
		return this.GetBehaviorTreeVarToNumber(ESurvivorsRougeSystemVarType.ConsecutiveKillCount);
	}

	// Token: 0x06015FDC RID: 90076 RVA: 0x0061A574 File Offset: 0x00618774
	public int GetGoldGainEfficiency()
	{
		return this.GetBehaviorTreeVarToNumber(ESurvivorsRougeSystemVarType.GoldGainEfficiency);
	}

	// Token: 0x17001C98 RID: 7320
	// (get) Token: 0x06015FDD RID: 90077 RVA: 0x0061A57D File Offset: 0x0061877D
	public bool EndlessWaveEnabled
	{
		get
		{
			return this.GetBehaviorTreeVarToNumber(ESurvivorsRougeSystemVarType.EndlessBatchLimit) == 1;
		}
	}

	// Token: 0x06015FDE RID: 90078 RVA: 0x0061A589 File Offset: 0x00618789
	public void EquipExplorePhantomSkill()
	{
	}

	// Token: 0x06015FDF RID: 90079 RVA: 0x0061A58B File Offset: 0x0061878B
	public void SkillCountChanged(GroupSkillCdInfo groupSkillCdInfo)
	{
		this.RefreshSkillCd(groupSkillCdInfo);
	}

	// Token: 0x06015FE0 RID: 90080 RVA: 0x0061A594 File Offset: 0x00618794
	public void SkillRemainCdChanged(GroupSkillCdInfo groupSkillCdInfo)
	{
		this.RefreshSkillCd(groupSkillCdInfo);
	}

	// Token: 0x06015FE1 RID: 90081 RVA: 0x0061A5A0 File Offset: 0x006187A0
	private void RefreshSkillCd(GroupSkillCdInfo groupSkillCdInfo)
	{
		foreach (int num in groupSkillCdInfo.SkillCdInfoMap.Keys)
		{
			foreach (SurvivorsRogueBattleSkillData survivorsRogueBattleSkillData in this.BattleSkillData.Values)
			{
				if (survivorsRogueBattleSkillData.GetSkillId() == num)
				{
					survivorsRogueBattleSkillData.RefreshSkillCd();
					Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, survivorsRogueBattleSkillData.GetButtonType());
				}
			}
		}
	}

	// Token: 0x0400A8DA RID: 43226
	private const int ACTIVE_SKILL_ID = 220003;

	// Token: 0x0400A8DB RID: 43227
	private const int DODGE_SKILL_ID = 100001;

	// Token: 0x0400A8DC RID: 43228
	public BehaviorTreeUpdateDelegateProxy BehaviorDelegate = new BehaviorTreeUpdateDelegateProxy();

	// Token: 0x0400A8DD RID: 43229
	private readonly Dictionary<string, SurvivorsRogueBattleSkillData> BattleSkillData = new Dictionary<string, SurvivorsRogueBattleSkillData>();
}
