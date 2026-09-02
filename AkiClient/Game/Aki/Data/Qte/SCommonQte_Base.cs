using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E46 RID: 15942
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_Base.SCommonQte_Base")]
	[UnrealStructLayout(936, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 936)]
	public class SCommonQte_Base : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060274AF RID: 160943 RVA: 0x009EE608 File Offset: 0x009EC808
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_Base._ScriptStructPtr != 0) ? SCommonQte_Base._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_Base.SCommonQte_Base", ref SCommonQte_Base._ScriptStructPtr);
		}

		// Token: 0x17005C08 RID: 23560
		// (get) Token: 0x060274B0 RID: 160944 RVA: 0x009EE62C File Offset: 0x009EC82C
		// (set) Token: 0x060274B1 RID: 160945 RVA: 0x009EE640 File Offset: 0x009EC840
		[Nullable(0)]
		public unsafe TEnumAsByte<ECommonQteType> QteType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C09 RID: 23561
		// (get) Token: 0x060274B2 RID: 160946 RVA: 0x009EE655 File Offset: 0x009EC855
		// (set) Token: 0x060274B3 RID: 160947 RVA: 0x009EE665 File Offset: 0x009EC865
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005C0A RID: 23562
		// (get) Token: 0x060274B4 RID: 160948 RVA: 0x009EE676 File Offset: 0x009EC876
		// (set) Token: 0x060274B5 RID: 160949 RVA: 0x009EE686 File Offset: 0x009EC886
		public unsafe float LeastDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C0B RID: 23563
		// (get) Token: 0x060274B6 RID: 160950 RVA: 0x009EE697 File Offset: 0x009EC897
		// (set) Token: 0x060274B7 RID: 160951 RVA: 0x009EE6A7 File Offset: 0x009EC8A7
		public unsafe float TimeDilation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005C0C RID: 23564
		// (get) Token: 0x060274B8 RID: 160952 RVA: 0x009EE6B8 File Offset: 0x009EC8B8
		// (set) Token: 0x060274B9 RID: 160953 RVA: 0x009EE6FB File Offset: 0x009EC8FB
		public SCommonQte_SingleClick SingleClickConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCommonQte_SingleClick result;
				if ((result = this._SingleClickConfig) == null)
				{
					result = (this._SingleClickConfig = new SCommonQte_SingleClick(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQte_SingleClick.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C0D RID: 23565
		// (get) Token: 0x060274BA RID: 160954 RVA: 0x009EE71C File Offset: 0x009EC91C
		// (set) Token: 0x060274BB RID: 160955 RVA: 0x009EE75F File Offset: 0x009EC95F
		public SCommonQte_ContinuousClick ContinuousClickConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCommonQte_ContinuousClick result;
				if ((result = this._ContinuousClickConfig) == null)
				{
					result = (this._ContinuousClickConfig = new SCommonQte_ContinuousClick(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQte_ContinuousClick.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C0E RID: 23566
		// (get) Token: 0x060274BC RID: 160956 RVA: 0x009EE780 File Offset: 0x009EC980
		// (set) Token: 0x060274BD RID: 160957 RVA: 0x009EE7C3 File Offset: 0x009EC9C3
		public SCommonQte_Drag DragConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCommonQte_Drag result;
				if ((result = this._DragConfig) == null)
				{
					result = (this._DragConfig = new SCommonQte_Drag(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQte_Drag.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C0F RID: 23567
		// (get) Token: 0x060274BE RID: 160958 RVA: 0x009EE7E4 File Offset: 0x009EC9E4
		// (set) Token: 0x060274BF RID: 160959 RVA: 0x009EE827 File Offset: 0x009ECA27
		public SCommonQte_LongPress LongPressConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCommonQte_LongPress result;
				if ((result = this._LongPressConfig) == null)
				{
					result = (this._LongPressConfig = new SCommonQte_LongPress(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQte_LongPress.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C10 RID: 23568
		// (get) Token: 0x060274C0 RID: 160960 RVA: 0x009EE848 File Offset: 0x009ECA48
		// (set) Token: 0x060274C1 RID: 160961 RVA: 0x009EE88B File Offset: 0x009ECA8B
		public SCommonQte_SelectOption SelectOptionConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCommonQte_SelectOption result;
				if ((result = this._SelectOptionConfig) == null)
				{
					result = (this._SelectOptionConfig = new SCommonQte_SelectOption(base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQte_SelectOption.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_Base.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060274C2 RID: 160962 RVA: 0x009EE8AC File Offset: 0x009ECAAC
		public SCommonQte_Base()
		{
		}

		// Token: 0x060274C3 RID: 160963 RVA: 0x009EE8B4 File Offset: 0x009ECAB4
		public SCommonQte_Base([Nullable(0)] TEnumAsByte<ECommonQteType> QteType, float Duration, float LeastDuration, float TimeDilation, SCommonQte_SingleClick SingleClickConfig, SCommonQte_ContinuousClick ContinuousClickConfig, SCommonQte_Drag DragConfig, SCommonQte_LongPress LongPressConfig, SCommonQte_SelectOption SelectOptionConfig)
		{
			this.QteType = QteType;
			this.Duration = Duration;
			this.LeastDuration = LeastDuration;
			this.TimeDilation = TimeDilation;
			this.SingleClickConfig = SingleClickConfig;
			this.ContinuousClickConfig = ContinuousClickConfig;
			this.DragConfig = DragConfig;
			this.LongPressConfig = LongPressConfig;
			this.SelectOptionConfig = SelectOptionConfig;
		}

		// Token: 0x060274C4 RID: 160964 RVA: 0x009EE90C File Offset: 0x009ECB0C
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte_Base.StaticStruct();
		}

		// Token: 0x060274C5 RID: 160965 RVA: 0x009EE918 File Offset: 0x009ECB18
		[NullableContext(2)]
		public SCommonQte_Base(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060274C6 RID: 160966 RVA: 0x009EE922 File Offset: 0x009ECB22
		public SCommonQte_Base(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060274C7 RID: 160967 RVA: 0x009EE92D File Offset: 0x009ECB2D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte_Base(Pointer, false, true);
		}

		// Token: 0x060274C8 RID: 160968 RVA: 0x009EE937 File Offset: 0x009ECB37
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte_Base(Pointer, MemoryOwner);
		}

		// Token: 0x04014926 RID: 84262
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_Base.SCommonQte_Base";

		// Token: 0x04014927 RID: 84263
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014928 RID: 84264
		internal static int __PropertyOffset_0;

		// Token: 0x04014929 RID: 84265
		internal static int __PropertyOffset_1;

		// Token: 0x0401492A RID: 84266
		internal static int __PropertyOffset_2;

		// Token: 0x0401492B RID: 84267
		internal static int __PropertyOffset_3;

		// Token: 0x0401492C RID: 84268
		internal static int __PropertyOffset_4;

		// Token: 0x0401492D RID: 84269
		[Nullable(2)]
		private SCommonQte_SingleClick _SingleClickConfig;

		// Token: 0x0401492E RID: 84270
		internal static int __PropertyOffset_5;

		// Token: 0x0401492F RID: 84271
		[Nullable(2)]
		private SCommonQte_ContinuousClick _ContinuousClickConfig;

		// Token: 0x04014930 RID: 84272
		internal static int __PropertyOffset_6;

		// Token: 0x04014931 RID: 84273
		[Nullable(2)]
		private SCommonQte_Drag _DragConfig;

		// Token: 0x04014932 RID: 84274
		internal static int __PropertyOffset_7;

		// Token: 0x04014933 RID: 84275
		[Nullable(2)]
		private SCommonQte_LongPress _LongPressConfig;

		// Token: 0x04014934 RID: 84276
		internal static int __PropertyOffset_8;

		// Token: 0x04014935 RID: 84277
		[Nullable(2)]
		private SCommonQte_SelectOption _SelectOptionConfig;
	}
}
