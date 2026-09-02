using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D6 RID: 17110
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTimer.BP_SM_ConditionTimer_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 65)]
	public class BP_SM_ConditionTimer_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D63B RID: 185915 RVA: 0x00ABED68 File Offset: 0x00ABCF68
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionTimer_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTimer.BP_SM_ConditionTimer_C");
			}
			return BP_SM_ConditionTimer_C._ClassPtr;
		}

		// Token: 0x0602D63C RID: 185916 RVA: 0x00ABED8C File Offset: 0x00ABCF8C
		public BP_SM_ConditionTimer_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionTimer_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D63D RID: 185917 RVA: 0x00ABEDB4 File Offset: 0x00ABCFB4
		[NullableContext(1)]
		public BP_SM_ConditionTimer_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionTimer_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BD0 RID: 31696
		// (get) Token: 0x0602D63E RID: 185918 RVA: 0x00ABEDE7 File Offset: 0x00ABCFE7
		// (set) Token: 0x0602D63F RID: 185919 RVA: 0x00ABEDF7 File Offset: 0x00ABCFF7
		public unsafe int MinTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionTimer_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionTimer_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BD1 RID: 31697
		// (get) Token: 0x0602D640 RID: 185920 RVA: 0x00ABEE08 File Offset: 0x00ABD008
		// (set) Token: 0x0602D641 RID: 185921 RVA: 0x00ABEE18 File Offset: 0x00ABD018
		public unsafe int MaxTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionTimer_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionTimer_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007BD2 RID: 31698
		// (get) Token: 0x0602D642 RID: 185922 RVA: 0x00ABEE29 File Offset: 0x00ABD029
		// (set) Token: 0x0602D643 RID: 185923 RVA: 0x00ABEE39 File Offset: 0x00ABD039
		public unsafe bool IsClient
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionTimer_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionTimer_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D644 RID: 185924 RVA: 0x00ABEE4A File Offset: 0x00ABD04A
		protected BP_SM_ConditionTimer_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401974C RID: 104268
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTimer.BP_SM_ConditionTimer_C";

		// Token: 0x0401974D RID: 104269
		private static IntPtr _ClassPtr;

		// Token: 0x0401974E RID: 104270
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401974F RID: 104271
		internal static int __PropertyOffset_0;

		// Token: 0x04019750 RID: 104272
		internal static int __PropertyOffset_1;

		// Token: 0x04019751 RID: 104273
		internal static int __PropertyOffset_2;
	}
}
