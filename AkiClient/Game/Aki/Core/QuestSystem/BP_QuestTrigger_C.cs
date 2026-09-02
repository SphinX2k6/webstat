using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Quest.Structures;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.QuestSystem
{
	// Token: 0x02003F4A RID: 16202
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/QuestSystem/BP_QuestTrigger.BP_QuestTrigger_C")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1144)]
	public class BP_QuestTrigger_C : ATriggerSphere, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060287A0 RID: 165792 RVA: 0x00A0C31B File Offset: 0x00A0A51B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QuestTrigger_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/QuestSystem/BP_QuestTrigger.BP_QuestTrigger_C");
			}
			return BP_QuestTrigger_C._ClassPtr;
		}

		// Token: 0x060287A1 RID: 165793 RVA: 0x00A0C340 File Offset: 0x00A0A540
		public BP_QuestTrigger_C() : this(BuiltinUtils.AllocNativeUObject(BP_QuestTrigger_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060287A2 RID: 165794 RVA: 0x00A0C368 File Offset: 0x00A0A568
		[NullableContext(1)]
		public BP_QuestTrigger_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QuestTrigger_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700626F RID: 25199
		// (get) Token: 0x060287A3 RID: 165795 RVA: 0x00A0C39C File Offset: 0x00A0A59C
		// (set) Token: 0x060287A4 RID: 165796 RVA: 0x00A0C3D5 File Offset: 0x00A0A5D5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006270 RID: 25200
		// (get) Token: 0x060287A5 RID: 165797 RVA: 0x00A0C3F6 File Offset: 0x00A0A5F6
		// (set) Token: 0x060287A6 RID: 165798 RVA: 0x00A0C40A File Offset: 0x00A0A60A
		public unsafe UTextRenderComponent TextRenderTime
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006271 RID: 25201
		// (get) Token: 0x060287A7 RID: 165799 RVA: 0x00A0C41F File Offset: 0x00A0A61F
		// (set) Token: 0x060287A8 RID: 165800 RVA: 0x00A0C433 File Offset: 0x00A0A633
		public unsafe UTextRenderComponent TextRenderDes
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17006272 RID: 25202
		// (get) Token: 0x060287A9 RID: 165801 RVA: 0x00A0C448 File Offset: 0x00A0A648
		// (set) Token: 0x060287AA RID: 165802 RVA: 0x00A0C45C File Offset: 0x00A0A65C
		public unsafe AActor player
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17006273 RID: 25203
		// (get) Token: 0x060287AB RID: 165803 RVA: 0x00A0C474 File Offset: 0x00A0A674
		// (set) Token: 0x060287AC RID: 165804 RVA: 0x00A0C4AD File Offset: 0x00A0A6AD
		[Nullable(1)]
		public TArray<SQuestRequest> QuestTriggerInfo
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SQuestRequest> result;
				if ((result = this._QuestTriggerInfo) == null)
				{
					result = (this._QuestTriggerInfo = new TArray<SQuestRequest>(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.QuestTriggerInfo.CopyAssign(value);
			}
		}

		// Token: 0x17006274 RID: 25204
		// (get) Token: 0x060287AD RID: 165805 RVA: 0x00A0C4BB File Offset: 0x00A0A6BB
		// (set) Token: 0x060287AE RID: 165806 RVA: 0x00A0C4CB File Offset: 0x00A0A6CB
		public unsafe int currindex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006275 RID: 25205
		// (get) Token: 0x060287AF RID: 165807 RVA: 0x00A0C4DC File Offset: 0x00A0A6DC
		// (set) Token: 0x060287B0 RID: 165808 RVA: 0x00A0C4EC File Offset: 0x00A0A6EC
		public unsafe bool bIsEnableInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006276 RID: 25206
		// (get) Token: 0x060287B1 RID: 165809 RVA: 0x00A0C500 File Offset: 0x00A0A700
		// (set) Token: 0x060287B2 RID: 165810 RVA: 0x00A0C539 File Offset: 0x00A0A739
		[Nullable(1)]
		public unsafe FText QuestDescription
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._QuestDescription) == null)
				{
					result = (this._QuestDescription = new FText(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)BP_QuestTrigger_C.__PropertyOffset_7)), value.NativePtr, 1);
			}
		}

		// Token: 0x17006277 RID: 25207
		// (get) Token: 0x060287B3 RID: 165811 RVA: 0x00A0C554 File Offset: 0x00A0A754
		// (set) Token: 0x060287B4 RID: 165812 RVA: 0x00A0C58D File Offset: 0x00A0A78D
		[Nullable(1)]
		public FTimerHandle timerhandler
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FTimerHandle result;
				if ((result = this._timerhandler) == null)
				{
					result = (this._timerhandler = new FTimerHandle(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FTimerHandle.StaticStruct(), base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006278 RID: 25208
		// (get) Token: 0x060287B5 RID: 165813 RVA: 0x00A0C5AE File Offset: 0x00A0A7AE
		// (set) Token: 0x060287B6 RID: 165814 RVA: 0x00A0C5BE File Offset: 0x00A0A7BE
		public unsafe bool bIsEnableDisplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006279 RID: 25209
		// (get) Token: 0x060287B7 RID: 165815 RVA: 0x00A0C5CF File Offset: 0x00A0A7CF
		// (set) Token: 0x060287B8 RID: 165816 RVA: 0x00A0C5DF File Offset: 0x00A0A7DF
		public unsafe bool bIsAutoTriggered
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700627A RID: 25210
		// (get) Token: 0x060287B9 RID: 165817 RVA: 0x00A0C5F0 File Offset: 0x00A0A7F0
		// (set) Token: 0x060287BA RID: 165818 RVA: 0x00A0C604 File Offset: 0x00A0A804
		public unsafe FColor DescriptionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x060287BB RID: 165819 RVA: 0x00A0C619 File Offset: 0x00A0A819
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060287BC RID: 165820 RVA: 0x00A0C62D File Offset: 0x00A0A82D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060287BD RID: 165821 RVA: 0x00A0C644 File Offset: 0x00A0A844
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_G_K2Node_InputKeyEvent_0(FKey Key)
		{
			BP_QuestTrigger_C.__InpActEvt_G_K2Node_InputKeyEvent_0_FunctionParams* ptr = stackalloc BP_QuestTrigger_C.__InpActEvt_G_K2Node_InputKeyEvent_0_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_QuestTrigger_C.__InpActEvt_G_K2Node_InputKeyEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_C.__InpActEvt_G_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_C.__InpActEvt_G_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_QuestTrigger_C.__InpActEvt_G_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060287BE RID: 165822 RVA: 0x00A0C6B6 File Offset: 0x00A0A8B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060287BF RID: 165823 RVA: 0x00A0C6CA File Offset: 0x00A0A8CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060287C0 RID: 165824 RVA: 0x00A0C6E0 File Offset: 0x00A0A8E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_QuestTrigger_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_QuestTrigger_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrigger_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060287C1 RID: 165825 RVA: 0x00A0C738 File Offset: 0x00A0A938
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_QuestTrigger_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_QuestTrigger_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrigger_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060287C2 RID: 165826 RVA: 0x00A0C790 File Offset: 0x00A0A990
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_QuestTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QuestTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QuestTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060287C3 RID: 165827 RVA: 0x00A0C7D8 File Offset: 0x00A0A9D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_QuestTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QuestTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QuestTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060287C4 RID: 165828 RVA: 0x00A0C820 File Offset: 0x00A0AA20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			BP_QuestTrigger_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_QuestTrigger_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrigger_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060287C5 RID: 165829 RVA: 0x00A0C878 File Offset: 0x00A0AA78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			BP_QuestTrigger_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_QuestTrigger_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrigger_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060287C6 RID: 165830 RVA: 0x00A0C8CE File Offset: 0x00A0AACE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TimeDisplay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_C.__TimeDisplay_NativeFunctionPtr, null);
		}

		// Token: 0x060287C7 RID: 165831 RVA: 0x00A0C8E2 File Offset: 0x00A0AAE2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void QuestRequest()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_C.__QuestRequest_NativeFunctionPtr, null);
		}

		// Token: 0x060287C8 RID: 165832 RVA: 0x00A0C8F8 File Offset: 0x00A0AAF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_QuestTrigger(int EntryPoint)
		{
			BP_QuestTrigger_C.__ExecuteUbergraph_BP_QuestTrigger_FunctionParams* ptr = stackalloc BP_QuestTrigger_C.__ExecuteUbergraph_BP_QuestTrigger_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_QuestTrigger_C.__ExecuteUbergraph_BP_QuestTrigger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_C.__ExecuteUbergraph_BP_QuestTrigger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_C.__ExecuteUbergraph_BP_QuestTrigger_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060287C9 RID: 165833 RVA: 0x00A0C942 File Offset: 0x00A0AB42
		protected BP_QuestTrigger_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040154C3 RID: 87235
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/QuestSystem/BP_QuestTrigger.BP_QuestTrigger_C";

		// Token: 0x040154C4 RID: 87236
		private static IntPtr _ClassPtr;

		// Token: 0x040154C5 RID: 87237
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040154C6 RID: 87238
		internal static int __PropertyOffset_0;

		// Token: 0x040154C7 RID: 87239
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040154C8 RID: 87240
		internal static int __PropertyOffset_1;

		// Token: 0x040154C9 RID: 87241
		internal static int __PropertyOffset_2;

		// Token: 0x040154CA RID: 87242
		internal static int __PropertyOffset_3;

		// Token: 0x040154CB RID: 87243
		internal static int __PropertyOffset_4;

		// Token: 0x040154CC RID: 87244
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SQuestRequest> _QuestTriggerInfo;

		// Token: 0x040154CD RID: 87245
		internal static int __PropertyOffset_5;

		// Token: 0x040154CE RID: 87246
		internal static int __PropertyOffset_6;

		// Token: 0x040154CF RID: 87247
		internal static int __PropertyOffset_7;

		// Token: 0x040154D0 RID: 87248
		private FText _QuestDescription;

		// Token: 0x040154D1 RID: 87249
		internal static int __PropertyOffset_8;

		// Token: 0x040154D2 RID: 87250
		private FTimerHandle _timerhandler;

		// Token: 0x040154D3 RID: 87251
		internal static int __PropertyOffset_9;

		// Token: 0x040154D4 RID: 87252
		internal static int __PropertyOffset_10;

		// Token: 0x040154D5 RID: 87253
		internal static int __PropertyOffset_11;

		// Token: 0x040154D6 RID: 87254
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040154D7 RID: 87255
		private static IntPtr __InpActEvt_G_K2Node_InputKeyEvent_0_NativeFunctionPtr;

		// Token: 0x040154D8 RID: 87256
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040154D9 RID: 87257
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x040154DA RID: 87258
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040154DB RID: 87259
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x040154DC RID: 87260
		private static IntPtr __TimeDisplay_NativeFunctionPtr;

		// Token: 0x040154DD RID: 87261
		private static IntPtr __QuestRequest_NativeFunctionPtr;

		// Token: 0x040154DE RID: 87262
		private static IntPtr __ExecuteUbergraph_BP_QuestTrigger_NativeFunctionPtr;

		// Token: 0x0200A108 RID: 41224
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_G_K2Node_InputKeyEvent_0_FunctionParams
		{
			// Token: 0x04032DF0 RID: 208368
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200A109 RID: 41225
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x04032DF1 RID: 208369
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x0200A10A RID: 41226
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032DF2 RID: 208370
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A10B RID: 41227
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x04032DF3 RID: 208371
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x0200A10C RID: 41228
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_QuestTrigger_FunctionParams
		{
			// Token: 0x04032DF4 RID: 208372
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
