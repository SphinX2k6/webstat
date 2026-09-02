using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP.Thunder
{
	// Token: 0x02003A04 RID: 14852
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_ThunderConfigMap.PDA_ThunderConfigMap_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PDA_ThunderConfigMap_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E434 RID: 123956 RVA: 0x008F136C File Offset: 0x008EF56C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_ThunderConfigMap_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_ThunderConfigMap.PDA_ThunderConfigMap_C");
			}
			return PDA_ThunderConfigMap_C._ClassPtr;
		}

		// Token: 0x0601E435 RID: 123957 RVA: 0x008F1390 File Offset: 0x008EF590
		public PDA_ThunderConfigMap_C() : this(BuiltinUtils.AllocNativeUObject(PDA_ThunderConfigMap_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E436 RID: 123958 RVA: 0x008F13B8 File Offset: 0x008EF5B8
		[NullableContext(1)]
		public PDA_ThunderConfigMap_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_ThunderConfigMap_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700293C RID: 10556
		// (get) Token: 0x0601E437 RID: 123959 RVA: 0x008F13EC File Offset: 0x008EF5EC
		// (set) Token: 0x0601E438 RID: 123960 RVA: 0x008F1425 File Offset: 0x008EF625
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EKuroThunderType>, PDA_ThunderConfig_C> Data
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EKuroThunderType>, PDA_ThunderConfig_C> result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new TMap<TEnumAsByte<EKuroThunderType>, PDA_ThunderConfig_C>(base.NativePtr + (IntPtr)PDA_ThunderConfigMap_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.Data.CopyAssign(value);
			}
		}

		// Token: 0x0601E439 RID: 123961 RVA: 0x008F1433 File Offset: 0x008EF633
		protected PDA_ThunderConfigMap_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EE17 RID: 60951
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_ThunderConfigMap.PDA_ThunderConfigMap_C";

		// Token: 0x0400EE18 RID: 60952
		private static IntPtr _ClassPtr;

		// Token: 0x0400EE19 RID: 60953
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EE1A RID: 60954
		internal static int __PropertyOffset_0;

		// Token: 0x0400EE1B RID: 60955
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EKuroThunderType>, PDA_ThunderConfig_C> _Data;
	}
}
