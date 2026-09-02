using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D33 RID: 15667
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_RandomLighteningActor.BP_RandomLighteningActor_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1381)]
	public class BP_RandomLighteningActor_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025FB2 RID: 155570 RVA: 0x009CA428 File Offset: 0x009C8628
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RandomLighteningActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_RandomLighteningActor.BP_RandomLighteningActor_C");
			}
			return BP_RandomLighteningActor_C._ClassPtr;
		}

		// Token: 0x06025FB3 RID: 155571 RVA: 0x009CA44C File Offset: 0x009C864C
		public BP_RandomLighteningActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_RandomLighteningActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025FB4 RID: 155572 RVA: 0x009CA474 File Offset: 0x009C8674
		[NullableContext(1)]
		public BP_RandomLighteningActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RandomLighteningActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170054DB RID: 21723
		// (get) Token: 0x06025FB5 RID: 155573 RVA: 0x009CA4A8 File Offset: 0x009C86A8
		// (set) Token: 0x06025FB6 RID: 155574 RVA: 0x009CA4E1 File Offset: 0x009C86E1
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054DC RID: 21724
		// (get) Token: 0x06025FB7 RID: 155575 RVA: 0x009CA502 File Offset: 0x009C8702
		// (set) Token: 0x06025FB8 RID: 155576 RVA: 0x009CA516 File Offset: 0x009C8716
		public unsafe USpotLightComponent SpotLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpotLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170054DD RID: 21725
		// (get) Token: 0x06025FB9 RID: 155577 RVA: 0x009CA52B File Offset: 0x009C872B
		// (set) Token: 0x06025FBA RID: 155578 RVA: 0x009CA53F File Offset: 0x009C873F
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170054DE RID: 21726
		// (get) Token: 0x06025FBB RID: 155579 RVA: 0x009CA554 File Offset: 0x009C8754
		// (set) Token: 0x06025FBC RID: 155580 RVA: 0x009CA568 File Offset: 0x009C8768
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170054DF RID: 21727
		// (get) Token: 0x06025FBD RID: 155581 RVA: 0x009CA57D File Offset: 0x009C877D
		// (set) Token: 0x06025FBE RID: 155582 RVA: 0x009CA591 File Offset: 0x009C8791
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170054E0 RID: 21728
		// (get) Token: 0x06025FBF RID: 155583 RVA: 0x009CA5A6 File Offset: 0x009C87A6
		// (set) Token: 0x06025FC0 RID: 155584 RVA: 0x009CA5B6 File Offset: 0x009C87B6
		public unsafe float Counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170054E1 RID: 21729
		// (get) Token: 0x06025FC1 RID: 155585 RVA: 0x009CA5C7 File Offset: 0x009C87C7
		// (set) Token: 0x06025FC2 RID: 155586 RVA: 0x009CA5D7 File Offset: 0x009C87D7
		public unsafe float Age
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170054E2 RID: 21730
		// (get) Token: 0x06025FC3 RID: 155587 RVA: 0x009CA5E8 File Offset: 0x009C87E8
		// (set) Token: 0x06025FC4 RID: 155588 RVA: 0x009CA5F8 File Offset: 0x009C87F8
		public unsafe float Delta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170054E3 RID: 21731
		// (get) Token: 0x06025FC5 RID: 155589 RVA: 0x009CA609 File Offset: 0x009C8809
		// (set) Token: 0x06025FC6 RID: 155590 RVA: 0x009CA61D File Offset: 0x009C881D
		public unsafe PDA_RandomLightening_C 配置
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RandomLightening_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RandomLighteningActor_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170054E4 RID: 21732
		// (get) Token: 0x06025FC7 RID: 155591 RVA: 0x009CA632 File Offset: 0x009C8832
		// (set) Token: 0x06025FC8 RID: 155592 RVA: 0x009CA642 File Offset: 0x009C8842
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170054E5 RID: 21733
		// (get) Token: 0x06025FC9 RID: 155593 RVA: 0x009CA653 File Offset: 0x009C8853
		// (set) Token: 0x06025FCA RID: 155594 RVA: 0x009CA663 File Offset: 0x009C8863
		public unsafe bool bDisableSpotLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RandomLighteningActor_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025FCB RID: 155595 RVA: 0x009CA674 File Offset: 0x009C8874
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Spawn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomLighteningActor_C.__Spawn_NativeFunctionPtr, null);
		}

		// Token: 0x06025FCC RID: 155596 RVA: 0x009CA688 File Offset: 0x009C8888
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomLighteningActor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025FCD RID: 155597 RVA: 0x009CA69C File Offset: 0x009C889C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomLighteningActor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025FCE RID: 155598 RVA: 0x009CA6B4 File Offset: 0x009C88B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_RandomLighteningActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RandomLighteningActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RandomLighteningActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomLighteningActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomLighteningActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025FCF RID: 155599 RVA: 0x009CA6FC File Offset: 0x009C88FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_RandomLighteningActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RandomLighteningActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RandomLighteningActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomLighteningActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomLighteningActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025FD0 RID: 155600 RVA: 0x009CA744 File Offset: 0x009C8944
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_RandomLighteningActor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_RandomLighteningActor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RandomLighteningActor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomLighteningActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RandomLighteningActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025FD1 RID: 155601 RVA: 0x009CA78C File Offset: 0x009C898C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_RandomLighteningActor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_RandomLighteningActor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RandomLighteningActor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomLighteningActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomLighteningActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025FD2 RID: 155602 RVA: 0x009CA7D4 File Offset: 0x009C89D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RandomLighteningActor(int EntryPoint)
		{
			BP_RandomLighteningActor_C.__ExecuteUbergraph_BP_RandomLighteningActor_FunctionParams* ptr = stackalloc BP_RandomLighteningActor_C.__ExecuteUbergraph_BP_RandomLighteningActor_FunctionParams[(UIntPtr)67] + 15L / (long)sizeof(BP_RandomLighteningActor_C.__ExecuteUbergraph_BP_RandomLighteningActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RandomLighteningActor_C.__ExecuteUbergraph_BP_RandomLighteningActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RandomLighteningActor_C.__ExecuteUbergraph_BP_RandomLighteningActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025FD3 RID: 155603 RVA: 0x009CA81B File Offset: 0x009C8A1B
		protected BP_RandomLighteningActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013A44 RID: 80452
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_RandomLighteningActor.BP_RandomLighteningActor_C";

		// Token: 0x04013A45 RID: 80453
		private static IntPtr _ClassPtr;

		// Token: 0x04013A46 RID: 80454
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013A47 RID: 80455
		internal static int __PropertyOffset_0;

		// Token: 0x04013A48 RID: 80456
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013A49 RID: 80457
		internal static int __PropertyOffset_1;

		// Token: 0x04013A4A RID: 80458
		internal static int __PropertyOffset_2;

		// Token: 0x04013A4B RID: 80459
		internal static int __PropertyOffset_3;

		// Token: 0x04013A4C RID: 80460
		internal static int __PropertyOffset_4;

		// Token: 0x04013A4D RID: 80461
		internal static int __PropertyOffset_5;

		// Token: 0x04013A4E RID: 80462
		internal static int __PropertyOffset_6;

		// Token: 0x04013A4F RID: 80463
		internal static int __PropertyOffset_7;

		// Token: 0x04013A50 RID: 80464
		internal static int __PropertyOffset_8;

		// Token: 0x04013A51 RID: 80465
		internal static int __PropertyOffset_9;

		// Token: 0x04013A52 RID: 80466
		internal static int __PropertyOffset_10;

		// Token: 0x04013A53 RID: 80467
		private static IntPtr __Spawn_NativeFunctionPtr;

		// Token: 0x04013A54 RID: 80468
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013A55 RID: 80469
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013A56 RID: 80470
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013A57 RID: 80471
		private static IntPtr __ExecuteUbergraph_BP_RandomLighteningActor_NativeFunctionPtr;

		// Token: 0x02009FDA RID: 40922
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B92 RID: 207762
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FDB RID: 40923
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032B93 RID: 207763
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FDC RID: 40924
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 52)]
		protected ref struct __ExecuteUbergraph_BP_RandomLighteningActor_FunctionParams
		{
			// Token: 0x04032B94 RID: 207764
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
