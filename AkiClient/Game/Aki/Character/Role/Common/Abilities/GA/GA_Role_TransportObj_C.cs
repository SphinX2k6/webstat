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
	// Token: 0x020040B8 RID: 16568
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_TransportObj.GA_Role_TransportObj_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_TransportObj_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B452 RID: 177234 RVA: 0x00A75FCB File Offset: 0x00A741CB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_TransportObj_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_TransportObj.GA_Role_TransportObj_C");
			}
			return GA_Role_TransportObj_C._ClassPtr;
		}

		// Token: 0x0602B453 RID: 177235 RVA: 0x00A75FF0 File Offset: 0x00A741F0
		public GA_Role_TransportObj_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_TransportObj_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B454 RID: 177236 RVA: 0x00A76018 File Offset: 0x00A74218
		public GA_Role_TransportObj_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_TransportObj_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007156 RID: 29014
		// (get) Token: 0x0602B455 RID: 177237 RVA: 0x00A7604C File Offset: 0x00A7424C
		// (set) Token: 0x0602B456 RID: 177238 RVA: 0x00A76085 File Offset: 0x00A74285
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_TransportObj_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_TransportObj_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B457 RID: 177239 RVA: 0x00A760A6 File Offset: 0x00A742A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_TransportObj_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B458 RID: 177240 RVA: 0x00A760BA File Offset: 0x00A742BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_TransportObj_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B459 RID: 177241 RVA: 0x00A760D0 File Offset: 0x00A742D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_TransportObj(int EntryPoint)
		{
			GA_Role_TransportObj_C.__ExecuteUbergraph_GA_Role_TransportObj_FunctionParams* ptr = stackalloc GA_Role_TransportObj_C.__ExecuteUbergraph_GA_Role_TransportObj_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(GA_Role_TransportObj_C.__ExecuteUbergraph_GA_Role_TransportObj_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_TransportObj_C.__ExecuteUbergraph_GA_Role_TransportObj_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_TransportObj_C.__ExecuteUbergraph_GA_Role_TransportObj_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B45A RID: 177242 RVA: 0x00A7611A File Offset: 0x00A7431A
		protected GA_Role_TransportObj_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017B3E RID: 97086
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_TransportObj.GA_Role_TransportObj_C";

		// Token: 0x04017B3F RID: 97087
		private static IntPtr _ClassPtr;

		// Token: 0x04017B40 RID: 97088
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017B41 RID: 97089
		internal new static int __PropertyOffset_0;

		// Token: 0x04017B42 RID: 97090
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B43 RID: 97091
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017B44 RID: 97092
		private static IntPtr __ExecuteUbergraph_GA_Role_TransportObj_NativeFunctionPtr;

		// Token: 0x0200A33D RID: 41789
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __ExecuteUbergraph_GA_Role_TransportObj_FunctionParams
		{
			// Token: 0x0403311A RID: 209178
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
