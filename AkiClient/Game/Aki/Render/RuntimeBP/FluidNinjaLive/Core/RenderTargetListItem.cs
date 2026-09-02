using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D0F RID: 15631
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/RenderTargetListItem.RenderTargetListItem")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 9)]
	public class RenderTargetListItem : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025BEB RID: 154603 RVA: 0x009C3C29 File Offset: 0x009C1E29
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (RenderTargetListItem._ScriptStructPtr != 0) ? RenderTargetListItem._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/RenderTargetListItem.RenderTargetListItem", ref RenderTargetListItem._ScriptStructPtr);
		}

		// Token: 0x17005382 RID: 21378
		// (get) Token: 0x06025BEC RID: 154604 RVA: 0x009C3C4D File Offset: 0x009C1E4D
		// (set) Token: 0x06025BED RID: 154605 RVA: 0x009C3C61 File Offset: 0x009C1E61
		[Nullable(2)]
		public unsafe UTextureRenderTarget2D RT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + RenderTargetListItem.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + RenderTargetListItem.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005383 RID: 21379
		// (get) Token: 0x06025BEE RID: 154606 RVA: 0x009C3C76 File Offset: 0x009C1E76
		// (set) Token: 0x06025BEF RID: 154607 RVA: 0x009C3C86 File Offset: 0x009C1E86
		public unsafe bool free
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RenderTargetListItem.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)RenderTargetListItem.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025BF0 RID: 154608 RVA: 0x009C3C97 File Offset: 0x009C1E97
		public RenderTargetListItem()
		{
		}

		// Token: 0x06025BF1 RID: 154609 RVA: 0x009C3C9F File Offset: 0x009C1E9F
		[NullableContext(1)]
		public RenderTargetListItem(UTextureRenderTarget2D RT, bool free)
		{
			this.RT = RT;
			this.free = free;
		}

		// Token: 0x06025BF2 RID: 154610 RVA: 0x009C3CB5 File Offset: 0x009C1EB5
		protected override IntPtr GetUStructPtr()
		{
			return RenderTargetListItem.StaticStruct();
		}

		// Token: 0x06025BF3 RID: 154611 RVA: 0x009C3CC1 File Offset: 0x009C1EC1
		[NullableContext(2)]
		public RenderTargetListItem(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025BF4 RID: 154612 RVA: 0x009C3CCB File Offset: 0x009C1ECB
		public RenderTargetListItem(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025BF5 RID: 154613 RVA: 0x009C3CD6 File Offset: 0x009C1ED6
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new RenderTargetListItem(Pointer, false, true);
		}

		// Token: 0x06025BF6 RID: 154614 RVA: 0x009C3CE0 File Offset: 0x009C1EE0
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new RenderTargetListItem(Pointer, MemoryOwner);
		}

		// Token: 0x040137E6 RID: 79846
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/RenderTargetListItem.RenderTargetListItem";

		// Token: 0x040137E7 RID: 79847
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040137E8 RID: 79848
		internal static int __PropertyOffset_0;

		// Token: 0x040137E9 RID: 79849
		internal static int __PropertyOffset_1;
	}
}
