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
	// Token: 0x020040CD RID: 16589
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_SwitchBlackHoleState.GA_SwitchBlackHoleState_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_SwitchBlackHoleState_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B632 RID: 177714 RVA: 0x00A7A5A3 File Offset: 0x00A787A3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_SwitchBlackHoleState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SwitchBlackHoleState.GA_SwitchBlackHoleState_C");
			}
			return GA_SwitchBlackHoleState_C._ClassPtr;
		}

		// Token: 0x0602B633 RID: 177715 RVA: 0x00A7A5C8 File Offset: 0x00A787C8
		public GA_SwitchBlackHoleState_C() : this(BuiltinUtils.AllocNativeUObject(GA_SwitchBlackHoleState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B634 RID: 177716 RVA: 0x00A7A5F0 File Offset: 0x00A787F0
		public GA_SwitchBlackHoleState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_SwitchBlackHoleState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071A5 RID: 29093
		// (get) Token: 0x0602B635 RID: 177717 RVA: 0x00A7A624 File Offset: 0x00A78824
		// (set) Token: 0x0602B636 RID: 177718 RVA: 0x00A7A65D File Offset: 0x00A7885D
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_SwitchBlackHoleState_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_SwitchBlackHoleState_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B637 RID: 177719 RVA: 0x00A7A67E File Offset: 0x00A7887E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SwitchBlackHoleState_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B638 RID: 177720 RVA: 0x00A7A692 File Offset: 0x00A78892
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SwitchBlackHoleState_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B639 RID: 177721 RVA: 0x00A7A6A8 File Offset: 0x00A788A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_SwitchBlackHoleState(int EntryPoint)
		{
			GA_SwitchBlackHoleState_C.__ExecuteUbergraph_GA_SwitchBlackHoleState_FunctionParams* ptr = stackalloc GA_SwitchBlackHoleState_C.__ExecuteUbergraph_GA_SwitchBlackHoleState_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(GA_SwitchBlackHoleState_C.__ExecuteUbergraph_GA_SwitchBlackHoleState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SwitchBlackHoleState_C.__ExecuteUbergraph_GA_SwitchBlackHoleState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SwitchBlackHoleState_C.__ExecuteUbergraph_GA_SwitchBlackHoleState_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B63A RID: 177722 RVA: 0x00A7A6EF File Offset: 0x00A788EF
		protected GA_SwitchBlackHoleState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CAC RID: 97452
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SwitchBlackHoleState.GA_SwitchBlackHoleState_C";

		// Token: 0x04017CAD RID: 97453
		private static IntPtr _ClassPtr;

		// Token: 0x04017CAE RID: 97454
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CAF RID: 97455
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CB0 RID: 97456
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CB1 RID: 97457
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CB2 RID: 97458
		private static IntPtr __ExecuteUbergraph_GA_SwitchBlackHoleState_NativeFunctionPtr;

		// Token: 0x0200A39F RID: 41887
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __ExecuteUbergraph_GA_SwitchBlackHoleState_FunctionParams
		{
			// Token: 0x0403317C RID: 209276
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
