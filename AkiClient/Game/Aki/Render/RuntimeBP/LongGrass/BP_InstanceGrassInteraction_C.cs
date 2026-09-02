using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LongGrass
{
	// Token: 0x02003C5E RID: 15454
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LongGrass/BP_InstanceGrassInteraction.BP_InstanceGrassInteraction_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1432)]
	public class BP_InstanceGrassInteraction_C : AKuroInstanceGrassInteraction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023BD6 RID: 146390 RVA: 0x0098AB37 File Offset: 0x00988D37
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InstanceGrassInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LongGrass/BP_InstanceGrassInteraction.BP_InstanceGrassInteraction_C");
			}
			return BP_InstanceGrassInteraction_C._ClassPtr;
		}

		// Token: 0x06023BD7 RID: 146391 RVA: 0x0098AB5C File Offset: 0x00988D5C
		public BP_InstanceGrassInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_InstanceGrassInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023BD8 RID: 146392 RVA: 0x0098AB84 File Offset: 0x00988D84
		[NullableContext(1)]
		public BP_InstanceGrassInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InstanceGrassInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004815 RID: 18453
		// (get) Token: 0x06023BD9 RID: 146393 RVA: 0x0098ABB8 File Offset: 0x00988DB8
		// (set) Token: 0x06023BDA RID: 146394 RVA: 0x0098ABF1 File Offset: 0x00988DF1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InstanceGrassInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InstanceGrassInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004816 RID: 18454
		// (get) Token: 0x06023BDB RID: 146395 RVA: 0x0098AC12 File Offset: 0x00988E12
		// (set) Token: 0x06023BDC RID: 146396 RVA: 0x0098AC26 File Offset: 0x00988E26
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InstanceGrassInteraction_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InstanceGrassInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06023BDD RID: 146397 RVA: 0x0098AC3C File Offset: 0x00988E3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord(FVectorDouble MainPlayerPos, FVectorDouble OtherPlayerPos, float InteractionSize, ref FVector2D TexCoord)
		{
			BP_InstanceGrassInteraction_C.__CalcTexCoord_FunctionParams* ptr = stackalloc BP_InstanceGrassInteraction_C.__CalcTexCoord_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_InstanceGrassInteraction_C.__CalcTexCoord_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InstanceGrassInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MainPlayerPos = MainPlayerPos;
			ptr->OtherPlayerPos = OtherPlayerPos;
			ptr->InteractionSize = InteractionSize;
			ptr->TexCoord = TexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr);
			TexCoord = ptr->TexCoord;
		}

		// Token: 0x06023BDE RID: 146398 RVA: 0x0098ACAD File Offset: 0x00988EAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__ClearRT_NativeFunctionPtr, null);
		}

		// Token: 0x06023BDF RID: 146399 RVA: 0x0098ACC1 File Offset: 0x00988EC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Create_MID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__Create_MID_NativeFunctionPtr, null);
		}

		// Token: 0x06023BE0 RID: 146400 RVA: 0x0098ACD5 File Offset: 0x00988ED5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023BE1 RID: 146401 RVA: 0x0098ACE9 File Offset: 0x00988EE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023BE2 RID: 146402 RVA: 0x0098ACFE File Offset: 0x00988EFE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearRenderTarget()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__ClearRenderTarget_NativeFunctionPtr, null);
		}

		// Token: 0x06023BE3 RID: 146403 RVA: 0x0098AD14 File Offset: 0x00988F14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_InstanceGrassInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InstanceGrassInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InstanceGrassInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InstanceGrassInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023BE4 RID: 146404 RVA: 0x0098AD5C File Offset: 0x00988F5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_InstanceGrassInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InstanceGrassInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InstanceGrassInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InstanceGrassInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023BE5 RID: 146405 RVA: 0x0098ADA4 File Offset: 0x00988FA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InstanceGrassInteraction(int EntryPoint)
		{
			BP_InstanceGrassInteraction_C.__ExecuteUbergraph_BP_InstanceGrassInteraction_FunctionParams* ptr = stackalloc BP_InstanceGrassInteraction_C.__ExecuteUbergraph_BP_InstanceGrassInteraction_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_InstanceGrassInteraction_C.__ExecuteUbergraph_BP_InstanceGrassInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InstanceGrassInteraction_C.__ExecuteUbergraph_BP_InstanceGrassInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InstanceGrassInteraction_C.__ExecuteUbergraph_BP_InstanceGrassInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023BE6 RID: 146406 RVA: 0x0098ADEB File Offset: 0x00988FEB
		protected BP_InstanceGrassInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040123AE RID: 74670
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LongGrass/BP_InstanceGrassInteraction.BP_InstanceGrassInteraction_C";

		// Token: 0x040123AF RID: 74671
		private static IntPtr _ClassPtr;

		// Token: 0x040123B0 RID: 74672
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040123B1 RID: 74673
		internal static int __PropertyOffset_0;

		// Token: 0x040123B2 RID: 74674
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040123B3 RID: 74675
		internal static int __PropertyOffset_1;

		// Token: 0x040123B4 RID: 74676
		private static IntPtr __CalcTexCoord_NativeFunctionPtr;

		// Token: 0x040123B5 RID: 74677
		private static IntPtr __ClearRT_NativeFunctionPtr;

		// Token: 0x040123B6 RID: 74678
		private static IntPtr __Create_MID_NativeFunctionPtr;

		// Token: 0x040123B7 RID: 74679
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040123B8 RID: 74680
		private static IntPtr __ClearRenderTarget_NativeFunctionPtr;

		// Token: 0x040123B9 RID: 74681
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040123BA RID: 74682
		private static IntPtr __ExecuteUbergraph_BP_InstanceGrassInteraction_NativeFunctionPtr;

		// Token: 0x02009D2D RID: 40237
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __CalcTexCoord_FunctionParams
		{
			// Token: 0x040326F3 RID: 206579
			[FieldOffset(0)]
			public FVectorDouble MainPlayerPos;

			// Token: 0x040326F4 RID: 206580
			[FieldOffset(24)]
			public FVectorDouble OtherPlayerPos;

			// Token: 0x040326F5 RID: 206581
			[FieldOffset(48)]
			public float InteractionSize;

			// Token: 0x040326F6 RID: 206582
			[FieldOffset(52)]
			public FVector2D TexCoord;
		}

		// Token: 0x02009D2E RID: 40238
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326F7 RID: 206583
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D2F RID: 40239
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_InstanceGrassInteraction_FunctionParams
		{
			// Token: 0x040326F8 RID: 206584
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
