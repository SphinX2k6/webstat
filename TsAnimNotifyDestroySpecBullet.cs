using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DC1 RID: 3521
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDestroySpecBullet.TsAnimNotifyDestroySpecBullet_C")]
public class TsAnimNotifyDestroySpecBullet : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700051A RID: 1306
	// (get) Token: 0x06004FF8 RID: 20472 RVA: 0x000B8113 File Offset: 0x000B6313
	// (set) Token: 0x06004FF9 RID: 20473 RVA: 0x000B8127 File Offset: 0x000B6327
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName bulletName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyDestroySpecBullet.__PropertyOffset_bulletName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyDestroySpecBullet.__PropertyOffset_bulletName) = value;
		}
	}

	// Token: 0x1700051B RID: 1307
	// (get) Token: 0x06004FFA RID: 20474 RVA: 0x000B813C File Offset: 0x000B633C
	// (set) Token: 0x06004FFB RID: 20475 RVA: 0x000B814C File Offset: 0x000B634C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否召唤子子弹
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyDestroySpecBullet.__PropertyOffset_是否召唤子子弹) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyDestroySpecBullet.__PropertyOffset_是否召唤子子弹) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700051C RID: 1308
	// (get) Token: 0x06004FFC RID: 20476 RVA: 0x000B815D File Offset: 0x000B635D
	// (set) Token: 0x06004FFD RID: 20477 RVA: 0x000B816D File Offset: 0x000B636D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 立即销毁子弹特效
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyDestroySpecBullet.__PropertyOffset_立即销毁子弹特效) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyDestroySpecBullet.__PropertyOffset_立即销毁子弹特效) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700051D RID: 1309
	// (get) Token: 0x06004FFE RID: 20478 RVA: 0x000B8180 File Offset: 0x000B6380
	// (set) Token: 0x06004FFF RID: 20479 RVA: 0x000B81B9 File Offset: 0x000B63B9
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer 角色拥有标签执行判定
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._角色拥有标签执行判定) == null)
			{
				result = (this._角色拥有标签执行判定 = new FGameplayTagContainer(base.NativePtr + (IntPtr)TsAnimNotifyDestroySpecBullet.__PropertyOffset_角色拥有标签执行判定, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyDestroySpecBullet.__PropertyOffset_角色拥有标签执行判定, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06005000 RID: 20480 RVA: 0x000B81E4 File Offset: 0x000B63E4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06005001 RID: 20481 RVA: 0x000B8284 File Offset: 0x000B6484
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			if (this.角色拥有标签执行判定.GameplayTags.Num() > 0)
			{
				UBaseAbilitySystemComponent ubaseAbilitySystemComponent = tsBaseCharacter.GetComponentByClass(UBaseAbilitySystemComponent.StaticClass()) as UBaseAbilitySystemComponent;
				if (ubaseAbilitySystemComponent != null)
				{
					UBaseAbilitySystemComponent ubaseAbilitySystemComponent2 = ubaseAbilitySystemComponent;
					FGameplayTagContainer 角色拥有标签执行判定 = this.角色拥有标签执行判定;
					if (ubaseAbilitySystemComponent2.HasAnyGameplayTag(角色拥有标签执行判定))
					{
						goto IL_55;
					}
				}
				return false;
			}
			IL_55:
			IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(tsBaseCharacter.EntityId);
			List<int> list = new List<int>();
			string text = this.bulletName.ToString();
			if (bulletSetByAttacker != null)
			{
				foreach (BulletEntity bulletEntity in bulletSetByAttacker)
				{
					string a = text;
					BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
					if (a == ((bulletInfo != null) ? bulletInfo.BulletDataMain.BulletName : null))
					{
						list.Add(bulletEntity.Id);
					}
				}
			}
			if (list.Count == 0)
			{
				return false;
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				ControllerBase<BulletController>.Instance.DestroyBullet(list[i], this.是否召唤子子弹, EBulletDestroyReason.Normal, this.立即销毁子弹特效);
			}
		}
		return true;
	}

	// Token: 0x06005002 RID: 20482 RVA: 0x000B83C0 File Offset: 0x000B65C0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06005003 RID: 20483 RVA: 0x000B843B File Offset: 0x000B663B
	protected override string GetNotifyName_Implementation()
	{
		return "销毁子弹";
	}

	// Token: 0x06005004 RID: 20484 RVA: 0x000B8442 File Offset: 0x000B6642
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyDestroySpecBullet._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDestroySpecBullet.TsAnimNotifyDestroySpecBullet_C");
		}
		return TsAnimNotifyDestroySpecBullet._ClassPtr;
	}

	// Token: 0x06005005 RID: 20485 RVA: 0x000B8468 File Offset: 0x000B6668
	public TsAnimNotifyDestroySpecBullet() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDestroySpecBullet.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005006 RID: 20486 RVA: 0x000B8490 File Offset: 0x000B6690
	public TsAnimNotifyDestroySpecBullet(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDestroySpecBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005007 RID: 20487 RVA: 0x000B84C3 File Offset: 0x000B66C3
	protected TsAnimNotifyDestroySpecBullet(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005008 RID: 20488 RVA: 0x000B84CC File Offset: 0x000B66CC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005009 RID: 20489 RVA: 0x000B84FF File Offset: 0x000B66FF
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001758 RID: 5976
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDestroySpecBullet.TsAnimNotifyDestroySpecBullet_C";

	// Token: 0x04001759 RID: 5977
	private static IntPtr _ClassPtr;

	// Token: 0x0400175A RID: 5978
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400175B RID: 5979
	private static int __PropertyOffset_bulletName;

	// Token: 0x0400175C RID: 5980
	private static int __PropertyOffset_是否召唤子子弹;

	// Token: 0x0400175D RID: 5981
	private static int __PropertyOffset_立即销毁子弹特效;

	// Token: 0x0400175E RID: 5982
	private static int __PropertyOffset_角色拥有标签执行判定;

	// Token: 0x0400175F RID: 5983
	[Nullable(2)]
	private FGameplayTagContainer _角色拥有标签执行判定;
}
