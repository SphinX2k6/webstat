using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.WuwaGo.Controller.Role;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameMode
{
	// Token: 0x02004B18 RID: 19224
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoNormalGameMode : WuWaGoGameModeBase
	{
		// Token: 0x0603226C RID: 205420 RVA: 0x00C8D09B File Offset: 0x00C8B29B
		protected override bool OnStart()
		{
			this.PrimeFollowCameraToMainControl();
			return true;
		}

		// Token: 0x0603226D RID: 205421 RVA: 0x00C8D0A4 File Offset: 0x00C8B2A4
		protected override bool OnEnd()
		{
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			if (fightCamera != null)
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				if (logicComponent != null)
				{
					logicComponent.RestoreCameraFromAdjust(new float?((float)1), null, true);
				}
			}
			return true;
		}

		// Token: 0x0603226E RID: 205422 RVA: 0x00C8D0D5 File Offset: 0x00C8B2D5
		protected override void OnTick(float delta)
		{
			if (ModelBase<WuWaGoModel>.Instance.EnableDebug)
			{
				this.DrawDebug(this.GameData);
			}
			this.UpdateFollowCameraToMainControl();
			if (base.IsDeathSequenceActive || base.IsCinematicPlaying)
			{
				return;
			}
			this.RoundManager.Tick(delta);
		}

		// Token: 0x0603226F RID: 205423 RVA: 0x00C8D113 File Offset: 0x00C8B313
		private void PrimeFollowCameraToMainControl()
		{
			if (!this.UpdateFollowCameraToMainControl())
			{
				return;
			}
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			if (fightCamera == null)
			{
				return;
			}
			FightCameraLogicComponent component = fightCamera.GetComponent<FightCameraLogicComponent>();
			if (component == null)
			{
				return;
			}
			component.SnapZoneFollowToCurrentTarget();
		}

		// Token: 0x06032270 RID: 205424 RVA: 0x00C8D144 File Offset: 0x00C8B344
		private bool UpdateFollowCameraToMainControl()
		{
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.GetComponent<FightCameraLogicComponent>() : null;
			WuWaGoMainControlRole mainControlRole = this.GameData.MainControlRole;
			FVectorDouble? fvectorDouble = (mainControlRole != null) ? mainControlRole.GetWorldLocation() : null;
			if (fightCameraLogicComponent == null || fvectorDouble == null)
			{
				return false;
			}
			Vector followCameraTargetScratch = this.FollowCameraTargetScratch;
			FVectorDouble value = fvectorDouble.Value;
			followCameraTargetScratch.FromUeVector(value);
			fightCameraLogicComponent.UpdateZoneFollowTargetPosition(this.FollowCameraTargetScratch);
			return true;
		}

		// Token: 0x06032271 RID: 205425 RVA: 0x00C8D1BD File Offset: 0x00C8B3BD
		private void DrawDebug(WuWaGoGameData gameData)
		{
			this.DrawMainControlCoordinateText(gameData);
			this.DrawCurProcessUnitArrow(gameData);
			this.DrawAllGridLinks(gameData);
		}

		// Token: 0x06032272 RID: 205426 RVA: 0x00C8D1D4 File Offset: 0x00C8B3D4
		private void DrawMainControlCoordinateText(WuWaGoGameData gameData)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Vector vector;
			if (baseCharacter == null)
			{
				vector = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				vector = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
			}
			Vector vector2 = vector;
			if (vector2 == null)
			{
				return;
			}
			WuWaGoMainControlRole mainControlRole = gameData.MainControlRole;
			Vector vector3 = (mainControlRole != null) ? mainControlRole.Coordinate : null;
			UObject world = GlobalData.World;
			FVectorDouble textLocation = vector2.ToUeVector(false);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 3);
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted<double>((vector3 != null) ? vector3.X : 0.0);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<double>((vector3 != null) ? vector3.Y : 0.0);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<double>((vector3 != null) ? vector3.Z : 0.0);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			UKismetSystemLibrary.D_DrawDebugString(world, textLocation, defaultInterpolatedStringHandler.ToStringAndClear(), null, new FLinearColor?(WuWaGoNormalGameMode.DebugColorGreen), 0f);
		}

		// Token: 0x06032273 RID: 205427 RVA: 0x00C8D2C8 File Offset: 0x00C8B4C8
		private void DrawCurProcessUnitArrow(WuWaGoGameData gameData)
		{
			WuWaGoRoleController curProcessUnit = this.RoundManager.CurProcessUnit;
			if (curProcessUnit == null)
			{
				return;
			}
			Vector worldPositionByCoordinate = WuWaGoUtil.GetWorldPositionByCoordinate(gameData.OriginTransform, curProcessUnit.BaseRole.Coordinate, null);
			worldPositionByCoordinate.Z += 300.0;
			Vector vector = Vector.Create();
			vector.DeepCopy(worldPositionByCoordinate);
			vector.Z -= 50.0;
			UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, worldPositionByCoordinate.ToUeVector(false), vector.ToUeVector(false), 100f, WuWaGoNormalGameMode.DebugColorGreen, 1f, 25f);
		}

		// Token: 0x06032274 RID: 205428 RVA: 0x00C8D364 File Offset: 0x00C8B564
		private void DrawAllGridLinks(WuWaGoGameData gameData)
		{
			foreach (KeyValuePair<string, WuWaGoGrid> keyValuePair in gameData.Girds)
			{
				string text;
				WuWaGoGrid wuWaGoGrid;
				keyValuePair.Deconstruct(out text, out wuWaGoGrid);
				WuWaGoGrid wuWaGoGrid2 = wuWaGoGrid;
				this.DrawGridLinkDebug(gameData, wuWaGoGrid2, wuWaGoGrid2.LinkedDirections, WuWaGoNormalGameMode.DebugColorGreen);
			}
		}

		// Token: 0x06032275 RID: 205429 RVA: 0x00C8D3D4 File Offset: 0x00C8B5D4
		private void DrawGearTrackLinks(WuWaGoGameData gameData)
		{
			foreach (WuWaGoGrid wuWaGoGrid in this.CollectGearTrackGrids(gameData))
			{
				this.DrawGridLinkDebug(gameData, wuWaGoGrid, wuWaGoGrid.GearLinkDirections, WuWaGoNormalGameMode.DebugColorGear);
			}
		}

		// Token: 0x06032276 RID: 205430 RVA: 0x00C8D430 File Offset: 0x00C8B630
		private IReadOnlyList<WuWaGoGrid> CollectGearTrackGrids(WuWaGoGameData gameData)
		{
			this.DebugGearGridKeys.Clear();
			List<WuWaGoGrid> list = new List<WuWaGoGrid>();
			foreach (WuWaGoGameplayEntityBase wuWaGoGameplayEntityBase in gameData.GetGameplayEntitiesByType(EWuWaGoEntityType.Gear))
			{
				foreach (int pbDataId in (wuWaGoGameplayEntityBase as WuWaGoGearTrapEntity).TrackEntityIds)
				{
					WuWaGoGrid gameplayGridByPbDataId = gameData.GetGameplayGridByPbDataId(pbDataId);
					if (gameplayGridByPbDataId != null && gameplayGridByPbDataId.HasGearPath)
					{
						string coordinateKeyByVector = WuWaGoUtil.GetCoordinateKeyByVector(gameplayGridByPbDataId.Coordinate);
						if (this.DebugGearGridKeys.Add(coordinateKeyByVector))
						{
							list.Add(gameplayGridByPbDataId);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06032277 RID: 205431 RVA: 0x00C8D504 File Offset: 0x00C8B704
		private void DrawGridLinkDebug(WuWaGoGameData gameData, WuWaGoGrid grid, IReadOnlyList<Vector> directions, FLinearColor color)
		{
			IWallFrame wallFrame = (grid.GridShape == EGridShape.Vertical) ? grid.WallFrame : null;
			if (grid.GridShape == EGridShape.Vertical && wallFrame == null)
			{
				return;
			}
			Vector worldPositionByCoordinate = WuWaGoUtil.GetWorldPositionByCoordinate(gameData.OriginTransform, grid.Coordinate, null);
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, worldPositionByCoordinate.ToUeVector(false), 15f, 12, new FLinearColor?(color), 1f, 0f);
			UObject world = GlobalData.World;
			FVectorDouble textLocation = worldPositionByCoordinate.ToUeVector(false);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted<double>(grid.Coordinate.X);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<double>(grid.Coordinate.Y);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<double>(grid.Coordinate.Z);
			UKismetSystemLibrary.D_DrawDebugString(world, textLocation, defaultInterpolatedStringHandler.ToStringAndClear(), null, new FLinearColor?(color), 0f);
			Quat rotation = gameData.OriginTransform.GetRotation();
			rotation.Multiply(grid.Rotator.Quaternion(null), this.DebugScratchQuat);
			this.DebugScratchQuat.RotateVector(WuWaGoNormalGameMode.DebugLocalUpStep, this.DebugScratchLocalUp);
			worldPositionByCoordinate.Addition(this.DebugScratchLocalUp, this.DebugScratchArrowOrigin);
			int singleGridSize = WuWaGoGlobal.Setting.SingleGridSize;
			int num = (wallFrame != null) ? wallFrame.WallNormalX : 0;
			int num2 = (wallFrame != null) ? wallFrame.WallNormalY : 0;
			foreach (Vector vector in directions)
			{
				double num3 = (wallFrame != null) ? (vector.X * (double)num + vector.Y * (double)num2) : 0.0;
				double num4 = vector.X - num3 * (double)num;
				double num5 = vector.Y - num3 * (double)num2;
				double num6 = (grid.GridShape == EGridShape.Horizontal) ? 0.0 : vector.Z;
				double num7 = Math.Max(Math.Max(Math.Abs(num4), Math.Abs(num5)), Math.Abs(num6));
				if (num7 != 0.0)
				{
					double num8 = 0.5 / num7;
					this.DebugScratchLocalHalfDelta.Set(num4 * num8, num5 * num8, num6 * num8);
					this.DebugScratchLocalHalfDelta.MultiplyEqual((double)singleGridSize);
					rotation.RotateVector(this.DebugScratchLocalHalfDelta, this.DebugScratchHalfDeltaWorld);
					this.DebugScratchArrowOrigin.Addition(this.DebugScratchHalfDeltaWorld, this.DebugScratchArrowHalfEnd);
					UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, this.DebugScratchArrowOrigin.ToUeVector(false), this.DebugScratchArrowHalfEnd.ToUeVector(false), 100f, color, 1f, 5f);
				}
			}
		}

		// Token: 0x0401D4E8 RID: 120040
		private readonly Vector FollowCameraTargetScratch = Vector.Create();

		// Token: 0x0401D4E9 RID: 120041
		private const bool ENABLE_GRID_LINK_DEBUG = true;

		// Token: 0x0401D4EA RID: 120042
		private const bool ENABLE_GEAR_TRACK_DEBUG = false;

		// Token: 0x0401D4EB RID: 120043
		[StaticVariableRuleIgnore]
		private static readonly Vector DebugLocalUpStep = Vector.Create(0.0, 0.0, 20.0);

		// Token: 0x0401D4EC RID: 120044
		[StaticVariableRuleIgnore]
		private static readonly FLinearColor DebugColorGreen = new FLinearColor(0f, 1f, 0f, 1f);

		// Token: 0x0401D4ED RID: 120045
		[StaticVariableRuleIgnore]
		private static readonly FLinearColor DebugColorGear = new FLinearColor(1f, 0.4f, 0f, 1f);

		// Token: 0x0401D4EE RID: 120046
		private readonly HashSet<string> DebugGearGridKeys = new HashSet<string>();

		// Token: 0x0401D4EF RID: 120047
		private readonly Vector DebugScratchArrowOrigin = Vector.Create();

		// Token: 0x0401D4F0 RID: 120048
		private readonly Vector DebugScratchLocalUp = Vector.Create();

		// Token: 0x0401D4F1 RID: 120049
		private readonly Vector DebugScratchLocalHalfDelta = Vector.Create();

		// Token: 0x0401D4F2 RID: 120050
		private readonly Vector DebugScratchHalfDeltaWorld = Vector.Create();

		// Token: 0x0401D4F3 RID: 120051
		private readonly Vector DebugScratchArrowHalfEnd = Vector.Create();

		// Token: 0x0401D4F4 RID: 120052
		private readonly Quat DebugScratchQuat = Quat.Create(0f, 0f, 0f, 1f);
	}
}
