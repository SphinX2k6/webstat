using System;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.InstanceDungeon;

// Token: 0x02003441 RID: 13377
public class UiInteractChatData
{
	// Token: 0x17002646 RID: 9798
	// (get) Token: 0x0601C0C4 RID: 114884 RVA: 0x0085C8F6 File Offset: 0x0085AAF6
	public double DurationTime
	{
		get
		{
			return this.CloseTime - this.OpenTime;
		}
	}

	// Token: 0x0601C0C5 RID: 114885 RVA: 0x0085C905 File Offset: 0x0085AB05
	public void TriggerOpen()
	{
		this.Reset();
		this.IsStart = true;
		this.OpenTime = Singleton<Time>.Instance.ServerTimeStamp;
		this.OldRound = this.GetWaveCount();
		this.UseSkillId = this.GetUseSkillId();
	}

	// Token: 0x0601C0C6 RID: 114886 RVA: 0x0085C93C File Offset: 0x0085AB3C
	public void TriggerClose()
	{
		this.CloseTime = Singleton<Time>.Instance.ServerTimeStamp;
		this.NewRound = this.GetWaveCount();
		this.IsStart = false;
	}

	// Token: 0x0601C0C7 RID: 114887 RVA: 0x0085C961 File Offset: 0x0085AB61
	public void Reset()
	{
		this.OpenTime = 0.0;
		this.CloseTime = 0.0;
		this.OldRound = 0;
		this.NewRound = 0;
		this.UseSkillId = 0L;
		this.IsStart = false;
	}

	// Token: 0x0601C0C8 RID: 114888 RVA: 0x0085C9A0 File Offset: 0x0085ABA0
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

	// Token: 0x0601C0C9 RID: 114889 RVA: 0x0085C9F0 File Offset: 0x0085ABF0
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

	// Token: 0x0400E28E RID: 57998
	private double OpenTime;

	// Token: 0x0400E28F RID: 57999
	private double CloseTime;

	// Token: 0x0400E290 RID: 58000
	public int OldRound;

	// Token: 0x0400E291 RID: 58001
	public int NewRound;

	// Token: 0x0400E292 RID: 58002
	public bool IsStart;

	// Token: 0x0400E293 RID: 58003
	public long UseSkillId;
}
