using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.VolumeGroupFade
{
	// Token: 0x02003B5E RID: 15198
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_MeshGroupFade.BP_MeshGroupFade_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_MeshGroupFade_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060213A0 RID: 136096 RVA: 0x009439A0 File Offset: 0x00941BA0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MeshGroupFade_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_MeshGroupFade.BP_MeshGroupFade_C");
			}
			return BP_MeshGroupFade_C._ClassPtr;
		}

		// Token: 0x060213A1 RID: 136097 RVA: 0x009439C4 File Offset: 0x00941BC4
		public BP_MeshGroupFade_C() : this(BuiltinUtils.AllocNativeUObject(BP_MeshGroupFade_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060213A2 RID: 136098 RVA: 0x009439EC File Offset: 0x00941BEC
		public BP_MeshGroupFade_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MeshGroupFade_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170039D2 RID: 14802
		// (get) Token: 0x060213A3 RID: 136099 RVA: 0x00943A20 File Offset: 0x00941C20
		// (set) Token: 0x060213A4 RID: 136100 RVA: 0x00943A59 File Offset: 0x00941C59
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170039D3 RID: 14803
		// (get) Token: 0x060213A5 RID: 136101 RVA: 0x00943A7A File Offset: 0x00941C7A
		// (set) Token: 0x060213A6 RID: 136102 RVA: 0x00943A8E File Offset: 0x00941C8E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshGroupFade_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshGroupFade_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170039D4 RID: 14804
		// (get) Token: 0x060213A7 RID: 136103 RVA: 0x00943AA4 File Offset: 0x00941CA4
		// (set) Token: 0x060213A8 RID: 136104 RVA: 0x00943ADD File Offset: 0x00941CDD
		public TArray<AStaticMeshActor> StaticMesh
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._StaticMesh) == null)
				{
					result = (this._StaticMesh = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.StaticMesh.CopyAssign(value);
			}
		}

		// Token: 0x170039D5 RID: 14805
		// (get) Token: 0x060213A9 RID: 136105 RVA: 0x00943AEB File Offset: 0x00941CEB
		// (set) Token: 0x060213AA RID: 136106 RVA: 0x00943AFB File Offset: 0x00941CFB
		public unsafe float FadeValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170039D6 RID: 14806
		// (get) Token: 0x060213AB RID: 136107 RVA: 0x00943B0C File Offset: 0x00941D0C
		// (set) Token: 0x060213AC RID: 136108 RVA: 0x00943B1C File Offset: 0x00941D1C
		public unsafe int FadeGroup
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170039D7 RID: 14807
		// (get) Token: 0x060213AD RID: 136109 RVA: 0x00943B2D File Offset: 0x00941D2D
		// (set) Token: 0x060213AE RID: 136110 RVA: 0x00943B41 File Offset: 0x00941D41
		public unsafe FName Parameter_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170039D8 RID: 14808
		// (get) Token: 0x060213AF RID: 136111 RVA: 0x00943B56 File Offset: 0x00941D56
		// (set) Token: 0x060213B0 RID: 136112 RVA: 0x00943B66 File Offset: 0x00941D66
		public unsafe bool bHide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039D9 RID: 14809
		// (get) Token: 0x060213B1 RID: 136113 RVA: 0x00943B77 File Offset: 0x00941D77
		// (set) Token: 0x060213B2 RID: 136114 RVA: 0x00943B87 File Offset: 0x00941D87
		public unsafe bool bInverseVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039DA RID: 14810
		// (get) Token: 0x060213B3 RID: 136115 RVA: 0x00943B98 File Offset: 0x00941D98
		// (set) Token: 0x060213B4 RID: 136116 RVA: 0x00943BAC File Offset: 0x00941DAC
		[Nullable(2)]
		public unsafe UStaticMeshComponent Static_Mesh_Component
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshGroupFade_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshGroupFade_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170039DB RID: 14811
		// (get) Token: 0x060213B5 RID: 136117 RVA: 0x00943BC1 File Offset: 0x00941DC1
		// (set) Token: 0x060213B6 RID: 136118 RVA: 0x00943BD1 File Offset: 0x00941DD1
		public unsafe bool bUpdateFinished
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039DC RID: 14812
		// (get) Token: 0x060213B7 RID: 136119 RVA: 0x00943BE2 File Offset: 0x00941DE2
		// (set) Token: 0x060213B8 RID: 136120 RVA: 0x00943BF2 File Offset: 0x00941DF2
		public unsafe int maxProcessCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170039DD RID: 14813
		// (get) Token: 0x060213B9 RID: 136121 RVA: 0x00943C03 File Offset: 0x00941E03
		// (set) Token: 0x060213BA RID: 136122 RVA: 0x00943C13 File Offset: 0x00941E13
		public unsafe int currentIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170039DE RID: 14814
		// (get) Token: 0x060213BB RID: 136123 RVA: 0x00943C24 File Offset: 0x00941E24
		// (set) Token: 0x060213BC RID: 136124 RVA: 0x00943C34 File Offset: 0x00941E34
		public unsafe int MeshCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshGroupFade_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x060213BD RID: 136125 RVA: 0x00943C45 File Offset: 0x00941E45
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshGroupFade_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x060213BE RID: 136126 RVA: 0x00943C59 File Offset: 0x00941E59
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshGroupFade_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060213BF RID: 136127 RVA: 0x00943C6D File Offset: 0x00941E6D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshGroupFade_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060213C0 RID: 136128 RVA: 0x00943C82 File Offset: 0x00941E82
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshGroupFade_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060213C1 RID: 136129 RVA: 0x00943C96 File Offset: 0x00941E96
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshGroupFade_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060213C2 RID: 136130 RVA: 0x00943CAC File Offset: 0x00941EAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MeshGroupFade_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshGroupFade_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshGroupFade_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshGroupFade_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshGroupFade_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060213C3 RID: 136131 RVA: 0x00943CF4 File Offset: 0x00941EF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MeshGroupFade_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshGroupFade_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshGroupFade_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshGroupFade_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshGroupFade_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060213C4 RID: 136132 RVA: 0x00943D3C File Offset: 0x00941F3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MeshGroupFade_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshGroupFade_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshGroupFade_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshGroupFade_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshGroupFade_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060213C5 RID: 136133 RVA: 0x00943D84 File Offset: 0x00941F84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MeshGroupFade_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MeshGroupFade_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshGroupFade_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshGroupFade_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshGroupFade_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060213C6 RID: 136134 RVA: 0x00943DCB File Offset: 0x00941FCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateStat()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshGroupFade_C.__UpdateStat_NativeFunctionPtr, null);
		}

		// Token: 0x060213C7 RID: 136135 RVA: 0x00943DE0 File Offset: 0x00941FE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MeshGroupFade(int EntryPoint)
		{
			BP_MeshGroupFade_C.__ExecuteUbergraph_BP_MeshGroupFade_FunctionParams* ptr = stackalloc BP_MeshGroupFade_C.__ExecuteUbergraph_BP_MeshGroupFade_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_MeshGroupFade_C.__ExecuteUbergraph_BP_MeshGroupFade_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshGroupFade_C.__ExecuteUbergraph_BP_MeshGroupFade_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshGroupFade_C.__ExecuteUbergraph_BP_MeshGroupFade_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060213C8 RID: 136136 RVA: 0x00943E27 File Offset: 0x00942027
		protected BP_MeshGroupFade_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010B5D RID: 68445
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_MeshGroupFade.BP_MeshGroupFade_C";

		// Token: 0x04010B5E RID: 68446
		private static IntPtr _ClassPtr;

		// Token: 0x04010B5F RID: 68447
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010B60 RID: 68448
		internal static int __PropertyOffset_0;

		// Token: 0x04010B61 RID: 68449
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010B62 RID: 68450
		internal static int __PropertyOffset_1;

		// Token: 0x04010B63 RID: 68451
		internal static int __PropertyOffset_2;

		// Token: 0x04010B64 RID: 68452
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _StaticMesh;

		// Token: 0x04010B65 RID: 68453
		internal static int __PropertyOffset_3;

		// Token: 0x04010B66 RID: 68454
		internal static int __PropertyOffset_4;

		// Token: 0x04010B67 RID: 68455
		internal static int __PropertyOffset_5;

		// Token: 0x04010B68 RID: 68456
		internal static int __PropertyOffset_6;

		// Token: 0x04010B69 RID: 68457
		internal static int __PropertyOffset_7;

		// Token: 0x04010B6A RID: 68458
		internal static int __PropertyOffset_8;

		// Token: 0x04010B6B RID: 68459
		internal static int __PropertyOffset_9;

		// Token: 0x04010B6C RID: 68460
		internal static int __PropertyOffset_10;

		// Token: 0x04010B6D RID: 68461
		internal static int __PropertyOffset_11;

		// Token: 0x04010B6E RID: 68462
		internal static int __PropertyOffset_12;

		// Token: 0x04010B6F RID: 68463
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04010B70 RID: 68464
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010B71 RID: 68465
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010B72 RID: 68466
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010B73 RID: 68467
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010B74 RID: 68468
		private static IntPtr __UpdateStat_NativeFunctionPtr;

		// Token: 0x04010B75 RID: 68469
		private static IntPtr __ExecuteUbergraph_BP_MeshGroupFade_NativeFunctionPtr;

		// Token: 0x02009AA2 RID: 39586
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032207 RID: 205319
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AA3 RID: 39587
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032208 RID: 205320
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AA4 RID: 39588
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_MeshGroupFade_FunctionParams
		{
			// Token: 0x04032209 RID: 205321
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
