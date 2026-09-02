using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002DC4 RID: 11716
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicForceController : BulletLogicController<LogicDataForce, object>, IStaticVariableResetter
{
	// Token: 0x060179F3 RID: 96755 RVA: 0x00693174 File Offset: 0x00691374
	static BulletLogicForceController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BulletLogicForceController.CreateStaticDefaultValue), new Action(BulletLogicForceController.ResetStaticDefaultValue));
	}

	// Token: 0x17001F9A RID: 8090
	// (get) Token: 0x060179F4 RID: 96756 RVA: 0x00693193 File Offset: 0x00691393
	private static Dictionary<int, int> LastVelocityAdditionHandler
	{
		get
		{
			return BulletLogicForceController._lastVelocityAdditionHandler;
		}
	}

	// Token: 0x17001F9B RID: 8091
	// (get) Token: 0x060179F5 RID: 96757 RVA: 0x0069319A File Offset: 0x0069139A
	private static Dictionary<int, int> LastGravityAdditionHandler
	{
		get
		{
			return BulletLogicForceController._lastGravityAdditionHandler;
		}
	}

	// Token: 0x060179F6 RID: 96758 RVA: 0x006931A4 File Offset: 0x006913A4
	public BulletLogicForceController(LogicDataForce bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		this.Parameter = bulletLogicBase;
		this.BulletInfo = (bullet as BulletEntity).GetBulletInfo();
		this.BulletActorComp = bullet.GetComponent<BulletActorComponent>();
		this.VelocityAdditionHandlerMap = new Dictionary<Entity, int>();
		this.GravityAdditionHandlerMap = new Dictionary<Entity, int>();
		base.NeedTick = true;
		this.ConstantForce = this.Parameter.ConstantForce;
		this.IsLaunching = this.Parameter.IsLaunching;
		this.NeedCheckTag = (this.LogicController.WorkHaveTag.GameplayTags.Num() > 0);
		this.ImmuneStopDuration = this.LogicController.ImmuneStopDuration;
	}

	// Token: 0x060179F7 RID: 96759 RVA: 0x0069326C File Offset: 0x0069146C
	public override void OnInit()
	{
		this.InitForce();
	}

	// Token: 0x060179F8 RID: 96760 RVA: 0x00693274 File Offset: 0x00691474
	private void InitForce()
	{
		if (!this.ConstantForce)
		{
			return;
		}
		CharacterMoveComponent attackerMoveComp = this.BulletInfo.AttackerMoveComp;
		if (attackerMoveComp == null || attackerMoveComp.IsStandardGravity)
		{
			this.ConstantForceVector = Vector.Create((!this.Parameter.TowardsBullet) ? Vector.UpVectorProxy : this.BulletActorComp.ActorUpProxy);
		}
		else
		{
			this.ConstantForceVector = Vector.Create((!this.Parameter.TowardsBullet) ? this.BulletInfo.AttackerMoveComp.GravityUp : this.BulletActorComp.ActorUpProxy);
		}
		this.ConstantForceVector.MultiplyEqual((double)this.Parameter.ForceBase);
	}

	// Token: 0x060179F9 RID: 96761 RVA: 0x0069331C File Offset: 0x0069151C
	protected override void Update(float deltaTime)
	{
		base.Update(deltaTime);
		this.BulletLogicPhysicalForce();
	}

	// Token: 0x060179FA RID: 96762 RVA: 0x0069332B File Offset: 0x0069152B
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		if (this.Parameter.ConstantForce)
		{
			this.BulletLogicPhysicalForce();
		}
	}

	// Token: 0x060179FB RID: 96763 RVA: 0x00693340 File Offset: 0x00691540
	private void BulletLogicPhysicalForce()
	{
		List<int> tagIds = GameplayTagUtils.ConvertFromUeContainer(this.LogicController.WorkHaveTag);
		if (this.ConstantForce)
		{
			if (!this.IsLaunching)
			{
				HashSet<Entity> inAreaButNotGlidingEntity = this.InAreaButNotGlidingEntity2;
				HashSet<Entity> inAreaButNotGlidingEntity2 = this.InAreaButNotGlidingEntity;
				this.InAreaButNotGlidingEntity = inAreaButNotGlidingEntity;
				this.InAreaButNotGlidingEntity2 = inAreaButNotGlidingEntity2;
				this.InAreaButNotGlidingEntity.Clear();
			}
			using (Dictionary<Entity, int>.Enumerator enumerator = this.BulletInfo.CollisionInfo.CharacterEntityMap.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<Entity, int> keyValuePair = enumerator.Current;
					Entity key = keyValuePair.Key;
					if (key != null && (!this.NeedCheckTag || key.GetComponent<BaseTagComponent>().HasAnyTag(tagIds)))
					{
						this.TowardsConstantForce(key);
					}
				}
				return;
			}
		}
		foreach (KeyValuePair<Entity, int> keyValuePair2 in this.BulletInfo.CollisionInfo.CharacterEntityMap)
		{
			Entity key2 = keyValuePair2.Key;
			BaseTagComponent component = key2.GetComponent<BaseTagComponent>();
			if (key2 != null && (!this.NeedCheckTag || component.HasAnyTag(tagIds)) && !component.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.免疫子弹吸附"]))
			{
				this.PhysicalForce(key2);
			}
		}
	}

	// Token: 0x060179FC RID: 96764 RVA: 0x006934A0 File Offset: 0x006916A0
	private void PhysicalForce(Entity character)
	{
		CharacterMoveComponent component = character.GetComponent<CharacterMoveComponent>();
		if (component == null || !component.Valid || component.CharacterWeight > (float)this.Parameter.LimitWeight)
		{
			return;
		}
		Vector actorLocationProxy = character.GetComponent<BaseActorComponent>().ActorLocationProxy;
		double num = Vector.Dist(this.BulletActorComp.ActorLocationProxy, actorLocationProxy);
		if (num > (double)this.Parameter.OuterRadius || num < (double)this.Parameter.InnerRadius || this.Parameter.OuterRadius <= 0f)
		{
			return;
		}
		float num2 = Math.Max(50f, component.CharacterWeight) - 14f;
		double inB = Math.Exp(-(num / (double)this.Parameter.OuterRadius * (double)this.Parameter.ForceDampingRatio * 0.5)) * (double)this.Parameter.ForceBase * 5000.0 / (double)(num2 * num2) * 100.0;
		Vector vector = Vector.Create(this.BulletActorComp.ActorLocation);
		vector.SubtractionEqual(actorLocationProxy);
		if (this.LogicController.ForceHorizontal)
		{
			vector.Z = 0.0;
		}
		vector.Normalize(9.999999747378752E-06);
		vector.MultiplyEqual(inB);
		int num3;
		int value = this.VelocityAdditionHandlerMap.TryGetValue(character, out num3) ? num3 : 0;
		value = component.SetAddMoveWorld(new FVectorDouble?(vector.ToUeVector(false)), 0.1f, null, new int?(value), null, EVelocityCurveType.None, 0f, 1f);
		this.VelocityAdditionHandlerMap[character] = value;
		if (this.ImmuneStopDuration > 0f)
		{
			CharacterHitComponent component2 = character.GetComponent<CharacterHitComponent>();
			if (component2 != null && !component2.IsImmuneTimeScaleEffect())
			{
				component2.AddImmuneTimeScaleEffectTimer(this.ImmuneStopDuration * 1000f);
			}
		}
	}

	// Token: 0x060179FD RID: 96765 RVA: 0x0069367C File Offset: 0x0069187C
	private void TowardsConstantForce(Entity character)
	{
		CharacterUnifiedStateComponent component = character.GetComponent<CharacterUnifiedStateComponent>();
		CharacterMoveComponent component2 = character.GetComponent<CharacterMoveComponent>();
		if (component == null || !component.Valid || (component2 == null || !component2.Valid))
		{
			return;
		}
		int? movementMode = new int?(2);
		if (this.IsLaunching)
		{
			if (component.PositionState != ECharPositionState.Air || component.MoveState != ECharMoveState.Other)
			{
				CharacterActorComponent actorComp = component2.ActorComp;
				if (actorComp != null)
				{
					TsBaseCharacter actor = actorComp.Actor;
					if (actor != null)
					{
						actor.KuroSetMovementMode(new SetMovementModeInfo
						{
							Mode = EMovementMode.MOVE_Falling,
							Context = "[BulletLogicForceController.TowardsConstantForce]"
						});
					}
				}
			}
			movementMode = null;
		}
		else
		{
			if (component.MoveState != ECharMoveState.Glide)
			{
				this.InAreaButNotGlidingEntity.Add(character);
				return;
			}
			if (this.InAreaButNotGlidingEntity2.Contains(character))
			{
				component2.SetForceSpeed(Vector.ZeroVectorProxy);
			}
		}
		int num;
		int value = this.VelocityAdditionHandlerMap.TryGetValue(character, out num) ? num : 0;
		BaseActorComponent component3 = character.GetComponent<BaseActorComponent>();
		CharacterMoveComponent attackerMoveComp = this.BulletInfo.AttackerMoveComp;
		bool flag = attackerMoveComp == null || attackerMoveComp.IsStandardGravity;
		float num2;
		if (flag)
		{
			num2 = (float)(this.BulletActorComp.ActorLocationProxy.Z - component3.ActorLocationProxy.Z);
		}
		else
		{
			Vector vector = BulletPool.CreateVector(false);
			vector.FromUeVector(this.BulletActorComp.ActorLocationProxy);
			vector.SubtractionEqual(component3.ActorLocationProxy);
			num2 = (float)Vector.DotProduct(vector, this.BulletInfo.AttackerMoveComp.GravityUp);
			BulletPool.RecycleVector(vector);
		}
		double num3 = (double)(num2 - component3.ScaledHalfHeight) + this.BulletInfo.Size.Z;
		if (this.Parameter.HaveTopArea && num3 < (double)this.Parameter.TopAreaHeight)
		{
			if (num3 > 0.0)
			{
				if (flag)
				{
					this.UpForce.Set(0.0, 0.0, (double)(-(double)component2.CharacterMovement.Velocity.Z));
				}
				else
				{
					Vector vector2 = BulletPool.CreateVector(false);
					FVector velocity = component2.CharacterMovement.Velocity;
					vector2.FromUeVector(velocity);
					double inB = -Vector.DotProduct(vector2, this.BulletInfo.AttackerMoveComp.GravityUp);
					BulletPool.RecycleVector(vector2);
					this.BulletInfo.AttackerMoveComp.GravityUp.Multiply(inB, this.UpForce);
				}
				value = component2.SetAddMoveWorld(new FVectorDouble?(this.UpForce.ToUeVector(false)), 0.1f, this.Parameter.ContinueTimeCurve ?? null, new int?(value), null, EVelocityCurveType.None, 0f, 1f);
				this.VelocityAdditionHandlerMap[character] = value;
			}
			return;
		}
		float timeLength;
		if (this.Parameter.TowardsBullet)
		{
			timeLength = this.Parameter.ContinueTime;
			if (flag)
			{
				this.UpForce.Set(0.0, 0.0, 230.0);
			}
			else
			{
				this.BulletInfo.AttackerMoveComp.GravityUp.Multiply(230.0, this.UpForce);
			}
			int num4;
			int num5;
			int value2 = this.Parameter.IsResetOnLast ? (BulletLogicForceController.LastGravityAdditionHandler.TryGetValue(this.Parameter.Group, out num4) ? num4 : 0) : (this.GravityAdditionHandlerMap.TryGetValue(character, out num5) ? num5 : 0);
			value2 = component2.SetAddMoveWorld(new FVectorDouble?(this.UpForce.ToUeVector(false)), timeLength, null, new int?(value2), movementMode, EVelocityCurveType.None, 0f, 1f);
			if (this.Parameter.IsResetOnLast)
			{
				BulletLogicForceController.LastGravityAdditionHandler[this.Parameter.Group] = value2;
			}
			else
			{
				this.GravityAdditionHandlerMap[character] = value2;
			}
		}
		else
		{
			timeLength = 0.1f;
		}
		int num6;
		int num7;
		value = (this.Parameter.IsResetOnLast ? (BulletLogicForceController.LastVelocityAdditionHandler.TryGetValue(this.Parameter.Group, out num6) ? num6 : 0) : (this.VelocityAdditionHandlerMap.TryGetValue(character, out num7) ? num7 : 0));
		value = component2.SetAddMoveWorld(new FVectorDouble?(this.ConstantForceVector.ToUeVector(false)), timeLength, this.Parameter.ContinueTimeCurve ?? null, new int?(value), movementMode, EVelocityCurveType.None, 0f, 1f);
		if (this.Parameter.IsResetOnLast)
		{
			BulletLogicForceController.LastVelocityAdditionHandler[this.Parameter.Group] = value;
			return;
		}
		this.VelocityAdditionHandlerMap[character] = value;
	}

	// Token: 0x060179FE RID: 96766 RVA: 0x00693AF8 File Offset: 0x00691CF8
	public static void CreateStaticDefaultValue()
	{
		BulletLogicForceController._lastVelocityAdditionHandler = new Dictionary<int, int>();
		BulletLogicForceController._lastGravityAdditionHandler = new Dictionary<int, int>();
	}

	// Token: 0x060179FF RID: 96767 RVA: 0x00693B0E File Offset: 0x00691D0E
	public static void ResetStaticDefaultValue()
	{
		BulletLogicForceController._lastVelocityAdditionHandler = null;
		BulletLogicForceController._lastGravityAdditionHandler = null;
	}

	// Token: 0x0400B5EB RID: 46571
	private const float WEIGHT_COEFFICIENT = 14f;

	// Token: 0x0400B5EC RID: 46572
	private const float TOLERANCE = 1E-05f;

	// Token: 0x0400B5ED RID: 46573
	private const float FORCE_DAMPING_RATIO = 0.5f;

	// Token: 0x0400B5EE RID: 46574
	private const float MOVE_TIME = 0.1f;

	// Token: 0x0400B5EF RID: 46575
	private const float FORCE_RATIO = 5000f;

	// Token: 0x0400B5F0 RID: 46576
	private const float MIN_WEIGHT = 50f;

	// Token: 0x0400B5F1 RID: 46577
	private const float LENGTH_CONVERSION = 100f;

	// Token: 0x0400B5F2 RID: 46578
	private readonly LogicDataForce Parameter;

	// Token: 0x0400B5F3 RID: 46579
	private readonly BulletInfo BulletInfo;

	// Token: 0x0400B5F4 RID: 46580
	private readonly BulletActorComponent BulletActorComp;

	// Token: 0x0400B5F5 RID: 46581
	private readonly Dictionary<Entity, int> VelocityAdditionHandlerMap;

	// Token: 0x0400B5F6 RID: 46582
	[Nullable(2)]
	private static Dictionary<int, int> _lastVelocityAdditionHandler;

	// Token: 0x0400B5F7 RID: 46583
	[Nullable(2)]
	private static Dictionary<int, int> _lastGravityAdditionHandler;

	// Token: 0x0400B5F8 RID: 46584
	private readonly Dictionary<Entity, int> GravityAdditionHandlerMap;

	// Token: 0x0400B5F9 RID: 46585
	private readonly bool ConstantForce;

	// Token: 0x0400B5FA RID: 46586
	[Nullable(2)]
	private Vector ConstantForceVector;

	// Token: 0x0400B5FB RID: 46587
	private readonly bool IsLaunching;

	// Token: 0x0400B5FC RID: 46588
	private readonly bool NeedCheckTag;

	// Token: 0x0400B5FD RID: 46589
	private HashSet<Entity> InAreaButNotGlidingEntity = new HashSet<Entity>();

	// Token: 0x0400B5FE RID: 46590
	private HashSet<Entity> InAreaButNotGlidingEntity2 = new HashSet<Entity>();

	// Token: 0x0400B5FF RID: 46591
	private readonly Vector UpForce = Vector.Create();

	// Token: 0x0400B600 RID: 46592
	private readonly float ImmuneStopDuration;
}
