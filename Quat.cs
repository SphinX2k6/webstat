using System;
using System.Runtime.CompilerServices;
using Aki.Common.Common;
using UnrealEngine;
using UnrealEngine.Bulitin.Utils;
using UnrealEngine.Extension;

// Token: 0x02000C19 RID: 3097
[NullableContext(1)]
[Nullable(0)]
public class Quat : IQuat, IClearable, ILogFormattedPrint
{
	// Token: 0x170000DC RID: 220
	// (get) Token: 0x0600341B RID: 13339 RVA: 0x0002C3D0 File Offset: 0x0002A5D0
	// (set) Token: 0x0600341C RID: 13340 RVA: 0x0002C3D8 File Offset: 0x0002A5D8
	float IQuat.X
	{
		get
		{
			return this.X;
		}
		set
		{
			this.X = value;
		}
	}

	// Token: 0x170000DD RID: 221
	// (get) Token: 0x0600341D RID: 13341 RVA: 0x0002C3E1 File Offset: 0x0002A5E1
	// (set) Token: 0x0600341E RID: 13342 RVA: 0x0002C3E9 File Offset: 0x0002A5E9
	float IQuat.Y
	{
		get
		{
			return this.Y;
		}
		set
		{
			this.Y = value;
		}
	}

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x0600341F RID: 13343 RVA: 0x0002C3F2 File Offset: 0x0002A5F2
	// (set) Token: 0x06003420 RID: 13344 RVA: 0x0002C3FA File Offset: 0x0002A5FA
	float IQuat.Z
	{
		get
		{
			return this.Z;
		}
		set
		{
			this.Z = value;
		}
	}

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x06003421 RID: 13345 RVA: 0x0002C403 File Offset: 0x0002A603
	// (set) Token: 0x06003422 RID: 13346 RVA: 0x0002C40B File Offset: 0x0002A60B
	float IQuat.W
	{
		get
		{
			return this.W;
		}
		set
		{
			this.W = value;
		}
	}

