using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;

// Token: 0x02003142 RID: 12610
[NullableContext(1)]
[Nullable(0)]
public class SpecialSkillAimisi : SpecialSkillMorphBase
{
	// Token: 0x17002372 RID: 9074
	// (get) Token: 0x0601A1AF RID: 106927 RVA: 0x007A8D89 File Offset: 0x007A6F89
	protected override string MorphBuffsConfigKey
	{
		get
		{
			return "AimisiMorphBuffs";
		}
	}

	// Token: 0x17002373 RID: 9075
	// (get) Token: 0x0601A1B0 RID: 106928 RVA: 0x007A8D90 File Offset: 0x007A6F90
	protected override string MorphCueIdConfigKey
	{
		get
		{
			return "AimisiMorphCues";
		}
	}

	// Token: 0x17002374 RID: 9076
	// (get) Token: 0x0601A1B1 RID: 106929 RVA: 0x007A8D97 File Offset: 0x007A6F97
	protected override string ResetMorphSkillsConfigKey
	{
		get
		{
			return "AimisiResetMorphSkills";
		}
	}

	// Token: 0x17002375 RID: 9077
	// (get) Token: 0x0601A1B2 RID: 106930 RVA: 0x007A8D9E File Offset: 0x007A6F9E
	protected override string NotResetMorphSkillsConfigKey
	{
		get
		{
			return "AimisiNotResetMorphSkills";
		}
	}

	// Token: 0x17002376 RID: 9078
	// (get) Token: 0x0601A1B3 RID: 106931 RVA: 0x007A8DA5 File Offset: 0x007A6FA5
	protected override string ChangeRoleResetMorphTagsConfigKey
	{
		get
		{
			return "AimisiChangeRoleResetMorphTags";
		}
	}

	// Token: 0x17002377 RID: 9079
	// (get) Token: 0x0601A1B4 RID: 106932 RVA: 0x007A8DAC File Offset: 0x007A6FAC
	protected override string Morph0SubMeshConfigKey
	{
		get
		{
			return "AimisiMorph0SubMeshList";
		}
	}

	// Token: 0x17002378 RID: 9080
	// (get) Token: 0x0601A1B5 RID: 106933 RVA: 0x007A8DB3 File Offset: 0x007A6FB3
	protected override string Morph1SubMeshConfigKey
	{
		get
		{
			return "AimisiMorph1SubMeshList";
		}
	}

