using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BFE RID: 27646
	[NullableContext(1)]
	[Nullable(0)]
	internal class TsAttachEffectContext : IEffectContext
	{
		// Token: 0x1700A345 RID: 41797
		// (get) Token: 0x06044128 RID: 278824 RVA: 0x011AC212 File Offset: 0x011AA412
		// (set) Token: 0x06044129 RID: 278825 RVA: 0x011AC21A File Offset: 0x011AA41A
		public string AssetPath { get; set; }

		// Token: 0x1700A346 RID: 41798
		// (get) Token: 0x0604412A RID: 278826 RVA: 0x011AC223 File Offset: 0x011AA423
		// (set) Token: 0x0604412B RID: 278827 RVA: 0x011AC22B File Offset: 0x011AA42B
		public Transform Transform { get; set; }

		// Token: 0x1700A347 RID: 41799
		// (get) Token: 0x0604412C RID: 278828 RVA: 0x011AC234 File Offset: 0x011AA434
		// (set) Token: 0x0604412D RID: 278829 RVA: 0x011AC23C File Offset: 0x011AA43C
		[Nullable(2)]
		public EntityHandle EntityHandle { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700A348 RID: 41800
		// (get) Token: 0x0604412E RID: 278830 RVA: 0x011AC245 File Offset: 0x011AA445
		// (set) Token: 0x0604412F RID: 278831 RVA: 0x011AC24D File Offset: 0x011AA44D
		public bool? ShouldAttachToEntity { get; set; }

		// Token: 0x1700A349 RID: 41801
		// (get) Token: 0x06044130 RID: 278832 RVA: 0x011AC256 File Offset: 0x011AA456
		// (set) Token: 0x06044131 RID: 278833 RVA: 0x011AC25E File Offset: 0x011AA45E
		public FName? AttachSocket { get; set; }

		// Token: 0x1700A34A RID: 41802
		// (get) Token: 0x06044132 RID: 278834 RVA: 0x011AC267 File Offset: 0x011AA467
		// (set) Token: 0x06044133 RID: 278835 RVA: 0x011AC26F File Offset: 0x011AA46F
		[Nullable(2)]
		public Vector AttachOffset { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x06044134 RID: 278836 RVA: 0x011AC278 File Offset: 0x011AA478
		public TsAttachEffectContext(string assetPath, Transform transform, [Nullable(2)] EntityHandle entityHandle = null, bool? shouldAttachToEntity = null, FName? attachSocket = null, [Nullable(2)] Vector attachOffset = null)
		{
			this.AssetPath = assetPath;
			this.Transform = transform;
			this.EntityHandle = entityHandle;
			this.ShouldAttachToEntity = shouldAttachToEntity;
			this.AttachSocket = attachSocket;
			this.AttachOffset = attachOffset;
		}
	}
}
