using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBigAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA018
{
	// Token: 0x0200416C RID: 16748
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA018/BP_NA018.BP_NA018_C")]
	[UnrealStructLayout(2288, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2280)]
	public class BP_NA018_C : BP_CommonBigAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6DF RID: 181983 RVA: 0x00AA1180 File Offset: 0x00A9F380
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA018_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA018/BP_NA018.BP_NA018_C");
			}
			return BP_NA018_C._ClassPtr;
		}

		// Token: 0x0602C6E0 RID: 181984 RVA: 0x00AA11A4 File Offset: 0x00A9F3A4
		public BP_NA018_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA018_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6E1 RID: 181985 RVA: 0x00AA11CC File Offset: 0x00A9F3CC
		public BP_NA018_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA018_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007773 RID: 30579
		// (get) Token: 0x0602C6E2 RID: 181986 RVA: 0x00AA11FF File Offset: 0x00A9F3FF
		// (set) Token: 0x0602C6E3 RID: 181987 RVA: 0x00AA1213 File Offset: 0x00A9F413
		[Nullable(2)]
		public unsafe UCapsuleComponent Bip001Spine1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA018_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA018_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007774 RID: 30580
		// (get) Token: 0x0602C6E4 RID: 181988 RVA: 0x00AA1228 File Offset: 0x00A9F428
		// (set) Token: 0x0602C6E5 RID: 181989 RVA: 0x00AA123C File Offset: 0x00A9F43C
		[Nullable(2)]
		public unsafe UCapsuleComponent Bip001Head
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA018_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA018_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007775 RID: 30581
		// (get) Token: 0x0602C6E6 RID: 181990 RVA: 0x00AA1254 File Offset: 0x00A9F454
		// (set) Token: 0x0602C6E7 RID: 181991 RVA: 0x00AA128D File Offset: 0x00A9F48D
		public TArray<string> SocketNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._SocketNames) == null)
				{
					result = (this._SocketNames = new TArray<string>(base.NativePtr + (IntPtr)BP_NA018_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.SocketNames.CopyAssign(value);
			}
		}

		// Token: 0x17007776 RID: 30582
		// (get) Token: 0x0602C6E8 RID: 181992 RVA: 0x00AA129C File Offset: 0x00A9F49C
		// (set) Token: 0x0602C6E9 RID: 181993 RVA: 0x00AA12D5 File Offset: 0x00A9F4D5
		public TArray<FVector> Size
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Size) == null)
				{
					result = (this._Size = new TArray<FVector>(base.NativePtr + (IntPtr)BP_NA018_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Size.CopyAssign(value);
			}
		}

		// Token: 0x0602C6EA RID: 181994 RVA: 0x00AA12E3 File Offset: 0x00A9F4E3
		protected BP_NA018_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AC1 RID: 101057
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA018/BP_NA018.BP_NA018_C";

		// Token: 0x04018AC2 RID: 101058
		private static IntPtr _ClassPtr;

		// Token: 0x04018AC3 RID: 101059
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018AC4 RID: 101060
		internal new static int __PropertyOffset_0;

		// Token: 0x04018AC5 RID: 101061
		internal static int __PropertyOffset_1;

		// Token: 0x04018AC6 RID: 101062
		internal static int __PropertyOffset_2;

		// Token: 0x04018AC7 RID: 101063
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _SocketNames;

		// Token: 0x04018AC8 RID: 101064
		internal static int __PropertyOffset_3;

		// Token: 0x04018AC9 RID: 101065
		[Nullable(2)]
		private TArray<FVector> _Size;
	}
}
