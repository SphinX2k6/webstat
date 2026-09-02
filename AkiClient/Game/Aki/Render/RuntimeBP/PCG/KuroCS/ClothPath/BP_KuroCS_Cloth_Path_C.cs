using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.ClothPath
{
	// Token: 0x02003C02 RID: 15362
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/BP_KuroCS_Cloth_Path.BP_KuroCS_Cloth_Path_C")]
	[UnrealStructLayout(1584, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1578)]
	public class BP_KuroCS_Cloth_Path_C : AKuroCS_Cloth_Path, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022CB9 RID: 142521 RVA: 0x0096F3C4 File Offset: 0x0096D5C4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCS_Cloth_Path_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/BP_KuroCS_Cloth_Path.BP_KuroCS_Cloth_Path_C");
			}
			return BP_KuroCS_Cloth_Path_C._ClassPtr;
		}

		// Token: 0x06022CBA RID: 142522 RVA: 0x0096F3E8 File Offset: 0x0096D5E8
		public BP_KuroCS_Cloth_Path_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCS_Cloth_Path_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022CBB RID: 142523 RVA: 0x0096F410 File Offset: 0x0096D610
		public BP_KuroCS_Cloth_Path_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCS_Cloth_Path_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170042C6 RID: 17094
		// (get) Token: 0x06022CBC RID: 142524 RVA: 0x0096F444 File Offset: 0x0096D644
		// (set) Token: 0x06022CBD RID: 142525 RVA: 0x0096F47D File Offset: 0x0096D67D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170042C7 RID: 17095
		// (get) Token: 0x06022CBE RID: 142526 RVA: 0x0096F49E File Offset: 0x0096D69E
		// (set) Token: 0x06022CBF RID: 142527 RVA: 0x0096F4B2 File Offset: 0x0096D6B2
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170042C8 RID: 17096
		// (get) Token: 0x06022CC0 RID: 142528 RVA: 0x0096F4C7 File Offset: 0x0096D6C7
		// (set) Token: 0x06022CC1 RID: 142529 RVA: 0x0096F4DB File Offset: 0x0096D6DB
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170042C9 RID: 17097
		// (get) Token: 0x06022CC2 RID: 142530 RVA: 0x0096F4F0 File Offset: 0x0096D6F0
		// (set) Token: 0x06022CC3 RID: 142531 RVA: 0x0096F504 File Offset: 0x0096D704
		[Nullable(2)]
		public unsafe UDataTable DataTable
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170042CA RID: 17098
		// (get) Token: 0x06022CC4 RID: 142532 RVA: 0x0096F51C File Offset: 0x0096D71C
		// (set) Token: 0x06022CC5 RID: 142533 RVA: 0x0096F555 File Offset: 0x0096D755
		public TArray<UMaterialInstanceDynamic> Mats
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Mats) == null)
				{
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x170042CB RID: 17099
		// (get) Token: 0x06022CC6 RID: 142534 RVA: 0x0096F563 File Offset: 0x0096D763
		// (set) Token: 0x06022CC7 RID: 142535 RVA: 0x0096F573 File Offset: 0x0096D773
		public unsafe bool bXueyuanBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042CC RID: 17100
		// (get) Token: 0x06022CC8 RID: 142536 RVA: 0x0096F584 File Offset: 0x0096D784
		// (set) Token: 0x06022CC9 RID: 142537 RVA: 0x0096F594 File Offset: 0x0096D794
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042CD RID: 17101
		// (get) Token: 0x06022CCA RID: 142538 RVA: 0x0096F5A5 File Offset: 0x0096D7A5
		// (set) Token: 0x06022CCB RID: 142539 RVA: 0x0096F5B9 File Offset: 0x0096D7B9
		[Nullable(2)]
		public unsafe UTextureRenderTarget2D RT_pos
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170042CE RID: 17102
		// (get) Token: 0x06022CCC RID: 142540 RVA: 0x0096F5CE File Offset: 0x0096D7CE
		// (set) Token: 0x06022CCD RID: 142541 RVA: 0x0096F5E2 File Offset: 0x0096D7E2
		[Nullable(2)]
		public unsafe UTextureRenderTarget2D RT_normal
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCS_Cloth_Path_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170042CF RID: 17103
		// (get) Token: 0x06022CCE RID: 142542 RVA: 0x0096F5F7 File Offset: 0x0096D7F7
		// (set) Token: 0x06022CCF RID: 142543 RVA: 0x0096F607 File Offset: 0x0096D807
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042D0 RID: 17104
		// (get) Token: 0x06022CD0 RID: 142544 RVA: 0x0096F618 File Offset: 0x0096D818
		// (set) Token: 0x06022CD1 RID: 142545 RVA: 0x0096F628 File Offset: 0x0096D828
		public unsafe float CollisionWorld
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170042D1 RID: 17105
		// (get) Token: 0x06022CD2 RID: 142546 RVA: 0x0096F63C File Offset: 0x0096D83C
		// (set) Token: 0x06022CD3 RID: 142547 RVA: 0x0096F675 File Offset: 0x0096D875
		public TMap<TSoftObjectPtr<UStaticMesh>, S_KuroCSClothPath> Preset
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, S_KuroCSClothPath> result;
				if ((result = this._Preset) == null)
				{
					result = (this._Preset = new TMap<TSoftObjectPtr<UStaticMesh>, S_KuroCSClothPath>(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.Preset.CopyAssign(value);
			}
		}

		// Token: 0x170042D2 RID: 17106
		// (get) Token: 0x06022CD4 RID: 142548 RVA: 0x0096F683 File Offset: 0x0096D883
		// (set) Token: 0x06022CD5 RID: 142549 RVA: 0x0096F693 File Offset: 0x0096D893
		public unsafe bool bReadFromPreset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042D3 RID: 17107
		// (get) Token: 0x06022CD6 RID: 142550 RVA: 0x0096F6A4 File Offset: 0x0096D8A4
		// (set) Token: 0x06022CD7 RID: 142551 RVA: 0x0096F6B4 File Offset: 0x0096D8B4
		public unsafe bool bFadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042D4 RID: 17108
		// (get) Token: 0x06022CD8 RID: 142552 RVA: 0x0096F6C5 File Offset: 0x0096D8C5
		// (set) Token: 0x06022CD9 RID: 142553 RVA: 0x0096F6D5 File Offset: 0x0096D8D5
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170042D5 RID: 17109
		// (get) Token: 0x06022CDA RID: 142554 RVA: 0x0096F6E6 File Offset: 0x0096D8E6
		// (set) Token: 0x06022CDB RID: 142555 RVA: 0x0096F6F6 File Offset: 0x0096D8F6
		public unsafe bool bStopSim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042D6 RID: 17110
		// (get) Token: 0x06022CDC RID: 142556 RVA: 0x0096F707 File Offset: 0x0096D907
		// (set) Token: 0x06022CDD RID: 142557 RVA: 0x0096F717 File Offset: 0x0096D917
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042D7 RID: 17111
		// (get) Token: 0x06022CDE RID: 142558 RVA: 0x0096F728 File Offset: 0x0096D928
		// (set) Token: 0x06022CDF RID: 142559 RVA: 0x0096F738 File Offset: 0x0096D938
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042D8 RID: 17112
		// (get) Token: 0x06022CE0 RID: 142560 RVA: 0x0096F74C File Offset: 0x0096D94C
		// (set) Token: 0x06022CE1 RID: 142561 RVA: 0x0096F785 File Offset: 0x0096D985
		public TMap<FName, float> Scalar_Parameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170042D9 RID: 17113
		// (get) Token: 0x06022CE2 RID: 142562 RVA: 0x0096F794 File Offset: 0x0096D994
		// (set) Token: 0x06022CE3 RID: 142563 RVA: 0x0096F7CD File Offset: 0x0096D9CD
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170042DA RID: 17114
		// (get) Token: 0x06022CE4 RID: 142564 RVA: 0x0096F7DC File Offset: 0x0096D9DC
		// (set) Token: 0x06022CE5 RID: 142565 RVA: 0x0096F815 File Offset: 0x0096DA15
		public TMap<FName, UTexture> Texture_Parameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170042DB RID: 17115
		// (get) Token: 0x06022CE6 RID: 142566 RVA: 0x0096F823 File Offset: 0x0096DA23
		// (set) Token: 0x06022CE7 RID: 142567 RVA: 0x0096F833 File Offset: 0x0096DA33
		public unsafe bool bAfterBeginplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042DC RID: 17116
		// (get) Token: 0x06022CE8 RID: 142568 RVA: 0x0096F844 File Offset: 0x0096DA44
		// (set) Token: 0x06022CE9 RID: 142569 RVA: 0x0096F854 File Offset: 0x0096DA54
		public unsafe bool SkipConstruction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCS_Cloth_Path_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022CEA RID: 142570 RVA: 0x0096F865 File Offset: 0x0096DA65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CheckLength()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__CheckLength_NativeFunctionPtr, null);
		}

		// Token: 0x06022CEB RID: 142571 RVA: 0x0096F879 File Offset: 0x0096DA79
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReadFromDT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__ReadFromDT_NativeFunctionPtr, null);
		}

		// Token: 0x06022CEC RID: 142572 RVA: 0x0096F88D File Offset: 0x0096DA8D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__UpdateMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x06022CED RID: 142573 RVA: 0x0096F8A1 File Offset: 0x0096DAA1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022CEE RID: 142574 RVA: 0x0096F8B5 File Offset: 0x0096DAB5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022CEF RID: 142575 RVA: 0x0096F8C9 File Offset: 0x0096DAC9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitDataFromPreset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__InitDataFromPreset_NativeFunctionPtr, null);
		}

		// Token: 0x06022CF0 RID: 142576 RVA: 0x0096F8DD File Offset: 0x0096DADD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06022CF1 RID: 142577 RVA: 0x0096F8F1 File Offset: 0x0096DAF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06022CF2 RID: 142578 RVA: 0x0096F905 File Offset: 0x0096DB05
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022CF3 RID: 142579 RVA: 0x0096F919 File Offset: 0x0096DB19
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022CF4 RID: 142580 RVA: 0x0096F92E File Offset: 0x0096DB2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022CF5 RID: 142581 RVA: 0x0096F942 File Offset: 0x0096DB42
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022CF6 RID: 142582 RVA: 0x0096F958 File Offset: 0x0096DB58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCS_Cloth_Path_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCS_Cloth_Path_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCS_Cloth_Path_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Cloth_Path_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022CF7 RID: 142583 RVA: 0x0096F9A0 File Offset: 0x0096DBA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCS_Cloth_Path_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCS_Cloth_Path_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCS_Cloth_Path_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Cloth_Path_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022CF8 RID: 142584 RVA: 0x0096F9E8 File Offset: 0x0096DBE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022CF9 RID: 142585 RVA: 0x0096FA34 File Offset: 0x0096DC34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022CFA RID: 142586 RVA: 0x0096FA80 File Offset: 0x0096DC80
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022CFB RID: 142587 RVA: 0x0096FB3C File Offset: 0x0096DD3C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022CFC RID: 142588 RVA: 0x0096FBC8 File Offset: 0x0096DDC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCS_Cloth_Path(int EntryPoint)
		{
			BP_KuroCS_Cloth_Path_C.__ExecuteUbergraph_BP_KuroCS_Cloth_Path_FunctionParams* ptr = stackalloc BP_KuroCS_Cloth_Path_C.__ExecuteUbergraph_BP_KuroCS_Cloth_Path_FunctionParams[(UIntPtr)1599] + 15L / (long)sizeof(BP_KuroCS_Cloth_Path_C.__ExecuteUbergraph_BP_KuroCS_Cloth_Path_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCS_Cloth_Path_C.__ExecuteUbergraph_BP_KuroCS_Cloth_Path_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCS_Cloth_Path_C.__ExecuteUbergraph_BP_KuroCS_Cloth_Path_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022CFD RID: 142589 RVA: 0x0096FC12 File Offset: 0x0096DE12
		protected BP_KuroCS_Cloth_Path_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011A69 RID: 72297
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/BP_KuroCS_Cloth_Path.BP_KuroCS_Cloth_Path_C";

		// Token: 0x04011A6A RID: 72298
		private static IntPtr _ClassPtr;

		// Token: 0x04011A6B RID: 72299
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011A6C RID: 72300
		internal static int __PropertyOffset_0;

		// Token: 0x04011A6D RID: 72301
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011A6E RID: 72302
		internal static int __PropertyOffset_1;

		// Token: 0x04011A6F RID: 72303
		internal static int __PropertyOffset_2;

		// Token: 0x04011A70 RID: 72304
		internal static int __PropertyOffset_3;

		// Token: 0x04011A71 RID: 72305
		internal static int __PropertyOffset_4;

		// Token: 0x04011A72 RID: 72306
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011A73 RID: 72307
		internal static int __PropertyOffset_5;

		// Token: 0x04011A74 RID: 72308
		internal static int __PropertyOffset_6;

		// Token: 0x04011A75 RID: 72309
		internal static int __PropertyOffset_7;

		// Token: 0x04011A76 RID: 72310
		internal static int __PropertyOffset_8;

		// Token: 0x04011A77 RID: 72311
		internal static int __PropertyOffset_9;

		// Token: 0x04011A78 RID: 72312
		internal static int __PropertyOffset_10;

		// Token: 0x04011A79 RID: 72313
		internal static int __PropertyOffset_11;

		// Token: 0x04011A7A RID: 72314
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, S_KuroCSClothPath> _Preset;

		// Token: 0x04011A7B RID: 72315
		internal static int __PropertyOffset_12;

		// Token: 0x04011A7C RID: 72316
		internal static int __PropertyOffset_13;

		// Token: 0x04011A7D RID: 72317
		internal static int __PropertyOffset_14;

		// Token: 0x04011A7E RID: 72318
		internal static int __PropertyOffset_15;

		// Token: 0x04011A7F RID: 72319
		internal static int __PropertyOffset_16;

		// Token: 0x04011A80 RID: 72320
		internal static int __PropertyOffset_17;

		// Token: 0x04011A81 RID: 72321
		internal static int __PropertyOffset_18;

		// Token: 0x04011A82 RID: 72322
		[Nullable(2)]
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x04011A83 RID: 72323
		internal static int __PropertyOffset_19;

		// Token: 0x04011A84 RID: 72324
		[Nullable(2)]
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x04011A85 RID: 72325
		internal static int __PropertyOffset_20;

		// Token: 0x04011A86 RID: 72326
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x04011A87 RID: 72327
		internal static int __PropertyOffset_21;

		// Token: 0x04011A88 RID: 72328
		internal static int __PropertyOffset_22;

		// Token: 0x04011A89 RID: 72329
		private static IntPtr __CheckLength_NativeFunctionPtr;

		// Token: 0x04011A8A RID: 72330
		private static IntPtr __ReadFromDT_NativeFunctionPtr;

		// Token: 0x04011A8B RID: 72331
		private static IntPtr __UpdateMaterialParams_NativeFunctionPtr;

		// Token: 0x04011A8C RID: 72332
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x04011A8D RID: 72333
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04011A8E RID: 72334
		private static IntPtr __InitDataFromPreset_NativeFunctionPtr;

		// Token: 0x04011A8F RID: 72335
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011A90 RID: 72336
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011A91 RID: 72337
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011A92 RID: 72338
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011A93 RID: 72339
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011A94 RID: 72340
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011A95 RID: 72341
		private static IntPtr __BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011A96 RID: 72342
		private static IntPtr __BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011A97 RID: 72343
		private static IntPtr __ExecuteUbergraph_BP_KuroCS_Cloth_Path_NativeFunctionPtr;

		// Token: 0x02009C2D RID: 39981
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040324AF RID: 205999
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C2E RID: 39982
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040324B0 RID: 206000
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C2F RID: 39983
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324B1 RID: 206001
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324B2 RID: 206002
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324B3 RID: 206003
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324B4 RID: 206004
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040324B5 RID: 206005
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040324B6 RID: 206006
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C30 RID: 39984
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCS_Cloth_Path_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324B7 RID: 206007
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324B8 RID: 206008
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324B9 RID: 206009
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324BA RID: 206010
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C31 RID: 39985
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1584)]
		protected ref struct __ExecuteUbergraph_BP_KuroCS_Cloth_Path_FunctionParams
		{
			// Token: 0x040324BB RID: 206011
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
