using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A97 RID: 14999
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowDecal_AlwayTick.BP_ShadowDecal_AlwayTick_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1196)]
	public class BP_ShadowDecal_AlwayTick_C : AKuroDecalActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F9C7 RID: 129479 RVA: 0x0091634C File Offset: 0x0091454C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ShadowDecal_AlwayTick_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowDecal_AlwayTick.BP_ShadowDecal_AlwayTick_C");
			}
			return BP_ShadowDecal_AlwayTick_C._ClassPtr;
		}

		// Token: 0x0601F9C8 RID: 129480 RVA: 0x00916370 File Offset: 0x00914570
		public BP_ShadowDecal_AlwayTick_C() : this(BuiltinUtils.AllocNativeUObject(BP_ShadowDecal_AlwayTick_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F9C9 RID: 129481 RVA: 0x00916398 File Offset: 0x00914598
		[NullableContext(1)]
		public BP_ShadowDecal_AlwayTick_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ShadowDecal_AlwayTick_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170030E7 RID: 12519
		// (get) Token: 0x0601F9CA RID: 129482 RVA: 0x009163CC File Offset: 0x009145CC
		// (set) Token: 0x0601F9CB RID: 129483 RVA: 0x00916405 File Offset: 0x00914605
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170030E8 RID: 12520
		// (get) Token: 0x0601F9CC RID: 129484 RVA: 0x00916426 File Offset: 0x00914626
		// (set) Token: 0x0601F9CD RID: 129485 RVA: 0x0091643A File Offset: 0x0091463A
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_AlwayTick_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_AlwayTick_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170030E9 RID: 12521
		// (get) Token: 0x0601F9CE RID: 129486 RVA: 0x0091644F File Offset: 0x0091464F
		// (set) Token: 0x0601F9CF RID: 129487 RVA: 0x00916463 File Offset: 0x00914663
		public unsafe UMaterialInstanceDynamic DYMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_AlwayTick_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_AlwayTick_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170030EA RID: 12522
		// (get) Token: 0x0601F9D0 RID: 129488 RVA: 0x00916478 File Offset: 0x00914678
		// (set) Token: 0x0601F9D1 RID: 129489 RVA: 0x0091648C File Offset: 0x0091468C
		public unsafe UTexture2D ShadowTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_AlwayTick_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_AlwayTick_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170030EB RID: 12523
		// (get) Token: 0x0601F9D2 RID: 129490 RVA: 0x009164A1 File Offset: 0x009146A1
		// (set) Token: 0x0601F9D3 RID: 129491 RVA: 0x009164B1 File Offset: 0x009146B1
		public unsafe float ShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170030EC RID: 12524
		// (get) Token: 0x0601F9D4 RID: 129492 RVA: 0x009164C2 File Offset: 0x009146C2
		// (set) Token: 0x0601F9D5 RID: 129493 RVA: 0x009164D2 File Offset: 0x009146D2
		public unsafe float InvShadow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170030ED RID: 12525
		// (get) Token: 0x0601F9D6 RID: 129494 RVA: 0x009164E3 File Offset: 0x009146E3
		// (set) Token: 0x0601F9D7 RID: 129495 RVA: 0x009164F7 File Offset: 0x009146F7
		public unsafe UTexture2D EvolutionaryTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_AlwayTick_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowDecal_AlwayTick_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170030EE RID: 12526
		// (get) Token: 0x0601F9D8 RID: 129496 RVA: 0x0091650C File Offset: 0x0091470C
		// (set) Token: 0x0601F9D9 RID: 129497 RVA: 0x0091651C File Offset: 0x0091471C
		public unsafe float EvolutionaryIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170030EF RID: 12527
		// (get) Token: 0x0601F9DA RID: 129498 RVA: 0x0091652D File Offset: 0x0091472D
		// (set) Token: 0x0601F9DB RID: 129499 RVA: 0x0091653D File Offset: 0x0091473D
		public unsafe float EvolutionaryRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170030F0 RID: 12528
		// (get) Token: 0x0601F9DC RID: 129500 RVA: 0x0091654E File Offset: 0x0091474E
		// (set) Token: 0x0601F9DD RID: 129501 RVA: 0x0091655E File Offset: 0x0091475E
		public unsafe float EvolutionaryDirectional_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170030F1 RID: 12529
		// (get) Token: 0x0601F9DE RID: 129502 RVA: 0x0091656F File Offset: 0x0091476F
		// (set) Token: 0x0601F9DF RID: 129503 RVA: 0x0091657F File Offset: 0x0091477F
		public unsafe float EvolutionaryDirectional_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170030F2 RID: 12530
		// (get) Token: 0x0601F9E0 RID: 129504 RVA: 0x00916590 File Offset: 0x00914790
		// (set) Token: 0x0601F9E1 RID: 129505 RVA: 0x009165A0 File Offset: 0x009147A0
		public unsafe float MobileShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170030F3 RID: 12531
		// (get) Token: 0x0601F9E2 RID: 129506 RVA: 0x009165B1 File Offset: 0x009147B1
		// (set) Token: 0x0601F9E3 RID: 129507 RVA: 0x009165C1 File Offset: 0x009147C1
		public unsafe int DALayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170030F4 RID: 12532
		// (get) Token: 0x0601F9E4 RID: 129508 RVA: 0x009165D2 File Offset: 0x009147D2
		// (set) Token: 0x0601F9E5 RID: 129509 RVA: 0x009165E6 File Offset: 0x009147E6
		public unsafe FName MPC_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170030F5 RID: 12533
		// (get) Token: 0x0601F9E6 RID: 129510 RVA: 0x009165FB File Offset: 0x009147FB
		// (set) Token: 0x0601F9E7 RID: 129511 RVA: 0x0091660B File Offset: 0x0091480B
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170030F6 RID: 12534
		// (get) Token: 0x0601F9E8 RID: 129512 RVA: 0x0091661C File Offset: 0x0091481C
		// (set) Token: 0x0601F9E9 RID: 129513 RVA: 0x0091662C File Offset: 0x0091482C
		public unsafe float RestoreVal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170030F7 RID: 12535
		// (get) Token: 0x0601F9EA RID: 129514 RVA: 0x0091663D File Offset: 0x0091483D
		// (set) Token: 0x0601F9EB RID: 129515 RVA: 0x0091664D File Offset: 0x0091484D
		public unsafe float DeltaTimeTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170030F8 RID: 12536
		// (get) Token: 0x0601F9EC RID: 129516 RVA: 0x0091665E File Offset: 0x0091485E
		// (set) Token: 0x0601F9ED RID: 129517 RVA: 0x0091666E File Offset: 0x0091486E
		public unsafe float WindIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170030F9 RID: 12537
		// (get) Token: 0x0601F9EE RID: 129518 RVA: 0x0091667F File Offset: 0x0091487F
		// (set) Token: 0x0601F9EF RID: 129519 RVA: 0x0091668F File Offset: 0x0091488F
		public unsafe float WindSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170030FA RID: 12538
		// (get) Token: 0x0601F9F0 RID: 129520 RVA: 0x009166A0 File Offset: 0x009148A0
		// (set) Token: 0x0601F9F1 RID: 129521 RVA: 0x009166B0 File Offset: 0x009148B0
		public unsafe float WindDir_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170030FB RID: 12539
		// (get) Token: 0x0601F9F2 RID: 129522 RVA: 0x009166C1 File Offset: 0x009148C1
		// (set) Token: 0x0601F9F3 RID: 129523 RVA: 0x009166D1 File Offset: 0x009148D1
		public unsafe float WindDir_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170030FC RID: 12540
		// (get) Token: 0x0601F9F4 RID: 129524 RVA: 0x009166E2 File Offset: 0x009148E2
		// (set) Token: 0x0601F9F5 RID: 129525 RVA: 0x009166F2 File Offset: 0x009148F2
		public unsafe float StrenghtAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170030FD RID: 12541
		// (get) Token: 0x0601F9F6 RID: 129526 RVA: 0x00916703 File Offset: 0x00914903
		// (set) Token: 0x0601F9F7 RID: 129527 RVA: 0x00916713 File Offset: 0x00914913
		public unsafe float WindRandomSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170030FE RID: 12542
		// (get) Token: 0x0601F9F8 RID: 129528 RVA: 0x00916724 File Offset: 0x00914924
		// (set) Token: 0x0601F9F9 RID: 129529 RVA: 0x00916734 File Offset: 0x00914934
		public unsafe float WindRandomIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowDecal_AlwayTick_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x0601F9FA RID: 129530 RVA: 0x00916745 File Offset: 0x00914945
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FromDa()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowDecal_AlwayTick_C.__FromDa_NativeFunctionPtr, null);
		}

		// Token: 0x0601F9FB RID: 129531 RVA: 0x00916759 File Offset: 0x00914959
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowDecal_AlwayTick_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F9FC RID: 129532 RVA: 0x0091676D File Offset: 0x0091496D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowDecal_AlwayTick_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F9FD RID: 129533 RVA: 0x00916784 File Offset: 0x00914984
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ShadowDecal_AlwayTick_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShadowDecal_AlwayTick_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowDecal_AlwayTick_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowDecal_AlwayTick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowDecal_AlwayTick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F9FE RID: 129534 RVA: 0x009167CC File Offset: 0x009149CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ShadowDecal_AlwayTick_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShadowDecal_AlwayTick_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowDecal_AlwayTick_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowDecal_AlwayTick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowDecal_AlwayTick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F9FF RID: 129535 RVA: 0x00916814 File Offset: 0x00914A14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ShadowDecal_AlwayTick(int EntryPoint)
		{
			BP_ShadowDecal_AlwayTick_C.__ExecuteUbergraph_BP_ShadowDecal_AlwayTick_FunctionParams* ptr = stackalloc BP_ShadowDecal_AlwayTick_C.__ExecuteUbergraph_BP_ShadowDecal_AlwayTick_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_ShadowDecal_AlwayTick_C.__ExecuteUbergraph_BP_ShadowDecal_AlwayTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowDecal_AlwayTick_C.__ExecuteUbergraph_BP_ShadowDecal_AlwayTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowDecal_AlwayTick_C.__ExecuteUbergraph_BP_ShadowDecal_AlwayTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FA00 RID: 129536 RVA: 0x0091685B File Offset: 0x00914A5B
		protected BP_ShadowDecal_AlwayTick_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FB76 RID: 64374
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowDecal_AlwayTick.BP_ShadowDecal_AlwayTick_C";

		// Token: 0x0400FB77 RID: 64375
		private static IntPtr _ClassPtr;

		// Token: 0x0400FB78 RID: 64376
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FB79 RID: 64377
		internal static int __PropertyOffset_0;

		// Token: 0x0400FB7A RID: 64378
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FB7B RID: 64379
		internal static int __PropertyOffset_1;

		// Token: 0x0400FB7C RID: 64380
		internal static int __PropertyOffset_2;

		// Token: 0x0400FB7D RID: 64381
		internal static int __PropertyOffset_3;

		// Token: 0x0400FB7E RID: 64382
		internal static int __PropertyOffset_4;

		// Token: 0x0400FB7F RID: 64383
		internal static int __PropertyOffset_5;

		// Token: 0x0400FB80 RID: 64384
		internal static int __PropertyOffset_6;

		// Token: 0x0400FB81 RID: 64385
		internal static int __PropertyOffset_7;

		// Token: 0x0400FB82 RID: 64386
		internal static int __PropertyOffset_8;

		// Token: 0x0400FB83 RID: 64387
		internal static int __PropertyOffset_9;

		// Token: 0x0400FB84 RID: 64388
		internal static int __PropertyOffset_10;

		// Token: 0x0400FB85 RID: 64389
		internal static int __PropertyOffset_11;

		// Token: 0x0400FB86 RID: 64390
		internal static int __PropertyOffset_12;

		// Token: 0x0400FB87 RID: 64391
		internal static int __PropertyOffset_13;

		// Token: 0x0400FB88 RID: 64392
		internal static int __PropertyOffset_14;

		// Token: 0x0400FB89 RID: 64393
		internal static int __PropertyOffset_15;

		// Token: 0x0400FB8A RID: 64394
		internal static int __PropertyOffset_16;

		// Token: 0x0400FB8B RID: 64395
		internal static int __PropertyOffset_17;

		// Token: 0x0400FB8C RID: 64396
		internal static int __PropertyOffset_18;

		// Token: 0x0400FB8D RID: 64397
		internal static int __PropertyOffset_19;

		// Token: 0x0400FB8E RID: 64398
		internal static int __PropertyOffset_20;

		// Token: 0x0400FB8F RID: 64399
		internal static int __PropertyOffset_21;

		// Token: 0x0400FB90 RID: 64400
		internal static int __PropertyOffset_22;

		// Token: 0x0400FB91 RID: 64401
		internal static int __PropertyOffset_23;

		// Token: 0x0400FB92 RID: 64402
		private static IntPtr __FromDa_NativeFunctionPtr;

		// Token: 0x0400FB93 RID: 64403
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FB94 RID: 64404
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FB95 RID: 64405
		private static IntPtr __ExecuteUbergraph_BP_ShadowDecal_AlwayTick_NativeFunctionPtr;

		// Token: 0x02009908 RID: 39176
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F67 RID: 204647
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009909 RID: 39177
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_ShadowDecal_AlwayTick_FunctionParams
		{
			// Token: 0x04031F68 RID: 204648
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
