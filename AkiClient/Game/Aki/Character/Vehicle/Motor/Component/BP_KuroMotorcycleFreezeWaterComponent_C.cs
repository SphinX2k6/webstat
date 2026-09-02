using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Component
{
	// Token: 0x02003FBD RID: 16317
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Component/BP_KuroMotorcycleFreezeWaterComponent.BP_KuroMotorcycleFreezeWaterComponent_C")]
	[UnrealStructLayout(2224, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2216)]
	public class BP_KuroMotorcycleFreezeWaterComponent_C : UKuroWaterInteractionComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028F02 RID: 167682 RVA: 0x00A1B4A0 File Offset: 0x00A196A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroMotorcycleFreezeWaterComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Component/BP_KuroMotorcycleFreezeWaterComponent.BP_KuroMotorcycleFreezeWaterComponent_C");
			}
			return BP_KuroMotorcycleFreezeWaterComponent_C._ClassPtr;
		}

		// Token: 0x06028F03 RID: 167683 RVA: 0x00A1B4C4 File Offset: 0x00A196C4
		public BP_KuroMotorcycleFreezeWaterComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroMotorcycleFreezeWaterComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028F04 RID: 167684 RVA: 0x00A1B4EC File Offset: 0x00A196EC
		[NullableContext(1)]
		public BP_KuroMotorcycleFreezeWaterComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroMotorcycleFreezeWaterComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064DA RID: 25818
		// (get) Token: 0x06028F05 RID: 167685 RVA: 0x00A1B520 File Offset: 0x00A19720
		// (set) Token: 0x06028F06 RID: 167686 RVA: 0x00A1B559 File Offset: 0x00A19759
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064DB RID: 25819
		// (get) Token: 0x06028F07 RID: 167687 RVA: 0x00A1B57A File Offset: 0x00A1977A
		// (set) Token: 0x06028F08 RID: 167688 RVA: 0x00A1B58E File Offset: 0x00A1978E
		public unsafe UTextureRenderTarget2D RT_PosA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170064DC RID: 25820
		// (get) Token: 0x06028F09 RID: 167689 RVA: 0x00A1B5A3 File Offset: 0x00A197A3
		// (set) Token: 0x06028F0A RID: 167690 RVA: 0x00A1B5B7 File Offset: 0x00A197B7
		public unsafe UTextureRenderTarget2D RT_PosB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170064DD RID: 25821
		// (get) Token: 0x06028F0B RID: 167691 RVA: 0x00A1B5CC File Offset: 0x00A197CC
		// (set) Token: 0x06028F0C RID: 167692 RVA: 0x00A1B5E0 File Offset: 0x00A197E0
		public unsafe UMaterialInterface M_DrawRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170064DE RID: 25822
		// (get) Token: 0x06028F0D RID: 167693 RVA: 0x00A1B5F5 File Offset: 0x00A197F5
		// (set) Token: 0x06028F0E RID: 167694 RVA: 0x00A1B609 File Offset: 0x00A19809
		public unsafe UMaterialInstanceDynamic MID_StampPos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170064DF RID: 25823
		// (get) Token: 0x06028F0F RID: 167695 RVA: 0x00A1B61E File Offset: 0x00A1981E
		// (set) Token: 0x06028F10 RID: 167696 RVA: 0x00A1B632 File Offset: 0x00A19832
		public unsafe UMaterialInstanceDynamic MID_UpdatePos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170064E0 RID: 25824
		// (get) Token: 0x06028F11 RID: 167697 RVA: 0x00A1B647 File Offset: 0x00A19847
		// (set) Token: 0x06028F12 RID: 167698 RVA: 0x00A1B65B File Offset: 0x00A1985B
		public unsafe UMaterialInstanceDynamic MID_Ice
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170064E1 RID: 25825
		// (get) Token: 0x06028F13 RID: 167699 RVA: 0x00A1B670 File Offset: 0x00A19870
		// (set) Token: 0x06028F14 RID: 167700 RVA: 0x00A1B684 File Offset: 0x00A19884
		public unsafe FLinearColor Clear_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170064E2 RID: 25826
		// (get) Token: 0x06028F15 RID: 167701 RVA: 0x00A1B699 File Offset: 0x00A19899
		// (set) Token: 0x06028F16 RID: 167702 RVA: 0x00A1B6A9 File Offset: 0x00A198A9
		public unsafe float InteractionSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170064E3 RID: 25827
		// (get) Token: 0x06028F17 RID: 167703 RVA: 0x00A1B6BA File Offset: 0x00A198BA
		// (set) Token: 0x06028F18 RID: 167704 RVA: 0x00A1B6CA File Offset: 0x00A198CA
		public unsafe float Attenuation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170064E4 RID: 25828
		// (get) Token: 0x06028F19 RID: 167705 RVA: 0x00A1B6DB File Offset: 0x00A198DB
		// (set) Token: 0x06028F1A RID: 167706 RVA: 0x00A1B6EF File Offset: 0x00A198EF
		public unsafe FVectorDouble PixelPos_Curr
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170064E5 RID: 25829
		// (get) Token: 0x06028F1B RID: 167707 RVA: 0x00A1B704 File Offset: 0x00A19904
		// (set) Token: 0x06028F1C RID: 167708 RVA: 0x00A1B718 File Offset: 0x00A19918
		public unsafe FVectorDouble PixelPos_Prev
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170064E6 RID: 25830
		// (get) Token: 0x06028F1D RID: 167709 RVA: 0x00A1B72D File Offset: 0x00A1992D
		// (set) Token: 0x06028F1E RID: 167710 RVA: 0x00A1B73D File Offset: 0x00A1993D
		public unsafe bool DetectingWater
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064E7 RID: 25831
		// (get) Token: 0x06028F1F RID: 167711 RVA: 0x00A1B74E File Offset: 0x00A1994E
		// (set) Token: 0x06028F20 RID: 167712 RVA: 0x00A1B762 File Offset: 0x00A19962
		public unsafe UKuroTrailCollisionAsset Config
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroTrailCollisionAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170064E8 RID: 25832
		// (get) Token: 0x06028F21 RID: 167713 RVA: 0x00A1B777 File Offset: 0x00A19977
		// (set) Token: 0x06028F22 RID: 167714 RVA: 0x00A1B78B File Offset: 0x00A1998B
		public unsafe UMaterialInterface M_Ice
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170064E9 RID: 25833
		// (get) Token: 0x06028F23 RID: 167715 RVA: 0x00A1B7A0 File Offset: 0x00A199A0
		// (set) Token: 0x06028F24 RID: 167716 RVA: 0x00A1B7B4 File Offset: 0x00A199B4
		public unsafe FVectorDouble PixelPos_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroMotorcycleFreezeWaterComponent_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x06028F25 RID: 167717 RVA: 0x00A1B7C9 File Offset: 0x00A199C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__ClearRT_NativeFunctionPtr, null);
		}

		// Token: 0x06028F26 RID: 167718 RVA: 0x00A1B7DD File Offset: 0x00A199DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CreateMID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__CreateMID_NativeFunctionPtr, null);
		}

		// Token: 0x06028F27 RID: 167719 RVA: 0x00A1B7F1 File Offset: 0x00A199F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06028F28 RID: 167720 RVA: 0x00A1B805 File Offset: 0x00A19A05
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028F29 RID: 167721 RVA: 0x00A1B81A File Offset: 0x00A19A1A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void HandleWaterDetectedStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedStart_NativeFunctionPtr, null);
		}

		// Token: 0x06028F2A RID: 167722 RVA: 0x00A1B82E File Offset: 0x00A19A2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void HandleWaterDetectedStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028F2B RID: 167723 RVA: 0x00A1B843 File Offset: 0x00A19A43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void HandleWaterDetectedEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedEnd_NativeFunctionPtr, null);
		}

		// Token: 0x06028F2C RID: 167724 RVA: 0x00A1B857 File Offset: 0x00A19A57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void HandleWaterDetectedEnd_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedEnd_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028F2D RID: 167725 RVA: 0x00A1B86C File Offset: 0x00A19A6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void HandleWaterDetectedTick(float DeltaTime, float WaterSurface, in FVectorDouble Location)
		{
			BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_FunctionParams* ptr = stackalloc BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			ptr->WaterSurface = WaterSurface;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028F2E RID: 167726 RVA: 0x00A1B8C8 File Offset: 0x00A19AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void HandleWaterDetectedTick_Implementation(float DeltaTime, float WaterSurface, in FVectorDouble Location)
		{
			BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_FunctionParams* ptr = stackalloc BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			ptr->WaterSurface = WaterSurface;
			ptr->Location = Location;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__HandleWaterDetectedTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F2F RID: 167727 RVA: 0x00A1B924 File Offset: 0x00A19B24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028F30 RID: 167728 RVA: 0x00A1B96C File Offset: 0x00A19B6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F31 RID: 167729 RVA: 0x00A1B9B4 File Offset: 0x00A19BB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028F32 RID: 167730 RVA: 0x00A1BA00 File Offset: 0x00A19C00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F33 RID: 167731 RVA: 0x00A1BA4C File Offset: 0x00A19C4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroMotorcycleFreezeWaterComponent(int EntryPoint)
		{
			BP_KuroMotorcycleFreezeWaterComponent_C.__ExecuteUbergraph_BP_KuroMotorcycleFreezeWaterComponent_FunctionParams* ptr = stackalloc BP_KuroMotorcycleFreezeWaterComponent_C.__ExecuteUbergraph_BP_KuroMotorcycleFreezeWaterComponent_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_KuroMotorcycleFreezeWaterComponent_C.__ExecuteUbergraph_BP_KuroMotorcycleFreezeWaterComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMotorcycleFreezeWaterComponent_C.__ExecuteUbergraph_BP_KuroMotorcycleFreezeWaterComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMotorcycleFreezeWaterComponent_C.__ExecuteUbergraph_BP_KuroMotorcycleFreezeWaterComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F34 RID: 167732 RVA: 0x00A1BA96 File Offset: 0x00A19C96
		protected BP_KuroMotorcycleFreezeWaterComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A87 RID: 88711
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Component/BP_KuroMotorcycleFreezeWaterComponent.BP_KuroMotorcycleFreezeWaterComponent_C";

		// Token: 0x04015A88 RID: 88712
		private static IntPtr _ClassPtr;

		// Token: 0x04015A89 RID: 88713
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015A8A RID: 88714
		internal static int __PropertyOffset_0;

		// Token: 0x04015A8B RID: 88715
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015A8C RID: 88716
		internal static int __PropertyOffset_1;

		// Token: 0x04015A8D RID: 88717
		internal static int __PropertyOffset_2;

		// Token: 0x04015A8E RID: 88718
		internal static int __PropertyOffset_3;

		// Token: 0x04015A8F RID: 88719
		internal static int __PropertyOffset_4;

		// Token: 0x04015A90 RID: 88720
		internal static int __PropertyOffset_5;

		// Token: 0x04015A91 RID: 88721
		internal static int __PropertyOffset_6;

		// Token: 0x04015A92 RID: 88722
		internal static int __PropertyOffset_7;

		// Token: 0x04015A93 RID: 88723
		internal static int __PropertyOffset_8;

		// Token: 0x04015A94 RID: 88724
		internal static int __PropertyOffset_9;

		// Token: 0x04015A95 RID: 88725
		internal static int __PropertyOffset_10;

		// Token: 0x04015A96 RID: 88726
		internal static int __PropertyOffset_11;

		// Token: 0x04015A97 RID: 88727
		internal static int __PropertyOffset_12;

		// Token: 0x04015A98 RID: 88728
		internal static int __PropertyOffset_13;

		// Token: 0x04015A99 RID: 88729
		internal static int __PropertyOffset_14;

		// Token: 0x04015A9A RID: 88730
		internal static int __PropertyOffset_15;

		// Token: 0x04015A9B RID: 88731
		private static IntPtr __ClearRT_NativeFunctionPtr;

		// Token: 0x04015A9C RID: 88732
		private static IntPtr __CreateMID_NativeFunctionPtr;

		// Token: 0x04015A9D RID: 88733
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04015A9E RID: 88734
		private static IntPtr __HandleWaterDetectedStart_NativeFunctionPtr;

		// Token: 0x04015A9F RID: 88735
		private static IntPtr __HandleWaterDetectedEnd_NativeFunctionPtr;

		// Token: 0x04015AA0 RID: 88736
		private static IntPtr __HandleWaterDetectedTick_NativeFunctionPtr;

		// Token: 0x04015AA1 RID: 88737
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04015AA2 RID: 88738
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04015AA3 RID: 88739
		private static IntPtr __ExecuteUbergraph_BP_KuroMotorcycleFreezeWaterComponent_NativeFunctionPtr;

		// Token: 0x0200A167 RID: 41319
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected new ref struct __HandleWaterDetectedTick_FunctionParams
		{
			// Token: 0x04032EA7 RID: 208551
			[FieldOffset(0)]
			public float DeltaTime;

			// Token: 0x04032EA8 RID: 208552
			[FieldOffset(4)]
			public float WaterSurface;

			// Token: 0x04032EA9 RID: 208553
			[FieldOffset(8)]
			public FVectorDouble Location;
		}

		// Token: 0x0200A168 RID: 41320
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032EAA RID: 208554
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A169 RID: 41321
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032EAB RID: 208555
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200A16A RID: 41322
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __ExecuteUbergraph_BP_KuroMotorcycleFreezeWaterComponent_FunctionParams
		{
			// Token: 0x04032EAC RID: 208556
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
