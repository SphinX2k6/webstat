using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200431C RID: 17180
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SRangeCurve.SRangeCurve")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SRangeCurve : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D91C RID: 186652 RVA: 0x00AC3A6A File Offset: 0x00AC1C6A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRangeCurve._ScriptStructPtr != 0) ? SRangeCurve._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SRangeCurve.SRangeCurve", ref SRangeCurve._ScriptStructPtr);
		}

		// Token: 0x17007CD4 RID: 31956
		// (get) Token: 0x0602D91D RID: 186653 RVA: 0x00AC3A8E File Offset: 0x00AC1C8E
		// (set) Token: 0x0602D91E RID: 186654 RVA: 0x00AC3A9E File Offset: 0x00AC1C9E
		public unsafe float From
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRangeCurve.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRangeCurve.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007CD5 RID: 31957
		// (get) Token: 0x0602D91F RID: 186655 RVA: 0x00AC3AAF File Offset: 0x00AC1CAF
		// (set) Token: 0x0602D920 RID: 186656 RVA: 0x00AC3ABF File Offset: 0x00AC1CBF
		public unsafe float To
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRangeCurve.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRangeCurve.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007CD6 RID: 31958
		// (get) Token: 0x0602D921 RID: 186657 RVA: 0x00AC3AD0 File Offset: 0x00AC1CD0
		// (set) Token: 0x0602D922 RID: 186658 RVA: 0x00AC3B13 File Offset: 0x00AC1D13
		public SBaseCurve BaseCurve
		{
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._BaseCurve) == null)
				{
					result = (this._BaseCurve = new SBaseCurve(base.NativePtr + (IntPtr)SRangeCurve.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)SRangeCurve.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D923 RID: 186659 RVA: 0x00AC3B34 File Offset: 0x00AC1D34
		public SRangeCurve()
		{
		}

		// Token: 0x0602D924 RID: 186660 RVA: 0x00AC3B3C File Offset: 0x00AC1D3C
		public SRangeCurve(float From, float To, SBaseCurve BaseCurve)
		{
			this.From = From;
			this.To = To;
			this.BaseCurve = BaseCurve;
		}

		// Token: 0x0602D925 RID: 186661 RVA: 0x00AC3B59 File Offset: 0x00AC1D59
		protected override IntPtr GetUStructPtr()
		{
			return SRangeCurve.StaticStruct();
		}

		// Token: 0x0602D926 RID: 186662 RVA: 0x00AC3B65 File Offset: 0x00AC1D65
		[NullableContext(2)]
		public SRangeCurve(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D927 RID: 186663 RVA: 0x00AC3B6F File Offset: 0x00AC1D6F
		public SRangeCurve(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D928 RID: 186664 RVA: 0x00AC3B7A File Offset: 0x00AC1D7A
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRangeCurve(Pointer, false, true);
		}

		// Token: 0x0602D929 RID: 186665 RVA: 0x00AC3B84 File Offset: 0x00AC1D84
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRangeCurve(Pointer, MemoryOwner);
		}

		// Token: 0x04019B0F RID: 105231
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SRangeCurve.SRangeCurve";

		// Token: 0x04019B10 RID: 105232
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B11 RID: 105233
		internal static int __PropertyOffset_0;

		// Token: 0x04019B12 RID: 105234
		internal static int __PropertyOffset_1;

		// Token: 0x04019B13 RID: 105235
		internal static int __PropertyOffset_2;

		// Token: 0x04019B14 RID: 105236
		[Nullable(2)]
		private SBaseCurve _BaseCurve;
	}
}
