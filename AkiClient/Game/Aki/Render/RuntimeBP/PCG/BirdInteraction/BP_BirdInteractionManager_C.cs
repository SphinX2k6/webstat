using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BirdInteraction
{
	// Token: 0x02003C3E RID: 15422
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BirdInteraction/BP_BirdInteractionManager.BP_BirdInteractionManager_C")]
	[UnrealStructLayout(2016, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2012)]
	public class BP_BirdInteractionManager_C : AKuroBirdInteractionManager, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023738 RID: 145208 RVA: 0x009828DE File Offset: 0x00980ADE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BirdInteractionManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BirdInteraction/BP_BirdInteractionManager.BP_BirdInteractionManager_C");
			}
			return BP_BirdInteractionManager_C._ClassPtr;
		}

		// Token: 0x06023739 RID: 145209 RVA: 0x00982904 File Offset: 0x00980B04
		public BP_BirdInteractionManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_BirdInteractionManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602373A RID: 145210 RVA: 0x0098292C File Offset: 0x00980B2C
		public BP_BirdInteractionManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BirdInteractionManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004685 RID: 18053
		// (get) Token: 0x0602373B RID: 145211 RVA: 0x00982960 File Offset: 0x00980B60
		// (set) Token: 0x0602373C RID: 145212 RVA: 0x00982999 File Offset: 0x00980B99
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BirdInteractionManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BirdInteractionManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004686 RID: 18054
		// (get) Token: 0x0602373D RID: 145213 RVA: 0x009829BA File Offset: 0x00980BBA
		// (set) Token: 0x0602373E RID: 145214 RVA: 0x009829CE File Offset: 0x00980BCE
		[Nullable(2)]
		public unsafe UBoxComponent Box1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BirdInteractionManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BirdInteractionManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004687 RID: 18055
		// (get) Token: 0x0602373F RID: 145215 RVA: 0x009829E3 File Offset: 0x00980BE3
		// (set) Token: 0x06023740 RID: 145216 RVA: 0x009829F7 File Offset: 0x00980BF7
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BirdInteractionManager_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BirdInteractionManager_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004688 RID: 18056
		// (get) Token: 0x06023741 RID: 145217 RVA: 0x00982A0C File Offset: 0x00980C0C
		// (set) Token: 0x06023742 RID: 145218 RVA: 0x00982A1C File Offset: 0x00980C1C
		public unsafe int BirdCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BirdInteractionManager_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BirdInteractionManager_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004689 RID: 18057
		// (get) Token: 0x06023743 RID: 145219 RVA: 0x00982A30 File Offset: 0x00980C30
		// (set) Token: 0x06023744 RID: 145220 RVA: 0x00982A69 File Offset: 0x00980C69
		public TArray<FTransform> BirdTransforms
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._BirdTransforms) == null)
				{
					result = (this._BirdTransforms = new TArray<FTransform>(base.NativePtr + (IntPtr)BP_BirdInteractionManager_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.BirdTransforms.CopyAssign(value);
			}
		}

		// Token: 0x1700468A RID: 18058
		// (get) Token: 0x06023745 RID: 145221 RVA: 0x00982A77 File Offset: 0x00980C77
		// (set) Token: 0x06023746 RID: 145222 RVA: 0x00982A8B File Offset: 0x00980C8B
		public unsafe FVector LandingBoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BirdInteractionManager_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BirdInteractionManager_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06023747 RID: 145223 RVA: 0x00982AA0 File Offset: 0x00980CA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWorldOffset(FVector Offset)
		{
			BP_BirdInteractionManager_C.__OnWorldOffset_FunctionParams* ptr = stackalloc BP_BirdInteractionManager_C.__OnWorldOffset_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_BirdInteractionManager_C.__OnWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BirdInteractionManager_C.__OnWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BirdInteractionManager_C.__OnWorldOffset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023748 RID: 145224 RVA: 0x00982AE9 File Offset: 0x00980CE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetBirdTransforms()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BirdInteractionManager_C.__SetBirdTransforms_NativeFunctionPtr, null);
		}

		// Token: 0x06023749 RID: 145225 RVA: 0x00982AFD File Offset: 0x00980CFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BirdInteractionManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602374A RID: 145226 RVA: 0x00982B11 File Offset: 0x00980D11
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BirdInteractionManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602374B RID: 145227 RVA: 0x00982B28 File Offset: 0x00980D28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnApplyWorldOffset(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_BirdInteractionManager_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_BirdInteractionManager_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_BirdInteractionManager_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BirdInteractionManager_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BirdInteractionManager_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602374C RID: 145228 RVA: 0x00982B7C File Offset: 0x00980D7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnApplyWorldOffset_Implementation(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_BirdInteractionManager_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_BirdInteractionManager_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_BirdInteractionManager_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BirdInteractionManager_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BirdInteractionManager_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602374D RID: 145229 RVA: 0x00982BD0 File Offset: 0x00980DD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BirdInteractionManager(int EntryPoint)
		{
			BP_BirdInteractionManager_C.__ExecuteUbergraph_BP_BirdInteractionManager_FunctionParams* ptr = stackalloc BP_BirdInteractionManager_C.__ExecuteUbergraph_BP_BirdInteractionManager_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_BirdInteractionManager_C.__ExecuteUbergraph_BP_BirdInteractionManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BirdInteractionManager_C.__ExecuteUbergraph_BP_BirdInteractionManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BirdInteractionManager_C.__ExecuteUbergraph_BP_BirdInteractionManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602374E RID: 145230 RVA: 0x00982C17 File Offset: 0x00980E17
		protected BP_BirdInteractionManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040120C0 RID: 73920
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BirdInteraction/BP_BirdInteractionManager.BP_BirdInteractionManager_C";

		// Token: 0x040120C1 RID: 73921
		private static IntPtr _ClassPtr;

		// Token: 0x040120C2 RID: 73922
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040120C3 RID: 73923
		internal static int __PropertyOffset_0;

		// Token: 0x040120C4 RID: 73924
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040120C5 RID: 73925
		internal static int __PropertyOffset_1;

		// Token: 0x040120C6 RID: 73926
		internal static int __PropertyOffset_2;

		// Token: 0x040120C7 RID: 73927
		internal static int __PropertyOffset_3;

		// Token: 0x040120C8 RID: 73928
		internal static int __PropertyOffset_4;

		// Token: 0x040120C9 RID: 73929
		[Nullable(2)]
		private TArray<FTransform> _BirdTransforms;

		// Token: 0x040120CA RID: 73930
		internal static int __PropertyOffset_5;

		// Token: 0x040120CB RID: 73931
		private static IntPtr __OnWorldOffset_NativeFunctionPtr;

		// Token: 0x040120CC RID: 73932
		private static IntPtr __SetBirdTransforms_NativeFunctionPtr;

		// Token: 0x040120CD RID: 73933
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040120CE RID: 73934
		private static IntPtr __OnApplyWorldOffset_NativeFunctionPtr;

		// Token: 0x040120CF RID: 73935
		private static IntPtr __ExecuteUbergraph_BP_BirdInteractionManager_NativeFunctionPtr;

		// Token: 0x02009CE5 RID: 40165
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __OnWorldOffset_FunctionParams
		{
			// Token: 0x04032672 RID: 206450
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x02009CE6 RID: 40166
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __OnApplyWorldOffset_FunctionParams
		{
			// Token: 0x04032673 RID: 206451
			[FieldOffset(0)]
			public FVector InWorldOffset;

			// Token: 0x04032674 RID: 206452
			[FieldOffset(12)]
			public bool bWorldShift;
		}

		// Token: 0x02009CE7 RID: 40167
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __ExecuteUbergraph_BP_BirdInteractionManager_FunctionParams
		{
			// Token: 0x04032675 RID: 206453
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