	// Token: 0x06003423 RID: 13347 RVA: 0x0002C414 File Offset: 0x0002A614
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 4);
		defaultInterpolatedStringHandler.AppendLiteral("X=");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.X);
		defaultInterpolatedStringHandler.AppendLiteral(", Y=");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Y);
		defaultInterpolatedStringHandler.AppendLiteral(", Z=");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Z);
		defaultInterpolatedStringHandler.AppendLiteral(", W=");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.W);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06003424 RID: 13348 RVA: 0x0002C496 File Offset: 0x0002A696
	public string ToFormattedString()
	{
		return this.ToString();
	}

	// Token: 0x06003425 RID: 13349 RVA: 0x0002C4A0 File Offset: 0x0002A6A0
	public void ToFormattedString(UnsafeStringBuilder sb)
	{
		UnsafeStringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new UnsafeStringBuilder.AppendInterpolatedStringHandler(14, 4, sb);
		appendInterpolatedStringHandler.AppendLiteral("X=");
		appendInterpolatedStringHandler.AppendFormatted<float>(this.X);
		appendInterpolatedStringHandler.AppendLiteral(", Y=");
		appendInterpolatedStringHandler.AppendFormatted<float>(this.Y);
		appendInterpolatedStringHandler.AppendLiteral(", Z=");
		appendInterpolatedStringHandler.AppendFormatted<float>(this.Z);
		appendInterpolatedStringHandler.AppendLiteral(", W=");
		appendInterpolatedStringHandler.AppendFormatted<float>(this.W);
		sb.Append(ref appendInterpolatedStringHandler);
	}

	// Token: 0x06003426 RID: 13350 RVA: 0x0002C527 File Offset: 0x0002A727
	public void Clear()
	{
		this.Reset();
	}

	// Token: 0x06003427 RID: 13351 RVA: 0x0002C52F File Offset: 0x0002A72F
	public FQuat ToUeQuat()
	{
		return new FQuat(this.X, this.Y, this.Z, this.W);
	}

	// Token: 0x06003428 RID: 13352 RVA: 0x0002C54E File Offset: 0x0002A74E
	public void FromUeQuat(IQuat inQ)
	{
		this.X = inQ.X;
		this.Y = inQ.Y;
		this.Z = inQ.Z;
		this.W = inQ.W;
	}

	// Token: 0x06003429 RID: 13353 RVA: 0x0002C580 File Offset: 0x0002A780
	public void FromUeQuat(Quat inQ)
	{
		this.X = inQ.X;
		this.Y = inQ.Y;
		this.Z = inQ.Z;
		this.W = inQ.W;
	}

	// Token: 0x0600342A RID: 13354 RVA: 0x0002C5B2 File Offset: 0x0002A7B2
	public void FromUeQuat(FQuat inQ)
	{
		this.X = inQ.X;
		this.Y = inQ.Y;
		this.Z = inQ.Z;
		this.W = inQ.W;
	}

	// Token: 0x0600342B RID: 13355 RVA: 0x0002C5E4 File Offset: 0x0002A7E4
	public static Quat Create(float x = 0f, float y = 0f, float z = 0f, float w = 1f)
	{
		return new Quat(x, y, z, w);
	}

	// Token: 0x0600342C RID: 13356 RVA: 0x0002C5EF File Offset: 0x0002A7EF
	public static Quat Create(IQuat inQ)
	{
		return new Quat(inQ.X, inQ.Y, inQ.Z, inQ.W);
	}

	// Token: 0x0600342D RID: 13357 RVA: 0x0002C60E File Offset: 0x0002A80E
	public static Quat Create(Quat inQ)
	{
		return new Quat(inQ.X, inQ.Y, inQ.Z, inQ.W);
	}

	// Token: 0x0600342E RID: 13358 RVA: 0x0002C62D File Offset: 0x0002A82D
	public static Quat Create(FQuat inQ)
	{
		return new Quat(inQ.X, inQ.Y, inQ.Z, inQ.W);
	}

	// Token: 0x0600342F RID: 13359 RVA: 0x0002C64C File Offset: 0x0002A84C
	public Quat()
	{
		this.W = 1f;
	}

	// Token: 0x06003430 RID: 13360 RVA: 0x0002C65F File Offset: 0x0002A85F
	public Quat(float inX = 0f, float inY = 0f, float inZ = 0f, float inW = 1f)
	{
		this.X = inX;
		this.Y = inY;
		this.Z = inZ;
		this.W = inW;
	}

	// Token: 0x06003431 RID: 13361 RVA: 0x0002C684 File Offset: 0x0002A884
	public void DeepCopy(Quat inQ)
	{
		this.Set(inQ.X, inQ.Y, inQ.Z, inQ.W);
	}

	// Token: 0x06003432 RID: 13362 RVA: 0x0002C6A4 File Offset: 0x0002A8A4
	public void DeepCopy(FQuat inQ)
	{
		this.Set(inQ.X, inQ.Y, inQ.Z, inQ.W);
	}

	// Token: 0x06003433 RID: 13363 RVA: 0x0002C6C4 File Offset: 0x0002A8C4
	public void Set(float inX, float inY, float inZ, float inW)
	{
		this.X = inX;
		this.Y = inY;
		this.Z = inZ;
		this.W = inW;
		this.ToUeQuat();
	}

	// Token: 0x06003434 RID: 13364 RVA: 0x0002C6EA File Offset: 0x0002A8EA
	public void Multiply(Quat inQ, Quat outQ)
	{
		Quat.VectorQuaternionMultiply(this, inQ, outQ);
		outQ.Inverse2(outQ);
	}

	// Token: 0x06003435 RID: 13365 RVA: 0x0002C6FB File Offset: 0x0002A8FB
	public void Multiply(float inQ, Quat outQ)
	{
		outQ.X *= inQ;
		outQ.Y *= inQ;
		outQ.Z *= inQ;
		outQ.W *= inQ;
	}

	// Token: 0x06003436 RID: 13366 RVA: 0x0002C738 File Offset: 0x0002A938
	private static void FindBetweenHelper(Vector aV, Vector bV, float normAvBv, Quat outQ)
	{
		double num = (double)normAvBv + Vector.DotProduct(aV, bV);
		if (num > (double)(1E-06f * normAvBv))
		{
			outQ.X = (float)(aV.Y * bV.Z - aV.Z * bV.Y);
			outQ.Y = (float)(aV.Z * bV.X - aV.X * bV.Z);
			outQ.Z = (float)(aV.X * bV.Y - aV.Y * bV.X);
			outQ.W = (float)num;
		}
		else
		{
			bool flag = Math.Abs(aV.X) > Math.Abs(aV.Y);
			outQ.X = (float)(flag ? (-(float)aV.Z) : 0.0);
			outQ.Y = (float)(flag ? 0.0 : (-(float)aV.Z));
			outQ.Z = (float)(flag ? aV.X : aV.Y);
			outQ.W = 0f;
		}
		outQ.Normalize(1E-06f);
	}

	// Token: 0x06003437 RID: 13367 RVA: 0x0002C84C File Offset: 0x0002AA4C
	private static void SlerpNotNormalized(Quat quat1, Quat quat2, float slerp, Quat outR)
	{
		float num = quat1.X * quat2.X + quat1.Y * quat2.Y + quat1.Z * quat2.Z + quat1.W * quat2.W;
		float num2 = Math.Abs(num);
		float num5;
		float num6;
		if (num2 < 0.9999f)
		{
			float num3 = (float)Math.Acos((double)num2);
			float num4 = 1f / (float)Math.Sin((double)num3);
			num5 = (float)Math.Sin((double)((1f - slerp) * num3)) * num4;
			num6 = (float)Math.Sin((double)(slerp * num3)) * num4;
		}
		else
		{
			num5 = 1f - slerp;
			num6 = slerp;
		}
		num6 = ((num < 0f) ? (-num6) : num6);
		outR.X = num5 * quat1.X + num6 * quat2.X;
		outR.Y = num5 * quat1.Y + num6 * quat2.Y;
		outR.Z = num5 * quat1.Z + num6 * quat2.Z;
		outR.W = num5 * quat1.W + num6 * quat2.W;
	}

	// Token: 0x06003438 RID: 13368 RVA: 0x0002C95B File Offset: 0x0002AB5B
	public static void Squad(Quat quat1, Quat tang1, Quat quat2, Quat tang2, float alpha, Quat outQ)
	{
		Quat.SlerpNotNormalized(quat1, quat2, alpha, Quat.TmpQuat1);
		Quat.SlerpNotNormalized(tang1, tang2, alpha, Quat.TmpQuat2);
		Quat.Slerp(Quat.TmpQuat1, Quat.TmpQuat2, 2f * alpha * (1f - alpha), outQ);
	}

	// Token: 0x06003439 RID: 13369 RVA: 0x0002C99B File Offset: 0x0002AB9B
	public static void FindBetween(Vector from, Vector to, Quat outQ)
	{
		Quat.FindBetweenVectors(from, to, outQ);
	}

	// Token: 0x0600343A RID: 13370 RVA: 0x0002C9A8 File Offset: 0x0002ABA8
	public static double AngularDistance(Quat q1, Quat q2)
	{
		float value = q1.X * q2.X + q1.Y * q2.Y + q1.Z * q2.Z + q1.W * q2.W;
		return 2.0 * Math.Acos(Math.Min((double)Math.Abs(value), 1.0));
	}

	// Token: 0x0600343B RID: 13371 RVA: 0x0002CA14 File Offset: 0x0002AC14
	public static void FindBetweenVectors(Vector aV, Vector bV, Quat outQ)
	{
		float normAvBv = (float)Math.Sqrt(aV.SizeSquared() * bV.SizeSquared());
		Quat.FindBetweenHelper(aV, bV, normAvBv, outQ);
	}

	// Token: 0x0600343C RID: 13372 RVA: 0x0002CA3E File Offset: 0x0002AC3E
	public static void Slerp(Quat quat1, Quat quat2, float slerp, Quat outQ)
	{
		Quat.SlerpNotNormalized(quat1, quat2, slerp, outQ);
		outQ.Normalize(1E-06f);
	}

	// Token: 0x0600343D RID: 13373 RVA: 0x0002CA55 File Offset: 0x0002AC55
	public bool Normalize(float tolerance = 1E-06f)
	{
		this.GetNormalized(this, tolerance);
		return true;
	}

	// Token: 0x0600343E RID: 13374 RVA: 0x0002CA60 File Offset: 0x0002AC60
	public void GetNormalized(Quat outQ, float tolerance = 1E-06f)
	{
		float num = this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
		if (num >= tolerance)
		{
			float num2 = 1f / (float)Math.Sqrt((double)num);
			outQ.X = this.X * num2;
			outQ.Y = this.Y * num2;
			outQ.Z = this.Z * num2;
			outQ.W = this.W * num2;
			return;
		}
		outQ.Reset();
	}

	// Token: 0x0600343F RID: 13375 RVA: 0x0002CAF7 File Offset: 0x0002ACF7
	public void Reset()
	{
		this.X = 0f;
		this.Y = 0f;
		this.Z = 0f;
		this.W = 1f;
		this.ToUeQuat();
	}

	// Token: 0x06003440 RID: 13376 RVA: 0x0002CB2C File Offset: 0x0002AD2C
	public void RotateVector(Vector inV, Vector outV)
	{
		double num = ((double)this.Y * inV.Z - (double)this.Z * inV.Y) * 2.0;
		double num2 = ((double)this.Z * inV.X - (double)this.X * inV.Z) * 2.0;
		double num3 = ((double)this.X * inV.Y - (double)this.Y * inV.X) * 2.0;
		double num4 = (double)this.Y * num3 - (double)this.Z * num2;
		double num5 = (double)this.Z * num - (double)this.X * num3;
		double num6 = (double)this.X * num2 - (double)this.Y * num;
		outV.X = inV.X + (double)this.W * num + num4;
		outV.Y = inV.Y + (double)this.W * num2 + num5;
		outV.Z = inV.Z + (double)this.W * num3 + num6;
	}

	// Token: 0x06003441 RID: 13377 RVA: 0x0002CC3C File Offset: 0x0002AE3C
	public void UnRotateVector(Vector inV, Vector outV)
	{
		float num = -this.X;
		float num2 = -this.Y;
		float num3 = -this.Z;
		double num4 = ((double)num2 * inV.Z - (double)num3 * inV.Y) * 2.0;
		double num5 = ((double)num3 * inV.X - (double)num * inV.Z) * 2.0;
		double num6 = ((double)num * inV.Y - (double)num2 * inV.X) * 2.0;
		double num7 = (double)num2 * num6 - (double)num3 * num5;
		double num8 = (double)num3 * num4 - (double)num * num6;
		double num9 = (double)num * num5 - (double)num2 * num4;
		outV.X = inV.X + (double)this.W * num4 + num7;
		outV.Y = inV.Y + (double)this.W * num5 + num8;
		outV.Z = inV.Z + (double)this.W * num6 + num9;
	}

	// Token: 0x06003442 RID: 13378 RVA: 0x0002CD30 File Offset: 0x0002AF30
	public Rotator Rotator([Nullable(2)] Rotator outR = null)
	{
		Rotator rotator = outR;
		if (outR == null && (rotator = this._rotatorInternal) == null)
		{
			rotator = (this._rotatorInternal = new Rotator());
		}
		Rotator rotator2 = rotator;
		float num = this.Z * this.X - this.W * this.Y;
		float num2 = 2f * (this.W * this.Z + this.X * this.Y);
		float num3 = 1f - 2f * (this.Y * this.Y + this.Z * this.Z);
		if (num < -0.4999995f)
		{
			rotator2.Pitch = -90f;
			rotator2.Yaw = (float)Math.Atan2((double)num2, (double)num3) * 57.29578f;
			rotator2.Roll = global::Rotator.NormalizeAxis(-rotator2.Yaw - 2f * (float)Math.Atan2((double)this.X, (double)this.W) * 57.29578f);
		}
		else if (num > 0.4999995f)
		{
			rotator2.Pitch = 90f;
			rotator2.Yaw = (float)Math.Atan2((double)num2, (double)num3) * 57.29578f;
			rotator2.Roll = global::Rotator.NormalizeAxis(rotator2.Yaw - 2f * (float)Math.Atan2((double)this.X, (double)this.W) * 57.29578f);
		}
		else
		{
			rotator2.Pitch = (float)Math.Asin((double)(2f * num)) * 57.29578f;
			rotator2.Yaw = (float)Math.Atan2((double)num2, (double)num3) * 57.29578f;
			rotator2.Roll = (float)Math.Atan2((double)(-(double)(this.W * this.X + this.Y * this.Z) * 2f), (double)(1f - 2f * (this.Y * this.Y + this.X * this.X))) * 57.29578f;
		}
		return rotator2;
	}

	// Token: 0x06003443 RID: 13379 RVA: 0x0002CF12 File Offset: 0x0002B112
	public void Inverse(Quat outQ)
	{
		outQ.X = -this.X;
		outQ.Y = -this.Y;
		outQ.Z = -this.Z;
		outQ.W = this.W;
	}

	// Token: 0x06003444 RID: 13380 RVA: 0x0002CF47 File Offset: 0x0002B147
	public void Inverse2(Quat outQ)
	{
		outQ.X = -this.X;
		outQ.Y = -this.Y;
		outQ.Z = -this.Z;
		outQ.W = -this.W;
	}

	// Token: 0x06003445 RID: 13381 RVA: 0x0002CF7D File Offset: 0x0002B17D
	public bool IsNearZero(float tolerance = 1E-06f)
	{
		return Math.Abs(this.X) < tolerance && Math.Abs(this.Y) < tolerance && Math.Abs(this.Z) < tolerance && Math.Abs(this.W) < tolerance;
	}

	// Token: 0x06003446 RID: 13382 RVA: 0x0002CFB9 File Offset: 0x0002B1B9
	public Vector GetAxisX(Vector outV)
	{
		this.RotateVector(Vector.ForwardVectorProxy, outV);
		return outV;
	}

	// Token: 0x06003447 RID: 13383 RVA: 0x0002CFC8 File Offset: 0x0002B1C8
	public Vector GetAxisY(Vector outV)
	{
		this.RotateVector(Vector.RightVectorProxy, outV);
		return outV;
	}

	// Token: 0x06003448 RID: 13384 RVA: 0x0002CFD7 File Offset: 0x0002B1D7
	public Vector GetAxisZ(Vector outV)
	{
		this.RotateVector(Vector.UpVectorProxy, outV);
		return outV;
	}

	// Token: 0x06003449 RID: 13385 RVA: 0x0002CFE6 File Offset: 0x0002B1E6
	public Vector GetForwardVector(Vector outV)
	{
		return this.GetAxisX(outV);
	}

	// Token: 0x0600344A RID: 13386 RVA: 0x0002CFEF File Offset: 0x0002B1EF
	public Vector GetRightVector(Vector outV)
	{
		return this.GetAxisY(outV);
	}

	// Token: 0x0600344B RID: 13387 RVA: 0x0002CFF8 File Offset: 0x0002B1F8
	public Vector GetUpVector(Vector outV)
	{
		return this.GetAxisZ(outV);
	}

	// Token: 0x0600344C RID: 13388 RVA: 0x0002D004 File Offset: 0x0002B204
	public static void ConstructorByAxisAngle(Vector axis, float angleRad, Quat outQ)
	{
		float num = 0.5f * angleRad;
		float num2 = (float)Math.Sin((double)num);
		float w = (float)Math.Cos((double)num);
		outQ.X = (float)((double)num2 * axis.X);
		outQ.Y = (float)((double)num2 * axis.Y);
		outQ.Z = (float)((double)num2 * axis.Z);
		outQ.W = w;
	}

	// Token: 0x0600344D RID: 13389 RVA: 0x0002D060 File Offset: 0x0002B260
	public bool Equals(Quat b, float tolerance = 0.0001f)
	{
		return Math.Abs(this.X - b.X) <= tolerance && Math.Abs(this.Y - b.Y) <= tolerance && Math.Abs(this.Z - b.Z) <= tolerance && Math.Abs(this.W - b.W) <= tolerance;
	}

	// Token: 0x0600344E RID: 13390 RVA: 0x0002D0C8 File Offset: 0x0002B2C8
	public static void VectorQuaternionMultiply(Quat quat1, Quat quat2, Quat outQ)
	{
		Quat.OriginQuat1.FromUeQuat(quat1);
		Quat.OriginQuat2.FromUeQuat(quat2);
		Quat.TmpQuat1.Reset();
		Quat.TmpQuat2.Reset();
		Quat.TmpQuat3.Reset();
		Quat.VectorReplicate(Quat.OriginQuat1, 3, Quat.TmpQuat1);
		Quat.VectorMultiply(Quat.TmpQuat1, Quat.OriginQuat2, outQ);
		Quat.VectorReplicate(Quat.OriginQuat1, 0, Quat.TmpQuat1);
		Quat.VectorSwizzle(Quat.OriginQuat2, 3, 2, 1, 0, Quat.TmpQuat2);
		Quat.VectorMultiply(Quat.TmpQuat1, Quat.TmpQuat2, Quat.TmpQuat3);
		Quat.VectorMultiplyAdd(Quat.TmpQuat3, Quat.QuatMultiSignMask0, outQ, outQ);
		Quat.VectorReplicate(Quat.OriginQuat1, 1, Quat.TmpQuat1);
		Quat.VectorSwizzle(Quat.OriginQuat2, 2, 3, 0, 1, Quat.TmpQuat2);
		Quat.VectorMultiply(Quat.TmpQuat1, Quat.TmpQuat2, Quat.TmpQuat3);
		Quat.VectorMultiplyAdd(Quat.TmpQuat3, Quat.QuatMultiSignMask1, outQ, outQ);
		Quat.VectorReplicate(Quat.OriginQuat1, 2, Quat.TmpQuat1);
		Quat.VectorSwizzle(Quat.OriginQuat2, 1, 0, 3, 2, Quat.TmpQuat2);
		Quat.VectorMultiply(Quat.TmpQuat1, Quat.TmpQuat2, Quat.TmpQuat3);
		Quat.VectorMultiplyAdd(Quat.TmpQuat3, Quat.QuatMultiSignMask2, outQ, outQ);
	}

	// Token: 0x0600344F RID: 13391 RVA: 0x0002D204 File Offset: 0x0002B404
	private static void VectorMultiply(Quat q1, Quat q2, Quat outQ)
	{
		outQ.X = q1.X * q2.X;
		outQ.Y = q1.Y * q2.Y;
		outQ.Z = q1.Z * q2.Z;
		outQ.W = q1.W * q2.W;
	}

	// Token: 0x06003450 RID: 13392 RVA: 0x0002D260 File Offset: 0x0002B460
	private static void VectorMultiplyAdd(Quat q1, Quat q2, Quat q3, Quat outQ)
	{
		outQ.X = q1.X * q2.X + q3.X;
		outQ.Y = q1.Y * q2.Y + q3.Y;
		outQ.Z = q1.Z * q2.Z + q3.Z;
		outQ.W = q1.W * q2.W + q3.W;
	}

	// Token: 0x06003451 RID: 13393 RVA: 0x0002D2D8 File Offset: 0x0002B4D8
	private static void VectorReplicate(Quat quat, int index, Quat outQ)
	{
		float num = quat[index];
		outQ.X = num;
		outQ.Y = num;
		outQ.Z = num;
		outQ.W = num;
	}

	// Token: 0x06003452 RID: 13394 RVA: 0x0002D309 File Offset: 0x0002B509
	private static void VectorSwizzle(Quat quat, int x, int y, int z, int w, Quat outQ)
	{
		outQ.X = quat[x];
		outQ.Y = quat[y];
		outQ.Z = quat[z];
		outQ.W = quat[w];
	}

	// Token: 0x170000E0 RID: 224
	public float this[int index]
	{
		get
		{
			float result;
			switch (index)
			{
			case 0:
				result = this.X;
				break;
			case 1:
				result = this.Y;
				break;
			case 2:
				result = this.Z;
				break;
			case 3:
				result = this.W;
				break;
			default:
				throw new IndexOutOfRangeException();
			}
			return result;
		}
	}

	// Token: 0x04000621 RID: 1569
	public const float FIND_BETWEEN_CONST = 1E-06f;

	// Token: 0x04000622 RID: 1570
	public const float SLERP_CONST = 0.9999f;

	// Token: 0x04000623 RID: 1571
	public const float SINGULARITY_THRESHOLD = 0.4999995f;

	// Token: 0x04000624 RID: 1572
	public float X;

	// Token: 0x04000625 RID: 1573
	public float Y;

	// Token: 0x04000626 RID: 1574
	public float Z;

	// Token: 0x04000627 RID: 1575
	public float W;

	// Token: 0x04000628 RID: 1576
	[StaticVariableRuleIgnore]
	public static readonly FQuat Identity = new FQuat(0f, 0f, 0f, 1f);

	// Token: 0x04000629 RID: 1577
	[StaticVariableRuleIgnore]
	public static readonly Quat IdentityProxy = new Quat(0f, 0f, 0f, 1f);

	// Token: 0x0400062A RID: 1578
	[Nullable(2)]
	private Rotator _rotatorInternal;

	// Token: 0x0400062B RID: 1579
	[StaticVariableRuleIgnore]
	private static readonly Quat QuatMultiSignMask0 = new Quat(1f, -1f, 1f, -1f);

	// Token: 0x0400062C RID: 1580
	[StaticVariableRuleIgnore]
	private static readonly Quat QuatMultiSignMask1 = new Quat(1f, 1f, -1f, -1f);

	// Token: 0x0400062D RID: 1581
	[StaticVariableRuleIgnore]
	private static readonly Quat QuatMultiSignMask2 = new Quat(-1f, 1f, 1f, -1f);

	// Token: 0x0400062E RID: 1582
	[StaticVariableRuleIgnore]
	private static readonly Quat OriginQuat1 = new Quat();

	// Token: 0x0400062F RID: 1583
	[StaticVariableRuleIgnore]
	private static readonly Quat OriginQuat2 = new Quat();

	// Token: 0x04000630 RID: 1584
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat1 = new Quat();

	// Token: 0x04000631 RID: 1585
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat2 = new Quat();

	// Token: 0x04000632 RID: 1586
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat3 = new Quat();
}
