using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040B2 RID: 16562
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotAim_Auto.GA_Role_PilotAim_Auto_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_Role_PilotAim_Auto_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B31D RID: 176925 RVA: 0x00A73C83 File Offset: 0x00A71E83
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_PilotAim_Auto_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotAim_Auto.GA_Role_PilotAim_Auto_C");
			}
			return GA_Role_PilotAim_Auto_C._ClassPtr;
		}

		// Token: 0x0602B31E RID: 176926 RVA: 0x00A73CA8 File Offset: 0x00A71EA8
		public GA_Role_PilotAim_Auto_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotAim_Auto_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B31F RID: 176927 RVA: 0x00A73CD0 File Offset: 0x00A71ED0
		[NullableContext(1)]
		public GA_Role_PilotAim_Auto_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotAim_Auto_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007102 RID: 28930
		// (get) Token: 0x0602B320 RID: 176928 RVA: 0x00A73D04 File Offset: 0x00A71F04
		// (set) Token: 0x0602B321 RID: 176929 RVA: 0x00A73D3D File Offset: 0x00A71F3D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_PilotAim_Auto_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_PilotAim_Auto_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007103 RID: 28931
		// (get) Token: 0x0602B322 RID: 176930 RVA: 0x00A73D5E File Offset: 0x00A71F5E
		// (set) Token: 0x0602B323 RID: 176931 RVA: 0x00A73D72 File Offset: 0x00A71F72
		[Nullable(2)]
		public unsafe TsBaseCharacter 施法者_0
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_Auto_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_Auto_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007104 RID: 28932
		// (get) Token: 0x0602B324 RID: 176932 RVA: 0x00A73D87 File Offset: 0x00A71F87
		// (set) Token: 0x0602B325 RID: 176933 RVA: 0x00A73D9B File Offset: 0x00A71F9B
		[Nullable(2)]
		public unsafe USkeletalMeshComponent PilotSkeletal
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_Auto_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_Auto_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007105 RID: 28933
		// (get) Token: 0x0602B326 RID: 176934 RVA: 0x00A73DB0 File Offset: 0x00A71FB0
		// (set) Token: 0x0602B327 RID: 176935 RVA: 0x00A73DC0 File Offset: 0x00A71FC0
		public unsafe bool IsThrow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotAim_Auto_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotAim_Auto_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007106 RID: 28934
		// (get) Token: 0x0602B328 RID: 176936 RVA: 0x00A73DD1 File Offset: 0x00A71FD1
		// (set) Token: 0x0602B329 RID: 176937 RVA: 0x00A73DE1 File Offset: 0x00A71FE1
		public unsafe int 变身特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotAim_Auto_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotAim_Auto_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602B32A RID: 176938 RVA: 0x00A73DF2 File Offset: 0x00A71FF2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void onEndAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__onEndAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B32B RID: 176939 RVA: 0x00A73E06 File Offset: 0x00A72006
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void onBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__onBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602B32C RID: 176940 RVA: 0x00A73E1A File Offset: 0x00A7201A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AimTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__AimTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B32D RID: 176941 RVA: 0x00A73E2E File Offset: 0x00A7202E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AimStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__AimStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B32E RID: 176942 RVA: 0x00A73E44 File Offset: 0x00A72044
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD880D1BBE62(FGameplayEventData Payload)
		{
			GA_Role_PilotAim_Auto_C.__EventReceived_18B59F5945020DB23C42FD880D1BBE62_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__EventReceived_18B59F5945020DB23C42FD880D1BBE62_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__EventReceived_18B59F5945020DB23C42FD880D1BBE62_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__EventReceived_18B59F5945020DB23C42FD880D1BBE62_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__EventReceived_18B59F5945020DB23C42FD880D1BBE62_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotAim_Auto_C.__EventReceived_18B59F5945020DB23C42FD880D1BBE62_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B32F RID: 176943 RVA: 0x00A73EBC File Offset: 0x00A720BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyEnd_80D1BE3544247D6E275C61916DB57E88(FName NotifyName)
		{
			GA_Role_PilotAim_Auto_C.__OnNotifyEnd_80D1BE3544247D6E275C61916DB57E88_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__OnNotifyEnd_80D1BE3544247D6E275C61916DB57E88_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__OnNotifyEnd_80D1BE3544247D6E275C61916DB57E88_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__OnNotifyEnd_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__OnNotifyEnd_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B330 RID: 176944 RVA: 0x00A73F04 File Offset: 0x00A72104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyBegin_80D1BE3544247D6E275C61916DB57E88(FName NotifyName)
		{
			GA_Role_PilotAim_Auto_C.__OnNotifyBegin_80D1BE3544247D6E275C61916DB57E88_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__OnNotifyBegin_80D1BE3544247D6E275C61916DB57E88_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__OnNotifyBegin_80D1BE3544247D6E275C61916DB57E88_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__OnNotifyBegin_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__OnNotifyBegin_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B331 RID: 176945 RVA: 0x00A73F4C File Offset: 0x00A7214C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnInterrupted_80D1BE3544247D6E275C61916DB57E88(FName NotifyName)
		{
			GA_Role_PilotAim_Auto_C.__OnInterrupted_80D1BE3544247D6E275C61916DB57E88_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__OnInterrupted_80D1BE3544247D6E275C61916DB57E88_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__OnInterrupted_80D1BE3544247D6E275C61916DB57E88_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__OnInterrupted_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__OnInterrupted_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B332 RID: 176946 RVA: 0x00A73F94 File Offset: 0x00A72194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBlendOut_80D1BE3544247D6E275C61916DB57E88(FName NotifyName)
		{
			GA_Role_PilotAim_Auto_C.__OnBlendOut_80D1BE3544247D6E275C61916DB57E88_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__OnBlendOut_80D1BE3544247D6E275C61916DB57E88_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__OnBlendOut_80D1BE3544247D6E275C61916DB57E88_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__OnBlendOut_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__OnBlendOut_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B333 RID: 176947 RVA: 0x00A73FDC File Offset: 0x00A721DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnCompleted_80D1BE3544247D6E275C61916DB57E88(FName NotifyName)
		{
			GA_Role_PilotAim_Auto_C.__OnCompleted_80D1BE3544247D6E275C61916DB57E88_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__OnCompleted_80D1BE3544247D6E275C61916DB57E88_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__OnCompleted_80D1BE3544247D6E275C61916DB57E88_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__OnCompleted_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__OnCompleted_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B334 RID: 176948 RVA: 0x00A74022 File Offset: 0x00A72222
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B335 RID: 176949 RVA: 0x00A74036 File Offset: 0x00A72236
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B336 RID: 176950 RVA: 0x00A7404C File Offset: 0x00A7224C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B337 RID: 176951 RVA: 0x00A74094 File Offset: 0x00A72294
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B338 RID: 176952 RVA: 0x00A740DC File Offset: 0x00A722DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_PilotAim_Auto(int EntryPoint)
		{
			GA_Role_PilotAim_Auto_C.__ExecuteUbergraph_GA_Role_PilotAim_Auto_FunctionParams* ptr = stackalloc GA_Role_PilotAim_Auto_C.__ExecuteUbergraph_GA_Role_PilotAim_Auto_FunctionParams[(UIntPtr)751] + 15L / (long)sizeof(GA_Role_PilotAim_Auto_C.__ExecuteUbergraph_GA_Role_PilotAim_Auto_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_Auto_C.__ExecuteUbergraph_GA_Role_PilotAim_Auto_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotAim_Auto_C.__ExecuteUbergraph_GA_Role_PilotAim_Auto_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B339 RID: 176953 RVA: 0x00A74126 File Offset: 0x00A72326
		protected GA_Role_PilotAim_Auto_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A69 RID: 96873
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotAim_Auto.GA_Role_PilotAim_Auto_C";

		// Token: 0x04017A6A RID: 96874
		private static IntPtr _ClassPtr;

		// Token: 0x04017A6B RID: 96875
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017A6C RID: 96876
		internal new static int __PropertyOffset_0;

		// Token: 0x04017A6D RID: 96877
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017A6E RID: 96878
		internal new static int __PropertyOffset_1;

		// Token: 0x04017A6F RID: 96879
		internal new static int __PropertyOffset_2;

		// Token: 0x04017A70 RID: 96880
		internal new static int __PropertyOffset_3;

		// Token: 0x04017A71 RID: 96881
		internal static int __PropertyOffset_4;

		// Token: 0x04017A72 RID: 96882
		private static IntPtr __onEndAbility_NativeFunctionPtr;

		// Token: 0x04017A73 RID: 96883
		private static IntPtr __onBegin_NativeFunctionPtr;

		// Token: 0x04017A74 RID: 96884
		private static IntPtr __AimTick_NativeFunctionPtr;

		// Token: 0x04017A75 RID: 96885
		private static IntPtr __AimStart_NativeFunctionPtr;

		// Token: 0x04017A76 RID: 96886
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD880D1BBE62_NativeFunctionPtr;

		// Token: 0x04017A77 RID: 96887
		private static IntPtr __OnNotifyEnd_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr;

		// Token: 0x04017A78 RID: 96888
		private static IntPtr __OnNotifyBegin_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr;

		// Token: 0x04017A79 RID: 96889
		private static IntPtr __OnInterrupted_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr;

		// Token: 0x04017A7A RID: 96890
		private static IntPtr __OnBlendOut_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr;

		// Token: 0x04017A7B RID: 96891
		private static IntPtr __OnCompleted_80D1BE3544247D6E275C61916DB57E88_NativeFunctionPtr;

		// Token: 0x04017A7C RID: 96892
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A7D RID: 96893
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A7E RID: 96894
		private static IntPtr __ExecuteUbergraph_GA_Role_PilotAim_Auto_NativeFunctionPtr;

		// Token: 0x0200A31F RID: 41759
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD880D1BBE62_FunctionParams
		{
			// Token: 0x040330F4 RID: 209140
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A320 RID: 41760
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyEnd_80D1BE3544247D6E275C61916DB57E88_FunctionParams
		{
			// Token: 0x040330F5 RID: 209141
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A321 RID: 41761
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyBegin_80D1BE3544247D6E275C61916DB57E88_FunctionParams
		{
			// Token: 0x040330F6 RID: 209142
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A322 RID: 41762
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnInterrupted_80D1BE3544247D6E275C61916DB57E88_FunctionParams
		{
			// Token: 0x040330F7 RID: 209143
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A323 RID: 41763
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnBlendOut_80D1BE3544247D6E275C61916DB57E88_FunctionParams
		{
			// Token: 0x040330F8 RID: 209144
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A324 RID: 41764
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnCompleted_80D1BE3544247D6E275C61916DB57E88_FunctionParams
		{
			// Token: 0x040330F9 RID: 209145
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A325 RID: 41765
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330FA RID: 209146
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A326 RID: 41766
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 736)]
		protected ref struct __ExecuteUbergraph_GA_Role_PilotAim_Auto_FunctionParams
		{
			// Token: 0x040330FB RID: 209147
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
