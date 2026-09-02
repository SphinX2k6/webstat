using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x02005334 RID: 21300
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLinePathItem : UiPanelBase
	{
		// Token: 0x0603658E RID: 222606 RVA: 0x00DB345A File Offset: 0x00DB165A
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUI2DLineRaw)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x0603658F RID: 222607 RVA: 0x00DB3493 File Offset: 0x00DB1693
		public void DrawPath(QuestMultiLineComponentData componentData)
		{
			this.DrawPathByPoints(componentData.AnimMovePoint);
		}

		// Token: 0x06036590 RID: 222608 RVA: 0x00DB34A4 File Offset: 0x00DB16A4
		public void DrawPathByPoints(IntVector2D[] points)
		{
			if (points == null || points.Length < 2)
			{
				return;
			}
			List<global::Vector> list = new List<global::Vector>(points.Length);
			foreach (IntVector2D intVector2D in points)
			{
				list.Add(global::Vector.Create((double)intVector2D.X, (double)intVector2D.Y, 0.0));
			}
			this.DrawPathByPoints(list);
		}

		// Token: 0x06036591 RID: 222609 RVA: 0x00DB3508 File Offset: 0x00DB1708
		public void DrawPathByPoints(IReadOnlyList<global::Vector> points)
		{
			if (points == null || points.Count < 2)
			{
				return;
			}
			this.RootItem.SetUIActive(true);
			this.RootItem.SetAnchorOffset(new FVector2D(0f, 0f));
			CatmullRomCurve catmullRomCurve = new CatmullRomCurve(points);
			List<global::Vector> points2 = catmullRomCurve.GetPoints(100);
			this.FollowCurve = catmullRomCurve;
			this.FollowPresampled = points2;
			TArray<FVector2D> tarray = QuestMultiLineUtils.PointArrayToVectorArray(points2);
			UUI2DLineRaw uiLineRaw = base.GetUiLineRaw(0);
			if (uiLineRaw != null)
			{
				uiLineRaw.SetEndType(EUI2DLineRenderer_EndType.None);
				uiLineRaw.SetPoints(tarray, false);
			}
			global::Vector derivative = catmullRomCurve.GetDerivative(1.0);
			UUISprite sprite = base.GetSprite(1);
			Rotator rotator = Rotator.Create();
			rotator.Yaw = (float)(Math.Atan2(derivative.Y, derivative.X) * 180.0 / 3.141592653589793);
			FRotator frotator = rotator.ToUeRotator();
			sprite.SetUIRelativeRotation(frotator);
			sprite.SetAnchorOffset(tarray.Get(tarray.Num() - 1));
		}

		// Token: 0x06036592 RID: 222610 RVA: 0x00DB35FA File Offset: 0x00DB17FA
		public void SetVisibleForAnim(bool visible)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(visible);
			}
			if (visible)
			{
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 == null)
				{
					return;
				}
				rootItem2.SetAlpha(1f);
			}
		}

		// Token: 0x06036593 RID: 222611 RVA: 0x00DB3628 File Offset: 0x00DB1828
		public void SetVisibleProgress(float t)
		{
			if (this.FollowCurve == null || this.FollowPresampled == null)
			{
				return;
			}
			UUI2DLineRaw uiLineRaw = base.GetUiLineRaw(0);
			if (uiLineRaw == null)
			{
				return;
			}
			if (t < 1f)
			{
				float num = Math.Max(0f, t);
				global::Vector point = this.FollowCurve.GetPoint((double)num);
				int num2 = Math.Min(this.FollowPresampled.Count, (int)Math.Ceiling((double)(num * 100f)));
				List<global::Vector> list = new List<global::Vector>
				{
					global::Vector.Create(point.X, point.Y, 0.0)
				};
				for (int i = num2; i < this.FollowPresampled.Count; i++)
				{
					list.Add(this.FollowPresampled[i]);
				}
				if (list.Count < 2)
				{
					global::Vector vector = this.FollowPresampled[this.FollowPresampled.Count - 1];
					list.Add(global::Vector.Create(vector.X, vector.Y, 0.0));
				}
				TArray<FVector2D> tarray = QuestMultiLineUtils.PointArrayToVectorArray(list);
				uiLineRaw.SetPoints(tarray, false);
				return;
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(false);
		}

		// Token: 0x06036594 RID: 222612 RVA: 0x00DB3750 File Offset: 0x00DB1950
		public void PlayDrawProgressively(QuestMultiLineComponentData componentData, float? speedUiPxPerSec = null, [Nullable(2)] Action onComplete = null)
		{
			this.StopDraw();
			IntVector2D[] animMovePoint = componentData.AnimMovePoint;
			if (animMovePoint == null || animMovePoint.Length < 2)
			{
				Action onComplete2 = onComplete;
				if (onComplete2 == null)
				{
					return;
				}
				onComplete2();
				return;
			}
			else
			{
				this.RootItem.SetUIActive(true);
				this.RootItem.SetAnchorOffset(new FVector2D(0f, 0f));
				UUI2DLineRaw lineRaw = base.GetUiLineRaw(0);
				if (lineRaw == null)
				{
					Action onComplete3 = onComplete;
					if (onComplete3 == null)
					{
						return;
					}
					onComplete3();
					return;
				}
				else
				{
					lineRaw.SetEndType(EUI2DLineRenderer_EndType.None);
					CatmullRomCurve curve = new CatmullRomCurve(animMovePoint);
					List<global::Vector> presampled = curve.GetPoints(100);
					this.FollowCurve = curve;
					this.FollowPresampled = presampled;
					UUISprite arrowSprite = base.GetSprite(1);
					float num = speedUiPxPerSec ?? ((float)componentData.PathSpeed);
					if (num <= 0f)
					{
						this.ApplyFullPath(lineRaw, arrowSprite, curve, presampled);
						Action onComplete4 = onComplete;
						if (onComplete4 == null)
						{
							return;
						}
						onComplete4();
						return;
					}
					else
					{
						ICatmullRomArcLengthLookup arcLengthLookup = CatmullRomCurve.CreateArcLengthLookup(curve, 100);
						double totalArcLength = arcLengthLookup.TotalLength;
						if (totalArcLength > 0.0)
						{
							this.ApplyProgress(lineRaw, arrowSprite, curve, presampled, 0f);
							float speedAlongCurvePxPerMs = num / 1000f;
							double traveledArcLength = 0.0;
							TimerHandle timerHandle = TimerSystem.Instance.Forever(delegate(float delta)
							{
								traveledArcLength = Math.Min(totalArcLength, traveledArcLength + (double)(speedAlongCurvePxPerMs * delta));
								double parameterByArcLength = CatmullRomCurve.GetParameterByArcLength(arcLengthLookup, traveledArcLength);
								this.ApplyProgress(lineRaw, arrowSprite, curve, presampled, (float)parameterByArcLength);
								if (traveledArcLength >= totalArcLength)
								{
									this.ApplyFullPath(lineRaw, arrowSprite, curve, presampled);
									TimerHandle drawTimerHandle = this.DrawTimerHandle;
									if (drawTimerHandle != null)
									{
										drawTimerHandle.Remove();
									}
									this.DrawTimerHandle = null;
									Action onComplete6 = onComplete;
									if (onComplete6 == null)
									{
										return;
									}
									onComplete6();
								}
							}, 20f, 1f, null, "QuestMultiLinePathItem.PlayDrawProgressively", true);
							if (timerHandle != null)
							{
								this.DrawTimerHandle = timerHandle;
							}
							return;
						}
						this.ApplyFullPath(lineRaw, arrowSprite, curve, presampled);
						Action onComplete5 = onComplete;
						if (onComplete5 == null)
						{
							return;
						}
						onComplete5();
						return;
					}
				}
			}
		}

		// Token: 0x06036595 RID: 222613 RVA: 0x00DB395D File Offset: 0x00DB1B5D
		public void StopDraw()
		{
			if (this.DrawTimerHandle != null)
			{
				this.DrawTimerHandle.Remove();
				this.DrawTimerHandle = null;
			}
		}

		// Token: 0x06036596 RID: 222614 RVA: 0x00DB397A File Offset: 0x00DB1B7A
		protected override void OnBeforeDestroy()
		{
			this.StopDraw();
		}

		// Token: 0x06036597 RID: 222615 RVA: 0x00DB3984 File Offset: 0x00DB1B84
		private void ApplyProgress(UUI2DLineRaw lineRaw, UUISprite arrowSprite, CatmullRomCurve curve, IReadOnlyList<global::Vector> presampled, float t)
		{
			float num = Math.Min(1f, Math.Max(0f, t));
			int num2 = Math.Max(1, (int)Math.Floor((double)(num * 100f)));
			List<global::Vector> list = new List<global::Vector>();
			int num3 = 0;
			while (num3 < num2 && num3 < presampled.Count)
			{
				list.Add(presampled[num3]);
				num3++;
			}
			global::Vector point = curve.GetPoint((double)num);
			if (list.Count == 0)
			{
				list.Add(presampled[0]);
			}
			list.Add(global::Vector.Create(point.X, point.Y, 0.0));
			TArray<FVector2D> tarray = QuestMultiLineUtils.PointArrayToVectorArray(list);
			lineRaw.SetPoints(tarray, false);
			global::Vector derivative = curve.GetDerivative((double)num);
			Rotator rotator = Rotator.Create();
			rotator.Yaw = (float)(Math.Atan2(derivative.Y, derivative.X) * 180.0 / 3.141592653589793);
			FRotator frotator = rotator.ToUeRotator();
			arrowSprite.SetUIRelativeRotation(frotator);
			arrowSprite.SetAnchorOffset(new FVector2D((float)point.X, (float)point.Y));
		}

		// Token: 0x06036598 RID: 222616 RVA: 0x00DB3AA8 File Offset: 0x00DB1CA8
		private void ApplyFullPath(UUI2DLineRaw lineRaw, UUISprite arrowSprite, CatmullRomCurve curve, IReadOnlyList<global::Vector> presampled)
		{
			TArray<FVector2D> tarray = QuestMultiLineUtils.PointArrayToVectorArray(presampled);
			lineRaw.SetPoints(tarray, false);
			global::Vector derivative = curve.GetDerivative(1.0);
			Rotator rotator = Rotator.Create();
			rotator.Yaw = (float)(Math.Atan2(derivative.Y, derivative.X) * 180.0 / 3.141592653589793);
			FRotator frotator = rotator.ToUeRotator();
			arrowSprite.SetUIRelativeRotation(frotator);
			arrowSprite.SetAnchorOffset(tarray.Get(tarray.Num() - 1));
		}

		// Token: 0x0401F3FF RID: 127999
		[Nullable(2)]
		private TimerHandle DrawTimerHandle;

		// Token: 0x0401F400 RID: 128000
		[Nullable(2)]
		private CatmullRomCurve FollowCurve;

		// Token: 0x0401F401 RID: 128001
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<global::Vector> FollowPresampled;
	}
}
