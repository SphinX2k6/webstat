using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab.Struction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab
{
	// Token: 0x02003BDA RID: 15322
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/BP_LightPrefab.BP_LightPrefab_C")]
	[UnrealStructLayout(4904, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4897)]
	public class BP_LightPrefab_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602260A RID: 140810 RVA: 0x00963E30 File Offset: 0x00962030
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LightPrefab_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/BP_LightPrefab.BP_LightPrefab_C");
			}
			return BP_LightPrefab_C._ClassPtr;
		}

		// Token: 0x0602260B RID: 140811 RVA: 0x00963E54 File Offset: 0x00962054
		public BP_LightPrefab_C() : this(BuiltinUtils.AllocNativeUObject(BP_LightPrefab_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602260C RID: 140812 RVA: 0x00963E7C File Offset: 0x0096207C
		public BP_LightPrefab_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LightPrefab_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004073 RID: 16499
		// (get) Token: 0x0602260D RID: 140813 RVA: 0x00963EB0 File Offset: 0x009620B0
		// (set) Token: 0x0602260E RID: 140814 RVA: 0x00963EE9 File Offset: 0x009620E9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004074 RID: 16500
		// (get) Token: 0x0602260F RID: 140815 RVA: 0x00963F0A File Offset: 0x0096210A
		// (set) Token: 0x06022610 RID: 140816 RVA: 0x00963F1E File Offset: 0x0096211E
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004075 RID: 16501
		// (get) Token: 0x06022611 RID: 140817 RVA: 0x00963F33 File Offset: 0x00962133
		// (set) Token: 0x06022612 RID: 140818 RVA: 0x00963F47 File Offset: 0x00962147
		[Nullable(2)]
		public unsafe UArrowComponent LightPrefabArrow
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004076 RID: 16502
		// (get) Token: 0x06022613 RID: 140819 RVA: 0x00963F5C File Offset: 0x0096215C
		// (set) Token: 0x06022614 RID: 140820 RVA: 0x00963F70 File Offset: 0x00962170
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004077 RID: 16503
		// (get) Token: 0x06022615 RID: 140821 RVA: 0x00963F85 File Offset: 0x00962185
		// (set) Token: 0x06022616 RID: 140822 RVA: 0x00963F95 File Offset: 0x00962195
		public unsafe bool 工具同步
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004078 RID: 16504
		// (get) Token: 0x06022617 RID: 140823 RVA: 0x00963FA6 File Offset: 0x009621A6
		// (set) Token: 0x06022618 RID: 140824 RVA: 0x00963FB6 File Offset: 0x009621B6
		public unsafe bool TOD同步
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004079 RID: 16505
		// (get) Token: 0x06022619 RID: 140825 RVA: 0x00963FC7 File Offset: 0x009621C7
		// (set) Token: 0x0602261A RID: 140826 RVA: 0x00963FD7 File Offset: 0x009621D7
		public unsafe float TOD同步频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700407A RID: 16506
		// (get) Token: 0x0602261B RID: 140827 RVA: 0x00963FE8 File Offset: 0x009621E8
		// (set) Token: 0x0602261C RID: 140828 RVA: 0x00964021 File Offset: 0x00962221
		public PCG_LightPrefab_Light 灯光
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Light result;
				if ((result = this._灯光) == null)
				{
					result = (this._灯光 = new PCG_LightPrefab_Light(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Light.StaticStruct(), base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700407B RID: 16507
		// (get) Token: 0x0602261D RID: 140829 RVA: 0x00964044 File Offset: 0x00962244
		// (set) Token: 0x0602261E RID: 140830 RVA: 0x0096407D File Offset: 0x0096227D
		public PCG_LightPrefab_Mesh 模型
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Mesh result;
				if ((result = this._模型) == null)
				{
					result = (this._模型 = new PCG_LightPrefab_Mesh(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Mesh.StaticStruct(), base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700407C RID: 16508
		// (get) Token: 0x0602261F RID: 140831 RVA: 0x009640A0 File Offset: 0x009622A0
		// (set) Token: 0x06022620 RID: 140832 RVA: 0x009640D9 File Offset: 0x009622D9
		public PCG_LightPrefab_Decal 贴花
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Decal result;
				if ((result = this._贴花) == null)
				{
					result = (this._贴花 = new PCG_LightPrefab_Decal(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Decal.StaticStruct(), base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700407D RID: 16509
		// (get) Token: 0x06022621 RID: 140833 RVA: 0x009640FC File Offset: 0x009622FC
		// (set) Token: 0x06022622 RID: 140834 RVA: 0x00964135 File Offset: 0x00962335
		public PCG_LightPrefab_Fog 雾效
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Fog result;
				if ((result = this._雾效) == null)
				{
					result = (this._雾效 = new PCG_LightPrefab_Fog(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Fog.StaticStruct(), base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700407E RID: 16510
		// (get) Token: 0x06022623 RID: 140835 RVA: 0x00964158 File Offset: 0x00962358
		// (set) Token: 0x06022624 RID: 140836 RVA: 0x00964191 File Offset: 0x00962391
		public PCG_LightPrefab_Effect 特效
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Effect result;
				if ((result = this._特效) == null)
				{
					result = (this._特效 = new PCG_LightPrefab_Effect(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Effect.StaticStruct(), base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700407F RID: 16511
		// (get) Token: 0x06022625 RID: 140837 RVA: 0x009641B4 File Offset: 0x009623B4
		// (set) Token: 0x06022626 RID: 140838 RVA: 0x009641ED File Offset: 0x009623ED
		public PCG_LightPrefab_Swing 摆动
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Swing result;
				if ((result = this._摆动) == null)
				{
					result = (this._摆动 = new PCG_LightPrefab_Swing(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Swing.StaticStruct(), base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004080 RID: 16512
		// (get) Token: 0x06022627 RID: 140839 RVA: 0x0096420E File Offset: 0x0096240E
		// (set) Token: 0x06022628 RID: 140840 RVA: 0x00964222 File Offset: 0x00962422
		[Nullable(2)]
		public unsafe BP_GlobalGI_C GlobalGIActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004081 RID: 16513
		// (get) Token: 0x06022629 RID: 140841 RVA: 0x00964237 File Offset: 0x00962437
		// (set) Token: 0x0602262A RID: 140842 RVA: 0x00964247 File Offset: 0x00962447
		public unsafe float GlobalTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004082 RID: 16514
		// (get) Token: 0x0602262B RID: 140843 RVA: 0x00964258 File Offset: 0x00962458
		// (set) Token: 0x0602262C RID: 140844 RVA: 0x00964268 File Offset: 0x00962468
		public unsafe float LocalTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004083 RID: 16515
		// (get) Token: 0x0602262D RID: 140845 RVA: 0x00964279 File Offset: 0x00962479
		// (set) Token: 0x0602262E RID: 140846 RVA: 0x0096428D File Offset: 0x0096248D
		[Nullable(2)]
		public unsafe USceneComponent Array_Element
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004084 RID: 16516
		// (get) Token: 0x0602262F RID: 140847 RVA: 0x009642A2 File Offset: 0x009624A2
		// (set) Token: 0x06022630 RID: 140848 RVA: 0x009642B6 File Offset: 0x009624B6
		public unsafe FVector SwingDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004085 RID: 16517
		// (get) Token: 0x06022631 RID: 140849 RVA: 0x009642CB File Offset: 0x009624CB
		// (set) Token: 0x06022632 RID: 140850 RVA: 0x009642DF File Offset: 0x009624DF
		[Nullable(2)]
		public unsafe USceneComponent Array_Element_0
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightPrefab_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17004086 RID: 16518
		// (get) Token: 0x06022633 RID: 140851 RVA: 0x009642F4 File Offset: 0x009624F4
		// (set) Token: 0x06022634 RID: 140852 RVA: 0x00964304 File Offset: 0x00962504
		public unsafe int TickCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004087 RID: 16519
		// (get) Token: 0x06022635 RID: 140853 RVA: 0x00964318 File Offset: 0x00962518
		// (set) Token: 0x06022636 RID: 140854 RVA: 0x00964351 File Offset: 0x00962551
		public TArray<UMaterialInstanceDynamic> DynamicMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DynamicMaterials) == null)
				{
					result = (this._DynamicMaterials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				this.DynamicMaterials.CopyAssign(value);
			}
		}

		// Token: 0x17004088 RID: 16520
		// (get) Token: 0x06022637 RID: 140855 RVA: 0x00964360 File Offset: 0x00962560
		// (set) Token: 0x06022638 RID: 140856 RVA: 0x00964399 File Offset: 0x00962599
		public TArray<AActor> ChildActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ChildActors) == null)
				{
					result = (this._ChildActors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				this.ChildActors.CopyAssign(value);
			}
		}

		// Token: 0x17004089 RID: 16521
		// (get) Token: 0x06022639 RID: 140857 RVA: 0x009643A7 File Offset: 0x009625A7
		// (set) Token: 0x0602263A RID: 140858 RVA: 0x009643B7 File Offset: 0x009625B7
		public unsafe bool IsDaytime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightPrefab_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602263B RID: 140859 RVA: 0x009643C8 File Offset: 0x009625C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Material_Parameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__Update_Material_Parameter_NativeFunctionPtr, null);
		}

		// Token: 0x0602263C RID: 140860 RVA: 0x009643DC File Offset: 0x009625DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LightModelProperty()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__LightModelProperty_NativeFunctionPtr, null);
		}

		// Token: 0x0602263D RID: 140861 RVA: 0x009643F0 File Offset: 0x009625F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshPrefab()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__RefreshPrefab_NativeFunctionPtr, null);
		}

		// Token: 0x0602263E RID: 140862 RVA: 0x00964404 File Offset: 0x00962604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetChildActorLocation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__ResetChildActorLocation_NativeFunctionPtr, null);
		}

		// Token: 0x0602263F RID: 140863 RVA: 0x00964418 File Offset: 0x00962618
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdataProperty()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__UpdataProperty_NativeFunctionPtr, null);
		}

		// Token: 0x06022640 RID: 140864 RVA: 0x0096442C File Offset: 0x0096262C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitialProperty()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__InitialProperty_NativeFunctionPtr, null);
		}

		// Token: 0x06022641 RID: 140865 RVA: 0x00964440 File Offset: 0x00962640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022642 RID: 140866 RVA: 0x00964454 File Offset: 0x00962654
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightPrefab_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022643 RID: 140867 RVA: 0x00964469 File Offset: 0x00962669
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022644 RID: 140868 RVA: 0x0096447D File Offset: 0x0096267D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightPrefab_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022645 RID: 140869 RVA: 0x00964494 File Offset: 0x00962694
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LightPrefab_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightPrefab_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightPrefab_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightPrefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022646 RID: 140870 RVA: 0x009644DC File Offset: 0x009626DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LightPrefab_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightPrefab_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightPrefab_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightPrefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightPrefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022647 RID: 140871 RVA: 0x00964524 File Offset: 0x00962724
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_LightPrefab_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LightPrefab_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightPrefab_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightPrefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightPrefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022648 RID: 140872 RVA: 0x0096456C File Offset: 0x0096276C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_LightPrefab_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LightPrefab_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightPrefab_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightPrefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightPrefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022649 RID: 140873 RVA: 0x009645B4 File Offset: 0x009627B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LightPrefab(int EntryPoint)
		{
			BP_LightPrefab_C.__ExecuteUbergraph_BP_LightPrefab_FunctionParams* ptr = stackalloc BP_LightPrefab_C.__ExecuteUbergraph_BP_LightPrefab_FunctionParams[(UIntPtr)647] + 15L / (long)sizeof(BP_LightPrefab_C.__ExecuteUbergraph_BP_LightPrefab_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightPrefab_C.__ExecuteUbergraph_BP_LightPrefab_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightPrefab_C.__ExecuteUbergraph_BP_LightPrefab_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602264A RID: 140874 RVA: 0x009645FE File Offset: 0x009627FE
		protected BP_LightPrefab_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011660 RID: 71264
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/BP_LightPrefab.BP_LightPrefab_C";

		// Token: 0x04011661 RID: 71265
		private static IntPtr _ClassPtr;

		// Token: 0x04011662 RID: 71266
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011663 RID: 71267
		internal static int __PropertyOffset_0;

		// Token: 0x04011664 RID: 71268
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011665 RID: 71269
		internal static int __PropertyOffset_1;

		// Token: 0x04011666 RID: 71270
		internal static int __PropertyOffset_2;

		// Token: 0x04011667 RID: 71271
		internal static int __PropertyOffset_3;

		// Token: 0x04011668 RID: 71272
		internal static int __PropertyOffset_4;

		// Token: 0x04011669 RID: 71273
		internal static int __PropertyOffset_5;

		// Token: 0x0401166A RID: 71274
		internal static int __PropertyOffset_6;

		// Token: 0x0401166B RID: 71275
		internal static int __PropertyOffset_7;

		// Token: 0x0401166C RID: 71276
		[Nullable(2)]
		private PCG_LightPrefab_Light _灯光;

		// Token: 0x0401166D RID: 71277
		internal static int __PropertyOffset_8;

		// Token: 0x0401166E RID: 71278
		[Nullable(2)]
		private PCG_LightPrefab_Mesh _模型;

		// Token: 0x0401166F RID: 71279
		internal static int __PropertyOffset_9;

		// Token: 0x04011670 RID: 71280
		[Nullable(2)]
		private PCG_LightPrefab_Decal _贴花;

		// Token: 0x04011671 RID: 71281
		internal static int __PropertyOffset_10;

		// Token: 0x04011672 RID: 71282
		[Nullable(2)]
		private PCG_LightPrefab_Fog _雾效;

		// Token: 0x04011673 RID: 71283
		internal static int __PropertyOffset_11;

		// Token: 0x04011674 RID: 71284
		[Nullable(2)]
		private PCG_LightPrefab_Effect _特效;

		// Token: 0x04011675 RID: 71285
		internal static int __PropertyOffset_12;

		// Token: 0x04011676 RID: 71286
		[Nullable(2)]
		private PCG_LightPrefab_Swing _摆动;

		// Token: 0x04011677 RID: 71287
		internal static int __PropertyOffset_13;

		// Token: 0x04011678 RID: 71288
		internal static int __PropertyOffset_14;

		// Token: 0x04011679 RID: 71289
		internal static int __PropertyOffset_15;

		// Token: 0x0401167A RID: 71290
		internal static int __PropertyOffset_16;

		// Token: 0x0401167B RID: 71291
		internal static int __PropertyOffset_17;

		// Token: 0x0401167C RID: 71292
		internal static int __PropertyOffset_18;

		// Token: 0x0401167D RID: 71293
		internal static int __PropertyOffset_19;

		// Token: 0x0401167E RID: 71294
		internal static int __PropertyOffset_20;

		// Token: 0x0401167F RID: 71295
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DynamicMaterials;

		// Token: 0x04011680 RID: 71296
		internal static int __PropertyOffset_21;

		// Token: 0x04011681 RID: 71297
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ChildActors;

		// Token: 0x04011682 RID: 71298
		internal static int __PropertyOffset_22;

		// Token: 0x04011683 RID: 71299
		private static IntPtr __Update_Material_Parameter_NativeFunctionPtr;

		// Token: 0x04011684 RID: 71300
		private static IntPtr __LightModelProperty_NativeFunctionPtr;

		// Token: 0x04011685 RID: 71301
		private static IntPtr __RefreshPrefab_NativeFunctionPtr;

		// Token: 0x04011686 RID: 71302
		private static IntPtr __ResetChildActorLocation_NativeFunctionPtr;

		// Token: 0x04011687 RID: 71303
		private static IntPtr __UpdataProperty_NativeFunctionPtr;

		// Token: 0x04011688 RID: 71304
		private static IntPtr __InitialProperty_NativeFunctionPtr;

		// Token: 0x04011689 RID: 71305
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401168A RID: 71306
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401168B RID: 71307
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401168C RID: 71308
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401168D RID: 71309
		private static IntPtr __ExecuteUbergraph_BP_LightPrefab_NativeFunctionPtr;

		// Token: 0x02009BD2 RID: 39890
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032418 RID: 205848
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BD3 RID: 39891
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032419 RID: 205849
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BD4 RID: 39892
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 632)]
		protected ref struct __ExecuteUbergraph_BP_LightPrefab_FunctionParams
		{
			// Token: 0x0403241A RID: 205850
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
