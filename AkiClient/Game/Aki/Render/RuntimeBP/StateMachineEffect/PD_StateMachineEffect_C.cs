using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A48 RID: 14920
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/PD_StateMachineEffect.PD_StateMachineEffect_C")]
	[UnrealStructLayout(1824, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1824)]
	public class PD_StateMachineEffect_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EE8A RID: 126602 RVA: 0x00901CFC File Offset: 0x008FFEFC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_StateMachineEffect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/StateMachineEffect/PD_StateMachineEffect.PD_StateMachineEffect_C");
			}
			return PD_StateMachineEffect_C._ClassPtr;
		}

		// Token: 0x0601EE8B RID: 126603 RVA: 0x00901D20 File Offset: 0x008FFF20
		public PD_StateMachineEffect_C() : this(BuiltinUtils.AllocNativeUObject(PD_StateMachineEffect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EE8C RID: 126604 RVA: 0x00901D48 File Offset: 0x008FFF48
		public PD_StateMachineEffect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_StateMachineEffect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002D1D RID: 11549
		// (get) Token: 0x0601EE8D RID: 126605 RVA: 0x00901D7C File Offset: 0x008FFF7C
		// (set) Token: 0x0601EE8E RID: 126606 RVA: 0x00901DB5 File Offset: 0x008FFFB5
		public SEffectStateInfo State1
		{
			get
			{
				base.FastCheckIsValid();
				SEffectStateInfo result;
				if ((result = this._State1) == null)
				{
					result = (this._State1 = new SEffectStateInfo(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateInfo.StaticStruct(), base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D1E RID: 11550
		// (get) Token: 0x0601EE8F RID: 126607 RVA: 0x00901DD8 File Offset: 0x008FFFD8
		// (set) Token: 0x0601EE90 RID: 126608 RVA: 0x00901E11 File Offset: 0x00900011
		public SEffectStateInfo State2
		{
			get
			{
				base.FastCheckIsValid();
				SEffectStateInfo result;
				if ((result = this._State2) == null)
				{
					result = (this._State2 = new SEffectStateInfo(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateInfo.StaticStruct(), base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D1F RID: 11551
		// (get) Token: 0x0601EE91 RID: 126609 RVA: 0x00901E34 File Offset: 0x00900034
		// (set) Token: 0x0601EE92 RID: 126610 RVA: 0x00901E6D File Offset: 0x0090006D
		public SEffectStateInfo State3
		{
			get
			{
				base.FastCheckIsValid();
				SEffectStateInfo result;
				if ((result = this._State3) == null)
				{
					result = (this._State3 = new SEffectStateInfo(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateInfo.StaticStruct(), base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D20 RID: 11552
		// (get) Token: 0x0601EE93 RID: 126611 RVA: 0x00901E90 File Offset: 0x00900090
		// (set) Token: 0x0601EE94 RID: 126612 RVA: 0x00901EC9 File Offset: 0x009000C9
		public SEffectStateInfo State4
		{
			get
			{
				base.FastCheckIsValid();
				SEffectStateInfo result;
				if ((result = this._State4) == null)
				{
					result = (this._State4 = new SEffectStateInfo(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateInfo.StaticStruct(), base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D21 RID: 11553
		// (get) Token: 0x0601EE95 RID: 126613 RVA: 0x00901EEC File Offset: 0x009000EC
		// (set) Token: 0x0601EE96 RID: 126614 RVA: 0x00901F25 File Offset: 0x00900125
		public SEffectStateInfo State5
		{
			get
			{
				base.FastCheckIsValid();
				SEffectStateInfo result;
				if ((result = this._State5) == null)
				{
					result = (this._State5 = new SEffectStateInfo(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateInfo.StaticStruct(), base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D22 RID: 11554
		// (get) Token: 0x0601EE97 RID: 126615 RVA: 0x00901F48 File Offset: 0x00900148
		// (set) Token: 0x0601EE98 RID: 126616 RVA: 0x00901F81 File Offset: 0x00900181
		public TArray<UStaticMesh> StaticMeshes
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._StaticMeshes) == null)
				{
					result = (this._StaticMeshes = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.StaticMeshes.CopyAssign(value);
			}
		}

		// Token: 0x17002D23 RID: 11555
		// (get) Token: 0x0601EE99 RID: 126617 RVA: 0x00901F90 File Offset: 0x00900190
		// (set) Token: 0x0601EE9A RID: 126618 RVA: 0x00901FC9 File Offset: 0x009001C9
		public TArray<UNiagaraSystem> NiagaraSystems
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UNiagaraSystem> result;
				if ((result = this._NiagaraSystems) == null)
				{
					result = (this._NiagaraSystems = new TArray<UNiagaraSystem>(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.NiagaraSystems.CopyAssign(value);
			}
		}

		// Token: 0x17002D24 RID: 11556
		// (get) Token: 0x0601EE9B RID: 126619 RVA: 0x00901FD8 File Offset: 0x009001D8
		// (set) Token: 0x0601EE9C RID: 126620 RVA: 0x00902011 File Offset: 0x00900211
		public TArray<FTransform> StaticMeshTransform
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._StaticMeshTransform) == null)
				{
					result = (this._StaticMeshTransform = new TArray<FTransform>(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.StaticMeshTransform.CopyAssign(value);
			}
		}

		// Token: 0x17002D25 RID: 11557
		// (get) Token: 0x0601EE9D RID: 126621 RVA: 0x00902020 File Offset: 0x00900220
		// (set) Token: 0x0601EE9E RID: 126622 RVA: 0x00902059 File Offset: 0x00900259
		public TArray<FTransform> NiagaraParticleTransform
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._NiagaraParticleTransform) == null)
				{
					result = (this._NiagaraParticleTransform = new TArray<FTransform>(base.NativePtr + (IntPtr)PD_StateMachineEffect_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.NiagaraParticleTransform.CopyAssign(value);
			}
		}

		// Token: 0x0601EE9F RID: 126623 RVA: 0x00902068 File Offset: 0x00900268
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetStateInfo(EEffectState InputState, ref SEffectStateInfo Ret)
		{
			PD_StateMachineEffect_C.__GetStateInfo_FunctionParams* ptr = stackalloc PD_StateMachineEffect_C.__GetStateInfo_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(PD_StateMachineEffect_C.__GetStateInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PD_StateMachineEffect_C.__GetStateInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputState = InputState;
			if (Ret != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateInfo.StaticStruct(), &ptr->Ret, Ret.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_StateMachineEffect_C.__GetStateInfo_NativeFunctionPtr, (void*)ptr);
			if (Ret != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateInfo.StaticStruct(), Ret.NativePtr, &ptr->Ret, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(PD_StateMachineEffect_C.__GetStateInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601EEA0 RID: 126624 RVA: 0x0090210F File Offset: 0x0090030F
		protected PD_StateMachineEffect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F475 RID: 62581
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/PD_StateMachineEffect.PD_StateMachineEffect_C";

		// Token: 0x0400F476 RID: 62582
		private static IntPtr _ClassPtr;

		// Token: 0x0400F477 RID: 62583
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F478 RID: 62584
		internal static int __PropertyOffset_0;

		// Token: 0x0400F479 RID: 62585
		[Nullable(2)]
		private SEffectStateInfo _State1;

		// Token: 0x0400F47A RID: 62586
		internal static int __PropertyOffset_1;

		// Token: 0x0400F47B RID: 62587
		[Nullable(2)]
		private SEffectStateInfo _State2;

		// Token: 0x0400F47C RID: 62588
		internal static int __PropertyOffset_2;

		// Token: 0x0400F47D RID: 62589
		[Nullable(2)]
		private SEffectStateInfo _State3;

		// Token: 0x0400F47E RID: 62590
		internal static int __PropertyOffset_3;

		// Token: 0x0400F47F RID: 62591
		[Nullable(2)]
		private SEffectStateInfo _State4;

		// Token: 0x0400F480 RID: 62592
		internal static int __PropertyOffset_4;

		// Token: 0x0400F481 RID: 62593
		[Nullable(2)]
		private SEffectStateInfo _State5;

		// Token: 0x0400F482 RID: 62594
		internal static int __PropertyOffset_5;

		// Token: 0x0400F483 RID: 62595
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _StaticMeshes;

		// Token: 0x0400F484 RID: 62596
		internal static int __PropertyOffset_6;

		// Token: 0x0400F485 RID: 62597
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UNiagaraSystem> _NiagaraSystems;

		// Token: 0x0400F486 RID: 62598
		internal static int __PropertyOffset_7;

		// Token: 0x0400F487 RID: 62599
		[Nullable(2)]
		private TArray<FTransform> _StaticMeshTransform;

		// Token: 0x0400F488 RID: 62600
		internal static int __PropertyOffset_8;

		// Token: 0x0400F489 RID: 62601
		[Nullable(2)]
		private TArray<FTransform> _NiagaraParticleTransform;

		// Token: 0x0400F48A RID: 62602
		private static IntPtr __GetStateInfo_NativeFunctionPtr;

		// Token: 0x0200981F RID: 38943
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __GetStateInfo_FunctionParams
		{
			// Token: 0x04031E3D RID: 204349
			[FieldOffset(0)]
			public TEnumAsByte<EEffectState> InputState;

			// Token: 0x04031E3E RID: 204350
			[FieldOffset(8)]
			public byte Ret;
		}
	}
}
