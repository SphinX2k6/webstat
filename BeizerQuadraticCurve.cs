using System;
using System.Runtime.CompilerServices;

// Token: 0x02003432 RID: 13362
[NullableContext(1)]
[Nullable(0)]
public class BeizerQuadraticCurve
{
	// Token: 0x0601C02C RID: 114732 RVA: 0x00859D0B File Offset: 0x00857F0B
	public void InitByThreePoints(Vector pointA, Vector pointB, Vector controlPoint)
	{
		this.PointA = pointA;
		this.PointB = pointB;
		this.ControlPoint = controlPoint;
	}

	// Token: 0x0601C02D RID: 114733 RVA: 0x00859D24 File Offset: 0x00857F24
	public void InitByPhysics(Vector pointA, Vector pointB, Vector speedA, double delta)
	{
		this.PointA = pointA;
		this.PointB = pointB;
		speedA.Multiply(delta, this.TempVector);
		this.ControlPoint = Vector.Create();
		this.PointA.Addition(this.TempVector, this.ControlPoint);
	}

	// Token: 0x0601C02E RID: 114734 RVA: 0x00859D74 File Offset: 0x00857F74
	public void InitByFactor(Vector pointA, Vector pointB, Vector upVetcor, double factor, double centerFactor)
	{
		this.PointA = pointA;
		this.PointB = pointB;
		this.ControlPoint = Vector.Create();
		this.PointB.Subtraction(this.PointA, this.TempVector);
		double num = this.TempVector.Size();
		this.TempVector.CrossProduct(upVetcor, this.TempVector2);
		this.TempVector2.Normalize(9.99999993922529E-09);
		this.PointA.Addition(this.PointB, this.TempVector3);
		this.TempVector3.Multiply(centerFactor, this.TempVector3);
		this.TempVector2.Multiply(num * factor, this.TempVector2);
		this.TempVector2.Addition(this.TempVector3, this.ControlPoint);
	}

	// Token: 0x0601C02F RID: 114735 RVA: 0x00859E40 File Offset: 0x00858040
	public Vector GetPos(double factor)
	{
		double num = 1.0 - factor;
		this.PointA.Multiply(num * num, this.TempVector);
		this.ControlPoint.Multiply(2.0 * num * factor, this.TempVector2);
		this.TempVector.Addition(this.TempVector2, this.TempVector3);
		this.PointB.Multiply(factor * factor, this.TempVector2);
		this.TempVector3.Addition(this.TempVector2, this.TempVector);
		return this.TempVector;
	}

	// Token: 0x0601C030 RID: 114736 RVA: 0x00859ED8 File Offset: 0x008580D8
	public Vector GetDerivativeAt(double factor)
	{
		double num = 1.0 - factor;
		this.PointA.Multiply(-2.0 * num, this.TempVector);
		this.ControlPoint.Multiply(2.0 * num - 2.0 * factor, this.TempVector2);
		this.TempVector.Addition(this.TempVector2, this.TempVector3);
		this.PointB.Multiply(2.0 * factor, this.TempVector2);
		this.TempVector3.Addition(this.TempVector2, this.TempVector);
		return this.TempVector;
	}

	// Token: 0x0601C031 RID: 114737 RVA: 0x00859F8C File Offset: 0x0085818C
	public double GetPolylineLength()
	{
		this.ControlPoint.Subtraction(this.PointA, this.TempVector);
		this.PointB.Subtraction(this.PointA, this.TempVector2);
		return this.TempVector.Size() + this.TempVector2.Size();
	}

	// Token: 0x0400E255 RID: 57941
	[Nullable(2)]
	protected Vector PointA;

	// Token: 0x0400E256 RID: 57942
	[Nullable(2)]
	protected Vector PointB;

	// Token: 0x0400E257 RID: 57943
	[Nullable(2)]
	protected Vector ControlPoint;

	// Token: 0x0400E258 RID: 57944
	protected Vector TempVector = Vector.Create();

	// Token: 0x0400E259 RID: 57945
	protected Vector TempVector2 = Vector.Create();

	// Token: 0x0400E25A RID: 57946
	protected Vector TempVector3 = Vector.Create();
}
