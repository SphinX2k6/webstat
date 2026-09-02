using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.AI.StateMachine;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02003448 RID: 13384
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CombatDebugDrawController : ControllerBase<CombatDebugDrawController>
{
	// Token: 0x0601C144 RID: 115012 RVA: 0x008603D4 File Offset: 0x0085E5D4
	protected override bool OnInit()
	{
		this.RedColor = new FLinearColor(1f, 0f, 0f, 1f);
		this.GreenColor = new FLinearColor(0f, 1f, 0f, 1f);
		this.BlueColor = new FLinearColor(0f, 0f, 1f, 1f);
		this.YellowColor = new FLinearColor(1f, 1f, 0f, 1f);
		this.EntityBoxColor = new FLinearColor(0.8f, 0.8f, 0f, 0.5f);
		this.EntityBoxColorInvincible = new FLinearColor(0.5f, 0.5f, 1f, 1f);
		this.EntityBoxColorCollisionDisabled = new FLinearColor(0.5f, 0.5f, 0.5f, 0.5f);
		this.EntityBoxInfoColor = new FLinearColor(0.8f, 0.8f, 1f, 0.5f);
		return true;
	}

	// Token: 0x0601C145 RID: 115013 RVA: 0x008604DA File Offset: 0x0085E6DA
	protected override void OnTick(float delta)
	{
		if (this.DebugMonsterControl)
		{
			this.DrawMonsterControl();
		}
		this.DrawEntityBox(ControllerBase<CombatDebugController>.Instance.DebugEntityId);
	}

	// Token: 0x0601C146 RID: 115014 RVA: 0x008604FC File Offset: 0x0085E6FC
	private void DrawMonsterControl()
	{
		this.PlayerIdToEntity.Clear();
		foreach (EntityHandle entityHandle in (ModelBase<CreatureModel>.Instance.GetAllEntities() ?? Array.Empty<EntityHandle>()))
		{
			if (entityHandle.Entity.Active)
			{
				CreatureDataComponent component = entityHandle.Entity.GetComponent<CreatureDataComponent>();
				if (component.IsRole())
				{
					this.PlayerIdToEntity.Add(component.GetPlayerId(), entityHandle.Entity);
				}
			}
		}
		foreach (EntityHandle entityHandle2 in (ModelBase<CreatureModel>.Instance.GetAllEntities() ?? Array.Empty<EntityHandle>()))
		{
			if (entityHandle2.Entity.Active && entityHandle2.Entity.GetComponent<CreatureDataComponent>().IsMonster())
			{
				CharacterAiComponent component2 = entityHandle2.Entity.GetComponent<CharacterAiComponent>();
				AiController aiController = (component2 != null) ? component2.AiController : null;
				if (aiController != null)
				{
					Entity entity;
					this.PlayerIdToEntity.TryGetValue(aiController.ControllerPlayerId, out entity);
					if (entity != null)
					{
						this.LocationCache1.DeepCopy(entityHandle2.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy);
						this.LocationCache2.DeepCopy(entity.GetComponent<CharacterActorComponent>().ActorLocationProxy);
						UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, this.LocationCache1.ToUeVector(false), this.LocationCache2.ToUeVector(false), 2f, this.GreenColor, 0f, 0f);
						CharacterMovementSyncComponent component3 = entityHandle2.Entity.GetComponent<CharacterMovementSyncComponent>();
						if (component3 != null && aiController.ControllerPlayerId != component3.ControllerPlayerId)
						{
							Entity entity2;
							this.PlayerIdToEntity.TryGetValue(component3.ControllerPlayerId, out entity2);
							if (entity2 != null)
							{
								this.LocationCache2.DeepCopy(entity2.GetComponent<CharacterActorComponent>().ActorLocationProxy);
								UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, this.LocationCache1.ToUeVector(false), this.LocationCache2.ToUeVector(false), 2f, this.YellowColor, 0f, 0f);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0601C147 RID: 115015 RVA: 0x00860744 File Offset: 0x0085E944
	private unsafe void DrawEntityBox(int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
		TsBaseCharacter tsBaseCharacter = (characterActorComponent != null) ? characterActorComponent.Actor : null;
		UCapsuleComponent ucapsuleComponent = (tsBaseCharacter != null) ? tsBaseCharacter.CapsuleComponent : null;
		if (tsBaseCharacter == null || !tsBaseCharacter.IsValid() || (ucapsuleComponent == null || !ucapsuleComponent.IsValid()))
		{
			return;
		}
		FVectorDouble fvectorDouble = tsBaseCharacter.D_K2_GetActorLocation();
		if (this.IsDrawEntityBoxEnabled)
		{
			FLinearColor value = this.EntityBoxColor;
			if (!tsBaseCharacter.bActorEnableCollision)
			{
				value = this.EntityBoxColorCollisionDisabled;
			}
			else if (entity != null)
			{
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				bool? flag;
				if (component == null)
				{
					flag = null;
				}
				else
				{
					<>y__InlineArray2<int> <>y__InlineArray = default(<>y__InlineArray2<int>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<int>, int>(ref <>y__InlineArray, 0) = GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌"];
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<int>, int>(ref <>y__InlineArray, 1) = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.不被子弹命中"];
					ReadOnlySpan<int> readOnlySpan = <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<int>, int>(<>y__InlineArray, 2);
					flag = new bool?(component.HasAnyTag(readOnlySpan));
				}
				bool? flag2 = flag;
				if (flag2.GetValueOrDefault())
				{
					value = this.EntityBoxColorInvincible;
				}
			}
			UKismetSystemLibrary.D_DrawDebugCapsule(tsBaseCharacter, fvectorDouble, ucapsuleComponent.CapsuleHalfHeight, ucapsuleComponent.CapsuleRadius, tsBaseCharacter.K2_GetActorRotation(), new FLinearColor?(value), 0f, 0f);
		}
		if (this.IsDrawEntityBoxInfoEnabled)
		{
			FVectorDouble textLocation = new FVectorDouble(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z - (double)ucapsuleComponent.CapsuleHalfHeight - 30.0);
			string text = string.Concat(new string[]
			{
				tsBaseCharacter.GetName(),
				"_",
				(entity != null) ? entity.Id.ToString() : null,
				"\n",
				fvectorDouble.ToString()
			});
			text = text + "\n" + ((characterActorComponent != null && characterActorComponent.IsAutonomousProxy) ? "主控" : "非主控");
			PawnTimeScaleComponent component2 = entity.GetComponent<PawnTimeScaleComponent>();
			if (component2 != null)
			{
				text = text + "\n时间缩放: " + component2.CurrentTimeScale.ToString("F2");
			}
			CharacterStateMachineNewComponent component3 = entity.GetComponent<CharacterStateMachineNewComponent>();
			List<AiStateMachineBase> list;
			if (component3 == null)
			{
				list = null;
			}
			else
			{
				AiStateMachineGroup stateMachineGroup = component3.StateMachineGroup;
				list = ((stateMachineGroup != null) ? stateMachineGroup.StateMachines : null);
			}
			foreach (AiStateMachineBase aiStateMachineBase in (list ?? new List<AiStateMachineBase>()))
			{
				text = string.Concat(new string[]
				{
					text,
					"\n状态机",
					aiStateMachineBase.Name,
					": ",
					aiStateMachineBase.GetCurrentStateString()
				});
			}
			CharacterSkillComponent component4 = entity.GetComponent<CharacterSkillComponent>();
			if (component4 != null)
			{
				string str = text;
				string str2 = "\n技能目标: ";
				EntityHandle skillTarget = component4.SkillTarget;
				string str3;
				if (skillTarget == null)
				{
					str3 = null;
				}
				else
				{
					CharacterActorComponent component5 = skillTarget.Entity.GetComponent<CharacterActorComponent>();
					if (component5 == null)
					{
						str3 = null;
					}
					else
					{
						TsBaseCharacter actor = component5.Actor;
						str3 = ((actor != null) ? actor.GetName() : null);
					}
				}
				text = str + str2 + str3;
				string str4 = text;
				string str5 = "\n当前技能: ";
				Skill currentSkill = component4.CurrentSkill;
				text = str4 + str5 + ((currentSkill != null) ? new int?(currentSkill.SkillId) : null).ToString();
			}
			UKismetSystemLibrary.D_DrawDebugString(tsBaseCharacter, textLocation, text, null, new FLinearColor?(this.EntityBoxInfoColor), 0f);
		}
	}

	// Token: 0x0400E2BF RID: 58047
	public bool DebugMonsterMovePath;

	// Token: 0x0400E2C0 RID: 58048
	public bool DebugMonsterControl;

	// Token: 0x0400E2C1 RID: 58049
	public bool IsDrawEntityBoxEnabled = true;

	// Token: 0x0400E2C2 RID: 58050
	public bool IsDrawEntityBoxInfoEnabled;

	// Token: 0x0400E2C3 RID: 58051
	protected FLinearColor RedColor;

	// Token: 0x0400E2C4 RID: 58052
	protected FLinearColor GreenColor;

	// Token: 0x0400E2C5 RID: 58053
	protected FLinearColor BlueColor;

	// Token: 0x0400E2C6 RID: 58054
	protected FLinearColor YellowColor;

	// Token: 0x0400E2C7 RID: 58055
	protected FLinearColor EntityBoxColor;

	// Token: 0x0400E2C8 RID: 58056
	protected FLinearColor EntityBoxColorInvincible;

	// Token: 0x0400E2C9 RID: 58057
	protected FLinearColor EntityBoxColorCollisionDisabled;

	// Token: 0x0400E2CA RID: 58058
	protected FLinearColor EntityBoxInfoColor;

	// Token: 0x0400E2CB RID: 58059
	private readonly Vector LocationCache1 = Vector.Create();

	// Token: 0x0400E2CC RID: 58060
	private readonly Vector LocationCache2 = Vector.Create();

	// Token: 0x0400E2CD RID: 58061
	private readonly Dictionary<int, Entity> PlayerIdToEntity = new Dictionary<int, Entity>();
}
