using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.PathLine.Pathline_EdgeWall;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BinTest
{
	// Token: 0x02006F4A RID: 28490
	[NullableContext(1)]
	[Nullable(0)]
	public class BinItem
	{
		// Token: 0x06044F7C RID: 282492 RVA: 0x011F4478 File Offset: 0x011F2678
		public void Init(string path)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(path, delegate([Nullable(2)] UClass result, string _)
			{
				if (result != null && this.InitSplineAsset(result))
				{
					this.BinSetup(this.TestPoints, 30, this.BinSet);
					if (this.InitCallback != null)
					{
						this.InitCallback();
						return;
					}
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Map;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "样条Asset资源加载错误，或选中的目标样条非BP_BasePathLine_Edgewall类";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", path);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}, 100, "js_undefined");
		}

		// Token: 0x06044F7D RID: 282493 RVA: 0x011F44C0 File Offset: 0x011F26C0
		[NullableContext(2)]
		private bool InitSplineAsset(UClass splineClass)
		{
			AActor aactor = Singleton<ActorSystem>.Instance.Get(splineClass.ClassStackOnlyPtr, Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
			BP_BasePathLine_Edgewall_C bp_BasePathLine_Edgewall_C = aactor as BP_BasePathLine_Edgewall_C;
			if (bp_BasePathLine_Edgewall_C != null)
			{
				FVectorDouble newLocation = UKismetMathLibrary.Conv_VectorToVectorDouble(bp_BasePathLine_Edgewall_C.OriginalLocation);
				FHitResult fhitResult = null;
				bp_BasePathLine_Edgewall_C.D_K2_SetActorLocationAndRotation(newLocation, Rotator.ZeroRotator, false, ref fhitResult, false);
				USplineComponent spline = bp_BasePathLine_Edgewall_C.Spline;
				int numberOfSplinePoints = spline.GetNumberOfSplinePoints();
				this.TestPoints.Clear();
				int i = 0;
				int num = numberOfSplinePoints;
				while (i < num)
				{
					FVectorDouble fvectorDouble = spline.D_GetLocationAtSplinePoint(i, ESplineCoordinateSpace.World);
					this.TestPoints.Add(new Vector2D(fvectorDouble.X, fvectorDouble.Y));
					i++;
				}
				aactor.K2_DestroyActor();
				return true;
			}
			return false;
		}

		// Token: 0x06044F7E RID: 282494 RVA: 0x011F4574 File Offset: 0x011F2774
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

		// Token: 0x06044F7F RID: 282495 RVA: 0x011F461C File Offset: 0x011F281C
		public bool BinTest(IVector2D inputP)
		{
			Vector2D vector2D = new Vector2D(inputP.X, inputP.Y);
			BinSet binSet = this.BinSet;
			List<Vector2D> testPoints = this.TestPoints;
			if (vector2D.Y < binSet.MinY || vector2D.Y >= binSet.MaxY || vector2D.X < binSet.MinX || vector2D.X >= binSet.MaxX)
			{
				return false;
			}
			int index = (int)Math.Floor((vector2D.Y - binSet.MinY) * binSet.ReciprocalDeltaY);
			Bin bin = binSet.Bins[index];
			if (vector2D.X < bin.MinX || vector2D.X > bin.MaxX)
			{
				return false;
			}
			List<Edge> edgeSet = bin.EdgeSet;
			int count = bin.Count;
			int num = 0;
			bool flag = false;
			int i = 0;
			while (i < count)
			{
				if (vector2D.X < edgeSet[num].MinX)
				{
					do
					{
						if (edgeSet[num].FullCross)
						{
							flag = !flag;
						}
						else
						{
							int id = edgeSet[num].Id;
							if (vector2D.Y <= testPoints[id].Y != vector2D.Y <= testPoints[(id + 1) % testPoints.Count].Y)
							{
								flag = !flag;
							}
						}
						num++;
					}
					while (++i < count);
					return flag;
				}
				if (vector2D.X < edgeSet[num].MaxX)
				{
					int id2 = edgeSet[num].Id;
					Vector2D vector2D2 = testPoints[id2];
					Vector2D vector2D3 = testPoints[(id2 + 1) % testPoints.Count];
					if ((edgeSet[num].FullCross || vector2D.Y <= vector2D2.Y != vector2D.Y <= vector2D3.Y) && vector2D2.X - (vector2D2.Y - vector2D.Y) * (vector2D3.X - vector2D2.X) / (vector2D3.Y - vector2D2.Y) >= vector2D.X)
					{
						flag = !flag;
					}
				}
				i++;
				num++;
			}
			return flag;
		}

		// Token: 0x06044F80 RID: 282496 RVA: 0x011F485C File Offset: 0x011F2A5C
		private void BinSetup(List<Vector2D> polygon, int binNum, BinSet binSet)
		{
			int[] array = new int[binNum];
			binSet.BinNum = binNum;
			binSet.Bins = new List<Bin>(binNum);
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
			binSet.ReciprocalDeltaY = 1.0 / binSet.DeltaY;
			Vector2D vector2D2 = polygon[polygon.Count - 1];
			foreach (Vector2D vector2D3 in polygon)
			{
				Vector2D vector2D3;
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
					int num = (int)Math.Floor((vector2D5.Y - binSet.MinY) * binSet.ReciprocalDeltaY);
					double num2 = (vector2D4.Y - binSet.MinY) * binSet.ReciprocalDeltaY;
					int num3 = (int)Math.Floor(num2);
					if (num2 - (double)num3 == 0.0)
					{
						num3--;
					}
					for (int j = num; j <= num3; j++)
					{
						array[j]++;
					}
				}
				vector2D2 = vector2D3;
			}
			for (int k = 0; k < binNum; k++)
			{
				binSet.Bins.Add(new Bin());
				List<Edge> list = new List<Edge>(array[k]);
				for (int l = 0; l < array[k]; l++)
				{
					list.Add(new Edge());
				}
				binSet.Bins[k].EdgeSet = list;
				binSet.Bins[k].MinX = binSet.MaxX;
				binSet.Bins[k].MaxX = binSet.MinX;
				binSet.Bins[k].Count = 0;
			}
			vector2D2 = polygon[polygon.Count - 1];
			int id = polygon.Count - 1;
			for (int m = 0; m < polygon.Count; m++)
			{
				Vector2D vector2D3 = polygon[m];
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
					double num4 = (vector2D5.Y - binSet.MinY) * binSet.ReciprocalDeltaY;
					int num5 = (int)Math.Floor(num4);
					double num6 = (vector2D4.Y - binSet.MinY) * binSet.ReciprocalDeltaY;
					int num7 = (int)Math.Floor(num6);
					if (num6 - (double)num7 == 0.0)
					{
						num7--;
					}
					double num8 = vector2D5.X;
					double num9 = binSet.DeltaY * (vector2D4.X - vector2D5.X) / (vector2D4.Y - vector2D5.Y);
					double num10 = num8;
					bool fullCross = false;
					int n = num5;
					while (n < num7)
					{
						num10 = vector2D5.X + ((double)(n + 1) - num4) * num9;
						int count = binSet.Bins[n].Count;
						binSet.Bins[n].Count++;
						binSet.Bins[n].EdgeSet[count].Id = id;
						binSet.Bins[n].EdgeSet[count].FullCross = fullCross;
						this.TrapBound(n, count, num8, num10, binSet);
						fullCross = true;
						n++;
						num8 = num10;
					}
					num8 = num10;
					num10 = vector2D4.X;
					Bin bin = binSet.Bins[num7];
					int count2 = bin.Count;
					bin.Count = count2 + 1;
					int num11 = count2;
					binSet.Bins[num7].EdgeSet[num11].Id = id;
					binSet.Bins[num7].EdgeSet[num11].FullCross = false;
					this.TrapBound(num7, num11, num8, num10, binSet);
				}
				vector2D2 = vector2D3;
				id = m;
			}
			for (int num12 = 0; num12 < binSet.BinNum; num12++)
			{
				binSet.Bins[num12].EdgeSet.Sort(delegate(Edge a, Edge b)
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

		// Token: 0x04026763 RID: 157539
		private const int TEST_AREA_COUNT = 30;

		// Token: 0x04026764 RID: 157540
		public int MapId = -1;

		// Token: 0x04026765 RID: 157541
		public int DungeonId = -1;

		// Token: 0x04026766 RID: 157542
		public BinSet BinSet = new BinSet();

		// Token: 0x04026767 RID: 157543
		public List<Vector2D> TestPoints = new List<Vector2D>();

		// Token: 0x04026768 RID: 157544
		[Nullable(2)]
		public Action InitCallback;
	}
}
