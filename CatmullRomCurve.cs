using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02003438 RID: 13368
[NullableContext(1)]
[Nullable(0)]
public class CatmullRomCurve
{
	// Token: 0x0601C04A RID: 114762 RVA: 0x0085A590 File Offset: 0x00858790
	public CatmullRomCurve(IntVector2D[] points)
	{
		if (points == null || points.Length < 2)
		{
			throw new InvalidOperationException("Catmull-Rom 曲线至少需要 2 个控制点");
		}
		this.ControlPoints = new global::Vector[points.Length];
		for (int i = 0; i < points.Length; i++)
		{
			IntVector2D intVector2D = points[i];
			this.ControlPoints[i] = global::Vector.Create((double)intVector2D.X, (double)intVector2D.Y, 0.0);
		}
		this.SegmentCount = this.ControlPoints.Length - 1;
	}

	// Token: 0x0601C04B RID: 114763 RVA: 0x0085A614 File Offset: 0x00858814
	public CatmullRomCurve(IReadOnlyList<global::Vector> points)
	{
		if (points == null || points.Count < 2)
		{
			throw new InvalidOperationException("Catmull-Rom 曲线至少需要 2 个控制点");
		}
		this.ControlPoints = new global::Vector[points.Count];
		for (int i = 0; i < points.Count; i++)
		{
			global::Vector vector = points[i];
			this.ControlPoints[i] = global::Vector.Create(vector.X, vector.Y, 0.0);
		}
		this.SegmentCount = this.ControlPoints.Length - 1;
	}

	// Token: 0x0601C04C RID: 114764 RVA: 0x0085A69A File Offset: 0x0085889A
	public int GetPointCount()
	{
		return this.ControlPoints.Length;
	}

	// Token: 0x0601C04D RID: 114765 RVA: 0x0085A6A4 File Offset: 0x008588A4
	public int GetSegmentCount()
	{
		return this.SegmentCount;
	}

	// Token: 0x0601C04E RID: 114766 RVA: 0x0085A6AC File Offset: 0x008588AC
	public global::Vector GetPoint(double t)
	{
		if (t < 0.0 || t > 1.0)
		{
			throw new InvalidOperationException("参数 t 必须在 [0, 1] 范围内");
		}
		if (this.ControlPoints.Length == 2)
		{
			global::Vector vector = this.ControlPoints[0];
			global::Vector vector2 = this.ControlPoints[1];
			return global::Vector.Create(vector.X + (vector2.X - vector.X) * t, vector.Y + (vector2.Y - vector.Y) * t, 0.0);
		}
		int segmentCount = this.SegmentCount;
		int num = (int)Math.Floor(t * (double)segmentCount);
		if (num >= segmentCount)
		{
			num = segmentCount - 1;
		}
		double localT = t * (double)segmentCount - (double)num;
		return this.EvaluateSegment(num, localT);
	}

	// Token: 0x0601C04F RID: 114767 RVA: 0x0085A764 File Offset: 0x00858964
	public global::Vector GetDerivative(double t)
	{
		double t2 = Math.Max(0.0, t - 0.001);
		double t3 = Math.Min(1.0, t + 0.001);
		global::Vector point = this.GetPoint(t2);
		global::Vector point2 = this.GetPoint(t3);
		return global::Vector.Create(point2.X - point.X, point2.Y - point.Y, 0.0);
	}

	// Token: 0x0601C050 RID: 114768 RVA: 0x0085A7E0 File Offset: 0x008589E0
	public List<global::Vector> GetPoints(int segments = 100)
	{
		List<global::Vector> list = new List<global::Vector>(segments + 1);
		for (int i = 0; i <= segments; i++)
		{
			list.Add(this.GetPoint((double)i / (double)segments));
		}
		return list;
	}

	// Token: 0x0601C051 RID: 114769 RVA: 0x0085A814 File Offset: 0x00858A14
	private global::Vector EvaluateSegment(int segmentIndex, double localT)
	{
		global::Vector[] controlPoints = this.ControlPoints;
		int num = controlPoints.Length - 1;
		global::Vector vector = controlPoints[segmentIndex];
		global::Vector vector2 = controlPoints[segmentIndex + 1];
		global::Vector vector3 = (segmentIndex == 0) ? global::Vector.Create(2.0 * vector.X - vector2.X, 2.0 * vector.Y - vector2.Y, 0.0) : controlPoints[segmentIndex - 1];
		global::Vector vector4 = (segmentIndex + 2 > num) ? global::Vector.Create(2.0 * vector2.X - vector.X, 2.0 * vector2.Y - vector.Y, 0.0) : controlPoints[segmentIndex + 2];
		double num2 = 0.0;
		double num3 = num2 + Math.Pow(this.Distance(vector3, vector), 0.5);
		double num4 = num3 + Math.Pow(this.Distance(vector, vector2), 0.5);
		double t = num4 + Math.Pow(this.Distance(vector2, vector4), 0.5);
		double t2 = num3 + (num4 - num3) * localT;
		global::Vector p = this.LinearInterp(vector3, vector, num2, num3, t2);
		global::Vector vector5 = this.LinearInterp(vector, vector2, num3, num4, t2);
		global::Vector p2 = this.LinearInterp(vector2, vector4, num4, t, t2);
		global::Vector p3 = this.LinearInterp(p, vector5, num2, num4, t2);
		global::Vector p4 = this.LinearInterp(vector5, p2, num3, t, t2);
		return this.LinearInterp(p3, p4, num3, num4, t2);
	}

