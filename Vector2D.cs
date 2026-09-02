using System;
using System.Runtime.CompilerServices;
using Aki.Common.Common;
using UnrealEngine;
using UnrealEngine.Bulitin.Utils;
using UnrealEngine.Extension;

// Token: 0x02000C1D RID: 3101
[NullableContext(1)]
[Nullable(0)]
public class Vector2D : IVector2D, IClearable, ILogFormattedPrint
{
	// Token: 0x06003542 RID: 13634 RVA: 0x00030D0A File Offset: 0x0002EF0A
	public Vector2D()
	{
	}

	// Token: 0x06003543 RID: 13635 RVA: 0x00030D12 File Offset: 0x0002EF12
	public Vector2D(double inX, double inY)
	{
		this.X = inX;
		this.Y = inY;
	}

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x06003544 RID: 13636 RVA: 0x00030D28 File Offset: 0x0002EF28
	// (set) Token: 0x06003545 RID: 13637 RVA: 0x00030D30 File Offset: 0x0002EF30
	double IVector2D.X
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

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x06003546 RID: 13638 RVA: 0x00030D39 File Offset: 0x0002EF39
	// (set) Token: 0x06003547 RID: 13639 RVA: 0x00030D41 File Offset: 0x0002EF41
	double IVector2D.Y
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

	// Token: 0x06003548 RID: 13640 RVA: 0x00030D4A File Offset: 0x0002EF4A
	public void FromUeVector2D(IVector2D inV)
	{
		this.X = inV.X;
		this.Y = inV.Y;
	}

	// Token: 0x06003549 RID: 13641 RVA: 0x00030D64 File Offset: 0x0002EF64
	public static Vector2D Create(double x, double y)
	{
		return new Vector2D(x, y);
	}

	// Token: 0x0600354A RID: 13642 RVA: 0x00030D6D File Offset: 0x0002EF6D
	public static Vector2D Create([Nullable(2)] IVector2D inV)
	{
		if (inV != null)
		{
			return new Vector2D(inV.X, inV.Y);
		}
		return new Vector2D();
	}

	// Token: 0x0600354B RID: 13643 RVA: 0x00030D89 File Offset: 0x0002EF89
	public static Vector2D Create()
	{
		return new Vector2D();
	}

	// Token: 0x0600354C RID: 13644 RVA: 0x00030D90 File Offset: 0x0002EF90
	public FVector2D ToUeVector2D(bool isCacheUeObj = false)
	{
		return new FVector2D((float)this.X, (float)this.Y);
	}

