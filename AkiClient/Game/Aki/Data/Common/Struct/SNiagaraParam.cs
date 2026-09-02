using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Common.Struct
{
	// Token: 0x02003F0A RID: 16138
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Common/Struct/SNiagaraParam.SNiagaraParam")]
	[UnrealStructLayout(264, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 264)]
	public class SNiagaraParam : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602832B RID: 164651 RVA: 0x00A05066 File Offset: 0x00A03266
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNiagaraParam._ScriptStructPtr != 0) ? SNiagaraParam._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Common/Struct/SNiagaraParam.SNiagaraParam", ref SNiagaraParam._ScriptStructPtr);
		}

		// Token: 0x17006102 RID: 24834
		// (get) Token: 0x0602832C RID: 164652 RVA: 0x00A0508A File Offset: 0x00A0328A
		// (set) Token: 0x0602832D RID: 164653 RVA: 0x00A0509A File Offset: 0x00A0329A
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006103 RID: 24835
		// (get) Token: 0x0602832E RID: 164654 RVA: 0x00A050AC File Offset: 0x00A032AC
		// (set) Token: 0x0602832F RID: 164655 RVA: 0x00A050EF File Offset: 0x00A032EF
		public TMap<FName, FKuroCurveFloat> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveFloat> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TMap<FName, FKuroCurveFloat>(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x17006104 RID: 24836
		// (get) Token: 0x06028330 RID: 164656 RVA: 0x00A05100 File Offset: 0x00A03300
		// (set) Token: 0x06028331 RID: 164657 RVA: 0x00A05143 File Offset: 0x00A03343
		public TMap<FName, FKuroCurveLinearColor> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveLinearColor> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TMap<FName, FKuroCurveLinearColor>(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x17006105 RID: 24837
		// (get) Token: 0x06028332 RID: 164658 RVA: 0x00A05154 File Offset: 0x00A03354
		// (set) Token: 0x06028333 RID: 164659 RVA: 0x00A05197 File Offset: 0x00A03397
		public TMap<FName, FKuroCurveVector> VectorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveVector> result;
				if ((result = this._VectorParameters) == null)
				{
					result = (this._VectorParameters = new TMap<FName, FKuroCurveVector>(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.VectorParameters.CopyAssign(value);
			}
		}

		// Token: 0x17006106 RID: 24838
		// (get) Token: 0x06028334 RID: 164660 RVA: 0x00A051A5 File Offset: 0x00A033A5
		// (set) Token: 0x06028335 RID: 164661 RVA: 0x00A051B5 File Offset: 0x00A033B5
		public unsafe float StartTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006107 RID: 24839
		// (get) Token: 0x06028336 RID: 164662 RVA: 0x00A051C6 File Offset: 0x00A033C6
		// (set) Token: 0x06028337 RID: 164663 RVA: 0x00A051D6 File Offset: 0x00A033D6
		public unsafe float LoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006108 RID: 24840
		// (get) Token: 0x06028338 RID: 164664 RVA: 0x00A051E7 File Offset: 0x00A033E7
		// (set) Token: 0x06028339 RID: 164665 RVA: 0x00A051F7 File Offset: 0x00A033F7
		public unsafe float EndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006109 RID: 24841
		// (get) Token: 0x0602833A RID: 164666 RVA: 0x00A05208 File Offset: 0x00A03408
		// (set) Token: 0x0602833B RID: 164667 RVA: 0x00A05218 File Offset: 0x00A03418
		public unsafe float ManualLifeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNiagaraParam.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602833C RID: 164668 RVA: 0x00A05229 File Offset: 0x00A03429
		public SNiagaraParam()
		{
		}

		// Token: 0x0602833D RID: 164669 RVA: 0x00A05234 File Offset: 0x00A03434
		public SNiagaraParam(int ID, TMap<FName, FKuroCurveFloat> FloatParameters, TMap<FName, FKuroCurveLinearColor> ColorParameters, TMap<FName, FKuroCurveVector> VectorParameters, float StartTime, float LoopTime, float EndTime, float ManualLifeTime)
		{
			this.ID = ID;
			this.FloatParameters = FloatParameters;
			this.ColorParameters = ColorParameters;
			this.VectorParameters = VectorParameters;
			this.StartTime = StartTime;
			this.LoopTime = LoopTime;
			this.EndTime = EndTime;
			this.ManualLifeTime = ManualLifeTime;
		}

		// Token: 0x0602833E RID: 164670 RVA: 0x00A05284 File Offset: 0x00A03484
		protected override IntPtr GetUStructPtr()
		{
			return SNiagaraParam.StaticStruct();
		}

		// Token: 0x0602833F RID: 164671 RVA: 0x00A05290 File Offset: 0x00A03490
		[NullableContext(2)]
		public SNiagaraParam(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028340 RID: 164672 RVA: 0x00A0529A File Offset: 0x00A0349A
		public SNiagaraParam(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028341 RID: 164673 RVA: 0x00A052A5 File Offset: 0x00A034A5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNiagaraParam(Pointer, false, true);
		}

		// Token: 0x06028342 RID: 164674 RVA: 0x00A052AF File Offset: 0x00A034AF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNiagaraParam(Pointer, MemoryOwner);
		}

		// Token: 0x04015221 RID: 86561
		public const string __ObjectPath = "/Game/Aki/Data/Common/Struct/SNiagaraParam.SNiagaraParam";

		// Token: 0x04015222 RID: 86562
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015223 RID: 86563
		internal static int __PropertyOffset_0;

		// Token: 0x04015224 RID: 86564
		internal static int __PropertyOffset_1;

		// Token: 0x04015225 RID: 86565
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveFloat> _FloatParameters;

		// Token: 0x04015226 RID: 86566
		internal static int __PropertyOffset_2;

		// Token: 0x04015227 RID: 86567
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveLinearColor> _ColorParameters;

		// Token: 0x04015228 RID: 86568
		internal static int __PropertyOffset_3;

		// Token: 0x04015229 RID: 86569
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveVector> _VectorParameters;

		// Token: 0x0401522A RID: 86570
		internal static int __PropertyOffset_4;

		// Token: 0x0401522B RID: 86571
		internal static int __PropertyOffset_5;

		// Token: 0x0401522C RID: 86572
		internal static int __PropertyOffset_6;

		// Token: 0x0401522D RID: 86573
		internal static int __PropertyOffset_7;
	}
}
