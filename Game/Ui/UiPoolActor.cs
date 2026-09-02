using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A3E RID: 19006
	[NullableContext(1)]
	[Nullable(0)]
	public class UiPoolActor
	{
		// Token: 0x1700847A RID: 33914
		// (get) Token: 0x06031A7A RID: 203386 RVA: 0x00C5EDF0 File Offset: 0x00C5CFF0
		// (set) Token: 0x06031A7B RID: 203387 RVA: 0x00C5EDF8 File Offset: 0x00C5CFF8
		[Nullable(2)]
		public AActor Actor
		{
			[NullableContext(2)]
			get
			{
				return this.ActorInternal;
			}
			[NullableContext(2)]
			set
			{
				this.ActorInternal = value;
			}
		}

		// Token: 0x1700847B RID: 33915
		// (get) Token: 0x06031A7C RID: 203388 RVA: 0x00C5EE01 File Offset: 0x00C5D001
		public bool IsValid
		{
			get
			{
				AActor actorInternal = this.ActorInternal;
				return actorInternal != null && actorInternal.IsValid();
			}
		}

		// Token: 0x1700847C RID: 33916
		// (get) Token: 0x06031A7D RID: 203389 RVA: 0x00C5EE14 File Offset: 0x00C5D014
		public UUIItem UiItem
		{
			get
			{
				AActor actorInternal = this.ActorInternal;
				return ((actorInternal != null) ? actorInternal.RootComponent : null) as UUIItem;
			}
		}

		// Token: 0x1700847D RID: 33917
		// (get) Token: 0x06031A7E RID: 203390 RVA: 0x00C5EE2D File Offset: 0x00C5D02D
		public string Path
		{
			get
			{
				return this.PathInternal;
			}
		}

		// Token: 0x1700847E RID: 33918
		// (get) Token: 0x06031A7F RID: 203391 RVA: 0x00C5EE35 File Offset: 0x00C5D035
		// (set) Token: 0x06031A80 RID: 203392 RVA: 0x00C5EE3D File Offset: 0x00C5D03D
		public double EndTime
		{
			get
			{
				return this.EndTimeInternal;
			}
			set
			{
				this.EndTimeInternal = value;
			}
		}

		// Token: 0x06031A81 RID: 203393 RVA: 0x00C5EE46 File Offset: 0x00C5D046
		public void Clear()
		{
			if (!this.IsValid)
			{
				return;
			}
			Singleton<ActorSystem>.Instance.Put("UiPoolActor.Clear", this.ActorInternal, null);
			this.ActorInternal = null;
		}

		// Token: 0x06031A82 RID: 203394 RVA: 0x00C5EE6F File Offset: 0x00C5D06F
		public UiPoolActor(string path)
		{
			this.PathInternal = path;
		}

		// Token: 0x0401CE66 RID: 118374
		[Nullable(2)]
		private AActor ActorInternal;

		// Token: 0x0401CE67 RID: 118375
		private readonly string PathInternal = "";

		// Token: 0x0401CE68 RID: 118376
		private double EndTimeInternal;
	}
}
