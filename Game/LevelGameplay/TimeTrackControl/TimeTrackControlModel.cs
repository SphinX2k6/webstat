using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

namespace CSharpScript.Game.LevelGamePlay.TimeTrackControl
{
	// Token: 0x02006A95 RID: 27285
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class TimeTrackControlModel : ModelBase<TimeTrackControlModel>
	{
		// Token: 0x1700A26C RID: 41580
		// (get) Token: 0x06043785 RID: 276357 RVA: 0x01162067 File Offset: 0x01160267
		public long CreatureDataId
		{
			get
			{
				return this.CurCreatureDataId;
			}
		}

		// Token: 0x1700A26D RID: 41581
		// (get) Token: 0x06043786 RID: 276358 RVA: 0x0116206F File Offset: 0x0116026F
		public int ControlPoint
		{
			get
			{
				return this.CurControlPoint;
			}
		}

		// Token: 0x1700A26E RID: 41582
		// (get) Token: 0x06043787 RID: 276359 RVA: 0x01162077 File Offset: 0x01160277
		// (set) Token: 0x06043788 RID: 276360 RVA: 0x0116207F File Offset: 0x0116027F
		public bool CanUpdated
		{
			get
			{
				return this.CanUpdate;
			}
			set
			{
				this.CanUpdate = value;
			}
		}

		// Token: 0x1700A26F RID: 41583
		// (get) Token: 0x06043789 RID: 276361 RVA: 0x01162088 File Offset: 0x01160288
		// (set) Token: 0x0604378A RID: 276362 RVA: 0x01162090 File Offset: 0x01160290
		public long RefEntityId
		{
			get
			{
				return this.CurStaticSceneRefEntityId;
			}
			set
			{
				this.CurStaticSceneRefEntityId = value;
			}
		}

		// Token: 0x1700A270 RID: 41584
		// (get) Token: 0x0604378B RID: 276363 RVA: 0x01162099 File Offset: 0x01160299
		// (set) Token: 0x0604378C RID: 276364 RVA: 0x011620A1 File Offset: 0x011602A1
		public long RefTrueEntityId
		{
			get
			{
				return this.CurStaticSceneRefTrueEntityId;
			}
			set
			{
				this.CurStaticSceneRefTrueEntityId = value;
			}
		}

		// Token: 0x1700A271 RID: 41585
		// (get) Token: 0x0604378D RID: 276365 RVA: 0x011620AA File Offset: 0x011602AA
		public EntityHandle ControllerEntity
		{
			get
			{
				return this.CurTimeTrackControlEntity;
			}
		}

		// Token: 0x0604378E RID: 276366 RVA: 0x011620B4 File Offset: 0x011602B4
		public void SetCurrentTimeTrackControl(long inEntityId, int index)
		{
			this.CurTimeTrackControlEntity = ModelBase<CreatureModel>.Instance.GetEntity(inEntityId);
			this.CurConfigIndex = new int?(index);
			EntityHandle curTimeTrackControlEntity = this.CurTimeTrackControlEntity;
			CreatureDataComponent creatureDataComponent = (curTimeTrackControlEntity != null) ? curTimeTrackControlEntity.Entity.GetComponent<CreatureDataComponent>() : null;
			this.CurCreatureDataId = ((creatureDataComponent != null) ? creatureDataComponent.GetCreatureDataId() : 0L);
			this.UpdateCurConfig();
			this.CanUpdate = true;
		}

		// Token: 0x0604378F RID: 276367 RVA: 0x01162118 File Offset: 0x01160318
		private void UpdateCurConfig()
		{
			if (this.CurTimeTrackControlEntity == null || this.CurConfigIndex == null)
			{
				return;
			}
			SceneItemTimeTrackControlComponent component = this.CurTimeTrackControlEntity.Entity.GetComponent<SceneItemTimeTrackControlComponent>();
			if (component == null)
			{
				return;
			}
			this.CurConfig = component.GetTimeTrackControlConfig(this.CurConfigIndex.Value);
		}

		// Token: 0x06043790 RID: 276368 RVA: 0x01162168 File Offset: 0x01160368
		public int GetConfigStatesCounts()
		{
			if (this.CurConfig == null)
			{
				return 0;
			}
			using (List<ITimelineTrackControlData>.Enumerator enumerator = this.CurConfig.ControlConfigs.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					IReadOnlyList<object> controlPoints = enumerator.Current.GetControlPoints();
					return (controlPoints != null) ? controlPoints.Count : 0;
				}
			}
			return 0;
		}

