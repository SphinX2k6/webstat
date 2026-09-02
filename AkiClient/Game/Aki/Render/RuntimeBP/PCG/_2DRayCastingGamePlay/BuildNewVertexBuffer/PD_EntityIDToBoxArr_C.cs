using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG._2DRayCastingGamePlay.BuildNewVertexBuffer
{
	// Token: 0x02003C54 RID: 15444
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/PD_EntityIDToBoxArr.PD_EntityIDToBoxArr_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_EntityIDToBoxArr_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023A96 RID: 146070 RVA: 0x009888AB File Offset: 0x00986AAB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_EntityIDToBoxArr_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/PD_EntityIDToBoxArr.PD_EntityIDToBoxArr_C");
			}
			return PD_EntityIDToBoxArr_C._ClassPtr;
		}

		// Token: 0x06023A97 RID: 146071 RVA: 0x009888D0 File Offset: 0x00986AD0
		public PD_EntityIDToBoxArr_C() : this(BuiltinUtils.AllocNativeUObject(PD_EntityIDToBoxArr_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023A98 RID: 146072 RVA: 0x009888F8 File Offset: 0x00986AF8
		public PD_EntityIDToBoxArr_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_EntityIDToBoxArr_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170047B5 RID: 18357
		// (get) Token: 0x06023A99 RID: 146073 RVA: 0x0098892C File Offset: 0x00986B2C
		// (set) Token: 0x06023A9A RID: 146074 RVA: 0x00988965 File Offset: 0x00986B65
		public TMap<int, S_FSBoxArr> EntityIDToBoxArr
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, S_FSBoxArr> result;
				if ((result = this._EntityIDToBoxArr) == null)
				{
					result = (this._EntityIDToBoxArr = new TMap<int, S_FSBoxArr>(base.NativePtr + (IntPtr)PD_EntityIDToBoxArr_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.EntityIDToBoxArr.CopyAssign(value);
			}
		}

		// Token: 0x06023A9B RID: 146075 RVA: 0x00988973 File Offset: 0x00986B73
		protected PD_EntityIDToBoxArr_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040122E3 RID: 74467
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/PD_EntityIDToBoxArr.PD_EntityIDToBoxArr_C";

		// Token: 0x040122E4 RID: 74468
		private static IntPtr _ClassPtr;

		// Token: 0x040122E5 RID: 74469
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040122E6 RID: 74470
		internal static int __PropertyOffset_0;

		// Token: 0x040122E7 RID: 74471
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, S_FSBoxArr> _EntityIDToBoxArr;
	}
}
