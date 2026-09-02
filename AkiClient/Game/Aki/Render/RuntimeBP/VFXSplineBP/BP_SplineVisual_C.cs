using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.VFXSplineBP
{
	// Token: 0x02003A10 RID: 14864
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/VFXSplineBP/BP_SplineVisual.BP_SplineVisual_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_SplineVisual_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E617 RID: 124439 RVA: 0x008F45AD File Offset: 0x008F27AD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplineVisual_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/VFXSplineBP/BP_SplineVisual.BP_SplineVisual_C");
			}
			return BP_SplineVisual_C._ClassPtr;
		}

		// Token: 0x0601E618 RID: 124440 RVA: 0x008F45D4 File Offset: 0x008F27D4
		public BP_SplineVisual_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplineVisual_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E619 RID: 124441 RVA: 0x008F45FC File Offset: 0x008F27FC
		[NullableContext(1)]
		public BP_SplineVisual_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplineVisual_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170029F0 RID: 10736
		// (get) Token: 0x0601E61A RID: 124442 RVA: 0x008F4630 File Offset: 0x008F2830
		// (set) Token: 0x0601E61B RID: 124443 RVA: 0x008F4669 File Offset: 0x008F2869
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplineVisual_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineVisual_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170029F1 RID: 10737
		// (get) Token: 0x0601E61C RID: 124444 RVA: 0x008F468A File Offset: 0x008F288A
		// (set) Token: 0x0601E61D RID: 124445 RVA: 0x008F469E File Offset: 0x008F289E
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170029F2 RID: 10738
		// (get) Token: 0x0601E61E RID: 124446 RVA: 0x008F46B3 File Offset: 0x008F28B3
		// (set) Token: 0x0601E61F RID: 124447 RVA: 0x008F46C7 File Offset: 0x008F28C7
		public unsafe URopeVerletComponent RopeVerlet
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeVerletComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170029F3 RID: 10739
		// (get) Token: 0x0601E620 RID: 124448 RVA: 0x008F46DC File Offset: 0x008F28DC
		// (set) Token: 0x0601E621 RID: 124449 RVA: 0x008F46F0 File Offset: 0x008F28F0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170029F4 RID: 10740
		// (get) Token: 0x0601E622 RID: 124450 RVA: 0x008F4705 File Offset: 0x008F2905
		// (set) Token: 0x0601E623 RID: 124451 RVA: 0x008F4719 File Offset: 0x008F2919
		public unsafe FVector StartPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineVisual_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineVisual_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170029F5 RID: 10741
		// (get) Token: 0x0601E624 RID: 124452 RVA: 0x008F472E File Offset: 0x008F292E
		// (set) Token: 0x0601E625 RID: 124453 RVA: 0x008F4742 File Offset: 0x008F2942
		public unsafe FVector EndPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineVisual_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineVisual_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170029F6 RID: 10742
		// (get) Token: 0x0601E626 RID: 124454 RVA: 0x008F4757 File Offset: 0x008F2957
		// (set) Token: 0x0601E627 RID: 124455 RVA: 0x008F476B File Offset: 0x008F296B
		public unsafe URopeVerletDataAsset RopeStaticDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeVerletDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170029F7 RID: 10743
		// (get) Token: 0x0601E628 RID: 124456 RVA: 0x008F4780 File Offset: 0x008F2980
		// (set) Token: 0x0601E629 RID: 124457 RVA: 0x008F4794 File Offset: 0x008F2994
		public unsafe URopeVerletDataAsset RopeDynamicDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeVerletDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170029F8 RID: 10744
		// (get) Token: 0x0601E62A RID: 124458 RVA: 0x008F47A9 File Offset: 0x008F29A9
		// (set) Token: 0x0601E62B RID: 124459 RVA: 0x008F47BD File Offset: 0x008F29BD
		public unsafe URopeVerletDataAsset LocalRopeDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeVerletDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170029F9 RID: 10745
		// (get) Token: 0x0601E62C RID: 124460 RVA: 0x008F47D2 File Offset: 0x008F29D2
		// (set) Token: 0x0601E62D RID: 124461 RVA: 0x008F47E6 File Offset: 0x008F29E6
		public unsafe UEffectModelNiagara NiagaraDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEffectModelNiagara>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineVisual_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x0601E62E RID: 124462 RVA: 0x008F47FB File Offset: 0x008F29FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置特效DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineVisual_C.__设置特效DA_NativeFunctionPtr, null);
		}

		// Token: 0x0601E62F RID: 124463 RVA: 0x008F480F File Offset: 0x008F2A0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置空放DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineVisual_C.__设置空放DA_NativeFunctionPtr, null);
		}

		// Token: 0x0601E630 RID: 124464 RVA: 0x008F4823 File Offset: 0x008F2A23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置战斗DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineVisual_C.__设置战斗DA_NativeFunctionPtr, null);
		}

		// Token: 0x0601E631 RID: 124465 RVA: 0x008F4837 File Offset: 0x008F2A37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRope()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineVisual_C.__InitRope_NativeFunctionPtr, null);
		}

		// Token: 0x0601E632 RID: 124466 RVA: 0x008F484B File Offset: 0x008F2A4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineVisual_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E633 RID: 124467 RVA: 0x008F485F File Offset: 0x008F2A5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineVisual_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E634 RID: 124468 RVA: 0x008F4874 File Offset: 0x008F2A74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SplineVisual_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplineVisual_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineVisual_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineVisual_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineVisual_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E635 RID: 124469 RVA: 0x008F48BC File Offset: 0x008F2ABC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SplineVisual_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplineVisual_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineVisual_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineVisual_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineVisual_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E636 RID: 124470 RVA: 0x008F4904 File Offset: 0x008F2B04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplineVisual(int EntryPoint)
		{
			BP_SplineVisual_C.__ExecuteUbergraph_BP_SplineVisual_FunctionParams* ptr = stackalloc BP_SplineVisual_C.__ExecuteUbergraph_BP_SplineVisual_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_SplineVisual_C.__ExecuteUbergraph_BP_SplineVisual_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineVisual_C.__ExecuteUbergraph_BP_SplineVisual_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineVisual_C.__ExecuteUbergraph_BP_SplineVisual_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E637 RID: 124471 RVA: 0x008F494B File Offset: 0x008F2B4B
		protected BP_SplineVisual_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EF38 RID: 61240
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/VFXSplineBP/BP_SplineVisual.BP_SplineVisual_C";

		// Token: 0x0400EF39 RID: 61241
		private static IntPtr _ClassPtr;

		// Token: 0x0400EF3A RID: 61242
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EF3B RID: 61243
		internal static int __PropertyOffset_0;

		// Token: 0x0400EF3C RID: 61244
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EF3D RID: 61245
		internal static int __PropertyOffset_1;

		// Token: 0x0400EF3E RID: 61246
		internal static int __PropertyOffset_2;

		// Token: 0x0400EF3F RID: 61247
		internal static int __PropertyOffset_3;

		// Token: 0x0400EF40 RID: 61248
		internal static int __PropertyOffset_4;

		// Token: 0x0400EF41 RID: 61249
		internal static int __PropertyOffset_5;

		// Token: 0x0400EF42 RID: 61250
		internal static int __PropertyOffset_6;

		// Token: 0x0400EF43 RID: 61251
		internal static int __PropertyOffset_7;

		// Token: 0x0400EF44 RID: 61252
		internal static int __PropertyOffset_8;

		// Token: 0x0400EF45 RID: 61253
		internal static int __PropertyOffset_9;

		// Token: 0x0400EF46 RID: 61254
		private static IntPtr __设置特效DA_NativeFunctionPtr;

		// Token: 0x0400EF47 RID: 61255
		private static IntPtr __设置空放DA_NativeFunctionPtr;

		// Token: 0x0400EF48 RID: 61256
		private static IntPtr __设置战斗DA_NativeFunctionPtr;

		// Token: 0x0400EF49 RID: 61257
		private static IntPtr __InitRope_NativeFunctionPtr;

		// Token: 0x0400EF4A RID: 61258
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EF4B RID: 61259
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400EF4C RID: 61260
		private static IntPtr __ExecuteUbergraph_BP_SplineVisual_NativeFunctionPtr;

		// Token: 0x020097B2 RID: 38834
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031D8B RID: 204171
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097B3 RID: 38835
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_SplineVisual_FunctionParams
		{
			// Token: 0x04031D8C RID: 204172
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
