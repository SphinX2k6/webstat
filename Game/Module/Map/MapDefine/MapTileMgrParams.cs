using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058DF RID: 22751
	[NullableContext(2)]
	[Nullable(0)]
	public class MapTileMgrParams
	{
		// Token: 0x17009399 RID: 37785
		// (get) Token: 0x06039BDC RID: 236508 RVA: 0x00EA05DA File Offset: 0x00E9E7DA
		// (set) Token: 0x06039BDD RID: 236509 RVA: 0x00EA05E2 File Offset: 0x00E9E7E2
		[Nullable(1)]
		public UUIItem MapRootItem { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700939A RID: 37786
		// (get) Token: 0x06039BDE RID: 236510 RVA: 0x00EA05EB File Offset: 0x00E9E7EB
		// (set) Token: 0x06039BDF RID: 236511 RVA: 0x00EA05F3 File Offset: 0x00E9E7F3
		[Nullable(1)]
		public UUIItem TileContainer { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700939B RID: 37787
		// (get) Token: 0x06039BE0 RID: 236512 RVA: 0x00EA05FC File Offset: 0x00E9E7FC
		// (set) Token: 0x06039BE1 RID: 236513 RVA: 0x00EA0604 File Offset: 0x00E9E804
		[Nullable(1)]
		public UUITexture TileTexture { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700939C RID: 37788
		// (get) Token: 0x06039BE2 RID: 236514 RVA: 0x00EA060D File Offset: 0x00E9E80D
		// (set) Token: 0x06039BE3 RID: 236515 RVA: 0x00EA0615 File Offset: 0x00E9E815
		public UUIItem SubMapContainer { get; set; }

		// Token: 0x1700939D RID: 37789
		// (get) Token: 0x06039BE4 RID: 236516 RVA: 0x00EA061E File Offset: 0x00E9E81E
		// (set) Token: 0x06039BE5 RID: 236517 RVA: 0x00EA0626 File Offset: 0x00E9E826
		public UUITexture SubMapTexture { get; set; }

		// Token: 0x1700939E RID: 37790
		// (get) Token: 0x06039BE6 RID: 236518 RVA: 0x00EA062F File Offset: 0x00E9E82F
		// (set) Token: 0x06039BE7 RID: 236519 RVA: 0x00EA0637 File Offset: 0x00E9E837
		public EMapType MapType { get; set; }

		// Token: 0x1700939F RID: 37791
		// (get) Token: 0x06039BE8 RID: 236520 RVA: 0x00EA0640 File Offset: 0x00E9E840
		// (set) Token: 0x06039BE9 RID: 236521 RVA: 0x00EA0648 File Offset: 0x00E9E848
		public int MapId { get; set; }

		// Token: 0x170093A0 RID: 37792
		// (get) Token: 0x06039BEA RID: 236522 RVA: 0x00EA0651 File Offset: 0x00E9E851
		// (set) Token: 0x06039BEB RID: 236523 RVA: 0x00EA0659 File Offset: 0x00E9E859
		public int InstanceDungeonId { get; set; }

		// Token: 0x170093A1 RID: 37793
		// (get) Token: 0x06039BEC RID: 236524 RVA: 0x00EA0662 File Offset: 0x00E9E862
		// (set) Token: 0x06039BED RID: 236525 RVA: 0x00EA066A File Offset: 0x00E9E86A
		public int MapVersion { get; set; }

		// Token: 0x170093A2 RID: 37794
		// (get) Token: 0x06039BEE RID: 236526 RVA: 0x00EA0673 File Offset: 0x00E9E873
		// (set) Token: 0x06039BEF RID: 236527 RVA: 0x00EA067B File Offset: 0x00E9E87B
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, UTexture> PreloadTiles { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }

		// Token: 0x170093A3 RID: 37795
		// (get) Token: 0x06039BF0 RID: 236528 RVA: 0x00EA0684 File Offset: 0x00E9E884
		// (set) Token: 0x06039BF1 RID: 236529 RVA: 0x00EA068C File Offset: 0x00E9E88C
		public UUIItem SubMapMask { get; set; }

		// Token: 0x170093A4 RID: 37796
		// (get) Token: 0x06039BF2 RID: 236530 RVA: 0x00EA0695 File Offset: 0x00E9E895
		// (set) Token: 0x06039BF3 RID: 236531 RVA: 0x00EA069D File Offset: 0x00E9E89D
		public UUIItem FogUnlockItem { get; set; }

		// Token: 0x170093A5 RID: 37797
		// (get) Token: 0x06039BF4 RID: 236532 RVA: 0x00EA06A6 File Offset: 0x00E9E8A6
		// (set) Token: 0x06039BF5 RID: 236533 RVA: 0x00EA06AE File Offset: 0x00E9E8AE
		public EMapGravityDirection? Gravity { get; set; }
	}
}
