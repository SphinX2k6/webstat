using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Quest;
using AkiClient.Game.Aki.Data.Gameplay.Tetris;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F02 RID: 20226
	[NullableContext(1)]
	[Nullable(0)]
	public class SlidingBlocksUtil : IStaticVariableResetter
	{
		// Token: 0x06034477 RID: 214135 RVA: 0x00D13D98 File Offset: 0x00D11F98
		static SlidingBlocksUtil()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SlidingBlocksUtil.CreateStaticDefaultValue), new Action(SlidingBlocksUtil.ResetStaticDefaultValue));
		}

		// Token: 0x06034478 RID: 214136 RVA: 0x00D13DB8 File Offset: 0x00D11FB8
		public static string GetCoordKey(double x, double y)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<double>(x);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<double>(y);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06034479 RID: 214137 RVA: 0x00D13DF4 File Offset: 0x00D11FF4
		public static void FillMinoMapByIndexGridConfig(Vector2D gridSize, IReadOnlyList<ITetrisSingleIndexGrid> gridsConfig, Action<string, double, double> callback)
		{
			foreach (ITetrisSingleIndexGrid tetrisSingleIndexGrid in gridsConfig)
			{
				double floatCoord = Math.Floor((double)tetrisSingleIndexGrid.Index / gridSize.X);
				double floatCoord2 = (double)tetrisSingleIndexGrid.Index % gridSize.X;
				ITetrisSingleBlock block = tetrisSingleIndexGrid.Value.Block;
				if (!StringUtils.IsBlank((block != null) ? block.StyleName : null))
				{
					double arg = SlidingBlocksUtil.ConvertConfigCoordToSmooth(floatCoord2);
					double arg2 = SlidingBlocksUtil.ConvertConfigCoordToSmooth(floatCoord);
					callback(tetrisSingleIndexGrid.Value.Block.StyleName, arg, arg2);
				}
			}
		}

		// Token: 0x0603447A RID: 214138 RVA: 0x00D13EA0 File Offset: 0x00D120A0
		public static void FillMinoMapByGridConfig(IReadOnlyList<ITetrisSingleGrid> gridsConfig, float boardSizeX, Action<string, double, double> callback)
		{
			int num = 0;
			int num2 = 0;
			foreach (ITetrisSingleGrid tetrisSingleGrid in gridsConfig)
			{
				ITetrisSingleBlock block = tetrisSingleGrid.Block;
				if (!StringUtils.IsBlank((block != null) ? block.StyleName : null))
				{
					double arg = SlidingBlocksUtil.ConvertConfigCoordToSmooth((double)num2);
					double arg2 = SlidingBlocksUtil.ConvertConfigCoordToSmooth((double)num);
					callback(tetrisSingleGrid.Block.StyleName, arg, arg2);
				}
				num2++;
				if ((float)num2 > boardSizeX - 1f)
				{
					num++;
					num2 = 0;
				}
			}
		}

		// Token: 0x0603447B RID: 214139 RVA: 0x00D13F3C File Offset: 0x00D1213C
		[return: Nullable(2)]
		public static ITetrominoConfig GetTetrominoConfigByShapeName(string shapeName)
		{
			TetrisShapeConfig? config = ConfigTetrisShapeConfigByName.GetConfig(shapeName, true);
			if (config == null)
			{
				return null;
			}
			ITetrisBoard tetrisBoard = Json.Parse<ITetrisBoard>(config.Value.Shape, null);
			if (tetrisBoard == null)
			{
				return null;
			}
			return new TetrominoConfig
			{
				ShapeName = config.Value.Name,
				Type = Enum.Parse<SlidingBlocksDefine.ETetrominoType>(config.Value.LogicType),
				Board = tetrisBoard
			};
		}

		// Token: 0x0603447C RID: 214140 RVA: 0x00D13FB4 File Offset: 0x00D121B4
		public static SlidingBlocksDefine.ETetrominoRotateState ConvertToTetrisRotationState(ETetrisRotation config)
		{
			SlidingBlocksDefine.ETetrominoRotateState result = SlidingBlocksDefine.ETetrominoRotateState.角度0;
			switch (config)
			{
			case ETetrisRotation.Origin:
				result = SlidingBlocksDefine.ETetrominoRotateState.角度0;
				break;
			case ETetrisRotation.Clockwise90:
				result = SlidingBlocksDefine.ETetrominoRotateState.角度90;
				break;
			case ETetrisRotation.Clockwise180:
				result = SlidingBlocksDefine.ETetrominoRotateState.角度180;
				break;
			case ETetrisRotation.Clockwise270:
				result = SlidingBlocksDefine.ETetrominoRotateState.角度270;
				break;
			}
			return result;
		}

		// Token: 0x0603447D RID: 214141 RVA: 0x00D13FEC File Offset: 0x00D121EC
		[return: Nullable(2)]
		public static AActor CreateDynamicCube(string styleName, double smoothX, double smoothY, Transform originTransform, [Nullable(2)] UStaticMesh boxMesh)
		{
			if (boxMesh == null || !boxMesh.IsValid())
			{
				return null;
			}
			Transform transformByCoord = SlidingBlocksUtil.GetTransformByCoord(smoothX, smoothY, originTransform, null);
			AActor cubeActor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
			AActor cubeActor3 = cubeActor;
			if (cubeActor3 == null || !cubeActor3.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("SlidingBlocksController.CreateDynamicCube fail", cubeActor, null);
				return null;
			}
			cubeActor.AddComponentByClass(USceneComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
			AActor cubeActor2 = cubeActor;
			FTransformDouble ftransformDouble = transformByCoord.ToUeTransform();
			cubeActor2.D_K2_SetActorTransform(ftransformDouble, false, null, true);
			UStaticMeshComponent staticMeshComp = cubeActor.AddComponentByClass(UStaticMeshComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UStaticMeshComponent;
			UStaticMeshComponent staticMeshComp2 = staticMeshComp;
			if (staticMeshComp2 != null && staticMeshComp2.IsValid())
			{
				staticMeshComp.SetStaticMesh(boxMesh);
				TetrisStyleConfig? config = ConfigTetrisStyleConfigByName.GetConfig(styleName, true);
				if (config != null)
				{
					if (Singleton<ResourceSystem>.Instance.CheckAssetLoaded<UMaterialInterface>(config.Value.MaterialPath))
					{
						UMaterialInterface loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UMaterialInterface>(config.Value.MaterialPath);
						UMaterialInstanceDynamic material = UKismetMaterialLibrary.CreateDynamicMaterialInstance(cubeActor, loadedAsset, default(FName), EMIDCreationFlags.None);
						staticMeshComp.SetMaterial(0, material);
					}
					else
					{
						Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInterface>(config.Value.MaterialPath, delegate([Nullable(2)] UMaterialInterface ret, string _)
						{
							UMaterialInstanceDynamic material2 = UKismetMaterialLibrary.CreateDynamicMaterialInstance(cubeActor, ret, default(FName), EMIDCreationFlags.None);
							staticMeshComp.SetMaterial(0, material2);
						}, 100, "js_undefined");
					}
				}
			}
			return cubeActor;
		}

		// Token: 0x0603447E RID: 214142 RVA: 0x00D141B6 File Offset: 0x00D123B6
		public static bool DestroyCube(AActor cubeActor)
		{
			return Singleton<ActorSystem>.Instance.Put("SlidingBlocksUtil.DestroyCube", cubeActor, null);
		}

		// Token: 0x0603447F RID: 214143 RVA: 0x00D141CC File Offset: 0x00D123CC
		public static global::Vector GetWorldLocationByCoord(double smoothX, double smoothY, Transform originTransform, [Nullable(2)] global::Vector @out = null)
		{
			Bp_Tetris_C setting = SlidingBlocksGlobal.Setting;
			float num = ((setting != null) ? setting.CubeSize : 1.8f) * 100f;
			global::Vector tempVector = SlidingBlocksUtil._tempVector;
			if (tempVector != null)
			{
				tempVector.Set(smoothX * (double)num, 0.0, -smoothY * (double)num);
			}
			global::Vector vector = @out ?? global::Vector.Create();
			if (SlidingBlocksUtil._tempVector != null)
			{
				originTransform.TransformPosition(SlidingBlocksUtil._tempVector, vector);
			}
			return vector;
		}

		// Token: 0x06034480 RID: 214144 RVA: 0x00D14238 File Offset: 0x00D12438
		public static Transform GetTransformByCoord(double smoothX, double smoothY, Transform originTransform, [Nullable(2)] Transform @out = null)
		{
			Transform transform = @out ?? Transform.Create();
			SlidingBlocksUtil.GetWorldLocationByCoord(smoothX, smoothY, originTransform, transform.GetLocation());
			transform.SetRotation(originTransform.GetRotation());
			float cubeSize = SlidingBlocksGlobal.Setting.CubeSize;
			transform.SetScale3D(global::Vector.Create((double)cubeSize, (double)cubeSize, (double)cubeSize));
			return transform;
		}

		// Token: 0x06034481 RID: 214145 RVA: 0x00D14288 File Offset: 0x00D12488
		public static double ConvertConfigCoordToSmooth(double floatCoord)
		{
			return floatCoord + 0.5;
		}

		// Token: 0x06034482 RID: 214146 RVA: 0x00D14295 File Offset: 0x00D12495
		public static double StandardSmoothCoordToCellCenter(double floatCoord)
		{
			return Math.Floor(floatCoord) + 0.5;
		}

		// Token: 0x06034483 RID: 214147 RVA: 0x00D142A8 File Offset: 0x00D124A8
		public static double MapToHalfInteger(double x)
		{
			double num = x + 0.5;
			double num2 = Math.Floor(num);
			if (num2.Equals(num))
			{
				return x;
			}
			return num2 + 0.5;
		}

		// Token: 0x06034484 RID: 214148 RVA: 0x00D142DF File Offset: 0x00D124DF
		public static void CreateStaticDefaultValue()
		{
			SlidingBlocksUtil._tempVector = global::Vector.Create();
		}

		// Token: 0x06034485 RID: 214149 RVA: 0x00D142EB File Offset: 0x00D124EB
		public static void ResetStaticDefaultValue()
		{
			SlidingBlocksUtil._tempVector = null;
		}

		// Token: 0x0401E2A1 RID: 123553
		[Nullable(2)]
		private static global::Vector _tempVector;
	}
}
