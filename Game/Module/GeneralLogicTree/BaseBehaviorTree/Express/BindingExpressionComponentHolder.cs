using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using UnrealEngine;

namespace CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree.Express
{
	// Token: 0x02005CFF RID: 23807
	[NullableContext(1)]
	[Nullable(0)]
	public class BindingExpressionComponentHolder
	{
		// Token: 0x0603C039 RID: 245817 RVA: 0x00F38C3C File Offset: 0x00F36E3C
		public BindingExpressionComponentHolder(Blackboard Blackboard)
		{
		}

		// Token: 0x0603C03A RID: 245818 RVA: 0x00F38CA3 File Offset: 0x00F36EA3
		public void Init()
		{
			this.WatchingList.Clear();
			this.AddEvents();
			this.Ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "BindingExpressionComponentHolder", ETickingGroup.TG_PrePhysics, false, 0, false);
		}

		// Token: 0x0603C03B RID: 245819 RVA: 0x00F38CDC File Offset: 0x00F36EDC
		public void Destroy()
		{
			this.BindingExpressions.Clear();
			this.WatchingList.Clear();
			this.BindingMapTrackDataCache.Clear();
			this.DefaultMapTrackMarkIds.Clear();
			this.DefaultMapTrackData.Clear();
			this.DefaultTrackPosCache.Clear();
			this.LevelPlayIdToQuestNodeId.Clear();
			this.RemoveEvents();
			if (this.Ticker != null)
			{
				Singleton<TickSystem>.Instance.Remove(this.Ticker.Id);
				this.Ticker = null;
			}
			Dictionary<int, HashSet<int>> everBoundLevelPlayIds = ModelBase<LevelPlayModel>.Instance.EverBoundLevelPlayIds;
			HashSet<int> hashSet;
			if (everBoundLevelPlayIds != null && everBoundLevelPlayIds.TryGetValue(this.<Blackboard>P.TreeConfigId, out hashSet))
			{
				hashSet.Clear();
			}
		}

