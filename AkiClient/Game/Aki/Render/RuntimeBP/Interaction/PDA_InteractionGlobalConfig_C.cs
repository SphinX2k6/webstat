using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C89 RID: 15497
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionGlobalConfig.PDA_InteractionGlobalConfig_C")]
	[UnrealStructLayout(528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 522)]
	public class PDA_InteractionGlobalConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602417B RID: 147835 RVA: 0x0099482B File Offset: 0x00992A2B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_InteractionGlobalConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionGlobalConfig.PDA_InteractionGlobalConfig_C");
			}
			return PDA_InteractionGlobalConfig_C._ClassPtr;
		}

		// Token: 0x0602417C RID: 147836 RVA: 0x00994850 File Offset: 0x00992A50
		public PDA_InteractionGlobalConfig_C() : this(BuiltinUtils.AllocNativeUObject(PDA_InteractionGlobalConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602417D RID: 147837 RVA: 0x00994878 File Offset: 0x00992A78
		public PDA_InteractionGlobalConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_InteractionGlobalConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170049F0 RID: 18928
		// (get) Token: 0x0602417E RID: 147838 RVA: 0x009948AB File Offset: 0x00992AAB
		// (set) Token: 0x0602417F RID: 147839 RVA: 0x009948BB File Offset: 0x00992ABB
		public unsafe bool 屏蔽所有水面交互物体
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170049F1 RID: 18929
		// (get) Token: 0x06024180 RID: 147840 RVA: 0x009948CC File Offset: 0x00992ACC
		// (set) Token: 0x06024181 RID: 147841 RVA: 0x00994905 File Offset: 0x00992B05
		public FSoftObjectPath 植被恢复材质
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._植被恢复材质) == null)
				{
					result = (this._植被恢复材质 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049F2 RID: 18930
		// (get) Token: 0x06024182 RID: 147842 RVA: 0x00994928 File Offset: 0x00992B28
		// (set) Token: 0x06024183 RID: 147843 RVA: 0x00994961 File Offset: 0x00992B61
		public FSoftObjectPath 植被交互计算材质
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._植被交互计算材质) == null)
				{
					result = (this._植被交互计算材质 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049F3 RID: 18931
		// (get) Token: 0x06024184 RID: 147844 RVA: 0x00994984 File Offset: 0x00992B84
		// (set) Token: 0x06024185 RID: 147845 RVA: 0x009949BD File Offset: 0x00992BBD
		public FSoftObjectPath 植被结果材质
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._植被结果材质) == null)
				{
					result = (this._植被结果材质 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049F4 RID: 18932
		// (get) Token: 0x06024186 RID: 147846 RVA: 0x009949E0 File Offset: 0x00992BE0
		// (set) Token: 0x06024187 RID: 147847 RVA: 0x00994A19 File Offset: 0x00992C19
		public FSoftObjectPath 水面波纹触发材质
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._水面波纹触发材质) == null)
				{
					result = (this._水面波纹触发材质 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049F5 RID: 18933
		// (get) Token: 0x06024188 RID: 147848 RVA: 0x00994A3C File Offset: 0x00992C3C
		// (set) Token: 0x06024189 RID: 147849 RVA: 0x00994A75 File Offset: 0x00992C75
		public FSoftObjectPath 水面波纹计算材质
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._水面波纹计算材质) == null)
				{
					result = (this._水面波纹计算材质 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049F6 RID: 18934
		// (get) Token: 0x0602418A RID: 147850 RVA: 0x00994A98 File Offset: 0x00992C98
		// (set) Token: 0x0602418B RID: 147851 RVA: 0x00994AD1 File Offset: 0x00992CD1
		public FSoftObjectPath 高斯模糊材质
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._高斯模糊材质) == null)
				{
					result = (this._高斯模糊材质 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049F7 RID: 18935
		// (get) Token: 0x0602418C RID: 147852 RVA: 0x00994AF4 File Offset: 0x00992CF4
		// (set) Token: 0x0602418D RID: 147853 RVA: 0x00994B2D File Offset: 0x00992D2D
		public FSoftObjectPath 水面波纹结果材质
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._水面波纹结果材质) == null)
				{
					result = (this._水面波纹结果材质 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049F8 RID: 18936
		// (get) Token: 0x0602418E RID: 147854 RVA: 0x00994B50 File Offset: 0x00992D50
		// (set) Token: 0x0602418F RID: 147855 RVA: 0x00994B89 File Offset: 0x00992D89
		public FSoftObjectPath 植被交互纹理
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._植被交互纹理) == null)
				{
					result = (this._植被交互纹理 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049F9 RID: 18937
		// (get) Token: 0x06024190 RID: 147856 RVA: 0x00994BAC File Offset: 0x00992DAC
		// (set) Token: 0x06024191 RID: 147857 RVA: 0x00994BE5 File Offset: 0x00992DE5
		public FSoftObjectPath 植被交互临时纹理
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._植被交互临时纹理) == null)
				{
					result = (this._植被交互临时纹理 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049FA RID: 18938
		// (get) Token: 0x06024192 RID: 147858 RVA: 0x00994C08 File Offset: 0x00992E08
		// (set) Token: 0x06024193 RID: 147859 RVA: 0x00994C41 File Offset: 0x00992E41
		public FSoftObjectPath 水面交互纹理
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._水面交互纹理) == null)
				{
					result = (this._水面交互纹理 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049FB RID: 18939
		// (get) Token: 0x06024194 RID: 147860 RVA: 0x00994C64 File Offset: 0x00992E64
		// (set) Token: 0x06024195 RID: 147861 RVA: 0x00994C9D File Offset: 0x00992E9D
		public FSoftObjectPath 水面交互临时纹理1
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._水面交互临时纹理1) == null)
				{
					result = (this._水面交互临时纹理1 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049FC RID: 18940
		// (get) Token: 0x06024196 RID: 147862 RVA: 0x00994CC0 File Offset: 0x00992EC0
		// (set) Token: 0x06024197 RID: 147863 RVA: 0x00994CF9 File Offset: 0x00992EF9
		public FSoftObjectPath 水面交互临时纹理2
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._水面交互临时纹理2) == null)
				{
					result = (this._水面交互临时纹理2 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049FD RID: 18941
		// (get) Token: 0x06024198 RID: 147864 RVA: 0x00994D1C File Offset: 0x00992F1C
		// (set) Token: 0x06024199 RID: 147865 RVA: 0x00994D55 File Offset: 0x00992F55
		public FSoftObjectPath 水面交互临时纹理3
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._水面交互临时纹理3) == null)
				{
					result = (this._水面交互临时纹理3 = new FSoftObjectPath(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049FE RID: 18942
		// (get) Token: 0x0602419A RID: 147866 RVA: 0x00994D76 File Offset: 0x00992F76
		// (set) Token: 0x0602419B RID: 147867 RVA: 0x00994D86 File Offset: 0x00992F86
		public unsafe bool 屏蔽所有草地交互物体
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170049FF RID: 18943
		// (get) Token: 0x0602419C RID: 147868 RVA: 0x00994D97 File Offset: 0x00992F97
		// (set) Token: 0x0602419D RID: 147869 RVA: 0x00994DA7 File Offset: 0x00992FA7
		public unsafe bool 停止水模拟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A00 RID: 18944
		// (get) Token: 0x0602419E RID: 147870 RVA: 0x00994DB8 File Offset: 0x00992FB8
		// (set) Token: 0x0602419F RID: 147871 RVA: 0x00994DC8 File Offset: 0x00992FC8
		public unsafe bool 停止草模拟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A01 RID: 18945
		// (get) Token: 0x060241A0 RID: 147872 RVA: 0x00994DD9 File Offset: 0x00992FD9
		// (set) Token: 0x060241A1 RID: 147873 RVA: 0x00994DED File Offset: 0x00992FED
		[Nullable(2)]
		public unsafe PDA_InteractionGlobalConfigParameters_C 交互参数
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_InteractionGlobalConfigParameters_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_InteractionGlobalConfig_C.__PropertyOffset_17);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_InteractionGlobalConfig_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004A02 RID: 18946
		// (get) Token: 0x060241A2 RID: 147874 RVA: 0x00994E02 File Offset: 0x00993002
		// (set) Token: 0x060241A3 RID: 147875 RVA: 0x00994E12 File Offset: 0x00993012
		public unsafe bool 强制启用水模拟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A03 RID: 18947
		// (get) Token: 0x060241A4 RID: 147876 RVA: 0x00994E23 File Offset: 0x00993023
		// (set) Token: 0x060241A5 RID: 147877 RVA: 0x00994E33 File Offset: 0x00993033
		public unsafe bool 强制启用草模拟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfig_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x060241A6 RID: 147878 RVA: 0x00994E44 File Offset: 0x00993044
		protected PDA_InteractionGlobalConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401273D RID: 75581
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionGlobalConfig.PDA_InteractionGlobalConfig_C";

		// Token: 0x0401273E RID: 75582
		private static IntPtr _ClassPtr;

		// Token: 0x0401273F RID: 75583
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012740 RID: 75584
		internal static int __PropertyOffset_0;

		// Token: 0x04012741 RID: 75585
		internal static int __PropertyOffset_1;

		// Token: 0x04012742 RID: 75586
		[Nullable(2)]
		private FSoftObjectPath _植被恢复材质;

		// Token: 0x04012743 RID: 75587
		internal static int __PropertyOffset_2;

		// Token: 0x04012744 RID: 75588
		[Nullable(2)]
		private FSoftObjectPath _植被交互计算材质;

		// Token: 0x04012745 RID: 75589
		internal static int __PropertyOffset_3;

		// Token: 0x04012746 RID: 75590
		[Nullable(2)]
		private FSoftObjectPath _植被结果材质;

		// Token: 0x04012747 RID: 75591
		internal static int __PropertyOffset_4;

		// Token: 0x04012748 RID: 75592
		[Nullable(2)]
		private FSoftObjectPath _水面波纹触发材质;

		// Token: 0x04012749 RID: 75593
		internal static int __PropertyOffset_5;

		// Token: 0x0401274A RID: 75594
		[Nullable(2)]
		private FSoftObjectPath _水面波纹计算材质;

		// Token: 0x0401274B RID: 75595
		internal static int __PropertyOffset_6;

		// Token: 0x0401274C RID: 75596
		[Nullable(2)]
		private FSoftObjectPath _高斯模糊材质;

		// Token: 0x0401274D RID: 75597
		internal static int __PropertyOffset_7;

		// Token: 0x0401274E RID: 75598
		[Nullable(2)]
		private FSoftObjectPath _水面波纹结果材质;

		// Token: 0x0401274F RID: 75599
		internal static int __PropertyOffset_8;

		// Token: 0x04012750 RID: 75600
		[Nullable(2)]
		private FSoftObjectPath _植被交互纹理;

		// Token: 0x04012751 RID: 75601
		internal static int __PropertyOffset_9;

		// Token: 0x04012752 RID: 75602
		[Nullable(2)]
		private FSoftObjectPath _植被交互临时纹理;

		// Token: 0x04012753 RID: 75603
		internal static int __PropertyOffset_10;

		// Token: 0x04012754 RID: 75604
		[Nullable(2)]
		private FSoftObjectPath _水面交互纹理;

		// Token: 0x04012755 RID: 75605
		internal static int __PropertyOffset_11;

		// Token: 0x04012756 RID: 75606
		[Nullable(2)]
		private FSoftObjectPath _水面交互临时纹理1;

		// Token: 0x04012757 RID: 75607
		internal static int __PropertyOffset_12;

		// Token: 0x04012758 RID: 75608
		[Nullable(2)]
		private FSoftObjectPath _水面交互临时纹理2;

		// Token: 0x04012759 RID: 75609
		internal static int __PropertyOffset_13;

		// Token: 0x0401275A RID: 75610
		[Nullable(2)]
		private FSoftObjectPath _水面交互临时纹理3;

		// Token: 0x0401275B RID: 75611
		internal static int __PropertyOffset_14;

		// Token: 0x0401275C RID: 75612
		internal static int __PropertyOffset_15;

		// Token: 0x0401275D RID: 75613
		internal static int __PropertyOffset_16;

		// Token: 0x0401275E RID: 75614
		internal static int __PropertyOffset_17;

		// Token: 0x0401275F RID: 75615
		internal static int __PropertyOffset_18;

		// Token: 0x04012760 RID: 75616
		internal static int __PropertyOffset_19;
	}
}
