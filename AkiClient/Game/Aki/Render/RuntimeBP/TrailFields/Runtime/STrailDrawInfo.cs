using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime
{
	// Token: 0x02003A2D RID: 14893
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/STrailDrawInfo.STrailDrawInfo")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class STrailDrawInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EA8D RID: 125581 RVA: 0x008FB017 File Offset: 0x008F9217
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (STrailDrawInfo._ScriptStructPtr != 0) ? STrailDrawInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/STrailDrawInfo.STrailDrawInfo", ref STrailDrawInfo._ScriptStructPtr);
		}

		// Token: 0x17002BC1 RID: 11201
		// (get) Token: 0x0601EA8E RID: 125582 RVA: 0x008FB03B File Offset: 0x008F923B
		// (set) Token: 0x0601EA8F RID: 125583 RVA: 0x008FB04F File Offset: 0x008F924F
		public unsafe FVector2D Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)STrailDrawInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)STrailDrawInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17002BC2 RID: 11202
		// (get) Token: 0x0601EA90 RID: 125584 RVA: 0x008FB064 File Offset: 0x008F9264
		// (set) Token: 0x0601EA91 RID: 125585 RVA: 0x008FB078 File Offset: 0x008F9278
		[Nullable(2)]
		public unsafe UTexture texture
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + STrailDrawInfo.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + STrailDrawInfo.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002BC3 RID: 11203
		// (get) Token: 0x0601EA92 RID: 125586 RVA: 0x008FB08D File Offset: 0x008F928D
		// (set) Token: 0x0601EA93 RID: 125587 RVA: 0x008FB0A1 File Offset: 0x008F92A1
		public unsafe FVector2D Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)STrailDrawInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)STrailDrawInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002BC4 RID: 11204
		// (get) Token: 0x0601EA94 RID: 125588 RVA: 0x008FB0B6 File Offset: 0x008F92B6
		// (set) Token: 0x0601EA95 RID: 125589 RVA: 0x008FB0C6 File Offset: 0x008F92C6
		public unsafe float Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)STrailDrawInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)STrailDrawInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002BC5 RID: 11205
		// (get) Token: 0x0601EA96 RID: 125590 RVA: 0x008FB0D7 File Offset: 0x008F92D7
		// (set) Token: 0x0601EA97 RID: 125591 RVA: 0x008FB0E7 File Offset: 0x008F92E7
		public unsafe float Depth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)STrailDrawInfo.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)STrailDrawInfo.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0601EA98 RID: 125592 RVA: 0x008FB0F8 File Offset: 0x008F92F8
		public STrailDrawInfo()
		{
		}

		// Token: 0x0601EA99 RID: 125593 RVA: 0x008FB100 File Offset: 0x008F9300
		[NullableContext(1)]
		public STrailDrawInfo(FVector2D Position, UTexture texture, FVector2D Size, float Rotation, float Depth)
		{
			this.Position = Position;
			this.texture = texture;
			this.Size = Size;
			this.Rotation = Rotation;
			this.Depth = Depth;
		}

		// Token: 0x0601EA9A RID: 125594 RVA: 0x008FB12D File Offset: 0x008F932D
		protected override IntPtr GetUStructPtr()
		{
			return STrailDrawInfo.StaticStruct();
		}

		// Token: 0x0601EA9B RID: 125595 RVA: 0x008FB139 File Offset: 0x008F9339
		[NullableContext(2)]
		public STrailDrawInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EA9C RID: 125596 RVA: 0x008FB143 File Offset: 0x008F9343
		public STrailDrawInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EA9D RID: 125597 RVA: 0x008FB14E File Offset: 0x008F934E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new STrailDrawInfo(Pointer, false, true);
		}

		// Token: 0x0601EA9E RID: 125598 RVA: 0x008FB158 File Offset: 0x008F9358
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new STrailDrawInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0400F1FB RID: 61947
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/STrailDrawInfo.STrailDrawInfo";

		// Token: 0x0400F1FC RID: 61948
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F1FD RID: 61949
		internal static int __PropertyOffset_0;

		// Token: 0x0400F1FE RID: 61950
		internal static int __PropertyOffset_1;

		// Token: 0x0400F1FF RID: 61951
		internal static int __PropertyOffset_2;

		// Token: 0x0400F200 RID: 61952
		internal static int __PropertyOffset_3;

		// Token: 0x0400F201 RID: 61953
		internal static int __PropertyOffset_4;
	}
}
