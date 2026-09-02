using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint.MeshActor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint
{
	// Token: 0x02003ACF RID: 15055
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractBreakFoliageActor.BP_InteractBreakFoliageActor_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class BP_InteractBreakFoliageActor_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060202BB RID: 131771 RVA: 0x009241C3 File Offset: 0x009223C3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractBreakFoliageActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractBreakFoliageActor.BP_InteractBreakFoliageActor_C");
			}
			return BP_InteractBreakFoliageActor_C._ClassPtr;
		}

		// Token: 0x060202BC RID: 131772 RVA: 0x009241E8 File Offset: 0x009223E8
		public BP_InteractBreakFoliageActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractBreakFoliageActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060202BD RID: 131773 RVA: 0x00924210 File Offset: 0x00922410
		[NullableContext(1)]
		public BP_InteractBreakFoliageActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractBreakFoliageActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700343F RID: 13375
		// (get) Token: 0x060202BE RID: 131774 RVA: 0x00924244 File Offset: 0x00922444
		// (set) Token: 0x060202BF RID: 131775 RVA: 0x0092427D File Offset: 0x0092247D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003440 RID: 13376
		// (get) Token: 0x060202C0 RID: 131776 RVA: 0x0092429E File Offset: 0x0092249E
		// (set) Token: 0x060202C1 RID: 131777 RVA: 0x009242B2 File Offset: 0x009224B2
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003441 RID: 13377
		// (get) Token: 0x060202C2 RID: 131778 RVA: 0x009242C7 File Offset: 0x009224C7
		// (set) Token: 0x060202C3 RID: 131779 RVA: 0x009242DB File Offset: 0x009224DB
		public unsafe USkeletalMeshComponent SkeletalMeshFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003442 RID: 13378
		// (get) Token: 0x060202C4 RID: 131780 RVA: 0x009242F0 File Offset: 0x009224F0
		// (set) Token: 0x060202C5 RID: 131781 RVA: 0x00924304 File Offset: 0x00922504
		public unsafe UStaticMeshComponent StaticMeshFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003443 RID: 13379
		// (get) Token: 0x060202C6 RID: 131782 RVA: 0x00924319 File Offset: 0x00922519
		// (set) Token: 0x060202C7 RID: 131783 RVA: 0x0092432D File Offset: 0x0092252D
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003444 RID: 13380
		// (get) Token: 0x060202C8 RID: 131784 RVA: 0x00924342 File Offset: 0x00922542
		// (set) Token: 0x060202C9 RID: 131785 RVA: 0x00924352 File Offset: 0x00922552
		public unsafe float PointDissolveTimeline_NewTrack_0_D19F1AC4432ACC0334FB0C888B0DFE3E
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003445 RID: 13381
		// (get) Token: 0x060202CA RID: 131786 RVA: 0x00924363 File Offset: 0x00922563
		// (set) Token: 0x060202CB RID: 131787 RVA: 0x00924377 File Offset: 0x00922577
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> PointDissolveTimeline__Direction_D19F1AC4432ACC0334FB0C888B0DFE3E
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003446 RID: 13382
		// (get) Token: 0x060202CC RID: 131788 RVA: 0x0092438C File Offset: 0x0092258C
		// (set) Token: 0x060202CD RID: 131789 RVA: 0x009243A0 File Offset: 0x009225A0
		public unsafe UTimelineComponent PointDissolveTimeline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003447 RID: 13383
		// (get) Token: 0x060202CE RID: 131790 RVA: 0x009243B5 File Offset: 0x009225B5
		// (set) Token: 0x060202CF RID: 131791 RVA: 0x009243C5 File Offset: 0x009225C5
		public unsafe float PartDissolveTimeline_NewTrack_0_8AF5E49A48B1594A8225889CB48ACD7F
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003448 RID: 13384
		// (get) Token: 0x060202D0 RID: 131792 RVA: 0x009243D6 File Offset: 0x009225D6
		// (set) Token: 0x060202D1 RID: 131793 RVA: 0x009243EA File Offset: 0x009225EA
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> PartDissolveTimeline__Direction_8AF5E49A48B1594A8225889CB48ACD7F
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_9);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003449 RID: 13385
		// (get) Token: 0x060202D2 RID: 131794 RVA: 0x009243FF File Offset: 0x009225FF
		// (set) Token: 0x060202D3 RID: 131795 RVA: 0x00924413 File Offset: 0x00922613
		public unsafe UTimelineComponent PartDissolveTimeline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700344A RID: 13386
		// (get) Token: 0x060202D4 RID: 131796 RVA: 0x00924428 File Offset: 0x00922628
		// (set) Token: 0x060202D5 RID: 131797 RVA: 0x0092443C File Offset: 0x0092263C
		public unsafe KUROInteractFoliage_C FoliageType
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KUROInteractFoliage_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractBreakFoliageActor_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700344B RID: 13387
		// (get) Token: 0x060202D6 RID: 131798 RVA: 0x00924451 File Offset: 0x00922651
		// (set) Token: 0x060202D7 RID: 131799 RVA: 0x00924461 File Offset: 0x00922661
		public unsafe bool Active
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700344C RID: 13388
		// (get) Token: 0x060202D8 RID: 131800 RVA: 0x00924472 File Offset: 0x00922672
		// (set) Token: 0x060202D9 RID: 131801 RVA: 0x00924482 File Offset: 0x00922682
		public unsafe float CachedQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700344D RID: 13389
		// (get) Token: 0x060202DA RID: 131802 RVA: 0x00924493 File Offset: 0x00922693
		// (set) Token: 0x060202DB RID: 131803 RVA: 0x009244A7 File Offset: 0x009226A7
		public unsafe FName AngleBoneName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700344E RID: 13390
		// (get) Token: 0x060202DC RID: 131804 RVA: 0x009244BC File Offset: 0x009226BC
		// (set) Token: 0x060202DD RID: 131805 RVA: 0x009244D0 File Offset: 0x009226D0
		public unsafe FName BreakBoneName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700344F RID: 13391
		// (get) Token: 0x060202DE RID: 131806 RVA: 0x009244E5 File Offset: 0x009226E5
		// (set) Token: 0x060202DF RID: 131807 RVA: 0x009244F9 File Offset: 0x009226F9
		public unsafe FVector InitialDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003450 RID: 13392
		// (get) Token: 0x060202E0 RID: 131808 RVA: 0x0092450E File Offset: 0x0092270E
		// (set) Token: 0x060202E1 RID: 131809 RVA: 0x0092451E File Offset: 0x0092271E
		public unsafe bool UpperBone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003451 RID: 13393
		// (get) Token: 0x060202E2 RID: 131810 RVA: 0x0092452F File Offset: 0x0092272F
		// (set) Token: 0x060202E3 RID: 131811 RVA: 0x00924543 File Offset: 0x00922743
		public unsafe FName BreakJointName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003452 RID: 13394
		// (get) Token: 0x060202E4 RID: 131812 RVA: 0x00924558 File Offset: 0x00922758
		// (set) Token: 0x060202E5 RID: 131813 RVA: 0x00924591 File Offset: 0x00922791
		[Nullable(1)]
		public FCollisionResponseContainer New_Reponses
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FCollisionResponseContainer result;
				if ((result = this._New_Reponses) == null)
				{
					result = (this._New_Reponses = new FCollisionResponseContainer(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_19, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FCollisionResponseContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003453 RID: 13395
		// (get) Token: 0x060202E6 RID: 131814 RVA: 0x009245B2 File Offset: 0x009227B2
		// (set) Token: 0x060202E7 RID: 131815 RVA: 0x009245C2 File Offset: 0x009227C2
		public unsafe float ImpulseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003454 RID: 13396
		// (get) Token: 0x060202E8 RID: 131816 RVA: 0x009245D3 File Offset: 0x009227D3
		// (set) Token: 0x060202E9 RID: 131817 RVA: 0x009245E7 File Offset: 0x009227E7
		public unsafe FVector ExtraImpulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003455 RID: 13397
		// (get) Token: 0x060202EA RID: 131818 RVA: 0x009245FC File Offset: 0x009227FC
		// (set) Token: 0x060202EB RID: 131819 RVA: 0x0092460C File Offset: 0x0092280C
		public unsafe float AngularThreashold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003456 RID: 13398
		// (get) Token: 0x060202EC RID: 131820 RVA: 0x0092461D File Offset: 0x0092281D
		// (set) Token: 0x060202ED RID: 131821 RVA: 0x0092462D File Offset: 0x0092282D
		public unsafe float DissolveTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003457 RID: 13399
		// (get) Token: 0x060202EE RID: 131822 RVA: 0x0092463E File Offset: 0x0092283E
		// (set) Token: 0x060202EF RID: 131823 RVA: 0x0092464E File Offset: 0x0092284E
		public unsafe bool Broken
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003458 RID: 13400
		// (get) Token: 0x060202F0 RID: 131824 RVA: 0x0092465F File Offset: 0x0092285F
		// (set) Token: 0x060202F1 RID: 131825 RVA: 0x0092466F File Offset: 0x0092286F
		public unsafe float PartDissolve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003459 RID: 13401
		// (get) Token: 0x060202F2 RID: 131826 RVA: 0x00924680 File Offset: 0x00922880
		// (set) Token: 0x060202F3 RID: 131827 RVA: 0x00924690 File Offset: 0x00922890
		public unsafe float BreakPointDissolve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700345A RID: 13402
		// (get) Token: 0x060202F4 RID: 131828 RVA: 0x009246A4 File Offset: 0x009228A4
		// (set) Token: 0x060202F5 RID: 131829 RVA: 0x009246DD File Offset: 0x009228DD
		[Nullable(1)]
		public TArray<float> CustomData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CustomData) == null)
				{
					result = (this._CustomData = new TArray<float>(base.NativePtr + (IntPtr)BP_InteractBreakFoliageActor_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomData.CopyAssign(value);
			}
		}

		// Token: 0x060202F6 RID: 131830 RVA: 0x009246EB File Offset: 0x009228EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x060202F7 RID: 131831 RVA: 0x009246FF File Offset: 0x009228FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Test()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__Test_NativeFunctionPtr, null);
		}

		// Token: 0x060202F8 RID: 131832 RVA: 0x00924714 File Offset: 0x00922914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AdaptQualityLevel(ref bool bShouldTick)
		{
			BP_InteractBreakFoliageActor_C.__AdaptQualityLevel_FunctionParams* ptr = stackalloc BP_InteractBreakFoliageActor_C.__AdaptQualityLevel_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_InteractBreakFoliageActor_C.__AdaptQualityLevel_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBreakFoliageActor_C.__AdaptQualityLevel_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bShouldTick = bShouldTick;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__AdaptQualityLevel_NativeFunctionPtr, (void*)ptr);
			bShouldTick = ptr->bShouldTick;
		}

		// Token: 0x060202F9 RID: 131833 RVA: 0x00924764 File Offset: 0x00922964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeActiveFoliageNum(float ChangeNum)
		{
			BP_InteractBreakFoliageActor_C.__ChangeActiveFoliageNum_FunctionParams* ptr = stackalloc BP_InteractBreakFoliageActor_C.__ChangeActiveFoliageNum_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_InteractBreakFoliageActor_C.__ChangeActiveFoliageNum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBreakFoliageActor_C.__ChangeActiveFoliageNum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ChangeNum = ChangeNum;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__ChangeActiveFoliageNum_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060202FA RID: 131834 RVA: 0x009247AA File Offset: 0x009229AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060202FB RID: 131835 RVA: 0x009247BE File Offset: 0x009229BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060202FC RID: 131836 RVA: 0x009247D3 File Offset: 0x009229D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PartDissolveTimeline__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__PartDissolveTimeline__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x060202FD RID: 131837 RVA: 0x009247E7 File Offset: 0x009229E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PartDissolveTimeline__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__PartDissolveTimeline__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x060202FE RID: 131838 RVA: 0x009247FB File Offset: 0x009229FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PointDissolveTimeline__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__PointDissolveTimeline__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x060202FF RID: 131839 RVA: 0x0092480F File Offset: 0x00922A0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PointDissolveTimeline__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__PointDissolveTimeline__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06020300 RID: 131840 RVA: 0x00924824 File Offset: 0x00922A24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020301 RID: 131841 RVA: 0x009248E0 File Offset: 0x00922AE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020302 RID: 131842 RVA: 0x0092496C File Offset: 0x00922B6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_InteractBreakFoliageActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractBreakFoliageActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractBreakFoliageActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBreakFoliageActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020303 RID: 131843 RVA: 0x009249B4 File Offset: 0x00922BB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_InteractBreakFoliageActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractBreakFoliageActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractBreakFoliageActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBreakFoliageActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020304 RID: 131844 RVA: 0x009249FB File Offset: 0x00922BFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TestBreak()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__TestBreak_NativeFunctionPtr, null);
		}

		// Token: 0x06020305 RID: 131845 RVA: 0x00924A10 File Offset: 0x00922C10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CallChange(float Weight)
		{
			BP_InteractBreakFoliageActor_C.__CallChange_FunctionParams* ptr = stackalloc BP_InteractBreakFoliageActor_C.__CallChange_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractBreakFoliageActor_C.__CallChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBreakFoliageActor_C.__CallChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Weight = Weight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__CallChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020306 RID: 131846 RVA: 0x00924A56 File Offset: 0x00922C56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020307 RID: 131847 RVA: 0x00924A6A File Offset: 0x00922C6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020308 RID: 131848 RVA: 0x00924A80 File Offset: 0x00922C80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteractBreakFoliageActor(int EntryPoint)
		{
			BP_InteractBreakFoliageActor_C.__ExecuteUbergraph_BP_InteractBreakFoliageActor_FunctionParams* ptr = stackalloc BP_InteractBreakFoliageActor_C.__ExecuteUbergraph_BP_InteractBreakFoliageActor_FunctionParams[(UIntPtr)631] + 15L / (long)sizeof(BP_InteractBreakFoliageActor_C.__ExecuteUbergraph_BP_InteractBreakFoliageActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractBreakFoliageActor_C.__ExecuteUbergraph_BP_InteractBreakFoliageActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractBreakFoliageActor_C.__ExecuteUbergraph_BP_InteractBreakFoliageActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020309 RID: 131849 RVA: 0x00924ACA File Offset: 0x00922CCA
		protected BP_InteractBreakFoliageActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010091 RID: 65681
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractBreakFoliageActor.BP_InteractBreakFoliageActor_C";

		// Token: 0x04010092 RID: 65682
		private static IntPtr _ClassPtr;

		// Token: 0x04010093 RID: 65683
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010094 RID: 65684
		internal static int __PropertyOffset_0;

		// Token: 0x04010095 RID: 65685
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010096 RID: 65686
		internal static int __PropertyOffset_1;

		// Token: 0x04010097 RID: 65687
		internal static int __PropertyOffset_2;

		// Token: 0x04010098 RID: 65688
		internal static int __PropertyOffset_3;

		// Token: 0x04010099 RID: 65689
		internal static int __PropertyOffset_4;

		// Token: 0x0401009A RID: 65690
		internal static int __PropertyOffset_5;

		// Token: 0x0401009B RID: 65691
		internal static int __PropertyOffset_6;

		// Token: 0x0401009C RID: 65692
		internal static int __PropertyOffset_7;

		// Token: 0x0401009D RID: 65693
		internal static int __PropertyOffset_8;

		// Token: 0x0401009E RID: 65694
		internal static int __PropertyOffset_9;

		// Token: 0x0401009F RID: 65695
		internal static int __PropertyOffset_10;

		// Token: 0x040100A0 RID: 65696
		internal static int __PropertyOffset_11;

		// Token: 0x040100A1 RID: 65697
		internal static int __PropertyOffset_12;

		// Token: 0x040100A2 RID: 65698
		internal static int __PropertyOffset_13;

		// Token: 0x040100A3 RID: 65699
		internal static int __PropertyOffset_14;

		// Token: 0x040100A4 RID: 65700
		internal static int __PropertyOffset_15;

		// Token: 0x040100A5 RID: 65701
		internal static int __PropertyOffset_16;

		// Token: 0x040100A6 RID: 65702
		internal static int __PropertyOffset_17;

		// Token: 0x040100A7 RID: 65703
		internal static int __PropertyOffset_18;

		// Token: 0x040100A8 RID: 65704
		internal static int __PropertyOffset_19;

		// Token: 0x040100A9 RID: 65705
		private FCollisionResponseContainer _New_Reponses;

		// Token: 0x040100AA RID: 65706
		internal static int __PropertyOffset_20;

		// Token: 0x040100AB RID: 65707
		internal static int __PropertyOffset_21;

		// Token: 0x040100AC RID: 65708
		internal static int __PropertyOffset_22;

		// Token: 0x040100AD RID: 65709
		internal static int __PropertyOffset_23;

		// Token: 0x040100AE RID: 65710
		internal static int __PropertyOffset_24;

		// Token: 0x040100AF RID: 65711
		internal static int __PropertyOffset_25;

		// Token: 0x040100B0 RID: 65712
		internal static int __PropertyOffset_26;

		// Token: 0x040100B1 RID: 65713
		internal static int __PropertyOffset_27;

		// Token: 0x040100B2 RID: 65714
		private TArray<float> _CustomData;

		// Token: 0x040100B3 RID: 65715
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x040100B4 RID: 65716
		private static IntPtr __Test_NativeFunctionPtr;

		// Token: 0x040100B5 RID: 65717
		private static IntPtr __AdaptQualityLevel_NativeFunctionPtr;

		// Token: 0x040100B6 RID: 65718
		private static IntPtr __ChangeActiveFoliageNum_NativeFunctionPtr;

		// Token: 0x040100B7 RID: 65719
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040100B8 RID: 65720
		private static IntPtr __PartDissolveTimeline__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040100B9 RID: 65721
		private static IntPtr __PartDissolveTimeline__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040100BA RID: 65722
		private static IntPtr __PointDissolveTimeline__FinishedFunc_NativeFunctionPtr;

		// Token: 0x040100BB RID: 65723
		private static IntPtr __PointDissolveTimeline__UpdateFunc_NativeFunctionPtr;

		// Token: 0x040100BC RID: 65724
		private static IntPtr __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040100BD RID: 65725
		private static IntPtr __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040100BE RID: 65726
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040100BF RID: 65727
		private static IntPtr __TestBreak_NativeFunctionPtr;

		// Token: 0x040100C0 RID: 65728
		private static IntPtr __CallChange_NativeFunctionPtr;

		// Token: 0x040100C1 RID: 65729
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040100C2 RID: 65730
		private static IntPtr __ExecuteUbergraph_BP_InteractBreakFoliageActor_NativeFunctionPtr;

		// Token: 0x02009963 RID: 39267
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __AdaptQualityLevel_FunctionParams
		{
			// Token: 0x04031FD1 RID: 204753
			[FieldOffset(0)]
			public bool bShouldTick;
		}

		// Token: 0x02009964 RID: 39268
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ChangeActiveFoliageNum_FunctionParams
		{
			// Token: 0x04031FD2 RID: 204754
			[FieldOffset(0)]
			public float ChangeNum;
		}

		// Token: 0x02009965 RID: 39269
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031FD3 RID: 204755
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031FD4 RID: 204756
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031FD5 RID: 204757
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031FD6 RID: 204758
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04031FD7 RID: 204759
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04031FD8 RID: 204760
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009966 RID: 39270
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031FD9 RID: 204761
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031FDA RID: 204762
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031FDB RID: 204763
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031FDC RID: 204764
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009967 RID: 39271
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FDD RID: 204765
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009968 RID: 39272
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __CallChange_FunctionParams
		{
			// Token: 0x04031FDE RID: 204766
			[FieldOffset(0)]
			public float Weight;
		}

		// Token: 0x02009969 RID: 39273
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 616)]
		protected ref struct __ExecuteUbergraph_BP_InteractBreakFoliageActor_FunctionParams
		{
			// Token: 0x04031FDF RID: 204767
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
