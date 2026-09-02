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
	// Token: 0x020040A3 RID: 16547
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook.GA_Role_FixHook_C")]
	[UnrealStructLayout(1632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1632)]
	public class GA_Role_FixHook_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B121 RID: 176417 RVA: 0x00A6F714 File Offset: 0x00A6D914
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_FixHook_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook.GA_Role_FixHook_C");
			}
			return GA_Role_FixHook_C._ClassPtr;
		}

		// Token: 0x0602B122 RID: 176418 RVA: 0x00A6F738 File Offset: 0x00A6D938
		public GA_Role_FixHook_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B123 RID: 176419 RVA: 0x00A6F760 File Offset: 0x00A6D960
		[NullableContext(1)]
		public GA_Role_FixHook_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007096 RID: 28822
		// (get) Token: 0x0602B124 RID: 176420 RVA: 0x00A6F794 File Offset: 0x00A6D994
		// (set) Token: 0x0602B125 RID: 176421 RVA: 0x00A6F7CD File Offset: 0x00A6D9CD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007097 RID: 28823
		// (get) Token: 0x0602B126 RID: 176422 RVA: 0x00A6F7EE File Offset: 0x00A6D9EE
		// (set) Token: 0x0602B127 RID: 176423 RVA: 0x00A6F802 File Offset: 0x00A6DA02
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007098 RID: 28824
		// (get) Token: 0x0602B128 RID: 176424 RVA: 0x00A6F817 File Offset: 0x00A6DA17
		// (set) Token: 0x0602B129 RID: 176425 RVA: 0x00A6F82B File Offset: 0x00A6DA2B
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007099 RID: 28825
		// (get) Token: 0x0602B12A RID: 176426 RVA: 0x00A6F840 File Offset: 0x00A6DA40
		// (set) Token: 0x0602B12B RID: 176427 RVA: 0x00A6F854 File Offset: 0x00A6DA54
		public unsafe FVectorDouble 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700709A RID: 28826
		// (get) Token: 0x0602B12C RID: 176428 RVA: 0x00A6F869 File Offset: 0x00A6DA69
		// (set) Token: 0x0602B12D RID: 176429 RVA: 0x00A6F879 File Offset: 0x00A6DA79
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700709B RID: 28827
		// (get) Token: 0x0602B12E RID: 176430 RVA: 0x00A6F88A File Offset: 0x00A6DA8A
		// (set) Token: 0x0602B12F RID: 176431 RVA: 0x00A6F89A File Offset: 0x00A6DA9A
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700709C RID: 28828
		// (get) Token: 0x0602B130 RID: 176432 RVA: 0x00A6F8AB File Offset: 0x00A6DAAB
		// (set) Token: 0x0602B131 RID: 176433 RVA: 0x00A6F8BF File Offset: 0x00A6DABF
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700709D RID: 28829
		// (get) Token: 0x0602B132 RID: 176434 RVA: 0x00A6F8D4 File Offset: 0x00A6DAD4
		// (set) Token: 0x0602B133 RID: 176435 RVA: 0x00A6F90D File Offset: 0x00A6DB0D
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
					result = (this._FixHookPathways = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FixHookPathways.CopyAssign(value);
			}
		}

		// Token: 0x1700709E RID: 28830
		// (get) Token: 0x0602B134 RID: 176436 RVA: 0x00A6F91B File Offset: 0x00A6DB1B
		// (set) Token: 0x0602B135 RID: 176437 RVA: 0x00A6F92F File Offset: 0x00A6DB2F
		public unsafe BP_KuroPortalCapture_C FixHookEnterPortalCapture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_KuroPortalCapture_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700709F RID: 28831
		// (get) Token: 0x0602B136 RID: 176438 RVA: 0x00A6F944 File Offset: 0x00A6DB44
		// (set) Token: 0x0602B137 RID: 176439 RVA: 0x00A6F958 File Offset: 0x00A6DB58
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170070A0 RID: 28832
		// (get) Token: 0x0602B138 RID: 176440 RVA: 0x00A6F96D File Offset: 0x00A6DB6D
		// (set) Token: 0x0602B139 RID: 176441 RVA: 0x00A6F97D File Offset: 0x00A6DB7D
		public unsafe bool 是否忽略碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170070A1 RID: 28833
		// (get) Token: 0x0602B13A RID: 176442 RVA: 0x00A6F98E File Offset: 0x00A6DB8E
		// (set) Token: 0x0602B13B RID: 176443 RVA: 0x00A6F99E File Offset: 0x00A6DB9E
		public unsafe int 当前角色穿透值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170070A2 RID: 28834
		// (get) Token: 0x0602B13C RID: 176444 RVA: 0x00A6F9AF File Offset: 0x00A6DBAF
		// (set) Token: 0x0602B13D RID: 176445 RVA: 0x00A6F9BF File Offset: 0x00A6DBBF
		public unsafe int 钩锁速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170070A3 RID: 28835
		// (get) Token: 0x0602B13E RID: 176446 RVA: 0x00A6F9D0 File Offset: 0x00A6DBD0
		// (set) Token: 0x0602B13F RID: 176447 RVA: 0x00A6F9E0 File Offset: 0x00A6DBE0
		public unsafe int 钩锁Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x0602B140 RID: 176448 RVA: 0x00A6F9F1 File Offset: 0x00A6DBF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 新增是否忽略碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__新增是否忽略碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602B141 RID: 176449 RVA: 0x00A6FA05 File Offset: 0x00A6DC05
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 是否继承速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__是否继承速度_NativeFunctionPtr, null);
		}

		// Token: 0x0602B142 RID: 176450 RVA: 0x00A6FA19 File Offset: 0x00A6DC19
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__FixHookTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B143 RID: 176451 RVA: 0x00A6FA2D File Offset: 0x00A6DC2D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B144 RID: 176452 RVA: 0x00A6FA44 File Offset: 0x00A6DC44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual AActor FindBestHookPoint()
		{
			GA_Role_FixHook_C.__FindBestHookPoint_FunctionParams* ptr = stackalloc GA_Role_FixHook_C.__FindBestHookPoint_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(GA_Role_FixHook_C.__FindBestHookPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_C.__FindBestHookPoint_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__FindBestHookPoint_NativeFunctionPtr, (void*)ptr);
			return BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->__Result);
		}

		// Token: 0x0602B145 RID: 176453 RVA: 0x00A6FA90 File Offset: 0x00A6DC90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88D09B5CE2(FGameplayEventData Payload)
		{
			GA_Role_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D09B5CE2_FunctionParams* ptr = stackalloc GA_Role_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D09B5CE2_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D09B5CE2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D09B5CE2_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D09B5CE2_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D09B5CE2_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B146 RID: 176454 RVA: 0x00A6FB05 File Offset: 0x00A6DD05
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_1AD12E0F4865557B76E6619F9D0D670F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__OnFinish_1AD12E0F4865557B76E6619F9D0D670F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B147 RID: 176455 RVA: 0x00A6FB19 File Offset: 0x00A6DD19
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_1AD12E0F4865557B76E6619F9D0D670F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__OnTick_1AD12E0F4865557B76E6619F9D0D670F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B148 RID: 176456 RVA: 0x00A6FB2D File Offset: 0x00A6DD2D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B149 RID: 176457 RVA: 0x00A6FB41 File Offset: 0x00A6DD41
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B14A RID: 176458 RVA: 0x00A6FB58 File Offset: 0x00A6DD58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_FixHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B14B RID: 176459 RVA: 0x00A6FBA0 File Offset: 0x00A6DDA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_FixHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B14C RID: 176460 RVA: 0x00A6FBE8 File Offset: 0x00A6DDE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_FixHook_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_FixHook_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_FixHook_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B14D RID: 176461 RVA: 0x00A6FC50 File Offset: 0x00A6DE50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RoleTeleport(FVector Velocity)
		{
			GA_Role_FixHook_C.__RoleTeleport_FunctionParams* ptr = stackalloc GA_Role_FixHook_C.__RoleTeleport_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_FixHook_C.__RoleTeleport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_C.__RoleTeleport_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Velocity = Velocity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_C.__RoleTeleport_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B14E RID: 176462 RVA: 0x00A6FC98 File Offset: 0x00A6DE98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_FixHook(int EntryPoint)
		{
			GA_Role_FixHook_C.__ExecuteUbergraph_GA_Role_FixHook_FunctionParams* ptr = stackalloc GA_Role_FixHook_C.__ExecuteUbergraph_GA_Role_FixHook_FunctionParams[(UIntPtr)831] + 15L / (long)sizeof(GA_Role_FixHook_C.__ExecuteUbergraph_GA_Role_FixHook_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_C.__ExecuteUbergraph_GA_Role_FixHook_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_C.__ExecuteUbergraph_GA_Role_FixHook_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B14F RID: 176463 RVA: 0x00A6FCE2 File Offset: 0x00A6DEE2
		protected GA_Role_FixHook_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178F1 RID: 96497
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook.GA_Role_FixHook_C";

		// Token: 0x040178F2 RID: 96498
		private static IntPtr _ClassPtr;

		// Token: 0x040178F3 RID: 96499
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178F4 RID: 96500
		internal new static int __PropertyOffset_0;

		// Token: 0x040178F5 RID: 96501
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178F6 RID: 96502
		internal new static int __PropertyOffset_1;

		// Token: 0x040178F7 RID: 96503
		internal new static int __PropertyOffset_2;

		// Token: 0x040178F8 RID: 96504
		internal new static int __PropertyOffset_3;

		// Token: 0x040178F9 RID: 96505
		internal static int __PropertyOffset_4;

		// Token: 0x040178FA RID: 96506
		internal static int __PropertyOffset_5;

		// Token: 0x040178FB RID: 96507
		internal static int __PropertyOffset_6;

		// Token: 0x040178FC RID: 96508
		internal static int __PropertyOffset_7;

		// Token: 0x040178FD RID: 96509
		private TArray<FVectorDouble> _FixHookPathways;

		// Token: 0x040178FE RID: 96510
		internal static int __PropertyOffset_8;

		// Token: 0x040178FF RID: 96511
		internal static int __PropertyOffset_9;

		// Token: 0x04017900 RID: 96512
		internal static int __PropertyOffset_10;

		// Token: 0x04017901 RID: 96513
		internal static int __PropertyOffset_11;

		// Token: 0x04017902 RID: 96514
		internal static int __PropertyOffset_12;

		// Token: 0x04017903 RID: 96515
		internal static int __PropertyOffset_13;

		// Token: 0x04017904 RID: 96516
		private static IntPtr __新增是否忽略碰撞_NativeFunctionPtr;

		// Token: 0x04017905 RID: 96517
		private static IntPtr __是否继承速度_NativeFunctionPtr;

		// Token: 0x04017906 RID: 96518
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x04017907 RID: 96519
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x04017908 RID: 96520
		private static IntPtr __FindBestHookPoint_NativeFunctionPtr;

		// Token: 0x04017909 RID: 96521
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88D09B5CE2_NativeFunctionPtr;

		// Token: 0x0401790A RID: 96522
		private static IntPtr __OnFinish_1AD12E0F4865557B76E6619F9D0D670F_NativeFunctionPtr;

		// Token: 0x0401790B RID: 96523
		private static IntPtr __OnTick_1AD12E0F4865557B76E6619F9D0D670F_NativeFunctionPtr;

		// Token: 0x0401790C RID: 96524
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401790D RID: 96525
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401790E RID: 96526
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x0401790F RID: 96527
		private static IntPtr __RoleTeleport_NativeFunctionPtr;

		// Token: 0x04017910 RID: 96528
		private static IntPtr __ExecuteUbergraph_GA_Role_FixHook_NativeFunctionPtr;

		// Token: 0x0200A2E1 RID: 41697
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __FindBestHookPoint_FunctionParams
		{
			// Token: 0x040330A2 RID: 209058
			[FieldOffset(0)]
			public IntPtr __Result;
		}

		// Token: 0x0200A2E2 RID: 41698
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88D09B5CE2_FunctionParams
		{
			// Token: 0x040330A3 RID: 209059
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A2E3 RID: 41699
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330A4 RID: 209060
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2E4 RID: 41700
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x040330A5 RID: 209061
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x040330A6 RID: 209062
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x040330A7 RID: 209063
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2E5 RID: 41701
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __RoleTeleport_FunctionParams
		{
			// Token: 0x040330A8 RID: 209064
			[FieldOffset(0)]
			public FVector Velocity;
		}

		// Token: 0x0200A2E6 RID: 41702
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 816)]
		protected ref struct __ExecuteUbergraph_GA_Role_FixHook_FunctionParams
		{
			// Token: 0x040330A9 RID: 209065
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
