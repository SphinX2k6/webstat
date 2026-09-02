using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Module.WorldMap.ViewComponent.SteamingLoad;

// Token: 0x02002D72 RID: 11634
[NullableContext(1)]
[Nullable(0)]
public class WorldMapStreamingComponent : MapComponent
{
	// Token: 0x060177AF RID: 96175 RVA: 0x00681D64 File Offset: 0x0067FF64
	public WorldMapStreamingComponent([Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
	{
	}

	// Token: 0x17001EFA RID: 7930
	// (get) Token: 0x060177B0 RID: 96176 RVA: 0x00681DBA File Offset: 0x0067FFBA
	public override EMapComponent ComponentType
	{
		get
		{
			return EMapComponent.WorldMapStreaming;
		}
	}

	// Token: 0x17001EFB RID: 7931
	// (get) Token: 0x060177B1 RID: 96177 RVA: 0x00681DC0 File Offset: 0x0067FFC0
	[Nullable(2)]
	private WorldMapUiEntity WorldMapUiComponent
	{
		[NullableContext(2)]
		get
		{
			WorldMapUiEntity worldMapUiEntity = base.Parent.AsT3 as WorldMapUiEntity;
			if (worldMapUiEntity == null)
			{
				base.LogError(ELogAuthor.LRX, "[地图系统]->二级界面组件没有附加到容器下！", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return worldMapUiEntity;
		}
	}

	// Token: 0x060177B2 RID: 96178 RVA: 0x00681E00 File Offset: 0x00680000
	protected override void OnUpdate()
	{
		this.RefreshViewportCache();
		foreach (IWorldMapStreamingObject obj in this.StreamingObjectSet)
		{
			this.HandleStreamingUpdate(obj);
		}
	}

	// Token: 0x060177B3 RID: 96179 RVA: 0x00681E5C File Offset: 0x0068005C
	public void RefreshViewportCache()
	{
		WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
		Vector2D mapUiPosition = worldMapUiComponent.MoveComponent.MapUiPosition;
		Vector2D outOfViewPortSize = worldMapUiComponent.OutOfViewPortSize;
		this.MapUiPositionCache.Set(mapUiPosition.X, mapUiPosition.Y);
		this.OutOfViewPortSizeCache.Set(outOfViewPortSize.X, outOfViewPortSize.Y);
		this.MapScaleCache = ModelBase<WorldMapModel>.Instance.MapScale;
	}

	// Token: 0x060177B4 RID: 96180 RVA: 0x00681EBF File Offset: 0x006800BF
	protected override void OnRemove()
	{
		this.StreamingObjectSet.Clear();
		this.StreamingStateMap.Clear();
	}

	// Token: 0x060177B5 RID: 96181 RVA: 0x00681ED7 File Offset: 0x006800D7
	public void Bind(IWorldMapStreamingObject obj)
	{
		this.StreamingObjectSet.Add(obj);
	}

	// Token: 0x060177B6 RID: 96182 RVA: 0x00681EE6 File Offset: 0x006800E6
	public void Unbind(IWorldMapStreamingObject obj)
	{
		this.StreamingObjectSet.Remove(obj);
		this.StreamingStateMap.Remove(obj);
	}

	// Token: 0x060177B7 RID: 96183 RVA: 0x00681F04 File Offset: 0x00680104
	public void BindAll(IReadOnlyList<IWorldMapStreamingObject> objList)
	{
		foreach (IWorldMapStreamingObject obj in objList)
		{
			this.Bind(obj);
		}
	}

	// Token: 0x060177B8 RID: 96184 RVA: 0x00681F4C File Offset: 0x0068014C
	public bool HandleStreamingUpdate(IWorldMapStreamingObject obj)
	{
		bool flag = this.IsInStreamingRange(obj);
		bool value;
		bool? flag2 = this.StreamingStateMap.TryGetValue(obj, out value) ? new bool?(value) : null;
		if (flag2 == null || flag != flag2.Value)
		{
			this.StreamingStateMap[obj] = flag;
			obj.IsVisible = flag;
			if (flag)
			{
				obj.OnLoad();
			}
			else
			{
				obj.OnUnload();
			}
		}
		return flag;
	}

	// Token: 0x060177B9 RID: 96185 RVA: 0x00681FBC File Offset: 0x006801BC
	public bool IsInStreamingRange(IWorldMapStreamingObject obj)
	{
		if (!obj.IsStreaming)
		{
			return true;
		}
		Vector uiPosition = obj.GetUiPosition();
		this.ObjectPositionInMapViewportTemp.Set(uiPosition.X * (double)this.MapScaleCache + this.MapUiPositionCache.X, uiPosition.Y * (double)this.MapScaleCache + this.MapUiPositionCache.Y);
		Vector2D preloadThreshold = obj.GetPreloadThreshold();
		return Math.Abs(this.ObjectPositionInMapViewportTemp.X) <= this.OutOfViewPortSizeCache.X + preloadThreshold.X && Math.Abs(this.ObjectPositionInMapViewportTemp.Y) <= this.OutOfViewPortSizeCache.Y + preloadThreshold.Y;
	}

	// Token: 0x0400B40A RID: 46090
	private readonly HashSet<IWorldMapStreamingObject> StreamingObjectSet = new HashSet<IWorldMapStreamingObject>();

	// Token: 0x0400B40B RID: 46091
	private readonly Dictionary<IWorldMapStreamingObject, bool> StreamingStateMap = new Dictionary<IWorldMapStreamingObject, bool>();

	// Token: 0x0400B40C RID: 46092
	private readonly Vector2D ObjectPositionInMapViewportTemp = Vector2D.Create();

	// Token: 0x0400B40D RID: 46093
	private readonly Vector2D MapUiPositionCache = Vector2D.Create();

	// Token: 0x0400B40E RID: 46094
	private readonly Vector2D OutOfViewPortSizeCache = Vector2D.Create();

	// Token: 0x0400B40F RID: 46095
	private float MapScaleCache = 1f;
}
