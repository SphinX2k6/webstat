using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.CommonBird
{
	// Token: 0x02004194 RID: 16788
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/CommonBird/ABP_BaseBird.ABP_BaseBird_C")]
	[UnrealStructLayout(4320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4312)]
	public class ABP_BaseBird_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C7FA RID: 182266 RVA: 0x00AA3B1D File Offset: 0x00AA1D1D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseBird_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/CommonBird/ABP_BaseBird.ABP_BaseBird_C");
			}
			return ABP_BaseBird_C._ClassPtr;
		}

		// Token: 0x0602C7FB RID: 182267 RVA: 0x00AA3B44 File Offset: 0x00AA1D44
		public ABP_BaseBird_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseBird_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C7FC RID: 182268 RVA: 0x00AA3B6C File Offset: 0x00AA1D6C
		public ABP_BaseBird_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseBird_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170077A5 RID: 30629
		// (get) Token: 0x0602C7FD RID: 182269 RVA: 0x00AA3BA0 File Offset: 0x00AA1DA0
		// (set) Token: 0x0602C7FE RID: 182270 RVA: 0x00AA3BD9 File Offset: 0x00AA1DD9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077A6 RID: 30630
		// (get) Token: 0x0602C7FF RID: 182271 RVA: 0x00AA3BFC File Offset: 0x00AA1DFC
		// (set) Token: 0x0602C800 RID: 182272 RVA: 0x00AA3C35 File Offset: 0x00AA1E35
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077A7 RID: 30631
		// (get) Token: 0x0602C801 RID: 182273 RVA: 0x00AA3C58 File Offset: 0x00AA1E58
		// (set) Token: 0x0602C802 RID: 182274 RVA: 0x00AA3C91 File Offset: 0x00AA1E91
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077A8 RID: 30632
		// (get) Token: 0x0602C803 RID: 182275 RVA: 0x00AA3CB4 File Offset: 0x00AA1EB4
		// (set) Token: 0x0602C804 RID: 182276 RVA: 0x00AA3CED File Offset: 0x00AA1EED
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077A9 RID: 30633
		// (get) Token: 0x0602C805 RID: 182277 RVA: 0x00AA3D10 File Offset: 0x00AA1F10
		// (set) Token: 0x0602C806 RID: 182278 RVA: 0x00AA3D49 File Offset: 0x00AA1F49
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077AA RID: 30634
		// (get) Token: 0x0602C807 RID: 182279 RVA: 0x00AA3D6C File Offset: 0x00AA1F6C
		// (set) Token: 0x0602C808 RID: 182280 RVA: 0x00AA3DA5 File Offset: 0x00AA1FA5
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077AB RID: 30635
		// (get) Token: 0x0602C809 RID: 182281 RVA: 0x00AA3DC8 File Offset: 0x00AA1FC8
		// (set) Token: 0x0602C80A RID: 182282 RVA: 0x00AA3E01 File Offset: 0x00AA2001
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077AC RID: 30636
		// (get) Token: 0x0602C80B RID: 182283 RVA: 0x00AA3E24 File Offset: 0x00AA2024
		// (set) Token: 0x0602C80C RID: 182284 RVA: 0x00AA3E5D File Offset: 0x00AA205D
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077AD RID: 30637
		// (get) Token: 0x0602C80D RID: 182285 RVA: 0x00AA3E80 File Offset: 0x00AA2080
		// (set) Token: 0x0602C80E RID: 182286 RVA: 0x00AA3EB9 File Offset: 0x00AA20B9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077AE RID: 30638
		// (get) Token: 0x0602C80F RID: 182287 RVA: 0x00AA3EDC File Offset: 0x00AA20DC
		// (set) Token: 0x0602C810 RID: 182288 RVA: 0x00AA3F15 File Offset: 0x00AA2115
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077AF RID: 30639
		// (get) Token: 0x0602C811 RID: 182289 RVA: 0x00AA3F38 File Offset: 0x00AA2138
		// (set) Token: 0x0602C812 RID: 182290 RVA: 0x00AA3F71 File Offset: 0x00AA2171
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseBird_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602C813 RID: 182291 RVA: 0x00AA3F94 File Offset: 0x00AA2194
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_BaseBird_C.__基础层_FunctionParams* ptr = stackalloc ABP_BaseBird_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseBird_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseBird_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseBird_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602C814 RID: 182292 RVA: 0x00AA401C File Offset: 0x00AA221C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseBird_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseBird_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseBird_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseBird_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseBird_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C815 RID: 182293 RVA: 0x00AA40A4 File Offset: 0x00AA22A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseBird(int EntryPoint)
		{
			ABP_BaseBird_C.__ExecuteUbergraph_ABP_BaseBird_FunctionParams* ptr = stackalloc ABP_BaseBird_C.__ExecuteUbergraph_ABP_BaseBird_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseBird_C.__ExecuteUbergraph_ABP_BaseBird_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseBird_C.__ExecuteUbergraph_ABP_BaseBird_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseBird_C.__ExecuteUbergraph_ABP_BaseBird_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C816 RID: 182294 RVA: 0x00AA40EB File Offset: 0x00AA22EB
		protected ABP_BaseBird_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B9D RID: 101277
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/CommonBird/ABP_BaseBird.ABP_BaseBird_C";

		// Token: 0x04018B9E RID: 101278
		private static IntPtr _ClassPtr;

		// Token: 0x04018B9F RID: 101279
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018BA0 RID: 101280
		internal static int __PropertyOffset_0;

		// Token: 0x04018BA1 RID: 101281
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018BA2 RID: 101282
		internal static int __PropertyOffset_1;

		// Token: 0x04018BA3 RID: 101283
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04018BA4 RID: 101284
		internal static int __PropertyOffset_2;

		// Token: 0x04018BA5 RID: 101285
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04018BA6 RID: 101286
		internal static int __PropertyOffset_3;

		// Token: 0x04018BA7 RID: 101287
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04018BA8 RID: 101288
		internal static int __PropertyOffset_4;

		// Token: 0x04018BA9 RID: 101289
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018BAA RID: 101290
		internal static int __PropertyOffset_5;

		// Token: 0x04018BAB RID: 101291
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04018BAC RID: 101292
		internal static int __PropertyOffset_6;

		// Token: 0x04018BAD RID: 101293
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04018BAE RID: 101294
		internal static int __PropertyOffset_7;

		// Token: 0x04018BAF RID: 101295
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04018BB0 RID: 101296
		internal static int __PropertyOffset_8;

		// Token: 0x04018BB1 RID: 101297
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04018BB2 RID: 101298
		internal static int __PropertyOffset_9;

		// Token: 0x04018BB3 RID: 101299
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04018BB4 RID: 101300
		internal static int __PropertyOffset_10;

		// Token: 0x04018BB5 RID: 101301
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x04018BB6 RID: 101302
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x04018BB7 RID: 101303
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04018BB8 RID: 101304
		private static IntPtr __ExecuteUbergraph_ABP_BaseBird_NativeFunctionPtr;

		// Token: 0x0200A457 RID: 42071
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x04033259 RID: 209497
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A458 RID: 42072
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x0403325A RID: 209498
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A459 RID: 42073
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_ABP_BaseBird_FunctionParams
		{
			// Token: 0x0403325B RID: 209499
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
