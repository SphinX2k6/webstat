using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003060 RID: 12384
[NullableContext(1)]
[Nullable(0)]
public class CharacterPendulumComponent : EntityComponent
{
	// Token: 0x1700224B RID: 8779
	// (get) Token: 0x06019722 RID: 104226 RVA: 0x0075ADC8 File Offset: 0x00758FC8
	// (set) Token: 0x06019723 RID: 104227 RVA: 0x0075ADD0 File Offset: 0x00758FD0
	public bool Hooked
	{
		get
		{
			return this.HookedInternal;
		}
		set
		{
			this.HookedInternal = value;
		}
	}

	// Token: 0x1700224C RID: 8780
	// (get) Token: 0x06019724 RID: 104228 RVA: 0x0075ADD9 File Offset: 0x00758FD9
	// (set) Token: 0x06019725 RID: 104229 RVA: 0x0075ADE1 File Offset: 0x00758FE1
	public double UpLength
	{
		get
		{
			return this.UpLengthInternal;
		}
		set
		{
			this.UpLengthInternal = value;
		}
	}

	// Token: 0x1700224D RID: 8781
	// (get) Token: 0x06019726 RID: 104230 RVA: 0x0075ADEA File Offset: 0x00758FEA
	// (set) Token: 0x06019727 RID: 104231 RVA: 0x0075ADF8 File Offset: 0x00758FF8
	public FVectorDouble GrabPoint
	{
		get
		{
			return this.GrabPointInternal.ToUeVector(false);
		}
		set
		{
			this.GrabPointInternal.FromUeVector(value);
		}
	}

	// Token: 0x1700224E RID: 8782
	// (get) Token: 0x06019728 RID: 104232 RVA: 0x0075AE07 File Offset: 0x00759007
	// (set) Token: 0x06019729 RID: 104233 RVA: 0x0075AE0F File Offset: 0x0075900F
	public string SocketName
	{
		get
		{
			return this.SocketNameInternal;
		}
		set
		{
			this.SocketNameInternal = value;
		}
	}

	// Token: 0x1700224F RID: 8783
	// (get) Token: 0x0601972A RID: 104234 RVA: 0x0075AE18 File Offset: 0x00759018
	// (set) Token: 0x0601972B RID: 104235 RVA: 0x0075AE20 File Offset: 0x00759020
	public double RopeForce
	{
		get
		{
			return this.RopeForceInternal;
		}
		set
		{
			this.RopeForceInternal = value;
		}
	}

	// Token: 0x17002250 RID: 8784
	// (get) Token: 0x0601972C RID: 104236 RVA: 0x0075AE29 File Offset: 0x00759029
	// (set) Token: 0x0601972D RID: 104237 RVA: 0x0075AE31 File Offset: 0x00759031
	public double DistanceRopeToActor
	{
		get
		{
			return this.DistanceRopeToActorInternal;
		}
		set
		{
			this.DistanceRopeToActorInternal = value;
		}
	}

	// Token: 0x17002251 RID: 8785
	// (get) Token: 0x0601972E RID: 104238 RVA: 0x0075AE3A File Offset: 0x0075903A
	// (set) Token: 0x0601972F RID: 104239 RVA: 0x0075AE42 File Offset: 0x00759042
	public float AirControl
	{
		get
		{
			return this.AirControlInternal;
		}
		set
		{
			this.AirControlInternal = value;
		}
	}

