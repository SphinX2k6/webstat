using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using CSharpScript.Game.Common.Event;

// Token: 0x02003147 RID: 12615
[NullableContext(2)]
[Nullable(0)]
public class SpecialSkillFuLuoLuo : SpecialSkillBase
{
	// Token: 0x0601A1E8 RID: 106984 RVA: 0x007A9F60 File Offset: 0x007A8160
	[NullableContext(1)]
	public SpecialSkillFuLuoLuo(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A1E9 RID: 106985 RVA: 0x007A9F80 File Offset: 0x007A8180
	public override void OnStart()
	{
		this.EntityRef = this.SpecialSkillComponent.Entity;
		this.AttributeComponent = this.EntityRef.GetComponent<BaseAttributeComponent>();
		this.TagComponent = this.EntityRef.GetComponent<RoleTagComponent>();
		this.ActorComponent = this.EntityRef.CheckGetComponent<CharacterActorComponent>();
		RoleEnergyComponent component = this.EntityRef.GetComponent<RoleEnergyComponent>();
		if (component != null)
		{
			component.SetEnableRefreshStarScarByEnergy(false);
		}
		CreatureDataComponent component2 = this.EntityRef.GetComponent<CreatureDataComponent>();
		this.IsAutonomous = (ModelBase<CreatureModel>.Instance.GetPlayerId() == component2.GetPlayerId());
		this.InitSpecialEnergy();
		this.RefreshStarScarMaterial();
		if (this.IsAutonomous)
		{
			Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(this.EntityRef, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharSkillBegin));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int>(this.EntityRef, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnBeforeChangeRole, new Action<EntityHandle, EntityHandle>(this.OnBeforeChangeRole));
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnBeforeUpdateSceneTeam, new Action<EntityHandle, EntityHandle>(this.OnBeforeUpdateSceneTeam));
			if (this.AttributeComponent != null)
			{
				this.AttributeComponent.AddListener(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.OnAttributeChanged), null);
				this.AttributeComponent.AddListener(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty), null);
				return;
			}
		}
		else
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			attributeComponent.AddListener(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty), null);
		}
	}

	// Token: 0x0601A1EA RID: 106986 RVA: 0x007AA0F8 File Offset: 0x007A82F8
	public override void OnEnd()
	{
		if (this.IsAutonomous)
		{
			Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnBeforeChangeRole, new Action<EntityHandle, EntityHandle>(this.OnBeforeChangeRole));
			Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnBeforeUpdateSceneTeam, new Action<EntityHandle, EntityHandle>(this.OnBeforeUpdateSceneTeam));
			if (this.EntityRef != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(this.EntityRef, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharSkillBegin));
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(this.EntityRef, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
				this.EntityRef = null;
			}
			if (this.AttributeComponent != null)
			{
				this.AttributeComponent.RemoveListener(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
				this.AttributeComponent.RemoveListener(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty));
				return;
			}
		}
		else
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			attributeComponent.RemoveListener(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty));
		}
	}

	// Token: 0x0601A1EB RID: 106987 RVA: 0x007AA1F4 File Offset: 0x007A83F4
	private void InitSpecialEnergy()
	{
		this.SpecialEnergyTypeList.Clear();
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		int num = (int)((attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1) : 0f);
		for (int i = 0; i < 6; i++)
		{
			int num2 = (6 - i - 1) * 2;
			int num3 = (num & 3 << num2) >> num2;
			if (num3 > 0)
			{
				this.SpecialEnergyTypeList.Add(num3);
			}
		}
	}

	// Token: 0x0601A1EC RID: 106988 RVA: 0x007AA258 File Offset: 0x007A8458
	public int GetSpecialEnergyType(int index)
	{
		if (index < 0 || index >= this.SpecialEnergyTypeList.Count)
		{
			return 0;
		}
		return this.SpecialEnergyTypeList[index];
	}

	// Token: 0x0601A1ED RID: 106989 RVA: 0x007AA27C File Offset: 0x007A847C
	public void AddSpecialEnergy(int type)
	{
		if (this.SpecialEnergyTypeList.Count < 6)
		{
			this.SpecialEnergyTypeList.Add(type);
			this.SaveSpecialEnergy();
			return;
		}
		RoleTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1FuluoluoMd10011.状态标识.乐谱锁定"]))
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < 6; i++)
		{
			if (!flag && this.SpecialEnergyTypeList[i] != 3)
			{
				flag = true;
			}
			if (flag && i != 5)
			{
				this.SpecialEnergyTypeList[i] = this.SpecialEnergyTypeList[i + 1];
			}
		}
		if (flag)
		{
			this.SpecialEnergyTypeList[5] = type;
			if (this.AttributeComponent != null)
			{
				float baseValue = this.AttributeComponent.GetBaseValue(EAttributeType.SpecialEnergy1);
				this.SaveSpecialEnergy();
				if (baseValue == this.AttributeComponent.GetBaseValue(EAttributeType.SpecialEnergy1))
				{
					EventSystem instance = Singleton<EventSystem>.Instance;
					EEventName name = EEventName.FuLuoLuoAddDuplicatedEnergy;
					Entity entityRef = this.EntityRef;
					instance.Emit<int>(name, (entityRef != null) ? entityRef.Id : 0);
				}
			}
		}
	}

	// Token: 0x0601A1EE RID: 106990 RVA: 0x007AA36A File Offset: 0x007A856A
	public void RemoveSpecialEnergy()
	{
		if (this.SpecialEnergyTypeList.Count <= 0)
		{
			return;
		}
		this.SpecialEnergyTypeList.RemoveAt(0);
		this.SaveSpecialEnergy();
	}

	// Token: 0x0601A1EF RID: 106991 RVA: 0x007AA390 File Offset: 0x007A8590
	private void SaveSpecialEnergy()
	{
		int num = 0;
		foreach (int num2 in this.SpecialEnergyTypeList)
		{
			num <<= 2;
			num += num2;
		}
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent == null)
		{
			return;
		}
		attributeComponent.SetBaseValue(EAttributeType.SpecialEnergy1, (float)num);
	}

	// Token: 0x0601A1F0 RID: 106992 RVA: 0x007AA3FC File Offset: 0x007A85FC
	private void OnAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		if (newValue == 0f && this.SpecialEnergyTypeList.Count != 0)
		{
			this.SpecialEnergyTypeList.Clear();
		}
	}

	// Token: 0x0601A1F1 RID: 106993 RVA: 0x007AA420 File Offset: 0x007A8620
	public override void OnTick(float delta)
	{
		if (!this.InBurstState || this.SummonedEntity == null || this.EntityRef == null)
		{
			return;
		}
		BaseActorComponent component = this.EntityRef.GetComponent<BaseActorComponent>();
		global::Vector vector = (component != null) ? component.ActorLocationProxy : null;
		BaseActorComponent component2 = this.SummonedEntity.GetComponent<BaseActorComponent>();
		global::Vector vector2 = (component2 != null) ? component2.ActorLocationProxy : null;
		if (vector == null || vector2 == null || component2 == null)
		{
			return;
		}
		if (global::Vector.DistSquaredXY(vector, vector2) > 9000000.0)
		{
			vector2.Subtraction(vector, this.TmpVector);
			this.TmpVector.Normalize(9.99999993922529E-09);
			this.TmpVector.MultiplyEqual(3000.0);
			this.TmpVector.AdditionEqual(vector);
			component2.SetActorLocation(this.TmpVector.ToUeVector(false), "弗洛洛大招移动范围限制", false);
		}
		if (Math.Abs(vector.Z - vector2.Z) > 1500.0)
		{
			this.TmpVector.X = vector.X;
			this.TmpVector.Y = vector.Y;
			this.TmpVector.Z = vector.Z - 200.0;
			component2.SetActorLocation(this.TmpVector.ToUeVector(false), "弗洛洛大招Z超范围", false);
			CharacterSkillComponent component3 = this.SummonedEntity.GetComponent<CharacterSkillComponent>();
			if (component3 == null)
			{
				return;
			}
			component3.BeginSkill(1608942, null);
		}
	}

	// Token: 0x0601A1F2 RID: 106994 RVA: 0x007AA580 File Offset: 0x007A8780
	private void SetBurstSpecialMove(bool isOpen)
	{
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(this.EntityRef, ESummonType.ConcomitantCustom, 2);
		WorldEntity worldEntity = (summonedEntity != null) ? summonedEntity.Entity : null;
		if (worldEntity == null)
		{
			this.SummonedEntity = null;
			return;
		}
		this.SummonedEntity = worldEntity;
		CharacterMoveComponent component = worldEntity.GetComponent<CharacterMoveComponent>();
		if (component != null)
		{
			component.SetWalkOffLedgeRecord(!isOpen);
		}
		this.InBurstState = isOpen;
	}

	// Token: 0x0601A1F3 RID: 106995 RVA: 0x007AA5D5 File Offset: 0x007A87D5
	private void RefreshStarScarMaterialProperty(EAttributeType attribute, float newValue, float oldValue)
	{
		this.RefreshStarScarMaterial();
	}

	// Token: 0x0601A1F4 RID: 106996 RVA: 0x007AA5E0 File Offset: 0x007A87E0
	public void RefreshStarScarMaterial()
	{
		if (this.AttributeComponent == null)
		{
			return;
		}
		float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2);
		float currentValue2 = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2Max);
		CharacterActorComponent actorComponent = this.ActorComponent;
		if (actorComponent == null)
		{
			return;
		}
		TsBaseCharacter actor = actorComponent.Actor;
		if (actor == null)
		{
			return;
		}
		CharRenderingComponent charRenderingComponent = actor.CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return;
		}
		charRenderingComponent.SetStarScarEnergy(currentValue / currentValue2);
	}

	// Token: 0x0601A1F5 RID: 106997 RVA: 0x007AA639 File Offset: 0x007A8839
	private void OnCharSkillBegin(int charId, int skillId, bool isAutonomousProxy)
	{
		if (1608301L == (long)skillId)
		{
			this.SetBurstSpecialMove(true);
		}
	}

	// Token: 0x0601A1F6 RID: 106998 RVA: 0x007AA64C File Offset: 0x007A884C
	private void OnCharSkillEnd(int entityId, int skillId)
	{
		if (1608301L == (long)skillId)
		{
			this.SetBurstSpecialMove(false);
		}
	}

	// Token: 0x0601A1F7 RID: 106999 RVA: 0x007AA65F File Offset: 0x007A885F
	[NullableContext(1)]
	private void OnBeforeChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		if (newEntity == oldEntity)
		{
			return;
		}
		this.StopUltraSkillBeforeChangeRole(newEntity);
	}

	// Token: 0x0601A1F8 RID: 107000 RVA: 0x007AA66D File Offset: 0x007A886D
	private void OnBeforeUpdateSceneTeam(EntityHandle newEntity, EntityHandle oldEntity)
	{
		if (newEntity == oldEntity)
		{
			return;
		}
		this.StopUltraSkillBeforeChangeRole(newEntity);
	}

	// Token: 0x0601A1F9 RID: 107001 RVA: 0x007AA67B File Offset: 0x007A887B
	private void StopUltraSkillBeforeChangeRole(EntityHandle newEntity)
	{
		if (!this.InBurstState)
		{
			return;
		}
		if (((newEntity != null) ? newEntity.Entity : null) == this.EntityRef)
		{
			Entity entityRef = this.EntityRef;
			if (entityRef == null)
			{
				return;
			}
			RoleTeamComponent component = entityRef.GetComponent<RoleTeamComponent>();
			if (component == null)
			{
				return;
			}
			component.DisableRoleWithoutEffect();
		}
	}

	// Token: 0x0400D1A4 RID: 53668
	private const int SPECIAL_ENERGY_COUNT = 6;

	// Token: 0x0400D1A5 RID: 53669
	private const long SPECIAL_SKILL_ID = 1608301L;

	// Token: 0x0400D1A6 RID: 53670
	private const double DISTANCE_XY = 3000.0;

	// Token: 0x0400D1A7 RID: 53671
	private const double DISTANCE_Z = 1500.0;

	// Token: 0x0400D1A8 RID: 53672
	private const double DISTANCE_Z_DELTA = 200.0;

	// Token: 0x0400D1A9 RID: 53673
	private const int RESET_SKILL = 1608942;

	// Token: 0x0400D1AA RID: 53674
	private Entity EntityRef;

	// Token: 0x0400D1AB RID: 53675
	private Entity SummonedEntity;

	// Token: 0x0400D1AC RID: 53676
	private bool InBurstState;

	// Token: 0x0400D1AD RID: 53677
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x0400D1AE RID: 53678
	private RoleTagComponent TagComponent;

	// Token: 0x0400D1AF RID: 53679
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400D1B0 RID: 53680
	[Nullable(1)]
	private readonly List<int> SpecialEnergyTypeList = new List<int>();

	// Token: 0x0400D1B1 RID: 53681
	[Nullable(1)]
	private readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x0400D1B2 RID: 53682
	private bool IsAutonomous;
}
