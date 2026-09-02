using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UI.ActorComponent
{
	// Token: 0x02003A26 RID: 14886
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UI/ActorComponent/S_UIitemOffset.S_UIitemOffset")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class S_UIitemOffset : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601E9F4 RID: 125428 RVA: 0x008F9D58 File Offset: 0x008F7F58
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_UIitemOffset._ScriptStructPtr != 0) ? S_UIitemOffset._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/UI/ActorComponent/S_UIitemOffset.S_UIitemOffset", ref S_UIitemOffset._ScriptStructPtr);
		}

		// Token: 0x17002B8F RID: 11151
		// (get) Token: 0x0601E9F5 RID: 125429 RVA: 0x008F9D7C File Offset: 0x008F7F7C
		// (set) Token: 0x0601E9F6 RID: 125430 RVA: 0x008F9D90 File Offset: 0x008F7F90
		[Nullable(2)]
		public unsafe AUIBaseActor UIActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUIBaseActor>(base.NativePtr / (IntPtr)sizeof(void*) + S_UIitemOffset.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_UIitemOffset.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002B90 RID: 11152
		// (get) Token: 0x0601E9F7 RID: 125431 RVA: 0x008F9DA5 File Offset: 0x008F7FA5
		// (set) Token: 0x0601E9F8 RID: 125432 RVA: 0x008F9DB9 File Offset: 0x008F7FB9
		public unsafe FVector2D MaxOffsetXY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_UIitemOffset.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_UIitemOffset.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0601E9F9 RID: 125433 RVA: 0x008F9DCE File Offset: 0x008F7FCE
		public S_UIitemOffset()
		{
		}

		// Token: 0x0601E9FA RID: 125434 RVA: 0x008F9DD6 File Offset: 0x008F7FD6
		[NullableContext(1)]
		public S_UIitemOffset(AUIBaseActor UIActor, FVector2D MaxOffsetXY)
		{
			this.UIActor = UIActor;
			this.MaxOffsetXY = MaxOffsetXY;
		}

		// Token: 0x0601E9FB RID: 125435 RVA: 0x008F9DEC File Offset: 0x008F7FEC
		protected override IntPtr GetUStructPtr()
		{
			return S_UIitemOffset.StaticStruct();
		}

		// Token: 0x0601E9FC RID: 125436 RVA: 0x008F9DF8 File Offset: 0x008F7FF8
		[NullableContext(2)]
		public S_UIitemOffset(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E9FD RID: 125437 RVA: 0x008F9E02 File Offset: 0x008F8002
		public S_UIitemOffset(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E9FE RID: 125438 RVA: 0x008F9E0D File Offset: 0x008F800D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_UIitemOffset(Pointer, false, true);
		}

		// Token: 0x0601E9FF RID: 125439 RVA: 0x008F9E17 File Offset: 0x008F8017
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_UIitemOffset(Pointer, MemoryOwner);
		}

		// Token: 0x0400F194 RID: 61844
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UI/ActorComponent/S_UIitemOffset.S_UIitemOffset";

		// Token: 0x0400F195 RID: 61845
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F196 RID: 61846
		internal static int __PropertyOffset_0;

		// Token: 0x0400F197 RID: 61847
		internal static int __PropertyOffset_1;
	}
}
