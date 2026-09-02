using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant
{
	// Token: 0x020057F3 RID: 22515
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRoadWaysMgr
	{
		// Token: 0x0603946F RID: 234607 RVA: 0x00E88B24 File Offset: 0x00E86D24
		public MapRoadWaysMgr(MapRoadWaysMgrParams param)
		{
			this.MapId = param.MapId;
			this.InstanceDungeonId = param.InstanceDungeonId;
			this.Container = param.Container;
			Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureRoadDataUpdate, new Action(this.OnMapSetup));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.MapOpenFogChange, new Action<int>(this.OnMapOpenFogChange));
			Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, bool>>(EEventName.MapOpenFogFullUpdate, new Action<IReadOnlyDictionary<int, bool>>(this.OnMapOpenFogFullUpdate));
		}

		// Token: 0x06039470 RID: 234608 RVA: 0x00E88BE6 File Offset: 0x00E86DE6
		private void OnMapOpenFogChange(int i)
		{
			this.OnMapSetup();
		}

		// Token: 0x06039471 RID: 234609 RVA: 0x00E88BEE File Offset: 0x00E86DEE
		private void OnMapOpenFogFullUpdate(IReadOnlyDictionary<int, bool> readOnlyDictionary)
		{
			this.OnMapSetup();
		}

		// Token: 0x06039472 RID: 234610 RVA: 0x00E88BF6 File Offset: 0x00E86DF6
		public void OnMapSetup()
		{
			this.ClearRoadWays();
			this.LoadAllMapRoadWays().Forget();
		}

		// Token: 0x06039473 RID: 234611 RVA: 0x00E88C0C File Offset: 0x00E86E0C
		private void ClearRoadWays()
		{
			foreach (MapRoadWayView mapRoadWayView in this.RoadWays)
			{
				mapRoadWayView.SetUiActive(false);
				this.RoadWaysPool.Add(mapRoadWayView);
			}
			this.RoadWays.Clear();
		}

		// Token: 0x06039474 RID: 234612 RVA: 0x00E88C78 File Offset: 0x00E86E78
		private UniTask LoadAllMapRoadWays()
		{
			MapRoadWaysMgr.<LoadAllMapRoadWays>d__13 <LoadAllMapRoadWays>d__;
			<LoadAllMapRoadWays>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadAllMapRoadWays>d__.<>4__this = this;
			<LoadAllMapRoadWays>d__.<>1__state = -1;
			<LoadAllMapRoadWays>d__.<>t__builder.Start<MapRoadWaysMgr.<LoadAllMapRoadWays>d__13>(ref <LoadAllMapRoadWays>d__);
			return <LoadAllMapRoadWays>d__.<>t__builder.Task;
		}

		// Token: 0x06039475 RID: 234613 RVA: 0x00E88CBC File Offset: 0x00E86EBC
		private unsafe bool CheckRoadWayValid(MapRoadWays config)
		{
			if (config.RoadBuildId > 0)
			{
				InfrastructureModel instance = ModelBase<InfrastructureModel>.Instance;
				InfrastructureDefine.IInfrRoadData infrRoadData = (instance != null) ? instance.GetRoadDataByRoadId(config.RoadBuildId) : null;
				if (infrRoadData == null || infrRoadData.Status != InfrStatusPb.InfrStatusComplete)
				{
					return false;
				}
			}
			InstanceDungeon? config2 = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceDungeonId);
			int? num = (config2 != null) ? new int?(config2.GetValueOrDefault().MapConfigId) : null;
			int i = this.MapId;
			if ((num.GetValueOrDefault() == i & num != null) && !ConfigBase<WorldMapConfig>.Instance.IsMapInWorld(this.InstanceDungeonId) && !config.GetShowDungeonListBytes().Contains(this.InstanceDungeonId))
			{
				return false;
			}
			Span<int> fogIdArrayBytes = config.GetFogIdArrayBytes();
			for (i = 0; i < fogIdArrayBytes.Length; i++)
			{
				int fogId = *fogIdArrayBytes[i];
				if (!ModelBase<MapModel>.Instance.CheckFogUnlocked(fogId, null))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06039476 RID: 234614 RVA: 0x00E88DBC File Offset: 0x00E86FBC
		private UniTask LoadMapRoadWay(int mapId, string roadWayTexPath, float[] anchorOffset, float scale)
		{
			MapRoadWaysMgr.<LoadMapRoadWay>d__15 <LoadMapRoadWay>d__;
			<LoadMapRoadWay>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadMapRoadWay>d__.<>4__this = this;
			<LoadMapRoadWay>d__.mapId = mapId;
			<LoadMapRoadWay>d__.roadWayTexPath = roadWayTexPath;
			<LoadMapRoadWay>d__.anchorOffset = anchorOffset;
			<LoadMapRoadWay>d__.scale = scale;
			<LoadMapRoadWay>d__.<>1__state = -1;
			<LoadMapRoadWay>d__.<>t__builder.Start<MapRoadWaysMgr.<LoadMapRoadWay>d__15>(ref <LoadMapRoadWay>d__);
			return <LoadMapRoadWay>d__.<>t__builder.Task;
		}

		// Token: 0x06039477 RID: 234615 RVA: 0x00E88E20 File Offset: 0x00E87020
		public void OnChangeWorldMap(int mapId)
		{
			this.MapId = mapId;
			this.OnMapSetup();
		}

		// Token: 0x06039478 RID: 234616 RVA: 0x00E88E30 File Offset: 0x00E87030
		public void Dispose()
		{
			foreach (MapRoadWayView mapRoadWayView in this.RoadWays)
			{
				mapRoadWayView.Destroy(null);
			}
			this.RoadWays.Clear();
			foreach (MapRoadWayView mapRoadWayView2 in this.RoadWaysPool)
			{
				mapRoadWayView2.Destroy(null);
			}
			this.RoadWaysPool.Clear();
			Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureRoadDataUpdate, new Action(this.OnMapSetup));
			Singleton<EventSystem>.Instance.Remove(EEventName.MapOpenFogChange, new Action<int>(this.OnMapOpenFogChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.MapOpenFogFullUpdate, new Action<IReadOnlyDictionary<int, bool>>(this.OnMapOpenFogFullUpdate));
		}

		// Token: 0x040208EE RID: 133358
		private int MapId;

		// Token: 0x040208EF RID: 133359
		private readonly int InstanceDungeonId;

		// Token: 0x040208F0 RID: 133360
		private readonly UUIItem Container;

		// Token: 0x040208F1 RID: 133361
		private readonly List<MapRoadWayView> RoadWays = new List<MapRoadWayView>();

		// Token: 0x040208F2 RID: 133362
		private readonly List<MapRoadWayView> RoadWaysPool = new List<MapRoadWayView>();

		// Token: 0x040208F3 RID: 133363
		private readonly Vector2D AnchorOffset = Vector2D.Create();

		// Token: 0x040208F4 RID: 133364
		private readonly global::Vector Scale = global::Vector.Create();

		// Token: 0x040208F5 RID: 133365
		private readonly string RoadWayPrefabPath = "/Game/Aki/UI/UIResources/UiWorldMap/Prefabs/UiItem_MapRoadWay_Prefab.UiItem_MapRoadWay_Prefab";
	}
}
