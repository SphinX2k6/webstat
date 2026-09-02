using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.World;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003253 RID: 12883
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractPlane.TsSimpleInteractPlane_C")]
public class TsSimpleInteractPlane : TsSimpleInteractBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002474 RID: 9332
	// (get) Token: 0x0601ADAA RID: 109994 RVA: 0x00802785 File Offset: 0x00800985
	// (set) Token: 0x0601ADAB RID: 109995 RVA: 0x00802795 File Offset: 0x00800995
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float PlaneHalfHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleInteractPlane.__PropertyOffset_PlaneHalfHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleInteractPlane.__PropertyOffset_PlaneHalfHeight) = value;
		}
	}

	// Token: 0x17002475 RID: 9333
	// (get) Token: 0x0601ADAC RID: 109996 RVA: 0x008027A6 File Offset: 0x008009A6
	// (set) Token: 0x0601ADAD RID: 109997 RVA: 0x008027B6 File Offset: 0x008009B6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float PlaneHalfWidth
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSimpleInteractPlane.__PropertyOffset_PlaneHalfWidth);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSimpleInteractPlane.__PropertyOffset_PlaneHalfWidth) = value;
		}
	}

	// Token: 0x0601ADAE RID: 109998 RVA: 0x008027C8 File Offset: 0x008009C8
	protected override void OnBeginPlay()
	{
		this.SelfForward = Vector.Create();
		this.SelfRight = Vector.Create();
		this.SelfUp = Vector.Create();
		this.SelfBackward = Vector.Create();
		this.Forward2D = Vector.Create();
		this.TmpResultLocation = Vector.Create();
		this.TmpResultRotator = Rotator.Create();
		this.TmpLocation = Vector.Create();
		this.StartLocation = Vector.Create();
		this.EndLocation = Vector.Create();
		this.NormalRotator = Rotator.Create();
		base.OnBeginPlay();
	}

	// Token: 0x0601ADAF RID: 109999 RVA: 0x00802854 File Offset: 0x00800A54
	protected override void UpdateData()
	{
		base.UpdateData();
		Quat rotation = this.SelfTransform.GetRotation();
		rotation.RotateVector(Vector.ForwardVectorProxy, this.SelfForward);
		rotation.RotateVector(Vector.RightVectorProxy, this.SelfRight);
		this.SelfForward.CrossProduct(this.SelfRight, this.SelfUp);
		this.ForwardSizeSquared2D = (float)(1.0 - Singleton<MathUtils>.Instance.Square(this.SelfForward.Z));
		if (!this.IsHorizontalPlane)
		{
			this.Forward2D.DeepCopy(this.SelfForward);
			this.Forward2D.Z = 0.0;
			this.Forward2D.DivisionEqual((double)this.ForwardSizeSquared2D);
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.SelfBackward, Vector.UpVectorProxy, this.NormalRotator);
		}
	}

	// Token: 0x0601ADB0 RID: 110000 RVA: 0x0080292C File Offset: 0x00800B2C
	protected override bool CheckLegal()
	{
		if (this.TmpLocation == null)
		{
			this.TmpLocation = Vector.Create();
		}
		if (this.StartLocation == null)
		{
			this.StartLocation = Vector.Create();
		}
		if (this.EndLocation == null)
		{
			this.EndLocation = Vector.Create();
		}
		bool isLegal = this.IsLegal;
		if (this.LineTrace == null)
		{
			base.InitTraceInfo();
		}
		int num = (int)Math.Ceiling((double)(this.PlaneHalfHeight * 2f / 100f)) + 1;
		float num2 = (num > 1) ? (this.PlaneHalfHeight * 2f / (float)(num - 1)) : 0f;
		float num3 = -this.PlaneHalfHeight;
		for (int i = 0; i < num; i++)
		{
			this.TmpLocation.X = 0.0;
			this.TmpLocation.Y = (double)(-(double)this.PlaneHalfWidth);
			this.TmpLocation.Z = (double)num3;
			this.SelfTransform.TransformPositionNoScale(this.TmpLocation, this.StartLocation);
			this.TmpLocation.Y = (double)this.PlaneHalfWidth;
			this.SelfTransform.TransformPositionNoScale(this.TmpLocation, this.EndLocation);
			this.LineTrace.WorldContextObject = this;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.LineTrace, this.StartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.LineTrace, this.EndLocation);
			if (Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "TsSimpleInteractPlane_CheckLegal"))
			{
				return false;
			}
			num3 += num2;
		}
		int num4 = (int)Math.Ceiling((double)(this.PlaneHalfWidth * 2f / 100f)) + 1;
		float num5 = (num4 > 1) ? (this.PlaneHalfWidth * 2f / (float)(num4 - 1)) : 0f;
		float num6 = -this.PlaneHalfWidth;
		for (int j = 0; j < num4; j++)
		{
			this.TmpLocation.X = 0.0;
			this.TmpLocation.Y = (double)num6;
			this.TmpLocation.Z = (double)(-(double)this.PlaneHalfHeight);
			this.SelfTransform.TransformPositionNoScale(this.TmpLocation, this.StartLocation);
			this.TmpLocation.Z = (double)this.PlaneHalfHeight;
			this.SelfTransform.TransformPositionNoScale(this.TmpLocation, this.EndLocation);
			this.LineTrace.WorldContextObject = this;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.LineTrace, this.StartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.LineTrace, this.EndLocation);
			if (Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "TsSimpleInteractPlane_CheckLegal"))
			{
				return false;
			}
			num6 += num5;
		}
		return true;
	}

	// Token: 0x0601ADB1 RID: 110001 RVA: 0x00802BD0 File Offset: 0x00800DD0
	protected override void OnDraw()
	{
		FLinearColor lineColor = this.IsLegal ? TsSimpleInteractPlane.GreenColor : TsSimpleInteractPlane.YellowColor;
		this.TmpLocation.X = 0.0;
		int num = TsSimpleInteractPlane.DrawPoints.Length;
		for (int i = 0; i < num; i++)
		{
			this.TmpLocation.Y = (double)(TsSimpleInteractPlane.DrawPoints[i].Y * this.PlaneHalfWidth);
			this.TmpLocation.Z = (double)(TsSimpleInteractPlane.DrawPoints[i].Z * this.PlaneHalfHeight);
			this.SelfTransform.TransformPositionNoScale(this.TmpLocation, this.StartLocation);
			for (int j = i + 1; j < num; j++)
			{
				this.TmpLocation.Y = (double)(TsSimpleInteractPlane.DrawPoints[j].Y * this.PlaneHalfWidth);
				this.TmpLocation.Z = (double)(TsSimpleInteractPlane.DrawPoints[j].Z * this.PlaneHalfHeight);
				this.SelfTransform.TransformPositionNoScale(this.TmpLocation, this.EndLocation);
				UKismetSystemLibrary.D_DrawDebugLine(this, this.StartLocation.ToUeVector(false), this.EndLocation.ToUeVector(false), lineColor, 0.05f, 4f);
			}
		}
		this.SelfTransform.TransformPositionNoScale(TsSimpleInteractPlane.ForwardOffset, this.EndLocation);
		UKismetSystemLibrary.D_DrawDebugArrow(this, base.D_K2_GetActorLocation(), this.EndLocation.ToUeVector(false), 100f, TsSimpleInteractPlane.RedColor, 0.05f, 4f);
	}

	// Token: 0x0601ADB2 RID: 110002 RVA: 0x00802D5C File Offset: 0x00800F5C
	protected override void SetText(FVector offset)
	{
		base.Text.HorizontalAlignment = EHorizTextAligment.EHTA_Center;
		base.Text.SetWorldSize(200f);
		base.Text.SetTextRenderColor(TsSimpleInteractPlane.TextColor);
		UTextRenderComponent text = base.Text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Plane ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(base.TypeId);
		text.Text = defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601ADB3 RID: 110003 RVA: 0x00802DD4 File Offset: 0x00800FD4
	[NullableContext(1)]
	protected override SSimpleInteractResult OnGetBestTransform(AActor actor, FVector moveOffset, float halfHeight, float radius)
	{
		this.UpdateData();
		SSimpleInteractResult tmpResult = this.TmpResult;
		Vector actorLocation = this.ActorLocation;
		FVectorDouble fvectorDouble = actor.D_K2_GetActorLocation();
		actorLocation.FromUeVector(fvectorDouble);
		this.ActorLocation.Subtraction(this.SelfLocation, this.SelfToActor);
		tmpResult.Success = (this.SelfToActor.DotProduct(this.SelfForward) > (double)radius);
		if (!tmpResult.Success)
		{
			return tmpResult;
		}
		this.MoveOffset.FromUeVector(moveOffset);
		if (this.IsHorizontalPlane)
		{
			ValueTuple<Vector, Rotator, float> bestTransformHorizontal = this.GetBestTransformHorizontal(halfHeight, radius);
			tmpResult.Location = bestTransformHorizontal.Item1.ToUeVectorOld();
			tmpResult.Rotator = bestTransformHorizontal.Item2.ToUeRotator();
			tmpResult.SquaredOffsetLength = bestTransformHorizontal.Item3;
		}
		else
		{
			ValueTuple<Vector, Rotator, float> bestTransformNotHorizontal = this.GetBestTransformNotHorizontal(halfHeight, radius);
			tmpResult.Location = bestTransformNotHorizontal.Item1.ToUeVectorOld();
			tmpResult.Rotator = bestTransformNotHorizontal.Item2.ToUeRotator();
			tmpResult.SquaredOffsetLength = bestTransformNotHorizontal.Item3;
		}
		this.LineTrace.WorldContextObject = actor;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.LineTrace, this.ActorLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.LineTrace, tmpResult.Location);
		tmpResult.Success = !Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "TsSimpleInteractPlane_GetBestTransform");
		return tmpResult;
	}

	// Token: 0x0601ADB4 RID: 110004 RVA: 0x00802F2C File Offset: 0x0080112C
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private ValueTuple<Vector, Rotator, float> GetBestTransformHorizontal(float halfHeight, float radius)
	{
		double num = this.SelfRight.DotProduct(this.SelfToActor);
		double num2 = this.SelfUp.DotProduct(this.SelfToActor);
		double num3 = num + this.SelfRight.DotProduct(this.MoveOffset);
		double num4 = num2 + this.SelfUp.DotProduct(this.MoveOffset);
		double num5 = Math.Abs(num3);
		double num6 = Math.Abs(num4);
		float planeHalfWidth = this.PlaneHalfWidth;
		float planeHalfHeight = this.PlaneHalfHeight;
		if (num5 < (double)planeHalfWidth && num6 < (double)planeHalfHeight)
		{
			this.ActorLocation.Addition(this.MoveOffset, this.TmpResultLocation);
			double num7 = this.SelfLocation.Z + this.SelfForward.X * (double)radius;
			double num8 = num7 - this.TmpResultLocation.Z;
			this.TmpResultLocation.Z = num7;
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.SelfBackward, this.MoveOffset, this.TmpResultRotator);
			return new ValueTuple<Vector, Rotator, float>(this.TmpResultLocation, this.TmpResultRotator, (float)(num8 * num8));
		}
		double num9 = Math.Abs(num);
		double num10 = Math.Abs(num2);
		double num11 = Singleton<MathUtils>.Instance.Square(num9 + (double)planeHalfWidth) + Singleton<MathUtils>.Instance.Square(num10 + (double)planeHalfHeight);
		double num12 = this.MoveOffset.SizeSquared2D();
		if (num11 <= num12)
		{
			this.TmpResultLocation.X = (double)radius;
			this.TmpResultLocation.Y = (double)((num3 > 0.0) ? (-(double)planeHalfWidth) : planeHalfWidth);
			this.TmpResultLocation.Z = (double)((num4 > 0.0) ? (-(double)planeHalfHeight) : planeHalfHeight);
			this.SelfTransform.TransformPositionNoScale(this.TmpResultLocation, this.TmpResultLocation);
			this.TmpResultLocation.Subtraction(this.ActorLocation, this.TmpVector1);
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.SelfBackward, this.TmpVector1, this.TmpResultRotator);
			double num13 = Singleton<MathUtils>.Instance.Square(this.TmpResultLocation.Z - (this.ActorLocation.Z + this.MoveOffset.Z)) + Singleton<MathUtils>.Instance.Square((double)((float)Math.Sqrt(num12) - (float)Math.Sqrt(num11)));
			return new ValueTuple<Vector, Rotator, float>(this.TmpResultLocation, this.TmpResultRotator, (float)num13);
		}
		if (this.FindHitMatrixAndCircle((double)planeHalfWidth, (double)planeHalfHeight, num, num2, num12, num3, num4))
		{
			this.TmpResultLocation.X = (double)radius;
			this.TmpResultLocation.Subtraction(this.ActorLocation, this.TmpVector1);
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.SelfBackward, this.TmpVector1, this.TmpResultRotator);
			double num14 = Singleton<MathUtils>.Instance.Square(this.TmpResultLocation.Z - (this.ActorLocation.Z + this.MoveOffset.Z));
			return new ValueTuple<Vector, Rotator, float>(this.TmpResultLocation, this.TmpResultRotator, (float)num14);
		}
		this.TmpResultLocation.X = (double)radius;
		this.TmpResultLocation.Y = (double)((num3 > 0.0) ? planeHalfWidth : (-(double)planeHalfWidth));
		this.TmpResultLocation.Z = (double)((num4 > 0.0) ? planeHalfHeight : (-(double)planeHalfHeight));
		this.SelfTransform.TransformPositionNoScale(this.TmpResultLocation, this.TmpResultLocation);
		this.TmpResultLocation.Subtraction(this.ActorLocation, this.TmpVector1);
		Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.SelfBackward, this.TmpVector1, this.TmpResultRotator);
		num11 = Singleton<MathUtils>.Instance.Square(num9 - (double)planeHalfWidth) + Singleton<MathUtils>.Instance.Square(num10 - (double)planeHalfHeight);
		double num15 = Singleton<MathUtils>.Instance.Square(this.TmpResultLocation.Z - (this.ActorLocation.Z + this.MoveOffset.Z)) + num12 + num11 - (double)(2f * (float)Math.Sqrt(num12 * num11));
		return new ValueTuple<Vector, Rotator, float>(this.TmpResultLocation, this.TmpResultRotator, (float)num15);
	}

	// Token: 0x0601ADB5 RID: 110005 RVA: 0x0080332C File Offset: 0x0080152C
	private bool FindHitMatrixAndCircle(double validHalfWidth, double validHalfHeight, double yActor, double zActor, double moveOffsetSizeSquared2D, double yMoveTarget, double zMoveTarget)
	{
		double num = moveOffsetSizeSquared2D * 10.0;
		for (int i = 0; i < 2; i++)
		{
			double num2 = (i == 0) ? validHalfWidth : (-validHalfWidth);
			double num3 = moveOffsetSizeSquared2D - Singleton<MathUtils>.Instance.Square(yActor - num2);
			if (num3 > 0.0)
			{
				double num4 = Math.Sqrt(num3);
				double num5 = zActor - num4;
				if (Math.Abs(num5) < validHalfHeight)
				{
					double num6 = Singleton<MathUtils>.Instance.Square(num2 - yMoveTarget) + Singleton<MathUtils>.Instance.Square(num5 - zMoveTarget);
					if (num6 < num)
					{
						num = num6;
						this.TmpResultLocation.Y = num2;
						this.TmpResultLocation.Z = num5;
					}
				}
				num5 = zActor + num4;
				if (Math.Abs(num5) < validHalfHeight)
				{
					double num7 = Singleton<MathUtils>.Instance.Square(num2 - yMoveTarget) + Singleton<MathUtils>.Instance.Square(num5 - zMoveTarget);
					if (num7 < num)
					{
						num = num7;
						this.TmpResultLocation.Y = num2;
						this.TmpResultLocation.Z = num5;
					}
				}
			}
		}
		for (int j = 0; j < 2; j++)
		{
			double num8 = (j == 0) ? validHalfHeight : (-validHalfHeight);
			double num9 = moveOffsetSizeSquared2D - Singleton<MathUtils>.Instance.Square(zActor - num8);
			if (num9 > 0.0)
			{
				float num10 = (float)Math.Sqrt(num9);
				double num11 = yActor - (double)num10;
				if (Math.Abs(yActor) < validHalfWidth)
				{
					double num12 = Singleton<MathUtils>.Instance.Square(num11 - yMoveTarget) + Singleton<MathUtils>.Instance.Square(num8 - zMoveTarget);
					if (num12 < num)
					{
						num = (double)((float)num12);
						this.TmpResultLocation.Y = num11;
						this.TmpResultLocation.Z = num8;
					}
				}
				num11 = yActor + (double)num10;
				if (Math.Abs(num11) < validHalfHeight)
				{
					double num13 = Singleton<MathUtils>.Instance.Square(num11 - yMoveTarget) + Singleton<MathUtils>.Instance.Square(num8 - zMoveTarget);
					if (num13 < num)
					{
						num = (double)((float)num13);
						this.TmpResultLocation.Y = num11;
						this.TmpResultLocation.Z = num8;
					}
				}
			}
		}
		return num < moveOffsetSizeSquared2D * 10.0;
	}

	// Token: 0x0601ADB6 RID: 110006 RVA: 0x00803538 File Offset: 0x00801738
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private ValueTuple<Vector, Rotator, float> GetBestTransformNotHorizontal(float halfHeight, float radius)
	{
		this.TmpVector1.DeepCopy(this.SelfToActor);
		this.TmpVector1.Z += this.MoveOffset.Z;
		double num = this.SelfForward.DotProduct(this.TmpVector1);
		double num2 = Singleton<MathUtils>.Instance.Square(num - (double)radius) / (double)this.ForwardSizeSquared2D;
		double num3 = this.MoveOffset.SizeSquared2D();
		float planeHalfWidth = this.PlaneHalfWidth;
		float planeHalfHeight = this.PlaneHalfHeight;
		if (num2 >= num3)
		{
			this.TmpVector2.DeepCopy(this.Forward2D);
			this.TmpVector2.MultiplyEqual((double)((float)Math.Sqrt(num3)));
			this.TmpVector1.SubtractionEqual(this.TmpVector2);
			this.TmpResultLocation.X = (double)radius;
			this.TmpResultLocation.Y = Singleton<MathUtils>.Instance.Clamp(this.SelfRight.DotProduct(this.TmpVector1), (double)(-(double)planeHalfWidth), (double)planeHalfWidth);
			this.TmpResultLocation.Z = Singleton<MathUtils>.Instance.Clamp(this.SelfUp.DotProduct(this.TmpVector1), (double)(-(double)planeHalfHeight), (double)planeHalfHeight);
			this.SelfTransform.TransformPositionNoScale(this.TmpResultLocation, this.TmpResultLocation);
			this.TmpResultLocation.Subtraction(this.ActorLocation, this.TmpVector1);
			return new ValueTuple<Vector, Rotator, float>(this.TmpResultLocation, this.NormalRotator, (float)(Singleton<MathUtils>.Instance.Square(this.TmpVector1.Size2D() - (double)((float)Math.Sqrt(num3))) + Singleton<MathUtils>.Instance.Square(this.TmpVector1.Z - this.MoveOffset.Z)));
		}
		Vector.UpVectorProxy.CrossProduct(this.SelfForward, this.TmpVector1);
		Vector.UpVectorProxy.CrossProduct(this.TmpVector1, this.TmpVector2);
		this.TmpVector2.MultiplyEqual((double)((float)Math.Sign(num - (double)radius) * (float)Math.Sqrt(num2 / this.TmpVector2.SizeSquared())));
		this.TmpVector2.AdditionEqual(this.ActorLocation);
		this.TmpVector2.Z += this.MoveOffset.Z;
		this.TmpVector1.MultiplyEqual((double)((float)Math.Sqrt((num3 - num2) / this.TmpVector1.SizeSquared())));
		this.TmpVector2.Addition(this.TmpVector1, this.TmpVector3);
		this.SelfTransform.InverseTransformPositionNoScale(this.TmpVector3, this.TmpVector3);
		double num4 = Singleton<MathUtils>.Instance.Square(Math.Max(0.0, Math.Abs(this.TmpVector3.Y) - (double)planeHalfWidth)) + Singleton<MathUtils>.Instance.Square(Math.Max(0.0, Math.Abs(this.TmpVector3.Z) - (double)planeHalfHeight));
		this.TmpVector3.Y = (double)Math.Sign(this.TmpVector3.Y) * Math.Min(Math.Abs(this.TmpVector3.Y), (double)planeHalfWidth);
		this.TmpVector3.Z = (double)Math.Sign(this.TmpVector3.Z) * Math.Min(Math.Abs(this.TmpVector3.Z), (double)planeHalfHeight);
		this.TmpVector2.Subtraction(this.TmpVector1, this.TmpVector4);
		this.SelfTransform.InverseTransformPositionNoScale(this.TmpVector4, this.TmpVector4);
		double num5 = Singleton<MathUtils>.Instance.Square(Math.Max(0.0, Math.Abs(this.TmpVector4.Y) - (double)planeHalfWidth)) + Singleton<MathUtils>.Instance.Square(Math.Max(0.0, Math.Abs(this.TmpVector4.Z) - (double)planeHalfHeight));
		if (num4 > num5 || (Math.Abs(num4 - num5) < 0.10000000149011612 && UKismetMathLibrary.RandomFloat() >= 0.5f))
		{
			num4 = num5;
			this.TmpVector4.Y = (double)Math.Sign(this.TmpVector4.Y) * Math.Min(Math.Abs(this.TmpVector4.Y), (double)planeHalfWidth);
			this.TmpVector4.Z = (double)Math.Sign(this.TmpVector4.Z) * Math.Min(Math.Abs(this.TmpVector4.Z), (double)planeHalfHeight);
			this.SelfTransform.InverseTransformPositionNoScale(this.TmpVector4, this.TmpResultLocation);
		}
		else
		{
			this.TmpVector3.Y = (double)Math.Sign(this.TmpVector3.Y) * Math.Min(Math.Abs(this.TmpVector3.Y), (double)planeHalfWidth);
			this.TmpVector3.Z = (double)Math.Sign(this.TmpVector3.Z) * Math.Min(Math.Abs(this.TmpVector3.Z), (double)planeHalfHeight);
			this.SelfTransform.InverseTransformPositionNoScale(this.TmpVector3, this.TmpResultLocation);
		}
		return new ValueTuple<Vector, Rotator, float>(this.TmpResultLocation, this.NormalRotator, (float)num4);
	}

	// Token: 0x0601ADB7 RID: 110007 RVA: 0x00803A49 File Offset: 0x00801C49
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSimpleInteractPlane._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractPlane.TsSimpleInteractPlane_C");
		}
		return TsSimpleInteractPlane._ClassPtr;
	}

	// Token: 0x0601ADB8 RID: 110008 RVA: 0x00803A70 File Offset: 0x00801C70
	public TsSimpleInteractPlane() : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractPlane.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601ADB9 RID: 110009 RVA: 0x00803A98 File Offset: 0x00801C98
	[NullableContext(1)]
	public TsSimpleInteractPlane(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractPlane.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601ADBA RID: 110010 RVA: 0x00803ACB File Offset: 0x00801CCB
	protected TsSimpleInteractPlane(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400D9D9 RID: 55769
	private static readonly FLinearColor RedColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x0400D9DA RID: 55770
	private static readonly FLinearColor YellowColor = new FLinearColor(1f, 1f, 0f, 1f);

	// Token: 0x0400D9DB RID: 55771
	private static readonly FLinearColor GreenColor = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x0400D9DC RID: 55772
	private const float DRAW_TIME = 0.05f;

	// Token: 0x0400D9DD RID: 55773
	private const float DEFAULT_THICKNESS = 4f;

	// Token: 0x0400D9DE RID: 55774
	private const float DEFAULT_ARROW_SIZE = 100f;

	// Token: 0x0400D9DF RID: 55775
	private const float DRAW_LENGTH = 200f;

	// Token: 0x0400D9E0 RID: 55776
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Vector ForwardOffset = Vector.Create(200.0, 0.0, 0.0);

	// Token: 0x0400D9E1 RID: 55777
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly FVector[] DrawPoints = new FVector[]
	{
		new FVector(0f, -1f, -1f),
		new FVector(0f, -1f, 1f),
		new FVector(0f, 1f, -1f),
		new FVector(0f, 1f, 1f)
	};

	// Token: 0x0400D9E2 RID: 55778
	private static readonly FColor TextColor = new FColor(byte.MaxValue, 128, 128, byte.MaxValue);

	// Token: 0x0400D9E3 RID: 55779
	private const float TEXT_SIZE = 200f;

	// Token: 0x0400D9E4 RID: 55780
	private const float LEGAL_CHECK_PERIOD = 100f;

	// Token: 0x0400D9E5 RID: 55781
	private const float SMALL_VALUE = 0.1f;

	// Token: 0x0400D9E6 RID: 55782
	[Nullable(1)]
	private const string PROFILE_KEY_CEHCK_LEGAL = "TsSimpleInteractPlane_CheckLegal";

	// Token: 0x0400D9E7 RID: 55783
	[Nullable(1)]
	private const string PROFILE_KEY = "TsSimpleInteractPlane_GetBestTransform";

	// Token: 0x0400D9E8 RID: 55784
	private Vector SelfForward;

	// Token: 0x0400D9E9 RID: 55785
	private Vector SelfBackward;

	// Token: 0x0400D9EA RID: 55786
	private Vector SelfRight;

	// Token: 0x0400D9EB RID: 55787
	private Vector SelfUp;

	// Token: 0x0400D9EC RID: 55788
	private readonly bool IsHorizontalPlane;

	// Token: 0x0400D9ED RID: 55789
	private Vector TmpResultLocation;

	// Token: 0x0400D9EE RID: 55790
	private Rotator TmpResultRotator;

	// Token: 0x0400D9EF RID: 55791
	private float ForwardSizeSquared2D;

	// Token: 0x0400D9F0 RID: 55792
	private Vector Forward2D;

	// Token: 0x0400D9F1 RID: 55793
	private Rotator NormalRotator;

	// Token: 0x0400D9F2 RID: 55794
	private Vector TmpLocation;

	// Token: 0x0400D9F3 RID: 55795
	private Vector StartLocation;

	// Token: 0x0400D9F4 RID: 55796
	private Vector EndLocation;

	// Token: 0x0400D9F5 RID: 55797
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/SimpleBlueprintItem/TsSimpleInteractPlane.TsSimpleInteractPlane_C";

	// Token: 0x0400D9F6 RID: 55798
	private static IntPtr _ClassPtr;

	// Token: 0x0400D9F7 RID: 55799
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400D9F8 RID: 55800
	private static int __PropertyOffset_PlaneHalfHeight;

	// Token: 0x0400D9F9 RID: 55801
	private static int __PropertyOffset_PlaneHalfWidth;
}
