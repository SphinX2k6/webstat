using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030C9 RID: 12489
[NullableContext(1)]
[Nullable(0)]
public class BigJumpUnit
{
	// Token: 0x06019C10 RID: 105488 RVA: 0x00780698 File Offset: 0x0077E898
	public Rotator GetEndRotator()
	{
		return this.EndRotator;
	}

	// Token: 0x06019C11 RID: 105489 RVA: 0x007806A0 File Offset: 0x0077E8A0
	public void SetAll(float time1, Vector startPoint, Vector middlePoint, Vector endPoint, string curvePath = "", float gravity2 = 1960f, [Nullable(2)] Rotator endRotator = null, [Nullable(2)] Vector gravityDirect = null, string rotatorCurve = "", [Nullable(2)] Quat startQuat = null)
	{
		this.TimeLength1 = time1;
		this.StartPoint.DeepCopy(startPoint);
		this.MiddlePoint.DeepCopy(middlePoint);
		this.EndPoint.DeepCopy(endPoint);
		this.Curve = (string.IsNullOrEmpty(curvePath) ? null : Singleton<ResourceSystem>.Instance.Load<UCurveFloat>(curvePath, "js_undefined"));
		if (startQuat != null)
		{
			this.StartQuat.DeepCopy(startQuat);
			this.GotStartQuat = true;
		}
		else
		{
			this.GotStartQuat = true;
		}
		if (endRotator != null)
		{
			this.EndRotator.DeepCopy(endRotator);
			this.GotEndQuat = true;
			this.EndRotator.Quaternion(this.EndQuat);
			if (!this.GotStartQuat)
			{
				this.StartQuat.DeepCopy(this.EndQuat);
			}
		}
		else
		{
			this.GotEndQuat = false;
		}
		this.RotatorCurve = (string.IsNullOrEmpty(rotatorCurve) ? null : Singleton<ResourceSystem>.Instance.Load<UCurveFloat>(rotatorCurve, "js_undefined"));
		this.Gravity2 = gravity2;
		this.GravityDirect.DeepCopy(gravityDirect ?? Vector.DownVectorProxy);
	}

	// Token: 0x06019C12 RID: 105490 RVA: 0x007807AA File Offset: 0x0077E9AA
	public void SetStartPoint(Vector startPoint)
	{
		this.StartPoint.DeepCopy(startPoint);
	}

	// Token: 0x06019C13 RID: 105491 RVA: 0x007807B8 File Offset: 0x0077E9B8
	public void Init()
	{
		this.EndPoint.Subtraction(this.MiddlePoint, BigJumpUnit.TmpVector);
		if (this.Gravity2 > 0f && Singleton<GravityUtils>.Instance.GetZnInGravity(this.GravityDirect, BigJumpUnit.TmpVector) < -1E-08)
		{
			this.EndPoint.Subtraction(this.StartPoint, BigJumpUnit.TmpVector);
			if (!this.GotEndQuat)
			{
				this.GravityDirect.UnaryNegation(BigJumpUnit.TmpVector2);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(BigJumpUnit.TmpVector, BigJumpUnit.TmpVector2, this.EndQuat);
				this.EndQuat.Rotator(this.EndRotator);
			}
			this.MiddlePoint.Subtraction(this.StartPoint, BigJumpUnit.TmpVector2);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForDirect(this.GravityDirect, BigJumpUnit.TmpVector);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForDirect(this.GravityDirect, BigJumpUnit.TmpVector2);
			BigJumpUnit.TmpVector.Normalize(9.99999993922529E-09);
			BigJumpUnit.TmpVector.MultiplyEqual(BigJumpUnit.TmpVector2.DotProduct(BigJumpUnit.TmpVector));
			BigJumpUnit.TmpVector.AdditionEqual(this.StartPoint);
			double znInGravityForDirect = Singleton<GravityUtils>.Instance.GetZnInGravityForDirect(this.GravityDirect, this.MiddlePoint);
			this.MiddlePoint.DeepCopy(BigJumpUnit.TmpVector);
			Singleton<GravityUtils>.Instance.SetZnInGravity(this.GravityDirect, this.MiddlePoint, znInGravityForDirect);
			double znInGravityForDirect2 = Singleton<GravityUtils>.Instance.GetZnInGravityForDirect(this.GravityDirect, this.EndPoint);
			this.TimeLength2 = (float)Math.Sqrt((znInGravityForDirect - znInGravityForDirect2) * 2.0 / (double)this.Gravity2);
			this.EndPoint.Subtraction(this.MiddlePoint, BigJumpUnit.TmpVector);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForDirect(this.GravityDirect, BigJumpUnit.TmpVector);
			BigJumpUnit.TmpVector.Division((double)this.TimeLength2, this.Speed2);
			this.MiddlePoint.Subtraction(this.StartPoint, BigJumpUnit.TmpVector);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForDirect(this.GravityDirect, BigJumpUnit.TmpVector);
			BigJumpUnit.TmpVector.DivisionEqual((double)this.TimeLength1);
			BigJumpUnit.TmpVector.MultiplyEqual(2.0);
			BigJumpUnit.TmpVector.Subtraction(this.Speed2, this.Speed1);
		}
		else
		{
			this.MiddlePoint.Subtraction(this.StartPoint, BigJumpUnit.TmpVector);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForDirect(this.GravityDirect, BigJumpUnit.TmpVector);
			BigJumpUnit.TmpVector.DivisionEqual((double)this.TimeLength1);
			this.Speed1.DeepCopy(BigJumpUnit.TmpVector);
			this.Speed2.DeepCopy(this.Speed1);
			this.TimeLength2 = 0f;
		}
		if (!this.GotStartQuat)
		{
			this.StartQuat.DeepCopy(this.EndQuat);
		}
	}

