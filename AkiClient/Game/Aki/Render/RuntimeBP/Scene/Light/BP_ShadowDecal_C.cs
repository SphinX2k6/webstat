using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A98 RID: 15000
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowDecal.BP_ShadowDecal_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1196)]
	public class BP_ShadowDecal_C : AKuroDecalActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FA01 RID: 129537 RVA: 0x00916864 File Offset: 0x00914A64
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ShadowDecal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowDecal.BP_ShadowDecal_C");
			}
			return BP_ShadowDecal_C._ClassPtr;
		}

		// Token: 0x0601FA02 RID: 129538 RVA: 0x00916888 File Offset: 0x00914A88
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_ShadowDecal_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FA03 RID: 129539 RVA: 0x00916890 File Offset: 0x00914A90
		public BP_ShadowDecal_C() : this(BuiltinUtils.AllocNativeUObject(BP_ShadowDecal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FA04 RID: 129540 RVA: 0x009168B8 File Offset: 0x00914AB8
		[NullableContext(1)]
		public BP_ShadowDecal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ShadowDecal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170030FF RID: 12543
		// (get) Token: 0x0601FA05 RID: 129541 RVA: 0x009168EC File Offset: 0x00914AEC
		// (set) Token: 0x0601FA06 RID: 129542 RVA: 0x00916925 File Offset: 0x00914B25
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003100 RID: 12544
		// (get) Token: 0x0601FA07 RID: 129543 RVA: 0x00916946 File Offset: 0x00914B46
		// (set) Token: 0x0601FA08 RID: 129544 RVA: 0x0091695A File Offset: 0x00914B5A
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003101 RID: 12545
		// (get) Token: 0x0601FA09 RID: 129545 RVA: 0x0091696F File Offset: 0x00914B6F
		// (set) Token: 0x0601FA0A RID: 129546 RVA: 0x00916983 File Offset: 0x00914B83
		public unsafe UMaterialInstanceDynamic DYMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003102 RID: 12546
		// (get) Token: 0x0601FA0B RID: 129547 RVA: 0x00916998 File Offset: 0x00914B98
		// (set) Token: 0x0601FA0C RID: 129548 RVA: 0x009169AC File Offset: 0x00914BAC
		public unsafe UTexture2D ShadowTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003103 RID: 12547
		// (get) Token: 0x0601FA0D RID: 129549 RVA: 0x009169C1 File Offset: 0x00914BC1
		// (set) Token: 0x0601FA0E RID: 129550 RVA: 0x009169D1 File Offset: 0x00914BD1
		public unsafe float ShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003104 RID: 12548
		// (get) Token: 0x0601FA0F RID: 129551 RVA: 0x009169E2 File Offset: 0x00914BE2
		// (set) Token: 0x0601FA10 RID: 129552 RVA: 0x009169F2 File Offset: 0x00914BF2
		public unsafe float InvShadow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003105 RID: 12549
		// (get) Token: 0x0601FA11 RID: 129553 RVA: 0x00916A03 File Offset: 0x00914C03
		// (set) Token: 0x0601FA12 RID: 129554 RVA: 0x00916A17 File Offset: 0x00914C17
		public unsafe UTexture2D EvolutionaryTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003106 RID: 12550
		// (get) Token: 0x0601FA13 RID: 129555 RVA: 0x00916A2C File Offset: 0x00914C2C
		// (set) Token: 0x0601FA14 RID: 129556 RVA: 0x00916A3C File Offset: 0x00914C3C
		public unsafe float EvolutionaryIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003107 RID: 12551
		// (get) Token: 0x0601FA15 RID: 129557 RVA: 0x00916A4D File Offset: 0x00914C4D
		// (set) Token: 0x0601FA16 RID: 129558 RVA: 0x00916A5D File Offset: 0x00914C5D
		public unsafe float EvolutionaryRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003108 RID: 12552
		// (get) Token: 0x0601FA17 RID: 129559 RVA: 0x00916A6E File Offset: 0x00914C6E
		// (set) Token: 0x0601FA18 RID: 129560 RVA: 0x00916A7E File Offset: 0x00914C7E
		public unsafe float EvolutionaryDirectional_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003109 RID: 12553
		// (get) Token: 0x0601FA19 RID: 129561 RVA: 0x00916A8F File Offset: 0x00914C8F
		// (set) Token: 0x0601FA1A RID: 129562 RVA: 0x00916A9F File Offset: 0x00914C9F
		public unsafe float EvolutionaryDirectional_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700310A RID: 12554
		// (get) Token: 0x0601FA1B RID: 129563 RVA: 0x00916AB0 File Offset: 0x00914CB0
		// (set) Token: 0x0601FA1C RID: 129564 RVA: 0x00916AC0 File Offset: 0x00914CC0
		public unsafe float MobileShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700310B RID: 12555
		// (get) Token: 0x0601FA1D RID: 129565 RVA: 0x00916AD1 File Offset: 0x00914CD1
		// (set) Token: 0x0601FA1E RID: 129566 RVA: 0x00916AE1 File Offset: 0x00914CE1
		public unsafe int DALayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700310C RID: 12556
		// (get) Token: 0x0601FA1F RID: 129567 RVA: 0x00916AF2 File Offset: 0x00914CF2
		// (set) Token: 0x0601FA20 RID: 129568 RVA: 0x00916B06 File Offset: 0x00914D06
		public unsafe FName MPC_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700310D RID: 12557
		// (get) Token: 0x0601FA21 RID: 129569 RVA: 0x00916B1B File Offset: 0x00914D1B
		// (set) Token: 0x0601FA22 RID: 129570 RVA: 0x00916B2B File Offset: 0x00914D2B
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700310E RID: 12558
		// (get) Token: 0x0601FA23 RID: 129571 RVA: 0x00916B3C File Offset: 0x00914D3C
		// (set) Token: 0x0601FA24 RID: 129572 RVA: 0x00916B4C File Offset: 0x00914D4C
		public unsafe float RestoreVal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700310F RID: 12559
		// (get) Token: 0x0601FA25 RID: 129573 RVA: 0x00916B5D File Offset: 0x00914D5D
		// (set) Token: 0x0601FA26 RID: 129574 RVA: 0x00916B6D File Offset: 0x00914D6D
		public unsafe float DeltaTimeTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003110 RID: 12560
		// (get) Token: 0x0601FA27 RID: 129575 RVA: 0x00916B7E File Offset: 0x00914D7E
		// (set) Token: 0x0601FA28 RID: 129576 RVA: 0x00916B8E File Offset: 0x00914D8E
		public unsafe float WindIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003111 RID: 12561
		// (get) Token: 0x0601FA29 RID: 129577 RVA: 0x00916B9F File Offset: 0x00914D9F
		// (set) Token: 0x0601FA2A RID: 129578 RVA: 0x00916BAF File Offset: 0x00914DAF
		public unsafe float WindSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003112 RID: 12562
		// (get) Token: 0x0601FA2B RID: 129579 RVA: 0x00916BC0 File Offset: 0x00914DC0
		// (set) Token: 0x0601FA2C RID: 129580 RVA: 0x00916BD0 File Offset: 0x00914DD0
		public unsafe float WindDir_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003113 RID: 12563
		// (get) Token: 0x0601FA2D RID: 129581 RVA: 0x00916BE1 File Offset: 0x00914DE1
		// (set) Token: 0x0601FA2E RID: 129582 RVA: 0x00916BF1 File Offset: 0x00914DF1
		public unsafe float WindDir_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003114 RID: 12564
		// (get) Token: 0x0601FA2F RID: 129583 RVA: 0x00916C02 File Offset: 0x00914E02
		// (set) Token: 0x0601FA30 RID: 129584 RVA: 0x00916C12 File Offset: 0x00914E12
		public unsafe float StrenghtAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003115 RID: 12565
		// (get) Token: 0x0601FA31 RID: 129585 RVA: 0x00916C23 File Offset: 0x00914E23
		// (set) Token: 0x0601FA32 RID: 129586 RVA: 0x00916C33 File Offset: 0x00914E33
		public unsafe float WindRandomSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003116 RID: 12566
		// (get) Token: 0x0601FA33 RID: 129587 RVA: 0x00916C44 File Offset: 0x00914E44
		// (set) Token: 0x0601FA34 RID: 129588 RVA: 0x00916C54 File Offset: 0x00914E54
		public unsafe float WindRandomIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x0601FA35 RID: 129589 RVA: 0x00916C68 File Offset: 0x00914E68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_ShadowDecal_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_ShadowDecal_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowDecal_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowDecal_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowDecal_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FA36 RID: 129590 RVA: 0x00916CB0 File Offset: 0x00914EB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_ShadowDecal_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_ShadowDecal_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowDecal_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowDecal_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowDecal_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FA37 RID: 129591 RVA: 0x00916CF6 File Offset: 0x00914EF6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FromDa()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowDecal_C.__FromDa_NativeFunctionPtr, null);
		}

		// Token: 0x0601FA38 RID: 129592 RVA: 0x00916D0A File Offset: 0x00914F0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowDecal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FA39 RID: 129593 RVA: 0x00916D1E File Offset: 0x00914F1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowDecal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FA3A RID: 129594 RVA: 0x00916D34 File Offset: 0x00914F34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ShadowDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShadowDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FA3B RID: 129595 RVA: 0x00916D7C File Offset: 0x00914F7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ShadowDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShadowDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FA3C RID: 129596 RVA: 0x00916DC4 File Offset: 0x00914FC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ShadowDecal(int EntryPoint)
		{
			BP_ShadowDecal_C.__ExecuteUbergraph_BP_ShadowDecal_FunctionParams* ptr = stackalloc BP_ShadowDecal_C.__ExecuteUbergraph_BP_ShadowDecal_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_ShadowDecal_C.__ExecuteUbergraph_BP_ShadowDecal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowDecal_C.__ExecuteUbergraph_BP_ShadowDecal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowDecal_C.__ExecuteUbergraph_BP_ShadowDecal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FA3D RID: 129597 RVA: 0x00916E0B File Offset: 0x0091500B
		protected BP_ShadowDecal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FB96 RID: 64406
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FB97 RID: 64407
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowDecal.BP_ShadowDecal_C";

		// Token: 0x0400FB98 RID: 64408
		private static IntPtr _ClassPtr;

		// Token: 0x0400FB99 RID: 64409
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FB9A RID: 64410
		internal static int __PropertyOffset_0;

		// Token: 0x0400FB9B RID: 64411
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FB9C RID: 64412
		internal static int __PropertyOffset_1;

		// Token: 0x0400FB9D RID: 64413
		internal static int __PropertyOffset_2;

		// Token: 0x0400FB9E RID: 64414
		internal static int __PropertyOffset_3;

		// Token: 0x0400FB9F RID: 64415
		internal static int __PropertyOffset_4;

		// Token: 0x0400FBA0 RID: 64416
		internal static int __PropertyOffset_5;

		// Token: 0x0400FBA1 RID: 64417
		internal static int __PropertyOffset_6;

		// Token: 0x0400FBA2 RID: 64418
		internal static int __PropertyOffset_7;

		// Token: 0x0400FBA3 RID: 64419
		internal static int __PropertyOffset_8;

		// Token: 0x0400FBA4 RID: 64420
		internal static int __PropertyOffset_9;

		// Token: 0x0400FBA5 RID: 64421
		internal static int __PropertyOffset_10;

		// Token: 0x0400FBA6 RID: 64422
		internal static int __PropertyOffset_11;

		// Token: 0x0400FBA7 RID: 64423
		internal static int __PropertyOffset_12;

		// Token: 0x0400FBA8 RID: 64424
		internal static int __PropertyOffset_13;

		// Token: 0x0400FBA9 RID: 64425
		internal static int __PropertyOffset_14;

		// Token: 0x0400FBAA RID: 64426
		internal static int __PropertyOffset_15;

		// Token: 0x0400FBAB RID: 64427
		internal static int __PropertyOffset_16;

		// Token: 0x0400FBAC RID: 64428
		internal static int __PropertyOffset_17;

		// Token: 0x0400FBAD RID: 64429
		internal static int __PropertyOffset_18;

		// Token: 0x0400FBAE RID: 64430
		internal static int __PropertyOffset_19;

		// Token: 0x0400FBAF RID: 64431
		internal static int __PropertyOffset_20;

		// Token: 0x0400FBB0 RID: 64432
		internal static int __PropertyOffset_21;

		// Token: 0x0400FBB1 RID: 64433
		internal static int __PropertyOffset_22;

		// Token: 0x0400FBB2 RID: 64434
		internal static int __PropertyOffset_23;

		// Token: 0x0400FBB3 RID: 64435
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FBB4 RID: 64436
		private static IntPtr __FromDa_NativeFunctionPtr;

		// Token: 0x0400FBB5 RID: 64437
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FBB6 RID: 64438
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FBB7 RID: 64439
		private static IntPtr __ExecuteUbergraph_BP_ShadowDecal_NativeFunctionPtr;

		// Token: 0x0200990A RID: 39178
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F69 RID: 204649
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x0200990B RID: 39179
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F6A RID: 204650
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200990C RID: 39180
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_ShadowDecal_FunctionParams
		{
			// Token: 0x04031F6B RID: 204651
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
