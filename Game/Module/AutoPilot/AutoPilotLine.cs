using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant;
using CSharpScript.Game.Module.Transport;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006144 RID: 24900
	[NullableContext(1)]
	[Nullable(0)]
	public class AutoPilotLine
	{
		// Token: 0x17009ADB RID: 39643
		// (get) Token: 0x0603EE5A RID: 257626 RVA: 0x0101E98B File Offset: 0x0101CB8B
		// (set) Token: 0x0603EE5B RID: 257627 RVA: 0x0101E993 File Offset: 0x0101CB93
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<BaseMap, MiniMap> Map { [return: Nullable(new byte[]
		{
			0,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			0,
			1,
			1
		})] private set; }

		// Token: 0x0603EE5C RID: 257628 RVA: 0x0101E99C File Offset: 0x0101CB9C
		public AutoPilotLine([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<BaseMap, MiniMap> map)
		{
			this.Map = map;
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateAutoPilotLine, new Action(this.OnUpdateAutoPilotLine));
		}

		// Token: 0x0603EE5D RID: 257629 RVA: 0x0101EA60 File Offset: 0x0101CC60
		private void SetComponentWidthAndHeight()
		{
			Vector2D vector2D;
			if (!this.Map.IsT1)
			{
				MapTileMgr mapTileMgr = this.Map.AsT2.MapTileMgr;
				vector2D = ((mapTileMgr != null) ? mapTileMgr.TotalTileSize : null);
			}
			else
			{
				vector2D = this.Map.AsT1.MapTileMgr.TotalTileSize;
			}
			Vector2D vector2D2 = vector2D;
			if (vector2D2 == null)
			{
				return;
			}
			AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
			if (autoPilotLineComponent != null)
			{
				UUIItem rootItem = autoPilotLineComponent.GetRootItem();
				if (rootItem != null)
				{
					rootItem.SetWidth((float)vector2D2.X);
				}
			}
			AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
			if (autoPilotLineComponent2 == null)
			{
				return;
			}
			UUIItem rootItem2 = autoPilotLineComponent2.GetRootItem();
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetHeight((float)vector2D2.Y);
		}

		// Token: 0x0603EE5E RID: 257630 RVA: 0x0101EB00 File Offset: 0x0101CD00
		private UniTask InitComponentAsync()
		{
			AutoPilotLine.<InitComponentAsync>d__19 <InitComponentAsync>d__;
			<InitComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitComponentAsync>d__.<>4__this = this;
			<InitComponentAsync>d__.<>1__state = -1;
			<InitComponentAsync>d__.<>t__builder.Start<AutoPilotLine.<InitComponentAsync>d__19>(ref <InitComponentAsync>d__);
			return <InitComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EE5F RID: 257631 RVA: 0x0101EB43 File Offset: 0x0101CD43
		public void CheckAutoPilotLineInfo()
		{
			this.CheckAutoPilotLineAsync().Forget();
		}

		// Token: 0x0603EE60 RID: 257632 RVA: 0x0101EB50 File Offset: 0x0101CD50
		private UniTask CheckAutoPilotLineAsync()
		{
			AutoPilotLine.<CheckAutoPilotLineAsync>d__21 <CheckAutoPilotLineAsync>d__;
			<CheckAutoPilotLineAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckAutoPilotLineAsync>d__.<>4__this = this;
			<CheckAutoPilotLineAsync>d__.<>1__state = -1;
			<CheckAutoPilotLineAsync>d__.<>t__builder.Start<AutoPilotLine.<CheckAutoPilotLineAsync>d__21>(ref <CheckAutoPilotLineAsync>d__);
			return <CheckAutoPilotLineAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EE61 RID: 257633 RVA: 0x0101EB94 File Offset: 0x0101CD94
		public void Destroy()
		{
			if (this.AutoPilotLineComponent != null)
			{
				this.AutoPilotLineComponent.SkipDestroyActor = false;
				this.AutoPilotLineComponent.Destroy(null);
				this.AutoPilotLineComponent = null;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateAutoPilotLine, new Action(this.OnUpdateAutoPilotLine));
		}

		// Token: 0x0603EE62 RID: 257634 RVA: 0x0101EBE4 File Offset: 0x0101CDE4
		private void OnUpdateAutoPilotLine()
		{
			this.CheckAutoPilotLineInfo();
		}

		// Token: 0x0603EE63 RID: 257635 RVA: 0x0101EBEC File Offset: 0x0101CDEC
		public void RefreshFindPathLine()
		{
			AutoPilotFindPathResult findPathResult = ModelBase<AutoPilotModel>.Instance.GetFindPathResult();
			int num = this.Map.IsT1 ? this.Map.AsT1.MapId : this.Map.AsT2.MapId;
			if (findPathResult != null && (findPathResult.MapId == num || findPathResult.MapId == 105))
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent != null)
				{
					UUIItem findPathRoot = autoPilotLineComponent.FindPathRoot;
					if (findPathRoot != null)
					{
						findPathRoot.SetUIActive(true);
					}
				}
				this.SetScale();
				this.DrawStartPoint(findPathResult);
				this.DrawEndPoint(findPathResult);
				this.DrawPlayerToStartLine(findPathResult);
				this.DrawEndToTargetLine(findPathResult);
				this.DrawPlayerToTargetLine(findPathResult);
				this.DrawFindPathHighLightLine(findPathResult);
				return;
			}
			AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
			if (autoPilotLineComponent2 == null)
			{
				return;
			}
			UUIItem findPathRoot2 = autoPilotLineComponent2.FindPathRoot;
			if (findPathRoot2 == null)
			{
				return;
			}
			findPathRoot2.SetUIActive(false);
		}

		// Token: 0x0603EE64 RID: 257636 RVA: 0x0101ECBC File Offset: 0x0101CEBC
		private void DrawStartPoint(AutoPilotFindPathResult result)
		{
			float mapScale = ModelBase<WorldMapModel>.Instance.MapScale;
			float mapScaleMin = ModelBase<WorldMapModel>.Instance.MapScaleMin;
			EMapType emapType = this.Map.IsT1 ? this.Map.AsT1.MapType : this.Map.AsT2.MapType;
			bool flag = mapScale <= mapScaleMin && emapType == EMapType.WorldMap;
			if (!result.GetIsShowStartPoint() || flag)
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent == null)
				{
					return;
				}
				UUIItem startPoint = autoPilotLineComponent.StartPoint;
				if (startPoint == null)
				{
					return;
				}
				startPoint.SetUIActive(false);
				return;
			}
			else
			{
				AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent2 != null)
				{
					UUIItem startPoint2 = autoPilotLineComponent2.StartPoint;
					if (startPoint2 != null)
					{
						startPoint2.SetUIActive(true);
					}
				}
				this.TmpVector2D.Set(result.StartPoint.X, result.StartPoint.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, this.StartPoint2D);
				AutoPilotLineComponent autoPilotLineComponent3 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent3 != null)
				{
					UUIItem startPoint3 = autoPilotLineComponent3.StartPoint;
					if (startPoint3 != null)
					{
						startPoint3.SetAnchorOffset(this.StartPoint2D.ToUeVector2D(false));
					}
				}
				AutoPilotLineComponent autoPilotLineComponent4 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent4 == null)
				{
					return;
				}
				UUIItem startPoint4 = autoPilotLineComponent4.StartPoint;
				if (startPoint4 == null)
				{
					return;
				}
				startPoint4.SetUIItemScale(this.Scale3D.ToUeVectorOld());
				return;
			}
		}

		// Token: 0x0603EE65 RID: 257637 RVA: 0x0101EDE8 File Offset: 0x0101CFE8
		private void DrawEndPoint(AutoPilotFindPathResult result)
		{
			float mapScale = ModelBase<WorldMapModel>.Instance.MapScale;
			float mapScaleMin = ModelBase<WorldMapModel>.Instance.MapScaleMin;
			EMapType emapType = this.Map.IsT1 ? this.Map.AsT1.MapType : this.Map.AsT2.MapType;
			bool flag = mapScale <= mapScaleMin && emapType == EMapType.WorldMap;
			if (!result.GetIsShowEndPoint() || flag)
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent == null)
				{
					return;
				}
				UUIItem endPoint = autoPilotLineComponent.EndPoint;
				if (endPoint == null)
				{
					return;
				}
				endPoint.SetUIActive(false);
				return;
			}
			else
			{
				AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent2 != null)
				{
					UUIItem endPoint2 = autoPilotLineComponent2.EndPoint;
					if (endPoint2 != null)
					{
						endPoint2.SetUIActive(true);
					}
				}
				this.TmpVector2D.Set(result.EndPoint.X, result.EndPoint.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, this.EndPoint2D);
				AutoPilotLineComponent autoPilotLineComponent3 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent3 != null)
				{
					UUIItem endPoint3 = autoPilotLineComponent3.EndPoint;
					if (endPoint3 != null)
					{
						endPoint3.SetAnchorOffset(this.EndPoint2D.ToUeVector2D(false));
					}
				}
				AutoPilotLineComponent autoPilotLineComponent4 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent4 == null)
				{
					return;
				}
				UUIItem endPoint4 = autoPilotLineComponent4.EndPoint;
				if (endPoint4 == null)
				{
					return;
				}
				endPoint4.SetUIItemScale(this.Scale3D.ToUeVectorOld());
				return;
			}
		}

		// Token: 0x0603EE66 RID: 257638 RVA: 0x0101EF14 File Offset: 0x0101D114
		private void DrawPlayerToStartLine(AutoPilotFindPathResult result)
		{
			if (!result.GetIsShowPlayerToStartLine())
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent == null)
				{
					return;
				}
				UUIItem playerToStartLine = autoPilotLineComponent.PlayerToStartLine;
				if (playerToStartLine == null)
				{
					return;
				}
				playerToStartLine.SetUIActive(false);
				return;
			}
			else
			{
				AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent2 != null)
				{
					UUIItem playerToStartLine2 = autoPilotLineComponent2.PlayerToStartLine;
					if (playerToStartLine2 != null)
					{
						playerToStartLine2.SetUIActive(true);
					}
				}
				this.TmpVector2D.Set(result.PlayerPoint.X, result.PlayerPoint.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, this.PlayerPoint2D);
				AutoPilotLineComponent autoPilotLineComponent3 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent3 != null)
				{
					UUIItem playerToStartLine3 = autoPilotLineComponent3.PlayerToStartLine;
					if (playerToStartLine3 != null)
					{
						playerToStartLine3.SetAnchorOffset(this.PlayerPoint2D.ToUeVector2D(false));
					}
				}
				this.TmpVector2D.Set(result.StartPoint.X, result.StartPoint.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, this.StartPoint2D);
				double num = Vector2D.Distance(this.PlayerPoint2D, this.StartPoint2D);
				num *= this.ScaleDivideOne;
				AutoPilotLineComponent autoPilotLineComponent4 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent4 != null)
				{
					UUIItem playerToStartLine4 = autoPilotLineComponent4.PlayerToStartLine;
					if (playerToStartLine4 != null)
					{
						playerToStartLine4.SetHeight((float)num);
					}
				}
				AutoPilotLineComponent autoPilotLineComponent5 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent5 != null)
				{
					UUIItem playerToStartLine5 = autoPilotLineComponent5.PlayerToStartLine;
					if (playerToStartLine5 != null)
					{
						playerToStartLine5.SetUIItemScale(this.Scale3D.ToUeVectorOld());
					}
				}
				this.PlayerToStartLineRotator.Yaw = (float)(Math.Atan2(this.StartPoint2D.Y - this.PlayerPoint2D.Y, this.StartPoint2D.X - this.PlayerPoint2D.X) * 57.295780181884766 - 90.0);
				AutoPilotLineComponent autoPilotLineComponent6 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent6 == null)
				{
					return;
				}
				UUIItem playerToStartLine6 = autoPilotLineComponent6.PlayerToStartLine;
				if (playerToStartLine6 == null)
				{
					return;
				}
				FRotator frotator = this.PlayerToStartLineRotator.ToUeRotator();
				playerToStartLine6.SetUIRelativeRotation(frotator);
				return;
			}
		}

		// Token: 0x0603EE67 RID: 257639 RVA: 0x0101F0CC File Offset: 0x0101D2CC
		private void DrawEndToTargetLine(AutoPilotFindPathResult result)
		{
			if (!result.GetIsShowEndToTargetLine())
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent == null)
				{
					return;
				}
				UUIItem endToTargetLine = autoPilotLineComponent.EndToTargetLine;
				if (endToTargetLine == null)
				{
					return;
				}
				endToTargetLine.SetUIActive(false);
				return;
			}
			else
			{
				AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent2 != null)
				{
					UUIItem endToTargetLine2 = autoPilotLineComponent2.EndToTargetLine;
					if (endToTargetLine2 != null)
					{
						endToTargetLine2.SetUIActive(true);
					}
				}
				this.TmpVector2D.Set(result.EndPoint.X, result.EndPoint.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, this.EndPoint2D);
				AutoPilotLineComponent autoPilotLineComponent3 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent3 != null)
				{
					UUIItem endToTargetLine3 = autoPilotLineComponent3.EndToTargetLine;
					if (endToTargetLine3 != null)
					{
						endToTargetLine3.SetAnchorOffset(this.EndPoint2D.ToUeVector2D(false));
					}
				}
				this.TmpVector2D.Set(result.TargetPoint.X, result.TargetPoint.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, this.TargetPoint2D);
				double num = Vector2D.Distance(this.EndPoint2D, this.TargetPoint2D);
				num *= this.ScaleDivideOne;
				AutoPilotLineComponent autoPilotLineComponent4 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent4 != null)
				{
					UUIItem endToTargetLine4 = autoPilotLineComponent4.EndToTargetLine;
					if (endToTargetLine4 != null)
					{
						endToTargetLine4.SetHeight((float)num);
					}
				}
				AutoPilotLineComponent autoPilotLineComponent5 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent5 != null)
				{
					UUIItem endToTargetLine5 = autoPilotLineComponent5.EndToTargetLine;
					if (endToTargetLine5 != null)
					{
						endToTargetLine5.SetUIItemScale(this.Scale3D.ToUeVectorOld());
					}
				}
				this.EndToTargetLineRotator.Yaw = (float)(Math.Atan2(this.TargetPoint2D.Y - this.EndPoint2D.Y, this.TargetPoint2D.X - this.EndPoint2D.X) * 57.295780181884766 - 90.0);
				AutoPilotLineComponent autoPilotLineComponent6 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent6 == null)
				{
					return;
				}
				UUIItem endToTargetLine6 = autoPilotLineComponent6.EndToTargetLine;
				if (endToTargetLine6 == null)
				{
					return;
				}
				FRotator frotator = this.EndToTargetLineRotator.ToUeRotator();
				endToTargetLine6.SetUIRelativeRotation(frotator);
				return;
			}
		}

		// Token: 0x0603EE68 RID: 257640 RVA: 0x0101F284 File Offset: 0x0101D484
		private void DrawPlayerToTargetLine(AutoPilotFindPathResult result)
		{
			if (!result.GetIsShowPlayerToTargetLine())
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent == null)
				{
					return;
				}
				UUIItem playerToTargetLine = autoPilotLineComponent.PlayerToTargetLine;
				if (playerToTargetLine == null)
				{
					return;
				}
				playerToTargetLine.SetUIActive(false);
				return;
			}
			else
			{
				AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent2 != null)
				{
					UUIItem playerToTargetLine2 = autoPilotLineComponent2.PlayerToTargetLine;
					if (playerToTargetLine2 != null)
					{
						playerToTargetLine2.SetUIActive(true);
					}
				}
				this.TmpVector2D.Set(result.PlayerPoint.X, result.PlayerPoint.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, this.PlayerPoint2D);
				AutoPilotLineComponent autoPilotLineComponent3 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent3 != null)
				{
					UUIItem playerToTargetLine3 = autoPilotLineComponent3.PlayerToTargetLine;
					if (playerToTargetLine3 != null)
					{
						playerToTargetLine3.SetAnchorOffset(this.PlayerPoint2D.ToUeVector2D(false));
					}
				}
				this.TmpVector2D.Set(result.TargetPoint.X, result.TargetPoint.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, this.TargetPoint2D);
				double num = Vector2D.Distance(this.PlayerPoint2D, this.TargetPoint2D);
				num *= this.ScaleDivideOne;
				AutoPilotLineComponent autoPilotLineComponent4 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent4 != null)
				{
					UUIItem playerToTargetLine4 = autoPilotLineComponent4.PlayerToTargetLine;
					if (playerToTargetLine4 != null)
					{
						playerToTargetLine4.SetHeight((float)num);
					}
				}
				AutoPilotLineComponent autoPilotLineComponent5 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent5 != null)
				{
					UUIItem playerToTargetLine5 = autoPilotLineComponent5.PlayerToTargetLine;
					if (playerToTargetLine5 != null)
					{
						playerToTargetLine5.SetUIItemScale(this.Scale3D.ToUeVectorOld());
					}
				}
				this.PlayerToTargetLineRotator.Yaw = (float)(Math.Atan2(this.TargetPoint2D.Y - this.PlayerPoint2D.Y, this.TargetPoint2D.X - this.PlayerPoint2D.X) * 57.295780181884766 - 90.0);
				AutoPilotLineComponent autoPilotLineComponent6 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent6 == null)
				{
					return;
				}
				UUIItem playerToTargetLine6 = autoPilotLineComponent6.PlayerToTargetLine;
				if (playerToTargetLine6 == null)
				{
					return;
				}
				FRotator frotator = this.PlayerToTargetLineRotator.ToUeRotator();
				playerToTargetLine6.SetUIRelativeRotation(frotator);
				return;
			}
		}

		// Token: 0x0603EE69 RID: 257641 RVA: 0x0101F43C File Offset: 0x0101D63C
		private void DrawFindPathHighLightLine(AutoPilotFindPathResult result)
		{
			if (!result.GetIsShowHighLightLine())
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent == null)
				{
					return;
				}
				UUI2DLineRaw findPathHighLightLine = autoPilotLineComponent.FindPathHighLightLine;
				if (findPathHighLightLine == null)
				{
					return;
				}
				findPathHighLightLine.SetUIActive(false);
				return;
			}
			else
			{
				AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent2 != null)
				{
					UUI2DLineRaw findPathHighLightLine2 = autoPilotLineComponent2.FindPathHighLightLine;
					if (findPathHighLightLine2 != null)
					{
						findPathHighLightLine2.SetUIActive(true);
					}
				}
				AutoPilotLineComponent autoPilotLineComponent3 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent3 == null)
				{
					return;
				}
				UUI2DLineRaw findPathHighLightLine3 = autoPilotLineComponent3.FindPathHighLightLine;
				if (findPathHighLightLine3 == null)
				{
					return;
				}
				findPathHighLightLine3.SetPoints(result.SplinePoints, false);
				return;
			}
		}

		// Token: 0x0603EE6A RID: 257642 RVA: 0x0101F4AC File Offset: 0x0101D6AC
		public void SetScale()
		{
			bool flag = (this.Map.IsT1 ? this.Map.AsT1.MapType : this.Map.AsT2.MapType) == EMapType.MiniMap;
			float num = flag ? 1f : ModelBase<WorldMapModel>.Instance.MapScale;
			double num2;
			if (flag)
			{
				UUIItem uuiitem = this.Map.IsT2 ? this.Map.AsT2.GetRootItem() : null;
				num2 = (double)((uuiitem != null) ? uuiitem.RelativeScale3D.X : 1f);
			}
			else
			{
				num2 = 1.0;
			}
			this.ScaleDivideOne = (double)num * num2;
			double num3 = 1.0 / this.ScaleDivideOne;
			this.Scale3D.Set(num3, num3, num3);
		}

		// Token: 0x0603EE6B RID: 257643 RVA: 0x0101F580 File Offset: 0x0101D780
		private void RefreshCirclePathHighLightLine()
		{
			AutoPilotCirclePathResult circlePathResult = ModelBase<AutoPilotModel>.Instance.GetCirclePathResult();
			int num = this.Map.IsT1 ? this.Map.AsT1.MapId : this.Map.AsT2.MapId;
			if (circlePathResult != null && (circlePathResult.MapId == num || circlePathResult.MapId == 105))
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent != null)
				{
					UUIItem circlePathRoot = autoPilotLineComponent.CirclePathRoot;
					if (circlePathRoot != null)
					{
						circlePathRoot.SetUIActive(true);
					}
				}
				this.DrawCirclePathHighLightLine(circlePathResult);
				this.DrawPathToCircleHighLightLine(circlePathResult);
				return;
			}
			AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
			if (autoPilotLineComponent2 != null)
			{
				UUIItem circlePathRoot2 = autoPilotLineComponent2.CirclePathRoot;
				if (circlePathRoot2 != null)
				{
					circlePathRoot2.SetUIActive(false);
				}
			}
			AutoPilotLineComponent autoPilotLineComponent3 = this.AutoPilotLineComponent;
			if (autoPilotLineComponent3 == null)
			{
				return;
			}
			autoPilotLineComponent3.ResetCircleId();
		}

		// Token: 0x0603EE6C RID: 257644 RVA: 0x0101F640 File Offset: 0x0101D840
		private void DrawCirclePathHighLightLine(AutoPilotCirclePathResult result)
		{
			AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
			if (autoPilotLineComponent == null)
			{
				return;
			}
			autoPilotLineComponent.LoadCirclePathHighLightLine(result.CircleId).Forget();
		}

		// Token: 0x0603EE6D RID: 257645 RVA: 0x0101F660 File Offset: 0x0101D860
		private void DrawPathToCircleHighLightLine(AutoPilotCirclePathResult result)
		{
			if (result.GetIsInCircle())
			{
				AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
				if (autoPilotLineComponent == null)
				{
					return;
				}
				UUI2DLineRaw pathToCircleHighLightLine = autoPilotLineComponent.PathToCircleHighLightLine;
				if (pathToCircleHighLightLine == null)
				{
					return;
				}
				pathToCircleHighLightLine.SetUIActive(false);
				return;
			}
			else
			{
				AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent2 != null)
				{
					UUI2DLineRaw pathToCircleHighLightLine2 = autoPilotLineComponent2.PathToCircleHighLightLine;
					if (pathToCircleHighLightLine2 != null)
					{
						pathToCircleHighLightLine2.SetUIActive(true);
					}
				}
				AutoPilotLineComponent autoPilotLineComponent3 = this.AutoPilotLineComponent;
				if (autoPilotLineComponent3 == null)
				{
					return;
				}
				UUI2DLineRaw pathToCircleHighLightLine3 = autoPilotLineComponent3.PathToCircleHighLightLine;
				if (pathToCircleHighLightLine3 == null)
				{
					return;
				}
				pathToCircleHighLightLine3.SetPoints(result.PathToCircleSplinePoints, false);
				return;
			}
		}

		// Token: 0x0603EE6E RID: 257646 RVA: 0x0101F6CF File Offset: 0x0101D8CF
		public void OnMiniMapTick()
		{
			this.CheckAutoPilotLineInfo();
		}

		// Token: 0x0603EE6F RID: 257647 RVA: 0x0101F6D8 File Offset: 0x0101D8D8
		public void DrawDebugLine(int[] roadWayIds)
		{
			AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
			if (autoPilotLineComponent != null)
			{
				autoPilotLineComponent.RecycleDebugLine();
			}
			foreach (int roadwayId in roadWayIds)
			{
				UKuroRoadway roadWay = ControllerBase<TransportNetworkController>.Instance.GetTransportSystem().GetRoadWay(roadwayId);
				if (roadWay != null && roadWay.RoadSpline != null)
				{
					TArray<FVector2D> tarray = new TArray<FVector2D>();
					AutoPilotUtil.GenerateSingleSplinePoints(roadWay.RoadSpline, tarray);
					AutoPilotLineComponent autoPilotLineComponent2 = this.AutoPilotLineComponent;
					if (autoPilotLineComponent2 != null)
					{
						autoPilotLineComponent2.CreateDebugRoadLine(tarray).Forget();
					}
				}
			}
		}

		// Token: 0x0603EE70 RID: 257648 RVA: 0x0101F754 File Offset: 0x0101D954
		public void DebugDrawCircle(int[] roadWayIds)
		{
			List<UKuroRoadway> list = new List<UKuroRoadway>();
			foreach (int roadwayId in roadWayIds)
			{
				UKuroRoadway roadWay = ControllerBase<TransportNetworkController>.Instance.GetTransportSystem().GetRoadWay(roadwayId);
				if (roadWay != null && roadWay.RoadSpline != null)
				{
					list.Add(roadWay);
				}
			}
			TArray<FVector2D> tarray = new TArray<FVector2D>();
			AutoPilotUtil.GenerateAllSplinePoints(list.ToArray(), tarray, null, null, null);
			AutoPilotLineComponent autoPilotLineComponent = this.AutoPilotLineComponent;
			if (autoPilotLineComponent == null)
			{
				return;
			}
			autoPilotLineComponent.CreateDebugRoadLine(tarray).Forget();
		}

		// Token: 0x0603EE71 RID: 257649 RVA: 0x0101F7D0 File Offset: 0x0101D9D0
		private void RefreshDebugLine()
		{
			if ((this.Map.IsT1 ? this.Map.AsT1.MapType : this.Map.AsT2.MapType) != EMapType.WorldMap)
			{
				return;
			}
			if (ModelBase<AutoPilotModel>.Instance.DebugCircleId != 0)
			{
				AutoPilotCircles? autoPilotCircles;
				int[] array = (ConfigAutoPilotCirclesById.GetConfig(ModelBase<AutoPilotModel>.Instance.DebugCircleId, true) != null) ? autoPilotCircles.GetValueOrDefault().GetWaySplinesArray() : null;
				if (array == null || array.Length == 0)
				{
					return;
				}
				this.DebugDrawCircle(array);
				ModelBase<AutoPilotModel>.Instance.DebugCircleId = 0;
				return;
			}
			else
			{
				List<int> debugRoadWayIds = ModelBase<AutoPilotModel>.Instance.DebugRoadWayIds;
				if (debugRoadWayIds.Count == 0)
				{
					return;
				}
				this.DrawDebugLine(debugRoadWayIds.ToArray());
				ModelBase<AutoPilotModel>.Instance.DebugRoadWayIds.Clear();
				return;
			}
		}

		// Token: 0x040234AE RID: 144558
		[Nullable(2)]
		private AutoPilotLineComponent AutoPilotLineComponent;

		// Token: 0x040234AF RID: 144559
		[Nullable(2)]
		private UniTaskCompletionSource ComponentPromise;

		// Token: 0x040234B0 RID: 144560
		private readonly Vector2D TmpVector2D = Vector2D.Create();

		// Token: 0x040234B1 RID: 144561
		private readonly Vector2D StartPoint2D = Vector2D.Create();

		// Token: 0x040234B2 RID: 144562
		private readonly Vector2D PlayerPoint2D = Vector2D.Create();

		// Token: 0x040234B3 RID: 144563
		private readonly Vector2D TargetPoint2D = Vector2D.Create();

		// Token: 0x040234B4 RID: 144564
		private readonly Vector2D EndPoint2D = Vector2D.Create();

		// Token: 0x040234B5 RID: 144565
		private readonly Rotator PlayerToStartLineRotator = Rotator.Create();

		// Token: 0x040234B6 RID: 144566
		private readonly Rotator EndToTargetLineRotator = Rotator.Create();

		// Token: 0x040234B7 RID: 144567
		private readonly Rotator PlayerToTargetLineRotator = Rotator.Create();

		// Token: 0x040234B8 RID: 144568
		private double ScaleDivideOne = 1.0;

		// Token: 0x040234B9 RID: 144569
		private readonly global::Vector Scale3D = global::Vector.Create();

		// Token: 0x040234BA RID: 144570
		private readonly Stat StatsObject0 = Stat.Create("DrawFindPathHighLightLine", "", "");
	}
}
