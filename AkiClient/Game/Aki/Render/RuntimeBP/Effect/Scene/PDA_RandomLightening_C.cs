using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D36 RID: 15670
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/PDA_RandomLightening.PDA_RandomLightening_C")]
	[UnrealStructLayout(560, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 560)]
	public class PDA_RandomLightening_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025FF4 RID: 155636 RVA: 0x009CAB4C File Offset: 0x009C8D4C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_RandomLightening_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Scene/PDA_RandomLightening.PDA_RandomLightening_C");
			}
			return PDA_RandomLightening_C._ClassPtr;
		}

		// Token: 0x06025FF5 RID: 155637 RVA: 0x009CAB70 File Offset: 0x009C8D70
		public PDA_RandomLightening_C() : this(BuiltinUtils.AllocNativeUObject(PDA_RandomLightening_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025FF6 RID: 155638 RVA: 0x009CAB98 File Offset: 0x009C8D98
		[NullableContext(1)]
		public PDA_RandomLightening_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_RandomLightening_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170054F2 RID: 21746
		// (get) Token: 0x06025FF7 RID: 155639 RVA: 0x009CABCB File Offset: 0x009C8DCB
		// (set) Token: 0x06025FF8 RID: 155640 RVA: 0x009CABDB File Offset: 0x009C8DDB
		public unsafe float 发生频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170054F3 RID: 21747
		// (get) Token: 0x06025FF9 RID: 155641 RVA: 0x009CABEC File Offset: 0x009C8DEC
		// (set) Token: 0x06025FFA RID: 155642 RVA: 0x009CABFC File Offset: 0x009C8DFC
		public unsafe float 发生频率随机
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170054F4 RID: 21748
		// (get) Token: 0x06025FFB RID: 155643 RVA: 0x009CAC10 File Offset: 0x009C8E10
		// (set) Token: 0x06025FFC RID: 155644 RVA: 0x009CAC49 File Offset: 0x009C8E49
		[Nullable(1)]
		public FKuroCurveFloat 灯光强度曲线
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._灯光强度曲线) == null)
				{
					result = (this._灯光强度曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054F5 RID: 21749
		// (get) Token: 0x06025FFD RID: 155645 RVA: 0x009CAC6C File Offset: 0x009C8E6C
		// (set) Token: 0x06025FFE RID: 155646 RVA: 0x009CACA5 File Offset: 0x009C8EA5
		[Nullable(1)]
		public FKuroCurveFloat 灯光距离强度曲线
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._灯光距离强度曲线) == null)
				{
					result = (this._灯光距离强度曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054F6 RID: 21750
		// (get) Token: 0x06025FFF RID: 155647 RVA: 0x009CACC8 File Offset: 0x009C8EC8
		// (set) Token: 0x06026000 RID: 155648 RVA: 0x009CAD01 File Offset: 0x009C8F01
		[Nullable(1)]
		public FKuroCurveFloat 后处理强度曲线
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._后处理强度曲线) == null)
				{
					result = (this._后处理强度曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170054F7 RID: 21751
		// (get) Token: 0x06026001 RID: 155649 RVA: 0x009CAD22 File Offset: 0x009C8F22
		// (set) Token: 0x06026002 RID: 155650 RVA: 0x009CAD36 File Offset: 0x009C8F36
		public unsafe UNiagaraSystem NiagaraSystem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RandomLightening_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RandomLightening_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170054F8 RID: 21752
		// (get) Token: 0x06026003 RID: 155651 RVA: 0x009CAD4B File Offset: 0x009C8F4B
		// (set) Token: 0x06026004 RID: 155652 RVA: 0x009CAD5F File Offset: 0x009C8F5F
		public unsafe UAkAudioEvent 音频事件
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RandomLightening_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RandomLightening_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170054F9 RID: 21753
		// (get) Token: 0x06026005 RID: 155653 RVA: 0x009CAD74 File Offset: 0x009C8F74
		// (set) Token: 0x06026006 RID: 155654 RVA: 0x009CAD88 File Offset: 0x009C8F88
		public unsafe FName MPC参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RandomLightening_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170054FA RID: 21754
		// (get) Token: 0x06026007 RID: 155655 RVA: 0x009CAD9D File Offset: 0x009C8F9D
		// (set) Token: 0x06026008 RID: 155656 RVA: 0x009CADB1 File Offset: 0x009C8FB1
		public unsafe UMaterialParameterCollection MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RandomLightening_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RandomLightening_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x06026009 RID: 155657 RVA: 0x009CADC6 File Offset: 0x009C8FC6
		protected PDA_RandomLightening_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013A70 RID: 80496
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Scene/PDA_RandomLightening.PDA_RandomLightening_C";

		// Token: 0x04013A71 RID: 80497
		private static IntPtr _ClassPtr;

		// Token: 0x04013A72 RID: 80498
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013A73 RID: 80499
		internal static int __PropertyOffset_0;

		// Token: 0x04013A74 RID: 80500
		internal static int __PropertyOffset_1;

		// Token: 0x04013A75 RID: 80501
		internal static int __PropertyOffset_2;

		// Token: 0x04013A76 RID: 80502
		private FKuroCurveFloat _灯光强度曲线;

		// Token: 0x04013A77 RID: 80503
		internal static int __PropertyOffset_3;

		// Token: 0x04013A78 RID: 80504
		private FKuroCurveFloat _灯光距离强度曲线;

		// Token: 0x04013A79 RID: 80505
		internal static int __PropertyOffset_4;

		// Token: 0x04013A7A RID: 80506
		private FKuroCurveFloat _后处理强度曲线;

		// Token: 0x04013A7B RID: 80507
		internal static int __PropertyOffset_5;

		// Token: 0x04013A7C RID: 80508
		internal static int __PropertyOffset_6;

		// Token: 0x04013A7D RID: 80509
		internal static int __PropertyOffset_7;

		// Token: 0x04013A7E RID: 80510
		internal static int __PropertyOffset_8;
	}
}
