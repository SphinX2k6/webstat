using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AEB RID: 15083
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollActor.BP_DollActor_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class BP_DollActor_C : AKuroBPActor, IUnrealUObject, IUnrealObject, IBPI_DollActor_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06020656 RID: 132694 RVA: 0x0092AB25 File Offset: 0x00928D25
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollActor.BP_DollActor_C");
			}
			return BP_DollActor_C._ClassPtr;
		}

		// Token: 0x06020657 RID: 132695 RVA: 0x0092AB4C File Offset: 0x00928D4C
		public BP_DollActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020658 RID: 132696 RVA: 0x0092AB74 File Offset: 0x00928D74
		[NullableContext(1)]
		public BP_DollActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003574 RID: 13684
		// (get) Token: 0x06020659 RID: 132697 RVA: 0x0092ABA8 File Offset: 0x00928DA8
		// (set) Token: 0x0602065A RID: 132698 RVA: 0x0092ABE1 File Offset: 0x00928DE1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003575 RID: 13685
		// (get) Token: 0x0602065B RID: 132699 RVA: 0x0092AC02 File Offset: 0x00928E02
		// (set) Token: 0x0602065C RID: 132700 RVA: 0x0092AC16 File Offset: 0x00928E16
		[Nullable(2)]
		public unsafe UChildActorComponent PermanentEffect1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003576 RID: 13686
		// (get) Token: 0x0602065D RID: 132701 RVA: 0x0092AC2B File Offset: 0x00928E2B
		// (set) Token: 0x0602065E RID: 132702 RVA: 0x0092AC3F File Offset: 0x00928E3F
		[Nullable(2)]
		public unsafe UChildActorComponent PermanentEffect
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003577 RID: 13687
		// (get) Token: 0x0602065F RID: 132703 RVA: 0x0092AC54 File Offset: 0x00928E54
		// (set) Token: 0x06020660 RID: 132704 RVA: 0x0092AC68 File Offset: 0x00928E68
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003578 RID: 13688
		// (get) Token: 0x06020661 RID: 132705 RVA: 0x0092AC7D File Offset: 0x00928E7D
		// (set) Token: 0x06020662 RID: 132706 RVA: 0x0092AC8D File Offset: 0x00928E8D
		public unsafe int Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003579 RID: 13689
		// (get) Token: 0x06020663 RID: 132707 RVA: 0x0092AC9E File Offset: 0x00928E9E
		// (set) Token: 0x06020664 RID: 132708 RVA: 0x0092ACB3 File Offset: 0x00928EB3
		[Nullable(1)]
		public TSoftObjectPtr<EffectModelGroup> GrabEffect
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_5, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700357A RID: 13690
		// (get) Token: 0x06020665 RID: 132709 RVA: 0x0092ACD8 File Offset: 0x00928ED8
		// (set) Token: 0x06020666 RID: 132710 RVA: 0x0092ACED File Offset: 0x00928EED
		[Nullable(1)]
		public TSoftObjectPtr<EffectModelGroup> GrabEndlessEffect
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_6, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700357B RID: 13691
		// (get) Token: 0x06020667 RID: 132711 RVA: 0x0092AD12 File Offset: 0x00928F12
		// (set) Token: 0x06020668 RID: 132712 RVA: 0x0092AD27 File Offset: 0x00928F27
		[Nullable(1)]
		public TSoftObjectPtr<EffectModelGroup> SpawnEffect
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_7, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700357C RID: 13692
		// (get) Token: 0x06020669 RID: 132713 RVA: 0x0092AD4C File Offset: 0x00928F4C
		// (set) Token: 0x0602066A RID: 132714 RVA: 0x0092AD5C File Offset: 0x00928F5C
		public unsafe bool MainDoll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700357D RID: 13693
		// (get) Token: 0x0602066B RID: 132715 RVA: 0x0092AD6D File Offset: 0x00928F6D
		// (set) Token: 0x0602066C RID: 132716 RVA: 0x0092AD81 File Offset: 0x00928F81
		[Nullable(2)]
		public unsafe UAnimSequence DollIdleAnim
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_9);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700357E RID: 13694
		// (get) Token: 0x0602066D RID: 132717 RVA: 0x0092AD96 File Offset: 0x00928F96
		// (set) Token: 0x0602066E RID: 132718 RVA: 0x0092ADAA File Offset: 0x00928FAA
		[Nullable(2)]
		public unsafe UAnimSequence DollGrabAnim
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_10);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollActor_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700357F RID: 13695
		// (get) Token: 0x0602066F RID: 132719 RVA: 0x0092ADC0 File Offset: 0x00928FC0
		// (set) Token: 0x06020670 RID: 132720 RVA: 0x0092ADF9 File Offset: 0x00928FF9
		[Nullable(1)]
		public OnBeginPlay OnBeginPlay
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnBeginPlay result;
				if ((result = this._OnBeginPlay) == null)
				{
					result = (this._OnBeginPlay = new OnBeginPlay(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_DollActor_C.__PropertyOffset_11, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x06020671 RID: 132721 RVA: 0x0092AE1C File Offset: 0x0092901C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetSimulatePhysics(bool Enable)
		{
			BP_DollActor_C.__SetSimulatePhysics_FunctionParams* ptr = stackalloc BP_DollActor_C.__SetSimulatePhysics_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_DollActor_C.__SetSimulatePhysics_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__SetSimulatePhysics_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable = Enable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__SetSimulatePhysics_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020672 RID: 132722 RVA: 0x0092AE62 File Offset: 0x00929062
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayGrabAnim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__PlayGrabAnim_NativeFunctionPtr, null);
		}

		// Token: 0x06020673 RID: 132723 RVA: 0x0092AE78 File Offset: 0x00929078
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TogglePlayIdleAnim(bool toggle)
		{
			BP_DollActor_C.__TogglePlayIdleAnim_FunctionParams* ptr = stackalloc BP_DollActor_C.__TogglePlayIdleAnim_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_DollActor_C.__TogglePlayIdleAnim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__TogglePlayIdleAnim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->toggle = toggle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__TogglePlayIdleAnim_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020674 RID: 132724 RVA: 0x0092AEC0 File Offset: 0x009290C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EnableRagdoll(bool Enable)
		{
			BP_DollActor_C.__EnableRagdoll_FunctionParams* ptr = stackalloc BP_DollActor_C.__EnableRagdoll_FunctionParams[(UIntPtr)303] + 15L / (long)sizeof(BP_DollActor_C.__EnableRagdoll_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__EnableRagdoll_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable = Enable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__EnableRagdoll_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020675 RID: 132725 RVA: 0x0092AF0C File Offset: 0x0092910C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPermanentEffect(bool Visibility, string Reason)
		{
			BP_DollActor_C.__SetPermanentEffect_FunctionParams* ptr = stackalloc BP_DollActor_C.__SetPermanentEffect_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_DollActor_C.__SetPermanentEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__SetPermanentEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Visibility = Visibility;
			FString.CopyFrom((void*)(&ptr->Reason), Reason);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__SetPermanentEffect_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_DollActor_C.__SetPermanentEffect_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020676 RID: 132726 RVA: 0x0092AF70 File Offset: 0x00929170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayGrabEffectByLocation(FVectorDouble Location)
		{
			BP_DollActor_C.__PlayGrabEffectByLocation_FunctionParams* ptr = stackalloc BP_DollActor_C.__PlayGrabEffectByLocation_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_DollActor_C.__PlayGrabEffectByLocation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__PlayGrabEffectByLocation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__PlayGrabEffectByLocation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020677 RID: 132727 RVA: 0x0092AFB6 File Offset: 0x009291B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayTimeEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__PlayTimeEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06020678 RID: 132728 RVA: 0x0092AFCA File Offset: 0x009291CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020679 RID: 132729 RVA: 0x0092AFDE File Offset: 0x009291DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602067A RID: 132730 RVA: 0x0092AFF4 File Offset: 0x009291F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVisible(bool ToggleVisibility, bool TogglePhysics)
		{
			BP_DollActor_C.__SetVisible_FunctionParams* ptr = stackalloc BP_DollActor_C.__SetVisible_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_DollActor_C.__SetVisible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__SetVisible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ToggleVisibility = ToggleVisibility;
			ptr->TogglePhysics = TogglePhysics;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__SetVisible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602067B RID: 132731 RVA: 0x0092B044 File Offset: 0x00929244
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayGrabEffect(bool IsEndless, FVectorDouble Location)
		{
			BP_DollActor_C.__PlayGrabEffect_FunctionParams* ptr = stackalloc BP_DollActor_C.__PlayGrabEffect_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_DollActor_C.__PlayGrabEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__PlayGrabEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEndless = IsEndless;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__PlayGrabEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602067C RID: 132732 RVA: 0x0092B091 File Offset: 0x00929291
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlaySpawnEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__PlaySpawnEffect_NativeFunctionPtr, null);
		}

		// Token: 0x0602067D RID: 132733 RVA: 0x0092B0A8 File Offset: 0x009292A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPhysicsParameters(float AngularDamping, float LineraDamping)
		{
			BP_DollActor_C.__SetPhysicsParameters_FunctionParams* ptr = stackalloc BP_DollActor_C.__SetPhysicsParameters_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_DollActor_C.__SetPhysicsParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__SetPhysicsParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AngularDamping = AngularDamping;
			ptr->LineraDamping = LineraDamping;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__SetPhysicsParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602067E RID: 132734 RVA: 0x0092B0F5 File Offset: 0x009292F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetPhysics()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__ResetPhysics_NativeFunctionPtr, null);
		}

		// Token: 0x0602067F RID: 132735 RVA: 0x0092B10C File Offset: 0x0092930C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TogglePlayShow(bool Toggle, float PlayRate)
		{
			BP_DollActor_C.__TogglePlayShow_FunctionParams* ptr = stackalloc BP_DollActor_C.__TogglePlayShow_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_DollActor_C.__TogglePlayShow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__TogglePlayShow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Toggle = Toggle;
			ptr->PlayRate = PlayRate;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__TogglePlayShow_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020680 RID: 132736 RVA: 0x0092B15C File Offset: 0x0092935C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TogglePlayGrabAnim(bool Enable, float Rate)
		{
			BP_DollActor_C.__TogglePlayGrabAnim_FunctionParams* ptr = stackalloc BP_DollActor_C.__TogglePlayGrabAnim_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_DollActor_C.__TogglePlayGrabAnim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__TogglePlayGrabAnim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable = Enable;
			ptr->Rate = Rate;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__TogglePlayGrabAnim_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020681 RID: 132737 RVA: 0x0092B1AC File Offset: 0x009293AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayGrabEffectByTransform(bool IsEndless, FTransformDouble Transform)
		{
			BP_DollActor_C.__PlayGrabEffectByTransform_FunctionParams* ptr = stackalloc BP_DollActor_C.__PlayGrabEffectByTransform_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_DollActor_C.__PlayGrabEffectByTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__PlayGrabEffectByTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEndless = IsEndless;
			ptr->Transform = Transform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollActor_C.__PlayGrabEffectByTransform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020682 RID: 132738 RVA: 0x0092B1FC File Offset: 0x009293FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DollActor(int EntryPoint)
		{
			BP_DollActor_C.__ExecuteUbergraph_BP_DollActor_FunctionParams* ptr = stackalloc BP_DollActor_C.__ExecuteUbergraph_BP_DollActor_FunctionParams[(UIntPtr)687] + 15L / (long)sizeof(BP_DollActor_C.__ExecuteUbergraph_BP_DollActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollActor_C.__ExecuteUbergraph_BP_DollActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollActor_C.__ExecuteUbergraph_BP_DollActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020683 RID: 132739 RVA: 0x0092B246 File Offset: 0x00929446
		protected BP_DollActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040102E6 RID: 66278
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollActor.BP_DollActor_C";

		// Token: 0x040102E7 RID: 66279
		private static IntPtr _ClassPtr;

		// Token: 0x040102E8 RID: 66280
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040102E9 RID: 66281
		public static IntPtr __OnBeginPlay__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040102EA RID: 66282
		internal static int __PropertyOffset_0;

		// Token: 0x040102EB RID: 66283
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040102EC RID: 66284
		internal static int __PropertyOffset_1;

		// Token: 0x040102ED RID: 66285
		internal static int __PropertyOffset_2;

		// Token: 0x040102EE RID: 66286
		internal static int __PropertyOffset_3;

		// Token: 0x040102EF RID: 66287
		internal static int __PropertyOffset_4;

		// Token: 0x040102F0 RID: 66288
		internal static int __PropertyOffset_5;

		// Token: 0x040102F1 RID: 66289
		internal static int __PropertyOffset_6;

		// Token: 0x040102F2 RID: 66290
		internal static int __PropertyOffset_7;

		// Token: 0x040102F3 RID: 66291
		internal static int __PropertyOffset_8;

		// Token: 0x040102F4 RID: 66292
		internal static int __PropertyOffset_9;

		// Token: 0x040102F5 RID: 66293
		internal static int __PropertyOffset_10;

		// Token: 0x040102F6 RID: 66294
		internal static int __PropertyOffset_11;

		// Token: 0x040102F7 RID: 66295
		[Nullable(2)]
		private OnBeginPlay _OnBeginPlay;

		// Token: 0x040102F8 RID: 66296
		private static IntPtr __SetSimulatePhysics_NativeFunctionPtr;

		// Token: 0x040102F9 RID: 66297
		private static IntPtr __PlayGrabAnim_NativeFunctionPtr;

		// Token: 0x040102FA RID: 66298
		private static IntPtr __TogglePlayIdleAnim_NativeFunctionPtr;

		// Token: 0x040102FB RID: 66299
		private static IntPtr __EnableRagdoll_NativeFunctionPtr;

		// Token: 0x040102FC RID: 66300
		private static IntPtr __SetPermanentEffect_NativeFunctionPtr;

		// Token: 0x040102FD RID: 66301
		private static IntPtr __PlayGrabEffectByLocation_NativeFunctionPtr;

		// Token: 0x040102FE RID: 66302
		private static IntPtr __PlayTimeEffect_NativeFunctionPtr;

		// Token: 0x040102FF RID: 66303
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010300 RID: 66304
		private static IntPtr __SetVisible_NativeFunctionPtr;

		// Token: 0x04010301 RID: 66305
		private static IntPtr __PlayGrabEffect_NativeFunctionPtr;

		// Token: 0x04010302 RID: 66306
		private static IntPtr __PlaySpawnEffect_NativeFunctionPtr;

		// Token: 0x04010303 RID: 66307
		private static IntPtr __SetPhysicsParameters_NativeFunctionPtr;

		// Token: 0x04010304 RID: 66308
		private static IntPtr __ResetPhysics_NativeFunctionPtr;

		// Token: 0x04010305 RID: 66309
		private static IntPtr __TogglePlayShow_NativeFunctionPtr;

		// Token: 0x04010306 RID: 66310
		private static IntPtr __TogglePlayGrabAnim_NativeFunctionPtr;

		// Token: 0x04010307 RID: 66311
		private static IntPtr __PlayGrabEffectByTransform_NativeFunctionPtr;

		// Token: 0x04010308 RID: 66312
		private static IntPtr __ExecuteUbergraph_BP_DollActor_NativeFunctionPtr;

		// Token: 0x020099AA RID: 39338
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetSimulatePhysics_FunctionParams
		{
			// Token: 0x04032043 RID: 204867
			[FieldOffset(0)]
			public bool Enable;
		}

		// Token: 0x020099AB RID: 39339
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __TogglePlayIdleAnim_FunctionParams
		{
			// Token: 0x04032044 RID: 204868
			[FieldOffset(0)]
			public bool toggle;
		}

		// Token: 0x020099AC RID: 39340
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 288)]
		protected ref struct __EnableRagdoll_FunctionParams
		{
			// Token: 0x04032045 RID: 204869
			[FieldOffset(0)]
			public bool Enable;
		}

		// Token: 0x020099AD RID: 39341
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __SetPermanentEffect_FunctionParams
		{
			// Token: 0x04032046 RID: 204870
			[FieldOffset(0)]
			public bool Visibility;

			// Token: 0x04032047 RID: 204871
			[FieldOffset(8)]
			public FString Reason;
		}

		// Token: 0x020099AE RID: 39342
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __PlayGrabEffectByLocation_FunctionParams
		{
			// Token: 0x04032048 RID: 204872
			[FieldOffset(0)]
			public FVectorDouble Location;
		}

		// Token: 0x020099AF RID: 39343
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __SetVisible_FunctionParams
		{
			// Token: 0x04032049 RID: 204873
			[FieldOffset(0)]
			public bool ToggleVisibility;

			// Token: 0x0403204A RID: 204874
			[FieldOffset(1)]
			public bool TogglePhysics;
		}

		// Token: 0x020099B0 RID: 39344
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __PlayGrabEffect_FunctionParams
		{
			// Token: 0x0403204B RID: 204875
			[FieldOffset(0)]
			public bool IsEndless;

			// Token: 0x0403204C RID: 204876
			[FieldOffset(8)]
			public FVectorDouble Location;
		}

		// Token: 0x020099B1 RID: 39345
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __SetPhysicsParameters_FunctionParams
		{
			// Token: 0x0403204D RID: 204877
			[FieldOffset(0)]
			public float AngularDamping;

			// Token: 0x0403204E RID: 204878
			[FieldOffset(4)]
			public float LineraDamping;
		}

		// Token: 0x020099B2 RID: 39346
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __TogglePlayShow_FunctionParams
		{
			// Token: 0x0403204F RID: 204879
			[FieldOffset(0)]
			public bool Toggle;

			// Token: 0x04032050 RID: 204880
			[FieldOffset(4)]
			public float PlayRate;
		}

		// Token: 0x020099B3 RID: 39347
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __TogglePlayGrabAnim_FunctionParams
		{
			// Token: 0x04032051 RID: 204881
			[FieldOffset(0)]
			public bool Enable;

			// Token: 0x04032052 RID: 204882
			[FieldOffset(4)]
			public float Rate;
		}

		// Token: 0x020099B4 RID: 39348
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __PlayGrabEffectByTransform_FunctionParams
		{
			// Token: 0x04032053 RID: 204883
			[FieldOffset(0)]
			public bool IsEndless;

			// Token: 0x04032054 RID: 204884
			[FieldOffset(16)]
			public FTransformDouble Transform;
		}

		// Token: 0x020099B5 RID: 39349
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 672)]
		protected ref struct __ExecuteUbergraph_BP_DollActor_FunctionParams
		{
			// Token: 0x04032055 RID: 204885
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
