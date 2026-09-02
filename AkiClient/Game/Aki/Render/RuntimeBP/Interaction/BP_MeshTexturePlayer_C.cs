using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C84 RID: 15492
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshTexturePlayer.BP_MeshTexturePlayer_C")]
	[UnrealStructLayout(1456, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1456)]
	public class BP_MeshTexturePlayer_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060240D8 RID: 147672 RVA: 0x00993758 File Offset: 0x00991958
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MeshTexturePlayer_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshTexturePlayer.BP_MeshTexturePlayer_C");
			}
			return BP_MeshTexturePlayer_C._ClassPtr;
		}

		// Token: 0x060240D9 RID: 147673 RVA: 0x0099377C File Offset: 0x0099197C
		public BP_MeshTexturePlayer_C() : this(BuiltinUtils.AllocNativeUObject(BP_MeshTexturePlayer_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060240DA RID: 147674 RVA: 0x009937A4 File Offset: 0x009919A4
		[NullableContext(1)]
		public BP_MeshTexturePlayer_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MeshTexturePlayer_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170049B4 RID: 18868
		// (get) Token: 0x060240DB RID: 147675 RVA: 0x009937D8 File Offset: 0x009919D8
		// (set) Token: 0x060240DC RID: 147676 RVA: 0x00993811 File Offset: 0x00991A11
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049B5 RID: 18869
		// (get) Token: 0x060240DD RID: 147677 RVA: 0x00993832 File Offset: 0x00991A32
		// (set) Token: 0x060240DE RID: 147678 RVA: 0x00993846 File Offset: 0x00991A46
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170049B6 RID: 18870
		// (get) Token: 0x060240DF RID: 147679 RVA: 0x0099385B File Offset: 0x00991A5B
		// (set) Token: 0x060240E0 RID: 147680 RVA: 0x0099386F File Offset: 0x00991A6F
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170049B7 RID: 18871
		// (get) Token: 0x060240E1 RID: 147681 RVA: 0x00993884 File Offset: 0x00991A84
		// (set) Token: 0x060240E2 RID: 147682 RVA: 0x00993898 File Offset: 0x00991A98
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170049B8 RID: 18872
		// (get) Token: 0x060240E3 RID: 147683 RVA: 0x009938AD File Offset: 0x00991AAD
		// (set) Token: 0x060240E4 RID: 147684 RVA: 0x009938BD File Offset: 0x00991ABD
		public unsafe float MediaIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170049B9 RID: 18873
		// (get) Token: 0x060240E5 RID: 147685 RVA: 0x009938CE File Offset: 0x00991ACE
		// (set) Token: 0x060240E6 RID: 147686 RVA: 0x009938DE File Offset: 0x00991ADE
		public unsafe float GlitchIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170049BA RID: 18874
		// (get) Token: 0x060240E7 RID: 147687 RVA: 0x009938EF File Offset: 0x00991AEF
		// (set) Token: 0x060240E8 RID: 147688 RVA: 0x00993903 File Offset: 0x00991B03
		public unsafe UStaticMesh ActorMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170049BB RID: 18875
		// (get) Token: 0x060240E9 RID: 147689 RVA: 0x00993918 File Offset: 0x00991B18
		// (set) Token: 0x060240EA RID: 147690 RVA: 0x00993928 File Offset: 0x00991B28
		public unsafe int MaterialIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170049BC RID: 18876
		// (get) Token: 0x060240EB RID: 147691 RVA: 0x00993939 File Offset: 0x00991B39
		// (set) Token: 0x060240EC RID: 147692 RVA: 0x0099394D File Offset: 0x00991B4D
		public unsafe UTexture2D ScreenTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170049BD RID: 18877
		// (get) Token: 0x060240ED RID: 147693 RVA: 0x00993962 File Offset: 0x00991B62
		// (set) Token: 0x060240EE RID: 147694 RVA: 0x00993976 File Offset: 0x00991B76
		public unsafe FVector ScreenUV_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170049BE RID: 18878
		// (get) Token: 0x060240EF RID: 147695 RVA: 0x0099398B File Offset: 0x00991B8B
		// (set) Token: 0x060240F0 RID: 147696 RVA: 0x0099399F File Offset: 0x00991B9F
		public unsafe FVector ScreenUV_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170049BF RID: 18879
		// (get) Token: 0x060240F1 RID: 147697 RVA: 0x009939B4 File Offset: 0x00991BB4
		// (set) Token: 0x060240F2 RID: 147698 RVA: 0x009939C8 File Offset: 0x00991BC8
		public unsafe UMaterialInstance MediaMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170049C0 RID: 18880
		// (get) Token: 0x060240F3 RID: 147699 RVA: 0x009939DD File Offset: 0x00991BDD
		// (set) Token: 0x060240F4 RID: 147700 RVA: 0x009939F1 File Offset: 0x00991BF1
		public unsafe UMaterialInstanceDynamic MediaMaterial_Dynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170049C1 RID: 18881
		// (get) Token: 0x060240F5 RID: 147701 RVA: 0x00993A06 File Offset: 0x00991C06
		// (set) Token: 0x060240F6 RID: 147702 RVA: 0x00993A1A File Offset: 0x00991C1A
		public unsafe UTexture2D MainTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshTexturePlayer_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170049C2 RID: 18882
		// (get) Token: 0x060240F7 RID: 147703 RVA: 0x00993A2F File Offset: 0x00991C2F
		// (set) Token: 0x060240F8 RID: 147704 RVA: 0x00993A43 File Offset: 0x00991C43
		public unsafe FVector BackgroundUV_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170049C3 RID: 18883
		// (get) Token: 0x060240F9 RID: 147705 RVA: 0x00993A58 File Offset: 0x00991C58
		// (set) Token: 0x060240FA RID: 147706 RVA: 0x00993A6C File Offset: 0x00991C6C
		public unsafe FVector BackgroundUV_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170049C4 RID: 18884
		// (get) Token: 0x060240FB RID: 147707 RVA: 0x00993A81 File Offset: 0x00991C81
		// (set) Token: 0x060240FC RID: 147708 RVA: 0x00993A91 File Offset: 0x00991C91
		public unsafe int NumberOfChunks
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170049C5 RID: 18885
		// (get) Token: 0x060240FD RID: 147709 RVA: 0x00993AA2 File Offset: 0x00991CA2
		// (set) Token: 0x060240FE RID: 147710 RVA: 0x00993AB2 File Offset: 0x00991CB2
		public unsafe int PlayingChunk
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshTexturePlayer_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x060240FF RID: 147711 RVA: 0x00993AC3 File Offset: 0x00991CC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshTexturePlayer_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024100 RID: 147712 RVA: 0x00993AD7 File Offset: 0x00991CD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshTexturePlayer_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024101 RID: 147713 RVA: 0x00993AEC File Offset: 0x00991CEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MeshTexturePlayer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshTexturePlayer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshTexturePlayer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshTexturePlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshTexturePlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024102 RID: 147714 RVA: 0x00993B34 File Offset: 0x00991D34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MeshTexturePlayer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshTexturePlayer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshTexturePlayer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshTexturePlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshTexturePlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024103 RID: 147715 RVA: 0x00993B7C File Offset: 0x00991D7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MeshTexturePlayer_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshTexturePlayer_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshTexturePlayer_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshTexturePlayer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshTexturePlayer_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024104 RID: 147716 RVA: 0x00993BC4 File Offset: 0x00991DC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MeshTexturePlayer_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshTexturePlayer_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshTexturePlayer_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshTexturePlayer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshTexturePlayer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024105 RID: 147717 RVA: 0x00993C0C File Offset: 0x00991E0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MeshTexturePlayer(int EntryPoint)
		{
			BP_MeshTexturePlayer_C.__ExecuteUbergraph_BP_MeshTexturePlayer_FunctionParams* ptr = stackalloc BP_MeshTexturePlayer_C.__ExecuteUbergraph_BP_MeshTexturePlayer_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_MeshTexturePlayer_C.__ExecuteUbergraph_BP_MeshTexturePlayer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshTexturePlayer_C.__ExecuteUbergraph_BP_MeshTexturePlayer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshTexturePlayer_C.__ExecuteUbergraph_BP_MeshTexturePlayer_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024106 RID: 147718 RVA: 0x00993C53 File Offset: 0x00991E53
		protected BP_MeshTexturePlayer_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040126E1 RID: 75489
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_MeshTexturePlayer.BP_MeshTexturePlayer_C";

		// Token: 0x040126E2 RID: 75490
		private static IntPtr _ClassPtr;

		// Token: 0x040126E3 RID: 75491
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040126E4 RID: 75492
		internal static int __PropertyOffset_0;

		// Token: 0x040126E5 RID: 75493
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040126E6 RID: 75494
		internal static int __PropertyOffset_1;

		// Token: 0x040126E7 RID: 75495
		internal static int __PropertyOffset_2;

		// Token: 0x040126E8 RID: 75496
		internal static int __PropertyOffset_3;

		// Token: 0x040126E9 RID: 75497
		internal static int __PropertyOffset_4;

		// Token: 0x040126EA RID: 75498
		internal static int __PropertyOffset_5;

		// Token: 0x040126EB RID: 75499
		internal static int __PropertyOffset_6;

		// Token: 0x040126EC RID: 75500
		internal static int __PropertyOffset_7;

		// Token: 0x040126ED RID: 75501
		internal static int __PropertyOffset_8;

		// Token: 0x040126EE RID: 75502
		internal static int __PropertyOffset_9;

		// Token: 0x040126EF RID: 75503
		internal static int __PropertyOffset_10;

		// Token: 0x040126F0 RID: 75504
		internal static int __PropertyOffset_11;

		// Token: 0x040126F1 RID: 75505
		internal static int __PropertyOffset_12;

		// Token: 0x040126F2 RID: 75506
		internal static int __PropertyOffset_13;

		// Token: 0x040126F3 RID: 75507
		internal static int __PropertyOffset_14;

		// Token: 0x040126F4 RID: 75508
		internal static int __PropertyOffset_15;

		// Token: 0x040126F5 RID: 75509
		internal static int __PropertyOffset_16;

		// Token: 0x040126F6 RID: 75510
		internal static int __PropertyOffset_17;

		// Token: 0x040126F7 RID: 75511
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040126F8 RID: 75512
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040126F9 RID: 75513
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040126FA RID: 75514
		private static IntPtr __ExecuteUbergraph_BP_MeshTexturePlayer_NativeFunctionPtr;

		// Token: 0x02009D85 RID: 40325
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403277A RID: 206714
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D86 RID: 40326
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403277B RID: 206715
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D87 RID: 40327
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_MeshTexturePlayer_FunctionParams
		{
			// Token: 0x0403277C RID: 206716
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
