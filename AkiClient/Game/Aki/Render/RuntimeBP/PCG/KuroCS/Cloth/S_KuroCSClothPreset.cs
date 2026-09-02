using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.Cloth
{
	// Token: 0x02003C01 RID: 15361
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/S_KuroCSClothPreset.S_KuroCSClothPreset")]
	[UnrealStructLayout(80, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 77)]
	public class S_KuroCSClothPreset : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06022C8F RID: 142479 RVA: 0x0096F088 File Offset: 0x0096D288
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_KuroCSClothPreset._ScriptStructPtr != 0) ? S_KuroCSClothPreset._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/S_KuroCSClothPreset.S_KuroCSClothPreset", ref S_KuroCSClothPreset._ScriptStructPtr);
		}

		// Token: 0x170042B5 RID: 17077
		// (get) Token: 0x06022C90 RID: 142480 RVA: 0x0096F0AC File Offset: 0x0096D2AC
		// (set) Token: 0x06022C91 RID: 142481 RVA: 0x0096F0BC File Offset: 0x0096D2BC
		public unsafe int XCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170042B6 RID: 17078
		// (get) Token: 0x06022C92 RID: 142482 RVA: 0x0096F0CD File Offset: 0x0096D2CD
		// (set) Token: 0x06022C93 RID: 142483 RVA: 0x0096F0DD File Offset: 0x0096D2DD
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170042B7 RID: 17079
		// (get) Token: 0x06022C94 RID: 142484 RVA: 0x0096F0EE File Offset: 0x0096D2EE
		// (set) Token: 0x06022C95 RID: 142485 RVA: 0x0096F0FE File Offset: 0x0096D2FE
		public unsafe float DisStiffness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170042B8 RID: 17080
		// (get) Token: 0x06022C96 RID: 142486 RVA: 0x0096F10F File Offset: 0x0096D30F
		// (set) Token: 0x06022C97 RID: 142487 RVA: 0x0096F11F File Offset: 0x0096D31F
		public unsafe float BendStiffness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170042B9 RID: 17081
		// (get) Token: 0x06022C98 RID: 142488 RVA: 0x0096F130 File Offset: 0x0096D330
		// (set) Token: 0x06022C99 RID: 142489 RVA: 0x0096F140 File Offset: 0x0096D340
		public unsafe float CollisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170042BA RID: 17082
		// (get) Token: 0x06022C9A RID: 142490 RVA: 0x0096F151 File Offset: 0x0096D351
		// (set) Token: 0x06022C9B RID: 142491 RVA: 0x0096F161 File Offset: 0x0096D361
		public unsafe float LinkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170042BB RID: 17083
		// (get) Token: 0x06022C9C RID: 142492 RVA: 0x0096F172 File Offset: 0x0096D372
		// (set) Token: 0x06022C9D RID: 142493 RVA: 0x0096F182 File Offset: 0x0096D382
		public unsafe float LinkDisY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170042BC RID: 17084
		// (get) Token: 0x06022C9E RID: 142494 RVA: 0x0096F193 File Offset: 0x0096D393
		// (set) Token: 0x06022C9F RID: 142495 RVA: 0x0096F1A7 File Offset: 0x0096D3A7
		public unsafe FVector AccelExt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170042BD RID: 17085
		// (get) Token: 0x06022CA0 RID: 142496 RVA: 0x0096F1BC File Offset: 0x0096D3BC
		// (set) Token: 0x06022CA1 RID: 142497 RVA: 0x0096F1D0 File Offset: 0x0096D3D0
		public unsafe FVector PosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170042BE RID: 17086
		// (get) Token: 0x06022CA2 RID: 142498 RVA: 0x0096F1E5 File Offset: 0x0096D3E5
		// (set) Token: 0x06022CA3 RID: 142499 RVA: 0x0096F1F5 File Offset: 0x0096D3F5
		public unsafe int SubstepCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170042BF RID: 17087
		// (get) Token: 0x06022CA4 RID: 142500 RVA: 0x0096F206 File Offset: 0x0096D406
		// (set) Token: 0x06022CA5 RID: 142501 RVA: 0x0096F216 File Offset: 0x0096D416
		public unsafe bool bYZPlane
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042C0 RID: 17088
		// (get) Token: 0x06022CA6 RID: 142502 RVA: 0x0096F227 File Offset: 0x0096D427
		// (set) Token: 0x06022CA7 RID: 142503 RVA: 0x0096F237 File Offset: 0x0096D437
		public unsafe bool bFlipNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042C1 RID: 17089
		// (get) Token: 0x06022CA8 RID: 142504 RVA: 0x0096F248 File Offset: 0x0096D448
		// (set) Token: 0x06022CA9 RID: 142505 RVA: 0x0096F258 File Offset: 0x0096D458
		public unsafe float deltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170042C2 RID: 17090
		// (get) Token: 0x06022CAA RID: 142506 RVA: 0x0096F269 File Offset: 0x0096D469
		// (set) Token: 0x06022CAB RID: 142507 RVA: 0x0096F279 File Offset: 0x0096D479
		public unsafe bool bHypotenuseConstraint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042C3 RID: 17091
		// (get) Token: 0x06022CAC RID: 142508 RVA: 0x0096F28A File Offset: 0x0096D48A
		// (set) Token: 0x06022CAD RID: 142509 RVA: 0x0096F29A File Offset: 0x0096D49A
		public unsafe float gravityZeroDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170042C4 RID: 17092
		// (get) Token: 0x06022CAE RID: 142510 RVA: 0x0096F2AB File Offset: 0x0096D4AB
		// (set) Token: 0x06022CAF RID: 142511 RVA: 0x0096F2BB File Offset: 0x0096D4BB
		public unsafe float collisionFriction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170042C5 RID: 17093
		// (get) Token: 0x06022CB0 RID: 142512 RVA: 0x0096F2CC File Offset: 0x0096D4CC
		// (set) Token: 0x06022CB1 RID: 142513 RVA: 0x0096F2DC File Offset: 0x0096D4DC
		public unsafe bool bDisableBoxCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPreset.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022CB2 RID: 142514 RVA: 0x0096F2ED File Offset: 0x0096D4ED
		public S_KuroCSClothPreset()
		{
		}

		// Token: 0x06022CB3 RID: 142515 RVA: 0x0096F2F8 File Offset: 0x0096D4F8
		public S_KuroCSClothPreset(int XCount, int YCount, float DisStiffness, float BendStiffness, float CollisionR, float LinkDis, float LinkDisY, FVector AccelExt, FVector PosOffset, int SubstepCount, bool bYZPlane, bool bFlipNormal, float deltaTime, bool bHypotenuseConstraint, float gravityZeroDistance, float collisionFriction, bool bDisableBoxCollision)
		{
			this.XCount = XCount;
			this.YCount = YCount;
			this.DisStiffness = DisStiffness;
			this.BendStiffness = BendStiffness;
			this.CollisionR = CollisionR;
			this.LinkDis = LinkDis;
			this.LinkDisY = LinkDisY;
			this.AccelExt = AccelExt;
			this.PosOffset = PosOffset;
			this.SubstepCount = SubstepCount;
			this.bYZPlane = bYZPlane;
			this.bFlipNormal = bFlipNormal;
			this.deltaTime = deltaTime;
			this.bHypotenuseConstraint = bHypotenuseConstraint;
			this.gravityZeroDistance = gravityZeroDistance;
			this.collisionFriction = collisionFriction;
			this.bDisableBoxCollision = bDisableBoxCollision;
		}

		// Token: 0x06022CB4 RID: 142516 RVA: 0x0096F390 File Offset: 0x0096D590
		protected override IntPtr GetUStructPtr()
		{
			return S_KuroCSClothPreset.StaticStruct();
		}

		// Token: 0x06022CB5 RID: 142517 RVA: 0x0096F39C File Offset: 0x0096D59C
		[NullableContext(2)]
		public S_KuroCSClothPreset(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022CB6 RID: 142518 RVA: 0x0096F3A6 File Offset: 0x0096D5A6
		public S_KuroCSClothPreset(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022CB7 RID: 142519 RVA: 0x0096F3B1 File Offset: 0x0096D5B1
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_KuroCSClothPreset(Pointer, false, true);
		}

		// Token: 0x06022CB8 RID: 142520 RVA: 0x0096F3BB File Offset: 0x0096D5BB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_KuroCSClothPreset(Pointer, MemoryOwner);
		}

		// Token: 0x04011A56 RID: 72278
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/S_KuroCSClothPreset.S_KuroCSClothPreset";

		// Token: 0x04011A57 RID: 72279
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011A58 RID: 72280
		internal static int __PropertyOffset_0;

		// Token: 0x04011A59 RID: 72281
		internal static int __PropertyOffset_1;

		// Token: 0x04011A5A RID: 72282
		internal static int __PropertyOffset_2;

		// Token: 0x04011A5B RID: 72283
		internal static int __PropertyOffset_3;

		// Token: 0x04011A5C RID: 72284
		internal static int __PropertyOffset_4;

		// Token: 0x04011A5D RID: 72285
		internal static int __PropertyOffset_5;

		// Token: 0x04011A5E RID: 72286
		internal static int __PropertyOffset_6;

		// Token: 0x04011A5F RID: 72287
		internal static int __PropertyOffset_7;

		// Token: 0x04011A60 RID: 72288
		internal static int __PropertyOffset_8;

		// Token: 0x04011A61 RID: 72289
		internal static int __PropertyOffset_9;

		// Token: 0x04011A62 RID: 72290
		internal static int __PropertyOffset_10;

		// Token: 0x04011A63 RID: 72291
		internal static int __PropertyOffset_11;

		// Token: 0x04011A64 RID: 72292
		internal static int __PropertyOffset_12;

		// Token: 0x04011A65 RID: 72293
		internal static int __PropertyOffset_13;

		// Token: 0x04011A66 RID: 72294
		internal static int __PropertyOffset_14;

		// Token: 0x04011A67 RID: 72295
		internal static int __PropertyOffset_15;

		// Token: 0x04011A68 RID: 72296
		internal static int __PropertyOffset_16;
	}
}
