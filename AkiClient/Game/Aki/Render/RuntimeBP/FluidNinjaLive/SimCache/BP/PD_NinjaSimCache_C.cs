using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.SimCache.BP
{
	// Token: 0x02003D00 RID: 15616
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/SimCache/BP/PD_NinjaSimCache.PD_NinjaSimCache_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_NinjaSimCache_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025A55 RID: 154197 RVA: 0x009BFAE7 File Offset: 0x009BDCE7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_NinjaSimCache_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/SimCache/BP/PD_NinjaSimCache.PD_NinjaSimCache_C");
			}
			return PD_NinjaSimCache_C._ClassPtr;
		}

		// Token: 0x06025A56 RID: 154198 RVA: 0x009BFB0C File Offset: 0x009BDD0C
		public PD_NinjaSimCache_C() : this(BuiltinUtils.AllocNativeUObject(PD_NinjaSimCache_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025A57 RID: 154199 RVA: 0x009BFB34 File Offset: 0x009BDD34
		public PD_NinjaSimCache_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_NinjaSimCache_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005313 RID: 21267
		// (get) Token: 0x06025A58 RID: 154200 RVA: 0x009BFB68 File Offset: 0x009BDD68
		// (set) Token: 0x06025A59 RID: 154201 RVA: 0x009BFBA1 File Offset: 0x009BDDA1
		public TMap<string, UTexture2D> CachedSimMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, UTexture2D> result;
				if ((result = this._CachedSimMap) == null)
				{
					result = (this._CachedSimMap = new TMap<string, UTexture2D>(base.NativePtr + (IntPtr)PD_NinjaSimCache_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.CachedSimMap.CopyAssign(value);
			}
		}

		// Token: 0x06025A5A RID: 154202 RVA: 0x009BFBAF File Offset: 0x009BDDAF
		protected PD_NinjaSimCache_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040136C4 RID: 79556
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/SimCache/BP/PD_NinjaSimCache.PD_NinjaSimCache_C";

		// Token: 0x040136C5 RID: 79557
		private static IntPtr _ClassPtr;

		// Token: 0x040136C6 RID: 79558
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040136C7 RID: 79559
		internal static int __PropertyOffset_0;

		// Token: 0x040136C8 RID: 79560
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, UTexture2D> _CachedSimMap;
	}
}