	// Token: 0x06019C14 RID: 105492 RVA: 0x00780A98 File Offset: 0x0077EC98
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 8);
		defaultInterpolatedStringHandler.AppendLiteral("TimeLength: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.TimeLength1);
		defaultInterpolatedStringHandler.AppendLiteral(" + ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.TimeLength2);
		defaultInterpolatedStringHandler.AppendLiteral(", Points: ");
		defaultInterpolatedStringHandler.AppendFormatted(this.StartPoint.ToString());
		defaultInterpolatedStringHandler.AppendLiteral(", ");
		defaultInterpolatedStringHandler.AppendFormatted(this.MiddlePoint.ToString());
		defaultInterpolatedStringHandler.AppendLiteral(", ");
		defaultInterpolatedStringHandler.AppendFormatted(this.EndPoint.ToString());
		defaultInterpolatedStringHandler.AppendLiteral("\n  Gravity2: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Gravity2);
		defaultInterpolatedStringHandler.AppendLiteral(", Speeds: ");
		defaultInterpolatedStringHandler.AppendFormatted(this.Speed1.ToString());
		defaultInterpolatedStringHandler.AppendLiteral(", ");
		defaultInterpolatedStringHandler.AppendFormatted(this.Speed2.ToString());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x170022B6 RID: 8886
	// (get) Token: 0x06019C15 RID: 105493 RVA: 0x00780B97 File Offset: 0x0077ED97
	public float RisingTime
	{
		get
		{
			return this.TimeLength1;
		}
	}

	// Token: 0x170022B7 RID: 8887
	// (get) Token: 0x06019C16 RID: 105494 RVA: 0x00780B9F File Offset: 0x0077ED9F
	public float TimeLength
	{
		get
		{
			return this.TimeLength1 + this.TimeLength2;
		}
	}

	// Token: 0x06019C17 RID: 105495 RVA: 0x00780BB0 File Offset: 0x0077EDB0
	public void GetLocation(float time, Vector output)
	{
		if (time < this.TimeLength1)
		{
			Vector.Lerp(this.Speed1, this.Speed2, (double)(time / this.TimeLength1), output);
			output.AdditionEqual(this.Speed1);
			output.MultiplyEqual((double)(time / 2f));
			output.AdditionEqual(this.StartPoint);
			float num = (this.Curve != null) ? this.Curve.GetFloatValue(time / this.TimeLength1) : CurveUtils.DefaultPara.GetCurrentValue(time / this.TimeLength1);
			double znInGravityForDirect = Singleton<GravityUtils>.Instance.GetZnInGravityForDirect(this.GravityDirect, this.StartPoint);
			double znInGravityForDirect2 = Singleton<GravityUtils>.Instance.GetZnInGravityForDirect(this.GravityDirect, this.MiddlePoint);
			Singleton<GravityUtils>.Instance.SetZnInGravity(this.GravityDirect, output, Singleton<MathUtils>.Instance.Lerp(znInGravityForDirect, znInGravityForDirect2, (double)num));
			return;
		}
		float num2 = time - this.TimeLength1;
		this.Speed2.Multiply((double)num2, output);
		Singleton<GravityUtils>.Instance.SetZnInGravity(this.GravityDirect, output, (double)(-(double)(this.Gravity2 * num2 * num2) / 2f));
		output.AdditionEqual(this.MiddlePoint);
	}

	// Token: 0x06019C18 RID: 105496 RVA: 0x00780CD3 File Offset: 0x0077EED3
	public void GetOffset(float time, float deltaTime, Vector output)
	{
		this.GetLocation(time, BigJumpUnit.TmpVector);
		this.GetLocation(time + deltaTime, output);
		output.SubtractionEqual(BigJumpUnit.TmpVector);
	}

	// Token: 0x06019C19 RID: 105497 RVA: 0x00780CF8 File Offset: 0x0077EEF8
	public void GetSpeed(float time, Vector output)
	{
		if (time < this.TimeLength1)
		{
			Vector.Lerp(this.Speed1, this.Speed2, (double)(time / this.TimeLength1), output);
			output.AdditionEqual(this.Speed1);
			output.MultiplyEqual(0.5);
			return;
		}
		output.DeepCopy(this.Speed2);
		float num = time - this.TimeLength1;
		Singleton<GravityUtils>.Instance.SetZnInGravity(this.GravityDirect, output, (double)(-(double)this.Gravity2 * num));
	}

	// Token: 0x06019C1A RID: 105498 RVA: 0x00780D78 File Offset: 0x0077EF78
	public void GetQuat(float time, Quat @out)
	{
		float num = time / this.TimeLength;
		if (this.RotatorCurve != null)
		{
			num = this.RotatorCurve.GetFloatValue(num);
		}
		Quat.Slerp(this.StartQuat, this.EndQuat, num, @out);
	}

	// Token: 0x06019C1B RID: 105499 RVA: 0x00780DB8 File Offset: 0x0077EFB8
	public void GetQuatOffset(float time, float deltaTime, Quat @out)
	{
		if (!this.GotEndQuat)
		{
			@out.DeepCopy(Quat.Identity);
			return;
		}
		this.GetQuat(time, BigJumpUnit.TmpQuat);
		BigJumpUnit.TmpQuat.Inverse(BigJumpUnit.TmpQuat2);
		this.GetQuat(time + deltaTime, BigJumpUnit.TmpQuat);
		BigJumpUnit.TmpQuat.Multiply(BigJumpUnit.TmpQuat2, @out);
	}

	// Token: 0x0400CD6D RID: 52589
	public const float DEFAULT_GRAVITY = 1960f;

	// Token: 0x0400CD6E RID: 52590
	private float TimeLength1;

	// Token: 0x0400CD6F RID: 52591
	private float TimeLength2;

	// Token: 0x0400CD70 RID: 52592
	private readonly Vector StartPoint = Vector.Create();

	// Token: 0x0400CD71 RID: 52593
	private readonly Vector MiddlePoint = Vector.Create();

	// Token: 0x0400CD72 RID: 52594
	private readonly Vector EndPoint = Vector.Create();

	// Token: 0x0400CD73 RID: 52595
	[Nullable(2)]
	private UCurveFloat Curve;

	// Token: 0x0400CD74 RID: 52596
	private float Gravity2;

	// Token: 0x0400CD75 RID: 52597
	private Vector GravityDirect = Vector.Create(0.0, 0.0, -1.0);

	// Token: 0x0400CD76 RID: 52598
	private readonly Vector Speed1 = Vector.Create();

	// Token: 0x0400CD77 RID: 52599
	private readonly Vector Speed2 = Vector.Create();

	// Token: 0x0400CD78 RID: 52600
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400CD79 RID: 52601
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x0400CD7A RID: 52602
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400CD7B RID: 52603
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400CD7C RID: 52604
	private bool GotStartQuat;

	// Token: 0x0400CD7D RID: 52605
	private bool GotEndQuat;

	// Token: 0x0400CD7E RID: 52606
	private readonly Quat StartQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400CD7F RID: 52607
	private readonly Quat EndQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400CD80 RID: 52608
	private readonly Rotator EndRotator = Rotator.Create();

	// Token: 0x0400CD81 RID: 52609
	[Nullable(2)]
	private UCurveFloat RotatorCurve;
}
