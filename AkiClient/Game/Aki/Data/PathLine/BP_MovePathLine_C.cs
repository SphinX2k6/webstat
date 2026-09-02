using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.PathLine
{
	// Token: 0x02003E52 RID: 15954
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/PathLine/BP_MovePathLine.BP_MovePathLine_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1069)]
	public class BP_MovePathLine_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060275EF RID: 161263 RVA: 0x009F0500 File Offset: 0x009EE700
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MovePathLine_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/PathLine/BP_MovePathLine.BP_MovePathLine_C");
			}
			return BP_MovePathLine_C._ClassPtr;
		}

		// Token: 0x060275F0 RID: 161264 RVA: 0x009F0524 File Offset: 0x009EE724
		public BP_MovePathLine_C() : this(BuiltinUtils.AllocNativeUObject(BP_MovePathLine_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060275F1 RID: 161265 RVA: 0x009F054C File Offset: 0x009EE74C
		[NullableContext(1)]
		public BP_MovePathLine_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MovePathLine_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005C72 RID: 23666
		// (get) Token: 0x060275F2 RID: 161266 RVA: 0x009F0580 File Offset: 0x009EE780
		// (set) Token: 0x060275F3 RID: 161267 RVA: 0x009F05B9 File Offset: 0x009EE7B9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MovePathLine_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MovePathLine_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C73 RID: 23667
		// (get) Token: 0x060275F4 RID: 161268 RVA: 0x009F05DA File Offset: 0x009EE7DA
		// (set) Token: 0x060275F5 RID: 161269 RVA: 0x009F05EE File Offset: 0x009EE7EE
		public unsafe UKuroMoveSplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMoveSplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MovePathLine_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MovePathLine_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005C74 RID: 23668
		// (get) Token: 0x060275F6 RID: 161270 RVA: 0x009F0603 File Offset: 0x009EE803
		// (set) Token: 0x060275F7 RID: 161271 RVA: 0x009F0617 File Offset: 0x009EE817
		public unsafe AActor DebugTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MovePathLine_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MovePathLine_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005C75 RID: 23669
		// (get) Token: 0x060275F8 RID: 161272 RVA: 0x009F062C File Offset: 0x009EE82C
		// (set) Token: 0x060275F9 RID: 161273 RVA: 0x009F0640 File Offset: 0x009EE840
		public unsafe FVector OriginalLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MovePathLine_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MovePathLine_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005C76 RID: 23670
		// (get) Token: 0x060275FA RID: 161274 RVA: 0x009F0655 File Offset: 0x009EE855
		// (set) Token: 0x060275FB RID: 161275 RVA: 0x009F0665 File Offset: 0x009EE865
		public unsafe bool IsAttachedToEntity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MovePathLine_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MovePathLine_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x060275FC RID: 161276 RVA: 0x009F0676 File Offset: 0x009EE876
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 贴地处理()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MovePathLine_C.__贴地处理_NativeFunctionPtr, null);
		}

		// Token: 0x060275FD RID: 161277 RVA: 0x009F068A File Offset: 0x009EE88A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Save()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MovePathLine_C.__Save_NativeFunctionPtr, null);
		}

		// Token: 0x060275FE RID: 161278 RVA: 0x009F069E File Offset: 0x009EE89E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MovePathLine_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060275FF RID: 161279 RVA: 0x009F06B2 File Offset: 0x009EE8B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MovePathLine_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06027600 RID: 161280 RVA: 0x009F06C8 File Offset: 0x009EE8C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MovePathLine(int EntryPoint)
		{
			BP_MovePathLine_C.__ExecuteUbergraph_BP_MovePathLine_FunctionParams* ptr = stackalloc BP_MovePathLine_C.__ExecuteUbergraph_BP_MovePathLine_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MovePathLine_C.__ExecuteUbergraph_BP_MovePathLine_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MovePathLine_C.__ExecuteUbergraph_BP_MovePathLine_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MovePathLine_C.__ExecuteUbergraph_BP_MovePathLine_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06027601 RID: 161281 RVA: 0x009F070F File Offset: 0x009EE90F
		protected BP_MovePathLine_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040149D1 RID: 84433
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/PathLine/BP_MovePathLine.BP_MovePathLine_C";

		// Token: 0x040149D2 RID: 84434
		private static IntPtr _ClassPtr;

		// Token: 0x040149D3 RID: 84435
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040149D4 RID: 84436
		internal static int __PropertyOffset_0;

		// Token: 0x040149D5 RID: 84437
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040149D6 RID: 84438
		internal static int __PropertyOffset_1;

		// Token: 0x040149D7 RID: 84439
		internal static int __PropertyOffset_2;

		// Token: 0x040149D8 RID: 84440
		internal static int __PropertyOffset_3;

		// Token: 0x040149D9 RID: 84441
		internal static int __PropertyOffset_4;

		// Token: 0x040149DA RID: 84442
		private static IntPtr __贴地处理_NativeFunctionPtr;

		// Token: 0x040149DB RID: 84443
		private static IntPtr __Save_NativeFunctionPtr;

		// Token: 0x040149DC RID: 84444
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040149DD RID: 84445
		private static IntPtr __ExecuteUbergraph_BP_MovePathLine_NativeFunctionPtr;

		// Token: 0x0200A0D4 RID: 41172
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_MovePathLine_FunctionParams
		{
			// Token: 0x04032D89 RID: 208265
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
