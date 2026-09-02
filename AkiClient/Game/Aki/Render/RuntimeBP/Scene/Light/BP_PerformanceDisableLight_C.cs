using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A91 RID: 14993
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_PerformanceDisableLight.BP_PerformanceDisableLight_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1340)]
	public class BP_PerformanceDisableLight_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F8B8 RID: 129208 RVA: 0x00914548 File Offset: 0x00912748
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PerformanceDisableLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_PerformanceDisableLight.BP_PerformanceDisableLight_C");
			}
			return BP_PerformanceDisableLight_C._ClassPtr;
		}

		// Token: 0x0601F8B9 RID: 129209 RVA: 0x0091456C File Offset: 0x0091276C
		public BP_PerformanceDisableLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_PerformanceDisableLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F8BA RID: 129210 RVA: 0x00914594 File Offset: 0x00912794
		[NullableContext(1)]
		public BP_PerformanceDisableLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PerformanceDisableLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003091 RID: 12433
		// (get) Token: 0x0601F8BB RID: 129211 RVA: 0x009145C8 File Offset: 0x009127C8
		// (set) Token: 0x0601F8BC RID: 129212 RVA: 0x00914601 File Offset: 0x00912801
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003092 RID: 12434
		// (get) Token: 0x0601F8BD RID: 129213 RVA: 0x00914622 File Offset: 0x00912822
		// (set) Token: 0x0601F8BE RID: 129214 RVA: 0x00914636 File Offset: 0x00912836
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PerformanceDisableLight_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PerformanceDisableLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003093 RID: 12435
		// (get) Token: 0x0601F8BF RID: 129215 RVA: 0x0091464B File Offset: 0x0091284B
		// (set) Token: 0x0601F8C0 RID: 129216 RVA: 0x0091465B File Offset: 0x0091285B
		public unsafe float SceneLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003094 RID: 12436
		// (get) Token: 0x0601F8C1 RID: 129217 RVA: 0x0091466C File Offset: 0x0091286C
		// (set) Token: 0x0601F8C2 RID: 129218 RVA: 0x0091467C File Offset: 0x0091287C
		public unsafe float ToonLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003095 RID: 12437
		// (get) Token: 0x0601F8C3 RID: 129219 RVA: 0x0091468D File Offset: 0x0091288D
		// (set) Token: 0x0601F8C4 RID: 129220 RVA: 0x0091469D File Offset: 0x0091289D
		public unsafe bool DisableLight_Store
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003096 RID: 12438
		// (get) Token: 0x0601F8C5 RID: 129221 RVA: 0x009146AE File Offset: 0x009128AE
		// (set) Token: 0x0601F8C6 RID: 129222 RVA: 0x009146BE File Offset: 0x009128BE
		public unsafe bool DisableLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003097 RID: 12439
		// (get) Token: 0x0601F8C7 RID: 129223 RVA: 0x009146CF File Offset: 0x009128CF
		// (set) Token: 0x0601F8C8 RID: 129224 RVA: 0x009146DF File Offset: 0x009128DF
		public unsafe bool DisableToonLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003098 RID: 12440
		// (get) Token: 0x0601F8C9 RID: 129225 RVA: 0x009146F0 File Offset: 0x009128F0
		// (set) Token: 0x0601F8CA RID: 129226 RVA: 0x00914700 File Offset: 0x00912900
		public unsafe bool DisableToonLight_Store
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F8CB RID: 129227 RVA: 0x00914711 File Offset: 0x00912911
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__TickFunction_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8CC RID: 129228 RVA: 0x00914725 File Offset: 0x00912925
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableToonLightFun()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__DisableToonLightFun_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8CD RID: 129229 RVA: 0x00914739 File Offset: 0x00912939
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableLightFun()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__DisableLightFun_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8CE RID: 129230 RVA: 0x0091474D File Offset: 0x0091294D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8CF RID: 129231 RVA: 0x00914761 File Offset: 0x00912961
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8D0 RID: 129232 RVA: 0x00914776 File Offset: 0x00912976
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8D1 RID: 129233 RVA: 0x0091478A File Offset: 0x0091298A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8D2 RID: 129234 RVA: 0x009147A0 File Offset: 0x009129A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PerformanceDisableLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PerformanceDisableLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PerformanceDisableLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PerformanceDisableLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F8D3 RID: 129235 RVA: 0x009147E8 File Offset: 0x009129E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PerformanceDisableLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PerformanceDisableLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PerformanceDisableLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PerformanceDisableLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8D4 RID: 129236 RVA: 0x00914830 File Offset: 0x00912A30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PerformanceDisableLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PerformanceDisableLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PerformanceDisableLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PerformanceDisableLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F8D5 RID: 129237 RVA: 0x00914878 File Offset: 0x00912A78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PerformanceDisableLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PerformanceDisableLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PerformanceDisableLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PerformanceDisableLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8D6 RID: 129238 RVA: 0x009148BF File Offset: 0x00912ABF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8D7 RID: 129239 RVA: 0x009148D3 File Offset: 0x00912AD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8D8 RID: 129240 RVA: 0x009148E8 File Offset: 0x00912AE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PerformanceDisableLight(int EntryPoint)
		{
			BP_PerformanceDisableLight_C.__ExecuteUbergraph_BP_PerformanceDisableLight_FunctionParams* ptr = stackalloc BP_PerformanceDisableLight_C.__ExecuteUbergraph_BP_PerformanceDisableLight_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_PerformanceDisableLight_C.__ExecuteUbergraph_BP_PerformanceDisableLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PerformanceDisableLight_C.__ExecuteUbergraph_BP_PerformanceDisableLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_C.__ExecuteUbergraph_BP_PerformanceDisableLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8D9 RID: 129241 RVA: 0x0091492F File Offset: 0x00912B2F
		protected BP_PerformanceDisableLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FAD2 RID: 64210
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_PerformanceDisableLight.BP_PerformanceDisableLight_C";

		// Token: 0x0400FAD3 RID: 64211
		private static IntPtr _ClassPtr;

		// Token: 0x0400FAD4 RID: 64212
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FAD5 RID: 64213
		internal static int __PropertyOffset_0;

		// Token: 0x0400FAD6 RID: 64214
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FAD7 RID: 64215
		internal static int __PropertyOffset_1;

		// Token: 0x0400FAD8 RID: 64216
		internal static int __PropertyOffset_2;

		// Token: 0x0400FAD9 RID: 64217
		internal static int __PropertyOffset_3;

		// Token: 0x0400FADA RID: 64218
		internal static int __PropertyOffset_4;

		// Token: 0x0400FADB RID: 64219
		internal static int __PropertyOffset_5;

		// Token: 0x0400FADC RID: 64220
		internal static int __PropertyOffset_6;

		// Token: 0x0400FADD RID: 64221
		internal static int __PropertyOffset_7;

		// Token: 0x0400FADE RID: 64222
		private static IntPtr __TickFunction_NativeFunctionPtr;

		// Token: 0x0400FADF RID: 64223
		private static IntPtr __DisableToonLightFun_NativeFunctionPtr;

		// Token: 0x0400FAE0 RID: 64224
		private static IntPtr __DisableLightFun_NativeFunctionPtr;

		// Token: 0x0400FAE1 RID: 64225
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FAE2 RID: 64226
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FAE3 RID: 64227
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FAE4 RID: 64228
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FAE5 RID: 64229
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FAE6 RID: 64230
		private static IntPtr __ExecuteUbergraph_BP_PerformanceDisableLight_NativeFunctionPtr;

		// Token: 0x020098F6 RID: 39158
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F55 RID: 204629
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098F7 RID: 39159
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F56 RID: 204630
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098F8 RID: 39160
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_PerformanceDisableLight_FunctionParams
		{
			// Token: 0x04031F57 RID: 204631
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
