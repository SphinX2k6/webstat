using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.DandelionInteraction.DT
{
	// Token: 0x02003D52 RID: 15698
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/DandelionInteraction/DT/Struct_DandelionFT.Struct_DandelionFT")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class Struct_DandelionFT : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060261FC RID: 156156 RVA: 0x009CEA40 File Offset: 0x009CCC40
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_DandelionFT._ScriptStructPtr != 0) ? Struct_DandelionFT._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/DandelionInteraction/DT/Struct_DandelionFT.Struct_DandelionFT", ref Struct_DandelionFT._ScriptStructPtr);
		}

		// Token: 0x17005596 RID: 21910
		// (get) Token: 0x060261FD RID: 156157 RVA: 0x009CEA64 File Offset: 0x009CCC64
		// (set) Token: 0x060261FE RID: 156158 RVA: 0x009CEA78 File Offset: 0x009CCC78
		[Nullable(2)]
		public unsafe UFoliageType_InstancedStaticMesh FT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UFoliageType_InstancedStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionFT.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionFT.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005597 RID: 21911
		// (get) Token: 0x060261FF RID: 156159 RVA: 0x009CEA90 File Offset: 0x009CCC90
		// (set) Token: 0x06026200 RID: 156160 RVA: 0x009CEAD3 File Offset: 0x009CCCD3
		public TArray<FVector4> PointsArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector4> result;
				if ((result = this._PointsArray) == null)
				{
					result = (this._PointsArray = new TArray<FVector4>(base.NativePtr + (IntPtr)Struct_DandelionFT.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PointsArray.CopyAssign(value);
			}
		}

		// Token: 0x06026201 RID: 156161 RVA: 0x009CEAE1 File Offset: 0x009CCCE1
		public Struct_DandelionFT()
		{
		}

		// Token: 0x06026202 RID: 156162 RVA: 0x009CEAE9 File Offset: 0x009CCCE9
		public Struct_DandelionFT(UFoliageType_InstancedStaticMesh FT, TArray<FVector4> PointsArray)
		{
			this.FT = FT;
			this.PointsArray = PointsArray;
		}

		// Token: 0x06026203 RID: 156163 RVA: 0x009CEAFF File Offset: 0x009CCCFF
		protected override IntPtr GetUStructPtr()
		{
			return Struct_DandelionFT.StaticStruct();
		}

		// Token: 0x06026204 RID: 156164 RVA: 0x009CEB0B File Offset: 0x009CCD0B
		[NullableContext(2)]
		public Struct_DandelionFT(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026205 RID: 156165 RVA: 0x009CEB15 File Offset: 0x009CCD15
		public Struct_DandelionFT(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026206 RID: 156166 RVA: 0x009CEB20 File Offset: 0x009CCD20
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_DandelionFT(Pointer, false, true);
		}

		// Token: 0x06026207 RID: 156167 RVA: 0x009CEB2A File Offset: 0x009CCD2A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_DandelionFT(Pointer, MemoryOwner);
		}

		// Token: 0x04013BF6 RID: 80886
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/DandelionInteraction/DT/Struct_DandelionFT.Struct_DandelionFT";

		// Token: 0x04013BF7 RID: 80887
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013BF8 RID: 80888
		internal static int __PropertyOffset_0;

		// Token: 0x04013BF9 RID: 80889
		internal static int __PropertyOffset_1;

		// Token: 0x04013BFA RID: 80890
		[Nullable(2)]
		private TArray<FVector4> _PointsArray;
	}
}
