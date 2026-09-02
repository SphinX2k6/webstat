using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;

// Token: 0x02002275 RID: 8821
public class MoraleBuffData
{
	// Token: 0x06010ACB RID: 68299 RVA: 0x00490D2F File Offset: 0x0048EF2F
	[NullableContext(1)]
	public static MoraleBuffData Create(MoraleLvPower cfg)
	{
		MoraleBuffData moraleBuffData = new MoraleBuffData(cfg);
		moraleBuffData.Init();
		return moraleBuffData;
	}

	// Token: 0x06010ACC RID: 68300 RVA: 0x00490D3D File Offset: 0x0048EF3D
	private MoraleBuffData(MoraleLvPower cfg)
	{
		this.Id = cfg.Id;
		this.Config = cfg;
	}

	// Token: 0x06010ACD RID: 68301 RVA: 0x00490D59 File Offset: 0x0048EF59
	private void Init()
	{
		this.EndStageLv = this.Config.LvStage;
	}

	// Token: 0x06010ACE RID: 68302 RVA: 0x00490D6C File Offset: 0x0048EF6C
	public void SetStartStageLv(int lv)
	{
		this.StartStageLv = lv;
	}

	// Token: 0x06010ACF RID: 68303 RVA: 0x00490D75 File Offset: 0x0048EF75
	public void SetIndex(int index)
	{
		this.Index = index;
	}

	// Token: 0x06010AD0 RID: 68304 RVA: 0x00490D80 File Offset: 0x0048EF80
	public EMoraleBuffState GetActiveState()
	{
		int lvStage = this.Config.LvStage;
		int moraleLevel = ModelBase<MoraleBattleModel>.Instance.GetMoraleLevel();
		if (moraleLevel >= lvStage)
		{
			return EMoraleBuffState.Active;
		}
		int tempMoraleLevel = ModelBase<MoraleBattleModel>.Instance.GetTempMoraleLevel();
		if (moraleLevel + tempMoraleLevel >= lvStage)
		{
			return EMoraleBuffState.TempActive;
		}
		return EMoraleBuffState.NotActive;
	}

	// Token: 0x06010AD1 RID: 68305 RVA: 0x00490DBE File Offset: 0x0048EFBE
	public bool IsActive()
	{
		return this.GetActiveState() == EMoraleBuffState.Active;
	}

	// Token: 0x06010AD2 RID: 68306 RVA: 0x00490DC9 File Offset: 0x0048EFC9
	public bool IsTempActive()
	{
		return this.GetActiveState() == EMoraleBuffState.TempActive;
	}

	// Token: 0x06010AD3 RID: 68307 RVA: 0x00490DD4 File Offset: 0x0048EFD4
	public bool IsNotActive()
	{
		return this.GetActiveState() == EMoraleBuffState.NotActive;
	}

	// Token: 0x06010AD4 RID: 68308 RVA: 0x00490DE0 File Offset: 0x0048EFE0
	public bool IsActiveOrTempActive()
	{
		EMoraleBuffState activeState = this.GetActiveState();
		return activeState == EMoraleBuffState.Active || activeState == EMoraleBuffState.TempActive;
	}

	// Token: 0x06010AD5 RID: 68309 RVA: 0x00490DFE File Offset: 0x0048EFFE
	public void SetSelectState(bool isSelect)
	{
		this.IsSelect = isSelect;
	}

	// Token: 0x04008368 RID: 33640
	public int Id;

	// Token: 0x04008369 RID: 33641
	public MoraleLvPower Config;

	// Token: 0x0400836A RID: 33642
	public bool IsSelect;

	// Token: 0x0400836B RID: 33643
	public int StartStageLv;

	// Token: 0x0400836C RID: 33644
	public int EndStageLv;

	// Token: 0x0400836D RID: 33645
	public int Index;
}
