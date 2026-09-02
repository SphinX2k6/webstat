using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BatchedCloth
{
	// Token: 0x02003C40 RID: 15424
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/BP_BatchedCloth.BP_BatchedCloth_C")]
	[UnrealStructLayout(1992, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1988)]
	public class BP_BatchedCloth_C : AKuroCSStaticBatchCloth, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023753 RID: 145235 RVA: 0x00982CA8 File Offset: 0x00980EA8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BatchedCloth_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/BP_BatchedCloth.BP_BatchedCloth_C");
			}
			return BP_BatchedCloth_C._ClassPtr;
		}

		// Token: 0x06023754 RID: 145236 RVA: 0x00982CCC File Offset: 0x00980ECC
		public BP_BatchedCloth_C() : this(BuiltinUtils.AllocNativeUObject(BP_BatchedCloth_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023755 RID: 145237 RVA: 0x00982CF4 File Offset: 0x00980EF4
		[NullableContext(1)]
		public BP_BatchedCloth_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BatchedCloth_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700468B RID: 18059
		// (get) Token: 0x06023756 RID: 145238 RVA: 0x00982D28 File Offset: 0x00980F28
		// (set) Token: 0x06023757 RID: 145239 RVA: 0x00982D61 File Offset: 0x00980F61
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700468C RID: 18060
		// (get) Token: 0x06023758 RID: 145240 RVA: 0x00982D82 File Offset: 0x00980F82
		// (set) Token: 0x06023759 RID: 145241 RVA: 0x00982D96 File Offset: 0x00980F96
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700468D RID: 18061
		// (get) Token: 0x0602375A RID: 145242 RVA: 0x00982DAB File Offset: 0x00980FAB
		// (set) Token: 0x0602375B RID: 145243 RVA: 0x00982DBF File Offset: 0x00980FBF
		public unsafe UStaticMeshComponent SM_ClothController
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700468E RID: 18062
		// (get) Token: 0x0602375C RID: 145244 RVA: 0x00982DD4 File Offset: 0x00980FD4
		// (set) Token: 0x0602375D RID: 145245 RVA: 0x00982DE8 File Offset: 0x00980FE8
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700468F RID: 18063
		// (get) Token: 0x0602375E RID: 145246 RVA: 0x00982DFD File Offset: 0x00980FFD
		// (set) Token: 0x0602375F RID: 145247 RVA: 0x00982E0D File Offset: 0x0098100D
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004690 RID: 18064
		// (get) Token: 0x06023760 RID: 145248 RVA: 0x00982E1E File Offset: 0x0098101E
		// (set) Token: 0x06023761 RID: 145249 RVA: 0x00982E2E File Offset: 0x0098102E
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004691 RID: 18065
		// (get) Token: 0x06023762 RID: 145250 RVA: 0x00982E3F File Offset: 0x0098103F
		// (set) Token: 0x06023763 RID: 145251 RVA: 0x00982E53 File Offset: 0x00981053
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004692 RID: 18066
		// (get) Token: 0x06023764 RID: 145252 RVA: 0x00982E68 File Offset: 0x00981068
		// (set) Token: 0x06023765 RID: 145253 RVA: 0x00982E7C File Offset: 0x0098107C
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BatchedCloth_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004693 RID: 18067
		// (get) Token: 0x06023766 RID: 145254 RVA: 0x00982E91 File Offset: 0x00981091
		// (set) Token: 0x06023767 RID: 145255 RVA: 0x00982EA1 File Offset: 0x009810A1
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004694 RID: 18068
		// (get) Token: 0x06023768 RID: 145256 RVA: 0x00982EB2 File Offset: 0x009810B2
		// (set) Token: 0x06023769 RID: 145257 RVA: 0x00982EC2 File Offset: 0x009810C2
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004695 RID: 18069
		// (get) Token: 0x0602376A RID: 145258 RVA: 0x00982ED3 File Offset: 0x009810D3
		// (set) Token: 0x0602376B RID: 145259 RVA: 0x00982EE3 File Offset: 0x009810E3
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004696 RID: 18070
		// (get) Token: 0x0602376C RID: 145260 RVA: 0x00982EF4 File Offset: 0x009810F4
		// (set) Token: 0x0602376D RID: 145261 RVA: 0x00982F04 File Offset: 0x00981104
		public unsafe bool bAfterBeginplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004697 RID: 18071
		// (get) Token: 0x0602376E RID: 145262 RVA: 0x00982F15 File Offset: 0x00981115
		// (set) Token: 0x0602376F RID: 145263 RVA: 0x00982F25 File Offset: 0x00981125
		public unsafe bool PlatformCheck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004698 RID: 18072
		// (get) Token: 0x06023770 RID: 145264 RVA: 0x00982F36 File Offset: 0x00981136
		// (set) Token: 0x06023771 RID: 145265 RVA: 0x00982F46 File Offset: 0x00981146
		public unsafe bool debugWindField
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004699 RID: 18073
		// (get) Token: 0x06023772 RID: 145266 RVA: 0x00982F57 File Offset: 0x00981157
		// (set) Token: 0x06023773 RID: 145267 RVA: 0x00982F6B File Offset: 0x0098116B
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700469A RID: 18074
		// (get) Token: 0x06023774 RID: 145268 RVA: 0x00982F80 File Offset: 0x00981180
		// (set) Token: 0x06023775 RID: 145269 RVA: 0x00982F94 File Offset: 0x00981194
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BatchedCloth_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x06023776 RID: 145270 RVA: 0x00982FA9 File Offset: 0x009811A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawParticlesOffline_2s_()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__DrawParticlesOffline_2s__NativeFunctionPtr, null);
		}

		// Token: 0x06023777 RID: 145271 RVA: 0x00982FBD File Offset: 0x009811BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023778 RID: 145272 RVA: 0x00982FD1 File Offset: 0x009811D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedCloth_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023779 RID: 145273 RVA: 0x00982FE6 File Offset: 0x009811E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602377A RID: 145274 RVA: 0x00982FFA File Offset: 0x009811FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedCloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602377B RID: 145275 RVA: 0x00983010 File Offset: 0x00981210
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BatchedCloth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BatchedCloth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BatchedCloth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602377C RID: 145276 RVA: 0x00983058 File Offset: 0x00981258
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BatchedCloth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BatchedCloth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BatchedCloth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602377D RID: 145277 RVA: 0x009830A0 File Offset: 0x009812A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_BatchedCloth_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_BatchedCloth_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BatchedCloth_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602377E RID: 145278 RVA: 0x009830EC File Offset: 0x009812EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_BatchedCloth_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_BatchedCloth_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BatchedCloth_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602377F RID: 145279 RVA: 0x00983138 File Offset: 0x00981338
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023780 RID: 145280 RVA: 0x009831F4 File Offset: 0x009813F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023781 RID: 145281 RVA: 0x0098327D File Offset: 0x0098147D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023782 RID: 145282 RVA: 0x00983294 File Offset: 0x00981494
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_BatchedCloth_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_BatchedCloth_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_BatchedCloth_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedCloth_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BatchedCloth_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023783 RID: 145283 RVA: 0x009832F8 File Offset: 0x009814F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BatchedCloth(int EntryPoint)
		{
			BP_BatchedCloth_C.__ExecuteUbergraph_BP_BatchedCloth_FunctionParams* ptr = stackalloc BP_BatchedCloth_C.__ExecuteUbergraph_BP_BatchedCloth_FunctionParams[(UIntPtr)4335] + 15L / (long)sizeof(BP_BatchedCloth_C.__ExecuteUbergraph_BP_BatchedCloth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BatchedCloth_C.__ExecuteUbergraph_BP_BatchedCloth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BatchedCloth_C.__ExecuteUbergraph_BP_BatchedCloth_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023784 RID: 145284 RVA: 0x00983342 File Offset: 0x00981542
		protected BP_BatchedCloth_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040120D3 RID: 73939
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/BP_BatchedCloth.BP_BatchedCloth_C";

		// Token: 0x040120D4 RID: 73940
		private static IntPtr _ClassPtr;

		// Token: 0x040120D5 RID: 73941
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040120D6 RID: 73942
		internal static int __PropertyOffset_0;

		// Token: 0x040120D7 RID: 73943
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040120D8 RID: 73944
		internal static int __PropertyOffset_1;

		// Token: 0x040120D9 RID: 73945
		internal static int __PropertyOffset_2;

		// Token: 0x040120DA RID: 73946
		internal static int __PropertyOffset_3;

		// Token: 0x040120DB RID: 73947
		internal static int __PropertyOffset_4;

		// Token: 0x040120DC RID: 73948
		internal static int __PropertyOffset_5;

		// Token: 0x040120DD RID: 73949
		internal static int __PropertyOffset_6;

		// Token: 0x040120DE RID: 73950
		internal static int __PropertyOffset_7;

		// Token: 0x040120DF RID: 73951
		internal static int __PropertyOffset_8;

		// Token: 0x040120E0 RID: 73952
		internal static int __PropertyOffset_9;

		// Token: 0x040120E1 RID: 73953
		internal static int __PropertyOffset_10;

		// Token: 0x040120E2 RID: 73954
		internal static int __PropertyOffset_11;

		// Token: 0x040120E3 RID: 73955
		internal static int __PropertyOffset_12;

		// Token: 0x040120E4 RID: 73956
		internal static int __PropertyOffset_13;

		// Token: 0x040120E5 RID: 73957
		internal static int __PropertyOffset_14;

		// Token: 0x040120E6 RID: 73958
		internal static int __PropertyOffset_15;

		// Token: 0x040120E7 RID: 73959
		private static IntPtr __DrawParticlesOffline_2s__NativeFunctionPtr;

		// Token: 0x040120E8 RID: 73960
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040120E9 RID: 73961
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040120EA RID: 73962
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040120EB RID: 73963
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040120EC RID: 73964
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040120ED RID: 73965
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040120EE RID: 73966
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040120EF RID: 73967
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040120F0 RID: 73968
		private static IntPtr __ExecuteUbergraph_BP_BatchedCloth_NativeFunctionPtr;

		// Token: 0x02009CE8 RID: 40168
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032676 RID: 206454
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CE9 RID: 40169
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032677 RID: 206455
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009CEA RID: 40170
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032678 RID: 206456
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032679 RID: 206457
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403267A RID: 206458
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403267B RID: 206459
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403267C RID: 206460
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403267D RID: 206461
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CEB RID: 40171
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403267E RID: 206462
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403267F RID: 206463
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032680 RID: 206464
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032681 RID: 206465
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CEC RID: 40172
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032682 RID: 206466
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032683 RID: 206467
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032684 RID: 206468
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009CED RID: 40173
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4320)]
		protected ref struct __ExecuteUbergraph_BP_BatchedCloth_FunctionParams
		{
			// Token: 0x04032685 RID: 206469
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
