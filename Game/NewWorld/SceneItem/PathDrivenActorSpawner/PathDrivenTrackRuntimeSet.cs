using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.Common;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x02004840 RID: 18496
	[NullableContext(1)]
	[Nullable(0)]
	public class PathDrivenTrackRuntimeSet
	{
		// Token: 0x060301FF RID: 197119 RVA: 0x00BABCA3 File Offset: 0x00BA9EA3
		public PathDrivenTrackRuntimeSet(int ownerEntityId)
		{
			this.OwnerEntityId = ownerEntityId;
		}

		// Token: 0x06030200 RID: 197120 RVA: 0x00BABCBD File Offset: 0x00BA9EBD
		public void AddTrack(IPathDrivenSplineRuntimeData trackRuntimeData)
		{
			if (!this.Released)
			{
				this.TrackList.Add(trackRuntimeData);
				return;
			}
			GameSplineModel instance = ModelBase<GameSplineModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ReleaseSpline(trackRuntimeData.SplineEntityId, (long)this.OwnerEntityId, EIdType.EntityId);
		}

		// Token: 0x06030201 RID: 197121 RVA: 0x00BABCF4 File Offset: 0x00BA9EF4
		public void Release()
		{
			if (this.Released)
			{
				return;
			}
			this.Released = true;
			for (int i = 0; i < this.TrackList.Count; i++)
			{
				IPathDrivenSplineRuntimeData pathDrivenSplineRuntimeData = this.TrackList[i];
				GameSplineModel instance = ModelBase<GameSplineModel>.Instance;
				if (instance != null)
				{
					instance.ReleaseSpline(pathDrivenSplineRuntimeData.SplineEntityId, (long)this.OwnerEntityId, EIdType.EntityId);
				}
			}
			this.TrackList.Clear();
		}

		// Token: 0x0401BA0B RID: 113163
		public readonly List<IPathDrivenSplineRuntimeData> TrackList = new List<IPathDrivenSplineRuntimeData>();

		// Token: 0x0401BA0C RID: 113164
		private readonly int OwnerEntityId;

		// Token: 0x0401BA0D RID: 113165
		private bool Released;
	}
}