		// Token: 0x0603C03C RID: 245820 RVA: 0x00F38D8C File Offset: 0x00F36F8C
		public void AddBindingExpression(int nodeId, int levelPlayConfigId)
		{
			this.LevelPlayIdToQuestNodeId[levelPlayConfigId] = nodeId;
			BaseBehaviorTree behaviorTreeByConfigId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeByConfigId(BtType.LevelPlay, levelPlayConfigId);
			bool flag;
			if (behaviorTreeByConfigId == null)
			{
				flag = true;
			}
			else
			{
				BehaviorTreeExpressionComponent expression = behaviorTreeByConfigId.Expression;
				flag = !((expression != null) ? new bool?(expression.IsValid) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return;
			}
			Dictionary<int, HashSet<int>> everBoundLevelPlayIds = ModelBase<LevelPlayModel>.Instance.EverBoundLevelPlayIds;
			if (everBoundLevelPlayIds != null)
			{
				HashSet<int> hashSet;
				if (!everBoundLevelPlayIds.TryGetValue(this.<Blackboard>P.TreeConfigId, out hashSet))
				{
					hashSet = (everBoundLevelPlayIds[this.<Blackboard>P.TreeConfigId] = new HashSet<int>());
				}
				hashSet.Add(levelPlayConfigId);
			}
			behaviorTreeByConfigId.SetTrack(false, ESetTrackReason.None);
			behaviorTreeByConfigId.Expression.BoundParentTreeId = new long?(this.<Blackboard>P.TreeIncId);
			behaviorTreeByConfigId.Expression.BoundParentNodeId = new int?(nodeId);
			this.BindingExpressions[levelPlayConfigId] = behaviorTreeByConfigId.Expression;
			if (this.CurFocusLevelPlayId == levelPlayConfigId)
			{
				this.RefreshTrack();
			}
		}

		// Token: 0x0603C03D RID: 245821 RVA: 0x00F38E80 File Offset: 0x00F37080
		public void RemoveBindingExpression(int levelPlayConfigId)
		{
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (this.BindingExpressions.TryGetValue(levelPlayConfigId, out behaviorTreeExpressionComponent))
			{
				behaviorTreeExpressionComponent.BoundParentTreeId = null;
				behaviorTreeExpressionComponent.BoundParentNodeId = null;
			}
			this.BindingExpressions.Remove(levelPlayConfigId);
			this.BindingMapTrackDataCache.Remove(levelPlayConfigId);
			if (this.CurFocusLevelPlayId == levelPlayConfigId)
			{
				this.RefreshTrack();
			}
		}

		// Token: 0x0603C03E RID: 245822 RVA: 0x00F38EE4 File Offset: 0x00F370E4
		public void AddWatchingLevelPlay(int levelPlayConfigId)
		{
			this.WatchingList.Add(levelPlayConfigId);
		}

		// Token: 0x0603C03F RID: 245823 RVA: 0x00F38EF3 File Offset: 0x00F370F3
		public void RemoveWatchingLevelPlay(int levelPlayConfigId)
		{
			this.WatchingList.Remove(levelPlayConfigId);
		}

		// Token: 0x0603C040 RID: 245824 RVA: 0x00F38F04 File Offset: 0x00F37104
		public void EnableTrack(bool value, ESetTrackReason reason = ESetTrackReason.None, BindingExpressionComponentHolder.EUpdateTrackType type = BindingExpressionComponentHolder.EUpdateTrackType.Text | BindingExpressionComponentHolder.EUpdateTrackType.TrackMark)
		{
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.<Blackboard>P.TreeIncId), false);
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent = (behaviorTree != null) ? behaviorTree.Expression : null;
			if (behaviorTreeExpressionComponent != null)
			{
				behaviorTreeExpressionComponent.ForceSetAllMapMarksVisible(!this.IsValid());
			}
			if (!this.IsBinding())
			{
				return;
			}
			foreach (KeyValuePair<int, BehaviorTreeExpressionComponent> keyValuePair in this.BindingExpressions)
			{
				int num;
				BehaviorTreeExpressionComponent behaviorTreeExpressionComponent2;
				keyValuePair.Deconstruct(out num, out behaviorTreeExpressionComponent2);
				int num2 = num;
				behaviorTreeExpressionComponent2.EnableTrack(value && num2 == this.CurFocusLevelPlayId, reason, true);
			}
			if ((type & BindingExpressionComponentHolder.EUpdateTrackType.Text) != (BindingExpressionComponentHolder.EUpdateTrackType)0)
			{
				this.EnableTrackForText(value, reason);
			}
			if ((type & BindingExpressionComponentHolder.EUpdateTrackType.TrackMark) != (BindingExpressionComponentHolder.EUpdateTrackType)0)
			{
				this.EnableTrackForTrackMark(value, reason);
			}
		}

		// Token: 0x0603C041 RID: 245825 RVA: 0x00F38FD4 File Offset: 0x00F371D4
		public bool IsValid()
		{
			foreach (int levelPlayConfigId in this.BindingExpressions.Keys)
			{
				if (this.IsBindingValid(levelPlayConfigId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C042 RID: 245826 RVA: 0x00F39038 File Offset: 0x00F37238
		public bool IsBinding()
		{
			foreach (BehaviorTreeExpressionComponent behaviorTreeExpressionComponent in this.BindingExpressions.Values)
			{
				if (behaviorTreeExpressionComponent != null && behaviorTreeExpressionComponent.IsValid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C043 RID: 245827 RVA: 0x00F390A0 File Offset: 0x00F372A0
		public void OnBindingNodeTextUpdate()
		{
			this.IsTrackTextDirty = true;
		}

		// Token: 0x0603C044 RID: 245828 RVA: 0x00F390A9 File Offset: 0x00F372A9
		public void OnBindingNodeTrackMarkUpdate()
		{
			this.IsTrackMarkDirty = true;
		}

		// Token: 0x0603C045 RID: 245829 RVA: 0x00F390B2 File Offset: 0x00F372B2
		public BehaviorTreeViewShowData GetShowData(bool bTrackText)
		{
			return this.BuildBehaviorTreeViewShowData(true);
		}

		// Token: 0x0603C046 RID: 245830 RVA: 0x00F390BB File Offset: 0x00F372BB
		public int GetNodeIdByLevelPlayConfigId(int levelPlayConfigId)
		{
			return this.LevelPlayIdToQuestNodeId.GetValueOrDefault(levelPlayConfigId, 0);
		}

		// Token: 0x0603C047 RID: 245831 RVA: 0x00F390CA File Offset: 0x00F372CA
		public int GetCurFocusLevelPlayId()
		{
			return this.CurFocusLevelPlayId;
		}

		// Token: 0x0603C048 RID: 245832 RVA: 0x00F390D4 File Offset: 0x00F372D4
		private bool IsBindingValid(int levelPlayConfigId)
		{
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (!this.BindingExpressions.TryGetValue(levelPlayConfigId, out behaviorTreeExpressionComponent) || !behaviorTreeExpressionComponent.IsValid)
			{
				return false;
			}
			int valueOrDefault = this.LevelPlayIdToQuestNodeId.GetValueOrDefault(levelPlayConfigId, 0);
			BehaviorNodeBase node = this.<Blackboard>P.GetNode(new int?(valueOrDefault));
			object obj;
			if (node == null)
			{
				obj = null;
			}
			else
			{
				ITrackTarget trackTarget = node.TrackTarget;
				obj = ((trackTarget != null) ? trackTarget.TrackType : null);
			}
			ITrackLevelPlay trackLevelPlay = obj as ITrackLevelPlay;
			global::LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(levelPlayConfigId);
			return (levelPlayInfo != null && levelPlayInfo.IsInTrackRange()) || ((trackLevelPlay != null) ? trackLevelPlay.TrackSwitchRule : null).GetValueOrDefault() != ELevelPlayTrackSwitchRule.SwitchByLevelPlayTrack;
		}

		// Token: 0x0603C049 RID: 245833 RVA: 0x00F39178 File Offset: 0x00F37378
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<long>(EEventName.OnCreateBehaviorTree, new Action<long>(this.OnTreeCreate));
			Singleton<EventSystem>.Instance.Add<long, ETreeRemoveReason>(EEventName.OnGeneralLogicTreeRemove, new Action<long, ETreeRemoveReason>(this.OnTreeRemove));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnEnterLevelPlayNotify, new Action<int>(this.OnEnterLevelPlayRange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnLeaveLevelPlayNotify, new Action<int>(this.OnLeaveLevelPlayRange));
		}

		// Token: 0x0603C04A RID: 245834 RVA: 0x00F391F8 File Offset: 0x00F373F8
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<long>(EEventName.OnCreateBehaviorTree, new Action<long>(this.OnTreeCreate));
			Singleton<EventSystem>.Instance.Remove<long, ETreeRemoveReason>(EEventName.OnGeneralLogicTreeRemove, new Action<long, ETreeRemoveReason>(this.OnTreeRemove));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnEnterLevelPlayNotify, new Action<int>(this.OnEnterLevelPlayRange));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnLeaveLevelPlayNotify, new Action<int>(this.OnLeaveLevelPlayRange));
		}

		// Token: 0x0603C04B RID: 245835 RVA: 0x00F39278 File Offset: 0x00F37478
		private void EnableTrackForText(bool enable, ESetTrackReason reason)
		{
			ETreeTextExpressReason p = ETreeTextExpressReason.None;
			if (reason == ESetTrackReason.QuestFinished)
			{
				p = ETreeTextExpressReason.QuestFinished;
			}
			bool flag = this.<Blackboard>P.ContainTag(EBehaviorTreeTag.SkipMissionPanelAnim) || ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled;
			if (enable)
			{
				BehaviorTreeViewShowData behaviorTreeViewShowData = this.BuildBehaviorTreeViewShowData(true);
				if (behaviorTreeViewShowData.MainStepInfo == null && (behaviorTreeViewShowData.SubStepInfos == null || behaviorTreeViewShowData.SubStepInfos.Count == 0))
				{
					return;
				}
				if (this.IsTextExpressing)
				{
					Singleton<EventSystem>.Instance.Emit<BehaviorTreeViewShowData, bool>(EEventName.GeneralLogicTreeUpdateShowTrackText, behaviorTreeViewShowData, flag);
					return;
				}
				Singleton<EventSystem>.Instance.Emit<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeStartShowTrackText, behaviorTreeViewShowData, p, flag);
				this.IsTextExpressing = true;
				return;
			}
			else
			{
				if (!this.IsTextExpressing)
				{
					return;
				}
				Singleton<EventSystem>.Instance.Emit<long, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeEndShowTrackText, this.<Blackboard>P.TreeIncId, p, flag);
				this.IsTextExpressing = false;
				return;
			}
		}

		// Token: 0x0603C04C RID: 245836 RVA: 0x00F3933C File Offset: 0x00F3753C
		private void EnableTrackForTrackMark(bool enable, ESetTrackReason reason)
		{
			if (enable)
			{
				foreach (ITrackData data in this.BuildTrackData())
				{
					ControllerBase<TrackController>.Instance.StartTrack(data, true);
				}
			}
		}

		// Token: 0x0603C04D RID: 245837 RVA: 0x00F39398 File Offset: 0x00F37598
		private BehaviorTreeViewShowData BuildBehaviorTreeViewShowData(bool bTrackText = true)
		{
			BehaviorTreeViewShowData behaviorTreeViewShowData = this.<Blackboard>P.CreateOriginalShowData(bTrackText);
			BtType btType = behaviorTreeViewShowData.BtType;
			long id = behaviorTreeViewShowData.Id;
			int treeConfigId = behaviorTreeViewShowData.TreeConfigId;
			long value = 0L;
			int trackIconConfigId = behaviorTreeViewShowData.TrackIconConfigId;
			string titleTextKey = behaviorTreeViewShowData.TitleTextKey;
			bool flag = behaviorTreeViewShowData.IsInChallenge;
			int num = behaviorTreeViewShowData.ShowPriority;
			BehaviorTreeStepTextInfo mainStepInfo = behaviorTreeViewShowData.MainStepInfo;
			List<BehaviorTreeStepTextInfo> subStepText = new List<BehaviorTreeStepTextInfo>();
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (this.BindingExpressions.TryGetValue(this.CurFocusLevelPlayId, out behaviorTreeExpressionComponent))
			{
				BehaviorTreeViewShowData behaviorTreeViewShowData2 = behaviorTreeExpressionComponent.CreateShowData();
				if (behaviorTreeViewShowData2.MainStepInfo == null)
				{
					List<BehaviorTreeStepTextInfo> subStepInfos = behaviorTreeViewShowData2.SubStepInfos;
					if (((subStepInfos != null) ? subStepInfos.Count : 0) <= 0)
					{
						goto IL_E1;
					}
				}
				btType = behaviorTreeViewShowData2.BtType;
				id = behaviorTreeViewShowData2.Id;
				treeConfigId = behaviorTreeViewShowData2.TreeConfigId;
				flag = (behaviorTreeViewShowData2.IsInChallenge || flag);
				num = Math.Max(behaviorTreeViewShowData2.ShowPriority, num);
				mainStepInfo = behaviorTreeViewShowData2.MainStepInfo;
				subStepText = (behaviorTreeViewShowData2.SubStepInfos ?? new List<BehaviorTreeStepTextInfo>());
				IL_E1:
				value = behaviorTreeViewShowData.Id;
			}
			return BehaviorTreeViewShowData.Create(btType, id, treeConfigId, flag, trackIconConfigId, num, titleTextKey, mainStepInfo, subStepText, new long?(value));
		}

		// Token: 0x0603C04E RID: 245838 RVA: 0x00F394AC File Offset: 0x00F376AC
		private List<ITrackData> BuildTrackData()
		{
			string questMarkIconPathByQuestId = Singleton<QuestUtil>.Instance.GetQuestMarkIconPathByQuestId(this.<Blackboard>P.TreeConfigId);
			List<ITrackData> list = new List<ITrackData>();
			foreach (int num in this.BindingExpressions.Keys)
			{
				Dictionary<int, List<ITrackData>> dictionary;
				if (this.IsBindingValid(num) && num == this.CurFocusLevelPlayId && this.BindingMapTrackDataCache.TryGetValue(num, out dictionary))
				{
					foreach (List<ITrackData> list2 in dictionary.Values)
					{
						foreach (ITrackData trackData in list2)
						{
							if (!trackData.WeakTrack.GetValueOrDefault())
							{
								trackData.IconPath = questMarkIconPathByQuestId;
							}
							list.Add(trackData);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0603C04F RID: 245839 RVA: 0x00F395E0 File Offset: 0x00F377E0
		private void RefreshTrack()
		{
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.<Blackboard>P.TreeIncId), false);
			if (behaviorTree == null)
			{
				return;
			}
			if (this.<Blackboard>P.IsTracking)
			{
				behaviorTree.SetTrack(false, ESetTrackReason.None);
				behaviorTree.SetTrack(true, ESetTrackReason.None);
			}
		}

		// Token: 0x0603C050 RID: 245840 RVA: 0x00F3962C File Offset: 0x00F3782C
		private void OnTreeCreate(long treeIncId)
		{
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null || behaviorTree.BtType != BtType.LevelPlay)
			{
				return;
			}
			if (this.WatchingList.Contains(behaviorTree.TreeConfigId))
			{
				if (!this.WatchingList.Contains(this.CurFocusLevelPlayId))
				{
					this.CurFocusLevelPlayId = behaviorTree.TreeConfigId;
				}
				int valueOrDefault = this.LevelPlayIdToQuestNodeId.GetValueOrDefault(behaviorTree.TreeConfigId, 0);
				this.AddBindingExpression(valueOrDefault, behaviorTree.TreeConfigId);
			}
		}

		// Token: 0x0603C051 RID: 245841 RVA: 0x00F396B4 File Offset: 0x00F378B4
		private void OnTreeRemove(long treeIncId, ETreeRemoveReason eTreeRemoveReason)
		{
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null || behaviorTree.BtType != BtType.LevelPlay)
			{
				return;
			}
			if (this.WatchingList.Contains(behaviorTree.TreeConfigId))
			{
				if (behaviorTree.GetBlackBoard().GetCurrentActiveChildQuestNode(true) == null)
				{
					bool p = this.<Blackboard>P.ContainTag(EBehaviorTreeTag.SkipMissionPanelAnim) || ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled;
					BehaviorTreeViewShowData p2 = this.BuildBehaviorTreeViewShowData(true);
					Singleton<EventSystem>.Instance.Emit<BehaviorTreeViewShowData, bool>(EEventName.GeneralLogicTreeUpdateShowTrackText, p2, p);
				}
				this.RemoveBindingExpression(behaviorTree.TreeConfigId);
			}
		}

		// Token: 0x0603C052 RID: 245842 RVA: 0x00F39750 File Offset: 0x00F37950
		private void OnEnterLevelPlayRange(int levelPlayId)
		{
			BaseBehaviorTree behaviorTreeByConfigId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeByConfigId(BtType.LevelPlay, levelPlayId);
			if (behaviorTreeByConfigId == null || behaviorTreeByConfigId.BtType != BtType.LevelPlay)
			{
				return;
			}
			if (this.WatchingList.Contains(behaviorTreeByConfigId.TreeConfigId))
			{
				if (!this.WatchingList.Contains(this.CurFocusLevelPlayId))
				{
					this.CurFocusLevelPlayId = behaviorTreeByConfigId.TreeConfigId;
				}
				int valueOrDefault = this.LevelPlayIdToQuestNodeId.GetValueOrDefault(behaviorTreeByConfigId.TreeConfigId, 0);
				this.AddBindingExpression(valueOrDefault, behaviorTreeByConfigId.TreeConfigId);
			}
		}

		// Token: 0x0603C053 RID: 245843 RVA: 0x00F397D4 File Offset: 0x00F379D4
		private void OnLeaveLevelPlayRange(int levelPlayId)
		{
			BaseBehaviorTree behaviorTreeByConfigId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeByConfigId(BtType.LevelPlay, levelPlayId);
			if (behaviorTreeByConfigId == null || behaviorTreeByConfigId.BtType != BtType.LevelPlay)
			{
				return;
			}
			if (this.WatchingList.Contains(behaviorTreeByConfigId.TreeConfigId))
			{
				this.RemoveBindingExpression(behaviorTreeByConfigId.TreeConfigId);
			}
		}

		// Token: 0x0603C054 RID: 245844 RVA: 0x00F39822 File Offset: 0x00F37A22
		private void OnTick(float deltaTime)
		{
			this.TickFocusExpression(deltaTime);
			this.TickTrackUpdate(deltaTime);
		}

		// Token: 0x0603C055 RID: 245845 RVA: 0x00F39834 File Offset: 0x00F37A34
		private void TickTrackUpdate(float deltaTime)
		{
			if (!this.IsValid())
			{
				return;
			}
			this.TickTime += deltaTime;
			if (this.TickTime < 100f)
			{
				return;
			}
			this.TickTime = 0f;
			BindingExpressionComponentHolder.EUpdateTrackType eupdateTrackType = (BindingExpressionComponentHolder.EUpdateTrackType)0;
			eupdateTrackType |= (this.IsTrackTextDirty ? BindingExpressionComponentHolder.EUpdateTrackType.Text : ((BindingExpressionComponentHolder.EUpdateTrackType)0));
			eupdateTrackType |= (this.IsTrackMarkDirty ? BindingExpressionComponentHolder.EUpdateTrackType.TrackMark : ((BindingExpressionComponentHolder.EUpdateTrackType)0));
			if (eupdateTrackType != (BindingExpressionComponentHolder.EUpdateTrackType)0 && this.<Blackboard>P.IsTracking)
			{
				this.IsTrackTextDirty = false;
				this.IsTrackMarkDirty = false;
				this.EnableTrack(true, ESetTrackReason.None, eupdateTrackType);
			}
		}

		// Token: 0x0603C056 RID: 245846 RVA: 0x00F398B8 File Offset: 0x00F37AB8
		private void TickFocusExpression(float deltaTime)
		{
			int curFocusLevelPlayId = this.CurFocusLevelPlayId;
			int trackBoundLevelPlayId = ModelBase<LevelPlayModel>.Instance.GetTrackBoundLevelPlayId();
			if (curFocusLevelPlayId == trackBoundLevelPlayId)
			{
				return;
			}
			this.CurFocusLevelPlayId = trackBoundLevelPlayId;
			if (this.CurFocusLevelPlayId == 0 || curFocusLevelPlayId == 0)
			{
				this.RefreshTrack();
				return;
			}
			if (!this.IsBindingValid(trackBoundLevelPlayId))
			{
				return;
			}
			if (this.<Blackboard>P.IsTracking)
			{
				this.EnableTrack(true, ESetTrackReason.None, BindingExpressionComponentHolder.EUpdateTrackType.Text | BindingExpressionComponentHolder.EUpdateTrackType.TrackMark);
			}
		}

		// Token: 0x0603C057 RID: 245847 RVA: 0x00F39918 File Offset: 0x00F37B18
		public double GetTrackDistance()
		{
			BehaviorNodeBase curTrackNode = this.GetCurTrackNode();
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (this.BindingExpressions.TryGetValue(this.CurFocusLevelPlayId, out behaviorTreeExpressionComponent))
			{
				return behaviorTreeExpressionComponent.GetTrackDistance((curTrackNode != null) ? curTrackNode.NodeId : 0);
			}
			return 0.0;
		}

		// Token: 0x0603C058 RID: 245848 RVA: 0x00F39960 File Offset: 0x00F37B60
		public int GetDefaultMark()
		{
			BehaviorNodeBase curTrackNode = this.GetCurTrackNode();
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (this.BindingExpressions.TryGetValue(this.CurFocusLevelPlayId, out behaviorTreeExpressionComponent))
			{
				return behaviorTreeExpressionComponent.GetDefaultMark((curTrackNode != null) ? curTrackNode.NodeId : 0).GetValueOrDefault();
			}
			return 0;
		}

		// Token: 0x0603C059 RID: 245849 RVA: 0x00F399A8 File Offset: 0x00F37BA8
		public double GetRangeMarkSize()
		{
			BehaviorNodeBase curTrackNode = this.GetCurTrackNode();
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (this.BindingExpressions.TryGetValue(this.CurFocusLevelPlayId, out behaviorTreeExpressionComponent))
			{
				return behaviorTreeExpressionComponent.GetRangeMarkSize((curTrackNode != null) ? curTrackNode.NodeId : 0);
			}
			return 0.0;
		}

		// Token: 0x0603C05A RID: 245850 RVA: 0x00F399F0 File Offset: 0x00F37BF0
		public double GetRangeMarkShowDis()
		{
			BehaviorNodeBase curTrackNode = this.GetCurTrackNode();
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (this.BindingExpressions.TryGetValue(this.CurFocusLevelPlayId, out behaviorTreeExpressionComponent))
			{
				return behaviorTreeExpressionComponent.GetRangeMarkShowDis((curTrackNode != null) ? curTrackNode.NodeId : 0).GetValueOrDefault();
			}
			return 0.0;
		}

		// Token: 0x0603C05B RID: 245851 RVA: 0x00F39A40 File Offset: 0x00F37C40
		[NullableContext(2)]
		public global::Vector GetNodeTrackPosition()
		{
			BehaviorNodeBase curTrackNode = this.GetCurTrackNode();
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (this.BindingExpressions.TryGetValue(this.CurFocusLevelPlayId, out behaviorTreeExpressionComponent))
			{
				return behaviorTreeExpressionComponent.GetNodeTrackPosition((curTrackNode != null) ? curTrackNode.NodeId : 0);
			}
			return null;
		}

		// Token: 0x0603C05C RID: 245852 RVA: 0x00F39A80 File Offset: 0x00F37C80
		[NullableContext(2)]
		private BehaviorNodeBase GetCurTrackNode()
		{
			BehaviorTreeViewShowData behaviorTreeViewShowData = this.BuildBehaviorTreeViewShowData(true);
			GeneralLogicTreeController instance = ControllerBase<GeneralLogicTreeController>.Instance;
			BehaviorTreeStepTextInfo mainStepInfo = behaviorTreeViewShowData.MainStepInfo;
			int titleTrackNodeId = instance.GetTitleTrackNodeId((mainStepInfo != null) ? mainStepInfo.QuestScheduleType : null);
			BehaviorTreeExpressionComponent behaviorTreeExpressionComponent;
			if (!this.BindingExpressions.TryGetValue(this.CurFocusLevelPlayId, out behaviorTreeExpressionComponent))
			{
				return null;
			}
			if (titleTrackNodeId != 0)
			{
				return behaviorTreeExpressionComponent.GetBlackBoard().GetNode(new int?(titleTrackNodeId));
			}
			return behaviorTreeExpressionComponent.GetBlackBoard().GetCurrentActiveChildQuestNode(true);
		}

		// Token: 0x04021B72 RID: 138098
		[CompilerGenerated]
		private Blackboard <Blackboard>P = Blackboard;

		// Token: 0x04021B73 RID: 138099
		private const int TICK_INTERVAL = 100;

		// Token: 0x04021B74 RID: 138100
		private readonly Dictionary<int, BehaviorTreeExpressionComponent> BindingExpressions = new Dictionary<int, BehaviorTreeExpressionComponent>();

		// Token: 0x04021B75 RID: 138101
		private readonly HashSet<int> WatchingList = new HashSet<int>();

		// Token: 0x04021B76 RID: 138102
		private readonly Dictionary<int, int> DefaultMapTrackMarkIds = new Dictionary<int, int>();

		// Token: 0x04021B77 RID: 138103
		private readonly Dictionary<int, List<ITrackData>> DefaultMapTrackData = new Dictionary<int, List<ITrackData>>();

		// Token: 0x04021B78 RID: 138104
		private readonly Dictionary<int, global::Vector> DefaultTrackPosCache = new Dictionary<int, global::Vector>();

		// Token: 0x04021B79 RID: 138105
		private readonly Dictionary<int, int> LevelPlayIdToQuestNodeId = new Dictionary<int, int>();

		// Token: 0x04021B7A RID: 138106
		public readonly Dictionary<int, Dictionary<int, List<ITrackData>>> BindingMapTrackDataCache = new Dictionary<int, Dictionary<int, List<ITrackData>>>();

		// Token: 0x04021B7B RID: 138107
		private bool IsTextExpressing;

		// Token: 0x04021B7C RID: 138108
		private bool IsTrackTextDirty;

		// Token: 0x04021B7D RID: 138109
		private bool IsTrackMarkDirty;

		// Token: 0x04021B7E RID: 138110
		private float TickTime;

		// Token: 0x04021B7F RID: 138111
		[Nullable(2)]
		private Ticker Ticker;

		// Token: 0x04021B80 RID: 138112
		private int CurFocusLevelPlayId;

		// Token: 0x0200BD68 RID: 48488
		[NullableContext(0)]
		[Flags]
		public enum EUpdateTrackType
		{
			// Token: 0x0403A583 RID: 238979
			Text = 1,
			// Token: 0x0403A584 RID: 238980
			TrackMark = 2
		}
	}
}
