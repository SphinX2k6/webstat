using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002C54 RID: 11348
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Module/UiComponent/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiSceneDangoActor.TsUiSceneDangoActor_C")]
public class TsUiSceneDangoActor : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001DD5 RID: 7637
	// (get) Token: 0x06016C02 RID: 93186 RVA: 0x0064FC50 File Offset: 0x0064DE50
	// (set) Token: 0x06016C03 RID: 93187 RVA: 0x0064FC58 File Offset: 0x0064DE58
	public UiModelBase Model { get; private set; }

	// Token: 0x17001DD6 RID: 7638
	// (get) Token: 0x06016C04 RID: 93188 RVA: 0x0064FC61 File Offset: 0x0064DE61
	// (set) Token: 0x06016C05 RID: 93189 RVA: 0x0064FC69 File Offset: 0x0064DE69
	private int ActorIndex { get; set; }

	// Token: 0x06016C06 RID: 93190 RVA: 0x0064FC74 File Offset: 0x0064DE74
	public void Init(int actorIndex, int useWay)
	{
		this.ActorIndex = actorIndex;
		base.SetTickableWhenPaused(true);
		base.SetActorTickEnabled(true);
		base.CustomTimeDilation = ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation;
		UKuroRenderingRuntimeBPPluginBPLibrary.SetActorUISceneRendering(this, true);
		this.Model = Singleton<UiModelSystem>.Instance.CreateUiModelByUseWay((EUiModelUseWay)useWay, this);
		UiModelBase model = this.Model;
		if (model != null)
		{
			model.Init();
		}
		UiModelBase model2 = this.Model;
		if (model2 != null)
		{
			model2.Start();
		}
		base.SetPrimitiveEntityType(1U);
	}

	// Token: 0x06016C07 RID: 93191 RVA: 0x0064FCE8 File Offset: 0x0064DEE8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06016C08 RID: 93192 RVA: 0x0064FD5E File Offset: 0x0064DF5E
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
		UiModelBase model = this.Model;
		if (model == null)
		{
			return;
		}
		model.Tick(deltaSeconds);
	}

	// Token: 0x06016C09 RID: 93193 RVA: 0x0064FD71 File Offset: 0x0064DF71
	public int GetActorIndex()
	{
		return this.ActorIndex;
	}

	// Token: 0x06016C0A RID: 93194 RVA: 0x0064FD79 File Offset: 0x0064DF79
	public void SetState(EDangoState state, float stateParam = 0f, float stateParam2 = 0f)
	{
		UiDangoStateMachineComponent stateMachine = this.GetStateMachine();
		if (stateMachine == null)
		{
			return;
		}
		stateMachine.SetState(state, stateParam, stateParam2);
	}

	// Token: 0x06016C0B RID: 93195 RVA: 0x0064FD8E File Offset: 0x0064DF8E
	public UiDangoStateMachineComponent GetStateMachine()
	{
		UiModelBase model = this.Model;
		if (model == null)
		{
			return null;
		}
		return model.CheckGetComponent<UiDangoStateMachineComponent>();
	}

	// Token: 0x06016C0C RID: 93196 RVA: 0x0064FDA4 File Offset: 0x0064DFA4
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
		this.ActorIndex = 0;
		Singleton<ActorSystem>.Instance.Put("TsUiSceneDangoActor.Destroy", this, null);
	}

	// Token: 0x06016C0D RID: 93197 RVA: 0x0064FDF3 File Offset: 0x0064DFF3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiSceneDangoActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiSceneDangoActor.TsUiSceneDangoActor_C");
		}
		return TsUiSceneDangoActor._ClassPtr;
	}

	// Token: 0x06016C0E RID: 93198 RVA: 0x0064FE18 File Offset: 0x0064E018
	public TsUiSceneDangoActor() : this(BuiltinUtils.AllocNativeUObject(TsUiSceneDangoActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06016C0F RID: 93199 RVA: 0x0064FE40 File Offset: 0x0064E040
	public TsUiSceneDangoActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiSceneDangoActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06016C10 RID: 93200 RVA: 0x0064FE73 File Offset: 0x0064E073
	protected TsUiSceneDangoActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x17001DD7 RID: 7639
	// (get) Token: 0x06016C11 RID: 93201 RVA: 0x0064FE7C File Offset: 0x0064E07C
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiSceneDangoActor.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x17001DD8 RID: 7640
	// (get) Token: 0x06016C12 RID: 93202 RVA: 0x0064FE8C File Offset: 0x0064E08C
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiSceneDangoActor.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x06016C13 RID: 93203 RVA: 0x0064FEA0 File Offset: 0x0064E0A0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0400AF58 RID: 44888
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiSceneDangoActor.TsUiSceneDangoActor_C";

	// Token: 0x0400AF59 RID: 44889
	private static IntPtr _ClassPtr;

	// Token: 0x0400AF5A RID: 44890
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400AF5B RID: 44891
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400AF5C RID: 44892
	private static int __PropertyOffset_DefaultSceneRoot;
}
