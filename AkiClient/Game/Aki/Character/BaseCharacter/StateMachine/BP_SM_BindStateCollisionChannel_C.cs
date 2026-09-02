using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B6 RID: 17078
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateCollisionChannel.BP_SM_BindStateCollisionChannel_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 64)]
	public class BP_SM_BindStateCollisionChannel_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D54D RID: 185677 RVA: 0x00ABD3A1 File Offset: 0x00ABB5A1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateCollisionChannel_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateCollisionChannel.BP_SM_BindStateCollisionChannel_C");
			}
			return BP_SM_BindStateCollisionChannel_C._ClassPtr;
		}

		// Token: 0x0602D54E RID: 185678 RVA: 0x00ABD3C8 File Offset: 0x00ABB5C8
		public BP_SM_BindStateCollisionChannel_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateCollisionChannel_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D54F RID: 185679 RVA: 0x00ABD3F0 File Offset: 0x00ABB5F0
		[NullableContext(1)]
		public BP_SM_BindStateCollisionChannel_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateCollisionChannel_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B99 RID: 31641
		// (get) Token: 0x0602D550 RID: 185680 RVA: 0x00ABD424 File Offset: 0x00ABB624
		// (set) Token: 0x0602D551 RID: 185681 RVA: 0x00ABD45D File Offset: 0x00ABB65D
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<ECollisionChannel>> IgnoreChannels
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<ECollisionChannel>> result;
				if ((result = this._IgnoreChannels) == null)
				{
					result = (this._IgnoreChannels = new TArray<TEnumAsByte<ECollisionChannel>>(base.NativePtr + (IntPtr)BP_SM_BindStateCollisionChannel_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.IgnoreChannels.CopyAssign(value);
			}
		}

		// Token: 0x0602D552 RID: 185682 RVA: 0x00ABD46B File Offset: 0x00ABB66B
		protected BP_SM_BindStateCollisionChannel_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196B0 RID: 104112
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateCollisionChannel.BP_SM_BindStateCollisionChannel_C";

		// Token: 0x040196B1 RID: 104113
		private static IntPtr _ClassPtr;

		// Token: 0x040196B2 RID: 104114
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196B3 RID: 104115
		internal static int __PropertyOffset_0;

		// Token: 0x040196B4 RID: 104116
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<ECollisionChannel>> _IgnoreChannels;
	}
}
