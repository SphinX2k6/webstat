using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003ABD RID: 15037
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_InteractionGroup.BP_InteractionGroup_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1120)]
	public class BP_InteractionGroup_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020143 RID: 131395 RVA: 0x00921A0F File Offset: 0x0091FC0F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractionGroup_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_InteractionGroup.BP_InteractionGroup_C");
			}
			return BP_InteractionGroup_C._ClassPtr;
		}

		// Token: 0x06020144 RID: 131396 RVA: 0x00921A34 File Offset: 0x0091FC34
		public BP_InteractionGroup_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractionGroup_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020145 RID: 131397 RVA: 0x00921A5C File Offset: 0x0091FC5C
		public BP_InteractionGroup_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractionGroup_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170033D3 RID: 13267
		// (get) Token: 0x06020146 RID: 131398 RVA: 0x00921A90 File Offset: 0x0091FC90
		// (set) Token: 0x06020147 RID: 131399 RVA: 0x00921AC9 File Offset: 0x0091FCC9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteractionGroup_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractionGroup_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170033D4 RID: 13268
		// (get) Token: 0x06020148 RID: 131400 RVA: 0x00921AEA File Offset: 0x0091FCEA
		// (set) Token: 0x06020149 RID: 131401 RVA: 0x00921AFE File Offset: 0x0091FCFE
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionGroup_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionGroup_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170033D5 RID: 13269
		// (get) Token: 0x0602014A RID: 131402 RVA: 0x00921B13 File Offset: 0x0091FD13
		// (set) Token: 0x0602014B RID: 131403 RVA: 0x00921B23 File Offset: 0x0091FD23
		public unsafe float Float
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionGroup_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionGroup_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170033D6 RID: 13270
		// (get) Token: 0x0602014C RID: 131404 RVA: 0x00921B34 File Offset: 0x0091FD34
		// (set) Token: 0x0602014D RID: 131405 RVA: 0x00921B48 File Offset: 0x0091FD48
		public unsafe string ScalarName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_InteractionGroup_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_InteractionGroup_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x170033D7 RID: 13271
		// (get) Token: 0x0602014E RID: 131406 RVA: 0x00921B60 File Offset: 0x0091FD60
		// (set) Token: 0x0602014F RID: 131407 RVA: 0x00921B99 File Offset: 0x0091FD99
		public TArray<AActor> Actor
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Actor) == null)
				{
					result = (this._Actor = new TArray<AActor>(base.NativePtr + (IntPtr)BP_InteractionGroup_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.Actor.CopyAssign(value);
			}
		}

		// Token: 0x170033D8 RID: 13272
		// (get) Token: 0x06020150 RID: 131408 RVA: 0x00921BA7 File Offset: 0x0091FDA7
		// (set) Token: 0x06020151 RID: 131409 RVA: 0x00921BBB File Offset: 0x0091FDBB
		public unsafe string VectorName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_InteractionGroup_C.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_InteractionGroup_C.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x170033D9 RID: 13273
		// (get) Token: 0x06020152 RID: 131410 RVA: 0x00921BD0 File Offset: 0x0091FDD0
		// (set) Token: 0x06020153 RID: 131411 RVA: 0x00921BE4 File Offset: 0x0091FDE4
		public unsafe FLinearColor Vector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionGroup_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionGroup_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06020154 RID: 131412 RVA: 0x00921BF9 File Offset: 0x0091FDF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionGroup_C.__DisableTick_NativeFunctionPtr, null);
		}

		// Token: 0x06020155 RID: 131413 RVA: 0x00921C0D File Offset: 0x0091FE0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionGroup_C.__EnableTick_NativeFunctionPtr, null);
		}

		// Token: 0x06020156 RID: 131414 RVA: 0x00921C24 File Offset: 0x0091FE24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeVectorParameter(FLinearColor VectorParameter, string VectorParameterName)
		{
			BP_InteractionGroup_C.__ChangeVectorParameter_FunctionParams* ptr = stackalloc BP_InteractionGroup_C.__ChangeVectorParameter_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_InteractionGroup_C.__ChangeVectorParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionGroup_C.__ChangeVectorParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->VectorParameter = VectorParameter;
			FString.CopyFrom((void*)(&ptr->VectorParameterName), VectorParameterName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionGroup_C.__ChangeVectorParameter_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_InteractionGroup_C.__ChangeVectorParameter_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020157 RID: 131415 RVA: 0x00921C88 File Offset: 0x0091FE88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeScalarParameter(float FloatParameter, string FloatParameterName)
		{
			BP_InteractionGroup_C.__ChangeScalarParameter_FunctionParams* ptr = stackalloc BP_InteractionGroup_C.__ChangeScalarParameter_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_InteractionGroup_C.__ChangeScalarParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionGroup_C.__ChangeScalarParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FloatParameter = FloatParameter;
			FString.CopyFrom((void*)(&ptr->FloatParameterName), FloatParameterName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionGroup_C.__ChangeScalarParameter_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_InteractionGroup_C.__ChangeScalarParameter_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020158 RID: 131416 RVA: 0x00921CEF File Offset: 0x0091FEEF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ForEach()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionGroup_C.__ForEach_NativeFunctionPtr, null);
		}

		// Token: 0x06020159 RID: 131417 RVA: 0x00921D03 File Offset: 0x0091FF03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Test()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionGroup_C.__Test_NativeFunctionPtr, null);
		}

		// Token: 0x0602015A RID: 131418 RVA: 0x00921D17 File Offset: 0x0091FF17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionGroup_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602015B RID: 131419 RVA: 0x00921D2B File Offset: 0x0091FF2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionGroup_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602015C RID: 131420 RVA: 0x00921D40 File Offset: 0x0091FF40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_InteractionGroup_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractionGroup_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractionGroup_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602015D RID: 131421 RVA: 0x00921D88 File Offset: 0x0091FF88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_InteractionGroup_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractionGroup_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractionGroup_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602015E RID: 131422 RVA: 0x00921DD0 File Offset: 0x0091FFD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteractionGroup(int EntryPoint)
		{
			BP_InteractionGroup_C.__ExecuteUbergraph_BP_InteractionGroup_FunctionParams* ptr = stackalloc BP_InteractionGroup_C.__ExecuteUbergraph_BP_InteractionGroup_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_InteractionGroup_C.__ExecuteUbergraph_BP_InteractionGroup_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionGroup_C.__ExecuteUbergraph_BP_InteractionGroup_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionGroup_C.__ExecuteUbergraph_BP_InteractionGroup_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602015F RID: 131423 RVA: 0x00921E17 File Offset: 0x00920017
		protected BP_InteractionGroup_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FFB9 RID: 65465
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_InteractionGroup.BP_InteractionGroup_C";

		// Token: 0x0400FFBA RID: 65466
		private static IntPtr _ClassPtr;

		// Token: 0x0400FFBB RID: 65467
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FFBC RID: 65468
		internal static int __PropertyOffset_0;

		// Token: 0x0400FFBD RID: 65469
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FFBE RID: 65470
		internal static int __PropertyOffset_1;

		// Token: 0x0400FFBF RID: 65471
		internal static int __PropertyOffset_2;

		// Token: 0x0400FFC0 RID: 65472
		internal static int __PropertyOffset_3;

		// Token: 0x0400FFC1 RID: 65473
		internal static int __PropertyOffset_4;

		// Token: 0x0400FFC2 RID: 65474
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Actor;

		// Token: 0x0400FFC3 RID: 65475
		internal static int __PropertyOffset_5;

		// Token: 0x0400FFC4 RID: 65476
		internal static int __PropertyOffset_6;

		// Token: 0x0400FFC5 RID: 65477
		private static IntPtr __DisableTick_NativeFunctionPtr;

		// Token: 0x0400FFC6 RID: 65478
		private static IntPtr __EnableTick_NativeFunctionPtr;

		// Token: 0x0400FFC7 RID: 65479
		private static IntPtr __ChangeVectorParameter_NativeFunctionPtr;

		// Token: 0x0400FFC8 RID: 65480
		private static IntPtr __ChangeScalarParameter_NativeFunctionPtr;

		// Token: 0x0400FFC9 RID: 65481
		private static IntPtr __ForEach_NativeFunctionPtr;

		// Token: 0x0400FFCA RID: 65482
		private static IntPtr __Test_NativeFunctionPtr;

		// Token: 0x0400FFCB RID: 65483
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FFCC RID: 65484
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FFCD RID: 65485
		private static IntPtr __ExecuteUbergraph_BP_InteractionGroup_NativeFunctionPtr;

		// Token: 0x0200995A RID: 39258
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ChangeVectorParameter_FunctionParams
		{
			// Token: 0x04031FC4 RID: 204740
			[FieldOffset(0)]
			public FLinearColor VectorParameter;

			// Token: 0x04031FC5 RID: 204741
			[FieldOffset(16)]
			public FString VectorParameterName;
		}

		// Token: 0x0200995B RID: 39259
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __ChangeScalarParameter_FunctionParams
		{
			// Token: 0x04031FC6 RID: 204742
			[FieldOffset(0)]
			public float FloatParameter;

			// Token: 0x04031FC7 RID: 204743
			[FieldOffset(8)]
			public FString FloatParameterName;
		}

		// Token: 0x0200995C RID: 39260
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FC8 RID: 204744
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200995D RID: 39261
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_InteractionGroup_FunctionParams
		{
			// Token: 0x04031FC9 RID: 204745
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
