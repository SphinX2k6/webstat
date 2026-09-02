using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.ModelMat
{
	// Token: 0x02003E63 RID: 15971
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/ModelMat/ST_MatReplace.ST_MatReplace")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class ST_MatReplace : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060276D5 RID: 161493 RVA: 0x009F19A0 File Offset: 0x009EFBA0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (ST_MatReplace._ScriptStructPtr != 0) ? ST_MatReplace._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/ModelMat/ST_MatReplace.ST_MatReplace", ref ST_MatReplace._ScriptStructPtr);
		}

		// Token: 0x17005CB1 RID: 23729
		// (get) Token: 0x060276D6 RID: 161494 RVA: 0x009F19C4 File Offset: 0x009EFBC4
		// (set) Token: 0x060276D7 RID: 161495 RVA: 0x009F19D8 File Offset: 0x009EFBD8
		[Nullable(2)]
		public unsafe UStaticMesh StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + ST_MatReplace.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ST_MatReplace.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005CB2 RID: 23730
		// (get) Token: 0x060276D8 RID: 161496 RVA: 0x009F19F0 File Offset: 0x009EFBF0
		// (set) Token: 0x060276D9 RID: 161497 RVA: 0x009F1A33 File Offset: 0x009EFC33
		public TArray<UMaterialInstance> Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._Materials) == null)
				{
					result = (this._Materials = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)ST_MatReplace.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Materials.CopyAssign(value);
			}
		}

		// Token: 0x060276DA RID: 161498 RVA: 0x009F1A41 File Offset: 0x009EFC41
		public ST_MatReplace()
		{
		}

		// Token: 0x060276DB RID: 161499 RVA: 0x009F1A49 File Offset: 0x009EFC49
		public ST_MatReplace(UStaticMesh StaticMesh, TArray<UMaterialInstance> Materials)
		{
			this.StaticMesh = StaticMesh;
			this.Materials = Materials;
		}

		// Token: 0x060276DC RID: 161500 RVA: 0x009F1A5F File Offset: 0x009EFC5F
		protected override IntPtr GetUStructPtr()
		{
			return ST_MatReplace.StaticStruct();
		}

		// Token: 0x060276DD RID: 161501 RVA: 0x009F1A6B File Offset: 0x009EFC6B
		[NullableContext(2)]
		public ST_MatReplace(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060276DE RID: 161502 RVA: 0x009F1A75 File Offset: 0x009EFC75
		public ST_MatReplace(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060276DF RID: 161503 RVA: 0x009F1A80 File Offset: 0x009EFC80
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new ST_MatReplace(Pointer, false, true);
		}

		// Token: 0x060276E0 RID: 161504 RVA: 0x009F1A8A File Offset: 0x009EFC8A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new ST_MatReplace(Pointer, MemoryOwner);
		}

		// Token: 0x04014A63 RID: 84579
		public const string __ObjectPath = "/Game/Aki/Data/ModelMat/ST_MatReplace.ST_MatReplace";

		// Token: 0x04014A64 RID: 84580
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014A65 RID: 84581
		internal static int __PropertyOffset_0;

		// Token: 0x04014A66 RID: 84582
		internal static int __PropertyOffset_1;

		// Token: 0x04014A67 RID: 84583
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _Materials;
	}
}
