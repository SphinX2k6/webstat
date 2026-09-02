using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000BE8 RID: 3048
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TickSystem : Singleton<TickSystem>
{
	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x06003242 RID: 12866 RVA: 0x00021DD1 File Offset: 0x0001FFD1
	// (set) Token: 0x06003243 RID: 12867 RVA: 0x00021DEF File Offset: 0x0001FFEF
	public bool IsPaused
	{
		get
		{
			return this.IsPausedInternal && Singleton<Time>.Instance.Frame > this.PausedFrame;
		}
		set
		{
			this.IsPausedInternal = value;
			if (value)
			{
				this.PausedFrame = Singleton<Time>.Instance.Frame;
			}
		}
	}

	// Token: 0x170000C7 RID: 199
	// (get) Token: 0x06003244 RID: 12868 RVA: 0x00021E0B File Offset: 0x0002000B
	public bool IsSetPaused
	{
		get
		{
			return this.IsPausedInternal;
		}
	}

	// Token: 0x06003245 RID: 12869 RVA: 0x00021E13 File Offset: 0x00020013
	public void Initialize(UGameInstance gameInstance)
	{
		this.KuroTickManager = new UKuroTickManager(gameInstance, null, EObjectFlags.RF_NoFlags);
		this.Tickers.Clear();
		this.Groups.Clear();
	}

	// Token: 0x06003246 RID: 12870 RVA: 0x00021E3C File Offset: 0x0002003C
	public void Destroy()
	{
		foreach (KeyValuePair<ETickingGroup, Action<float>> keyValuePair in this.Delegates)
		{
			ETickingGroup etickingGroup;
			Action<float> callBack;
			keyValuePair.Deconstruct(out etickingGroup, out callBack);
			global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
		}
		this.KuroTickManager.ClearTick();
	}

	// Token: 0x06003247 RID: 12871 RVA: 0x00021EA4 File Offset: 0x000200A4
	public bool Has(int id)
	{
		return id > 0 && this.Tickers.ContainsKey(id);
	}

	// Token: 0x06003248 RID: 12872 RVA: 0x00021EB8 File Offset: 0x000200B8
	[NullableContext(2)]
	public Ticker Add(Action<float> handle, [Nullable(1)] string name, ETickingGroup group = ETickingGroup.TG_PrePhysics, bool tickEvenPaused = false, int priority = 0, bool ignoreSelfCenterMode = false)
	{
		if (handle == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Tick;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "处理方法不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", handle);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		int num = this.Increment + 1;
		this.Increment = num;
		int num2 = num;
		Ticker ticker = new Ticker(num2, handle, group, priority, name, 0, tickEvenPaused, ignoreSelfCenterMode);
		this.Tickers[num2] = ticker;
		List<List<Ticker>> list;
		this.Groups.TryGetValue(group, out list);
		if (list == null)
		{
			list = new List<List<Ticker>>();
			this.Groups[group] = list;
		}
		while (list.Count <= priority)
		{
			list.Add(null);
		}
		List<Ticker> set = list[priority];
		if (set != null)
		{
			set.Add(ticker);
			return ticker;
		}
		set = new List<Ticker>();
		set.Add(ticker);
		list[priority] = set;
		Action<float> action = delegate(float delta)
		{
			this.IsIterating = true;
			this.IteratingGroup = group;
			this.IteratingPriority = priority;
			float num3 = delta * 1000f;
			for (int i = 0; i < set.Count; i++)
			{
				Ticker ticker2 = set[i];
				if (!ticker2.PendingRemove && (!this.IsPaused || ticker2.TickEvenPaused))
				{
					float delta2 = ticker2.IgnoreSelfCenterMode ? (num3 * Singleton<Time>.Instance.InverseSelfCenteredTimeDilation) : num3;
					this.Handle(ticker2, delta2);
				}
			}
			this.IsIterating = false;
			foreach (int id in this.PendingRemoveIds)
			{
				this.Remove(id);
			}
			this.PendingRemoveIds.Clear();
		};
		this.Delegates[group] = action;
		this.KuroTickManager.AddTick(group, global::DelegateUtils.ToManualReleaseDelegate<FTickHandler>(action), priority);
		return ticker;
	}

	// Token: 0x06003249 RID: 12873 RVA: 0x00022020 File Offset: 0x00020220
	public unsafe bool Remove(int id)
	{
		Ticker ticker;
		this.Tickers.TryGetValue(id, out ticker);
		if (ticker == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Tick;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "编号不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (this.IsIterating && this.IteratingGroup == ticker.Group && this.IteratingPriority == ticker.Priority)
		{
			ticker.PendingRemove = true;
			this.PendingRemoveIds.Add(id);
			return true;
		}
		this.Tickers.Remove(id);
		List<List<Ticker>> list;
		this.Groups.TryGetValue(ticker.Group, out list);
		if (list == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Tick;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "分组不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("group", ticker.Group);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (list.Count <= ticker.Priority || list[ticker.Priority] == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Tick;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "优先级不存在";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("id", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("group", ticker.Group);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("priority", ticker.Priority);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return false;
		}
		List<Ticker> list2 = list[ticker.Priority];
		list2.Remove(ticker);
		if (list2.Count == 0)
		{
			this.Groups.Remove(ticker.Group);
			Action<float> callBack;
			this.Delegates.TryGetValue(ticker.Group, out callBack);
			this.Delegates.Remove(ticker.Group);
			this.KuroTickManager.RemoveTick(ticker.Group);
			global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
		}
		return true;
	}

	// Token: 0x0600324A RID: 12874 RVA: 0x00022240 File Offset: 0x00020440
	public bool Pause(int id)
	{
		Ticker ticker;
		this.Tickers.TryGetValue(id, out ticker);
		if (ticker == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Tick;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "编号不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		ticker.Pause = true;
		return true;
	}

	// Token: 0x0600324B RID: 12875 RVA: 0x00022294 File Offset: 0x00020494
	public bool Resume(int id)
	{
		Ticker ticker;
		this.Tickers.TryGetValue(id, out ticker);
		if (ticker == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Tick;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "编号不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		ticker.Pause = false;
		return true;
	}

	// Token: 0x0600324C RID: 12876 RVA: 0x000222E8 File Offset: 0x000204E8
	private unsafe void Handle(Ticker ticker, float delta)
	{
		if (ticker.Pause)
		{
			return;
		}
		float obj = delta;
		if (ticker.TickIntervalMs > 0)
		{
			ticker.CoolDown += delta;
			if (ticker.CoolDown < (float)ticker.TickIntervalMs)
			{
				return;
			}
			float num = ticker.CoolDown % (float)ticker.TickIntervalMs;
			obj = ticker.CoolDown - num;
			ticker.CoolDown = num;
		}
		ticker.Count++;
		double milliseconds = KuroTime.GetMilliseconds64();
		try
		{
			ticker.Handle(obj);
		}
		catch (Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Tick;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "处理方法执行异常";
			Exception error = ex;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", ticker.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		if (Singleton<PerfSight>.Instance.IsEnable && ticker.Group == ETickingGroup.TG_PrePhysics)
		{
			int maxFps = UKuroRenderingRuntimeBPPluginBPLibrary.GetMaxFps();
			double num2 = 1000.0 / (double)maxFps;
			float gameThreadTime = UKuroRenderingRuntimeBPPluginBPLibrary.GetGameThreadTime();
			float renderThreadTime = UKuroRenderingRuntimeBPPluginBPLibrary.GetRenderThreadTime();
			if ((double)gameThreadTime > num2 * 2.0 || (double)renderThreadTime > num2 * 2.0)
			{
				double num3 = KuroTime.GetMilliseconds64() - milliseconds;
				if (ticker.Name == "Core")
				{
					FKuroPerfSightHelper.PostValueFloat1("CustomPerformance", "[PrePhysics]TickSystem_Core", (float)num3);
					return;
				}
				if (ticker.Name == "Game")
				{
					FKuroPerfSightHelper.PostValueFloat1("CustomPerformance", "[PrePhysics]TickSystem_Game", (float)num3);
					FKuroPerfSightHelper.PostValueFloat1("CustomPerformance", "[PrePhysics]TickSystem_GameThreadTime", gameThreadTime);
					FKuroPerfSightHelper.PostValueFloat1("CustomPerformance", "[PrePhysics]TickSystem_RenderThreadTime", renderThreadTime);
					FKuroPerfSightHelper.PostValueFloat1("CustomPerformance", "[PrePhysics]TickSystem_RHIThreadTime", UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIThreadTime());
					FKuroPerfSightHelper.PostValueFloat1("CustomPerformance", "[PrePhysics]TickSystem_PresentTime", UKuroRenderingRuntimeBPPluginBPLibrary.GetSwapBufferTime());
				}
			}
		}
	}

	// Token: 0x0600324D RID: 12877 RVA: 0x000224E0 File Offset: 0x000206E0
	public void AddTickPrerequisiteActor(ETickingGroup group, AActor actor, int priority)
	{
		this.KuroTickManager.AddPrerequisiteActor(group, actor, priority);
	}

	// Token: 0x0600324E RID: 12878 RVA: 0x000224F0 File Offset: 0x000206F0
	public void RemoveTickPrerequisiteActor(ETickingGroup group, AActor actor, int priority)
	{
		this.KuroTickManager.RemovePrerequisiteActor(group, actor, priority);
	}

	// Token: 0x0600324F RID: 12879 RVA: 0x00022500 File Offset: 0x00020700
	public void AddTickPrerequisiteActorComp(ETickingGroup group, UActorComponent comp, int priority)
	{
		this.KuroTickManager.AddPrerequisiteActorComponent(group, comp, priority);
	}

	// Token: 0x06003250 RID: 12880 RVA: 0x00022510 File Offset: 0x00020710
	public void RemoveTickPrerequisiteActorComp(ETickingGroup group, UActorComponent comp, int priority)
	{
		this.KuroTickManager.RemovePrerequisiteActorComponent(group, comp, priority);
	}

	// Token: 0x06003251 RID: 12881 RVA: 0x00022520 File Offset: 0x00020720
	public void SetSkeletalMeshProxyTickFunction(ETickingGroup group, USkeletalMeshComponent comp, int priority)
	{
		this.KuroTickManager.SetSkeletalMeshProxyTickFunction(group, comp, priority);
	}

	// Token: 0x06003252 RID: 12882 RVA: 0x00022530 File Offset: 0x00020730
	public void CleanSkeletalMeshProxyTickFunction(USkeletalMeshComponent comp)
	{
		this.KuroTickManager.CleanSkeletalMeshProxyTickFunction(comp);
	}

	// Token: 0x06003253 RID: 12883 RVA: 0x0002253E File Offset: 0x0002073E
	public void SetMovementProxyTickFunction(ETickingGroup group, UCharacterMovementComponent comp, int priority)
	{
		this.KuroTickManager.SetCharacterMovementProxyTickFunction(group, comp, priority);
	}

	// Token: 0x06003254 RID: 12884 RVA: 0x0002254E File Offset: 0x0002074E
	public void CleanMovementProxyTickFunction(UCharacterMovementComponent comp)
	{
		this.KuroTickManager.CleanCharacterMovementProxyTickFunction(comp);
	}

	// Token: 0x06003255 RID: 12885 RVA: 0x0002255C File Offset: 0x0002075C
	public void SetTickFunctionCompletionCallbackInMainThread(ETickingGroup group, int priority)
	{
		this.KuroTickManager.SetTickFunctionCompletionCallbackInMainThread(group, priority);
	}

	// Token: 0x06003256 RID: 12886 RVA: 0x0002256B File Offset: 0x0002076B
	public void SetGamePrerequisiteTickFunction(ETickingGroup group, int priority)
	{
		this.KuroTickManager.SetGamePrerequisiteTickFunction(group, priority);
	}

	// Token: 0x04000525 RID: 1317
	private const int SECOND_TO_MILLISECOND = 1000;

	// Token: 0x04000526 RID: 1318
	public const int InvalidId = -1;

	// Token: 0x04000527 RID: 1319
	private bool IsPausedInternal;

	// Token: 0x04000528 RID: 1320
	public int PausedFrame = -1;

	// Token: 0x04000529 RID: 1321
	private int Increment;

	// Token: 0x0400052A RID: 1322
	[Nullable(2)]
	private UKuroTickManager KuroTickManager;

	// Token: 0x0400052B RID: 1323
	private readonly Dictionary<int, Ticker> Tickers = new Dictionary<int, Ticker>();

	// Token: 0x0400052C RID: 1324
	private readonly Dictionary<ETickingGroup, Action<float>> Delegates = new Dictionary<ETickingGroup, Action<float>>();

	// Token: 0x0400052D RID: 1325
	[Nullable(new byte[]
	{
		1,
		1,
		2,
		1
	})]
	private readonly Dictionary<ETickingGroup, List<List<Ticker>>> Groups = new Dictionary<ETickingGroup, List<List<Ticker>>>();

	// Token: 0x0400052E RID: 1326
	private readonly HashSet<int> PendingRemoveIds = new HashSet<int>();

	// Token: 0x0400052F RID: 1327
	private bool IsIterating;

	// Token: 0x04000530 RID: 1328
	private ETickingGroup IteratingGroup;

	// Token: 0x04000531 RID: 1329
	private int IteratingPriority;
}
