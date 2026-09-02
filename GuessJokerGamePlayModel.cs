using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.GameplayABP;
using AkiClient.Game.Aki.Character.NPC.RoleNPC;
using AkiClient.Game.Aki.Character.Role.Common.ABP_Gameplay;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200111B RID: 4379
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class GuessJokerGamePlayModel : ModelBase<GuessJokerGamePlayModel>
{
	// Token: 0x060071CE RID: 29134 RVA: 0x001DAE70 File Offset: 0x001D9070
	protected override bool OnInit()
	{
		IReadOnlyList<GuessJokerLevel> jokerLevelList = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelList();
		if (jokerLevelList.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker初始化失败：关卡配置表为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this.LevelId = jokerLevelList[0].Id;
		return true;
	}

	// Token: 0x060071CF RID: 29135 RVA: 0x001DAEC7 File Offset: 0x001D90C7
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotSequenceEnd, new Action(this.OnPlotSequenceEnd));
		this.PendingNpcSitSet.Clear();
		return true;
	}

	// Token: 0x060071D0 RID: 29136 RVA: 0x001DAEF1 File Offset: 0x001D90F1
	private void OnPlotSequenceEnd()
	{
		if (this.GetGamePlayView() == null)
		{
			return;
		}
		this.OpenGamePlayView(null);
	}

	// Token: 0x060071D1 RID: 29137 RVA: 0x001DAF03 File Offset: 0x001D9103
	public void InitGame()
	{
		this.InGamePlay = true;
		this.CardDataMap.Clear();
		this.RoundStartTipShownMap.Clear();
	}

	// Token: 0x060071D2 RID: 29138 RVA: 0x001DAF24 File Offset: 0x001D9124
	public void EnterGame(JokerGuessInitGame response, int levelId, string serverTime)
	{
		if (ModelBase<SpringManorModel>.Instance.ActivityData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker进入游戏失败：活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.InGamePlay)
		{
			Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker进入游戏失败：游戏已经开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.InitGame();
		this.InitData(response, levelId, serverTime);
		this.InitStateMachine();
		this.ChangeState(EGuessJokerCardStateType.GameStart);
		this.InitTimerSystem();
	}

	// Token: 0x060071D3 RID: 29139 RVA: 0x001DAFA7 File Offset: 0x001D91A7
	public void NextRound()
	{
		this.RoundNumber++;
		this.RoundStartTipShownMap.Clear();
	}

	// Token: 0x060071D4 RID: 29140 RVA: 0x001DAFC4 File Offset: 0x001D91C4
	public UniTask RematchGame(JokerGuessInitGame response, int levelId, string serverTime)
	{
		GuessJokerGamePlayModel.<RematchGame>d__34 <RematchGame>d__;
		<RematchGame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RematchGame>d__.<>4__this = this;
		<RematchGame>d__.response = response;
		<RematchGame>d__.levelId = levelId;
		<RematchGame>d__.serverTime = serverTime;
		<RematchGame>d__.<>1__state = -1;
		<RematchGame>d__.<>t__builder.Start<GuessJokerGamePlayModel.<RematchGame>d__34>(ref <RematchGame>d__);
		return <RematchGame>d__.<>t__builder.Task;
	}

	// Token: 0x060071D5 RID: 29141 RVA: 0x001DB01F File Offset: 0x001D921F
	public void ExitGame()
	{
		if (this.IsExit)
		{
			return;
		}
		this.IsExit = true;
		this.ChangeState(EGuessJokerCardStateType.GameExit);
	}

	// Token: 0x060071D6 RID: 29142 RVA: 0x001DB038 File Offset: 0x001D9238
	public void GameEnd()
	{
		this.SetNpcPokerState(EPokerStateType.Idel);
		Singleton<UiCameraAnimationManager>.Instance.EnablePlayerActor();
		this.ClearData();
	}

	// Token: 0x060071D7 RID: 29143 RVA: 0x001DB052 File Offset: 0x001D9252
	public void SettleGameClear()
	{
		this.InGamePlay = false;
	}

	// Token: 0x1700094C RID: 2380
	// (get) Token: 0x060071D8 RID: 29144 RVA: 0x001DB05B File Offset: 0x001D925B
	public bool InGame
	{
		get
		{
			return this.InGamePlay;
		}
	}

	// Token: 0x060071D9 RID: 29145 RVA: 0x001DB064 File Offset: 0x001D9264
	public unsafe void InitData(JokerGuessInitGame gameData, int levelId, string serverTime)
	{
		this.LevelId = levelId;
		this.S_Track_Id = serverTime;
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId);
		if (jokerLevelById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJoker初始化数据失败：关卡配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelId", levelId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.RoleId = jokerLevelById.Value.AiRole;
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.GuessJokerCard;
		ELogAuthor author2 = ELogAuthor.LRC;
		string message2 = "GuessJoker初始化Npc roleId";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("levelId", levelId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RoleId", this.RoleId);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (gameData.AiHandCards != null && gameData.AiHandCards.CardIds != null)
		{
			foreach (int num in gameData.AiHandCards.CardIds)
			{
				GuessJokerCardData guessJokerCardData = new GuessJokerCardData(num);
				guessJokerCardData.SetBelongPlayerType(new EGuessJokerPlayerType?(EGuessJokerPlayerType.Ai));
				this.CardDataMap[num] = guessJokerCardData;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.GuessJokerCard;
			ELogAuthor author3 = ELogAuthor.LRC;
			string message3 = "GuessJoker初始化AI手牌";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("cardIdList", string.Join<int>(",", gameData.AiHandCards.CardIds));
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		if (gameData.PlayerHandCards != null && gameData.PlayerHandCards.CardIds != null)
		{
			foreach (int num2 in gameData.PlayerHandCards.CardIds)
			{
				GuessJokerCardData guessJokerCardData2 = new GuessJokerCardData(num2);
				guessJokerCardData2.SetBelongPlayerType(new EGuessJokerPlayerType?(EGuessJokerPlayerType.Me));
				this.CardDataMap[num2] = guessJokerCardData2;
			}
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.GuessJokerCard;
			ELogAuthor author4 = ELogAuthor.LRC;
			string message4 = "GuessJoker初始化玩家手牌";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("cardIdList", string.Join<int>(",", gameData.PlayerHandCards.CardIds));
			instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		}
		this.RoundNumber = 0;
		this.FirstPlayerTurn = GuessJokerUtils.ServerPlayerTransToClient(gameData.FirstActor);
		int initHP = jokerLevelById.Value.InitHP;
		this.AiRoleData = new GuessJokerRoleData(EGuessJokerPlayerType.Ai, initHP);
		this.PlayerRoleData = new GuessJokerRoleData(EGuessJokerPlayerType.Me, initHP);
		IGuessJokerLevelInfo guessJokerGameData = ModelBase<SpringManorModel>.Instance.ActivityData.GetGuessJokerGameData(this.LevelId);
		this.IsFinish = (guessJokerGameData != null && guessJokerGameData.FirstPass);
		this.ShowInitialNoPairTip = (!this.CheckPlayerHasPair(EGuessJokerPlayerType.Ai) || !this.CheckPlayerHasPair(EGuessJokerPlayerType.Me));
	}

	// Token: 0x060071DA RID: 29146 RVA: 0x001DB348 File Offset: 0x001D9548
	public GuessJokerCardData GetBlankCardData()
	{
		foreach (GuessJokerCardData guessJokerCardData in this.CardDataMap.Values)
		{
			if (guessJokerCardData.Type == EGuessJokerCardType.Blank)
			{
				return guessJokerCardData;
			}
		}
		return null;
	}

	// Token: 0x060071DB RID: 29147 RVA: 0x001DB3AC File Offset: 0x001D95AC
	public int GetJokerCardId()
	{
		foreach (GuessJokerCardData guessJokerCardData in this.CardDataMap.Values)
		{
			if (guessJokerCardData.Type == EGuessJokerCardType.Joker)
			{
				return guessJokerCardData.Id;
			}
		}
		Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker获取鬼牌失败：鬼牌数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
		return -1;
	}

	// Token: 0x060071DC RID: 29148 RVA: 0x001DB434 File Offset: 0x001D9634
	public void RemoveCardData(int[] cardIdList)
	{
		foreach (int key in cardIdList)
		{
			GuessJokerCardData guessJokerCardData;
			if (this.CardDataMap.TryGetValue(key, out guessJokerCardData))
			{
				this.CardDataMap.Remove(key);
			}
		}
	}

	// Token: 0x060071DD RID: 29149 RVA: 0x001DB474 File Offset: 0x001D9674
	public void ClearData()
	{
		this.InGamePlay = false;
		this.IsExit = false;
		this.CardDataMap.Clear();
		GuessJokerActionRunner<GuessJokerActionBase> actionRunner = this.ActionRunner;
		if (actionRunner != null)
		{
			actionRunner.Destroy();
		}
		this.ActionRunner = null;
		GuessJokerPlotActionRunner plotActionRunner = this.PlotActionRunner;
		if (plotActionRunner != null)
		{
			plotActionRunner.Destroy();
		}
		this.PlotActionRunner = null;
		this.ClearTimerHandle();
		this.AiRoleData = null;
		this.PlayerRoleData = null;
		this.ShowInitialNoPairTip = true;
		this.RoleId = -1;
		this.S_Track_Id = "";
		this.LastUsedPlotIdMap.Clear();
		GuessJokerDialogLogic activeDialogLogic = this.ActiveDialogLogic;
		if (activeDialogLogic != null)
		{
			activeDialogLogic.Clear();
		}
		this.ActiveDialogLogic = null;
		this.PlayerDrawnCardId = null;
		this.AiDrawnCardId = null;
		this.GuessJokerFsm = null;
	}

	// Token: 0x060071DE RID: 29150 RVA: 0x001DB539 File Offset: 0x001D9739
	private void InitTimerSystem()
	{
		if (this.GamePlayTimerHandle != null)
		{
			this.ClearTimerHandle();
		}
		this.GamePlayTimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.GamePlayTick), 20f, 1f, null, null, true);
	}

	// Token: 0x060071DF RID: 29151 RVA: 0x001DB572 File Offset: 0x001D9772
	private void GamePlayTick(float deltaTime)
	{
		this.GuessJokerFsm.Tick(deltaTime);
		GuessJokerActionRunner<GuessJokerActionBase> actionRunner = this.ActionRunner;
		if (actionRunner != null)
		{
			actionRunner.Tick(deltaTime);
		}
		GuessJokerPlotActionRunner plotActionRunner = this.PlotActionRunner;
		if (plotActionRunner == null)
		{
			return;
		}
		plotActionRunner.Tick(deltaTime);
	}

	// Token: 0x060071E0 RID: 29152 RVA: 0x001DB5A3 File Offset: 0x001D97A3
	private void NpcSitTick(float deltaTime)
	{
		this.ProcessPendingNpcSit();
	}

	// Token: 0x060071E1 RID: 29153 RVA: 0x001DB5AC File Offset: 0x001D97AC
	private void ClearTimerHandle()
	{
		if (this.GamePlayTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.GamePlayTimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.GamePlayTimerHandle);
			this.GamePlayTimerHandle = null;
		}
		if (this.NpcSitTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.NpcSitTimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.NpcSitTimerHandle);
			this.NpcSitTimerHandle = null;
		}
	}

	// Token: 0x060071E2 RID: 29154 RVA: 0x001DB61D File Offset: 0x001D981D
	public void InitStateMachine()
	{
		this.GuessJokerFsm = new GuessJokerStageFsm();
		this.GuessJokerFsm.Init();
	}

	// Token: 0x060071E3 RID: 29155 RVA: 0x001DB635 File Offset: 0x001D9835
	public void ChangeState(EGuessJokerCardStateType state)
	{
		this.GuessJokerFsm.ChangeState(state);
	}

	// Token: 0x060071E4 RID: 29156 RVA: 0x001DB644 File Offset: 0x001D9844
	public void OpenGamePlayView(Action finishCallback = null)
	{
		Singleton<UiCameraAnimationManager>.Instance.DisablePlayerActor();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GuessJokerGamePlayView, this.EntityId, delegate(bool isSuccess, int viewId)
		{
			if (!isSuccess)
			{
				Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker打开游戏界面失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ExitGame();
				return;
			}
			this.GamePlayView = (Singleton<UiManager>.Instance.GetView(viewId) as GuessJokerGamePlayView);
			if (this.ActionRunner == null)
			{
				this.ActionRunner = new GuessJokerActionRunner<GuessJokerActionBase>();
			}
			if (this.PlotActionRunner == null)
			{
				this.PlotActionRunner = new GuessJokerPlotActionRunner();
			}
			this.SetNpcPokerState(EPokerStateType.Idel);
			Action finishCallback2 = finishCallback;
			if (finishCallback2 == null)
			{
				return;
			}
			finishCallback2();
		});
	}

	// Token: 0x060071E5 RID: 29157 RVA: 0x001DB698 File Offset: 0x001D9898
	public UniTask CloseGamePlayViewAsync()
	{
		GuessJokerGamePlayModel.<CloseGamePlayViewAsync>d__52 <CloseGamePlayViewAsync>d__;
		<CloseGamePlayViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseGamePlayViewAsync>d__.<>4__this = this;
		<CloseGamePlayViewAsync>d__.<>1__state = -1;
		<CloseGamePlayViewAsync>d__.<>t__builder.Start<GuessJokerGamePlayModel.<CloseGamePlayViewAsync>d__52>(ref <CloseGamePlayViewAsync>d__);
		return <CloseGamePlayViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060071E6 RID: 29158 RVA: 0x001DB6DC File Offset: 0x001D98DC
	public GuessJokerGamePlayView GetGamePlayView()
	{
		if (this.GamePlayView == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker获取游戏界面失败：游戏界面未打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.GamePlayView;
	}

	// Token: 0x060071E7 RID: 29159 RVA: 0x001DB718 File Offset: 0x001D9918
	public void PushActions(IReadOnlyList<GuessJokerActionBase> actions)
	{
		if (this.ActionRunner == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker PushActions Fail：ActionRunner is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.ActionRunner.PushActions(actions);
	}

	// Token: 0x060071E8 RID: 29160 RVA: 0x001DB75C File Offset: 0x001D995C
	public void PushPlotActions(GuessJokerPlotAction[] actions)
	{
		if (this.PlotActionRunner == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker PushPlotActions Fail：PlotActionRunner is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.PlotActionRunner.PushPlotActions(actions);
	}

	// Token: 0x060071E9 RID: 29161 RVA: 0x001DB79D File Offset: 0x001D999D
	public void SetWinner(JokerGuessActor winner)
	{
		this.Winner = GuessJokerUtils.ServerPlayerTransToClient(winner);
	}

	// Token: 0x060071EA RID: 29162 RVA: 0x001DB7AB File Offset: 0x001D99AB
	public EGuessJokerPlayerType GetWinner()
	{
		return this.Winner;
	}

	// Token: 0x060071EB RID: 29163 RVA: 0x001DB7B3 File Offset: 0x001D99B3
	public int GetLevelId()
	{
		return this.LevelId;
	}

	// Token: 0x060071EC RID: 29164 RVA: 0x001DB7BB File Offset: 0x001D99BB
	public void UpdateTaskData(IEnumerable<JokerGuessOp> taskList)
	{
		this.TaskDataList.Clear();
		this.TaskDataList.AddRange(taskList);
		Singleton<EventSystem>.Instance.Emit(EEventName.GuessJokerCardUpdateTaskData);
	}

	// Token: 0x060071ED RID: 29165 RVA: 0x001DB7E4 File Offset: 0x001D99E4
	public List<JokerGuessOp> GetTaskDataList()
	{
		List<JokerGuessOp> result = new List<JokerGuessOp>(this.TaskDataList);
		this.TaskDataList.Clear();
		return result;
	}

	// Token: 0x060071EE RID: 29166 RVA: 0x001DB7FC File Offset: 0x001D99FC
	private bool CheckPlayerHasPair(EGuessJokerPlayerType playerType)
	{
		List<GuessJokerCardData> handCardsByPlayer = this.GetHandCardsByPlayer(playerType);
		HashSet<int> hashSet = new HashSet<int>();
		foreach (GuessJokerCardData guessJokerCardData in handCardsByPlayer)
		{
			int value = guessJokerCardData.Value;
			if (hashSet.Contains(value))
			{
				return true;
			}
			hashSet.Add(value);
		}
		return false;
	}

	// Token: 0x060071EF RID: 29167 RVA: 0x001DB870 File Offset: 0x001D9A70
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x1700094D RID: 2381
	// (get) Token: 0x060071F0 RID: 29168 RVA: 0x001DB878 File Offset: 0x001D9A78
	public int EntityId
	{
		get
		{
			GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(this.RoleId);
			if (jokerAiConfigByRoleId == null)
			{
				return -1;
			}
			return jokerAiConfigByRoleId.Value.NpcId;
		}
	}

	// Token: 0x060071F1 RID: 29169 RVA: 0x001DB8B0 File Offset: 0x001D9AB0
	public GuessJokerRoleData GetRoleData(EGuessJokerPlayerType playerType)
	{
		if (playerType == EGuessJokerPlayerType.Ai)
		{
			if (this.AiRoleData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker获取角色数据失败：AI角色数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.AiRoleData;
		}
		else
		{
			if (this.PlayerRoleData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker获取角色数据失败：玩家角色数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.PlayerRoleData;
		}
	}

	// Token: 0x060071F2 RID: 29170 RVA: 0x001DB920 File Offset: 0x001D9B20
	public void UpdateHp(EGuessJokerPlayerType playerType, int value)
	{
		this.GetRoleData(playerType).SetHp(value);
	}

	// Token: 0x060071F3 RID: 29171 RVA: 0x001DB930 File Offset: 0x001D9B30
	public List<IPlayCardInfo> GetPlayerPlayCardIdList()
	{
		List<GuessJokerCardData> handCardsByPlayer = this.GetHandCardsByPlayer(EGuessJokerPlayerType.Me);
		Dictionary<int, List<GuessJokerCardData>> dictionary = new Dictionary<int, List<GuessJokerCardData>>();
		foreach (GuessJokerCardData guessJokerCardData in handCardsByPlayer)
		{
			int value = guessJokerCardData.Value;
			if (!dictionary.ContainsKey(value))
			{
				dictionary[value] = new List<GuessJokerCardData>();
			}
			dictionary[value].Add(guessJokerCardData);
		}
		List<IPlayCardInfo> list = new List<IPlayCardInfo>();
		foreach (KeyValuePair<int, List<GuessJokerCardData>> keyValuePair in dictionary)
		{
			List<GuessJokerCardData> value2 = keyValuePair.Value;
			int count = value2.Count;
			if (count >= 2)
			{
				if (count > 2)
				{
					for (int i = value2.Count - 1; i >= 0; i--)
					{
						if (value2[i].Type == EGuessJokerCardType.Blank)
						{
							value2.RemoveAt(i);
						}
					}
				}
				List<int> list2 = new List<int>();
				foreach (GuessJokerCardData guessJokerCardData2 in value2)
				{
					list2.Add(guessJokerCardData2.Id);
				}
				list.Add(new PlayCardInfo
				{
					Value = keyValuePair.Key,
					CardIdList = list2.ToArray()
				});
			}
		}
		return list;
	}

	// Token: 0x060071F4 RID: 29172 RVA: 0x001DBAB8 File Offset: 0x001D9CB8
	public List<GuessJokerCardData> GetAllCardDataList()
	{
		return new List<GuessJokerCardData>(this.CardDataMap.Values);
	}

	// Token: 0x060071F5 RID: 29173 RVA: 0x001DBACC File Offset: 0x001D9CCC
	public GuessJokerCardData GetCardDataById(int cardId)
	{
		GuessJokerCardData result;
		if (!this.CardDataMap.TryGetValue(cardId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x060071F6 RID: 29174 RVA: 0x001DBAEC File Offset: 0x001D9CEC
	public List<GuessJokerCardData> QueryCards(Func<GuessJokerCardData, bool> predicate)
	{
		List<GuessJokerCardData> list = new List<GuessJokerCardData>();
		foreach (GuessJokerCardData guessJokerCardData in this.CardDataMap.Values)
		{
			if (predicate(guessJokerCardData))
			{
				list.Add(guessJokerCardData);
			}
		}
		return list;
	}

	// Token: 0x060071F7 RID: 29175 RVA: 0x001DBB54 File Offset: 0x001D9D54
	public List<GuessJokerCardData> GetHandCardsByPlayer(EGuessJokerPlayerType playerType)
	{
		return this.QueryCards(delegate(GuessJokerCardData card)
		{
			EGuessJokerPlayerType? belongPlayerType = card.GetBelongPlayerType();
			EGuessJokerPlayerType playerType2 = playerType;
			return belongPlayerType.GetValueOrDefault() == playerType2 & belongPlayerType != null;
		});
	}

	// Token: 0x060071F8 RID: 29176 RVA: 0x001DBB80 File Offset: 0x001D9D80
	public List<GuessJokerCardData> GetAllCardsByPlayer(EGuessJokerPlayerType playerType)
	{
		return this.QueryCards(delegate(GuessJokerCardData card)
		{
			EGuessJokerPlayerType? belongPlayerType = card.GetBelongPlayerType();
			EGuessJokerPlayerType playerType2 = playerType;
			return belongPlayerType.GetValueOrDefault() == playerType2 & belongPlayerType != null;
		});
	}

	// Token: 0x060071F9 RID: 29177 RVA: 0x001DBBAC File Offset: 0x001D9DAC
	public void UpdateCardBelongPlayerType(int[] cardIdList, EGuessJokerPlayerType? playerType = null)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GuessJokerCard;
		ELogAuthor author = ELogAuthor.LRC;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
		defaultInterpolatedStringHandler.AppendLiteral("更新卡牌归属玩家类型：");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<int>(",", cardIdList));
		defaultInterpolatedStringHandler.AppendLiteral(", ");
		defaultInterpolatedStringHandler.AppendFormatted<EGuessJokerPlayerType?>(playerType);
		instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		foreach (int key in cardIdList)
		{
			GuessJokerCardData guessJokerCardData;
			if (this.CardDataMap.TryGetValue(key, out guessJokerCardData))
			{
				guessJokerCardData.SetBelongPlayerType(playerType);
			}
		}
	}

	// Token: 0x060071FA RID: 29178 RVA: 0x001DBC44 File Offset: 0x001D9E44
	public int GetLevelIdByNpcId(int npcId)
	{
		GuessJokerLevel? jokerLevelByNpcId = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelByNpcId(npcId);
		if (jokerLevelByNpcId == null)
		{
			return -1;
		}
		return jokerLevelByNpcId.GetValueOrDefault().Id;
	}

	// Token: 0x060071FB RID: 29179 RVA: 0x001DBC78 File Offset: 0x001D9E78
	public int? GetLastUsedPlotId(int aiPlotConfigId)
	{
		int value;
		if (!this.LastUsedPlotIdMap.TryGetValue(aiPlotConfigId, out value))
		{
			return null;
		}
		return new int?(value);
	}

	// Token: 0x060071FC RID: 29180 RVA: 0x001DBCA5 File Offset: 0x001D9EA5
	public void SetLastUsedPlotId(int aiPlotConfigId, int plotId)
	{
		this.LastUsedPlotIdMap[aiPlotConfigId] = plotId;
	}

	// Token: 0x060071FD RID: 29181 RVA: 0x001DBCB4 File Offset: 0x001D9EB4
	public bool CheckBlankCardDisable()
	{
		using (Dictionary<int, GuessJokerCardData>.ValueCollection.Enumerator enumerator = this.CardDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Type == EGuessJokerCardType.Blank)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060071FE RID: 29182 RVA: 0x001DBD14 File Offset: 0x001D9F14
	public int GetAiSkillId()
	{
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(this.LevelId);
		if (jokerLevelById == null)
		{
			return -1;
		}
		return jokerLevelById.GetValueOrDefault().AiCardSkill;
	}

	// Token: 0x060071FF RID: 29183 RVA: 0x001DBD4C File Offset: 0x001D9F4C
	public void MarkRoundStartTipShown(EGuessJokerPlayerType playerType)
	{
		this.RoundStartTipShownMap[playerType] = true;
	}

	// Token: 0x06007200 RID: 29184 RVA: 0x001DBD5C File Offset: 0x001D9F5C
	public bool HasShownRoundStartTip(EGuessJokerPlayerType playerType)
	{
		bool flag;
		return this.RoundStartTipShownMap.TryGetValue(playerType, out flag) && flag;
	}

	// Token: 0x06007201 RID: 29185 RVA: 0x001DBD7C File Offset: 0x001D9F7C
	public bool IsInFirstTutorial()
	{
		if (!this.InGamePlay)
		{
			return false;
		}
		if (this.LevelId != 1010)
		{
			return false;
		}
		IGuessJokerLevelInfo guessJokerGameData = ModelBase<SpringManorModel>.Instance.ActivityData.GetGuessJokerGameData(this.LevelId);
		return guessJokerGameData != null && !guessJokerGameData.FirstPass;
	}

	// Token: 0x06007202 RID: 29186 RVA: 0x001DBDC8 File Offset: 0x001D9FC8
	public string GetPlayerNameByType(EGuessJokerPlayerType playerType)
	{
		if (playerType == EGuessJokerPlayerType.Me)
		{
			return ModelBase<FunctionModel>.Instance.GetPlayerName();
		}
		int roleId = this.GetRoleId();
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig != null)
		{
			string name = roleConfig.Value.Name;
			return ConfigMultiTextLang.GetLocalTextNew(name, null) ?? name;
		}
		return "";
	}

	// Token: 0x06007203 RID: 29187 RVA: 0x001DBE24 File Offset: 0x001DA024
	public bool EnterNpcPokerState(int npcPbDataId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(npcPbDataId);
		if (entityByPbDataId == null || entityByPbDataId.Entity == null)
		{
			return false;
		}
		CharacterLinkedAnimInstComponent component = entityByPbDataId.Entity.GetComponent<CharacterLinkedAnimInstComponent>();
		if (component != null)
		{
			component.SyncLinkGameplayAnimBlueprint(EGameplayABPType.Poker);
		}
		BaseMoveComponent component2 = entityByPbDataId.Entity.GetComponent<BaseMoveComponent>();
		if (component2 == null)
		{
			return false;
		}
		component2.IsRegionMoveMode = true;
		CharacterActorComponent component3 = entityByPbDataId.Entity.GetComponent<CharacterActorComponent>();
		USkeletalMeshComponent uskeletalMeshComponent;
		if (component3 == null)
		{
			uskeletalMeshComponent = null;
		}
		else
		{
			TsBaseCharacter actor = component3.Actor;
			uskeletalMeshComponent = ((actor != null) ? actor.Mesh : null);
		}
		USkeletalMeshComponent uskeletalMeshComponent2 = uskeletalMeshComponent;
		if (uskeletalMeshComponent2 == null)
		{
			return false;
		}
		ABP_BaseRole_Gameplay_Poker_C abp_BaseRole_Gameplay_Poker_C = uskeletalMeshComponent2.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_GAMEPLAY) as ABP_BaseRole_Gameplay_Poker_C;
		if (abp_BaseRole_Gameplay_Poker_C == null)
		{
			return false;
		}
		abp_BaseRole_Gameplay_Poker_C.SetPokerState(EPokerStateType.Idel);
		return true;
	}

	// Token: 0x06007204 RID: 29188 RVA: 0x001DBEC8 File Offset: 0x001DA0C8
	public bool SetNpcPokerState(EPokerStateType state)
	{
		ABP_BaseRole_Gameplay_Poker_C npcAnimInst = this.GetNpcAnimInst(this.EntityId);
		if (npcAnimInst == null)
		{
			return false;
		}
		if (state == EPokerStateType.BeChosenCardStrong || state == EPokerStateType.BeChosenCardWeak)
		{
			int beChooseEmotionIndex = new Random().Next(2);
			npcAnimInst.SetBeChooseEmotionIndex(beChooseEmotionIndex);
		}
		npcAnimInst.SetPokerState(state);
		return true;
	}

	// Token: 0x06007205 RID: 29189 RVA: 0x001DBF0C File Offset: 0x001DA10C
	public void SetNpcEnterInteractiveStage(bool isInteractive)
	{
		ABP_BaseRole_Gameplay_Poker_C npcAnimInst = this.GetNpcAnimInst(this.EntityId);
		if (npcAnimInst == null)
		{
			return;
		}
		npcAnimInst.SetPlayerInteractiveStage(isInteractive);
	}

	// Token: 0x06007206 RID: 29190 RVA: 0x001DBF34 File Offset: 0x001DA134
	public void UpdateNpcIdleState()
	{
		List<GuessJokerCardData> handCardsByPlayer = this.GetHandCardsByPlayer(EGuessJokerPlayerType.Ai);
		List<GuessJokerCardData> handCardsByPlayer2 = this.GetHandCardsByPlayer(EGuessJokerPlayerType.Me);
		int count = handCardsByPlayer.Count;
		int count2 = handCardsByPlayer2.Count;
		bool flag = false;
		using (List<GuessJokerCardData>.Enumerator enumerator = handCardsByPlayer.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Type == EGuessJokerCardType.Joker)
				{
					flag = true;
					break;
				}
			}
		}
		EPokerIdleState npcIdleState;
		if (count2 > 4)
		{
			npcIdleState = EPokerIdleState.Normal;
		}
		else if (count2 < 4 && flag)
		{
			npcIdleState = EPokerIdleState.Disadvantage;
		}
		else if (count < 4 && flag)
		{
			npcIdleState = EPokerIdleState.Advantage;
		}
		else
		{
			npcIdleState = EPokerIdleState.Normal;
		}
		this.SetNpcIdleState(npcIdleState);
	}

	// Token: 0x06007207 RID: 29191 RVA: 0x001DBFD8 File Offset: 0x001DA1D8
	public bool SetNpcIdleState(EPokerIdleState state)
	{
		ABP_BaseRole_Gameplay_Poker_C npcAnimInst = this.GetNpcAnimInst(this.EntityId);
		if (npcAnimInst == null)
		{
			return false;
		}
		npcAnimInst.SetPokerIdleState(state);
		return true;
	}

	// Token: 0x06007208 RID: 29192 RVA: 0x001DC000 File Offset: 0x001DA200
	public unsafe ABP_BaseRole_Gameplay_Poker_C GetNpcAnimInst(int entityId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId);
		if (entityByPbDataId == null || entityByPbDataId.Entity == null)
		{
			return null;
		}
		CharacterActorComponent component = entityByPbDataId.Entity.GetComponent<CharacterActorComponent>();
		USkeletalMeshComponent uskeletalMeshComponent;
		if (component == null)
		{
			uskeletalMeshComponent = null;
		}
		else
		{
			TsBaseCharacter actor = component.Actor;
			uskeletalMeshComponent = ((actor != null) ? actor.Mesh : null);
		}
		USkeletalMeshComponent uskeletalMeshComponent2 = uskeletalMeshComponent;
		if (uskeletalMeshComponent2 == null)
		{
			return null;
		}
		ABP_BaseRole_Gameplay_Poker_C abp_BaseRole_Gameplay_Poker_C = uskeletalMeshComponent2.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_GAMEPLAY) as ABP_BaseRole_Gameplay_Poker_C;
		if (abp_BaseRole_Gameplay_Poker_C == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJoker获取NPC动画实例失败：动画实例不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AnimInstance", (abp_BaseRole_Gameplay_Poker_C != null) ? "存在" : "不存在");
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return abp_BaseRole_Gameplay_Poker_C;
	}

	// Token: 0x06007209 RID: 29193 RVA: 0x001DC0D4 File Offset: 0x001DA2D4
	public List<int> GetLevelIdList()
	{
		IEnumerable<GuessJokerLevel> jokerLevelList = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelList();
		List<int> list = new List<int>();
		foreach (GuessJokerLevel guessJokerLevel in jokerLevelList)
		{
			list.Add(guessJokerLevel.Id);
		}
		if (list.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJoker获取关卡ID列表失败：关卡配置表为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<int>();
		}
		return list;
	}

	// Token: 0x0600720A RID: 29194 RVA: 0x001DC160 File Offset: 0x001DA360
	public void SetActiveDialogLogic(GuessJokerDialogLogic logic)
	{
		this.ActiveDialogLogic = logic;
	}

	// Token: 0x0600720B RID: 29195 RVA: 0x001DC169 File Offset: 0x001DA369
	public GuessJokerDialogLogic GetActiveDialogLogic()
	{
		return this.ActiveDialogLogic;
	}

	// Token: 0x0600720C RID: 29196 RVA: 0x001DC171 File Offset: 0x001DA371
	public void SetPlayerDrawnCard(int cardId)
	{
		this.PlayerDrawnCardId = new int?(cardId);
	}

	// Token: 0x0600720D RID: 29197 RVA: 0x001DC17F File Offset: 0x001DA37F
	public void SetAiDrawnCard(int cardId)
	{
		this.AiDrawnCardId = new int?(cardId);
	}

	// Token: 0x0600720E RID: 29198 RVA: 0x001DC190 File Offset: 0x001DA390
	public bool HasPlayerNewCardInHand()
	{
		if (this.PlayerDrawnCardId == null)
		{
			return false;
		}
		GuessJokerCardData guessJokerCardData2;
		GuessJokerCardData guessJokerCardData = this.CardDataMap.TryGetValue(this.PlayerDrawnCardId.Value, out guessJokerCardData2) ? guessJokerCardData2 : null;
		if (guessJokerCardData != null)
		{
			EGuessJokerPlayerType? belongPlayerType = guessJokerCardData.GetBelongPlayerType();
			EGuessJokerPlayerType eguessJokerPlayerType = EGuessJokerPlayerType.Me;
			return belongPlayerType.GetValueOrDefault() == eguessJokerPlayerType & belongPlayerType != null;
		}
		return false;
	}

	// Token: 0x0600720F RID: 29199 RVA: 0x001DC1EC File Offset: 0x001DA3EC
	public bool HasAiNewCardInHand()
	{
		if (this.AiDrawnCardId == null)
		{
			return false;
		}
		GuessJokerCardData guessJokerCardData2;
		GuessJokerCardData guessJokerCardData = this.CardDataMap.TryGetValue(this.AiDrawnCardId.Value, out guessJokerCardData2) ? guessJokerCardData2 : null;
		return guessJokerCardData != null && guessJokerCardData.GetBelongPlayerType().GetValueOrDefault() == EGuessJokerPlayerType.Ai;
	}

	// Token: 0x06007210 RID: 29200 RVA: 0x001DC23D File Offset: 0x001DA43D
	public void ClearPlayerDrawnCard()
	{
		this.PlayerDrawnCardId = null;
	}

	// Token: 0x06007211 RID: 29201 RVA: 0x001DC24B File Offset: 0x001DA44B
	public void ClearAiDrawnCard()
	{
		this.AiDrawnCardId = null;
	}

	// Token: 0x06007212 RID: 29202 RVA: 0x001DC25C File Offset: 0x001DA45C
	public void EnableGuessJokerNpcSit(int pdDataId)
	{
		int num = 0;
		int num2 = 0;
		foreach (IGuessJokerNpcAndChairInfo guessJokerNpcAndChairInfo in ConfigBase<GuessJokerConfig>.Instance.GetNpcAndChairMatchInfo())
		{
			if (guessJokerNpcAndChairInfo.NpcId == pdDataId || guessJokerNpcAndChairInfo.ChairId == pdDataId)
			{
				num = guessJokerNpcAndChairInfo.ChairId;
				num2 = guessJokerNpcAndChairInfo.NpcId;
				break;
			}
		}
		if (num == 0 || num2 == 0)
		{
			return;
		}
		this.PendingNpcSitSet.Add(num2);
		if (this.NpcSitTimerHandle == null)
		{
			this.NpcSitTimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.NpcSitTick), 20f, 1f, null, null, true);
		}
	}

	// Token: 0x06007213 RID: 29203 RVA: 0x001DC318 File Offset: 0x001DA518
	private void ProcessPendingNpcSit()
	{
		if (this.PendingNpcSitSet.Count == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (int num in this.PendingNpcSitSet)
		{
			List<IGuessJokerNpcAndChairInfo> npcAndChairMatchInfo = ConfigBase<GuessJokerConfig>.Instance.GetNpcAndChairMatchInfo();
			int num2 = 0;
			foreach (IGuessJokerNpcAndChairInfo guessJokerNpcAndChairInfo in npcAndChairMatchInfo)
			{
				if (guessJokerNpcAndChairInfo.NpcId == num)
				{
					num2 = guessJokerNpcAndChairInfo.ChairId;
					break;
				}
			}
			if (num2 == 0)
			{
				list.Add(num);
			}
			else if (this.CheckNpcIsReady(num) && this.CheckChairIsReady(num2))
			{
				this.GuessJokerDoSitDown(num, num2);
				list.Add(num);
			}
		}
		foreach (int item in list)
		{
			this.PendingNpcSitSet.Remove(item);
		}
		if (this.PendingNpcSitSet.Count == 0 && this.NpcSitTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.NpcSitTimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.NpcSitTimerHandle);
			this.NpcSitTimerHandle = null;
		}
	}

	// Token: 0x06007214 RID: 29204 RVA: 0x001DC488 File Offset: 0x001DA688
	private bool CheckNpcIsReady(int npcPbDataId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(npcPbDataId);
		WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
		return worldEntity != null && ((worldEntity != null) ? worldEntity.GetComponent<NpcSitOnChairComponent>() : null) != null;
	}

	// Token: 0x06007215 RID: 29205 RVA: 0x001DC4C4 File Offset: 0x001DA6C4
	private bool CheckChairIsReady(int chairPbDataId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(chairPbDataId);
		WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
		if (worldEntity == null)
		{
			return false;
		}
		PawnInteractNewComponent component = worldEntity.GetComponent<PawnInteractNewComponent>();
		if (component == null)
		{
			return false;
		}
		PawnChairController pawnChairController = component.GetSubEntityInteractLogicController() as PawnChairController;
		return pawnChairController != null && pawnChairController.IsSceneInteractionLoadCompleted();
	}

	// Token: 0x06007216 RID: 29206 RVA: 0x001DC514 File Offset: 0x001DA714
	public void GuessJokerDoSitDown(int npcPbDataId, int chairPbDataId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(npcPbDataId);
		WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
		if (worldEntity == null)
		{
			return;
		}
		NpcSitOnChairComponent npcSitOnChairComponent = (worldEntity != null) ? worldEntity.GetComponent<NpcSitOnChairComponent>() : null;
		EntityHandle entityByPbDataId2 = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(chairPbDataId);
		WorldEntity worldEntity2 = (entityByPbDataId2 != null) ? entityByPbDataId2.Entity : null;
		if (npcSitOnChairComponent != null && worldEntity2 != null)
		{
			PawnInteractNewComponent component = worldEntity2.GetComponent<PawnInteractNewComponent>();
			PawnChairController pawnChairController = ((component != null) ? component.GetSubEntityInteractLogicController() : null) as PawnChairController;
			if (pawnChairController == null || !pawnChairController.IsSceneInteractionLoadCompleted())
			{
				return;
			}
			if (pawnChairController != null)
			{
				pawnChairController.Possess(worldEntity, false);
			}
			if (pawnChairController != null)
			{
				pawnChairController.IgnoreCollision();
			}
			npcSitOnChairComponent.DoSitDownAction(worldEntity2);
			CharacterAnimationComponent component2 = worldEntity.GetComponent<CharacterAnimationComponent>();
			ABP_BaseRoleNPC_C abp_BaseRoleNPC_C = ((component2 != null) ? component2.MainAnimInstance : null) as ABP_BaseRoleNPC_C;
			if (((abp_BaseRoleNPC_C != null) ? abp_BaseRoleNPC_C.LogicParams : null) != null)
			{
				abp_BaseRoleNPC_C.LogicParams.SitDownType = 1;
				abp_BaseRoleNPC_C.LogicParams.bSitDown = true;
			}
			this.EnterNpcPokerState(npcPbDataId);
		}
	}

	// Token: 0x06007217 RID: 29207 RVA: 0x001DC5FC File Offset: 0x001DA7FC
	public List<int> GetAllGuessJokerNpcIds()
	{
		IEnumerable<GuessJokerLevel> jokerLevelList = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelList();
		List<int> list = new List<int>();
		foreach (GuessJokerLevel guessJokerLevel in jokerLevelList)
		{
			GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(guessJokerLevel.AiRole);
			if (jokerAiConfigByRoleId != null)
			{
				list.Add(jokerAiConfigByRoleId.Value.NpcId);
			}
		}
		return list;
	}

	// Token: 0x06007218 RID: 29208 RVA: 0x001DC680 File Offset: 0x001DA880
	public bool CheckIsGuessJokerEntityId(int entityId)
	{
		bool result = false;
		foreach (IGuessJokerNpcAndChairInfo guessJokerNpcAndChairInfo in ConfigBase<GuessJokerConfig>.Instance.GetNpcAndChairMatchInfo())
		{
			if (guessJokerNpcAndChairInfo.NpcId == entityId || guessJokerNpcAndChairInfo.ChairId == entityId)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06007219 RID: 29209 RVA: 0x001DC6EC File Offset: 0x001DA8EC
	public void HideAllGuessJokerNpc()
	{
		foreach (int npcId in this.GetAllGuessJokerNpcIds())
		{
			this.HideGuessJokerNpc(npcId);
		}
	}

	// Token: 0x0600721A RID: 29210 RVA: 0x001DC740 File Offset: 0x001DA940
	public void ShowAllGuessJokerNpc()
	{
		foreach (int npcId in this.GetAllGuessJokerNpcIds())
		{
			this.ShowGuessJokerNpc(npcId);
		}
	}

	// Token: 0x0600721B RID: 29211 RVA: 0x001DC794 File Offset: 0x001DA994
	public void ShowOnlyGuessJokerNpc(int npcId)
	{
		foreach (int num in this.GetAllGuessJokerNpcIds())
		{
			if (num == npcId)
			{
				this.ShowGuessJokerNpc(num);
			}
			else
			{
				this.HideGuessJokerNpc(num);
			}
		}
	}

	// Token: 0x0600721C RID: 29212 RVA: 0x001DC7F4 File Offset: 0x001DA9F4
	public void HideGuessJokerNpc(int npcId)
	{
		if (this.HiddenGuessJokerNpcSet.Contains(npcId))
		{
			return;
		}
		if (!this.GetAllGuessJokerNpcIds().Contains(npcId))
		{
			return;
		}
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(npcId);
		if (entityByPbDataId == null || !entityByPbDataId.Valid || entityByPbDataId.Entity == null)
		{
			return;
		}
		ControllerBase<CreatureController>.Instance.SetEntityEnable(entityByPbDataId.Entity, false, "[GuessJoker] 隐藏猜鬼牌NPC", false);
		this.HiddenGuessJokerNpcSet.Add(npcId);
	}

	// Token: 0x0600721D RID: 29213 RVA: 0x001DC86C File Offset: 0x001DAA6C
	private void ShowGuessJokerNpc(int npcId)
	{
		if (!this.HiddenGuessJokerNpcSet.Contains(npcId))
		{
			return;
		}
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(npcId);
		if (entityByPbDataId == null || !entityByPbDataId.Valid || entityByPbDataId.Entity == null)
		{
			this.HiddenGuessJokerNpcSet.Remove(npcId);
			return;
		}
		ControllerBase<CreatureController>.Instance.SetEntityEnable(entityByPbDataId.Entity, true, "[GuessJoker] 显示猜鬼牌NPC", false);
		this.HiddenGuessJokerNpcSet.Remove(npcId);
	}

	// Token: 0x0600721E RID: 29214 RVA: 0x001DC8DF File Offset: 0x001DAADF
	public void ClearHideJokerNpcRecord(int npcId)
	{
		this.HiddenGuessJokerNpcSet.Remove(npcId);
	}

	// Token: 0x0600721F RID: 29215 RVA: 0x001DC8F0 File Offset: 0x001DAAF0
	public UniTask OpenSelectRoleView(int levelId = 0)
	{
		GuessJokerGamePlayModel.<OpenSelectRoleView>d__111 <OpenSelectRoleView>d__;
		<OpenSelectRoleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSelectRoleView>d__.<>4__this = this;
		<OpenSelectRoleView>d__.levelId = levelId;
		<OpenSelectRoleView>d__.<>1__state = -1;
		<OpenSelectRoleView>d__.<>t__builder.Start<GuessJokerGamePlayModel.<OpenSelectRoleView>d__111>(ref <OpenSelectRoleView>d__);
		return <OpenSelectRoleView>d__.<>t__builder.Task;
	}

	// Token: 0x06007220 RID: 29216 RVA: 0x001DC93C File Offset: 0x001DAB3C
	public bool CheckRedDot()
	{
		SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return false;
		}
		if (!activityData.IsFunctionUnlocked(ESpringFunctionType.Card))
		{
			return false;
		}
		int num = 0;
		bool flag = false;
		foreach (GuessJokerLevel guessJokerLevel in ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelList())
		{
			IGuessJokerLevelInfo guessJokerGameData = activityData.GetGuessJokerGameData(guessJokerLevel.Id);
			if (guessJokerGameData != null)
			{
				if (guessJokerGameData.FirstPass && !guessJokerGameData.RewardGet)
				{
					flag = true;
					break;
				}
				if (guessJokerGameData.Unlock && !guessJokerGameData.FirstPass)
				{
					num = guessJokerLevel.Id;
					break;
				}
			}
		}
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.GuessJokerUnlockLevelClicked, null) ?? new HashSet<int>();
		return flag || (num != 0 && !hashSet.Contains(num));
	}

	// Token: 0x06007221 RID: 29217 RVA: 0x001DCA1C File Offset: 0x001DAC1C
	public EGuessJokerSkillEffectPlayStrategy GetSkillEffectPlayStrategy(int skillId)
	{
		JokerSkill? jokerSkill = ConfigBase<GuessJokerConfig>.Instance.GetJokerSkill(skillId);
		if (jokerSkill == null)
		{
			return EGuessJokerSkillEffectPlayStrategy.Always;
		}
		if (jokerSkill.Value.EffectPlayStrategy != 1)
		{
			return EGuessJokerSkillEffectPlayStrategy.Always;
		}
		return EGuessJokerSkillEffectPlayStrategy.NotOnce;
	}

	// Token: 0x06007222 RID: 29218 RVA: 0x001DCA58 File Offset: 0x001DAC58
	public bool ShouldPlaySkillEffect(int skillId)
	{
		EGuessJokerSkillEffectPlayStrategy skillEffectPlayStrategy = this.GetSkillEffectPlayStrategy(skillId);
		return skillEffectPlayStrategy == EGuessJokerSkillEffectPlayStrategy.Always || skillEffectPlayStrategy != EGuessJokerSkillEffectPlayStrategy.NotOnce;
	}

	// Token: 0x06007223 RID: 29219 RVA: 0x001DCA7C File Offset: 0x001DAC7C
	public bool ShowPlayGiveUpSkillTip(int skillId)
	{
		JokerSkill? jokerSkill = ConfigBase<GuessJokerConfig>.Instance.GetJokerSkill(skillId);
		return jokerSkill != null && jokerSkill.Value.ShowGiveUpTip;
	}

	// Token: 0x06007224 RID: 29220 RVA: 0x001DCAB0 File Offset: 0x001DACB0
	public void GuessJokerExitSaveReport()
	{
		if (!this.InGamePlay)
		{
			return;
		}
		GuessJokerExitSaveReport guessJokerExitSaveReport = new GuessJokerExitSaveReport();
		guessJokerExitSaveReport.i_level_id = this.LevelId;
		guessJokerExitSaveReport.s_trace_id = this.S_Track_Id;
		guessJokerExitSaveReport.i_turn_id = this.RoundNumber;
		GuessJokerRoleData roleData = this.GetRoleData(EGuessJokerPlayerType.Me);
		int i_role_hp = (roleData != null) ? roleData.GetHp() : 0;
		GuessJokerRoleData roleData2 = this.GetRoleData(EGuessJokerPlayerType.Ai);
		int i_enemy_hp = (roleData2 != null) ? roleData2.GetHp() : 0;
		guessJokerExitSaveReport.i_role_hp = i_role_hp;
		guessJokerExitSaveReport.i_enemy_hp = i_enemy_hp;
		ControllerBase<LogReportController>.Instance.LogReport(guessJokerExitSaveReport);
	}

	// Token: 0x04003703 RID: 14083
	private GuessJokerStageFsm GuessJokerFsm;

	// Token: 0x04003704 RID: 14084
	private bool InGamePlay;

	// Token: 0x04003705 RID: 14085
	public bool IsExit;

	// Token: 0x04003706 RID: 14086
	private GuessJokerGamePlayView GamePlayView;

	// Token: 0x04003707 RID: 14087
	[Nullable(2)]
	private TimerHandle GamePlayTimerHandle;

	// Token: 0x04003708 RID: 14088
	[Nullable(2)]
	private TimerHandle NpcSitTimerHandle;

	// Token: 0x04003709 RID: 14089
	private int LevelId = -1;

	// Token: 0x0400370A RID: 14090
	private string S_Track_Id = "";

	// Token: 0x0400370B RID: 14091
	private int RoleId = -1;

	// Token: 0x0400370C RID: 14092
	public bool IsFinish;

	// Token: 0x0400370D RID: 14093
	private GuessJokerRoleData AiRoleData;

	// Token: 0x0400370E RID: 14094
	private GuessJokerRoleData PlayerRoleData;

	// Token: 0x0400370F RID: 14095
	private readonly Dictionary<int, GuessJokerCardData> CardDataMap = new Dictionary<int, GuessJokerCardData>();

	// Token: 0x04003710 RID: 14096
	public int RoundNumber;

	// Token: 0x04003711 RID: 14097
	private readonly List<JokerGuessOp> TaskDataList = new List<JokerGuessOp>();

	// Token: 0x04003712 RID: 14098
	public EGuessJokerPlayerType FirstPlayerTurn = EGuessJokerPlayerType.Ai;

	// Token: 0x04003713 RID: 14099
	private EGuessJokerPlayerType Winner = EGuessJokerPlayerType.Ai;

	// Token: 0x04003714 RID: 14100
	private GuessJokerActionRunner<GuessJokerActionBase> ActionRunner;

	// Token: 0x04003715 RID: 14101
	private GuessJokerPlotActionRunner PlotActionRunner;

	// Token: 0x04003716 RID: 14102
	public bool ShowInitialNoPairTip = true;

	// Token: 0x04003717 RID: 14103
	private readonly Dictionary<int, int> LastUsedPlotIdMap = new Dictionary<int, int>();

	// Token: 0x04003718 RID: 14104
	private GuessJokerDialogLogic ActiveDialogLogic;

	// Token: 0x04003719 RID: 14105
	private int? PlayerDrawnCardId;

	// Token: 0x0400371A RID: 14106
	private int? AiDrawnCardId;

	// Token: 0x0400371B RID: 14107
	private readonly Dictionary<EGuessJokerPlayerType, bool> RoundStartTipShownMap = new Dictionary<EGuessJokerPlayerType, bool>();

	// Token: 0x0400371C RID: 14108
	private readonly HashSet<int> HiddenGuessJokerNpcSet = new HashSet<int>();

	// Token: 0x0400371D RID: 14109
	private readonly HashSet<int> PendingNpcSitSet = new HashSet<int>();

	// Token: 0x0400371E RID: 14110
	public bool IsShowAiCards;
}
