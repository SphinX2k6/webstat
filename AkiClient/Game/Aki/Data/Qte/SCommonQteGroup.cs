using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E43 RID: 15939
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQteGroup.SCommonQteGroup")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 116)]
	public class SCommonQteGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027472 RID: 160882 RVA: 0x009EDFBC File Offset: 0x009EC1BC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQteGroup._ScriptStructPtr != 0) ? SCommonQteGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQteGroup.SCommonQteGroup", ref SCommonQteGroup._ScriptStructPtr);
		}

		// Token: 0x17005BF5 RID: 23541
		// (get) Token: 0x06027473 RID: 160883 RVA: 0x009EDFE0 File Offset: 0x009EC1E0
		// (set) Token: 0x06027474 RID: 160884 RVA: 0x009EDFF4 File Offset: 0x009EC1F4
		public unsafe string Desc
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCommonQteGroup.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCommonQteGroup.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005BF6 RID: 23542
		// (get) Token: 0x06027475 RID: 160885 RVA: 0x009EE00C File Offset: 0x009EC20C
		// (set) Token: 0x06027476 RID: 160886 RVA: 0x009EE04F File Offset: 0x009EC24F
		public TSet<int> CommonQteIdSet
		{
			get
			{
				base.FastCheckIsValid();
				TSet<int> result;
				if ((result = this._CommonQteIdSet) == null)
				{
					result = (this._CommonQteIdSet = new TSet<int>(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CommonQteIdSet.CopyAssign(value);
			}
		}

		// Token: 0x17005BF7 RID: 23543
		// (get) Token: 0x06027477 RID: 160887 RVA: 0x009EE05D File Offset: 0x009EC25D
		// (set) Token: 0x06027478 RID: 160888 RVA: 0x009EE06D File Offset: 0x009EC26D
		public unsafe int MainQteId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005BF8 RID: 23544
		// (get) Token: 0x06027479 RID: 160889 RVA: 0x009EE07E File Offset: 0x009EC27E
		// (set) Token: 0x0602747A RID: 160890 RVA: 0x009EE08E File Offset: 0x009EC28E
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005BF9 RID: 23545
		// (get) Token: 0x0602747B RID: 160891 RVA: 0x009EE09F File Offset: 0x009EC29F
		// (set) Token: 0x0602747C RID: 160892 RVA: 0x009EE0AF File Offset: 0x009EC2AF
		public unsafe float LeastDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005BFA RID: 23546
		// (get) Token: 0x0602747D RID: 160893 RVA: 0x009EE0C0 File Offset: 0x009EC2C0
		// (set) Token: 0x0602747E RID: 160894 RVA: 0x009EE0D0 File Offset: 0x009EC2D0
		public unsafe float TimeDilation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005BFB RID: 23547
		// (get) Token: 0x0602747F RID: 160895 RVA: 0x009EE0E1 File Offset: 0x009EC2E1
		// (set) Token: 0x06027480 RID: 160896 RVA: 0x009EE0F1 File Offset: 0x009EC2F1
		public unsafe float ToleranceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQteGroup.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06027481 RID: 160897 RVA: 0x009EE102 File Offset: 0x009EC302
		public SCommonQteGroup()
		{
		}

		// Token: 0x06027482 RID: 160898 RVA: 0x009EE10A File Offset: 0x009EC30A
		public SCommonQteGroup(string Desc, TSet<int> CommonQteIdSet, int MainQteId, float Duration, float LeastDuration, float TimeDilation, float ToleranceTime)
		{
			this.Desc = Desc;
			this.CommonQteIdSet = CommonQteIdSet;
			this.MainQteId = MainQteId;
			this.Duration = Duration;
			this.LeastDuration = LeastDuration;
			this.TimeDilation = TimeDilation;
			this.ToleranceTime = ToleranceTime;
		}

		// Token: 0x06027483 RID: 160899 RVA: 0x009EE147 File Offset: 0x009EC347
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQteGroup.StaticStruct();
		}

		// Token: 0x06027484 RID: 160900 RVA: 0x009EE153 File Offset: 0x009EC353
		[NullableContext(2)]
		public SCommonQteGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027485 RID: 160901 RVA: 0x009EE15D File Offset: 0x009EC35D
		public SCommonQteGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027486 RID: 160902 RVA: 0x009EE168 File Offset: 0x009EC368
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQteGroup(Pointer, false, true);
		}

		// Token: 0x06027487 RID: 160903 RVA: 0x009EE172 File Offset: 0x009EC372
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQteGroup(Pointer, MemoryOwner);
		}

		// Token: 0x04014908 RID: 84232
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQteGroup.SCommonQteGroup";

		// Token: 0x04014909 RID: 84233
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401490A RID: 84234
		internal static int __PropertyOffset_0;

		// Token: 0x0401490B RID: 84235
		internal static int __PropertyOffset_1;

		// Token: 0x0401490C RID: 84236
		[Nullable(2)]
		private TSet<int> _CommonQteIdSet;

		// Token: 0x0401490D RID: 84237
		internal static int __PropertyOffset_2;

		// Token: 0x0401490E RID: 84238
		internal static int __PropertyOffset_3;

		// Token: 0x0401490F RID: 84239
		internal static int __PropertyOffset_4;

		// Token: 0x04014910 RID: 84240
		internal static int __PropertyOffset_5;

		// Token: 0x04014911 RID: 84241
		internal static int __PropertyOffset_6;
	}
}
