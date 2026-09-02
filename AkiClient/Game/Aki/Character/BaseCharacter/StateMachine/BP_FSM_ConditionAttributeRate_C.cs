using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Monster.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x02004298 RID: 17048
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionAttributeRate.BP_FSM_ConditionAttributeRate_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class BP_FSM_ConditionAttributeRate_C : UKuroStateMachineConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D477 RID: 185463 RVA: 0x00ABBBDA File Offset: 0x00AB9DDA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FSM_ConditionAttributeRate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionAttributeRate.BP_FSM_ConditionAttributeRate_C");
			}
			return BP_FSM_ConditionAttributeRate_C._ClassPtr;
		}

		// Token: 0x0602D478 RID: 185464 RVA: 0x00ABBC00 File Offset: 0x00AB9E00
		public BP_FSM_ConditionAttributeRate_C() : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionAttributeRate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D479 RID: 185465 RVA: 0x00ABBC28 File Offset: 0x00AB9E28
		public BP_FSM_ConditionAttributeRate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionAttributeRate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B6A RID: 31594
		// (get) Token: 0x0602D47A RID: 185466 RVA: 0x00ABBC5C File Offset: 0x00AB9E5C
		// (set) Token: 0x0602D47B RID: 185467 RVA: 0x00ABBC95 File Offset: 0x00AB9E95
		public TArray<SAiAttributeRate> AttributeRates
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SAiAttributeRate> result;
				if ((result = this._AttributeRates) == null)
				{
					result = (this._AttributeRates = new TArray<SAiAttributeRate>(base.NativePtr + (IntPtr)BP_FSM_ConditionAttributeRate_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.AttributeRates.CopyAssign(value);
			}
		}

		// Token: 0x0602D47C RID: 185468 RVA: 0x00ABBCA3 File Offset: 0x00AB9EA3
		protected BP_FSM_ConditionAttributeRate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401961F RID: 103967
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionAttributeRate.BP_FSM_ConditionAttributeRate_C";

		// Token: 0x04019620 RID: 103968
		private static IntPtr _ClassPtr;

		// Token: 0x04019621 RID: 103969
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019622 RID: 103970
		internal static int __PropertyOffset_0;

		// Token: 0x04019623 RID: 103971
		[Nullable(2)]
		private TArray<SAiAttributeRate> _AttributeRates;
	}
}
