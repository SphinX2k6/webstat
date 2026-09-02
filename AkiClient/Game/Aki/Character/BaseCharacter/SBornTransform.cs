using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200423D RID: 16957
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBornTransform.SBornTransform")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SBornTransform : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CDC1 RID: 183745 RVA: 0x00AB1C84 File Offset: 0x00AAFE84
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBornTransform._ScriptStructPtr != 0) ? SBornTransform._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBornTransform.SBornTransform", ref SBornTransform._ScriptStructPtr);
		}

		// Token: 0x17007961 RID: 31073
		// (get) Token: 0x0602CDC2 RID: 183746 RVA: 0x00AB1CA8 File Offset: 0x00AAFEA8
		// (set) Token: 0x0602CDC3 RID: 183747 RVA: 0x00AB1CBC File Offset: 0x00AAFEBC
		public unsafe FVector Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007962 RID: 31074
		// (get) Token: 0x0602CDC4 RID: 183748 RVA: 0x00AB1CD1 File Offset: 0x00AAFED1
		// (set) Token: 0x0602CDC5 RID: 183749 RVA: 0x00AB1CE5 File Offset: 0x00AAFEE5
		public unsafe TEnumAsByte<EOffsetTargetType> OffsetTargetType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007963 RID: 31075
		// (get) Token: 0x0602CDC6 RID: 183750 RVA: 0x00AB1CFA File Offset: 0x00AAFEFA
		// (set) Token: 0x0602CDC7 RID: 183751 RVA: 0x00AB1D0E File Offset: 0x00AAFF0E
		public unsafe TEnumAsByte<EBornRotateType> RotateType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007964 RID: 31076
		// (get) Token: 0x0602CDC8 RID: 183752 RVA: 0x00AB1D23 File Offset: 0x00AAFF23
		// (set) Token: 0x0602CDC9 RID: 183753 RVA: 0x00AB1D33 File Offset: 0x00AAFF33
		public unsafe int RotateCameraDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007965 RID: 31077
		// (get) Token: 0x0602CDCA RID: 183754 RVA: 0x00AB1D44 File Offset: 0x00AAFF44
		// (set) Token: 0x0602CDCB RID: 183755 RVA: 0x00AB1D87 File Offset: 0x00AAFF87
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<ECommonAxis>> RotateInvalidAxis
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<ECommonAxis>> result;
				if ((result = this._RotateInvalidAxis) == null)
				{
					result = (this._RotateInvalidAxis = new TArray<TEnumAsByte<ECommonAxis>>(base.NativePtr + (IntPtr)SBornTransform.__PropertyOffset_4, base.MemoryOwner ?? this));
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
				this.RotateInvalidAxis.CopyAssign(value);
			}
		}

		// Token: 0x0602CDCC RID: 183756 RVA: 0x00AB1D95 File Offset: 0x00AAFF95
		public SBornTransform()
		{
		}

		// Token: 0x0602CDCD RID: 183757 RVA: 0x00AB1D9D File Offset: 0x00AAFF9D
		public SBornTransform(FVector Offset, TEnumAsByte<EOffsetTargetType> OffsetTargetType, TEnumAsByte<EBornRotateType> RotateType, int RotateCameraDistance, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<ECommonAxis>> RotateInvalidAxis)
		{
			this.Offset = Offset;
			this.OffsetTargetType = OffsetTargetType;
			this.RotateType = RotateType;
			this.RotateCameraDistance = RotateCameraDistance;
			this.RotateInvalidAxis = RotateInvalidAxis;
		}

		// Token: 0x0602CDCE RID: 183758 RVA: 0x00AB1DCA File Offset: 0x00AAFFCA
		protected override IntPtr GetUStructPtr()
		{
			return SBornTransform.StaticStruct();
		}

		// Token: 0x0602CDCF RID: 183759 RVA: 0x00AB1DD6 File Offset: 0x00AAFFD6
		[NullableContext(2)]
		public SBornTransform(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CDD0 RID: 183760 RVA: 0x00AB1DE0 File Offset: 0x00AAFFE0
		public SBornTransform(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CDD1 RID: 183761 RVA: 0x00AB1DEB File Offset: 0x00AAFFEB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBornTransform(Pointer, false, true);
		}

		// Token: 0x0602CDD2 RID: 183762 RVA: 0x00AB1DF5 File Offset: 0x00AAFFF5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBornTransform(Pointer, MemoryOwner);
		}

		// Token: 0x040192BB RID: 103099
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBornTransform.SBornTransform";

		// Token: 0x040192BC RID: 103100
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192BD RID: 103101
		internal static int __PropertyOffset_0;

		// Token: 0x040192BE RID: 103102
		internal static int __PropertyOffset_1;

		// Token: 0x040192BF RID: 103103
		internal static int __PropertyOffset_2;

		// Token: 0x040192C0 RID: 103104
		internal static int __PropertyOffset_3;

		// Token: 0x040192C1 RID: 103105
		internal static int __PropertyOffset_4;

		// Token: 0x040192C2 RID: 103106
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<ECommonAxis>> _RotateInvalidAxis;
	}
}
