using System;
using System.Runtime.CompilerServices;
using Aki.Common.Common;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Bulitin.Utils;
using UnrealEngine.Extension;

// Token: 0x02000C1A RID: 3098
[NullableContext(1)]
[Nullable(0)]
public class Rotator : IRotator, IClearable, ILogFormattedPrint
{
	// Token: 0x06003455 RID: 13397 RVA: 0x0002D46C File Offset: 0x0002B66C
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 3);
		defaultInterpolatedStringHandler.AppendLiteral("(Pitch = ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Pitch);
		defaultInterpolatedStringHandler.AppendLiteral(", Yaw = ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Yaw);
		defaultInterpolatedStringHandler.AppendLiteral(", Roll = ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Roll);
		defaultInterpolatedStringHandler.AppendLiteral(")");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06003456 RID: 13398 RVA: 0x0002D4E1 File Offset: 0x0002B6E1
	public string ToFormattedString()
	{
		return this.ToString();
	}

	// Token: 0x06003457 RID: 13399 RVA: 0x0002D4EC File Offset: 0x0002B6EC
	public void ToFormattedString(UnsafeStringBuilder sb)
	{
		UnsafeStringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new UnsafeStringBuilder.AppendInterpolatedStringHandler(27, 3, sb);
		appendInterpolatedStringHandler.AppendLiteral("(Pitch = ");
		appendInterpolatedStringHandler.AppendFormatted<float>(this.Pitch);
		appendInterpolatedStringHandler.AppendLiteral(", Yaw = ");
		appendInterpolatedStringHandler.AppendFormatted<float>(this.Yaw);
		appendInterpolatedStringHandler.AppendLiteral(", Roll = ");
		appendInterpolatedStringHandler.AppendFormatted<float>(this.Roll);
		appendInterpolatedStringHandler.AppendLiteral(")");
		sb.Append(ref appendInterpolatedStringHandler);
	}

	// Token: 0x06003458 RID: 13400 RVA: 0x0002D566 File Offset: 0x0002B766
	public void Clear()
	{
		this.Reset();
	}

	// Token: 0x06003459 RID: 13401 RVA: 0x0002D56E File Offset: 0x0002B76E
	public Rotator()
	{
	}

	// Token: 0x0600345A RID: 13402 RVA: 0x0002D576 File Offset: 0x0002B776
	public Rotator(float inPitch, float inYaw, float inRoll)
	{
		this.Pitch = inPitch;
		this.Yaw = inYaw;
		this.Roll = inRoll;
	}

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x0600345B RID: 13403 RVA: 0x0002D593 File Offset: 0x0002B793
	// (set) Token: 0x0600345C RID: 13404 RVA: 0x0002D59B File Offset: 0x0002B79B
	float IRotator.Pitch
	{
		get
		{
			return this.Pitch;
		}
		set
		{
			this.Pitch = value;
		}
	}

	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x0600345D RID: 13405 RVA: 0x0002D5A4 File Offset: 0x0002B7A4
	// (set) Token: 0x0600345E RID: 13406 RVA: 0x0002D5AC File Offset: 0x0002B7AC
	float IRotator.Yaw
	{
		get
		{
			return this.Yaw;
		}
		set
		{
			this.Yaw = value;
		}
	}

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x0600345F RID: 13407 RVA: 0x0002D5B5 File Offset: 0x0002B7B5
	// (set) Token: 0x06003460 RID: 13408 RVA: 0x0002D5BD File Offset: 0x0002B7BD
	float IRotator.Roll
	{
		get
		{
			return this.Roll;
		}
		set
		{
			this.Roll = value;
		}
	}

	// Token: 0x06003461 RID: 13409 RVA: 0x0002D5C6 File Offset: 0x0002B7C6
	public void Set(float inPitch, float inYaw, float inRoll)
	{
		this.Pitch = inPitch;
		this.Yaw = inYaw;
		this.Roll = inRoll;
	}

	// Token: 0x06003462 RID: 13410 RVA: 0x0002D5DD File Offset: 0x0002B7DD
	public void FromUeRotator(IRotator inR)
	{
		this.Pitch = inR.Pitch;
		this.Yaw = inR.Yaw;
		this.Roll = inR.Roll;
	}

	// Token: 0x06003463 RID: 13411 RVA: 0x0002D603 File Offset: 0x0002B803
	public void FromUeRotator(Aki.Protocol.Rotator inR)
	{
		this.Pitch = inR.Pitch;
		this.Yaw = inR.Yaw;
		this.Roll = inR.Roll;
	}

	// Token: 0x06003464 RID: 13412 RVA: 0x0002D629 File Offset: 0x0002B829
	public void FromUeRotator(global::Rotator inR)
	{
		this.Pitch = inR.Pitch;
		this.Yaw = inR.Yaw;
		this.Roll = inR.Roll;
	}

	// Token: 0x06003465 RID: 13413 RVA: 0x0002D64F File Offset: 0x0002B84F
	public void FromUeRotator(in FRotator inR)
	{
		this.Pitch = inR.Pitch;
		this.Yaw = inR.Yaw;
		this.Roll = inR.Roll;
	}

	// Token: 0x06003466 RID: 13414 RVA: 0x0002D675 File Offset: 0x0002B875
	public void DeepCopy(IRotator inR)
	{
		this.Set(inR.Pitch, inR.Yaw, inR.Roll);
	}

	// Token: 0x06003467 RID: 13415 RVA: 0x0002D68F File Offset: 0x0002B88F
	public void DeepCopy(global::Rotator inR)
	{
		this.Set(inR.Pitch, inR.Yaw, inR.Roll);
	}

	// Token: 0x06003468 RID: 13416 RVA: 0x0002D6A9 File Offset: 0x0002B8A9
	public void DeepCopy(in FRotator inR)
	{
		this.Set(inR.Pitch, inR.Yaw, inR.Roll);
	}

	// Token: 0x06003469 RID: 13417 RVA: 0x0002D6C3 File Offset: 0x0002B8C3
	public static global::Rotator Create(float pitch, float yaw, float roll)
	{
		return new global::Rotator(pitch, yaw, roll);
	}

	// Token: 0x0600346A RID: 13418 RVA: 0x0002D6CD File Offset: 0x0002B8CD
	public static global::Rotator Create([Nullable(2)] IRotator inR)
	{
		if (inR == null)
		{
			return new global::Rotator();
		}
		return new global::Rotator(inR.Pitch, inR.Yaw, inR.Roll);
	}

	// Token: 0x0600346B RID: 13419 RVA: 0x0002D6EF File Offset: 0x0002B8EF
	public static global::Rotator Create()
	{
		return new global::Rotator();
	}

	// Token: 0x0600346C RID: 13420 RVA: 0x0002D6F6 File Offset: 0x0002B8F6
	public FRotator ToUeRotator()
	{
		return new FRotator(this.Pitch, this.Yaw, this.Roll);
	}

	// Token: 0x0600346D RID: 13421 RVA: 0x0002D710 File Offset: 0x0002B910
	public static float NormalizeAxis(float angle)
	{
		float num = global::Rotator.ClampAxis(angle);
		if (num > 180f)
		{
			num -= 360f;
		}
		return num;
	}

	// Token: 0x0600346E RID: 13422 RVA: 0x0002D738 File Offset: 0x0002B938
	public static double NormalizeAxis(double angle)
	{
		double num = global::Rotator.ClampAxis(angle);
		if (num > 180.0)
		{
			num -= 360.0;
		}
		return num;
	}

	// Token: 0x0600346F RID: 13423 RVA: 0x0002D765 File Offset: 0x0002B965
	public global::Rotator Normalize(global::Rotator outR)
	{
		outR.Pitch = global::Rotator.NormalizeAxis(this.Pitch);
		outR.Yaw = global::Rotator.NormalizeAxis(this.Yaw);
		outR.Roll = global::Rotator.NormalizeAxis(this.Roll);
		return outR;
	}

	// Token: 0x06003470 RID: 13424 RVA: 0x0002D79C File Offset: 0x0002B99C
	public static float ClampAxis(float angle)
	{
		float num = angle % 360f;
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	// Token: 0x06003471 RID: 13425 RVA: 0x0002D7C4 File Offset: 0x0002B9C4
	public static double ClampAxis(double angle)
	{
		double num = angle % 360.0;
		if (num < 0.0)
		{
			num += 360.0;
		}
		return num;
	}

	// Token: 0x06003472 RID: 13426 RVA: 0x0002D7F6 File Offset: 0x0002B9F6
	public global::Rotator Clamp(global::Rotator outR)
	{
		outR.Pitch = global::Rotator.ClampAxis(this.Pitch);
		outR.Yaw = global::Rotator.ClampAxis(this.Yaw);
		outR.Roll = global::Rotator.ClampAxis(this.Roll);
		return outR;
	}

	// Token: 0x06003473 RID: 13427 RVA: 0x0002D82C File Offset: 0x0002BA2C
	public void Vector(global::Vector outV)
	{
		float degVal = MathCommon.WrapAngle(this.Pitch);
		float degVal2 = MathCommon.WrapAngle(this.Yaw);
		float num = MathCommon.DegreeToRadian(degVal);
		float num2 = MathCommon.DegreeToRadian(degVal2);
		float num3 = (float)Math.Cos((double)num);
		float num4 = (float)Math.Sin((double)num);
		float num5 = (float)Math.Cos((double)num2);
		float num6 = (float)Math.Sin((double)num2);
		outV.X = (double)(num3 * num5);
		outV.Y = (double)(num3 * num6);
		outV.Z = (double)num4;
	}

	// Token: 0x06003474 RID: 13428 RVA: 0x0002D8A0 File Offset: 0x0002BAA0
	public Quat Quaternion([Nullable(2)] Quat outQ = null)
	{
		Quat quat = outQ;
		if (quat == null)
		{
			if (this.QuatInternal == null)
			{
				this.QuatInternal = Quat.Create(0f, 0f, 0f, 1f);
			}
			quat = this.QuatInternal;
		}
		float num = this.Pitch % 360f;
		float num2 = this.Yaw % 360f;
		float num3 = this.Roll % 360f;
		float num4 = num * 0.008726646f;
		float num5 = num2 * 0.008726646f;
		float num6 = num3 * 0.008726646f;
		float num7 = (float)Math.Sin((double)num4);
		float num8 = (float)Math.Cos((double)num4);
		float num9 = (float)Math.Sin((double)num5);
		float num10 = (float)Math.Cos((double)num5);
		float num11 = (float)Math.Sin((double)num6);
		float num12 = (float)Math.Cos((double)num6);
		float x = num12 * num7 * num9 - num11 * num8 * num10;
		float y = -num12 * num7 * num10 - num11 * num8 * num9;
		float z = num12 * num8 * num9 - num11 * num7 * num10;
		float w = num12 * num8 * num10 + num11 * num7 * num9;
		quat.X = x;
		quat.Y = y;
		quat.Z = z;
		quat.W = w;
		return quat;
	}

	// Token: 0x06003475 RID: 13429 RVA: 0x0002D9C4 File Offset: 0x0002BBC4
	public bool IsNearlyZero()
	{
		float num = 0.0001f;
		return Math.Abs(global::Rotator.NormalizeAxis(this.Yaw)) <= num && Math.Abs(global::Rotator.NormalizeAxis(this.Pitch)) <= num && Math.Abs(global::Rotator.NormalizeAxis(this.Roll)) <= num;
	}

	// Token: 0x06003476 RID: 13430 RVA: 0x0002DA18 File Offset: 0x0002BC18
	public bool Equals(global::Rotator b, float tolerance = 0.0001f)
	{
		return Math.Abs(global::Rotator.NormalizeAxis(this.Yaw - b.Yaw)) <= tolerance && Math.Abs(global::Rotator.NormalizeAxis(this.Pitch - b.Pitch)) <= tolerance && Math.Abs(global::Rotator.NormalizeAxis(this.Roll - b.Roll)) <= tolerance;
	}

	// Token: 0x06003477 RID: 13431 RVA: 0x0002DA78 File Offset: 0x0002BC78
	public bool Equals2(IRotator inB, float tolerance = 0.0001f)
	{
		return Math.Abs(global::Rotator.NormalizeAxis(this.Yaw - inB.Yaw)) <= tolerance && Math.Abs(global::Rotator.NormalizeAxis(this.Pitch - inB.Pitch)) <= tolerance && Math.Abs(global::Rotator.NormalizeAxis(this.Roll - inB.Roll)) <= tolerance;
	}

	// Token: 0x06003478 RID: 13432 RVA: 0x0002DAD8 File Offset: 0x0002BCD8
	public global::Rotator AdditionEqual(IRotator inB)
	{
		this.Pitch += inB.Pitch;
		this.Yaw += inB.Yaw;
		this.Roll += inB.Roll;
		return this;
	}

	// Token: 0x06003479 RID: 13433 RVA: 0x0002DB14 File Offset: 0x0002BD14
	public global::Rotator SubtractionEqual(IRotator inB)
	{
		this.Pitch -= inB.Pitch;
		this.Yaw -= inB.Yaw;
		this.Roll -= inB.Roll;
		return this;
	}

	// Token: 0x0600347A RID: 13434 RVA: 0x0002DB50 File Offset: 0x0002BD50
	public global::Rotator MultiplyEqual(float inV)
	{
		this.Pitch *= inV;
		this.Yaw *= inV;
		this.Roll *= inV;
		return this;
	}

	// Token: 0x0600347B RID: 13435 RVA: 0x0002DB7D File Offset: 0x0002BD7D
	public void UnaryNegation(global::Rotator outV)
	{
		outV.Pitch = -this.Pitch;
		outV.Yaw = -this.Yaw;
		outV.Roll = -this.Roll;
	}

	// Token: 0x0600347C RID: 13436 RVA: 0x0002DBA6 File Offset: 0x0002BDA6
	public void Reset()
	{
		this.Pitch = 0f;
		this.Yaw = 0f;
		this.Roll = 0f;
	}

	// Token: 0x0600347D RID: 13437 RVA: 0x0002DBC9 File Offset: 0x0002BDC9
	public static void UeRotatorCopy(FRotator inR, FRotator outR)
	{
		outR.Pitch = inR.Pitch;
		outR.Yaw = inR.Yaw;
		outR.Roll = inR.Roll;
	}

	// Token: 0x0600347E RID: 13438 RVA: 0x0002DBF4 File Offset: 0x0002BDF4
	public static void Lerp(global::Rotator from, global::Rotator to, float alpha, global::Rotator outR)
	{
		outR.Pitch = to.Pitch - from.Pitch;
		outR.Yaw = to.Yaw - from.Yaw;
		outR.Roll = to.Roll - from.Roll;
		MathCommon.VectorNormalizeRotator(outR);
		outR.Pitch *= alpha;
		outR.Pitch += from.Pitch;
		outR.Yaw *= alpha;
		outR.Yaw += from.Yaw;
		outR.Roll *= alpha;
		outR.Roll += from.Roll;
		MathCommon.VectorNormalizeRotator(outR);
	}

	// Token: 0x0600347F RID: 13439 RVA: 0x0002DCA9 File Offset: 0x0002BEA9
	public static float AxisLerp(float from, float to, float alpha)
	{
		return MathCommon.WrapAngle(MathCommon.WrapAngle(to - from) * alpha + from);
	}

	// Token: 0x06003480 RID: 13440 RVA: 0x0002DCBC File Offset: 0x0002BEBC
	public Aki.Protocol.Rotator ToProtocolRotator()
	{
		Aki.Protocol.Rotator rotator = Aki.Protocol.Rotator.Create();
		rotator.Pitch = this.Pitch;
		rotator.Roll = this.Roll;
		rotator.Yaw = this.Yaw;
		return rotator;
	}

	// Token: 0x04000633 RID: 1587
	public float Pitch;

	// Token: 0x04000634 RID: 1588
	public float Yaw;

	// Token: 0x04000635 RID: 1589
	public float Roll;

	// Token: 0x04000636 RID: 1590
	[Nullable(2)]
	private Quat QuatInternal;

	// Token: 0x04000637 RID: 1591
	[StaticVariableRuleIgnore]
	public static readonly global::Rotator ZeroRotatorProxy = new global::Rotator(0f, 0f, 0f);

	// Token: 0x04000638 RID: 1592
	[StaticVariableRuleIgnore]
	public static readonly FRotator ZeroRotator = new FRotator(0f, 0f, 0f);
}