	// Token: 0x0600354D RID: 13645 RVA: 0x00030DA8 File Offset: 0x0002EFA8
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
		defaultInterpolatedStringHandler.AppendLiteral("X=");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.X);
		defaultInterpolatedStringHandler.AppendLiteral(", Y=");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.Y);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600354E RID: 13646 RVA: 0x00030DF7 File Offset: 0x0002EFF7
	public string ToFormattedString()
	{
		return this.ToString();
	}

	// Token: 0x0600354F RID: 13647 RVA: 0x00030E00 File Offset: 0x0002F000
	public void ToFormattedString(UnsafeStringBuilder sb)
	{
		UnsafeStringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new UnsafeStringBuilder.AppendInterpolatedStringHandler(6, 2, sb);
		appendInterpolatedStringHandler.AppendLiteral("X=");
		appendInterpolatedStringHandler.AppendFormatted<double>(this.X);
		appendInterpolatedStringHandler.AppendLiteral(", Y=");
		appendInterpolatedStringHandler.AppendFormatted<double>(this.Y);
		sb.Append(ref appendInterpolatedStringHandler);
	}

	// Token: 0x06003550 RID: 13648 RVA: 0x00030E54 File Offset: 0x0002F054
	public Vector2D Addition(Vector2D inB, Vector2D outV)
	{
		outV.X = this.X + inB.X;
		outV.Y = this.Y + inB.Y;
		return outV;
	}

	// Token: 0x06003551 RID: 13649 RVA: 0x00030E7D File Offset: 0x0002F07D
	public Vector2D Addition(double inB, Vector2D outV)
	{
		outV.X = this.X + inB;
		outV.Y = this.Y + inB;
		return outV;
	}

	// Token: 0x06003552 RID: 13650 RVA: 0x00030E9C File Offset: 0x0002F09C
	public Vector2D AdditionEqual(Vector2D b)
	{
		this.X += b.X;
		this.Y += b.Y;
		return this;
	}

	// Token: 0x06003553 RID: 13651 RVA: 0x00030EC5 File Offset: 0x0002F0C5
	public Vector2D AdditionEqual(FVector2D inB)
	{
		this.X += (double)inB.X;
		this.Y += (double)inB.Y;
		return this;
	}

	// Token: 0x06003554 RID: 13652 RVA: 0x00030EF0 File Offset: 0x0002F0F0
	public Vector2D AdditionEqual(double inB)
	{
		this.X += inB;
		this.Y += inB;
		return this;
	}

	// Token: 0x06003555 RID: 13653 RVA: 0x00030F0F File Offset: 0x0002F10F
	public Vector2D Subtraction(Vector2D b, Vector2D outV)
	{
		outV.X = this.X - b.X;
		outV.Y = this.Y - b.Y;
		return outV;
	}

	// Token: 0x06003556 RID: 13654 RVA: 0x00030F38 File Offset: 0x0002F138
	public Vector2D Subtraction(double inB, Vector2D outV)
	{
		outV.X = this.X - inB;
		outV.Y = this.Y - inB;
		return outV;
	}

	// Token: 0x06003557 RID: 13655 RVA: 0x00030F57 File Offset: 0x0002F157
	public Vector2D SubtractionEqual(Vector2D b)
	{
		this.X -= b.X;
		this.Y -= b.Y;
		return this;
	}

	// Token: 0x06003558 RID: 13656 RVA: 0x00030F80 File Offset: 0x0002F180
	public Vector2D SubtractionEqual(double inB)
	{
		this.X -= inB;
		this.Y -= inB;
		return this;
	}

	// Token: 0x06003559 RID: 13657 RVA: 0x00030F9F File Offset: 0x0002F19F
	public Vector2D Multiply(Vector2D b, Vector2D outV)
	{
		outV.X = this.X * b.X;
		outV.Y = this.Y * b.Y;
		return outV;
	}

	// Token: 0x0600355A RID: 13658 RVA: 0x00030FC8 File Offset: 0x0002F1C8
	public Vector2D Multiply(double inB, Vector2D outV)
	{
		outV.X = this.X * inB;
		outV.Y = this.Y * inB;
		return outV;
	}

	// Token: 0x0600355B RID: 13659 RVA: 0x00030FE7 File Offset: 0x0002F1E7
	public Vector2D MultiplyEqual(Vector2D b)
	{
		this.X *= b.X;
		this.Y *= b.Y;
		return this;
	}

	// Token: 0x0600355C RID: 13660 RVA: 0x00031010 File Offset: 0x0002F210
	public Vector2D MultiplyEqual(FVector2D inB)
	{
		this.X *= (double)inB.X;
		this.Y *= (double)inB.Y;
		return this;
	}

	// Token: 0x0600355D RID: 13661 RVA: 0x0003103B File Offset: 0x0002F23B
	public Vector2D MultiplyEqual(double inB)
	{
		this.X *= inB;
		this.Y *= inB;
		return this;
	}

	// Token: 0x0600355E RID: 13662 RVA: 0x0003105A File Offset: 0x0002F25A
	public Vector2D Division(Vector2D b, Vector2D outV)
	{
		outV.X = this.X / b.X;
		outV.Y = this.Y / b.Y;
		return outV;
	}

	// Token: 0x0600355F RID: 13663 RVA: 0x00031084 File Offset: 0x0002F284
	public Vector2D Division(double inB, Vector2D outV)
	{
		double num = 1.0 / inB;
		outV.X = this.X * num;
		outV.Y = this.Y * num;
		return outV;
	}

	// Token: 0x06003560 RID: 13664 RVA: 0x000310BA File Offset: 0x0002F2BA
	public Vector2D DivisionEqual(Vector2D b)
	{
		this.X /= b.X;
		this.Y /= b.Y;
		return this;
	}

	// Token: 0x06003561 RID: 13665 RVA: 0x000310E4 File Offset: 0x0002F2E4
	public Vector2D DivisionEqual(double inB)
	{
		double num = 1.0 / inB;
		this.X *= num;
		this.Y *= num;
		return this;
	}

	// Token: 0x06003562 RID: 13666 RVA: 0x0003111A File Offset: 0x0002F31A
	public void UnaryNegation(Vector2D outV)
	{
		outV.X = -this.X;
		outV.Y = -this.Y;
	}

	// Token: 0x06003563 RID: 13667 RVA: 0x00031136 File Offset: 0x0002F336
	public double DotProduct(Vector2D b)
	{
		return this.X * b.X + this.Y * b.Y;
	}

	// Token: 0x06003564 RID: 13668 RVA: 0x00031153 File Offset: 0x0002F353
	public double DotProduct(in FVector2D b)
	{
		return this.X * (double)b.X + this.Y * (double)b.Y;
	}

	// Token: 0x06003565 RID: 13669 RVA: 0x00031172 File Offset: 0x0002F372
	public double CrossProduct(Vector2D b)
	{
		return this.X * b.Y - this.Y * b.X;
	}

	// Token: 0x06003566 RID: 13670 RVA: 0x0003118F File Offset: 0x0002F38F
	public double Size()
	{
		return Math.Sqrt(this.SizeSquared());
	}

	// Token: 0x06003567 RID: 13671 RVA: 0x0003119C File Offset: 0x0002F39C
	public double SizeSquared()
	{
		return this.X * this.X + this.Y * this.Y;
	}

	// Token: 0x06003568 RID: 13672 RVA: 0x000311B9 File Offset: 0x0002F3B9
	public bool IsNearlyZero(double tolerance = 9.999999747378752E-05)
	{
		return Math.Abs(this.X) <= tolerance && Math.Abs(this.Y) <= tolerance;
	}

	// Token: 0x06003569 RID: 13673 RVA: 0x000311DC File Offset: 0x0002F3DC
	public bool Normalize(double tolerance = 9.99999993922529E-09)
	{
		double num = this.SizeSquared();
		if (num > tolerance)
		{
			double inB = 1.0 / Math.Sqrt(num);
			this.Multiply(inB, this);
			return true;
		}
		return false;
	}

	// Token: 0x0600356A RID: 13674 RVA: 0x00031214 File Offset: 0x0002F414
	public void GetSafeNormal(Vector2D outV, double tolerance = 9.99999993922529E-09)
	{
		double num = this.SizeSquared();
		if (num == 1.0)
		{
			outV.DeepCopy(this);
			return;
		}
		if (num < tolerance)
		{
			outV.Reset();
			return;
		}
		double inB = 1.0 / Math.Sqrt(num);
		this.Multiply(inB, outV);
	}

	// Token: 0x0600356B RID: 13675 RVA: 0x00031261 File Offset: 0x0002F461
	public void DeepCopy(Vector2D inV)
	{
		this.Set(inV.X, inV.Y);
	}

	// Token: 0x0600356C RID: 13676 RVA: 0x00031278 File Offset: 0x0002F478
	public void GetRotated(double angleDeg, Vector2D outV)
	{
		double num = MathCommon.DegreeToRadian(angleDeg);
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		outV.X = num3 * this.X - num2 * this.Y;
		outV.Y = num2 * this.X + num3 * this.Y;
	}

	// Token: 0x0600356D RID: 13677 RVA: 0x000312C8 File Offset: 0x0002F4C8
	public void SphericalToUnitCartesian(Vector outV3D)
	{
		double num = Math.Sin(this.X);
		outV3D.X = Math.Cos(this.Y) * num;
		outV3D.Y = Math.Sin(this.Y) * num;
		outV3D.Z = Math.Cos(this.X);
	}

	// Token: 0x0600356E RID: 13678 RVA: 0x00031318 File Offset: 0x0002F518
	public bool Equals(Vector2D b, double tolerance = 9.999999747378752E-05)
	{
		return Math.Abs(this.X - b.X) <= tolerance && Math.Abs(this.Y - b.Y) <= tolerance;
	}

	// Token: 0x0600356F RID: 13679 RVA: 0x00031349 File Offset: 0x0002F549
	public double GetMax()
	{
		return Math.Max(this.X, this.Y);
	}

	// Token: 0x06003570 RID: 13680 RVA: 0x0003135C File Offset: 0x0002F55C
	public double GetAbsMax()
	{
		return Math.Max(Math.Abs(this.X), Math.Abs(this.Y));
	}

	// Token: 0x06003571 RID: 13681 RVA: 0x00031379 File Offset: 0x0002F579
	public double GetMin()
	{
		return Math.Min(this.X, this.Y);
	}

	// Token: 0x06003572 RID: 13682 RVA: 0x0003138C File Offset: 0x0002F58C
	public double GetAbsMin()
	{
		return Math.Min(Math.Abs(this.X), Math.Abs(this.Y));
	}

	// Token: 0x06003573 RID: 13683 RVA: 0x000313AC File Offset: 0x0002F5AC
	public double ToDirectionAndLength(Vector2D outDir)
	{
		double num = this.Size();
		if (num > 9.99999993922529E-09)
		{
			double num2 = 1.0 / num;
			outDir.X = this.X * num2;
			outDir.Y = this.Y * num2;
		}
		else
		{
			outDir.Reset();
		}
		return num;
	}

	// Token: 0x06003574 RID: 13684 RVA: 0x000313FD File Offset: 0x0002F5FD
	public void Set(double inX, double inY)
	{
		this.X = inX;
		this.Y = inY;
	}

	// Token: 0x06003575 RID: 13685 RVA: 0x0003140D File Offset: 0x0002F60D
	public static double Distance(Vector2D v1, Vector2D v2)
	{
		return Math.Sqrt(Vector2D.DistSquared(v1, v2));
	}

	// Token: 0x06003576 RID: 13686 RVA: 0x0003141B File Offset: 0x0002F61B
	public static double DistSquared(Vector2D a, Vector2D b)
	{
		return Math.Pow(b.X - a.X, 2.0) + Math.Pow(b.Y - a.Y, 2.0);
	}

	// Token: 0x06003577 RID: 13687 RVA: 0x00031454 File Offset: 0x0002F654
	public void Reset()
	{
		this.X = 0.0;
		this.Y = 0.0;
	}

	// Token: 0x06003578 RID: 13688 RVA: 0x00031474 File Offset: 0x0002F674
	public bool ContainsNaN()
	{
		return !double.IsFinite(this.X) || !double.IsFinite(this.Y);
	}

	// Token: 0x06003579 RID: 13689 RVA: 0x00031493 File Offset: 0x0002F693
	public void Clear()
	{
		this.Reset();
	}

	// Token: 0x04000666 RID: 1638
	public double X;

	// Token: 0x04000667 RID: 1639
	public double Y;

	// Token: 0x04000668 RID: 1640
	public static readonly FVector2D ZeroVector = new FVector2D(0f, 0f);

	// Token: 0x04000669 RID: 1641
	public static readonly FVector2D UnitVector = new FVector2D(1f, 1f);

	// Token: 0x0400066A RID: 1642
	public static readonly FVector2D Unit45Deg = new FVector2D((float)Math.Sqrt(0.5), (float)Math.Sqrt(0.5));
}
