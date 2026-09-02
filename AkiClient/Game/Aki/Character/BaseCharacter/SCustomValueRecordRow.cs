using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004255 RID: 16981
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCustomValueRecordRow.SCustomValueRecordRow")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class SCustomValueRecordRow : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CFBE RID: 184254 RVA: 0x00AB4C6D File Offset: 0x00AB2E6D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCustomValueRecordRow._ScriptStructPtr != 0) ? SCustomValueRecordRow._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCustomValueRecordRow.SCustomValueRecordRow", ref SCustomValueRecordRow._ScriptStructPtr);
		}

		// Token: 0x17007A01 RID: 31233
		// (get) Token: 0x0602CFBF RID: 184255 RVA: 0x00AB4C91 File Offset: 0x00AB2E91
		// (set) Token: 0x0602CFC0 RID: 184256 RVA: 0x00AB4CA5 File Offset: 0x00AB2EA5
		[Nullable(0)]
		public unsafe TEnumAsByte<ECustomValueReturn> ReturnType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A02 RID: 31234
		// (get) Token: 0x0602CFC1 RID: 184257 RVA: 0x00AB4CBA File Offset: 0x00AB2EBA
		// (set) Token: 0x0602CFC2 RID: 184258 RVA: 0x00AB4CCE File Offset: 0x00AB2ECE
		[Nullable(0)]
		public unsafe TEnumAsByte<ECustomValueSourceNum> NumSource
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A03 RID: 31235
		// (get) Token: 0x0602CFC3 RID: 184259 RVA: 0x00AB4CE3 File Offset: 0x00AB2EE3
		// (set) Token: 0x0602CFC4 RID: 184260 RVA: 0x00AB4CF7 File Offset: 0x00AB2EF7
		[Nullable(0)]
		public unsafe TEnumAsByte<ECustomValueSourceVector> VecSource
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_2);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A04 RID: 31236
		// (get) Token: 0x0602CFC5 RID: 184261 RVA: 0x00AB4D0C File Offset: 0x00AB2F0C
		// (set) Token: 0x0602CFC6 RID: 184262 RVA: 0x00AB4D20 File Offset: 0x00AB2F20
		[Nullable(0)]
		public unsafe TEnumAsByte<ECustomValueSourceRotator> RotSource
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A05 RID: 31237
		// (get) Token: 0x0602CFC7 RID: 184263 RVA: 0x00AB4D38 File Offset: 0x00AB2F38
		// (set) Token: 0x0602CFC8 RID: 184264 RVA: 0x00AB4D7B File Offset: 0x00AB2F7B
		public TArray<float> NumberValue
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._NumberValue) == null)
				{
					result = (this._NumberValue = new TArray<float>(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.NumberValue.CopyAssign(value);
			}
		}

		// Token: 0x17007A06 RID: 31238
		// (get) Token: 0x0602CFC9 RID: 184265 RVA: 0x00AB4D8C File Offset: 0x00AB2F8C
		// (set) Token: 0x0602CFCA RID: 184266 RVA: 0x00AB4DCF File Offset: 0x00AB2FCF
		public TArray<FVectorDouble> VectorValue
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._VectorValue) == null)
				{
					result = (this._VectorValue = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.VectorValue.CopyAssign(value);
			}
		}

		// Token: 0x17007A07 RID: 31239
		// (get) Token: 0x0602CFCB RID: 184267 RVA: 0x00AB4DE0 File Offset: 0x00AB2FE0
		// (set) Token: 0x0602CFCC RID: 184268 RVA: 0x00AB4E23 File Offset: 0x00AB3023
		public TArray<FRotator> RotatorValue
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FRotator> result;
				if ((result = this._RotatorValue) == null)
				{
					result = (this._RotatorValue = new TArray<FRotator>(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RotatorValue.CopyAssign(value);
			}
		}

		// Token: 0x17007A08 RID: 31240
		// (get) Token: 0x0602CFCD RID: 184269 RVA: 0x00AB4E34 File Offset: 0x00AB3034
		// (set) Token: 0x0602CFCE RID: 184270 RVA: 0x00AB4E77 File Offset: 0x00AB3077
		public TArray<SCustomValueFormula> FormulaList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCustomValueFormula> result;
				if ((result = this._FormulaList) == null)
				{
					result = (this._FormulaList = new TArray<SCustomValueFormula>(base.NativePtr + (IntPtr)SCustomValueRecordRow.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FormulaList.CopyAssign(value);
			}
		}

		// Token: 0x17007A09 RID: 31241
		// (get) Token: 0x0602CFCF RID: 184271 RVA: 0x00AB4E85 File Offset: 0x00AB3085
		// (set) Token: 0x0602CFD0 RID: 184272 RVA: 0x00AB4E99 File Offset: 0x00AB3099
		public unsafe string Notes
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCustomValueRecordRow.__PropertyOffset_8)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCustomValueRecordRow.__PropertyOffset_8)), value);
			}
		}

		// Token: 0x0602CFD1 RID: 184273 RVA: 0x00AB4EAE File Offset: 0x00AB30AE
		public SCustomValueRecordRow()
		{
		}

		// Token: 0x0602CFD2 RID: 184274 RVA: 0x00AB4EB8 File Offset: 0x00AB30B8
		public SCustomValueRecordRow([Nullable(0)] TEnumAsByte<ECustomValueReturn> ReturnType, [Nullable(0)] TEnumAsByte<ECustomValueSourceNum> NumSource, [Nullable(0)] TEnumAsByte<ECustomValueSourceVector> VecSource, [Nullable(0)] TEnumAsByte<ECustomValueSourceRotator> RotSource, TArray<float> NumberValue, TArray<FVectorDouble> VectorValue, TArray<FRotator> RotatorValue, TArray<SCustomValueFormula> FormulaList, string Notes)
		{
			this.ReturnType = ReturnType;
			this.NumSource = NumSource;
			this.VecSource = VecSource;
			this.RotSource = RotSource;
			this.NumberValue = NumberValue;
			this.VectorValue = VectorValue;
			this.RotatorValue = RotatorValue;
			this.FormulaList = FormulaList;
			this.Notes = Notes;
		}

		// Token: 0x0602CFD3 RID: 184275 RVA: 0x00AB4F10 File Offset: 0x00AB3110
		protected override IntPtr GetUStructPtr()
		{
			return SCustomValueRecordRow.StaticStruct();
		}

		// Token: 0x0602CFD4 RID: 184276 RVA: 0x00AB4F1C File Offset: 0x00AB311C
		[NullableContext(2)]
		public SCustomValueRecordRow(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CFD5 RID: 184277 RVA: 0x00AB4F26 File Offset: 0x00AB3126
		public SCustomValueRecordRow(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CFD6 RID: 184278 RVA: 0x00AB4F31 File Offset: 0x00AB3131
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCustomValueRecordRow(Pointer, false, true);
		}

		// Token: 0x0602CFD7 RID: 184279 RVA: 0x00AB4F3B File Offset: 0x00AB313B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCustomValueRecordRow(Pointer, MemoryOwner);
		}

		// Token: 0x040193B9 RID: 103353
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCustomValueRecordRow.SCustomValueRecordRow";

		// Token: 0x040193BA RID: 103354
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193BB RID: 103355
		internal static int __PropertyOffset_0;

		// Token: 0x040193BC RID: 103356
		internal static int __PropertyOffset_1;

		// Token: 0x040193BD RID: 103357
		internal static int __PropertyOffset_2;

		// Token: 0x040193BE RID: 103358
		internal static int __PropertyOffset_3;

		// Token: 0x040193BF RID: 103359
		internal static int __PropertyOffset_4;

		// Token: 0x040193C0 RID: 103360
		[Nullable(2)]
		private TArray<float> _NumberValue;

		// Token: 0x040193C1 RID: 103361
		internal static int __PropertyOffset_5;

		// Token: 0x040193C2 RID: 103362
		[Nullable(2)]
		private TArray<FVectorDouble> _VectorValue;

		// Token: 0x040193C3 RID: 103363
		internal static int __PropertyOffset_6;

		// Token: 0x040193C4 RID: 103364
		[Nullable(2)]
		private TArray<FRotator> _RotatorValue;

		// Token: 0x040193C5 RID: 103365
		internal static int __PropertyOffset_7;

		// Token: 0x040193C6 RID: 103366
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCustomValueFormula> _FormulaList;

		// Token: 0x040193C7 RID: 103367
		internal static int __PropertyOffset_8;
	}
}
