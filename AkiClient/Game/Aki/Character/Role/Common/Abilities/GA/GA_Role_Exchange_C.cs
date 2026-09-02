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
	// Token: 0x020040A2 RID: 16546
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Exchange.GA_Role_Exchange_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_Exchange_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B117 RID: 176407 RVA: 0x00A6F5AC File Offset: 0x00A6D7AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_Exchange_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Exchange.GA_Role_Exchange_C");
			}
			return GA_Role_Exchange_C._ClassPtr;
		}

		// Token: 0x0602B118 RID: 176408 RVA: 0x00A6F5D0 File Offset: 0x00A6D7D0
		public GA_Role_Exchange_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_Exchange_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B119 RID: 176409 RVA: 0x00A6F5F8 File Offset: 0x00A6D7F8
		public GA_Role_Exchange_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_Exchange_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007095 RID: 28821
		// (get) Token: 0x0602B11A RID: 176410 RVA: 0x00A6F62C File Offset: 0x00A6D82C
		// (set) Token: 0x0602B11B RID: 176411 RVA: 0x00A6F665 File Offset: 0x00A6D865
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_Exchange_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_Exchange_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B11C RID: 176412 RVA: 0x00A6F686 File Offset: 0x00A6D886
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_F5022130490EA872D5F5AA989A337C9B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Exchange_C.__OnFinish_F5022130490EA872D5F5AA989A337C9B_NativeFunctionPtr, null);
		}

		// Token: 0x0602B11D RID: 176413 RVA: 0x00A6F69A File Offset: 0x00A6D89A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Exchange_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B11E RID: 176414 RVA: 0x00A6F6AE File Offset: 0x00A6D8AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Exchange_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B11F RID: 176415 RVA: 0x00A6F6C4 File Offset: 0x00A6D8C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_Exchange(int EntryPoint)
		{
			GA_Role_Exchange_C.__ExecuteUbergraph_GA_Role_Exchange_FunctionParams* ptr = stackalloc GA_Role_Exchange_C.__ExecuteUbergraph_GA_Role_Exchange_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(GA_Role_Exchange_C.__ExecuteUbergraph_GA_Role_Exchange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Exchange_C.__ExecuteUbergraph_GA_Role_Exchange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Exchange_C.__ExecuteUbergraph_GA_Role_Exchange_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B120 RID: 176416 RVA: 0x00A6F70B File Offset: 0x00A6D90B
		protected GA_Role_Exchange_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178E9 RID: 96489
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Exchange.GA_Role_Exchange_C";

		// Token: 0x040178EA RID: 96490
		private static IntPtr _ClassPtr;

		// Token: 0x040178EB RID: 96491
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178EC RID: 96492
		internal new static int __PropertyOffset_0;

		// Token: 0x040178ED RID: 96493
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178EE RID: 96494
		private static IntPtr __OnFinish_F5022130490EA872D5F5AA989A337C9B_NativeFunctionPtr;

		// Token: 0x040178EF RID: 96495
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178F0 RID: 96496
		private static IntPtr __ExecuteUbergraph_GA_Role_Exchange_NativeFunctionPtr;

		// Token: 0x0200A2E0 RID: 41696
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_GA_Role_Exchange_FunctionParams
		{
			// Token: 0x040330A1 RID: 209057
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
