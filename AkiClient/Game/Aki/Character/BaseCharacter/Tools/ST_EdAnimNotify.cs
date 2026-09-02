using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools
{
	// Token: 0x02004292 RID: 17042
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/ST_EdAnimNotify.ST_EdAnimNotify")]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 12)]
	public class ST_EdAnimNotify : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D42B RID: 185387 RVA: 0x00ABB5FC File Offset: 0x00AB97FC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (ST_EdAnimNotify._ScriptStructPtr != 0) ? ST_EdAnimNotify._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Tools/ST_EdAnimNotify.ST_EdAnimNotify", ref ST_EdAnimNotify._ScriptStructPtr);
		}

		// Token: 0x17007B5C RID: 31580
		// (get) Token: 0x0602D42C RID: 185388 RVA: 0x00ABB620 File Offset: 0x00AB9820
		// (set) Token: 0x0602D42D RID: 185389 RVA: 0x00ABB634 File Offset: 0x00AB9834
		public unsafe FGameplayTag tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ST_EdAnimNotify.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ST_EdAnimNotify.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D42E RID: 185390 RVA: 0x00ABB649 File Offset: 0x00AB9849
		public ST_EdAnimNotify()
		{
		}

		// Token: 0x0602D42F RID: 185391 RVA: 0x00ABB651 File Offset: 0x00AB9851
		public ST_EdAnimNotify(FGameplayTag tag)
		{
			this.tag = tag;
		}

		// Token: 0x0602D430 RID: 185392 RVA: 0x00ABB660 File Offset: 0x00AB9860
		protected override IntPtr GetUStructPtr()
		{
			return ST_EdAnimNotify.StaticStruct();
		}

		// Token: 0x0602D431 RID: 185393 RVA: 0x00ABB66C File Offset: 0x00AB986C
		[NullableContext(2)]
		public ST_EdAnimNotify(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D432 RID: 185394 RVA: 0x00ABB676 File Offset: 0x00AB9876
		public ST_EdAnimNotify(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D433 RID: 185395 RVA: 0x00ABB681 File Offset: 0x00AB9881
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new ST_EdAnimNotify(Pointer, false, true);
		}

		// Token: 0x0602D434 RID: 185396 RVA: 0x00ABB68B File Offset: 0x00AB988B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new ST_EdAnimNotify(Pointer, MemoryOwner);
		}

		// Token: 0x04019600 RID: 103936
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Tools/ST_EdAnimNotify.ST_EdAnimNotify";

		// Token: 0x04019601 RID: 103937
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019602 RID: 103938
		internal static int __PropertyOffset_0;
	}
}
