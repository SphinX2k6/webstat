using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.GameMainView.Data;
using CSharpScript.Game.Module.SkillButtonUi;

// Token: 0x02001DA5 RID: 7589
[NullableContext(2)]
[Nullable(0)]
public class TrapDefenseBattleSkillData : BattleSkillDataBase
{
	// Token: 0x0600DFFA RID: 57338 RVA: 0x003C4354 File Offset: 0x003C2554
	protected override void OnInitData()
	{
		this.Config = this.GetSkillDataConfig(base.GetActionName());
		this.EntityHandle = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (this.EntityHandle != null)
		{
			WorldEntity entity = this.EntityHandle.Entity;
			if (entity != null)
			{
				this.GameplayTagComponent = entity.GetComponent<BaseTagComponent>();
				this.CharacterSkillCdComponent = entity.GetComponent<CharacterSkillCdComponent>();
			}
		}
		if (this.Config != null)
		{
			this.InitSkill();
		}
	}

	// Token: 0x0600DFFB RID: 57339 RVA: 0x003C43C5 File Offset: 0x003C25C5
	protected virtual void InitSkill()
	{
		this.RefreshSkillTexturePath();
	}

	// Token: 0x0600DFFC RID: 57340 RVA: 0x003C43D0 File Offset: 0x003C25D0
	[NullableContext(1)]
	protected SkillGameplayButton? GetSkillDataConfig(string actionName)
	{
		IReadOnlyList<SkillGameplayButton> trapDefenseSkillButtonConfigByType = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseSkillButtonConfigByType(1);
		if (trapDefenseSkillButtonConfigByType != null)
		{
			for (int i = 0; i < trapDefenseSkillButtonConfigByType.Count; i++)
			{
				SkillGameplayButton value = trapDefenseSkillButtonConfigByType[i];
				if (value.ActionName == actionName)
				{
					return new SkillGameplayButton?(value);
				}
			}
		}
		return null;
	}

	// Token: 0x0600DFFD RID: 57341 RVA: 0x003C4424 File Offset: 0x003C2624
	protected virtual void RefreshSkillTexturePath()
	{
		if (this.Config == null)
		{
			return;
		}
		this.SkillTexturePath = this.Config.Value.SkillIcon;
	}

	// Token: 0x0600DFFE RID: 57342 RVA: 0x003C4458 File Offset: 0x003C2658
	public override string GetSkillTexturePath()
	{
		return this.SkillTexturePath;
	}

	// Token: 0x0600DFFF RID: 57343 RVA: 0x003C4460 File Offset: 0x003C2660
	public override void RefreshLongPressTime()
	{
		if (this.Config == null)
		{
			return;
		}
		this.LongPressTime = (float)this.Config.Value.LongPressTime / 1000f;
	}

	// Token: 0x0600E000 RID: 57344 RVA: 0x003C449B File Offset: 0x003C269B
	public override double GetLongPressTime()
	{
		return (double)this.LongPressTime;
	}

	// Token: 0x0600E001 RID: 57345 RVA: 0x003C44A4 File Offset: 0x003C26A4
	public override bool? GetIsLongPressControlCamera()
	{
		if (this.Config == null)
		{
			return new bool?(false);
		}
		return new bool?(this.Config.Value.IsLongPressControlCamera);
	}

	// Token: 0x0600E002 RID: 57346 RVA: 0x003C44E0 File Offset: 0x003C26E0
	public override EInputAction GetActionType()
	{
		if (this.Config == null)
		{
			return EInputAction.None;
		}
		return (EInputAction)((byte)this.Config.Value.ButtonType);
	}

	// Token: 0x0600E003 RID: 57347 RVA: 0x003C451C File Offset: 0x003C271C
	public override ESkillButtonType GetButtonType()
	{
		if (this.Config == null)
		{
			return ESkillButtonType.None;
		}
		return (ESkillButtonType)this.Config.Value.ButtonType;
	}

	// Token: 0x0600E004 RID: 57348 RVA: 0x003C454B File Offset: 0x003C274B
	public override bool IsEnable()
	{
		return this.IsEnableInternal;
	}

	// Token: 0x0600E005 RID: 57349 RVA: 0x003C4553 File Offset: 0x003C2753
	public void SetEnable(bool enable)
	{
		this.IsEnableInternal = enable;
	}

	// Token: 0x0600E006 RID: 57350 RVA: 0x003C455C File Offset: 0x003C275C
	public void SetVisible(bool visible)
	{
		this.IsVisibleInternal = visible;
	}

	// Token: 0x0600E007 RID: 57351 RVA: 0x003C4568 File Offset: 0x003C2768
	public virtual void RefreshSkillCd()
	{
		if (this.CharacterSkillCdComponent != null)
		{
			GroupSkillCdInfo groupSkillCdInfo = this.GetGroupSkillCdInfo();
			if (groupSkillCdInfo == null || groupSkillCdInfo.RemainingCount <= 0)
			{
				this.IsEnableInternal = false;
				return;
			}
		}
		this.IsEnableInternal = true;
	}

	// Token: 0x0600E008 RID: 57352 RVA: 0x003C459F File Offset: 0x003C279F
	public void SetIsBuilding(bool isBuilding)
	{
		this.IsBuilding = isBuilding;
	}

	// Token: 0x0600E009 RID: 57353 RVA: 0x003C45A8 File Offset: 0x003C27A8
	public override bool IsCdVisible()
	{
		if (this.IsBuilding)
		{
			return false;
		}
		int? followerProxyId = TowerDefensePlayerController.GetFollowerProxyId();
		if (followerProxyId == null)
		{
			return false;
		}
		TrapDefenseAuxiliary? auxiliaryById = ConfigBase<TrapDefenseConfig>.Instance.GetAuxiliaryById(followerProxyId.Value);
		return auxiliaryById != null && auxiliaryById.GetValueOrDefault().CDSkill == 1;
	}

	// Token: 0x0600E00A RID: 57354 RVA: 0x003C4600 File Offset: 0x003C2800
	public override string GetSkillIconName()
	{
		if (this.Config == null)
		{
			return null;
		}
		if (base.GetActionName() == "塔防射击" && !this.IsBuilding)
		{
			return null;
		}
		return this.Config.Value.Name;
	}

	// Token: 0x04006B87 RID: 27527
	protected float LongPressTime;

	// Token: 0x04006B88 RID: 27528
	protected SkillGameplayButton? Config;

	// Token: 0x04006B89 RID: 27529
	protected EntityHandle EntityHandle;

	// Token: 0x04006B8A RID: 27530
	protected BaseTagComponent GameplayTagComponent;

	// Token: 0x04006B8B RID: 27531
	protected CharacterSkillCdComponent CharacterSkillCdComponent;

	// Token: 0x04006B8C RID: 27532
	protected string SkillTexturePath;

	// Token: 0x04006B8D RID: 27533
	protected bool IsEnableInternal = true;

	// Token: 0x04006B8E RID: 27534
	private bool IsBuilding;
}
