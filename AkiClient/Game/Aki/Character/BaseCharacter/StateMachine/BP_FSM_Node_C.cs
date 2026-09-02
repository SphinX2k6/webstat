using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x0200429E RID: 17054
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_Node.BP_FSM_Node_C")]
	[UnrealStructLayout(264, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 264)]
	public class BP_FSM_Node_C : UKuroStateMachineBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D49D RID: 185501 RVA: 0x00ABC076 File Offset: 0x00ABA276
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FSM_Node_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_Node.BP_FSM_Node_C");
			}
			return BP_FSM_Node_C._ClassPtr;
		}

		// Token: 0x0602D49E RID: 185502 RVA: 0x00ABC09C File Offset: 0x00ABA29C
		public BP_FSM_Node_C() : this(BuiltinUtils.AllocNativeUObject(BP_FSM_Node_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D49F RID: 185503 RVA: 0x00ABC0C4 File Offset: 0x00ABA2C4
		public BP_FSM_Node_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FSM_Node_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B71 RID: 31601
		// (get) Token: 0x0602D4A0 RID: 185504 RVA: 0x00ABC0F7 File Offset: 0x00ABA2F7
		// (set) Token: 0x0602D4A1 RID: 185505 RVA: 0x00ABC107 File Offset: 0x00ABA307
		public unsafe int 技能Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FSM_Node_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FSM_Node_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B72 RID: 31602
		// (get) Token: 0x0602D4A2 RID: 185506 RVA: 0x00ABC118 File Offset: 0x00ABA318
		// (set) Token: 0x0602D4A3 RID: 185507 RVA: 0x00ABC128 File Offset: 0x00ABA328
		public unsafe float 持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FSM_Node_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FSM_Node_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007B73 RID: 31603
		// (get) Token: 0x0602D4A4 RID: 185508 RVA: 0x00ABC13C File Offset: 0x00ABA33C
		// (set) Token: 0x0602D4A5 RID: 185509 RVA: 0x00ABC175 File Offset: 0x00ABA375
		public TArray<long> 绑定Buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._绑定Buff) == null)
				{
					result = (this._绑定Buff = new TArray<long>(base.NativePtr + (IntPtr)BP_FSM_Node_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.绑定Buff.CopyAssign(value);
			}
		}

		// Token: 0x17007B74 RID: 31604
		// (get) Token: 0x0602D4A6 RID: 185510 RVA: 0x00ABC184 File Offset: 0x00ABA384
		// (set) Token: 0x0602D4A7 RID: 185511 RVA: 0x00ABC1BD File Offset: 0x00ABA3BD
		public TArray<long> 进入时添加Buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._进入时添加Buff) == null)
				{
					result = (this._进入时添加Buff = new TArray<long>(base.NativePtr + (IntPtr)BP_FSM_Node_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.进入时添加Buff.CopyAssign(value);
			}
		}

		// Token: 0x17007B75 RID: 31605
		// (get) Token: 0x0602D4A8 RID: 185512 RVA: 0x00ABC1CC File Offset: 0x00ABA3CC
		// (set) Token: 0x0602D4A9 RID: 185513 RVA: 0x00ABC205 File Offset: 0x00ABA405
		public TArray<long> 退出时添加Buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._退出时添加Buff) == null)
				{
					result = (this._退出时添加Buff = new TArray<long>(base.NativePtr + (IntPtr)BP_FSM_Node_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.退出时添加Buff.CopyAssign(value);
			}
		}

		// Token: 0x17007B76 RID: 31606
		// (get) Token: 0x0602D4AA RID: 185514 RVA: 0x00ABC214 File Offset: 0x00ABA414
		// (set) Token: 0x0602D4AB RID: 185515 RVA: 0x00ABC24D File Offset: 0x00ABA44D
		public TArray<FGameplayTag> 绑定Tag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._绑定Tag) == null)
				{
					result = (this._绑定Tag = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)BP_FSM_Node_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.绑定Tag.CopyAssign(value);
			}
		}

		// Token: 0x0602D4AC RID: 185516 RVA: 0x00ABC25B File Offset: 0x00ABA45B
		protected BP_FSM_Node_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401963B RID: 103995
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_Node.BP_FSM_Node_C";

		// Token: 0x0401963C RID: 103996
		private static IntPtr _ClassPtr;

		// Token: 0x0401963D RID: 103997
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401963E RID: 103998
		internal static int __PropertyOffset_0;

		// Token: 0x0401963F RID: 103999
		internal static int __PropertyOffset_1;

		// Token: 0x04019640 RID: 104000
		internal static int __PropertyOffset_2;

		// Token: 0x04019641 RID: 104001
		[Nullable(2)]
		private TArray<long> _绑定Buff;

		// Token: 0x04019642 RID: 104002
		internal static int __PropertyOffset_3;

		// Token: 0x04019643 RID: 104003
		[Nullable(2)]
		private TArray<long> _进入时添加Buff;

		// Token: 0x04019644 RID: 104004
		internal static int __PropertyOffset_4;

		// Token: 0x04019645 RID: 104005
		[Nullable(2)]
		private TArray<long> _退出时添加Buff;

		// Token: 0x04019646 RID: 104006
		internal static int __PropertyOffset_5;

		// Token: 0x04019647 RID: 104007
		[Nullable(2)]
		private TArray<FGameplayTag> _绑定Tag;
	}
}
