using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterPlanet
{
	// Token: 0x02003B55 RID: 15189
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterPlanet/BP_WaterPlanet.BP_WaterPlanet_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_WaterPlanet_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021229 RID: 135721 RVA: 0x00940BC0 File Offset: 0x0093EDC0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterPlanet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterPlanet/BP_WaterPlanet.BP_WaterPlanet_C");
			}
			return BP_WaterPlanet_C._ClassPtr;
		}

		// Token: 0x0602122A RID: 135722 RVA: 0x00940BE4 File Offset: 0x0093EDE4
		public BP_WaterPlanet_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterPlanet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602122B RID: 135723 RVA: 0x00940C0C File Offset: 0x0093EE0C
		[NullableContext(1)]
		public BP_WaterPlanet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterPlanet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700395B RID: 14683
		// (get) Token: 0x0602122C RID: 135724 RVA: 0x00940C40 File Offset: 0x0093EE40
		// (set) Token: 0x0602122D RID: 135725 RVA: 0x00940C79 File Offset: 0x0093EE79
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700395C RID: 14684
		// (get) Token: 0x0602122E RID: 135726 RVA: 0x00940C9A File Offset: 0x0093EE9A
		// (set) Token: 0x0602122F RID: 135727 RVA: 0x00940CAE File Offset: 0x0093EEAE
		public unsafe UStaticMeshComponent SM_WaterPlanet_02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterPlanet_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterPlanet_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700395D RID: 14685
		// (get) Token: 0x06021230 RID: 135728 RVA: 0x00940CC3 File Offset: 0x0093EEC3
		// (set) Token: 0x06021231 RID: 135729 RVA: 0x00940CD7 File Offset: 0x0093EED7
		public unsafe UStaticMeshComponent SM_WaterPlanet_01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterPlanet_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterPlanet_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700395E RID: 14686
		// (get) Token: 0x06021232 RID: 135730 RVA: 0x00940CEC File Offset: 0x0093EEEC
		// (set) Token: 0x06021233 RID: 135731 RVA: 0x00940D00 File Offset: 0x0093EF00
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterPlanet_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterPlanet_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700395F RID: 14687
		// (get) Token: 0x06021234 RID: 135732 RVA: 0x00940D15 File Offset: 0x0093EF15
		// (set) Token: 0x06021235 RID: 135733 RVA: 0x00940D25 File Offset: 0x0093EF25
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003960 RID: 14688
		// (get) Token: 0x06021236 RID: 135734 RVA: 0x00940D36 File Offset: 0x0093EF36
		// (set) Token: 0x06021237 RID: 135735 RVA: 0x00940D46 File Offset: 0x0093EF46
		public unsafe float TransitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003961 RID: 14689
		// (get) Token: 0x06021238 RID: 135736 RVA: 0x00940D57 File Offset: 0x0093EF57
		// (set) Token: 0x06021239 RID: 135737 RVA: 0x00940D67 File Offset: 0x0093EF67
		public unsafe float AnimaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003962 RID: 14690
		// (get) Token: 0x0602123A RID: 135738 RVA: 0x00940D78 File Offset: 0x0093EF78
		// (set) Token: 0x0602123B RID: 135739 RVA: 0x00940D88 File Offset: 0x0093EF88
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003963 RID: 14691
		// (get) Token: 0x0602123C RID: 135740 RVA: 0x00940D99 File Offset: 0x0093EF99
		// (set) Token: 0x0602123D RID: 135741 RVA: 0x00940DA9 File Offset: 0x0093EFA9
		public unsafe float ShaderTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003964 RID: 14692
		// (get) Token: 0x0602123E RID: 135742 RVA: 0x00940DBA File Offset: 0x0093EFBA
		// (set) Token: 0x0602123F RID: 135743 RVA: 0x00940DCE File Offset: 0x0093EFCE
		public unsafe FVectorDouble Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterPlanet_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x06021240 RID: 135744 RVA: 0x00940DE3 File Offset: 0x0093EFE3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterPlanet_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021241 RID: 135745 RVA: 0x00940DF7 File Offset: 0x0093EFF7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterPlanet_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021242 RID: 135746 RVA: 0x00940E0C File Offset: 0x0093F00C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterPlanet_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterPlanet_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterPlanet_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterPlanet_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterPlanet_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021243 RID: 135747 RVA: 0x00940E54 File Offset: 0x0093F054
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterPlanet_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterPlanet_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterPlanet_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterPlanet_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterPlanet_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021244 RID: 135748 RVA: 0x00940E9C File Offset: 0x0093F09C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_WaterPlanet_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WaterPlanet_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterPlanet_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterPlanet_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterPlanet_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021245 RID: 135749 RVA: 0x00940EE4 File Offset: 0x0093F0E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_WaterPlanet_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WaterPlanet_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterPlanet_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterPlanet_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterPlanet_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021246 RID: 135750 RVA: 0x00940F2C File Offset: 0x0093F12C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterPlanet(int EntryPoint)
		{
			BP_WaterPlanet_C.__ExecuteUbergraph_BP_WaterPlanet_FunctionParams* ptr = stackalloc BP_WaterPlanet_C.__ExecuteUbergraph_BP_WaterPlanet_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_WaterPlanet_C.__ExecuteUbergraph_BP_WaterPlanet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterPlanet_C.__ExecuteUbergraph_BP_WaterPlanet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterPlanet_C.__ExecuteUbergraph_BP_WaterPlanet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021247 RID: 135751 RVA: 0x00940F76 File Offset: 0x0093F176
		protected BP_WaterPlanet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010A5C RID: 68188
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterPlanet/BP_WaterPlanet.BP_WaterPlanet_C";

		// Token: 0x04010A5D RID: 68189
		private static IntPtr _ClassPtr;

		// Token: 0x04010A5E RID: 68190
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010A5F RID: 68191
		internal static int __PropertyOffset_0;

		// Token: 0x04010A60 RID: 68192
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010A61 RID: 68193
		internal static int __PropertyOffset_1;

		// Token: 0x04010A62 RID: 68194
		internal static int __PropertyOffset_2;

		// Token: 0x04010A63 RID: 68195
		internal static int __PropertyOffset_3;

		// Token: 0x04010A64 RID: 68196
		internal static int __PropertyOffset_4;

		// Token: 0x04010A65 RID: 68197
		internal static int __PropertyOffset_5;

		// Token: 0x04010A66 RID: 68198
		internal static int __PropertyOffset_6;

		// Token: 0x04010A67 RID: 68199
		internal static int __PropertyOffset_7;

		// Token: 0x04010A68 RID: 68200
		internal static int __PropertyOffset_8;

		// Token: 0x04010A69 RID: 68201
		internal static int __PropertyOffset_9;

		// Token: 0x04010A6A RID: 68202
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010A6B RID: 68203
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010A6C RID: 68204
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010A6D RID: 68205
		private static IntPtr __ExecuteUbergraph_BP_WaterPlanet_NativeFunctionPtr;

		// Token: 0x02009A81 RID: 39553
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040321D5 RID: 205269
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A82 RID: 39554
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040321D6 RID: 205270
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A83 RID: 39555
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __ExecuteUbergraph_BP_WaterPlanet_FunctionParams
		{
			// Token: 0x040321D7 RID: 205271
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
