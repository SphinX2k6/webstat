using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.TreeSkinBreak.BluePrint
{
	// Token: 0x02003B62 RID: 15202
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/TreeSkinBreak/BluePrint/BP_TreeSkinBreak.BP_TreeSkinBreak_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class BP_TreeSkinBreak_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021610 RID: 136720 RVA: 0x0094767F File Offset: 0x0094587F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TreeSkinBreak_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/TreeSkinBreak/BluePrint/BP_TreeSkinBreak.BP_TreeSkinBreak_C");
			}
			return BP_TreeSkinBreak_C._ClassPtr;
		}

		// Token: 0x06021611 RID: 136721 RVA: 0x009476A4 File Offset: 0x009458A4
		public BP_TreeSkinBreak_C() : this(BuiltinUtils.AllocNativeUObject(BP_TreeSkinBreak_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021612 RID: 136722 RVA: 0x009476CC File Offset: 0x009458CC
		[NullableContext(1)]
		public BP_TreeSkinBreak_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TreeSkinBreak_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003AD9 RID: 15065
		// (get) Token: 0x06021613 RID: 136723 RVA: 0x00947700 File Offset: 0x00945900
		// (set) Token: 0x06021614 RID: 136724 RVA: 0x00947739 File Offset: 0x00945939
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003ADA RID: 15066
		// (get) Token: 0x06021615 RID: 136725 RVA: 0x0094775A File Offset: 0x0094595A
		// (set) Token: 0x06021616 RID: 136726 RVA: 0x0094776E File Offset: 0x0094596E
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003ADB RID: 15067
		// (get) Token: 0x06021617 RID: 136727 RVA: 0x00947783 File Offset: 0x00945983
		// (set) Token: 0x06021618 RID: 136728 RVA: 0x00947797 File Offset: 0x00945997
		public unsafe UStaticMeshComponent SM_Tree
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003ADC RID: 15068
		// (get) Token: 0x06021619 RID: 136729 RVA: 0x009477AC File Offset: 0x009459AC
		// (set) Token: 0x0602161A RID: 136730 RVA: 0x009477C0 File Offset: 0x009459C0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003ADD RID: 15069
		// (get) Token: 0x0602161B RID: 136731 RVA: 0x009477D5 File Offset: 0x009459D5
		// (set) Token: 0x0602161C RID: 136732 RVA: 0x009477E5 File Offset: 0x009459E5
		public unsafe float HitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003ADE RID: 15070
		// (get) Token: 0x0602161D RID: 136733 RVA: 0x009477F6 File Offset: 0x009459F6
		// (set) Token: 0x0602161E RID: 136734 RVA: 0x00947806 File Offset: 0x00945A06
		public unsafe float TraceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003ADF RID: 15071
		// (get) Token: 0x0602161F RID: 136735 RVA: 0x00947817 File Offset: 0x00945A17
		// (set) Token: 0x06021620 RID: 136736 RVA: 0x0094782B File Offset: 0x00945A2B
		public unsafe FVector LastWeaponPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003AE0 RID: 15072
		// (get) Token: 0x06021621 RID: 136737 RVA: 0x00947840 File Offset: 0x00945A40
		// (set) Token: 0x06021622 RID: 136738 RVA: 0x00947850 File Offset: 0x00945A50
		public unsafe bool DebugBreak
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003AE1 RID: 15073
		// (get) Token: 0x06021623 RID: 136739 RVA: 0x00947861 File Offset: 0x00945A61
		// (set) Token: 0x06021624 RID: 136740 RVA: 0x00947871 File Offset: 0x00945A71
		public unsafe bool DebugEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003AE2 RID: 15074
		// (get) Token: 0x06021625 RID: 136741 RVA: 0x00947882 File Offset: 0x00945A82
		// (set) Token: 0x06021626 RID: 136742 RVA: 0x00947892 File Offset: 0x00945A92
		public unsafe float SpeedThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003AE3 RID: 15075
		// (get) Token: 0x06021627 RID: 136743 RVA: 0x009478A3 File Offset: 0x00945AA3
		// (set) Token: 0x06021628 RID: 136744 RVA: 0x009478B3 File Offset: 0x00945AB3
		public unsafe bool LastPointUseAble
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003AE4 RID: 15076
		// (get) Token: 0x06021629 RID: 136745 RVA: 0x009478C4 File Offset: 0x00945AC4
		// (set) Token: 0x0602162A RID: 136746 RVA: 0x009478D8 File Offset: 0x00945AD8
		public unsafe UMaterialInstanceDynamic StampMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003AE5 RID: 15077
		// (get) Token: 0x0602162B RID: 136747 RVA: 0x009478ED File Offset: 0x00945AED
		// (set) Token: 0x0602162C RID: 136748 RVA: 0x00947901 File Offset: 0x00945B01
		public unsafe UMaterialInstanceDynamic TreeSkinMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003AE6 RID: 15078
		// (get) Token: 0x0602162D RID: 136749 RVA: 0x00947916 File Offset: 0x00945B16
		// (set) Token: 0x0602162E RID: 136750 RVA: 0x0094792A File Offset: 0x00945B2A
		public unsafe UStaticMesh SMTree
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003AE7 RID: 15079
		// (get) Token: 0x0602162F RID: 136751 RVA: 0x0094793F File Offset: 0x00945B3F
		// (set) Token: 0x06021630 RID: 136752 RVA: 0x00947953 File Offset: 0x00945B53
		public unsafe UMaterialInterface TreeSkinMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003AE8 RID: 15080
		// (get) Token: 0x06021631 RID: 136753 RVA: 0x00947968 File Offset: 0x00945B68
		// (set) Token: 0x06021632 RID: 136754 RVA: 0x00947978 File Offset: 0x00945B78
		public unsafe int TreeMatIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003AE9 RID: 15081
		// (get) Token: 0x06021633 RID: 136755 RVA: 0x00947989 File Offset: 0x00945B89
		// (set) Token: 0x06021634 RID: 136756 RVA: 0x0094799D File Offset: 0x00945B9D
		public unsafe UTexture2D TreePosTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003AEA RID: 15082
		// (get) Token: 0x06021635 RID: 136757 RVA: 0x009479B2 File Offset: 0x00945BB2
		// (set) Token: 0x06021636 RID: 136758 RVA: 0x009479C6 File Offset: 0x00945BC6
		public unsafe UNiagaraSystem NiagaraFX
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003AEB RID: 15083
		// (get) Token: 0x06021637 RID: 136759 RVA: 0x009479DB File Offset: 0x00945BDB
		// (set) Token: 0x06021638 RID: 136760 RVA: 0x009479EF File Offset: 0x00945BEF
		public unsafe UTextureRenderTarget2D SkinMaskRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003AEC RID: 15084
		// (get) Token: 0x06021639 RID: 136761 RVA: 0x00947A04 File Offset: 0x00945C04
		// (set) Token: 0x0602163A RID: 136762 RVA: 0x00947A14 File Offset: 0x00945C14
		public unsafe float VFXSpawnTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003AED RID: 15085
		// (get) Token: 0x0602163B RID: 136763 RVA: 0x00947A25 File Offset: 0x00945C25
		// (set) Token: 0x0602163C RID: 136764 RVA: 0x00947A35 File Offset: 0x00945C35
		public unsafe float SwordRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003AEE RID: 15086
		// (get) Token: 0x0602163D RID: 136765 RVA: 0x00947A46 File Offset: 0x00945C46
		// (set) Token: 0x0602163E RID: 136766 RVA: 0x00947A56 File Offset: 0x00945C56
		public unsafe float KnifeRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003AEF RID: 15087
		// (get) Token: 0x0602163F RID: 136767 RVA: 0x00947A67 File Offset: 0x00945C67
		// (set) Token: 0x06021640 RID: 136768 RVA: 0x00947A77 File Offset: 0x00945C77
		public unsafe float WeaponRadius2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003AF0 RID: 15088
		// (get) Token: 0x06021641 RID: 136769 RVA: 0x00947A88 File Offset: 0x00945C88
		// (set) Token: 0x06021642 RID: 136770 RVA: 0x00947A98 File Offset: 0x00945C98
		public unsafe float BulletRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003AF1 RID: 15089
		// (get) Token: 0x06021643 RID: 136771 RVA: 0x00947AA9 File Offset: 0x00945CA9
		// (set) Token: 0x06021644 RID: 136772 RVA: 0x00947ABD File Offset: 0x00945CBD
		public unsafe BP_SceneBattleInteract_C SceneInteractConf
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneBattleInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TreeSkinBreak_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003AF2 RID: 15090
		// (get) Token: 0x06021645 RID: 136773 RVA: 0x00947AD2 File Offset: 0x00945CD2
		// (set) Token: 0x06021646 RID: 136774 RVA: 0x00947AE6 File Offset: 0x00945CE6
		public unsafe FVector LastWeaponP1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003AF3 RID: 15091
		// (get) Token: 0x06021647 RID: 136775 RVA: 0x00947AFB File Offset: 0x00945CFB
		// (set) Token: 0x06021648 RID: 136776 RVA: 0x00947B0F File Offset: 0x00945D0F
		public unsafe FVector LastWeaponP2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TreeSkinBreak_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x06021649 RID: 136777 RVA: 0x00947B24 File Offset: 0x00945D24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLastPosition(int Index, ref FVector NewParam1)
		{
			BP_TreeSkinBreak_C.__GetLastPosition_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__GetLastPosition_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__GetLastPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__GetLastPosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Index = Index;
			ptr->NewParam1 = NewParam1;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__GetLastPosition_NativeFunctionPtr, (void*)ptr);
			NewParam1 = ptr->NewParam1;
		}

		// Token: 0x0602164A RID: 136778 RVA: 0x00947B84 File Offset: 0x00945D84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DrawBreakTrail(FVector CurrPos, FVector PrevPos, float Radius)
		{
			BP_TreeSkinBreak_C.__DrawBreakTrail_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__DrawBreakTrail_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__DrawBreakTrail_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__DrawBreakTrail_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurrPos = CurrPos;
			ptr->PrevPos = PrevPos;
			ptr->Radius = Radius;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__DrawBreakTrail_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602164B RID: 136779 RVA: 0x00947BDC File Offset: 0x00945DDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLastPosition(int Index, FVector HitPos)
		{
			BP_TreeSkinBreak_C.__SetLastPosition_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__SetLastPosition_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__SetLastPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__SetLastPosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Index = Index;
			ptr->HitPos = HitPos;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__SetLastPosition_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602164C RID: 136780 RVA: 0x00947C29 File Offset: 0x00945E29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x0602164D RID: 136781 RVA: 0x00947C3D File Offset: 0x00945E3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602164E RID: 136782 RVA: 0x00947C51 File Offset: 0x00945E51
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TreeSkinBreak_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602164F RID: 136783 RVA: 0x00947C68 File Offset: 0x00945E68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_48399B0741DF29F7DA29A6AB705C74E1(int PlayingID)
		{
			BP_TreeSkinBreak_C.__Completed_48399B0741DF29F7DA29A6AB705C74E1_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__Completed_48399B0741DF29F7DA29A6AB705C74E1_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__Completed_48399B0741DF29F7DA29A6AB705C74E1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__Completed_48399B0741DF29F7DA29A6AB705C74E1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__Completed_48399B0741DF29F7DA29A6AB705C74E1_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021650 RID: 136784 RVA: 0x00947CB0 File Offset: 0x00945EB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_TreeSkinBreak_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021651 RID: 136785 RVA: 0x00947D14 File Offset: 0x00945F14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021652 RID: 136786 RVA: 0x00947DD0 File Offset: 0x00945FD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021653 RID: 136787 RVA: 0x00947E5C File Offset: 0x0094605C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_TreeSkinBreak_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021654 RID: 136788 RVA: 0x00947EA8 File Offset: 0x009460A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_TreeSkinBreak_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TreeSkinBreak_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021655 RID: 136789 RVA: 0x00947EF4 File Offset: 0x009460F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TreeSkinBreak_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021656 RID: 136790 RVA: 0x00947F08 File Offset: 0x00946108
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TreeSkinBreak_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021657 RID: 136791 RVA: 0x00947F20 File Offset: 0x00946120
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TreeSkinBreak(int EntryPoint)
		{
			BP_TreeSkinBreak_C.__ExecuteUbergraph_BP_TreeSkinBreak_FunctionParams* ptr = stackalloc BP_TreeSkinBreak_C.__ExecuteUbergraph_BP_TreeSkinBreak_FunctionParams[(UIntPtr)1199] + 15L / (long)sizeof(BP_TreeSkinBreak_C.__ExecuteUbergraph_BP_TreeSkinBreak_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TreeSkinBreak_C.__ExecuteUbergraph_BP_TreeSkinBreak_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TreeSkinBreak_C.__ExecuteUbergraph_BP_TreeSkinBreak_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021658 RID: 136792 RVA: 0x00947F6A File Offset: 0x0094616A
		protected BP_TreeSkinBreak_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010CCC RID: 68812
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/TreeSkinBreak/BluePrint/BP_TreeSkinBreak.BP_TreeSkinBreak_C";

		// Token: 0x04010CCD RID: 68813
		private static IntPtr _ClassPtr;

		// Token: 0x04010CCE RID: 68814
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010CCF RID: 68815
		internal static int __PropertyOffset_0;

		// Token: 0x04010CD0 RID: 68816
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010CD1 RID: 68817
		internal static int __PropertyOffset_1;

		// Token: 0x04010CD2 RID: 68818
		internal static int __PropertyOffset_2;

		// Token: 0x04010CD3 RID: 68819
		internal static int __PropertyOffset_3;

		// Token: 0x04010CD4 RID: 68820
		internal static int __PropertyOffset_4;

		// Token: 0x04010CD5 RID: 68821
		internal static int __PropertyOffset_5;

		// Token: 0x04010CD6 RID: 68822
		internal static int __PropertyOffset_6;

		// Token: 0x04010CD7 RID: 68823
		internal static int __PropertyOffset_7;

		// Token: 0x04010CD8 RID: 68824
		internal static int __PropertyOffset_8;

		// Token: 0x04010CD9 RID: 68825
		internal static int __PropertyOffset_9;

		// Token: 0x04010CDA RID: 68826
		internal static int __PropertyOffset_10;

		// Token: 0x04010CDB RID: 68827
		internal static int __PropertyOffset_11;

		// Token: 0x04010CDC RID: 68828
		internal static int __PropertyOffset_12;

		// Token: 0x04010CDD RID: 68829
		internal static int __PropertyOffset_13;

		// Token: 0x04010CDE RID: 68830
		internal static int __PropertyOffset_14;

		// Token: 0x04010CDF RID: 68831
		internal static int __PropertyOffset_15;

		// Token: 0x04010CE0 RID: 68832
		internal static int __PropertyOffset_16;

		// Token: 0x04010CE1 RID: 68833
		internal static int __PropertyOffset_17;

		// Token: 0x04010CE2 RID: 68834
		internal static int __PropertyOffset_18;

		// Token: 0x04010CE3 RID: 68835
		internal static int __PropertyOffset_19;

		// Token: 0x04010CE4 RID: 68836
		internal static int __PropertyOffset_20;

		// Token: 0x04010CE5 RID: 68837
		internal static int __PropertyOffset_21;

		// Token: 0x04010CE6 RID: 68838
		internal static int __PropertyOffset_22;

		// Token: 0x04010CE7 RID: 68839
		internal static int __PropertyOffset_23;

		// Token: 0x04010CE8 RID: 68840
		internal static int __PropertyOffset_24;

		// Token: 0x04010CE9 RID: 68841
		internal static int __PropertyOffset_25;

		// Token: 0x04010CEA RID: 68842
		internal static int __PropertyOffset_26;

		// Token: 0x04010CEB RID: 68843
		private static IntPtr __GetLastPosition_NativeFunctionPtr;

		// Token: 0x04010CEC RID: 68844
		private static IntPtr __DrawBreakTrail_NativeFunctionPtr;

		// Token: 0x04010CED RID: 68845
		private static IntPtr __SetLastPosition_NativeFunctionPtr;

		// Token: 0x04010CEE RID: 68846
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x04010CEF RID: 68847
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010CF0 RID: 68848
		private static IntPtr __Completed_48399B0741DF29F7DA29A6AB705C74E1_NativeFunctionPtr;

		// Token: 0x04010CF1 RID: 68849
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04010CF2 RID: 68850
		private static IntPtr __BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010CF3 RID: 68851
		private static IntPtr __BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010CF4 RID: 68852
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010CF5 RID: 68853
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010CF6 RID: 68854
		private static IntPtr __ExecuteUbergraph_BP_TreeSkinBreak_NativeFunctionPtr;

		// Token: 0x02009AC1 RID: 39617
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __GetLastPosition_FunctionParams
		{
			// Token: 0x04032237 RID: 205367
			[FieldOffset(0)]
			public int Index;

			// Token: 0x04032238 RID: 205368
			[FieldOffset(4)]
			public FVector NewParam1;
		}

		// Token: 0x02009AC2 RID: 39618
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __DrawBreakTrail_FunctionParams
		{
			// Token: 0x04032239 RID: 205369
			[FieldOffset(0)]
			public FVector CurrPos;

			// Token: 0x0403223A RID: 205370
			[FieldOffset(12)]
			public FVector PrevPos;

			// Token: 0x0403223B RID: 205371
			[FieldOffset(24)]
			public float Radius;
		}

		// Token: 0x02009AC3 RID: 39619
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __SetLastPosition_FunctionParams
		{
			// Token: 0x0403223C RID: 205372
			[FieldOffset(0)]
			public int Index;

			// Token: 0x0403223D RID: 205373
			[FieldOffset(4)]
			public FVector HitPos;
		}

		// Token: 0x02009AC4 RID: 39620
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_48399B0741DF29F7DA29A6AB705C74E1_FunctionParams
		{
			// Token: 0x0403223E RID: 205374
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AC5 RID: 39621
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x0403223F RID: 205375
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032240 RID: 205376
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032241 RID: 205377
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009AC6 RID: 39622
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032242 RID: 205378
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032243 RID: 205379
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032244 RID: 205380
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032245 RID: 205381
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032246 RID: 205382
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032247 RID: 205383
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009AC7 RID: 39623
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_TreeSkinBreak_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032248 RID: 205384
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032249 RID: 205385
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403224A RID: 205386
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403224B RID: 205387
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009AC8 RID: 39624
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403224C RID: 205388
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009AC9 RID: 39625
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1184)]
		protected ref struct __ExecuteUbergraph_BP_TreeSkinBreak_FunctionParams
		{
			// Token: 0x0403224D RID: 205389
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
