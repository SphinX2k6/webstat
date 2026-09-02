using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x0200483F RID: 18495
	public class PathDrivenCurveLoadRequest : IPathDrivenCurveLoadRequest
	{
		// Token: 0x17008266 RID: 33382
		// (get) Token: 0x060301FA RID: 197114 RVA: 0x00BABC79 File Offset: 0x00BA9E79
		// (set) Token: 0x060301FB RID: 197115 RVA: 0x00BABC81 File Offset: 0x00BA9E81
		public int HandleId { get; set; }

		// Token: 0x17008267 RID: 33383
		// (get) Token: 0x060301FC RID: 197116 RVA: 0x00BABC8A File Offset: 0x00BA9E8A
		// (set) Token: 0x060301FD RID: 197117 RVA: 0x00BABC92 File Offset: 0x00BA9E92
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public CustomPromise<UCurveFloat> Promise { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			1,
			2
		})] set; }
	}
}
