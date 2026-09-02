using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Recorder
{
	// Token: 0x02003E14 RID: 15892
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Recorder/BP_GameplayCueBeamDataAsset.BP_GameplayCueBeamDataAsset_C")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 112)]
	public class BP_GameplayCueBeamDataAsset_C : UKuroBpDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060272B6 RID: 160438 RVA: 0x009EB618 File Offset: 0x009E9818
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GameplayCueBeamDataAsset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Recorder/BP_GameplayCueBeamDataAsset.BP_GameplayCueBeamDataAsset_C");
			}
			return BP_GameplayCueBeamDataAsset_C._ClassPtr;
		}

		// Token: 0x060272B7 RID: 160439 RVA: 0x009EB63C File Offset: 0x009E983C
		public BP_GameplayCueBeamDataAsset_C() : this(BuiltinUtils.AllocNativeUObject(BP_GameplayCueBeamDataAsset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060272B8 RID: 160440 RVA: 0x009EB664 File Offset: 0x009E9864
		public BP_GameplayCueBeamDataAsset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GameplayCueBeamDataAsset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005B6F RID: 23407
		// (get) Token: 0x060272B9 RID: 160441 RVA: 0x009EB698 File Offset: 0x009E9898
		// (set) Token: 0x060272BA RID: 160442 RVA: 0x009EB6D1 File Offset: 0x009E98D1
		public TArray<float> TimeLine
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._TimeLine) == null)
				{
					result = (this._TimeLine = new TArray<float>(base.NativePtr + (IntPtr)BP_GameplayCueBeamDataAsset_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.TimeLine.CopyAssign(value);
			}
		}

		// Token: 0x17005B70 RID: 23408
		// (get) Token: 0x060272BB RID: 160443 RVA: 0x009EB6E0 File Offset: 0x009E98E0
		// (set) Token: 0x060272BC RID: 160444 RVA: 0x009EB719 File Offset: 0x009E9919
		public TArray<SVectorArray> PointPositions
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SVectorArray> result;
				if ((result = this._PointPositions) == null)
				{
					result = (this._PointPositions = new TArray<SVectorArray>(base.NativePtr + (IntPtr)BP_GameplayCueBeamDataAsset_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.PointPositions.CopyAssign(value);
			}
		}

		// Token: 0x060272BD RID: 160445 RVA: 0x009EB727 File Offset: 0x009E9927
		protected BP_GameplayCueBeamDataAsset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401477E RID: 83838
		public new const string __ObjectPath = "/Game/Aki/Data/Recorder/BP_GameplayCueBeamDataAsset.BP_GameplayCueBeamDataAsset_C";

		// Token: 0x0401477F RID: 83839
		private static IntPtr _ClassPtr;

		// Token: 0x04014780 RID: 83840
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014781 RID: 83841
		internal static int __PropertyOffset_0;

		// Token: 0x04014782 RID: 83842
		[Nullable(2)]
		private TArray<float> _TimeLine;

		// Token: 0x04014783 RID: 83843
		internal static int __PropertyOffset_1;

		// Token: 0x04014784 RID: 83844
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SVectorArray> _PointPositions;
	}
}