		// Token: 0x06043791 RID: 276369 RVA: 0x011621DC File Offset: 0x011603DC
		public float GetConfigSegmentTime()
		{
			if (this.CurConfig == null)
			{
				return 0.5f;
			}
			return this.CurConfig.SegmentTime.GetValueOrDefault(0.5f);
		}

		// Token: 0x06043792 RID: 276370 RVA: 0x0116220F File Offset: 0x0116040F
		[NullableContext(1)]
		public void InitControlInfo(TimelineTraceStartResponse inInfo)
		{
			this.CurControlPoint = inInfo.ControlPoint;
			this.ControlPointsStates = inInfo.PointDatas;
			this.UpdatePointsUsable();
		}

		// Token: 0x06043793 RID: 276371 RVA: 0x0116222F File Offset: 0x0116042F
		public void UpdateControlInfo(int inIndex)
		{
			this.CurControlPoint = inIndex;
			this.UpdatePointsUsable();
		}

		// Token: 0x06043794 RID: 276372 RVA: 0x01162240 File Offset: 0x01160440
		public void UpdatePointsUsable()
		{
			int configStatesCounts = this.GetConfigStatesCounts();
			if (configStatesCounts == 0)
			{
				return;
			}
			if (this.ControlPointsUsable == null || this.ControlPointsUsable.Length != configStatesCounts)
			{
				this.ControlPointsUsable = new bool[configStatesCounts];
			}
			Array.Fill<bool>(this.ControlPointsUsable, false);
			ControlPointData controlPointData = this.ControlPointsStates[this.CurControlPoint];
			this.ControlPointsUsable[this.CurControlPoint] = (controlPointData.LeftEnable || controlPointData.RightEnable);
			for (int i = this.CurControlPoint - 1; i >= 0; i--)
			{
				if (!controlPointData.LeftEnable || !this.ControlPointsUsable[i + 1])
				{
					this.ControlPointsUsable[i] = false;
				}
				else
				{
					this.ControlPointsUsable[i] = this.ControlPointsStates[i + 1].LeftEnable;
				}
			}
			for (int j = this.CurControlPoint + 1; j < configStatesCounts; j++)
			{
				if (!controlPointData.RightEnable || !this.ControlPointsUsable[j - 1])
				{
					this.ControlPointsUsable[j] = false;
				}
				else
				{
					this.ControlPointsUsable[j] = this.ControlPointsStates[j - 1].RightEnable;
				}
			}
		}

		// Token: 0x06043795 RID: 276373 RVA: 0x0116234D File Offset: 0x0116054D
		public bool IsControlPointUsable(int index)
		{
			return this.ControlPointsUsable != null && this.ControlPointsUsable.Length != 0 && index <= this.ControlPointsUsable.Length - 1 && this.ControlPointsUsable[index];
		}

		// Token: 0x04025AE6 RID: 154342
		private EntityHandle CurTimeTrackControlEntity;

		// Token: 0x04025AE7 RID: 154343
		private int? CurConfigIndex;

		// Token: 0x04025AE8 RID: 154344
		private ITimelineControlGroup CurConfig;

		// Token: 0x04025AE9 RID: 154345
		private long CurCreatureDataId;

		// Token: 0x04025AEA RID: 154346
		private int CurControlPoint;

		// Token: 0x04025AEB RID: 154347
		private bool CanUpdate;

		// Token: 0x04025AEC RID: 154348
		private long CurStaticSceneRefEntityId;

		// Token: 0x04025AED RID: 154349
		private long CurStaticSceneRefTrueEntityId;

		// Token: 0x04025AEE RID: 154350
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private IList<ControlPointData> ControlPointsStates;

		// Token: 0x04025AEF RID: 154351
		private bool[] ControlPointsUsable;
	}
}
