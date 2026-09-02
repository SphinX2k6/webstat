using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004267 RID: 16999
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SHitMapping.SHitMapping")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SHitMapping : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D115 RID: 184597 RVA: 0x00AB6A10 File Offset: 0x00AB4C10
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SHitMapping._ScriptStructPtr != 0) ? SHitMapping._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SHitMapping.SHitMapping", ref SHitMapping._ScriptStructPtr);
		}

		// Token: 0x17007A66 RID: 31334
		// (get) Token: 0x0602D116 RID: 184598 RVA: 0x00AB6A34 File Offset: 0x00AB4C34
		// (set) Token: 0x0602D117 RID: 184599 RVA: 0x00AB6A44 File Offset: 0x00AB4C44
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitMapping.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitMapping.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A67 RID: 31335
		// (get) Token: 0x0602D118 RID: 184600 RVA: 0x00AB6A58 File Offset: 0x00AB4C58
		// (set) Token: 0x0602D119 RID: 184601 RVA: 0x00AB6A9B File Offset: 0x00AB4C9B
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EHitAnim>> 映射表
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EHitAnim>> result;
				if ((result = this._映射表) == null)
				{
					result = (this._映射表 = new TArray<TEnumAsByte<EHitAnim>>(base.NativePtr + (IntPtr)SHitMapping.__PropertyOffset_1, base.MemoryOwner ?? this));
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
				this.映射表.CopyAssign(value);
			}
		}

		// Token: 0x17007A68 RID: 31336
		// (get) Token: 0x0602D11A RID: 184602 RVA: 0x00AB6AA9 File Offset: 0x00AB4CA9
		// (set) Token: 0x0602D11B RID: 184603 RVA: 0x00AB6ABD File Offset: 0x00AB4CBD
		public unsafe string 备注
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SHitMapping.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SHitMapping.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x0602D11C RID: 184604 RVA: 0x00AB6AD2 File Offset: 0x00AB4CD2
		public SHitMapping()
		{
		}

		// Token: 0x0602D11D RID: 184605 RVA: 0x00AB6ADA File Offset: 0x00AB4CDA
		public SHitMapping(int ID, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<EHitAnim>> 映射表, string 备注)
		{
			this.ID = ID;
			this.映射表 = 映射表;
			this.备注 = 备注;
		}

		// Token: 0x0602D11E RID: 184606 RVA: 0x00AB6AF7 File Offset: 0x00AB4CF7
		protected override IntPtr GetUStructPtr()
		{
			return SHitMapping.StaticStruct();
		}

		// Token: 0x0602D11F RID: 184607 RVA: 0x00AB6B03 File Offset: 0x00AB4D03
		[NullableContext(2)]
		public SHitMapping(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D120 RID: 184608 RVA: 0x00AB6B0D File Offset: 0x00AB4D0D
		public SHitMapping(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D121 RID: 184609 RVA: 0x00AB6B18 File Offset: 0x00AB4D18
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SHitMapping(Pointer, false, true);
		}

		// Token: 0x0602D122 RID: 184610 RVA: 0x00AB6B22 File Offset: 0x00AB4D22
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SHitMapping(Pointer, MemoryOwner);
		}

		// Token: 0x0401945A RID: 103514
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SHitMapping.SHitMapping";

		// Token: 0x0401945B RID: 103515
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401945C RID: 103516
		internal static int __PropertyOffset_0;

		// Token: 0x0401945D RID: 103517
		internal static int __PropertyOffset_1;

		// Token: 0x0401945E RID: 103518
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EHitAnim>> _映射表;

		// Token: 0x0401945F RID: 103519
		internal static int __PropertyOffset_2;
	}
}
