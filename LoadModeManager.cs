using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

// Token: 0x02000BD7 RID: 3031
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LoadModeManager : Singleton<LoadModeManager>
{
	// Token: 0x060031C7 RID: 12743 RVA: 0x0001EE18 File Offset: 0x0001D018
	private ILoadModeHandler GetHandlerByLoadMode(ELoadMode mode)
	{
		LoadModeManager.LoadModeData loadModeData = this.LoadModeToDataRecord[mode];
		if (loadModeData.HandlerInstance != null)
		{
			return loadModeData.HandlerInstance;
		}
		loadModeData.HandlerInstance = loadModeData.HandlerCtor();
		return loadModeData.HandlerInstance;
	}

	// Token: 0x060031C8 RID: 12744 RVA: 0x0001EE58 File Offset: 0x0001D058
	private void CheckAndUpdateLoadMode()
	{
		this.UpdateLoadMode(this.GetTargetLoadMode());
	}

	// Token: 0x060031C9 RID: 12745 RVA: 0x0001EE68 File Offset: 0x0001D068
	private ELoadMode GetTargetLoadMode()
	{
		ELoadMode targetLoadMode = ELoadMode.InGame;
		IEnumerable<ELoadMode> values = this.ReasonToLoadMode.Values;
		Func<ELoadMode, bool> <>9__0;
		Func<ELoadMode, bool> predicate;
		if ((predicate = <>9__0) == null)
		{
			predicate = (<>9__0 = ((ELoadMode mode) => this.LoadModeToDataRecord[mode].Priority > this.LoadModeToDataRecord[targetLoadMode].Priority));
		}
		foreach (ELoadMode targetLoadMode2 in values.Where(predicate))
		{
			targetLoadMode = targetLoadMode2;
		}
		return targetLoadMode;
	}

	// Token: 0x060031CA RID: 12746 RVA: 0x0001EEF8 File Offset: 0x0001D0F8
	private unsafe void UpdateLoadMode(ELoadMode newLoadMode)
	{
		if (newLoadMode == this.LoadMode)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameMode;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "[LoadModeManager] UpdateLoadMode";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("OldLoadMode", this.LoadMode);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NewLoadMode", newLoadMode);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.GetHandlerByLoadMode(this.LoadMode).ExitMode(Singleton<Info>.Instance.GameInstance);
		this.LoadMode = newLoadMode;
		this.GetHandlerByLoadMode(newLoadMode).EnterMode(Singleton<Info>.Instance.GameInstance);
		this.AfterUpdateLoadMode();
	}

	// Token: 0x060031CB RID: 12747 RVA: 0x0001EFB0 File Offset: 0x0001D1B0
	private void AfterUpdateLoadMode()
	{
		this.DisableLoadModeResetTimer();
		int sharedStayTimeLimit = this.LoadModeToDataRecord[this.LoadMode].SharedStayTimeLimit;
		if (sharedStayTimeLimit > 0)
		{
			this.EnableLoadModeResetTimer(sharedStayTimeLimit);
		}
	}

	// Token: 0x060031CC RID: 12748 RVA: 0x0001EFE5 File Offset: 0x0001D1E5
	private void EnableLoadModeResetTimer(int timeLimit)
	{
		this.DisableLoadModeResetTimer();
		this.LoadModeResetTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[LoadModeManager] 长时间处于限时LoadMode中，触发超时重置保底";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LoadMode", this.LoadMode);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DisableLoadModeResetTimer();
			this.ClearReasonAndResetLoadMode("LoadModeManager内部超时重置保底");
		}, (float)timeLimit, null, "LoadModeResetTimer", false, 1f);
	}

	// Token: 0x060031CD RID: 12749 RVA: 0x0001F017 File Offset: 0x0001D217
	private void DisableLoadModeResetTimer()
	{
		if (this.LoadModeResetTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.LoadModeResetTimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.LoadModeResetTimerHandle);
		}
		this.LoadModeResetTimerHandle = null;
	}

	// Token: 0x060031CE RID: 12750 RVA: 0x0001F04B File Offset: 0x0001D24B
	public ELoadMode GetLoadMode()
	{
		return this.LoadMode;
	}

	// Token: 0x060031CF RID: 12751 RVA: 0x0001F054 File Offset: 0x0001D254
	public unsafe void SetLoadModeByReason(ELoadMode mode, ELoadModeReason reason)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameMode;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "[LoadModeManager] SetLoadModeByReason";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LoadMode", mode);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ELoadMode eloadMode = mode;
		if (mode == ELoadMode.None)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameMode;
			ELogAuthor author2 = ELogAuthor.ZYL;
			string message2 = "[LoadModeManager] SetLoadModeByReason时发现传入了不允许外部设置的LoadMode，自动转为InGame";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			eloadMode = ELoadMode.InGame;
		}
		if (eloadMode == ELoadMode.InGame)
		{
			if (this.LoadMode != ELoadMode.None && !this.IsReasonTargetNotDefault(reason))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.GameMode;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[LoadModeManager] SetLoadModeByReason时发现不成对";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("TargetLoadMode", eloadMode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("CurrentLoadMode", this.ReasonToLoadMode.GetValueOrDefault(reason, ELoadMode.None));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Reason", reason);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
			this.ReasonToLoadMode.Remove(reason);
		}
		else
		{
			this.ReasonToLoadMode[reason] = eloadMode;
		}
		this.CheckAndUpdateLoadMode();
	}

	// Token: 0x060031D0 RID: 12752 RVA: 0x0001F1B7 File Offset: 0x0001D3B7
	public void ResetLoadModeByReason(ELoadModeReason reason)
	{
		this.SetLoadModeByReason(ELoadMode.InGame, reason);
	}

	// Token: 0x060031D1 RID: 12753 RVA: 0x0001F1C1 File Offset: 0x0001D3C1
	public bool IsReasonTargetNotDefault(ELoadModeReason reason)
	{
		return this.ReasonToLoadMode.GetValueOrDefault(reason, ELoadMode.InGame) != ELoadMode.InGame;
	}

	// Token: 0x060031D2 RID: 12754 RVA: 0x0001F1D8 File Offset: 0x0001D3D8
	public unsafe void ClearReasonAndResetLoadMode(string debugReason)
	{
		if (this.ReasonToLoadMode.Count > 0 || this.GetLoadMode() != ELoadMode.InGame)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[LoadModeManager] 调用了特殊接口清除所有设置LoadMode的原因并重置LoadMode";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DebugReason", debugReason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentLoadMode", this.GetLoadMode());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CurrentReasonMap", this.ReasonToLoadMode);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		this.ReasonToLoadMode.Clear();
		this.CheckAndUpdateLoadMode();
	}

	// Token: 0x060031D3 RID: 12755 RVA: 0x0001F288 File Offset: 0x0001D488
	public bool IsLoadModeInGameOrForceInGame()
	{
		ELoadMode loadMode = this.LoadMode;
		return loadMode == ELoadMode.InGame || loadMode == ELoadMode.ForceInGame;
	}

	// Token: 0x060031D4 RID: 12756 RVA: 0x0001F2AC File Offset: 0x0001D4AC
	public LoadModeManager()
	{
		Dictionary<ELoadMode, LoadModeManager.LoadModeData> dictionary = new Dictionary<ELoadMode, LoadModeManager.LoadModeData>();
		ELoadMode key = ELoadMode.None;
		LoadModeManager.LoadModeData loadModeData = new LoadModeManager.LoadModeData();
		loadModeData.Priority = -1;
		loadModeData.SharedStayTimeLimit = -1;
		loadModeData.HandlerCtor = (() => new LoadModeHandlerNone());
		dictionary.Add(key, loadModeData);
		ELoadMode key2 = ELoadMode.InGame;
		LoadModeManager.LoadModeData loadModeData2 = new LoadModeManager.LoadModeData();
		loadModeData2.Priority = 0;
		loadModeData2.SharedStayTimeLimit = -1;
		loadModeData2.HandlerCtor = (() => new LoadModeHandlerInGame());
		dictionary.Add(key2, loadModeData2);
		ELoadMode key3 = ELoadMode.InGameLoading;
		LoadModeManager.LoadModeData loadModeData3 = new LoadModeManager.LoadModeData();
		loadModeData3.Priority = 5;
		loadModeData3.SharedStayTimeLimit = (Singleton<Info>.Instance.IsPlayInEditor ? 900000 : 180000);
		loadModeData3.HandlerCtor = (() => new LoadModeHandlerInGameLoading());
		dictionary.Add(key3, loadModeData3);
		ELoadMode key4 = ELoadMode.Loading;
		LoadModeManager.LoadModeData loadModeData4 = new LoadModeManager.LoadModeData();
		loadModeData4.Priority = 10;
		loadModeData4.SharedStayTimeLimit = (Singleton<Info>.Instance.IsPlayInEditor ? 900000 : 180000);
		loadModeData4.HandlerCtor = (() => new LoadModeHandlerLoading());
		dictionary.Add(key4, loadModeData4);
		ELoadMode key5 = ELoadMode.ForceInGame;
		LoadModeManager.LoadModeData loadModeData5 = new LoadModeManager.LoadModeData();
		loadModeData5.Priority = 99;
		loadModeData5.SharedStayTimeLimit = -1;
		loadModeData5.HandlerCtor = (() => new LoadModeHandlerInGame());
		dictionary.Add(key5, loadModeData5);
		this.LoadModeToDataRecord = dictionary;
		this.ReasonToLoadMode = new Dictionary<ELoadModeReason, ELoadMode>();
		base..ctor();
	}

	// Token: 0x040004BC RID: 1212
	private const int RESET_TIME = 180000;

	// Token: 0x040004BD RID: 1213
	private const int RESET_TIME_PIE = 900000;

	// Token: 0x040004BE RID: 1214
	private readonly Dictionary<ELoadMode, LoadModeManager.LoadModeData> LoadModeToDataRecord;

	// Token: 0x040004BF RID: 1215
	private ELoadMode LoadMode;

	// Token: 0x040004C0 RID: 1216
	private readonly Dictionary<ELoadModeReason, ELoadMode> ReasonToLoadMode;

	// Token: 0x040004C1 RID: 1217
	[Nullable(2)]
	private TimerHandle LoadModeResetTimerHandle;

	// Token: 0x020071B6 RID: 29110
	[NullableContext(0)]
	[RequiredMember]
	private class LoadModeData
	{
		// Token: 0x060467DC RID: 288732 RVA: 0x012ADD2E File Offset: 0x012ABF2E
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public LoadModeData()
		{
		}

		// Token: 0x0402795C RID: 162140
		public int Priority;

		// Token: 0x0402795D RID: 162141
		public int SharedStayTimeLimit;

		// Token: 0x0402795E RID: 162142
		[Nullable(1)]
		[RequiredMember]
		public Func<ILoadModeHandler> HandlerCtor;

		// Token: 0x0402795F RID: 162143
		[Nullable(2)]
		public ILoadModeHandler HandlerInstance;
	}
}
