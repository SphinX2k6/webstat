using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SoftMesh
{
	// Token: 0x02003B6A RID: 15210
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_2.BP_Soft_2_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1136)]
	public class BP_Soft_2_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602170D RID: 136973 RVA: 0x00949408 File Offset: 0x00947608
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Soft_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_2.BP_Soft_2_C");
			}
			return BP_Soft_2_C._ClassPtr;
		}

		// Token: 0x0602170E RID: 136974 RVA: 0x0094942C File Offset: 0x0094762C
		public BP_Soft_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_Soft_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602170F RID: 136975 RVA: 0x00949454 File Offset: 0x00947654
		[NullableContext(1)]
		public BP_Soft_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Soft_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B2D RID: 15149
		// (get) Token: 0x06021710 RID: 136976 RVA: 0x00949488 File Offset: 0x00947688
		// (set) Token: 0x06021711 RID: 136977 RVA: 0x009494C1 File Offset: 0x009476C1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B2E RID: 15150
		// (get) Token: 0x06021712 RID: 136978 RVA: 0x009494E2 File Offset: 0x009476E2
		// (set) Token: 0x06021713 RID: 136979 RVA: 0x009494F6 File Offset: 0x009476F6
		public unsafe UStaticMeshComponent SM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B2F RID: 15151
		// (get) Token: 0x06021714 RID: 136980 RVA: 0x0094950B File Offset: 0x0094770B
		// (set) Token: 0x06021715 RID: 136981 RVA: 0x0094951F File Offset: 0x0094771F
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B30 RID: 15152
		// (get) Token: 0x06021716 RID: 136982 RVA: 0x00949534 File Offset: 0x00947734
		// (set) Token: 0x06021717 RID: 136983 RVA: 0x00949548 File Offset: 0x00947748
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B31 RID: 15153
		// (get) Token: 0x06021718 RID: 136984 RVA: 0x0094955D File Offset: 0x0094775D
		// (set) Token: 0x06021719 RID: 136985 RVA: 0x00949571 File Offset: 0x00947771
		public unsafe FVector BoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003B32 RID: 15154
		// (get) Token: 0x0602171A RID: 136986 RVA: 0x00949586 File Offset: 0x00947786
		// (set) Token: 0x0602171B RID: 136987 RVA: 0x00949596 File Offset: 0x00947796
		public unsafe float Mass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003B33 RID: 15155
		// (get) Token: 0x0602171C RID: 136988 RVA: 0x009495A7 File Offset: 0x009477A7
		// (set) Token: 0x0602171D RID: 136989 RVA: 0x009495BB File Offset: 0x009477BB
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003B34 RID: 15156
		// (get) Token: 0x0602171E RID: 136990 RVA: 0x009495D0 File Offset: 0x009477D0
		// (set) Token: 0x0602171F RID: 136991 RVA: 0x009495E0 File Offset: 0x009477E0
		public unsafe float Tightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_2_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003B35 RID: 15157
		// (get) Token: 0x06021720 RID: 136992 RVA: 0x009495F1 File Offset: 0x009477F1
		// (set) Token: 0x06021721 RID: 136993 RVA: 0x00949605 File Offset: 0x00947805
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003B36 RID: 15158
		// (get) Token: 0x06021722 RID: 136994 RVA: 0x0094961A File Offset: 0x0094781A
		// (set) Token: 0x06021723 RID: 136995 RVA: 0x0094962E File Offset: 0x0094782E
		public unsafe UHoudiniPointCache HoudiniPointCache
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003B37 RID: 15159
		// (get) Token: 0x06021724 RID: 136996 RVA: 0x00949643 File Offset: 0x00947843
		// (set) Token: 0x06021725 RID: 136997 RVA: 0x00949657 File Offset: 0x00947857
		public unsafe UMaterialInstanceDynamic Dmaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003B38 RID: 15160
		// (get) Token: 0x06021726 RID: 136998 RVA: 0x0094966C File Offset: 0x0094786C
		// (set) Token: 0x06021727 RID: 136999 RVA: 0x00949680 File Offset: 0x00947880
		public unsafe UMaterialInstance InputMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_2_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x06021728 RID: 137000 RVA: 0x00949695 File Offset: 0x00947895
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021729 RID: 137001 RVA: 0x009496A9 File Offset: 0x009478A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602172A RID: 137002 RVA: 0x009496BE File Offset: 0x009478BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602172B RID: 137003 RVA: 0x009496D2 File Offset: 0x009478D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602172C RID: 137004 RVA: 0x009496E8 File Offset: 0x009478E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Soft_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Soft_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Soft_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602172D RID: 137005 RVA: 0x00949730 File Offset: 0x00947930
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Soft_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Soft_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Soft_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602172E RID: 137006 RVA: 0x00949777 File Offset: 0x00947977
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_2_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x0602172F RID: 137007 RVA: 0x0094978B File Offset: 0x0094798B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_2_C.__CustomEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x06021730 RID: 137008 RVA: 0x009497A0 File Offset: 0x009479A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Soft_2(int EntryPoint)
		{
			BP_Soft_2_C.__ExecuteUbergraph_BP_Soft_2_FunctionParams* ptr = stackalloc BP_Soft_2_C.__ExecuteUbergraph_BP_Soft_2_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_Soft_2_C.__ExecuteUbergraph_BP_Soft_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_2_C.__ExecuteUbergraph_BP_Soft_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_2_C.__ExecuteUbergraph_BP_Soft_2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021731 RID: 137009 RVA: 0x009497E7 File Offset: 0x009479E7
		protected BP_Soft_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010D62 RID: 68962
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_2.BP_Soft_2_C";

		// Token: 0x04010D63 RID: 68963
		private static IntPtr _ClassPtr;

		// Token: 0x04010D64 RID: 68964
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010D65 RID: 68965
		internal static int __PropertyOffset_0;

		// Token: 0x04010D66 RID: 68966
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010D67 RID: 68967
		internal static int __PropertyOffset_1;

		// Token: 0x04010D68 RID: 68968
		internal static int __PropertyOffset_2;

		// Token: 0x04010D69 RID: 68969
		internal static int __PropertyOffset_3;

		// Token: 0x04010D6A RID: 68970
		internal static int __PropertyOffset_4;

		// Token: 0x04010D6B RID: 68971
		internal static int __PropertyOffset_5;

		// Token: 0x04010D6C RID: 68972
		internal static int __PropertyOffset_6;

		// Token: 0x04010D6D RID: 68973
		internal static int __PropertyOffset_7;

		// Token: 0x04010D6E RID: 68974
		internal static int __PropertyOffset_8;

		// Token: 0x04010D6F RID: 68975
		internal static int __PropertyOffset_9;

		// Token: 0x04010D70 RID: 68976
		internal static int __PropertyOffset_10;

		// Token: 0x04010D71 RID: 68977
		internal static int __PropertyOffset_11;

		// Token: 0x04010D72 RID: 68978
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010D73 RID: 68979
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010D74 RID: 68980
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010D75 RID: 68981
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x04010D76 RID: 68982
		private static IntPtr __CustomEvent1_NativeFunctionPtr;

		// Token: 0x04010D77 RID: 68983
		private static IntPtr __ExecuteUbergraph_BP_Soft_2_NativeFunctionPtr;

		// Token: 0x02009ADB RID: 39643
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403225F RID: 205407
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009ADC RID: 39644
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_Soft_2_FunctionParams
		{
			// Token: 0x04032260 RID: 205408
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
