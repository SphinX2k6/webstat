using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.AI.AIMoveSplineCount
{
	// Token: 0x02004386 RID: 17286
	[UnrealObjectPath("/Game/Aki/AI/AIMoveSplineCount/MoveSplineAI.MoveSplineAI_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class MoveSplineAI_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DD33 RID: 187699 RVA: 0x00ACD05D File Offset: 0x00ACB25D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (MoveSplineAI_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/AI/AIMoveSplineCount/MoveSplineAI.MoveSplineAI_C");
			}
			return MoveSplineAI_C._ClassPtr;
		}

		// Token: 0x0602DD34 RID: 187700 RVA: 0x00ACD084 File Offset: 0x00ACB284
		public MoveSplineAI_C() : this(BuiltinUtils.AllocNativeUObject(MoveSplineAI_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DD35 RID: 187701 RVA: 0x00ACD0AC File Offset: 0x00ACB2AC
		[NullableContext(1)]
		public MoveSplineAI_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(MoveSplineAI_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DD36 RID: 187702 RVA: 0x00ACD0E0 File Offset: 0x00ACB2E0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void DCS_Demo(float DeltaSeconds, TsBaseCharacter 跟随角色, USplineComponent 移动样条, float 当前样条位置, float 样条速度, int 飞行模式, float 操作上下偏移, float 操作左右偏移, float 转向速度, FVector 追踪坐标, UObject __WorldContext, ref float 样条位置, ref float 旋转速度累加值)
		{
			MoveSplineAI_C.StaticClass();
			MoveSplineAI_C.__DCS_Demo_FunctionParams* ptr = stackalloc MoveSplineAI_C.__DCS_Demo_FunctionParams[(UIntPtr)1207] + 15L / (long)sizeof(MoveSplineAI_C.__DCS_Demo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MoveSplineAI_C.__DCS_Demo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			ptr->跟随角色 = ((跟随角色 != null) ? 跟随角色.NativePtr : IntPtr.Zero);
			ptr->移动样条 = ((移动样条 != null) ? 移动样条.NativePtr : IntPtr.Zero);
			ptr->当前样条位置 = 当前样条位置;
			ptr->样条速度 = 样条速度;
			ptr->飞行模式 = 飞行模式;
			ptr->操作上下偏移 = 操作上下偏移;
			ptr->操作左右偏移 = 操作左右偏移;
			ptr->转向速度 = 转向速度;
			ptr->追踪坐标 = 追踪坐标;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->样条位置 = 样条位置;
			ptr->旋转速度累加值 = 旋转速度累加值;
			UnrealReflectionUtils.CallVirtualUFunction(MoveSplineAI_C._ClassDefaultObjectPtr, MoveSplineAI_C.__DCS_Demo_NativeFunctionPtr, (void*)ptr);
			样条位置 = ptr->样条位置;
			旋转速度累加值 = ptr->旋转速度累加值;
		}

		// Token: 0x0602DD37 RID: 187703 RVA: 0x00ACD1D0 File Offset: 0x00ACB3D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 元素球跟随(float DeltaSeconds, AActor 特效对象, TsBaseCharacter 跟随角色, UKuroMoveSplineComponent 移动样条, float 当前样条位置, float 样条速度, float 旋转速度, float 旋转速度累加, bool 王府开关, UObject __WorldContext, ref float 样条位置, ref float 旋转速度累加值, ref bool 上行下行)
		{
			MoveSplineAI_C.StaticClass();
			MoveSplineAI_C.__元素球跟随_FunctionParams* ptr = stackalloc MoveSplineAI_C.__元素球跟随_FunctionParams[(UIntPtr)959] + 15L / (long)sizeof(MoveSplineAI_C.__元素球跟随_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MoveSplineAI_C.__元素球跟随_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			ptr->特效对象 = ((特效对象 != null) ? 特效对象.NativePtr : IntPtr.Zero);
			ptr->跟随角色 = ((跟随角色 != null) ? 跟随角色.NativePtr : IntPtr.Zero);
			ptr->移动样条 = ((移动样条 != null) ? 移动样条.NativePtr : IntPtr.Zero);
			ptr->当前样条位置 = 当前样条位置;
			ptr->样条速度 = 样条速度;
			ptr->旋转速度 = 旋转速度;
			ptr->旋转速度累加 = 旋转速度累加;
			ptr->王府开关 = 王府开关;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->样条位置 = 样条位置;
			ptr->旋转速度累加值 = 旋转速度累加值;
			ptr->上行下行 = 上行下行;
			UnrealReflectionUtils.CallVirtualUFunction(MoveSplineAI_C._ClassDefaultObjectPtr, MoveSplineAI_C.__元素球跟随_NativeFunctionPtr, (void*)ptr);
			样条位置 = ptr->样条位置;
			旋转速度累加值 = ptr->旋转速度累加值;
			上行下行 = ptr->上行下行;
		}

		// Token: 0x0602DD38 RID: 187704 RVA: 0x00ACD2D6 File Offset: 0x00ACB4D6
		protected MoveSplineAI_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019DFD RID: 105981
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/AI/AIMoveSplineCount/MoveSplineAI.MoveSplineAI_C";

		// Token: 0x04019DFE RID: 105982
		private static IntPtr _ClassPtr;

		// Token: 0x04019DFF RID: 105983
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019E00 RID: 105984
		private static IntPtr __DCS_Demo_NativeFunctionPtr;

		// Token: 0x04019E01 RID: 105985
		private static IntPtr __元素球跟随_NativeFunctionPtr;

		// Token: 0x0200A5AF RID: 42415
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1192)]
		protected ref struct __DCS_Demo_FunctionParams
		{
			// Token: 0x0403350F RID: 210191
			[FieldOffset(0)]
			public float DeltaSeconds;

			// Token: 0x04033510 RID: 210192
			[FieldOffset(8)]
			public IntPtr 跟随角色;

			// Token: 0x04033511 RID: 210193
			[FieldOffset(16)]
			public IntPtr 移动样条;

			// Token: 0x04033512 RID: 210194
			[FieldOffset(24)]
			public float 当前样条位置;

			// Token: 0x04033513 RID: 210195
			[FieldOffset(28)]
			public float 样条速度;

			// Token: 0x04033514 RID: 210196
			[FieldOffset(32)]
			public int 飞行模式;

			// Token: 0x04033515 RID: 210197
			[FieldOffset(36)]
			public float 操作上下偏移;

			// Token: 0x04033516 RID: 210198
			[FieldOffset(40)]
			public float 操作左右偏移;

			// Token: 0x04033517 RID: 210199
			[FieldOffset(44)]
			public float 转向速度;

			// Token: 0x04033518 RID: 210200
			[FieldOffset(48)]
			public FVector 追踪坐标;

			// Token: 0x04033519 RID: 210201
			[FieldOffset(64)]
			public IntPtr __WorldContext;

			// Token: 0x0403351A RID: 210202
			[FieldOffset(72)]
			public float 样条位置;

			// Token: 0x0403351B RID: 210203
			[FieldOffset(76)]
			public float 旋转速度累加值;
		}

		// Token: 0x0200A5B0 RID: 42416
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 944)]
		protected ref struct __元素球跟随_FunctionParams
		{
			// Token: 0x0403351C RID: 210204
			[FieldOffset(0)]
			public float DeltaSeconds;

			// Token: 0x0403351D RID: 210205
			[FieldOffset(8)]
			public IntPtr 特效对象;

			// Token: 0x0403351E RID: 210206
			[FieldOffset(16)]
			public IntPtr 跟随角色;

			// Token: 0x0403351F RID: 210207
			[FieldOffset(24)]
			public IntPtr 移动样条;

			// Token: 0x04033520 RID: 210208
			[FieldOffset(32)]
			public float 当前样条位置;

			// Token: 0x04033521 RID: 210209
			[FieldOffset(36)]
			public float 样条速度;

			// Token: 0x04033522 RID: 210210
			[FieldOffset(40)]
			public float 旋转速度;

			// Token: 0x04033523 RID: 210211
			[FieldOffset(44)]
			public float 旋转速度累加;

			// Token: 0x04033524 RID: 210212
			[FieldOffset(48)]
			public bool 王府开关;

			// Token: 0x04033525 RID: 210213
			[FieldOffset(56)]
			public IntPtr __WorldContext;

			// Token: 0x04033526 RID: 210214
			[FieldOffset(64)]
			public float 样条位置;

			// Token: 0x04033527 RID: 210215
			[FieldOffset(68)]
			public float 旋转速度累加值;

			// Token: 0x04033528 RID: 210216
			[FieldOffset(72)]
			public bool 上行下行;
		}
	}
}
