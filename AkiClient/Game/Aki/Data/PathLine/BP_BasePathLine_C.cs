using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.PathLine
{
	// Token: 0x02003E4E RID: 15950
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/PathLine/BP_BasePathLine.BP_BasePathLine_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1073)]
	public class BP_BasePathLine_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027593 RID: 161171 RVA: 0x009EFAB4 File Offset: 0x009EDCB4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BasePathLine_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/PathLine/BP_BasePathLine.BP_BasePathLine_C");
			}
			return BP_BasePathLine_C._ClassPtr;
		}

		// Token: 0x06027594 RID: 161172 RVA: 0x009EFAD8 File Offset: 0x009EDCD8
		public BP_BasePathLine_C() : this(BuiltinUtils.AllocNativeUObject(BP_BasePathLine_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027595 RID: 161173 RVA: 0x009EFB00 File Offset: 0x009EDD00
		[NullableContext(1)]
		public BP_BasePathLine_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BasePathLine_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005C5A RID: 23642
		// (get) Token: 0x06027596 RID: 161174 RVA: 0x009EFB34 File Offset: 0x009EDD34
		// (set) Token: 0x06027597 RID: 161175 RVA: 0x009EFB6D File Offset: 0x009EDD6D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BasePathLine_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BasePathLine_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C5B RID: 23643
		// (get) Token: 0x06027598 RID: 161176 RVA: 0x009EFB8E File Offset: 0x009EDD8E
		// (set) Token: 0x06027599 RID: 161177 RVA: 0x009EFBA2 File Offset: 0x009EDDA2
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLine_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLine_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005C5C RID: 23644
		// (get) Token: 0x0602759A RID: 161178 RVA: 0x009EFBB7 File Offset: 0x009EDDB7
		// (set) Token: 0x0602759B RID: 161179 RVA: 0x009EFBCB File Offset: 0x009EDDCB
		public unsafe FVector OriginalLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BasePathLine_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BasePathLine_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C5D RID: 23645
		// (get) Token: 0x0602759C RID: 161180 RVA: 0x009EFBE0 File Offset: 0x009EDDE0
		// (set) Token: 0x0602759D RID: 161181 RVA: 0x009EFBF4 File Offset: 0x009EDDF4
		public unsafe AActor DebugTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLine_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLine_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005C5E RID: 23646
		// (get) Token: 0x0602759E RID: 161182 RVA: 0x009EFC09 File Offset: 0x009EDE09
		// (set) Token: 0x0602759F RID: 161183 RVA: 0x009EFC19 File Offset: 0x009EDE19
		public unsafe bool IsAttachedToEntity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BasePathLine_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BasePathLine_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x060275A0 RID: 161184 RVA: 0x009EFC2A File Offset: 0x009EDE2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Save()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BasePathLine_C.__Save_NativeFunctionPtr, null);
		}

		// Token: 0x060275A1 RID: 161185 RVA: 0x009EFC3E File Offset: 0x009EDE3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 贴地处理()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BasePathLine_C.__贴地处理_NativeFunctionPtr, null);
		}

		// Token: 0x060275A2 RID: 161186 RVA: 0x009EFC52 File Offset: 0x009EDE52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BasePathLine_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060275A3 RID: 161187 RVA: 0x009EFC66 File Offset: 0x009EDE66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BasePathLine_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060275A4 RID: 161188 RVA: 0x009EFC7C File Offset: 0x009EDE7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BasePathLine(int EntryPoint)
		{
			BP_BasePathLine_C.__ExecuteUbergraph_BP_BasePathLine_FunctionParams* ptr = stackalloc BP_BasePathLine_C.__ExecuteUbergraph_BP_BasePathLine_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BasePathLine_C.__ExecuteUbergraph_BP_BasePathLine_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BasePathLine_C.__ExecuteUbergraph_BP_BasePathLine_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BasePathLine_C.__ExecuteUbergraph_BP_BasePathLine_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060275A5 RID: 161189 RVA: 0x009EFCC3 File Offset: 0x009EDEC3
		protected BP_BasePathLine_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014993 RID: 84371
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/PathLine/BP_BasePathLine.BP_BasePathLine_C";

		// Token: 0x04014994 RID: 84372
		private static IntPtr _ClassPtr;

		// Token: 0x04014995 RID: 84373
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014996 RID: 84374
		internal static int __PropertyOffset_0;

		// Token: 0x04014997 RID: 84375
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014998 RID: 84376
		internal static int __PropertyOffset_1;

		// Token: 0x04014999 RID: 84377
		internal static int __PropertyOffset_2;

		// Token: 0x0401499A RID: 84378
		internal static int __PropertyOffset_3;

		// Token: 0x0401499B RID: 84379
		internal static int __PropertyOffset_4;

		// Token: 0x0401499C RID: 84380
		private static IntPtr __Save_NativeFunctionPtr;

		// Token: 0x0401499D RID: 84381
		private static IntPtr __贴地处理_NativeFunctionPtr;

		// Token: 0x0401499E RID: 84382
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401499F RID: 84383
		private static IntPtr __ExecuteUbergraph_BP_BasePathLine_NativeFunctionPtr;

		// Token: 0x0200A0CE RID: 41166
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_BasePathLine_FunctionParams
		{
			// Token: 0x04032D82 RID: 208258
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
