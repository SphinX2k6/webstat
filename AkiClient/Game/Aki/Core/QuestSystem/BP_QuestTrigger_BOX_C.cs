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
	// Token: 0x02003F49 RID: 16201
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/QuestSystem/BP_QuestTrigger_BOX.BP_QuestTrigger_BOX_C")]
	[UnrealStructLayout(1152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1152)]
	public class BP_QuestTrigger_BOX_C : ATriggerBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028774 RID: 165748 RVA: 0x00A0BCC4 File Offset: 0x00A09EC4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QuestTrigger_BOX_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/QuestSystem/BP_QuestTrigger_BOX.BP_QuestTrigger_BOX_C");
			}
			return BP_QuestTrigger_BOX_C._ClassPtr;
		}

		// Token: 0x06028775 RID: 165749 RVA: 0x00A0BCE8 File Offset: 0x00A09EE8
		public BP_QuestTrigger_BOX_C() : this(BuiltinUtils.AllocNativeUObject(BP_QuestTrigger_BOX_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028776 RID: 165750 RVA: 0x00A0BD10 File Offset: 0x00A09F10
		[NullableContext(1)]
		public BP_QuestTrigger_BOX_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QuestTrigger_BOX_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006262 RID: 25186
		// (get) Token: 0x06028777 RID: 165751 RVA: 0x00A0BD44 File Offset: 0x00A09F44
		// (set) Token: 0x06028778 RID: 165752 RVA: 0x00A0BD7D File Offset: 0x00A09F7D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006263 RID: 25187
		// (get) Token: 0x06028779 RID: 165753 RVA: 0x00A0BD9E File Offset: 0x00A09F9E
		// (set) Token: 0x0602877A RID: 165754 RVA: 0x00A0BDB2 File Offset: 0x00A09FB2
		public unsafe UBoxComponent CollisonBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_BOX_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_BOX_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006264 RID: 25188
		// (get) Token: 0x0602877B RID: 165755 RVA: 0x00A0BDC7 File Offset: 0x00A09FC7
		// (set) Token: 0x0602877C RID: 165756 RVA: 0x00A0BDDB File Offset: 0x00A09FDB
		public unsafe UTextRenderComponent TextRenderTime
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_BOX_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_BOX_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17006265 RID: 25189
		// (get) Token: 0x0602877D RID: 165757 RVA: 0x00A0BDF0 File Offset: 0x00A09FF0
		// (set) Token: 0x0602877E RID: 165758 RVA: 0x00A0BE04 File Offset: 0x00A0A004
		public unsafe UTextRenderComponent TextRenderDes
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_BOX_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_BOX_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17006266 RID: 25190
		// (get) Token: 0x0602877F RID: 165759 RVA: 0x00A0BE19 File Offset: 0x00A0A019
		// (set) Token: 0x06028780 RID: 165760 RVA: 0x00A0BE2D File Offset: 0x00A0A02D
		public unsafe AActor player
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_BOX_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrigger_BOX_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17006267 RID: 25191
		// (get) Token: 0x06028781 RID: 165761 RVA: 0x00A0BE44 File Offset: 0x00A0A044
		// (set) Token: 0x06028782 RID: 165762 RVA: 0x00A0BE7D File Offset: 0x00A0A07D
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
					result = (this._QuestTriggerInfo = new TArray<SQuestRequest>(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.QuestTriggerInfo.CopyAssign(value);
			}
		}

		// Token: 0x17006268 RID: 25192
		// (get) Token: 0x06028783 RID: 165763 RVA: 0x00A0BE8B File Offset: 0x00A0A08B
		// (set) Token: 0x06028784 RID: 165764 RVA: 0x00A0BE9B File Offset: 0x00A0A09B
		public unsafe int currindex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006269 RID: 25193
		// (get) Token: 0x06028785 RID: 165765 RVA: 0x00A0BEAC File Offset: 0x00A0A0AC
		// (set) Token: 0x06028786 RID: 165766 RVA: 0x00A0BEBC File Offset: 0x00A0A0BC
		public unsafe bool bIsEnableInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700626A RID: 25194
		// (get) Token: 0x06028787 RID: 165767 RVA: 0x00A0BED0 File Offset: 0x00A0A0D0
		// (set) Token: 0x06028788 RID: 165768 RVA: 0x00A0BF09 File Offset: 0x00A0A109
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
					result = (this._QuestDescription = new FText(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_8)), value.NativePtr, 1);
			}
		}

		// Token: 0x1700626B RID: 25195
		// (get) Token: 0x06028789 RID: 165769 RVA: 0x00A0BF24 File Offset: 0x00A0A124
		// (set) Token: 0x0602878A RID: 165770 RVA: 0x00A0BF5D File Offset: 0x00A0A15D
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
					result = (this._timerhandler = new FTimerHandle(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FTimerHandle.StaticStruct(), base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700626C RID: 25196
		// (get) Token: 0x0602878B RID: 165771 RVA: 0x00A0BF7E File Offset: 0x00A0A17E
		// (set) Token: 0x0602878C RID: 165772 RVA: 0x00A0BF8E File Offset: 0x00A0A18E
		public unsafe bool bIsEnableDisplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700626D RID: 25197
		// (get) Token: 0x0602878D RID: 165773 RVA: 0x00A0BF9F File Offset: 0x00A0A19F
		// (set) Token: 0x0602878E RID: 165774 RVA: 0x00A0BFAF File Offset: 0x00A0A1AF
		public unsafe bool bIsAutoTriggered
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700626E RID: 25198
		// (get) Token: 0x0602878F RID: 165775 RVA: 0x00A0BFC0 File Offset: 0x00A0A1C0
		// (set) Token: 0x06028790 RID: 165776 RVA: 0x00A0BFD4 File Offset: 0x00A0A1D4
		public unsafe FColor DescriptionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrigger_BOX_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x06028791 RID: 165777 RVA: 0x00A0BFE9 File Offset: 0x00A0A1E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06028792 RID: 165778 RVA: 0x00A0BFFD File Offset: 0x00A0A1FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028793 RID: 165779 RVA: 0x00A0C014 File Offset: 0x00A0A214
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_G_K2Node_InputKeyEvent_0(FKey Key)
		{
			BP_QuestTrigger_BOX_C.__InpActEvt_G_K2Node_InputKeyEvent_0_FunctionParams* ptr = stackalloc BP_QuestTrigger_BOX_C.__InpActEvt_G_K2Node_InputKeyEvent_0_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_QuestTrigger_BOX_C.__InpActEvt_G_K2Node_InputKeyEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_BOX_C.__InpActEvt_G_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__InpActEvt_G_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_QuestTrigger_BOX_C.__InpActEvt_G_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028794 RID: 165780 RVA: 0x00A0C086 File Offset: 0x00A0A286
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06028795 RID: 165781 RVA: 0x00A0C09A File Offset: 0x00A0A29A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028796 RID: 165782 RVA: 0x00A0C0B0 File Offset: 0x00A0A2B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028797 RID: 165783 RVA: 0x00A0C108 File Offset: 0x00A0A308
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028798 RID: 165784 RVA: 0x00A0C160 File Offset: 0x00A0A360
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_QuestTrigger_BOX_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QuestTrigger_BOX_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QuestTrigger_BOX_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_BOX_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028799 RID: 165785 RVA: 0x00A0C1A8 File Offset: 0x00A0A3A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_QuestTrigger_BOX_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QuestTrigger_BOX_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QuestTrigger_BOX_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_BOX_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602879A RID: 165786 RVA: 0x00A0C1F0 File Offset: 0x00A0A3F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602879B RID: 165787 RVA: 0x00A0C248 File Offset: 0x00A0A448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602879C RID: 165788 RVA: 0x00A0C29E File Offset: 0x00A0A49E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TimeDisplay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__TimeDisplay_NativeFunctionPtr, null);
		}

		// Token: 0x0602879D RID: 165789 RVA: 0x00A0C2B2 File Offset: 0x00A0A4B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void QuestRequest()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__QuestRequest_NativeFunctionPtr, null);
		}

		// Token: 0x0602879E RID: 165790 RVA: 0x00A0C2C8 File Offset: 0x00A0A4C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_QuestTrigger_BOX(int EntryPoint)
		{
			BP_QuestTrigger_BOX_C.__ExecuteUbergraph_BP_QuestTrigger_BOX_FunctionParams* ptr = stackalloc BP_QuestTrigger_BOX_C.__ExecuteUbergraph_BP_QuestTrigger_BOX_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_QuestTrigger_BOX_C.__ExecuteUbergraph_BP_QuestTrigger_BOX_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrigger_BOX_C.__ExecuteUbergraph_BP_QuestTrigger_BOX_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrigger_BOX_C.__ExecuteUbergraph_BP_QuestTrigger_BOX_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602879F RID: 165791 RVA: 0x00A0C312 File Offset: 0x00A0A512
		protected BP_QuestTrigger_BOX_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040154A6 RID: 87206
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/QuestSystem/BP_QuestTrigger_BOX.BP_QuestTrigger_BOX_C";

		// Token: 0x040154A7 RID: 87207
		private static IntPtr _ClassPtr;

		// Token: 0x040154A8 RID: 87208
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040154A9 RID: 87209
		internal static int __PropertyOffset_0;

		// Token: 0x040154AA RID: 87210
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040154AB RID: 87211
		internal static int __PropertyOffset_1;

		// Token: 0x040154AC RID: 87212
		internal static int __PropertyOffset_2;

		// Token: 0x040154AD RID: 87213
		internal static int __PropertyOffset_3;

		// Token: 0x040154AE RID: 87214
		internal static int __PropertyOffset_4;

		// Token: 0x040154AF RID: 87215
		internal static int __PropertyOffset_5;

		// Token: 0x040154B0 RID: 87216
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SQuestRequest> _QuestTriggerInfo;

		// Token: 0x040154B1 RID: 87217
		internal static int __PropertyOffset_6;

		// Token: 0x040154B2 RID: 87218
		internal static int __PropertyOffset_7;

		// Token: 0x040154B3 RID: 87219
		internal static int __PropertyOffset_8;

		// Token: 0x040154B4 RID: 87220
		private FText _QuestDescription;

		// Token: 0x040154B5 RID: 87221
		internal static int __PropertyOffset_9;

		// Token: 0x040154B6 RID: 87222
		private FTimerHandle _timerhandler;

		// Token: 0x040154B7 RID: 87223
		internal static int __PropertyOffset_10;

		// Token: 0x040154B8 RID: 87224
		internal static int __PropertyOffset_11;

		// Token: 0x040154B9 RID: 87225
		internal static int __PropertyOffset_12;

		// Token: 0x040154BA RID: 87226
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040154BB RID: 87227
		private static IntPtr __InpActEvt_G_K2Node_InputKeyEvent_0_NativeFunctionPtr;

		// Token: 0x040154BC RID: 87228
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040154BD RID: 87229
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x040154BE RID: 87230
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040154BF RID: 87231
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x040154C0 RID: 87232
		private static IntPtr __TimeDisplay_NativeFunctionPtr;

		// Token: 0x040154C1 RID: 87233
		private static IntPtr __QuestRequest_NativeFunctionPtr;

		// Token: 0x040154C2 RID: 87234
		private static IntPtr __ExecuteUbergraph_BP_QuestTrigger_BOX_NativeFunctionPtr;

		// Token: 0x0200A103 RID: 41219
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_G_K2Node_InputKeyEvent_0_FunctionParams
		{
			// Token: 0x04032DEB RID: 208363
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200A104 RID: 41220
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x04032DEC RID: 208364
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x0200A105 RID: 41221
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032DED RID: 208365
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A106 RID: 41222
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x04032DEE RID: 208366
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x0200A107 RID: 41223
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_QuestTrigger_BOX_FunctionParams
		{
			// Token: 0x04032DEF RID: 208367
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
