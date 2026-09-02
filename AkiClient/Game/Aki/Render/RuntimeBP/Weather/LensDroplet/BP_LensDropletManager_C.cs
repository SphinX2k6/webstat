using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.LensDroplet
{
	// Token: 0x020039FC RID: 14844
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/LensDroplet/BP_LensDropletManager.BP_LensDropletManager_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1510)]
	public class BP_LensDropletManager_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E342 RID: 123714 RVA: 0x008EF720 File Offset: 0x008ED920
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LensDropletManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/LensDroplet/BP_LensDropletManager.BP_LensDropletManager_C");
			}
			return BP_LensDropletManager_C._ClassPtr;
		}

		// Token: 0x0601E343 RID: 123715 RVA: 0x008EF744 File Offset: 0x008ED944
		public BP_LensDropletManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_LensDropletManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E344 RID: 123716 RVA: 0x008EF76C File Offset: 0x008ED96C
		[NullableContext(1)]
		public BP_LensDropletManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LensDropletManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170028F5 RID: 10485
		// (get) Token: 0x0601E345 RID: 123717 RVA: 0x008EF7A0 File Offset: 0x008ED9A0
		// (set) Token: 0x0601E346 RID: 123718 RVA: 0x008EF7D9 File Offset: 0x008ED9D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028F6 RID: 10486
		// (get) Token: 0x0601E347 RID: 123719 RVA: 0x008EF7FA File Offset: 0x008ED9FA
		// (set) Token: 0x0601E348 RID: 123720 RVA: 0x008EF80E File Offset: 0x008EDA0E
		[Nullable(2)]
		public unsafe UProceduralMeshComponent Droplets
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UProceduralMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDropletManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDropletManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170028F7 RID: 10487
		// (get) Token: 0x0601E349 RID: 123721 RVA: 0x008EF823 File Offset: 0x008EDA23
		// (set) Token: 0x0601E34A RID: 123722 RVA: 0x008EF837 File Offset: 0x008EDA37
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDropletManager_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDropletManager_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170028F8 RID: 10488
		// (get) Token: 0x0601E34B RID: 123723 RVA: 0x008EF84C File Offset: 0x008EDA4C
		// (set) Token: 0x0601E34C RID: 123724 RVA: 0x008EF85C File Offset: 0x008EDA5C
		public unsafe float DropletGenerate_NewTrack_0_43A8026C4C5253C2ECCC34BC1AFDE7FF
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170028F9 RID: 10489
		// (get) Token: 0x0601E34D RID: 123725 RVA: 0x008EF86D File Offset: 0x008EDA6D
		// (set) Token: 0x0601E34E RID: 123726 RVA: 0x008EF881 File Offset: 0x008EDA81
		public unsafe TEnumAsByte<ETimelineDirection> DropletGenerate__Direction_43A8026C4C5253C2ECCC34BC1AFDE7FF
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170028FA RID: 10490
		// (get) Token: 0x0601E34F RID: 123727 RVA: 0x008EF896 File Offset: 0x008EDA96
		// (set) Token: 0x0601E350 RID: 123728 RVA: 0x008EF8AA File Offset: 0x008EDAAA
		[Nullable(2)]
		public unsafe UTimelineComponent DropletGenerate
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDropletManager_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDropletManager_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170028FB RID: 10491
		// (get) Token: 0x0601E351 RID: 123729 RVA: 0x008EF8BF File Offset: 0x008EDABF
		// (set) Token: 0x0601E352 RID: 123730 RVA: 0x008EF8CF File Offset: 0x008EDACF
		public unsafe float Rain_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170028FC RID: 10492
		// (get) Token: 0x0601E353 RID: 123731 RVA: 0x008EF8E0 File Offset: 0x008EDAE0
		// (set) Token: 0x0601E354 RID: 123732 RVA: 0x008EF8F0 File Offset: 0x008EDAF0
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170028FD RID: 10493
		// (get) Token: 0x0601E355 RID: 123733 RVA: 0x008EF901 File Offset: 0x008EDB01
		// (set) Token: 0x0601E356 RID: 123734 RVA: 0x008EF911 File Offset: 0x008EDB11
		public unsafe float DropletIntensityMul
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170028FE RID: 10494
		// (get) Token: 0x0601E357 RID: 123735 RVA: 0x008EF922 File Offset: 0x008EDB22
		// (set) Token: 0x0601E358 RID: 123736 RVA: 0x008EF932 File Offset: 0x008EDB32
		public unsafe float time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170028FF RID: 10495
		// (get) Token: 0x0601E359 RID: 123737 RVA: 0x008EF943 File Offset: 0x008EDB43
		// (set) Token: 0x0601E35A RID: 123738 RVA: 0x008EF953 File Offset: 0x008EDB53
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002900 RID: 10496
		// (get) Token: 0x0601E35B RID: 123739 RVA: 0x008EF964 File Offset: 0x008EDB64
		// (set) Token: 0x0601E35C RID: 123740 RVA: 0x008EF978 File Offset: 0x008EDB78
		public unsafe FVector2D ScreenSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002901 RID: 10497
		// (get) Token: 0x0601E35D RID: 123741 RVA: 0x008EF98D File Offset: 0x008EDB8D
		// (set) Token: 0x0601E35E RID: 123742 RVA: 0x008EF99D File Offset: 0x008EDB9D
		public unsafe float RainDropOpacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002902 RID: 10498
		// (get) Token: 0x0601E35F RID: 123743 RVA: 0x008EF9AE File Offset: 0x008EDBAE
		// (set) Token: 0x0601E360 RID: 123744 RVA: 0x008EF9BE File Offset: 0x008EDBBE
		public unsafe bool InOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002903 RID: 10499
		// (get) Token: 0x0601E361 RID: 123745 RVA: 0x008EF9CF File Offset: 0x008EDBCF
		// (set) Token: 0x0601E362 RID: 123746 RVA: 0x008EF9E3 File Offset: 0x008EDBE3
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic DropletDMI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDropletManager_C.__PropertyOffset_14);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDropletManager_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17002904 RID: 10500
		// (get) Token: 0x0601E363 RID: 123747 RVA: 0x008EF9F8 File Offset: 0x008EDBF8
		// (set) Token: 0x0601E364 RID: 123748 RVA: 0x008EFA08 File Offset: 0x008EDC08
		public unsafe float TimeForInOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002905 RID: 10501
		// (get) Token: 0x0601E365 RID: 123749 RVA: 0x008EFA19 File Offset: 0x008EDC19
		// (set) Token: 0x0601E366 RID: 123750 RVA: 0x008EFA29 File Offset: 0x008EDC29
		public unsafe bool InOutActive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002906 RID: 10502
		// (get) Token: 0x0601E367 RID: 123751 RVA: 0x008EFA3A File Offset: 0x008EDC3A
		// (set) Token: 0x0601E368 RID: 123752 RVA: 0x008EFA4A File Offset: 0x008EDC4A
		public unsafe float time_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002907 RID: 10503
		// (get) Token: 0x0601E369 RID: 123753 RVA: 0x008EFA5B File Offset: 0x008EDC5B
		// (set) Token: 0x0601E36A RID: 123754 RVA: 0x008EFA6B File Offset: 0x008EDC6B
		public unsafe bool IsEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002908 RID: 10504
		// (get) Token: 0x0601E36B RID: 123755 RVA: 0x008EFA7C File Offset: 0x008EDC7C
		// (set) Token: 0x0601E36C RID: 123756 RVA: 0x008EFA90 File Offset: 0x008EDC90
		public unsafe FVectorDouble PrezCamPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002909 RID: 10505
		// (get) Token: 0x0601E36D RID: 123757 RVA: 0x008EFAA5 File Offset: 0x008EDCA5
		// (set) Token: 0x0601E36E RID: 123758 RVA: 0x008EFAB9 File Offset: 0x008EDCB9
		public unsafe FVector PrezCamVec
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700290A RID: 10506
		// (get) Token: 0x0601E36F RID: 123759 RVA: 0x008EFACE File Offset: 0x008EDCCE
		// (set) Token: 0x0601E370 RID: 123760 RVA: 0x008EFAE2 File Offset: 0x008EDCE2
		public unsafe FVectorDouble CurrCamPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700290B RID: 10507
		// (get) Token: 0x0601E371 RID: 123761 RVA: 0x008EFAF7 File Offset: 0x008EDCF7
		// (set) Token: 0x0601E372 RID: 123762 RVA: 0x008EFB0B File Offset: 0x008EDD0B
		public unsafe FVector CurrCamVec
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700290C RID: 10508
		// (get) Token: 0x0601E373 RID: 123763 RVA: 0x008EFB20 File Offset: 0x008EDD20
		// (set) Token: 0x0601E374 RID: 123764 RVA: 0x008EFB30 File Offset: 0x008EDD30
		public unsafe float SpawnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700290D RID: 10509
		// (get) Token: 0x0601E375 RID: 123765 RVA: 0x008EFB41 File Offset: 0x008EDD41
		// (set) Token: 0x0601E376 RID: 123766 RVA: 0x008EFB55 File Offset: 0x008EDD55
		public unsafe TEnumAsByte<EKuroRainType> RainType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700290E RID: 10510
		// (get) Token: 0x0601E377 RID: 123767 RVA: 0x008EFB6A File Offset: 0x008EDD6A
		// (set) Token: 0x0601E378 RID: 123768 RVA: 0x008EFB7A File Offset: 0x008EDD7A
		public unsafe float MaxNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700290F RID: 10511
		// (get) Token: 0x0601E379 RID: 123769 RVA: 0x008EFB8B File Offset: 0x008EDD8B
		// (set) Token: 0x0601E37A RID: 123770 RVA: 0x008EFB9B File Offset: 0x008EDD9B
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002910 RID: 10512
		// (get) Token: 0x0601E37B RID: 123771 RVA: 0x008EFBAC File Offset: 0x008EDDAC
		// (set) Token: 0x0601E37C RID: 123772 RVA: 0x008EFBBC File Offset: 0x008EDDBC
		public unsafe bool Is_in_Cave
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002911 RID: 10513
		// (get) Token: 0x0601E37D RID: 123773 RVA: 0x008EFBCD File Offset: 0x008EDDCD
		// (set) Token: 0x0601E37E RID: 123774 RVA: 0x008EFBDD File Offset: 0x008EDDDD
		public unsafe bool DoEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDropletManager_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E37F RID: 123775 RVA: 0x008EFBEE File Offset: 0x008EDDEE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GenerateOneDroplets()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__GenerateOneDroplets_NativeFunctionPtr, null);
		}

		// Token: 0x0601E380 RID: 123776 RVA: 0x008EFC04 File Offset: 0x008EDE04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(float Time, bool InOut)
		{
			BP_LensDropletManager_C.__Timer_FunctionParams* ptr = stackalloc BP_LensDropletManager_C.__Timer_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_LensDropletManager_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDropletManager_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			ptr->InOut = InOut;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__Timer_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E381 RID: 123777 RVA: 0x008EFC51 File Offset: 0x008EDE51
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__UpdateParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0601E382 RID: 123778 RVA: 0x008EFC65 File Offset: 0x008EDE65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x0601E383 RID: 123779 RVA: 0x008EFC7C File Offset: 0x008EDE7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ConstructPolyMesh(int DropletAmount)
		{
			BP_LensDropletManager_C.__ConstructPolyMesh_FunctionParams* ptr = stackalloc BP_LensDropletManager_C.__ConstructPolyMesh_FunctionParams[(UIntPtr)1503] + 15L / (long)sizeof(BP_LensDropletManager_C.__ConstructPolyMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDropletManager_C.__ConstructPolyMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DropletAmount = DropletAmount;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__ConstructPolyMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E384 RID: 123780 RVA: 0x008EFCC8 File Offset: 0x008EDEC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetBasicDropletParameters(float RainIntensity, float Gravity, EKuroRainType RainType, bool IsInCave)
		{
			BP_LensDropletManager_C.__SetBasicDropletParameters_FunctionParams* ptr = stackalloc BP_LensDropletManager_C.__SetBasicDropletParameters_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_LensDropletManager_C.__SetBasicDropletParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDropletManager_C.__SetBasicDropletParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RainIntensity = RainIntensity;
			ptr->Gravity = Gravity;
			ptr->RainType = RainType;
			ptr->IsInCave = IsInCave;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__SetBasicDropletParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E385 RID: 123781 RVA: 0x008EFD29 File Offset: 0x008EDF29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E386 RID: 123782 RVA: 0x008EFD3D File Offset: 0x008EDF3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDropletManager_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E387 RID: 123783 RVA: 0x008EFD52 File Offset: 0x008EDF52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DropletGenerate__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__DropletGenerate__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0601E388 RID: 123784 RVA: 0x008EFD66 File Offset: 0x008EDF66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DropletGenerate__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__DropletGenerate__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0601E389 RID: 123785 RVA: 0x008EFD7A File Offset: 0x008EDF7A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__CustomEvent_1_NativeFunctionPtr, null);
		}

		// Token: 0x0601E38A RID: 123786 RVA: 0x008EFD8E File Offset: 0x008EDF8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DropletEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__DropletEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0601E38B RID: 123787 RVA: 0x008EFDA2 File Offset: 0x008EDFA2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DropletStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__DropletStart_NativeFunctionPtr, null);
		}

		// Token: 0x0601E38C RID: 123788 RVA: 0x008EFDB6 File Offset: 0x008EDFB6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableDroplets()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__DisableDroplets_NativeFunctionPtr, null);
		}

		// Token: 0x0601E38D RID: 123789 RVA: 0x008EFDCA File Offset: 0x008EDFCA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CleanMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__CleanMesh_NativeFunctionPtr, null);
		}

		// Token: 0x0601E38E RID: 123790 RVA: 0x008EFDE0 File Offset: 0x008EDFE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_LensDropletManager_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LensDropletManager_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LensDropletManager_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDropletManager_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E38F RID: 123791 RVA: 0x008EFE28 File Offset: 0x008EE028
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_LensDropletManager_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LensDropletManager_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LensDropletManager_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDropletManager_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDropletManager_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E390 RID: 123792 RVA: 0x008EFE6F File Offset: 0x008EE06F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableDroplets()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__EnableDroplets_NativeFunctionPtr, null);
		}

		// Token: 0x0601E391 RID: 123793 RVA: 0x008EFE84 File Offset: 0x008EE084
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LensDropletManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LensDropletManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LensDropletManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDropletManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E392 RID: 123794 RVA: 0x008EFECC File Offset: 0x008EE0CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LensDropletManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LensDropletManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LensDropletManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDropletManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDropletManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E393 RID: 123795 RVA: 0x008EFF13 File Offset: 0x008EE113
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDropletManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E394 RID: 123796 RVA: 0x008EFF27 File Offset: 0x008EE127
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDropletManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E395 RID: 123797 RVA: 0x008EFF3C File Offset: 0x008EE13C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LensDropletManager(int EntryPoint)
		{
			BP_LensDropletManager_C.__ExecuteUbergraph_BP_LensDropletManager_FunctionParams* ptr = stackalloc BP_LensDropletManager_C.__ExecuteUbergraph_BP_LensDropletManager_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_LensDropletManager_C.__ExecuteUbergraph_BP_LensDropletManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDropletManager_C.__ExecuteUbergraph_BP_LensDropletManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDropletManager_C.__ExecuteUbergraph_BP_LensDropletManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E396 RID: 123798 RVA: 0x008EFF86 File Offset: 0x008EE186
		protected BP_LensDropletManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400ED82 RID: 60802
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/LensDroplet/BP_LensDropletManager.BP_LensDropletManager_C";

		// Token: 0x0400ED83 RID: 60803
		private static IntPtr _ClassPtr;

		// Token: 0x0400ED84 RID: 60804
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400ED85 RID: 60805
		internal static int __PropertyOffset_0;

		// Token: 0x0400ED86 RID: 60806
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400ED87 RID: 60807
		internal static int __PropertyOffset_1;

		// Token: 0x0400ED88 RID: 60808
		internal static int __PropertyOffset_2;

		// Token: 0x0400ED89 RID: 60809
		internal static int __PropertyOffset_3;

		// Token: 0x0400ED8A RID: 60810
		internal static int __PropertyOffset_4;

		// Token: 0x0400ED8B RID: 60811
		internal static int __PropertyOffset_5;

		// Token: 0x0400ED8C RID: 60812
		internal static int __PropertyOffset_6;

		// Token: 0x0400ED8D RID: 60813
		internal static int __PropertyOffset_7;

		// Token: 0x0400ED8E RID: 60814
		internal static int __PropertyOffset_8;

		// Token: 0x0400ED8F RID: 60815
		internal static int __PropertyOffset_9;

		// Token: 0x0400ED90 RID: 60816
		internal static int __PropertyOffset_10;

		// Token: 0x0400ED91 RID: 60817
		internal static int __PropertyOffset_11;

		// Token: 0x0400ED92 RID: 60818
		internal static int __PropertyOffset_12;

		// Token: 0x0400ED93 RID: 60819
		internal static int __PropertyOffset_13;

		// Token: 0x0400ED94 RID: 60820
		internal static int __PropertyOffset_14;

		// Token: 0x0400ED95 RID: 60821
		internal static int __PropertyOffset_15;

		// Token: 0x0400ED96 RID: 60822
		internal static int __PropertyOffset_16;

		// Token: 0x0400ED97 RID: 60823
		internal static int __PropertyOffset_17;

		// Token: 0x0400ED98 RID: 60824
		internal static int __PropertyOffset_18;

		// Token: 0x0400ED99 RID: 60825
		internal static int __PropertyOffset_19;

		// Token: 0x0400ED9A RID: 60826
		internal static int __PropertyOffset_20;

		// Token: 0x0400ED9B RID: 60827
		internal static int __PropertyOffset_21;

		// Token: 0x0400ED9C RID: 60828
		internal static int __PropertyOffset_22;

		// Token: 0x0400ED9D RID: 60829
		internal static int __PropertyOffset_23;

		// Token: 0x0400ED9E RID: 60830
		internal static int __PropertyOffset_24;

		// Token: 0x0400ED9F RID: 60831
		internal static int __PropertyOffset_25;

		// Token: 0x0400EDA0 RID: 60832
		internal static int __PropertyOffset_26;

		// Token: 0x0400EDA1 RID: 60833
		internal static int __PropertyOffset_27;

		// Token: 0x0400EDA2 RID: 60834
		internal static int __PropertyOffset_28;

		// Token: 0x0400EDA3 RID: 60835
		private static IntPtr __GenerateOneDroplets_NativeFunctionPtr;

		// Token: 0x0400EDA4 RID: 60836
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x0400EDA5 RID: 60837
		private static IntPtr __UpdateParameters_NativeFunctionPtr;

		// Token: 0x0400EDA6 RID: 60838
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x0400EDA7 RID: 60839
		private static IntPtr __ConstructPolyMesh_NativeFunctionPtr;

		// Token: 0x0400EDA8 RID: 60840
		private static IntPtr __SetBasicDropletParameters_NativeFunctionPtr;

		// Token: 0x0400EDA9 RID: 60841
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EDAA RID: 60842
		private static IntPtr __DropletGenerate__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0400EDAB RID: 60843
		private static IntPtr __DropletGenerate__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0400EDAC RID: 60844
		private static IntPtr __CustomEvent_1_NativeFunctionPtr;

		// Token: 0x0400EDAD RID: 60845
		private static IntPtr __DropletEnd_NativeFunctionPtr;

		// Token: 0x0400EDAE RID: 60846
		private static IntPtr __DropletStart_NativeFunctionPtr;

		// Token: 0x0400EDAF RID: 60847
		private static IntPtr __DisableDroplets_NativeFunctionPtr;

		// Token: 0x0400EDB0 RID: 60848
		private static IntPtr __CleanMesh_NativeFunctionPtr;

		// Token: 0x0400EDB1 RID: 60849
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400EDB2 RID: 60850
		private static IntPtr __EnableDroplets_NativeFunctionPtr;

		// Token: 0x0400EDB3 RID: 60851
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EDB4 RID: 60852
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EDB5 RID: 60853
		private static IntPtr __ExecuteUbergraph_BP_LensDropletManager_NativeFunctionPtr;

		// Token: 0x02009787 RID: 38791
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x04031D3E RID: 204094
			[FieldOffset(0)]
			public float Time;

			// Token: 0x04031D3F RID: 204095
			[FieldOffset(4)]
			public bool InOut;
		}

		// Token: 0x02009788 RID: 38792
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1488)]
		protected ref struct __ConstructPolyMesh_FunctionParams
		{
			// Token: 0x04031D40 RID: 204096
			[FieldOffset(0)]
			public int DropletAmount;
		}

		// Token: 0x02009789 RID: 38793
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __SetBasicDropletParameters_FunctionParams
		{
			// Token: 0x04031D41 RID: 204097
			[FieldOffset(0)]
			public float RainIntensity;

			// Token: 0x04031D42 RID: 204098
			[FieldOffset(4)]
			public float Gravity;

			// Token: 0x04031D43 RID: 204099
			[FieldOffset(8)]
			public TEnumAsByte<EKuroRainType> RainType;

			// Token: 0x04031D44 RID: 204100
			[FieldOffset(9)]
			public bool IsInCave;
		}

		// Token: 0x0200978A RID: 38794
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031D45 RID: 204101
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200978B RID: 38795
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D46 RID: 204102
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200978C RID: 38796
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __ExecuteUbergraph_BP_LensDropletManager_FunctionParams
		{
			// Token: 0x04031D47 RID: 204103
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
