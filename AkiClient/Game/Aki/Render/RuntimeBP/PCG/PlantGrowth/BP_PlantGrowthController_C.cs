using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PlantGrowth
{
	// Token: 0x02003BA2 RID: 15266
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PlantGrowth/BP_PlantGrowthController.BP_PlantGrowthController_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_PlantGrowthController_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021ED5 RID: 138965 RVA: 0x00957714 File Offset: 0x00955914
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PlantGrowthController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PlantGrowth/BP_PlantGrowthController.BP_PlantGrowthController_C");
			}
			return BP_PlantGrowthController_C._ClassPtr;
		}

		// Token: 0x06021ED6 RID: 138966 RVA: 0x00957738 File Offset: 0x00955938
		public BP_PlantGrowthController_C() : this(BuiltinUtils.AllocNativeUObject(BP_PlantGrowthController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021ED7 RID: 138967 RVA: 0x00957760 File Offset: 0x00955960
		[NullableContext(1)]
		public BP_PlantGrowthController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PlantGrowthController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003DC7 RID: 15815
		// (get) Token: 0x06021ED8 RID: 138968 RVA: 0x00957794 File Offset: 0x00955994
		// (set) Token: 0x06021ED9 RID: 138969 RVA: 0x009577CD File Offset: 0x009559CD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DC8 RID: 15816
		// (get) Token: 0x06021EDA RID: 138970 RVA: 0x009577EE File Offset: 0x009559EE
		// (set) Token: 0x06021EDB RID: 138971 RVA: 0x00957802 File Offset: 0x00955A02
		public unsafe UBoxComponent AreaBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthController_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003DC9 RID: 15817
		// (get) Token: 0x06021EDC RID: 138972 RVA: 0x00957817 File Offset: 0x00955A17
		// (set) Token: 0x06021EDD RID: 138973 RVA: 0x0095782B File Offset: 0x00955A2B
		public unsafe UChildActorComponent EditorCharacterPosition
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthController_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthController_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003DCA RID: 15818
		// (get) Token: 0x06021EDE RID: 138974 RVA: 0x00957840 File Offset: 0x00955A40
		// (set) Token: 0x06021EDF RID: 138975 RVA: 0x00957854 File Offset: 0x00955A54
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthController_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantGrowthController_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003DCB RID: 15819
		// (get) Token: 0x06021EE0 RID: 138976 RVA: 0x00957869 File Offset: 0x00955A69
		// (set) Token: 0x06021EE1 RID: 138977 RVA: 0x00957879 File Offset: 0x00955A79
		public unsafe float Delay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003DCC RID: 15820
		// (get) Token: 0x06021EE2 RID: 138978 RVA: 0x0095788A File Offset: 0x00955A8A
		// (set) Token: 0x06021EE3 RID: 138979 RVA: 0x0095789A File Offset: 0x00955A9A
		public unsafe float MaxDistanceLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003DCD RID: 15821
		// (get) Token: 0x06021EE4 RID: 138980 RVA: 0x009578AB File Offset: 0x00955AAB
		// (set) Token: 0x06021EE5 RID: 138981 RVA: 0x009578BF File Offset: 0x00955ABF
		public unsafe FVector AreaExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003DCE RID: 15822
		// (get) Token: 0x06021EE6 RID: 138982 RVA: 0x009578D4 File Offset: 0x00955AD4
		// (set) Token: 0x06021EE7 RID: 138983 RVA: 0x009578E4 File Offset: 0x00955AE4
		public unsafe bool RuntimePreview
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DCF RID: 15823
		// (get) Token: 0x06021EE8 RID: 138984 RVA: 0x009578F5 File Offset: 0x00955AF5
		// (set) Token: 0x06021EE9 RID: 138985 RVA: 0x00957909 File Offset: 0x00955B09
		public unsafe FVectorDouble CharacterLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003DD0 RID: 15824
		// (get) Token: 0x06021EEA RID: 138986 RVA: 0x0095791E File Offset: 0x00955B1E
		// (set) Token: 0x06021EEB RID: 138987 RVA: 0x0095792E File Offset: 0x00955B2E
		public unsafe bool Runtime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DD1 RID: 15825
		// (get) Token: 0x06021EEC RID: 138988 RVA: 0x0095793F File Offset: 0x00955B3F
		// (set) Token: 0x06021EED RID: 138989 RVA: 0x0095794F File Offset: 0x00955B4F
		public unsafe float TimeBySeq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantGrowthController_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06021EEE RID: 138990 RVA: 0x00957960 File Offset: 0x00955B60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthController_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021EEF RID: 138991 RVA: 0x00957974 File Offset: 0x00955B74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthController_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021EF0 RID: 138992 RVA: 0x00957989 File Offset: 0x00955B89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021EF1 RID: 138993 RVA: 0x0095799D File Offset: 0x00955B9D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021EF2 RID: 138994 RVA: 0x009579B4 File Offset: 0x00955BB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PlantGrowthController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PlantGrowthController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlantGrowthController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021EF3 RID: 138995 RVA: 0x009579FC File Offset: 0x00955BFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PlantGrowthController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PlantGrowthController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlantGrowthController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021EF4 RID: 138996 RVA: 0x00957A44 File Offset: 0x00955C44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PlantGrowthController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PlantGrowthController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlantGrowthController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthController_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021EF5 RID: 138997 RVA: 0x00957A8C File Offset: 0x00955C8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PlantGrowthController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PlantGrowthController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlantGrowthController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021EF6 RID: 138998 RVA: 0x00957AD3 File Offset: 0x00955CD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantGrowthController_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06021EF7 RID: 138999 RVA: 0x00957AE7 File Offset: 0x00955CE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthController_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021EF8 RID: 139000 RVA: 0x00957AFC File Offset: 0x00955CFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PlantGrowthController(int EntryPoint)
		{
			BP_PlantGrowthController_C.__ExecuteUbergraph_BP_PlantGrowthController_FunctionParams* ptr = stackalloc BP_PlantGrowthController_C.__ExecuteUbergraph_BP_PlantGrowthController_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_PlantGrowthController_C.__ExecuteUbergraph_BP_PlantGrowthController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantGrowthController_C.__ExecuteUbergraph_BP_PlantGrowthController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantGrowthController_C.__ExecuteUbergraph_BP_PlantGrowthController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021EF9 RID: 139001 RVA: 0x00957B46 File Offset: 0x00955D46
		protected BP_PlantGrowthController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011216 RID: 70166
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PlantGrowth/BP_PlantGrowthController.BP_PlantGrowthController_C";

		// Token: 0x04011217 RID: 70167
		private static IntPtr _ClassPtr;

		// Token: 0x04011218 RID: 70168
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011219 RID: 70169
		internal static int __PropertyOffset_0;

		// Token: 0x0401121A RID: 70170
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401121B RID: 70171
		internal static int __PropertyOffset_1;

		// Token: 0x0401121C RID: 70172
		internal static int __PropertyOffset_2;

		// Token: 0x0401121D RID: 70173
		internal static int __PropertyOffset_3;

		// Token: 0x0401121E RID: 70174
		internal static int __PropertyOffset_4;

		// Token: 0x0401121F RID: 70175
		internal static int __PropertyOffset_5;

		// Token: 0x04011220 RID: 70176
		internal static int __PropertyOffset_6;

		// Token: 0x04011221 RID: 70177
		internal static int __PropertyOffset_7;

		// Token: 0x04011222 RID: 70178
		internal static int __PropertyOffset_8;

		// Token: 0x04011223 RID: 70179
		internal static int __PropertyOffset_9;

		// Token: 0x04011224 RID: 70180
		internal static int __PropertyOffset_10;

		// Token: 0x04011225 RID: 70181
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011226 RID: 70182
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011227 RID: 70183
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011228 RID: 70184
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011229 RID: 70185
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0401122A RID: 70186
		private static IntPtr __ExecuteUbergraph_BP_PlantGrowthController_NativeFunctionPtr;

		// Token: 0x02009B73 RID: 39795
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032366 RID: 205670
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B74 RID: 39796
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032367 RID: 205671
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B75 RID: 39797
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_PlantGrowthController_FunctionParams
		{
			// Token: 0x04032368 RID: 205672
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
