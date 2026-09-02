using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x02004299 RID: 17049
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionAttribute.BP_FSM_ConditionAttribute_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class BP_FSM_ConditionAttribute_C : UKuroStateMachineConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D47D RID: 185469 RVA: 0x00ABBCAC File Offset: 0x00AB9EAC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FSM_ConditionAttribute_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionAttribute.BP_FSM_ConditionAttribute_C");
			}
			return BP_FSM_ConditionAttribute_C._ClassPtr;
		}

		// Token: 0x0602D47E RID: 185470 RVA: 0x00ABBCD0 File Offset: 0x00AB9ED0
		public BP_FSM_ConditionAttribute_C() : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionAttribute_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D47F RID: 185471 RVA: 0x00ABBCF8 File Offset: 0x00AB9EF8
		[NullableContext(1)]
		public BP_FSM_ConditionAttribute_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionAttribute_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B6B RID: 31595
		// (get) Token: 0x0602D480 RID: 185472 RVA: 0x00ABBD2C File Offset: 0x00AB9F2C
		// (set) Token: 0x0602D481 RID: 185473 RVA: 0x00ABBD65 File Offset: 0x00AB9F65
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EAttributeType>, FFloatRange> Attributes
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EAttributeType>, FFloatRange> result;
				if ((result = this._Attributes) == null)
				{
					result = (this._Attributes = new TMap<TEnumAsByte<EAttributeType>, FFloatRange>(base.NativePtr + (IntPtr)BP_FSM_ConditionAttribute_C.__PropertyOffset_0, this));
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
				this.Attributes.CopyAssign(value);
			}
		}

		// Token: 0x0602D482 RID: 185474 RVA: 0x00ABBD73 File Offset: 0x00AB9F73
		protected BP_FSM_ConditionAttribute_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019624 RID: 103972
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionAttribute.BP_FSM_ConditionAttribute_C";

		// Token: 0x04019625 RID: 103973
		private static IntPtr _ClassPtr;

		// Token: 0x04019626 RID: 103974
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019627 RID: 103975
		internal static int __PropertyOffset_0;

		// Token: 0x04019628 RID: 103976
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EAttributeType>, FFloatRange> _Attributes;
	}
}
