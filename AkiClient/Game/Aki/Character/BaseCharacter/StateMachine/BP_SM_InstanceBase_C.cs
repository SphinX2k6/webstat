using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D8 RID: 17112
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_InstanceBase.BP_SM_InstanceBase_C")]
	[UnrealStructLayout(1584, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1584)]
	public class BP_SM_InstanceBase_C : USMInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D649 RID: 185929 RVA: 0x00ABEEDC File Offset: 0x00ABD0DC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_InstanceBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_InstanceBase.BP_SM_InstanceBase_C");
			}
			return BP_SM_InstanceBase_C._ClassPtr;
		}

		// Token: 0x0602D64A RID: 185930 RVA: 0x00ABEF00 File Offset: 0x00ABD100
		public BP_SM_InstanceBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_InstanceBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D64B RID: 185931 RVA: 0x00ABEF28 File Offset: 0x00ABD128
		public BP_SM_InstanceBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_InstanceBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BD3 RID: 31699
		// (get) Token: 0x0602D64C RID: 185932 RVA: 0x00ABEF5C File Offset: 0x00ABD15C
		// (set) Token: 0x0602D64D RID: 185933 RVA: 0x00ABEF95 File Offset: 0x00ABD195
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SM_InstanceBase_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SM_InstanceBase_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007BD4 RID: 31700
		// (get) Token: 0x0602D64E RID: 185934 RVA: 0x00ABEFB8 File Offset: 0x00ABD1B8
		// (set) Token: 0x0602D64F RID: 185935 RVA: 0x00ABEFF1 File Offset: 0x00ABD1F1
		public TArray<USMStateMachineInstance> Fsm
		{
			get
			{
				base.FastCheckIsValid();
				TArray<USMStateMachineInstance> result;
				if ((result = this._Fsm) == null)
				{
					result = (this._Fsm = new TArray<USMStateMachineInstance>(base.NativePtr + (IntPtr)BP_SM_InstanceBase_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.Fsm.CopyAssign(value);
			}
		}

		// Token: 0x0602D650 RID: 185936 RVA: 0x00ABEFFF File Offset: 0x00ABD1FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnPostCompile()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SM_InstanceBase_C.__OnPostCompile_NativeFunctionPtr, null);
		}

		// Token: 0x0602D651 RID: 185937 RVA: 0x00ABF013 File Offset: 0x00ABD213
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OnPostCompile_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SM_InstanceBase_C.__OnPostCompile_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602D652 RID: 185938 RVA: 0x00ABF028 File Offset: 0x00ABD228
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SM_InstanceBase(int EntryPoint)
		{
			BP_SM_InstanceBase_C.__ExecuteUbergraph_BP_SM_InstanceBase_FunctionParams* ptr = stackalloc BP_SM_InstanceBase_C.__ExecuteUbergraph_BP_SM_InstanceBase_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_SM_InstanceBase_C.__ExecuteUbergraph_BP_SM_InstanceBase_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SM_InstanceBase_C.__ExecuteUbergraph_BP_SM_InstanceBase_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SM_InstanceBase_C.__ExecuteUbergraph_BP_SM_InstanceBase_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602D653 RID: 185939 RVA: 0x00ABF06F File Offset: 0x00ABD26F
		protected BP_SM_InstanceBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019755 RID: 104277
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_InstanceBase.BP_SM_InstanceBase_C";

		// Token: 0x04019756 RID: 104278
		private static IntPtr _ClassPtr;

		// Token: 0x04019757 RID: 104279
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019758 RID: 104280
		internal static int __PropertyOffset_0;

		// Token: 0x04019759 RID: 104281
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401975A RID: 104282
		internal static int __PropertyOffset_1;

		// Token: 0x0401975B RID: 104283
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USMStateMachineInstance> _Fsm;

		// Token: 0x0401975C RID: 104284
		private static IntPtr __OnPostCompile_NativeFunctionPtr;

		// Token: 0x0401975D RID: 104285
		private static IntPtr __ExecuteUbergraph_BP_SM_InstanceBase_NativeFunctionPtr;

		// Token: 0x0200A527 RID: 42279
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_SM_InstanceBase_FunctionParams
		{
			// Token: 0x040333D3 RID: 209875
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
