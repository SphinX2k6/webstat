using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.CloudCard
{
	// Token: 0x02003CE9 RID: 15593
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/CloudCard/Bp_CloudCircle.Bp_CloudCircle_C")]
	[UnrealStructLayout(1568, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1568)]
	public class Bp_CloudCircle_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602534F RID: 152399 RVA: 0x009B37FE File Offset: 0x009B19FE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Bp_CloudCircle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/CloudCard/Bp_CloudCircle.Bp_CloudCircle_C");
			}
			return Bp_CloudCircle_C._ClassPtr;
		}

		// Token: 0x06025350 RID: 152400 RVA: 0x009B3824 File Offset: 0x009B1A24
		public Bp_CloudCircle_C() : this(BuiltinUtils.AllocNativeUObject(Bp_CloudCircle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025351 RID: 152401 RVA: 0x009B384C File Offset: 0x009B1A4C
		[NullableContext(1)]
		public Bp_CloudCircle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Bp_CloudCircle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005037 RID: 20535
		// (get) Token: 0x06025352 RID: 152402 RVA: 0x009B3880 File Offset: 0x009B1A80
		// (set) Token: 0x06025353 RID: 152403 RVA: 0x009B38B9 File Offset: 0x009B1AB9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005038 RID: 20536
		// (get) Token: 0x06025354 RID: 152404 RVA: 0x009B38DA File Offset: 0x009B1ADA
		// (set) Token: 0x06025355 RID: 152405 RVA: 0x009B38EE File Offset: 0x009B1AEE
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudCircle_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudCircle_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005039 RID: 20537
		// (get) Token: 0x06025356 RID: 152406 RVA: 0x009B3903 File Offset: 0x009B1B03
		// (set) Token: 0x06025357 RID: 152407 RVA: 0x009B3917 File Offset: 0x009B1B17
		[Nullable(2)]
		public unsafe UStaticMesh SM_CloudCard
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudCircle_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudCircle_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700503A RID: 20538
		// (get) Token: 0x06025358 RID: 152408 RVA: 0x009B392C File Offset: 0x009B1B2C
		// (set) Token: 0x06025359 RID: 152409 RVA: 0x009B393C File Offset: 0x009B1B3C
		public unsafe int CloudRow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700503B RID: 20539
		// (get) Token: 0x0602535A RID: 152410 RVA: 0x009B394D File Offset: 0x009B1B4D
		// (set) Token: 0x0602535B RID: 152411 RVA: 0x009B395D File Offset: 0x009B1B5D
		public unsafe int CloudColumn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700503C RID: 20540
		// (get) Token: 0x0602535C RID: 152412 RVA: 0x009B396E File Offset: 0x009B1B6E
		// (set) Token: 0x0602535D RID: 152413 RVA: 0x009B397E File Offset: 0x009B1B7E
		public unsafe int CloudCardCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700503D RID: 20541
		// (get) Token: 0x0602535E RID: 152414 RVA: 0x009B398F File Offset: 0x009B1B8F
		// (set) Token: 0x0602535F RID: 152415 RVA: 0x009B399F File Offset: 0x009B1B9F
		public unsafe float DefaultHorizontalOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700503E RID: 20542
		// (get) Token: 0x06025360 RID: 152416 RVA: 0x009B39B0 File Offset: 0x009B1BB0
		// (set) Token: 0x06025361 RID: 152417 RVA: 0x009B39C4 File Offset: 0x009B1BC4
		public unsafe FVector CloudUVNoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700503F RID: 20543
		// (get) Token: 0x06025362 RID: 152418 RVA: 0x009B39D9 File Offset: 0x009B1BD9
		// (set) Token: 0x06025363 RID: 152419 RVA: 0x009B39ED File Offset: 0x009B1BED
		public unsafe FRotator DefaultRotator
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005040 RID: 20544
		// (get) Token: 0x06025364 RID: 152420 RVA: 0x009B3A04 File Offset: 0x009B1C04
		// (set) Token: 0x06025365 RID: 152421 RVA: 0x009B3A3D File Offset: 0x009B1C3D
		[Nullable(1)]
		public TMap<UStaticMeshComponent, UMaterialInstanceDynamic> CloudCardComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<UStaticMeshComponent, UMaterialInstanceDynamic> result;
				if ((result = this._CloudCardComponents) == null)
				{
					result = (this._CloudCardComponents = new TMap<UStaticMeshComponent, UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CloudCardComponents.CopyAssign(value);
			}
		}

		// Token: 0x17005041 RID: 20545
		// (get) Token: 0x06025366 RID: 152422 RVA: 0x009B3A4B File Offset: 0x009B1C4B
		// (set) Token: 0x06025367 RID: 152423 RVA: 0x009B3A5B File Offset: 0x009B1C5B
		public unsafe float CloudUVNoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005042 RID: 20546
		// (get) Token: 0x06025368 RID: 152424 RVA: 0x009B3A6C File Offset: 0x009B1C6C
		// (set) Token: 0x06025369 RID: 152425 RVA: 0x009B3A7C File Offset: 0x009B1C7C
		public unsafe float CloudUVNoiseTiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005043 RID: 20547
		// (get) Token: 0x0602536A RID: 152426 RVA: 0x009B3A8D File Offset: 0x009B1C8D
		// (set) Token: 0x0602536B RID: 152427 RVA: 0x009B3A9D File Offset: 0x009B1C9D
		public unsafe float DefaultDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005044 RID: 20548
		// (get) Token: 0x0602536C RID: 152428 RVA: 0x009B3AB0 File Offset: 0x009B1CB0
		// (set) Token: 0x0602536D RID: 152429 RVA: 0x009B3AE9 File Offset: 0x009B1CE9
		[Nullable(1)]
		public TArray<FKuroCloudCircleData> CloudDatas
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCloudCircleData> result;
				if ((result = this._CloudDatas) == null)
				{
					result = (this._CloudDatas = new TArray<FKuroCloudCircleData>(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CloudDatas.CopyAssign(value);
			}
		}

		// Token: 0x17005045 RID: 20549
		// (get) Token: 0x0602536E RID: 152430 RVA: 0x009B3AF7 File Offset: 0x009B1CF7
		// (set) Token: 0x0602536F RID: 152431 RVA: 0x009B3B07 File Offset: 0x009B1D07
		public unsafe float CurYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005046 RID: 20550
		// (get) Token: 0x06025370 RID: 152432 RVA: 0x009B3B18 File Offset: 0x009B1D18
		// (set) Token: 0x06025371 RID: 152433 RVA: 0x009B3B28 File Offset: 0x009B1D28
		public unsafe float WindSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005047 RID: 20551
		// (get) Token: 0x06025372 RID: 152434 RVA: 0x009B3B3C File Offset: 0x009B1D3C
		// (set) Token: 0x06025373 RID: 152435 RVA: 0x009B3B75 File Offset: 0x009B1D75
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
					result = (this._FadeTime = new TArray<float>(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FadeTime.CopyAssign(value);
			}
		}

		// Token: 0x17005048 RID: 20552
		// (get) Token: 0x06025374 RID: 152436 RVA: 0x009B3B84 File Offset: 0x009B1D84
		// (set) Token: 0x06025375 RID: 152437 RVA: 0x009B3BBD File Offset: 0x009B1DBD
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
					result = (this._CloudMaterials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CloudMaterials.CopyAssign(value);
			}
		}

		// Token: 0x17005049 RID: 20553
		// (get) Token: 0x06025376 RID: 152438 RVA: 0x009B3BCB File Offset: 0x009B1DCB
		// (set) Token: 0x06025377 RID: 152439 RVA: 0x009B3BDF File Offset: 0x009B1DDF
		[Nullable(2)]
		public unsafe UTexture2D CloudTex
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudCircle_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudCircle_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700504A RID: 20554
		// (get) Token: 0x06025378 RID: 152440 RVA: 0x009B3BF4 File Offset: 0x009B1DF4
		// (set) Token: 0x06025379 RID: 152441 RVA: 0x009B3C04 File Offset: 0x009B1E04
		public unsafe bool ToggleNew
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700504B RID: 20555
		// (get) Token: 0x0602537A RID: 152442 RVA: 0x009B3C15 File Offset: 0x009B1E15
		// (set) Token: 0x0602537B RID: 152443 RVA: 0x009B3C29 File Offset: 0x009B1E29
		public unsafe FLinearColor CloudAmbientColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Bp_CloudCircle_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700504C RID: 20556
		// (get) Token: 0x0602537C RID: 152444 RVA: 0x009B3C3E File Offset: 0x009B1E3E
		// (set) Token: 0x0602537D RID: 152445 RVA: 0x009B3C52 File Offset: 0x009B1E52
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic CloudMatMid
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudCircle_C.__PropertyOffset_21);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Bp_CloudCircle_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x0602537E RID: 152446 RVA: 0x009B3C68 File Offset: 0x009B1E68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardBrightness(int Idx, ref float Brightness)
		{
			Bp_CloudCircle_C.__GetCardBrightness_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardBrightness_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardBrightness_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardBrightness_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->Brightness = Brightness;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardBrightness_NativeFunctionPtr, (void*)ptr);
			Brightness = ptr->Brightness;
		}

		// Token: 0x0602537F RID: 152447 RVA: 0x009B3CC0 File Offset: 0x009B1EC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardDisappearTime(int Idx, ref float FullStayTime)
		{
			Bp_CloudCircle_C.__GetCardDisappearTime_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardDisappearTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardDisappearTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardDisappearTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FullStayTime = FullStayTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardDisappearTime_NativeFunctionPtr, (void*)ptr);
			FullStayTime = ptr->FullStayTime;
		}

		// Token: 0x06025380 RID: 152448 RVA: 0x009B3D18 File Offset: 0x009B1F18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetFadeTickTime(int Idx, ref float FadeTime)
		{
			Bp_CloudCircle_C.__GetFadeTickTime_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetFadeTickTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetFadeTickTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetFadeTickTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FadeTime = FadeTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetFadeTickTime_NativeFunctionPtr, (void*)ptr);
			FadeTime = ptr->FadeTime;
		}

		// Token: 0x06025381 RID: 152449 RVA: 0x009B3D70 File Offset: 0x009B1F70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FadeTimeTick(float DeltaTime)
		{
			Bp_CloudCircle_C.__FadeTimeTick_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__FadeTimeTick_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(Bp_CloudCircle_C.__FadeTimeTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__FadeTimeTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__FadeTimeTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025382 RID: 152450 RVA: 0x009B3DB8 File Offset: 0x009B1FB8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardMaterial(int Idx, ref UMaterialInstanceDynamic MatIns)
		{
			Bp_CloudCircle_C.__GetCardMaterial_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardMaterial_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ref Bp_CloudCircle_C.__GetCardMaterial_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = MatIns;
			ptr2.MatIns = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardMaterial_NativeFunctionPtr, (void*)ptr);
			MatIns = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->MatIns);
		}

		// Token: 0x06025383 RID: 152451 RVA: 0x009B3E24 File Offset: 0x009B2024
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardFullStayTime(int Idx, ref float FullStayTime)
		{
			Bp_CloudCircle_C.__GetCardFullStayTime_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardFullStayTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardFullStayTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardFullStayTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FullStayTime = FullStayTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardFullStayTime_NativeFunctionPtr, (void*)ptr);
			FullStayTime = ptr->FullStayTime;
		}

		// Token: 0x06025384 RID: 152452 RVA: 0x009B3E7C File Offset: 0x009B207C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardFadeInTime(int Idx, ref float FadeInTime)
		{
			Bp_CloudCircle_C.__GetCardFadeInTime_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardFadeInTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardFadeInTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardFadeInTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FadeInTime = FadeInTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardFadeInTime_NativeFunctionPtr, (void*)ptr);
			FadeInTime = ptr->FadeInTime;
		}

		// Token: 0x06025385 RID: 152453 RVA: 0x009B3ED4 File Offset: 0x009B20D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardFadeOutTime(int Idx, ref float FadeOutTime)
		{
			Bp_CloudCircle_C.__GetCardFadeOutTime_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardFadeOutTime_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardFadeOutTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardFadeOutTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->FadeOutTime = FadeOutTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardFadeOutTime_NativeFunctionPtr, (void*)ptr);
			FadeOutTime = ptr->FadeOutTime;
		}

		// Token: 0x06025386 RID: 152454 RVA: 0x009B3F2C File Offset: 0x009B212C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardAlphaMin(int Idx, ref float alphamin)
		{
			Bp_CloudCircle_C.__GetCardAlphaMin_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardAlphaMin_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardAlphaMin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardAlphaMin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->alphamin = alphamin;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardAlphaMin_NativeFunctionPtr, (void*)ptr);
			alphamin = ptr->alphamin;
		}

		// Token: 0x06025387 RID: 152455 RVA: 0x009B3F84 File Offset: 0x009B2184
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardAlphaMax(int Idx, ref float alphamax)
		{
			Bp_CloudCircle_C.__GetCardAlphaMax_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardAlphaMax_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardAlphaMax_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardAlphaMax_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->alphamax = alphamax;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardAlphaMax_NativeFunctionPtr, (void*)ptr);
			alphamax = ptr->alphamax;
		}

		// Token: 0x06025388 RID: 152456 RVA: 0x009B3FDC File Offset: 0x009B21DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardAlphaControl(int Idx, ref float alphacontrol)
		{
			Bp_CloudCircle_C.__GetCardAlphaControl_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardAlphaControl_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardAlphaControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardAlphaControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->alphacontrol = alphacontrol;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardAlphaControl_NativeFunctionPtr, (void*)ptr);
			alphacontrol = ptr->alphacontrol;
		}

		// Token: 0x06025389 RID: 152457 RVA: 0x009B4034 File Offset: 0x009B2234
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardOffset(int Idx, ref FVector Offset)
		{
			Bp_CloudCircle_C.__GetCardOffset_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardOffset_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardOffset_NativeFunctionPtr, (void*)ptr);
			Offset = ptr->Offset;
		}

		// Token: 0x0602538A RID: 152458 RVA: 0x009B4094 File Offset: 0x009B2294
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardScale(int Idx, UStaticMeshComponent SMComponent, ref FVector scale)
		{
			Bp_CloudCircle_C.__GetCardScale_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardScale_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->SMComponent = ((SMComponent != null) ? SMComponent.NativePtr : IntPtr.Zero);
			ptr->scale = scale;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardScale_NativeFunctionPtr, (void*)ptr);
			scale = ptr->scale;
		}

		// Token: 0x0602538B RID: 152459 RVA: 0x009B410C File Offset: 0x009B230C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Card_Horizontal_Offset(int Idx, ref float HorizontalOffset)
		{
			Bp_CloudCircle_C.__Get_Card_Horizontal_Offset_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__Get_Card_Horizontal_Offset_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudCircle_C.__Get_Card_Horizontal_Offset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__Get_Card_Horizontal_Offset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->HorizontalOffset = HorizontalOffset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__Get_Card_Horizontal_Offset_NativeFunctionPtr, (void*)ptr);
			HorizontalOffset = ptr->HorizontalOffset;
		}

		// Token: 0x0602538C RID: 152460 RVA: 0x009B4164 File Offset: 0x009B2364
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardTextureIdx(int Idx, ref int TextureIdx)
		{
			Bp_CloudCircle_C.__GetCardTextureIdx_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardTextureIdx_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardTextureIdx_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardTextureIdx_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->TextureIdx = TextureIdx;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardTextureIdx_NativeFunctionPtr, (void*)ptr);
			TextureIdx = ptr->TextureIdx;
		}

		// Token: 0x0602538D RID: 152461 RVA: 0x009B41BC File Offset: 0x009B23BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardRotator(int Idx, ref FRotator rotator)
		{
			Bp_CloudCircle_C.__GetCardRotator_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardRotator_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardRotator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardRotator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->rotator = rotator;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardRotator_NativeFunctionPtr, (void*)ptr);
			rotator = ptr->rotator;
		}

		// Token: 0x0602538E RID: 152462 RVA: 0x009B421C File Offset: 0x009B241C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCardDis(int Idx, ref float Distance)
		{
			Bp_CloudCircle_C.__GetCardDis_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__GetCardDis_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(Bp_CloudCircle_C.__GetCardDis_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__GetCardDis_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Idx = Idx;
			ptr->Distance = Distance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__GetCardDis_NativeFunctionPtr, (void*)ptr);
			Distance = ptr->Distance;
		}

		// Token: 0x0602538F RID: 152463 RVA: 0x009B4272 File Offset: 0x009B2472
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetupCloudCards()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__SetupCloudCards_NativeFunctionPtr, null);
		}

		// Token: 0x06025390 RID: 152464 RVA: 0x009B4286 File Offset: 0x009B2486
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025391 RID: 152465 RVA: 0x009B429A File Offset: 0x009B249A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Bp_CloudCircle_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025392 RID: 152466 RVA: 0x009B42B0 File Offset: 0x009B24B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			Bp_CloudCircle_C.__ReceiveTick_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Bp_CloudCircle_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025393 RID: 152467 RVA: 0x009B42F8 File Offset: 0x009B24F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			Bp_CloudCircle_C.__ReceiveTick_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Bp_CloudCircle_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Bp_CloudCircle_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025394 RID: 152468 RVA: 0x009B4340 File Offset: 0x009B2540
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			Bp_CloudCircle_C.__EditorTick_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Bp_CloudCircle_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Bp_CloudCircle_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025395 RID: 152469 RVA: 0x009B4388 File Offset: 0x009B2588
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			Bp_CloudCircle_C.__EditorTick_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Bp_CloudCircle_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Bp_CloudCircle_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025396 RID: 152470 RVA: 0x009B43D0 File Offset: 0x009B25D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Bp_CloudCircle(int EntryPoint)
		{
			Bp_CloudCircle_C.__ExecuteUbergraph_Bp_CloudCircle_FunctionParams* ptr = stackalloc Bp_CloudCircle_C.__ExecuteUbergraph_Bp_CloudCircle_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Bp_CloudCircle_C.__ExecuteUbergraph_Bp_CloudCircle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Bp_CloudCircle_C.__ExecuteUbergraph_Bp_CloudCircle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Bp_CloudCircle_C.__ExecuteUbergraph_Bp_CloudCircle_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025397 RID: 152471 RVA: 0x009B4417 File Offset: 0x009B2617
		protected Bp_CloudCircle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013284 RID: 78468
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/CloudCard/Bp_CloudCircle.Bp_CloudCircle_C";

		// Token: 0x04013285 RID: 78469
		private static IntPtr _ClassPtr;

		// Token: 0x04013286 RID: 78470
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013287 RID: 78471
		internal static int __PropertyOffset_0;

		// Token: 0x04013288 RID: 78472
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013289 RID: 78473
		internal static int __PropertyOffset_1;

		// Token: 0x0401328A RID: 78474
		internal static int __PropertyOffset_2;

		// Token: 0x0401328B RID: 78475
		internal static int __PropertyOffset_3;

		// Token: 0x0401328C RID: 78476
		internal static int __PropertyOffset_4;

		// Token: 0x0401328D RID: 78477
		internal static int __PropertyOffset_5;

		// Token: 0x0401328E RID: 78478
		internal static int __PropertyOffset_6;

		// Token: 0x0401328F RID: 78479
		internal static int __PropertyOffset_7;

		// Token: 0x04013290 RID: 78480
		internal static int __PropertyOffset_8;

		// Token: 0x04013291 RID: 78481
		internal static int __PropertyOffset_9;

		// Token: 0x04013292 RID: 78482
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<UStaticMeshComponent, UMaterialInstanceDynamic> _CloudCardComponents;

		// Token: 0x04013293 RID: 78483
		internal static int __PropertyOffset_10;

		// Token: 0x04013294 RID: 78484
		internal static int __PropertyOffset_11;

		// Token: 0x04013295 RID: 78485
		internal static int __PropertyOffset_12;

		// Token: 0x04013296 RID: 78486
		internal static int __PropertyOffset_13;

		// Token: 0x04013297 RID: 78487
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCloudCircleData> _CloudDatas;

		// Token: 0x04013298 RID: 78488
		internal static int __PropertyOffset_14;

		// Token: 0x04013299 RID: 78489
		internal static int __PropertyOffset_15;

		// Token: 0x0401329A RID: 78490
		internal static int __PropertyOffset_16;

		// Token: 0x0401329B RID: 78491
		[Nullable(2)]
		private TArray<float> _FadeTime;

		// Token: 0x0401329C RID: 78492
		internal static int __PropertyOffset_17;

		// Token: 0x0401329D RID: 78493
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _CloudMaterials;

		// Token: 0x0401329E RID: 78494
		internal static int __PropertyOffset_18;

		// Token: 0x0401329F RID: 78495
		internal static int __PropertyOffset_19;

		// Token: 0x040132A0 RID: 78496
		internal static int __PropertyOffset_20;

		// Token: 0x040132A1 RID: 78497
		internal static int __PropertyOffset_21;

		// Token: 0x040132A2 RID: 78498
		private static IntPtr __GetCardBrightness_NativeFunctionPtr;

		// Token: 0x040132A3 RID: 78499
		private static IntPtr __GetCardDisappearTime_NativeFunctionPtr;

		// Token: 0x040132A4 RID: 78500
		private static IntPtr __GetFadeTickTime_NativeFunctionPtr;

		// Token: 0x040132A5 RID: 78501
		private static IntPtr __FadeTimeTick_NativeFunctionPtr;

		// Token: 0x040132A6 RID: 78502
		private static IntPtr __GetCardMaterial_NativeFunctionPtr;

		// Token: 0x040132A7 RID: 78503
		private static IntPtr __GetCardFullStayTime_NativeFunctionPtr;

		// Token: 0x040132A8 RID: 78504
		private static IntPtr __GetCardFadeInTime_NativeFunctionPtr;

		// Token: 0x040132A9 RID: 78505
		private static IntPtr __GetCardFadeOutTime_NativeFunctionPtr;

		// Token: 0x040132AA RID: 78506
		private static IntPtr __GetCardAlphaMin_NativeFunctionPtr;

		// Token: 0x040132AB RID: 78507
		private static IntPtr __GetCardAlphaMax_NativeFunctionPtr;

		// Token: 0x040132AC RID: 78508
		private static IntPtr __GetCardAlphaControl_NativeFunctionPtr;

		// Token: 0x040132AD RID: 78509
		private static IntPtr __GetCardOffset_NativeFunctionPtr;

		// Token: 0x040132AE RID: 78510
		private static IntPtr __GetCardScale_NativeFunctionPtr;

		// Token: 0x040132AF RID: 78511
		private static IntPtr __Get_Card_Horizontal_Offset_NativeFunctionPtr;

		// Token: 0x040132B0 RID: 78512
		private static IntPtr __GetCardTextureIdx_NativeFunctionPtr;

		// Token: 0x040132B1 RID: 78513
		private static IntPtr __GetCardRotator_NativeFunctionPtr;

		// Token: 0x040132B2 RID: 78514
		private static IntPtr __GetCardDis_NativeFunctionPtr;

		// Token: 0x040132B3 RID: 78515
		private static IntPtr __SetupCloudCards_NativeFunctionPtr;

		// Token: 0x040132B4 RID: 78516
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040132B5 RID: 78517
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040132B6 RID: 78518
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040132B7 RID: 78519
		private static IntPtr __ExecuteUbergraph_Bp_CloudCircle_NativeFunctionPtr;

		// Token: 0x02009EC5 RID: 40645
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardBrightness_FunctionParams
		{
			// Token: 0x04032994 RID: 207252
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x04032995 RID: 207253
			[FieldOffset(4)]
			public float Brightness;
		}

		// Token: 0x02009EC6 RID: 40646
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardDisappearTime_FunctionParams
		{
			// Token: 0x04032996 RID: 207254
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x04032997 RID: 207255
			[FieldOffset(4)]
			public float FullStayTime;
		}

		// Token: 0x02009EC7 RID: 40647
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetFadeTickTime_FunctionParams
		{
			// Token: 0x04032998 RID: 207256
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x04032999 RID: 207257
			[FieldOffset(4)]
			public float FadeTime;
		}

		// Token: 0x02009EC8 RID: 40648
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __FadeTimeTick_FunctionParams
		{
			// Token: 0x0403299A RID: 207258
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009EC9 RID: 40649
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetCardMaterial_FunctionParams
		{
			// Token: 0x0403299B RID: 207259
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x0403299C RID: 207260
			[FieldOffset(8)]
			public IntPtr MatIns;
		}

		// Token: 0x02009ECA RID: 40650
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardFullStayTime_FunctionParams
		{
			// Token: 0x0403299D RID: 207261
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x0403299E RID: 207262
			[FieldOffset(4)]
			public float FullStayTime;
		}

		// Token: 0x02009ECB RID: 40651
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardFadeInTime_FunctionParams
		{
			// Token: 0x0403299F RID: 207263
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329A0 RID: 207264
			[FieldOffset(4)]
			public float FadeInTime;
		}

		// Token: 0x02009ECC RID: 40652
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetCardFadeOutTime_FunctionParams
		{
			// Token: 0x040329A1 RID: 207265
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329A2 RID: 207266
			[FieldOffset(4)]
			public float FadeOutTime;
		}

		// Token: 0x02009ECD RID: 40653
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCardAlphaMin_FunctionParams
		{
			// Token: 0x040329A3 RID: 207267
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329A4 RID: 207268
			[FieldOffset(4)]
			public float alphamin;
		}

		// Token: 0x02009ECE RID: 40654
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCardAlphaMax_FunctionParams
		{
			// Token: 0x040329A5 RID: 207269
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329A6 RID: 207270
			[FieldOffset(4)]
			public float alphamax;
		}

		// Token: 0x02009ECF RID: 40655
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCardAlphaControl_FunctionParams
		{
			// Token: 0x040329A7 RID: 207271
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329A8 RID: 207272
			[FieldOffset(4)]
			public float alphacontrol;
		}

		// Token: 0x02009ED0 RID: 40656
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetCardOffset_FunctionParams
		{
			// Token: 0x040329A9 RID: 207273
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329AA RID: 207274
			[FieldOffset(4)]
			public FVector Offset;
		}

		// Token: 0x02009ED1 RID: 40657
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __GetCardScale_FunctionParams
		{
			// Token: 0x040329AB RID: 207275
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329AC RID: 207276
			[FieldOffset(8)]
			public IntPtr SMComponent;

			// Token: 0x040329AD RID: 207277
			[FieldOffset(16)]
			public FVector scale;
		}

		// Token: 0x02009ED2 RID: 40658
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Get_Card_Horizontal_Offset_FunctionParams
		{
			// Token: 0x040329AE RID: 207278
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329AF RID: 207279
			[FieldOffset(4)]
			public float HorizontalOffset;
		}

		// Token: 0x02009ED3 RID: 40659
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __GetCardTextureIdx_FunctionParams
		{
			// Token: 0x040329B0 RID: 207280
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329B1 RID: 207281
			[FieldOffset(4)]
			public int TextureIdx;
		}

		// Token: 0x02009ED4 RID: 40660
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __GetCardRotator_FunctionParams
		{
			// Token: 0x040329B2 RID: 207282
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329B3 RID: 207283
			[FieldOffset(4)]
			public FRotator rotator;
		}

		// Token: 0x02009ED5 RID: 40661
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __GetCardDis_FunctionParams
		{
			// Token: 0x040329B4 RID: 207284
			[FieldOffset(0)]
			public int Idx;

			// Token: 0x040329B5 RID: 207285
			[FieldOffset(4)]
			public float Distance;
		}

		// Token: 0x02009ED6 RID: 40662
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040329B6 RID: 207286
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009ED7 RID: 40663
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040329B7 RID: 207287
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009ED8 RID: 40664
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_Bp_CloudCircle_FunctionParams
		{
			// Token: 0x040329B8 RID: 207288
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
