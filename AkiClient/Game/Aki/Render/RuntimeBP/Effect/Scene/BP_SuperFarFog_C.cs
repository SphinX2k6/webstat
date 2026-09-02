using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D34 RID: 15668
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_SuperFarFog.BP_SuperFarFog_C")]
	[UnrealStructLayout(1736, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1736)]
	public class BP_SuperFarFog_C : AKuroSuperFarFog, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025FD4 RID: 155604 RVA: 0x009CA824 File Offset: 0x009C8A24
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SuperFarFog_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_SuperFarFog.BP_SuperFarFog_C");
			}
			return BP_SuperFarFog_C._ClassPtr;
		}

		// Token: 0x06025FD5 RID: 155605 RVA: 0x009CA848 File Offset: 0x009C8A48
		public BP_SuperFarFog_C() : this(BuiltinUtils.AllocNativeUObject(BP_SuperFarFog_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025FD6 RID: 155606 RVA: 0x009CA870 File Offset: 0x009C8A70
		public BP_SuperFarFog_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SuperFarFog_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170054E6 RID: 21734
		// (get) Token: 0x06025FD7 RID: 155607 RVA: 0x009CA8A4 File Offset: 0x009C8AA4
		// (set) Token: 0x06025FD8 RID: 155608 RVA: 0x009CA8DD File Offset: 0x009C8ADD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054E7 RID: 21735
		// (get) Token: 0x06025FD9 RID: 155609 RVA: 0x009CA8FE File Offset: 0x009C8AFE
		// (set) Token: 0x06025FDA RID: 155610 RVA: 0x009CA90E File Offset: 0x009C8B0E
		public unsafe bool 固定旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170054E8 RID: 21736
		// (get) Token: 0x06025FDB RID: 155611 RVA: 0x009CA91F File Offset: 0x009C8B1F
		// (set) Token: 0x06025FDC RID: 155612 RVA: 0x009CA92F File Offset: 0x009C8B2F
		public unsafe float 固定旋转弹性
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170054E9 RID: 21737
		// (get) Token: 0x06025FDD RID: 155613 RVA: 0x009CA940 File Offset: 0x009C8B40
		// (set) Token: 0x06025FDE RID: 155614 RVA: 0x009CA950 File Offset: 0x009C8B50
		public unsafe int 贴图序号
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170054EA RID: 21738
		// (get) Token: 0x06025FDF RID: 155615 RVA: 0x009CA961 File Offset: 0x009C8B61
		// (set) Token: 0x06025FE0 RID: 155616 RVA: 0x009CA971 File Offset: 0x009C8B71
		public unsafe float 受光照影响值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170054EB RID: 21739
		// (get) Token: 0x06025FE1 RID: 155617 RVA: 0x009CA982 File Offset: 0x009C8B82
		// (set) Token: 0x06025FE2 RID: 155618 RVA: 0x009CA996 File Offset: 0x009C8B96
		public unsafe FLinearColor 颜色和不透明度调整
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170054EC RID: 21740
		// (get) Token: 0x06025FE3 RID: 155619 RVA: 0x009CA9AB File Offset: 0x009C8BAB
		// (set) Token: 0x06025FE4 RID: 155620 RVA: 0x009CA9BB File Offset: 0x009C8BBB
		public unsafe bool 夜间给单独的调整值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170054ED RID: 21741
		// (get) Token: 0x06025FE5 RID: 155621 RVA: 0x009CA9CC File Offset: 0x009C8BCC
		// (set) Token: 0x06025FE6 RID: 155622 RVA: 0x009CA9E0 File Offset: 0x009C8BE0
		public unsafe FLinearColor 夜间的颜色和不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170054EE RID: 21742
		// (get) Token: 0x06025FE7 RID: 155623 RVA: 0x009CA9F8 File Offset: 0x009C8BF8
		// (set) Token: 0x06025FE8 RID: 155624 RVA: 0x009CAA31 File Offset: 0x009C8C31
		public FKuroCurveFloat 日夜混合曲线
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._日夜混合曲线) == null)
				{
					result = (this._日夜混合曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054EF RID: 21743
		// (get) Token: 0x06025FE9 RID: 155625 RVA: 0x009CAA52 File Offset: 0x009C8C52
		// (set) Token: 0x06025FEA RID: 155626 RVA: 0x009CAA66 File Offset: 0x009C8C66
		public unsafe FVector2D 流动速度_Add_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170054F0 RID: 21744
		// (get) Token: 0x06025FEB RID: 155627 RVA: 0x009CAA7B File Offset: 0x009C8C7B
		// (set) Token: 0x06025FEC RID: 155628 RVA: 0x009CAA8B File Offset: 0x009C8C8B
		public unsafe float 深度渐隐距离缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170054F1 RID: 21745
		// (get) Token: 0x06025FED RID: 155629 RVA: 0x009CAA9C File Offset: 0x009C8C9C
		// (set) Token: 0x06025FEE RID: 155630 RVA: 0x009CAAAC File Offset: 0x009C8CAC
		public unsafe float 相机距离渐隐缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SuperFarFog_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x06025FEF RID: 155631 RVA: 0x009CAABD File Offset: 0x009C8CBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SuperFarFog_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025FF0 RID: 155632 RVA: 0x009CAAD1 File Offset: 0x009C8CD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SuperFarFog_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025FF1 RID: 155633 RVA: 0x009CAAE6 File Offset: 0x009C8CE6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Refresh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SuperFarFog_C.__Refresh_NativeFunctionPtr, null);
		}

		// Token: 0x06025FF2 RID: 155634 RVA: 0x009CAAFC File Offset: 0x009C8CFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SuperFarFog(int EntryPoint)
		{
			BP_SuperFarFog_C.__ExecuteUbergraph_BP_SuperFarFog_FunctionParams* ptr = stackalloc BP_SuperFarFog_C.__ExecuteUbergraph_BP_SuperFarFog_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SuperFarFog_C.__ExecuteUbergraph_BP_SuperFarFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SuperFarFog_C.__ExecuteUbergraph_BP_SuperFarFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SuperFarFog_C.__ExecuteUbergraph_BP_SuperFarFog_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025FF3 RID: 155635 RVA: 0x009CAB43 File Offset: 0x009C8D43
		protected BP_SuperFarFog_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013A58 RID: 80472
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_SuperFarFog.BP_SuperFarFog_C";

		// Token: 0x04013A59 RID: 80473
		private static IntPtr _ClassPtr;

		// Token: 0x04013A5A RID: 80474
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013A5B RID: 80475
		internal static int __PropertyOffset_0;

		// Token: 0x04013A5C RID: 80476
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013A5D RID: 80477
		internal static int __PropertyOffset_1;

		// Token: 0x04013A5E RID: 80478
		internal static int __PropertyOffset_2;

		// Token: 0x04013A5F RID: 80479
		internal static int __PropertyOffset_3;

		// Token: 0x04013A60 RID: 80480
		internal static int __PropertyOffset_4;

		// Token: 0x04013A61 RID: 80481
		internal static int __PropertyOffset_5;

		// Token: 0x04013A62 RID: 80482
		internal static int __PropertyOffset_6;

		// Token: 0x04013A63 RID: 80483
		internal static int __PropertyOffset_7;

		// Token: 0x04013A64 RID: 80484
		internal static int __PropertyOffset_8;

		// Token: 0x04013A65 RID: 80485
		[Nullable(2)]
		private FKuroCurveFloat _日夜混合曲线;

		// Token: 0x04013A66 RID: 80486
		internal static int __PropertyOffset_9;

		// Token: 0x04013A67 RID: 80487
		internal static int __PropertyOffset_10;

		// Token: 0x04013A68 RID: 80488
		internal static int __PropertyOffset_11;

		// Token: 0x04013A69 RID: 80489
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013A6A RID: 80490
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x04013A6B RID: 80491
		private static IntPtr __ExecuteUbergraph_BP_SuperFarFog_NativeFunctionPtr;

		// Token: 0x02009FDD RID: 40925
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_SuperFarFog_FunctionParams
		{
			// Token: 0x04032B95 RID: 207765
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
