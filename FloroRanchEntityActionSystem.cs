using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BEE RID: 7150
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchEntityActionSystem : IStaticVariableResetter
{
	// Token: 0x0600D006 RID: 53254 RVA: 0x00373704 File Offset: 0x00371904
	static FloroRanchEntityActionSystem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FloroRanchEntityActionSystem.CreateStaticDefaultValue), new Action(FloroRanchEntityActionSystem.ResetStaticDefaultValue));
	}

	// Token: 0x0600D007 RID: 53255 RVA: 0x00373723 File Offset: 0x00371923
	public static void CreateStaticDefaultValue()
	{
		FloroRanchEntityActionSystem.CurrentAction = null;
	}

	// Token: 0x0600D008 RID: 53256 RVA: 0x0037372B File Offset: 0x0037192B
	public static void ResetStaticDefaultValue()
	{
		FloroRanchEntityActionSystem.CurrentAction = null;
	}

	// Token: 0x0600D009 RID: 53257 RVA: 0x00373734 File Offset: 0x00371934
	public static UniTask DayStart(FloroRanchDayStart dayStartData)
	{
		FloroRanchEntityActionSystem.<DayStart>d__4 <DayStart>d__;
		<DayStart>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DayStart>d__.dayStartData = dayStartData;
		<DayStart>d__.<>1__state = -1;
		<DayStart>d__.<>t__builder.Start<FloroRanchEntityActionSystem.<DayStart>d__4>(ref <DayStart>d__);
		return <DayStart>d__.<>t__builder.Task;
	}

	// Token: 0x0600D00A RID: 53258 RVA: 0x00373778 File Offset: 0x00371978
	public static UniTask ExecuteActionList(List<FloroRanchUnitActionMsg> actionDataList)
	{
		FloroRanchEntityActionSystem.<ExecuteActionList>d__5 <ExecuteActionList>d__;
		<ExecuteActionList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteActionList>d__.actionDataList = actionDataList;
		<ExecuteActionList>d__.<>1__state = -1;
		<ExecuteActionList>d__.<>t__builder.Start<FloroRanchEntityActionSystem.<ExecuteActionList>d__5>(ref <ExecuteActionList>d__);
		return <ExecuteActionList>d__.<>t__builder.Task;
	}

	// Token: 0x0600D00B RID: 53259 RVA: 0x003737BC File Offset: 0x003719BC
	public static UniTask ExecuteWageSettleAction(FloroRanchWageSettleTask wageSettle)
	{
		FloroRanchEntityActionSystem.<ExecuteWageSettleAction>d__6 <ExecuteWageSettleAction>d__;
		<ExecuteWageSettleAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteWageSettleAction>d__.wageSettle = wageSettle;
		<ExecuteWageSettleAction>d__.<>1__state = -1;
		<ExecuteWageSettleAction>d__.<>t__builder.Start<FloroRanchEntityActionSystem.<ExecuteWageSettleAction>d__6>(ref <ExecuteWageSettleAction>d__);
		return <ExecuteWageSettleAction>d__.<>t__builder.Task;
	}

	// Token: 0x0600D00C RID: 53260 RVA: 0x00373800 File Offset: 0x00371A00
	private static bool CheckCanExecuteAction()
	{
		if (FloroRanchEntityActionSystem.CurrentAction != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "FloroRanchEntityActionSystem ExecuteActionList 正在执行", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return true;
	}

	// Token: 0x0600D00D RID: 53261 RVA: 0x00373836 File Offset: 0x00371A36
	public static void Pause()
	{
		if (FloroRanchEntityActionSystem.CurrentAction != null)
		{
			FloroRanchEntityActionSystem.CurrentAction.Pause();
		}
	}

	// Token: 0x0600D00E RID: 53262 RVA: 0x00373849 File Offset: 0x00371A49
	public static void Resume()
	{
		if (FloroRanchEntityActionSystem.CurrentAction != null)
		{
			FloroRanchEntityActionSystem.CurrentAction.Resume();
		}
	}

	// Token: 0x0600D00F RID: 53263 RVA: 0x0037385C File Offset: 0x00371A5C
	public static void Exit()
	{
		if (FloroRanchEntityActionSystem.CurrentAction != null)
		{
			FloroRanchEntityActionSystem.CurrentAction.Exit();
			FloroRanchEntityActionSystem.CurrentAction = null;
		}
	}

	// Token: 0x0600D010 RID: 53264 RVA: 0x00373878 File Offset: 0x00371A78
	public static FloroRanchActionDataBase CreateActionData(FloroRanchUnitActionMsg actionData)
	{
		switch (actionData.UnitActionType)
		{
		case FloroRanchUnitActionType.OpBuff:
			return new FloroRanchBuffUpdateActionData(actionData);
		case FloroRanchUnitActionType.OpUnit:
			return new FloroRanchEntityChangeActionData(actionData);
		case FloroRanchUnitActionType.UnitResourcesChange:
			return new FloroRanchResourceChangeActionData(actionData);
		case FloroRanchUnitActionType.Eating:
			return new FloroRanchEatGroupActionData(actionData);
		case FloroRanchUnitActionType.EvolveUpdate:
			return new FloroRanchEvolveUpdateActionData(actionData);
		case FloroRanchUnitActionType.Mix:
			return new FloroRanchFusionActionData(actionData);
		case FloroRanchUnitActionType.Sacrifice:
			return new FloroRanchSacrificeActionData(actionData);
		case FloroRanchUnitActionType.DebugActionInfo:
			return new FloroRanchDebugInfoActionData(actionData);
		case FloroRanchUnitActionType.BeEat:
			return new FloroRanchEatActionData(actionData);
		case FloroRanchUnitActionType.ChangePoint:
			return new FloroRanchChangePointActionData(actionData);
		case FloroRanchUnitActionType.ActionStop:
			return new FloroRanchActionStopActionData(actionData);
		case FloroRanchUnitActionType.ToyLvUp:
			return new FloroRanchToyLevelUpActionData(actionData);
		case FloroRanchUnitActionType.StageTributeChange:
			return new FloroRanchStageTributeChange(actionData);
		case FloroRanchUnitActionType.SelfDefineValue:
			return new FloroRanchSelfDefineValueActionData(actionData);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanchGamePlay;
		ELogAuthor author = ELogAuthor.BB;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 1);
		defaultInterpolatedStringHandler.AppendLiteral("FloroRanchEntityActionSystem CreateActionData 未知的行为类型:");
		defaultInterpolatedStringHandler.AppendFormatted<FloroRanchUnitActionType>(actionData.UnitActionType);
		instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		return new FloroRanchActionDataBase(actionData);
	}

	// Token: 0x0600D011 RID: 53265 RVA: 0x00373980 File Offset: 0x00371B80
	public static void DayEnd()
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FloroRanchGamePlayView);
		if (viewByName == null)
		{
			return;
		}
		((FloroRanchGamePlayView)viewByName).SetNewDayButtonActive(true);
	}

	// Token: 0x0600D012 RID: 53266 RVA: 0x003739B0 File Offset: 0x00371BB0
	public static UniTask AddEntities(List<FloroRanchPlayUnit> units)
	{
		FloroRanchEntityActionSystem.<AddEntities>d__13 <AddEntities>d__;
		<AddEntities>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddEntities>d__.units = units;
		<AddEntities>d__.<>1__state = -1;
		<AddEntities>d__.<>t__builder.Start<FloroRanchEntityActionSystem.<AddEntities>d__13>(ref <AddEntities>d__);
		return <AddEntities>d__.<>t__builder.Task;
	}

	// Token: 0x0600D013 RID: 53267 RVA: 0x003739F4 File Offset: 0x00371BF4
	public static UniTask AddEntity(FloroRanchPlayUnit unit)
	{
		FloroRanchEntityActionSystem.<AddEntity>d__14 <AddEntity>d__;
		<AddEntity>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddEntity>d__.unit = unit;
		<AddEntity>d__.<>1__state = -1;
		<AddEntity>d__.<>t__builder.Start<FloroRanchEntityActionSystem.<AddEntity>d__14>(ref <AddEntity>d__);
		return <AddEntity>d__.<>t__builder.Task;
	}

	// Token: 0x0600D014 RID: 53268 RVA: 0x00373A38 File Offset: 0x00371C38
	public static UniTask RemoveEntity(int entityId)
	{
		FloroRanchEntityActionSystem.<RemoveEntity>d__15 <RemoveEntity>d__;
		<RemoveEntity>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RemoveEntity>d__.entityId = entityId;
		<RemoveEntity>d__.<>1__state = -1;
		<RemoveEntity>d__.<>t__builder.Start<FloroRanchEntityActionSystem.<RemoveEntity>d__15>(ref <RemoveEntity>d__);
		return <RemoveEntity>d__.<>t__builder.Task;
	}

	// Token: 0x040062F5 RID: 25333
	[Nullable(2)]
	private static FloroRanchAsyncActionBase CurrentAction;
}
