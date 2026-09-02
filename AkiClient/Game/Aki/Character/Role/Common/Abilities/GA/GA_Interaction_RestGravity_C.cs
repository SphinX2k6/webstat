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
	// Token: 0x02004093 RID: 16531
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_RestGravity.GA_Interaction_RestGravity_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Interaction_RestGravity_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B039 RID: 176185 RVA: 0x00A6D52C File Offset: 0x00A6B72C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_RestGravity_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_RestGravity.GA_Interaction_RestGravity_C");
			}
			return GA_Interaction_RestGravity_C._ClassPtr;
		}

		// Token: 0x0602B03A RID: 176186 RVA: 0x00A6D550 File Offset: 0x00A6B750
		public GA_Interaction_RestGravity_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_RestGravity_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B03B RID: 176187 RVA: 0x00A6D578 File Offset: 0x00A6B778
		public GA_Interaction_RestGravity_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_RestGravity_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007075 RID: 28789
		// (get) Token: 0x0602B03C RID: 176188 RVA: 0x00A6D5AC File Offset: 0x00A6B7AC
		// (set) Token: 0x0602B03D RID: 176189 RVA: 0x00A6D5E5 File Offset: 0x00A6B7E5
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_RestGravity_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_RestGravity_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007076 RID: 28790
		// (get) Token: 0x0602B03E RID: 176190 RVA: 0x00A6D606 File Offset: 0x00A6B806
		// (set) Token: 0x0602B03F RID: 176191 RVA: 0x00A6D61A File Offset: 0x00A6B81A
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_RestGravity_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_RestGravity_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B040 RID: 176192 RVA: 0x00A6D62F File Offset: 0x00A6B82F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_RestGravity_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B041 RID: 176193 RVA: 0x00A6D643 File Offset: 0x00A6B843
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_RestGravity_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B042 RID: 176194 RVA: 0x00A6D658 File Offset: 0x00A6B858
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_RestGravity(int EntryPoint)
		{
			GA_Interaction_RestGravity_C.__ExecuteUbergraph_GA_Interaction_RestGravity_FunctionParams* ptr = stackalloc GA_Interaction_RestGravity_C.__ExecuteUbergraph_GA_Interaction_RestGravity_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GA_Interaction_RestGravity_C.__ExecuteUbergraph_GA_Interaction_RestGravity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_RestGravity_C.__ExecuteUbergraph_GA_Interaction_RestGravity_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_RestGravity_C.__ExecuteUbergraph_GA_Interaction_RestGravity_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B043 RID: 176195 RVA: 0x00A6D69F File Offset: 0x00A6B89F
		protected GA_Interaction_RestGravity_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017843 RID: 96323
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_RestGravity.GA_Interaction_RestGravity_C";

		// Token: 0x04017844 RID: 96324
		private static IntPtr _ClassPtr;

		// Token: 0x04017845 RID: 96325
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017846 RID: 96326
		internal new static int __PropertyOffset_0;

		// Token: 0x04017847 RID: 96327
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017848 RID: 96328
		internal new static int __PropertyOffset_1;

		// Token: 0x04017849 RID: 96329
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401784A RID: 96330
		private static IntPtr __ExecuteUbergraph_GA_Interaction_RestGravity_NativeFunctionPtr;

		// Token: 0x0200A2C2 RID: 41666
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_RestGravity_FunctionParams
		{
			// Token: 0x0403307C RID: 209020
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
