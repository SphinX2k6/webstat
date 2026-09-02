using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C88 RID: 15496
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionGlobalConfigParameters.PDA_InteractionGlobalConfigParameters_C")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 124)]
	public class PDA_InteractionGlobalConfigParameters_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024161 RID: 147809 RVA: 0x00994635 File Offset: 0x00992835
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_InteractionGlobalConfigParameters_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionGlobalConfigParameters.PDA_InteractionGlobalConfigParameters_C");
			}
			return PDA_InteractionGlobalConfigParameters_C._ClassPtr;
		}

		// Token: 0x06024162 RID: 147810 RVA: 0x0099465C File Offset: 0x0099285C
		public PDA_InteractionGlobalConfigParameters_C() : this(BuiltinUtils.AllocNativeUObject(PDA_InteractionGlobalConfigParameters_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024163 RID: 147811 RVA: 0x00994684 File Offset: 0x00992884
		[NullableContext(1)]
		public PDA_InteractionGlobalConfigParameters_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_InteractionGlobalConfigParameters_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170049E5 RID: 18917
		// (get) Token: 0x06024164 RID: 147812 RVA: 0x009946B7 File Offset: 0x009928B7
		// (set) Token: 0x06024165 RID: 147813 RVA: 0x009946C7 File Offset: 0x009928C7
		public unsafe bool 启用植被交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170049E6 RID: 18918
		// (get) Token: 0x06024166 RID: 147814 RVA: 0x009946D8 File Offset: 0x009928D8
		// (set) Token: 0x06024167 RID: 147815 RVA: 0x009946E8 File Offset: 0x009928E8
		public unsafe float 植被交互范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170049E7 RID: 18919
		// (get) Token: 0x06024168 RID: 147816 RVA: 0x009946F9 File Offset: 0x009928F9
		// (set) Token: 0x06024169 RID: 147817 RVA: 0x00994709 File Offset: 0x00992909
		public unsafe bool 启用水面交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170049E8 RID: 18920
		// (get) Token: 0x0602416A RID: 147818 RVA: 0x0099471A File Offset: 0x0099291A
		// (set) Token: 0x0602416B RID: 147819 RVA: 0x0099472A File Offset: 0x0099292A
		public unsafe float 水面交互范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170049E9 RID: 18921
		// (get) Token: 0x0602416C RID: 147820 RVA: 0x0099473B File Offset: 0x0099293B
		// (set) Token: 0x0602416D RID: 147821 RVA: 0x0099474B File Offset: 0x0099294B
		public unsafe float 水面交互更新频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170049EA RID: 18922
		// (get) Token: 0x0602416E RID: 147822 RVA: 0x0099475C File Offset: 0x0099295C
		// (set) Token: 0x0602416F RID: 147823 RVA: 0x0099476C File Offset: 0x0099296C
		public unsafe float 水波纹停止更新时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170049EB RID: 18923
		// (get) Token: 0x06024170 RID: 147824 RVA: 0x0099477D File Offset: 0x0099297D
		// (set) Token: 0x06024171 RID: 147825 RVA: 0x0099478D File Offset: 0x0099298D
		public unsafe float 植被恢复速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170049EC RID: 18924
		// (get) Token: 0x06024172 RID: 147826 RVA: 0x0099479E File Offset: 0x0099299E
		// (set) Token: 0x06024173 RID: 147827 RVA: 0x009947AE File Offset: 0x009929AE
		public unsafe float 水波纹扩散速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170049ED RID: 18925
		// (get) Token: 0x06024174 RID: 147828 RVA: 0x009947BF File Offset: 0x009929BF
		// (set) Token: 0x06024175 RID: 147829 RVA: 0x009947CF File Offset: 0x009929CF
		public unsafe float 水波纹消退速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170049EE RID: 18926
		// (get) Token: 0x06024176 RID: 147830 RVA: 0x009947E0 File Offset: 0x009929E0
		// (set) Token: 0x06024177 RID: 147831 RVA: 0x009947F0 File Offset: 0x009929F0
		public unsafe float 水粘度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170049EF RID: 18927
		// (get) Token: 0x06024178 RID: 147832 RVA: 0x00994801 File Offset: 0x00992A01
		// (set) Token: 0x06024179 RID: 147833 RVA: 0x00994811 File Offset: 0x00992A11
		public unsafe float 水波纹强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionGlobalConfigParameters_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x0602417A RID: 147834 RVA: 0x00994822 File Offset: 0x00992A22
		protected PDA_InteractionGlobalConfigParameters_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401272F RID: 75567
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionGlobalConfigParameters.PDA_InteractionGlobalConfigParameters_C";

		// Token: 0x04012730 RID: 75568
		private static IntPtr _ClassPtr;

		// Token: 0x04012731 RID: 75569
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012732 RID: 75570
		internal static int __PropertyOffset_0;

		// Token: 0x04012733 RID: 75571
		internal static int __PropertyOffset_1;

		// Token: 0x04012734 RID: 75572
		internal static int __PropertyOffset_2;

		// Token: 0x04012735 RID: 75573
		internal static int __PropertyOffset_3;

		// Token: 0x04012736 RID: 75574
		internal static int __PropertyOffset_4;

		// Token: 0x04012737 RID: 75575
		internal static int __PropertyOffset_5;

		// Token: 0x04012738 RID: 75576
		internal static int __PropertyOffset_6;

		// Token: 0x04012739 RID: 75577
		internal static int __PropertyOffset_7;

		// Token: 0x0401273A RID: 75578
		internal static int __PropertyOffset_8;

		// Token: 0x0401273B RID: 75579
		internal static int __PropertyOffset_9;

		// Token: 0x0401273C RID: 75580
		internal static int __PropertyOffset_10;
	}
}
