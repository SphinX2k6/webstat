using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C0 RID: 17088
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateSkillCounter.BP_SM_BindStateSkillCounter_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 89)]
	public class BP_SM_BindStateSkillCounter_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D597 RID: 185751 RVA: 0x00ABDC22 File Offset: 0x00ABBE22
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateSkillCounter_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateSkillCounter.BP_SM_BindStateSkillCounter_C");
			}
			return BP_SM_BindStateSkillCounter_C._ClassPtr;
		}

		// Token: 0x0602D598 RID: 185752 RVA: 0x00ABDC48 File Offset: 0x00ABBE48
		public BP_SM_BindStateSkillCounter_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateSkillCounter_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D599 RID: 185753 RVA: 0x00ABDC70 File Offset: 0x00ABBE70
		public BP_SM_BindStateSkillCounter_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateSkillCounter_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BAA RID: 31658
		// (get) Token: 0x0602D59A RID: 185754 RVA: 0x00ABDCA4 File Offset: 0x00ABBEA4
		// (set) Token: 0x0602D59B RID: 185755 RVA: 0x00ABDCDD File Offset: 0x00ABBEDD
		public TArray<int> SkillIds
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._SkillIds) == null)
				{
					result = (this._SkillIds = new TArray<int>(base.NativePtr + (IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SkillIds.CopyAssign(value);
			}
		}

		// Token: 0x17007BAB RID: 31659
		// (get) Token: 0x0602D59C RID: 185756 RVA: 0x00ABDCEB File Offset: 0x00ABBEEB
		// (set) Token: 0x0602D59D RID: 185757 RVA: 0x00ABDCFF File Offset: 0x00ABBEFF
		public unsafe string 黑板Key
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007BAC RID: 31660
		// (get) Token: 0x0602D59E RID: 185758 RVA: 0x00ABDD14 File Offset: 0x00ABBF14
		// (set) Token: 0x0602D59F RID: 185759 RVA: 0x00ABDD24 File Offset: 0x00ABBF24
		public unsafe int 增加值Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007BAD RID: 31661
		// (get) Token: 0x0602D5A0 RID: 185760 RVA: 0x00ABDD35 File Offset: 0x00ABBF35
		// (set) Token: 0x0602D5A1 RID: 185761 RVA: 0x00ABDD45 File Offset: 0x00ABBF45
		public unsafe int 增加值Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007BAE RID: 31662
		// (get) Token: 0x0602D5A2 RID: 185762 RVA: 0x00ABDD56 File Offset: 0x00ABBF56
		// (set) Token: 0x0602D5A3 RID: 185763 RVA: 0x00ABDD66 File Offset: 0x00ABBF66
		public unsafe bool 重置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateSkillCounter_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D5A4 RID: 185764 RVA: 0x00ABDD77 File Offset: 0x00ABBF77
		protected BP_SM_BindStateSkillCounter_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196E3 RID: 104163
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateSkillCounter.BP_SM_BindStateSkillCounter_C";

		// Token: 0x040196E4 RID: 104164
		private static IntPtr _ClassPtr;

		// Token: 0x040196E5 RID: 104165
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196E6 RID: 104166
		internal static int __PropertyOffset_0;

		// Token: 0x040196E7 RID: 104167
		[Nullable(2)]
		private TArray<int> _SkillIds;

		// Token: 0x040196E8 RID: 104168
		internal static int __PropertyOffset_1;

		// Token: 0x040196E9 RID: 104169
		internal static int __PropertyOffset_2;

		// Token: 0x040196EA RID: 104170
		internal static int __PropertyOffset_3;

		// Token: 0x040196EB RID: 104171
		internal static int __PropertyOffset_4;
	}
}
