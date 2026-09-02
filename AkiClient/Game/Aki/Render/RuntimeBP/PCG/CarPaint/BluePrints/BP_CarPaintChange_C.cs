using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.CarPaint.BluePrints
{
	// Token: 0x02003C39 RID: 15417
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BP_CarPaintChange.BP_CarPaintChange_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class BP_CarPaintChange_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_CarPaintChange_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602362F RID: 144943 RVA: 0x009808B3 File Offset: 0x0097EAB3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CarPaintChange_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BP_CarPaintChange.BP_CarPaintChange_C");
			}
			return BP_CarPaintChange_C._ClassPtr;
		}

		// Token: 0x06023630 RID: 144944 RVA: 0x009808D8 File Offset: 0x0097EAD8
		public BP_CarPaintChange_C() : this(BuiltinUtils.AllocNativeUObject(BP_CarPaintChange_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023631 RID: 144945 RVA: 0x00980900 File Offset: 0x0097EB00
		[NullableContext(1)]
		public BP_CarPaintChange_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CarPaintChange_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004621 RID: 17953
		// (get) Token: 0x06023632 RID: 144946 RVA: 0x00980934 File Offset: 0x0097EB34
		// (set) Token: 0x06023633 RID: 144947 RVA: 0x0098096D File Offset: 0x0097EB6D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004622 RID: 17954
		// (get) Token: 0x06023634 RID: 144948 RVA: 0x0098098E File Offset: 0x0097EB8E
		// (set) Token: 0x06023635 RID: 144949 RVA: 0x009809A2 File Offset: 0x0097EBA2
		public unsafe UStaticMeshComponent PlaneDissolve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004623 RID: 17955
		// (get) Token: 0x06023636 RID: 144950 RVA: 0x009809B7 File Offset: 0x0097EBB7
		// (set) Token: 0x06023637 RID: 144951 RVA: 0x009809CB File Offset: 0x0097EBCB
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004624 RID: 17956
		// (get) Token: 0x06023638 RID: 144952 RVA: 0x009809E0 File Offset: 0x0097EBE0
		// (set) Token: 0x06023639 RID: 144953 RVA: 0x009809F4 File Offset: 0x0097EBF4
		public unsafe UStaticMeshComponent SM_Vehicle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004625 RID: 17957
		// (get) Token: 0x0602363A RID: 144954 RVA: 0x00980A09 File Offset: 0x0097EC09
		// (set) Token: 0x0602363B RID: 144955 RVA: 0x00980A1D File Offset: 0x0097EC1D
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004626 RID: 17958
		// (get) Token: 0x0602363C RID: 144956 RVA: 0x00980A32 File Offset: 0x0097EC32
		// (set) Token: 0x0602363D RID: 144957 RVA: 0x00980A42 File Offset: 0x0097EC42
		public unsafe float CurrentColorSet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004627 RID: 17959
		// (get) Token: 0x0602363E RID: 144958 RVA: 0x00980A53 File Offset: 0x0097EC53
		// (set) Token: 0x0602363F RID: 144959 RVA: 0x00980A63 File Offset: 0x0097EC63
		public unsafe float TargetColorSet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004628 RID: 17960
		// (get) Token: 0x06023640 RID: 144960 RVA: 0x00980A74 File Offset: 0x0097EC74
		// (set) Token: 0x06023641 RID: 144961 RVA: 0x00980A84 File Offset: 0x0097EC84
		public unsafe float ColorChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004629 RID: 17961
		// (get) Token: 0x06023642 RID: 144962 RVA: 0x00980A95 File Offset: 0x0097EC95
		// (set) Token: 0x06023643 RID: 144963 RVA: 0x00980AA5 File Offset: 0x0097ECA5
		public unsafe bool ShouldUpdateChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700462A RID: 17962
		// (get) Token: 0x06023644 RID: 144964 RVA: 0x00980AB6 File Offset: 0x0097ECB6
		// (set) Token: 0x06023645 RID: 144965 RVA: 0x00980ACA File Offset: 0x0097ECCA
		public unsafe UMaterialInstanceDynamic CarPaintDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700462B RID: 17963
		// (get) Token: 0x06023646 RID: 144966 RVA: 0x00980ADF File Offset: 0x0097ECDF
		// (set) Token: 0x06023647 RID: 144967 RVA: 0x00980AF3 File Offset: 0x0097ECF3
		public unsafe UMaterialInstanceDynamic CarPaintDMI1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700462C RID: 17964
		// (get) Token: 0x06023648 RID: 144968 RVA: 0x00980B08 File Offset: 0x0097ED08
		// (set) Token: 0x06023649 RID: 144969 RVA: 0x00980B1C File Offset: 0x0097ED1C
		public unsafe UMaterialInstanceDynamic CarPaintDMI2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700462D RID: 17965
		// (get) Token: 0x0602364A RID: 144970 RVA: 0x00980B34 File Offset: 0x0097ED34
		// (set) Token: 0x0602364B RID: 144971 RVA: 0x00980B6D File Offset: 0x0097ED6D
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> CarPaintDMIList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._CarPaintDMIList) == null)
				{
					result = (this._CarPaintDMIList = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CarPaintDMIList.CopyAssign(value);
			}
		}

		// Token: 0x1700462E RID: 17966
		// (get) Token: 0x0602364C RID: 144972 RVA: 0x00980B7B File Offset: 0x0097ED7B
		// (set) Token: 0x0602364D RID: 144973 RVA: 0x00980B8B File Offset: 0x0097ED8B
		public unsafe int ColorSetID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700462F RID: 17967
		// (get) Token: 0x0602364E RID: 144974 RVA: 0x00980B9C File Offset: 0x0097ED9C
		// (set) Token: 0x0602364F RID: 144975 RVA: 0x00980BAC File Offset: 0x0097EDAC
		public unsafe bool PlayPlaneDissolve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004630 RID: 17968
		// (get) Token: 0x06023650 RID: 144976 RVA: 0x00980BBD File Offset: 0x0097EDBD
		// (set) Token: 0x06023651 RID: 144977 RVA: 0x00980BCD File Offset: 0x0097EDCD
		public unsafe float DirEdgeWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004631 RID: 17969
		// (get) Token: 0x06023652 RID: 144978 RVA: 0x00980BDE File Offset: 0x0097EDDE
		// (set) Token: 0x06023653 RID: 144979 RVA: 0x00980BF2 File Offset: 0x0097EDF2
		public unsafe FLinearColor PlaneDisEdgeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004632 RID: 17970
		// (get) Token: 0x06023654 RID: 144980 RVA: 0x00980C07 File Offset: 0x0097EE07
		// (set) Token: 0x06023655 RID: 144981 RVA: 0x00980C1B File Offset: 0x0097EE1B
		public unsafe UStaticMesh SMVehicle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004633 RID: 17971
		// (get) Token: 0x06023656 RID: 144982 RVA: 0x00980C30 File Offset: 0x0097EE30
		// (set) Token: 0x06023657 RID: 144983 RVA: 0x00980C40 File Offset: 0x0097EE40
		public unsafe bool EditorDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004634 RID: 17972
		// (get) Token: 0x06023658 RID: 144984 RVA: 0x00980C51 File Offset: 0x0097EE51
		// (set) Token: 0x06023659 RID: 144985 RVA: 0x00980C61 File Offset: 0x0097EE61
		public unsafe float ChangeRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004635 RID: 17973
		// (get) Token: 0x0602365A RID: 144986 RVA: 0x00980C72 File Offset: 0x0097EE72
		// (set) Token: 0x0602365B RID: 144987 RVA: 0x00980C82 File Offset: 0x0097EE82
		public unsafe float ChangeEdgeWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004636 RID: 17974
		// (get) Token: 0x0602365C RID: 144988 RVA: 0x00980C93 File Offset: 0x0097EE93
		// (set) Token: 0x0602365D RID: 144989 RVA: 0x00980CA7 File Offset: 0x0097EEA7
		public unsafe FLinearColor ChangeEdgeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004637 RID: 17975
		// (get) Token: 0x0602365E RID: 144990 RVA: 0x00980CBC File Offset: 0x0097EEBC
		// (set) Token: 0x0602365F RID: 144991 RVA: 0x00980CCC File Offset: 0x0097EECC
		public unsafe bool UseBPTex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarPaintChange_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004638 RID: 17976
		// (get) Token: 0x06023660 RID: 144992 RVA: 0x00980CDD File Offset: 0x0097EEDD
		// (set) Token: 0x06023661 RID: 144993 RVA: 0x00980CF1 File Offset: 0x0097EEF1
		public unsafe UTexture2D BaseTex2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004639 RID: 17977
		// (get) Token: 0x06023662 RID: 144994 RVA: 0x00980D06 File Offset: 0x0097EF06
		// (set) Token: 0x06023663 RID: 144995 RVA: 0x00980D1A File Offset: 0x0097EF1A
		public unsafe UTexture2D BaseTex3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarPaintChange_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x06023664 RID: 144996 RVA: 0x00980D2F File Offset: 0x0097EF2F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RecoverMat()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__RecoverMat_NativeFunctionPtr, null);
		}

		// Token: 0x06023665 RID: 144997 RVA: 0x00980D43 File Offset: 0x0097EF43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Initialize()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__Initialize_NativeFunctionPtr, null);
		}

		// Token: 0x06023666 RID: 144998 RVA: 0x00980D58 File Offset: 0x0097EF58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDMIListScalar([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UMaterialInstanceDynamic> NewParam)
		{
			BP_CarPaintChange_C.__SetDMIListScalar_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__SetDMIListScalar_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_CarPaintChange_C.__SetDMIListScalar_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__SetDMIListScalar_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UMaterialInstanceDynamic> tarray = NewParam;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->NewParam);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__SetDMIListScalar_NativeFunctionPtr, (void*)ptr);
			TArray<UMaterialInstanceDynamic> tarray2 = NewParam;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->NewParam);
			}
			UnrealReflectionUtils.DestroyStruct(BP_CarPaintChange_C.__SetDMIListScalar_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06023667 RID: 144999 RVA: 0x00980DD0 File Offset: 0x0097EFD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDMI(UMaterialInstanceDynamic NewParam)
		{
			BP_CarPaintChange_C.__SetDMI_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__SetDMI_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_CarPaintChange_C.__SetDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__SetDMI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = ((NewParam != null) ? NewParam.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__SetDMI_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023668 RID: 145000 RVA: 0x00980E25 File Offset: 0x0097F025
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetColorFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__SetColorFunction_NativeFunctionPtr, null);
		}

		// Token: 0x06023669 RID: 145001 RVA: 0x00980E39 File Offset: 0x0097F039
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602366A RID: 145002 RVA: 0x00980E4D File Offset: 0x0097F04D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CarPaintChange_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602366B RID: 145003 RVA: 0x00980E62 File Offset: 0x0097F062
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602366C RID: 145004 RVA: 0x00980E76 File Offset: 0x0097F076
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CarPaintChange_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602366D RID: 145005 RVA: 0x00980E8C File Offset: 0x0097F08C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CarPaintChange_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarPaintChange_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602366E RID: 145006 RVA: 0x00980ED4 File Offset: 0x0097F0D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CarPaintChange_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarPaintChange_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CarPaintChange_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602366F RID: 145007 RVA: 0x00980F1C File Offset: 0x0097F11C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetColorChange(float TargetColorSet)
		{
			BP_CarPaintChange_C.__SetColorChange_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__SetColorChange_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarPaintChange_C.__SetColorChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__SetColorChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TargetColorSet = TargetColorSet;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__SetColorChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023670 RID: 145008 RVA: 0x00980F64 File Offset: 0x0097F164
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CarPaintChange_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarPaintChange_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023671 RID: 145009 RVA: 0x00980FAC File Offset: 0x0097F1AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CarPaintChange_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarPaintChange_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CarPaintChange_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023672 RID: 145010 RVA: 0x00980FF4 File Offset: 0x0097F1F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetColorFunctionByBPI(bool _bool)
		{
			BP_CarPaintChange_C.__SetColorFunctionByBPI_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__SetColorFunctionByBPI_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_CarPaintChange_C.__SetColorFunctionByBPI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__SetColorFunctionByBPI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->_bool = _bool;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarPaintChange_C.__SetColorFunctionByBPI_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023673 RID: 145011 RVA: 0x0098103C File Offset: 0x0097F23C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CarPaintChange(int EntryPoint)
		{
			BP_CarPaintChange_C.__ExecuteUbergraph_BP_CarPaintChange_FunctionParams* ptr = stackalloc BP_CarPaintChange_C.__ExecuteUbergraph_BP_CarPaintChange_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(BP_CarPaintChange_C.__ExecuteUbergraph_BP_CarPaintChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarPaintChange_C.__ExecuteUbergraph_BP_CarPaintChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CarPaintChange_C.__ExecuteUbergraph_BP_CarPaintChange_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023674 RID: 145012 RVA: 0x00981086 File Offset: 0x0097F286
		protected BP_CarPaintChange_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012025 RID: 73765
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BP_CarPaintChange.BP_CarPaintChange_C";

		// Token: 0x04012026 RID: 73766
		private static IntPtr _ClassPtr;

		// Token: 0x04012027 RID: 73767
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012028 RID: 73768
		internal static int __PropertyOffset_0;

		// Token: 0x04012029 RID: 73769
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401202A RID: 73770
		internal static int __PropertyOffset_1;

		// Token: 0x0401202B RID: 73771
		internal static int __PropertyOffset_2;

		// Token: 0x0401202C RID: 73772
		internal static int __PropertyOffset_3;

		// Token: 0x0401202D RID: 73773
		internal static int __PropertyOffset_4;

		// Token: 0x0401202E RID: 73774
		internal static int __PropertyOffset_5;

		// Token: 0x0401202F RID: 73775
		internal static int __PropertyOffset_6;

		// Token: 0x04012030 RID: 73776
		internal static int __PropertyOffset_7;

		// Token: 0x04012031 RID: 73777
		internal static int __PropertyOffset_8;

		// Token: 0x04012032 RID: 73778
		internal static int __PropertyOffset_9;

		// Token: 0x04012033 RID: 73779
		internal static int __PropertyOffset_10;

		// Token: 0x04012034 RID: 73780
		internal static int __PropertyOffset_11;

		// Token: 0x04012035 RID: 73781
		internal static int __PropertyOffset_12;

		// Token: 0x04012036 RID: 73782
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _CarPaintDMIList;

		// Token: 0x04012037 RID: 73783
		internal static int __PropertyOffset_13;

		// Token: 0x04012038 RID: 73784
		internal static int __PropertyOffset_14;

		// Token: 0x04012039 RID: 73785
		internal static int __PropertyOffset_15;

		// Token: 0x0401203A RID: 73786
		internal static int __PropertyOffset_16;

		// Token: 0x0401203B RID: 73787
		internal static int __PropertyOffset_17;

		// Token: 0x0401203C RID: 73788
		internal static int __PropertyOffset_18;

		// Token: 0x0401203D RID: 73789
		internal static int __PropertyOffset_19;

		// Token: 0x0401203E RID: 73790
		internal static int __PropertyOffset_20;

		// Token: 0x0401203F RID: 73791
		internal static int __PropertyOffset_21;

		// Token: 0x04012040 RID: 73792
		internal static int __PropertyOffset_22;

		// Token: 0x04012041 RID: 73793
		internal static int __PropertyOffset_23;

		// Token: 0x04012042 RID: 73794
		internal static int __PropertyOffset_24;

		// Token: 0x04012043 RID: 73795
		private static IntPtr __RecoverMat_NativeFunctionPtr;

		// Token: 0x04012044 RID: 73796
		private static IntPtr __Initialize_NativeFunctionPtr;

		// Token: 0x04012045 RID: 73797
		private static IntPtr __SetDMIListScalar_NativeFunctionPtr;

		// Token: 0x04012046 RID: 73798
		private static IntPtr __SetDMI_NativeFunctionPtr;

		// Token: 0x04012047 RID: 73799
		private static IntPtr __SetColorFunction_NativeFunctionPtr;

		// Token: 0x04012048 RID: 73800
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012049 RID: 73801
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401204A RID: 73802
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401204B RID: 73803
		private static IntPtr __SetColorChange_NativeFunctionPtr;

		// Token: 0x0401204C RID: 73804
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401204D RID: 73805
		private static IntPtr __SetColorFunctionByBPI_NativeFunctionPtr;

		// Token: 0x0401204E RID: 73806
		private static IntPtr __ExecuteUbergraph_BP_CarPaintChange_NativeFunctionPtr;

		// Token: 0x02009CD0 RID: 40144
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetDMIListScalar_FunctionParams
		{
			// Token: 0x04032643 RID: 206403
			[FieldOffset(0)]
			public byte NewParam;
		}

		// Token: 0x02009CD1 RID: 40145
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetDMI_FunctionParams
		{
			// Token: 0x04032644 RID: 206404
			[FieldOffset(0)]
			public IntPtr NewParam;
		}

		// Token: 0x02009CD2 RID: 40146
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032645 RID: 206405
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CD3 RID: 40147
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetColorChange_FunctionParams
		{
			// Token: 0x04032646 RID: 206406
			[FieldOffset(0)]
			public float TargetColorSet;
		}

		// Token: 0x02009CD4 RID: 40148
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032647 RID: 206407
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CD5 RID: 40149
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetColorFunctionByBPI_FunctionParams
		{
			// Token: 0x04032648 RID: 206408
			[FieldOffset(0)]
			public bool _bool;
		}

		// Token: 0x02009CD6 RID: 40150
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __ExecuteUbergraph_BP_CarPaintChange_FunctionParams
		{
			// Token: 0x04032649 RID: 206409
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
