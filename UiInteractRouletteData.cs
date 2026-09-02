using System;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.InstanceDungeon;

// Token: 0x02003444 RID: 13380
public class UiInteractRouletteData
{
	// Token: 0x17002647 RID: 9799
	// (get) Token: 0x0601C0D7 RID: 114903 RVA: 0x0085CCB9 File Offset: 0x0085AEB9
	public double DurationTime
	{
		get
		{
			return this.CloseTime - this.OpenTime;
		}
	}

	// Token: 0x0601C0D8 RID: 114904 RVA: 0x0085CCC8 File Offset: 0x0085AEC8
	public void TriggerOpen()
	{
		this.Reset();
		this.IsStart = true;
		this.OpenTime = Singleton<Time>.Instance.ServerTimeStamp;
		this.OldRound = this.GetWaveCount();
		this.UseSkillId = this.GetUseSkillId();
	}

	// Token: 0x0601C0D9 RID: 114905 RVA: 0x0085CCFF File Offset: 0x0085AEFF
	public void TriggerClose()
	{
		this.CloseTime = Singleton<Time>.Instance.ServerTimeStamp;
		this.NewRound = this.GetWaveCount();
		this.IsStart = false;
	}

	// Token: 0x0601C0DA RID: 114906 RVA: 0x0085CD24 File Offset: 0x0085AF24
	public void Reset()
	{
		this.OpenTime = 0.0;
		this.CloseTime = 0.0;
		this.OldRound = 0;
		this.NewRound = 0;
		this.UseSkillId = 0L;
		this.IsStart = false;
	}

	// Token: 0x0601C0DB RID: 114907 RVA: 0x0085CD64 File Offset: 0x0085AF64
	private int GetWaveCount()
	{
		InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
		if (((instanceDungeonInfo != null) ? instanceDungeonInfo.Tree : null) == null)
		{
			return 0;
		}
		VarDefinePb treeVarByKey = instanceDungeonInfo.Tree.GetTreeVarByKey(EGradingSystemVarType.Wave.ToEnumString());
		if (treeVarByKey == null)
		{
			return 0;
		}
		return (int)Singleton<MathUtils>.Instance.LongToNumber(treeVarByKey.Int);
	}

	// Token: 0x0601C0DC RID: 114908 RVA: 0x0085CDB4 File Offset: 0x0085AFB4
	private long GetUseSkillId()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		BaseSkillComponent baseSkillComponent;
		if (getCurrentEntity == null)
		{
			baseSkillComponent = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			baseSkillComponent = ((entity != null) ? entity.GetComponent<BaseSkillComponent>() : null);
		}
		BaseSkillComponent baseSkillComponent2 = baseSkillComponent;
		if (((baseSkillComponent2 != null) ? baseSkillComponent2.CurrentSkill : null) == null)
		{
			return 0L;
		}
		return (long)baseSkillComponent2.CurrentSkill.SkillId;
	}

	// Token: 0x0400E2A3 RID: 58019
	private double OpenTime;

	// Token: 0x0400E2A4 RID: 58020
	private double CloseTime;

	// Token: 0x0400E2A5 RID: 58021
	public int OldRound;

	// Token: 0x0400E2A6 RID: 58022
	public int NewRound;

	// Token: 0x0400E2A7 RID: 58023
	public bool IsStart;

	// Token: 0x0400E2A8 RID: 58024
	public long UseSkillId;
}
