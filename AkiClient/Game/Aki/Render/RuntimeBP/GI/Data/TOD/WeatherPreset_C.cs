using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CDA RID: 15578
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WeatherPreset.WeatherPreset_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WeatherPreset_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252BB RID: 152251 RVA: 0x009B2778 File Offset: 0x009B0978
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WeatherPreset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WeatherPreset.WeatherPreset_C");
			}
			return WeatherPreset_C._ClassPtr;
		}

		// Token: 0x060252BC RID: 152252 RVA: 0x009B279C File Offset: 0x009B099C
		public WeatherPreset_C() : this(BuiltinUtils.AllocNativeUObject(WeatherPreset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252BD RID: 152253 RVA: 0x009B27C4 File Offset: 0x009B09C4
		public WeatherPreset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WeatherPreset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700500E RID: 20494
		// (get) Token: 0x060252BE RID: 152254 RVA: 0x009B27F8 File Offset: 0x009B09F8
		// (set) Token: 0x060252BF RID: 152255 RVA: 0x009B2831 File Offset: 0x009B0A31
		public WeatherData Data
		{
			get
			{
				base.FastCheckIsValid();
				WeatherData result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new WeatherData(base.NativePtr + (IntPtr)WeatherPreset_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(WeatherData.StaticStruct(), base.NativePtr + (IntPtr)WeatherPreset_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060252C0 RID: 152256 RVA: 0x009B2852 File Offset: 0x009B0A52
		protected WeatherPreset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013223 RID: 78371
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WeatherPreset.WeatherPreset_C";

		// Token: 0x04013224 RID: 78372
		private static IntPtr _ClassPtr;

		// Token: 0x04013225 RID: 78373
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013226 RID: 78374
		internal static int __PropertyOffset_0;

		// Token: 0x04013227 RID: 78375
		[Nullable(2)]
		private WeatherData _Data;
	}
}
