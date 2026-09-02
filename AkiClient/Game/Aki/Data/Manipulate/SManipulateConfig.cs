using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Manipulate
{
	// Token: 0x02003E65 RID: 15973
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Manipulate/SManipulateConfig.SManipulateConfig")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 36)]
	public class SManipulateConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060276E8 RID: 161512 RVA: 0x009F1B3C File Offset: 0x009EFD3C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SManipulateConfig._ScriptStructPtr != 0) ? SManipulateConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Manipulate/SManipulateConfig.SManipulateConfig", ref SManipulateConfig._ScriptStructPtr);
		}

		// Token: 0x17005CB3 RID: 23731
		// (get) Token: 0x060276E9 RID: 161513 RVA: 0x009F1B60 File Offset: 0x009EFD60
		// (set) Token: 0x060276EA RID: 161514 RVA: 0x009F1B74 File Offset: 0x009EFD74
		public unsafe FName ConfigName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SManipulateConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SManipulateConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005CB4 RID: 23732
		// (get) Token: 0x060276EB RID: 161515 RVA: 0x009F1B8C File Offset: 0x009EFD8C
		// (set) Token: 0x060276EC RID: 161516 RVA: 0x009F1BCF File Offset: 0x009EFDCF
		public TArray<SManipulatePointInfo> ManipulatePoints
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SManipulatePointInfo> result;
				if ((result = this._ManipulatePoints) == null)
				{
					result = (this._ManipulatePoints = new TArray<SManipulatePointInfo>(base.NativePtr + (IntPtr)SManipulateConfig.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ManipulatePoints.CopyAssign(value);
			}
		}

		// Token: 0x17005CB5 RID: 23733
		// (get) Token: 0x060276ED RID: 161517 RVA: 0x009F1BDD File Offset: 0x009EFDDD
		// (set) Token: 0x060276EE RID: 161518 RVA: 0x009F1BED File Offset: 0x009EFDED
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SManipulateConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SManipulateConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x060276EF RID: 161519 RVA: 0x009F1BFE File Offset: 0x009EFDFE
		public SManipulateConfig()
		{
		}

		// Token: 0x060276F0 RID: 161520 RVA: 0x009F1C06 File Offset: 0x009EFE06
		public SManipulateConfig(FName ConfigName, TArray<SManipulatePointInfo> ManipulatePoints, float Duration)
		{
			this.ConfigName = ConfigName;
			this.ManipulatePoints = ManipulatePoints;
			this.Duration = Duration;
		}

		// Token: 0x060276F1 RID: 161521 RVA: 0x009F1C23 File Offset: 0x009EFE23
		protected override IntPtr GetUStructPtr()
		{
			return SManipulateConfig.StaticStruct();
		}

		// Token: 0x060276F2 RID: 161522 RVA: 0x009F1C2F File Offset: 0x009EFE2F
		[NullableContext(2)]
		public SManipulateConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060276F3 RID: 161523 RVA: 0x009F1C39 File Offset: 0x009EFE39
		public SManipulateConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060276F4 RID: 161524 RVA: 0x009F1C44 File Offset: 0x009EFE44
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SManipulateConfig(Pointer, false, true);
		}

		// Token: 0x060276F5 RID: 161525 RVA: 0x009F1C4E File Offset: 0x009EFE4E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SManipulateConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014A6C RID: 84588
		public const string __ObjectPath = "/Game/Aki/Data/Manipulate/SManipulateConfig.SManipulateConfig";

		// Token: 0x04014A6D RID: 84589
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014A6E RID: 84590
		internal static int __PropertyOffset_0;

		// Token: 0x04014A6F RID: 84591
		internal static int __PropertyOffset_1;

		// Token: 0x04014A70 RID: 84592
		[Nullable(2)]
		private TArray<SManipulatePointInfo> _ManipulatePoints;

		// Token: 0x04014A71 RID: 84593
		internal static int __PropertyOffset_2;
	}
}
