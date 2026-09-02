using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x020030CA RID: 12490
[NullableContext(1)]
[Nullable(0)]
public class CharacterCatapultComponent : EntityComponent, IComponentDependency, IStaticVariableResetter
{
	// Token: 0x06019C1E RID: 105502 RVA: 0x00780F2D File Offset: 0x0077F12D
	static CharacterCatapultComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterCatapultComponent.CreateStaticDefaultValue), new Action(CharacterCatapultComponent.ResetStaticDefaultValue));
	}

	// Token: 0x06019C1F RID: 105503 RVA: 0x00780F4C File Offset: 0x0077F14C
	public static void CreateStaticDefaultValue()
	{
		CharacterCatapultComponent._tmpVector = Vector.Create();
	}

	// Token: 0x06019C20 RID: 105504 RVA: 0x00780F58 File Offset: 0x0077F158
	public static void ResetStaticDefaultValue()
	{
		CharacterCatapultComponent._tmpVector = null;
	}

	// Token: 0x170022B8 RID: 8888
	// (get) Token: 0x06019C21 RID: 105505 RVA: 0x00780F60 File Offset: 0x0077F160
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CharacterMoveComponent)
			};
		}
	}

	// Token: 0x170022B9 RID: 8889
	// (get) Token: 0x06019C22 RID: 105506 RVA: 0x00780F82 File Offset: 0x0077F182
	private static Vector TmpVector
	{
		get
		{
			return CharacterCatapultComponent._tmpVector;
		}
	}

	// Token: 0x06019C23 RID: 105507 RVA: 0x00780F8C File Offset: 0x0077F18C
	private void OnCustomMoveCatapult(float deltaSeconds)
	{
		if ((double)deltaSeconds < 1E-08)
		{
			return;
		}
		this.CatapultUnit.GetOffset(this.RunTime, deltaSeconds, CharacterCatapultComponent.TmpVector);
		this.RunTime += deltaSeconds;
		this.MoveComp.MoveCharacter(CharacterCatapultComponent.TmpVector, deltaSeconds, "");
		if (this.LockRotator)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.SetInputRotator(this.CatapultUnit.GetEndRotator());
			}
		}
		if (this.RunTime > this.CatapultUnit.TimeLength)
		{
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null)
			{
				actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Falling,
					Context = "[CharacterCatapultComponent.OnCustomMoveCatapult]"
				});
			}
			this.CatapultUnit.GetSpeed(this.RunTime, CharacterCatapultComponent.TmpVector);
			this.MoveComp.SetForceSpeed(CharacterCatapultComponent.TmpVector);
		}
	}

	// Token: 0x06019C24 RID: 105508 RVA: 0x0078106C File Offset: 0x0077F26C
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.CatapultUnit = new BigJumpUnit();
		return true;
	}

	// Token: 0x06019C25 RID: 105509 RVA: 0x0078107C File Offset: 0x0077F27C
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CustomMoveCatapult, new Action<float>(this.OnCustomMoveCatapult));
		return true;
	}

	// Token: 0x06019C26 RID: 105510 RVA: 0x007810CB File Offset: 0x0077F2CB
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CustomMoveCatapult, new Action<float>(this.OnCustomMoveCatapult));
		return true;
	}

	// Token: 0x06019C27 RID: 105511 RVA: 0x007810F0 File Offset: 0x0077F2F0
	public void SetConfig(float time1, Vector startPoint, Vector middlePoint, Vector endPoint, string curvePath = "", float gravity2 = 1960f, [Nullable(2)] Rotator endRotator = null, [Nullable(2)] Vector gravityDirect = null, bool isSuperCatapult = false)
	{
		this.IsSuperCatapult = isSuperCatapult;
		this.LockRotator = (gravity2 > 0f);
		this.CatapultUnit.SetAll(time1, startPoint, middlePoint, endPoint, curvePath, gravity2, endRotator, gravityDirect, "", null);
	}

	// Token: 0x06019C28 RID: 105512 RVA: 0x00781134 File Offset: 0x0077F334
	public unsafe void StartCatapult()
	{
		this.CatapultUnit.SetStartPoint(this.ActorComp.ActorLocationProxy);
		this.CatapultUnit.Init();
		this.RunTime = 0f;
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Custom,
				CustomMode = 6,
				Context = "[CharacterCatapultComponent.StartCatapult]"
			});
		}
		CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
		if (component != null)
		{
			component.SetLocationAndRotatorWithModelBuffer(this.ActorComp.ActorLocationProxy.ToUeVector(false), this.CatapultUnit.GetEndRotator().ToUeRotator(), 200f, "Catapult Start", ESetRotationPriority.Anim, true);
		}
		if (this.IsSuperCatapult)
		{
			UAnimMontage skillMontageInstance = base.Entity.GetComponent<CharacterSkillComponent>().GetSkillMontageInstance(400107, 0);
			if (((component != null) ? component.MainAnimInstance : null) != null && skillMontageInstance != null && skillMontageInstance.IsValid())
			{
				float num = component.MainAnimInstance.Montage_GetPosition(skillMontageInstance);
				float newPlayRate = (skillMontageInstance.SequenceLength - num) / this.CatapultUnit.RisingTime;
				component.MainAnimInstance.Montage_SetPlayRate(skillMontageInstance, newPlayRate);
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Movement;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "StartCatapult";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.ActorComp.Actor.GetName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CatapultUnit", this.CatapultUnit);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsSuperCatapult", this.IsSuperCatapult);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06019C29 RID: 105513 RVA: 0x007812D4 File Offset: 0x0077F4D4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterCatapultComponent characterCatapultComponent = (CharacterCatapultComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterCatapultComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterCatapultComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RunTime"))
		{
			this.RunTime = characterCatapultComponent.RunTime;
		}
		if (base.CanResetComponentProperty("CatapultUnit"))
		{
			if (characterCatapultComponent.CatapultUnit == null)
			{
				this.CatapultUnit = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BigJumpUnit>(this.CatapultUnit), "CatapultUnit"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LockRotator"))
		{
			this.LockRotator = characterCatapultComponent.LockRotator;
		}
		if (base.CanResetComponentProperty("IsSuperCatapult"))
		{
			this.IsSuperCatapult = characterCatapultComponent.IsSuperCatapult;
		}
		return true;
	}

	// Token: 0x0400CD82 RID: 52610
	public const int MODEL_BUFFER_TIME_LENGTH = 200;

	// Token: 0x0400CD83 RID: 52611
	public const int SUPER_CATAPULT_SKILL_ID = 400107;

	// Token: 0x0400CD84 RID: 52612
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CD85 RID: 52613
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400CD86 RID: 52614
	private float RunTime;

	// Token: 0x0400CD87 RID: 52615
	[Nullable(2)]
	private BigJumpUnit CatapultUnit;

	// Token: 0x0400CD88 RID: 52616
	public bool LockRotator;

	// Token: 0x0400CD89 RID: 52617
	private bool IsSuperCatapult;

	// Token: 0x0400CD8A RID: 52618
	[Nullable(2)]
	private static Vector _tmpVector;
}
