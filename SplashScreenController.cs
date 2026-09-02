using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MovieMode;
using CSharpScript.Game.Ui;

// Token: 0x02002A91 RID: 10897
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class SplashScreenController : ControllerBase<SplashScreenController>
{
	// Token: 0x06015CFE RID: 89342 RVA: 0x0060C24E File Offset: 0x0060A44E
	protected override bool OnInit()
	{
		this.AddEvents();
		return true;
	}

	// Token: 0x06015CFF RID: 89343 RVA: 0x0060C257 File Offset: 0x0060A457
	protected override bool OnClear()
	{
		this.RemoveEvents();
		return true;
	}

	// Token: 0x06015D00 RID: 89344 RVA: 0x0060C260 File Offset: 0x0060A460
	private void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Add(EEventName.ResetModuleByResetToBattleView, new Action(this.OnResetModuleByResetToBattleView));
		Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
	}

	// Token: 0x06015D01 RID: 89345 RVA: 0x0060C2E0 File Offset: 0x0060A4E0
	private void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.ResetModuleByResetToBattleView, new Action(this.OnResetModuleByResetToBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
	}

	// Token: 0x06015D02 RID: 89346 RVA: 0x0060C360 File Offset: 0x0060A560
	private void OnWorldDoneAndCloseLoading()
	{
		Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "WorldDoneAndCloseLoading 尝试运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.TryRunSplashScreenTask();
	}

	// Token: 0x06015D03 RID: 89347 RVA: 0x0060C394 File Offset: 0x0060A594
	private void OnActiveBattleView()
	{
		Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "ActiveBattleView 尝试运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.TryRunSplashScreenTask();
	}

	// Token: 0x06015D04 RID: 89348 RVA: 0x0060C3C8 File Offset: 0x0060A5C8
	private void OnResetModuleByResetToBattleView()
	{
		Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "ResetModuleByResetToBattleView 尝试运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.TryRunSplashScreenTask();
	}

	// Token: 0x06015D05 RID: 89349 RVA: 0x0060C3FA File Offset: 0x0060A5FA
	private void OnBeforeLoadMap()
	{
		this.ClearAllTasks();
	}

	// Token: 0x06015D06 RID: 89350 RVA: 0x0060C404 File Offset: 0x0060A604
	public void PushSplashScreenTask(SplashScreenTask splashScreenTask, bool isInstantly = false)
	{
		if (splashScreenTask.Type == ESplashScreenType.Config && Singleton<Info>.Instance.IsPlayInEditor && this.IsForbidAddTask)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SplashScreenTask;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "添加开屏动画任务失败，当前处于禁止添加任务状态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TaskSourceModule", splashScreenTask.SourceModule);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.SplashScreenQueue.EnQueue(splashScreenTask);
		if (isInstantly)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SplashScreenTask;
			ELogAuthor author2 = ELogAuthor.CXJ;
			string message2 = "添加开屏动画任务且立即执行";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("TaskSourceModule", splashScreenTask.SourceModule);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.TryRunSplashScreenTask();
		}
	}

	// Token: 0x06015D07 RID: 89351 RVA: 0x0060C4AC File Offset: 0x0060A6AC
	public void FinishCurTask(ESplashScreenSourceModuleType taskSourceModule = ESplashScreenSourceModuleType.None)
	{
		if (this.SplashScreenQueue.FinishTask(taskSourceModule))
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "FinishCurTask 尝试运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.TryRunSplashScreenTask();
		}
	}

	// Token: 0x06015D08 RID: 89352 RVA: 0x0060C4EC File Offset: 0x0060A6EC
	public void TryRunSplashScreenTask()
	{
		if (this.SplashScreenQueue.TaskQueue == null || this.SplashScreenQueue.TaskQueue.Count == 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "开屏任务队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "世界未加载完成，且加载界面未关闭", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "未在战斗主界面，不运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!Singleton<UiManager>.Instance.IsNormalContainerEmpty())
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "待打开界面队列不为空，不运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		if (worldEntity == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "当前角色实体不存在，不运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		BaseTagComponent component = worldEntity.GetComponent<BaseTagComponent>();
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "处于战斗中，不运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "处于副本中，不运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (ControllerBase<MovieModeController>.Instance.IsInMovieMode())
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CB, "处于电影模式中，不运行开屏动画任务", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int[] runningGroupIdList = ModelBase<GuideModel>.Instance.GetRunningGroupIdList();
		if (runningGroupIdList.Length != 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "处于引导中，不运行开屏动画任务，引导GroupId: " + string.Join<int>(", ", runningGroupIdList), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SplashScreenQueue.ProcessQueue();
	}

	// Token: 0x06015D09 RID: 89353 RVA: 0x0060C6F5 File Offset: 0x0060A8F5
	public void ClearAllTasks()
	{
		this.SplashScreenQueue.ClearAllTask();
	}

	// Token: 0x0400A74F RID: 42831
	protected SplashScreenQueue SplashScreenQueue = new SplashScreenQueue();

	// Token: 0x0400A750 RID: 42832
	public bool IsForbidAddTask = true;
}
