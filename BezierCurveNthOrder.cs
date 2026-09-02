using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02003435 RID: 13365
[NullableContext(1)]
[Nullable(0)]
public class BezierCurveNthOrder
{
	// Token: 0x0601C03A RID: 114746 RVA: 0x0085A040 File Offset: 0x00858240
	public BezierCurveNthOrder(IntVector2D[] points)
	{
		if (points == null || points.Length < 1)
		{
			throw new InvalidOperationException("贝塞尔曲线至少需要1个控制点");
		}
		this.ControlPoints = new global::Vector[points.Length];
		for (int i = 0; i < points.Length; i++)
		{
			IntVector2D intVector2D = points[i];
			this.ControlPoints[i] = global::Vector.Create((double)intVector2D.X, (double)intVector2D.Y, 0.0);
		}
		this.Order = points.Length - 1;
	}

	// Token: 0x0601C03B RID: 114747 RVA: 0x0085A0BC File Offset: 0x008582BC
	public BezierCurveNthOrder(IReadOnlyList<global::Vector> points)
	{
		if (points == null || points.Count < 1)
		{
			throw new InvalidOperationException("贝塞尔曲线至少需要1个控制点");
		}
		this.ControlPoints = new global::Vector[points.Count];
		for (int i = 0; i < points.Count; i++)
		{
			global::Vector vector = points[i];
			this.ControlPoints[i] = global::Vector.Create(vector.X, vector.Y, 0.0);
		}
		this.Order = points.Count - 1;
	}

	// Token: 0x0601C03C RID: 114748 RVA: 0x0085A140 File Offset: 0x00858340
	public int GetPointCount()
	{
		return this.ControlPoints.Length;
	}

	// Token: 0x0601C03D RID: 114749 RVA: 0x0085A14A File Offset: 0x0085834A
	public int GetOrder()
	{
		return this.Order;
	}

	// Token: 0x0601C03E RID: 114750 RVA: 0x0085A154 File Offset: 0x00858354
	public global::Vector GetPoint(double t)
	{
		if (t < 0.0 || t > 1.0)
		{
			throw new InvalidOperationException("参数 t 必须在 [0, 1] 范围内");
		}
		global::Vector[] array = new global::Vector[this.Order + 1];
		for (int i = 0; i <= this.Order; i++)
		{
			array[i] = global::Vector.Create(this.ControlPoints[i].X, this.ControlPoints[i].Y, 0.0);
		}
		for (int j = 1; j <= this.Order; j++)
		{
			for (int k = 0; k <= this.Order - j; k++)
			{
				array[k].X = (1.0 - t) * array[k].X + t * array[k + 1].X;
				array[k].Y = (1.0 - t) * array[k].Y + t * array[k + 1].Y;
			}
		}
		return array[0];
	}

	// Token: 0x0601C03F RID: 114751 RVA: 0x0085A248 File Offset: 0x00858448
	public global::Vector GetDerivative(double t)
	{
		if (this.Order == 0)
		{
			return global::Vector.Create(0.0, 0.0, 0.0);
		}
		List<global::Vector> list = new List<global::Vector>(this.Order);
		for (int i = 0; i < this.Order; i++)
		{
			list.Add(global::Vector.Create((double)this.Order * (this.ControlPoints[i + 1].X - this.ControlPoints[i].X), (double)this.Order * (this.ControlPoints[i + 1].Y - this.ControlPoints[i].Y), 0.0));
		}
		return new BezierCurveNthOrder(list).GetPoint(t);
	}

	// Token: 0x0601C040 RID: 114752 RVA: 0x0085A308 File Offset: 0x00858508
	public List<global::Vector> GetPoints(int segments = 100)
	{
		List<global::Vector> list = new List<global::Vector>(segments + 1);
		for (int i = 0; i <= segments; i++)
		{
			double t = (double)i / (double)segments;
			list.Add(this.GetPoint(t));
		}
		return list;
	}

	// Token: 0x0601C041 RID: 114753 RVA: 0x0085A340 File Offset: 0x00858540
	public static IBezierArcLengthLookup CreateArcLengthLookup(BezierCurveNthOrder curve, int segmentCount)
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
		return new BezierArcLengthLookup(array, array2, num2);
	}

	// Token: 0x0601C042 RID: 114754 RVA: 0x0085A41C File Offset: 0x0085861C
	public static double GetParameterByArcLength(IBezierArcLengthLookup lookup, double arcLength)
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

	// Token: 0x0400E25E RID: 57950
	private readonly global::Vector[] ControlPoints;

	// Token: 0x0400E25F RID: 57951
	private readonly int Order;

	// Token: 0x0400E260 RID: 57952
	private const int ARC_LENGTH_LUT_MIN_SEGMENTS = 1;

	// Token: 0x0400E261 RID: 57953
	private const double ARC_LENGTH_SEGMENT_LENGTH_EPSILON = 1E-10;
}
