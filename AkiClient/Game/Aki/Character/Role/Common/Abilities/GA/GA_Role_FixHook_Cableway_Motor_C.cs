using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.GamePlay.Portal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040A5 RID: 16549
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Cableway_Motor.GA_Role_FixHook_Cableway_Motor_C")]
	[UnrealStructLayout(1728, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1721)]
	public class GA_Role_FixHook_Cableway_Motor_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B1A3 RID: 176547 RVA: 0x00A705EF File Offset: 0x00A6E7EF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_FixHook_Cableway_Motor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Cableway_Motor.GA_Role_FixHook_Cableway_Motor_C");
			}
			return GA_Role_FixHook_Cableway_Motor_C._ClassPtr;
		}

		// Token: 0x0602B1A4 RID: 176548 RVA: 0x00A70614 File Offset: 0x00A6E814
		public GA_Role_FixHook_Cableway_Motor_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_Cableway_Motor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B1A5 RID: 176549 RVA: 0x00A7063C File Offset: 0x00A6E83C
		[NullableContext(1)]
		public GA_Role_FixHook_Cableway_Motor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_Cableway_Motor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070B9 RID: 28857
		// (get) Token: 0x0602B1A6 RID: 176550 RVA: 0x00A70670 File Offset: 0x00A6E870
		// (set) Token: 0x0602B1A7 RID: 176551 RVA: 0x00A706A9 File Offset: 0x00A6E8A9
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070BA RID: 28858
		// (get) Token: 0x0602B1A8 RID: 176552 RVA: 0x00A706CA File Offset: 0x00A6E8CA
		// (set) Token: 0x0602B1A9 RID: 176553 RVA: 0x00A706DE File Offset: 0x00A6E8DE
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170070BB RID: 28859
		// (get) Token: 0x0602B1AA RID: 176554 RVA: 0x00A706F3 File Offset: 0x00A6E8F3
		// (set) Token: 0x0602B1AB RID: 176555 RVA: 0x00A70707 File Offset: 0x00A6E907
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170070BC RID: 28860
		// (get) Token: 0x0602B1AC RID: 176556 RVA: 0x00A7071C File Offset: 0x00A6E91C
		// (set) Token: 0x0602B1AD RID: 176557 RVA: 0x00A70730 File Offset: 0x00A6E930
		public unsafe FVectorDouble 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170070BD RID: 28861
		// (get) Token: 0x0602B1AE RID: 176558 RVA: 0x00A70745 File Offset: 0x00A6E945
		// (set) Token: 0x0602B1AF RID: 176559 RVA: 0x00A70755 File Offset: 0x00A6E955
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170070BE RID: 28862
		// (get) Token: 0x0602B1B0 RID: 176560 RVA: 0x00A70766 File Offset: 0x00A6E966
		// (set) Token: 0x0602B1B1 RID: 176561 RVA: 0x00A70776 File Offset: 0x00A6E976
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170070BF RID: 28863
		// (get) Token: 0x0602B1B2 RID: 176562 RVA: 0x00A70787 File Offset: 0x00A6E987
		// (set) Token: 0x0602B1B3 RID: 176563 RVA: 0x00A7079B File Offset: 0x00A6E99B
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170070C0 RID: 28864
		// (get) Token: 0x0602B1B4 RID: 176564 RVA: 0x00A707B0 File Offset: 0x00A6E9B0
		// (set) Token: 0x0602B1B5 RID: 176565 RVA: 0x00A707E9 File Offset: 0x00A6E9E9
		[Nullable(1)]
		public TArray<FVectorDouble> FixHookPathways
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._FixHookPathways) == null)
				{
					result = (this._FixHookPathways = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FixHookPathways.CopyAssign(value);
			}
		}

		// Token: 0x170070C1 RID: 28865
		// (get) Token: 0x0602B1B6 RID: 176566 RVA: 0x00A707F7 File Offset: 0x00A6E9F7
		// (set) Token: 0x0602B1B7 RID: 176567 RVA: 0x00A7080B File Offset: 0x00A6EA0B
		public unsafe BP_KuroPortalCapture_C FixHookEnterPortalCapture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_KuroPortalCapture_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170070C2 RID: 28866
		// (get) Token: 0x0602B1B8 RID: 176568 RVA: 0x00A70820 File Offset: 0x00A6EA20
		// (set) Token: 0x0602B1B9 RID: 176569 RVA: 0x00A70834 File Offset: 0x00A6EA34
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170070C3 RID: 28867
		// (get) Token: 0x0602B1BA RID: 176570 RVA: 0x00A70849 File Offset: 0x00A6EA49
		// (set) Token: 0x0602B1BB RID: 176571 RVA: 0x00A70859 File Offset: 0x00A6EA59
		public unsafe bool 是否忽略碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170070C4 RID: 28868
		// (get) Token: 0x0602B1BC RID: 176572 RVA: 0x00A7086A File Offset: 0x00A6EA6A
		// (set) Token: 0x0602B1BD RID: 176573 RVA: 0x00A7087A File Offset: 0x00A6EA7A
		public unsafe int 当前角色穿透值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170070C5 RID: 28869
		// (get) Token: 0x0602B1BE RID: 176574 RVA: 0x00A7088B File Offset: 0x00A6EA8B
		// (set) Token: 0x0602B1BF RID: 176575 RVA: 0x00A7089F File Offset: 0x00A6EA9F
		public unsafe UGameplayTask_WaitDelay Async_Task
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UGameplayTask_WaitDelay>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170070C6 RID: 28870
		// (get) Token: 0x0602B1C0 RID: 176576 RVA: 0x00A708B4 File Offset: 0x00A6EAB4
		// (set) Token: 0x0602B1C1 RID: 176577 RVA: 0x00A708C8 File Offset: 0x00A6EAC8
		public unsafe UKuroBooleanEventBinder OnCableWayMoveEndEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroBooleanEventBinder>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170070C7 RID: 28871
		// (get) Token: 0x0602B1C2 RID: 176578 RVA: 0x00A708DD File Offset: 0x00A6EADD
		// (set) Token: 0x0602B1C3 RID: 176579 RVA: 0x00A708ED File Offset: 0x00A6EAED
		public unsafe int 变身材质handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170070C8 RID: 28872
		// (get) Token: 0x0602B1C4 RID: 176580 RVA: 0x00A708FE File Offset: 0x00A6EAFE
		// (set) Token: 0x0602B1C5 RID: 176581 RVA: 0x00A7090E File Offset: 0x00A6EB0E
		public unsafe int 变身特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170070C9 RID: 28873
		// (get) Token: 0x0602B1C6 RID: 176582 RVA: 0x00A7091F File Offset: 0x00A6EB1F
		// (set) Token: 0x0602B1C7 RID: 176583 RVA: 0x00A70933 File Offset: 0x00A6EB33
		public unsafe FVectorDouble Transform_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170070CA RID: 28874
		// (get) Token: 0x0602B1C8 RID: 176584 RVA: 0x00A70948 File Offset: 0x00A6EB48
		// (set) Token: 0x0602B1C9 RID: 176585 RVA: 0x00A70958 File Offset: 0x00A6EB58
		public unsafe bool 索道被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170070CB RID: 28875
		// (get) Token: 0x0602B1CA RID: 176586 RVA: 0x00A7096C File Offset: 0x00A6EB6C
		// (set) Token: 0x0602B1CB RID: 176587 RVA: 0x00A709A5 File Offset: 0x00A6EBA5
		[Nullable(1)]
		public FTimerHandle TimerHandler
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FTimerHandle result;
				if ((result = this._TimerHandler) == null)
				{
					result = (this._TimerHandler = new FTimerHandle(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FTimerHandle.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070CC RID: 28876
		// (get) Token: 0x0602B1CC RID: 176588 RVA: 0x00A709C6 File Offset: 0x00A6EBC6
		// (set) Token: 0x0602B1CD RID: 176589 RVA: 0x00A709DA File Offset: 0x00A6EBDA
		public unsafe FVectorDouble PreviousLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170070CD RID: 28877
		// (get) Token: 0x0602B1CE RID: 176590 RVA: 0x00A709EF File Offset: 0x00A6EBEF
		// (set) Token: 0x0602B1CF RID: 176591 RVA: 0x00A709FF File Offset: 0x00A6EBFF
		public unsafe int 变身特效2Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170070CE RID: 28878
		// (get) Token: 0x0602B1D0 RID: 176592 RVA: 0x00A70A10 File Offset: 0x00A6EC10
		// (set) Token: 0x0602B1D1 RID: 176593 RVA: 0x00A70A20 File Offset: 0x00A6EC20
		public unsafe int 摩托钩锁ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170070CF RID: 28879
		// (get) Token: 0x0602B1D2 RID: 176594 RVA: 0x00A70A31 File Offset: 0x00A6EC31
		// (set) Token: 0x0602B1D3 RID: 176595 RVA: 0x00A70A41 File Offset: 0x00A6EC41
		public unsafe bool 是否有变身材质
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Cableway_Motor_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B1D4 RID: 176596 RVA: 0x00A70A52 File Offset: 0x00A6EC52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 新增是否忽略碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__新增是否忽略碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1D5 RID: 176597 RVA: 0x00A70A66 File Offset: 0x00A6EC66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 是否继承速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__是否继承速度_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1D6 RID: 176598 RVA: 0x00A70A7A File Offset: 0x00A6EC7A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__FixHookTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1D7 RID: 176599 RVA: 0x00A70A8E File Offset: 0x00A6EC8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1D8 RID: 176600 RVA: 0x00A70AA4 File Offset: 0x00A6ECA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual AActor FindBestHookPoint()
		{
			GA_Role_FixHook_Cableway_Motor_C.__FindBestHookPoint_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_Motor_C.__FindBestHookPoint_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_Motor_C.__FindBestHookPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_Motor_C.__FindBestHookPoint_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__FindBestHookPoint_NativeFunctionPtr, (void*)ptr);
			return BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->__Result);
		}

		// Token: 0x0602B1D9 RID: 176601 RVA: 0x00A70AEE File Offset: 0x00A6ECEE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81E3B8DF47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnTick_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1DA RID: 176602 RVA: 0x00A70B02 File Offset: 0x00A6ED02
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81E3B8DF47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnCancelled_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1DB RID: 176603 RVA: 0x00A70B16 File Offset: 0x00A6ED16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81E3B8DF47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnInterrupted_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1DC RID: 176604 RVA: 0x00A70B2A File Offset: 0x00A6ED2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81E3B8DF47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnBlendOut_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1DD RID: 176605 RVA: 0x00A70B3E File Offset: 0x00A6ED3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81E3B8DF47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnCompleted_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1DE RID: 176606 RVA: 0x00A70B52 File Offset: 0x00A6ED52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_47768F5446E78377499424B2FD6562F9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnFinish_47768F5446E78377499424B2FD6562F9_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1DF RID: 176607 RVA: 0x00A70B66 File Offset: 0x00A6ED66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_47768F5446E78377499424B2FD6562F9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnTick_47768F5446E78377499424B2FD6562F9_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1E0 RID: 176608 RVA: 0x00A70B7C File Offset: 0x00A6ED7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88078A1EC4(FGameplayEventData Payload)
		{
			GA_Role_FixHook_Cableway_Motor_C.__EventReceived_18B59F5945020DB23C42FD88078A1EC4_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_Motor_C.__EventReceived_18B59F5945020DB23C42FD88078A1EC4_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_Motor_C.__EventReceived_18B59F5945020DB23C42FD88078A1EC4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_Motor_C.__EventReceived_18B59F5945020DB23C42FD88078A1EC4_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__EventReceived_18B59F5945020DB23C42FD88078A1EC4_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_FixHook_Cableway_Motor_C.__EventReceived_18B59F5945020DB23C42FD88078A1EC4_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B1E1 RID: 176609 RVA: 0x00A70BF1 File Offset: 0x00A6EDF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8169A7E71C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnTick_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1E2 RID: 176610 RVA: 0x00A70C05 File Offset: 0x00A6EE05
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8169A7E71C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnCancelled_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1E3 RID: 176611 RVA: 0x00A70C19 File Offset: 0x00A6EE19
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8169A7E71C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnInterrupted_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1E4 RID: 176612 RVA: 0x00A70C2D File Offset: 0x00A6EE2D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8169A7E71C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnBlendOut_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1E5 RID: 176613 RVA: 0x00A70C41 File Offset: 0x00A6EE41
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8169A7E71C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnCompleted_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1E6 RID: 176614 RVA: 0x00A70C55 File Offset: 0x00A6EE55
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1E7 RID: 176615 RVA: 0x00A70C69 File Offset: 0x00A6EE69
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B1E8 RID: 176616 RVA: 0x00A70C80 File Offset: 0x00A6EE80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_FixHook_Cableway_Motor_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_Motor_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_Motor_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_Motor_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B1E9 RID: 176617 RVA: 0x00A70CE8 File Offset: 0x00A6EEE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RoleTeleport(FVector Velocity)
		{
			GA_Role_FixHook_Cableway_Motor_C.__RoleTeleport_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_Motor_C.__RoleTeleport_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_Motor_C.__RoleTeleport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_Motor_C.__RoleTeleport_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Velocity = Velocity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__RoleTeleport_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B1EA RID: 176618 RVA: 0x00A70D30 File Offset: 0x00A6EF30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnCableWayMoveEnd(bool bContent)
		{
			GA_Role_FixHook_Cableway_Motor_C.__OnCableWayMoveEnd_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_Motor_C.__OnCableWayMoveEnd_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_Motor_C.__OnCableWayMoveEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_Motor_C.__OnCableWayMoveEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bContent = bContent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnCableWayMoveEnd_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B1EB RID: 176619 RVA: 0x00A70D78 File Offset: 0x00A6EF78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B1EC RID: 176620 RVA: 0x00A70DC0 File Offset: 0x00A6EFC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B1ED RID: 176621 RVA: 0x00A70E07 File Offset: 0x00A6F007
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnHookEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnHookEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1EE RID: 176622 RVA: 0x00A70E1B File Offset: 0x00A6F01B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCableWayEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__OnCableWayEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1EF RID: 176623 RVA: 0x00A70E2F File Offset: 0x00A6F02F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CableWayStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__CableWayStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1F0 RID: 176624 RVA: 0x00A70E43 File Offset: 0x00A6F043
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayCableWableEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__PlayCableWableEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1F1 RID: 176625 RVA: 0x00A70E57 File Offset: 0x00A6F057
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TrySaveCableLocation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__TrySaveCableLocation_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1F2 RID: 176626 RVA: 0x00A70E6B File Offset: 0x00A6F06B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveCableTag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__RemoveCableTag_NativeFunctionPtr, null);
		}

		// Token: 0x0602B1F3 RID: 176627 RVA: 0x00A70E80 File Offset: 0x00A6F080
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_FixHook_Cableway_Motor(int EntryPoint)
		{
			GA_Role_FixHook_Cableway_Motor_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_Motor_FunctionParams* ptr = stackalloc GA_Role_FixHook_Cableway_Motor_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_Motor_FunctionParams[(UIntPtr)3487] + 15L / (long)sizeof(GA_Role_FixHook_Cableway_Motor_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_Motor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Cableway_Motor_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_Motor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Cableway_Motor_C.__ExecuteUbergraph_GA_Role_FixHook_Cableway_Motor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B1F4 RID: 176628 RVA: 0x00A70ECA File Offset: 0x00A6F0CA
		protected GA_Role_FixHook_Cableway_Motor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401794F RID: 96591
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Cableway_Motor.GA_Role_FixHook_Cableway_Motor_C";

		// Token: 0x04017950 RID: 96592
		private static IntPtr _ClassPtr;

		// Token: 0x04017951 RID: 96593
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017952 RID: 96594
		internal new static int __PropertyOffset_0;

		// Token: 0x04017953 RID: 96595
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017954 RID: 96596
		internal new static int __PropertyOffset_1;

		// Token: 0x04017955 RID: 96597
		internal new static int __PropertyOffset_2;

		// Token: 0x04017956 RID: 96598
		internal new static int __PropertyOffset_3;

		// Token: 0x04017957 RID: 96599
		internal static int __PropertyOffset_4;

		// Token: 0x04017958 RID: 96600
		internal static int __PropertyOffset_5;

		// Token: 0x04017959 RID: 96601
		internal static int __PropertyOffset_6;

		// Token: 0x0401795A RID: 96602
		internal static int __PropertyOffset_7;

		// Token: 0x0401795B RID: 96603
		private TArray<FVectorDouble> _FixHookPathways;

		// Token: 0x0401795C RID: 96604
		internal static int __PropertyOffset_8;

		// Token: 0x0401795D RID: 96605
		internal static int __PropertyOffset_9;

		// Token: 0x0401795E RID: 96606
		internal static int __PropertyOffset_10;

		// Token: 0x0401795F RID: 96607
		internal static int __PropertyOffset_11;

		// Token: 0x04017960 RID: 96608
		internal static int __PropertyOffset_12;

		// Token: 0x04017961 RID: 96609
		internal static int __PropertyOffset_13;

		// Token: 0x04017962 RID: 96610
		internal static int __PropertyOffset_14;

		// Token: 0x04017963 RID: 96611
		internal static int __PropertyOffset_15;

		// Token: 0x04017964 RID: 96612
		internal static int __PropertyOffset_16;

		// Token: 0x04017965 RID: 96613
		internal static int __PropertyOffset_17;

		// Token: 0x04017966 RID: 96614
		internal static int __PropertyOffset_18;

		// Token: 0x04017967 RID: 96615
		private FTimerHandle _TimerHandler;

		// Token: 0x04017968 RID: 96616
		internal static int __PropertyOffset_19;

		// Token: 0x04017969 RID: 96617
		internal static int __PropertyOffset_20;

		// Token: 0x0401796A RID: 96618
		internal static int __PropertyOffset_21;

		// Token: 0x0401796B RID: 96619
		internal static int __PropertyOffset_22;

		// Token: 0x0401796C RID: 96620
		private static IntPtr __新增是否忽略碰撞_NativeFunctionPtr;

		// Token: 0x0401796D RID: 96621
		private static IntPtr __是否继承速度_NativeFunctionPtr;

		// Token: 0x0401796E RID: 96622
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x0401796F RID: 96623
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x04017970 RID: 96624
		private static IntPtr __FindBestHookPoint_NativeFunctionPtr;

		// Token: 0x04017971 RID: 96625
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr;

		// Token: 0x04017972 RID: 96626
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr;

		// Token: 0x04017973 RID: 96627
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr;

		// Token: 0x04017974 RID: 96628
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr;

		// Token: 0x04017975 RID: 96629
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81E3B8DF47_NativeFunctionPtr;

		// Token: 0x04017976 RID: 96630
		private static IntPtr __OnFinish_47768F5446E78377499424B2FD6562F9_NativeFunctionPtr;

		// Token: 0x04017977 RID: 96631
		private static IntPtr __OnTick_47768F5446E78377499424B2FD6562F9_NativeFunctionPtr;

		// Token: 0x04017978 RID: 96632
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88078A1EC4_NativeFunctionPtr;

		// Token: 0x04017979 RID: 96633
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr;

		// Token: 0x0401797A RID: 96634
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr;

		// Token: 0x0401797B RID: 96635
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr;

		// Token: 0x0401797C RID: 96636
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr;

		// Token: 0x0401797D RID: 96637
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8169A7E71C_NativeFunctionPtr;

		// Token: 0x0401797E RID: 96638
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401797F RID: 96639
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017980 RID: 96640
		private static IntPtr __RoleTeleport_NativeFunctionPtr;

		// Token: 0x04017981 RID: 96641
		private static IntPtr __OnCableWayMoveEnd_NativeFunctionPtr;

		// Token: 0x04017982 RID: 96642
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017983 RID: 96643
		private static IntPtr __OnHookEnd_NativeFunctionPtr;

		// Token: 0x04017984 RID: 96644
		private static IntPtr __OnCableWayEnd_NativeFunctionPtr;

		// Token: 0x04017985 RID: 96645
		private static IntPtr __CableWayStart_NativeFunctionPtr;

		// Token: 0x04017986 RID: 96646
		private static IntPtr __PlayCableWableEnd_NativeFunctionPtr;

		// Token: 0x04017987 RID: 96647
		private static IntPtr __TrySaveCableLocation_NativeFunctionPtr;

		// Token: 0x04017988 RID: 96648
		private static IntPtr __RemoveCableTag_NativeFunctionPtr;

		// Token: 0x04017989 RID: 96649
		private static IntPtr __ExecuteUbergraph_GA_Role_FixHook_Cableway_Motor_NativeFunctionPtr;

		// Token: 0x0200A2EE RID: 41710
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __FindBestHookPoint_FunctionParams
		{
			// Token: 0x040330B3 RID: 209075
			[FieldOffset(0)]
			public IntPtr __Result;
		}

		// Token: 0x0200A2EF RID: 41711
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88078A1EC4_FunctionParams
		{
			// Token: 0x040330B4 RID: 209076
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A2F0 RID: 41712
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x040330B5 RID: 209077
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x040330B6 RID: 209078
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x040330B7 RID: 209079
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2F1 RID: 41713
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __RoleTeleport_FunctionParams
		{
			// Token: 0x040330B8 RID: 209080
			[FieldOffset(0)]
			public FVector Velocity;
		}

		// Token: 0x0200A2F2 RID: 41714
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __OnCableWayMoveEnd_FunctionParams
		{
			// Token: 0x040330B9 RID: 209081
			[FieldOffset(0)]
			public bool bContent;
		}

		// Token: 0x0200A2F3 RID: 41715
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330BA RID: 209082
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2F4 RID: 41716
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3472)]
		protected ref struct __ExecuteUbergraph_GA_Role_FixHook_Cableway_Motor_FunctionParams
		{
			// Token: 0x040330BB RID: 209083
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
