using System;
using System.Runtime.CompilerServices;

// Token: 0x02003023 RID: 12323
[NullableContext(1)]
[Nullable(0)]
internal class PathLineSegment
{
	// Token: 0x06019287 RID: 103047 RVA: 0x0072B4E4 File Offset: 0x007296E4
	public PathLineSegment(Vector start, Vector end)
	{
		this.Start.DeepCopy(start);
		end.Subtraction(start, this.Direct);
		this.Length = this.Direct.Size();
		if (this.Length > 1E-08)
		{
			this.Direct.DivisionEqual(this.Length);
		}
		else
		{
			this.Direct.Reset();
		}
		this.Min[0] = Math.Min(start[0], end[0]);
		this.Min[1] = Math.Min(start[1], end[1]);
		this.Min[2] = Math.Min(start[2], end[2]);
		this.Max[0] = Math.Max(start[0], end[0]);
		this.Max[1] = Math.Max(start[1], end[1]);
		this.Max[2] = Math.Max(start[2], end[2]);
	}

	// Token: 0x06019288 RID: 103048 RVA: 0x0072B628 File Offset: 0x00729828
	public double FindNearestLocation(Vector point, Vector outVect, double distSquared)
	{
		if (!this.PossibleInDistSquared(point, distSquared))
		{
			return distSquared;
		}
		point.Subtraction(this.Start, CharacterAiComponent.TmpVector);
		double inB = Math.Clamp(CharacterAiComponent.TmpVector.DotProduct(this.Direct), 0.0, this.Length);
		this.Direct.Multiply(inB, CharacterAiComponent.TmpVector);
		CharacterAiComponent.TmpVector.AdditionEqual(this.Start);
		double num = Vector.DistSquared(CharacterAiComponent.TmpVector, point);
		if (num > distSquared)
		{
			return distSquared;
		}
		outVect.DeepCopy(CharacterAiComponent.TmpVector);
		return num;
	}

	// Token: 0x06019289 RID: 103049 RVA: 0x0072B6BC File Offset: 0x007298BC
	public bool PossibleInDistSquared(Vector point, double distSquared)
	{
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			if (point[i] < this.Min[i])
			{
				num += Singleton<MathUtils>.Instance.Square(this.Min[i] - point[i]);
			}
			else if (point[i] > this.Max[i])
			{
				num += Singleton<MathUtils>.Instance.Square(this.Max[i] - point[i]);
			}
		}
		return num < distSquared;
	}

	// Token: 0x0400C577 RID: 50551
	public Vector Start = Vector.Create();

	// Token: 0x0400C578 RID: 50552
	public Vector Direct = Vector.Create();

	// Token: 0x0400C579 RID: 50553
	public double Length;

	// Token: 0x0400C57A RID: 50554
	private double[] Min = new double[3];

	// Token: 0x0400C57B RID: 50555
	private double[] Max = new double[3];
}
