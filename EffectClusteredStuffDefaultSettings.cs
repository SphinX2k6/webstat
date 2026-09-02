using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003409 RID: 13321
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/ClusteredStuff/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/ClusteredStuff/EffectClusteredStuffDefaultSettings.EffectClusteredStuffDefaultSettings_C")]
public class EffectClusteredStuffDefaultSettings : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025A8 RID: 9640
	// (get) Token: 0x0601BD14 RID: 113940 RVA: 0x0084C930 File Offset: 0x0084AB30
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<EffectClusteredStuffSettings> Settings
	{
		get
		{
			base.FastCheckIsValid();
			TArray<EffectClusteredStuffSettings> result;
			if ((result = this._Settings) == null)
			{
				result = (this._Settings = new TArray<EffectClusteredStuffSettings>(base.NativePtr + (IntPtr)EffectClusteredStuffDefaultSettings.__PropertyOffset_Settings, this));
			}
			return result;
		}
	}

	// Token: 0x0601BD15 RID: 113941 RVA: 0x0084C969 File Offset: 0x0084AB69
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectClusteredStuffDefaultSettings._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/ClusteredStuff/EffectClusteredStuffDefaultSettings.EffectClusteredStuffDefaultSettings_C");
		}
		return EffectClusteredStuffDefaultSettings._ClassPtr;
	}

	// Token: 0x0601BD16 RID: 113942 RVA: 0x0084C990 File Offset: 0x0084AB90
	public EffectClusteredStuffDefaultSettings() : this(BuiltinUtils.AllocNativeUObject(EffectClusteredStuffDefaultSettings.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD17 RID: 113943 RVA: 0x0084C9B8 File Offset: 0x0084ABB8
	public EffectClusteredStuffDefaultSettings(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectClusteredStuffDefaultSettings.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD18 RID: 113944 RVA: 0x0084C9EB File Offset: 0x0084ABEB
	protected EffectClusteredStuffDefaultSettings(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E099 RID: 57497
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/ClusteredStuff/EffectClusteredStuffDefaultSettings.EffectClusteredStuffDefaultSettings_C";

	// Token: 0x0400E09A RID: 57498
	private static IntPtr _ClassPtr;

	// Token: 0x0400E09B RID: 57499
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E09C RID: 57500
	private static int __PropertyOffset_Settings;

	// Token: 0x0400E09D RID: 57501
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<EffectClusteredStuffSettings> _Settings;
}
