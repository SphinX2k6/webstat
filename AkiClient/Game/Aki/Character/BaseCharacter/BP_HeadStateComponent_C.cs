using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041CA RID: 16842
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_HeadStateComponent.BP_HeadStateComponent_C")]
	[UnrealStructLayout(296, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 296)]
	public class BP_HeadStateComponent_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CC8B RID: 183435 RVA: 0x00AAF64B File Offset: 0x00AAD84B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HeadStateComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_HeadStateComponent.BP_HeadStateComponent_C");
			}
			return BP_HeadStateComponent_C._ClassPtr;
		}

		// Token: 0x0602CC8C RID: 183436 RVA: 0x00AAF670 File Offset: 0x00AAD870
		public BP_HeadStateComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_HeadStateComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CC8D RID: 183437 RVA: 0x00AAF698 File Offset: 0x00AAD898
		public BP_HeadStateComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HeadStateComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007906 RID: 30982
		// (get) Token: 0x0602CC8E RID: 183438 RVA: 0x00AAF6CC File Offset: 0x00AAD8CC
		// (set) Token: 0x0602CC8F RID: 183439 RVA: 0x00AAF705 File Offset: 0x00AAD905
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007907 RID: 30983
		// (get) Token: 0x0602CC90 RID: 183440 RVA: 0x00AAF726 File Offset: 0x00AAD926
		// (set) Token: 0x0602CC91 RID: 183441 RVA: 0x00AAF736 File Offset: 0x00AAD936
		public unsafe float 检测半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007908 RID: 30984
		// (get) Token: 0x0602CC92 RID: 183442 RVA: 0x00AAF747 File Offset: 0x00AAD947
		// (set) Token: 0x0602CC93 RID: 183443 RVA: 0x00AAF757 File Offset: 0x00AAD957
		public unsafe float 检测频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007909 RID: 30985
		// (get) Token: 0x0602CC94 RID: 183444 RVA: 0x00AAF768 File Offset: 0x00AAD968
		// (set) Token: 0x0602CC95 RID: 183445 RVA: 0x00AAF7A1 File Offset: 0x00AAD9A1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> 检测ObjectTypes
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._检测ObjectTypes) == null)
				{
					result = (this._检测ObjectTypes = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.检测ObjectTypes.CopyAssign(value);
			}
		}

		// Token: 0x1700790A RID: 30986
		// (get) Token: 0x0602CC96 RID: 183446 RVA: 0x00AAF7AF File Offset: 0x00AAD9AF
		// (set) Token: 0x0602CC97 RID: 183447 RVA: 0x00AAF7C3 File Offset: 0x00AAD9C3
		[Nullable(2)]
		public unsafe AActor Source_Actor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HeadStateComponent_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HeadStateComponent_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700790B RID: 30987
		// (get) Token: 0x0602CC98 RID: 183448 RVA: 0x00AAF7D8 File Offset: 0x00AAD9D8
		// (set) Token: 0x0602CC99 RID: 183449 RVA: 0x00AAF811 File Offset: 0x00AADA11
		public FTimerHandle 检测TimerHandle
		{
			get
			{
				base.FastCheckIsValid();
				FTimerHandle result;
				if ((result = this._检测TimerHandle) == null)
				{
					result = (this._检测TimerHandle = new FTimerHandle(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FTimerHandle.StaticStruct(), base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700790C RID: 30988
		// (get) Token: 0x0602CC9A RID: 183450 RVA: 0x00AAF832 File Offset: 0x00AADA32
		// (set) Token: 0x0602CC9B RID: 183451 RVA: 0x00AAF842 File Offset: 0x00AADA42
		public unsafe float Draw_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700790D RID: 30989
		// (get) Token: 0x0602CC9C RID: 183452 RVA: 0x00AAF853 File Offset: 0x00AADA53
		// (set) Token: 0x0602CC9D RID: 183453 RVA: 0x00AAF867 File Offset: 0x00AADA67
		[Nullable(0)]
		public unsafe TEnumAsByte<EDrawDebugTrace> Draw_Debug_Type
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_7);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700790E RID: 30990
		// (get) Token: 0x0602CC9E RID: 183454 RVA: 0x00AAF87C File Offset: 0x00AADA7C
		// (set) Token: 0x0602CC9F RID: 183455 RVA: 0x00AAF8B5 File Offset: 0x00AADAB5
		public 当刷新检测结果时 当刷新检测结果时
		{
			get
			{
				base.FastCheckIsValid();
				当刷新检测结果时 result;
				if ((result = this._当刷新检测结果时) == null)
				{
					result = (this._当刷新检测结果时 = new 当刷新检测结果时(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_8, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700790F RID: 30991
		// (get) Token: 0x0602CCA0 RID: 183456 RVA: 0x00AAF8D8 File Offset: 0x00AADAD8
		// (set) Token: 0x0602CCA1 RID: 183457 RVA: 0x00AAF911 File Offset: 0x00AADB11
		public TArray<TsBaseCharacter> CheckCharacters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TsBaseCharacter> result;
				if ((result = this._CheckCharacters) == null)
				{
					result = (this._CheckCharacters = new TArray<TsBaseCharacter>(base.NativePtr + (IntPtr)BP_HeadStateComponent_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.CheckCharacters.CopyAssign(value);
			}
		}

		// Token: 0x0602CCA2 RID: 183458 RVA: 0x00AAF920 File Offset: 0x00AADB20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取检测结果([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<TsBaseCharacter> Results)
		{
			BP_HeadStateComponent_C.__获取检测结果_FunctionParams* ptr = stackalloc BP_HeadStateComponent_C.__获取检测结果_FunctionParams[(UIntPtr)407] + 15L / (long)sizeof(BP_HeadStateComponent_C.__获取检测结果_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeadStateComponent_C.__获取检测结果_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Results;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Results);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HeadStateComponent_C.__获取检测结果_NativeFunctionPtr, (void*)ptr);
			object obj2 = Results;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Results);
			}
			UnrealReflectionUtils.DestroyStruct(BP_HeadStateComponent_C.__获取检测结果_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CCA3 RID: 183459 RVA: 0x00AAF99C File Offset: 0x00AADB9C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool 获取是否在检测范围内(AActor OtherActor)
		{
			BP_HeadStateComponent_C.__获取是否在检测范围内_FunctionParams* ptr = stackalloc BP_HeadStateComponent_C.__获取是否在检测范围内_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_HeadStateComponent_C.__获取是否在检测范围内_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeadStateComponent_C.__获取是否在检测范围内_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HeadStateComponent_C.__获取是否在检测范围内_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CCA4 RID: 183460 RVA: 0x00AAF9F7 File Offset: 0x00AADBF7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 当检测时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HeadStateComponent_C.__当检测时_NativeFunctionPtr, null);
		}

		// Token: 0x0602CCA5 RID: 183461 RVA: 0x00AAFA0B File Offset: 0x00AADC0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 休眠检测()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HeadStateComponent_C.__休眠检测_NativeFunctionPtr, null);
		}

		// Token: 0x0602CCA6 RID: 183462 RVA: 0x00AAFA20 File Offset: 0x00AADC20
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 激活检测(AActor Source_Actor)
		{
			BP_HeadStateComponent_C.__激活检测_FunctionParams* ptr = stackalloc BP_HeadStateComponent_C.__激活检测_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_HeadStateComponent_C.__激活检测_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeadStateComponent_C.__激活检测_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Source_Actor = ((Source_Actor != null) ? Source_Actor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HeadStateComponent_C.__激活检测_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CCA7 RID: 183463 RVA: 0x00AAFA78 File Offset: 0x00AADC78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_HeadStateComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_HeadStateComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_HeadStateComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeadStateComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HeadStateComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CCA8 RID: 183464 RVA: 0x00AAFAC4 File Offset: 0x00AADCC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_HeadStateComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_HeadStateComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_HeadStateComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeadStateComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HeadStateComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CCA9 RID: 183465 RVA: 0x00AAFB10 File Offset: 0x00AADD10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_HeadStateComponent(int EntryPoint)
		{
			BP_HeadStateComponent_C.__ExecuteUbergraph_BP_HeadStateComponent_FunctionParams* ptr = stackalloc BP_HeadStateComponent_C.__ExecuteUbergraph_BP_HeadStateComponent_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_HeadStateComponent_C.__ExecuteUbergraph_BP_HeadStateComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HeadStateComponent_C.__ExecuteUbergraph_BP_HeadStateComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HeadStateComponent_C.__ExecuteUbergraph_BP_HeadStateComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CCAA RID: 183466 RVA: 0x00AAFB57 File Offset: 0x00AADD57
		protected BP_HeadStateComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F4B RID: 102219
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_HeadStateComponent.BP_HeadStateComponent_C";

		// Token: 0x04018F4C RID: 102220
		private static IntPtr _ClassPtr;

		// Token: 0x04018F4D RID: 102221
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F4E RID: 102222
		public static IntPtr __当刷新检测结果时__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04018F4F RID: 102223
		internal static int __PropertyOffset_0;

		// Token: 0x04018F50 RID: 102224
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018F51 RID: 102225
		internal static int __PropertyOffset_1;

		// Token: 0x04018F52 RID: 102226
		internal static int __PropertyOffset_2;

		// Token: 0x04018F53 RID: 102227
		internal static int __PropertyOffset_3;

		// Token: 0x04018F54 RID: 102228
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _检测ObjectTypes;

		// Token: 0x04018F55 RID: 102229
		internal static int __PropertyOffset_4;

		// Token: 0x04018F56 RID: 102230
		internal static int __PropertyOffset_5;

		// Token: 0x04018F57 RID: 102231
		[Nullable(2)]
		private FTimerHandle _检测TimerHandle;

		// Token: 0x04018F58 RID: 102232
		internal static int __PropertyOffset_6;

		// Token: 0x04018F59 RID: 102233
		internal static int __PropertyOffset_7;

		// Token: 0x04018F5A RID: 102234
		internal static int __PropertyOffset_8;

		// Token: 0x04018F5B RID: 102235
		[Nullable(2)]
		private 当刷新检测结果时 _当刷新检测结果时;

		// Token: 0x04018F5C RID: 102236
		internal static int __PropertyOffset_9;

		// Token: 0x04018F5D RID: 102237
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<TsBaseCharacter> _CheckCharacters;

		// Token: 0x04018F5E RID: 102238
		private static IntPtr __获取检测结果_NativeFunctionPtr;

		// Token: 0x04018F5F RID: 102239
		private static IntPtr __获取是否在检测范围内_NativeFunctionPtr;

		// Token: 0x04018F60 RID: 102240
		private static IntPtr __当检测时_NativeFunctionPtr;

		// Token: 0x04018F61 RID: 102241
		private static IntPtr __休眠检测_NativeFunctionPtr;

		// Token: 0x04018F62 RID: 102242
		private static IntPtr __激活检测_NativeFunctionPtr;

		// Token: 0x04018F63 RID: 102243
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04018F64 RID: 102244
		private static IntPtr __ExecuteUbergraph_BP_HeadStateComponent_NativeFunctionPtr;

		// Token: 0x0200A51C RID: 42268
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 392)]
		protected ref struct __获取检测结果_FunctionParams
		{
			// Token: 0x040333C2 RID: 209858
			[FieldOffset(0)]
			public byte Results;
		}

		// Token: 0x0200A51D RID: 42269
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __获取是否在检测范围内_FunctionParams
		{
			// Token: 0x040333C3 RID: 209859
			[FieldOffset(0)]
			public IntPtr OtherActor;

			// Token: 0x040333C4 RID: 209860
			[FieldOffset(8)]
			public bool __Result;
		}

		// Token: 0x0200A51E RID: 42270
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __激活检测_FunctionParams
		{
			// Token: 0x040333C5 RID: 209861
			[FieldOffset(0)]
			public IntPtr Source_Actor;
		}

		// Token: 0x0200A51F RID: 42271
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040333C6 RID: 209862
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200A520 RID: 42272
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_HeadStateComponent_FunctionParams
		{
			// Token: 0x040333C7 RID: 209863
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
