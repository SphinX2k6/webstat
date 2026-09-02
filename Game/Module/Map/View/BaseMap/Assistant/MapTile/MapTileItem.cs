using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap.ViewComponent.SteamingLoad;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapTile
{
	// Token: 0x020057FF RID: 22527
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTileItem : IWorldMapStreamingObject
	{
		// Token: 0x17009201 RID: 37377
		// (get) Token: 0x06039511 RID: 234769 RVA: 0x00E8D45F File Offset: 0x00E8B65F
		// (set) Token: 0x06039512 RID: 234770 RVA: 0x00E8D467 File Offset: 0x00E8B667
		public bool IsStreaming { get; set; } = true;

		// Token: 0x17009202 RID: 37378
		// (get) Token: 0x06039513 RID: 234771 RVA: 0x00E8D470 File Offset: 0x00E8B670
		// (set) Token: 0x06039514 RID: 234772 RVA: 0x00E8D478 File Offset: 0x00E8B678
		public bool IsVisible { get; set; }

		// Token: 0x06039515 RID: 234773 RVA: 0x00E8D484 File Offset: 0x00E8B684
		public MapTileItem(IMapTileCreateParam param)
		{
			this.MapTileCreateParam = param;
			this.UiPosition = Vector.Create(param.AnchorOffset.X, param.AnchorOffset.Y, 0.0);
			UUITextureBase mapTile = param.MapTile;
			this.PreloadThreshold = Vector2D.Create((double)(mapTile.GetWidth() * 2f), (double)(mapTile.GetHeight() * 2f));
		}

		// Token: 0x06039516 RID: 234774 RVA: 0x00E8D504 File Offset: 0x00E8B704
		public unsafe void OnLoad()
		{
			Dictionary<string, string> assetData = this.MapTileCreateParam.AssetData;
			EMapType mapType = this.MapTileCreateParam.MapType;
			int x = this.MapTileCreateParam.TileX;
			int y = this.MapTileCreateParam.TileY;
			UUITextureBase mapTile = this.MapTileCreateParam.MapTile;
			FColor fogDefaultColor = this.MapTileCreateParam.FogDefaultColor;
			int mapId = this.MapTileCreateParam.MapId;
			if (!string.IsNullOrEmpty(assetData["MapTilePath"]))
			{
				this.LoadHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(assetData["MapTilePath"], new Action<UTexture, string>(this.OnLoadEnd), 102, "Ui.MapUi");
				if (Singleton<Info>.Instance.IsPcOrGamepadPlatform() && !string.IsNullOrEmpty(assetData["HdMapTilePath"]) && mapType == EMapType.WorldMap)
				{
					Action<UTexture, string> callback = delegate([Nullable(2)] UTexture textureObject, string assetPath)
					{
						if (textureObject == null)
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.Map;
							ELogAuthor author2 = ELogAuthor.LYX;
							string message2 = "[地图系统]->loadHdCallback 高清切块贴图为空";
							<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("MapId", mapId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("TileX", x);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("TileY", y);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("assetData", assetData);
							instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
						}
						mapTile.SetCustomMaterialScalarParameter(MapTileItem.HD_SCALAR_NAME, 1f);
						mapTile.SetCustomMaterialTextureParameter(MapTileItem.HD_TEXTURE_NAME, textureObject);
					};
					this.LoadHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(assetData["HdMapTilePath"], callback, 102, "Ui.MapUi");
					return;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "[地图系统]->切块贴图为空";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MapId", mapId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TileX", x);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TileY", y);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				mapTile.SetTexture(null);
				mapTile.SetColor(fogDefaultColor);
			}
		}

		// Token: 0x06039517 RID: 234775 RVA: 0x00E8D6DC File Offset: 0x00E8B8DC
		public void OnUnload()
		{
			UUITextureBase mapTile = this.MapTileCreateParam.MapTile;
			FColor fogDefaultColor = this.MapTileCreateParam.FogDefaultColor;
			mapTile.SetTexture(null);
			mapTile.SetColor(fogDefaultColor);
		}

		// Token: 0x06039518 RID: 234776 RVA: 0x00E8D70D File Offset: 0x00E8B90D
		public Vector2D GetPreloadThreshold()
		{
			return this.PreloadThreshold;
		}

		// Token: 0x06039519 RID: 234777 RVA: 0x00E8D715 File Offset: 0x00E8B915
		public Vector GetUiPosition()
		{
			return this.UiPosition;
		}

		// Token: 0x0603951A RID: 234778 RVA: 0x00E8D71D File Offset: 0x00E8B91D
		public void ReleaseLoadHandle()
		{
			if (this.LoadHandle != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandle);
				this.LoadHandle = -1;
			}
		}

		// Token: 0x0603951B RID: 234779 RVA: 0x00E8D73F File Offset: 0x00E8B93F
		private void OnLoadEnd(UTexture textureObject, string assetPath)
		{
			this.LoadHandle = -1;
			Action<UTexture> loadMapTileCallBack = this.MapTileCreateParam.LoadMapTileCallBack;
			if (loadMapTileCallBack == null)
			{
				return;
			}
			loadMapTileCallBack(textureObject);
		}

		// Token: 0x04020956 RID: 133462
		private readonly IMapTileCreateParam MapTileCreateParam;

		// Token: 0x04020957 RID: 133463
		private readonly Vector UiPosition;

		// Token: 0x04020958 RID: 133464
		private readonly Vector2D PreloadThreshold;

		// Token: 0x04020959 RID: 133465
		private int LoadHandle = -1;

		// Token: 0x0402095A RID: 133466
		public static readonly FName HD_TEXTURE_NAME = new FName("HDTexture");

		// Token: 0x0402095B RID: 133467
		public static readonly FName HD_SCALAR_NAME = new FName("UseHDPicture");
	}
}
