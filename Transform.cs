using System;
using System.Runtime.CompilerServices;
using Aki.Common.Common;
using UnrealEngine;
using UnrealEngine.Bulitin.Utils;
using UnrealEngine.Extension;

// Token: 0x02000C1B RID: 3099
[NullableContext(1)]
[Nullable(0)]
public class Transform : ITransform, IClearable, ILogFormattedPrint
{
	// Token: 0x06003482 RID: 13442 RVA: 0x0002DD1B File Offset: 0x0002BF1B
	private Transform()
	{
	}

	// Token: 0x06003483 RID: 13443 RVA: 0x0002DD24 File Offset: 0x0002BF24
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 3);
		defaultInterpolatedStringHandler.AppendLiteral("Translation=");
		defaultInterpolatedStringHandler.AppendFormatted<Vector>(this.Translation);
		defaultInterpolatedStringHandler.AppendLiteral(", Rotation=");
		defaultInterpolatedStringHandler.AppendFormatted<Quat>(this.Rotation);
		defaultInterpolatedStringHandler.AppendLiteral(", Scale3D=");
		defaultInterpolatedStringHandler.AppendFormatted<Vector>(this.Scale3D);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06003484 RID: 13444 RVA: 0x0002DD8D File Offset: 0x0002BF8D
	public string ToFormattedString()
	{
		return this.ToString();
	}

	// Token: 0x06003485 RID: 13445 RVA: 0x0002DD98 File Offset: 0x0002BF98
	public void ToFormattedString(UnsafeStringBuilder sb)
	{
		UnsafeStringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new UnsafeStringBuilder.AppendInterpolatedStringHandler(33, 3, sb);
		appendInterpolatedStringHandler.AppendLiteral("Translation=");
		appendInterpolatedStringHandler.AppendFormatted<Vector>(this.Translation);
		appendInterpolatedStringHandler.AppendLiteral(", Rotation=");
		appendInterpolatedStringHandler.AppendFormatted<Quat>(this.Rotation);
		appendInterpolatedStringHandler.AppendLiteral(", Scale3D=");
		appendInterpolatedStringHandler.AppendFormatted<Vector>(this.Scale3D);
		sb.Append(ref appendInterpolatedStringHandler);
	}

	// Token: 0x06003486 RID: 13446 RVA: 0x0002DE08 File Offset: 0x0002C008
	public static Transform Create([Nullable(2)] ITransform inT)
	{
		Transform transform = new Transform();
		if (inT != null)
		{
			transform.Rotation = Quat.Create(inT.GetRotation());
			transform.Translation = Vector.Create(inT.GetLocation());
			transform.Scale3D = Vector.Create(inT.GetScale3D());
		}
		else
		{
			transform.Rotation = Quat.Create(0f, 0f, 0f, 1f);
			transform.Translation = Vector.Create();
			transform.Scale3D = Vector.Create(1.0, 1.0, 1.0);
		}
		return transform;
	}

	// Token: 0x06003487 RID: 13447 RVA: 0x0002DEA4 File Offset: 0x0002C0A4
	public static Transform Create(IQuat inR, IVector inT, IVector inS)
	{
		return new Transform
		{
			Rotation = Quat.Create(inR),
			Translation = Vector.Create(inT),
			Scale3D = Vector.Create(inS)
		};
	}

	// Token: 0x06003488 RID: 13448 RVA: 0x0002DED0 File Offset: 0x0002C0D0
	public static Transform Create()
	{
		return new Transform
		{
			Rotation = Quat.Create(0f, 0f, 0f, 1f),
			Translation = Vector.Create(),
			Scale3D = Vector.Create(1.0, 1.0, 1.0)
		};
	}

	// Token: 0x06003489 RID: 13449 RVA: 0x0002DF34 File Offset: 0x0002C134
	public void FromUeTransform(in FTransform inT)
	{
		this.Rotation.FromUeQuat(inT.GetRotation());
		Vector translation = this.Translation;
		FVector fvector = inT.GetTranslation();
		translation.FromUeVector(fvector);
		Vector scale3D = this.Scale3D;
		fvector = inT.GetScale3D();
		scale3D.FromUeVector(fvector);
	}

	// Token: 0x0600348A RID: 13450 RVA: 0x0002DF7C File Offset: 0x0002C17C
	public void FromUeTransform(in FTransformDouble inT)
	{
		this.Rotation.FromUeQuat(inT.GetRotation());
		Vector translation = this.Translation;
		FVectorDouble translation2 = inT.GetTranslation();
		translation.FromUeVector(translation2);
		Vector scale3D = this.Scale3D;
		FVector scale3D2 = inT.GetScale3D();
		scale3D.FromUeVector(scale3D2);
	}

	// Token: 0x0600348B RID: 13451 RVA: 0x0002DFC4 File Offset: 0x0002C1C4
	public FTransform ToUeTransformOld()
	{
		FQuat fquat = this.Rotation.ToUeQuat();
		FVector fvector = this.Translation.ToUeVectorOld();
		FVector fvector2 = this.Scale3D.ToUeVectorOld();
		return new FTransform(ref fquat, ref fvector, ref fvector2);
	}

	// Token: 0x0600348C RID: 13452 RVA: 0x0002E000 File Offset: 0x0002C200
	public FTransformDouble ToUeTransform()
	{
		FQuat fquat = this.Rotation.ToUeQuat();
		FVectorDouble fvectorDouble = this.Translation.ToUeVector(false);
		FVectorDouble fvectorDouble2 = this.Scale3D.ToUeVector(false);
		FVector fvector = fvectorDouble2;
		return new FTransformDouble(ref fquat, ref fvectorDouble, ref fvector);
	}

	// Token: 0x0600348D RID: 13453 RVA: 0x0002E048 File Offset: 0x0002C248
	public void Set(IVector location, IQuat rotation, IVector scale)
	{
		this.Translation.Set(location.X, location.Y, location.Z);
		this.Rotation.Set(rotation.X, rotation.Y, rotation.Z, rotation.W);
		this.Scale3D.Set(scale.X, scale.Y, scale.Z);
	}

	// Token: 0x0600348E RID: 13454 RVA: 0x0002E0B2 File Offset: 0x0002C2B2
	public void SetLocation(IVector origin)
	{
		this.Translation.Set(origin.X, origin.Y, origin.Z);
	}

	// Token: 0x0600348F RID: 13455 RVA: 0x0002E0D1 File Offset: 0x0002C2D1
	void ITransform.SetLocation(IVector value)
	{
		this.Translation.Set(value.X, value.Y, value.Z);
	}

	// Token: 0x06003490 RID: 13456 RVA: 0x0002E0F0 File Offset: 0x0002C2F0
	public Vector GetLocation()
	{
		return this.Translation;
	}

	// Token: 0x06003491 RID: 13457 RVA: 0x0002E0F8 File Offset: 0x0002C2F8
	IVector ITransform.GetLocation()
	{
		return this.Translation;
	}

	// Token: 0x06003492 RID: 13458 RVA: 0x0002E100 File Offset: 0x0002C300
	public void SetRotation(IQuat origin)
	{
		this.Rotation.Set(origin.X, origin.Y, origin.Z, origin.W);
	}

	// Token: 0x06003493 RID: 13459 RVA: 0x0002E125 File Offset: 0x0002C325
	void ITransform.SetRotation(IQuat origin)
	{
		this.Rotation.Set(origin.X, origin.Y, origin.Z, origin.W);
	}

	// Token: 0x06003494 RID: 13460 RVA: 0x0002E14A File Offset: 0x0002C34A
	public Quat GetRotation()
	{
		return this.Rotation;
	}

	// Token: 0x06003495 RID: 13461 RVA: 0x0002E152 File Offset: 0x0002C352
	IQuat ITransform.GetRotation()
	{
		return this.Rotation;
	}

	// Token: 0x06003496 RID: 13462 RVA: 0x0002E15A File Offset: 0x0002C35A
	public void SetScale3D(IVector origin)
	{
		this.Scale3D.Set(origin.X, origin.Y, origin.Z);
	}

	// Token: 0x06003497 RID: 13463 RVA: 0x0002E179 File Offset: 0x0002C379
	void ITransform.SetScale3D(IVector origin)
	{
		this.Scale3D.Set(origin.X, origin.Y, origin.Z);
	}

	// Token: 0x06003498 RID: 13464 RVA: 0x0002E198 File Offset: 0x0002C398
	public Vector GetScale3D()
	{
		return this.Scale3D;
	}

	// Token: 0x06003499 RID: 13465 RVA: 0x0002E1A0 File Offset: 0x0002C3A0
	IVector ITransform.GetScale3D()
	{
		return this.Scale3D;
	}

	// Token: 0x0600349A RID: 13466 RVA: 0x0002E1A8 File Offset: 0x0002C3A8
	public void TransformPosition(Vector v, Vector @out)
	{
		this.Scale3D.Multiply(v, @out);
		this.Rotation.RotateVector(@out, @out);
		this.Translation.Addition(@out, @out);
	}

	// Token: 0x0600349B RID: 13467 RVA: 0x0002E1D3 File Offset: 0x0002C3D3
	public void TransformVector(Vector v, Vector @out)
	{
		this.Scale3D.Multiply(v, @out);
		this.Rotation.RotateVector(@out, @out);
	}

	// Token: 0x0600349C RID: 13468 RVA: 0x0002E1F0 File Offset: 0x0002C3F0
	public void TransformPositionNoScale(Vector v, Vector @out)
	{
		this.Rotation.RotateVector(v, @out);
		this.Translation.Addition(@out, @out);
	}

	// Token: 0x0600349D RID: 13469 RVA: 0x0002E20D File Offset: 0x0002C40D
	public void InverseTransformVector(Vector v, Vector @out)
	{
		this.Rotation.Inverse(Transform.TmpQuat);
		Transform.TmpQuat.RotateVector(v, @out);
		this.Scale3D.Reciprocal(Transform.TmpVec);
		Transform.TmpVec.Multiply(@out, @out);
	}

	// Token: 0x0600349E RID: 13470 RVA: 0x0002E248 File Offset: 0x0002C448
	public void InverseTransformPosition(Vector v, Vector @out)
	{
		v.Subtraction(this.Translation, @out);
		this.Rotation.Inverse(Transform.TmpQuat);
		Transform.TmpQuat.RotateVector(@out, @out);
		this.Scale3D.Reciprocal(Transform.TmpVec);
		Transform.TmpVec.Multiply(@out, @out);
	}

	// Token: 0x0600349F RID: 13471 RVA: 0x0002E29C File Offset: 0x0002C49C
	public void InverseTransformPositionNoScale(Vector v, Vector @out)
	{
		v.Subtraction(this.Translation, @out);
		this.Rotation.Inverse(Transform.TmpQuat);
		Transform.TmpQuat.RotateVector(@out, @out);
	}

	// Token: 0x060034A0 RID: 13472 RVA: 0x0002E2C8 File Offset: 0x0002C4C8
	public void InverseTransformRotation(Quat q, Quat @out)
	{
		this.Rotation.Inverse(@out);
		@out.Multiply(q, @out);
	}

	// Token: 0x060034A1 RID: 13473 RVA: 0x0002E2E0 File Offset: 0x0002C4E0
	public void TransformRotation(Rotator r, Quat @out)
	{
		Quat rotation = this.Rotation;
		Quat inQ = r.Quaternion(null);
		rotation.Multiply(inQ, @out);
	}

	// Token: 0x060034A2 RID: 13474 RVA: 0x0002E304 File Offset: 0x0002C504
	public void TransformRotation(Rotator r, Rotator @out)
	{
		Quat rotation = this.Rotation;
		Quat inQ = r.Quaternion(null);
		rotation.Multiply(inQ, Transform.TmpQuat);
		@out.FromUeRotator(Transform.TmpQuat.Rotator(null));
	}

	// Token: 0x060034A3 RID: 13475 RVA: 0x0002E33C File Offset: 0x0002C53C
	public void ComposeTransforms(Transform target, Transform @out)
	{
		this.Translation.Multiply(target.Scale3D, @out.Translation);
		target.Rotation.RotateVector(@out.Translation, @out.Translation);
		target.Translation.Addition(@out.Translation, @out.Translation);
		this.Scale3D.Multiply(target.Scale3D, @out.Scale3D);
		target.Rotation.Multiply(this.Rotation, @out.Rotation);
	}

	// Token: 0x060034A4 RID: 13476 RVA: 0x0002E3C0 File Offset: 0x0002C5C0
	public void UnComposeTransform(Transform target, Transform @out)
	{
		target.Rotation.Inverse(@out.Rotation);
		@out.Rotation.Multiply(this.Rotation, @out.Rotation);
		this.Scale3D.Division(target.Scale3D, @out.Scale3D);
		this.Translation.Subtraction(target.Translation, @out.Translation);
		target.Rotation.UnRotateVector(@out.Translation, @out.Translation);
		@out.Translation.DivisionEqual(target.Scale3D);
	}

	// Token: 0x060034A5 RID: 13477 RVA: 0x0002E44E File Offset: 0x0002C64E
	public void Reset()
	{
		this.Translation.Reset();
		this.Scale3D.Reset();
		this.Rotation.Reset();
	}

	// Token: 0x060034A6 RID: 13478 RVA: 0x0002E471 File Offset: 0x0002C671
	public void Clear()
	{
		this.Reset();
	}

	// Token: 0x04000639 RID: 1593
	[Nullable(2)]
	private Vector Translation;

	// Token: 0x0400063A RID: 1594
	[Nullable(2)]
	private Quat Rotation;

	// Token: 0x0400063B RID: 1595
	[Nullable(2)]
	private Vector Scale3D;

	// Token: 0x0400063C RID: 1596
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVec = Vector.Create();

	// Token: 0x0400063D RID: 1597
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);
}
