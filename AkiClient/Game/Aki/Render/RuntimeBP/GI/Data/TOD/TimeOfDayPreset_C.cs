using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CD8 RID: 15576
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayPreset.TimeOfDayPreset_C")]
	[UnrealStructLayout(216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 212)]
	public class TimeOfDayPreset_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025277 RID: 152183 RVA: 0x009B21D0 File Offset: 0x009B03D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (TimeOfDayPreset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayPreset.TimeOfDayPreset_C");
			}
			return TimeOfDayPreset_C._ClassPtr;
		}

		// Token: 0x06025278 RID: 152184 RVA: 0x009B21F4 File Offset: 0x009B03F4
		public TimeOfDayPreset_C() : this(BuiltinUtils.AllocNativeUObject(TimeOfDayPreset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025279 RID: 152185 RVA: 0x009B221C File Offset: 0x009B041C
		public TimeOfDayPreset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TimeOfDayPreset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004FF2 RID: 20466
		// (get) Token: 0x0602527A RID: 152186 RVA: 0x009B2250 File Offset: 0x009B0450
		// (set) Token: 0x0602527B RID: 152187 RVA: 0x009B2289 File Offset: 0x009B0489
		public TimeOfDayData Data
		{
			get
			{
				base.FastCheckIsValid();
				TimeOfDayData result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new TimeOfDayData(base.NativePtr + (IntPtr)TimeOfDayPreset_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(TimeOfDayData.StaticStruct(), base.NativePtr + (IntPtr)TimeOfDayPreset_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602527C RID: 152188 RVA: 0x009B22AA File Offset: 0x009B04AA
		protected TimeOfDayPreset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013201 RID: 78337
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayPreset.TimeOfDayPreset_C";

		// Token: 0x04013202 RID: 78338
		private static IntPtr _ClassPtr;

		// Token: 0x04013203 RID: 78339
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013204 RID: 78340
		internal static int __PropertyOffset_0;

		// Token: 0x04013205 RID: 78341
		[Nullable(2)]
		private TimeOfDayData _Data;
	}
}
