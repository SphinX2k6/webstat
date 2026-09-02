using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;

// Token: 0x0200310E RID: 12558
[NullableContext(1)]
[Nullable(0)]
public class BaseSkillCdComponent : EntityComponent
{
	// Token: 0x06019F84 RID: 106372 RVA: 0x0079A0D2 File Offset: 0x007982D2
	protected override bool OnInit()
	{
		this.BuffComp = base.Entity.CheckGetComponent<BaseBuffComponent>();
		this.PassiveSkillCdInfoMap = new Dictionary<long, PassiveSkillCdInfo>();
		this.CurWorldPassiveSkillCdData = ModelBase<SkillCdModel>.Instance.GetCurWorldPassiveSkillCdData();
		return true;
	}

	// Token: 0x06019F85 RID: 106373 RVA: 0x0079A101 File Offset: 0x00798301
	protected override bool OnEnd()
	{
		base.OnEnd();
		if (this.CurWorldPassiveSkillCdData != null)
		{
			this.CurWorldPassiveSkillCdData.RemoveEntity(base.Entity);
			this.CurWorldPassiveSkillCdData = null;
		}
		return true;
	}

	// Token: 0x06019F86 RID: 106374 RVA: 0x0079A12C File Offset: 0x0079832C
	public void UpdateModifyCdEffect(bool bAdd, ModifyCd modifyCdEffect)
	{
		if (this.BuffComp == null)
		{
			this.HasModifyCdEffect = false;
			return;
		}
		if (bAdd)
		{
			this.HasModifyCdEffect = true;
			return;
		}
		foreach (ModifyCd modifyCd in this.BuffComp.BuffEffectManager.FilterById<ModifyCd>(EExtraEffectId.ModifyCd, null))
		{
			if (modifyCdEffect != modifyCd && modifyCd.SkillIdOrGenres.Count > 0)
			{
				this.HasModifyCdEffect = true;
				return;
			}
		}
		this.HasModifyCdEffect = false;
	}

	// Token: 0x06019F87 RID: 106375 RVA: 0x0079A1BC File Offset: 0x007983BC
	public PassiveSkillCdInfo InitPassiveSkill(PassiveSkill passiveSkill)
	{
		long id = passiveSkill.Id;
		PassiveSkillCdInfo passiveSkillCdInfo;
		if (this.PassiveSkillCdInfoMap.TryGetValue(id, out passiveSkillCdInfo))
		{
			return passiveSkillCdInfo;
		}
		passiveSkillCdInfo = this.CurWorldPassiveSkillCdData.InitPassiveSkillCd(base.Entity, passiveSkill);
		this.PassiveSkillCdInfoMap.Add(id, passiveSkillCdInfo);
		return passiveSkillCdInfo;
	}

	// Token: 0x06019F88 RID: 106376 RVA: 0x0079A208 File Offset: 0x00798408
	public bool IsPassiveSkillInCd(long skillId, int entityId)
	{
		PassiveSkillCdInfo passiveSkillCdInfo;
		return this.PassiveSkillCdInfoMap.TryGetValue(skillId, out passiveSkillCdInfo) && passiveSkillCdInfo.IsInCd(entityId);
	}

	// Token: 0x06019F89 RID: 106377 RVA: 0x0079A230 File Offset: 0x00798430
	public bool StartPassiveCd(long skillId, int entityId, float cdTime = -1f)
	{
		PassiveSkillCdInfo passiveSkillCdInfo;
		if (!this.PassiveSkillCdInfoMap.TryGetValue(skillId, out passiveSkillCdInfo))
		{
			return false;
		}
		passiveSkillCdInfo.StartCd(passiveSkillCdInfo.SkillId, entityId, cdTime);
		return true;
	}

	// Token: 0x06019F8A RID: 106378 RVA: 0x0079A25F File Offset: 0x0079845F
	public PassiveSkillCdInfo GetPassiveSkillCdInfo(long skillId)
	{
		return this.PassiveSkillCdInfoMap[skillId];
	}

	// Token: 0x06019F8B RID: 106379 RVA: 0x0079A270 File Offset: 0x00798470
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseSkillCdComponent baseSkillCdComponent = (BaseSkillCdComponent)componentTemplate;
		if (base.CanResetComponentProperty("BuffComp"))
		{
			if (baseSkillCdComponent.BuffComp == null)
			{
				this.BuffComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseBuffComponent>(this.BuffComp), "BuffComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HasModifyCdEffect"))
		{
			this.HasModifyCdEffect = baseSkillCdComponent.HasModifyCdEffect;
		}
		if (base.CanResetComponentProperty("PassiveSkillCdInfoMap"))
		{
			if (baseSkillCdComponent.PassiveSkillCdInfoMap == null)
			{
				this.PassiveSkillCdInfoMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, PassiveSkillCdInfo>>(this.PassiveSkillCdInfoMap), "PassiveSkillCdInfoMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurWorldPassiveSkillCdData"))
		{
			if (baseSkillCdComponent.CurWorldPassiveSkillCdData == null)
			{
				this.CurWorldPassiveSkillCdData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<WorldPassiveSkillCdData>(this.CurWorldPassiveSkillCdData), "CurWorldPassiveSkillCdData"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D045 RID: 53317
	[Nullable(2)]
	protected BaseBuffComponent BuffComp;

	// Token: 0x0400D046 RID: 53318
	public bool HasModifyCdEffect;

	// Token: 0x0400D047 RID: 53319
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<long, PassiveSkillCdInfo> PassiveSkillCdInfoMap;

	// Token: 0x0400D048 RID: 53320
	[Nullable(2)]
	private WorldPassiveSkillCdData CurWorldPassiveSkillCdData;
}