	// Token: 0x0601A1B6 RID: 106934 RVA: 0x007A8DBA File Offset: 0x007A6FBA
	public SpecialSkillAimisi(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A1B7 RID: 106935 RVA: 0x007A8DC4 File Offset: 0x007A6FC4
	public override void OnStart()
	{
		base.OnStart();
		this.AnimComp = this.SpecialSkillComponent.Entity.GetComponent<CharacterAnimationComponent>();
		BaseBuffComponent buffComp = this.BuffComp;
		if (buffComp != null)
		{
			buffComp.SetDeferredCueCreationEnable(true);
		}
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
	}

	// Token: 0x0601A1B8 RID: 106936 RVA: 0x007A8E1C File Offset: 0x007A701C
	public override void OnEnd()
	{
		base.OnEnd();
		BaseBuffComponent buffComp = this.BuffComp;
		if (buffComp != null)
		{
			buffComp.SetDeferredCueCreationEnable(false);
		}
		if (this.IsUsingAimisExploreSkill)
		{
			this.ResetMorphExploreSkill("Aimisi实体销毁", true);
		}
		Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
	}

	// Token: 0x0601A1B9 RID: 106937 RVA: 0x007A8E74 File Offset: 0x007A7074
	private void SetMorphExploreSkill(string reason, bool skipCurrentEntityCheck = false)
	{
		CharacterExploreModel instance = ModelBase<CharacterExploreModel>.Instance;
		if (instance == null)
		{
			return;
		}
		if (!skipCurrentEntityCheck)
		{
			int id = this.SpecialSkillComponent.Entity.Id;
			SceneTeamModel instance2 = ModelBase<SceneTeamModel>.Instance;
			int? num;
			if (instance2 == null)
			{
				num = null;
			}
			else
			{
				EntityHandle getCurrentEntity = instance2.GetCurrentEntity;
				if (getCurrentEntity == null)
				{
					num = null;
				}
				else
				{
					WorldEntity entity = getCurrentEntity.Entity;
					num = ((entity != null) ? new int?(entity.Id) : null);
				}
			}
			int? num2 = num;
			if (!(id == num2.GetValueOrDefault() & num2 != null))
			{
				return;
			}
		}
		CharacterMorphComponent morphComp = this.MorphComp;
		EMorphType? emorphType = (morphComp != null) ? new EMorphType?(morphComp.GetMorphType()) : null;
		if (emorphType != null)
		{
			EMorphType? emorphType2 = emorphType;
			EMorphType emorphType3 = EMorphType.默认形态;
			if (!(emorphType2.GetValueOrDefault() == emorphType3 & emorphType2 != null))
			{
				if (instance.CheckNeedChangeSkill(121001, EExploreSkillLayer.SpecialSkill))
				{
					ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(121001, null, true);
				}
				instance.SetExploreSkillId(121001, EExploreSkillLayer.SpecialSkill, reason);
				this.IsUsingAimisExploreSkill = true;
				return;
			}
		}
	}

	// Token: 0x0601A1BA RID: 106938 RVA: 0x007A8F74 File Offset: 0x007A7174
	private void ResetMorphExploreSkill(string reason, bool skipCurrentEntityCheck = false)
	{
		CharacterExploreModel instance = ModelBase<CharacterExploreModel>.Instance;
		if (instance == null)
		{
			return;
		}
		if (!skipCurrentEntityCheck)
		{
			int id = this.SpecialSkillComponent.Entity.Id;
			SceneTeamModel instance2 = ModelBase<SceneTeamModel>.Instance;
			int? num;
			if (instance2 == null)
			{
				num = null;
			}
			else
			{
				EntityHandle getCurrentEntity = instance2.GetCurrentEntity;
				if (getCurrentEntity == null)
				{
					num = null;
				}
				else
				{
					WorldEntity entity = getCurrentEntity.Entity;
					num = ((entity != null) ? new int?(entity.Id) : null);
				}
			}
			int? num2 = num;
			if (!(id == num2.GetValueOrDefault() & num2 != null))
			{
				return;
			}
		}
		instance.ResetExplodeSkillId(EExploreSkillLayer.SpecialSkill, reason);
		int topLayerExplodeSkillId = instance.GetTopLayerExplodeSkillId();
		ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(topLayerExplodeSkillId, null, true);
		this.IsUsingAimisExploreSkill = false;
	}

	// Token: 0x0601A1BB RID: 106939 RVA: 0x007A901C File Offset: 0x007A721C
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		WorldEntity entity = newEntity.Entity;
		int? num = (entity != null) ? new int?(entity.Id) : null;
		int id = this.SpecialSkillComponent.Entity.Id;
		bool flag = num.GetValueOrDefault() == id & num != null;
		int? num2;
		if (oldEntity == null)
		{
			num2 = null;
		}
		else
		{
			WorldEntity entity2 = oldEntity.Entity;
			num2 = ((entity2 != null) ? new int?(entity2.Id) : null);
		}
		num = num2;
		id = this.SpecialSkillComponent.Entity.Id;
		if (num.GetValueOrDefault() == id & num != null)
		{
			this.ResetMorphExploreSkill("Aimisi下场", true);
			return;
		}
		if (flag)
		{
			this.SetMorphExploreSkill("Aimisi上场", true);
		}
	}

	// Token: 0x0601A1BC RID: 106940 RVA: 0x007A90DC File Offset: 0x007A72DC
	protected override void OnCharacterMorphTypeChanged(Entity entity, EMorphType newMorphType, EMorphType oldMorphType)
	{
		base.RefreshNoUpdateMeshes(newMorphType);
		if (newMorphType != EMorphType.默认形态)
		{
			this.SetMorphExploreSkill("Aimisi切换到形态二", false);
			return;
		}
		this.ResetMorphExploreSkill("Aimisi恢复到形态一", false);
	}

	// Token: 0x0400D183 RID: 53635
	public const int AIMISI_MORPH_EXPLORE_SKILL_ID = 121001;

	// Token: 0x0400D184 RID: 53636
	private bool IsUsingAimisExploreSkill;
}
