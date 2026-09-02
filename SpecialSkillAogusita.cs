using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x02003143 RID: 12611
[NullableContext(2)]
[Nullable(0)]
public class SpecialSkillAogusita : SpecialSkillBase
{
	// Token: 0x0601A1BD RID: 106941 RVA: 0x007A9101 File Offset: 0x007A7301
	[NullableContext(1)]
	public SpecialSkillAogusita(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A1BE RID: 106942 RVA: 0x007A912C File Offset: 0x007A732C
	public override void OnStart()
	{
		Entity entity = this.SpecialSkillComponent.Entity;
		this.ActorComp = entity.GetComponent<CharacterActorComponent>();
		this.SkillComp = entity.GetComponent<BaseSkillComponent>();
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.IsRoleAndCtrlByMe)
		{
			this.InputComp = entity.GetComponent<CharacterInputComponent>();
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			this.HideUiListener = ((component != null) ? component.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.R2T1AogusitaMd10011.战斗逻辑.大循环充能X"]), new BaseTagComponent.TTagSwitchedCallback(this.OnHideUiStateChanged), null) : null);
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add<int?>(EEventName.CommonQteStart, new Action<int?>(this.OnCommonQteStart));
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		}
		Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnCharBeforeSkill));
	}

	// Token: 0x0601A1BF RID: 106943 RVA: 0x007A922C File Offset: 0x007A742C
	public override void OnEnd()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.IsRoleAndCtrlByMe && this.IsInHideUiState)
		{
			this.SetUiVisible(true);
		}
		ITagTask hideUiListener = this.HideUiListener;
		if (hideUiListener != null)
		{
			hideUiListener.EndTask();
		}
		this.HideUiListener = null;
		if (Singleton<EventSystem>.Instance.Has(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole)))
		{
			Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		}
		if (Singleton<EventSystem>.Instance.Has(EEventName.CommonQteStart, new Action<int?>(this.OnCommonQteStart)))
		{
			Singleton<EventSystem>.Instance.Remove<int?>(EEventName.CommonQteStart, new Action<int?>(this.OnCommonQteStart));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.SpecialSkillComponent.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.SpecialSkillComponent.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(this.SpecialSkillComponent.Entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnCharBeforeSkill));
	}

	// Token: 0x0601A1C0 RID: 106944 RVA: 0x007A935C File Offset: 0x007A755C
	private void OnHideUiStateChanged(int tagId, bool bTagExists)
	{
		this.IsInHideUiState = bTagExists;
		int id = this.SpecialSkillComponent.Entity.Id;
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		int? num;
		if (instance == null)
		{
			num = null;
		}
		else
		{
			EntityHandle getCurrentEntity = instance.GetCurrentEntity;
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
		if (id == num2.GetValueOrDefault() & num2 != null)
		{
			this.SetUiVisible(!bTagExists);
		}
	}

	// Token: 0x0601A1C1 RID: 106945 RVA: 0x007A93E4 File Offset: 0x007A75E4
	[NullableContext(1)]
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		int id = this.SpecialSkillComponent.Entity.Id;
		WorldEntity entity = newEntity.Entity;
		if (entity != null && entity.Id == id)
		{
			if (this.IsInHideUiState)
			{
				this.SetUiVisible(false);
				return;
			}
		}
		else if (oldEntity != null)
		{
			WorldEntity entity2 = oldEntity.Entity;
			int? num = (entity2 != null) ? new int?(entity2.Id) : null;
			int num2 = id;
			if (num.GetValueOrDefault() == num2 & num != null)
			{
				this.SetUiVisible(true);
			}
		}
	}

	// Token: 0x0601A1C2 RID: 106946 RVA: 0x007A9469 File Offset: 0x007A7669
	private void OnRoleDead()
	{
		this.SetUiVisible(true);
	}

	// Token: 0x0601A1C3 RID: 106947 RVA: 0x007A9472 File Offset: 0x007A7672
	private void OnCommonQteStart(int? handleId)
	{
		this.SkillComp.EndSkill(1306666, "触发通用QTE，终止奥古斯塔时停被动技能");
	}

	// Token: 0x0601A1C4 RID: 106948 RVA: 0x007A948C File Offset: 0x007A768C
	private void SetUiVisible(bool visible)
	{
		if (this.IsUiVisible == visible)
		{
			return;
		}
		this.IsUiVisible = visible;
		ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.SpecialSkill, this.hideBattleUiChildren, visible, true, 0);
		CharacterInputComponent inputComp = this.InputComp;
		if (inputComp == null)
		{
			return;
		}
		inputComp.SetOnlyAllowFightInput(!visible);
	}

	// Token: 0x0601A1C5 RID: 106949 RVA: 0x007A94D8 File Offset: 0x007A76D8
	private void OnCharBeforeSkill(int skillId, bool isAutonomousProxy)
	{
		if (ConfigBase<WorldConfig>.Instance.GetRoleCommonSkillRowNames().Contains(skillId.ToString()) && (long)skillId != 100003L && (long)skillId != 100004L)
		{
			this.SkillComp.EndSkill(1306666, "触发公共技能，终止奥古斯塔时停被动技能");
		}
	}

	// Token: 0x0400D185 RID: 53637
	[Nullable(1)]
	private readonly EBattleUiChild[] hideBattleUiChildren = new EBattleUiChild[]
	{
		EBattleUiChild.Common,
		EBattleUiChild.ExitButton,
		EBattleUiChild.HomeButton,
		EBattleUiChild.TopButton,
		EBattleUiChild.MiniMap,
		EBattleUiChild.Mission,
		EBattleUiChild.Chat,
		EBattleUiChild.Formation,
		EBattleUiChild.GamepadFormation,
		EBattleUiChild.InteractionHint,
		EBattleUiChild.SilentAreaView,
		EBattleUiChild.SilentAreaInfoPanel,
		EBattleUiChild.Score
	};

	// Token: 0x0400D186 RID: 53638
	private const int PASSIVE_SKILL_ID = 1306666;

	// Token: 0x0400D187 RID: 53639
	private const long JUMP_FORWARD = 100003L;

	// Token: 0x0400D188 RID: 53640
	private const long JUMP_BACKWARD = 100004L;

	// Token: 0x0400D189 RID: 53641
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D18A RID: 53642
	private CharacterInputComponent InputComp;

	// Token: 0x0400D18B RID: 53643
	private BaseSkillComponent SkillComp;

	// Token: 0x0400D18C RID: 53644
	private ITagTask HideUiListener;

	// Token: 0x0400D18D RID: 53645
	private bool IsInHideUiState;

	// Token: 0x0400D18E RID: 53646
	private bool IsUiVisible = true;
}
