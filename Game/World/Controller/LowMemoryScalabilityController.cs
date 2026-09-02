using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using UnrealEngine;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046E3 RID: 18147
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LowMemoryScalabilityController : ControllerBase<LowMemoryScalabilityController>
	{
		// Token: 0x17008142 RID: 33090
		// (get) Token: 0x0602F331 RID: 193329 RVA: 0x00B2F779 File Offset: 0x00B2D979
		private bool IsMobileLowMemoryDevice
		{
			get
			{
				return Singleton<Info>.Instance.IsLowMemoryDevice;
			}
		}

		// Token: 0x0602F332 RID: 193330 RVA: 0x00B2F788 File Offset: 0x00B2D988
		protected override bool OnInit()
		{
			if (!this.IsMobileLowMemoryDevice)
			{
				return true;
			}
			Singleton<EventSystem>.Instance.Add(EEventName.EndTravelMap, new Action(this.OnEndTravelMap));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeArea, new Action<int?, int>(this.OnChangeArea));
			Singleton<EventSystem>.Instance.Add(EEventName.OnManuallyClearStreamingPool, new Action(this.OnManuallyClearStreamingPool));
			Singleton<EventSystem>.Instance.Add(EEventName.OnManuallyResetStreamingPool, new Action(this.OnManuallyResetStreamingPool));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.LoadingRangeScaleChanged, new Action<float>(this.OnLoadingRangeScaleChanged));
			if (this.IsMobileLowMemoryDevice)
			{
				this.InitMobileLowMemorySettings();
			}
			return true;
		}

		// Token: 0x0602F333 RID: 193331 RVA: 0x00B2F858 File Offset: 0x00B2DA58
		protected override bool OnClear()
		{
			if (!this.IsMobileLowMemoryDevice)
			{
				return true;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.EndTravelMap, new Action(this.OnEndTravelMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeArea, new Action<int?, int>(this.OnChangeArea));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnManuallyClearStreamingPool, new Action(this.OnManuallyClearStreamingPool));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnManuallyResetStreamingPool, new Action(this.OnManuallyResetStreamingPool));
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.LoadingRangeScaleChanged, new Action<float>(this.OnLoadingRangeScaleChanged));
			UKuroBodySetupLibrary.EmptyClearWpBodySetupBlackList();
			return true;
		}

		// Token: 0x0602F334 RID: 193332 RVA: 0x00B2F920 File Offset: 0x00B2DB20
		private void InitMobileLowMemorySettings()
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.XY, "Init Mobile Low Memory Settings", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.UnloadHLODCellWhenAllHLODActorHidden 1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.EnableHLODCellMappingOptimization 1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.KuroSurfaceRipple.Enable 0", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.KuroInstanceGrassInteraction.Enabled 0", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.KuroWeaponEnvInteraction.Enabled 0", null);
		}

		// Token: 0x0602F335 RID: 193333 RVA: 0x00B2F999 File Offset: 0x00B2DB99
		private void OnEndTravelMap()
		{
			this.ScaleStreamingTextureOnEndTravelMap();
			this.OptimizeStreamingOnEndTravelMap();
			this.OptimizeStreamingGridRangeOnEndTravelMap();
		}

		// Token: 0x0602F336 RID: 193334 RVA: 0x00B2F9B0 File Offset: 0x00B2DBB0
		public bool IsSpecialLowMemoryMap()
		{
			int mapId = ModelBase<GameModeModel>.Instance.MapConfig.MapId;
			HashSet<int> hashSet;
			if (!LowMemoryScalabilityController.LowMemoryMapAreas.TryGetValue(mapId, out hashSet))
			{
				return false;
			}
			if (hashSet == null)
			{
				return true;
			}
			int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(new EAreaLevel?(EAreaLevel.FirstLevel));
			return hashSet.Contains(currentAreaId);
		}

		// Token: 0x0602F337 RID: 193335 RVA: 0x00B2FA00 File Offset: 0x00B2DC00
		public static bool IsMengZhouMap()
		{
			int mapId = ModelBase<GameModeModel>.Instance.MapConfig.MapId;
			if (mapId != 8)
			{
				return false;
			}
			HashSet<int> hashSet;
			if (!LowMemoryScalabilityController.LowMemoryMapAreas.TryGetValue(mapId, out hashSet))
			{
				return false;
			}
			if (hashSet == null)
			{
				return false;
			}
			int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(new EAreaLevel?(EAreaLevel.FirstLevel));
			return hashSet.Contains(currentAreaId);
		}

		// Token: 0x0602F338 RID: 193336 RVA: 0x00B2FA54 File Offset: 0x00B2DC54
		private void ScaleStreamingTextureOnEndTravelMap()
		{
			float value = 0.5f;
			float value2 = 0.3f;
			float value3 = 0.3f;
			float value4 = 1f;
			if (this.IsSpecialLowMemoryMap())
			{
				value = 0.2f;
				value2 = 0.15f;
				value3 = 0.15f;
				value4 = 0.8f;
			}
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.GroupBoost.LargeBuildingTextureFactor ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(49, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.GroupBoost.HugeBuildingTextureFactor ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(value2);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world3 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.GroupBoost.HugeRocTextureFactor ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(value3);
			UKismetSystemLibrary.ExecuteConsoleCommand(world3, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world4 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(49, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.GroupBoost.UnclassifiedTextureFactor ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(value4);
			UKismetSystemLibrary.ExecuteConsoleCommand(world4, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}

		// Token: 0x0602F339 RID: 193337 RVA: 0x00B2FB59 File Offset: 0x00B2DD59
		private void OptimizeStreamingOnEndTravelMap()
		{
			if (this.IsSpecialLowMemoryMap())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "s.ContinuouslyIncrementalGCWhileLevelsPendingPurge 1", null);
			}
			if (!Singleton<GameSettingsManager>.Instance.ReApply(EFunction.LOADINGRANGESCALELEVEL, EGameSettingsApplyReason.AnyTime, false))
			{
				this.OnLoadingRangeScaleChanged(1f);
			}
		}

		// Token: 0x0602F33A RID: 193338 RVA: 0x00B2FB91 File Offset: 0x00B2DD91
		private void OnWorldDone()
		{
			this.OnEndTravelMap();
			ControllerBase<WorldController>.Instance.ManuallyResetStreamingPool();
		}

		// Token: 0x0602F33B RID: 193339 RVA: 0x00B2FBA3 File Offset: 0x00B2DDA3
		private void OnChangeArea(int? preAreaId, int curAreaId)
		{
			this.OnWorldDone();
		}

		// Token: 0x0602F33C RID: 193340 RVA: 0x00B2FBAC File Offset: 0x00B2DDAC
		private void OptimizeStreamingGridRangeOnEndTravelMap()
		{
			if (!UKuroStaticLibrary.IsLowMemoryDevice())
			{
				return;
			}
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
			{
				if (LowMemoryScalabilityController.IsMengZhouMap())
				{
					Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.WLJ, "Enter MengZhouMap Set Grid_Collision Range 150", default(ReadOnlySpan<ValueTuple<string, object>>));
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.OverrideGridLoadingRanges Grid_StaticMesh_3m=35;Grid_StaticMesh_6m=50;Grid_StaticMesh_12m=50;Grid_Collision=150;Grid_HLOD_6400=0;Grid_CustomSSSuperFar=1500;Grid_CustomSSuperFar=500;Grid_CustomSuperFar=200;Grid_Imposter_400=10;Grid_Imposter_800=10;Grid_Imposter_1600=10;", null);
					return;
				}
				Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.WLJ, "Leave MengZhouMap Resume Grid_Collision Range", default(ReadOnlySpan<ValueTuple<string, object>>));
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.OverrideGridLoadingRanges Grid_StaticMesh_3m=35;Grid_StaticMesh_6m=50;Grid_StaticMesh_12m=50;", null);
			}
		}

		// Token: 0x0602F33D RID: 193341 RVA: 0x00B2FC30 File Offset: 0x00B2DE30
		private void OnManuallyClearStreamingPool()
		{
			if (this.IsSpecialLowMemoryMap() && this.IsMobileLowMemoryDevice && Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
			{
				Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.XY, "ManuallyClearStreamingPool In IOS Low Memory for Special Map", default(ReadOnlySpan<ValueTuple<string, object>>));
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.PoolSize ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(50);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				UObject world2 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.PoolSizeForMeshes ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(20);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
		}

		// Token: 0x0602F33E RID: 193342 RVA: 0x00B2FCE0 File Offset: 0x00B2DEE0
		private void OnManuallyResetStreamingPool()
		{
			if (this.IsSpecialLowMemoryMap() && this.IsMobileLowMemoryDevice && Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
			{
				Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.XY, "ManuallyResetStreamingPool In IOS Low Memory for Special Map", default(ReadOnlySpan<ValueTuple<string, object>>));
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.PoolSize ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(100);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				UObject world2 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.PoolSizeForMeshes ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(50);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
		}

		// Token: 0x0602F33F RID: 193343 RVA: 0x00B2FD8E File Offset: 0x00B2DF8E
		private void OnLoadingRangeScaleChanged(float value)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.PlannedLoadingRangeScaleExtra 0", null);
		}

		// Token: 0x0401AE4A RID: 110154
		private const int XUEYUAN_MAPID = 906;

		// Token: 0x0401AE4B RID: 110155
		private const int MAIN_WORLD_MAPID = 8;

		// Token: 0x0401AE4C RID: 110156
		[Nullable(new byte[]
		{
			1,
			2
		})]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, HashSet<int>> LowMemoryMapAreas = new Dictionary<int, HashSet<int>>
		{
			{
				906,
				null
			},
			{
				8,
				new HashSet<int>
				{
					44001,
					44002,
					44003,
					44004
				}
			}
		};

		// Token: 0x0401AE4D RID: 110157
		private const float LARGE_BUILDING_TEXTURE_FACTOR = 0.5f;

		// Token: 0x0401AE4E RID: 110158
		private const float LARGE_BUILDING_TEXTURE_FACTOR_LOW_MEMORY = 0.2f;

		// Token: 0x0401AE4F RID: 110159
		private const float HUGE_BUILDING_TEXTURE_FACTOR = 0.3f;

		// Token: 0x0401AE50 RID: 110160
		private const float HUGE_BUILDING_TEXTURE_FACTOR_LOW_MEMORY = 0.15f;

		// Token: 0x0401AE51 RID: 110161
		private const float HUGE_ROC_TEXTURE_FACTOR = 0.3f;

		// Token: 0x0401AE52 RID: 110162
		private const float HUGE_ROC_TEXTURE_FACTOR_LOW_MEMORY = 0.15f;

		// Token: 0x0401AE53 RID: 110163
		private const int UNCLASSIFIED_TEXTURE_FACTOR = 1;

		// Token: 0x0401AE54 RID: 110164
		private const float UNCLASSIFIED_TEXTURE_FACTOR_LOW_MEMORY = 0.8f;

		// Token: 0x0401AE55 RID: 110165
		private const int IOS_STREAMING_POOL_SIZE_LOW_MEMORY = 100;

		// Token: 0x0401AE56 RID: 110166
		private const int IOS_STREAMING_POOL_SIZE_FOR_MESHES_LOW_MEMORY = 50;

		// Token: 0x0401AE57 RID: 110167
		private const int IOS_STREAMING_POOL_SIZE_IN_LOADING_LOW_MEMORY = 50;

		// Token: 0x0401AE58 RID: 110168
		private const int IOS_STREAMING_POOL_SIZE_FOR_MESHES_IN_LOADING_LOW_MEMORY = 20;
	}
}
