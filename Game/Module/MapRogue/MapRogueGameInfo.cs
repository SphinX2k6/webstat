using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200590C RID: 22796
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueGameInfo
	{
		// Token: 0x170093FD RID: 37885
		// (get) Token: 0x06039D8E RID: 236942 RVA: 0x00EA4D16 File Offset: 0x00EA2F16
		public int TeamLv
		{
			get
			{
				return this.TeamLvInternal;
			}
		}

		// Token: 0x06039D8F RID: 236943 RVA: 0x00EA4D20 File Offset: 0x00EA2F20
		public void SetTeamLv(int lv, int? eventType = null)
		{
			int changeCount = lv - this.TeamLvInternal;
			this.TeamLvInternal = lv;
			MapRogueMainView view = this.View;
			if (view != null)
			{
				view.RefreshTeamLv();
			}
			MapRogueMainView view2 = this.View;
			if (view2 != null)
			{
				MapRogueMapModule mapModule = view2.MapModule;
				if (mapModule != null)
				{
					mapModule.RefreshAllEventLv();
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RogueResTeamLvChange, lv);
			if (eventType == null)
			{
				return;
			}
			foreach (int num in ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.GetShowLvChangeEventTypeArray())
			{
				int? num2 = eventType;
				if (num == num2.GetValueOrDefault() & num2 != null)
				{
					this.PushGetItemData(this.LvItemId, changeCount);
					return;
				}
			}
		}

		// Token: 0x170093FE RID: 37886
		// (get) Token: 0x06039D90 RID: 236944 RVA: 0x00EA4DD6 File Offset: 0x00EA2FD6
		public int TeamLvAnim
		{
			get
			{
				int teamLvAnimInterval = this.TeamLvAnimInterval;
				this.TeamLvAnimInterval = this.TeamLvInternal;
				return teamLvAnimInterval;
			}
		}

		// Token: 0x170093FF RID: 37887
		// (get) Token: 0x06039D91 RID: 236945 RVA: 0x00EA4DEA File Offset: 0x00EA2FEA
		// (set) Token: 0x06039D92 RID: 236946 RVA: 0x00EA4DF2 File Offset: 0x00EA2FF2
		public bool InBattle
		{
			get
			{
				return this.InBattleInternal;
			}
			set
			{
				this.InBattleInternal = value;
			}
		}

		// Token: 0x17009400 RID: 37888
		// (get) Token: 0x06039D93 RID: 236947 RVA: 0x00EA4DFB File Offset: 0x00EA2FFB
		// (set) Token: 0x06039D94 RID: 236948 RVA: 0x00EA4E03 File Offset: 0x00EA3003
		public int PlayerGridIndex
		{
			get
			{
				return this.PlayerGridIndexInternal;
			}
			set
			{
				this.PlayerGridIndexInternal = value;
				MapRogueMainView view = this.View;
				if (view != null)
				{
					MapRogueMapModule mapModule = view.MapModule;
					if (mapModule != null)
					{
						mapModule.SetRolePos(this.PlayerGridIndex);
					}
				}
				this.RefreshPerspectiveModeGrid(this.PlayerGridIndex);
			}
		}

		// Token: 0x17009401 RID: 37889
		// (get) Token: 0x06039D95 RID: 236949 RVA: 0x00EA4E3A File Offset: 0x00EA303A
		public int CenterIndex
		{
			get
			{
				return MapRogueDefine.GridLocationToIndex(this.Center.X, this.Center.Y, this.MapWidth);
			}
		}

		// Token: 0x06039D96 RID: 236950 RVA: 0x00EA4E5D File Offset: 0x00EA305D
		public MapRogueMapPoint GetGridPos(int gridId)
		{
			return MapRogueDefine.IndexToGridLocation(gridId, this.MapWidth);
		}

		// Token: 0x06039D97 RID: 236951 RVA: 0x00EA4E6B File Offset: 0x00EA306B
		public int GetGridIndex(int x, int y)
		{
			return MapRogueDefine.GridLocationToIndex(x, y, this.MapWidth);
		}

		// Token: 0x06039D98 RID: 236952 RVA: 0x00EA4E7C File Offset: 0x00EA307C
		public void Refresh(IGameInfoInitData gameInfo)
		{
			this.InstanceId = gameInfo.InstanceId;
			this.RandomSeed = gameInfo.RandomSeed;
			this.MapGrids = gameInfo.MapGrids;
			this.MapWidth = gameInfo.MapWidth;
			this.MapHeight = gameInfo.MapHeight;
			this.Center.X = (int)Math.Floor((double)this.MapWidth / 2.0);
			this.Center.Y = (int)Math.Floor((double)this.MapHeight / 2.0);
			this.PlayerGridIndexInternal = gameInfo.PlayerGridIndex;
			this.TeamLvInternal = gameInfo.TeamLv;
			this.TeamLvAnimInterval = gameInfo.TeamLv;
			this.InBattleInternal = gameInfo.InBattle;
			this.MoodRuleIdInternal = gameInfo.MoodRuleId;
			this.MoodMin = gameInfo.MoodMin;
			this.MoodMax = gameInfo.MoodMax;
			this.MoodInternal = gameInfo.InitMood;
			GridsConstructor gridConstructor = new GridsConstructor
			{
				Matrix = new List<IPathNode>(this.MapGrids),
				Width = this.MapWidth,
				Height = this.MapHeight
			};
			this.PathFinder = new GridPathFinder(gridConstructor, true, true, EHeuristicFunction.Manhattan);
			this.ActorPool = new MapRogueActorPool();
			this.IsEnd = false;
			this.ActivateTimer();
			this.ResetViewPromise();
			this.MapScale = (double)this.GetCacheMapScale();
		}

		// Token: 0x06039D99 RID: 236953 RVA: 0x00EA4FD4 File Offset: 0x00EA31D4
		private float GetCacheMapScale()
		{
			RogueResInstGrid? insGridConfigByInstId = ConfigBase<MapRogueConfig>.Instance.GetInsGridConfigByInstId(this.InstanceId);
			if (insGridConfigByInstId == null)
			{
				return 1f;
			}
			int num = insGridConfigByInstId.Value.MapInitScale / 1000;
			Dictionary<int, float> player = LocalStorage.GetPlayer<Dictionary<int, float>>(ELocalStoragePlayerKey.RogueResMapScale, null);
			if (player == null)
			{
				return (float)num;
			}
			float result;
			if (player.TryGetValue(this.InstanceId, out result))
			{
				return result;
			}
			return (float)num;
		}

		// Token: 0x06039D9A RID: 236954 RVA: 0x00EA5040 File Offset: 0x00EA3240
		private void SetCacheMapScale()
		{
			Dictionary<int, float> dictionary = LocalStorage.GetPlayer<Dictionary<int, float>>(ELocalStoragePlayerKey.RogueResMapScale, null) ?? new Dictionary<int, float>();
			dictionary[this.InstanceId] = (float)this.MapScale;
			LocalStorage.SetPlayer<Dictionary<int, float>>(ELocalStoragePlayerKey.RogueResMapScale, dictionary);
		}

		// Token: 0x06039D9B RID: 236955 RVA: 0x00EA5084 File Offset: 0x00EA3284
		public void Clear()
		{
			this.SetCacheMapScale();
			this.CurHoverIndex = -1;
			this.CurSelectedIndex = -1;
			this.MoodInternal = 0;
			this.MapGrids.Clear();
			this.Path.Clear();
			this.PathFinder = null;
			this.GetItemDataList.Clear();
			this.DeactivateTimer();
			if (this.ActorPool != null)
			{
				this.ActorPool.Clear();
				this.ActorPool = null;
			}
		}

		// Token: 0x06039D9C RID: 236956 RVA: 0x00EA50F4 File Offset: 0x00EA32F4
		[NullableContext(2)]
		public void BindView(MapRogueMainView view)
		{
			this.View = view;
			if (this.View != null)
			{
				this.RefreshPerspectiveModeGrid(this.PlayerGridIndex);
				return;
			}
			this.ResetViewPromise();
			this.SurroundingsGrids.Clear();
			this.HoverSurroundingsGrids.Clear();
		}

		// Token: 0x17009402 RID: 37890
		// (get) Token: 0x06039D9D RID: 236957 RVA: 0x00EA512E File Offset: 0x00EA332E
		public bool HasBindView
		{
			get
			{
				return this.View != null;
			}
		}

		// Token: 0x17009403 RID: 37891
		// (get) Token: 0x06039D9E RID: 236958 RVA: 0x00EA5139 File Offset: 0x00EA3339
		// (set) Token: 0x06039D9F RID: 236959 RVA: 0x00EA5144 File Offset: 0x00EA3344
		public EMapRogueGameStage GameStage
		{
			get
			{
				return this.GameStageInternal;
			}
			set
			{
				if (this.GameStage == value)
				{
					return;
				}
				EMapRogueGameStage gameStage = this.GameStage;
				this.GameStageInternal = value;
				switch (value)
				{
				case EMapRogueGameStage.Norm:
				{
					MapRogueMainView view = this.View;
					if (view != null)
					{
						MapRogueMapModule mapModule = view.MapModule;
						if (mapModule != null)
						{
							mapModule.ResetAllPath();
						}
					}
					MapRogueMainView view2 = this.View;
					if (view2 != null)
					{
						MapRogueMapModule mapModule2 = view2.MapModule;
						if (mapModule2 != null)
						{
							mapModule2.SetMapGridBgState(this.CurSelectedIndex, false, null);
						}
					}
					this.CurSelectedIndex = -1;
					this.CurHoverIndex = -1;
					this.ResetHoverPerspectiveModeGrid();
					this.SetInteractAvailable(EMapForbiddenTag.StageLock, true);
					break;
				}
				case EMapRogueGameStage.Wait:
					this.SetInteractAvailable(EMapForbiddenTag.StageLock, false);
					break;
				case EMapRogueGameStage.Move:
				{
					MapRogueMainView view3 = this.View;
					if (view3 != null)
					{
						MapRogueMapModule mapModule3 = view3.MapModule;
						if (mapModule3 != null)
						{
							mapModule3.RolePanel.SetRoleAnim(EMapRogueSpineAnim.Move, true);
						}
					}
					MapRogueMainView view4 = this.View;
					if (view4 != null)
					{
						MapRogueMapModule mapModule4 = view4.MapModule;
						if (mapModule4 != null)
						{
							mapModule4.RolePanel.SetRolePosItemVisible(false);
						}
					}
					break;
				}
				}
				MapRogueMainView view5 = this.View;
				if (view5 == null)
				{
					return;
				}
				view5.ChangeGameStagePerformance(gameStage, this.GameStageInternal);
			}
		}

		// Token: 0x17009404 RID: 37892
		// (get) Token: 0x06039DA0 RID: 236960 RVA: 0x00EA524E File Offset: 0x00EA344E
		public bool IsStageAvailable
		{
			get
			{
				return this.GameStage == EMapRogueGameStage.Norm;
			}
		}

		// Token: 0x06039DA1 RID: 236961 RVA: 0x00EA5259 File Offset: 0x00EA3459
		public void SetInteractAvailable(EMapForbiddenTag tag, bool bAvailable)
		{
			if (bAvailable)
			{
				this.MaskTagSet.Remove(tag);
			}
			else
			{
				this.MaskTagSet.Add(tag);
			}
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			view.SetInteractAvailable(this.MaskTagSet.Count == 0);
		}

		// Token: 0x17009405 RID: 37893
		// (get) Token: 0x06039DA2 RID: 236962 RVA: 0x00EA5298 File Offset: 0x00EA3498
		public bool CanInteract
		{
			get
			{
				return this.MaskTagSet.Count == 0;
			}
		}

		// Token: 0x06039DA3 RID: 236963 RVA: 0x00EA52A8 File Offset: 0x00EA34A8
		[NullableContext(2)]
		public void SetTipsItemProxy(bool bVisible, string textId = null)
		{
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			view.SetTipsItem(bVisible, textId);
		}

		// Token: 0x06039DA4 RID: 236964 RVA: 0x00EA52BC File Offset: 0x00EA34BC
		private void ActivateTimer()
		{
			this.DeactivateTimer();
			this.ActorPoolTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				MapRogueActorPool actorPool = this.ActorPool;
				if (actorPool == null)
				{
					return;
				}
				actorPool.Tick(100f);
			}, 100f, 1f, null, null, true);
		}

		// Token: 0x06039DA5 RID: 236965 RVA: 0x00EA52ED File Offset: 0x00EA34ED
		private void DeactivateTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.ActorPoolTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.ActorPoolTimer);
				this.ActorPoolTimer = null;
			}
		}

		// Token: 0x06039DA6 RID: 236966 RVA: 0x00EA531C File Offset: 0x00EA351C
		public void RefreshGrid(int index, bool exploreStateRefresh)
		{
			MapGridData mapGridData = this.MapGrids[index];
			GridPathFinder pathFinder = this.PathFinder;
			if (pathFinder != null)
			{
				pathFinder.UpdateGrid(mapGridData);
			}
			MapRogueMainView view = this.View;
			if (view != null)
			{
				MapRogueMapModule mapModule = view.MapModule;
				if (mapModule != null)
				{
					mapModule.RefreshMapGrid(mapGridData);
				}
			}
			if (!exploreStateRefresh)
			{
				return;
			}
			MapRogueMainView view2 = this.View;
			if (view2 != null)
			{
				view2.RefreshProgress();
			}
			if (!mapGridData.IsExplore)
			{
				return;
			}
			RogueResGlobalParam value = ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value;
			int[] array = value.GetGridTakeTipsEventTypeArray() ?? Array.Empty<int>();
			int i;
			for (i = 0; i < array.Length; i++)
			{
				if (array[i] == mapGridData.EventType)
				{
					ControllerBase<MapRogueController>.Instance.OpenRogueTipsView(ERogueTipsType.Normal, "RogueRes_Event_Rewards_1", null, null);
					break;
				}
			}
			array = (value.GetGridTakeSpineEventTypeArray() ?? Array.Empty<int>());
			i = 0;
			while (i < array.Length)
			{
				if (array[i] == mapGridData.EventType)
				{
					MapRogueMainView view3 = this.View;
					if (view3 == null)
					{
						return;
					}
					MapRogueMapModule mapModule2 = view3.MapModule;
					if (mapModule2 == null)
					{
						return;
					}
					mapModule2.RolePanel.SetRoleAnim(EMapRogueSpineAnim.Cheer, false);
					return;
				}
				else
				{
					i++;
				}
			}
		}

		// Token: 0x06039DA7 RID: 236967 RVA: 0x00EA542C File Offset: 0x00EA362C
		public void SetGridData(int gridIndex, RogueResGridData gridInfo)
		{
			MapGridData mapGridData = new MapGridData();
			mapGridData.RefreshByServer(gridInfo);
			mapGridData.GridIndex = gridIndex;
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			MapRogueMapModule mapModule = view.MapModule;
			if (mapModule == null)
			{
				return;
			}
			mapModule.RefreshMapGrid(mapGridData);
		}

		// Token: 0x06039DA8 RID: 236968 RVA: 0x00EA5468 File Offset: 0x00EA3668
		public void SetGridVisionProxy(int index, bool bHasVision)
		{
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			MapRogueMapModule mapModule = view.MapModule;
			if (mapModule == null)
			{
				return;
			}
			mapModule.SetMapGridBgVision(index, bHasVision);
		}

		// Token: 0x06039DA9 RID: 236969 RVA: 0x00EA5486 File Offset: 0x00EA3686
		public void SetMapGridBgStateProxy(int gridIndex, bool bSelectOn, bool? bFireEvent = null)
		{
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			MapRogueMapModule mapModule = view.MapModule;
			if (mapModule == null)
			{
				return;
			}
			mapModule.SetMapGridBgState(gridIndex, bSelectOn, bFireEvent);
		}

		// Token: 0x06039DAA RID: 236970 RVA: 0x00EA54A5 File Offset: 0x00EA36A5
		public bool CanGridCheck(int gridIndex)
		{
			return this.MapGrids[gridIndex].Walkable && gridIndex != this.PlayerGridIndex;
		}

		// Token: 0x06039DAB RID: 236971 RVA: 0x00EA54C8 File Offset: 0x00EA36C8
		private bool IsOnTheGrid(MapRogueMapPoint position)
		{
			return position.X >= 0 && position.X < this.MapWidth && position.Y >= 0 && position.Y < this.MapHeight;
		}

		// Token: 0x06039DAC RID: 236972 RVA: 0x00EA54FC File Offset: 0x00EA36FC
		private HashSet<int> GetPerspectiveModeGridIdList(int centerGridId)
		{
			HashSet<int> hashSet = new HashSet<int>();
			MapRogueMapPoint gridPos = this.GetGridPos(centerGridId);
			MapRogueMapPoint mapRogueMapPoint = new MapRogueMapPoint
			{
				X = gridPos.X - 1,
				Y = gridPos.Y
			};
			MapRogueMapPoint mapRogueMapPoint2 = new MapRogueMapPoint
			{
				X = gridPos.X - 1,
				Y = gridPos.Y + 1
			};
			MapRogueMapPoint mapRogueMapPoint3 = new MapRogueMapPoint
			{
				X = gridPos.X,
				Y = gridPos.Y + 1
			};
			foreach (MapRogueMapPoint mapRogueMapPoint4 in new MapRogueMapPoint[]
			{
				mapRogueMapPoint,
				mapRogueMapPoint2,
				mapRogueMapPoint3
			})
			{
				if (this.IsOnTheGrid(mapRogueMapPoint4))
				{
					hashSet.Add(this.GetGridIndex(mapRogueMapPoint4.X, mapRogueMapPoint4.Y));
				}
			}
			return hashSet;
		}

		// Token: 0x06039DAD RID: 236973 RVA: 0x00EA55D0 File Offset: 0x00EA37D0
		private void ResetHoverPerspectiveModeGrid()
		{
			foreach (int gridIndex in this.HoverSurroundingsGrids)
			{
				MapRogueMainView view = this.View;
				if (view != null)
				{
					MapRogueMapModule mapModule = view.MapModule;
					if (mapModule != null)
					{
						mapModule.SetPerspectiveMode(gridIndex, false);
					}
				}
			}
			this.HoverSurroundingsGrids.Clear();
		}

		// Token: 0x06039DAE RID: 236974 RVA: 0x00EA5648 File Offset: 0x00EA3848
		private void RefreshHoverPerspectiveModeGrid(int centerGridId)
		{
			HashSet<int> perspectiveModeGridIdList = this.GetPerspectiveModeGridIdList(centerGridId);
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int item in perspectiveModeGridIdList)
			{
				if (this.HoverSurroundingsGrids.Contains(item))
				{
					hashSet.Add(item);
				}
			}
			foreach (int num in this.HoverSurroundingsGrids)
			{
				if (!hashSet.Contains(num))
				{
					MapRogueMainView view = this.View;
					if (view != null)
					{
						MapRogueMapModule mapModule = view.MapModule;
						if (mapModule != null)
						{
							mapModule.SetPerspectiveMode(num, false);
						}
					}
				}
			}
			foreach (int num2 in perspectiveModeGridIdList)
			{
				if (!hashSet.Contains(num2))
				{
					MapRogueMainView view2 = this.View;
					if (view2 != null)
					{
						MapRogueMapModule mapModule2 = view2.MapModule;
						if (mapModule2 != null)
						{
							mapModule2.SetPerspectiveMode(num2, true);
						}
					}
				}
			}
			this.HoverSurroundingsGrids = perspectiveModeGridIdList;
		}

		// Token: 0x06039DAF RID: 236975 RVA: 0x00EA5780 File Offset: 0x00EA3980
		private void RefreshPerspectiveModeGrid(int centerGridId)
		{
			HashSet<int> perspectiveModeGridIdList = this.GetPerspectiveModeGridIdList(centerGridId);
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int item in perspectiveModeGridIdList)
			{
				if (this.SurroundingsGrids.Contains(item))
				{
					hashSet.Add(item);
				}
			}
			foreach (int num in this.SurroundingsGrids)
			{
				if (!hashSet.Contains(num))
				{
					MapRogueMainView view = this.View;
					if (view != null)
					{
						MapRogueMapModule mapModule = view.MapModule;
						if (mapModule != null)
						{
							mapModule.SetPerspectiveMode(num, false);
						}
					}
				}
			}
			foreach (int num2 in perspectiveModeGridIdList)
			{
				if (!hashSet.Contains(num2))
				{
					MapRogueMainView view2 = this.View;
					if (view2 != null)
					{
						MapRogueMapModule mapModule2 = view2.MapModule;
						if (mapModule2 != null)
						{
							mapModule2.SetPerspectiveMode(num2, true);
						}
					}
				}
			}
			this.SurroundingsGrids = perspectiveModeGridIdList;
		}

		// Token: 0x06039DB0 RID: 236976 RVA: 0x00EA58B8 File Offset: 0x00EA3AB8
		public bool IsPosInGridRange(int screenPosX, int screenPosY, int gridIndex)
		{
			MapRogueMainView view = this.View;
			IGridRangeInfo gridRangeInfo;
			if (view == null)
			{
				gridRangeInfo = null;
			}
			else
			{
				MapRogueMapModule mapModule = view.MapModule;
				gridRangeInfo = ((mapModule != null) ? mapModule.GetGridRangeInfo(gridIndex) : null);
			}
			IGridRangeInfo gridRangeInfo2 = gridRangeInfo;
			return gridRangeInfo2 != null && MapRogueDefine.InAxisAlignedDiamond(screenPosX, screenPosY, gridRangeInfo2);
		}

		// Token: 0x06039DB1 RID: 236977 RVA: 0x00EA58F2 File Offset: 0x00EA3AF2
		[NullableContext(2)]
		public void FocusOnGrid(int gridId, bool needTween = true, Action callback = null, float? focusTweenTime = null)
		{
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			MapRogueMapModule mapModule = view.MapModule;
			if (mapModule == null)
			{
				return;
			}
			mapModule.FocusOnGrid(gridId, needTween, callback, focusTweenTime);
		}

		// Token: 0x06039DB2 RID: 236978 RVA: 0x00EA5914 File Offset: 0x00EA3B14
		public bool IsOverEventRecommendLv(int gridIndex)
		{
			if (!this.MapGrids[gridIndex].HasEvent(new bool?(true)))
			{
				return true;
			}
			int lv = this.MapGrids[gridIndex].Lv;
			int toleranceLv = this.MapGrids[gridIndex].ToleranceLv;
			return this.TeamLv >= lv - toleranceLv;
		}

		// Token: 0x06039DB3 RID: 236979 RVA: 0x00EA5970 File Offset: 0x00EA3B70
		public bool IsGridCanSkipBattle(int gridIndex)
		{
			MapGridData mapGridData = this.MapGrids[gridIndex];
			if (!mapGridData.HasEvent(new bool?(true)))
			{
				return false;
			}
			if (!mapGridData.CanSkipBattle)
			{
				return false;
			}
			int lv = this.MapGrids[gridIndex].Lv;
			int skipBattleLv = this.MapGrids[gridIndex].SkipBattleLv;
			return this.TeamLv >= lv + skipBattleLv;
		}

		// Token: 0x17009406 RID: 37894
		// (get) Token: 0x06039DB4 RID: 236980 RVA: 0x00EA59D8 File Offset: 0x00EA3BD8
		public EMovePathType MoveState
		{
			get
			{
				if (this.CurSelectedIndex < 0)
				{
					return EMovePathType.UnSelect;
				}
				if (!this.MapGrids[this.CurSelectedIndex].Walkable)
				{
					return EMovePathType.CannotWalk;
				}
				if (!this.MapGrids[this.CurSelectedIndex].IsUnlock())
				{
					return EMovePathType.EventLock;
				}
				if (this.Path.Count == 0)
				{
					return EMovePathType.CannotAchieve;
				}
				if (this.InterruptPathCheck(this.Path))
				{
					return EMovePathType.EventInterrupt;
				}
				return EMovePathType.CanMove;
			}
		}

		// Token: 0x06039DB5 RID: 236981 RVA: 0x00EA5A44 File Offset: 0x00EA3C44
		private bool InterruptPathCheck(List<int> path)
		{
			for (int i = 0; i < path.Count - 1; i++)
			{
				if (this.MapGrids[path[i]].NeedTriggerEvent())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06039DB6 RID: 236982 RVA: 0x00EA5A80 File Offset: 0x00EA3C80
		public void HoverOnTarget(int targetGridId, bool updatePath = true)
		{
			if (!this.HasBindView)
			{
				return;
			}
			if (!this.CanGridCheck(targetGridId))
			{
				this.CurHoverIndex = -1;
				MapRogueMainView view = this.View;
				if (view != null)
				{
					MapRogueMapModule mapModule = view.MapModule;
					if (mapModule != null)
					{
						mapModule.SetInteractState(false, false, null);
					}
				}
				this.ResetAllPath();
				this.ResetHoverPerspectiveModeGrid();
				return;
			}
			if (updatePath)
			{
				this.CurHoverIndex = targetGridId;
				this.RefreshHoverPerspectiveModeGrid(this.CurHoverIndex);
			}
			this.GeneratePathToTarget(targetGridId, updatePath, null);
		}

		// Token: 0x06039DB7 RID: 236983 RVA: 0x00EA5B01 File Offset: 0x00EA3D01
		public void UnHoverOnTarget(int targetGridId)
		{
			if (!this.IsStageAvailable)
			{
				return;
			}
			if (this.CurHoverIndex != targetGridId)
			{
				return;
			}
			this.CurHoverIndex = -1;
		}

		// Token: 0x06039DB8 RID: 236984 RVA: 0x00EA5B20 File Offset: 0x00EA3D20
		public void BlankPlaneEnter()
		{
			MapRogueMainView view = this.View;
			if (view != null)
			{
				MapRogueMapModule mapModule = view.MapModule;
				if (mapModule != null)
				{
					mapModule.SetInteractState(false, false, null);
				}
			}
			this.CurHoverIndex = -1;
			this.ResetAllPath();
			this.ResetHoverPerspectiveModeGrid();
		}

		// Token: 0x06039DB9 RID: 236985 RVA: 0x00EA5B68 File Offset: 0x00EA3D68
		private void GeneratePathToTarget(int targetGridId, bool updatePath, int? startGridId = null)
		{
			int gridId = startGridId ?? this.PlayerGridIndex;
			if (!this.MapGrids[targetGridId].IsUnlock())
			{
				this.ResetAllPath();
				MapRogueMainView view = this.View;
				if (view != null)
				{
					MapRogueMapModule mapModule = view.MapModule;
					if (mapModule != null)
					{
						mapModule.SetInteractState(false, true, new int?(targetGridId));
					}
				}
				MapRogueMainView view2 = this.View;
				if (view2 == null)
				{
					return;
				}
				MapRogueMapModule mapModule2 = view2.MapModule;
				if (mapModule2 == null)
				{
					return;
				}
				mapModule2.SetMapGridMoveEnable(targetGridId, false);
				return;
			}
			else
			{
				MapRogueMapPoint gridPos = this.GetGridPos(gridId);
				MapRogueMapPoint gridPos2 = this.GetGridPos(targetGridId);
				List<int> list = this.PathFinder.FindPath(gridPos, gridPos2);
				if (list.Count == 0)
				{
					this.ResetAllPath();
					MapRogueMainView view3 = this.View;
					if (view3 != null)
					{
						MapRogueMapModule mapModule3 = view3.MapModule;
						if (mapModule3 != null)
						{
							mapModule3.SetInteractState(false, true, new int?(targetGridId));
						}
					}
					MapRogueMainView view4 = this.View;
					if (view4 == null)
					{
						return;
					}
					MapRogueMapModule mapModule4 = view4.MapModule;
					if (mapModule4 == null)
					{
						return;
					}
					mapModule4.SetMapGridMoveEnable(targetGridId, false);
					return;
				}
				else if (this.InterruptPathCheck(list))
				{
					this.ResetAllPath();
					this.Path = list;
					MapRogueMainView view5 = this.View;
					if (view5 != null)
					{
						MapRogueMapModule mapModule5 = view5.MapModule;
						if (mapModule5 != null)
						{
							mapModule5.SetInteractState(false, true, new int?(targetGridId));
						}
					}
					MapRogueMainView view6 = this.View;
					if (view6 == null)
					{
						return;
					}
					MapRogueMapModule mapModule6 = view6.MapModule;
					if (mapModule6 == null)
					{
						return;
					}
					mapModule6.SetMapGridMoveEnable(targetGridId, false);
					return;
				}
				else
				{
					MapRogueMainView view7 = this.View;
					if (view7 != null)
					{
						MapRogueMapModule mapModule7 = view7.MapModule;
						if (mapModule7 != null)
						{
							mapModule7.SetInteractState(true, true, new int?(targetGridId));
						}
					}
					MapRogueMainView view8 = this.View;
					if (view8 != null)
					{
						MapRogueMapModule mapModule8 = view8.MapModule;
						if (mapModule8 != null)
						{
							mapModule8.SetMapGridMoveEnable(targetGridId, true);
						}
					}
					if (!updatePath)
					{
						return;
					}
					this.CurSelectedIndex = list[list.Count - 1];
					MapRogueMainView view9 = this.View;
					if (view9 != null)
					{
						MapRogueMapModule mapModule9 = view9.MapModule;
						if (mapModule9 != null)
						{
							mapModule9.CreateAllMapGridPath(this.Path, list);
						}
					}
					this.Path = list;
					return;
				}
			}
		}

		// Token: 0x06039DBA RID: 236986 RVA: 0x00EA5D34 File Offset: 0x00EA3F34
		public UniTask CreateGridPathAsync(List<int> path)
		{
			MapRogueGameInfo.<CreateGridPathAsync>d__85 <CreateGridPathAsync>d__;
			<CreateGridPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateGridPathAsync>d__.<>4__this = this;
			<CreateGridPathAsync>d__.path = path;
			<CreateGridPathAsync>d__.<>1__state = -1;
			<CreateGridPathAsync>d__.<>t__builder.Start<MapRogueGameInfo.<CreateGridPathAsync>d__85>(ref <CreateGridPathAsync>d__);
			return <CreateGridPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039DBB RID: 236987 RVA: 0x00EA5D80 File Offset: 0x00EA3F80
		public void ResetAllPath()
		{
			foreach (int gridId in this.Path)
			{
				this.ResetPath(gridId);
			}
			this.Path.Clear();
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			MapRogueMoodBar moodBar = view.MoodBar;
			if (moodBar == null)
			{
				return;
			}
			moodBar.ClosePreviewValue();
		}

		// Token: 0x06039DBC RID: 236988 RVA: 0x00EA5DF8 File Offset: 0x00EA3FF8
		private void ResetPath(int gridId)
		{
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			MapRogueMapModule mapModule = view.MapModule;
			if (mapModule == null)
			{
				return;
			}
			mapModule.ResetPath(gridId);
		}

		// Token: 0x06039DBD RID: 236989 RVA: 0x00EA5E18 File Offset: 0x00EA4018
		public void SetMood(int mood, int? eventType = null, int? moodMin = null, int? moodMax = null, bool ignoreEvent = false)
		{
			int changeCount = mood - this.MoodInternal;
			this.MoodInternal = mood;
			if (moodMin != null && moodMax != null)
			{
				this.MoodMin = moodMin.Value;
				this.MoodMax = moodMax.Value;
				MapRogueMainView view = this.View;
				if (view != null)
				{
					MapRogueMoodBar moodBar = view.MoodBar;
					if (moodBar != null)
					{
						moodBar.SetLimit(this.MoodMin, this.MoodMax);
					}
				}
			}
			MapRogueMainView view2 = this.View;
			if (view2 != null)
			{
				MapRogueMoodBar moodBar2 = view2.MoodBar;
				if (moodBar2 != null)
				{
					moodBar2.SetCurrentValue(mood);
				}
			}
			if (!ignoreEvent)
			{
				Singleton<EventSystem>.Instance.Emit<int, int, int>(EEventName.RogueResMoodChange, mood, this.MoodMin, this.MoodMax);
			}
			if (eventType == null)
			{
				return;
			}
			foreach (int num in ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.GetShowMoodChangeEventTypeArray())
			{
				int? num2 = eventType;
				if (num == num2.GetValueOrDefault() & num2 != null)
				{
					this.PushGetItemData(this.MoodItemId, changeCount);
					return;
				}
			}
		}

		// Token: 0x17009407 RID: 37895
		// (get) Token: 0x06039DBE RID: 236990 RVA: 0x00EA5F26 File Offset: 0x00EA4126
		public int Mood
		{
			get
			{
				return this.MoodInternal;
			}
		}

		// Token: 0x17009408 RID: 37896
		// (get) Token: 0x06039DBF RID: 236991 RVA: 0x00EA5F2E File Offset: 0x00EA412E
		// (set) Token: 0x06039DC0 RID: 236992 RVA: 0x00EA5F38 File Offset: 0x00EA4138
		public int MoodRuleId
		{
			get
			{
				return this.MoodRuleIdInternal;
			}
			set
			{
				if (this.MoodRuleIdInternal == value)
				{
					return;
				}
				this.MoodRuleIdInternal = value;
				RogueResMoodRule? moodRuleById = ConfigBase<MapRogueConfig>.Instance.GetMoodRuleById(value);
				if (moodRuleById == null)
				{
					return;
				}
				MapRogueMainView view = this.View;
				if (view != null)
				{
					MapRogueMoodBar moodBar = view.MoodBar;
					if (moodBar != null)
					{
						moodBar.SetMoodRuleId(value);
					}
				}
				MapRogueMainView view2 = this.View;
				if (view2 != null)
				{
					view2.RefreshMoodMusicState();
				}
				int type = moodRuleById.Value.Type;
				if (type == 1)
				{
					ControllerBase<MapRogueController>.Instance.OpenRogueTipsView(ERogueTipsType.Normal, moodRuleById.Value.FloatTips, null, null);
					return;
				}
				if (type != 2)
				{
					return;
				}
				ControllerBase<MapRogueController>.Instance.OpenRogueTipsView(ERogueTipsType.Red, moodRuleById.Value.FloatTips, null, null);
			}
		}

		// Token: 0x06039DC1 RID: 236993 RVA: 0x00EA5FEC File Offset: 0x00EA41EC
		private void ResetViewPromise()
		{
			if (this.ViewOpenPromise != null)
			{
				this.ViewOpenPromise.SetResult();
			}
			this.ViewOpenPromise = new CustomPromise();
			if (this.ViewLoadPromise != null)
			{
				this.ViewLoadPromise.SetResult();
			}
			this.ViewLoadPromise = new CustomPromise();
			if (this.ViewShowPromise != null)
			{
				this.ViewShowPromise.SetResult();
			}
			this.ViewShowPromise = new CustomPromise();
		}

		// Token: 0x06039DC2 RID: 236994 RVA: 0x00EA6054 File Offset: 0x00EA4254
		public void SetMoveTimeGap(int pathLength)
		{
			float value = ConfigCommonParamById.GetFloatConfig("MapRogueRoleMoveMaxDuration").Value;
			float value2 = ConfigCommonParamById.GetFloatConfig("MapRogueRoleMoveSpeed").Value;
			if ((float)pathLength * value2 > value)
			{
				this.MoveTimeGap = (float)((int)Math.Floor((double)(value / (float)pathLength)));
				return;
			}
			this.MoveTimeGap = value2;
		}

		// Token: 0x06039DC3 RID: 236995 RVA: 0x00EA60A8 File Offset: 0x00EA42A8
		public void OnTick(float delta)
		{
			if (this.GameStage != EMapRogueGameStage.Move)
			{
				return;
			}
			this.TempPeriodTime += delta;
			if (this.TempPeriodTime < this.MoveTimeGap)
			{
				float progress = this.TempPeriodTime / this.MoveTimeGap;
				MapRogueMainView view = this.View;
				if (view == null)
				{
					return;
				}
				MapRogueMapModule mapModule = view.MapModule;
				if (mapModule == null)
				{
					return;
				}
				mapModule.SetRolePosByGrid(progress, this.LastMoveGridIndex, this.CurMoveGridIndex);
				return;
			}
			else
			{
				MapRogueMainView view2 = this.View;
				if (view2 != null)
				{
					MapRogueMapModule mapModule2 = view2.MapModule;
					if (mapModule2 != null)
					{
						mapModule2.SetRolePosByGrid(1f, this.LastMoveGridIndex, this.CurMoveGridIndex);
					}
				}
				MapRogueOp curOp = this.CurOp;
				if (curOp == null)
				{
					return;
				}
				curOp.Execute(this, null);
				return;
			}
		}

		// Token: 0x06039DC4 RID: 236996 RVA: 0x00EA6150 File Offset: 0x00EA4350
		public void OnCheck(int gridIndex)
		{
			if (!this.IsStageAvailable)
			{
				return;
			}
			this.CurSelectedIndex = gridIndex;
			EMovePathType moveState = this.MoveState;
			if (moveState == EMovePathType.UnSelect || moveState == EMovePathType.CannotWalk)
			{
				this.CurSelectedIndex = -1;
				return;
			}
			MapRogueMainView view = this.View;
			if (view != null)
			{
				MapRogueMapModule mapModule = view.MapModule;
				if (mapModule != null)
				{
					mapModule.FocusOnGrid(this.CurSelectedIndex, true, null, null);
				}
			}
			this.GameStage = EMapRogueGameStage.Wait;
			MapGridData gridData = this.MapGrids[this.CurSelectedIndex];
			MapRogueMainView view2 = this.View;
			if (view2 == null)
			{
				return;
			}
			view2.OpenPopupView(gridData);
		}

		// Token: 0x06039DC5 RID: 236997 RVA: 0x00EA61DC File Offset: 0x00EA43DC
		public void OnMove(int? gridIndex = null)
		{
			if (!this.IsStageAvailable)
			{
				return;
			}
			this.CurSelectedIndex = (gridIndex ?? this.CurHoverIndex);
			if (this.MoveState != EMovePathType.CanMove)
			{
				this.CurSelectedIndex = -1;
				return;
			}
			MapRogueMainView view = this.View;
			if (view != null)
			{
				MapRogueMapModule mapModule = view.MapModule;
				if (mapModule != null)
				{
					mapModule.SetMapGridBgState(this.CurSelectedIndex, true, null);
				}
			}
			Action<bool> callbackAfterConfirm = delegate(bool confirm)
			{
				if (!confirm)
				{
					MapRogueMainView view2 = this.View;
					if (view2 == null)
					{
						return;
					}
					MapRogueMapModule mapModule2 = view2.MapModule;
					if (mapModule2 == null)
					{
						return;
					}
					mapModule2.SetMapGridBgState(this.CurSelectedIndex, false, null);
				}
			};
			this.RequestMove(callbackAfterConfirm);
		}

		// Token: 0x06039DC6 RID: 236998 RVA: 0x00EA6264 File Offset: 0x00EA4464
		[NullableContext(2)]
		public void RequestMove(Action<bool> callbackAfterConfirm = null)
		{
			MapRogueGameInfo.<>c__DisplayClass111_0 CS$<>8__locals1 = new MapRogueGameInfo.<>c__DisplayClass111_0();
			CS$<>8__locals1.callbackAfterConfirm = callbackAfterConfirm;
			CS$<>8__locals1.<>4__this = this;
			if (!this.NotTipsRecommend && !this.IsOverEventRecommendLv(this.CurSelectedIndex))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MapRogueHighLvEventConfirm);
				confirmBoxDataNew.HasToggle = true;
				confirmBoxDataNew.ToggleTextKey = "RogueRes_LvlHint_Desc";
				confirmBoxDataNew.FunctionMap.Add(1, new Action(CS$<>8__locals1.<RequestMove>g__cancel|0));
				confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<RequestMove>g__moveRequest|1));
				confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
				{
					CS$<>8__locals1.<>4__this.NotTipsRecommend = isSelectOn;
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (!this.NotTipsSkipBattle && this.IsGridCanSkipBattle(this.CurSelectedIndex))
			{
				ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.RogueResSkipBattleConfirm);
				confirmBoxDataNew2.HasToggle = true;
				confirmBoxDataNew2.ToggleTextKey = "RogueRes_FightSweepConfirm_Hint";
				confirmBoxDataNew2.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew2.FunctionMap.Add(0, new Action(CS$<>8__locals1.<RequestMove>g__cancel|0));
				confirmBoxDataNew2.FunctionMap.Add(1, new Action(CS$<>8__locals1.<RequestMove>g__noSkipBattle|2));
				confirmBoxDataNew2.FunctionMap.Add(2, new Action(CS$<>8__locals1.<RequestMove>g__skipBattle|3));
				confirmBoxDataNew2.SetToggleFunction(delegate(bool isSelectOn)
				{
					CS$<>8__locals1.<>4__this.NotTipsSkipBattle = isSelectOn;
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
				return;
			}
			CS$<>8__locals1.<RequestMove>g__moveRequest|1();
		}

		// Token: 0x06039DC7 RID: 236999 RVA: 0x00EA63B4 File Offset: 0x00EA45B4
		public void MoveOneStep(int lastGridId, int gridId)
		{
			this.ResetPath(gridId);
			this.TempPeriodTime = 0f;
			this.LastMoveGridIndex = lastGridId;
			this.CurMoveGridIndex = gridId;
			MapRogueMainView view = this.View;
			if (view != null)
			{
				MapRogueMapModule mapModule = view.MapModule;
				if (mapModule != null)
				{
					mapModule.RolePanel.SetRoleDirection(gridId > lastGridId);
				}
			}
			this.RefreshPerspectiveModeGrid(gridId);
		}

		// Token: 0x06039DC8 RID: 237000 RVA: 0x00EA6410 File Offset: 0x00EA4610
		public void EndMove()
		{
			this.CurOp = null;
			this.Path.Clear();
			MapRogueMainView view = this.View;
			if (view != null)
			{
				MapRogueMapModule mapModule = view.MapModule;
				if (mapModule != null)
				{
					mapModule.RolePanel.SetRoleAnim(EMapRogueSpineAnim.Idle, true);
				}
			}
			MapRogueMainView view2 = this.View;
			if (view2 == null)
			{
				return;
			}
			MapRogueMapModule mapModule2 = view2.MapModule;
			if (mapModule2 == null)
			{
				return;
			}
			mapModule2.RolePanel.SetRolePosItemVisible(true);
		}

		// Token: 0x06039DC9 RID: 237001 RVA: 0x00EA6474 File Offset: 0x00EA4674
		public UniTask TeleportFlow(int playerGridIndex, List<int> unlockGrids)
		{
			MapRogueGameInfo.<TeleportFlow>d__114 <TeleportFlow>d__;
			<TeleportFlow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TeleportFlow>d__.<>4__this = this;
			<TeleportFlow>d__.playerGridIndex = playerGridIndex;
			<TeleportFlow>d__.unlockGrids = unlockGrids;
			<TeleportFlow>d__.<>1__state = -1;
			<TeleportFlow>d__.<>t__builder.Start<MapRogueGameInfo.<TeleportFlow>d__114>(ref <TeleportFlow>d__);
			return <TeleportFlow>d__.<>t__builder.Task;
		}

		// Token: 0x06039DCA RID: 237002 RVA: 0x00EA64C7 File Offset: 0x00EA46C7
		public void RoleAnimProxy(EMapRogueSpineAnim anim, bool loop = true)
		{
			MapRogueMainView view = this.View;
			if (view == null)
			{
				return;
			}
			MapRogueMapModule mapModule = view.MapModule;
			if (mapModule == null)
			{
				return;
			}
			mapModule.RolePanel.SetRoleAnim(anim, loop);
		}

		// Token: 0x06039DCB RID: 237003 RVA: 0x00EA64EC File Offset: 0x00EA46EC
		public void PushGetItemData(int itemId, int changeCount)
		{
			if (changeCount == 0)
			{
				return;
			}
			IRogueGetListItemData item = new RogueGetListItemData
			{
				ItemId = itemId,
				ChangeCount = changeCount
			};
			this.GetItemDataList.Add(item);
		}

		// Token: 0x06039DCC RID: 237004 RVA: 0x00EA651D File Offset: 0x00EA471D
		[NullableContext(2)]
		public IRogueGetListItemData ShiftGetItemData()
		{
			if (this.GetItemDataList.Count == 0)
			{
				return null;
			}
			IRogueGetListItemData result = this.GetItemDataList[0];
			this.GetItemDataList.RemoveAt(0);
			return result;
		}

		// Token: 0x06039DCD RID: 237005 RVA: 0x00EA6546 File Offset: 0x00EA4746
		public bool IsGetItemDataEmpty()
		{
			return this.GetItemDataList.Count == 0;
		}

		// Token: 0x06039DCE RID: 237006 RVA: 0x00EA6558 File Offset: 0x00EA4758
		public int ExplorationCurrentProgress()
		{
			RogueResGridExplore? exploreByInstId = ConfigBase<MapRogueConfig>.Instance.GetExploreByInstId(this.InstanceId);
			if (exploreByInstId == null)
			{
				return 0;
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (MapGridData mapGridData in this.MapGrids)
			{
				if (mapGridData.EventType > 0 && mapGridData.IsExplore)
				{
					int num;
					dictionary.TryGetValue(mapGridData.EventType, out num);
					dictionary[mapGridData.EventType] = num + 1;
				}
			}
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < exploreByInstId.Value.FinishCountTypeLength; i++)
			{
				int[] array = MapRogueDefine.ParseNumbers(exploreByInstId.Value.FinishCountType(i), "#");
				if (array.Length >= 2)
				{
					int key = array[0];
					int num4 = array[1];
					int num5;
					dictionary.TryGetValue(key, out num5);
					num2 += num5;
					num3 += num4;
				}
			}
			return (int)Math.Ceiling((double)num2 / (double)num3 * 100.0);
		}

		// Token: 0x06039DCF RID: 237007 RVA: 0x00EA667C File Offset: 0x00EA487C
		public List<IExploreData> GetAllExplorationData()
		{
			List<IExploreData> list = new List<IExploreData>();
			RogueResGridExplore? exploreByInstId = ConfigBase<MapRogueConfig>.Instance.GetExploreByInstId(this.InstanceId);
			if (exploreByInstId == null)
			{
				return list;
			}
			int num = 0;
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (MapGridData mapGridData in this.MapGrids)
			{
				if (mapGridData.EventType > 0)
				{
					if (mapGridData.IsExplore)
					{
						int num2;
						dictionary.TryGetValue(mapGridData.EventType, out num2);
						dictionary[mapGridData.EventType] = num2 + 1;
					}
					if (exploreByInstId.Value.GetScoreMap(mapGridData.EventType) != null && mapGridData.IsExplore)
					{
						int value = exploreByInstId.Value.GetScoreMap(mapGridData.EventType).Value;
						num += value;
					}
				}
			}
			IExploreData item = new ExploreData
			{
				TitleId = "RogueResExplore_1",
				ValueTxt = num.ToString()
			};
			list.Add(item);
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < exploreByInstId.Value.FinishCountTypeLength; i++)
			{
				int[] array = MapRogueDefine.ParseNumbers(exploreByInstId.Value.FinishCountType(i), "#");
				if (array.Length >= 2)
				{
					int key = array[0];
					int num5 = array[1];
					int num6;
					dictionary.TryGetValue(key, out num6);
					num3 += num6;
					num4 += num5;
				}
			}
			int value2 = (int)Math.Ceiling((double)num3 / (double)num4 * 100.0);
			ExploreData exploreData = new ExploreData();
			exploreData.TitleId = "RogueResExplore_2";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			exploreData.ValueTxt = defaultInterpolatedStringHandler.ToStringAndClear();
			IExploreData item2 = exploreData;
			list.Add(item2);
			for (int j = 0; j < exploreByInstId.Value.CountTypeALength; j++)
			{
				int[] array2 = MapRogueDefine.ParseNumbers(exploreByInstId.Value.CountTypeA(j), "#");
				if (array2.Length >= 2)
				{
					int key2 = array2[0];
					int value3 = array2[1];
					int value4;
					dictionary.TryGetValue(key2, out value4);
					ExploreData exploreData2 = new ExploreData();
					exploreData2.TitleId = ((j < exploreByInstId.Value.DescALength) ? exploreByInstId.Value.DescA(j) : "");
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(value4);
					defaultInterpolatedStringHandler.AppendLiteral("/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(value3);
					exploreData2.ValueTxt = defaultInterpolatedStringHandler.ToStringAndClear();
					IExploreData item3 = exploreData2;
					list.Add(item3);
				}
			}
			for (int k = 0; k < exploreByInstId.Value.CountTypeBLength; k++)
			{
				int key3 = exploreByInstId.Value.CountTypeB(k);
				int num7;
				dictionary.TryGetValue(key3, out num7);
				IExploreData item4 = new ExploreData
				{
					TitleId = ((k < exploreByInstId.Value.DescBLength) ? exploreByInstId.Value.DescB(k) : ""),
					ValueTxt = num7.ToString()
				};
				list.Add(item4);
			}
			return list;
		}

		// Token: 0x06039DD0 RID: 237008 RVA: 0x00EA69E0 File Offset: 0x00EA4BE0
		public void TriggerGuideEventOnFocusStart()
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.RogueMapMoveTweenStarOrEnd, true);
		}

		// Token: 0x06039DD1 RID: 237009 RVA: 0x00EA69F3 File Offset: 0x00EA4BF3
		public void TriggerGuideEventOnFocusEnd()
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.RogueMapMoveTweenStarOrEnd, false);
		}

		// Token: 0x04020C72 RID: 134258
		public int InstanceId;

		// Token: 0x04020C73 RID: 134259
		public int RandomSeed;

		// Token: 0x04020C74 RID: 134260
		[Nullable(2)]
		private MapRogueMainView View;

		// Token: 0x04020C75 RID: 134261
		[Nullable(2)]
		private GridPathFinder PathFinder;

		// Token: 0x04020C76 RID: 134262
		private EMapRogueGameStage GameStageInternal;

		// Token: 0x04020C77 RID: 134263
		public int CurHoverIndex = -1;

		// Token: 0x04020C78 RID: 134264
		public int CurSelectedIndex = -1;

		// Token: 0x04020C79 RID: 134265
		private int PlayerGridIndexInternal;

		// Token: 0x04020C7A RID: 134266
		public List<MapGridData> MapGrids = new List<MapGridData>();

		// Token: 0x04020C7B RID: 134267
		public int MapWidth;

		// Token: 0x04020C7C RID: 134268
		public int MapHeight;

		// Token: 0x04020C7D RID: 134269
		public MapRogueMapPoint Center = new MapRogueMapPoint
		{
			X = 0,
			Y = 0
		};

		// Token: 0x04020C7E RID: 134270
		public float MoveTimeGap = ConfigCommonParamById.GetFloatConfig("MapRogueRoleMoveSpeed").GetValueOrDefault(100f);

		// Token: 0x04020C7F RID: 134271
		private readonly float FocusTweenTime = (float)ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.FocusTime;

		// Token: 0x04020C80 RID: 134272
		private int TeamLvInternal = 1;

		// Token: 0x04020C81 RID: 134273
		private int TeamLvAnimInterval = 1;

		// Token: 0x04020C82 RID: 134274
		private bool InBattleInternal;

		// Token: 0x04020C83 RID: 134275
		private readonly int LvItemId = ConfigCommonParamById.GetIntConfig("MapRogueLvItemId").GetValueOrDefault();

		// Token: 0x04020C84 RID: 134276
		private readonly HashSet<EMapForbiddenTag> MaskTagSet = new HashSet<EMapForbiddenTag>();

		// Token: 0x04020C85 RID: 134277
		public bool IsEnd;

		// Token: 0x04020C86 RID: 134278
		public bool EnterBattleFlag;

		// Token: 0x04020C87 RID: 134279
		private bool NotTipsRecommend;

		// Token: 0x04020C88 RID: 134280
		private bool NotTipsSkipBattle;

		// Token: 0x04020C89 RID: 134281
		public bool IsSkipBattle;

		// Token: 0x04020C8A RID: 134282
		public bool NotTipsInactiveLink;

		// Token: 0x04020C8B RID: 134283
		public double MapScale = 1.0;

		// Token: 0x04020C8C RID: 134284
		[Nullable(2)]
		public MapRogueActorPool ActorPool;

		// Token: 0x04020C8D RID: 134285
		[Nullable(2)]
		private TimerHandle ActorPoolTimer;

		// Token: 0x04020C8E RID: 134286
		private HashSet<int> SurroundingsGrids = new HashSet<int>();

		// Token: 0x04020C8F RID: 134287
		private HashSet<int> HoverSurroundingsGrids = new HashSet<int>();

		// Token: 0x04020C90 RID: 134288
		public List<int> Path = new List<int>();

		// Token: 0x04020C91 RID: 134289
		public int MoodMin;

		// Token: 0x04020C92 RID: 134290
		public int MoodMax;

		// Token: 0x04020C93 RID: 134291
		private int MoodInternal;

		// Token: 0x04020C94 RID: 134292
		private int MoodRuleIdInternal;

		// Token: 0x04020C95 RID: 134293
		public readonly int MoodItemId = ConfigCommonParamById.GetIntConfig("MapRogueMoodItemId").GetValueOrDefault();

		// Token: 0x04020C96 RID: 134294
		[Nullable(2)]
		public MapRogueOp CurOp;

		// Token: 0x04020C97 RID: 134295
		[Nullable(2)]
		public CustomPromise ViewOpenPromise;

		// Token: 0x04020C98 RID: 134296
		[Nullable(2)]
		public CustomPromise ViewShowPromise;

		// Token: 0x04020C99 RID: 134297
		[Nullable(2)]
		public CustomPromise ViewLoadPromise;

		// Token: 0x04020C9A RID: 134298
		private float TempPeriodTime;

		// Token: 0x04020C9B RID: 134299
		private int LastMoveGridIndex;

		// Token: 0x04020C9C RID: 134300
		private int CurMoveGridIndex;

		// Token: 0x04020C9D RID: 134301
		private readonly List<IRogueGetListItemData> GetItemDataList = new List<IRogueGetListItemData>();
	}
}
