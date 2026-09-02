using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B09 RID: 19209
	[NullableContext(1)]
	[Nullable(0)]
	public class GameplayEntityActionExecutor : IStaticVariableResetter
	{
		// Token: 0x0603217A RID: 205178 RVA: 0x00C88B26 File Offset: 0x00C86D26
		static GameplayEntityActionExecutor()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(GameplayEntityActionExecutor.CreateStaticDefaultValue), new Action(GameplayEntityActionExecutor.ResetStaticDefaultValue));
		}

		// Token: 0x0603217B RID: 205179 RVA: 0x00C88B45 File Offset: 0x00C86D45
		public static void CreateStaticDefaultValue()
		{
			GameplayEntityActionExecutor._executionContextStack = new List<IGameplayEntityExecutionContext>();
		}

		// Token: 0x0603217C RID: 205180 RVA: 0x00C88B51 File Offset: 0x00C86D51
		public static void ResetStaticDefaultValue()
		{
			GameplayEntityActionExecutor._executionContextStack = null;
		}

		// Token: 0x0603217D RID: 205181 RVA: 0x00C88B5C File Offset: 0x00C86D5C
		public static UniTask ExecuteActionList(WuWaGoGameModeBase gameMode, IReadOnlyList<ActionInfo> actionList)
		{
			GameplayEntityActionExecutor.<ExecuteActionList>d__5 <ExecuteActionList>d__;
			<ExecuteActionList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteActionList>d__.gameMode = gameMode;
			<ExecuteActionList>d__.actionList = actionList;
			<ExecuteActionList>d__.<>1__state = -1;
			<ExecuteActionList>d__.<>t__builder.Start<GameplayEntityActionExecutor.<ExecuteActionList>d__5>(ref <ExecuteActionList>d__);
			return <ExecuteActionList>d__.<>t__builder.Task;
		}

		// Token: 0x0603217E RID: 205182 RVA: 0x00C88BA8 File Offset: 0x00C86DA8
		public static UniTask ExecutePullRodImmediately(WuWaGoGameModeBase gameMode, WuWaGoPullRodEntity pullRod)
		{
			GameplayEntityActionExecutor.<ExecutePullRodImmediately>d__6 <ExecutePullRodImmediately>d__;
			<ExecutePullRodImmediately>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecutePullRodImmediately>d__.gameMode = gameMode;
			<ExecutePullRodImmediately>d__.pullRod = pullRod;
			<ExecutePullRodImmediately>d__.<>1__state = -1;
			<ExecutePullRodImmediately>d__.<>t__builder.Start<GameplayEntityActionExecutor.<ExecutePullRodImmediately>d__6>(ref <ExecutePullRodImmediately>d__);
			return <ExecutePullRodImmediately>d__.<>t__builder.Task;
		}

		// Token: 0x0603217F RID: 205183 RVA: 0x00C88BF4 File Offset: 0x00C86DF4
		private static void PrepareLinkedPullRodPresentation(int sourcePbDataId, EGameplayEntityState targetState)
		{
			IGameplayEntityExecutionContext currentExecutionContext = GameplayEntityActionExecutor.GetCurrentExecutionContext();
			WuWaGoGameModeBase wuWaGoGameModeBase = (currentExecutionContext != null) ? currentExecutionContext.GameMode : null;
			if (wuWaGoGameModeBase == null)
			{
				return;
			}
			foreach (int pbDataId in wuWaGoGameModeBase.GameplayEntityLinkService.GetLinkedGroupPbDataIds(sourcePbDataId))
			{
				PullRodController pullRodController = wuWaGoGameModeBase.GetEntityControllerByPbDataId(pbDataId) as PullRodController;
				if (pullRodController != null)
				{
					pullRodController.PrepareInteractPresentation(targetState);
				}
			}
		}

		// Token: 0x06032180 RID: 205184 RVA: 0x00C88C70 File Offset: 0x00C86E70
		[NullableContext(0)]
		private static UniTask<bool> WaitForLinkedPullRodPresentation(int sourcePbDataId)
		{
			GameplayEntityActionExecutor.<WaitForLinkedPullRodPresentation>d__8 <WaitForLinkedPullRodPresentation>d__;
			<WaitForLinkedPullRodPresentation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<WaitForLinkedPullRodPresentation>d__.sourcePbDataId = sourcePbDataId;
			<WaitForLinkedPullRodPresentation>d__.<>1__state = -1;
			<WaitForLinkedPullRodPresentation>d__.<>t__builder.Start<GameplayEntityActionExecutor.<WaitForLinkedPullRodPresentation>d__8>(ref <WaitForLinkedPullRodPresentation>d__);
			return <WaitForLinkedPullRodPresentation>d__.<>t__builder.Task;
		}

		// Token: 0x06032181 RID: 205185 RVA: 0x00C88CB4 File Offset: 0x00C86EB4
		private static UniTask ExecuteActionListInternal(IReadOnlyList<ActionInfo> actionList)
		{
			GameplayEntityActionExecutor.<ExecuteActionListInternal>d__9 <ExecuteActionListInternal>d__;
			<ExecuteActionListInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteActionListInternal>d__.actionList = actionList;
			<ExecuteActionListInternal>d__.<>1__state = -1;
			<ExecuteActionListInternal>d__.<>t__builder.Start<GameplayEntityActionExecutor.<ExecuteActionListInternal>d__9>(ref <ExecuteActionListInternal>d__);
			return <ExecuteActionListInternal>d__.<>t__builder.Task;
		}

		// Token: 0x06032182 RID: 205186 RVA: 0x00C88CF8 File Offset: 0x00C86EF8
		private static UniTask ExecuteWuWaGoAction(ActionInfo actionInfo)
		{
			GameplayEntityActionExecutor.<ExecuteWuWaGoAction>d__10 <ExecuteWuWaGoAction>d__;
			<ExecuteWuWaGoAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteWuWaGoAction>d__.actionInfo = actionInfo;
			<ExecuteWuWaGoAction>d__.<>1__state = -1;
			<ExecuteWuWaGoAction>d__.<>t__builder.Start<GameplayEntityActionExecutor.<ExecuteWuWaGoAction>d__10>(ref <ExecuteWuWaGoAction>d__);
			return <ExecuteWuWaGoAction>d__.<>t__builder.Task;
		}

		// Token: 0x06032183 RID: 205187 RVA: 0x00C88D3C File Offset: 0x00C86F3C
		private static UniTask ExecuteSingleEntityStateChange(int entityId, string stateTag)
		{
			GameplayEntityActionExecutor.<ExecuteSingleEntityStateChange>d__11 <ExecuteSingleEntityStateChange>d__;
			<ExecuteSingleEntityStateChange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteSingleEntityStateChange>d__.entityId = entityId;
			<ExecuteSingleEntityStateChange>d__.stateTag = stateTag;
			<ExecuteSingleEntityStateChange>d__.<>1__state = -1;
			<ExecuteSingleEntityStateChange>d__.<>t__builder.Start<GameplayEntityActionExecutor.<ExecuteSingleEntityStateChange>d__11>(ref <ExecuteSingleEntityStateChange>d__);
			return <ExecuteSingleEntityStateChange>d__.<>t__builder.Task;
		}

		// Token: 0x06032184 RID: 205188 RVA: 0x00C88D88 File Offset: 0x00C86F88
		private static UniTask ExecuteEntityController(int pbDataId)
		{
			GameplayEntityActionExecutor.<ExecuteEntityController>d__12 <ExecuteEntityController>d__;
			<ExecuteEntityController>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteEntityController>d__.pbDataId = pbDataId;
			<ExecuteEntityController>d__.<>1__state = -1;
			<ExecuteEntityController>d__.<>t__builder.Start<GameplayEntityActionExecutor.<ExecuteEntityController>d__12>(ref <ExecuteEntityController>d__);
			return <ExecuteEntityController>d__.<>t__builder.Task;
		}

		// Token: 0x06032185 RID: 205189 RVA: 0x00C88DCC File Offset: 0x00C86FCC
		private static bool BeginExecutionContextIfNeeded(WuWaGoGameModeBase gameMode)
		{
			if (GameplayEntityActionExecutor.GetCurrentExecutionContext() != null)
			{
				return false;
			}
			GameplayEntityActionExecutor._executionContextStack.Add(new GameplayEntityExecutionContext
			{
				GameMode = gameMode,
				ExecutingPullRodGroups = new HashSet<int>(),
				PendingBowTrapPbDataIds = new HashSet<int>(),
				PendingMovableFloorPbDataIds = new HashSet<int>()
			});
			return true;
		}

		// Token: 0x06032186 RID: 205190 RVA: 0x00C88E1C File Offset: 0x00C8701C
		private static UniTask EndExecutionContextIfNeeded(bool isRootExecution)
		{
			GameplayEntityActionExecutor.<EndExecutionContextIfNeeded>d__14 <EndExecutionContextIfNeeded>d__;
			<EndExecutionContextIfNeeded>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EndExecutionContextIfNeeded>d__.isRootExecution = isRootExecution;
			<EndExecutionContextIfNeeded>d__.<>1__state = -1;
			<EndExecutionContextIfNeeded>d__.<>t__builder.Start<GameplayEntityActionExecutor.<EndExecutionContextIfNeeded>d__14>(ref <EndExecutionContextIfNeeded>d__);
			return <EndExecutionContextIfNeeded>d__.<>t__builder.Task;
		}

		// Token: 0x06032187 RID: 205191 RVA: 0x00C88E5F File Offset: 0x00C8705F
		[NullableContext(2)]
		private static IGameplayEntityExecutionContext GetCurrentExecutionContext()
		{
			if (GameplayEntityActionExecutor._executionContextStack.Count != 0)
			{
				List<IGameplayEntityExecutionContext> executionContextStack = GameplayEntityActionExecutor._executionContextStack;
				return executionContextStack[executionContextStack.Count - 1];
			}
			return null;
		}

		// Token: 0x06032188 RID: 205192 RVA: 0x00C88E84 File Offset: 0x00C87084
		private static void QueuePendingBowTrap(int pbDataId)
		{
			IGameplayEntityExecutionContext currentExecutionContext = GameplayEntityActionExecutor.GetCurrentExecutionContext();
			if (currentExecutionContext == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.WuWaGo;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "弓箭批量执行上下文不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", pbDataId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			currentExecutionContext.PendingBowTrapPbDataIds.Add(pbDataId);
		}

		// Token: 0x06032189 RID: 205193 RVA: 0x00C88ED8 File Offset: 0x00C870D8
		private static void QueuePendingMovableFloor(int pbDataId)
		{
			IGameplayEntityExecutionContext currentExecutionContext = GameplayEntityActionExecutor.GetCurrentExecutionContext();
			if (currentExecutionContext == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.WuWaGo;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "移动板批量执行上下文不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", pbDataId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			currentExecutionContext.PendingMovableFloorPbDataIds.Add(pbDataId);
		}

		// Token: 0x0603218A RID: 205194 RVA: 0x00C88F2C File Offset: 0x00C8712C
		private static UniTask FlushPendingBowTraps(IGameplayEntityExecutionContext context)
		{
			GameplayEntityActionExecutor.<FlushPendingBowTraps>d__18 <FlushPendingBowTraps>d__;
			<FlushPendingBowTraps>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FlushPendingBowTraps>d__.context = context;
			<FlushPendingBowTraps>d__.<>1__state = -1;
			<FlushPendingBowTraps>d__.<>t__builder.Start<GameplayEntityActionExecutor.<FlushPendingBowTraps>d__18>(ref <FlushPendingBowTraps>d__);
			return <FlushPendingBowTraps>d__.<>t__builder.Task;
		}

		// Token: 0x0603218B RID: 205195 RVA: 0x00C88F70 File Offset: 0x00C87170
		private static UniTask FlushPendingMovableFloors(IGameplayEntityExecutionContext context)
		{
			GameplayEntityActionExecutor.<FlushPendingMovableFloors>d__19 <FlushPendingMovableFloors>d__;
			<FlushPendingMovableFloors>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FlushPendingMovableFloors>d__.context = context;
			<FlushPendingMovableFloors>d__.<>1__state = -1;
			<FlushPendingMovableFloors>d__.<>t__builder.Start<GameplayEntityActionExecutor.<FlushPendingMovableFloors>d__19>(ref <FlushPendingMovableFloors>d__);
			return <FlushPendingMovableFloors>d__.<>t__builder.Task;
		}

		// Token: 0x0401D48D RID: 119949
		private const string DAMAGE_BATCH_REASON_IMMEDIATE_BOW_TRAP = "ImmediateBowTrapActionList";

		// Token: 0x0401D48E RID: 119950
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static List<IGameplayEntityExecutionContext> _executionContextStack;
	}
}
