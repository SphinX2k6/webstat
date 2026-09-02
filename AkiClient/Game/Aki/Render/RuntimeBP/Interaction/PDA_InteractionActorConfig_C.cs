using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C87 RID: 15495
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionActorConfig.PDA_InteractionActorConfig_C")]
	[UnrealStructLayout(264, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 264)]
	public class PDA_InteractionActorConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024147 RID: 147783 RVA: 0x00994408 File Offset: 0x00992608
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_InteractionActorConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionActorConfig.PDA_InteractionActorConfig_C");
			}
			return PDA_InteractionActorConfig_C._ClassPtr;
		}

		// Token: 0x06024148 RID: 147784 RVA: 0x0099442C File Offset: 0x0099262C
		public PDA_InteractionActorConfig_C() : this(BuiltinUtils.AllocNativeUObject(PDA_InteractionActorConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024149 RID: 147785 RVA: 0x00994454 File Offset: 0x00992654
		public PDA_InteractionActorConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_InteractionActorConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170049DA RID: 18906
		// (get) Token: 0x0602414A RID: 147786 RVA: 0x00994487 File Offset: 0x00992687
		// (set) Token: 0x0602414B RID: 147787 RVA: 0x00994497 File Offset: 0x00992697
		public unsafe bool 启用水面交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170049DB RID: 18907
		// (get) Token: 0x0602414C RID: 147788 RVA: 0x009944A8 File Offset: 0x009926A8
		// (set) Token: 0x0602414D RID: 147789 RVA: 0x009944B8 File Offset: 0x009926B8
		public unsafe float 水面交互半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170049DC RID: 18908
		// (get) Token: 0x0602414E RID: 147790 RVA: 0x009944C9 File Offset: 0x009926C9
		// (set) Token: 0x0602414F RID: 147791 RVA: 0x009944D9 File Offset: 0x009926D9
		public unsafe float 水面交互过渡值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170049DD RID: 18909
		// (get) Token: 0x06024150 RID: 147792 RVA: 0x009944EA File Offset: 0x009926EA
		// (set) Token: 0x06024151 RID: 147793 RVA: 0x009944FA File Offset: 0x009926FA
		public unsafe float 水面交互时间间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170049DE RID: 18910
		// (get) Token: 0x06024152 RID: 147794 RVA: 0x0099450B File Offset: 0x0099270B
		// (set) Token: 0x06024153 RID: 147795 RVA: 0x0099451B File Offset: 0x0099271B
		public unsafe float 时间间隔随机
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170049DF RID: 18911
		// (get) Token: 0x06024154 RID: 147796 RVA: 0x0099452C File Offset: 0x0099272C
		// (set) Token: 0x06024155 RID: 147797 RVA: 0x0099453C File Offset: 0x0099273C
		public unsafe float 水面交互站立强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170049E0 RID: 18912
		// (get) Token: 0x06024156 RID: 147798 RVA: 0x0099454D File Offset: 0x0099274D
		// (set) Token: 0x06024157 RID: 147799 RVA: 0x0099455D File Offset: 0x0099275D
		public unsafe float 水面交互移动强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170049E1 RID: 18913
		// (get) Token: 0x06024158 RID: 147800 RVA: 0x0099456E File Offset: 0x0099276E
		// (set) Token: 0x06024159 RID: 147801 RVA: 0x0099457E File Offset: 0x0099277E
		public unsafe float 水面交互最大移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170049E2 RID: 18914
		// (get) Token: 0x0602415A RID: 147802 RVA: 0x00994590 File Offset: 0x00992790
		// (set) Token: 0x0602415B RID: 147803 RVA: 0x009945C9 File Offset: 0x009927C9
		public FKuroCurveFloat 交互速度_强度曲线
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._交互速度_强度曲线) == null)
				{
					result = (this._交互速度_强度曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170049E3 RID: 18915
		// (get) Token: 0x0602415C RID: 147804 RVA: 0x009945EA File Offset: 0x009927EA
		// (set) Token: 0x0602415D RID: 147805 RVA: 0x009945FA File Offset: 0x009927FA
		public unsafe float 交互强度抖动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170049E4 RID: 18916
		// (get) Token: 0x0602415E RID: 147806 RVA: 0x0099460B File Offset: 0x0099280B
		// (set) Token: 0x0602415F RID: 147807 RVA: 0x0099461B File Offset: 0x0099281B
		public unsafe float 交互位置抖动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_InteractionActorConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06024160 RID: 147808 RVA: 0x0099462C File Offset: 0x0099282C
		protected PDA_InteractionActorConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012720 RID: 75552
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionActorConfig.PDA_InteractionActorConfig_C";

		// Token: 0x04012721 RID: 75553
		private static IntPtr _ClassPtr;

		// Token: 0x04012722 RID: 75554
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012723 RID: 75555
		internal static int __PropertyOffset_0;

		// Token: 0x04012724 RID: 75556
		internal static int __PropertyOffset_1;

		// Token: 0x04012725 RID: 75557
		internal static int __PropertyOffset_2;

		// Token: 0x04012726 RID: 75558
		internal static int __PropertyOffset_3;

		// Token: 0x04012727 RID: 75559
		internal static int __PropertyOffset_4;

		// Token: 0x04012728 RID: 75560
		internal static int __PropertyOffset_5;

		// Token: 0x04012729 RID: 75561
		internal static int __PropertyOffset_6;

		// Token: 0x0401272A RID: 75562
		internal static int __PropertyOffset_7;

		// Token: 0x0401272B RID: 75563
		internal static int __PropertyOffset_8;

		// Token: 0x0401272C RID: 75564
		[Nullable(2)]
		private FKuroCurveFloat _交互速度_强度曲线;

		// Token: 0x0401272D RID: 75565
		internal static int __PropertyOffset_9;

		// Token: 0x0401272E RID: 75566
		internal static int __PropertyOffset_10;
	}
}
