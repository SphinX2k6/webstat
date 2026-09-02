using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.InteractionLight
{
	// Token: 0x02003C8C RID: 15500
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/InteractionLight/BP_InteractionLight.BP_InteractionLight_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1432)]
	public class BP_InteractionLight_C : AKuroGameBudgetBlueprintActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060241CF RID: 147919 RVA: 0x009951A1 File Offset: 0x009933A1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractionLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/InteractionLight/BP_InteractionLight.BP_InteractionLight_C");
			}
			return BP_InteractionLight_C._ClassPtr;
		}

		// Token: 0x060241D0 RID: 147920 RVA: 0x009951C8 File Offset: 0x009933C8
		public BP_InteractionLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractionLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060241D1 RID: 147921 RVA: 0x009951F0 File Offset: 0x009933F0
		[NullableContext(1)]
		public BP_InteractionLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractionLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004A12 RID: 18962
		// (get) Token: 0x060241D2 RID: 147922 RVA: 0x00995224 File Offset: 0x00993424
		// (set) Token: 0x060241D3 RID: 147923 RVA: 0x0099525D File Offset: 0x0099345D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004A13 RID: 18963
		// (get) Token: 0x060241D4 RID: 147924 RVA: 0x0099527E File Offset: 0x0099347E
		// (set) Token: 0x060241D5 RID: 147925 RVA: 0x00995292 File Offset: 0x00993492
		public unsafe USpotLightComponent SpotLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpotLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004A14 RID: 18964
		// (get) Token: 0x060241D6 RID: 147926 RVA: 0x009952A7 File Offset: 0x009934A7
		// (set) Token: 0x060241D7 RID: 147927 RVA: 0x009952BB File Offset: 0x009934BB
		public unsafe UChildActorComponent BP_VolumetricConeLightShaft_InStage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004A15 RID: 18965
		// (get) Token: 0x060241D8 RID: 147928 RVA: 0x009952D0 File Offset: 0x009934D0
		// (set) Token: 0x060241D9 RID: 147929 RVA: 0x009952E4 File Offset: 0x009934E4
		public unsafe UStaticMeshComponent DownSM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004A16 RID: 18966
		// (get) Token: 0x060241DA RID: 147930 RVA: 0x009952F9 File Offset: 0x009934F9
		// (set) Token: 0x060241DB RID: 147931 RVA: 0x0099530D File Offset: 0x0099350D
		public unsafe UKuroInteractionComponent ProximityTrigger
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroInteractionComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004A17 RID: 18967
		// (get) Token: 0x060241DC RID: 147932 RVA: 0x00995322 File Offset: 0x00993522
		// (set) Token: 0x060241DD RID: 147933 RVA: 0x00995336 File Offset: 0x00993536
		public unsafe UStaticMeshComponent UpSM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004A18 RID: 18968
		// (get) Token: 0x060241DE RID: 147934 RVA: 0x0099534B File Offset: 0x0099354B
		// (set) Token: 0x060241DF RID: 147935 RVA: 0x0099535F File Offset: 0x0099355F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionLight_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004A19 RID: 18969
		// (get) Token: 0x060241E0 RID: 147936 RVA: 0x00995374 File Offset: 0x00993574
		// (set) Token: 0x060241E1 RID: 147937 RVA: 0x00995388 File Offset: 0x00993588
		public unsafe FVector SkillPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004A1A RID: 18970
		// (get) Token: 0x060241E2 RID: 147938 RVA: 0x0099539D File Offset: 0x0099359D
		// (set) Token: 0x060241E3 RID: 147939 RVA: 0x009953AD File Offset: 0x009935AD
		public unsafe float InteractionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004A1B RID: 18971
		// (get) Token: 0x060241E4 RID: 147940 RVA: 0x009953BE File Offset: 0x009935BE
		// (set) Token: 0x060241E5 RID: 147941 RVA: 0x009953CE File Offset: 0x009935CE
		public unsafe bool IsChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A1C RID: 18972
		// (get) Token: 0x060241E6 RID: 147942 RVA: 0x009953DF File Offset: 0x009935DF
		// (set) Token: 0x060241E7 RID: 147943 RVA: 0x009953EF File Offset: 0x009935EF
		public unsafe int TargetId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004A1D RID: 18973
		// (get) Token: 0x060241E8 RID: 147944 RVA: 0x00995400 File Offset: 0x00993600
		// (set) Token: 0x060241E9 RID: 147945 RVA: 0x00995410 File Offset: 0x00993610
		public unsafe int DefaultID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004A1E RID: 18974
		// (get) Token: 0x060241EA RID: 147946 RVA: 0x00995421 File Offset: 0x00993621
		// (set) Token: 0x060241EB RID: 147947 RVA: 0x00995431 File Offset: 0x00993631
		public unsafe float ResetTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004A1F RID: 18975
		// (get) Token: 0x060241EC RID: 147948 RVA: 0x00995442 File Offset: 0x00993642
		// (set) Token: 0x060241ED RID: 147949 RVA: 0x00995456 File Offset: 0x00993656
		public unsafe FVectorDouble ActorPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004A20 RID: 18976
		// (get) Token: 0x060241EE RID: 147950 RVA: 0x0099546B File Offset: 0x0099366B
		// (set) Token: 0x060241EF RID: 147951 RVA: 0x0099547B File Offset: 0x0099367B
		public unsafe float DebounceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004A21 RID: 18977
		// (get) Token: 0x060241F0 RID: 147952 RVA: 0x0099548C File Offset: 0x0099368C
		// (set) Token: 0x060241F1 RID: 147953 RVA: 0x009954A0 File Offset: 0x009936A0
		public unsafe FLinearColor Fall_Off_Color_Tint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004A22 RID: 18978
		// (get) Token: 0x060241F2 RID: 147954 RVA: 0x009954B5 File Offset: 0x009936B5
		// (set) Token: 0x060241F3 RID: 147955 RVA: 0x009954C5 File Offset: 0x009936C5
		public unsafe int TestId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionLight_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x060241F4 RID: 147956 RVA: 0x009954D6 File Offset: 0x009936D6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CanChange()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionLight_C.__CanChange_NativeFunctionPtr, null);
		}

		// Token: 0x060241F5 RID: 147957 RVA: 0x009954EA File Offset: 0x009936EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060241F6 RID: 147958 RVA: 0x009954FE File Offset: 0x009936FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060241F7 RID: 147959 RVA: 0x00995514 File Offset: 0x00993714
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeapon(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_InteractionLight_C.__OnWeapon_FunctionParams* ptr = stackalloc BP_InteractionLight_C.__OnWeapon_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_InteractionLight_C.__OnWeapon_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionLight_C.__OnWeapon_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionLight_C.__OnWeapon_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060241F8 RID: 147960 RVA: 0x00995578 File Offset: 0x00993778
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_InteractionLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractionLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractionLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060241F9 RID: 147961 RVA: 0x009955C0 File Offset: 0x009937C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_InteractionLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractionLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractionLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060241FA RID: 147962 RVA: 0x00995607 File Offset: 0x00993807
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060241FB RID: 147963 RVA: 0x0099561B File Offset: 0x0099381B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060241FC RID: 147964 RVA: 0x00995630 File Offset: 0x00993830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteractionLight(int EntryPoint)
		{
			BP_InteractionLight_C.__ExecuteUbergraph_BP_InteractionLight_FunctionParams* ptr = stackalloc BP_InteractionLight_C.__ExecuteUbergraph_BP_InteractionLight_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(BP_InteractionLight_C.__ExecuteUbergraph_BP_InteractionLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionLight_C.__ExecuteUbergraph_BP_InteractionLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionLight_C.__ExecuteUbergraph_BP_InteractionLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060241FD RID: 147965 RVA: 0x0099567A File Offset: 0x0099387A
		protected BP_InteractionLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012775 RID: 75637
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/InteractionLight/BP_InteractionLight.BP_InteractionLight_C";

		// Token: 0x04012776 RID: 75638
		private static IntPtr _ClassPtr;

		// Token: 0x04012777 RID: 75639
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012778 RID: 75640
		internal static int __PropertyOffset_0;

		// Token: 0x04012779 RID: 75641
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401277A RID: 75642
		internal static int __PropertyOffset_1;

		// Token: 0x0401277B RID: 75643
		internal static int __PropertyOffset_2;

		// Token: 0x0401277C RID: 75644
		internal static int __PropertyOffset_3;

		// Token: 0x0401277D RID: 75645
		internal static int __PropertyOffset_4;

		// Token: 0x0401277E RID: 75646
		internal static int __PropertyOffset_5;

		// Token: 0x0401277F RID: 75647
		internal static int __PropertyOffset_6;

		// Token: 0x04012780 RID: 75648
		internal static int __PropertyOffset_7;

		// Token: 0x04012781 RID: 75649
		internal static int __PropertyOffset_8;

		// Token: 0x04012782 RID: 75650
		internal static int __PropertyOffset_9;

		// Token: 0x04012783 RID: 75651
		internal static int __PropertyOffset_10;

		// Token: 0x04012784 RID: 75652
		internal static int __PropertyOffset_11;

		// Token: 0x04012785 RID: 75653
		internal static int __PropertyOffset_12;

		// Token: 0x04012786 RID: 75654
		internal static int __PropertyOffset_13;

		// Token: 0x04012787 RID: 75655
		internal static int __PropertyOffset_14;

		// Token: 0x04012788 RID: 75656
		internal static int __PropertyOffset_15;

		// Token: 0x04012789 RID: 75657
		internal static int __PropertyOffset_16;

		// Token: 0x0401278A RID: 75658
		private static IntPtr __CanChange_NativeFunctionPtr;

		// Token: 0x0401278B RID: 75659
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401278C RID: 75660
		private static IntPtr __OnWeapon_NativeFunctionPtr;

		// Token: 0x0401278D RID: 75661
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401278E RID: 75662
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401278F RID: 75663
		private static IntPtr __ExecuteUbergraph_BP_InteractionLight_NativeFunctionPtr;

		// Token: 0x02009D8E RID: 40334
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeapon_FunctionParams
		{
			// Token: 0x04032783 RID: 206723
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032784 RID: 206724
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032785 RID: 206725
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009D8F RID: 40335
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032786 RID: 206726
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D90 RID: 40336
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __ExecuteUbergraph_BP_InteractionLight_FunctionParams
		{
			// Token: 0x04032787 RID: 206727
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