	// Token: 0x06019730 RID: 104240 RVA: 0x0075AE4C File Offset: 0x0075904C
	protected override bool OnStart()
	{
		CharacterActorComponent characterActorComponent = base.Entity.CheckGetComponent<CharacterActorComponent>();
		this.Player = characterActorComponent.Actor;
		Singleton<EventSystem>.Instance.AddWithTarget<float>(base.Entity, EEventName.CustomMovePendulum, this.ReceivePendulumEvent);
		Singleton<EventSystem>.Instance.AddWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, this.OnCharMovementModeChanged);
		UCharacterMovementComponent characterMovement = base.Entity.GetComponent<CharacterMoveComponent>().CharacterMovement;
		this.DefaultAirControl = characterMovement.AirControl;
		return true;
	}

	// Token: 0x06019731 RID: 104241 RVA: 0x0075AEC4 File Offset: 0x007590C4
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<float>(base.Entity, EEventName.CustomMovePendulum, this.ReceivePendulumEvent);
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, this.OnCharMovementModeChanged);
		this.BreakRope();
		return true;
	}

	// Token: 0x06019732 RID: 104242 RVA: 0x0075AF02 File Offset: 0x00759102
	protected override void OnTick(float delta)
	{
		if (1 == this.FrameIndex)
		{
			this.FrameIndex = 0;
			return;
		}
		this.ThrowRopeAndSwing((double)delta);
	}

	// Token: 0x06019733 RID: 104243 RVA: 0x0075AF20 File Offset: 0x00759120
	protected void DrawCube(FTransformDouble transform, float duration)
	{
		int num = 156;
		FLinearColor lineColor = new FLinearColor((float)num, (float)num, (float)num, (float)num);
		FVectorDouble location = transform.GetLocation();
		int num2 = 10;
		FVector fvector = new FVector((float)num2, (float)num2, (float)num2);
		FVectorDouble extent = new FVectorDouble((double)fvector.X * 0.5, (double)fvector.Y * 0.5, (double)fvector.Z * 0.5);
		FRotator rotation = transform.Rotator();
		int num3 = 30;
		UKismetSystemLibrary.D_DrawDebugBox(GlobalData.World, location, extent, lineColor, rotation, duration, (float)num3);
		double num4 = 0.5;
		FVectorDouble lineStart = UKismetMathLibrary.D_TransformLocation(transform, new FVectorDouble(num4, num4, num4));
		FVectorDouble lineEnd = UKismetMathLibrary.D_TransformLocation(transform, new FVectorDouble(-num4, -num4, -num4));
		int num5 = 15;
		UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, lineStart, lineEnd, lineColor, duration, (float)num5);
		FVectorDouble lineStart2 = UKismetMathLibrary.D_TransformLocation(transform, new FVectorDouble(num4, -num4, num4));
		FVectorDouble lineEnd2 = UKismetMathLibrary.D_TransformLocation(transform, new FVectorDouble(-num4, num4, num4));
		UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, lineStart2, lineEnd2, lineColor, duration, (float)num5);
	}

	// Token: 0x06019734 RID: 104244 RVA: 0x0075B044 File Offset: 0x00759244
	private void ThrowRopeAndSwing(double delta)
	{
		if (!this.HookedInternal)
		{
			return;
		}
		Vector velocity = this.Velocity;
		FVectorDouble fvectorDouble = this.Player.D_GetVelocity();
		velocity.FromUeVector(fvectorDouble);
		if (delta > 33.0)
		{
			double num = (delta > 50.0) ? (delta / 50.0) : (delta / 33.0);
			double num2 = this.Velocity.Size() / num;
			if (1.0 < num2 && this.Velocity.Z < 0.0)
			{
				BaseMoveComponent component = base.Entity.GetComponent<CharacterMoveComponent>();
				int num3 = (delta > 50.0) ? 11 : 5;
				CharacterPendulumComponent.TmpVector.Set(0.0, 0.0, Math.Abs(this.Velocity.Z) / num2 * (double)num3);
				component.MoveCharacter(CharacterPendulumComponent.TmpVector, (float)(delta * 0.0010000000474974513), "钩锁.ThrowRopeAndSwing");
			}
		}
		Vector vector = Vector.Create(this.Player.D_K2_GetActorLocation());
		vector.Subtraction(this.GrabPointInternal, vector);
		double inB = Vector.DotProduct(this.Velocity, vector);
		vector.Normalize(9.99999993922529E-09);
		Vector vector2 = Vector.Create();
		vector.Multiply(inB, vector2);
		vector2.Multiply(this.RopeForce, vector2);
		UCharacterMovementComponent characterMovement = base.Entity.GetComponent<CharacterMoveComponent>().CharacterMovement;
		if (vector2.Size() > 600000.0)
		{
			vector2.Normalize(9.99999993922529E-09);
			vector2.Multiply(600000.0, vector2);
		}
		characterMovement.AddForce(vector2.ToUeVectorOld());
		characterMovement.AirControl = this.AirControlInternal;
	}

	// Token: 0x06019735 RID: 104245 RVA: 0x0075B209 File Offset: 0x00759409
	private void BreakRope()
	{
		this.HookedInternal = false;
		base.Entity.GetComponent<CharacterMoveComponent>().CharacterMovement.AirControl = this.DefaultAirControl;
	}

	// Token: 0x06019736 RID: 104246 RVA: 0x0075B22D File Offset: 0x0075942D
	public void SetPendulumData(double addVelocityX, double addVelocityY, double addVelocityZ, double forwardLossPercentage, double lossPercentage, double gravity, double friction, double deceleration, double accelerator, double maxSpeed, double maxFallingSpeed)
	{
		this.HookedInternal = true;
		this.FrameIndex = 1;
	}

	// Token: 0x06019737 RID: 104247 RVA: 0x0075B23D File Offset: 0x0075943D
	public void Reset()
	{
		this.FrameIndex = 0;
		this.BreakRope();
	}

	// Token: 0x06019738 RID: 104248 RVA: 0x0075B24C File Offset: 0x0075944C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterPendulumComponent characterPendulumComponent = (CharacterPendulumComponent)componentTemplate;
		if (base.CanResetComponentProperty("Player"))
		{
			if (characterPendulumComponent.Player == null)
			{
				this.Player = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.Player), "Player"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HookedInternal"))
		{
			this.HookedInternal = characterPendulumComponent.HookedInternal;
		}
		if (base.CanResetComponentProperty("UpLengthInternal"))
		{
			this.UpLengthInternal = characterPendulumComponent.UpLengthInternal;
		}
		if (base.CanResetComponentProperty("GrabPointInternal") && characterPendulumComponent.GrabPointInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.GrabPointInternal), "GrabPointInternal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SocketNameInternal"))
		{
			this.SocketNameInternal = characterPendulumComponent.SocketNameInternal;
		}
		if (base.CanResetComponentProperty("RopeForceInternal"))
		{
			this.RopeForceInternal = characterPendulumComponent.RopeForceInternal;
		}
		if (base.CanResetComponentProperty("DistanceRopeToActorInternal"))
		{
			this.DistanceRopeToActorInternal = characterPendulumComponent.DistanceRopeToActorInternal;
		}
		if (base.CanResetComponentProperty("AirControlInternal"))
		{
			this.AirControlInternal = characterPendulumComponent.AirControlInternal;
		}
		if (base.CanResetComponentProperty("FrameIndex"))
		{
			this.FrameIndex = characterPendulumComponent.FrameIndex;
		}
		if (base.CanResetComponentProperty("DefaultAirControl"))
		{
			this.DefaultAirControl = characterPendulumComponent.DefaultAirControl;
		}
		return (!base.CanResetComponentProperty("Velocity") || characterPendulumComponent.Velocity == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.Velocity), "Velocity")) && (!base.CanResetComponentProperty("ReceivePendulumEvent") || characterPendulumComponent.ReceivePendulumEvent == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Action<float>>(this.ReceivePendulumEvent), "ReceivePendulumEvent")) && (!base.CanResetComponentProperty("OnCharMovementModeChanged") || characterPendulumComponent.OnCharMovementModeChanged == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Action<int, EMovementMode, EMovementMode, byte, byte>>(this.OnCharMovementModeChanged), "OnCharMovementModeChanged"));
	}

	// Token: 0x0400C98D RID: 51597
	private const int LIMIT_FRAME_TIME = 33;

	// Token: 0x0400C98E RID: 51598
	private const int LIMIT_FRAME_TIME2 = 50;

	// Token: 0x0400C98F RID: 51599
	private const int UPDATE_UP_Z = 5;

	// Token: 0x0400C990 RID: 51600
	private const int UPDATE_UP_Z2 = 11;

	// Token: 0x0400C991 RID: 51601
	private const int LIMIT_FORCE = 600000;

	// Token: 0x0400C992 RID: 51602
	[StaticVariableRuleIgnore]
	protected static Vector TmpVector = Vector.Create();

	// Token: 0x0400C993 RID: 51603
	[Nullable(2)]
	private TsBaseCharacter Player;

	// Token: 0x0400C994 RID: 51604
	private bool HookedInternal;

	// Token: 0x0400C995 RID: 51605
	private double UpLengthInternal;

	// Token: 0x0400C996 RID: 51606
	private readonly Vector GrabPointInternal = Vector.Create();

	// Token: 0x0400C997 RID: 51607
	private string SocketNameInternal = "";

	// Token: 0x0400C998 RID: 51608
	private double RopeForceInternal;

	// Token: 0x0400C999 RID: 51609
	private double DistanceRopeToActorInternal;

	// Token: 0x0400C99A RID: 51610
	private float AirControlInternal;

	// Token: 0x0400C99B RID: 51611
	private int FrameIndex;

	// Token: 0x0400C99C RID: 51612
	private float DefaultAirControl;

	// Token: 0x0400C99D RID: 51613
	private readonly Vector Velocity = Vector.Create();

	// Token: 0x0400C99E RID: 51614
	private readonly Action<float> ReceivePendulumEvent = delegate(float deltaTime)
	{
	};

	// Token: 0x0400C99F RID: 51615
	private readonly Action<int, EMovementMode, EMovementMode, byte, byte> OnCharMovementModeChanged = delegate(int charId, EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode)
	{
	};
}
