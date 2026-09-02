using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.GameMainView.Data;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

// Token: 0x02001D28 RID: 7464
[NullableContext(2)]
[Nullable(0)]
public class KurotatoBattleSkillData : BattleSkillDataBase
{
	// Token: 0x0600DBA1 RID: 56225 RVA: 0x003B0398 File Offset: 0x003AE598
	public KurotatoBattleSkillData(int skillId)
	{
		this.SkillId = skillId;
	}

	// Token: 0x0600DBA2 RID: 56226 RVA: 0x003B03B0 File Offset: 0x003AE5B0
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
		CharacterSkillComponent characterSkillComponent = this.CharacterSkillComponent;
		this.SkillConfig = ((characterSkillComponent != null) ? characterSkillComponent.GetSkillInfo(this.SkillId) : null);
		CharacterSkillCdComponent characterSkillCdComponent = this.CharacterSkillCdComponent;
		this.GroupSkillCdInfo = ((characterSkillCdComponent != null) ? characterSkillCdComponent.GetGroupSkillCdInfo(this.SkillId) : null);
	}

	// Token: 0x0600DBA3 RID: 56227 RVA: 0x003B0448 File Offset: 0x003AE648
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

	// Token: 0x0600DBA4 RID: 56228 RVA: 0x003B047F File Offset: 0x003AE67F
	public override int GetSkillId()
	{
		return this.SkillId;
	}

	// Token: 0x0600DBA5 RID: 56229 RVA: 0x003B0488 File Offset: 0x003AE688
	public override string GetSkillTexturePath()
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

	// Token: 0x0600DBA6 RID: 56230 RVA: 0x003B04BF File Offset: 0x003AE6BF
	public override EInputAction GetActionType()
	{
		return EInputAction.闪避;
	}

	// Token: 0x0600DBA7 RID: 56231 RVA: 0x003B04C6 File Offset: 0x003AE6C6
	public override ESkillButtonType GetButtonType()
	{
		return ESkillButtonType.闪避;
	}

	// Token: 0x0600DBA8 RID: 56232 RVA: 0x003B04C9 File Offset: 0x003AE6C9
	public override bool IsEnable()
	{
		return this.IsEnableInternal;
	}

	// Token: 0x0600DBA9 RID: 56233 RVA: 0x003B04D1 File Offset: 0x003AE6D1
	public override GroupSkillCdInfo GetGroupSkillCdInfo()
	{
		return this.GroupSkillCdInfo;
	}

	// Token: 0x0600DBAA RID: 56234 RVA: 0x003B04D9 File Offset: 0x003AE6D9
	public override bool HasCdComponent()
	{
		return true;
	}

	// Token: 0x0600DBAB RID: 56235 RVA: 0x003B04DC File Offset: 0x003AE6DC
	public override float GetSkillRemainingCoolDown()
	{
		if (this.GroupSkillCdInfo != null)
		{
			return this.GroupSkillCdInfo.CurRemainingCd;
		}
		return 0f;
	}

	// Token: 0x0600DBAC RID: 56236 RVA: 0x003B04F7 File Offset: 0x003AE6F7
	public override bool IsCdVisible()
	{
		return true;
	}

	// Token: 0x040068FD RID: 26877
	private bool IsEnableInternal = true;

	// Token: 0x040068FE RID: 26878
	private readonly int SkillId;

	// Token: 0x040068FF RID: 26879
	private SSkillInfo SkillConfig;

	// Token: 0x04006900 RID: 26880
	private GroupSkillCdInfo GroupSkillCdInfo;

	// Token: 0x04006901 RID: 26881
	private EntityHandle EntityHandle;

	// Token: 0x04006902 RID: 26882
	private CharacterSkillComponent CharacterSkillComponent;

	// Token: 0x04006903 RID: 26883
	private CharacterSkillCdComponent CharacterSkillCdComponent;
}
