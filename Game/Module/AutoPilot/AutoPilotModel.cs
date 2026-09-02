using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Transport;
using CSharpScript.Game.NewWorld.Vehicle.Motorcycle;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006147 RID: 24903
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class AutoPilotModel : ModelBase<AutoPilotModel>
	{
		// Token: 0x17009ADC RID: 39644
		// (get) Token: 0x0603EE88 RID: 257672 RVA: 0x0101FFC6 File Offset: 0x0101E1C6
		[Nullable(2)]
		public CharacterActorComponent ActorComp
		{
			[NullableContext(2)]
			get
			{
				SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
				if (instance == null)
				{
					return null;
				}
				EntityHandle getCurrentEntity = instance.GetCurrentEntity;
				if (getCurrentEntity == null)
				{
					return null;
				}
				WorldEntity entity = getCurrentEntity.Entity;
				if (entity == null)
				{
					return null;
				}
				return entity.GetComponent<CharacterActorComponent>();
			}
		}

		// Token: 0x0603EE89 RID: 257673 RVA: 0x0101FFEE File Offset: 0x0101E1EE
		protected override bool OnInit()
		{
			this.InitParameters();
			this.AddEvents();
			return true;
		}

		// Token: 0x0603EE8A RID: 257674 RVA: 0x0101FFFD File Offset: 0x0101E1FD
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<ITrackData>(EEventName.UnTrackMark, new Action<ITrackData>(this.OnUnTrackMark));
			Singleton<EventSystem>.Instance.Add<bool, bool>(EEventName.OnMovieMotorRideSharingModeChangeResponse, new Action<bool, bool>(this.OnMovieMotorRideSharingModeChangeResponse));
		}

		// Token: 0x0603EE8B RID: 257675 RVA: 0x01020038 File Offset: 0x0101E238
		private void InitParameters()
		{
			this.PlayerToTargetDistanceThreshold = Math.Pow((double)ConfigCommonParamById.GetIntConfig("AutoPilotPlayerToTargetDistanceThreshold").GetValueOrDefault(), 2.0);
			this.SplineDistanceThreshold = (double)ConfigCommonParamById.GetIntConfig("AutoPilotSplineDistanceThreshold").GetValueOrDefault();
			this.SkillHighLightTime = ConfigCommonParamById.GetIntConfig("AutoPilotSkillHighLightTime").GetValueOrDefault(-1);
			this.EnterMovieModeTimeThreshold = ConfigCommonParamById.GetIntConfig("AutoPilotEnterMovieModeTimeThreshold").GetValueOrDefault();
			this.EnterMovieModeDistanceThreshold = Math.Pow((double)ConfigCommonParamById.GetIntConfig("AutoPilotEnterMovieModeDistanceThreshold").GetValueOrDefault(), 2.0);
			this.CanSkipTimeThreshold = ConfigCommonParamById.GetIntConfig("AutoPilotCanSkipTimeThreshold").GetValueOrDefault();
			this.CanSkipDistanceThreshold = Math.Pow((double)ConfigCommonParamById.GetIntConfig("AutoPilotCanSkipDistanceThreshold").GetValueOrDefault(), 2.0);
			this.IsAllowExitByMove = ConfigCommonParamById.GetBoolConfig("AutoPilotExitByMove").GetValueOrDefault();
			this.AutoPilotRoadWayWidthOffset = (double)ConfigCommonParamById.GetIntConfig("AutoPilotRoadWayWidthOffset").GetValueOrDefault();
			this.AutoPilotExitHorizontalDistThreshold = Math.Pow((double)ConfigCommonParamById.GetIntConfig("AutoPilotExitHorizontalDistanceThreshold").GetValueOrDefault(1800), 2.0);
			this.AutoPilotExitVerticalDistThreshold = (double)ConfigCommonParamById.GetIntConfig("AutoPilotExitVerticalDistanceThreshold").GetValueOrDefault(1200);
			this.HighLightSampleDist = (double)AutoPilotDefine.HIGHLIGHTLINEDISTANCEINTERVAL;
			IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig("AutoPilotMovieCameraRowName");
			if (stringArrayConfig != null)
			{
				foreach (string item in stringArrayConfig)
				{
					this.MovieModeCameraRowNameArray.Add(item);
				}
			}
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("AutoPilotStuckSpeedThreshold").GetValueOrDefault();
			this.AutoPilotStuckSpeedThreshold = (double)valueOrDefault * (double)valueOrDefault;
			this.AutoPilotStuckTimeThreshold = (double)ConfigCommonParamById.GetIntConfig("AutoPilotStuckTimeThreshold").GetValueOrDefault();
			this.AutoPilotStuckStepDistance = (double)ConfigCommonParamById.GetIntConfig("AutoPilotStuckStepDistance").GetValueOrDefault();
			this.UpdateCirclePathData();
		}

		// Token: 0x0603EE8C RID: 257676 RVA: 0x01020250 File Offset: 0x0101E450
		public unsafe void UpdateCirclePathData()
		{
			this.MapIdToCirclePathMap.Clear();
			Dictionary<int, AutoPilotDefine.IAutoPilotCircles> mapIdToCirclePathMap = this.MapIdToCirclePathMap;
			int key = 105;
			AutoPilotCircles autoPilotCircles = new AutoPilotCircles();
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int num2 = 0;
			*span[num2] = 0;
			autoPilotCircles.RoadBuildIdArray = list;
			num2 = 1;
			List<int> list2 = new List<int>(num2);
			CollectionsMarshal.SetCount<int>(list2, num2);
			span = CollectionsMarshal.AsSpan<int>(list2);
			num = 0;
			*span[num] = 0;
			autoPilotCircles.CircleIds = list2;
			mapIdToCirclePathMap[key] = autoPilotCircles;
			InfrastructureConfig instance = ConfigBase<InfrastructureConfig>.Instance;
			IReadOnlyList<InfrAutoPilotCircle> readOnlyList = (instance != null) ? instance.GetAutoPilotCircle() : null;
			if (readOnlyList == null || readOnlyList.Count <= 0)
			{
				return;
			}
			foreach (InfrAutoPilotCircle infrAutoPilotCircle in readOnlyList)
			{
				if (this.IsRoadConfigValid(infrAutoPilotCircle.RoadBuildIdArray()))
				{
					int mapId = infrAutoPilotCircle.MapId;
					int autoPilotCirclePathId = infrAutoPilotCircle.AutoPilotCirclePathId;
					if (!this.MapIdToCirclePathMap.ContainsKey(mapId))
					{
						Dictionary<int, AutoPilotDefine.IAutoPilotCircles> mapIdToCirclePathMap2 = this.MapIdToCirclePathMap;
						int key2 = mapId;
						AutoPilotCircles autoPilotCircles2 = new AutoPilotCircles();
						autoPilotCircles2.RoadBuildIdArray = infrAutoPilotCircle.RoadBuildIdArrayIter().ToList<int>();
						num = 1;
						List<int> list3 = new List<int>(num);
						CollectionsMarshal.SetCount<int>(list3, num);
						span = CollectionsMarshal.AsSpan<int>(list3);
						num2 = 0;
						*span[num2] = autoPilotCirclePathId;
						autoPilotCircles2.CircleIds = list3;
						mapIdToCirclePathMap2[key2] = autoPilotCircles2;
					}
					else
					{
						AutoPilotDefine.IAutoPilotCircles autoPilotCircles3 = this.MapIdToCirclePathMap[mapId];
						if (infrAutoPilotCircle.RoadBuildIdArrayLength > autoPilotCircles3.RoadBuildIdArray.Count)
						{
							autoPilotCircles3.RoadBuildIdArray = new List<int>(infrAutoPilotCircle.RoadBuildIdArrayIter());
							autoPilotCircles3.CircleIds.Clear();
							autoPilotCircles3.CircleIds.Add(autoPilotCirclePathId);
						}
						else if (infrAutoPilotCircle.RoadBuildIdArrayLength == autoPilotCircles3.RoadBuildIdArray.Count)
						{
							autoPilotCircles3.CircleIds.Add(autoPilotCirclePathId);
						}
					}
				}
			}
		}

		// Token: 0x0603EE8D RID: 257677 RVA: 0x01020430 File Offset: 0x0101E630
		private bool IsRoadConfigValid(int[] roadBuildIdArray)
		{
			foreach (int roadId in roadBuildIdArray)
			{
				InfrastructureModel instance = ModelBase<InfrastructureModel>.Instance;
				InfrastructureDefine.IInfrRoadData infrRoadData = (instance != null) ? instance.GetRoadDataByRoadId(roadId) : null;
				if (infrRoadData == null || infrRoadData.Status != InfrStatusPb.InfrStatusComplete)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603EE8E RID: 257678 RVA: 0x01020473 File Offset: 0x0101E673
		public bool GetIsTracking(int markId)
		{
			MarkItem trackingMarkItem = this.TrackingMarkItem;
			return trackingMarkItem != null && trackingMarkItem.MarkId == markId;
		}

		// Token: 0x0603EE8F RID: 257679 RVA: 0x0102048C File Offset: 0x0101E68C
		[NullableContext(2)]
		public void SetTrackingMarkItem(MarkItem markItem)
		{
			if (this.TrackingMarkItem != null && markItem != null && this.TrackingMarkItem.MarkId == markItem.MarkId)
			{
				return;
			}
			this.ClearTrackingData();
			MarkItem trackingMarkItem = this.TrackingMarkItem;
			this.TrackingMarkItem = markItem;
			if (this.TrackingMarkItem != null)
			{
				this.SetTrackingData(new AutoPilotTrackingData
				{
					TargetPos = this.TrackingMarkItem.WorldPosition,
					MapId = this.TrackingMarkItem.MapId
				});
				Singleton<EventSystem>.Instance.Emit<EMarkType, int>(EEventName.OnMarkItemAutoPilotTrackStateChange, this.TrackingMarkItem.MarkType, this.TrackingMarkItem.MarkId);
			}
			if (trackingMarkItem != null)
			{
				Singleton<EventSystem>.Instance.Emit<EMarkType, int>(EEventName.OnMarkItemAutoPilotTrackStateChange, trackingMarkItem.MarkType, trackingMarkItem.MarkId);
			}
		}

		// Token: 0x0603EE90 RID: 257680 RVA: 0x01020546 File Offset: 0x0101E746
		public void ClearData()
		{
			this.ClearTrackingData();
			this.ClearCirclePathResult();
		}

		// Token: 0x0603EE91 RID: 257681 RVA: 0x01020554 File Offset: 0x0101E754
		public void ClearFindPathResult()
		{
			AutoPilotFindPathResult findPathResult = this.FindPathResult;
			if (findPathResult != null)
			{
				findPathResult.Clear();
			}
			this.FindPathResult = null;
		}

		// Token: 0x0603EE92 RID: 257682 RVA: 0x0102056E File Offset: 0x0101E76E
		public void ClearCirclePathResult()
		{
			this.CirclePathResult = null;
		}

		// Token: 0x0603EE93 RID: 257683 RVA: 0x01020578 File Offset: 0x0101E778
		public void SetTrackingData(AutoPilotDefine.IAutoPilotTrackingData trackingData)
		{
			this.TrackingData = trackingData;
			this.RefreshFindPath(null);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnUpdateAutoPilotLine);
			ControllerBase<AutoPilotController>.Instance.AddTick(new Action<float?>(this.RefreshFindPath));
		}

		// Token: 0x0603EE94 RID: 257684 RVA: 0x010205C4 File Offset: 0x0101E7C4
		public void ClearTrackingData()
		{
			ControllerBase<AutoPilotController>.Instance.ExitAutoPilot("ClearTrackingData", false);
			this.TrackingData = null;
			this.ClearFindPathResult();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnUpdateAutoPilotLine);
			ControllerBase<AutoPilotController>.Instance.RemoveTick(new Action<float?>(this.RefreshFindPath));
		}

		// Token: 0x0603EE95 RID: 257685 RVA: 0x01020615 File Offset: 0x0101E815
		public double GetSplineDistanceThreshold()
		{
			return this.SplineDistanceThreshold;
		}

		// Token: 0x0603EE96 RID: 257686 RVA: 0x0102061D File Offset: 0x0101E81D
		[NullableContext(2)]
		public AutoPilotFindPathResult GetFindPathResult()
		{
			return this.FindPathResult;
		}

		// Token: 0x0603EE97 RID: 257687 RVA: 0x01020625 File Offset: 0x0101E825
		[NullableContext(2)]
		public AutoPilotCirclePathResult GetCirclePathResult()
		{
			return this.CirclePathResult;
		}

		// Token: 0x0603EE98 RID: 257688 RVA: 0x01020630 File Offset: 0x0101E830
		public void RefreshFindPath(float? _ = null)
		{
			if (this.ActorComp == null)
			{
				return;
			}
			bool flag = false;
			if (this.FindPathResult == null)
			{
				this.FindPathResult = new AutoPilotFindPathResult();
				flag = true;
			}
			if (this.IsInAutoPilotInner)
			{
				this.FindPathResult.RefreshDataInAutoPilot();
				return;
			}
			if (!flag && !this.FindPathResult.IsNeedRefreshByFindPath(this.ActorComp.ActorLocationProxy))
			{
				return;
			}
			if (!this.CheckPlayerToTargetDistanceValid(this.TrackingData.TargetPos))
			{
				this.SetTrackingMarkItem(null);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(AutoPilotDefine.EAutoPilotTextId.TextCancelAutoPilotTooNearTips, Array.Empty<object>());
				return;
			}
			global::Vector targetPos = this.TrackingData.TargetPos;
			ITransportFindPathResult transportFindPathResult = ControllerBase<TransportNetworkController>.Instance.FindPath(this.ActorComp.ActorLocationProxy, targetPos, true, false, this.IsDebugMode);
			if (transportFindPathResult == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.AutoPilot, ELogAuthor.CB, "TransportNetworkController.FindPath return null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.FindPathResult.RefreshData(this.TrackingData.MapId, this.ActorComp.ActorLocationProxy, targetPos, transportFindPathResult);
		}

		// Token: 0x0603EE99 RID: 257689 RVA: 0x0102072D File Offset: 0x0101E92D
		public bool CheckPlayerToTargetDistanceValid(global::Vector targetPos)
		{
			return this.ActorComp != null && global::Vector.DistSquared2D(this.ActorComp.ActorLocationProxy, targetPos) > this.PlayerToTargetDistanceThreshold;
		}

		// Token: 0x0603EE9A RID: 257690 RVA: 0x01020752 File Offset: 0x0101E952
		public void RefreshCirclePath(int circleId, bool isInCircle)
		{
			if (this.CirclePathResult == null)
			{
				this.CirclePathResult = new AutoPilotCirclePathResult(circleId, isInCircle);
			}
			this.CirclePathResult.RefreshPathToCircleData();
		}

		// Token: 0x0603EE9B RID: 257691 RVA: 0x01020774 File Offset: 0x0101E974
		public bool GetIsInAutoPilot()
		{
			return this.IsInAutoPilotInner;
		}

		// Token: 0x0603EE9C RID: 257692 RVA: 0x0102077C File Offset: 0x0101E97C
		public AutoPilotDefine.EAutoPilotState GetAutoPilotState()
		{
			return this.AutoPilotState;
		}

		// Token: 0x0603EE9D RID: 257693 RVA: 0x01020784 File Offset: 0x0101E984
		public void SetAutoPilotState(AutoPilotDefine.EAutoPilotState state)
		{
			this.AutoPilotState = state;
			bool flag = state > AutoPilotDefine.EAutoPilotState.None;
			if (this.IsInAutoPilotInner == flag)
			{
				return;
			}
			this.IsInAutoPilotInner = flag;
			CharacterActorComponent actorComp = this.ActorComp;
			Entity entity = (actorComp != null) ? actorComp.Entity : null;
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null;
			BaseTagComponent baseTagComponent;
			if (characterDriveVehicleComponent == null)
			{
				baseTagComponent = null;
			}
			else
			{
				Entity vehicleEntity = characterDriveVehicleComponent.VehicleEntity;
				baseTagComponent = ((vehicleEntity != null) ? vehicleEntity.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (flag)
			{
				if (baseTagComponent2 != null && !baseTagComponent2.HasTag(AutoPilotDefine.autoPilotTag))
				{
					baseTagComponent2.AddTag(new int?(AutoPilotDefine.autoPilotTag));
				}
			}
			else if (baseTagComponent2 != null && baseTagComponent2.HasTag(AutoPilotDefine.autoPilotTag))
			{
				baseTagComponent2.RemoveTag(new int?(AutoPilotDefine.autoPilotTag));
			}
			Singleton<AudioSystem>.Instance.PostEvent(flag ? "play_ui_moto_autopilot_tips_enter" : "play_ui_moto_autopilot_tips_exit");
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnAutoPilotStateChange, flag);
		}

		// Token: 0x0603EE9E RID: 257694 RVA: 0x01020860 File Offset: 0x0101EA60
		public bool GetIsInMovieMode()
		{
			return this.IsInMovieModeInner;
		}

		// Token: 0x0603EE9F RID: 257695 RVA: 0x01020868 File Offset: 0x0101EA68
		public void SetIsInMovieMode(bool value)
		{
			this.IsInMovieModeInner = value;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.MotorInMovieModeChange, value);
		}

		// Token: 0x0603EEA0 RID: 257696 RVA: 0x0102088C File Offset: 0x0101EA8C
		public double GetPlayerToTargetDistanceThreshold()
		{
			return this.PlayerToTargetDistanceThreshold;
		}

		// Token: 0x0603EEA1 RID: 257697 RVA: 0x01020894 File Offset: 0x0101EA94
		public int GetEnterMovieModeTimeThreshold()
		{
			return this.EnterMovieModeTimeThreshold;
		}

		// Token: 0x0603EEA2 RID: 257698 RVA: 0x0102089C File Offset: 0x0101EA9C
		public double GetEnterMovieModeDistanceThreshold()
		{
			return this.EnterMovieModeDistanceThreshold;
		}

		// Token: 0x0603EEA3 RID: 257699 RVA: 0x010208A4 File Offset: 0x0101EAA4
		public int GetCanSkipTimeThreshold()
		{
			return this.CanSkipTimeThreshold;
		}

		// Token: 0x0603EEA4 RID: 257700 RVA: 0x010208AC File Offset: 0x0101EAAC
		public double GetCanSkipDistanceThreshold()
		{
			return this.CanSkipDistanceThreshold;
		}

		// Token: 0x0603EEA5 RID: 257701 RVA: 0x010208B4 File Offset: 0x0101EAB4
		public int GetSkillHighLightTime()
		{
			return this.SkillHighLightTime;
		}

		// Token: 0x0603EEA6 RID: 257702 RVA: 0x010208BC File Offset: 0x0101EABC
		public double GetAutoPilotTime()
		{
			return this.AutoPilotTime;
		}

		// Token: 0x0603EEA7 RID: 257703 RVA: 0x010208C4 File Offset: 0x0101EAC4
		public void AddAutoPilotTime(double deltaTime)
		{
			this.AutoPilotTime += deltaTime;
		}

		// Token: 0x0603EEA8 RID: 257704 RVA: 0x010208D4 File Offset: 0x0101EAD4
		public void ResetAutoPilotTime()
		{
			this.AutoPilotTime = 0.0;
		}

		// Token: 0x17009ADD RID: 39645
		// (get) Token: 0x0603EEA9 RID: 257705 RVA: 0x010208E5 File Offset: 0x0101EAE5
		// (set) Token: 0x0603EEAA RID: 257706 RVA: 0x010208ED File Offset: 0x0101EAED
		public int AutoPilotAreaId
		{
			get
			{
				return this.AutoPilotAreaIdInner;
			}
			set
			{
				if (this.AutoPilotAreaIdInner == value)
				{
					return;
				}
				if (this.TrackingData != null)
				{
					this.SetTrackingMarkItem(null);
				}
				this.AutoPilotAreaIdInner = value;
			}
		}

		// Token: 0x0603EEAB RID: 257707 RVA: 0x0102090F File Offset: 0x0101EB0F
		public bool GetIsCanShowSkipBtn()
		{
			return this.IsCanShowSkipBtn;
		}

		// Token: 0x0603EEAC RID: 257708 RVA: 0x01020917 File Offset: 0x0101EB17
		public void SetIsCanShowSkipBtn(bool value)
		{
			this.IsCanShowSkipBtn = value;
		}

		// Token: 0x0603EEAD RID: 257709 RVA: 0x01020920 File Offset: 0x0101EB20
		public AutoPilotDefine.IEnableAutoPilot GetEnableAutoPilot()
		{
			return this.EnableAutoPilot;
		}

		// Token: 0x0603EEAE RID: 257710 RVA: 0x01020928 File Offset: 0x0101EB28
		private void OnUnTrackMark(ITrackData markItem)
		{
			if (this.TrackingMarkItem == null)
			{
				return;
			}
			if (!ModelBase<TrackModel>.Instance.IsTracking(this.TrackingMarkItem.TrackSource, this.TrackingMarkItem.MarkId))
			{
				this.SetTrackingMarkItem(null);
			}
		}

		// Token: 0x0603EEAF RID: 257711 RVA: 0x0102095C File Offset: 0x0101EB5C
		public unsafe void SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot value, AutoPilotDefine.EDisableAutoPilotReason? reason = null)
		{
			if (this.EnableAutoPilot.Value == value)
			{
				AutoPilotDefine.EDisableAutoPilotReason? disableReason = this.EnableAutoPilot.DisableReason;
				AutoPilotDefine.EDisableAutoPilotReason? edisableAutoPilotReason = reason;
				if (disableReason.GetValueOrDefault() == edisableAutoPilotReason.GetValueOrDefault() & disableReason != null == (edisableAutoPilotReason != null))
				{
					return;
				}
			}
			this.EnableAutoPilot.Value = value;
			this.EnableAutoPilot.DisableReason = reason;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AutoPilot;
			ELogAuthor author = ELogAuthor.CB;
			string message = "设置可巡航的状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("value", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<AutoPilotController>.Instance.RefreshHighLightExploreSkill();
			if (value == AutoPilotDefine.EEnableAutoPilot.Dest)
			{
				FunctionModel instance2 = ModelBase<FunctionModel>.Instance;
				if (instance2 != null && instance2.IsOpen(EFunctionType.MotorDevelop))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(AutoPilotDefine.EAutoPilotTextId.TextCanAutoPilot, Array.Empty<object>());
				}
			}
		}

		// Token: 0x0603EEB0 RID: 257712 RVA: 0x01020A5C File Offset: 0x0101EC5C
		public bool CheckCommonConditions()
		{
			if (this.IsInAutoPilotInner)
			{
				this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.InAutoPilot));
				return false;
			}
			CharacterActorComponent actorComp = this.ActorComp;
			int? num = (actorComp != null) ? new int?(actorComp.CreatureData.GetRoleId()) : null;
			bool flag = (num ?? 0) == 0;
			if (flag)
			{
				this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.NotValidRole));
				return false;
			}
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num.Value, true);
			if (((roleDataById != null) ? new bool?(roleDataById.IsTrialRole()) : null).GetValueOrDefault())
			{
				this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.NotValidRole));
				return false;
			}
			return true;
		}

		// Token: 0x0603EEB1 RID: 257713 RVA: 0x01020B18 File Offset: 0x0101ED18
		public void CheckCircleAutoPilotConditions()
		{
			if (!this.CheckCommonConditions())
			{
				return;
			}
			AutoPilotDefine.IAutoPilotCircles autoPilotCircles;
			this.MapIdToCirclePathMap.TryGetValue(ModelBase<MapModel>.Instance.CurrentWorldMapConfigId, out autoPilotCircles);
			if (autoPilotCircles == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.AutoPilot, ELogAuthor.CB, "当前没有环路数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.NoCirclePath));
				return;
			}
			Entity vehicleEntity = this.VehicleEntity;
			MotorcycleRoadwayComponent motorcycleRoadwayComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<MotorcycleRoadwayComponent>() : null;
			if (!((motorcycleRoadwayComponent != null) ? new bool?(motorcycleRoadwayComponent.GetIsOnNearestRoadway()) : null).GetValueOrDefault())
			{
				this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.NotNearRoad));
				return;
			}
			NearestRoadway nearestRoadway = (motorcycleRoadwayComponent != null) ? motorcycleRoadwayComponent.GetNearestRoadway() : null;
			UKuroRoadway roadway = (nearestRoadway != null) ? nearestRoadway.Roadway : null;
			if (roadway == null)
			{
				this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.NoCirclePath));
				return;
			}
			Predicate<int> <>9__0;
			foreach (int num in autoPilotCircles.CircleIds)
			{
				AutoPilotCircles? autoPilotCircles2;
				int[] array = (ConfigAutoPilotCirclesById.GetConfig(num, true) != null) ? autoPilotCircles2.GetValueOrDefault().WaySplines() : null;
				if (array != null)
				{
					int[] array2 = array;
					Predicate<int> match;
					if ((match = <>9__0) == null)
					{
						match = (<>9__0 = ((int id) => id == roadway.Id));
					}
					if (Array.Exists<int>(array2, match))
					{
						this.RefreshCirclePath(num, true);
						this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Loop, null);
						return;
					}
				}
			}
			if (this.CheckCircleInIntersection(roadway.Id, autoPilotCircles.CircleIds))
			{
				this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Loop, null);
				return;
			}
			if (this.CheckCanReachCircle(autoPilotCircles.CircleIds))
			{
				this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Loop, null);
				return;
			}
			this.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.NoCirclePath));
		}

		// Token: 0x0603EEB2 RID: 257714 RVA: 0x01020D08 File Offset: 0x0101EF08
		private bool CheckCircleInIntersection(int roadWayId, List<int> circleIds)
		{
			UKuroTransportNetworkSubsystem transportSystem = ControllerBase<TransportNetworkController>.Instance.GetTransportSystem();
			int intersectionId = transportSystem.GetIntersectionId(roadWayId);
			if (intersectionId == 0)
			{
				return false;
			}
			TArray<int> tarray = new TArray<int>();
			transportSystem.GetRoadwaysAtSameIntersection(intersectionId, ref tarray);
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				UKuroRoadway roadWay = transportSystem.GetRoadWay(tarray.Get(i));
				if (roadWay != null)
				{
					Predicate<int> <>9__0;
					foreach (int num2 in circleIds)
					{
						AutoPilotCircles? autoPilotCircles;
						int[] array = (ConfigAutoPilotCirclesById.GetConfig(num2, true) != null) ? autoPilotCircles.GetValueOrDefault().WaySplines() : null;
						if (array != null)
						{
							CharacterActorComponent actorComp = this.ActorComp;
							int[] array2 = array;
							Predicate<int> match;
							if ((match = <>9__0) == null)
							{
								match = (<>9__0 = ((int id) => id == roadWay.Id));
							}
							if (Array.Exists<int>(array2, match) && actorComp != null && AutoPilotUtil.IsNearRoadWay(roadWay, actorComp.ActorLocationProxy))
							{
								this.RefreshCirclePath(num2, true);
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0603EEB3 RID: 257715 RVA: 0x01020E50 File Offset: 0x0101F050
		private bool CheckCanReachCircle(List<int> circleIds)
		{
			foreach (int num in circleIds)
			{
				AutoPilotCircles? autoPilotCircles;
				int[] array = (ConfigAutoPilotCirclesById.GetConfig(num, true) != null) ? autoPilotCircles.GetValueOrDefault().WaySplines() : null;
				if (array != null)
				{
					CharacterActorComponent actorComp = this.ActorComp;
					if (actorComp != null && this.CanReachCirclePath(actorComp.ActorLocationProxy, array))
					{
						this.RefreshCirclePath(num, false);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603EEB4 RID: 257716 RVA: 0x01020EEC File Offset: 0x0101F0EC
		private bool CanReachCirclePath(global::Vector actorLocation, int[] circlePath)
		{
			UKuroRoadway roadWay = ControllerBase<TransportNetworkController>.Instance.GetTransportSystem().GetRoadWay(circlePath[0]);
			if (roadWay == null)
			{
				return false;
			}
			USplineComponent roadSpline = roadWay.RoadSpline;
			FVectorDouble? fvectorDouble = (roadSpline != null) ? new FVectorDouble?(roadSpline.D_GetLocationAtSplinePoint(1, ESplineCoordinateSpace.World)) : null;
			if (fvectorDouble == null)
			{
				return false;
			}
			Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(fvectorDouble);
			ITransportFindPathResult transportFindPathResult = ControllerBase<TransportNetworkController>.Instance.FindPath(actorLocation, Singleton<MathUtils>.Instance.CommonTempVector, true, false, this.IsDebugMode);
			if (transportFindPathResult == null)
			{
				return false;
			}
			int num = transportFindPathResult.Roadways.Num();
			for (int i = 0; i < num; i++)
			{
				UKuroRoadway roadway = transportFindPathResult.Roadways.Get(i);
				bool isDebugMode = this.IsDebugMode;
				if (Array.Exists<int>(circlePath, (int id) => id == roadway.Id))
				{
					this.EnterCircleRoadId = roadway.Id;
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603EEB5 RID: 257717 RVA: 0x01020FDF File Offset: 0x0101F1DF
		private void OnMovieMotorRideSharingModeChangeResponse(bool enable, bool success)
		{
			if (!enable)
			{
				CustomPromise<bool> exitMovieModeWithRideShareQuitPromise = this.ExitMovieModeWithRideShareQuitPromise;
				if (exitMovieModeWithRideShareQuitPromise == null)
				{
					return;
				}
				exitMovieModeWithRideShareQuitPromise.SetResult(success);
				return;
			}
			else
			{
				CustomPromise<bool> enterRideSharePromise = this.EnterRideSharePromise;
				if (enterRideSharePromise == null)
				{
					return;
				}
				enterRideSharePromise.SetResult(success);
				return;
			}
		}

		// Token: 0x0603EEB6 RID: 257718 RVA: 0x01021007 File Offset: 0x0101F207
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<ITrackData>(EEventName.UnTrackMark, new Action<ITrackData>(this.OnUnTrackMark));
			Singleton<EventSystem>.Instance.Remove<bool, bool>(EEventName.OnMovieMotorRideSharingModeChangeResponse, new Action<bool, bool>(this.OnMovieMotorRideSharingModeChangeResponse));
		}

		// Token: 0x0603EEB7 RID: 257719 RVA: 0x01021041 File Offset: 0x0101F241
		protected override bool OnClear()
		{
			this.ClearData();
			this.MapIdToCirclePathMap.Clear();
			this.RemoveEvents();
			this.EnterRideSharePromise = null;
			this.ExitMovieModeWithRideShareQuitPromise = null;
			this.MovieModeCameraRowNameArray.Clear();
			return true;
		}

		// Token: 0x040234CE RID: 144590
		private bool IsInAutoPilotInner;

		// Token: 0x040234CF RID: 144591
		private bool IsInMovieModeInner;

		// Token: 0x040234D0 RID: 144592
		[Nullable(2)]
		private MarkItem TrackingMarkItem;

		// Token: 0x040234D1 RID: 144593
		[Nullable(2)]
		private AutoPilotFindPathResult FindPathResult;

		// Token: 0x040234D2 RID: 144594
		[Nullable(2)]
		private AutoPilotCirclePathResult CirclePathResult;

		// Token: 0x040234D3 RID: 144595
		private double PlayerToTargetDistanceThreshold;

		// Token: 0x040234D4 RID: 144596
		private double SplineDistanceThreshold;

		// Token: 0x040234D5 RID: 144597
		private int SkillHighLightTime = -1;

		// Token: 0x040234D6 RID: 144598
		private int EnterMovieModeTimeThreshold;

		// Token: 0x040234D7 RID: 144599
		private double EnterMovieModeDistanceThreshold;

		// Token: 0x040234D8 RID: 144600
		private int CanSkipTimeThreshold;

		// Token: 0x040234D9 RID: 144601
		private double CanSkipDistanceThreshold;

		// Token: 0x040234DA RID: 144602
		private double AutoPilotTime;

		// Token: 0x040234DB RID: 144603
		[Nullable(2)]
		private AutoPilotDefine.IAutoPilotTrackingData TrackingData;

		// Token: 0x040234DC RID: 144604
		private bool IsCanShowSkipBtn;

		// Token: 0x040234DD RID: 144605
		public bool IsDebugMode;

		// Token: 0x040234DE RID: 144606
		public bool IsSkipConfirmBoxShow = true;

		// Token: 0x040234DF RID: 144607
		public readonly Dictionary<int, AutoPilotDefine.IAutoPilotCircles> MapIdToCirclePathMap = new Dictionary<int, AutoPilotDefine.IAutoPilotCircles>();

		// Token: 0x040234E0 RID: 144608
		public int EnterCircleRoadId;

		// Token: 0x040234E1 RID: 144609
		private readonly AutoPilotDefine.IEnableAutoPilot EnableAutoPilot = new EnableAutoPilot
		{
			Value = AutoPilotDefine.EEnableAutoPilot.Disable
		};

		// Token: 0x040234E2 RID: 144610
		public float RideShareBtnProgress;

		// Token: 0x040234E3 RID: 144611
		public bool HideQuickTransferConfirmBox;

		// Token: 0x040234E4 RID: 144612
		public bool IsAllowExitByMove;

		// Token: 0x040234E5 RID: 144613
		public List<int> DebugRoadWayIds = new List<int>();

		// Token: 0x040234E6 RID: 144614
		public int DebugCircleId;

		// Token: 0x040234E7 RID: 144615
		public global::Vector LastActorLocation = global::Vector.Create();

		// Token: 0x040234E8 RID: 144616
		[Nullable(2)]
		public MotorcycleSplineMoveComponent SplineMoveComp;

		// Token: 0x040234E9 RID: 144617
		public bool IsSummonWaitingEnterVehicle;

		// Token: 0x040234EA RID: 144618
		private AutoPilotDefine.EAutoPilotState AutoPilotState;

		// Token: 0x040234EB RID: 144619
		[Nullable(2)]
		public Entity VehicleEntity;

		// Token: 0x040234EC RID: 144620
		[Nullable(2)]
		public CustomPromise<bool> ExitMovieModeWithRideShareQuitPromise;

		// Token: 0x040234ED RID: 144621
		[Nullable(2)]
		public CustomPromise<bool> EnterRideSharePromise;

		// Token: 0x040234EE RID: 144622
		public double HighLightSampleDist;

		// Token: 0x040234EF RID: 144623
		public double AutoPilotRoadWayWidthOffset;

		// Token: 0x040234F0 RID: 144624
		public double AutoPilotExitHorizontalDistThreshold;

		// Token: 0x040234F1 RID: 144625
		public double AutoPilotExitVerticalDistThreshold;

		// Token: 0x040234F2 RID: 144626
		public List<string> MovieModeCameraRowNameArray = new List<string>();

		// Token: 0x040234F3 RID: 144627
		public double AutoPilotStuckSpeedThreshold;

		// Token: 0x040234F4 RID: 144628
		public double AutoPilotStuckTimeThreshold;

		// Token: 0x040234F5 RID: 144629
		public double AutoPilotStuckStepDistance;

		// Token: 0x040234F6 RID: 144630
		private int AutoPilotAreaIdInner;
	}
}
