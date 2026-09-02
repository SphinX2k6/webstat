using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks;
using CSharpScript.Game.Module.Map.Misc;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006122 RID: 24866
	[NullableContext(1)]
	[Nullable(0)]
	public class TrackedMarksView : BattleChildView
	{
		// Token: 0x0603ED1F RID: 257311 RVA: 0x01017E80 File Offset: 0x01016080
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.BindEvents();
			foreach (Dictionary<int, ITrackData> dictionary in ModelBase<BattleUiModel>.Instance.TrackDatas.Values)
			{
				foreach (ITrackData trackData in dictionary.Values)
				{
					this.TrackMark(trackData);
				}
			}
		}

		// Token: 0x0603ED20 RID: 257312 RVA: 0x01017F24 File Offset: 0x01016124
		public override void Reset()
		{
			base.Reset();
			this.UnbindEvents();
			foreach (Dictionary<int, TrackedMark> dictionary in this.TrackedMarks.Values)
			{
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					trackedMark.Destroy(null);
				}
			}
			this.TrackedMarks.Clear();
		}

		// Token: 0x0603ED21 RID: 257313 RVA: 0x01017FCC File Offset: 0x010161CC
		public void OnShowBattleChildViewPanel()
		{
			foreach (Dictionary<int, TrackedMark> dictionary in this.TrackedMarks.Values)
			{
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					trackedMark.OnUiShow();
				}
			}
		}

		// Token: 0x0603ED22 RID: 257314 RVA: 0x0101805C File Offset: 0x0101625C
		public void Update(float delta)
		{
			ModelBase<TrackModel>.Instance.ClearGroupMinDistance();
			foreach (Dictionary<int, TrackedMark> dictionary in this.TrackedMarks.Values)
			{
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					trackedMark.UpdateTrackDistance();
				}
			}
			foreach (KeyValuePair<int, Dictionary<int, TrackedMark>> keyValuePair in this.TrackedMarks)
			{
				int num;
				Dictionary<int, TrackedMark> dictionary2;
				keyValuePair.Deconstruct(out num, out dictionary2);
				int inSourceId = num;
				foreach (TrackedMark trackedMark2 in dictionary2.Values)
				{
					if (this.TrackedMarksDirty)
					{
						if (this.IsTrackTargetRepeat(trackedMark2, (ETrackSource)inSourceId))
						{
							trackedMark2.ShouldShowTrackMark = false;
						}
						else
						{
							trackedMark2.ShouldShowTrackMark = true;
						}
					}
					trackedMark2.Update(delta);
				}
			}
			this.TrackedMarksDirty = false;
		}

		// Token: 0x0603ED23 RID: 257315 RVA: 0x010181B0 File Offset: 0x010163B0
		public bool IsTrackTargetRepeat(TrackedMark item, ETrackSource inSourceId)
		{
			foreach (KeyValuePair<int, Dictionary<int, TrackedMark>> keyValuePair in this.TrackedMarks)
			{
				int num;
				Dictionary<int, TrackedMark> dictionary;
				keyValuePair.Deconstruct(out num, out dictionary);
				int num2 = num;
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					if (item.TrackTarget == trackedMark.TrackTarget && inSourceId < (ETrackSource)num2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603ED24 RID: 257316 RVA: 0x01018264 File Offset: 0x01016464
		public void OnHideBattleChildViewPanel()
		{
			foreach (Dictionary<int, TrackedMark> dictionary in this.TrackedMarks.Values)
			{
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					trackedMark.OnUiHide();
				}
			}
		}

		// Token: 0x0603ED25 RID: 257317 RVA: 0x010182F4 File Offset: 0x010164F4
		private void TrackMark(ITrackData trackData)
		{
			if (!MarkItemUtil.CanShowTrackMark(trackData))
			{
				ELogAuthor author = ELogAuthor.LYX;
				string message = "标记系统-追踪->TackedMarksView.TrackMark,追踪标记不满足显示条件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("trackData", trackData);
				MapLogger.Debug(author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			TTrackTarget_AActor ttrackTarget_AActor = trackData.TrackTarget as TTrackTarget_AActor;
			if (ttrackTarget_AActor != null && !ttrackTarget_AActor.Value.IsValid())
			{
				return;
			}
			Dictionary<int, TrackedMark> dictionary;
			if (!this.TrackedMarks.TryGetValue((int)trackData.TrackSource, out dictionary))
			{
				dictionary = new Dictionary<int, TrackedMark>();
				this.TrackedMarks[(int)trackData.TrackSource] = dictionary;
			}
			if (!dictionary.ContainsKey(trackData.Id))
			{
				TrackedMark trackedMark;
				if (ControllerBase<TowerDefenseController>.Instance.CheckIsTowerEntity(trackData))
				{
					trackedMark = new TrackedMarkForTower(trackData);
				}
				else
				{
					trackedMark = new TrackedMark(trackData);
				}
				dictionary[trackData.Id] = trackedMark;
				trackedMark.Initialize(this.RootItem);
				Dictionary<int, ITrackData> dictionary2;
				if (!ModelBase<BattleUiModel>.Instance.TrackDatas.TryGetValue((int)trackData.TrackSource, out dictionary2))
				{
					dictionary2 = new Dictionary<int, ITrackData>();
					ModelBase<BattleUiModel>.Instance.TrackDatas[(int)trackData.TrackSource] = dictionary2;
				}
				dictionary2[trackData.Id] = trackData;
			}
			this.TrackedMarksDirty = true;
		}

		// Token: 0x0603ED26 RID: 257318 RVA: 0x01018408 File Offset: 0x01016608
		private void UnTrackMark(ITrackData trackData)
		{
			Dictionary<int, TrackedMark> dictionary;
			if (!this.TrackedMarks.TryGetValue((int)trackData.TrackSource, out dictionary))
			{
				return;
			}
			TrackedMark trackedMark;
			if (dictionary.TryGetValue(trackData.Id, out trackedMark))
			{
				trackedMark.Destroy(null);
				dictionary.Remove(trackData.Id);
				Dictionary<int, ITrackData> dictionary2;
				if (ModelBase<BattleUiModel>.Instance.TrackDatas.TryGetValue((int)trackData.TrackSource, out dictionary2))
				{
					dictionary2.Remove(trackData.Id);
				}
			}
			this.TrackedMarksDirty = true;
		}

		// Token: 0x0603ED27 RID: 257319 RVA: 0x0101847C File Offset: 0x0101667C
		private void UpdateTrackTarget(ETrackSource trackSource, int id, TTrackTarget trackTarget)
		{
			Dictionary<int, TrackedMark> dictionary;
			if (!this.TrackedMarks.TryGetValue((int)trackSource, out dictionary))
			{
				return;
			}
			TrackedMark trackedMark;
			if (dictionary.TryGetValue(id, out trackedMark))
			{
				trackedMark.UpdateTrackTarget(trackTarget);
			}
		}

		// Token: 0x0603ED28 RID: 257320 RVA: 0x010184B0 File Offset: 0x010166B0
		private void SetTrackMarkOccupied(ETrackSource trackSource, int id, bool bOccupied)
		{
			Dictionary<int, TrackedMark> dictionary;
			if (!this.TrackedMarks.TryGetValue((int)trackSource, out dictionary))
			{
				return;
			}
			TrackedMark trackedMark;
			if (dictionary.TryGetValue(id, out trackedMark))
			{
				trackedMark.SetVisibleByOccupied(bOccupied);
			}
		}

		// Token: 0x0603ED29 RID: 257321 RVA: 0x010184E0 File Offset: 0x010166E0
		private void SetInteractSpotOccupied(ETrackSource trackSource, int id, bool bOccupied)
		{
			Dictionary<int, TrackedMark> dictionary;
			if (!this.TrackedMarks.TryGetValue((int)trackSource, out dictionary))
			{
				return;
			}
			TrackedMark trackedMark;
			if (dictionary.TryGetValue(id, out trackedMark))
			{
				trackedMark.SetVisibleByInteractionSpotOccupied(bOccupied);
			}
		}

		// Token: 0x0603ED2A RID: 257322 RVA: 0x01018510 File Offset: 0x01016710
		private void OnWorldMapSubMapChanged(int floor)
		{
			foreach (Dictionary<int, TrackedMark> dictionary in this.TrackedMarks.Values)
			{
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					trackedMark.UpdateDownStateSprite();
				}
			}
		}

		// Token: 0x0603ED2B RID: 257323 RVA: 0x010185A0 File Offset: 0x010167A0
		private void OnMarkItemShowStateChange(int markId)
		{
			using (Dictionary<int, Dictionary<int, TrackedMark>>.ValueCollection.Enumerator enumerator = this.TrackedMarks.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TrackedMark trackedMark;
					if (enumerator.Current.TryGetValue(markId, out trackedMark))
					{
						trackedMark.UpdateUpStateSprite();
					}
				}
			}
		}

		// Token: 0x0603ED2C RID: 257324 RVA: 0x01018600 File Offset: 0x01016800
		private void OnMarkItemUpdateMarkHideInfo()
		{
			foreach (Dictionary<int, TrackedMark> dictionary in this.TrackedMarks.Values)
			{
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					trackedMark.UpdateUpStateSprite();
				}
			}
		}

		// Token: 0x0603ED2D RID: 257325 RVA: 0x01018690 File Offset: 0x01016890
		private void OnLevelPlayStateChange()
		{
			foreach (Dictionary<int, TrackedMark> dictionary in this.TrackedMarks.Values)
			{
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					trackedMark.UpdateUpStateSprite();
				}
			}
		}

		// Token: 0x0603ED2E RID: 257326 RVA: 0x01018720 File Offset: 0x01016920
		private void OnLevelPlayStateChange(int levelId, ELevelPlayState state)
		{
			foreach (Dictionary<int, TrackedMark> dictionary in this.TrackedMarks.Values)
			{
				foreach (TrackedMark trackedMark in dictionary.Values)
				{
					trackedMark.UpdateUpStateSprite();
				}
			}
		}

		// Token: 0x0603ED2F RID: 257327 RVA: 0x010187B0 File Offset: 0x010169B0
		private void BindEvents()
		{
			Singleton<EventSystem>.Instance.Add<ITrackData>(EEventName.TrackMark, new Action<ITrackData>(this.TrackMark));
			Singleton<EventSystem>.Instance.Add<ITrackData>(EEventName.UnTrackMark, new Action<ITrackData>(this.UnTrackMark));
			Singleton<EventSystem>.Instance.Add<ETrackSource, int, TTrackTarget>(EEventName.UpdateTrackTarget, new Action<ETrackSource, int, TTrackTarget>(this.UpdateTrackTarget));
			Singleton<EventSystem>.Instance.Add<ETrackSource, int, bool>(EEventName.SetTrackMarkOccupied, new Action<ETrackSource, int, bool>(this.SetTrackMarkOccupied));
			Singleton<EventSystem>.Instance.Add<ETrackSource, int, bool>(EEventName.SetInteractSpotOccupied, new Action<ETrackSource, int, bool>(this.SetInteractSpotOccupied));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSubMapChanged, new Action<int>(this.OnWorldMapSubMapChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnMarkItemShowStateChange, new Action<int>(this.OnMarkItemShowStateChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMarkItemUpdateMarkHideInfo, new Action(this.OnMarkItemUpdateMarkHideInfo));
			Singleton<EventSystem>.Instance.Add(EEventName.LevelPlayStateDetailUpdate, new Action(this.OnLevelPlayStateChange));
			Singleton<EventSystem>.Instance.Add<int, ELevelPlayState>(EEventName.OnLevelPlayStateChange, new Action<int, ELevelPlayState>(this.OnLevelPlayStateChange));
			Singleton<EventSystem>.Instance.Add(EEventName.LevelPlayRewardDetailUpdate, new Action(this.OnLevelPlayStateChange));
		}

		// Token: 0x0603ED30 RID: 257328 RVA: 0x010188F4 File Offset: 0x01016AF4
		private void UnbindEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TrackMark, new Action<ITrackData>(this.TrackMark));
			Singleton<EventSystem>.Instance.Remove(EEventName.UnTrackMark, new Action<ITrackData>(this.UnTrackMark));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdateTrackTarget, new Action<ETrackSource, int, TTrackTarget>(this.UpdateTrackTarget));
			Singleton<EventSystem>.Instance.Remove(EEventName.SetTrackMarkOccupied, new Action<ETrackSource, int, bool>(this.SetTrackMarkOccupied));
			Singleton<EventSystem>.Instance.Remove(EEventName.SetInteractSpotOccupied, new Action<ETrackSource, int, bool>(this.SetInteractSpotOccupied));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapSubMapChanged, new Action<int>(this.OnWorldMapSubMapChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMarkItemShowStateChange, new Action<int>(this.OnMarkItemShowStateChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMarkItemUpdateMarkHideInfo, new Action(this.OnMarkItemUpdateMarkHideInfo));
			Singleton<EventSystem>.Instance.Remove(EEventName.LevelPlayStateDetailUpdate, new Action(this.OnLevelPlayStateChange));
			Singleton<EventSystem>.Instance.Remove<int, ELevelPlayState>(EEventName.OnLevelPlayStateChange, new Action<int, ELevelPlayState>(this.OnLevelPlayStateChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.LevelPlayRewardDetailUpdate, new Action(this.OnLevelPlayStateChange));
		}

		// Token: 0x0603ED31 RID: 257329 RVA: 0x01018A35 File Offset: 0x01016C35
		protected override bool DestroyOverride()
		{
			return true;
		}

		// Token: 0x040233E9 RID: 144361
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("(BattleView)UpdateTrackDistance", "", "");

		// Token: 0x040233EA RID: 144362
		private readonly Dictionary<int, Dictionary<int, TrackedMark>> TrackedMarks = new Dictionary<int, Dictionary<int, TrackedMark>>();

		// Token: 0x040233EB RID: 144363
		private bool TrackedMarksDirty;
	}
}
