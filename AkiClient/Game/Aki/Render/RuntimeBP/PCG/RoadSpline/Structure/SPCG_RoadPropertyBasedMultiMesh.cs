using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline.Structure
{
	// Token: 0x02003B9E RID: 15262
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadPropertyBasedMultiMesh.SPCG_RoadPropertyBasedMultiMesh")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 36)]
	public class SPCG_RoadPropertyBasedMultiMesh : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06021E55 RID: 138837 RVA: 0x00956B2C File Offset: 0x00954D2C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCG_RoadPropertyBasedMultiMesh._ScriptStructPtr != 0) ? SPCG_RoadPropertyBasedMultiMesh._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadPropertyBasedMultiMesh.SPCG_RoadPropertyBasedMultiMesh", ref SPCG_RoadPropertyBasedMultiMesh._ScriptStructPtr);
		}

		// Token: 0x17003D9B RID: 15771
		// (get) Token: 0x06021E56 RID: 138838 RVA: 0x00956B50 File Offset: 0x00954D50
		// (set) Token: 0x06021E57 RID: 138839 RVA: 0x00956B64 File Offset: 0x00954D64
		[Nullable(2)]
		public unsafe UStaticMesh 基础模型
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003D9C RID: 15772
		// (get) Token: 0x06021E58 RID: 138840 RVA: 0x00956B79 File Offset: 0x00954D79
		// (set) Token: 0x06021E59 RID: 138841 RVA: 0x00956B8D File Offset: 0x00954D8D
		public unsafe TEnumAsByte<ESplineMeshAxis> 前向轴
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17003D9D RID: 15773
		// (get) Token: 0x06021E5A RID: 138842 RVA: 0x00956BA2 File Offset: 0x00954DA2
		// (set) Token: 0x06021E5B RID: 138843 RVA: 0x00956BB2 File Offset: 0x00954DB2
		public unsafe float 轴向旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003D9E RID: 15774
		// (get) Token: 0x06021E5C RID: 138844 RVA: 0x00956BC3 File Offset: 0x00954DC3
		// (set) Token: 0x06021E5D RID: 138845 RVA: 0x00956BD7 File Offset: 0x00954DD7
		public unsafe FVector 模型偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003D9F RID: 15775
		// (get) Token: 0x06021E5E RID: 138846 RVA: 0x00956BEC File Offset: 0x00954DEC
		// (set) Token: 0x06021E5F RID: 138847 RVA: 0x00956BFC File Offset: 0x00954DFC
		public unsafe float 缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003DA0 RID: 15776
		// (get) Token: 0x06021E60 RID: 138848 RVA: 0x00956C0D File Offset: 0x00954E0D
		// (set) Token: 0x06021E61 RID: 138849 RVA: 0x00956C1D File Offset: 0x00954E1D
		public unsafe int 数量限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBasedMultiMesh.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06021E62 RID: 138850 RVA: 0x00956C2E File Offset: 0x00954E2E
		public SPCG_RoadPropertyBasedMultiMesh()
		{
		}

		// Token: 0x06021E63 RID: 138851 RVA: 0x00956C36 File Offset: 0x00954E36
		public SPCG_RoadPropertyBasedMultiMesh([Nullable(1)] UStaticMesh 基础模型, TEnumAsByte<ESplineMeshAxis> 前向轴, float 轴向旋转, FVector 模型偏移, float 缩放, int 数量限制)
		{
			this.基础模型 = 基础模型;
			this.前向轴 = 前向轴;
			this.轴向旋转 = 轴向旋转;
			this.模型偏移 = 模型偏移;
			this.缩放 = 缩放;
			this.数量限制 = 数量限制;
		}

		// Token: 0x06021E64 RID: 138852 RVA: 0x00956C6B File Offset: 0x00954E6B
		protected override IntPtr GetUStructPtr()
		{
			return SPCG_RoadPropertyBasedMultiMesh.StaticStruct();
		}

		// Token: 0x06021E65 RID: 138853 RVA: 0x00956C77 File Offset: 0x00954E77
		[NullableContext(2)]
		public SPCG_RoadPropertyBasedMultiMesh(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06021E66 RID: 138854 RVA: 0x00956C81 File Offset: 0x00954E81
		public SPCG_RoadPropertyBasedMultiMesh(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06021E67 RID: 138855 RVA: 0x00956C8C File Offset: 0x00954E8C
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCG_RoadPropertyBasedMultiMesh(Pointer, false, true);
		}

		// Token: 0x06021E68 RID: 138856 RVA: 0x00956C96 File Offset: 0x00954E96
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCG_RoadPropertyBasedMultiMesh(Pointer, MemoryOwner);
		}

		// Token: 0x040111D3 RID: 70099
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadPropertyBasedMultiMesh.SPCG_RoadPropertyBasedMultiMesh";

		// Token: 0x040111D4 RID: 70100
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040111D5 RID: 70101
		internal static int __PropertyOffset_0;

		// Token: 0x040111D6 RID: 70102
		internal static int __PropertyOffset_1;

		// Token: 0x040111D7 RID: 70103
		internal static int __PropertyOffset_2;

		// Token: 0x040111D8 RID: 70104
		internal static int __PropertyOffset_3;

		// Token: 0x040111D9 RID: 70105
		internal static int __PropertyOffset_4;

		// Token: 0x040111DA RID: 70106
		internal static int __PropertyOffset_5;
	}
}
