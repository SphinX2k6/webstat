using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.PathLine.Pathline_EdgeWall;
using UnrealEngine;

// Token: 0x02002251 RID: 8785
[NullableContext(1)]
[Nullable(0)]
public class PointInPolygonTest
{
	// Token: 0x06010938 RID: 67896 RVA: 0x00487B00 File Offset: 0x00485D00
	public void InitSpline()
	{
		string testPath = this.TestPath;
		if (this.IsSplineInit)
		{
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(testPath, delegate([Nullable(2)] UClass result, string assetPath)
		{
			this.InitSplineAsset(result);
			this.IsSplineInit = true;
			this.BinSetup(this.TestPoints, 30, this.BinSet);
		}, 100, "Ui.MapUi");
	}

	// Token: 0x06010939 RID: 67897 RVA: 0x00487B3C File Offset: 0x00485D3C
	private void InitSplineAsset(UClass splineClass)
	{
		AActor aactor = Singleton<ActorSystem>.Instance.Get<AActor>(splineClass.ClassStackOnlyPtr, Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
		USplineComponent usplineComponent = null;
		BP_BasePathLine_Edgewall_C bp_BasePathLine_Edgewall_C = aactor as BP_BasePathLine_Edgewall_C;
		if (bp_BasePathLine_Edgewall_C != null)
		{
			FVector? fvector = new FVector?(bp_BasePathLine_Edgewall_C.OriginalLocation);
			FVectorDouble newLocation = UKismetMathLibrary.Conv_VectorToVectorDouble(fvector.Value);
			FHitResult fhitResult = null;
			bp_BasePathLine_Edgewall_C.D_K2_SetActorLocationAndRotation(newLocation, Rotator.ZeroRotator, false, ref fhitResult, false);
			usplineComponent = bp_BasePathLine_Edgewall_C.Spline;
		}
		int numberOfSplinePoints = usplineComponent.GetNumberOfSplinePoints();
		this.TestPoints.Clear();
		for (int i = 0; i < numberOfSplinePoints; i++)
		{
			FVectorDouble fvectorDouble = usplineComponent.D_GetLocationAtSplinePoint(i, ESplineCoordinateSpace.World);
			this.TestPoints.Add(new Vector2D(fvectorDouble.X, fvectorDouble.Y));
		}
		aactor.K2_DestroyActor();
	}

	// Token: 0x0601093A RID: 67898 RVA: 0x00487BFC File Offset: 0x00485DFC
	private void TrapBound(int index, int count, double vertexX0, double vertexX1, BinSet binSet)
	{
		double num = vertexX0;
		double num2 = vertexX1;
		if (vertexX0 > vertexX1)
		{
			num = vertexX1;
			num2 = vertexX0;
		}
		if (binSet.Bins[index].MinX > num)
		{
			binSet.Bins[index].MinX = num;
		}
		if (binSet.Bins[index].MaxX < num2)
		{
			binSet.Bins[index].MaxX = num2;
		}
		binSet.Bins[index].EdgeSet[count].MinX = num;
		binSet.Bins[index].EdgeSet[count].MaxX = num2;
	}

	// Token: 0x0601093B RID: 67899 RVA: 0x00487C84 File Offset: 0x00485E84
	public bool BinTest(Vector inputP)
	{
		return this.BinTest(new Vector2D(inputP.X, inputP.Y));
	}

	// Token: 0x0601093C RID: 67900 RVA: 0x00487CA0 File Offset: 0x00485EA0
	public bool BinTest(Vector2D inputP)
	{
		if (!this.IsSplineInit)
		{
			return true;
		}
		this.VectorProxy.Set(inputP.X, inputP.Y);
		Vector2D vectorProxy = this.VectorProxy;
		BinSet binSet = this.BinSet;
		List<Vector2D> testPoints = this.TestPoints;
		if (vectorProxy.Y < binSet.MinY || vectorProxy.Y >= binSet.MaxY || vectorProxy.X < binSet.MinX || vectorProxy.X >= binSet.MaxX)
		{
			return false;
		}
		int num = (int)Math.Floor((vectorProxy.Y - binSet.MinY) * binSet.InvDeltaY);
		Bin bin = binSet.Bins[num];
		if (vectorProxy.X < bin.MinX || vectorProxy.X > bin.MaxX)
		{
			return false;
		}
		Edge[] edgeSet = bin.EdgeSet;
		int count = bin.Count;
		int num2 = 0;
		bool flag = false;
		int i = 0;
		while (i < count)
		{
			if (vectorProxy.X < edgeSet[num2].MinX)
			{
				do
				{
					if (edgeSet[num2].FullCross)
					{
						flag = !flag;
					}
					else
					{
						int id = edgeSet[num2].Id;
						bool flag2 = vectorProxy.Y <= testPoints[id].Y;
						bool flag3 = vectorProxy.Y <= testPoints[(id + 1) % testPoints.Count].Y;
						if (flag2 != flag3)
						{
							flag = !flag;
						}
					}
					num2++;
				}
				while (++i < count);
				return flag;
			}
			if (vectorProxy.X < edgeSet[num2].MaxX)
			{
				int id2 = edgeSet[num2].Id;
				Vector2D vector2D = testPoints[id2];
				Vector2D vector2D2 = testPoints[(id2 + 1) % testPoints.Count];
				if ((edgeSet[num2].FullCross || vectorProxy.Y <= vector2D.Y != vectorProxy.Y <= vector2D2.Y) && vector2D.X - (vector2D.Y - vectorProxy.Y) * (vector2D2.X - vector2D.X) / (vector2D2.Y - vector2D.Y) >= vectorProxy.X)
				{
					flag = !flag;
				}
			}
			i++;
			num2++;
		}
		return flag;
	}

	// Token: 0x0601093D RID: 67901 RVA: 0x00487EDC File Offset: 0x004860DC
	private void BinSetup(List<Vector2D> polygon, int binNum, BinSet binSet)
	{
		int[] array = new int[binNum];
		binSet.BinNum = binNum;
		binSet.Bins = new Bin[binNum];
		binSet.MinX = (binSet.MaxX = polygon[0].X);
		binSet.MinY = (binSet.MaxY = polygon[0].Y);
		for (int i = 1; i < polygon.Count; i++)
		{
			Vector2D vector2D = polygon[i];
			if (binSet.MinX > vector2D.X)
			{
				binSet.MinX = vector2D.X;
			}
			else if (binSet.MaxX < vector2D.X)
			{
				binSet.MaxX = vector2D.X;
			}
			if (binSet.MinY > vector2D.Y)
			{
				binSet.MinY = vector2D.Y;
			}
			else if (binSet.MaxY < vector2D.Y)
			{
				binSet.MaxY = vector2D.Y;
			}
		}
		binSet.MinY -= 1E-08 * (binSet.MaxY - binSet.MinY);
		binSet.MaxY += 1E-08 * (binSet.MaxY - binSet.MinY);
		binSet.DeltaY = (binSet.MaxY - binSet.MinY) / (double)binNum;
		binSet.InvDeltaY = 1.0 / binSet.DeltaY;
		Vector2D vector2D2 = polygon[polygon.Count - 1];
		for (int j = 0; j < polygon.Count; j++)
		{
			Vector2D vector2D3 = polygon[j];
			if (vector2D2.Y != vector2D3.Y)
			{
				Vector2D vector2D4;
				Vector2D vector2D5;
				if (vector2D2.Y < vector2D3.Y)
				{
					vector2D4 = vector2D3;
					vector2D5 = vector2D2;
				}
				else
				{
					vector2D4 = vector2D2;
					vector2D5 = vector2D3;
				}
				int num = (int)Math.Floor((vector2D5.Y - binSet.MinY) * binSet.InvDeltaY);
				double num2 = (vector2D4.Y - binSet.MinY) * binSet.InvDeltaY;
				int num3 = (int)Math.Floor(num2);
				if (num2 - (double)num3 == 0.0)
				{
					num3--;
				}
				for (int k = num; k <= num3; k++)
				{
					array[k]++;
				}
			}
			vector2D2 = vector2D3;
		}
		for (int l = 0; l < binNum; l++)
		{
			binSet.Bins[l] = new Bin();
			Edge[] array2 = new Edge[array[l]];
			for (int m = 0; m < array[l]; m++)
			{
				array2[m] = new Edge();
			}
			binSet.Bins[l].EdgeSet = array2;
			binSet.Bins[l].MinX = binSet.MaxX;
			binSet.Bins[l].MaxX = binSet.MinX;
			binSet.Bins[l].Count = 0;
		}
		vector2D2 = polygon[polygon.Count - 1];
		int id = polygon.Count - 1;
		for (int n = 0; n < polygon.Count; n++)
		{
			Vector2D vector2D3 = polygon[n];
			if (vector2D2.Y != vector2D3.Y)
			{
				Vector2D vector2D4;
				Vector2D vector2D5;
				if (vector2D2.Y < vector2D3.Y)
				{
					vector2D4 = vector2D3;
					vector2D5 = vector2D2;
				}
				else
				{
					vector2D4 = vector2D2;
					vector2D5 = vector2D3;
				}
				double num4 = (vector2D5.Y - binSet.MinY) * binSet.InvDeltaY;
				int num5 = (int)Math.Floor(num4);
				double num6 = (vector2D4.Y - binSet.MinY) * binSet.InvDeltaY;
				int num7 = (int)Math.Floor(num6);
				if (num6 - (double)num7 == 0.0)
				{
					num7--;
				}
				double num8 = vector2D5.X;
				double num9 = binSet.DeltaY * (vector2D4.X - vector2D5.X) / (vector2D4.Y - vector2D5.Y);
				double num10 = num8;
				bool fullCross = false;
				int num11 = num5;
				while (num11 < num7)
				{
					num10 = vector2D5.X + ((double)(num11 + 1) - num4) * num9;
					int count = binSet.Bins[num11].Count;
					binSet.Bins[num11].Count++;
					binSet.Bins[num11].EdgeSet[count].Id = id;
					binSet.Bins[num11].EdgeSet[count].FullCross = fullCross;
					this.TrapBound(num11, count, num8, num10, binSet);
					fullCross = true;
					num11++;
					num8 = num10;
				}
				num8 = num10;
				num10 = vector2D4.X;
				int count2 = binSet.Bins[num7].Count;
				binSet.Bins[num7].Count++;
				binSet.Bins[num7].EdgeSet[count2].Id = id;
				binSet.Bins[num7].EdgeSet[count2].FullCross = false;
				this.TrapBound(num7, count2, num8, num10, binSet);
			}
			vector2D2 = vector2D3;
			id = n;
		}
		for (int num12 = 0; num12 < binSet.BinNum; num12++)
		{
			Array.Sort<Edge>(binSet.Bins[num12].EdgeSet, delegate(Edge a, Edge b)
			{
				if (a.MinX == b.MinX)
				{
					return 0;
				}
				if (a.MinX >= b.MinX)
				{
					return 1;
				}
				return -1;
			});
		}
	}

	// Token: 0x04008264 RID: 33380
	private readonly string TestPath = "/Game/Aki/Data/PathLine/Pathline_EdgeWall/BP_BasePathLine_Edgewall.BP_BasePathLine_Edgewall_C";

	// Token: 0x04008265 RID: 33381
	public bool IsSplineInit;

	// Token: 0x04008266 RID: 33382
	private readonly BinSet BinSet = new BinSet();

	// Token: 0x04008267 RID: 33383
	private readonly List<Vector2D> TestPoints = new List<Vector2D>();

	// Token: 0x04008268 RID: 33384
	private readonly Vector2D VectorProxy = Vector2D.Create();
}