	// Token: 0x0601C052 RID: 114770 RVA: 0x0085A99C File Offset: 0x00858B9C
	private global::Vector LinearInterp(global::Vector p0, global::Vector p1, double t0, double t1, double t)
	{
		double num = t1 - t0;
		if (Math.Abs(num) < 1E-12)
		{
			return global::Vector.Create(p0.X, p0.Y, 0.0);
		}
		double num2 = (t1 - t) / num;
		double num3 = (t - t0) / num;
		return global::Vector.Create(num2 * p0.X + num3 * p1.X, num2 * p0.Y + num3 * p1.Y, 0.0);
	}

	// Token: 0x0601C053 RID: 114771 RVA: 0x0085AA1C File Offset: 0x00858C1C
	private double Distance(global::Vector v0, global::Vector v1)
	{
		double num = v1.X - v0.X;
		double num2 = v1.Y - v0.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	// Token: 0x0601C054 RID: 114772 RVA: 0x0085AA50 File Offset: 0x00858C50
	public static ICatmullRomArcLengthLookup CreateArcLengthLookup(CatmullRomCurve curve, int segmentCount)
	{
		int num = Math.Max(1, (int)Math.Floor((double)segmentCount));
		double[] array = new double[num + 1];
		double[] array2 = new double[num + 1];
		double num2 = 0.0;
		array2[0] = 0.0;
		array[0] = 0.0;
		global::Vector point = curve.GetPoint(0.0);
		double x = point.X;
		double y = point.Y;
		for (int i = 1; i <= num; i++)
		{
			double num3 = (double)i / (double)num;
			global::Vector point2 = curve.GetPoint(num3);
			double num4 = point2.X - x;
			double num5 = point2.Y - y;
			num2 += Math.Sqrt(num4 * num4 + num5 * num5);
			array2[i] = num2;
			array[i] = num3;
			x = point2.X;
			y = point2.Y;
		}
		return new CatmullRomArcLengthLookup(array, array2, num2);
	}

	// Token: 0x0601C055 RID: 114773 RVA: 0x0085AB2C File Offset: 0x00858D2C
	public static double GetParameterByArcLength(ICatmullRomArcLengthLookup lookup, double arcLength)
	{
		if (lookup.TotalLength <= 1E-10 || lookup.ParamSamples.Count < 2)
		{
			return 0.0;
		}
		double num = Math.Min(Math.Max(arcLength, 0.0), lookup.TotalLength);
		if (num <= 0.0)
		{
			return 0.0;
		}
		if (num >= lookup.TotalLength)
		{
			return 1.0;
		}
		int i = 0;
		int num2 = lookup.CumulativeArcLengths.Count - 1;
		while (i < num2)
		{
			int num3 = (i + num2 + 1) / 2;
			if (lookup.CumulativeArcLengths[num3] <= num)
			{
				i = num3;
			}
			else
			{
				num2 = num3 - 1;
			}
		}
		int num4 = i;
		if (num4 >= lookup.ParamSamples.Count - 1)
		{
			return 1.0;
		}
		double num5 = lookup.CumulativeArcLengths[num4];
		double num6 = lookup.CumulativeArcLengths[num4 + 1] - num5;
		double num7 = (num6 > 1E-10) ? ((num - num5) / num6) : 0.0;
		return lookup.ParamSamples[num4] + num7 * (lookup.ParamSamples[num4 + 1] - lookup.ParamSamples[num4]);
	}

	// Token: 0x0400E265 RID: 57957
	private readonly global::Vector[] ControlPoints;

	// Token: 0x0400E266 RID: 57958
	private readonly int SegmentCount;

	// Token: 0x0400E267 RID: 57959
	private const int ARC_LENGTH_LUT_MIN_SEGMENTS = 1;

	// Token: 0x0400E268 RID: 57960
	private const double ARC_LENGTH_SEGMENT_LENGTH_EPSILON = 1E-10;

	// Token: 0x0400E269 RID: 57961
	private const double CENTRIPETAL_ALPHA = 0.5;

	// Token: 0x0400E26A RID: 57962
	private const double NUMERIC_DERIVATIVE_STEP = 0.001;

	// Token: 0x0400E26B RID: 57963
	private const double PARAM_DENOMINATOR_EPSILON = 1E-12;
}
