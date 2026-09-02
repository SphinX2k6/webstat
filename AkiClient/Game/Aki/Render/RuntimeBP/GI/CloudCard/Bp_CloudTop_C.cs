using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.CloudCard
{
	// Token: 0x02003CEA RID: 15594
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/CloudCard/Bp_CloudTop.Bp_CloudTop_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1200)]
	public class Bp_CloudTop_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025398 RID: 152472 RVA: 0x009B4420 File Offset: 0x009B2620
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Bp_CloudTop_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/CloudCard/Bp_CloudTop.Bp_CloudTop_C");
			}
			return Bp_CloudTop_C._ClassPtr;
		}

		// Token: 0x06025399 RID: 152473 RVA: 0x009B4444 File Offset: 0x009B2644
		public Bp_CloudTop_C() : this(BuiltinUtils.AllocNativeUObject(Bp_CloudTop_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602539A RID: 152474 RVA: 0x009B446C File Offset: 0x009B266C
		[NullableContext(1)]
		public Bp_CloudTop_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Bp_CloudTop_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700504D RID: 20557
		// (get) Token: 0x0602539B RID: 152475 RVA: 0x009B44A0 File Offset: 0x009B26A0
		// (set) Token: 0x0602539C RID: 152476 RVA: 0x009B44D9 File Offset: 0x009B26D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700504E RID: 20558
		// (get) Token: 0x0602539D RID: 152477 RVA: 0x009B44FA File Offset: 0x009B26FA
		// (set) Token: 0x0602539E RID: 152478 RVA: 0x009B450E File Offset: 0x009B270E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudTop_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudTop_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700504F RID: 20559
		// (get) Token: 0x0602539F RID: 152479 RVA: 0x009B4523 File Offset: 0x009B2723
		// (set) Token: 0x060253A0 RID: 152480 RVA: 0x009B4533 File Offset: 0x009B2733
		public unsafe int CloudRow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005050 RID: 20560
		// (get) Token: 0x060253A1 RID: 152481 RVA: 0x009B4544 File Offset: 0x009B2744
		// (set) Token: 0x060253A2 RID: 152482 RVA: 0x009B4554 File Offset: 0x009B2754
		public unsafe int CloudColumn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005051 RID: 20561
		// (get) Token: 0x060253A3 RID: 152483 RVA: 0x009B4565 File Offset: 0x009B2765
		// (set) Token: 0x060253A4 RID: 152484 RVA: 0x009B4575 File Offset: 0x009B2775
		public unsafe int DefaultOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005052 RID: 20562
		// (get) Token: 0x060253A5 RID: 152485 RVA: 0x009B4586 File Offset: 0x009B2786
		// (set) Token: 0x060253A6 RID: 152486 RVA: 0x009B459A File Offset: 0x009B279A
		[Nullable(2)]
		public unsafe UStaticMesh SM_CloudCard
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudTop_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudTop_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005053 RID: 20563
		// (get) Token: 0x060253A7 RID: 152487 RVA: 0x009B45AF File Offset: 0x009B27AF
		// (set) Token: 0x060253A8 RID: 152488 RVA: 0x009B45BF File Offset: 0x009B27BF
		public unsafe float DefaultHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005054 RID: 20564
		// (get) Token: 0x060253A9 RID: 152489 RVA: 0x009B45D0 File Offset: 0x009B27D0
		// (set) Token: 0x060253AA RID: 152490 RVA: 0x009B4609 File Offset: 0x009B2809
		[Nullable(1)]
		public TArray<UStaticMeshComponent> CloudCardComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._CloudCardComponents) == null)
				{
					result = (this._CloudCardComponents = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CloudCardComponents.CopyAssign(value);
			}
		}

		// Token: 0x17005055 RID: 20565
		// (get) Token: 0x060253AB RID: 152491 RVA: 0x009B4617 File Offset: 0x009B2817
		// (set) Token: 0x060253AC RID: 152492 RVA: 0x009B4627 File Offset: 0x009B2827
		public unsafe float InitAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005056 RID: 20566
		// (get) Token: 0x060253AD RID: 152493 RVA: 0x009B4638 File Offset: 0x009B2838
		// (set) Token: 0x060253AE RID: 152494 RVA: 0x009B464C File Offset: 0x009B284C
		public unsafe FVector CloudUVNoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005057 RID: 20567
		// (get) Token: 0x060253AF RID: 152495 RVA: 0x009B4661 File Offset: 0x009B2861
		// (set) Token: 0x060253B0 RID: 152496 RVA: 0x009B4671 File Offset: 0x009B2871
		public unsafe float CloudUVNoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005058 RID: 20568
		// (get) Token: 0x060253B1 RID: 152497 RVA: 0x009B4682 File Offset: 0x009B2882
		// (set) Token: 0x060253B2 RID: 152498 RVA: 0x009B4692 File Offset: 0x009B2892
		public unsafe float CloudUVNoiseTiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005059 RID: 20569
		// (get) Token: 0x060253B3 RID: 152499 RVA: 0x009B46A4 File Offset: 0x009B28A4
		// (set) Token: 0x060253B4 RID: 152500 RVA: 0x009B46DD File Offset: 0x009B28DD
		[Nullable(1)]
		public TArray<FKuroCloudTopData> CloudDatas
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCloudTopData> result;
				if ((result = this._CloudDatas) == null)
				{
					result = (this._CloudDatas = new TArray<FKuroCloudTopData>(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CloudDatas.CopyAssign(value);
			}
		}

		// Token: 0x1700505A RID: 20570
		// (get) Token: 0x060253B5 RID: 152501 RVA: 0x009B46EB File Offset: 0x009B28EB
		// (set) Token: 0x060253B6 RID: 152502 RVA: 0x009B46FB File Offset: 0x009B28FB
		public unsafe float WindSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700505B RID: 20571
		// (get) Token: 0x060253B7 RID: 152503 RVA: 0x009B470C File Offset: 0x009B290C
		// (set) Token: 0x060253B8 RID: 152504 RVA: 0x009B471C File Offset: 0x009B291C
		public unsafe float CurYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700505C RID: 20572
		// (get) Token: 0x060253B9 RID: 152505 RVA: 0x009B4730 File Offset: 0x009B2930
		// (set) Token: 0x060253BA RID: 152506 RVA: 0x009B4769 File Offset: 0x009B2969
		[Nullable(1)]
		public TArray<float> FadeTime
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._FadeTime) == null)
				{
					result = (this._FadeTime = new TArray<float>(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FadeTime.CopyAssign(value);
			}
		}

		// Token: 0x1700505D RID: 20573
		// (get) Token: 0x060253BB RID: 152507 RVA: 0x009B4778 File Offset: 0x009B2978
		// (set) Token: 0x060253BC RID: 152508 RVA: 0x009B47B1 File Offset: 0x009B29B1
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> CloudMaterials
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._CloudMaterials) == null)
				{
					result = (this._CloudMaterials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)Bp_CloudTop_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CloudMaterials.CopyAssign(value);
			}
		}

		// Token: 0x1700505E RID: 20574
		// (get) Token: 0x060253BD RID: 152509 RVA: 0x009B47BF File Offset: 0x009B29BF
		// (set) Token: 0x060253BE RID: 152510 RVA: 0x009B47D3 File Offset: 0x009B29D3
		[Nullable(1)]
		public unsafe string TestStr
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Bp_CloudTop_C.__PropertyOffset_17)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Bp_CloudTop_C.__PropertyOffset_17)), value);
			}
		}

		// Token: 0x1700505F RID: 20575
		// (get) Token: 0x060253BF RID: 152511 RVA: 0x009B47E8 File Offset: 0x009B29E8
		// (set) Token: 0x060253C0 RID: 152512 RVA: 0x009B47FC File Offset: 0x009B29FC
		[Nullable(2)]
		public unsafe UTexture2D CloudTex
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudTop_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudTop_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x060253C1 RID: 152513 RVA: 0x009B4814 File Offset: 0x009B2A14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardBrightness(int Idx, ref float Brightness)
		{
			Bp_CloudTop_C.__GetCardBrightness_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardBrightness_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardBrightness_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardBrightness_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->Brightness = Brightness;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardBrightness_NativeFunctionPtr, (void*)ptr);
			Brightness = ptr->Brightness;
		}

		// Token: 0x060253C2 RID: 152514 RVA: 0x009B486C File Offset: 0x009B2A6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardDisappearTime(int Idx, ref float FullStayTime)
		{
			Bp_CloudTop_C.__GetCardDisappearTime_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardDisappearTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardDisappearTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardDisappearTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FullStayTime = FullStayTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardDisappearTime_NativeFunctionPtr, (void*)ptr);
			FullStayTime = ptr->FullStayTime;
		}

		// Token: 0x060253C3 RID: 152515 RVA: 0x009B48C4 File Offset: 0x009B2AC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetFadeTickTime(int Idx, ref float FadeTime)
		{
			Bp_CloudTop_C.__GetFadeTickTime_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetFadeTickTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudTop_C.__GetFadeTickTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetFadeTickTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FadeTime = FadeTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetFadeTickTime_NativeFunctionPtr, (void*)ptr);
			FadeTime = ptr->FadeTime;
		}

		// Token: 0x060253C4 RID: 152516 RVA: 0x009B491C File Offset: 0x009B2B1C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardMaterial(int Idx, ref UMaterialInstanceDynamic mat)
		{
			Bp_CloudTop_C.__GetCardMaterial_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardMaterial_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ref Bp_CloudTop_C.__GetCardMaterial_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = mat;
			ptr2.mat = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardMaterial_NativeFunctionPtr, (void*)ptr);
			mat = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->mat);
		}

		// Token: 0x060253C5 RID: 152517 RVA: 0x009B4988 File Offset: 0x009B2B88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardFullStayTime(int Idx, ref float FullStayTime)
		{
			Bp_CloudTop_C.__GetCardFullStayTime_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardFullStayTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardFullStayTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardFullStayTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FullStayTime = FullStayTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardFullStayTime_NativeFunctionPtr, (void*)ptr);
			FullStayTime = ptr->FullStayTime;
		}

		// Token: 0x060253C6 RID: 152518 RVA: 0x009B49E0 File Offset: 0x009B2BE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardFadeInTime(int Idx, ref float FadeInTime)
		{
			Bp_CloudTop_C.__GetCardFadeInTime_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardFadeInTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardFadeInTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardFadeInTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FadeInTime = FadeInTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardFadeInTime_NativeFunctionPtr, (void*)ptr);
			FadeInTime = ptr->FadeInTime;
		}

		// Token: 0x060253C7 RID: 152519 RVA: 0x009B4A38 File Offset: 0x009B2C38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardFadeOutTime(int Idx, ref float FadeOutTime)
		{
			Bp_CloudTop_C.__GetCardFadeOutTime_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardFadeOutTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardFadeOutTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardFadeOutTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FadeOutTime = FadeOutTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardFadeOutTime_NativeFunctionPtr, (void*)ptr);
			FadeOutTime = ptr->FadeOutTime;
		}

		// Token: 0x060253C8 RID: 152520 RVA: 0x009B4A90 File Offset: 0x009B2C90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FadeTimeTick(float DeltaTime)
		{
			Bp_CloudTop_C.__FadeTimeTick_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__FadeTimeTick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(Bp_CloudTop_C.__FadeTimeTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__FadeTimeTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__FadeTimeTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060253C9 RID: 152521 RVA: 0x009B4AD8 File Offset: 0x009B2CD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardAlphaMin(int Idx, ref float alphamax)
		{
			Bp_CloudTop_C.__GetCardAlphaMin_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardAlphaMin_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardAlphaMin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardAlphaMin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->alphamax = alphamax;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardAlphaMin_NativeFunctionPtr, (void*)ptr);
			alphamax = ptr->alphamax;
		}

		// Token: 0x060253CA RID: 152522 RVA: 0x009B4B30 File Offset: 0x009B2D30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardAlphaMax(int Idx, ref float alphamax)
		{
			Bp_CloudTop_C.__GetCardAlphaMax_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardAlphaMax_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardAlphaMax_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardAlphaMax_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->alphamax = alphamax;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardAlphaMax_NativeFunctionPtr, (void*)ptr);
			alphamax = ptr->alphamax;
		}

		// Token: 0x060253CB RID: 152523 RVA: 0x009B4B88 File Offset: 0x009B2D88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardAlphaControl(int Idx, ref float alphacontrol)
		{
			Bp_CloudTop_C.__GetCardAlphaControl_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardAlphaControl_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardAlphaControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardAlphaControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->alphacontrol = alphacontrol;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardAlphaControl_NativeFunctionPtr, (void*)ptr);
			alphacontrol = ptr->alphacontrol;
		}

		// Token: 0x060253CC RID: 152524 RVA: 0x009B4BE0 File Offset: 0x009B2DE0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardScale(int Idx, UStaticMeshComponent SMComponent, ref FVector scale)
		{
			Bp_CloudTop_C.__GetCardScale_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardScale_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->SMComponent = ((SMComponent != null) ? SMComponent.NativePtr : IntPtr.Zero);
			ptr->scale = scale;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardScale_NativeFunctionPtr, (void*)ptr);
			scale = ptr->scale;
		}

		// Token: 0x060253CD RID: 152525 RVA: 0x009B4C58 File Offset: 0x009B2E58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardRotator(int Idx, ref FRotator Rotator)
		{
			Bp_CloudTop_C.__GetCardRotator_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardRotator_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardRotator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardRotator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->Rotator = Rotator;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardRotator_NativeFunctionPtr, (void*)ptr);
			Rotator = ptr->Rotator;
		}

		// Token: 0x060253CE RID: 152526 RVA: 0x009B4CB8 File Offset: 0x009B2EB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardTextureIdx(int Idx, ref int TextureIdx)
		{
			Bp_CloudTop_C.__GetCardTextureIdx_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__GetCardTextureIdx_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudTop_C.__GetCardTextureIdx_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__GetCardTextureIdx_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->TextureIdx = TextureIdx;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__GetCardTextureIdx_NativeFunctionPtr, (void*)ptr);
			TextureIdx = ptr->TextureIdx;
		}

		// Token: 0x060253CF RID: 152527 RVA: 0x009B4D10 File Offset: 0x009B2F10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Card_Offset(int Idx, FVector DefaultOffset, ref FVector Offset)
		{
			Bp_CloudTop_C.__Get_Card_Offset_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__Get_Card_Offset_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(Bp_CloudTop_C.__Get_Card_Offset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__Get_Card_Offset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->DefaultOffset = DefaultOffset;
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__Get_Card_Offset_NativeFunctionPtr, (void*)ptr);
			Offset = ptr->Offset;
		}

		// Token: 0x060253D0 RID: 152528 RVA: 0x009B4D75 File Offset: 0x009B2F75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetupCloudCards()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__SetupCloudCards_NativeFunctionPtr, null);
		}

		// Token: 0x060253D1 RID: 152529 RVA: 0x009B4D89 File Offset: 0x009B2F89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060253D2 RID: 152530 RVA: 0x009B4D9D File Offset: 0x009B2F9D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Bp_CloudTop_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060253D3 RID: 152531 RVA: 0x009B4DB4 File Offset: 0x009B2FB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			Bp_CloudTop_C.__ReceiveTick_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Bp_CloudTop_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudTop_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060253D4 RID: 152532 RVA: 0x009B4DFC File Offset: 0x009B2FFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			Bp_CloudTop_C.__ReceiveTick_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Bp_CloudTop_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Bp_CloudTop_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060253D5 RID: 152533 RVA: 0x009B4E44 File Offset: 0x009B3044
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Bp_CloudTop(int EntryPoint)
		{
			Bp_CloudTop_C.__ExecuteUbergraph_Bp_CloudTop_FunctionParams* ptr = stackalloc Bp_CloudTop_C.__ExecuteUbergraph_Bp_CloudTop_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(Bp_CloudTop_C.__ExecuteUbergraph_Bp_CloudTop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudTop_C.__ExecuteUbergraph_Bp_CloudTop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Bp_CloudTop_C.__ExecuteUbergraph_Bp_CloudTop_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060253D6 RID: 152534 RVA: 0x009B4E8B File Offset: 0x009B308B
		protected Bp_CloudTop_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040132B8 RID: 78520
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/CloudCard/Bp_CloudTop.Bp_CloudTop_C";

		// Token: 0x040132B9 RID: 78521
		private static IntPtr _ClassPtr;

		// Token: 0x040132BA RID: 78522
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040132BB RID: 78523
		internal static int __PropertyOffset_0;

		// Token: 0x040132BC RID: 78524
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040132BD RID: 78525
		internal static int __PropertyOffset_1;

		// Token: 0x040132BE RID: 78526
		internal static int __PropertyOffset_2;

		// Token: 0x040132BF RID: 78527
		internal static int __PropertyOffset_3;

		// Token: 0x040132C0 RID: 78528
		internal static int __PropertyOffset_4;

		// Token: 0x040132C1 RID: 78529
		internal static int __PropertyOffset_5;

		// Token: 0x040132C2 RID: 78530
		internal static int __PropertyOffset_6;

		// Token: 0x040132C3 RID: 78531
		internal static int __PropertyOffset_7;

		// Token: 0x040132C4 RID: 78532
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _CloudCardComponents;

		// Token: 0x040132C5 RID: 78533
		internal static int __PropertyOffset_8;

		// Token: 0x040132C6 RID: 78534
		internal static int __PropertyOffset_9;

		// Token: 0x040132C7 RID: 78535
		internal static int __PropertyOffset_10;

		// Token: 0x040132C8 RID: 78536
		internal static int __PropertyOffset_11;

		// Token: 0x040132C9 RID: 78537
		internal static int __PropertyOffset_12;

		// Token: 0x040132CA RID: 78538
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCloudTopData> _CloudDatas;

		// Token: 0x040132CB RID: 78539
		internal static int __PropertyOffset_13;

		// Token: 0x040132CC RID: 78540
		internal static int __PropertyOffset_14;

		// Token: 0x040132CD RID: 78541
		internal static int __PropertyOffset_15;

		// Token: 0x040132CE RID: 78542
		[Nullable(2)]
		private TArray<float> _FadeTime;

		// Token: 0x040132CF RID: 78543
		internal static int __PropertyOffset_16;

		// Token: 0x040132D0 RID: 78544
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _CloudMaterials;

		// Token: 0x040132D1 RID: 78545
		internal static int __PropertyOffset_17;

		// Token: 0x040132D2 RID: 78546
		internal static int __PropertyOffset_18;

		// Token: 0x040132D3 RID: 78547
		private static IntPtr __GetCardBrightness_NativeFunctionPtr;

		// Token: 0x040132D4 RID: 78548
		private static IntPtr __GetCardDisappearTime_NativeFunctionPtr;

		// Token: 0x040132D5 RID: 78549
		private static IntPtr __GetFadeTickTime_NativeFunctionPtr;

		// Token: 0x040132D6 RID: 78550
		private static IntPtr __GetCardMaterial_NativeFunctionPtr;

		// Token: 0x040132D7 RID: 78551
		private static IntPtr __GetCardFullStayTime_NativeFunctionPtr;

		// Token: 0x040132D8 RID: 78552
		private static IntPtr __GetCardFadeInTime_NativeFunctionPtr;

		// Token: 0x040132D9 RID: 78553
		private static IntPtr __GetCardFadeOutTime_NativeFunctionPtr;

		// Token: 0x040132DA RID: 78554
		private static IntPtr __FadeTimeTick_NativeFunctionPtr;

		// Token: 0x040132DB RID: 78555
		private static IntPtr __GetCardAlphaMin_NativeFunctionPtr;

		// Token: 0x040132DC RID: 78556
		private static IntPtr __GetCardAlphaMax_NativeFunctionPtr;

		// Token: 0x040132DD RID: 78557
		private static IntPtr __GetCardAlphaControl_NativeFunctionPtr;

		// Token: 0x040132DE RID: 78558
		private static IntPtr __GetCardScale_NativeFunctionPtr;

		// Token: 0x040132DF RID: 78559
		private static IntPtr __GetCardRotator_NativeFunctionPtr;

		// Token: 0x040132E0 RID: 78560
		private static IntPtr __GetCardTextureIdx_NativeFunctionPtr;

		// Token: 0x040132E1 RID: 78561
		private static IntPtr __Get_Card_Offset_NativeFunctionPtr;

		// Token: 0x040132E2 RID: 78562
		private static IntPtr __SetupCloudCards_NativeFunctionPtr;

		// Token: 0x040132E3 RID: 78563
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040132E4 RID: 78564
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040132E5 RID: 78565
		private static IntPtr __ExecuteUbergraph_Bp_CloudTop_NativeFunctionPtr;

		// Token: 0x02009ED9 RID: 40665
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardBrightness_FunctionParams
		{
			// Token: 0x040329B9 RID: 207289
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329BA RID: 207290
			[FieldOffset(4)]
			public float Brightness;
		}

		// Token: 0x02009EDA RID: 40666
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardDisappearTime_FunctionParams
		{
			// Token: 0x040329BB RID: 207291
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329BC RID: 207292
			[FieldOffset(4)]
			public float FullStayTime;
		}

		// Token: 0x02009EDB RID: 40667
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetFadeTickTime_FunctionParams
		{
			// Token: 0x040329BD RID: 207293
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329BE RID: 207294
			[FieldOffset(4)]
			public float FadeTime;
		}

		// Token: 0x02009EDC RID: 40668
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetCardMaterial_FunctionParams
		{
			// Token: 0x040329BF RID: 207295
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329C0 RID: 207296
			[FieldOffset(8)]
			public IntPtr mat;
		}

		// Token: 0x02009EDD RID: 40669
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardFullStayTime_FunctionParams
		{
			// Token: 0x040329C1 RID: 207297
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329C2 RID: 207298
			[FieldOffset(4)]
			public float FullStayTime;
		}

		// Token: 0x02009EDE RID: 40670
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardFadeInTime_FunctionParams
		{
			// Token: 0x040329C3 RID: 207299
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329C4 RID: 207300
			[FieldOffset(4)]
			public float FadeInTime;
		}

		// Token: 0x02009EDF RID: 40671
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardFadeOutTime_FunctionParams
		{
			// Token: 0x040329C5 RID: 207301
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329C6 RID: 207302
			[FieldOffset(4)]
			public float FadeOutTime;
		}

		// Token: 0x02009EE0 RID: 40672
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected ref struct __FadeTimeTick_FunctionParams
		{
			// Token: 0x040329C7 RID: 207303
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009EE1 RID: 40673
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCardAlphaMin_FunctionParams
		{
			// Token: 0x040329C8 RID: 207304
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329C9 RID: 207305
			[FieldOffset(4)]
			public float alphamax;
		}

		// Token: 0x02009EE2 RID: 40674
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCardAlphaMax_FunctionParams
		{
			// Token: 0x040329CA RID: 207306
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329CB RID: 207307
			[FieldOffset(4)]
			public float alphamax;
		}

		// Token: 0x02009EE3 RID: 40675
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCardAlphaControl_FunctionParams
		{
			// Token: 0x040329CC RID: 207308
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329CD RID: 207309
			[FieldOffset(4)]
			public float alphacontrol;
		}

		// Token: 0x02009EE4 RID: 40676
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __GetCardScale_FunctionParams
		{
			// Token: 0x040329CE RID: 207310
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329CF RID: 207311
			[FieldOffset(8)]
			public IntPtr SMComponent;

			// Token: 0x040329D0 RID: 207312
			[FieldOffset(16)]
			public FVector scale;
		}

		// Token: 0x02009EE5 RID: 40677
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected ref struct __GetCardRotator_FunctionParams
		{
			// Token: 0x040329D1 RID: 207313
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329D2 RID: 207314
			[FieldOffset(4)]
			public FRotator Rotator;
		}

		// Token: 0x02009EE6 RID: 40678
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardTextureIdx_FunctionParams
		{
			// Token: 0x040329D3 RID: 207315
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329D4 RID: 207316
			[FieldOffset(4)]
			public int TextureIdx;
		}

		// Token: 0x02009EE7 RID: 40679
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected ref struct __Get_Card_Offset_FunctionParams
		{
			// Token: 0x040329D5 RID: 207317
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329D6 RID: 207318
			[FieldOffset(4)]
			public FVector DefaultOffset;

			// Token: 0x040329D7 RID: 207319
			[FieldOffset(16)]
			public FVector Offset;
		}

		// Token: 0x02009EE8 RID: 40680
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040329D8 RID: 207320
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EE9 RID: 40681
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __ExecuteUbergraph_Bp_CloudTop_FunctionParams
		{
			// Token: 0x040329D9 RID: 207321
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
