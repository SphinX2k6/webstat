using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Core.Utils;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.ThirdParty.UniTaskExtensions;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000E81 RID: 3713
[NullableContext(1)]
[Nullable(0)]
public static class GameProcedure
{
	// Token: 0x06005ABC RID: 23228 RVA: 0x00164460 File Offset: 0x00162660
	private static void LogLoadPhase(string name, double? time = null)
	{
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			double num = time ?? ((double)UKuroStaticLibrary.GetPlatformTimeInSeconds());
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.BLZ;
			string message = "[LoadPhase] " + name;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("time", num);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x06005ABD RID: 23229 RVA: 0x001644C8 File Offset: 0x001626C8
	public static void Start(UGameInstance gameInstance)
	{
		Singleton<Info>.Instance.Initialize(gameInstance);
		Singleton<Log>.Instance.ApplyPostHotPatchVerbosity();
		if (Singleton<PublicUtil>.Instance.GetIsSilentLogin())
		{
			global::DelegateUtils.CreateStaticDefaultValue();
			UnobservedExceptionHandler.Initialize(gameInstance);
			DllUtils.Initialize();
			GeneratedUtils.Init();
			StaticVariableRegister.CreateRequiredStaticDefaultValue();
			DecoratorManager.Init();
		}
		Singleton<LogAnalyzer>.Instance.Initialize(true, Singleton<BaseConfigController>.Instance.GetPackageConfigOrDefault("Stream", null));
		float piestartTimeInSeconds = UKuroStaticLibrary.GetPIEStartTimeInSeconds();
		GameProcedure.LogLoadPhase("EngineInit Start", new double?((double)piestartTimeInSeconds));
		GameProcedure.LogLoadPhase("EngineInit End", null);
		Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.LCC, "GameProcedure：启动游戏初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
		GameProcedure.OnStart(gameInstance).Forget();
	}

	// Token: 0x06005ABE RID: 23230 RVA: 0x00164584 File Offset: 0x00162784
	private static UniTask OnStart(UGameInstance instance)
	{
		GameProcedure.<OnStart>d__4 <OnStart>d__;
		<OnStart>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnStart>d__.instance = instance;
		<OnStart>d__.<>1__state = -1;
		<OnStart>d__.<>t__builder.Start<GameProcedure.<OnStart>d__4>(ref <OnStart>d__);
		return <OnStart>d__.<>t__builder.Task;
	}

	// Token: 0x06005ABF RID: 23231 RVA: 0x001645C8 File Offset: 0x001627C8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private static UniTask<T> FrameImport<[Nullable(2)] T>([Nullable(new byte[]
	{
		0,
		1
	})] UniTask<T> importTask, string moduleName)
	{
		GameProcedure.<FrameImport>d__5<T> <FrameImport>d__;
		<FrameImport>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
		<FrameImport>d__.importTask = importTask;
		<FrameImport>d__.moduleName = moduleName;
		<FrameImport>d__.<>1__state = -1;
		<FrameImport>d__.<>t__builder.Start<GameProcedure.<FrameImport>d__5<T>>(ref <FrameImport>d__);
		return <FrameImport>d__.<>t__builder.Task;
	}

	// Token: 0x06005AC0 RID: 23232 RVA: 0x00164614 File Offset: 0x00162814
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private static UniTask<T> MonitorImport<[Nullable(2)] T>([Nullable(new byte[]
	{
		0,
		1
	})] UniTask<T> importTask, string moduleName)
	{
		GameProcedure.<MonitorImport>d__6<T> <MonitorImport>d__;
		<MonitorImport>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
		<MonitorImport>d__.importTask = importTask;
		<MonitorImport>d__.moduleName = moduleName;
		<MonitorImport>d__.<>1__state = -1;
		<MonitorImport>d__.<>t__builder.Start<GameProcedure.<MonitorImport>d__6<T>>(ref <MonitorImport>d__);
		return <MonitorImport>d__.<>t__builder.Task;
	}

	// Token: 0x06005AC1 RID: 23233 RVA: 0x00164660 File Offset: 0x00162860
	private static UniTask FrameCallAsyncGenerator(string callName, bool bMonitorTime, Delegate func, [Nullable(2)] UGameInstance instance = null)
	{
		GameProcedure.<FrameCallAsyncGenerator>d__7 <FrameCallAsyncGenerator>d__;
		<FrameCallAsyncGenerator>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FrameCallAsyncGenerator>d__.callName = callName;
		<FrameCallAsyncGenerator>d__.bMonitorTime = bMonitorTime;
		<FrameCallAsyncGenerator>d__.func = func;
		<FrameCallAsyncGenerator>d__.instance = instance;
		<FrameCallAsyncGenerator>d__.<>1__state = -1;
		<FrameCallAsyncGenerator>d__.<>t__builder.Start<GameProcedure.<FrameCallAsyncGenerator>d__7>(ref <FrameCallAsyncGenerator>d__);
		return <FrameCallAsyncGenerator>d__.<>t__builder.Task;
	}

	// Token: 0x06005AC2 RID: 23234 RVA: 0x001646BB File Offset: 0x001628BB
	private static void Tick(float delta)
	{
		Action advance = GameProcedure.GameProcedureDefine.Advance;
		if (advance != null)
		{
			advance();
		}
		GameProcedure.GameProcedureDefine.Advance = null;
	}

	// Token: 0x06005AC3 RID: 23235 RVA: 0x001646D4 File Offset: 0x001628D4
	private static UniTask WaitFrame()
	{
		GameProcedure.<WaitFrame>d__9 <WaitFrame>d__;
		<WaitFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitFrame>d__.<>1__state = -1;
		<WaitFrame>d__.<>t__builder.Start<GameProcedure.<WaitFrame>d__9>(ref <WaitFrame>d__);
		return <WaitFrame>d__.<>t__builder.Task;
	}

	// Token: 0x06005AC4 RID: 23236 RVA: 0x00164710 File Offset: 0x00162910
	[return: Dynamic(new bool[]
	{
		false,
		true
	})]
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private static UniTask<dynamic> ImportAsync(string path)
	{
		GameProcedure.<ImportAsync>d__10 <ImportAsync>d__;
		<ImportAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
		<ImportAsync>d__.<>1__state = -1;
		<ImportAsync>d__.<>t__builder.Start<GameProcedure.<ImportAsync>d__10>(ref <ImportAsync>d__);
		return <ImportAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04002A0C RID: 10764
	private const int MaxFrameTime = 200;

	// Token: 0x020072BE RID: 29374
	[NullableContext(0)]
	public class GameProcedureDefine : IStaticVariableResetter
	{
		// Token: 0x06046959 RID: 289113 RVA: 0x012BD61F File Offset: 0x012BB81F
		static GameProcedureDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(GameProcedure.GameProcedureDefine.CreateStaticDefaultValue), new Action(GameProcedure.GameProcedureDefine.ResetStaticDefaultValue));
		}

		// Token: 0x1700A79D RID: 42909
		// (get) Token: 0x0604695A RID: 289114 RVA: 0x012BD63E File Offset: 0x012BB83E
		// (set) Token: 0x0604695B RID: 289115 RVA: 0x012BD645 File Offset: 0x012BB845
		public static bool Inited { get; set; }

		// Token: 0x0604695C RID: 289116 RVA: 0x012BD64D File Offset: 0x012BB84D
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0604695D RID: 289117 RVA: 0x012BD64F File Offset: 0x012BB84F
		public static void ResetStaticDefaultValue()
		{
			GameProcedure.GameProcedureDefine.Inited = false;
			GameProcedure.GameProcedureDefine.Advance = null;
		}

		// Token: 0x04027C71 RID: 162929
		[Nullable(1)]
		public static Action Advance;
	}

	// Token: 0x020072BF RID: 29375
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027C72 RID: 162930
		[Nullable(0)]
		public static Action<float> <0>__Tick;
	}
}
