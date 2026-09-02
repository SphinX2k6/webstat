using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints
{
	// Token: 0x02003A54 RID: 14932
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTrailComponent.BP_SnowTrailComponent_C")]
	[UnrealStructLayout(768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 764)]
	public class BP_SnowTrailComponent_C : USceneComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EFC5 RID: 126917 RVA: 0x009041AB File Offset: 0x009023AB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTrailComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTrailComponent.BP_SnowTrailComponent_C");
			}
			return BP_SnowTrailComponent_C._ClassPtr;
		}

		// Token: 0x0601EFC6 RID: 126918 RVA: 0x009041D0 File Offset: 0x009023D0
		public BP_SnowTrailComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTrailComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EFC7 RID: 126919 RVA: 0x009041F8 File Offset: 0x009023F8
		[NullableContext(1)]
		public BP_SnowTrailComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTrailComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002D81 RID: 11649
		// (get) Token: 0x0601EFC8 RID: 126920 RVA: 0x0090422C File Offset: 0x0090242C
		// (set) Token: 0x0601EFC9 RID: 126921 RVA: 0x00904265 File Offset: 0x00902465
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D82 RID: 11650
		// (get) Token: 0x0601EFCA RID: 126922 RVA: 0x00904286 File Offset: 0x00902486
		// (set) Token: 0x0601EFCB RID: 126923 RVA: 0x00904296 File Offset: 0x00902496
		public unsafe bool UseActorPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D83 RID: 11651
		// (get) Token: 0x0601EFCC RID: 126924 RVA: 0x009042A7 File Offset: 0x009024A7
		// (set) Token: 0x0601EFCD RID: 126925 RVA: 0x009042B7 File Offset: 0x009024B7
		public unsafe bool UseEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D84 RID: 11652
		// (get) Token: 0x0601EFCE RID: 126926 RVA: 0x009042C8 File Offset: 0x009024C8
		// (set) Token: 0x0601EFCF RID: 126927 RVA: 0x009042D8 File Offset: 0x009024D8
		public unsafe bool UseSimplePrint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D85 RID: 11653
		// (get) Token: 0x0601EFD0 RID: 126928 RVA: 0x009042E9 File Offset: 0x009024E9
		// (set) Token: 0x0601EFD1 RID: 126929 RVA: 0x009042F9 File Offset: 0x009024F9
		public unsafe int NFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002D86 RID: 11654
		// (get) Token: 0x0601EFD2 RID: 126930 RVA: 0x0090430A File Offset: 0x0090250A
		// (set) Token: 0x0601EFD3 RID: 126931 RVA: 0x0090431A File Offset: 0x0090251A
		public unsafe float Hardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002D87 RID: 11655
		// (get) Token: 0x0601EFD4 RID: 126932 RVA: 0x0090432B File Offset: 0x0090252B
		// (set) Token: 0x0601EFD5 RID: 126933 RVA: 0x0090433B File Offset: 0x0090253B
		public unsafe float RayLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002D88 RID: 11656
		// (get) Token: 0x0601EFD6 RID: 126934 RVA: 0x0090434C File Offset: 0x0090254C
		// (set) Token: 0x0601EFD7 RID: 126935 RVA: 0x0090435C File Offset: 0x0090255C
		public unsafe float TrailRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002D89 RID: 11657
		// (get) Token: 0x0601EFD8 RID: 126936 RVA: 0x0090436D File Offset: 0x0090256D
		// (set) Token: 0x0601EFD9 RID: 126937 RVA: 0x0090437D File Offset: 0x0090257D
		public unsafe float DistanceTraveld2D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002D8A RID: 11658
		// (get) Token: 0x0601EFDA RID: 126938 RVA: 0x0090438E File Offset: 0x0090258E
		// (set) Token: 0x0601EFDB RID: 126939 RVA: 0x009043A2 File Offset: 0x009025A2
		public unsafe FVector LastUpdateLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002D8B RID: 11659
		// (get) Token: 0x0601EFDC RID: 126940 RVA: 0x009043B7 File Offset: 0x009025B7
		// (set) Token: 0x0601EFDD RID: 126941 RVA: 0x009043CB File Offset: 0x009025CB
		[Nullable(2)]
		public unsafe BP_SnowTraceManager_C MyTraceManager
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTraceManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailComponent_C.__PropertyOffset_10);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailComponent_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002D8C RID: 11660
		// (get) Token: 0x0601EFDE RID: 126942 RVA: 0x009043E0 File Offset: 0x009025E0
		// (set) Token: 0x0601EFDF RID: 126943 RVA: 0x009043F4 File Offset: 0x009025F4
		public unsafe FVector LastCheckLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002D8D RID: 11661
		// (get) Token: 0x0601EFE0 RID: 126944 RVA: 0x00904409 File Offset: 0x00902609
		// (set) Token: 0x0601EFE1 RID: 126945 RVA: 0x0090441D File Offset: 0x0090261D
		public unsafe FName BoneName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002D8E RID: 11662
		// (get) Token: 0x0601EFE2 RID: 126946 RVA: 0x00904432 File Offset: 0x00902632
		// (set) Token: 0x0601EFE3 RID: 126947 RVA: 0x00904446 File Offset: 0x00902646
		public unsafe FVector BoneTransOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002D8F RID: 11663
		// (get) Token: 0x0601EFE4 RID: 126948 RVA: 0x0090445B File Offset: 0x0090265B
		// (set) Token: 0x0601EFE5 RID: 126949 RVA: 0x0090446F File Offset: 0x0090266F
		public unsafe FVector BoneLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002D90 RID: 11664
		// (get) Token: 0x0601EFE6 RID: 126950 RVA: 0x00904484 File Offset: 0x00902684
		// (set) Token: 0x0601EFE7 RID: 126951 RVA: 0x00904498 File Offset: 0x00902698
		[Nullable(2)]
		public unsafe BP_SceneBattleInteract_C Config
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneBattleInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailComponent_C.__PropertyOffset_15);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailComponent_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17002D91 RID: 11665
		// (get) Token: 0x0601EFE8 RID: 126952 RVA: 0x009044AD File Offset: 0x009026AD
		// (set) Token: 0x0601EFE9 RID: 126953 RVA: 0x009044BD File Offset: 0x009026BD
		public unsafe double Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002D92 RID: 11666
		// (get) Token: 0x0601EFEA RID: 126954 RVA: 0x009044CE File Offset: 0x009026CE
		// (set) Token: 0x0601EFEB RID: 126955 RVA: 0x009044DE File Offset: 0x009026DE
		public unsafe float BulletLastHitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002D93 RID: 11667
		// (get) Token: 0x0601EFEC RID: 126956 RVA: 0x009044F0 File Offset: 0x009026F0
		// (set) Token: 0x0601EFED RID: 126957 RVA: 0x00904529 File Offset: 0x00902729
		[Nullable(1)]
		public TArray<FVectorDouble> BulletHitList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._BulletHitList) == null)
				{
					result = (this._BulletHitList = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BulletHitList.CopyAssign(value);
			}
		}

		// Token: 0x17002D94 RID: 11668
		// (get) Token: 0x0601EFEE RID: 126958 RVA: 0x00904537 File Offset: 0x00902737
		// (set) Token: 0x0601EFEF RID: 126959 RVA: 0x00904547 File Offset: 0x00902747
		public unsafe double Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002D95 RID: 11669
		// (get) Token: 0x0601EFF0 RID: 126960 RVA: 0x00904558 File Offset: 0x00902758
		// (set) Token: 0x0601EFF1 RID: 126961 RVA: 0x00904568 File Offset: 0x00902768
		public unsafe double BulletMaxConnectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002D96 RID: 11670
		// (get) Token: 0x0601EFF2 RID: 126962 RVA: 0x00904579 File Offset: 0x00902779
		// (set) Token: 0x0601EFF3 RID: 126963 RVA: 0x00904589 File Offset: 0x00902789
		public unsafe double BulletMinConnectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002D97 RID: 11671
		// (get) Token: 0x0601EFF4 RID: 126964 RVA: 0x0090459A File Offset: 0x0090279A
		// (set) Token: 0x0601EFF5 RID: 126965 RVA: 0x009045AA File Offset: 0x009027AA
		public unsafe int Step
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002D98 RID: 11672
		// (get) Token: 0x0601EFF6 RID: 126966 RVA: 0x009045BB File Offset: 0x009027BB
		// (set) Token: 0x0601EFF7 RID: 126967 RVA: 0x009045CB File Offset: 0x009027CB
		public unsafe bool SelfEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D99 RID: 11673
		// (get) Token: 0x0601EFF8 RID: 126968 RVA: 0x009045DC File Offset: 0x009027DC
		// (set) Token: 0x0601EFF9 RID: 126969 RVA: 0x009045EC File Offset: 0x009027EC
		public unsafe int FrameConter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTrailComponent_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x0601EFFA RID: 126970 RVA: 0x00904600 File Offset: 0x00902800
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateDeltaTime(float DeltaTime)
		{
			BP_SnowTrailComponent_C.__UpdateDeltaTime_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_C.__UpdateDeltaTime_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SnowTrailComponent_C.__UpdateDeltaTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_C.__UpdateDeltaTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__UpdateDeltaTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFFB RID: 126971 RVA: 0x00904648 File Offset: 0x00902848
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CompareNewPointWeapon(FVectorDouble V2, ref bool Valid)
		{
			BP_SnowTrailComponent_C.__CompareNewPointWeapon_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_C.__CompareNewPointWeapon_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_SnowTrailComponent_C.__CompareNewPointWeapon_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_C.__CompareNewPointWeapon_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V2 = V2;
			ptr->Valid = Valid;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__CompareNewPointWeapon_NativeFunctionPtr, (void*)ptr);
			Valid = ptr->Valid;
		}

		// Token: 0x0601EFFC RID: 126972 RVA: 0x009046A0 File Offset: 0x009028A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SnowCollisionEffect(FVectorDouble AvailablePoint, float TrailRadius, float TrailDepth)
		{
			BP_SnowTrailComponent_C.__SnowCollisionEffect_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_C.__SnowCollisionEffect_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_SnowTrailComponent_C.__SnowCollisionEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_C.__SnowCollisionEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AvailablePoint = AvailablePoint;
			ptr->TrailRadius = TrailRadius;
			ptr->TrailDepth = TrailDepth;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__SnowCollisionEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFFD RID: 126973 RVA: 0x009046F7 File Offset: 0x009028F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SnowCollisionActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__SnowCollisionActor_NativeFunctionPtr, null);
		}

		// Token: 0x0601EFFE RID: 126974 RVA: 0x0090470B File Offset: 0x0090290B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SnowCollisionBone()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__SnowCollisionBone_NativeFunctionPtr, null);
		}

		// Token: 0x0601EFFF RID: 126975 RVA: 0x00904720 File Offset: 0x00902920
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RegisterTrailComp(float Radius, float Depth, float Hardness, float TrailRotation, FVector TrailLocation)
		{
			BP_SnowTrailComponent_C.__RegisterTrailComp_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_C.__RegisterTrailComp_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SnowTrailComponent_C.__RegisterTrailComp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_C.__RegisterTrailComp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Radius = Radius;
			ptr->Depth = Depth;
			ptr->Hardness = Hardness;
			ptr->TrailRotation = TrailRotation;
			ptr->TrailLocation = TrailLocation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__RegisterTrailComp_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F000 RID: 126976 RVA: 0x00904784 File Offset: 0x00902984
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FindTrailManager()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__FindTrailManager_NativeFunctionPtr, null);
		}

		// Token: 0x0601F001 RID: 126977 RVA: 0x00904798 File Offset: 0x00902998
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F002 RID: 126978 RVA: 0x009047AC File Offset: 0x009029AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTrailComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F003 RID: 126979 RVA: 0x009047C4 File Offset: 0x009029C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SnowTrailComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowTrailComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F004 RID: 126980 RVA: 0x0090480C File Offset: 0x00902A0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SnowTrailComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowTrailComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTrailComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F005 RID: 126981 RVA: 0x00904854 File Offset: 0x00902A54
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_SnowTrailComponent_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_SnowTrailComponent_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTrailComponent_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F006 RID: 126982 RVA: 0x009048B8 File Offset: 0x00902AB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SnowTrailComponent(int EntryPoint)
		{
			BP_SnowTrailComponent_C.__ExecuteUbergraph_BP_SnowTrailComponent_FunctionParams* ptr = stackalloc BP_SnowTrailComponent_C.__ExecuteUbergraph_BP_SnowTrailComponent_FunctionParams[(UIntPtr)751] + 15L / (long)sizeof(BP_SnowTrailComponent_C.__ExecuteUbergraph_BP_SnowTrailComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTrailComponent_C.__ExecuteUbergraph_BP_SnowTrailComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTrailComponent_C.__ExecuteUbergraph_BP_SnowTrailComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F007 RID: 126983 RVA: 0x00904902 File Offset: 0x00902B02
		protected BP_SnowTrailComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F536 RID: 62774
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTrailComponent.BP_SnowTrailComponent_C";

		// Token: 0x0400F537 RID: 62775
		private static IntPtr _ClassPtr;

		// Token: 0x0400F538 RID: 62776
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F539 RID: 62777
		internal static int __PropertyOffset_0;

		// Token: 0x0400F53A RID: 62778
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F53B RID: 62779
		internal static int __PropertyOffset_1;

		// Token: 0x0400F53C RID: 62780
		internal static int __PropertyOffset_2;

		// Token: 0x0400F53D RID: 62781
		internal static int __PropertyOffset_3;

		// Token: 0x0400F53E RID: 62782
		internal static int __PropertyOffset_4;

		// Token: 0x0400F53F RID: 62783
		internal static int __PropertyOffset_5;

		// Token: 0x0400F540 RID: 62784
		internal static int __PropertyOffset_6;

		// Token: 0x0400F541 RID: 62785
		internal static int __PropertyOffset_7;

		// Token: 0x0400F542 RID: 62786
		internal static int __PropertyOffset_8;

		// Token: 0x0400F543 RID: 62787
		internal static int __PropertyOffset_9;

		// Token: 0x0400F544 RID: 62788
		internal static int __PropertyOffset_10;

		// Token: 0x0400F545 RID: 62789
		internal static int __PropertyOffset_11;

		// Token: 0x0400F546 RID: 62790
		internal static int __PropertyOffset_12;

		// Token: 0x0400F547 RID: 62791
		internal static int __PropertyOffset_13;

		// Token: 0x0400F548 RID: 62792
		internal static int __PropertyOffset_14;

		// Token: 0x0400F549 RID: 62793
		internal static int __PropertyOffset_15;

		// Token: 0x0400F54A RID: 62794
		internal static int __PropertyOffset_16;

		// Token: 0x0400F54B RID: 62795
		internal static int __PropertyOffset_17;

		// Token: 0x0400F54C RID: 62796
		internal static int __PropertyOffset_18;

		// Token: 0x0400F54D RID: 62797
		[Nullable(2)]
		private TArray<FVectorDouble> _BulletHitList;

		// Token: 0x0400F54E RID: 62798
		internal static int __PropertyOffset_19;

		// Token: 0x0400F54F RID: 62799
		internal static int __PropertyOffset_20;

		// Token: 0x0400F550 RID: 62800
		internal static int __PropertyOffset_21;

		// Token: 0x0400F551 RID: 62801
		internal static int __PropertyOffset_22;

		// Token: 0x0400F552 RID: 62802
		internal static int __PropertyOffset_23;

		// Token: 0x0400F553 RID: 62803
		internal static int __PropertyOffset_24;

		// Token: 0x0400F554 RID: 62804
		private static IntPtr __UpdateDeltaTime_NativeFunctionPtr;

		// Token: 0x0400F555 RID: 62805
		private static IntPtr __CompareNewPointWeapon_NativeFunctionPtr;

		// Token: 0x0400F556 RID: 62806
		private static IntPtr __SnowCollisionEffect_NativeFunctionPtr;

		// Token: 0x0400F557 RID: 62807
		private static IntPtr __SnowCollisionActor_NativeFunctionPtr;

		// Token: 0x0400F558 RID: 62808
		private static IntPtr __SnowCollisionBone_NativeFunctionPtr;

		// Token: 0x0400F559 RID: 62809
		private static IntPtr __RegisterTrailComp_NativeFunctionPtr;

		// Token: 0x0400F55A RID: 62810
		private static IntPtr __FindTrailManager_NativeFunctionPtr;

		// Token: 0x0400F55B RID: 62811
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F55C RID: 62812
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F55D RID: 62813
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x0400F55E RID: 62814
		private static IntPtr __ExecuteUbergraph_BP_SnowTrailComponent_NativeFunctionPtr;

		// Token: 0x02009832 RID: 38962
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __UpdateDeltaTime_FunctionParams
		{
			// Token: 0x04031E58 RID: 204376
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009833 RID: 38963
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __CompareNewPointWeapon_FunctionParams
		{
			// Token: 0x04031E59 RID: 204377
			[FieldOffset(0)]
			public FVectorDouble V2;

			// Token: 0x04031E5A RID: 204378
			[FieldOffset(24)]
			public bool Valid;
		}

		// Token: 0x02009834 RID: 38964
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __SnowCollisionEffect_FunctionParams
		{
			// Token: 0x04031E5B RID: 204379
			[FieldOffset(0)]
			public FVectorDouble AvailablePoint;

			// Token: 0x04031E5C RID: 204380
			[FieldOffset(24)]
			public float TrailRadius;

			// Token: 0x04031E5D RID: 204381
			[FieldOffset(28)]
			public float TrailDepth;
		}

		// Token: 0x02009835 RID: 38965
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __RegisterTrailComp_FunctionParams
		{
			// Token: 0x04031E5E RID: 204382
			[FieldOffset(0)]
			public float Radius;

			// Token: 0x04031E5F RID: 204383
			[FieldOffset(4)]
			public float Depth;

			// Token: 0x04031E60 RID: 204384
			[FieldOffset(8)]
			public float Hardness;

			// Token: 0x04031E61 RID: 204385
			[FieldOffset(12)]
			public float TrailRotation;

			// Token: 0x04031E62 RID: 204386
			[FieldOffset(16)]
			public FVector TrailLocation;
		}

		// Token: 0x02009836 RID: 38966
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E63 RID: 204387
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009837 RID: 38967
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04031E64 RID: 204388
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04031E65 RID: 204389
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04031E66 RID: 204390
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009838 RID: 38968
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 736)]
		protected ref struct __ExecuteUbergraph_BP_SnowTrailComponent_FunctionParams
		{
			// Token: 0x04031E67 RID: 204391
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
