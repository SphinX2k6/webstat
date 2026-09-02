using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools.Data.Struct
{
	// Token: 0x02004294 RID: 17044
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SAnimCurveModify.SAnimCurveModify")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SAnimCurveModify : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D441 RID: 185409 RVA: 0x00ABB75C File Offset: 0x00AB995C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAnimCurveModify._ScriptStructPtr != 0) ? SAnimCurveModify._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SAnimCurveModify.SAnimCurveModify", ref SAnimCurveModify._ScriptStructPtr);
		}

		// Token: 0x17007B5F RID: 31583
		// (get) Token: 0x0602D442 RID: 185410 RVA: 0x00ABB780 File Offset: 0x00AB9980
		// (set) Token: 0x0602D443 RID: 185411 RVA: 0x00ABB794 File Offset: 0x00AB9994
		public unsafe string AnimSequenceNamePreFix
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SAnimCurveModify.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SAnimCurveModify.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B60 RID: 31584
		// (get) Token: 0x0602D444 RID: 185412 RVA: 0x00ABB7A9 File Offset: 0x00AB99A9
		// (set) Token: 0x0602D445 RID: 185413 RVA: 0x00ABB7BD File Offset: 0x00AB99BD
		public unsafe FName CurveName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnimCurveModify.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnimCurveModify.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007B61 RID: 31585
		// (get) Token: 0x0602D446 RID: 185414 RVA: 0x00ABB7D2 File Offset: 0x00AB99D2
		// (set) Token: 0x0602D447 RID: 185415 RVA: 0x00ABB7E2 File Offset: 0x00AB99E2
		public unsafe float CurveValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnimCurveModify.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnimCurveModify.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D448 RID: 185416 RVA: 0x00ABB7F3 File Offset: 0x00AB99F3
		public SAnimCurveModify()
		{
		}

		// Token: 0x0602D449 RID: 185417 RVA: 0x00ABB7FB File Offset: 0x00AB99FB
		public SAnimCurveModify(string AnimSequenceNamePreFix, FName CurveName, float CurveValue)
		{
			this.AnimSequenceNamePreFix = AnimSequenceNamePreFix;
			this.CurveName = CurveName;
			this.CurveValue = CurveValue;
		}

		// Token: 0x0602D44A RID: 185418 RVA: 0x00ABB818 File Offset: 0x00AB9A18
		protected override IntPtr GetUStructPtr()
		{
			return SAnimCurveModify.StaticStruct();
		}

		// Token: 0x0602D44B RID: 185419 RVA: 0x00ABB824 File Offset: 0x00AB9A24
		[NullableContext(2)]
		public SAnimCurveModify(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D44C RID: 185420 RVA: 0x00ABB82E File Offset: 0x00AB9A2E
		public SAnimCurveModify(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D44D RID: 185421 RVA: 0x00ABB839 File Offset: 0x00AB9A39
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAnimCurveModify(Pointer, false, true);
		}

		// Token: 0x0602D44E RID: 185422 RVA: 0x00ABB843 File Offset: 0x00AB9A43
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAnimCurveModify(Pointer, MemoryOwner);
		}

		// Token: 0x04019607 RID: 103943
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SAnimCurveModify.SAnimCurveModify";

		// Token: 0x04019608 RID: 103944
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019609 RID: 103945
		internal static int __PropertyOffset_0;

		// Token: 0x0401960A RID: 103946
		internal static int __PropertyOffset_1;

		// Token: 0x0401960B RID: 103947
		internal static int __PropertyOffset_2;
	}
}
