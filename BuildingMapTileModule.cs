using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013A4 RID: 5028
[NullableContext(1)]
[Nullable(0)]
public class BuildingMapTileModule : UiPanelBase
{
	// Token: 0x06008A85 RID: 35461 RVA: 0x00247826 File Offset: 0x00245A26
	public BuildingMapTileModule(bool needLoadingFixRole, bool needLoadingShowRoleItem)
	{
		this.NeedLoadingFixRole = needLoadingFixRole;
		this.NeedLoadingShowRoleItem = needLoadingShowRoleItem;
	}

	// Token: 0x17000BC3 RID: 3011
	// (get) Token: 0x06008A86 RID: 35462 RVA: 0x0024785D File Offset: 0x00245A5D
	public bool NeedLoadingFixRole { get; }

	// Token: 0x17000BC4 RID: 3012
	// (get) Token: 0x06008A87 RID: 35463 RVA: 0x00247865 File Offset: 0x00245A65
	public bool NeedLoadingShowRoleItem { get; }

	// Token: 0x06008A88 RID: 35464 RVA: 0x00247870 File Offset: 0x00245A70
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem))
		};
	}

	// Token: 0x06008A89 RID: 35465 RVA: 0x002479C4 File Offset: 0x00245BC4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 2)
		{
			return null;
		}
		int key;
		if (configParams[1] == "CanLevelUp")
		{
			key = ModelBase<MoonChasingBuildingModel>.Instance.GetFirstCanLevelUpBuildingId().GetValueOrDefault();
		}
		else
		{
			key = int.Parse(configParams[1]);
		}
		BuildingItem buildingItem;
		if (!this.BuildingItemMap.TryGetValue(key, out buildingItem))
		{
			return null;
		}
		return buildingItem.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x06008A8A RID: 35466 RVA: 0x00247A20 File Offset: 0x00245C20
	private UniTask InitMapLayout()
	{
		BuildingMapTileModule.<InitMapLayout>d__17 <InitMapLayout>d__;
		<InitMapLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitMapLayout>d__.<>4__this = this;
		<InitMapLayout>d__.<>1__state = -1;
		<InitMapLayout>d__.<>t__builder.Start<BuildingMapTileModule.<InitMapLayout>d__17>(ref <InitMapLayout>d__);
		return <InitMapLayout>d__.<>t__builder.Task;
	}

	// Token: 0x06008A8B RID: 35467 RVA: 0x00247A64 File Offset: 0x00245C64
	private UniTask LoadMapTexture()
	{
		BuildingMapTileModule.<LoadMapTexture>d__18 <LoadMapTexture>d__;
		<LoadMapTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadMapTexture>d__.<>4__this = this;
		<LoadMapTexture>d__.<>1__state = -1;
		<LoadMapTexture>d__.<>t__builder.Start<BuildingMapTileModule.<LoadMapTexture>d__18>(ref <LoadMapTexture>d__);
		return <LoadMapTexture>d__.<>t__builder.Task;
	}

	// Token: 0x06008A8C RID: 35468 RVA: 0x00247AA8 File Offset: 0x00245CA8
	private List<UUIItem> GetBuildingItemList()
	{
		return new List<UUIItem>
		{
			base.GetItem(3),
			base.GetItem(4),
			base.GetItem(5),
			base.GetItem(6),
			base.GetItem(7),
			base.GetItem(8),
			base.GetItem(9),
			base.GetItem(10),
			base.GetItem(11),
			base.GetItem(12)
		};
	}

	// Token: 0x06008A8D RID: 35469 RVA: 0x00247B40 File Offset: 0x00245D40
	private UniTask InitBuild()
	{
		BuildingMapTileModule.<InitBuild>d__20 <InitBuild>d__;
		<InitBuild>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBuild>d__.<>4__this = this;
		<InitBuild>d__.<>1__state = -1;
		<InitBuild>d__.<>t__builder.Start<BuildingMapTileModule.<InitBuild>d__20>(ref <InitBuild>d__);
		return <InitBuild>d__.<>t__builder.Task;
	}

	// Token: 0x06008A8E RID: 35470 RVA: 0x00247B84 File Offset: 0x00245D84
	private UniTask CreateRoleItem(UUIItem parentItem, int roleId)
	{
		BuildingMapTileModule.<CreateRoleItem>d__21 <CreateRoleItem>d__;
		<CreateRoleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRoleItem>d__.<>4__this = this;
		<CreateRoleItem>d__.parentItem = parentItem;
		<CreateRoleItem>d__.roleId = roleId;
		<CreateRoleItem>d__.<>1__state = -1;
		<CreateRoleItem>d__.<>t__builder.Start<BuildingMapTileModule.<CreateRoleItem>d__21>(ref <CreateRoleItem>d__);
		return <CreateRoleItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008A8F RID: 35471 RVA: 0x00247BD8 File Offset: 0x00245DD8
	private List<int> GetRandomNumberList(int count, int endIndex)
	{
		HashSet<int> hashSet = new HashSet<int>();
		List<int> list = new List<int>();
		Random random = new Random();
		for (int i = 1; i <= count; i++)
		{
			int item = random.Next(endIndex);
			while (hashSet.Contains(item))
			{
				item = random.Next(endIndex);
			}
			hashSet.Add(item);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06008A90 RID: 35472 RVA: 0x00247C34 File Offset: 0x00245E34
	private UniTask InitRole()
	{
		BuildingMapTileModule.<InitRole>d__23 <InitRole>d__;
		<InitRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRole>d__.<>4__this = this;
		<InitRole>d__.<>1__state = -1;
		<InitRole>d__.<>t__builder.Start<BuildingMapTileModule.<InitRole>d__23>(ref <InitRole>d__);
		return <InitRole>d__.<>t__builder.Task;
	}

	// Token: 0x06008A91 RID: 35473 RVA: 0x00247C78 File Offset: 0x00245E78
	private UniTask InitShowRole()
	{
		BuildingMapTileModule.<InitShowRole>d__24 <InitShowRole>d__;
		<InitShowRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitShowRole>d__.<>4__this = this;
		<InitShowRole>d__.<>1__state = -1;
		<InitShowRole>d__.<>t__builder.Start<BuildingMapTileModule.<InitShowRole>d__24>(ref <InitShowRole>d__);
		return <InitShowRole>d__.<>t__builder.Task;
	}

	// Token: 0x06008A92 RID: 35474 RVA: 0x00247CBC File Offset: 0x00245EBC
	protected override UniTask OnBeforeStartAsync()
	{
		BuildingMapTileModule.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BuildingMapTileModule.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008A93 RID: 35475 RVA: 0x00247CFF File Offset: 0x00245EFF
	public void RefreshRole()
	{
		this.InitRole().Forget();
	}

	// Token: 0x06008A94 RID: 35476 RVA: 0x00247D0C File Offset: 0x00245F0C
	private BuildingMapTileModule.TileItem InitTileItem()
	{
		return new BuildingMapTileModule.TileItem(this.TileMgr);
	}

	// Token: 0x06008A95 RID: 35477 RVA: 0x00247D1C File Offset: 0x00245F1C
	public void SetAllBuildingExhibitionMode(bool bShowOnly)
	{
		foreach (BuildingItem buildingItem in this.BuildingItemMap.Values)
		{
			buildingItem.SetExhibitionMode(bShowOnly);
			buildingItem.SetInteractive(!bShowOnly);
		}
	}

	// Token: 0x06008A96 RID: 35478 RVA: 0x00247D7C File Offset: 0x00245F7C
	public void SetBuildingItemActive(bool value)
	{
		foreach (BuildingItem buildingItem in this.BuildingItemMap.Values)
		{
			buildingItem.SetBuildingItemActive(value);
		}
	}

	// Token: 0x06008A97 RID: 35479 RVA: 0x00247DD4 File Offset: 0x00245FD4
	public void RefreshBuildingItem(int buildingId)
	{
		this.BuildingItemMap[buildingId].Refresh();
	}

	// Token: 0x040040D9 RID: 16601
	private readonly BuildingMapTileMgr TileMgr = new BuildingMapTileMgr();

	// Token: 0x040040DA RID: 16602
	protected GenericLayout<BuildingMapTileModule.TileItem, string> MapLayout;

	// Token: 0x040040DB RID: 16603
	private readonly Dictionary<int, BuildingItem> BuildingItemMap = new Dictionary<int, BuildingItem>();

	// Token: 0x040040DC RID: 16604
	private readonly List<BuildingRoleItem> RoleItemList = new List<BuildingRoleItem>();

	// Token: 0x040040DD RID: 16605
	private BuildingMapShowRoleModule ShowRoleItem;

	// Token: 0x02007755 RID: 30549
	[NullableContext(0)]
	private static class ETileItem
	{
		// Token: 0x04029177 RID: 168311
		public const int Texture = 0;
	}

	// Token: 0x02007756 RID: 30550
	[Nullable(new byte[]
	{
		0,
		1
	})]
	protected class TileItem : GridProxyAbstract<string>
	{
		// Token: 0x06047357 RID: 291671 RVA: 0x012EFBAE File Offset: 0x012EDDAE
		public TileItem(BuildingMapTileMgr tileMgr)
		{
			this.TileMgr = tileMgr;
		}

		// Token: 0x1700A7F7 RID: 42999
		// (get) Token: 0x06047358 RID: 291672 RVA: 0x012EFBBD File Offset: 0x012EDDBD
		public BuildingMapTileMgr TileMgr { get; }

		// Token: 0x06047359 RID: 291673 RVA: 0x012EFBC5 File Offset: 0x012EDDC5
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture))
			};
		}

		// Token: 0x0604735A RID: 291674 RVA: 0x012EFBE8 File Offset: 0x012EDDE8
		public override void Refresh(string data, bool isSelected, int gridIndex)
		{
		}

		// Token: 0x0604735B RID: 291675 RVA: 0x012EFBEC File Offset: 0x012EDDEC
		public override UniTask RefreshAsync(string data, bool isSelected, int gridIndex)
		{
			BuildingMapTileModule.TileItem.<RefreshAsync>d__6 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<BuildingMapTileModule.TileItem.<RefreshAsync>d__6>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}
	}

	// Token: 0x02007757 RID: 30551
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029179 RID: 168313
		public const int TileRootItem = 0;

		// Token: 0x0402917A RID: 168314
		public const int TileItem = 1;

		// Token: 0x0402917B RID: 168315
		public const int RoleRootItem = 2;

		// Token: 0x0402917C RID: 168316
		public const int BuildingItem1 = 3;

		// Token: 0x0402917D RID: 168317
		public const int BuildingItem2 = 4;

		// Token: 0x0402917E RID: 168318
		public const int BuildingItem3 = 5;

		// Token: 0x0402917F RID: 168319
		public const int BuildingItem4 = 6;

		// Token: 0x04029180 RID: 168320
		public const int BuildingItem5 = 7;

		// Token: 0x04029181 RID: 168321
		public const int BuildingItem6 = 8;

		// Token: 0x04029182 RID: 168322
		public const int BuildingItem7 = 9;

		// Token: 0x04029183 RID: 168323
		public const int BuildingItem8 = 10;

		// Token: 0x04029184 RID: 168324
		public const int BuildingItem9 = 11;

		// Token: 0x04029185 RID: 168325
		public const int BuildingItem10 = 12;

		// Token: 0x04029186 RID: 168326
		public const int ShowRoleRootItem = 13;
	}
}
