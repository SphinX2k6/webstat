using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200585A RID: 22618
	[NullableContext(1)]
	[Nullable(0)]
	public class TaskTrackedMarkItem
	{
		// Token: 0x0603987A RID: 235642 RVA: 0x00E993B4 File Offset: 0x00E975B4
		public TaskTrackedMarkItem(QuestMarkCreateInfo markPointInfo, ETrackSource trackSource)
		{
			this.MarkPointInfo = markPointInfo;
			this.TrackTarget = markPointInfo.TrackTarget;
			this.NodeId = markPointInfo.NodeId;
			this.TrackSource = trackSource;
			if (this.NodeId != 0)
			{
				this.TreeIncId = new long?(markPointInfo.TreeId);
				this.Tree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.TreeIncId.Value), false);
				if (this.Tree == null)
				{
					return;
				}
				this.BtType = new BtType?(this.Tree.BtType);
				this.TreeConfigId = this.Tree.TreeConfigId;
				BehaviorNodeBase node = this.Tree.GetNode(this.NodeId);
				bool flag;
				if (node == null)
				{
					flag = (null != null);
				}
				else
				{
					ITrackTarget trackTarget = node.TrackTarget;
					flag = (((trackTarget != null) ? trackTarget.ZaxisViewRange : null) != null);
				}
				if (flag)
				{
					this.RangeMarkShowDisUp = (double)((float)node.TrackTarget.ZaxisViewRange.Up.Value / 100f);
					this.RangeMarkShowDisDown = (double)((float)(-(float)node.TrackTarget.ZaxisViewRange.Down.Value) / 100f);
				}
				double rangeMarkSize = this.Tree.GetRangeMarkSize(this.NodeId);
				if (rangeMarkSize > 0.0)
				{
					this.MarkRange = rangeMarkSize / 100.0;
				}
				double rangeMarkShowDis = this.Tree.GetRangeMarkShowDis(this.NodeId);
				if (rangeMarkShowDis > 0.0)
				{
					this.RangeMarkShowDis = rangeMarkShowDis / 100.0;
				}
			}
			else
			{
				this.BtType = new BtType?(Aki.Protocol.BtType.Quest);
				this.TreeConfigId = (int)markPointInfo.TreeId;
			}
			double markRange = this.MarkRange;
			this.IsRangeTrack = (markRange > 0.0);
			Singleton<EventSystem>.Instance.Emit<ETrackSource, long, int, int, bool>(EEventName.TaskRangeTrackStateChange, this.TrackSource, this.TreeIncId.Value, this.MarkPointInfo.NodeId, this.MarkPointInfo.MarkId.Value, false);
		}

		// Token: 0x0603987B RID: 235643 RVA: 0x00E995B0 File Offset: 0x00E977B0
		public void Update()
		{
			if (!this.IsRangeTrack)
			{
				return;
			}
			if (this.TargetInDiffWorld())
			{
				return;
			}
			global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (playerLocation != null)
			{
				this.UpdateRangeShow(playerLocation);
			}
		}

		// Token: 0x0603987C RID: 235644 RVA: 0x00E995E4 File Offset: 0x00E977E4
		private void UpdateRangeShow(global::Vector playerLocation)
		{
			if (!this.IsRangeTrack)
			{
				return;
			}
			double rangeMarkShowDis = this.RangeMarkShowDis;
			double num = rangeMarkShowDis + 2.0;
			bool flag = true;
			double num3;
			bool flag2;
			if (this.RangeMarkShowDisUp != 0.0 || this.RangeMarkShowDisDown != 0.0)
			{
				double num2 = (playerLocation.Z - this.WorldPosition.Z) * 0.009999999776482582;
				num3 = global::Vector.Dist2D(playerLocation, this.WorldPosition) * 0.009999999776482582;
				flag = (num2 < this.RangeMarkShowDisUp && num2 > this.RangeMarkShowDisDown);
				flag2 = (num3 > rangeMarkShowDis && num2 > this.RangeMarkShowDisUp && num2 < this.RangeMarkShowDisDown);
			}
			else
			{
				num3 = global::Vector.Dist(playerLocation, this.WorldPosition) * 0.009999999776482582;
				flag2 = (num3 > rangeMarkShowDis);
			}
			if (this.Flag)
			{
				this.SetRangeActive(!flag2);
				this.Flag = false;
				return;
			}
			this.SetRangeActive(num3 < num && flag);
		}

		// Token: 0x170092D9 RID: 37593
		// (get) Token: 0x0603987D RID: 235645 RVA: 0x00E996ED File Offset: 0x00E978ED
		public global::Vector WorldPosition
		{
			get
			{
				return MapUtil.GetTrackPositionByTrackTarget(this.TrackTarget, false, null, new int?(this.MarkPointInfo.MapId), true);
			}
		}

		// Token: 0x170092DA RID: 37594
		// (get) Token: 0x0603987E RID: 235646 RVA: 0x00E99710 File Offset: 0x00E97910
		public int? InstanceDungeonId
		{
			get
			{
				BaseBehaviorTree tree = this.Tree;
				if (tree == null)
				{
					return null;
				}
				return new int?(tree.DungeonId);
			}
		}

		// Token: 0x0603987F RID: 235647 RVA: 0x00E9973C File Offset: 0x00E9793C
		private void SetRangeActive(bool active)
		{
			if (!this.IsRangeTrack)
			{
				return;
			}
			if (this.RangeActive == active)
			{
				return;
			}
			this.RangeActive = active;
			Singleton<EventSystem>.Instance.Emit<ETrackSource, long, int, int, bool>(EEventName.TaskRangeTrackStateChange, this.TrackSource, this.TreeIncId.Value, this.MarkPointInfo.NodeId, this.MarkPointInfo.MarkId.Value, active);
		}

		// Token: 0x06039880 RID: 235648 RVA: 0x00E997A4 File Offset: 0x00E979A4
		public bool TargetInDiffWorld()
		{
			if (this.Tree != null)
			{
				int dungeonId = this.Tree.DungeonId;
				int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
				return (ModelBase<WorldMapModel>.Instance.IsPlayerInStoryInstanceDungeon() && this.IsInConsistentBigWorldDungeon()) || MapUtil.IsDungeonDiffWorld(instanceId, dungeonId).GetValueOrDefault();
			}
			return false;
		}

		// Token: 0x06039881 RID: 235649 RVA: 0x00E997F8 File Offset: 0x00E979F8
		private bool IsInConsistentBigWorldDungeon()
		{
			int? instanceDungeonId = this.InstanceDungeonId;
			int num = 0;
			if ((instanceDungeonId.GetValueOrDefault() == num & instanceDungeonId != null) || this.InstanceDungeonId == null)
			{
				return false;
			}
			instanceDungeonId = this.InstanceDungeonId;
			num = ModelBase<CreatureModel>.Instance.GetInstanceId();
			return !(instanceDungeonId.GetValueOrDefault() == num & instanceDungeonId != null);
		}

		// Token: 0x04020A9A RID: 133786
		public double MarkRange;

		// Token: 0x04020A9B RID: 133787
		public double RangeMarkShowDisUp;

		// Token: 0x04020A9C RID: 133788
		public double RangeMarkShowDisDown;

		// Token: 0x04020A9D RID: 133789
		public double RangeMarkShowDis;

		// Token: 0x04020A9E RID: 133790
		public BtType? BtType;

		// Token: 0x04020A9F RID: 133791
		public long? TreeIncId;

		// Token: 0x04020AA0 RID: 133792
		public int TreeConfigId;

		// Token: 0x04020AA1 RID: 133793
		[Nullable(2)]
		public BaseBehaviorTree Tree;

		// Token: 0x04020AA2 RID: 133794
		public int NodeId;

		// Token: 0x04020AA3 RID: 133795
		[Nullable(2)]
		public TTrackTarget TrackTarget;

		// Token: 0x04020AA4 RID: 133796
		[Nullable(2)]
		public QuestMarkCreateInfo MarkPointInfo;

		// Token: 0x04020AA5 RID: 133797
		private bool RangeActive;

		// Token: 0x04020AA6 RID: 133798
		private readonly ETrackSource TrackSource = ETrackSource.Instance;

		// Token: 0x04020AA7 RID: 133799
		private readonly bool IsRangeTrack;

		// Token: 0x04020AA8 RID: 133800
		private bool Flag;
	}
}
