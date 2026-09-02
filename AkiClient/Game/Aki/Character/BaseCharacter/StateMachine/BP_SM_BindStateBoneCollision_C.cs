using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B3 RID: 17075
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBoneCollision.BP_SM_BindStateBoneCollision_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 72)]
	public class BP_SM_BindStateBoneCollision_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D529 RID: 185641 RVA: 0x00ABD065 File Offset: 0x00ABB265
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateBoneCollision_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBoneCollision.BP_SM_BindStateBoneCollision_C");
			}
			return BP_SM_BindStateBoneCollision_C._ClassPtr;
		}

		// Token: 0x0602D52A RID: 185642 RVA: 0x00ABD08C File Offset: 0x00ABB28C
		public BP_SM_BindStateBoneCollision_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateBoneCollision_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D52B RID: 185643 RVA: 0x00ABD0B4 File Offset: 0x00ABB2B4
		public BP_SM_BindStateBoneCollision_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateBoneCollision_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B8D RID: 31629
		// (get) Token: 0x0602D52C RID: 185644 RVA: 0x00ABD0E7 File Offset: 0x00ABB2E7
		// (set) Token: 0x0602D52D RID: 185645 RVA: 0x00ABD0FB File Offset: 0x00ABB2FB
		public unsafe string 骨骼名
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B8E RID: 31630
		// (get) Token: 0x0602D52E RID: 185646 RVA: 0x00ABD110 File Offset: 0x00ABB310
		// (set) Token: 0x0602D52F RID: 185647 RVA: 0x00ABD120 File Offset: 0x00ABB320
		public unsafe bool 阻挡角色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B8F RID: 31631
		// (get) Token: 0x0602D530 RID: 185648 RVA: 0x00ABD131 File Offset: 0x00ABB331
		// (set) Token: 0x0602D531 RID: 185649 RVA: 0x00ABD141 File Offset: 0x00ABB341
		public unsafe bool 阻挡子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B90 RID: 31632
		// (get) Token: 0x0602D532 RID: 185650 RVA: 0x00ABD152 File Offset: 0x00ABB352
		// (set) Token: 0x0602D533 RID: 185651 RVA: 0x00ABD162 File Offset: 0x00ABB362
		public unsafe bool 阻挡镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B91 RID: 31633
		// (get) Token: 0x0602D534 RID: 185652 RVA: 0x00ABD173 File Offset: 0x00ABB373
		// (set) Token: 0x0602D535 RID: 185653 RVA: 0x00ABD183 File Offset: 0x00ABB383
		public unsafe bool 退出节点时阻挡角色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B92 RID: 31634
		// (get) Token: 0x0602D536 RID: 185654 RVA: 0x00ABD194 File Offset: 0x00ABB394
		// (set) Token: 0x0602D537 RID: 185655 RVA: 0x00ABD1A4 File Offset: 0x00ABB3A4
		public unsafe bool 退出节点时阻挡子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B93 RID: 31635
		// (get) Token: 0x0602D538 RID: 185656 RVA: 0x00ABD1B5 File Offset: 0x00ABB3B5
		// (set) Token: 0x0602D539 RID: 185657 RVA: 0x00ABD1C5 File Offset: 0x00ABB3C5
		public unsafe bool 退出节点时阻挡镜头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B94 RID: 31636
		// (get) Token: 0x0602D53A RID: 185658 RVA: 0x00ABD1D6 File Offset: 0x00ABB3D6
		// (set) Token: 0x0602D53B RID: 185659 RVA: 0x00ABD1E6 File Offset: 0x00ABB3E6
		public unsafe bool 激活部位半透
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B95 RID: 31637
		// (get) Token: 0x0602D53C RID: 185660 RVA: 0x00ABD1F7 File Offset: 0x00ABB3F7
		// (set) Token: 0x0602D53D RID: 185661 RVA: 0x00ABD207 File Offset: 0x00ABB407
		public unsafe bool 退出节点时激活部位半透
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBoneCollision_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D53E RID: 185662 RVA: 0x00ABD218 File Offset: 0x00ABB418
		protected BP_SM_BindStateBoneCollision_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401969B RID: 104091
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBoneCollision.BP_SM_BindStateBoneCollision_C";

		// Token: 0x0401969C RID: 104092
		private static IntPtr _ClassPtr;

		// Token: 0x0401969D RID: 104093
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401969E RID: 104094
		internal static int __PropertyOffset_0;

		// Token: 0x0401969F RID: 104095
		internal static int __PropertyOffset_1;

		// Token: 0x040196A0 RID: 104096
		internal static int __PropertyOffset_2;

		// Token: 0x040196A1 RID: 104097
		internal static int __PropertyOffset_3;

		// Token: 0x040196A2 RID: 104098
		internal static int __PropertyOffset_4;

		// Token: 0x040196A3 RID: 104099
		internal static int __PropertyOffset_5;

		// Token: 0x040196A4 RID: 104100
		internal static int __PropertyOffset_6;

		// Token: 0x040196A5 RID: 104101
		internal static int __PropertyOffset_7;

		// Token: 0x040196A6 RID: 104102
		internal static int __PropertyOffset_8;
	}
}
