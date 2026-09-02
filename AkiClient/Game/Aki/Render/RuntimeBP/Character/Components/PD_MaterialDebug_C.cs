using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Components
{
	// Token: 0x02003D94 RID: 15764
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Components/PD_MaterialDebug.PD_MaterialDebug_C")]
	[UnrealStructLayout(400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 400)]
	public class PD_MaterialDebug_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026817 RID: 157719 RVA: 0x009DA2AB File Offset: 0x009D84AB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_MaterialDebug_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Components/PD_MaterialDebug.PD_MaterialDebug_C");
			}
			return PD_MaterialDebug_C._ClassPtr;
		}

		// Token: 0x06026818 RID: 157720 RVA: 0x009DA2D0 File Offset: 0x009D84D0
		public PD_MaterialDebug_C() : this(BuiltinUtils.AllocNativeUObject(PD_MaterialDebug_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026819 RID: 157721 RVA: 0x009DA2F8 File Offset: 0x009D84F8
		public PD_MaterialDebug_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_MaterialDebug_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170057AB RID: 22443
		// (get) Token: 0x0602681A RID: 157722 RVA: 0x009DA32C File Offset: 0x009D852C
		// (set) Token: 0x0602681B RID: 157723 RVA: 0x009DA365 File Offset: 0x009D8565
		public TMap<int, string> MaterialControllerList
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, string> result;
				if ((result = this._MaterialControllerList) == null)
				{
					result = (this._MaterialControllerList = new TMap<int, string>(base.NativePtr + (IntPtr)PD_MaterialDebug_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.MaterialControllerList.CopyAssign(value);
			}
		}

		// Token: 0x170057AC RID: 22444
		// (get) Token: 0x0602681C RID: 157724 RVA: 0x009DA374 File Offset: 0x009D8574
		// (set) Token: 0x0602681D RID: 157725 RVA: 0x009DA3AD File Offset: 0x009D85AD
		public TMap<string, SMaterialDebugInfo> Body
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, SMaterialDebugInfo> result;
				if ((result = this._Body) == null)
				{
					result = (this._Body = new TMap<string, SMaterialDebugInfo>(base.NativePtr + (IntPtr)PD_MaterialDebug_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.Body.CopyAssign(value);
			}
		}

		// Token: 0x170057AD RID: 22445
		// (get) Token: 0x0602681E RID: 157726 RVA: 0x009DA3BC File Offset: 0x009D85BC
		// (set) Token: 0x0602681F RID: 157727 RVA: 0x009DA3F5 File Offset: 0x009D85F5
		public TMap<string, SMaterialDebugInfo> Weapon
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, SMaterialDebugInfo> result;
				if ((result = this._Weapon) == null)
				{
					result = (this._Weapon = new TMap<string, SMaterialDebugInfo>(base.NativePtr + (IntPtr)PD_MaterialDebug_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.Weapon.CopyAssign(value);
			}
		}

		// Token: 0x170057AE RID: 22446
		// (get) Token: 0x06026820 RID: 157728 RVA: 0x009DA404 File Offset: 0x009D8604
		// (set) Token: 0x06026821 RID: 157729 RVA: 0x009DA43D File Offset: 0x009D863D
		public TMap<string, SMaterialDebugInfo> Hulu
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, SMaterialDebugInfo> result;
				if ((result = this._Hulu) == null)
				{
					result = (this._Hulu = new TMap<string, SMaterialDebugInfo>(base.NativePtr + (IntPtr)PD_MaterialDebug_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Hulu.CopyAssign(value);
			}
		}

		// Token: 0x06026822 RID: 157730 RVA: 0x009DA44B File Offset: 0x009D864B
		protected PD_MaterialDebug_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401404A RID: 81994
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Components/PD_MaterialDebug.PD_MaterialDebug_C";

		// Token: 0x0401404B RID: 81995
		private static IntPtr _ClassPtr;

		// Token: 0x0401404C RID: 81996
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401404D RID: 81997
		internal static int __PropertyOffset_0;

		// Token: 0x0401404E RID: 81998
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, string> _MaterialControllerList;

		// Token: 0x0401404F RID: 81999
		internal static int __PropertyOffset_1;

		// Token: 0x04014050 RID: 82000
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, SMaterialDebugInfo> _Body;

		// Token: 0x04014051 RID: 82001
		internal static int __PropertyOffset_2;

		// Token: 0x04014052 RID: 82002
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, SMaterialDebugInfo> _Weapon;

		// Token: 0x04014053 RID: 82003
		internal static int __PropertyOffset_3;

		// Token: 0x04014054 RID: 82004
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, SMaterialDebugInfo> _Hulu;
	}
}
