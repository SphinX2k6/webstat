using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.GamePlay.TriggerItems;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Season;
using CSharpScript.Game.NewWorld.TriggerItems.Model;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200325F RID: 12895
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsTriggerVolume.TsTriggerVolume_C")]
public class TsTriggerVolume : AKuroEffectActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002496 RID: 9366
	// (get) Token: 0x0601AE64 RID: 110180 RVA: 0x00806808 File Offset: 0x00804A08
	// (set) Token: 0x0601AE65 RID: 110181 RVA: 0x0080681C File Offset: 0x00804A1C
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ABrush TriggerItem
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ABrush>(base.NativePtr / (IntPtr)sizeof(void*) + TsTriggerVolume.__PropertyOffset_TriggerItem);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTriggerVolume.__PropertyOffset_TriggerItem, value);
		}
	}

	// Token: 0x17002497 RID: 9367
	// (get) Token: 0x0601AE66 RID: 110182 RVA: 0x00806834 File Offset: 0x00804A34
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<ABrush> TriggerItems
	{
		get
		{
			base.FastCheckIsValid();
			TArray<ABrush> result;
			if ((result = this._TriggerItems) == null)
			{
				result = (this._TriggerItems = new TArray<ABrush>(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerItems, this));
			}
			return result;
		}
	}

	// Token: 0x17002498 RID: 9368
	// (get) Token: 0x0601AE67 RID: 110183 RVA: 0x0080686D File Offset: 0x00804A6D
	// (set) Token: 0x0601AE68 RID: 110184 RVA: 0x0080687D File Offset: 0x00804A7D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AkiClient.Game.Aki.GamePlay.TriggerItems.ETriggerType TriggerType
	{
		get
		{
			return (AkiClient.Game.Aki.GamePlay.TriggerItems.ETriggerType)(*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerType) = (byte)value;
		}
	}

	// Token: 0x17002499 RID: 9369
	// (get) Token: 0x0601AE69 RID: 110185 RVA: 0x0080688E File Offset: 0x00804A8E
	// (set) Token: 0x0601AE6A RID: 110186 RVA: 0x0080689E File Offset: 0x00804A9E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TriggerGroup
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerGroup);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerGroup) = value;
		}
	}

	// Token: 0x1700249A RID: 9370
	// (get) Token: 0x0601AE6B RID: 110187 RVA: 0x008068AF File Offset: 0x00804AAF
	// (set) Token: 0x0601AE6C RID: 110188 RVA: 0x008068BF File Offset: 0x00804ABF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TriggerId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerId) = value;
		}
	}

	// Token: 0x1700249B RID: 9371
	// (get) Token: 0x0601AE6D RID: 110189 RVA: 0x008068D0 File Offset: 0x00804AD0
	// (set) Token: 0x0601AE6E RID: 110190 RVA: 0x008068E4 File Offset: 0x00804AE4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ConditionGroupId
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTriggerVolume.__PropertyOffset_ConditionGroupId)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTriggerVolume.__PropertyOffset_ConditionGroupId)), value);
		}
	}

	// Token: 0x1700249C RID: 9372
	// (get) Token: 0x0601AE6F RID: 110191 RVA: 0x008068F9 File Offset: 0x00804AF9
	// (set) Token: 0x0601AE70 RID: 110192 RVA: 0x0080690D File Offset: 0x00804B0D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string EventGroupId
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTriggerVolume.__PropertyOffset_EventGroupId)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTriggerVolume.__PropertyOffset_EventGroupId)), value);
		}
	}

	// Token: 0x1700249D RID: 9373
	// (get) Token: 0x0601AE71 RID: 110193 RVA: 0x00806922 File Offset: 0x00804B22
	// (set) Token: 0x0601AE72 RID: 110194 RVA: 0x00806936 File Offset: 0x00804B36
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ExitEventGroupId
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTriggerVolume.__PropertyOffset_ExitEventGroupId)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTriggerVolume.__PropertyOffset_ExitEventGroupId)), value);
		}
	}

	// Token: 0x1700249E RID: 9374
	// (get) Token: 0x0601AE73 RID: 110195 RVA: 0x0080694B File Offset: 0x00804B4B
	// (set) Token: 0x0601AE74 RID: 110196 RVA: 0x0080695B File Offset: 0x00804B5B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsPlayer
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsPlayer) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsPlayer) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700249F RID: 9375
	// (get) Token: 0x0601AE75 RID: 110197 RVA: 0x0080696C File Offset: 0x00804B6C
	// (set) Token: 0x0601AE76 RID: 110198 RVA: 0x008069A5 File Offset: 0x00804BA5
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> TriggerItemEffectData
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._TriggerItemEffectData) == null)
			{
				result = (this._TriggerItemEffectData = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerItemEffectData, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_TriggerItemEffectData, 1);
		}
	}

	// Token: 0x170024A0 RID: 9376
	// (get) Token: 0x0601AE77 RID: 110199 RVA: 0x008069CA File Offset: 0x00804BCA
	// (set) Token: 0x0601AE78 RID: 110200 RVA: 0x008069DA File Offset: 0x00804BDA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NotScale
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_NotScale) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_NotScale) = (value ? 1 : 0);
		}
	}

	// Token: 0x170024A1 RID: 9377
	// (get) Token: 0x0601AE79 RID: 110201 RVA: 0x008069EB File Offset: 0x00804BEB
	// (set) Token: 0x0601AE7A RID: 110202 RVA: 0x008069FB File Offset: 0x00804BFB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IgnoreBullet
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IgnoreBullet) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IgnoreBullet) = (value ? 1 : 0);
		}
	}

	// Token: 0x170024A2 RID: 9378
	// (get) Token: 0x0601AE7B RID: 110203 RVA: 0x00806A0C File Offset: 0x00804C0C
	// (set) Token: 0x0601AE7C RID: 110204 RVA: 0x00806A1C File Offset: 0x00804C1C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float HitCd
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_HitCd);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_HitCd) = value;
		}
	}

	// Token: 0x170024A3 RID: 9379
	// (get) Token: 0x0601AE7D RID: 110205 RVA: 0x00806A30 File Offset: 0x00804C30
	// (set) Token: 0x0601AE7E RID: 110206 RVA: 0x00806A69 File Offset: 0x00804C69
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> HitEffectData
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._HitEffectData) == null)
			{
				result = (this._HitEffectData = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_HitEffectData, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_HitEffectData, 1);
		}
	}

	// Token: 0x170024A4 RID: 9380
	// (get) Token: 0x0601AE7F RID: 110207 RVA: 0x00806A8E File Offset: 0x00804C8E
	// (set) Token: 0x0601AE80 RID: 110208 RVA: 0x00806AA2 File Offset: 0x00804CA2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string HitDataName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTriggerVolume.__PropertyOffset_HitDataName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTriggerVolume.__PropertyOffset_HitDataName)), value);
		}
	}

	// Token: 0x170024A5 RID: 9381
	// (get) Token: 0x0601AE81 RID: 110209 RVA: 0x00806AB7 File Offset: 0x00804CB7
	// (set) Token: 0x0601AE82 RID: 110210 RVA: 0x00806AC7 File Offset: 0x00804CC7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsBlockCamera
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsBlockCamera) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsBlockCamera) = (value ? 1 : 0);
		}
	}

	// Token: 0x170024A6 RID: 9382
	// (get) Token: 0x0601AE83 RID: 110211 RVA: 0x00806AD8 File Offset: 0x00804CD8
	// (set) Token: 0x0601AE84 RID: 110212 RVA: 0x00806AE8 File Offset: 0x00804CE8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int AreaId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_AreaId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_AreaId) = value;
		}
	}

	// Token: 0x170024A7 RID: 9383
	// (get) Token: 0x0601AE85 RID: 110213 RVA: 0x00806AF9 File Offset: 0x00804CF9
	// (set) Token: 0x0601AE86 RID: 110214 RVA: 0x00806B09 File Offset: 0x00804D09
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SeasonAreaId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_SeasonAreaId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_SeasonAreaId) = value;
		}
	}

	// Token: 0x170024A8 RID: 9384
	// (get) Token: 0x0601AE87 RID: 110215 RVA: 0x00806B1A File Offset: 0x00804D1A
	// (set) Token: 0x0601AE88 RID: 110216 RVA: 0x00806B2A File Offset: 0x00804D2A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsAutoTriggerEffect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsAutoTriggerEffect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsAutoTriggerEffect) = (value ? 1 : 0);
		}
	}

	// Token: 0x170024A9 RID: 9385
	// (get) Token: 0x0601AE89 RID: 110217 RVA: 0x00806B3B File Offset: 0x00804D3B
	// (set) Token: 0x0601AE8A RID: 110218 RVA: 0x00806B4B File Offset: 0x00804D4B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EffectCd
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_EffectCd);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_EffectCd) = value;
		}
	}

	// Token: 0x170024AA RID: 9386
	// (get) Token: 0x0601AE8B RID: 110219 RVA: 0x00806B5C File Offset: 0x00804D5C
	// (set) Token: 0x0601AE8C RID: 110220 RVA: 0x00806B6C File Offset: 0x00804D6C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ToleranceDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_ToleranceDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_ToleranceDistance) = value;
		}
	}

	// Token: 0x170024AB RID: 9387
	// (get) Token: 0x0601AE8D RID: 110221 RVA: 0x00806B7D File Offset: 0x00804D7D
	// (set) Token: 0x0601AE8E RID: 110222 RVA: 0x00806B91 File Offset: 0x00804D91
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UAkAudioEvent EnterAkEvent
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + TsTriggerVolume.__PropertyOffset_EnterAkEvent);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTriggerVolume.__PropertyOffset_EnterAkEvent, value);
		}
	}

	// Token: 0x170024AC RID: 9388
	// (get) Token: 0x0601AE8F RID: 110223 RVA: 0x00806BA6 File Offset: 0x00804DA6
	// (set) Token: 0x0601AE90 RID: 110224 RVA: 0x00806BBA File Offset: 0x00804DBA
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UAkAudioEvent ExitAkEvent
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + TsTriggerVolume.__PropertyOffset_ExitAkEvent);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTriggerVolume.__PropertyOffset_ExitAkEvent, value);
		}
	}

	// Token: 0x170024AD RID: 9389
	// (get) Token: 0x0601AE91 RID: 110225 RVA: 0x00806BCF File Offset: 0x00804DCF
	// (set) Token: 0x0601AE92 RID: 110226 RVA: 0x00806BDF File Offset: 0x00804DDF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsChangeFootStep
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsChangeFootStep) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsChangeFootStep) = (value ? 1 : 0);
		}
	}

	// Token: 0x170024AE RID: 9390
	// (get) Token: 0x0601AE93 RID: 110227 RVA: 0x00806BF0 File Offset: 0x00804DF0
	// (set) Token: 0x0601AE94 RID: 110228 RVA: 0x00806C00 File Offset: 0x00804E00
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int FootStepMaterialId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_FootStepMaterialId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_FootStepMaterialId) = value;
		}
	}

	// Token: 0x170024AF RID: 9391
	// (get) Token: 0x0601AE95 RID: 110229 RVA: 0x00806C14 File Offset: 0x00804E14
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<long> BuffIds
	{
		get
		{
			base.FastCheckIsValid();
			TArray<long> result;
			if ((result = this._BuffIds) == null)
			{
				result = (this._BuffIds = new TArray<long>(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_BuffIds, this));
			}
			return result;
		}
	}

	// Token: 0x170024B0 RID: 9392
	// (get) Token: 0x0601AE96 RID: 110230 RVA: 0x00806C4D File Offset: 0x00804E4D
	// (set) Token: 0x0601AE97 RID: 110231 RVA: 0x00806C5D File Offset: 0x00804E5D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsRemoveBuffIds
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsRemoveBuffIds) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_IsRemoveBuffIds) = (value ? 1 : 0);
		}
	}

	// Token: 0x170024B1 RID: 9393
	// (get) Token: 0x0601AE98 RID: 110232 RVA: 0x00806C70 File Offset: 0x00804E70
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> PropsIds
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._PropsIds) == null)
			{
				result = (this._PropsIds = new TArray<int>(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_PropsIds, this));
			}
			return result;
		}
	}

	// Token: 0x170024B2 RID: 9394
	// (get) Token: 0x0601AE99 RID: 110233 RVA: 0x00806CA9 File Offset: 0x00804EA9
	// (set) Token: 0x0601AE9A RID: 110234 RVA: 0x00806CB9 File Offset: 0x00804EB9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int AddBuffType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_AddBuffType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTriggerVolume.__PropertyOffset_AddBuffType) = value;
		}
	}

	// Token: 0x0601AE9B RID: 110235 RVA: 0x00806CCC File Offset: 0x00804ECC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveBeginPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveBeginPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601AE9C RID: 110236 RVA: 0x00806D3C File Offset: 0x00804F3C
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		base.SetActorTickEnabled(false);
		this.InitTriggerItem(this.TriggerItem);
		for (int i = 0; i < this.TriggerItems.Num(); i++)
		{
			this.InitTriggerItem(this.TriggerItems.Get(i));
		}
		this.HandleWorldDone = new Action(this.OnWorldDone);
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (instance == null || !instance.WorldDone)
		{
			GlobalData.BpEventManager.WorldDoneNotify.Remove(this.HandleWorldDone);
			GlobalData.BpEventManager.WorldDoneNotify.Add(this.HandleWorldDone);
		}
		else
		{
			this.OnWorldDone();
		}
		if (this.TriggerGroup != 0f && this.TriggerId != 0f)
		{
			ModelBase<TriggerVolumeModel>.Instance.AddTriggerVolume((int)this.TriggerGroup, (int)this.TriggerId, this);
		}
		if (this.AreaId != 0)
		{
			ModelBase<AreaModel>.Instance.AddArea(this.AreaId, this);
		}
		if (this.SeasonAreaId != 0)
		{
			ControllerBase<SeasonController>.Instance.RegisterVolume(this);
		}
		this.AddBuff();
	}

	// Token: 0x0601AE9D RID: 110237 RVA: 0x00806E44 File Offset: 0x00805044
	protected virtual void OnWorldDone()
	{
		if (this.AreaId != 0)
		{
			bool valueOrDefault = ModelBase<AreaModel>.Instance.GetAreaState(this.AreaId).GetValueOrDefault();
			this.SetEnable(valueOrDefault);
		}
		this.RegistEvents(this.TriggerItem);
		for (int i = 0; i < this.TriggerItems.Num(); i++)
		{
			this.RegistEvents(this.TriggerItems.Get(i));
		}
	}

	// Token: 0x0601AE9E RID: 110238 RVA: 0x00806EAD File Offset: 0x008050AD
	protected virtual void InitTriggerItem(ABrush inTrigger)
	{
		if (inTrigger == null)
		{
			return;
		}
		if (this.TriggerType == AkiClient.Game.Aki.GamePlay.TriggerItems.ETriggerType.Events)
		{
			inTrigger.BrushComponent.SetCollisionObjectType(TsTriggerVolume.KuroTriggerType);
		}
	}

	// Token: 0x0601AE9F RID: 110239 RVA: 0x00806ECC File Offset: 0x008050CC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)EndPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AEA0 RID: 110240 RVA: 0x00806F48 File Offset: 0x00805148
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
	{
		this.RemoveEvents(this.TriggerItem);
		for (int i = 0; i < this.TriggerItems.Num(); i++)
		{
			this.RemoveEvents(this.TriggerItems.Get(i));
		}
		if (this.TriggerGroup != 0f && this.TriggerId != 0f)
		{
			TriggerVolumeModel instance = ModelBase<TriggerVolumeModel>.Instance;
			if (instance != null)
			{
				instance.RemoveTriggerVolume((int)this.TriggerGroup, (int)this.TriggerId);
			}
		}
		if (this.AreaId != 0)
		{
			if (this.CountInTrigger > 0)
			{
				this.HandleAreaLeave(ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger(), null);
			}
			AreaModel instance2 = ModelBase<AreaModel>.Instance;
			if (instance2 != null)
			{
				instance2.RemoveArea(this.AreaId);
			}
		}
		if (this.SeasonAreaId != 0)
		{
			if (this.SeasonPlayerOverlapCount > 0)
			{
				ControllerBase<SeasonController>.Instance.HandleVolumeExit(this);
				this.SeasonPlayerOverlapCount = 0;
			}
			ControllerBase<SeasonController>.Instance.UnregisterVolume(this);
		}
	}

	// Token: 0x0601AEA1 RID: 110241 RVA: 0x00807028 File Offset: 0x00805228
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AEA2 RID: 110242 RVA: 0x0080709E File Offset: 0x0080529E
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
	}

	// Token: 0x0601AEA3 RID: 110243 RVA: 0x008070A0 File Offset: 0x008052A0
	private void RegistEvents(ABrush inTrigger)
	{
		this.CountInTrigger = 0;
		if (inTrigger == null || !inTrigger.IsValid())
		{
			return;
		}
		TArray<AActor> tarray = new TArray<AActor>();
		inTrigger.GetOverlappingActors(ref tarray, default(TSubclassOf<AActor>));
		if (tarray.Num() > 0)
		{
			int i = 0;
			int num = tarray.Num();
			while (i < num)
			{
				AActor otherActor2 = tarray.Get(i);
				this.OnCollisionEnterFunc(otherActor2, null);
				i++;
			}
		}
		inTrigger.OnActorBeginOverlap.Add(delegate(AActor overlapped, AActor otherActor)
		{
			this.OnCollisionEnterFunc(otherActor, overlapped);
		});
		inTrigger.OnActorEndOverlap.Add(delegate(AActor overlapped, AActor otherActor)
		{
			this.OnCollisionExitFunc(otherActor, overlapped);
		});
	}

	// Token: 0x0601AEA4 RID: 110244 RVA: 0x00807139 File Offset: 0x00805339
	private void RemoveEvents(ABrush inTrigger)
	{
		if (inTrigger != null)
		{
			inTrigger.OnActorBeginOverlap.Clear();
			inTrigger.OnActorEndOverlap.Clear();
			inTrigger.OnActorHit.Clear();
		}
		GlobalData.BpEventManager.WorldDoneNotify.Remove(this.HandleWorldDone);
	}

	// Token: 0x0601AEA5 RID: 110245 RVA: 0x00807174 File Offset: 0x00805374
	[NullableContext(2)]
	protected virtual void OnCollisionEnterFunc(AActor otherActor, AActor overlapped)
	{
		if (this.SeasonAreaId != 0 && otherActor != null && this.CheckBeginOverlapRoleTrigger(otherActor))
		{
			this.SeasonPlayerOverlapCount++;
			if (this.SeasonPlayerOverlapCount == 1)
			{
				ControllerBase<SeasonController>.Instance.HandleVolumeEnter(this);
			}
		}
		if (!this.CheckCondition(otherActor))
		{
			return;
		}
		this.CountInTrigger++;
		if (this.AreaId != 0 && this.CountInTrigger == 1)
		{
			this.HandleAreaEnter(otherActor, overlapped);
		}
		if (Global.BaseCharacter == null)
		{
			return;
		}
		if (this.EnterAkEvent != null)
		{
			this.PostAkEvent(otherActor, this.EnterAkEvent);
		}
	}

	// Token: 0x0601AEA6 RID: 110246 RVA: 0x00807208 File Offset: 0x00805408
	[NullableContext(2)]
	protected virtual void OnCollisionExitFunc(AActor otherActor, AActor overlapped)
	{
		if (this.CheckBeginOverlapRoleTrigger(otherActor))
		{
			Singleton<EventSystem>.Instance.Emit<AActor>(EEventName.OnTriggerVolumeExit, this);
			if (this.SeasonAreaId != 0 && this.SeasonPlayerOverlapCount > 0)
			{
				this.SeasonPlayerOverlapCount--;
				if (this.SeasonPlayerOverlapCount == 0)
				{
					ControllerBase<SeasonController>.Instance.HandleVolumeExit(this);
				}
			}
		}
		if (!this.CheckCondition(otherActor))
		{
			return;
		}
		this.CountInTrigger--;
		if (this.AreaId != 0 && this.CountInTrigger <= 0)
		{
			this.HandleAreaLeave(otherActor, overlapped);
			this.CountInTrigger = 0;
		}
		if (this.ExitAkEvent != null)
		{
			this.PostAkEvent(otherActor, this.ExitAkEvent);
		}
	}

	// Token: 0x0601AEA7 RID: 110247 RVA: 0x008072B0 File Offset: 0x008054B0
	private bool CheckCondition(AActor actor)
	{
		if (actor == null || !actor.IsValid())
		{
			return false;
		}
		if (this.IsPlayer || this.TriggerType == AkiClient.Game.Aki.GamePlay.TriggerItems.ETriggerType.NotOpened || this.EnterAkEvent != null || this.ExitAkEvent != null)
		{
			bool flag = this.CheckBeginOverlapRoleTrigger(actor);
			return flag && flag;
		}
		return actor is TsBaseCharacter || actor is TsBaseItem;
	}

	// Token: 0x0601AEA8 RID: 110248 RVA: 0x00807314 File Offset: 0x00805514
	private void SetEnable(bool value)
	{
		if (this.TriggerItem != null)
		{
			this.TriggerItem.SetActorEnableCollision(value);
		}
		for (int i = 0; i < this.TriggerItems.Num(); i++)
		{
			ABrush abrush = this.TriggerItems.Get(i);
			if (abrush != null)
			{
				abrush.SetActorEnableCollision(value);
			}
		}
	}

	// Token: 0x0601AEA9 RID: 110249 RVA: 0x00807364 File Offset: 0x00805564
	private void HandleAreaEnter(AActor otherActor, [Nullable(2)] AActor overlapped)
	{
		if (otherActor != ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger())
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Area;
		ELogAuthor author = ELogAuthor.YZH;
		string message = "[AreaController.EnterOverlap_TstriggerVolume] 进入区域";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LeaveArea", this.AreaId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Area? area;
		ControllerBase<AreaController>.Instance.EnterAreaRequest((ModelBase<AreaModel>.Instance.AreaInfo != null) ? new int?(area.GetValueOrDefault().AreaId) : null, this.AreaId, true, "AreaController.EnterOverlap_TstriggerVolume");
	}

	// Token: 0x0601AEAA RID: 110250 RVA: 0x008073FC File Offset: 0x008055FC
	private void HandleAreaLeave(AActor otherActor, [Nullable(2)] AActor overlapped)
	{
		if (otherActor != ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger())
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Area;
		ELogAuthor author = ELogAuthor.YZH;
		string message = "[AreaController.EndOverlap_TstriggerVolume] 离开区域";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LeaveArea", this.AreaId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<AreaController>.Instance.EndOverlap(this.AreaId);
	}

	// Token: 0x0601AEAB RID: 110251 RVA: 0x0080745A File Offset: 0x0080565A
	public void ToggleArea(bool inEnable)
	{
		this.SetEnable(inEnable);
	}

	// Token: 0x0601AEAC RID: 110252 RVA: 0x00807464 File Offset: 0x00805664
	private void PostAkEvent(AActor actor, UAkAudioEvent @event)
	{
		if (actor != ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger())
		{
			return;
		}
		string pathName = UKismetSystemLibrary.GetPathName(@event);
		Singleton<AudioController>.Instance.PostEvent(pathName, null, null, null, null, null, true, "");
	}

	// Token: 0x0601AEAD RID: 110253 RVA: 0x008074AC File Offset: 0x008056AC
	private void AddBuff()
	{
		TArray<long> buffIds = this.BuffIds;
		if (buffIds == null || !buffIds.IsValidIndex(0))
		{
			return;
		}
		this.AddBuffInner(this.BuffIds.Get(0));
		this.TryReportSelfBuffDamageLog();
	}

	// Token: 0x0601AEAE RID: 110254 RVA: 0x008074DF File Offset: 0x008056DF
	private bool CheckBeginOverlapRoleTrigger(AActor otherActor)
	{
		return otherActor == ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger();
	}

	// Token: 0x0601AEAF RID: 110255 RVA: 0x008074F4 File Offset: 0x008056F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void AddBuffInner(long buffId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddBuffInner"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTriggerVolume.__AddBuffInner_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTriggerVolume.__AddBuffInner_FunctionParams*)ptr + 15L / (long)sizeof(TsTriggerVolume.__AddBuffInner_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->buffId = buffId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AEB0 RID: 110256 RVA: 0x0080756A File Offset: 0x0080576A
	protected void AddBuffInner_Implementation(long buffId)
	{
	}

	// Token: 0x0601AEB1 RID: 110257 RVA: 0x0080756C File Offset: 0x0080576C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void TryReportSelfBuffDamageLog()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TryReportSelfBuffDamageLog"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601AEB2 RID: 110258 RVA: 0x008075DC File Offset: 0x008057DC
	protected void TryReportSelfBuffDamageLog_Implementation()
	{
	}

	// Token: 0x0601AEB3 RID: 110259 RVA: 0x008075DE File Offset: 0x008057DE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTriggerVolume._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsTriggerVolume.TsTriggerVolume_C");
		}
		return TsTriggerVolume._ClassPtr;
	}

	// Token: 0x0601AEB4 RID: 110260 RVA: 0x00807604 File Offset: 0x00805804
	public TsTriggerVolume() : this(BuiltinUtils.AllocNativeUObject(TsTriggerVolume.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601AEB5 RID: 110261 RVA: 0x0080762C File Offset: 0x0080582C
	public TsTriggerVolume(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTriggerVolume.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601AEB6 RID: 110262 RVA: 0x0080765F File Offset: 0x0080585F
	protected TsTriggerVolume(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601AEB7 RID: 110263 RVA: 0x00807668 File Offset: 0x00805868
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601AEB8 RID: 110264 RVA: 0x00807670 File Offset: 0x00805870
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601AEB9 RID: 110265 RVA: 0x00807690 File Offset: 0x00805890
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601AEBA RID: 110266 RVA: 0x0080769E File Offset: 0x0080589E
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_AddBuffInner_Implementation(TsTriggerVolume.__AddBuffInner_FunctionParams* __Params)
	{
		this.AddBuffInner_Implementation(__Params->buffId);
	}

	// Token: 0x0601AEBB RID: 110267 RVA: 0x008076AC File Offset: 0x008058AC
	protected virtual void __CPPCALL_TryReportSelfBuffDamageLog_Implementation()
	{
		this.TryReportSelfBuffDamageLog_Implementation();
	}

	// Token: 0x0400DA5F RID: 55903
	private static readonly ECollisionChannel KuroTriggerType = KuroCollisionChannel.KuroTrigger;

	// Token: 0x0400DA60 RID: 55904
	private int CountInTrigger;

	// Token: 0x0400DA61 RID: 55905
	private int SeasonPlayerOverlapCount;

	// Token: 0x0400DA62 RID: 55906
	[Nullable(2)]
	public TimerHandle BuffTimerId;

	// Token: 0x0400DA63 RID: 55907
	[Nullable(2)]
	private Action HandleWorldDone;

	// Token: 0x0400DA64 RID: 55908
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsTriggerVolume.TsTriggerVolume_C";

	// Token: 0x0400DA65 RID: 55909
	private static IntPtr _ClassPtr;

	// Token: 0x0400DA66 RID: 55910
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DA67 RID: 55911
	private static int __PropertyOffset_TriggerItem;

	// Token: 0x0400DA68 RID: 55912
	private static int __PropertyOffset_TriggerItems;

	// Token: 0x0400DA69 RID: 55913
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<ABrush> _TriggerItems;

	// Token: 0x0400DA6A RID: 55914
	private static int __PropertyOffset_TriggerType;

	// Token: 0x0400DA6B RID: 55915
	private static int __PropertyOffset_TriggerGroup;

	// Token: 0x0400DA6C RID: 55916
	private static int __PropertyOffset_TriggerId;

	// Token: 0x0400DA6D RID: 55917
	private static int __PropertyOffset_ConditionGroupId;

	// Token: 0x0400DA6E RID: 55918
	private static int __PropertyOffset_EventGroupId;

	// Token: 0x0400DA6F RID: 55919
	private static int __PropertyOffset_ExitEventGroupId;

	// Token: 0x0400DA70 RID: 55920
	private static int __PropertyOffset_IsPlayer;

	// Token: 0x0400DA71 RID: 55921
	private static int __PropertyOffset_TriggerItemEffectData;

	// Token: 0x0400DA72 RID: 55922
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _TriggerItemEffectData;

	// Token: 0x0400DA73 RID: 55923
	private static int __PropertyOffset_NotScale;

	// Token: 0x0400DA74 RID: 55924
	private static int __PropertyOffset_IgnoreBullet;

	// Token: 0x0400DA75 RID: 55925
	private static int __PropertyOffset_HitCd;

	// Token: 0x0400DA76 RID: 55926
	private static int __PropertyOffset_HitEffectData;

	// Token: 0x0400DA77 RID: 55927
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _HitEffectData;

	// Token: 0x0400DA78 RID: 55928
	private static int __PropertyOffset_HitDataName;

	// Token: 0x0400DA79 RID: 55929
	private static int __PropertyOffset_IsBlockCamera;

	// Token: 0x0400DA7A RID: 55930
	private static int __PropertyOffset_AreaId;

	// Token: 0x0400DA7B RID: 55931
	private static int __PropertyOffset_SeasonAreaId;

	// Token: 0x0400DA7C RID: 55932
	private static int __PropertyOffset_IsAutoTriggerEffect;

	// Token: 0x0400DA7D RID: 55933
	private static int __PropertyOffset_EffectCd;

	// Token: 0x0400DA7E RID: 55934
	private static int __PropertyOffset_ToleranceDistance;

	// Token: 0x0400DA7F RID: 55935
	private static int __PropertyOffset_EnterAkEvent;

	// Token: 0x0400DA80 RID: 55936
	private static int __PropertyOffset_ExitAkEvent;

	// Token: 0x0400DA81 RID: 55937
	private static int __PropertyOffset_IsChangeFootStep;

	// Token: 0x0400DA82 RID: 55938
	private static int __PropertyOffset_FootStepMaterialId;

	// Token: 0x0400DA83 RID: 55939
	private static int __PropertyOffset_BuffIds;

	// Token: 0x0400DA84 RID: 55940
	[Nullable(2)]
	private TArray<long> _BuffIds;

	// Token: 0x0400DA85 RID: 55941
	private static int __PropertyOffset_IsRemoveBuffIds;

	// Token: 0x0400DA86 RID: 55942
	private static int __PropertyOffset_PropsIds;

	// Token: 0x0400DA87 RID: 55943
	[Nullable(2)]
	private TArray<int> _PropsIds;

	// Token: 0x0400DA88 RID: 55944
	private static int __PropertyOffset_AddBuffType;

	// Token: 0x02009446 RID: 37958
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AddBuffInner_FunctionParams
	{
		// Token: 0x04031381 RID: 201601
		[FieldOffset(0)]
		public long buffId;
	}
}
