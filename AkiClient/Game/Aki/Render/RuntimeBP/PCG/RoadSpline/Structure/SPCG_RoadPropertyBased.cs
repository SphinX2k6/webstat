using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline.Structure
{
	// Token: 0x02003B9D RID: 15261
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadPropertyBased.SPCG_RoadPropertyBased")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 60)]
	public class SPCG_RoadPropertyBased : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06021E3B RID: 138811 RVA: 0x00956903 File Offset: 0x00954B03
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCG_RoadPropertyBased._ScriptStructPtr != 0) ? SPCG_RoadPropertyBased._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadPropertyBased.SPCG_RoadPropertyBased", ref SPCG_RoadPropertyBased._ScriptStructPtr);
		}

		// Token: 0x17003D92 RID: 15762
		// (get) Token: 0x06021E3C RID: 138812 RVA: 0x00956927 File Offset: 0x00954B27
		// (set) Token: 0x06021E3D RID: 138813 RVA: 0x0095693B File Offset: 0x00954B3B
		[Nullable(2)]
		public unsafe UStaticMesh 基础模型
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SPCG_RoadPropertyBased.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SPCG_RoadPropertyBased.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003D93 RID: 15763
		// (get) Token: 0x06021E3E RID: 138814 RVA: 0x00956950 File Offset: 0x00954B50
		// (set) Token: 0x06021E3F RID: 138815 RVA: 0x00956993 File Offset: 0x00954B93
		[Nullable(1)]
		public TArray<UMaterialInterface> 覆写材质
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._覆写材质) == null)
				{
					result = (this._覆写材质 = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.覆写材质.CopyAssign(value);
			}
		}

		// Token: 0x17003D94 RID: 15764
		// (get) Token: 0x06021E40 RID: 138816 RVA: 0x009569A1 File Offset: 0x00954BA1
		// (set) Token: 0x06021E41 RID: 138817 RVA: 0x009569B5 File Offset: 0x00954BB5
		public unsafe TEnumAsByte<ESplineMeshAxis> 前向轴
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003D95 RID: 15765
		// (get) Token: 0x06021E42 RID: 138818 RVA: 0x009569CA File Offset: 0x00954BCA
		// (set) Token: 0x06021E43 RID: 138819 RVA: 0x009569DE File Offset: 0x00954BDE
		public unsafe FVector 模型偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003D96 RID: 15766
		// (get) Token: 0x06021E44 RID: 138820 RVA: 0x009569F3 File Offset: 0x00954BF3
		// (set) Token: 0x06021E45 RID: 138821 RVA: 0x00956A03 File Offset: 0x00954C03
		public unsafe float 轴向旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003D97 RID: 15767
		// (get) Token: 0x06021E46 RID: 138822 RVA: 0x00956A14 File Offset: 0x00954C14
		// (set) Token: 0x06021E47 RID: 138823 RVA: 0x00956A24 File Offset: 0x00954C24
		public unsafe float 宽度缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003D98 RID: 15768
		// (get) Token: 0x06021E48 RID: 138824 RVA: 0x00956A35 File Offset: 0x00954C35
		// (set) Token: 0x06021E49 RID: 138825 RVA: 0x00956A45 File Offset: 0x00954C45
		public unsafe float 长度缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003D99 RID: 15769
		// (get) Token: 0x06021E4A RID: 138826 RVA: 0x00956A56 File Offset: 0x00954C56
		// (set) Token: 0x06021E4B RID: 138827 RVA: 0x00956A66 File Offset: 0x00954C66
		public unsafe bool 均匀分布
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D9A RID: 15770
		// (get) Token: 0x06021E4C RID: 138828 RVA: 0x00956A77 File Offset: 0x00954C77
		// (set) Token: 0x06021E4D RID: 138829 RVA: 0x00956A87 File Offset: 0x00954C87
		public unsafe float 分布缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPCG_RoadPropertyBased.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x06021E4E RID: 138830 RVA: 0x00956A98 File Offset: 0x00954C98
		public SPCG_RoadPropertyBased()
		{
		}

		// Token: 0x06021E4F RID: 138831 RVA: 0x00956AA0 File Offset: 0x00954CA0
		[NullableContext(1)]
		public SPCG_RoadPropertyBased(UStaticMesh 基础模型, TArray<UMaterialInterface> 覆写材质, [Nullable(0)] TEnumAsByte<ESplineMeshAxis> 前向轴, FVector 模型偏移, float 轴向旋转, float 宽度缩放, float 长度缩放, bool 均匀分布, float 分布缩放)
		{
			this.基础模型 = 基础模型;
			this.覆写材质 = 覆写材质;
			this.前向轴 = 前向轴;
			this.模型偏移 = 模型偏移;
			this.轴向旋转 = 轴向旋转;
			this.宽度缩放 = 宽度缩放;
			this.长度缩放 = 长度缩放;
			this.均匀分布 = 均匀分布;
			this.分布缩放 = 分布缩放;
		}

		// Token: 0x06021E50 RID: 138832 RVA: 0x00956AF8 File Offset: 0x00954CF8
		protected override IntPtr GetUStructPtr()
		{
			return SPCG_RoadPropertyBased.StaticStruct();
		}

		// Token: 0x06021E51 RID: 138833 RVA: 0x00956B04 File Offset: 0x00954D04
		[NullableContext(2)]
		public SPCG_RoadPropertyBased(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06021E52 RID: 138834 RVA: 0x00956B0E File Offset: 0x00954D0E
		public SPCG_RoadPropertyBased(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06021E53 RID: 138835 RVA: 0x00956B19 File Offset: 0x00954D19
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCG_RoadPropertyBased(Pointer, false, true);
		}

		// Token: 0x06021E54 RID: 138836 RVA: 0x00956B23 File Offset: 0x00954D23
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCG_RoadPropertyBased(Pointer, MemoryOwner);
		}

		// Token: 0x040111C7 RID: 70087
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/Structure/SPCG_RoadPropertyBased.SPCG_RoadPropertyBased";

		// Token: 0x040111C8 RID: 70088
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040111C9 RID: 70089
		internal static int __PropertyOffset_0;

		// Token: 0x040111CA RID: 70090
		internal static int __PropertyOffset_1;

		// Token: 0x040111CB RID: 70091
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _覆写材质;

		// Token: 0x040111CC RID: 70092
		internal static int __PropertyOffset_2;

		// Token: 0x040111CD RID: 70093
		internal static int __PropertyOffset_3;

		// Token: 0x040111CE RID: 70094
		internal static int __PropertyOffset_4;

		// Token: 0x040111CF RID: 70095
		internal static int __PropertyOffset_5;

		// Token: 0x040111D0 RID: 70096
		internal static int __PropertyOffset_6;

		// Token: 0x040111D1 RID: 70097
		internal static int __PropertyOffset_7;

		// Token: 0x040111D2 RID: 70098
		internal static int __PropertyOffset_8;
	}
}
