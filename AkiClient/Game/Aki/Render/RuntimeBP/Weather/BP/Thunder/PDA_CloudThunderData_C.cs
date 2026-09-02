using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP.Thunder
{
	// Token: 0x02003A03 RID: 14851
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_CloudThunderData.PDA_CloudThunderData_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class PDA_CloudThunderData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E42E RID: 123950 RVA: 0x008F1299 File Offset: 0x008EF499
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_CloudThunderData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_CloudThunderData.PDA_CloudThunderData_C");
			}
			return PDA_CloudThunderData_C._ClassPtr;
		}

		// Token: 0x0601E42F RID: 123951 RVA: 0x008F12C0 File Offset: 0x008EF4C0
		public PDA_CloudThunderData_C() : this(BuiltinUtils.AllocNativeUObject(PDA_CloudThunderData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E430 RID: 123952 RVA: 0x008F12E8 File Offset: 0x008EF4E8
		public PDA_CloudThunderData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_CloudThunderData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700293B RID: 10555
		// (get) Token: 0x0601E431 RID: 123953 RVA: 0x008F131C File Offset: 0x008EF51C
		// (set) Token: 0x0601E432 RID: 123954 RVA: 0x008F1355 File Offset: 0x008EF555
		public TArray<SCloudThunderInfo> DataInfos
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCloudThunderInfo> result;
				if ((result = this._DataInfos) == null)
				{
					result = (this._DataInfos = new TArray<SCloudThunderInfo>(base.NativePtr + (IntPtr)PDA_CloudThunderData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.DataInfos.CopyAssign(value);
			}
		}

		// Token: 0x0601E433 RID: 123955 RVA: 0x008F1363 File Offset: 0x008EF563
		protected PDA_CloudThunderData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EE12 RID: 60946
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_CloudThunderData.PDA_CloudThunderData_C";

		// Token: 0x0400EE13 RID: 60947
		private static IntPtr _ClassPtr;

		// Token: 0x0400EE14 RID: 60948
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EE15 RID: 60949
		internal static int __PropertyOffset_0;

		// Token: 0x0400EE16 RID: 60950
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCloudThunderInfo> _DataInfos;
	}
}
