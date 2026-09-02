using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D37 RID: 15671
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/SceneEffectStatePostVolume.SceneEffectStatePostVolume_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class SceneEffectStatePostVolume_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602600A RID: 155658 RVA: 0x009CADCF File Offset: 0x009C8FCF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SceneEffectStatePostVolume_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Scene/SceneEffectStatePostVolume.SceneEffectStatePostVolume_C");
			}
			return SceneEffectStatePostVolume_C._ClassPtr;
		}

		// Token: 0x0602600B RID: 155659 RVA: 0x009CADF4 File Offset: 0x009C8FF4
		public SceneEffectStatePostVolume_C() : this(BuiltinUtils.AllocNativeUObject(SceneEffectStatePostVolume_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602600C RID: 155660 RVA: 0x009CAE1C File Offset: 0x009C901C
		[NullableContext(1)]
		public SceneEffectStatePostVolume_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneEffectStatePostVolume_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170054FB RID: 21755
		// (get) Token: 0x0602600D RID: 155661 RVA: 0x009CAE4F File Offset: 0x009C904F
		// (set) Token: 0x0602600E RID: 155662 RVA: 0x009CAE63 File Offset: 0x009C9063
		[Nullable(2)]
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + SceneEffectStatePostVolume_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneEffectStatePostVolume_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170054FC RID: 21756
		// (get) Token: 0x0602600F RID: 155663 RVA: 0x009CAE78 File Offset: 0x009C9078
		// (set) Token: 0x06026010 RID: 155664 RVA: 0x009CAE8C File Offset: 0x009C908C
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + SceneEffectStatePostVolume_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneEffectStatePostVolume_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170054FD RID: 21757
		// (get) Token: 0x06026011 RID: 155665 RVA: 0x009CAEA1 File Offset: 0x009C90A1
		// (set) Token: 0x06026012 RID: 155666 RVA: 0x009CAEB1 File Offset: 0x009C90B1
		public unsafe bool Enabled
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SceneEffectStatePostVolume_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SceneEffectStatePostVolume_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170054FE RID: 21758
		// (get) Token: 0x06026013 RID: 155667 RVA: 0x009CAEC2 File Offset: 0x009C90C2
		// (set) Token: 0x06026014 RID: 155668 RVA: 0x009CAED2 File Offset: 0x009C90D2
		public unsafe float value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SceneEffectStatePostVolume_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SceneEffectStatePostVolume_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06026015 RID: 155669 RVA: 0x009CAEE3 File Offset: 0x009C90E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetToxicFog_Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SceneEffectStatePostVolume_C.__SetToxicFog_Debug_NativeFunctionPtr, null);
		}

		// Token: 0x06026016 RID: 155670 RVA: 0x009CAEF7 File Offset: 0x009C90F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetWall_Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SceneEffectStatePostVolume_C.__SetWall_Debug_NativeFunctionPtr, null);
		}

		// Token: 0x06026017 RID: 155671 RVA: 0x009CAF0C File Offset: 0x009C910C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetEffect(float Value)
		{
			SceneEffectStatePostVolume_C.__SetEffect_FunctionParams* ptr = stackalloc SceneEffectStatePostVolume_C.__SetEffect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(SceneEffectStatePostVolume_C.__SetEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SceneEffectStatePostVolume_C.__SetEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Value = Value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SceneEffectStatePostVolume_C.__SetEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026018 RID: 155672 RVA: 0x009CAF52 File Offset: 0x009C9152
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableVolume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SceneEffectStatePostVolume_C.__DisableVolume_NativeFunctionPtr, null);
		}

		// Token: 0x06026019 RID: 155673 RVA: 0x009CAF66 File Offset: 0x009C9166
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableVolume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SceneEffectStatePostVolume_C.__EnableVolume_NativeFunctionPtr, null);
		}

		// Token: 0x0602601A RID: 155674 RVA: 0x009CAF7C File Offset: 0x009C917C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetToxicFog(float Value)
		{
			SceneEffectStatePostVolume_C.__SetToxicFog_FunctionParams* ptr = stackalloc SceneEffectStatePostVolume_C.__SetToxicFog_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(SceneEffectStatePostVolume_C.__SetToxicFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SceneEffectStatePostVolume_C.__SetToxicFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Value = Value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SceneEffectStatePostVolume_C.__SetToxicFog_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602601B RID: 155675 RVA: 0x009CAFC4 File Offset: 0x009C91C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetAirWall(float value)
		{
			SceneEffectStatePostVolume_C.__SetAirWall_FunctionParams* ptr = stackalloc SceneEffectStatePostVolume_C.__SetAirWall_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(SceneEffectStatePostVolume_C.__SetAirWall_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SceneEffectStatePostVolume_C.__SetAirWall_NativeFunctionPtr, (void*)ptr, 1);
			ptr->value = value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SceneEffectStatePostVolume_C.__SetAirWall_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602601C RID: 155676 RVA: 0x009CB00A File Offset: 0x009C920A
		protected SceneEffectStatePostVolume_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013A7F RID: 80511
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Scene/SceneEffectStatePostVolume.SceneEffectStatePostVolume_C";

		// Token: 0x04013A80 RID: 80512
		private static IntPtr _ClassPtr;

		// Token: 0x04013A81 RID: 80513
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013A82 RID: 80514
		internal static int __PropertyOffset_0;

		// Token: 0x04013A83 RID: 80515
		internal static int __PropertyOffset_1;

		// Token: 0x04013A84 RID: 80516
		internal static int __PropertyOffset_2;

		// Token: 0x04013A85 RID: 80517
		internal static int __PropertyOffset_3;

		// Token: 0x04013A86 RID: 80518
		private static IntPtr __SetToxicFog_Debug_NativeFunctionPtr;

		// Token: 0x04013A87 RID: 80519
		private static IntPtr __SetWall_Debug_NativeFunctionPtr;

		// Token: 0x04013A88 RID: 80520
		private static IntPtr __SetEffect_NativeFunctionPtr;

		// Token: 0x04013A89 RID: 80521
		private static IntPtr __DisableVolume_NativeFunctionPtr;

		// Token: 0x04013A8A RID: 80522
		private static IntPtr __EnableVolume_NativeFunctionPtr;

		// Token: 0x04013A8B RID: 80523
		private static IntPtr __SetToxicFog_NativeFunctionPtr;

		// Token: 0x04013A8C RID: 80524
		private static IntPtr __SetAirWall_NativeFunctionPtr;

		// Token: 0x02009FDE RID: 40926
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __SetEffect_FunctionParams
		{
			// Token: 0x04032B96 RID: 207766
			[FieldOffset(0)]
			public float Value;
		}

		// Token: 0x02009FDF RID: 40927
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetToxicFog_FunctionParams
		{
			// Token: 0x04032B97 RID: 207767
			[FieldOffset(0)]
			public float Value;
		}

		// Token: 0x02009FE0 RID: 40928
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetAirWall_FunctionParams
		{
			// Token: 0x04032B98 RID: 207768
			[FieldOffset(0)]
			public float value;
		}
	}
}
