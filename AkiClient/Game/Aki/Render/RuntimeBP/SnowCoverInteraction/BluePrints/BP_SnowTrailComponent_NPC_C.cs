using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints
{
	// Token: 0x02003A55 RID: 14933
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTrailComponent_NPC.BP_SnowTrailComponent_NPC_C")]
	[UnrealStructLayout(336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 336)]
	public class BP_SnowTrailComponent_NPC_C : UKuroBPActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F008 RID: 126984 RVA: 0x0090490B File Offset: 0x00902B0B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTrailComponent_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTrailComponent_NPC.BP_SnowTrailComponent_NPC_C");
			}
			return BP_SnowTrailComponent_NPC_C._ClassPtr;
		}

		// Token: 0x0601F009 RID: 126985 RVA: 0x00904930 File Offset: 0x00902B30
		public BP_SnowTrailComponent_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTrailComponent_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F00A RID: 126986 RVA: 0x00904958 File Offset: 0x00902B58
		public BP_SnowTrailComponent_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTrailComponent_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002D9A RID: 11674
		// (get) Token: 0x0601F00B RID: 126987 RVA: 0x0090498C File Offset: 0x00902B8C
		// (set) Token: 0x0601F00C RID: 126988 RVA: 0x009049C5 File Offset: 0x00902BC5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D9B RID: 11675
		// (get) Token: 0x0601F00D RID: 126989 RVA: 0x009049E6 File Offset: 0x00902BE6
		// (set) Token: 0x0601F00E RID: 126990 RVA: 0x009049F6 File Offset: 0x00902BF6
		public unsafe bool UseActorPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D9C RID: 11676
		// (get) Token: 0x0601F00F RID: 126991 RVA: 0x00904A07 File Offset: 0x00902C07
		// (set) Token: 0x0601F010 RID: 126992 RVA: 0x00904A17 File Offset: 0x00902C17
		public unsafe bool UseSimplePrint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D9D RID: 11677
		// (get) Token: 0x0601F011 RID: 126993 RVA: 0x00904A28 File Offset: 0x00902C28
		// (set) Token: 0x0601F012 RID: 126994 RVA: 0x00904A38 File Offset: 0x00902C38
		public unsafe int NFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002D9E RID: 11678
		// (get) Token: 0x0601F013 RID: 126995 RVA: 0x00904A49 File Offset: 0x00902C49
		// (set) Token: 0x0601F014 RID: 126996 RVA: 0x00904A59 File Offset: 0x00902C59
		public unsafe float Hardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002D9F RID: 11679
		// (get) Token: 0x0601F015 RID: 126997 RVA: 0x00904A6A File Offset: 0x00902C6A
		// (set) Token: 0x0601F016 RID: 126998 RVA: 0x00904A7A File Offset: 0x00902C7A
		public unsafe float RayLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002DA0 RID: 11680
		// (get) Token: 0x0601F017 RID: 126999 RVA: 0x00904A8B File Offset: 0x00902C8B
		// (set) Token: 0x0601F018 RID: 127000 RVA: 0x00904A9B File Offset: 0x00902C9B
		public unsafe float TrailRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002DA1 RID: 11681
		// (get) Token: 0x0601F019 RID: 127001 RVA: 0x00904AAC File Offset: 0x00902CAC
		// (set) Token: 0x0601F01A RID: 127002 RVA: 0x00904ABC File Offset: 0x00902CBC
		public unsafe float DistanceTraveld2D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002DA2 RID: 11682
		// (get) Token: 0x0601F01B RID: 127003 RVA: 0x00904ACD File Offset: 0x00902CCD
		// (set) Token: 0x0601F01C RID: 127004 RVA: 0x00904AE1 File Offset: 0x00902CE1
		public unsafe FVector LastUpdateLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002DA3 RID: 11683
		// (get) Token: 0x0601F01D RID: 127005 RVA: 0x00904AF6 File Offset: 0x00902CF6
		// (set) Token: 0x0601F01E RID: 127006 RVA: 0x00904B0A File Offset: 0x00902D0A
		[Nullable(2)]
		public unsafe BP_SnowTraceManager_C MyTraceManager
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTraceManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailComponent_NPC_C.__PropertyOffset_9);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailComponent_NPC_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002DA4 RID: 11684
		// (get) Token: 0x0601F01F RID: 127007 RVA: 0x00904B1F File Offset: 0x00902D1F
		// (set) Token: 0x0601F020 RID: 127008 RVA: 0x00904B33 File Offset: 0x00902D33
		public unsafe FVector LastCheckLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002DA5 RID: 11685
		// (get) Token: 0x0601F021 RID: 127009 RVA: 0x00904B48 File Offset: 0x00902D48
		// (set) Token: 0x0601F022 RID: 127010 RVA: 0x00904B81 File Offset: 0x00902D81
		public TArray<FName> BoneNameList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._BoneNameList) == null)
				{
					result = (this._BoneNameList = new TArray<FName>(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.BoneNameList.CopyAssign(value);
			}
		}

		// Token: 0x17002DA6 RID: 11686
		// (get) Token: 0x0601F023 RID: 127011 RVA: 0x00904B8F File Offset: 0x00902D8F
		// (set) Token: 0x0601F024 RID: 127012 RVA: 0x00904BA3 File Offset: 0x00902DA3
		public unsafe FVector BoneTransOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002DA7 RID: 11687
		// (get) Token: 0x0601F025 RID: 127013 RVA: 0x00904BB8 File Offset: 0x00902DB8
		// (set) Token: 0x0601F026 RID: 127014 RVA: 0x00904BC8 File Offset: 0x00902DC8
		public unsafe bool SelfEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002DA8 RID: 11688
		// (get) Token: 0x0601F027 RID: 127015 RVA: 0x00904BD9 File Offset: 0x00902DD9
		// (set) Token: 0x0601F028 RID: 127016 RVA: 0x00904BE9 File Offset: 0x00902DE9
		public unsafe int FrameConter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_NPC_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002DA9 RID: 11689
		// (get) Token: 0x0601F029 RID: 127017 RVA: 0x00904BFA File Offset: 0x00902DFA
		// (set) Token: 0x0601F02A RID: 127018 RVA: 0x00904C0E File Offset: 0x00902E0E
		[Nullable(2)]
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailComponent_NPC_C.__PropertyOffset_15);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailComponent_NPC_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x0601F02B RID: 127019 RVA: 0x00904C24 File Offset: 0x00902E24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateDeltaTime(float DeltaTime)
		{
			BP_SnowTrailComponent_NPC_C.__UpdateDeltaTime_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_NPC_C.__UpdateDeltaTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowTrailComponent_NPC_C.__UpdateDeltaTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_NPC_C.__UpdateDeltaTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__UpdateDeltaTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F02C RID: 127020 RVA: 0x00904C6A File Offset: 0x00902E6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SnowCollisionActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__SnowCollisionActor_NativeFunctionPtr, null);
		}

		// Token: 0x0601F02D RID: 127021 RVA: 0x00904C7E File Offset: 0x00902E7E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SnowCollisionBone()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__SnowCollisionBone_NativeFunctionPtr, null);
		}

		// Token: 0x0601F02E RID: 127022 RVA: 0x00904C94 File Offset: 0x00902E94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RegisterTrailComp(float Radius, float Depth, float Hardness, float TrailRotation, FVector TrailLocation)
		{
			BP_SnowTrailComponent_NPC_C.__RegisterTrailComp_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_NPC_C.__RegisterTrailComp_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_SnowTrailComponent_NPC_C.__RegisterTrailComp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_NPC_C.__RegisterTrailComp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Radius = Radius;
			ptr->Depth = Depth;
			ptr->Hardness = Hardness;
			ptr->TrailRotation = TrailRotation;
			ptr->TrailLocation = TrailLocation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__RegisterTrailComp_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F02F RID: 127023 RVA: 0x00904CF8 File Offset: 0x00902EF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FindTrailManager()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__FindTrailManager_NativeFunctionPtr, null);
		}

		// Token: 0x0601F030 RID: 127024 RVA: 0x00904D0C File Offset: 0x00902F0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F031 RID: 127025 RVA: 0x00904D20 File Offset: 0x00902F20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F032 RID: 127026 RVA: 0x00904D38 File Offset: 0x00902F38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SnowTrailComponent_NPC_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_NPC_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowTrailComponent_NPC_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_NPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F033 RID: 127027 RVA: 0x00904D80 File Offset: 0x00902F80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SnowTrailComponent_NPC_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_NPC_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowTrailComponent_NPC_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_NPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F034 RID: 127028 RVA: 0x00904DC8 File Offset: 0x00902FC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SnowTrailComponent_NPC(int EntryPoint)
		{
			BP_SnowTrailComponent_NPC_C.__ExecuteUbergraph_BP_SnowTrailComponent_NPC_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_NPC_C.__ExecuteUbergraph_BP_SnowTrailComponent_NPC_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_SnowTrailComponent_NPC_C.__ExecuteUbergraph_BP_SnowTrailComponent_NPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_NPC_C.__ExecuteUbergraph_BP_SnowTrailComponent_NPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTrailComponent_NPC_C.__ExecuteUbergraph_BP_SnowTrailComponent_NPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F035 RID: 127029 RVA: 0x00904E0F File Offset: 0x0090300F
		protected BP_SnowTrailComponent_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F55F RID: 62815
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTrailComponent_NPC.BP_SnowTrailComponent_NPC_C";

		// Token: 0x0400F560 RID: 62816
		private static IntPtr _ClassPtr;

		// Token: 0x0400F561 RID: 62817
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F562 RID: 62818
		internal static int __PropertyOffset_0;

		// Token: 0x0400F563 RID: 62819
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F564 RID: 62820
		internal static int __PropertyOffset_1;

		// Token: 0x0400F565 RID: 62821
		internal static int __PropertyOffset_2;

		// Token: 0x0400F566 RID: 62822
		internal static int __PropertyOffset_3;

		// Token: 0x0400F567 RID: 62823
		internal static int __PropertyOffset_4;

		// Token: 0x0400F568 RID: 62824
		internal static int __PropertyOffset_5;

		// Token: 0x0400F569 RID: 62825
		internal static int __PropertyOffset_6;

		// Token: 0x0400F56A RID: 62826
		internal static int __PropertyOffset_7;

		// Token: 0x0400F56B RID: 62827
		internal static int __PropertyOffset_8;

		// Token: 0x0400F56C RID: 62828
		internal static int __PropertyOffset_9;

		// Token: 0x0400F56D RID: 62829
		internal static int __PropertyOffset_10;

		// Token: 0x0400F56E RID: 62830
		internal static int __PropertyOffset_11;

		// Token: 0x0400F56F RID: 62831
		[Nullable(2)]
		private TArray<FName> _BoneNameList;

		// Token: 0x0400F570 RID: 62832
		internal static int __PropertyOffset_12;

		// Token: 0x0400F571 RID: 62833
		internal static int __PropertyOffset_13;

		// Token: 0x0400F572 RID: 62834
		internal static int __PropertyOffset_14;

		// Token: 0x0400F573 RID: 62835
		internal static int __PropertyOffset_15;

		// Token: 0x0400F574 RID: 62836
		private static IntPtr __UpdateDeltaTime_NativeFunctionPtr;

		// Token: 0x0400F575 RID: 62837
		private static IntPtr __SnowCollisionActor_NativeFunctionPtr;

		// Token: 0x0400F576 RID: 62838
		private static IntPtr __SnowCollisionBone_NativeFunctionPtr;

		// Token: 0x0400F577 RID: 62839
		private static IntPtr __RegisterTrailComp_NativeFunctionPtr;

		// Token: 0x0400F578 RID: 62840
		private static IntPtr __FindTrailManager_NativeFunctionPtr;

		// Token: 0x0400F579 RID: 62841
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F57A RID: 62842
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F57B RID: 62843
		private static IntPtr __ExecuteUbergraph_BP_SnowTrailComponent_NPC_NativeFunctionPtr;

		// Token: 0x02009839 RID: 38969
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __UpdateDeltaTime_FunctionParams
		{
			// Token: 0x04031E68 RID: 204392
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x0200983A RID: 38970
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __RegisterTrailComp_FunctionParams
		{
			// Token: 0x04031E69 RID: 204393
			[FieldOffset(0)]
			public float Radius;

			// Token: 0x04031E6A RID: 204394
			[FieldOffset(4)]
			public float Depth;

			// Token: 0x04031E6B RID: 204395
			[FieldOffset(8)]
			public float Hardness;

			// Token: 0x04031E6C RID: 204396
			[FieldOffset(12)]
			public float TrailRotation;

			// Token: 0x04031E6D RID: 204397
			[FieldOffset(16)]
			public FVector TrailLocation;
		}

		// Token: 0x0200983B RID: 38971
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E6E RID: 204398
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200983C RID: 38972
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_SnowTrailComponent_NPC_FunctionParams
		{
			// Token: 0x04031E6F RID: 204399
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
