using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.GameMainView.Data;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

// Token: 0x02001D8B RID: 7563
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueBattleSkillData : BattleSkillDataBase
{
	// Token: 0x0600DECE RID: 57038 RVA: 0x003BF0E8 File Offset: 0x003BD2E8
	public SurvivorsRogueBattleSkillData(int skillId)
	{
		this.SkillId = skillId;
	}

	// Token: 0x0600DECF RID: 57039 RVA: 0x003BF108 File Offset: 0x003BD308
	protected override void OnInitData()
	{
		if (this.SkillId == 0)
		{
			return;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		this.EntityHandle = ((instance != null) ? instance.GetCurrentEntity : null);
		if (this.EntityHandle != null)
		{
			WorldEntity entity = this.EntityHandle.Entity;
			if (entity != null)
			{
				this.CharacterSkillCdComponent = entity.GetComponent<CharacterSkillCdComponent>();
				this.CharacterSkillComponent = entity.GetComponent<CharacterSkillComponent>();
			}
		}
		if (base.GetActionName() == "闪避")
		{
			this.IsCdVisibleInternal = false;
			CharacterSkillComponent characterSkillComponent = this.CharacterSkillComponent;
			this.SkillConfig = ((characterSkillComponent != null) ? characterSkillComponent.GetSkillInfo(this.SkillId) : null);
		}
		else
		{
			this.SkillButtonConfig = this.GetActiveSkillButtonConfig();
		}
		CharacterSkillCdComponent characterSkillCdComponent = this.CharacterSkillCdComponent;
		this.GroupSkillCdInfo = ((characterSkillCdComponent != null) ? characterSkillCdComponent.GetGroupSkillCdInfo(this.SkillId) : null);
	}

	// Token: 0x0600DED0 RID: 57040 RVA: 0x003BF1C8 File Offset: 0x003BD3C8
	private SkillGameplayButton? GetActiveSkillButtonConfig()
	{
		SurvivorsRogueConfig instance = ConfigBase<SurvivorsRogueConfig>.Instance;
		IReadOnlyList<SkillGameplayButton> readOnlyList = (instance != null) ? instance.GetSkillButtonConfigByType(2) : null;
		if (readOnlyList == null)
		{
			return null;
		}
		int curRoleId = ModelBase<SurvivorsRogueModel>.Instance.CurRoleId;
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			SkillGameplayButton value = readOnlyList[i];
			if (value.ActionName == base.GetActionName() && value.RoleId == curRoleId)
			{
				return new SkillGameplayButton?(value);
			}
		}
		return null;
	}

	// Token: 0x0600DED1 RID: 57041 RVA: 0x003BF24C File Offset: 0x003BD44C
	public void RefreshSkillCd()
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

	// Token: 0x0600DED2 RID: 57042 RVA: 0x003BF283 File Offset: 0x003BD483
	public override int GetSkillId()
	{
		return this.SkillId;
	}

	// Token: 0x0600DED3 RID: 57043 RVA: 0x003BF28C File Offset: 0x003BD48C
	public override string GetSkillTexturePath()
	{
		if (base.GetActionName() == "闪避")
		{
			SSkillInfo skillConfig = this.SkillConfig;
			if (skillConfig == null)
			{
				return null;
			}
			FSoftObjectPath skillIcon = skillConfig.SkillIcon;
			if (skillIcon == null)
			{
				return null;
			}
			return skillIcon.AssetPathName.ToString();
		}
		else
		{
			if (this.SkillButtonConfig == null)
			{
				return null;
			}
			return this.SkillButtonConfig.GetValueOrDefault().SkillIcon;
		}
	}

	// Token: 0x0600DED4 RID: 57044 RVA: 0x003BF2F4 File Offset: 0x003BD4F4
	public override EInputAction GetActionType()
	{
		if (this.SkillButtonConfig != null)
		{
			return (EInputAction)((byte)this.SkillButtonConfig.Value.ButtonType);
		}
		return EInputAction.闪避;
	}

	// Token: 0x0600DED5 RID: 57045 RVA: 0x003BF330 File Offset: 0x003BD530
	public override ESkillButtonType GetButtonType()
	{
		if (this.SkillButtonConfig != null)
		{
			return (ESkillButtonType)this.SkillButtonConfig.Value.ButtonType;
		}
		return ESkillButtonType.闪避;
	}

	// Token: 0x0600DED6 RID: 57046 RVA: 0x003BF35F File Offset: 0x003BD55F
	public override bool IsEnable()
	{
		return this.IsEnableInternal;
	}

	// Token: 0x0600DED7 RID: 57047 RVA: 0x003BF367 File Offset: 0x003BD567
	public override GroupSkillCdInfo GetGroupSkillCdInfo()
	{
		return this.GroupSkillCdInfo;
	}

	// Token: 0x0600DED8 RID: 57048 RVA: 0x003BF36F File Offset: 0x003BD56F
	public override bool HasCdComponent()
	{
		return true;
	}

	// Token: 0x0600DED9 RID: 57049 RVA: 0x003BF372 File Offset: 0x003BD572
	public override float GetSkillRemainingCoolDown()
	{
		if (this.GroupSkillCdInfo != null)
		{
			return this.GroupSkillCdInfo.CurRemainingCd;
		}
		return 0f;
	}

	// Token: 0x0600DEDA RID: 57050 RVA: 0x003BF38D File Offset: 0x003BD58D
	public override bool IsCdVisible()
	{
		return this.IsCdVisibleInternal;
	}

	// Token: 0x04006B1F RID: 27423
	private bool IsEnableInternal = true;

	// Token: 0x04006B20 RID: 27424
	private readonly int SkillId;

	// Token: 0x04006B21 RID: 27425
	private SkillGameplayButton? SkillButtonConfig;

	// Token: 0x04006B22 RID: 27426
	private SSkillInfo SkillConfig;

	// Token: 0x04006B23 RID: 27427
	private GroupSkillCdInfo GroupSkillCdInfo;

	// Token: 0x04006B24 RID: 27428
	private EntityHandle EntityHandle;

	// Token: 0x04006B25 RID: 27429
	private CharacterSkillComponent CharacterSkillComponent;

	// Token: 0x04006B26 RID: 27430
	private CharacterSkillCdComponent CharacterSkillCdComponent;

	// Token: 0x04006B27 RID: 27431
	private bool IsCdVisibleInternal = true;
}
