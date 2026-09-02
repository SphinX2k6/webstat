using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B7 RID: 17079
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateCue.BP_SM_BindStateCue_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 80)]
	public class BP_SM_BindStateCue_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D553 RID: 185683 RVA: 0x00ABD474 File Offset: 0x00ABB674
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateCue_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateCue.BP_SM_BindStateCue_C");
			}
			return BP_SM_BindStateCue_C._ClassPtr;
		}

		// Token: 0x0602D554 RID: 185684 RVA: 0x00ABD498 File Offset: 0x00ABB698
		public BP_SM_BindStateCue_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateCue_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D555 RID: 185685 RVA: 0x00ABD4C0 File Offset: 0x00ABB6C0
		public BP_SM_BindStateCue_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateCue_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B9A RID: 31642
		// (get) Token: 0x0602D556 RID: 185686 RVA: 0x00ABD4F4 File Offset: 0x00ABB6F4
		// (set) Token: 0x0602D557 RID: 185687 RVA: 0x00ABD52D File Offset: 0x00ABB72D
		public TArray<long> CueIds
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._CueIds) == null)
				{
					result = (this._CueIds = new TArray<long>(base.NativePtr + (IntPtr)BP_SM_BindStateCue_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.CueIds.CopyAssign(value);
			}
		}

		// Token: 0x17007B9B RID: 31643
		// (get) Token: 0x0602D558 RID: 185688 RVA: 0x00ABD53B File Offset: 0x00ABB73B
		// (set) Token: 0x0602D559 RID: 185689 RVA: 0x00ABD54B File Offset: 0x00ABB74B
		public unsafe bool 加载期间隐藏模型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateCue_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateCue_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B9C RID: 31644
		// (get) Token: 0x0602D55A RID: 185690 RVA: 0x00ABD55C File Offset: 0x00ABB75C
		// (set) Token: 0x0602D55B RID: 185691 RVA: 0x00ABD570 File Offset: 0x00ABB770
		public unsafe FGameplayTag ConfigReplaceTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateCue_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateCue_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D55C RID: 185692 RVA: 0x00ABD585 File Offset: 0x00ABB785
		protected BP_SM_BindStateCue_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196B5 RID: 104117
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateCue.BP_SM_BindStateCue_C";

		// Token: 0x040196B6 RID: 104118
		private static IntPtr _ClassPtr;

		// Token: 0x040196B7 RID: 104119
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196B8 RID: 104120
		internal static int __PropertyOffset_0;

		// Token: 0x040196B9 RID: 104121
		[Nullable(2)]
		private TArray<long> _CueIds;

		// Token: 0x040196BA RID: 104122
		internal static int __PropertyOffset_1;

		// Token: 0x040196BB RID: 104123
		internal static int __PropertyOffset_2;
	}
}
