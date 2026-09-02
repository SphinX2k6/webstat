using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020031F6 RID: 12790
[NullableContext(2)]
[Nullable(0)]
public class RoleInheritComponent : EntityComponent
{
	// Token: 0x0601A895 RID: 108693 RVA: 0x007D9C49 File Offset: 0x007D7E49
	protected override bool OnStart()
	{
		this.CreatureDataComponent = base.Entity.GetComponent<CreatureDataComponent>();
		this.BuffComponent = base.Entity.CheckGetComponent<CharacterBuffComponent>();
		return true;
	}

	// Token: 0x0601A896 RID: 108694 RVA: 0x007D9C70 File Offset: 0x007D7E70
	public static void StateInherit(RoleInheritComponent last, RoleInheritComponent newly, ERoleInheritType inheritType, bool skill)
	{
		if (last != null && newly != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.ZQR, "换人进入StateInherit", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (!last.CreatureDataComponent.GetRemoveState())
			{
				last.BuffComponent.TriggerEvents(EBuffTriggerType.ForGoDown, newly.BuffComponent, new Partial_RequirementPayload());
				newly.BuffComponent.TriggerEvents(EBuffTriggerType.ForGoBattle, last.BuffComponent, new Partial_RequirementPayload());
				RoleInheritComponent.InheritBuffs(last, newly);
			}
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.ZQR, "换人进入RoleOnStateInherit", default(ReadOnlySpan<ValueTuple<string, object>>));
			EventSystem instance = Singleton<EventSystem>.Instance;
			object entity = newly.Entity;
			EEventName name = EEventName.RoleOnStateInherit;
			Entity entity2 = last.Entity;
			bool p;
			if (inheritType != ERoleInheritType.QTE && !skill)
			{
				BaseTagComponent component = newly.Entity.GetComponent<BaseTagComponent>();
				p = (component != null && component.HasAnyTag(new int[]
				{
					GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"],
					GameplayTagDefine.EGameplayTagId["角色.Common.切人不隐藏"]
				}));
			}
			else
			{
				p = true;
			}
			instance.EmitWithTarget<Entity, bool>(entity, name, entity2, p);
		}
	}

	// Token: 0x0601A897 RID: 108695 RVA: 0x007D9D6C File Offset: 0x007D7F6C
	[NullableContext(1)]
	private static void InheritBuffs(RoleInheritComponent last, RoleInheritComponent newly)
	{
		foreach (IActiveBuff activeBuff in last.BuffComponent.GetAllBuffs())
		{
			int stackCount = activeBuff.StackCount;
			if (stackCount > 0)
			{
				int handle = activeBuff.Handle;
				long? instigatorId = activeBuff.InstigatorId;
				BuffDefinition config = activeBuff.Config;
				if (config.FormationPolicy == EBuffFormationPolicy.InheritedWhenChangeRole || config.FormationPolicy == EBuffFormationPolicy.InheritedWhenChangeRoleAndRemoveSelf)
				{
					float num = activeBuff.GetRemainDuration();
					if (activeBuff.Duration > 0f && num <= 0f)
					{
						num = 0.0001f;
					}
					newly.BuffComponent.AddBuff(activeBuff.Id, new AddBuffParam
					{
						Level = new int?(activeBuff.Level),
						ServerId = new int?(activeBuff.ServerId),
						InstigatorId = instigatorId.GetValueOrDefault(),
						OuterStackCount = new int?(stackCount),
						Duration = new float?(num),
						IsIterable = new bool?(false),
						PreMessageId = activeBuff.MessageId,
						Reason = "因为状态继承导致的buff添加"
					});
					if (config.FormationPolicy == EBuffFormationPolicy.InheritedWhenChangeRoleAndRemoveSelf)
					{
						last.BuffComponent.RemoveBuffByHandle(handle, -1, "因为状态继承导致的移除", null, null, null);
					}
				}
			}
		}
	}

	// Token: 0x0601A898 RID: 108696 RVA: 0x007D9EBC File Offset: 0x007D80BC
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleInheritComponent roleInheritComponent = (RoleInheritComponent)componentTemplate;
		if (base.CanResetComponentProperty("CreatureDataComponent"))
		{
			if (roleInheritComponent.CreatureDataComponent == null)
			{
				this.CreatureDataComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (roleInheritComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D689 RID: 54921
	private CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400D68A RID: 54922
	private CharacterBuffComponent BuffComponent;
}
