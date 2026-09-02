using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013A3 RID: 5027
[NullableContext(1)]
[Nullable(0)]
public class BuildingMapTileMgr
{
	// Token: 0x06008A81 RID: 35457 RVA: 0x00247714 File Offset: 0x00245914
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private UniTask<UUITexture> LoadTileAssetAsync(string tag, string path)
	{
		BuildingMapTileMgr.<LoadTileAssetAsync>d__4 <LoadTileAssetAsync>d__;
		<LoadTileAssetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UUITexture>.Create();
		<LoadTileAssetAsync>d__.<>4__this = this;
		<LoadTileAssetAsync>d__.tag = tag;
		<LoadTileAssetAsync>d__.path = path;
		<LoadTileAssetAsync>d__.<>1__state = -1;
		<LoadTileAssetAsync>d__.<>t__builder.Start<BuildingMapTileMgr.<LoadTileAssetAsync>d__4>(ref <LoadTileAssetAsync>d__);
		return <LoadTileAssetAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008A82 RID: 35458 RVA: 0x00247768 File Offset: 0x00245968
	public List<string> CreateTilesPathList()
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= 4; i++)
		{
			for (int j = 1; j <= 8; j++)
			{
				string resourceId = StringUtils.Format("ChasingMoonMap_{0}_{1}", new string[]
				{
					i.ToString(),
					j.ToString()
				});
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
				list.Add(resourcePath);
			}
		}
		return list;
	}

	// Token: 0x06008A83 RID: 35459 RVA: 0x002477D0 File Offset: 0x002459D0
	public UniTask LoadMapTiles()
	{
		BuildingMapTileMgr.<LoadMapTiles>d__6 <LoadMapTiles>d__;
		<LoadMapTiles>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadMapTiles>d__.<>4__this = this;
		<LoadMapTiles>d__.<>1__state = -1;
		<LoadMapTiles>d__.<>t__builder.Start<BuildingMapTileMgr.<LoadMapTiles>d__6>(ref <LoadMapTiles>d__);
		return <LoadMapTiles>d__.<>t__builder.Task;
	}

	// Token: 0x040040D5 RID: 16597
	private const int COLUMNS_NUM = 8;

	// Token: 0x040040D6 RID: 16598
	private const int ROW_NUM = 4;

	// Token: 0x040040D7 RID: 16599
	private const string MAPTILE_NAME_TEMPLATE = "ChasingMoonMap_{0}_{1}";

	// Token: 0x040040D8 RID: 16600
	private readonly Dictionary<string, UTexture> MapTilesMap = new Dictionary<string, UTexture>();
}
