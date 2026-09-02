using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapTile
{
	// Token: 0x020057FC RID: 22524
	[NullableContext(1)]
	public interface IMapTileCreateParam
	{
		// Token: 0x170091EF RID: 37359
		// (get) Token: 0x060394E8 RID: 234728
		// (set) Token: 0x060394E9 RID: 234729
		int TileX { get; set; }

		// Token: 0x170091F0 RID: 37360
		// (get) Token: 0x060394EA RID: 234730
		// (set) Token: 0x060394EB RID: 234731
		int TileY { get; set; }

		// Token: 0x170091F1 RID: 37361
		// (get) Token: 0x060394EC RID: 234732
		// (set) Token: 0x060394ED RID: 234733
		Vector2D AnchorOffset { get; set; }

		// Token: 0x170091F2 RID: 37362
		// (get) Token: 0x060394EE RID: 234734
		// (set) Token: 0x060394EF RID: 234735
		Action<UTexture> LoadMapTileCallBack { get; set; }

		// Token: 0x170091F3 RID: 37363
		// (get) Token: 0x060394F0 RID: 234736
		// (set) Token: 0x060394F1 RID: 234737
		Dictionary<string, string> AssetData { get; set; }

		// Token: 0x170091F4 RID: 37364
		// (get) Token: 0x060394F2 RID: 234738
		// (set) Token: 0x060394F3 RID: 234739
		FColor FogDefaultColor { get; set; }

		// Token: 0x170091F5 RID: 37365
		// (get) Token: 0x060394F4 RID: 234740
		// (set) Token: 0x060394F5 RID: 234741
		EMapType MapType { get; set; }

		// Token: 0x170091F6 RID: 37366
		// (get) Token: 0x060394F6 RID: 234742
		// (set) Token: 0x060394F7 RID: 234743
		UUITextureBase MapTile { get; set; }

		// Token: 0x170091F7 RID: 37367
		// (get) Token: 0x060394F8 RID: 234744
		// (set) Token: 0x060394F9 RID: 234745
		int MapId { get; set; }
	}
}
