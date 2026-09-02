using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Foliage
{
	// Token: 0x02003CEC RID: 15596
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Foliage/Struct_TranslucentFoliage.Struct_TranslucentFoliage")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 104)]
	public class Struct_TranslucentFoliage : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060253F3 RID: 152563 RVA: 0x009B51FF File Offset: 0x009B33FF
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_TranslucentFoliage._ScriptStructPtr != 0) ? Struct_TranslucentFoliage._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Foliage/Struct_TranslucentFoliage.Struct_TranslucentFoliage", ref Struct_TranslucentFoliage._ScriptStructPtr);
		}

		// Token: 0x17005068 RID: 20584
		// (get) Token: 0x060253F4 RID: 152564 RVA: 0x009B5223 File Offset: 0x009B3423
		// (set) Token: 0x060253F5 RID: 152565 RVA: 0x009B5237 File Offset: 0x009B3437
		[Nullable(2)]
		public unsafe UStaticMesh StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_TranslucentFoliage.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_TranslucentFoliage.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005069 RID: 20585
		// (get) Token: 0x060253F6 RID: 152566 RVA: 0x009B524C File Offset: 0x009B344C
		// (set) Token: 0x060253F7 RID: 152567 RVA: 0x009B528F File Offset: 0x009B348F
		public TArray<UMaterialInterface> PCMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._PCMaterials) == null)
				{
					result = (this._PCMaterials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)Struct_TranslucentFoliage.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PCMaterials.CopyAssign(value);
			}
		}

		// Token: 0x1700506A RID: 20586
		// (get) Token: 0x060253F8 RID: 152568 RVA: 0x009B52A0 File Offset: 0x009B34A0
		// (set) Token: 0x060253F9 RID: 152569 RVA: 0x009B52E3 File Offset: 0x009B34E3
		public TArray<UMaterialInterface> PCMaterialsOffFade
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._PCMaterialsOffFade) == null)
				{
					result = (this._PCMaterialsOffFade = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)Struct_TranslucentFoliage.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PCMaterialsOffFade.CopyAssign(value);
			}
		}

		// Token: 0x1700506B RID: 20587
		// (get) Token: 0x060253FA RID: 152570 RVA: 0x009B52F4 File Offset: 0x009B34F4
		// (set) Token: 0x060253FB RID: 152571 RVA: 0x009B5337 File Offset: 0x009B3537
		public TArray<UMaterialInterface> MobileMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._MobileMaterials) == null)
				{
					result = (this._MobileMaterials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)Struct_TranslucentFoliage.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MobileMaterials.CopyAssign(value);
			}
		}

		// Token: 0x1700506C RID: 20588
		// (get) Token: 0x060253FC RID: 152572 RVA: 0x009B5348 File Offset: 0x009B3548
		// (set) Token: 0x060253FD RID: 152573 RVA: 0x009B538B File Offset: 0x009B358B
		public TArray<UMaterialInterface> MobileMaterialsOffFade
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._MobileMaterialsOffFade) == null)
				{
					result = (this._MobileMaterialsOffFade = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)Struct_TranslucentFoliage.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MobileMaterialsOffFade.CopyAssign(value);
			}
		}

		// Token: 0x1700506D RID: 20589
		// (get) Token: 0x060253FE RID: 152574 RVA: 0x009B539C File Offset: 0x009B359C
		// (set) Token: 0x060253FF RID: 152575 RVA: 0x009B53DF File Offset: 0x009B35DF
		public TArray<UMaterialInterface> PCMaterialsNoDissolve
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._PCMaterialsNoDissolve) == null)
				{
					result = (this._PCMaterialsNoDissolve = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)Struct_TranslucentFoliage.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PCMaterialsNoDissolve.CopyAssign(value);
			}
		}

		// Token: 0x1700506E RID: 20590
		// (get) Token: 0x06025400 RID: 152576 RVA: 0x009B53F0 File Offset: 0x009B35F0
		// (set) Token: 0x06025401 RID: 152577 RVA: 0x009B5433 File Offset: 0x009B3633
		public TArray<UMaterialInterface> MobileMaterialsNoDissolve
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._MobileMaterialsNoDissolve) == null)
				{
					result = (this._MobileMaterialsNoDissolve = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)Struct_TranslucentFoliage.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MobileMaterialsNoDissolve.CopyAssign(value);
			}
		}

		// Token: 0x06025402 RID: 152578 RVA: 0x009B5441 File Offset: 0x009B3641
		public Struct_TranslucentFoliage()
		{
		}

		// Token: 0x06025403 RID: 152579 RVA: 0x009B5449 File Offset: 0x009B3649
		public Struct_TranslucentFoliage(UStaticMesh StaticMesh, TArray<UMaterialInterface> PCMaterials, TArray<UMaterialInterface> PCMaterialsOffFade, TArray<UMaterialInterface> MobileMaterials, TArray<UMaterialInterface> MobileMaterialsOffFade, TArray<UMaterialInterface> PCMaterialsNoDissolve, TArray<UMaterialInterface> MobileMaterialsNoDissolve)
		{
			this.StaticMesh = StaticMesh;
			this.PCMaterials = PCMaterials;
			this.PCMaterialsOffFade = PCMaterialsOffFade;
			this.MobileMaterials = MobileMaterials;
			this.MobileMaterialsOffFade = MobileMaterialsOffFade;
			this.PCMaterialsNoDissolve = PCMaterialsNoDissolve;
			this.MobileMaterialsNoDissolve = MobileMaterialsNoDissolve;
		}

		// Token: 0x06025404 RID: 152580 RVA: 0x009B5486 File Offset: 0x009B3686
		protected override IntPtr GetUStructPtr()
		{
			return Struct_TranslucentFoliage.StaticStruct();
		}

		// Token: 0x06025405 RID: 152581 RVA: 0x009B5492 File Offset: 0x009B3692
		[NullableContext(2)]
		public Struct_TranslucentFoliage(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025406 RID: 152582 RVA: 0x009B549C File Offset: 0x009B369C
		public Struct_TranslucentFoliage(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025407 RID: 152583 RVA: 0x009B54A7 File Offset: 0x009B36A7
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_TranslucentFoliage(Pointer, false, true);
		}

		// Token: 0x06025408 RID: 152584 RVA: 0x009B54B1 File Offset: 0x009B36B1
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_TranslucentFoliage(Pointer, MemoryOwner);
		}

		// Token: 0x040132F9 RID: 78585
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Foliage/Struct_TranslucentFoliage.Struct_TranslucentFoliage";

		// Token: 0x040132FA RID: 78586
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040132FB RID: 78587
		internal static int __PropertyOffset_0;

		// Token: 0x040132FC RID: 78588
		internal static int __PropertyOffset_1;

		// Token: 0x040132FD RID: 78589
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _PCMaterials;

		// Token: 0x040132FE RID: 78590
		internal static int __PropertyOffset_2;

		// Token: 0x040132FF RID: 78591
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _PCMaterialsOffFade;

		// Token: 0x04013300 RID: 78592
		internal static int __PropertyOffset_3;

		// Token: 0x04013301 RID: 78593
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _MobileMaterials;

		// Token: 0x04013302 RID: 78594
		internal static int __PropertyOffset_4;

		// Token: 0x04013303 RID: 78595
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _MobileMaterialsOffFade;

		// Token: 0x04013304 RID: 78596
		internal static int __PropertyOffset_5;

		// Token: 0x04013305 RID: 78597
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _PCMaterialsNoDissolve;

		// Token: 0x04013306 RID: 78598
		internal static int __PropertyOffset_6;

		// Token: 0x04013307 RID: 78599
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _MobileMaterialsNoDissolve;
	}
}
