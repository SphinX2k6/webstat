using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02000C14 RID: 3092
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MathUtils : Singleton<MathUtils>
{
	// Token: 0x06003362 RID: 13154 RVA: 0x00028BE0 File Offset: 0x00026DE0
	public bool IsNearlyEqual(double a, double b, double? tolerance = null)
	{
		double valueOrDefault = tolerance.GetValueOrDefault(1E-08);
		return Math.Abs(a - b) <= valueOrDefault;
	}

	// Token: 0x06003363 RID: 13155 RVA: 0x00028C0C File Offset: 0x00026E0C
	public bool IsNearlyZero(double value, double? tolerance = null)
	{
		double valueOrDefault = tolerance.GetValueOrDefault(1E-08);
		return Math.Abs(value) <= valueOrDefault;
	}

	// Token: 0x06003364 RID: 13156 RVA: 0x00028C36 File Offset: 0x00026E36
	public bool IsAngleNearEqual(double a, double b, double tolerance = 9.999999747378752E-05)
	{
		return Math.Abs(this.WrapAngle(a - b)) <= tolerance;
	}

	// Token: 0x06003365 RID: 13157 RVA: 0x00028C4C File Offset: 0x00026E4C
	public double Clamp(double currentValue, double min, double max)
	{
		return MathCommon.Clamp(currentValue, min, max);
	}

	// Token: 0x06003366 RID: 13158 RVA: 0x00028C56 File Offset: 0x00026E56
	public float Clamp(float currentValue, float min, float max)
	{
		return MathCommon.Clamp(currentValue, min, max);
	}

	// Token: 0x06003367 RID: 13159 RVA: 0x00028C60 File Offset: 0x00026E60
	public int Clamp(int currentValue, int min, int max)
	{
		return MathCommon.Clamp(currentValue, min, max);
	}

	// Token: 0x06003368 RID: 13160 RVA: 0x00028C6C File Offset: 0x00026E6C
	public float GetRangePct(float min, float max, float value)
	{
		float num = max - min;
		if (this.IsNearlyZero((double)num, null))
		{
			return value >= max;
		}
		return (value - min) / num;
	}

	// Token: 0x06003369 RID: 13161 RVA: 0x00028CA0 File Offset: 0x00026EA0
	public double GetRangePct(double min, double max, double value)
	{
		double num = max - min;
		if (this.IsNearlyZero(num, null))
		{
			return value >= max;
		}
		return (value - min) / num;
	}

	// Token: 0x0600336A RID: 13162 RVA: 0x00028CD4 File Offset: 0x00026ED4
	public double RangeClamp(double value, double inRangeA, double inRangeB, double outRangeA, double outRangeB)
	{
		double alpha = this.Clamp(this.GetRangePct(inRangeA, inRangeB, value), 0.0, 1.0);
		return this.Lerp(outRangeA, outRangeB, alpha);
	}

	// Token: 0x0600336B RID: 13163 RVA: 0x00028D10 File Offset: 0x00026F10
	public float RangeClamp(float value, float inRangeA, float inRangeB, float outRangeA, float outRangeB)
	{
		float alpha = this.Clamp(this.GetRangePct(inRangeA, inRangeB, value), 0f, 1f);
		return this.Lerp(outRangeA, outRangeB, alpha);
	}

	// Token: 0x0600336C RID: 13164 RVA: 0x00028D42 File Offset: 0x00026F42
	public double Lerp(double from, double to, double alpha)
	{
		return from * (1.0 - alpha) + to * alpha;
	}

	// Token: 0x0600336D RID: 13165 RVA: 0x00028D55 File Offset: 0x00026F55
	public float Lerp(float from, float to, float alpha)
	{
		return from * (1f - alpha) + to * alpha;
	}

	// Token: 0x0600336E RID: 13166 RVA: 0x00028D64 File Offset: 0x00026F64
	public double InverseLerp(double value, double min, double max)
	{
		double val = (value - min) / (max - min);
		return Math.Max(0.0, Math.Min(1.0, val));
	}

	// Token: 0x0600336F RID: 13167 RVA: 0x00028D98 File Offset: 0x00026F98
	public double LerpCubic(double p0, double t0, double p1, double t1, double alpha)
	{
		double num = alpha * alpha;
		double num2 = num * alpha;
		return (2.0 * num2 - 3.0 * num + 1.0) * p0 + (num2 - 2.0 * num + alpha) * t0 + (num2 - num) * t1 + (-2.0 * num2 + 3.0 * num) * p1;
	}

	// Token: 0x06003370 RID: 13168 RVA: 0x00028E08 File Offset: 0x00027008
	public double LerpSin(double from, double to, double alpha)
	{
		double num = Math.Sin(alpha * 3.141592653589793 / 2.0);
		return from * (1.0 - num) + to * num;
	}

	// Token: 0x06003371 RID: 13169 RVA: 0x00028E44 File Offset: 0x00027044
	public void LerpVectorOld(FVector from, FVector to, float alpha, ref FVector refVector)
	{
		float alpha2 = this.Clamp(alpha, 0f, 1f);
		refVector.X = this.Lerp(from.X, to.X, alpha2);
		refVector.Y = this.Lerp(from.Y, to.Y, alpha2);
		refVector.Z = this.Lerp(from.Z, to.Z, alpha2);
	}

	// Token: 0x06003372 RID: 13170 RVA: 0x00028EB4 File Offset: 0x000270B4
	public void LerpVector(FVectorDouble from, FVectorDouble to, float alpha, ref FVectorDouble refVector)
	{
		float num = this.Clamp(alpha, 0f, 1f);
		refVector.X = this.Lerp(from.X, to.X, (double)num);
		refVector.Y = this.Lerp(from.Y, to.Y, (double)num);
		refVector.Z = this.Lerp(from.Z, to.Z, (double)num);
	}

	// Token: 0x06003373 RID: 13171 RVA: 0x00028F24 File Offset: 0x00027124
	public void LerpDirect2dByMaxAngle(global::Vector from, global::Vector to, double zAngleScale, double maxAngle, bool invertYaw, global::Vector @out)
	{
		double angleByVector2D = this.GetAngleByVector2D(from);
		double angleByVector2D2 = this.GetAngleByVector2D(to);
		double num = Math.Asin(from.Z) * 57.295780181884766;
		double num2 = Math.Asin(to.Z) * 57.295780181884766 * zAngleScale;
		double num3;
		for (num3 = angleByVector2D2 - angleByVector2D; num3 > 180.0; num3 -= 360.0)
		{
		}
		while (-num3 > 180.0)
		{
			num3 += 360.0;
		}
		if (invertYaw)
		{
			num3 = ((num3 > 0.0) ? (num3 - 360.0) : (num3 + 360.0));
		}
		double num4 = num2 - num;
		double num5 = Math.Sqrt(num3 * num3 + num4 * num4);
		if (num5 > maxAngle)
		{
			num3 *= maxAngle / num5;
			num4 *= maxAngle / num5;
		}
		double num6 = angleByVector2D + num3;
		double num7 = (num + num4) * 0.01745329238474369;
		@out.Z = Math.Sin(num7);
		double num8 = Math.Cos(num7);
		@out.X = Math.Cos(num6 * 0.01745329238474369) * num8;
		@out.Y = Math.Sin(num6 * 0.01745329238474369) * num8;
	}

	// Token: 0x06003374 RID: 13172 RVA: 0x00029060 File Offset: 0x00027260
	public double InterpTo(double from, double to, double deltaTime, double interpSpeed)
	{
		double num = to - from;
		if (Math.Abs(num) < 9.999999747378752E-05)
		{
			return to;
		}
		return from + num * this.Clamp(deltaTime * interpSpeed, 0.0, 1.0);
	}

	// Token: 0x06003375 RID: 13173 RVA: 0x000290A4 File Offset: 0x000272A4
	public double InterpConstantTo(double from, double to, double deltaTime, double interpSpeed)
	{
		double num = to - from;
		if (Math.Abs(num) < 9.999999747378752E-05)
		{
			return to;
		}
		double num2 = deltaTime * interpSpeed;
		return from + this.Clamp(num, -num2, num2);
	}

	// Token: 0x06003376 RID: 13174 RVA: 0x000290DC File Offset: 0x000272DC
	public float InterpConstantTo(float from, float to, float deltaTime, float interpSpeed)
	{
		float num = to - from;
		if (Math.Abs(num) < 0.0001f)
		{
			return to;
		}
		float num2 = deltaTime * interpSpeed;
		return from + this.Clamp(num, -num2, num2);
	}

	// Token: 0x06003377 RID: 13175 RVA: 0x00029110 File Offset: 0x00027310
	public void VectorInterpTo(global::Vector from, global::Vector to, double deltaTime, double interpSpeed, global::Vector outResult)
	{
		to.Subtraction(from, this.TempVector);
		this.TempVector.MultiplyEqual(this.Clamp(deltaTime * interpSpeed, 0.0, 1.0));
		this.TempVector.Addition(from, outResult);
	}

	// Token: 0x06003378 RID: 13176 RVA: 0x00029164 File Offset: 0x00027364
	public void RotatorInterpTo(Rotator from, Rotator to, double deltaTime, double interpSpeed, Rotator res)
	{
		if (interpSpeed <= 0.0)
		{
			res.DeepCopy(to);
			return;
		}
		double num = interpSpeed * deltaTime;
		res.Pitch = to.Pitch - from.Pitch;
		res.Yaw = to.Yaw - from.Yaw;
		res.Roll = to.Roll - from.Roll;
		MathCommon.VectorNormalizeRotator(res);
		res.Pitch = (float)((num >= 1.0) ? ((double)res.Pitch) : ((double)res.Pitch * num));
		res.Yaw = (float)((num >= 1.0) ? ((double)res.Yaw) : ((double)res.Yaw * num));
		res.Roll = (float)((num >= 1.0) ? ((double)res.Roll) : ((double)res.Roll * num));
		res.Pitch += from.Pitch;
		res.Yaw += from.Yaw;
		res.Roll += from.Roll;
		MathCommon.VectorNormalizeRotator(res);
	}

	// Token: 0x06003379 RID: 13177 RVA: 0x0002928C File Offset: 0x0002748C
	public float RotatorAxisInterpTo(float from, float to, float deltaTime, float interpSpeed)
	{
		if (interpSpeed <= 0f)
		{
			return to;
		}
		float num = interpSpeed * deltaTime;
		float num2 = MathCommon.WrapAngle(to - from);
		num2 = ((num >= 1f) ? num2 : (num2 * num));
		num2 += from;
		return MathCommon.WrapAngle(num2);
	}

	// Token: 0x0600337A RID: 13178 RVA: 0x000292CC File Offset: 0x000274CC
	public double RotatorAxisInterpTo(double from, double to, double deltaTime, double interpSpeed)
	{
		if (interpSpeed <= 0.0)
		{
			return to;
		}
		double num = interpSpeed * deltaTime;
		double num2 = MathCommon.WrapAngle(to - from);
		num2 = ((num >= 1.0) ? num2 : (num2 * num));
		num2 += from;
		return MathCommon.WrapAngle(num2);
	}

	// Token: 0x0600337B RID: 13179 RVA: 0x00029314 File Offset: 0x00027514
	public void RotatorInterpConstantTo(Rotator from, Rotator to, float deltaTime, float interpSpeed, Rotator res)
	{
		if (deltaTime <= 0f || interpSpeed <= 0f)
		{
			res.DeepCopy(from);
			return;
		}
		float num = interpSpeed * deltaTime;
		res.Pitch = to.Pitch - from.Pitch;
		res.Yaw = to.Yaw - from.Yaw;
		res.Roll = to.Roll - from.Roll;
		MathCommon.VectorNormalizeRotator(res);
		res.Pitch = this.Clamp(res.Pitch, -num, num);
		res.Yaw = this.Clamp(res.Yaw, -num, num);
		res.Roll = this.Clamp(res.Roll, -num, num);
		res.Pitch += from.Pitch;
		res.Yaw += from.Yaw;
		res.Roll += from.Roll;
		MathCommon.VectorNormalizeRotator(res);
	}

	// Token: 0x0600337C RID: 13180 RVA: 0x0002940C File Offset: 0x0002760C
	public void RotatorInterpConstantToAvoid(Rotator from, Rotator to, float avoidYaw, float deltaTime, float interpSpeed, Rotator res)
	{
		if (deltaTime <= 0f || interpSpeed <= 0f)
		{
			res.DeepCopy(from);
			return;
		}
		float num = interpSpeed * deltaTime;
		res.Pitch = to.Pitch - from.Pitch;
		res.Yaw = to.Yaw - from.Yaw;
		res.Roll = to.Roll - from.Roll;
		MathCommon.VectorNormalizeRotator(res);
		res.Pitch = this.Clamp(res.Pitch, -num, num);
		res.Yaw = this.Clamp(res.Yaw, -num, num);
		res.Roll = this.Clamp(res.Roll, -num, num);
		res.Pitch += from.Pitch;
		res.Yaw += from.Yaw;
		res.Roll += from.Roll;
		MathCommon.VectorNormalizeRotator(res);
	}

	// Token: 0x0600337D RID: 13181 RVA: 0x00029505 File Offset: 0x00027705
	public float GetRandomFloatNumber(float min, float max)
	{
		return (float)((double)min + (double)(max - min) * this.Random.NextDouble());
	}

	// Token: 0x0600337E RID: 13182 RVA: 0x0002951B File Offset: 0x0002771B
	public double GetRandomDoubleNumber(double min, double max)
	{
		return min + (max - min) * this.Random.NextDouble();
	}

	// Token: 0x0600337F RID: 13183 RVA: 0x00029530 File Offset: 0x00027730
	public FVector GetRandomVector(float min, float max)
	{
		return new FVector
		{
			X = this.GetRandomFloatNumber(min, max),
			Y = this.GetRandomFloatNumber(min, max),
			Z = this.GetRandomFloatNumber(min, max)
		};
	}

	// Token: 0x06003380 RID: 13184 RVA: 0x00029574 File Offset: 0x00027774
	public FVectorDouble GetRandomVector(double min, double max)
	{
		return new FVectorDouble
		{
			X = this.GetRandomDoubleNumber(min, max),
			Y = this.GetRandomDoubleNumber(min, max),
			Z = this.GetRandomDoubleNumber(min, max)
		};
	}

	// Token: 0x06003381 RID: 13185 RVA: 0x000295B8 File Offset: 0x000277B8
	public FVector2D GetRandomVector2d(float min, float max)
	{
		return new FVector2D
		{
			X = this.GetRandomFloatNumber(min, max),
			Y = this.GetRandomFloatNumber(min, max)
		};
	}

	// Token: 0x06003382 RID: 13186 RVA: 0x000295EC File Offset: 0x000277EC
	public double GetAngleByVector2D(IVector vector)
	{
		float num = 0f;
		if (vector is FVector)
		{
			FVector fvector = (FVector)vector;
			this.TempVector.FromUeVector(fvector);
			num = (float)this.TempVector.HeadingAngle();
		}
		else
		{
			global::Vector vector2 = vector as global::Vector;
			if (vector2 != null)
			{
				num = (float)vector2.HeadingAngle();
			}
		}
		return (double)(num * 57.29578f);
	}

	// Token: 0x06003383 RID: 13187 RVA: 0x00029644 File Offset: 0x00027844
	public FVector GetUeVector2dByAngle(double angle)
	{
		double num = angle * 0.01745329238474369;
		return new FVector((float)Math.Cos(num), (float)Math.Sin(num), 0f);
	}

	// Token: 0x06003384 RID: 13188 RVA: 0x00029678 File Offset: 0x00027878
	public void GetVector2dByAngle(double angle, global::Vector refVector)
	{
		double num = angle * 0.01745329238474369;
		refVector.X = Math.Cos(num);
		refVector.Y = Math.Sin(num);
	}

	// Token: 0x06003385 RID: 13189 RVA: 0x000296A9 File Offset: 0x000278A9
	public bool InRange(double value, FloatRange range)
	{
		return value >= (double)range.Min && value <= (double)range.Max;
	}

	// Token: 0x06003386 RID: 13190 RVA: 0x000296C6 File Offset: 0x000278C6
	public bool InRangeArray(double value, double[] range)
	{
		return value >= range[0] && value <= range[1];
	}

	// Token: 0x06003387 RID: 13191 RVA: 0x000296DC File Offset: 0x000278DC
	public bool InRangeAngle(double value, FloatRange range)
	{
		double num = value;
		while (num + 360.0 <= (double)range.Max)
		{
			num += 360.0;
		}
		while (num - 360.0 >= (double)range.Min)
		{
			num -= 360.0;
		}
		return this.InRange(num, range);
	}

	// Token: 0x06003388 RID: 13192 RVA: 0x0002973C File Offset: 0x0002793C
	public bool InRangeAngleArray(double value, double[] range)
	{
		double num = value;
		while (num + 360.0 <= range[1])
		{
			num += 360.0;
		}
		while (num - 360.0 >= range[0])
		{
			num -= 360.0;
		}
		return this.InRangeArray(num, range);
	}

	// Token: 0x06003389 RID: 13193 RVA: 0x00029790 File Offset: 0x00027990
	public bool InUeRange(double value, FFloatRange range)
	{
		if (!((range.LowerBound.Type == ERangeBoundTypes.Exclusive) ? (value > (double)range.LowerBound.Value) : (value >= (double)range.LowerBound.Value)))
		{
			return false;
		}
		if (!(range.UpperBound.Type == ERangeBoundTypes.Exclusive))
		{
			return value <= (double)range.UpperBound.Value;
		}
		return value < (double)range.UpperBound.Value;
	}

	// Token: 0x0600338A RID: 13194 RVA: 0x00029818 File Offset: 0x00027A18
	public bool InFastUeRange(double value, FastUeFloatRange range)
	{
		if (!((range.LowerBoundType == ERangeBoundTypes.Exclusive) ? (value > range.LowerBoundValue) : (value >= range.LowerBoundValue)))
		{
			return false;
		}
		if (range.UpperBoundType != ERangeBoundTypes.Exclusive)
		{
			return value <= range.UpperBoundValue;
		}
		return value < range.UpperBoundValue;
	}

	// Token: 0x0600338B RID: 13195 RVA: 0x00029868 File Offset: 0x00027A68
	public bool InUeRangeAngle(double value, FFloatRange range)
	{
		double num = value;
		while (num + 360.0 <= (double)range.UpperBound.Value)
		{
			num += 360.0;
		}
		while (num - 360.0 >= (double)range.LowerBound.Value)
		{
			num -= 360.0;
		}
		return this.InUeRange(num, range);
	}

	// Token: 0x0600338C RID: 13196 RVA: 0x000298D0 File Offset: 0x00027AD0
	public bool InFastUeRangeAngle(double value, FastUeFloatRange range)
	{
		double num = value;
		while (num + 360.0 <= range.UpperBoundValue)
		{
			num += 360.0;
		}
		while (num - 360.0 >= range.LowerBoundValue)
		{
			num -= 360.0;
		}
		return this.InFastUeRange(num, range);
	}

	// Token: 0x0600338D RID: 13197 RVA: 0x0002992C File Offset: 0x00027B2C
	public bool LocationInRangeArray(global::Vector transformLocation, Rotator transformRotator, global::Vector location, double radius, double[] distanceRange, double[] angleRange, double[] heightRange)
	{
		this.InverseTransformPositionNoScale(transformLocation, transformRotator, location, this.TempVector);
		double z = this.TempVector.Z;
		if (!this.InRangeArray(z, heightRange))
		{
			return false;
		}
		double value = this.TempVector.Size2D() - radius;
		if (!this.InRangeArray(value, distanceRange))
		{
			return false;
		}
		double angleByVector2D = this.GetAngleByVector2D(this.TempVector);
		return this.InRangeAngleArray(angleByVector2D, angleRange);
	}

	// Token: 0x0600338E RID: 13198 RVA: 0x00029994 File Offset: 0x00027B94
	public bool LocationInUeRange(global::Vector transformLocation, Rotator transformRotator, global::Vector location, double radius, FFloatRange distanceRange, FFloatRange angleRange, FFloatRange heightRange)
	{
		this.InverseTransformPositionNoScale(transformLocation, transformRotator, location, this.TempVector);
		double z = this.TempVector.Z;
		if (!this.InUeRange(z, heightRange))
		{
			return false;
		}
		double value = this.TempVector.Size2D() - radius;
		if (!this.InUeRange(value, distanceRange))
		{
			return false;
		}
		double angleByVector2D = this.GetAngleByVector2D(this.TempVector);
		return this.InUeRangeAngle(angleByVector2D, angleRange);
	}

	// Token: 0x0600338F RID: 13199 RVA: 0x000299FC File Offset: 0x00027BFC
	public bool LocationInFastUeRange(global::Vector transformLocation, Rotator transformRotator, global::Vector location, double radius, FastUeFloatRange distanceRange, FastUeFloatRange angleRange, FastUeFloatRange heightRange)
	{
		this.InverseTransformPositionNoScale(transformLocation, transformRotator, location, this.TempVector);
		double z = this.TempVector.Z;
		if (!this.InFastUeRange(z, heightRange))
		{
			return false;
		}
		double value = Math.Max(1E-08, this.TempVector.Size2D() - radius);
		if (!this.InFastUeRange(value, distanceRange))
		{
			return false;
		}
		double angleByVector2D = this.GetAngleByVector2D(this.TempVector);
		return this.InFastUeRangeAngle(angleByVector2D, angleRange);
	}

	// Token: 0x06003390 RID: 13200 RVA: 0x00029A74 File Offset: 0x00027C74
	public float GetFloatPointFloor(float value, int digits = 0)
	{
		float num = (float)Math.Pow(10.0, (double)digits);
		return (float)Math.Floor((double)(value * num)) / num;
	}

	// Token: 0x06003391 RID: 13201 RVA: 0x00029AA0 File Offset: 0x00027CA0
	public double GetFloatPointFloor(double value, int digits = 0)
	{
		double num = Math.Pow(10.0, (double)digits);
		return Math.Floor(value * num) / num;
	}

	// Token: 0x06003392 RID: 13202 RVA: 0x00029AC8 File Offset: 0x00027CC8
	public double GetFloatPointCeil(double value, int digits = 0)
	{
		double num = Math.Pow(10.0, (double)digits);
		return Math.Ceiling(value * num) / num;
	}

	// Token: 0x06003393 RID: 13203 RVA: 0x00029AF0 File Offset: 0x00027CF0
	public double GetRoundToNDecimalPlaces(double value, int n)
	{
		double num = Math.Pow(10.0, (double)n);
		return Math.Round(value * num) / num;
	}

	// Token: 0x06003394 RID: 13204 RVA: 0x00029B18 File Offset: 0x00027D18
	public global::Vector RoundVector(global::Vector inVector, int digits)
	{
		return global::Vector.Create(this.GetRoundToNDecimalPlaces(inVector.X, digits), this.GetRoundToNDecimalPlaces(inVector.Y, digits), this.GetRoundToNDecimalPlaces(inVector.Z, digits));
	}

	// Token: 0x06003395 RID: 13205 RVA: 0x00029B48 File Offset: 0x00027D48
	public string GetFloatPointFloorString(double value, int digits = 0)
	{
		double floatPointFloor = this.GetFloatPointFloor(value, digits);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("F");
		defaultInterpolatedStringHandler.AppendFormatted<int>(digits);
		return floatPointFloor.ToString(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x06003396 RID: 13206 RVA: 0x00029B89 File Offset: 0x00027D89
	public double SafeDivide(double a, double b)
	{
		if (b == 0.0)
		{
			return 0.0;
		}
		return a / b;
	}

	// Token: 0x06003397 RID: 13207 RVA: 0x00029BA4 File Offset: 0x00027DA4
	[Obsolete("直接强转即可")]
	public long LongToBigInt(int value)
	{
		return (long)value;
	}

	// Token: 0x06003398 RID: 13208 RVA: 0x00029BA8 File Offset: 0x00027DA8
	[Obsolete("直接使用即可")]
	public long LongToBigInt(long value)
	{
		return value;
	}

	// Token: 0x06003399 RID: 13209 RVA: 0x00029BAB File Offset: 0x00027DAB
	[Obsolete("直接使用即可")]
	public long LongToNumber(long value)
	{
		return value;
	}

	// Token: 0x0600339A RID: 13210 RVA: 0x00029BAE File Offset: 0x00027DAE
	[Obsolete("直接使用即可")]
	public long NumberToLong(long value)
	{
		return value;
	}

	// Token: 0x0600339B RID: 13211 RVA: 0x00029BB1 File Offset: 0x00027DB1
	[Obsolete("直接使用即可")]
	public long BigIntToLong(long value)
	{
		return value;
	}

	// Token: 0x0600339C RID: 13212 RVA: 0x00029BB4 File Offset: 0x00027DB4
	public Number? StringToNumber(string s)
	{
		if (string.IsNullOrWhiteSpace(s))
		{
			return null;
		}
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		int value;
		if (int.TryParse(s, NumberStyles.Integer, invariantCulture, out value))
		{
			return new Number?(Number.FromInt(value));
		}
		double value2;
		if (double.TryParse(s, NumberStyles.Float, invariantCulture, out value2))
		{
			return new Number?(Number.FromDouble(value2));
		}
		return null;
	}

	// Token: 0x0600339D RID: 13213 RVA: 0x00029C18 File Offset: 0x00027E18
	public double GetRandomRange(double min, double max)
	{
		double num = max - min;
		double num2 = this.Random.NextDouble();
		return min + num2 * num;
	}

	// Token: 0x0600339E RID: 13214 RVA: 0x00029C3C File Offset: 0x00027E3C
	[NullableContext(2)]
	public T GetRandomItem<T>([Nullable(1)] IReadOnlyList<T> array)
	{
		if (array.Count == 0)
		{
			return default(T);
		}
		int index = (int)Math.Floor(this.Random.NextDouble() * (double)array.Count);
		return array[index];
	}

	// Token: 0x0600339F RID: 13215 RVA: 0x00029C7C File Offset: 0x00027E7C
	public double BlendEaseIn(double from, double to, float alpha, double exp)
	{
		double num = this.Lerp(0.0, 1.0, Math.Pow((double)alpha, exp));
		return from + (to - from) * num;
	}

	// Token: 0x060033A0 RID: 13216 RVA: 0x00029CB2 File Offset: 0x00027EB2
	public double StandardizingPitch(double pitch)
	{
		if (pitch > 180.0)
		{
			return pitch - 360.0;
		}
		if (pitch < -180.0)
		{
			return pitch + 360.0;
		}
		return pitch;
	}

	// Token: 0x060033A1 RID: 13217 RVA: 0x00029CE5 File Offset: 0x00027EE5
	public float WrapAngle(float angle)
	{
		return MathCommon.WrapAngle(angle);
	}

	// Token: 0x060033A2 RID: 13218 RVA: 0x00029CED File Offset: 0x00027EED
	public double WrapAngle(double angle)
	{
		return MathCommon.WrapAngle(angle);
	}

	// Token: 0x060033A3 RID: 13219 RVA: 0x00029CF8 File Offset: 0x00027EF8
	public double GetAngleByVectorDot(IVector inA, IVector inB)
	{
		double num = Math.Sqrt(inA.X * inA.X + inA.Y * inA.Y + inA.Z * inA.Z);
		double num2 = Math.Sqrt(inB.X * inB.X + inB.Y * inB.Y + inB.Z * inB.Z);
		return Math.Acos(MathCommon.Clamp(this.DotProduct(inA, inB) / (num * num2), -1.0, 1.0)) * 57.295780181884766;
	}

	// Token: 0x060033A4 RID: 13220 RVA: 0x00029D98 File Offset: 0x00027F98
	public double SignedAngleDeg(IVector inA, IVector inB, bool yDown = false)
	{
		double y = inA.X * inB.Y - inA.Y * inB.X;
		double x = inA.X * inB.X + inA.Y * inB.Y;
		double num = Math.Atan2(y, x) * 57.295780181884766;
		if (yDown)
		{
			num = -num;
		}
		return num;
	}

	// Token: 0x060033A5 RID: 13221 RVA: 0x00029DF4 File Offset: 0x00027FF4
	public double SignedAngleOnPlaneDeg(IVector inA, IVector inB, IVector inN)
	{
		double num = Math.Sqrt(inN.X * inN.X + inN.Y * inN.Y + inN.Z * inN.Z);
		if (num < 9.999999747378752E-05)
		{
			return 0.0;
		}
		double num2 = inN.X / num;
		double num3 = inN.Y / num;
		double num4 = inN.Z / num;
		double num5 = inA.X * num2 + inA.Y * num3 + inA.Z * num4;
		double num6 = inB.X * num2 + inB.Y * num3 + inB.Z * num4;
		double num7 = inA.X - num5 * num2;
		double num8 = inA.Y - num5 * num3;
		double num9 = inA.Z - num5 * num4;
		double num10 = inB.X - num6 * num2;
		double num11 = inB.Y - num6 * num3;
		double num12 = inB.Z - num6 * num4;
		double x = num7 * num10 + num8 * num11 + num9 * num12;
		double num13 = num8 * num12 - num9 * num11;
		double num14 = num9 * num10 - num7 * num12;
		double num15 = num7 * num11 - num8 * num10;
		return Math.Atan2(num2 * num13 + num3 * num14 + num4 * num15, x) * 57.295780181884766;
	}

	// Token: 0x060033A6 RID: 13222 RVA: 0x00029F40 File Offset: 0x00028140
	public double DotProduct(IVector inA, IVector inB)
	{
		return inA.X * inB.X + inA.Y * inB.Y + inA.Z * inB.Z;
	}

	// Token: 0x060033A7 RID: 13223 RVA: 0x00029F6C File Offset: 0x0002816C
	public void ComposeRotator(Rotator a, Rotator b, object @out)
	{
		Quat inQ = a.Quaternion(null);
		Quat quat = b.Quaternion(null);
		Quat quat2 = @out as Quat;
		if (quat2 != null)
		{
			quat.Multiply(inQ, quat2);
			return;
		}
		Rotator rotator = @out as Rotator;
		if (rotator != null)
		{
			quat.Multiply(inQ, this.TmpQuat);
			this.TmpQuat.Rotator(rotator);
		}
	}

	// Token: 0x060033A8 RID: 13224 RVA: 0x00029FC0 File Offset: 0x000281C0
	public IRotator VectorToRotator(IVector inA, IRotator @out)
	{
		@out.Yaw = (float)(Math.Atan2(inA.Y, inA.X) * 57.295780181884766);
		@out.Pitch = (float)(Math.Atan2(inA.Z, Math.Sqrt(inA.X * inA.X + inA.Y * inA.Y)) * 57.295780181884766);
		@out.Roll = 0f;
		return @out;
	}

	// Token: 0x060033A9 RID: 13225 RVA: 0x0002A038 File Offset: 0x00028238
	public IVector RotatorToVector(IRotator inA, IVector @out)
	{
		double degVal = (double)MathCommon.WrapAngle(inA.Pitch);
		double degVal2 = (double)MathCommon.WrapAngle(inA.Yaw);
		double num = MathCommon.DegreeToRadian(degVal);
		double num2 = MathCommon.DegreeToRadian(degVal2);
		double num3 = Math.Cos(num);
		double z = Math.Sin(num);
		double num4 = Math.Cos(num2);
		double num5 = Math.Sin(num2);
		@out.X = num3 * num4;
		@out.Y = num3 * num5;
		@out.Z = z;
		return @out;
	}

	// Token: 0x060033AA RID: 13226 RVA: 0x0002A0A4 File Offset: 0x000282A4
	public double Bisection(TCheck<double> check, double left, double right, double limit)
	{
		double num = left;
		double num2 = right;
		while (num2 - num > limit)
		{
			double num3 = (num + num2) / 2.0;
			if (check(num3))
			{
				num2 = num3;
			}
			else
			{
				num = num3 + limit;
			}
		}
		return num;
	}

	// Token: 0x060033AB RID: 13227 RVA: 0x0002A0DF File Offset: 0x000282DF
	public double Square(double v)
	{
		return v * v;
	}

	// Token: 0x060033AC RID: 13228 RVA: 0x0002A0E4 File Offset: 0x000282E4
	public void TransformPosition(global::Vector translation, Rotator rotation, global::Vector scale3D, global::Vector v, global::Vector @out)
	{
		scale3D.Multiply(v, @out);
		rotation.Quaternion(null).RotateVector(@out, @out);
		translation.Addition(@out, @out);
	}

	// Token: 0x060033AD RID: 13229 RVA: 0x0002A10C File Offset: 0x0002830C
	public void TransformPositionNoScale(global::Vector translation, Rotator rotation, global::Vector v, global::Vector @out)
	{
		rotation.Quaternion(null).RotateVector(v, @out);
		translation.Addition(@out, @out);
	}

	// Token: 0x060033AE RID: 13230 RVA: 0x0002A128 File Offset: 0x00028328
	public void InverseTransformPosition(global::Vector translation, Rotator rotation, global::Vector scale3D, global::Vector v, global::Vector @out)
	{
		v.Subtraction(translation, @out);
		rotation.Quaternion(this.TmpQuat);
		this.TmpQuat.Inverse(this.TmpQuat);
		this.TmpQuat.RotateVector(@out, @out);
		scale3D.Multiply(@out, @out);
	}

	// Token: 0x060033AF RID: 13231 RVA: 0x0002A178 File Offset: 0x00028378
	public void InverseTransformPositionNoScale(global::Vector translation, Rotator rotation, global::Vector v, global::Vector @out)
	{
		v.Subtraction(translation, @out);
		rotation.Quaternion(this.TmpQuat);
		this.TmpQuat.Inverse(this.TmpQuat);
		this.TmpQuat.RotateVector(@out, @out);
	}

	// Token: 0x060033B0 RID: 13232 RVA: 0x0002A1B4 File Offset: 0x000283B4
	private double[][] GetRotArray()
	{
		if (this.RotArray == null)
		{
			int num = 3;
			this.RotArray = new double[num][];
			this.RotArray[0] = new double[num];
			this.RotArray[1] = new double[num];
			this.RotArray[2] = new double[num];
		}
		return this.RotArray;
	}

	// Token: 0x060033B1 RID: 13233 RVA: 0x0002A208 File Offset: 0x00028408
	private double[] GetTmpArray()
	{
		if (this.TmpArray == null)
		{
			int num = 3;
			this.TmpArray = new double[num];
		}
		return this.TmpArray;
	}

	// Token: 0x060033B2 RID: 13234 RVA: 0x0002A234 File Offset: 0x00028434
	public void LookRotation(global::Vector forward, global::Vector right, global::Vector up, Quat @out)
	{
		double num = forward.X + right.Y + up.Z;
		if (num > 0.0)
		{
			num += 1.0;
			double num2 = 0.5 / Math.Sqrt(num);
			double num3 = num2 * num;
			double num4 = (right.Z - up.Y) * num2;
			double num5 = (up.X - forward.Z) * num2;
			double num6 = (forward.Y - right.X) * num2;
			@out.Set((float)num4, (float)num5, (float)num6, (float)num3);
			@out.Normalize(1E-06f);
			return;
		}
		double[][] rotArray = this.GetRotArray();
		rotArray[0][0] = forward.X;
		rotArray[0][1] = right.X;
		rotArray[0][2] = up.X;
		rotArray[1][0] = forward.Y;
		rotArray[1][1] = right.Y;
		rotArray[1][2] = up.Y;
		rotArray[2][0] = forward.Z;
		rotArray[2][1] = right.Z;
		rotArray[2][2] = up.Z;
		double[] tmpArray = this.GetTmpArray();
		int num7 = 0;
		if (right.Y > forward.Y)
		{
			num7 = 1;
		}
		if (up.Z > rotArray[num7][num7])
		{
			num7 = 2;
		}
		int num8 = 3;
		int num9 = (num7 + 1) % num8;
		int num10 = (num9 + 1) % num8;
		num = rotArray[num7][num7] - rotArray[num9][num9] - rotArray[num10][num10] + 1.0;
		double num11 = 0.5 / Math.Sqrt(num);
		tmpArray[num7] = num11 * num;
		double num12 = (rotArray[num10][num9] - rotArray[num9][num10]) * num11;
		tmpArray[num9] = (rotArray[num9][num7] + rotArray[num7][num9]) * num11;
		tmpArray[num10] = (rotArray[num10][num7] + rotArray[num7][num10]) * num11;
		@out.Set((float)tmpArray[0], (float)tmpArray[1], (float)tmpArray[2], (float)num12);
		@out.Normalize(1E-06f);
	}

	// Token: 0x060033B3 RID: 13235 RVA: 0x0002A43C File Offset: 0x0002863C
	public void LookRotationUpFirst(global::Vector forward, global::Vector up, [Nullable(2)] object @out)
	{
		global::Vector tempVector = this.TempVector;
		tempVector.FromUeVector(up);
		tempVector.Normalize(9.99999993922529E-09);
		global::Vector tempVector2 = this.TempVector2;
		tempVector.CrossProduct(forward, tempVector2);
		tempVector2.Normalize(9.99999993922529E-09);
		global::Vector tempVector3 = this.TempVector3;
		tempVector2.CrossProduct(tempVector, tempVector3);
		Quat quat = @out as Quat;
		if (quat != null)
		{
			this.LookRotation(tempVector3, tempVector2, tempVector, quat);
			return;
		}
		Rotator rotator = @out as Rotator;
		if (rotator != null)
		{
			this.LookRotation(tempVector3, tempVector2, tempVector, this.TmpQuat);
			this.TmpQuat.Rotator(rotator);
		}
	}

	// Token: 0x060033B4 RID: 13236 RVA: 0x0002A4D4 File Offset: 0x000286D4
	public void LookRotationForwardFirst(global::Vector forward, global::Vector up, object @out)
	{
		global::Vector tempVector = this.TempVector;
		tempVector.FromUeVector(forward);
		tempVector.Normalize(9.99999993922529E-09);
		global::Vector tempVector2 = this.TempVector2;
		up.CrossProduct(tempVector, tempVector2);
		tempVector2.Normalize(9.99999993922529E-09);
		global::Vector tempVector3 = this.TempVector3;
		tempVector.CrossProduct(tempVector2, tempVector3);
		Quat quat = @out as Quat;
		if (quat != null)
		{
			this.LookRotation(tempVector, tempVector2, tempVector3, quat);
			return;
		}
		Rotator rotator = @out as Rotator;
		if (rotator != null)
		{
			this.LookRotation(tempVector, tempVector2, tempVector3, this.TmpQuat);
			this.TmpQuat.Rotator(rotator);
		}
	}

	// Token: 0x060033B5 RID: 13237 RVA: 0x0002A56B File Offset: 0x0002876B
	public double GetCubicValue(double t)
	{
		return (-2.0 * t + 3.0) * t * t;
	}

	// Token: 0x060033B6 RID: 13238 RVA: 0x0002A588 File Offset: 0x00028788
	public string DecimalToBinary(int inDecimal)
	{
		int i = inDecimal;
		string text;
		if (i < 0)
		{
			text = "-";
			i = 0 - i;
		}
		else
		{
			if (i == 0)
			{
				return "0";
			}
			text = "+";
		}
		global::Stack<int> stack = new global::Stack<int>();
		while (i > 0)
		{
			stack.Push((int)Math.Floor((double)(i % 2)));
			i = (int)Math.Floor((double)(i / 2));
		}
		int size = stack.Size;
		for (int j = 0; j < size; j++)
		{
			text += stack.Pop().ToString();
		}
		return text;
	}

	// Token: 0x060033B7 RID: 13239 RVA: 0x0002A611 File Offset: 0x00028811
	public double GetObliqueTriangleAngle(double a, double b, double c)
	{
		return Math.Acos((a * a + b * b - c * c) / (2.0 * a * b));
	}

	// Token: 0x060033B8 RID: 13240 RVA: 0x0002A634 File Offset: 0x00028834
	public double GetTriangleCircumradius(double a, double b, double c)
	{
		double num = (a + b + c) / 2.0;
		return a * b * c / (4.0 * Math.Sqrt(num * (num - a) * (num - b) * (num - c)));
	}

	// Token: 0x060033B9 RID: 13241 RVA: 0x0002A673 File Offset: 0x00028873
	public double VerticalFovToHorizontally(double verticalFov, double aspectRatio)
	{
		return Math.Atan(Math.Tan(verticalFov / 2.0 * 0.01745329238474369) * aspectRatio) * 2.0 * 57.295780181884766;
	}

	// Token: 0x060033BA RID: 13242 RVA: 0x0002A6AA File Offset: 0x000288AA
	public double HorizontalFovToVertically(double horizontalFov, double aspectRatio)
	{
		return Math.Atan(Math.Tan(horizontalFov / 2.0 * 0.01745329238474369) / aspectRatio) * 2.0 * 57.295780181884766;
	}

	// Token: 0x060033BB RID: 13243 RVA: 0x0002A6E1 File Offset: 0x000288E1
	public bool IsValidNumber(double num)
	{
		return !double.IsNaN(num) && double.IsFinite(num);
	}

	// Token: 0x060033BC RID: 13244 RVA: 0x0002A6F8 File Offset: 0x000288F8
	public bool IsValidNumbers(double x, double y, double z, int maxAbs = 100000000)
	{
		return !double.IsNaN(x) && !double.IsNaN(y) && !double.IsNaN(z) && double.IsFinite(x) && double.IsFinite(y) && double.IsFinite(z) && (Math.Abs(x) < (double)maxAbs || Math.Abs(x) == double.MaxValue) && (Math.Abs(y) < (double)maxAbs || Math.Abs(y) == double.MaxValue) && (Math.Abs(z) < (double)maxAbs || Math.Abs(z) == double.MaxValue);
	}

	// Token: 0x060033BD RID: 13245 RVA: 0x0002A790 File Offset: 0x00028990
	[NullableContext(2)]
	public bool IsValidVector(IVector vector, int maxAbs = 100000000)
	{
		if (vector == null)
		{
			return false;
		}
		double x = vector.X;
		double y = vector.Y;
		double z = vector.Z;
		return !double.IsNaN(x) && !double.IsNaN(y) && !double.IsNaN(z) && double.IsFinite(x) && double.IsFinite(y) && double.IsFinite(z) && (Math.Abs(x) < (double)maxAbs || Math.Abs(x) == double.MaxValue) && (Math.Abs(y) < (double)maxAbs || Math.Abs(y) == double.MaxValue) && (Math.Abs(z) < (double)maxAbs || Math.Abs(z) == double.MaxValue);
	}

	// Token: 0x060033BE RID: 13246 RVA: 0x0002A840 File Offset: 0x00028A40
	[NullableContext(2)]
	public bool IsValidRotator(IRotator rotator, int maxAbs = 100000000)
	{
		if (rotator == null)
		{
			return false;
		}
		double num = (double)rotator.Roll;
		double num2 = (double)rotator.Pitch;
		double num3 = (double)rotator.Yaw;
		return !double.IsNaN(num) && !double.IsNaN(num2) && !double.IsNaN(num3) && double.IsFinite(num) && double.IsFinite(num2) && double.IsFinite(num3) && (Math.Abs(num) < (double)maxAbs || Math.Abs(num) == double.MaxValue) && (Math.Abs(num2) < (double)maxAbs || Math.Abs(num2) == double.MaxValue) && (Math.Abs(num3) < (double)maxAbs || Math.Abs(num3) == double.MaxValue);
	}

	// Token: 0x060033BF RID: 13247 RVA: 0x0002A8F4 File Offset: 0x00028AF4
	[NullableContext(2)]
	public bool IsValidQuat(IQuat quat, int maxAbs = 100000000)
	{
		if (quat == null)
		{
			return false;
		}
		double num = (double)quat.X;
		double num2 = (double)quat.Y;
		double num3 = (double)quat.Z;
		double num4 = (double)quat.W;
		return !double.IsNaN(num) && !double.IsNaN(num2) && !double.IsNaN(num3) && !double.IsNaN(num4) && double.IsFinite(num) && double.IsFinite(num2) && double.IsFinite(num3) && double.IsFinite(num4) && (Math.Abs(num) < (double)maxAbs || Math.Abs(num) == double.MaxValue) && (Math.Abs(num2) < (double)maxAbs || Math.Abs(num2) == double.MaxValue) && (Math.Abs(num3) < (double)maxAbs || Math.Abs(num3) == double.MaxValue) && (Math.Abs(num4) < (double)maxAbs || Math.Abs(num4) == double.MaxValue);
	}

	// Token: 0x060033C0 RID: 13248 RVA: 0x0002A9DC File Offset: 0x00028BDC
	public bool LinePlaneIntersectionOriginNormal(global::Vector lineStart, global::Vector lineEnd, global::Vector planeOrigin, global::Vector planeNormal, global::Vector outIntersection)
	{
		lineEnd.Subtraction(lineStart, this.TempVector);
		global::Vector tempVector = this.TempVector;
		double num = tempVector.DotProduct(planeNormal);
		if (num == 0.0)
		{
			outIntersection.Reset();
			return false;
		}
		planeOrigin.Subtraction(lineStart, this.TempVector2);
		double num2 = this.TempVector2.DotProduct(planeNormal) / num;
		if (num2 < 0.0 || num2 > 1.0)
		{
			outIntersection.Reset();
			return false;
		}
		lineStart.Addition(tempVector.Multiply(num2, this.TempVector3), outIntersection);
		return true;
	}

	// Token: 0x060033C1 RID: 13249 RVA: 0x0002AA88 File Offset: 0x00028C88
	public bool IsLocationInsideCone(global::Vector coneLocation, global::Vector coneDirection, double coneHeight, double coneRadius, global::Vector point)
	{
		point.Subtraction(coneLocation, this.TempVector);
		double num = this.DotProduct(this.TempVector, coneDirection);
		if (num < 0.0 || num > coneHeight)
		{
			return false;
		}
		double num2 = num / coneHeight * coneRadius;
		coneDirection.Multiply(num, this.TempVector2);
		this.TempVector.Subtraction(this.TempVector2, this.TempVector2);
		return this.TempVector2.SizeSquared() <= num2 * num2;
	}

	// Token: 0x060033C2 RID: 13250 RVA: 0x0002AB04 File Offset: 0x00028D04
	public void SqInterpToVector(global::Vector from, global::Vector to, float maxAngle, global::Vector @out)
	{
		float num = (float)(Math.Acos(from.DotProduct(to)) * 57.295780181884766);
		if (num < maxAngle)
		{
			@out.DeepCopy(to);
			return;
		}
		Quat.FindBetween(from, to, this.TmpQuat);
		Quat.Slerp(Quat.IdentityProxy, this.TmpQuat, maxAngle / num, this.TmpQuat);
		this.TmpQuat.RotateVector(from, @out);
	}

	// Token: 0x060033C3 RID: 13251 RVA: 0x0002AB6A File Offset: 0x00028D6A
	public void SqLerpVector(global::Vector from, global::Vector to, float alpha, global::Vector @out)
	{
		Quat.FindBetween(from, to, this.TmpQuat);
		Quat.Slerp(Quat.IdentityProxy, this.TmpQuat, alpha, this.TmpQuat);
		this.TmpQuat.RotateVector(from, @out);
	}

	// Token: 0x060033C4 RID: 13252 RVA: 0x0002ABA0 File Offset: 0x00028DA0
	public double ClampAngle(double angleDeg, double minAngleDeg, double maxAngleDeg)
	{
		double num = Rotator.ClampAxis(maxAngleDeg - minAngleDeg) * 0.5;
		double num2 = Rotator.ClampAxis(minAngleDeg + num);
		double num3 = Rotator.NormalizeAxis(angleDeg - num2);
		if (num3 > num)
		{
			return Rotator.NormalizeAxis(num2 + num);
		}
		if (num3 < -num)
		{
			return Rotator.NormalizeAxis(num2 - num);
		}
		return Rotator.NormalizeAxis(angleDeg);
	}

	// Token: 0x060033C5 RID: 13253 RVA: 0x0002ABF4 File Offset: 0x00028DF4
	[Conditional("DEBUG")]
	public void CheckNanObject(object obj, ref bool outHasNan, [Nullable(new byte[]
	{
		2,
		1
	})] ref List<string> outPaths, int maxDepth = 100)
	{
		MathUtils.<>c__DisplayClass129_0 CS$<>8__locals1;
		CS$<>8__locals1.maxDepth = maxDepth;
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.visited = new HashSet<object>(ReferenceEqualityComparer.Instance);
		CS$<>8__locals1.hasNan = false;
		CS$<>8__locals1.paths = new List<string>();
		this.<CheckNanObject>g__Traverse|129_0(obj, new List<string>(), 0, ref CS$<>8__locals1);
		outHasNan = CS$<>8__locals1.hasNan;
		outPaths = CS$<>8__locals1.paths;
	}

	// Token: 0x060033C6 RID: 13254 RVA: 0x0002AC58 File Offset: 0x00028E58
	public T[] Shuffle<[Nullable(2)] T>(T[] array)
	{
		for (int i = array.Length - 1; i > 0; i--)
		{
			int num = (int)Math.Floor(this.Random.NextDouble() * (double)(i + 1));
			int num2 = i;
			int num3 = num;
			T t = array[num];
			T t2 = array[i];
			array[num2] = t;
			array[num3] = t2;
		}
		return array;
	}

	// Token: 0x060033C7 RID: 13255 RVA: 0x0002ACBC File Offset: 0x00028EBC
	public FBox BoxUnion(FBox a, FVector b)
	{
		if (a.IsValid != 0)
		{
			a.Min = new FVector(Math.Min(a.Min.X, b.X), Math.Min(a.Min.Y, b.Y), Math.Min(a.Min.Z, b.Z));
			a.Max = new FVector(Math.Max(a.Max.X, b.X), Math.Max(a.Max.Y, b.Y), Math.Max(a.Max.Z, b.Z));
		}
		else
		{
			a.Min = b;
			a.Max = b;
			a.IsValid = 1;
		}
		return a;
	}

	// Token: 0x060033C8 RID: 13256 RVA: 0x0002AD8C File Offset: 0x00028F8C
	public FBoxSphereBounds BoxSphereBoundsUnion(FBoxSphereBounds a, FBoxSphereBounds b)
	{
		FBox a2 = new FBox();
		a2 = this.BoxUnion(a2, a.Origin - a.BoxExtent);
		a2 = this.BoxUnion(a2, a.Origin + a.BoxExtent);
		a2 = this.BoxUnion(a2, b.Origin - b.BoxExtent);
		a2 = this.BoxUnion(a2, b.Origin + b.BoxExtent);
		FBoxSphereBounds fboxSphereBounds = new FBoxSphereBounds();
		FVector fvector = a2.Max - a2.Min;
		fboxSphereBounds.BoxExtent = fvector * 0.5f;
		fboxSphereBounds.Origin = a2.Min + fboxSphereBounds.BoxExtent;
		fboxSphereBounds.SphereRadius = fboxSphereBounds.BoxExtent.Size();
		float sphereRadius = fboxSphereBounds.SphereRadius;
		fvector = a.Origin - fboxSphereBounds.Origin;
		float val = fvector.Size() + a.SphereRadius;
		fvector = b.Origin - fboxSphereBounds.Origin;
		fboxSphereBounds.SphereRadius = Math.Min(sphereRadius, Math.Max(val, fvector.Size() + b.SphereRadius));
		return fboxSphereBounds;
	}

	// Token: 0x060033C9 RID: 13257 RVA: 0x0002AEC4 File Offset: 0x000290C4
	public bool IsInSideBox(FBox box, FVector point)
	{
		return point.X > box.Min.X && point.X < box.Max.X && point.Y > box.Min.Y && point.Y < box.Max.Y && point.Z > box.Min.Z && point.Z < box.Max.Z;
	}

	// Token: 0x060033CA RID: 13258 RVA: 0x0002AF48 File Offset: 0x00029148
	public FBox BoxSphereBoundsGetBox(FBoxSphereBounds bounds)
	{
		FVector fvector = bounds.Origin - bounds.BoxExtent;
		FVector fvector2 = bounds.Origin + bounds.BoxExtent;
		return new FBox(ref fvector, ref fvector2);
	}

	// Token: 0x060033CB RID: 13259 RVA: 0x0002AF88 File Offset: 0x00029188
	public bool IsInsideSphere(FVector center, double radius, FVector point, double tolerance = 9.999999747378752E-05)
	{
		return (double)(center - point).SizeSquared() <= Math.Pow(radius + tolerance, 2.0);
	}

	// Token: 0x060033CC RID: 13260 RVA: 0x0002AFBE File Offset: 0x000291BE
	public bool IsInsideBoxSphereBounds(FBoxSphereBounds bounds, FVector point)
	{
		return this.IsInsideSphere(bounds.Origin, (double)bounds.SphereRadius, point, 9.999999747378752E-05) && this.IsInSideBox(this.BoxSphereBoundsGetBox(bounds), point);
	}

	// Token: 0x060033CD RID: 13261 RVA: 0x0002AFEF File Offset: 0x000291EF
	public bool IsAngleInRange(double angle, double left, double right)
	{
		if (left <= right)
		{
			return angle >= left && angle <= right;
		}
		return angle >= left || angle <= right;
	}

	// Token: 0x060033CE RID: 13262 RVA: 0x0002B010 File Offset: 0x00029210
	public double NormalizeDeg180(double a)
	{
		double num = a % 360.0;
		if (num > 180.0)
		{
			num -= 360.0;
		}
		else if (num < -180.0)
		{
			num += 360.0;
		}
		return num;
	}

	// Token: 0x060033CF RID: 13263 RVA: 0x0002B05C File Offset: 0x0002925C
	public double VectorDistanceSquared(IVector v1, IVector v2)
	{
		return Math.Pow(v2.X - v1.X, 2.0) + Math.Pow(v2.Y - v1.Y, 2.0) + Math.Pow(v2.Z - v1.Z, 2.0);
	}

	// Token: 0x060033D0 RID: 13264 RVA: 0x0002B0BC File Offset: 0x000292BC
	public double VectorDistance(IVector v1, IVector v2)
	{
		return Math.Sqrt(this.VectorDistanceSquared(v1, v2));
	}

	// Token: 0x060033D1 RID: 13265 RVA: 0x0002B0CC File Offset: 0x000292CC
	private global::Vector GetTmpVector()
	{
		global::Vector vector = null;
		if (this.TmpVectorCache.Count > 0)
		{
			vector = this.TmpVectorCache[this.TmpVectorCache.Count - 1];
			this.TmpVectorCache.RemoveAt(this.TmpVectorCache.Count - 1);
			if (vector != null)
			{
				vector.Reset();
			}
		}
		if (vector == null)
		{
			vector = global::Vector.Create();
		}
		return vector;
	}

	// Token: 0x060033D2 RID: 13266 RVA: 0x0002B12D File Offset: 0x0002932D
	private void PutTmpVector(global::Vector tmpVec)
	{
		tmpVec.Reset();
		this.TmpVectorCache.Add(tmpVec);
	}

	// Token: 0x060033D3 RID: 13267 RVA: 0x0002B144 File Offset: 0x00029344
	private Rotator GetTmpRotator()
	{
		Rotator rotator = null;
		if (this.TmpRotatorCache.Count > 0)
		{
			rotator = this.TmpRotatorCache[this.TmpRotatorCache.Count - 1];
			this.TmpRotatorCache.RemoveAt(this.TmpRotatorCache.Count - 1);
			if (rotator != null)
			{
				rotator.Reset();
			}
		}
		if (rotator == null)
		{
			rotator = Rotator.Create();
		}
		return rotator;
	}

	// Token: 0x060033D4 RID: 13268 RVA: 0x0002B1A5 File Offset: 0x000293A5
	private void PutTmpRotator(Rotator tmpRot)
	{
		tmpRot.Reset();
		this.TmpRotatorCache.Add(tmpRot);
	}

	// Token: 0x060033D5 RID: 13269 RVA: 0x0002B1BC File Offset: 0x000293BC
	public void ExecWithTmpVectorAndRotator(int vectorNum, int rotatorNum, Action<List<global::Vector>, List<Rotator>> func)
	{
		List<global::Vector> list = new List<global::Vector>();
		List<Rotator> list2 = new List<Rotator>();
		for (int i = 0; i < vectorNum; i++)
		{
			list.Add(this.GetTmpVector());
		}
		for (int j = 0; j < rotatorNum; j++)
		{
			list2.Add(this.GetTmpRotator());
		}
		func(list, list2);
		for (int k = 0; k < vectorNum; k++)
		{
			this.PutTmpVector(list[k]);
		}
		for (int l = 0; l < rotatorNum; l++)
		{
			this.PutTmpRotator(list2[l]);
		}
	}

	// Token: 0x060033D6 RID: 13270 RVA: 0x0002B24C File Offset: 0x0002944C
	public Vector2D GetSpiralGrid(int testIndex, int totalN)
	{
		int num = testIndex;
		if (num >= totalN)
		{
			num %= totalN;
		}
		int num2 = (int)Math.Ceiling((Math.Sqrt((double)totalN) + 1.0) / 2.0);
		int i = 0;
		int num3 = 0;
		while (i < num2)
		{
			int num4;
			if (i == 0)
			{
				num4 = 1;
			}
			else
			{
				num4 = 8 * i;
			}
			if (num < num3 + num4)
			{
				break;
			}
			num3 += num4;
			i++;
		}
		int num5 = num - num3;
		int num6 = 0;
		int num7 = 0;
		if (i == 0)
		{
			num6 = 0;
			num7 = 0;
		}
		else
		{
			int num8 = i * 2;
			int num9 = (int)Math.Floor((double)num5 / (double)num8);
			int num10 = num5 % num8;
			if (num9 == 0)
			{
				num6 = -i + num10;
				num7 = -i;
			}
			else if (num9 == 1)
			{
				num6 = i;
				num7 = -i + num10;
			}
			else if (num9 == 2)
			{
				num6 = i - num10;
				num7 = i;
			}
			else if (num9 == 3)
			{
				num6 = -i;
				num7 = i - num10;
			}
		}
		return new Vector2D((double)num6, (double)num7);
	}

	// Token: 0x060033D7 RID: 13271 RVA: 0x0002B32C File Offset: 0x0002952C
	public Vector2D GetSequentialGrid(int testIndex, int totalN = 25, int xMax = 5)
	{
		int num = testIndex % totalN;
		if (num < 0)
		{
			num += totalN;
		}
		return new Vector2D((double)(num % xMax), (double)((int)Math.Floor((double)num / (double)xMax)));
	}

	// Token: 0x060033D8 RID: 13272 RVA: 0x0002B35C File Offset: 0x0002955C
	public int[] GenerateUniqueRandomNumbers(int min = 0, int max = 30)
	{
		if (min > max)
		{
			int num = max;
			max = min;
			min = num;
		}
		List<int> list = new List<int>();
		for (int i = min; i <= max; i++)
		{
			list.Add(i);
		}
		for (int j = list.Count - 1; j > 0; j--)
		{
			int num2 = (int)Math.Floor(this.Random.NextDouble() * (double)(j + 1));
			List<int> list2 = list;
			int index = j;
			List<int> list3 = list;
			int index2 = num2;
			int value = list[num2];
			int value2 = list[j];
			list2[index] = value;
			list3[index2] = value2;
		}
		return list.ToArray();
	}

	// Token: 0x060033D9 RID: 13273 RVA: 0x0002B3F0 File Offset: 0x000295F0
	public global::Vector GetGravityPointOfPoints(global::Vector[] points)
	{
		if (points.Length == 0)
		{
			return global::Vector.Create(0.0, 0.0, 0.0);
		}
		global::Vector vector = global::Vector.Create(0.0, 0.0, 0.0);
		foreach (global::Vector vector2 in points)
		{
			vector.X += vector2.X;
			vector.Y += vector2.Y;
			vector.Z += vector2.Z;
		}
		vector.X /= (double)points.Length;
		vector.Y /= (double)points.Length;
		vector.Z /= (double)points.Length;
		return vector;
	}

	// Token: 0x060033DA RID: 13274 RVA: 0x0002B4C4 File Offset: 0x000296C4
	public global::Vector GetCenterOfPoints(global::Vector[] points)
	{
		this.TempVector.DeepCopy(points[0]);
		this.TempVector2.DeepCopy(points[0]);
		global::Vector tempVector = this.TempVector;
		global::Vector tempVector2 = this.TempVector2;
		foreach (global::Vector vector in points)
		{
			tempVector.X = Math.Min(tempVector.X, vector.X);
			tempVector.Y = Math.Min(tempVector.Y, vector.Y);
			tempVector.Z = Math.Min(tempVector.Z, vector.Z);
			tempVector2.X = Math.Max(tempVector2.X, vector.X);
			tempVector2.Y = Math.Max(tempVector2.Y, vector.Y);
			tempVector2.Z = Math.Max(tempVector2.Z, vector.Z);
		}
		return global::Vector.Create((tempVector.X + tempVector2.X) / 2.0, (tempVector.Y + tempVector2.Y) / 2.0, (tempVector.Z + tempVector2.Z) / 2.0);
	}

	// Token: 0x060033DB RID: 13275 RVA: 0x0002B5E8 File Offset: 0x000297E8
	public global::Vector GetNextPointWithDistance(global::Vector p0, global::Vector p1, double distance)
	{
		global::Vector vector = global::Vector.Create(p0);
		global::Vector tempVector = this.TempVector;
		tempVector.DeepCopy(p1);
		tempVector.SubtractionEqual(vector).Normalize(9.99999993922529E-09);
		return vector.AdditionEqual(tempVector.MultiplyEqual(distance));
	}

	// Token: 0x060033DC RID: 13276 RVA: 0x0002B62D File Offset: 0x0002982D
	public double ClampedAsin(double d)
	{
		return Math.Asin(MathCommon.Clamp(d, -1.0, 1.0));
	}

	// Token: 0x060033DD RID: 13277 RVA: 0x0002B64C File Offset: 0x0002984C
	public double ClampedAcos(double d)
	{
		return Math.Acos(MathCommon.Clamp(d, -1.0, 1.0));
	}

	// Token: 0x060033DF RID: 13279 RVA: 0x0002B744 File Offset: 0x00029944
	[CompilerGenerated]
	private void <CheckNanObject>g__Traverse|129_0(object value, List<string> currentPath, int depth, ref MathUtils.<>c__DisplayClass129_0 A_4)
	{
		if (depth >= A_4.maxDepth)
		{
			return;
		}
		if (value == null || (value == null && !(value is double)))
		{
			return;
		}
		if (A_4.visited.Contains(value))
		{
			return;
		}
		if (value is double)
		{
			double num = (double)value;
			if (!this.IsValidNumber(num))
			{
				A_4.hasNan = true;
				A_4.paths.Add(string.Join(".", currentPath) + ": " + num.ToString());
			}
			return;
		}
		global::Vector vector = value as global::Vector;
		if (vector != null)
		{
			if (!this.IsValidVector(vector, 999999999))
			{
				A_4.hasNan = true;
				A_4.paths.Add(string.Join(".", currentPath) + ": " + vector.ToString());
			}
		}
		else
		{
			Rotator rotator = value as Rotator;
			if (rotator != null)
			{
				if (!this.IsValidRotator(rotator, 999999999))
				{
					A_4.hasNan = true;
					A_4.paths.Add(string.Join(".", currentPath) + ": " + rotator.ToString());
				}
			}
			else
			{
				Quat quat = value as Quat;
				if (quat != null && !this.IsValidQuat(quat, 999999999))
				{
					A_4.hasNan = true;
					A_4.paths.Add(string.Join(".", currentPath) + ": " + quat.ToString());
				}
			}
		}
		A_4.visited.Add(value);
		Array array = value as Array;
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				List<string> list = new List<string>(currentPath);
				List<string> list2 = list;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[");
				defaultInterpolatedStringHandler.AppendFormatted<int>(i);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
				this.<CheckNanObject>g__Traverse|129_0(array.GetValue(i), list, depth + 1, ref A_4);
			}
			return;
		}
		foreach (FieldInfo fieldInfo in value.GetType().GetFields())
		{
			List<string> list3 = new List<string>(currentPath);
			list3.Add(fieldInfo.Name);
			this.<CheckNanObject>g__Traverse|129_0(fieldInfo.GetValue(value), list3, depth + 1, ref A_4);
		}
	}

	// Token: 0x040005EB RID: 1515
	public const int PI_DEG = 180;

	// Token: 0x040005EC RID: 1516
	public const int PI_DEG_DOUBLE = 360;

	// Token: 0x040005ED RID: 1517
	public const long intBit = 32L;

	// Token: 0x040005EE RID: 1518
	public const int INT_BIT = 32;

	// Token: 0x040005EF RID: 1519
	private const int MAX_INVALID_NUMBER = 999999999;

	// Token: 0x040005F0 RID: 1520
	public const double MaxFloat = 3.402823466E+38;

	// Token: 0x040005F1 RID: 1521
	public const int Int32Max = 2147483647;

	// Token: 0x040005F2 RID: 1522
	public const int Int16Max = 32767;

	// Token: 0x040005F3 RID: 1523
	public const double SmallNumber = 1E-08;

	// Token: 0x040005F4 RID: 1524
	public const double KindaSmallNumber = 0.0001;

	// Token: 0x040005F5 RID: 1525
	public const double LargeNumber = 1E+50;

	// Token: 0x040005F6 RID: 1526
	public const float MillisecondToSecond = 0.001f;

	// Token: 0x040005F7 RID: 1527
	public const int SecondToMillisecond = 1000;

	// Token: 0x040005F8 RID: 1528
	public const int CircumradiusRatio = 4;

	// Token: 0x040005F9 RID: 1529
	public const float RadToDeg = 57.29578f;

	// Token: 0x040005FA RID: 1530
	public const float DegToRad = 0.017453292f;

	// Token: 0x040005FB RID: 1531
	public readonly FTransform DefaultTransform = new FTransform();

	// Token: 0x040005FC RID: 1532
	public readonly FTransformDouble DefaultTransformDouble = new FTransformDouble();

	// Token: 0x040005FD RID: 1533
	public readonly Transform DefaultTransformProxy = Transform.Create();

	// Token: 0x040005FE RID: 1534
	public readonly Random Random = new Random();

	// Token: 0x040005FF RID: 1535
	private readonly global::Vector TempVector = global::Vector.Create();

	// Token: 0x04000600 RID: 1536
	private readonly global::Vector TempVector2 = global::Vector.Create();

	// Token: 0x04000601 RID: 1537
	private readonly global::Vector TempVector3 = global::Vector.Create();

	// Token: 0x04000602 RID: 1538
	public global::Vector CommonTempVector = global::Vector.Create();

	// Token: 0x04000603 RID: 1539
	public global::Vector CommonTempVector2 = global::Vector.Create();

	// Token: 0x04000604 RID: 1540
	public Rotator CommonTempRotator = Rotator.Create();

	// Token: 0x04000605 RID: 1541
	public Quat CommonTempQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04000606 RID: 1542
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private double[][] RotArray;

	// Token: 0x04000607 RID: 1543
	[Nullable(2)]
	private double[] TmpArray;

	// Token: 0x04000608 RID: 1544
	private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04000609 RID: 1545
	private readonly List<global::Vector> TmpVectorCache = new List<global::Vector>();

	// Token: 0x0400060A RID: 1546
	private readonly List<Rotator> TmpRotatorCache = new List<Rotator>();
}
