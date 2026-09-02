using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Common
{
	// Token: 0x020040ED RID: 16621
	[UnrealObjectPath("/Game/Aki/Character/NPC/Common/BP_BaseNPC.BP_BaseNPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_BaseNPC_C : __TsBaseCharacter_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C0C6 RID: 180422 RVA: 0x00A9305C File Offset: 0x00A9125C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Common/BP_BaseNPC.BP_BaseNPC_C");
			}
			return BP_BaseNPC_C._ClassPtr;
		}

		// Token: 0x0602C0C7 RID: 180423 RVA: 0x00A93080 File Offset: 0x00A91280
		public BP_BaseNPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C0C8 RID: 180424 RVA: 0x00A930A8 File Offset: 0x00A912A8
		[NullableContext(1)]
		public BP_BaseNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170075D7 RID: 30167
		// (get) Token: 0x0602C0C9 RID: 180425 RVA: 0x00A930DC File Offset: 0x00A912DC
		// (set) Token: 0x0602C0CA RID: 180426 RVA: 0x00A93115 File Offset: 0x00A91315
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075D8 RID: 30168
		// (get) Token: 0x0602C0CB RID: 180427 RVA: 0x00A93136 File Offset: 0x00A91336
		// (set) Token: 0x0602C0CC RID: 180428 RVA: 0x00A9314A File Offset: 0x00A9134A
		[Nullable(2)]
		public unsafe UBoxComponent HitCollision
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseNPC_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseNPC_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170075D9 RID: 30169
		// (get) Token: 0x0602C0CD RID: 180429 RVA: 0x00A9315F File Offset: 0x00A9135F
		// (set) Token: 0x0602C0CE RID: 180430 RVA: 0x00A93173 File Offset: 0x00A91373
		[Nullable(2)]
		public unsafe UNavigationInvokerComponent NavigationInvoker_0
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNavigationInvokerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseNPC_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseNPC_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170075DA RID: 30170
		// (get) Token: 0x0602C0CF RID: 180431 RVA: 0x00A93188 File Offset: 0x00A91388
		// (set) Token: 0x0602C0D0 RID: 180432 RVA: 0x00A93198 File Offset: 0x00A91398
		public unsafe bool IsBeingImpacted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075DB RID: 30171
		// (get) Token: 0x0602C0D1 RID: 180433 RVA: 0x00A931A9 File Offset: 0x00A913A9
		// (set) Token: 0x0602C0D2 RID: 180434 RVA: 0x00A931B9 File Offset: 0x00A913B9
		public unsafe float Direction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170075DC RID: 30172
		// (get) Token: 0x0602C0D3 RID: 180435 RVA: 0x00A931CA File Offset: 0x00A913CA
		// (set) Token: 0x0602C0D4 RID: 180436 RVA: 0x00A931DA File Offset: 0x00A913DA
		public unsafe float Strength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170075DD RID: 30173
		// (get) Token: 0x0602C0D5 RID: 180437 RVA: 0x00A931EB File Offset: 0x00A913EB
		// (set) Token: 0x0602C0D6 RID: 180438 RVA: 0x00A931FB File Offset: 0x00A913FB
		public unsafe bool IsBeingAttacked
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075DE RID: 30174
		// (get) Token: 0x0602C0D7 RID: 180439 RVA: 0x00A9320C File Offset: 0x00A9140C
		// (set) Token: 0x0602C0D8 RID: 180440 RVA: 0x00A9321C File Offset: 0x00A9141C
		public unsafe bool CanPlayerImpact
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075DF RID: 30175
		// (get) Token: 0x0602C0D9 RID: 180441 RVA: 0x00A9322D File Offset: 0x00A9142D
		// (set) Token: 0x0602C0DA RID: 180442 RVA: 0x00A9323D File Offset: 0x00A9143D
		public unsafe bool CanPlayerAttack
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075E0 RID: 30176
		// (get) Token: 0x0602C0DB RID: 180443 RVA: 0x00A9324E File Offset: 0x00A9144E
		// (set) Token: 0x0602C0DC RID: 180444 RVA: 0x00A9325E File Offset: 0x00A9145E
		public unsafe bool CanLookAtPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075E1 RID: 30177
		// (get) Token: 0x0602C0DD RID: 180445 RVA: 0x00A93270 File Offset: 0x00A91470
		// (set) Token: 0x0602C0DE RID: 180446 RVA: 0x00A932A9 File Offset: 0x00A914A9
		[Nullable(1)]
		public FSoftObjectPath BornEffect
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._BornEffect) == null)
				{
					result = (this._BornEffect = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075E2 RID: 30178
		// (get) Token: 0x0602C0DF RID: 180447 RVA: 0x00A932CA File Offset: 0x00A914CA
		// (set) Token: 0x0602C0E0 RID: 180448 RVA: 0x00A932DE File Offset: 0x00A914DE
		[Nullable(2)]
		public unsafe USkeletalMeshComponent CombineFaceMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseNPC_C.__PropertyOffset_11);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseNPC_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170075E3 RID: 30179
		// (get) Token: 0x0602C0E1 RID: 180449 RVA: 0x00A932F3 File Offset: 0x00A914F3
		// (set) Token: 0x0602C0E2 RID: 180450 RVA: 0x00A93303 File Offset: 0x00A91503
		public unsafe bool CanUpdateTextureFace
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075E4 RID: 30180
		// (get) Token: 0x0602C0E3 RID: 180451 RVA: 0x00A93314 File Offset: 0x00A91514
		// (set) Token: 0x0602C0E4 RID: 180452 RVA: 0x00A93324 File Offset: 0x00A91524
		public unsafe bool IsEnableIK
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseNPC_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602C0E5 RID: 180453 RVA: 0x00A93338 File Offset: 0x00A91538
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 检查是否玩家攻击(ref bool IsAttack)
		{
			BP_BaseNPC_C.__检查是否玩家攻击_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__检查是否玩家攻击_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BaseNPC_C.__检查是否玩家攻击_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__检查是否玩家攻击_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsAttack = IsAttack;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__检查是否玩家攻击_NativeFunctionPtr, (void*)ptr);
			IsAttack = ptr->IsAttack;
		}

		// Token: 0x0602C0E6 RID: 180454 RVA: 0x00A93388 File Offset: 0x00A91588
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通知AIC攻击结果(bool IsAttack)
		{
			BP_BaseNPC_C.__通知AIC攻击结果_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__通知AIC攻击结果_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_BaseNPC_C.__通知AIC攻击结果_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__通知AIC攻击结果_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsAttack = IsAttack;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__通知AIC攻击结果_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0E7 RID: 180455 RVA: 0x00A933D0 File Offset: 0x00A915D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 执行攻击处理(ref bool Success)
		{
			BP_BaseNPC_C.__执行攻击处理_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__执行攻击处理_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BaseNPC_C.__执行攻击处理_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__执行攻击处理_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Success = Success;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__执行攻击处理_NativeFunctionPtr, (void*)ptr);
			Success = ptr->Success;
		}

		// Token: 0x0602C0E8 RID: 180456 RVA: 0x00A93420 File Offset: 0x00A91620
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 执行冲撞处理(ref bool Success)
		{
			BP_BaseNPC_C.__执行冲撞处理_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__执行冲撞处理_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_BaseNPC_C.__执行冲撞处理_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__执行冲撞处理_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Success = Success;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__执行冲撞处理_NativeFunctionPtr, (void*)ptr);
			Success = ptr->Success;
		}

		// Token: 0x0602C0E9 RID: 180457 RVA: 0x00A93474 File Offset: 0x00A91674
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通知AIC冲撞结果(bool IsImpact)
		{
			BP_BaseNPC_C.__通知AIC冲撞结果_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__通知AIC冲撞结果_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_BaseNPC_C.__通知AIC冲撞结果_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__通知AIC冲撞结果_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsImpact = IsImpact;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__通知AIC冲撞结果_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0EA RID: 180458 RVA: 0x00A934BC File Offset: 0x00A916BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置硬直(bool Value)
		{
			BP_BaseNPC_C.__设置硬直_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__设置硬直_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(BP_BaseNPC_C.__设置硬直_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__设置硬直_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Value = Value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__设置硬直_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0EB RID: 180459 RVA: 0x00A93502 File Offset: 0x00A91702
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void initAI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__initAI_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0EC RID: 180460 RVA: 0x00A93518 File Offset: 0x00A91718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BaseNPC_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseNPC_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0ED RID: 180461 RVA: 0x00A93560 File Offset: 0x00A91760
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BaseNPC_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseNPC_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseNPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C0EE RID: 180462 RVA: 0x00A935A7 File Offset: 0x00A917A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0EF RID: 180463 RVA: 0x00A935BB File Offset: 0x00A917BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseNPC_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C0F0 RID: 180464 RVA: 0x00A935D0 File Offset: 0x00A917D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0F1 RID: 180465 RVA: 0x00A9365C File Offset: 0x00A9185C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseNPC_C.__BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0F2 RID: 180466 RVA: 0x00A93718 File Offset: 0x00A91918
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BaseNPC(int EntryPoint)
		{
			BP_BaseNPC_C.__ExecuteUbergraph_BP_BaseNPC_FunctionParams* ptr = stackalloc BP_BaseNPC_C.__ExecuteUbergraph_BP_BaseNPC_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_BaseNPC_C.__ExecuteUbergraph_BP_BaseNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseNPC_C.__ExecuteUbergraph_BP_BaseNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseNPC_C.__ExecuteUbergraph_BP_BaseNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C0F3 RID: 180467 RVA: 0x00A93762 File Offset: 0x00A91962
		protected BP_BaseNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401858C RID: 99724
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Common/BP_BaseNPC.BP_BaseNPC_C";

		// Token: 0x0401858D RID: 99725
		private static IntPtr _ClassPtr;

		// Token: 0x0401858E RID: 99726
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401858F RID: 99727
		internal static int __PropertyOffset_0;

		// Token: 0x04018590 RID: 99728
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018591 RID: 99729
		internal static int __PropertyOffset_1;

		// Token: 0x04018592 RID: 99730
		internal static int __PropertyOffset_2;

		// Token: 0x04018593 RID: 99731
		internal static int __PropertyOffset_3;

		// Token: 0x04018594 RID: 99732
		internal static int __PropertyOffset_4;

		// Token: 0x04018595 RID: 99733
		internal static int __PropertyOffset_5;

		// Token: 0x04018596 RID: 99734
		internal static int __PropertyOffset_6;

		// Token: 0x04018597 RID: 99735
		internal static int __PropertyOffset_7;

		// Token: 0x04018598 RID: 99736
		internal static int __PropertyOffset_8;

		// Token: 0x04018599 RID: 99737
		internal static int __PropertyOffset_9;

		// Token: 0x0401859A RID: 99738
		internal static int __PropertyOffset_10;

		// Token: 0x0401859B RID: 99739
		[Nullable(2)]
		private FSoftObjectPath _BornEffect;

		// Token: 0x0401859C RID: 99740
		internal static int __PropertyOffset_11;

		// Token: 0x0401859D RID: 99741
		internal static int __PropertyOffset_12;

		// Token: 0x0401859E RID: 99742
		internal static int __PropertyOffset_13;

		// Token: 0x0401859F RID: 99743
		private static IntPtr __检查是否玩家攻击_NativeFunctionPtr;

		// Token: 0x040185A0 RID: 99744
		private static IntPtr __通知AIC攻击结果_NativeFunctionPtr;

		// Token: 0x040185A1 RID: 99745
		private static IntPtr __执行攻击处理_NativeFunctionPtr;

		// Token: 0x040185A2 RID: 99746
		private static IntPtr __执行冲撞处理_NativeFunctionPtr;

		// Token: 0x040185A3 RID: 99747
		private static IntPtr __通知AIC冲撞结果_NativeFunctionPtr;

		// Token: 0x040185A4 RID: 99748
		private static IntPtr __设置硬直_NativeFunctionPtr;

		// Token: 0x040185A5 RID: 99749
		private static IntPtr __initAI_NativeFunctionPtr;

		// Token: 0x040185A6 RID: 99750
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040185A7 RID: 99751
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040185A8 RID: 99752
		private static IntPtr __BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040185A9 RID: 99753
		private static IntPtr __BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040185AA RID: 99754
		private static IntPtr __ExecuteUbergraph_BP_BaseNPC_NativeFunctionPtr;

		// Token: 0x0200A416 RID: 42006
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __检查是否玩家攻击_FunctionParams
		{
			// Token: 0x04033205 RID: 209413
			[FieldOffset(0)]
			public bool IsAttack;
		}

		// Token: 0x0200A417 RID: 42007
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __通知AIC攻击结果_FunctionParams
		{
			// Token: 0x04033206 RID: 209414
			[FieldOffset(0)]
			public bool IsAttack;
		}

		// Token: 0x0200A418 RID: 42008
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __执行攻击处理_FunctionParams
		{
			// Token: 0x04033207 RID: 209415
			[FieldOffset(0)]
			public bool Success;
		}

		// Token: 0x0200A419 RID: 42009
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected ref struct __执行冲撞处理_FunctionParams
		{
			// Token: 0x04033208 RID: 209416
			[FieldOffset(0)]
			public bool Success;
		}

		// Token: 0x0200A41A RID: 42010
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __通知AIC冲撞结果_FunctionParams
		{
			// Token: 0x04033209 RID: 209417
			[FieldOffset(0)]
			public bool IsImpact;
		}

		// Token: 0x0200A41B RID: 42011
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected ref struct __设置硬直_FunctionParams
		{
			// Token: 0x0403320A RID: 209418
			[FieldOffset(0)]
			public bool Value;
		}

		// Token: 0x0200A41C RID: 42012
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403320B RID: 209419
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A41D RID: 42013
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403320C RID: 209420
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403320D RID: 209421
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403320E RID: 209422
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403320F RID: 209423
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x0200A41E RID: 42014
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_BaseNPC_HitCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04033210 RID: 209424
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04033211 RID: 209425
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04033212 RID: 209426
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04033213 RID: 209427
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04033214 RID: 209428
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04033215 RID: 209429
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x0200A41F RID: 42015
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __ExecuteUbergraph_BP_BaseNPC_FunctionParams
		{
			// Token: 0x04033216 RID: 209430
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
