using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042CF RID: 17103
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionListenBeHit.BP_SM_ConditionListenBeHit_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 68)]
	public class BP_SM_ConditionListenBeHit_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5FD RID: 185853 RVA: 0x00ABE75C File Offset: 0x00ABC95C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionListenBeHit_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionListenBeHit.BP_SM_ConditionListenBeHit_C");
			}
			return BP_SM_ConditionListenBeHit_C._ClassPtr;
		}

		// Token: 0x0602D5FE RID: 185854 RVA: 0x00ABE780 File Offset: 0x00ABC980
		public BP_SM_ConditionListenBeHit_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionListenBeHit_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5FF RID: 185855 RVA: 0x00ABE7A8 File Offset: 0x00ABC9A8
		[NullableContext(1)]
		public BP_SM_ConditionListenBeHit_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionListenBeHit_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BBF RID: 31679
		// (get) Token: 0x0602D600 RID: 185856 RVA: 0x00ABE7DB File Offset: 0x00ABC9DB
		// (set) Token: 0x0602D601 RID: 185857 RVA: 0x00ABE7EB File Offset: 0x00ABC9EB
		public unsafe bool 无受击动作
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BC0 RID: 31680
		// (get) Token: 0x0602D602 RID: 185858 RVA: 0x00ABE7FC File Offset: 0x00ABC9FC
		// (set) Token: 0x0602D603 RID: 185859 RVA: 0x00ABE80C File Offset: 0x00ABCA0C
		public unsafe bool 轻击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BC1 RID: 31681
		// (get) Token: 0x0602D604 RID: 185860 RVA: 0x00ABE81D File Offset: 0x00ABCA1D
		// (set) Token: 0x0602D605 RID: 185861 RVA: 0x00ABE82D File Offset: 0x00ABCA2D
		public unsafe bool 重击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BC2 RID: 31682
		// (get) Token: 0x0602D606 RID: 185862 RVA: 0x00ABE83E File Offset: 0x00ABCA3E
		// (set) Token: 0x0602D607 RID: 185863 RVA: 0x00ABE84E File Offset: 0x00ABCA4E
		public unsafe bool 击飞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BC3 RID: 31683
		// (get) Token: 0x0602D608 RID: 185864 RVA: 0x00ABE85F File Offset: 0x00ABCA5F
		// (set) Token: 0x0602D609 RID: 185865 RVA: 0x00ABE86F File Offset: 0x00ABCA6F
		public unsafe bool 击倒
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BC4 RID: 31684
		// (get) Token: 0x0602D60A RID: 185866 RVA: 0x00ABE880 File Offset: 0x00ABCA80
		// (set) Token: 0x0602D60B RID: 185867 RVA: 0x00ABE890 File Offset: 0x00ABCA90
		public unsafe bool 被弹反
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BC5 RID: 31685
		// (get) Token: 0x0602D60C RID: 185868 RVA: 0x00ABE8A1 File Offset: 0x00ABCAA1
		// (set) Token: 0x0602D60D RID: 185869 RVA: 0x00ABE8B1 File Offset: 0x00ABCAB1
		public unsafe bool 被破弱
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BC6 RID: 31686
		// (get) Token: 0x0602D60E RID: 185870 RVA: 0x00ABE8C2 File Offset: 0x00ABCAC2
		// (set) Token: 0x0602D60F RID: 185871 RVA: 0x00ABE8D2 File Offset: 0x00ABCAD2
		public unsafe int 策略技Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionListenBeHit_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602D610 RID: 185872 RVA: 0x00ABE8E3 File Offset: 0x00ABCAE3
		protected BP_SM_ConditionListenBeHit_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019726 RID: 104230
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionListenBeHit.BP_SM_ConditionListenBeHit_C";

		// Token: 0x04019727 RID: 104231
		private static IntPtr _ClassPtr;

		// Token: 0x04019728 RID: 104232
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019729 RID: 104233
		internal static int __PropertyOffset_0;

		// Token: 0x0401972A RID: 104234
		internal static int __PropertyOffset_1;

		// Token: 0x0401972B RID: 104235
		internal static int __PropertyOffset_2;

		// Token: 0x0401972C RID: 104236
		internal static int __PropertyOffset_3;

		// Token: 0x0401972D RID: 104237
		internal static int __PropertyOffset_4;

		// Token: 0x0401972E RID: 104238
		internal static int __PropertyOffset_5;

		// Token: 0x0401972F RID: 104239
		internal static int __PropertyOffset_6;

		// Token: 0x04019730 RID: 104240
		internal static int __PropertyOffset_7;
	}
}
