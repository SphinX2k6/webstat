using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapTile
{
	// Token: 0x020057FD RID: 22525
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTileCreateParam : IMapTileCreateParam
	{
		// Token: 0x170091F8 RID: 37368
		// (get) Token: 0x060394FA RID: 234746 RVA: 0x00E8D3BE File Offset: 0x00E8B5BE
		// (set) Token: 0x060394FB RID: 234747 RVA: 0x00E8D3C6 File Offset: 0x00E8B5C6
		public int TileX { get; set; }

		// Token: 0x170091F9 RID: 37369
		// (get) Token: 0x060394FC RID: 234748 RVA: 0x00E8D3CF File Offset: 0x00E8B5CF
		// (set) Token: 0x060394FD RID: 234749 RVA: 0x00E8D3D7 File Offset: 0x00E8B5D7
		public int TileY { get; set; }

		// Token: 0x170091FA RID: 37370
		// (get) Token: 0x060394FE RID: 234750 RVA: 0x00E8D3E0 File Offset: 0x00E8B5E0
		// (set) Token: 0x060394FF RID: 234751 RVA: 0x00E8D3E8 File Offset: 0x00E8B5E8
		public Vector2D AnchorOffset { get; set; }

		// Token: 0x170091FB RID: 37371
		// (get) Token: 0x06039500 RID: 234752 RVA: 0x00E8D3F1 File Offset: 0x00E8B5F1
		// (set) Token: 0x06039501 RID: 234753 RVA: 0x00E8D3F9 File Offset: 0x00E8B5F9
		public Action<UTexture> LoadMapTileCallBack { get; set; }

		// Token: 0x170091FC RID: 37372
		// (get) Token: 0x06039502 RID: 234754 RVA: 0x00E8D402 File Offset: 0x00E8B602
		// (set) Token: 0x06039503 RID: 234755 RVA: 0x00E8D40A File Offset: 0x00E8B60A
		public Dictionary<string, string> AssetData { get; set; }

		// Token: 0x170091FD RID: 37373
		// (get) Token: 0x06039504 RID: 234756 RVA: 0x00E8D413 File Offset: 0x00E8B613
		// (set) Token: 0x06039505 RID: 234757 RVA: 0x00E8D41B File Offset: 0x00E8B61B
		public FColor FogDefaultColor { get; set; }

		// Token: 0x170091FE RID: 37374
		// (get) Token: 0x06039506 RID: 234758 RVA: 0x00E8D424 File Offset: 0x00E8B624
		// (set) Token: 0x06039507 RID: 234759 RVA: 0x00E8D42C File Offset: 0x00E8B62C
		public EMapType MapType { get; set; }

		// Token: 0x170091FF RID: 37375
		// (get) Token: 0x06039508 RID: 234760 RVA: 0x00E8D435 File Offset: 0x00E8B635
		// (set) Token: 0x06039509 RID: 234761 RVA: 0x00E8D43D File Offset: 0x00E8B63D
		public UUITextureBase MapTile { get; set; }

		// Token: 0x17009200 RID: 37376
		// (get) Token: 0x0603950A RID: 234762 RVA: 0x00E8D446 File Offset: 0x00E8B646
		// (set) Token: 0x0603950B RID: 234763 RVA: 0x00E8D44E File Offset: 0x00E8B64E
		public int MapId { get; set; }
	}
}
