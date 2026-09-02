using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.LensFlare
{
	// Token: 0x02003CD3 RID: 15571
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/LensFlare/SLensFlareConfig.SLensFlareConfig")]
	[UnrealStructLayout(48, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SLensFlareConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025215 RID: 152085 RVA: 0x009B1A0A File Offset: 0x009AFC0A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLensFlareConfig._ScriptStructPtr != 0) ? SLensFlareConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/LensFlare/SLensFlareConfig.SLensFlareConfig", ref SLensFlareConfig._ScriptStructPtr);
		}

		// Token: 0x17004FD1 RID: 20433
		// (get) Token: 0x06025216 RID: 152086 RVA: 0x009B1A2E File Offset: 0x009AFC2E
		// (set) Token: 0x06025217 RID: 152087 RVA: 0x009B1A42 File Offset: 0x009AFC42
		public unsafe FVector2D UVCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004FD2 RID: 20434
		// (get) Token: 0x06025218 RID: 152088 RVA: 0x009B1A57 File Offset: 0x009AFC57
		// (set) Token: 0x06025219 RID: 152089 RVA: 0x009B1A6B File Offset: 0x009AFC6B
		public unsafe FVector2D UVSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004FD3 RID: 20435
		// (get) Token: 0x0602521A RID: 152090 RVA: 0x009B1A80 File Offset: 0x009AFC80
		// (set) Token: 0x0602521B RID: 152091 RVA: 0x009B1A94 File Offset: 0x009AFC94
		public unsafe FVector2D LensFlareScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004FD4 RID: 20436
		// (get) Token: 0x0602521C RID: 152092 RVA: 0x009B1AA9 File Offset: 0x009AFCA9
		// (set) Token: 0x0602521D RID: 152093 RVA: 0x009B1AB9 File Offset: 0x009AFCB9
		public unsafe float LensFlareOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004FD5 RID: 20437
		// (get) Token: 0x0602521E RID: 152094 RVA: 0x009B1ACA File Offset: 0x009AFCCA
		// (set) Token: 0x0602521F RID: 152095 RVA: 0x009B1ADA File Offset: 0x009AFCDA
		public unsafe float LensFlareRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004FD6 RID: 20438
		// (get) Token: 0x06025220 RID: 152096 RVA: 0x009B1AEB File Offset: 0x009AFCEB
		// (set) Token: 0x06025221 RID: 152097 RVA: 0x009B1AFF File Offset: 0x009AFCFF
		public unsafe FLinearColor LensFlareTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLensFlareConfig.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06025222 RID: 152098 RVA: 0x009B1B14 File Offset: 0x009AFD14
		public SLensFlareConfig()
		{
		}

		// Token: 0x06025223 RID: 152099 RVA: 0x009B1B1C File Offset: 0x009AFD1C
		public SLensFlareConfig(FVector2D UVCenter, FVector2D UVSize, FVector2D LensFlareScale, float LensFlareOffset, float LensFlareRotation, FLinearColor LensFlareTint)
		{
			this.UVCenter = UVCenter;
			this.UVSize = UVSize;
			this.LensFlareScale = LensFlareScale;
			this.LensFlareOffset = LensFlareOffset;
			this.LensFlareRotation = LensFlareRotation;
			this.LensFlareTint = LensFlareTint;
		}

		// Token: 0x06025224 RID: 152100 RVA: 0x009B1B51 File Offset: 0x009AFD51
		protected override IntPtr GetUStructPtr()
		{
			return SLensFlareConfig.StaticStruct();
		}

		// Token: 0x06025225 RID: 152101 RVA: 0x009B1B5D File Offset: 0x009AFD5D
		[NullableContext(2)]
		public SLensFlareConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025226 RID: 152102 RVA: 0x009B1B67 File Offset: 0x009AFD67
		public SLensFlareConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025227 RID: 152103 RVA: 0x009B1B72 File Offset: 0x009AFD72
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SLensFlareConfig(Pointer, false, true);
		}

		// Token: 0x06025228 RID: 152104 RVA: 0x009B1B7C File Offset: 0x009AFD7C
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SLensFlareConfig(Pointer, MemoryOwner);
		}

		// Token: 0x040131D1 RID: 78289
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/LensFlare/SLensFlareConfig.SLensFlareConfig";

		// Token: 0x040131D2 RID: 78290
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040131D3 RID: 78291
		internal static int __PropertyOffset_0;

		// Token: 0x040131D4 RID: 78292
		internal static int __PropertyOffset_1;

		// Token: 0x040131D5 RID: 78293
		internal static int __PropertyOffset_2;

		// Token: 0x040131D6 RID: 78294
		internal static int __PropertyOffset_3;

		// Token: 0x040131D7 RID: 78295
		internal static int __PropertyOffset_4;

		// Token: 0x040131D8 RID: 78296
		internal static int __PropertyOffset_5;
	}
}
