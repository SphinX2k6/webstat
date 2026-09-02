using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E6E RID: 3694
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Define/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Define/CounterAttackEffectData.CounterAttackEffectData_C")]
public class CounterAttackEffectData : UKuroBpDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000650 RID: 1616
	// (get) Token: 0x060059D8 RID: 23000 RVA: 0x0010CAB0 File Offset: 0x0010ACB0
	// (set) Token: 0x060059D9 RID: 23001 RVA: 0x0010CAC0 File Offset: 0x0010ACC0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Pos
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CounterAttackEffectData.__PropertyOffset_Pos);
		}
		set
		{
			*(base.NativePtr + (IntPtr)CounterAttackEffectData.__PropertyOffset_Pos) = value;
		}
	}

	// Token: 0x17000651 RID: 1617
	// (get) Token: 0x060059DA RID: 23002 RVA: 0x0010CAD1 File Offset: 0x0010ACD1
	// (set) Token: 0x060059DB RID: 23003 RVA: 0x0010CAE5 File Offset: 0x0010ACE5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector Offset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CounterAttackEffectData.__PropertyOffset_Offset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)CounterAttackEffectData.__PropertyOffset_Offset) = value;
		}
	}

	// Token: 0x17000652 RID: 1618
	// (get) Token: 0x060059DC RID: 23004 RVA: 0x0010CAFA File Offset: 0x0010ACFA
	// (set) Token: 0x060059DD RID: 23005 RVA: 0x0010CB0E File Offset: 0x0010AD0E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector Scale
	{
		get
		{
			return *(base.NativePtr + (IntPtr)CounterAttackEffectData.__PropertyOffset_Scale);
		}
		set
		{
			*(base.NativePtr + (IntPtr)CounterAttackEffectData.__PropertyOffset_Scale) = value;
		}
	}

	// Token: 0x17000653 RID: 1619
	// (get) Token: 0x060059DE RID: 23006 RVA: 0x0010CB24 File Offset: 0x0010AD24
	// (set) Token: 0x060059DF RID: 23007 RVA: 0x0010CB5D File Offset: 0x0010AD5D
	[UProperty(EPropertyFlags.CPF_None)]
	public FSoftObjectPath EffectDA
	{
		get
		{
			base.FastCheckIsValid();
			FSoftObjectPath result;
			if ((result = this._EffectDA) == null)
			{
				result = (this._EffectDA = new FSoftObjectPath(base.NativePtr + (IntPtr)CounterAttackEffectData.__PropertyOffset_EffectDA, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)CounterAttackEffectData.__PropertyOffset_EffectDA, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x060059E0 RID: 23008 RVA: 0x0010CB85 File Offset: 0x0010AD85
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (CounterAttackEffectData._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Define/CounterAttackEffectData.CounterAttackEffectData_C");
		}
		return CounterAttackEffectData._ClassPtr;
	}

	// Token: 0x060059E1 RID: 23009 RVA: 0x0010CBAC File Offset: 0x0010ADAC
	public CounterAttackEffectData() : this(BuiltinUtils.AllocNativeUObject(CounterAttackEffectData.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060059E2 RID: 23010 RVA: 0x0010CBD4 File Offset: 0x0010ADD4
	public CounterAttackEffectData(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CounterAttackEffectData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060059E3 RID: 23011 RVA: 0x0010CC07 File Offset: 0x0010AE07
	protected CounterAttackEffectData(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x040029A2 RID: 10658
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Define/CounterAttackEffectData.CounterAttackEffectData_C";

	// Token: 0x040029A3 RID: 10659
	private static IntPtr _ClassPtr;

	// Token: 0x040029A4 RID: 10660
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040029A5 RID: 10661
	private static int __PropertyOffset_Pos;

	// Token: 0x040029A6 RID: 10662
	private static int __PropertyOffset_Offset;

	// Token: 0x040029A7 RID: 10663
	private static int __PropertyOffset_Scale;

	// Token: 0x040029A8 RID: 10664
	private static int __PropertyOffset_EffectDA;

	// Token: 0x040029A9 RID: 10665
	[Nullable(2)]
	private FSoftObjectPath _EffectDA;
}
