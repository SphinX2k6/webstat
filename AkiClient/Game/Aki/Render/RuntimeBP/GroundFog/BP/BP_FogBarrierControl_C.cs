using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GroundFog.BP
{
	// Token: 0x02003C8F RID: 15503
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_FogBarrierControl.BP_FogBarrierControl_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1340)]
	public class BP_FogBarrierControl_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060242B0 RID: 148144 RVA: 0x0099677E File Offset: 0x0099497E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FogBarrierControl_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_FogBarrierControl.BP_FogBarrierControl_C");
			}
			return BP_FogBarrierControl_C._ClassPtr;
		}

		// Token: 0x060242B1 RID: 148145 RVA: 0x009967A4 File Offset: 0x009949A4
		public BP_FogBarrierControl_C() : this(BuiltinUtils.AllocNativeUObject(BP_FogBarrierControl_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060242B2 RID: 148146 RVA: 0x009967CC File Offset: 0x009949CC
		[NullableContext(1)]
		public BP_FogBarrierControl_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FogBarrierControl_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004A71 RID: 19057
		// (get) Token: 0x060242B3 RID: 148147 RVA: 0x00996800 File Offset: 0x00994A00
		// (set) Token: 0x060242B4 RID: 148148 RVA: 0x00996839 File Offset: 0x00994A39
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FogBarrierControl_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FogBarrierControl_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004A72 RID: 19058
		// (get) Token: 0x060242B5 RID: 148149 RVA: 0x0099685A File Offset: 0x00994A5A
		// (set) Token: 0x060242B6 RID: 148150 RVA: 0x0099686E File Offset: 0x00994A6E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FogBarrierControl_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FogBarrierControl_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004A73 RID: 19059
		// (get) Token: 0x060242B7 RID: 148151 RVA: 0x00996883 File Offset: 0x00994A83
		// (set) Token: 0x060242B8 RID: 148152 RVA: 0x00996897 File Offset: 0x00994A97
		public unsafe FVector WidthHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FogBarrierControl_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FogBarrierControl_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x060242B9 RID: 148153 RVA: 0x009968AC File Offset: 0x00994AAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FogBarrierControl_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060242BA RID: 148154 RVA: 0x009968C0 File Offset: 0x00994AC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FogBarrierControl_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060242BB RID: 148155 RVA: 0x009968D8 File Offset: 0x00994AD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FogBarrierControl_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FogBarrierControl_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FogBarrierControl_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FogBarrierControl_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FogBarrierControl_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060242BC RID: 148156 RVA: 0x00996920 File Offset: 0x00994B20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FogBarrierControl_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FogBarrierControl_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FogBarrierControl_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FogBarrierControl_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FogBarrierControl_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060242BD RID: 148157 RVA: 0x00996968 File Offset: 0x00994B68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FogBarrierControl(int EntryPoint)
		{
			BP_FogBarrierControl_C.__ExecuteUbergraph_BP_FogBarrierControl_FunctionParams* ptr = stackalloc BP_FogBarrierControl_C.__ExecuteUbergraph_BP_FogBarrierControl_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_FogBarrierControl_C.__ExecuteUbergraph_BP_FogBarrierControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FogBarrierControl_C.__ExecuteUbergraph_BP_FogBarrierControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FogBarrierControl_C.__ExecuteUbergraph_BP_FogBarrierControl_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060242BE RID: 148158 RVA: 0x009969AF File Offset: 0x00994BAF
		protected BP_FogBarrierControl_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040127FA RID: 75770
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_FogBarrierControl.BP_FogBarrierControl_C";

		// Token: 0x040127FB RID: 75771
		private static IntPtr _ClassPtr;

		// Token: 0x040127FC RID: 75772
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040127FD RID: 75773
		internal static int __PropertyOffset_0;

		// Token: 0x040127FE RID: 75774
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040127FF RID: 75775
		internal static int __PropertyOffset_1;

		// Token: 0x04012800 RID: 75776
		internal static int __PropertyOffset_2;

		// Token: 0x04012801 RID: 75777
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012802 RID: 75778
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012803 RID: 75779
		private static IntPtr __ExecuteUbergraph_BP_FogBarrierControl_NativeFunctionPtr;

		// Token: 0x02009D96 RID: 40342
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403278D RID: 206733
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D97 RID: 40343
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_FogBarrierControl_FunctionParams
		{
			// Token: 0x0403278E RID: 206734
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
