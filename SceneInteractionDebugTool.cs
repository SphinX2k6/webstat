using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction;
using CSharpScript.Game.Render;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003425 RID: 13349
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Scene/Interaction/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Scene/Interaction/SceneInteractionDebugTool.SceneInteractionDebugTool_C")]
public class SceneInteractionDebugTool : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025AF RID: 9647
	// (get) Token: 0x0601BDC1 RID: 114113 RVA: 0x0084E8EC File Offset: 0x0084CAEC
	// (set) Token: 0x0601BDC2 RID: 114114 RVA: 0x0084E925 File Offset: 0x0084CB25
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public SWaterEffectObject Config
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			SWaterEffectObject result;
			if ((result = this._Config) == null)
			{
				result = (this._Config = new SWaterEffectObject(base.NativePtr + (IntPtr)SceneInteractionDebugTool.__PropertyOffset_Config, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SWaterEffectObject.StaticStruct(), base.NativePtr + (IntPtr)SceneInteractionDebugTool.__PropertyOffset_Config, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025B0 RID: 9648
	// (get) Token: 0x0601BDC3 RID: 114115 RVA: 0x0084E94D File Offset: 0x0084CB4D
	// (set) Token: 0x0601BDC4 RID: 114116 RVA: 0x0084E961 File Offset: 0x0084CB61
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor TargetActor
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionDebugTool.__PropertyOffset_TargetActor);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionDebugTool.__PropertyOffset_TargetActor, value);
		}
	}

	// Token: 0x170025B1 RID: 9649
	// (get) Token: 0x0601BDC5 RID: 114117 RVA: 0x0084E976 File Offset: 0x0084CB76
	// (set) Token: 0x0601BDC6 RID: 114118 RVA: 0x0084E97E File Offset: 0x0084CB7E
	private SceneObjectWaterEffect Interaction { get; set; }

	// Token: 0x0601BDC7 RID: 114119 RVA: 0x0084E988 File Offset: 0x0084CB88
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AttachInteraction()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AttachInteraction"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BDC8 RID: 114120 RVA: 0x0084E9F8 File Offset: 0x0084CBF8
	protected void AttachInteraction_Implementation()
	{
		if (this.TargetActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "SceneInteractionDebugTool缺少目标对象", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (this.Interaction != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "SceneInteractionDebugTool勿重复添加", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.Interaction = new SceneObjectWaterEffect();
		this.Interaction.Start(this.Config, this.TargetActor.K2_GetRootComponent());
		SceneInteractionManager.Get().RegisterWaterEffectObject(this.Interaction);
	}

	// Token: 0x0601BDC9 RID: 114121 RVA: 0x0084EA84 File Offset: 0x0084CC84
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveInteraction()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveInteraction"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BDCA RID: 114122 RVA: 0x0084EAF4 File Offset: 0x0084CCF4
	protected void RemoveInteraction_Implementation()
	{
		if (this.Interaction == null)
		{
			return;
		}
		SceneInteractionManager.Get().UnregisterWaterEffectObject(this.Interaction);
		this.Interaction = null;
	}

	// Token: 0x0601BDCB RID: 114123 RVA: 0x0084EB16 File Offset: 0x0084CD16
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (SceneInteractionDebugTool._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Scene/Interaction/SceneInteractionDebugTool.SceneInteractionDebugTool_C");
		}
		return SceneInteractionDebugTool._ClassPtr;
	}

	// Token: 0x0601BDCC RID: 114124 RVA: 0x0084EB3C File Offset: 0x0084CD3C
	public SceneInteractionDebugTool() : this(BuiltinUtils.AllocNativeUObject(SceneInteractionDebugTool.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BDCD RID: 114125 RVA: 0x0084EB64 File Offset: 0x0084CD64
	[NullableContext(1)]
	public SceneInteractionDebugTool(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneInteractionDebugTool.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BDCE RID: 114126 RVA: 0x0084EB97 File Offset: 0x0084CD97
	protected SceneInteractionDebugTool(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x170025B2 RID: 9650
	// (get) Token: 0x0601BDCF RID: 114127 RVA: 0x0084EBA0 File Offset: 0x0084CDA0
	[Nullable(1)]
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		[NullableContext(1)]
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugTool.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x170025B3 RID: 9651
	// (get) Token: 0x0601BDD0 RID: 114128 RVA: 0x0084EBB0 File Offset: 0x0084CDB0
	public unsafe USceneComponent DefaultSceneRoot
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionDebugTool.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x0601BDD1 RID: 114129 RVA: 0x0084EBC4 File Offset: 0x0084CDC4
	protected virtual void __CPPCALL_AttachInteraction_Implementation()
	{
		this.AttachInteraction_Implementation();
	}

	// Token: 0x0601BDD2 RID: 114130 RVA: 0x0084EBCC File Offset: 0x0084CDCC
	protected virtual void __CPPCALL_RemoveInteraction_Implementation()
	{
		this.RemoveInteraction_Implementation();
	}

	// Token: 0x0400E125 RID: 57637
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Scene/Interaction/SceneInteractionDebugTool.SceneInteractionDebugTool_C";

	// Token: 0x0400E126 RID: 57638
	private static IntPtr _ClassPtr;

	// Token: 0x0400E127 RID: 57639
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E128 RID: 57640
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400E129 RID: 57641
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x0400E12A RID: 57642
	private static int __PropertyOffset_Config;

	// Token: 0x0400E12B RID: 57643
	private SWaterEffectObject _Config;

	// Token: 0x0400E12C RID: 57644
	private static int __PropertyOffset_TargetActor;
}
