using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FloroRanch;
using CSharpScript.Game.Ui;

// Token: 0x02001C0C RID: 7180
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class FloroRanchGamePlayModel : ModelBase<FloroRanchGamePlayModel>
{
	// Token: 0x0600D0A9 RID: 53417 RVA: 0x00376256 File Offset: 0x00374456
	public void SetCurrentActivityData(global::FloroRanchActivityData data)
	{
		this.CurrentActivityData = data;
	}

	// Token: 0x0600D0AA RID: 53418 RVA: 0x00376260 File Offset: 0x00374460
	[NullableContext(2)]
	public global::FloroRanchActivityData GetCurrentActivityData()
	{
		if (this.CurrentActivityData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "FloroRanch获取当前活动数据失败：当前活动数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return this.CurrentActivityData;
	}

	// Token: 0x17001109 RID: 4361
	// (get) Token: 0x0600D0AB RID: 53419 RVA: 0x0037629A File Offset: 0x0037449A
	public bool IsInGamePlay
	{
		get
		{
			return this.InGamePlay;
		}
	}

	// Token: 0x0600D0AC RID: 53420 RVA: 0x003762A2 File Offset: 0x003744A2
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		return true;
	}

	// Token: 0x0600D0AD RID: 53421 RVA: 0x003762BE File Offset: 0x003744BE
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		return true;
	}

	// Token: 0x0600D0AE RID: 53422 RVA: 0x003762DA File Offset: 0x003744DA
	public void InitGame(int activityId, List<int> races, int skillId, bool isOver)
	{
		this.ActivityId = activityId;
		this.Races = races;
		this.SkillId = skillId;
		this.IsOver = isOver;
	}

	// Token: 0x0600D0AF RID: 53423 RVA: 0x003762FC File Offset: 0x003744FC
	public void EnterGame(FloroRanchStartPlayResponse gameData)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ConnectBan", Array.Empty<object>());
			return;
		}
		if (this.InGamePlay)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanch进入游戏失败：游戏已经开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.InitData(gameData.PlayInfo);
		this.RefreshDailyTaskData(new List<FloroRanchPlayTask>(gameData.Task));
		this.InitTimerSystem();
		this.InitStateMachine();
		this.ChangeState(EFloroRanchStageStateType.GameStart);
	}

	// Token: 0x0600D0B0 RID: 53424 RVA: 0x00376382 File Offset: 0x00374582
	public void InitStateMachine()
	{
		this.FloroRanchFsm = new FloroRanchStageFsm();
		this.FloroRanchFsm.Init();
	}

	// Token: 0x0600D0B1 RID: 53425 RVA: 0x0037639C File Offset: 0x0037459C
	public bool CanFsmInsertSkillTask()
	{
		if (this.FloroRanchFsm.GetCurrentStateType() != EFloroRanchStageStateType.DailyInStage)
		{
			return false;
		}
		FloroRanchStateBase currentState = this.FloroRanchFsm.GetCurrentState();
		return currentState != null && currentState is FloroRanchDailyInStageState && !((FloroRanchDailyInStageState)currentState).IsExecutingTask();
	}

	// Token: 0x0600D0B2 RID: 53426 RVA: 0x003763E0 File Offset: 0x003745E0
	public void ChangeState(EFloroRanchStageStateType state)
	{
		this.FloroRanchFsm.ChangeState(state);
	}

	// Token: 0x0600D0B3 RID: 53427 RVA: 0x003763F0 File Offset: 0x003745F0
	public void PauseGame()
	{
		if (!this.InGamePlay)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanch暂停游戏失败：游戏未开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.IsPause)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanch暂停游戏失败：游戏已经暂停", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.IsPause = true;
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.GetShowCardEntityList())
		{
			floroRanchEntityBase.GetUiItemComponent().Pause();
		}
		FloroRanchEntityBase roleEntity = this.RoleEntity;
		if (roleEntity != null)
		{
			roleEntity.GetUiItemComponent().Pause();
		}
		FloroRanchEntityActionSystem.Pause();
	}

	// Token: 0x0600D0B4 RID: 53428 RVA: 0x003764B8 File Offset: 0x003746B8
	public void ResumeGame()
	{
		if (!this.InGamePlay)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanch恢复游戏失败：游戏未开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!this.IsPause)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanch恢复游戏失败：游戏未暂停", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.IsPause = false;
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.GetShowCardEntityList())
		{
			floroRanchEntityBase.GetUiItemComponent().Resume();
		}
		FloroRanchEntityBase roleEntity = this.RoleEntity;
		if (roleEntity != null)
		{
			roleEntity.GetUiItemComponent().Resume();
		}
		FloroRanchEntityActionSystem.Resume();
	}

	// Token: 0x0600D0B5 RID: 53429 RVA: 0x00376580 File Offset: 0x00374780
	public void ExitGame(bool needSettle)
	{
		if (!this.InGamePlay)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanch退出游戏失败：游戏未开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.NeedSettle = needSettle;
		if (!needSettle)
		{
			global::FloroRanchActivityData currentActivityData = this.CurrentActivityData;
			if (currentActivityData != null)
			{
				currentActivityData.SetSavedStage(this.CurStage);
			}
		}
		this.IsExit = true;
		this.ChangeState(EFloroRanchStageStateType.GameExit);
	}

	// Token: 0x0600D0B6 RID: 53430 RVA: 0x003765E4 File Offset: 0x003747E4
	public void ReStartGame()
	{
		if (!this.InGamePlay)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanch退出游戏失败：游戏未开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.NeedReStart = true;
		this.IsExit = true;
		this.ChangeState(EFloroRanchStageStateType.GameExit);
	}

	// Token: 0x0600D0B7 RID: 53431 RVA: 0x00376630 File Offset: 0x00374830
	public void GameEnd()
	{
		if (!this.InGamePlay)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanch退出游戏失败：游戏未开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.ClearTimerSystem();
		this.ExitAllEntity();
		this.ClearData();
		this.CloseAllRecordView();
	}

	// Token: 0x0600D0B8 RID: 53432 RVA: 0x0037667D File Offset: 0x0037487D
	public void InitData(FloroRanchPlayInfo gameData)
	{
		this.InGamePlay = true;
		this.RefreshBasicData(gameData);
		this.InitEntityData(gameData);
	}

	// Token: 0x0600D0B9 RID: 53433 RVA: 0x00376694 File Offset: 0x00374894
	public void RefreshBasicData(FloroRanchPlayInfo gameData)
	{
		this.SubInstanceId = gameData.SubInsId;
		this.CurStage = gameData.Stage;
		this.CoinData.SetTotal((int)Singleton<MathUtils>.Instance.LongToBigInt(gameData.TotalCoin));
		this.CoinData.SetAmount((int)Singleton<MathUtils>.Instance.LongToBigInt(gameData.CurCoin));
		this.DiamondData.SetTotal((int)Singleton<MathUtils>.Instance.LongToBigInt(gameData.TotalDiamond));
		this.DiamondData.SetAmount((int)Singleton<MathUtils>.Instance.LongToBigInt(gameData.CurDiamond));
		this.StageTarget = (int)Singleton<MathUtils>.Instance.LongToBigInt(gameData.StageTributeCount);
		this.EnableToyCount = gameData.EnableToy;
		this.IsEndlessMode = gameData.IsUnLimited;
		this.StageDayCount = gameData.CurStageDayNum;
		this.TotalDayCount = gameData.TotalDay;
		this.RemindDay = gameData.RemainDay;
		this.ActionInfoList.Clear();
	}

	// Token: 0x0600D0BA RID: 53434 RVA: 0x00376788 File Offset: 0x00374988
	public void InitEntityData(FloroRanchPlayInfo gameData)
	{
		this.EntityMap.Clear();
		this.TerrainEntityList.Clear();
		this.CardEntityList.Clear();
		this.ToyEntityList.Clear();
		this.AddEntityList(new List<FloroRanchPlayUnit>(gameData.Terrains));
		this.AddEntityList(new List<FloroRanchPlayUnit>(gameData.PhantomList));
		this.AddEntityList(new List<FloroRanchPlayUnit>(gameData.ToyList));
		if (gameData.Dungeon != null)
		{
			this.DungeonEntity = FloroRanchEntityCreateSystem.CreateFloroRanchEntity(gameData.Dungeon);
			this.EntityMap[this.DungeonEntity.EntityId] = this.DungeonEntity;
		}
		if (gameData.Role != null)
		{
			this.RoleEntity = FloroRanchEntityCreateSystem.CreateFloroRanchEntity(gameData.Role);
			this.EntityMap[this.RoleEntity.EntityId] = this.RoleEntity;
		}
	}

	// Token: 0x0600D0BB RID: 53435 RVA: 0x0037685E File Offset: 0x00374A5E
	public void OnDayStart(FloroRanchDayStart data)
	{
		this.CurStage = data.CurStage;
		this.IsEndlessMode = data.IsUnlimited;
		this.TotalDayCount = data.TotalDay;
		this.RemindDay = data.RemainDay;
	}

	// Token: 0x0600D0BC RID: 53436 RVA: 0x00376890 File Offset: 0x00374A90
	public void OnStageStart(FloroRanchStageStart data)
	{
		this.StageTarget = (int)Singleton<MathUtils>.Instance.LongToBigInt(data.Target);
		this.StageDayCount = data.DayCount;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnFloroRanchStageInfoRefresh);
	}

	// Token: 0x0600D0BD RID: 53437 RVA: 0x003768C8 File Offset: 0x00374AC8
	public void AddEntityList(List<FloroRanchPlayUnit> entityDataList)
	{
		foreach (FloroRanchPlayUnit entityData in entityDataList)
		{
			this.AddEntity(entityData);
		}
	}

	// Token: 0x0600D0BE RID: 53438 RVA: 0x00376918 File Offset: 0x00374B18
	[return: Nullable(2)]
	public FloroRanchEntityBase AddEntity(FloroRanchPlayUnit entityData)
	{
		if (this.EntityMap.ContainsKey(entityData.PlayIncId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanch实体Id重复";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityData.PlayIncId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		FloroRanchEntityBase floroRanchEntityBase = FloroRanchEntityCreateSystem.CreateFloroRanchEntity(entityData);
		this.EntityMap[floroRanchEntityBase.EntityId] = floroRanchEntityBase;
		this.AddEntityByType(floroRanchEntityBase.EntityType, floroRanchEntityBase);
		if (floroRanchEntityBase.EntityType == EFloroRanchEntityType.Card)
		{
			int ownCardEntityCount = this.OwnCardEntityCountInternal + 1;
			this.SetOwnCardEntityCount(ownCardEntityCount);
		}
		return floroRanchEntityBase;
	}

	// Token: 0x0600D0BF RID: 53439 RVA: 0x003769B0 File Offset: 0x00374BB0
	public void RefreshEntityList(List<FloroRanchPlayUnit> entityDataList)
	{
		foreach (FloroRanchPlayUnit floroRanchPlayUnit in entityDataList)
		{
			this.GetEntity(floroRanchPlayUnit.PlayIncId).RefreshEntityData(floroRanchPlayUnit);
		}
	}

	// Token: 0x0600D0C0 RID: 53440 RVA: 0x00376A0C File Offset: 0x00374C0C
	public void RefreshRemoveEntityList(List<int> entityList)
	{
		foreach (int entityId in entityList)
		{
			this.GetEntity(entityId).CheckGetComponent<FloroRanchEntityDataComponent>().Remove();
		}
	}

	// Token: 0x0600D0C1 RID: 53441 RVA: 0x00376A64 File Offset: 0x00374C64
	public bool CheckEntityIsExist(int entityId)
	{
		return this.EntityMap.ContainsKey(entityId);
	}

	// Token: 0x0600D0C2 RID: 53442 RVA: 0x00376A74 File Offset: 0x00374C74
	[NullableContext(2)]
	public FloroRanchEntityBase GetEntity(int entityId)
	{
		if (entityId <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanch获取实体数据失败：实体Id错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (!this.EntityMap.ContainsKey(entityId))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.FloroRanchGamePlay;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "FloroRanch获取实体数据失败：实体不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		FloroRanchEntityBase result;
		this.EntityMap.TryGetValue(entityId, out result);
		return result;
	}

	// Token: 0x0600D0C3 RID: 53443 RVA: 0x00376B04 File Offset: 0x00374D04
	public void RemoveOwnEntityData(FloroRanchEntityBase entity)
	{
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = entity.CheckGetComponent<FloroRanchEntityDataComponent>();
		if (!floroRanchEntityDataComponent.IsValid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanch移除实体数据失败：实体重复移除";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entity.EntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		floroRanchEntityDataComponent.Remove();
		if (this.RemoveEntityByType(entity.EntityType, entity) && entity.EntityType == EFloroRanchEntityType.Card)
		{
			int ownCardEntityCount = this.OwnCardEntityCountInternal - 1;
			this.SetOwnCardEntityCount(ownCardEntityCount);
		}
	}

	// Token: 0x0600D0C4 RID: 53444 RVA: 0x00376B84 File Offset: 0x00374D84
	public void ClearRemoveEntity()
	{
		foreach (int key in new List<int>(this.EntityMap.Keys))
		{
			FloroRanchEntityBase floroRanchEntityBase = this.EntityMap[key];
			if (!floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>().IsValid)
			{
				this.EntityMap.Remove(floroRanchEntityBase.EntityId);
			}
		}
	}

	// Token: 0x0600D0C5 RID: 53445 RVA: 0x00376C08 File Offset: 0x00374E08
	public void OnShopItemPurchased(FloroRanchPlayShopBuyResponse data)
	{
		this.OnCurrencyChange((int)Singleton<MathUtils>.Instance.LongToBigInt(data.CurCoin), (int)Singleton<MathUtils>.Instance.LongToBigInt(data.CurDiamond));
		switch (data.Type)
		{
		case FloroRanchPlayShopBuyType.BuyCard:
			FloroRanchEntityActionSystem.AddEntity(data.Card.NewPhantom);
			return;
		case FloroRanchPlayShopBuyType.BuyGardGroup:
		{
			FloroRanchPlayShopBuyCardGroup cardGroup = data.CardGroup;
			this.OpenAndRecordView(EUiViewName.FloroRanchCardGroupSelectView, new List<int>(cardGroup.CardIds), null);
			return;
		}
		case FloroRanchPlayShopBuyType.BuyToy:
		{
			FloroRanchPlayUnit newToy = data.Toy.NewToy;
			if (this.CheckEntityIsExist(newToy.PlayIncId))
			{
				this.GetEntity(newToy.PlayIncId).RefreshEntityData(newToy);
				return;
			}
			FloroRanchEntityActionSystem.AddEntity(newToy);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x0600D0C6 RID: 53446 RVA: 0x00376CBC File Offset: 0x00374EBC
	public void OnTributeResult(FloroRanchPlayTributeResponse data)
	{
		this.RemindDay = data.RemainDay;
		this.CurStage = data.CurStage;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnFloroRanchStageInfoRefresh);
		int coinAmount = (int)Singleton<MathUtils>.Instance.LongToBigInt(data.CurCoin);
		int diamondAmount = (int)Singleton<MathUtils>.Instance.LongToBigInt(data.CurDiamond);
		this.OnCurrencyChange(coinAmount, diamondAmount);
	}

	// Token: 0x0600D0C7 RID: 53447 RVA: 0x00376D1D File Offset: 0x00374F1D
	public void OnCurrencyChange(int coinAmount, int diamondAmount)
	{
		this.CoinData.SetAmount(coinAmount);
		this.DiamondData.SetAmount(diamondAmount);
		this.GetGamePlayView().RefreshCurrencyInfo();
	}

	// Token: 0x0600D0C8 RID: 53448 RVA: 0x00376D44 File Offset: 0x00374F44
	[NullableContext(2)]
	public void OpenAndRecordView(EUiViewName viewName, object param = null, Action callback = null)
	{
		Singleton<UiManager>.Instance.OpenView(viewName, param, delegate(bool isSuccess, int viewId)
		{
			if (!isSuccess)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FloroRanchGamePlay;
				ELogAuthor author = ELogAuthor.BB;
				string message = "FloroRanch打开界面失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			UiPanelBase gamePlayView = this.GetGamePlayView();
			UiViewBase view = Singleton<UiManager>.Instance.GetView(viewId);
			gamePlayView.AddChild(view);
			this.OpenViewStack.Add(viewId);
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		});
	}

	// Token: 0x0600D0C9 RID: 53449 RVA: 0x00376D8C File Offset: 0x00374F8C
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		int count = this.OpenViewStack.Count;
		if (count > 0 && this.OpenViewStack[count - 1] == viewId)
		{
			this.OpenViewStack.RemoveAt(count - 1);
		}
	}

	// Token: 0x0600D0CA RID: 53450 RVA: 0x00376DC8 File Offset: 0x00374FC8
	public void ShowRecordView()
	{
		foreach (int viewId in this.OpenViewStack)
		{
			UiViewBase view = Singleton<UiManager>.Instance.GetView(viewId);
			if (view != null)
			{
				view.SetActive(true);
			}
		}
		this.GetGamePlayView().SetShowButtonActive(false);
	}

	// Token: 0x0600D0CB RID: 53451 RVA: 0x00376E38 File Offset: 0x00375038
	public void HideRecordView()
	{
		foreach (int viewId in this.OpenViewStack)
		{
			UiViewBase view = Singleton<UiManager>.Instance.GetView(viewId);
			if (view != null)
			{
				view.SetActive(false);
			}
		}
		this.GetGamePlayView().SetShowButtonActive(true);
	}

	// Token: 0x0600D0CC RID: 53452 RVA: 0x00376EA8 File Offset: 0x003750A8
	public void CloseAllRecordView()
	{
		foreach (int viewId in this.OpenViewStack)
		{
			Singleton<UiManager>.Instance.CloseViewById(viewId, null);
		}
		this.OpenViewStack.Clear();
	}

	// Token: 0x1700110A RID: 4362
	// (get) Token: 0x0600D0CD RID: 53453 RVA: 0x00376F0C File Offset: 0x0037510C
	public int OwnCardEntityCount
	{
		get
		{
			return this.OwnCardEntityCountInternal;
		}
	}

	// Token: 0x0600D0CE RID: 53454 RVA: 0x00376F14 File Offset: 0x00375114
	public void SetOwnCardEntityCount(int count)
	{
		this.OwnCardEntityCountInternal = count;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnFloroRanchCardEntityCountChange);
	}

	// Token: 0x0600D0CF RID: 53455 RVA: 0x00376F30 File Offset: 0x00375130
	public void ExitAllEntity()
	{
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.EntityMap.Values)
		{
			FloroRanchUiItemBaseComponent uiItemComponent = floroRanchEntityBase.GetUiItemComponent();
			if (uiItemComponent != null)
			{
				uiItemComponent.Exit();
			}
		}
	}

	// Token: 0x0600D0D0 RID: 53456 RVA: 0x00376F90 File Offset: 0x00375190
	public void ClearData()
	{
		this.InGamePlay = false;
		this.ActivityId = 0;
		this.SubInstanceId = 0;
		this.Races.Clear();
		this.SkillId = 0;
		this.CurStage = 0;
		this.RemindDay = 0;
		this.TerrainEntityList.Clear();
		this.CardEntityList.Clear();
		this.ToyEntityList.Clear();
		this.DungeonEntity = null;
		this.RoleEntity = null;
		this.TaskList.Clear();
		this.FloroRanchFsm = null;
		this.IsPause = false;
		this.OpenViewStack.Clear();
		this.LastDayIncome = 0;
		this.LastIncomeEntityList.Clear();
		this.OwnCardEntityCountInternal = 0;
		this.NeedReStart = false;
		this.IsExit = false;
		this.CurrentActivityData = null;
		this.ActionInfoList.Clear();
		this.EntityMap.Clear();
	}

	// Token: 0x0600D0D1 RID: 53457 RVA: 0x00377069 File Offset: 0x00375269
	public void RefreshDailyTaskData(List<FloroRanchPlayTask> taskList)
	{
		this.TaskList = taskList;
	}

	// Token: 0x0600D0D2 RID: 53458 RVA: 0x00377072 File Offset: 0x00375272
	public List<FloroRanchPlayTask> GetDailyTaskList()
	{
		List<FloroRanchPlayTask> result = new List<FloroRanchPlayTask>(this.TaskList);
		this.TaskList.Clear();
		return result;
	}

	// Token: 0x0600D0D3 RID: 53459 RVA: 0x0037708C File Offset: 0x0037528C
	private void AddEntityByType(EFloroRanchEntityType type, FloroRanchEntityBase entity)
	{
		switch (type)
		{
		case EFloroRanchEntityType.Terrain:
			this.TerrainEntityList.Add(entity);
			return;
		case EFloroRanchEntityType.Card:
			this.CardEntityList.Add(entity);
			return;
		case EFloroRanchEntityType.Toy:
			this.ToyEntityList.Add(entity);
			return;
		case EFloroRanchEntityType.Dungeon:
		{
			if (this.DungeonEntity == null)
			{
				this.DungeonEntity = entity;
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanch添加实体失败：DungeonEntity已存在 不可重复添加";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entity.EntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		case EFloroRanchEntityType.Role:
		{
			if (this.RoleEntity == null)
			{
				this.RoleEntity = entity;
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.FloroRanchGamePlay;
			ELogAuthor author2 = ELogAuthor.LRC;
			string message2 = "FloroRanch添加实体失败：RoleEntity已存在 不可重复添加";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entity.EntityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		default:
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.FloroRanchGamePlay;
			ELogAuthor author3 = ELogAuthor.LRC;
			string message3 = "FloroRanch添加实体失败：EntityType错误";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("type", type);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return;
		}
		}
	}

	// Token: 0x0600D0D4 RID: 53460 RVA: 0x00377198 File Offset: 0x00375398
	private bool RemoveEntityByType(EFloroRanchEntityType type, FloroRanchEntityBase entity)
	{
		int num = -1;
		switch (type)
		{
		case EFloroRanchEntityType.Terrain:
			num = this.TerrainEntityList.IndexOf(entity);
			if (num != -1)
			{
				this.TerrainEntityList.RemoveAt(num);
			}
			break;
		case EFloroRanchEntityType.Card:
			num = this.CardEntityList.IndexOf(entity);
			if (num != -1)
			{
				this.CardEntityList.RemoveAt(num);
			}
			break;
		case EFloroRanchEntityType.Toy:
			num = this.ToyEntityList.IndexOf(entity);
			if (num != -1)
			{
				this.ToyEntityList.RemoveAt(num);
			}
			break;
		case EFloroRanchEntityType.Dungeon:
			this.DungeonEntity = null;
			break;
		case EFloroRanchEntityType.Role:
			this.RoleEntity = null;
			break;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "RemoveEntityByType失败：EntityType错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			break;
		}
		}
		bool flag = num != -1;
		if (!flag)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.FloroRanchGamePlay;
			ELogAuthor author2 = ELogAuthor.LRC;
			string message2 = "RemoveEntityByType失败：实体不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entity.EntityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		return flag;
	}

	// Token: 0x0600D0D5 RID: 53461 RVA: 0x003772A4 File Offset: 0x003754A4
	public List<FloroRanchEntityBase> GetShowCardEntityList()
	{
		List<FloroRanchEntityBase> list = new List<FloroRanchEntityBase>();
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.CardEntityList)
		{
			FloroRanchEntityDataComponent floroRanchEntityDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>();
			if (floroRanchEntityDataComponent.IsValid && floroRanchEntityDataComponent.Point != -1)
			{
				list.Add(floroRanchEntityBase);
			}
		}
		return list;
	}

	// Token: 0x0600D0D6 RID: 53462 RVA: 0x00377318 File Offset: 0x00375518
	public List<FloroRanchEntityBase> GetShowToyEntityList()
	{
		List<FloroRanchEntityBase> list = new List<FloroRanchEntityBase>();
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.ToyEntityList)
		{
			FloroRanchEntityDataComponent floroRanchEntityDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>();
			if (floroRanchEntityDataComponent.IsValid && floroRanchEntityDataComponent.Point != -1)
			{
				list.Add(floroRanchEntityBase);
			}
		}
		return list;
	}

	// Token: 0x0600D0D7 RID: 53463 RVA: 0x0037738C File Offset: 0x0037558C
	public int GetCurToyCount()
	{
		return this.GetShowToyEntityList().Count;
	}

	// Token: 0x0600D0D8 RID: 53464 RVA: 0x0037739C File Offset: 0x0037559C
	public List<FloroRanchEntityBase> GetShowTerrainEntityList()
	{
		List<FloroRanchEntityBase> list = new List<FloroRanchEntityBase>();
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.TerrainEntityList)
		{
			FloroRanchEntityDataComponent floroRanchEntityDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>();
			if (floroRanchEntityDataComponent.IsValid && floroRanchEntityDataComponent.Point != -1)
			{
				list.Add(floroRanchEntityBase);
			}
		}
		return list;
	}

	// Token: 0x0600D0D9 RID: 53465 RVA: 0x00377410 File Offset: 0x00375610
	[NullableContext(2)]
	public FloroRanchEntityBase GetCardEntityByPoint(int point)
	{
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.CardEntityList)
		{
			FloroRanchEntityDataComponent floroRanchEntityDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>();
			if (floroRanchEntityDataComponent.IsValid && floroRanchEntityDataComponent.Point == point)
			{
				return floroRanchEntityBase;
			}
		}
		return null;
	}

	// Token: 0x0600D0DA RID: 53466 RVA: 0x0037747C File Offset: 0x0037567C
	[NullableContext(2)]
	public FloroRanchEntityBase GetTerrainEntityByPoint(int point)
	{
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.TerrainEntityList)
		{
			FloroRanchEntityDataComponent floroRanchEntityDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>();
			if (floroRanchEntityDataComponent.IsValid && floroRanchEntityDataComponent.Point == point)
			{
				return floroRanchEntityBase;
			}
		}
		return null;
	}

	// Token: 0x0600D0DB RID: 53467 RVA: 0x003774E8 File Offset: 0x003756E8
	[NullableContext(2)]
	public FloroRanchEntityBase GetToyEntityByPoint(int point)
	{
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.ToyEntityList)
		{
			FloroRanchEntityDataComponent floroRanchEntityDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>();
			if (floroRanchEntityDataComponent.IsValid && floroRanchEntityDataComponent.Point == point)
			{
				return floroRanchEntityBase;
			}
		}
		return null;
	}

	// Token: 0x0600D0DC RID: 53468 RVA: 0x00377554 File Offset: 0x00375754
	public void ClearLastDayIncome()
	{
		this.LastDayIncome = 0;
		foreach (FloroRanchEntityBase floroRanchEntityBase in this.EntityMap.Values)
		{
			floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>().Income = 0;
		}
	}

	// Token: 0x0600D0DD RID: 53469 RVA: 0x003775B8 File Offset: 0x003757B8
	public void RefreshLastIncomeEntityList()
	{
		this.LastIncomeEntityList.Clear();
		foreach (FloroRanchEntityBase item in this.EntityMap.Values)
		{
			this.LastIncomeEntityList.Add(item);
		}
		this.LastIncomeEntityList.Sort(delegate(FloroRanchEntityBase a, FloroRanchEntityBase b)
		{
			FloroRanchEntityDataComponent floroRanchEntityDataComponent = a.CheckGetComponent<FloroRanchEntityDataComponent>();
			FloroRanchEntityDataComponent floroRanchEntityDataComponent2 = b.CheckGetComponent<FloroRanchEntityDataComponent>();
			if (floroRanchEntityDataComponent2.Income != floroRanchEntityDataComponent.Income)
			{
				return floroRanchEntityDataComponent2.Income - floroRanchEntityDataComponent.Income;
			}
			bool isValid = floroRanchEntityDataComponent.IsValid;
			bool isValid2 = floroRanchEntityDataComponent2.IsValid;
			if (isValid != isValid2)
			{
				if (!isValid2)
				{
					return -1;
				}
				return 1;
			}
			else
			{
				int num2;
				int num = FloroRanchDefine.EntityTypePriority.TryGetValue((int)floroRanchEntityDataComponent.EntityType, out num2) ? num2 : 0;
				int num4;
				int num3 = FloroRanchDefine.EntityTypePriority.TryGetValue((int)floroRanchEntityDataComponent2.EntityType, out num4) ? num4 : 0;
				if (num3 != num)
				{
					return num - num3;
				}
				int race = a.GetRace();
				int race2 = b.GetRace();
				if (race != race2)
				{
					return race - race2;
				}
				int rarity = a.GetRarity();
				int rarity2 = b.GetRarity();
				if (rarity != rarity2)
				{
					return rarity2 - rarity;
				}
				return floroRanchEntityDataComponent.EntityId - floroRanchEntityDataComponent2.EntityId;
			}
		});
	}

	// Token: 0x0600D0DE RID: 53470 RVA: 0x0037764C File Offset: 0x0037584C
	public List<IFloroRanchDetailData> GetLastIncomeEntityList(FloroRanchFilterType filterType, bool isAscending, bool isShowNotPresentCard)
	{
		List<FloroRanchEntityBase> list = this.LastIncomeEntityList;
		list = list.FindAll(delegate(FloroRanchEntityBase entity)
		{
			EFloroRanchEntityType entityType = entity.EntityType;
			if (!this.CheckEntityTypeIsVisible(entityType))
			{
				return false;
			}
			int point = entity.GetPoint();
			return (isShowNotPresentCard || point != -1) && (filterType.FilterTypeId < 0 || filterType.FilterTypeId == (int)entityType);
		});
		List<IFloroRanchDetailData> list2 = new List<IFloroRanchDetailData>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(new FloroRanchDetailData
			{
				EntityData = list[i],
				Rank = i + 1
			});
		}
		if (!isAscending)
		{
			list2.Reverse();
		}
		return list2;
	}

	// Token: 0x0600D0DF RID: 53471 RVA: 0x003776D0 File Offset: 0x003758D0
	public int GetLastDayIncome()
	{
		return this.LastDayIncome;
	}

	// Token: 0x0600D0E0 RID: 53472 RVA: 0x003776D8 File Offset: 0x003758D8
	public void AddLastDayIncome(int income)
	{
		this.LastDayIncome += income;
	}

	// Token: 0x0600D0E1 RID: 53473 RVA: 0x003776E8 File Offset: 0x003758E8
	public void SetStageTarget(int target)
	{
		this.StageTarget = target;
	}

	// Token: 0x0600D0E2 RID: 53474 RVA: 0x003776F1 File Offset: 0x003758F1
	public int GetStageTarget()
	{
		return this.StageTarget;
	}

	// Token: 0x0600D0E3 RID: 53475 RVA: 0x003776FC File Offset: 0x003758FC
	[NullableContext(2)]
	public FloroRanchGamePlayView GetGamePlayView()
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FloroRanchGamePlayView);
		if (viewByName == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "GetGamePlayView失败：view不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return viewByName as FloroRanchGamePlayView;
	}

	// Token: 0x0600D0E4 RID: 53476 RVA: 0x00377743 File Offset: 0x00375943
	public bool CheckEntityTypeIsVisible(EFloroRanchEntityType entityType)
	{
		return entityType == EFloroRanchEntityType.Card || entityType == EFloroRanchEntityType.Toy || entityType == EFloroRanchEntityType.Terrain;
	}

	// Token: 0x0600D0E5 RID: 53477 RVA: 0x00377754 File Offset: 0x00375954
	private void InitTimerSystem()
	{
		if (this.TimerHandle != null)
		{
			this.ClearTimerHandle();
		}
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTick), 20f, 1f, null, null, true);
		this.TimeDilation = 1;
		this.IsSkipInternal = false;
	}

	// Token: 0x0600D0E6 RID: 53478 RVA: 0x003777A6 File Offset: 0x003759A6
	private void OnTick(float deltaTime)
	{
		if (this.IsPause)
		{
			return;
		}
		this.FloroRanchTimerSystem.Tick(deltaTime * (float)this.TimeDilation);
	}

	// Token: 0x0600D0E7 RID: 53479 RVA: 0x003777C5 File Offset: 0x003759C5
	private void ClearTimerSystem()
	{
		this.ClearTimerHandle();
		this.TimeDilation = 1;
		this.IsSkipInternal = false;
		this.FloroRanchTimerSystem.Clear();
	}

	// Token: 0x0600D0E8 RID: 53480 RVA: 0x003777E6 File Offset: 0x003759E6
	private void ClearTimerHandle()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.TimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x0600D0E9 RID: 53481 RVA: 0x00377812 File Offset: 0x00375A12
	public void SetTimeDilation(int dilation)
	{
		this.TimeDilation = dilation;
	}

	// Token: 0x0600D0EA RID: 53482 RVA: 0x0037781B File Offset: 0x00375A1B
	public int GetTimeDilation()
	{
		return this.TimeDilation;
	}

	// Token: 0x1700110B RID: 4363
	// (get) Token: 0x0600D0EB RID: 53483 RVA: 0x00377823 File Offset: 0x00375A23
	// (set) Token: 0x0600D0EC RID: 53484 RVA: 0x0037782B File Offset: 0x00375A2B
	public bool IsSkip
	{
		get
		{
			return this.IsSkipInternal;
		}
		set
		{
			this.IsSkipInternal = value;
		}
	}

	// Token: 0x0600D0ED RID: 53485 RVA: 0x00377834 File Offset: 0x00375A34
	public float GetPopupRewardStayTime()
	{
		if (!FloroRanchDefine.FloroRanchSpeedTimeMap.ContainsKey(this.TimeDilation))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GetPopupRewardStayTime失败：TimeDilation错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TimeDilation", this.TimeDilation);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 500f;
		}
		return FloroRanchDefine.FloroRanchSpeedTimeMap[this.TimeDilation].PopupRewardStayTime;
	}

	// Token: 0x0600D0EE RID: 53486 RVA: 0x003778A4 File Offset: 0x00375AA4
	public float GetPopupRewardWaitTime()
	{
		if (!FloroRanchDefine.FloroRanchSpeedTimeMap.ContainsKey(this.TimeDilation))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GetPopupRewardWaitTime失败：TimeDilation错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TimeDilation", this.TimeDilation);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 200f;
		}
		return FloroRanchDefine.FloroRanchSpeedTimeMap[this.TimeDilation].PopupRewardWaitTime;
	}

	// Token: 0x0600D0EF RID: 53487 RVA: 0x00377914 File Offset: 0x00375B14
	public float GetBezierCurveTime()
	{
		if (!FloroRanchDefine.FloroRanchSpeedTimeMap.ContainsKey(this.TimeDilation))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GetBezierCurveTime失败：TimeDilation错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TimeDilation", this.TimeDilation);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 500f;
		}
		return FloroRanchDefine.FloroRanchSpeedTimeMap[this.TimeDilation].BezierCurveTime;
	}

	// Token: 0x0600D0F0 RID: 53488 RVA: 0x00377984 File Offset: 0x00375B84
	public float GetWageSettleWaitTime()
	{
		if (!FloroRanchDefine.FloroRanchSpeedTimeMap.ContainsKey(this.TimeDilation))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GetWageSettleWaitTime失败：TimeDilation错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TimeDilation", this.TimeDilation);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 2500f;
		}
		return FloroRanchDefine.FloroRanchSpeedTimeMap[this.TimeDilation].WageSettleWaitTime;
	}

	// Token: 0x040063A3 RID: 25507
	public int ActivityId;

	// Token: 0x040063A4 RID: 25508
	public int SubInstanceId;

	// Token: 0x040063A5 RID: 25509
	public List<int> Races = new List<int>();

	// Token: 0x040063A6 RID: 25510
	public int SkillId;

	// Token: 0x040063A7 RID: 25511
	[Nullable(2)]
	private global::FloroRanchActivityData CurrentActivityData;

	// Token: 0x040063A8 RID: 25512
	public bool IsOver;

	// Token: 0x040063A9 RID: 25513
	public int CurStage;

	// Token: 0x040063AA RID: 25514
	public int RemindDay;

	// Token: 0x040063AB RID: 25515
	public int StageTarget;

	// Token: 0x040063AC RID: 25516
	public int StageDayCount;

	// Token: 0x040063AD RID: 25517
	public int TotalDayCount;

	// Token: 0x040063AE RID: 25518
	public int EnableToyCount;

	// Token: 0x040063AF RID: 25519
	private int LastDayIncome;

	// Token: 0x040063B0 RID: 25520
	private bool InGamePlay;

	// Token: 0x040063B1 RID: 25521
	public bool IsEndlessMode;

	// Token: 0x040063B2 RID: 25522
	public FloroRanchCurrencyData CoinData = new FloroRanchCurrencyData(ECurrencyType.Coin);

	// Token: 0x040063B3 RID: 25523
	public FloroRanchCurrencyData DiamondData = new FloroRanchCurrencyData(ECurrencyType.Diamond);

	// Token: 0x040063B4 RID: 25524
	private int OwnCardEntityCountInternal;

	// Token: 0x040063B5 RID: 25525
	public bool ShowEntityDebugInfo = true;

	// Token: 0x040063B6 RID: 25526
	private readonly List<FloroRanchEntityBase> TerrainEntityList = new List<FloroRanchEntityBase>();

	// Token: 0x040063B7 RID: 25527
	private readonly List<FloroRanchEntityBase> CardEntityList = new List<FloroRanchEntityBase>();

	// Token: 0x040063B8 RID: 25528
	private readonly List<FloroRanchEntityBase> ToyEntityList = new List<FloroRanchEntityBase>();

	// Token: 0x040063B9 RID: 25529
	[Nullable(2)]
	public FloroRanchEntityBase DungeonEntity;

	// Token: 0x040063BA RID: 25530
	[Nullable(2)]
	public FloroRanchEntityBase RoleEntity;

	// Token: 0x040063BB RID: 25531
	private readonly Dictionary<int, FloroRanchEntityBase> EntityMap = new Dictionary<int, FloroRanchEntityBase>();

	// Token: 0x040063BC RID: 25532
	private readonly List<FloroRanchEntityBase> LastIncomeEntityList = new List<FloroRanchEntityBase>();

	// Token: 0x040063BD RID: 25533
	private List<FloroRanchPlayTask> TaskList = new List<FloroRanchPlayTask>();

	// Token: 0x040063BE RID: 25534
	[Nullable(2)]
	private FloroRanchStageFsm FloroRanchFsm;

	// Token: 0x040063BF RID: 25535
	private readonly List<int> OpenViewStack = new List<int>();

	// Token: 0x040063C0 RID: 25536
	public List<string> ActionInfoList = new List<string>();

	// Token: 0x040063C1 RID: 25537
	public bool NeedReStart;

	// Token: 0x040063C2 RID: 25538
	public bool NeedSettle;

	// Token: 0x040063C3 RID: 25539
	public bool IsPause;

	// Token: 0x040063C4 RID: 25540
	public bool IsExit;

	// Token: 0x040063C5 RID: 25541
	public TimerSystemInstance FloroRanchTimerSystem = new TimerSystemInstance();

	// Token: 0x040063C6 RID: 25542
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040063C7 RID: 25543
	private int TimeDilation = 1;

	// Token: 0x040063C8 RID: 25544
	private bool IsSkipInternal;
}
