using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E1C RID: 15900
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/SQta.SQta")]
	[UnrealStructLayout(304, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 300)]
	public class SQta : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060272BE RID: 160446 RVA: 0x009EB730 File Offset: 0x009E9930
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQta._ScriptStructPtr != 0) ? SQta._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/SQta.SQta", ref SQta._ScriptStructPtr);
		}

		// Token: 0x17005B71 RID: 23409
		// (get) Token: 0x060272BF RID: 160447 RVA: 0x009EB754 File Offset: 0x009E9954
		// (set) Token: 0x060272C0 RID: 160448 RVA: 0x009EB768 File Offset: 0x009E9968
		public unsafe string Desc
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SQta.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SQta.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005B72 RID: 23410
		// (get) Token: 0x060272C1 RID: 160449 RVA: 0x009EB77D File Offset: 0x009E997D
		// (set) Token: 0x060272C2 RID: 160450 RVA: 0x009EB78D File Offset: 0x009E998D
		public unsafe int Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQta.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQta.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005B73 RID: 23411
		// (get) Token: 0x060272C3 RID: 160451 RVA: 0x009EB79E File Offset: 0x009E999E
		// (set) Token: 0x060272C4 RID: 160452 RVA: 0x009EB7AE File Offset: 0x009E99AE
		public unsafe bool AutonomousOnly
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQta.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQta.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B74 RID: 23412
		// (get) Token: 0x060272C5 RID: 160453 RVA: 0x009EB7C0 File Offset: 0x009E99C0
		// (set) Token: 0x060272C6 RID: 160454 RVA: 0x009EB803 File Offset: 0x009E9A03
		public SQtaCondition ActiveCondition
		{
			get
			{
				base.FastCheckIsValid();
				SQtaCondition result;
				if ((result = this._ActiveCondition) == null)
				{
					result = (this._ActiveCondition = new SQtaCondition(base.NativePtr + (IntPtr)SQta.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaCondition.StaticStruct(), base.NativePtr + (IntPtr)SQta.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B75 RID: 23413
		// (get) Token: 0x060272C7 RID: 160455 RVA: 0x009EB824 File Offset: 0x009E9A24
		// (set) Token: 0x060272C8 RID: 160456 RVA: 0x009EB867 File Offset: 0x009E9A67
		public SQtaCondition DeactiveCondition
		{
			get
			{
				base.FastCheckIsValid();
				SQtaCondition result;
				if ((result = this._DeactiveCondition) == null)
				{
					result = (this._DeactiveCondition = new SQtaCondition(base.NativePtr + (IntPtr)SQta.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaCondition.StaticStruct(), base.NativePtr + (IntPtr)SQta.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B76 RID: 23414
		// (get) Token: 0x060272C9 RID: 160457 RVA: 0x009EB888 File Offset: 0x009E9A88
		// (set) Token: 0x060272CA RID: 160458 RVA: 0x009EB8CB File Offset: 0x009E9ACB
		public SQtaBase BaseConfig
		{
			get
			{
				base.FastCheckIsValid();
				SQtaBase result;
				if ((result = this._BaseConfig) == null)
				{
					result = (this._BaseConfig = new SQtaBase(base.NativePtr + (IntPtr)SQta.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaBase.StaticStruct(), base.NativePtr + (IntPtr)SQta.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B77 RID: 23415
		// (get) Token: 0x060272CB RID: 160459 RVA: 0x009EB8EC File Offset: 0x009E9AEC
		// (set) Token: 0x060272CC RID: 160460 RVA: 0x009EB92F File Offset: 0x009E9B2F
		public TArray<SQtaPrompt> Prompt
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SQtaPrompt> result;
				if ((result = this._Prompt) == null)
				{
					result = (this._Prompt = new TArray<SQtaPrompt>(base.NativePtr + (IntPtr)SQta.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Prompt.CopyAssign(value);
			}
		}

		// Token: 0x17005B78 RID: 23416
		// (get) Token: 0x060272CD RID: 160461 RVA: 0x009EB940 File Offset: 0x009E9B40
		// (set) Token: 0x060272CE RID: 160462 RVA: 0x009EB983 File Offset: 0x009E9B83
		public TArray<SQtaResultAction> ResultAction
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SQtaResultAction> result;
				if ((result = this._ResultAction) == null)
				{
					result = (this._ResultAction = new TArray<SQtaResultAction>(base.NativePtr + (IntPtr)SQta.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ResultAction.CopyAssign(value);
			}
		}

		// Token: 0x17005B79 RID: 23417
		// (get) Token: 0x060272CF RID: 160463 RVA: 0x009EB991 File Offset: 0x009E9B91
		// (set) Token: 0x060272D0 RID: 160464 RVA: 0x009EB9A1 File Offset: 0x009E9BA1
		public unsafe bool EndActiveSkill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQta.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQta.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B7A RID: 23418
		// (get) Token: 0x060272D1 RID: 160465 RVA: 0x009EB9B2 File Offset: 0x009E9BB2
		// (set) Token: 0x060272D2 RID: 160466 RVA: 0x009EB9C2 File Offset: 0x009E9BC2
		public unsafe bool EndSkillWhenDeactive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQta.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQta.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B7B RID: 23419
		// (get) Token: 0x060272D3 RID: 160467 RVA: 0x009EB9D3 File Offset: 0x009E9BD3
		// (set) Token: 0x060272D4 RID: 160468 RVA: 0x009EB9E3 File Offset: 0x009E9BE3
		public unsafe bool HandleFailWhenInvalidStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQta.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQta.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B7C RID: 23420
		// (get) Token: 0x060272D5 RID: 160469 RVA: 0x009EB9F4 File Offset: 0x009E9BF4
		// (set) Token: 0x060272D6 RID: 160470 RVA: 0x009EBA04 File Offset: 0x009E9C04
		public unsafe bool StopWhenFightInputBlocked
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQta.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQta.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x060272D7 RID: 160471 RVA: 0x009EBA15 File Offset: 0x009E9C15
		public SQta()
		{
		}

		// Token: 0x060272D8 RID: 160472 RVA: 0x009EBA20 File Offset: 0x009E9C20
		public SQta(string Desc, int Priority, bool AutonomousOnly, SQtaCondition ActiveCondition, SQtaCondition DeactiveCondition, SQtaBase BaseConfig, TArray<SQtaPrompt> Prompt, TArray<SQtaResultAction> ResultAction, bool EndActiveSkill, bool EndSkillWhenDeactive, bool HandleFailWhenInvalidStop, bool StopWhenFightInputBlocked)
		{
			this.Desc = Desc;
			this.Priority = Priority;
			this.AutonomousOnly = AutonomousOnly;
			this.ActiveCondition = ActiveCondition;
			this.DeactiveCondition = DeactiveCondition;
			this.BaseConfig = BaseConfig;
			this.Prompt = Prompt;
			this.ResultAction = ResultAction;
			this.EndActiveSkill = EndActiveSkill;
			this.EndSkillWhenDeactive = EndSkillWhenDeactive;
			this.HandleFailWhenInvalidStop = HandleFailWhenInvalidStop;
			this.StopWhenFightInputBlocked = StopWhenFightInputBlocked;
		}

		// Token: 0x060272D9 RID: 160473 RVA: 0x009EBA90 File Offset: 0x009E9C90
		protected override IntPtr GetUStructPtr()
		{
			return SQta.StaticStruct();
		}

		// Token: 0x060272DA RID: 160474 RVA: 0x009EBA9C File Offset: 0x009E9C9C
		[NullableContext(2)]
		public SQta(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060272DB RID: 160475 RVA: 0x009EBAA6 File Offset: 0x009E9CA6
		public SQta(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060272DC RID: 160476 RVA: 0x009EBAB1 File Offset: 0x009E9CB1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQta(Pointer, false, true);
		}

		// Token: 0x060272DD RID: 160477 RVA: 0x009EBABB File Offset: 0x009E9CBB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQta(Pointer, MemoryOwner);
		}

		// Token: 0x040147AE RID: 83886
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/SQta.SQta";

		// Token: 0x040147AF RID: 83887
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040147B0 RID: 83888
		internal static int __PropertyOffset_0;

		// Token: 0x040147B1 RID: 83889
		internal static int __PropertyOffset_1;

		// Token: 0x040147B2 RID: 83890
		internal static int __PropertyOffset_2;

		// Token: 0x040147B3 RID: 83891
		internal static int __PropertyOffset_3;

		// Token: 0x040147B4 RID: 83892
		[Nullable(2)]
		private SQtaCondition _ActiveCondition;

		// Token: 0x040147B5 RID: 83893
		internal static int __PropertyOffset_4;

		// Token: 0x040147B6 RID: 83894
		[Nullable(2)]
		private SQtaCondition _DeactiveCondition;

		// Token: 0x040147B7 RID: 83895
		internal static int __PropertyOffset_5;

		// Token: 0x040147B8 RID: 83896
		[Nullable(2)]
		private SQtaBase _BaseConfig;

		// Token: 0x040147B9 RID: 83897
		internal static int __PropertyOffset_6;

		// Token: 0x040147BA RID: 83898
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SQtaPrompt> _Prompt;

		// Token: 0x040147BB RID: 83899
		internal static int __PropertyOffset_7;

		// Token: 0x040147BC RID: 83900
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SQtaResultAction> _ResultAction;

		// Token: 0x040147BD RID: 83901
		internal static int __PropertyOffset_8;

		// Token: 0x040147BE RID: 83902
		internal static int __PropertyOffset_9;

		// Token: 0x040147BF RID: 83903
		internal static int __PropertyOffset_10;

		// Token: 0x040147C0 RID: 83904
		internal static int __PropertyOffset_11;
	}
}
