using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AClusterBalloons
{
	// Token: 0x02003C4D RID: 15437
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/PD_BakedBalloon.PD_BakedBalloon_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_BakedBalloon_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602397A RID: 145786 RVA: 0x0098688B File Offset: 0x00984A8B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_BakedBalloon_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/PD_BakedBalloon.PD_BakedBalloon_C");
			}
			return PD_BakedBalloon_C._ClassPtr;
		}

		// Token: 0x0602397B RID: 145787 RVA: 0x009868B0 File Offset: 0x00984AB0
		public PD_BakedBalloon_C() : this(BuiltinUtils.AllocNativeUObject(PD_BakedBalloon_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602397C RID: 145788 RVA: 0x009868D8 File Offset: 0x00984AD8
		public PD_BakedBalloon_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_BakedBalloon_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700474E RID: 18254
		// (get) Token: 0x0602397D RID: 145789 RVA: 0x0098690C File Offset: 0x00984B0C
		// (set) Token: 0x0602397E RID: 145790 RVA: 0x00986945 File Offset: 0x00984B45
		public TMap<int, S_BakedBalloonSet> IntToBakedBalloons
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, S_BakedBalloonSet> result;
				if ((result = this._IntToBakedBalloons) == null)
				{
					result = (this._IntToBakedBalloons = new TMap<int, S_BakedBalloonSet>(base.NativePtr + (IntPtr)PD_BakedBalloon_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.IntToBakedBalloons.CopyAssign(value);
			}
		}

		// Token: 0x0602397F RID: 145791 RVA: 0x00986953 File Offset: 0x00984B53
		protected PD_BakedBalloon_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012210 RID: 74256
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/PD_BakedBalloon.PD_BakedBalloon_C";

		// Token: 0x04012211 RID: 74257
		private static IntPtr _ClassPtr;

		// Token: 0x04012212 RID: 74258
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012213 RID: 74259
		internal static int __PropertyOffset_0;

		// Token: 0x04012214 RID: 74260
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, S_BakedBalloonSet> _IntToBakedBalloons;
	}
}
