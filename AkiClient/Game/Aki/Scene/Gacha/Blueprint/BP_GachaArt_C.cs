using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.Gacha.Blueprint
{
	// Token: 0x020039E8 RID: 14824
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Scene/Gacha/Blueprint/BP_GachaArt.BP_GachaArt_C")]
	[UnrealStructLayout(1224, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1220)]
	public class BP_GachaArt_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E0A0 RID: 123040 RVA: 0x008EA318 File Offset: 0x008E8518
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GachaArt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Scene/Gacha/Blueprint/BP_GachaArt.BP_GachaArt_C");
			}
			return BP_GachaArt_C._ClassPtr;
		}

		// Token: 0x0601E0A1 RID: 123041 RVA: 0x008EA33C File Offset: 0x008E853C
		public BP_GachaArt_C() : this(BuiltinUtils.AllocNativeUObject(BP_GachaArt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E0A2 RID: 123042 RVA: 0x008EA364 File Offset: 0x008E8564
		[NullableContext(1)]
		public BP_GachaArt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GachaArt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700281B RID: 10267
		// (get) Token: 0x0601E0A3 RID: 123043 RVA: 0x008EA398 File Offset: 0x008E8598
		// (set) Token: 0x0601E0A4 RID: 123044 RVA: 0x008EA3D1 File Offset: 0x008E85D1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700281C RID: 10268
		// (get) Token: 0x0601E0A5 RID: 123045 RVA: 0x008EA3F2 File Offset: 0x008E85F2
		// (set) Token: 0x0601E0A6 RID: 123046 RVA: 0x008EA406 File Offset: 0x008E8606
		public unsafe UNiagaraComponent NS_Fx_UI_Chouka_04
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700281D RID: 10269
		// (get) Token: 0x0601E0A7 RID: 123047 RVA: 0x008EA41B File Offset: 0x008E861B
		// (set) Token: 0x0601E0A8 RID: 123048 RVA: 0x008EA42F File Offset: 0x008E862F
		public unsafe UNiagaraComponent NS_Fx_UI_Chouka_03
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700281E RID: 10270
		// (get) Token: 0x0601E0A9 RID: 123049 RVA: 0x008EA444 File Offset: 0x008E8644
		// (set) Token: 0x0601E0AA RID: 123050 RVA: 0x008EA458 File Offset: 0x008E8658
		public unsafe UNiagaraComponent NS_Fx_UI_Chouka_01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700281F RID: 10271
		// (get) Token: 0x0601E0AB RID: 123051 RVA: 0x008EA46D File Offset: 0x008E866D
		// (set) Token: 0x0601E0AC RID: 123052 RVA: 0x008EA481 File Offset: 0x008E8681
		public unsafe UNiagaraComponent NS_Fx_UI_Chouka_02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002820 RID: 10272
		// (get) Token: 0x0601E0AD RID: 123053 RVA: 0x008EA496 File Offset: 0x008E8696
		// (set) Token: 0x0601E0AE RID: 123054 RVA: 0x008EA4AA File Offset: 0x008E86AA
		public unsafe UStaticMeshComponent BGPlane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002821 RID: 10273
		// (get) Token: 0x0601E0AF RID: 123055 RVA: 0x008EA4BF File Offset: 0x008E86BF
		// (set) Token: 0x0601E0B0 RID: 123056 RVA: 0x008EA4D3 File Offset: 0x008E86D3
		public unsafe UStaticMeshComponent CenterDisk
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002822 RID: 10274
		// (get) Token: 0x0601E0B1 RID: 123057 RVA: 0x008EA4E8 File Offset: 0x008E86E8
		// (set) Token: 0x0601E0B2 RID: 123058 RVA: 0x008EA4FC File Offset: 0x008E86FC
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002823 RID: 10275
		// (get) Token: 0x0601E0B3 RID: 123059 RVA: 0x008EA511 File Offset: 0x008E8711
		// (set) Token: 0x0601E0B4 RID: 123060 RVA: 0x008EA525 File Offset: 0x008E8725
		public unsafe UMaterialInstanceDynamic CenterMaterialDynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002824 RID: 10276
		// (get) Token: 0x0601E0B5 RID: 123061 RVA: 0x008EA53A File Offset: 0x008E873A
		// (set) Token: 0x0601E0B6 RID: 123062 RVA: 0x008EA54A File Offset: 0x008E874A
		public unsafe float DefaultProcessInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002825 RID: 10277
		// (get) Token: 0x0601E0B7 RID: 123063 RVA: 0x008EA55B File Offset: 0x008E875B
		// (set) Token: 0x0601E0B8 RID: 123064 RVA: 0x008EA56F File Offset: 0x008E876F
		public unsafe FVector2D Mouse_Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002826 RID: 10278
		// (get) Token: 0x0601E0B9 RID: 123065 RVA: 0x008EA584 File Offset: 0x008E8784
		// (set) Token: 0x0601E0BA RID: 123066 RVA: 0x008EA594 File Offset: 0x008E8794
		public unsafe float DefaultProcessFinal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002827 RID: 10279
		// (get) Token: 0x0601E0BB RID: 123067 RVA: 0x008EA5A5 File Offset: 0x008E87A5
		// (set) Token: 0x0601E0BC RID: 123068 RVA: 0x008EA5B9 File Offset: 0x008E87B9
		public unsafe FVector2D Screen_Resolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002828 RID: 10280
		// (get) Token: 0x0601E0BD RID: 123069 RVA: 0x008EA5CE File Offset: 0x008E87CE
		// (set) Token: 0x0601E0BE RID: 123070 RVA: 0x008EA5DE File Offset: 0x008E87DE
		public unsafe float Camera_FOV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002829 RID: 10281
		// (get) Token: 0x0601E0BF RID: 123071 RVA: 0x008EA5EF File Offset: 0x008E87EF
		// (set) Token: 0x0601E0C0 RID: 123072 RVA: 0x008EA5FF File Offset: 0x008E87FF
		public unsafe float ColorChangeProcessInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700282A RID: 10282
		// (get) Token: 0x0601E0C1 RID: 123073 RVA: 0x008EA610 File Offset: 0x008E8810
		// (set) Token: 0x0601E0C2 RID: 123074 RVA: 0x008EA620 File Offset: 0x008E8820
		public unsafe float Camera_Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700282B RID: 10283
		// (get) Token: 0x0601E0C3 RID: 123075 RVA: 0x008EA631 File Offset: 0x008E8831
		// (set) Token: 0x0601E0C4 RID: 123076 RVA: 0x008EA645 File Offset: 0x008E8845
		public unsafe ACameraActor SceneCameraActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ACameraActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaArt_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700282C RID: 10284
		// (get) Token: 0x0601E0C5 RID: 123077 RVA: 0x008EA65A File Offset: 0x008E885A
		// (set) Token: 0x0601E0C6 RID: 123078 RVA: 0x008EA66E File Offset: 0x008E886E
		public unsafe FRotator CameraRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700282D RID: 10285
		// (get) Token: 0x0601E0C7 RID: 123079 RVA: 0x008EA683 File Offset: 0x008E8883
		// (set) Token: 0x0601E0C8 RID: 123080 RVA: 0x008EA693 File Offset: 0x008E8893
		public unsafe float SidesAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700282E RID: 10286
		// (get) Token: 0x0601E0C9 RID: 123081 RVA: 0x008EA6A4 File Offset: 0x008E88A4
		// (set) Token: 0x0601E0CA RID: 123082 RVA: 0x008EA6B4 File Offset: 0x008E88B4
		public unsafe float BleedingDist_PixelNum_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700282F RID: 10287
		// (get) Token: 0x0601E0CB RID: 123083 RVA: 0x008EA6C5 File Offset: 0x008E88C5
		// (set) Token: 0x0601E0CC RID: 123084 RVA: 0x008EA6D5 File Offset: 0x008E88D5
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002830 RID: 10288
		// (get) Token: 0x0601E0CD RID: 123085 RVA: 0x008EA6E6 File Offset: 0x008E88E6
		// (set) Token: 0x0601E0CE RID: 123086 RVA: 0x008EA6F6 File Offset: 0x008E88F6
		public unsafe float MousePositionX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002831 RID: 10289
		// (get) Token: 0x0601E0CF RID: 123087 RVA: 0x008EA707 File Offset: 0x008E8907
		// (set) Token: 0x0601E0D0 RID: 123088 RVA: 0x008EA717 File Offset: 0x008E8917
		public unsafe float MousePositionXFinal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002832 RID: 10290
		// (get) Token: 0x0601E0D1 RID: 123089 RVA: 0x008EA728 File Offset: 0x008E8928
		// (set) Token: 0x0601E0D2 RID: 123090 RVA: 0x008EA738 File Offset: 0x008E8938
		public unsafe float Process
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002833 RID: 10291
		// (get) Token: 0x0601E0D3 RID: 123091 RVA: 0x008EA749 File Offset: 0x008E8949
		// (set) Token: 0x0601E0D4 RID: 123092 RVA: 0x008EA759 File Offset: 0x008E8959
		public unsafe float CCProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002834 RID: 10292
		// (get) Token: 0x0601E0D5 RID: 123093 RVA: 0x008EA76A File Offset: 0x008E896A
		// (set) Token: 0x0601E0D6 RID: 123094 RVA: 0x008EA77A File Offset: 0x008E897A
		public unsafe bool Hidden
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002835 RID: 10293
		// (get) Token: 0x0601E0D7 RID: 123095 RVA: 0x008EA78B File Offset: 0x008E898B
		// (set) Token: 0x0601E0D8 RID: 123096 RVA: 0x008EA79F File Offset: 0x008E899F
		public unsafe FLinearColor Award_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002836 RID: 10294
		// (get) Token: 0x0601E0D9 RID: 123097 RVA: 0x008EA7B4 File Offset: 0x008E89B4
		// (set) Token: 0x0601E0DA RID: 123098 RVA: 0x008EA7C8 File Offset: 0x008E89C8
		[Nullable(0)]
		public unsafe TEnumAsByte<E_GachaResult> Gacha_Result
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_27);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002837 RID: 10295
		// (get) Token: 0x0601E0DB RID: 123099 RVA: 0x008EA7DD File Offset: 0x008E89DD
		// (set) Token: 0x0601E0DC RID: 123100 RVA: 0x008EA7ED File Offset: 0x008E89ED
		public unsafe float ProcessTemp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaArt_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x0601E0DD RID: 123101 RVA: 0x008EA7FE File Offset: 0x008E89FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateAudio()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__UpdateAudio_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0DE RID: 123102 RVA: 0x008EA814 File Offset: 0x008E8A14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TSInitParameters(FVector2D ScreenResolution, float BleedingDistance, FLinearColor AwardColor, E_GachaResult GachaResult)
		{
			BP_GachaArt_C.__TSInitParameters_FunctionParams* ptr = stackalloc BP_GachaArt_C.__TSInitParameters_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GachaArt_C.__TSInitParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaArt_C.__TSInitParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ScreenResolution = ScreenResolution;
			ptr->BleedingDistance = BleedingDistance;
			ptr->AwardColor = AwardColor;
			ptr->GachaResult = GachaResult;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__TSInitParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E0DF RID: 123103 RVA: 0x008EA875 File Offset: 0x008E8A75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PreUpdate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__PreUpdate_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0E0 RID: 123104 RVA: 0x008EA889 File Offset: 0x008E8A89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDebugParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__UpdateDebugParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0E1 RID: 123105 RVA: 0x008EA8A0 File Offset: 0x008E8AA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TSUpdateParameters(float DefaultProcess, float ColorChangeProcess, FVector2D MousePosition)
		{
			BP_GachaArt_C.__TSUpdateParameters_FunctionParams* ptr = stackalloc BP_GachaArt_C.__TSUpdateParameters_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_GachaArt_C.__TSUpdateParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaArt_C.__TSUpdateParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DefaultProcess = DefaultProcess;
			ptr->ColorChangeProcess = ColorChangeProcess;
			ptr->MousePosition = MousePosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__TSUpdateParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E0E2 RID: 123106 RVA: 0x008EA8F4 File Offset: 0x008E8AF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCamera()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__UpdateCamera_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0E3 RID: 123107 RVA: 0x008EA908 File Offset: 0x008E8B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0E4 RID: 123108 RVA: 0x008EA91C File Offset: 0x008E8B1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParticlePosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__UpdateParticlePosition_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0E5 RID: 123109 RVA: 0x008EA930 File Offset: 0x008E8B30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParticleParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__UpdateParticleParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0E6 RID: 123110 RVA: 0x008EA944 File Offset: 0x008E8B44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0E7 RID: 123111 RVA: 0x008EA958 File Offset: 0x008E8B58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaArt_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E0E8 RID: 123112 RVA: 0x008EA96D File Offset: 0x008E8B6D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0E9 RID: 123113 RVA: 0x008EA981 File Offset: 0x008E8B81
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaArt_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E0EA RID: 123114 RVA: 0x008EA998 File Offset: 0x008E8B98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GachaArt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GachaArt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GachaArt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaArt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaArt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E0EB RID: 123115 RVA: 0x008EA9E0 File Offset: 0x008E8BE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GachaArt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GachaArt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GachaArt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaArt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaArt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E0EC RID: 123116 RVA: 0x008EAA28 File Offset: 0x008E8C28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GachaArt(int EntryPoint)
		{
			BP_GachaArt_C.__ExecuteUbergraph_BP_GachaArt_FunctionParams* ptr = stackalloc BP_GachaArt_C.__ExecuteUbergraph_BP_GachaArt_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GachaArt_C.__ExecuteUbergraph_BP_GachaArt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaArt_C.__ExecuteUbergraph_BP_GachaArt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaArt_C.__ExecuteUbergraph_BP_GachaArt_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E0ED RID: 123117 RVA: 0x008EAA6F File Offset: 0x008E8C6F
		protected BP_GachaArt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EBA9 RID: 60329
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Scene/Gacha/Blueprint/BP_GachaArt.BP_GachaArt_C";

		// Token: 0x0400EBAA RID: 60330
		private static IntPtr _ClassPtr;

		// Token: 0x0400EBAB RID: 60331
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EBAC RID: 60332
		internal static int __PropertyOffset_0;

		// Token: 0x0400EBAD RID: 60333
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EBAE RID: 60334
		internal static int __PropertyOffset_1;

		// Token: 0x0400EBAF RID: 60335
		internal static int __PropertyOffset_2;

		// Token: 0x0400EBB0 RID: 60336
		internal static int __PropertyOffset_3;

		// Token: 0x0400EBB1 RID: 60337
		internal static int __PropertyOffset_4;

		// Token: 0x0400EBB2 RID: 60338
		internal static int __PropertyOffset_5;

		// Token: 0x0400EBB3 RID: 60339
		internal static int __PropertyOffset_6;

		// Token: 0x0400EBB4 RID: 60340
		internal static int __PropertyOffset_7;

		// Token: 0x0400EBB5 RID: 60341
		internal static int __PropertyOffset_8;

		// Token: 0x0400EBB6 RID: 60342
		internal static int __PropertyOffset_9;

		// Token: 0x0400EBB7 RID: 60343
		internal static int __PropertyOffset_10;

		// Token: 0x0400EBB8 RID: 60344
		internal static int __PropertyOffset_11;

		// Token: 0x0400EBB9 RID: 60345
		internal static int __PropertyOffset_12;

		// Token: 0x0400EBBA RID: 60346
		internal static int __PropertyOffset_13;

		// Token: 0x0400EBBB RID: 60347
		internal static int __PropertyOffset_14;

		// Token: 0x0400EBBC RID: 60348
		internal static int __PropertyOffset_15;

		// Token: 0x0400EBBD RID: 60349
		internal static int __PropertyOffset_16;

		// Token: 0x0400EBBE RID: 60350
		internal static int __PropertyOffset_17;

		// Token: 0x0400EBBF RID: 60351
		internal static int __PropertyOffset_18;

		// Token: 0x0400EBC0 RID: 60352
		internal static int __PropertyOffset_19;

		// Token: 0x0400EBC1 RID: 60353
		internal static int __PropertyOffset_20;

		// Token: 0x0400EBC2 RID: 60354
		internal static int __PropertyOffset_21;

		// Token: 0x0400EBC3 RID: 60355
		internal static int __PropertyOffset_22;

		// Token: 0x0400EBC4 RID: 60356
		internal static int __PropertyOffset_23;

		// Token: 0x0400EBC5 RID: 60357
		internal static int __PropertyOffset_24;

		// Token: 0x0400EBC6 RID: 60358
		internal static int __PropertyOffset_25;

		// Token: 0x0400EBC7 RID: 60359
		internal static int __PropertyOffset_26;

		// Token: 0x0400EBC8 RID: 60360
		internal static int __PropertyOffset_27;

		// Token: 0x0400EBC9 RID: 60361
		internal static int __PropertyOffset_28;

		// Token: 0x0400EBCA RID: 60362
		private static IntPtr __UpdateAudio_NativeFunctionPtr;

		// Token: 0x0400EBCB RID: 60363
		private static IntPtr __TSInitParameters_NativeFunctionPtr;

		// Token: 0x0400EBCC RID: 60364
		private static IntPtr __PreUpdate_NativeFunctionPtr;

		// Token: 0x0400EBCD RID: 60365
		private static IntPtr __UpdateDebugParameters_NativeFunctionPtr;

		// Token: 0x0400EBCE RID: 60366
		private static IntPtr __TSUpdateParameters_NativeFunctionPtr;

		// Token: 0x0400EBCF RID: 60367
		private static IntPtr __UpdateCamera_NativeFunctionPtr;

		// Token: 0x0400EBD0 RID: 60368
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x0400EBD1 RID: 60369
		private static IntPtr __UpdateParticlePosition_NativeFunctionPtr;

		// Token: 0x0400EBD2 RID: 60370
		private static IntPtr __UpdateParticleParameters_NativeFunctionPtr;

		// Token: 0x0400EBD3 RID: 60371
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EBD4 RID: 60372
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EBD5 RID: 60373
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EBD6 RID: 60374
		private static IntPtr __ExecuteUbergraph_BP_GachaArt_NativeFunctionPtr;

		// Token: 0x0200974A RID: 38730
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __TSInitParameters_FunctionParams
		{
			// Token: 0x04031CBF RID: 203967
			[FieldOffset(0)]
			public FVector2D ScreenResolution;

			// Token: 0x04031CC0 RID: 203968
			[FieldOffset(8)]
			public float BleedingDistance;

			// Token: 0x04031CC1 RID: 203969
			[FieldOffset(12)]
			public FLinearColor AwardColor;

			// Token: 0x04031CC2 RID: 203970
			[FieldOffset(28)]
			public TEnumAsByte<E_GachaResult> GachaResult;
		}

		// Token: 0x0200974B RID: 38731
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __TSUpdateParameters_FunctionParams
		{
			// Token: 0x04031CC3 RID: 203971
			[FieldOffset(0)]
			public float DefaultProcess;

			// Token: 0x04031CC4 RID: 203972
			[FieldOffset(4)]
			public float ColorChangeProcess;

			// Token: 0x04031CC5 RID: 203973
			[FieldOffset(8)]
			public FVector2D MousePosition;
		}

		// Token: 0x0200974C RID: 38732
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031CC6 RID: 203974
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200974D RID: 38733
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_GachaArt_FunctionParams
		{
			// Token: 0x04031CC7 RID: 203975
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
