using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A5 RID: 17061
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionCue.BP_SM_ActionCue_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 76)]
	public class BP_SM_ActionCue_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4D7 RID: 185559 RVA: 0x00ABC6E1 File Offset: 0x00ABA8E1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionCue_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionCue.BP_SM_ActionCue_C");
			}
			return BP_SM_ActionCue_C._ClassPtr;
		}

		// Token: 0x0602D4D8 RID: 185560 RVA: 0x00ABC708 File Offset: 0x00ABA908
		public BP_SM_ActionCue_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionCue_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4D9 RID: 185561 RVA: 0x00ABC730 File Offset: 0x00ABA930
		public BP_SM_ActionCue_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionCue_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B80 RID: 31616
		// (get) Token: 0x0602D4DA RID: 185562 RVA: 0x00ABC764 File Offset: 0x00ABA964
		// (set) Token: 0x0602D4DB RID: 185563 RVA: 0x00ABC79D File Offset: 0x00ABA99D
		public TArray<long> CueIds
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._CueIds) == null)
				{
					result = (this._CueIds = new TArray<long>(base.NativePtr + (IntPtr)BP_SM_ActionCue_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.CueIds.CopyAssign(value);
			}
		}

		// Token: 0x17007B81 RID: 31617
		// (get) Token: 0x0602D4DC RID: 185564 RVA: 0x00ABC7AB File Offset: 0x00ABA9AB
		// (set) Token: 0x0602D4DD RID: 185565 RVA: 0x00ABC7BF File Offset: 0x00ABA9BF
		public unsafe FGameplayTag ConfigReplaceTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionCue_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionCue_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602D4DE RID: 185566 RVA: 0x00ABC7D4 File Offset: 0x00ABA9D4
		protected BP_SM_ActionCue_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019663 RID: 104035
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionCue.BP_SM_ActionCue_C";

		// Token: 0x04019664 RID: 104036
		private static IntPtr _ClassPtr;

		// Token: 0x04019665 RID: 104037
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019666 RID: 104038
		internal static int __PropertyOffset_0;

		// Token: 0x04019667 RID: 104039
		[Nullable(2)]
		private TArray<long> _CueIds;

		// Token: 0x04019668 RID: 104040
		internal static int __PropertyOffset_1;
	}
}
