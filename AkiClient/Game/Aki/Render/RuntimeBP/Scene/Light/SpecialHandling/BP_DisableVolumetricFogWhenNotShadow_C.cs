using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light.SpecialHandling
{
	// Token: 0x02003AAD RID: 15021
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/SpecialHandling/BP_DisableVolumetricFogWhenNotShadow.BP_DisableVolumetricFogWhenNotShadow_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1057)]
	public class BP_DisableVolumetricFogWhenNotShadow_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020004 RID: 131076 RVA: 0x0091F73C File Offset: 0x0091D93C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DisableVolumetricFogWhenNotShadow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/SpecialHandling/BP_DisableVolumetricFogWhenNotShadow.BP_DisableVolumetricFogWhenNotShadow_C");
			}
			return BP_DisableVolumetricFogWhenNotShadow_C._ClassPtr;
		}

		// Token: 0x06020005 RID: 131077 RVA: 0x0091F760 File Offset: 0x0091D960
		public BP_DisableVolumetricFogWhenNotShadow_C() : this(BuiltinUtils.AllocNativeUObject(BP_DisableVolumetricFogWhenNotShadow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020006 RID: 131078 RVA: 0x0091F788 File Offset: 0x0091D988
		[NullableContext(1)]
		public BP_DisableVolumetricFogWhenNotShadow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DisableVolumetricFogWhenNotShadow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700336F RID: 13167
		// (get) Token: 0x06020007 RID: 131079 RVA: 0x0091F7BC File Offset: 0x0091D9BC
		// (set) Token: 0x06020008 RID: 131080 RVA: 0x0091F7F5 File Offset: 0x0091D9F5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003370 RID: 13168
		// (get) Token: 0x06020009 RID: 131081 RVA: 0x0091F816 File Offset: 0x0091DA16
		// (set) Token: 0x0602000A RID: 131082 RVA: 0x0091F82A File Offset: 0x0091DA2A
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003371 RID: 13169
		// (get) Token: 0x0602000B RID: 131083 RVA: 0x0091F83F File Offset: 0x0091DA3F
		// (set) Token: 0x0602000C RID: 131084 RVA: 0x0091F84F File Offset: 0x0091DA4F
		public unsafe int CurrentShadowConsole
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003372 RID: 13170
		// (get) Token: 0x0602000D RID: 131085 RVA: 0x0091F860 File Offset: 0x0091DA60
		// (set) Token: 0x0602000E RID: 131086 RVA: 0x0091F870 File Offset: 0x0091DA70
		public unsafe int CurrentVolumetricFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003373 RID: 13171
		// (get) Token: 0x0602000F RID: 131087 RVA: 0x0091F881 File Offset: 0x0091DA81
		// (set) Token: 0x06020010 RID: 131088 RVA: 0x0091F891 File Offset: 0x0091DA91
		public unsafe bool bDisableVolumetricFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DisableVolumetricFogWhenNotShadow_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020011 RID: 131089 RVA: 0x0091F8A2 File Offset: 0x0091DAA2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableVolumetricFogIfNotShadow()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__DisableVolumetricFogIfNotShadow_NativeFunctionPtr, null);
		}

		// Token: 0x06020012 RID: 131090 RVA: 0x0091F8B6 File Offset: 0x0091DAB6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020013 RID: 131091 RVA: 0x0091F8CA File Offset: 0x0091DACA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020014 RID: 131092 RVA: 0x0091F8DF File Offset: 0x0091DADF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020015 RID: 131093 RVA: 0x0091F8F3 File Offset: 0x0091DAF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020016 RID: 131094 RVA: 0x0091F908 File Offset: 0x0091DB08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020017 RID: 131095 RVA: 0x0091F950 File Offset: 0x0091DB50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020018 RID: 131096 RVA: 0x0091F997 File Offset: 0x0091DB97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TimerEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__TimerEvent_NativeFunctionPtr, null);
		}

		// Token: 0x06020019 RID: 131097 RVA: 0x0091F9AC File Offset: 0x0091DBAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DisableVolumetricFogWhenNotShadow(int EntryPoint)
		{
			BP_DisableVolumetricFogWhenNotShadow_C.__ExecuteUbergraph_BP_DisableVolumetricFogWhenNotShadow_FunctionParams* ptr = stackalloc BP_DisableVolumetricFogWhenNotShadow_C.__ExecuteUbergraph_BP_DisableVolumetricFogWhenNotShadow_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_DisableVolumetricFogWhenNotShadow_C.__ExecuteUbergraph_BP_DisableVolumetricFogWhenNotShadow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableVolumetricFogWhenNotShadow_C.__ExecuteUbergraph_BP_DisableVolumetricFogWhenNotShadow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableVolumetricFogWhenNotShadow_C.__ExecuteUbergraph_BP_DisableVolumetricFogWhenNotShadow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602001A RID: 131098 RVA: 0x0091F9F3 File Offset: 0x0091DBF3
		protected BP_DisableVolumetricFogWhenNotShadow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FEF4 RID: 65268
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/SpecialHandling/BP_DisableVolumetricFogWhenNotShadow.BP_DisableVolumetricFogWhenNotShadow_C";

		// Token: 0x0400FEF5 RID: 65269
		private static IntPtr _ClassPtr;

		// Token: 0x0400FEF6 RID: 65270
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FEF7 RID: 65271
		internal static int __PropertyOffset_0;

		// Token: 0x0400FEF8 RID: 65272
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FEF9 RID: 65273
		internal static int __PropertyOffset_1;

		// Token: 0x0400FEFA RID: 65274
		internal static int __PropertyOffset_2;

		// Token: 0x0400FEFB RID: 65275
		internal static int __PropertyOffset_3;

		// Token: 0x0400FEFC RID: 65276
		internal static int __PropertyOffset_4;

		// Token: 0x0400FEFD RID: 65277
		private static IntPtr __DisableVolumetricFogIfNotShadow_NativeFunctionPtr;

		// Token: 0x0400FEFE RID: 65278
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FEFF RID: 65279
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FF00 RID: 65280
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FF01 RID: 65281
		private static IntPtr __TimerEvent_NativeFunctionPtr;

		// Token: 0x0400FF02 RID: 65282
		private static IntPtr __ExecuteUbergraph_BP_DisableVolumetricFogWhenNotShadow_NativeFunctionPtr;

		// Token: 0x02009943 RID: 39235
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FA2 RID: 204706
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009944 RID: 39236
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_DisableVolumetricFogWhenNotShadow_FunctionParams
		{
			// Token: 0x04031FA3 RID: 204707
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
