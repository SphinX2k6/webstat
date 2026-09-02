using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D91 RID: 3473
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSubMeshFreeze.TsAnimNotifyStateSubMeshFreeze_C")]
public class TsAnimNotifyStateSubMeshFreeze : UKuroAnimNotifyState, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700049F RID: 1183
	// (get) Token: 0x06004CF7 RID: 19703 RVA: 0x000AC8FB File Offset: 0x000AAAFB
	// (set) Token: 0x06004CF8 RID: 19704 RVA: 0x000AC90F File Offset: 0x000AAB0F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string MeshName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_MeshName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_MeshName)), value);
		}
	}

	// Token: 0x170004A0 RID: 1184
	// (get) Token: 0x06004CF9 RID: 19705 RVA: 0x000AC924 File Offset: 0x000AAB24
	// (set) Token: 0x06004CFA RID: 19706 RVA: 0x000AC934 File Offset: 0x000AAB34
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 开始是否可见
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_开始是否可见) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_开始是否可见) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004A1 RID: 1185
	// (get) Token: 0x06004CFB RID: 19707 RVA: 0x000AC945 File Offset: 0x000AAB45
	// (set) Token: 0x06004CFC RID: 19708 RVA: 0x000AC959 File Offset: 0x000AAB59
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C 开始材质
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_开始材质);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_开始材质, value);
		}
	}

	// Token: 0x170004A2 RID: 1186
	// (get) Token: 0x06004CFD RID: 19709 RVA: 0x000AC970 File Offset: 0x000AAB70
	// (set) Token: 0x06004CFE RID: 19710 RVA: 0x000AC9A9 File Offset: 0x000AABA9
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> 开始特效
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._开始特效) == null)
			{
				result = (this._开始特效 = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_开始特效, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_开始特效, 1);
		}
	}

	// Token: 0x170004A3 RID: 1187
	// (get) Token: 0x06004CFF RID: 19711 RVA: 0x000AC9CE File Offset: 0x000AABCE
	// (set) Token: 0x06004D00 RID: 19712 RVA: 0x000AC9DE File Offset: 0x000AABDE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 结束是否可见
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_结束是否可见) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_结束是否可见) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004A4 RID: 1188
	// (get) Token: 0x06004D01 RID: 19713 RVA: 0x000AC9EF File Offset: 0x000AABEF
	// (set) Token: 0x06004D02 RID: 19714 RVA: 0x000ACA03 File Offset: 0x000AAC03
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C 结束材质
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_结束材质);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_结束材质, value);
		}
	}

	// Token: 0x170004A5 RID: 1189
	// (get) Token: 0x06004D03 RID: 19715 RVA: 0x000ACA18 File Offset: 0x000AAC18
	// (set) Token: 0x06004D04 RID: 19716 RVA: 0x000ACA51 File Offset: 0x000AAC51
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> 结束特效
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._结束特效) == null)
			{
				result = (this._结束特效 = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_结束特效, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_结束特效, 1);
		}
	}

	// Token: 0x170004A6 RID: 1190
	// (get) Token: 0x06004D05 RID: 19717 RVA: 0x000ACA76 File Offset: 0x000AAC76
	// (set) Token: 0x06004D06 RID: 19718 RVA: 0x000ACA86 File Offset: 0x000AAC86
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否冻结
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_是否冻结) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_是否冻结) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004A7 RID: 1191
	// (get) Token: 0x06004D07 RID: 19719 RVA: 0x000ACA97 File Offset: 0x000AAC97
	// (set) Token: 0x06004D08 RID: 19720 RVA: 0x000ACAA7 File Offset: 0x000AACA7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 快照延迟时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_快照延迟时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_快照延迟时间) = value;
		}
	}

	// Token: 0x170004A8 RID: 1192
	// (get) Token: 0x06004D09 RID: 19721 RVA: 0x000ACAB8 File Offset: 0x000AACB8
	// (set) Token: 0x06004D0A RID: 19722 RVA: 0x000ACACC File Offset: 0x000AACCC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag EnableTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_EnableTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSubMeshFreeze.__PropertyOffset_EnableTag) = value;
		}
	}

	// Token: 0x06004D0B RID: 19723 RVA: 0x000ACAE4 File Offset: 0x000AACE4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.ActivateSet == null)
		{
			this.ActivateSet = new HashSet<USkeletalMeshComponent>();
		}
		if (this.BeginTimeMap == null)
		{
			this.BeginTimeMap = new Dictionary<USkeletalMeshComponent, double>();
		}
		if (this.TotalDurationMap == null)
		{
			this.TotalDurationMap = new Dictionary<USkeletalMeshComponent, float>();
		}
		if (this.SnapshotTimerMap == null)
		{
			this.SnapshotTimerMap = new Dictionary<USkeletalMeshComponent, TimerHandle>();
		}
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = (aactor as TsBaseCharacter).GetEntityNoBlueprint();
		SubMeshComponent subMeshComp = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<SubMeshComponent>() : null;
		if (subMeshComp == null)
		{
			return false;
		}
		if (this.EnableTag.TagName != "None")
		{
			BaseTagComponent baseTagComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent == null)
			{
				return false;
			}
			if (!baseTagComponent.HasTag(this.EnableTag.TagId()))
			{
				return false;
			}
		}
		this.ActivateSet.Add(meshComp);
		this.BeginTimeMap[meshComp] = Singleton<Time>.Instance.NowSeconds;
		this.TotalDurationMap[meshComp] = totalDuration;
		subMeshComp.ShowSubMeshWithEffect(this.MeshName, this.开始是否可见, this.开始材质, this.开始特效);
		subMeshComp.SnapshotSubMesh(this.MeshName);
		if (this.快照延迟时间 > 0f)
		{
			string meshName = this.MeshName;
			USkeletalMeshComponent capturedMeshComp = meshComp;
			TimerHandle value = TimerSystem.Instance.Delay(delegate(float delta)
			{
				subMeshComp.SnapshotSubMesh(meshName);
				this.SnapshotTimerMap.Remove(capturedMeshComp);
			}, this.快照延迟时间 * 1000f, null, null, true, 1f);
			this.SnapshotTimerMap[meshComp] = value;
		}
		return true;
	}

	// Token: 0x06004D0C RID: 19724 RVA: 0x000ACC8C File Offset: 0x000AAE8C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		HashSet<USkeletalMeshComponent> activateSet = this.ActivateSet;
		if (activateSet == null || !activateSet.Contains(meshComp))
		{
			return false;
		}
		this.ActivateSet.Remove(meshComp);
		TimerHandle timerHandle;
		if (this.SnapshotTimerMap.TryGetValue(meshComp, out timerHandle) && timerHandle != null)
		{
			TimerSystem.Instance.Remove(timerHandle);
			this.SnapshotTimerMap.Remove(meshComp);
		}
		double num2;
		double num = this.BeginTimeMap.TryGetValue(meshComp, out num2) ? num2 : Singleton<Time>.Instance.NowSeconds;
		float num4;
		float num3 = this.TotalDurationMap.TryGetValue(meshComp, out num4) ? num4 : 0f;
		this.BeginTimeMap.Remove(meshComp);
		this.TotalDurationMap.Remove(meshComp);
		double num5 = Singleton<Time>.Instance.NowSeconds - num;
		bool flag = num3 > 0f && (double)num3 - num5 > 0.05000000074505806;
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = (aactor as TsBaseCharacter).GetEntityNoBlueprint();
		SubMeshComponent subMeshComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<SubMeshComponent>() : null;
		if (subMeshComponent == null)
		{
			return false;
		}
		if (flag && this.是否冻结)
		{
			subMeshComponent.FreezeSubMeshWithEffect(this.MeshName, this.结束是否可见, this.结束材质, this.结束特效);
		}
		else
		{
			subMeshComponent.PlaySubMeshEffectOnly(this.MeshName, this.结束是否可见, this.结束材质, this.结束特效);
		}
		return true;
	}

	// Token: 0x06004D0D RID: 19725 RVA: 0x000ACDEF File Offset: 0x000AAFEF
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "子Mesh冻结控制";
	}

	// Token: 0x06004D0E RID: 19726 RVA: 0x000ACDF6 File Offset: 0x000AAFF6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSubMeshFreeze._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSubMeshFreeze.TsAnimNotifyStateSubMeshFreeze_C");
		}
		return TsAnimNotifyStateSubMeshFreeze._ClassPtr;
	}

	// Token: 0x06004D0F RID: 19727 RVA: 0x000ACE1C File Offset: 0x000AB01C
	public TsAnimNotifyStateSubMeshFreeze() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSubMeshFreeze.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004D10 RID: 19728 RVA: 0x000ACE44 File Offset: 0x000AB044
	public TsAnimNotifyStateSubMeshFreeze(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSubMeshFreeze.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004D11 RID: 19729 RVA: 0x000ACE77 File Offset: 0x000AB077
	protected TsAnimNotifyStateSubMeshFreeze(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004D12 RID: 19730 RVA: 0x000ACEAC File Offset: 0x000AB0AC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004D13 RID: 19731 RVA: 0x000ACEE8 File Offset: 0x000AB0E8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004D14 RID: 19732 RVA: 0x000ACF1B File Offset: 0x000AB11B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x04001614 RID: 5652
	private const float INTERRUPT_THRESHOLD = 0.05f;

	// Token: 0x04001615 RID: 5653
	private HashSet<USkeletalMeshComponent> ActivateSet = new HashSet<USkeletalMeshComponent>();

	// Token: 0x04001616 RID: 5654
	private Dictionary<USkeletalMeshComponent, double> BeginTimeMap = new Dictionary<USkeletalMeshComponent, double>();

	// Token: 0x04001617 RID: 5655
	private Dictionary<USkeletalMeshComponent, float> TotalDurationMap = new Dictionary<USkeletalMeshComponent, float>();

	// Token: 0x04001618 RID: 5656
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private Dictionary<USkeletalMeshComponent, TimerHandle> SnapshotTimerMap = new Dictionary<USkeletalMeshComponent, TimerHandle>();

	// Token: 0x04001619 RID: 5657
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSubMeshFreeze.TsAnimNotifyStateSubMeshFreeze_C";

	// Token: 0x0400161A RID: 5658
	private static IntPtr _ClassPtr;

	// Token: 0x0400161B RID: 5659
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400161C RID: 5660
	private static int __PropertyOffset_MeshName;

	// Token: 0x0400161D RID: 5661
	private static int __PropertyOffset_开始是否可见;

	// Token: 0x0400161E RID: 5662
	private static int __PropertyOffset_开始材质;

	// Token: 0x0400161F RID: 5663
	private static int __PropertyOffset_开始特效;

	// Token: 0x04001620 RID: 5664
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _开始特效;

	// Token: 0x04001621 RID: 5665
	private static int __PropertyOffset_结束是否可见;

	// Token: 0x04001622 RID: 5666
	private static int __PropertyOffset_结束材质;

	// Token: 0x04001623 RID: 5667
	private static int __PropertyOffset_结束特效;

	// Token: 0x04001624 RID: 5668
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _结束特效;

	// Token: 0x04001625 RID: 5669
	private static int __PropertyOffset_是否冻结;

	// Token: 0x04001626 RID: 5670
	private static int __PropertyOffset_快照延迟时间;

	// Token: 0x04001627 RID: 5671
	private static int __PropertyOffset_EnableTag;
}
