using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002A24 RID: 10788
[UClass("/Game/Aki/TypeScript/Game/Module/SkeletalObserver/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/SkeletalObserver/TsSkeletalObserver.TsSkeletalObserver_C")]
public class TsSkeletalObserver : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001C04 RID: 7172
	// (get) Token: 0x0601588B RID: 88203 RVA: 0x005F8B97 File Offset: 0x005F6D97
	// (set) Token: 0x0601588C RID: 88204 RVA: 0x005F8B9F File Offset: 0x005F6D9F
	public EUiModelUseWay UseWay { get; set; }

	// Token: 0x0601588D RID: 88205 RVA: 0x005F8BA8 File Offset: 0x005F6DA8
	public void Init(EUiModelUseWay useWay)
	{
		base.SetTickableWhenPaused(true);
		base.SetActorTickEnabled(true);
		UKuroRenderingRuntimeBPPluginBPLibrary.SetActorUISceneRendering(this, true);
		this.UseWay = useWay;
		this.Model = Singleton<UiModelSystem>.Instance.CreateUiModelByUseWay(useWay, this);
		this.Model.Init();
		this.Model.Start();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCommon;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "TsSkeletalObserver Init";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("UseWay", this.UseWay);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601588E RID: 88206 RVA: 0x005F8C2C File Offset: 0x005F6E2C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSecond)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSecond;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601588F RID: 88207 RVA: 0x005F8CA2 File Offset: 0x005F6EA2
	protected virtual void ReceiveTick_Implementation(float deltaSecond)
	{
		UiModelBase model = this.Model;
		if (model == null)
		{
			return;
		}
		model.Tick(deltaSecond);
	}

	// Token: 0x06015890 RID: 88208 RVA: 0x005F8CB8 File Offset: 0x005F6EB8
	public void Destroy()
	{
		UiModelBase model = this.Model;
		if (model != null)
		{
			model.End();
		}
		UiModelBase model2 = this.Model;
		if (model2 != null)
		{
			model2.Clear();
		}
		this.Model = null;
		Singleton<ActorSystem>.Instance.Put("TsSkeletalObserver.Destroy", this, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCommon;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "TsSkeletalObserver Destroy";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("UseWay", this.UseWay);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015891 RID: 88209 RVA: 0x005F8D31 File Offset: 0x005F6F31
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSkeletalObserver._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/SkeletalObserver/TsSkeletalObserver.TsSkeletalObserver_C");
		}
		return TsSkeletalObserver._ClassPtr;
	}

	// Token: 0x06015892 RID: 88210 RVA: 0x005F8D58 File Offset: 0x005F6F58
	public TsSkeletalObserver() : this(BuiltinUtils.AllocNativeUObject(TsSkeletalObserver.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06015893 RID: 88211 RVA: 0x005F8D80 File Offset: 0x005F6F80
	[NullableContext(1)]
	public TsSkeletalObserver(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSkeletalObserver.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06015894 RID: 88212 RVA: 0x005F8DB3 File Offset: 0x005F6FB3
	protected TsSkeletalObserver(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x17001C05 RID: 7173
	// (get) Token: 0x06015895 RID: 88213 RVA: 0x005F8DBC File Offset: 0x005F6FBC
	[Nullable(1)]
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		[NullableContext(1)]
		get
		{
			return *(base.NativePtr + (IntPtr)TsSkeletalObserver.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x17001C06 RID: 7174
	// (get) Token: 0x06015896 RID: 88214 RVA: 0x005F8DCC File Offset: 0x005F6FCC
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsSkeletalObserver.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x06015897 RID: 88215 RVA: 0x005F8DE0 File Offset: 0x005F6FE0
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0400A5D8 RID: 42456
	[Nullable(2)]
	public UiModelBase Model;

	// Token: 0x0400A5DA RID: 42458
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/SkeletalObserver/TsSkeletalObserver.TsSkeletalObserver_C";

	// Token: 0x0400A5DB RID: 42459
	private static IntPtr _ClassPtr;

	// Token: 0x0400A5DC RID: 42460
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400A5DD RID: 42461
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400A5DE RID: 42462
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x02008DA5 RID: 36261
	// (Invoke) Token: 0x060499B6 RID: 301494
	public delegate void TLoadSkeletalMeshCallBack(USkeletalMesh skeletalMesh);
}
