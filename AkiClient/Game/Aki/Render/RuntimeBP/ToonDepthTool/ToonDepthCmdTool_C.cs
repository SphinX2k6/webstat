using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ToonDepthTool
{
	// Token: 0x02003A3C RID: 14908
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ToonDepthTool/ToonDepthCmdTool.ToonDepthCmdTool_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1088)]
	public class ToonDepthCmdTool_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EC04 RID: 125956 RVA: 0x008FD860 File Offset: 0x008FBA60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ToonDepthCmdTool_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ToonDepthTool/ToonDepthCmdTool.ToonDepthCmdTool_C");
			}
			return ToonDepthCmdTool_C._ClassPtr;
		}

		// Token: 0x0601EC05 RID: 125957 RVA: 0x008FD884 File Offset: 0x008FBA84
		public ToonDepthCmdTool_C() : this(BuiltinUtils.AllocNativeUObject(ToonDepthCmdTool_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EC06 RID: 125958 RVA: 0x008FD8AC File Offset: 0x008FBAAC
		public ToonDepthCmdTool_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ToonDepthCmdTool_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C37 RID: 11319
		// (get) Token: 0x0601EC07 RID: 125959 RVA: 0x008FD8E0 File Offset: 0x008FBAE0
		// (set) Token: 0x0601EC08 RID: 125960 RVA: 0x008FD919 File Offset: 0x008FBB19
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ToonDepthCmdTool_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ToonDepthCmdTool_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C38 RID: 11320
		// (get) Token: 0x0601EC09 RID: 125961 RVA: 0x008FD93A File Offset: 0x008FBB3A
		// (set) Token: 0x0601EC0A RID: 125962 RVA: 0x008FD94E File Offset: 0x008FBB4E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ToonDepthCmdTool_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ToonDepthCmdTool_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C39 RID: 11321
		// (get) Token: 0x0601EC0B RID: 125963 RVA: 0x008FD963 File Offset: 0x008FBB63
		// (set) Token: 0x0601EC0C RID: 125964 RVA: 0x008FD973 File Offset: 0x008FBB73
		public unsafe bool NeedRunEndCommand
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ToonDepthCmdTool_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ToonDepthCmdTool_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C3A RID: 11322
		// (get) Token: 0x0601EC0D RID: 125965 RVA: 0x008FD984 File Offset: 0x008FBB84
		// (set) Token: 0x0601EC0E RID: 125966 RVA: 0x008FD9BD File Offset: 0x008FBBBD
		public TArray<string> StartCommandArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._StartCommandArray) == null)
				{
					result = (this._StartCommandArray = new TArray<string>(base.NativePtr + (IntPtr)ToonDepthCmdTool_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.StartCommandArray.CopyAssign(value);
			}
		}

		// Token: 0x17002C3B RID: 11323
		// (get) Token: 0x0601EC0F RID: 125967 RVA: 0x008FD9CC File Offset: 0x008FBBCC
		// (set) Token: 0x0601EC10 RID: 125968 RVA: 0x008FDA05 File Offset: 0x008FBC05
		public TArray<string> EndCommandArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._EndCommandArray) == null)
				{
					result = (this._EndCommandArray = new TArray<string>(base.NativePtr + (IntPtr)ToonDepthCmdTool_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.EndCommandArray.CopyAssign(value);
			}
		}

		// Token: 0x0601EC11 RID: 125969 RVA: 0x008FDA13 File Offset: 0x008FBC13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ToonDepthCmdTool_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC12 RID: 125970 RVA: 0x008FDA27 File Offset: 0x008FBC27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ToonDepthCmdTool_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EC13 RID: 125971 RVA: 0x008FDA3C File Offset: 0x008FBC3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ToonDepthCmdTool_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EC14 RID: 125972 RVA: 0x008FDA50 File Offset: 0x008FBC50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ToonDepthCmdTool_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EC15 RID: 125973 RVA: 0x008FDA68 File Offset: 0x008FBC68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			ToonDepthCmdTool_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc ToonDepthCmdTool_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ToonDepthCmdTool_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ToonDepthCmdTool_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ToonDepthCmdTool_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EC16 RID: 125974 RVA: 0x008FDAB4 File Offset: 0x008FBCB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			ToonDepthCmdTool_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc ToonDepthCmdTool_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ToonDepthCmdTool_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ToonDepthCmdTool_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ToonDepthCmdTool_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EC17 RID: 125975 RVA: 0x008FDB00 File Offset: 0x008FBD00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ToonDepthCmdTool(int EntryPoint)
		{
			ToonDepthCmdTool_C.__ExecuteUbergraph_ToonDepthCmdTool_FunctionParams* ptr = stackalloc ToonDepthCmdTool_C.__ExecuteUbergraph_ToonDepthCmdTool_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(ToonDepthCmdTool_C.__ExecuteUbergraph_ToonDepthCmdTool_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ToonDepthCmdTool_C.__ExecuteUbergraph_ToonDepthCmdTool_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ToonDepthCmdTool_C.__ExecuteUbergraph_ToonDepthCmdTool_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EC18 RID: 125976 RVA: 0x008FDB4A File Offset: 0x008FBD4A
		protected ToonDepthCmdTool_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F2DD RID: 62173
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ToonDepthTool/ToonDepthCmdTool.ToonDepthCmdTool_C";

		// Token: 0x0400F2DE RID: 62174
		private static IntPtr _ClassPtr;

		// Token: 0x0400F2DF RID: 62175
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F2E0 RID: 62176
		internal static int __PropertyOffset_0;

		// Token: 0x0400F2E1 RID: 62177
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F2E2 RID: 62178
		internal static int __PropertyOffset_1;

		// Token: 0x0400F2E3 RID: 62179
		internal static int __PropertyOffset_2;

		// Token: 0x0400F2E4 RID: 62180
		internal static int __PropertyOffset_3;

		// Token: 0x0400F2E5 RID: 62181
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _StartCommandArray;

		// Token: 0x0400F2E6 RID: 62182
		internal static int __PropertyOffset_4;

		// Token: 0x0400F2E7 RID: 62183
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _EndCommandArray;

		// Token: 0x0400F2E8 RID: 62184
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F2E9 RID: 62185
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F2EA RID: 62186
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F2EB RID: 62187
		private static IntPtr __ExecuteUbergraph_ToonDepthCmdTool_NativeFunctionPtr;

		// Token: 0x020097FA RID: 38906
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031DEF RID: 204271
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x020097FB RID: 38907
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_ToonDepthCmdTool_FunctionParams
		{
			// Token: 0x04031DF0 RID: 204272
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
