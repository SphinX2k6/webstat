using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EAD RID: 7853
[NullableContext(1)]
[Nullable(0)]
public class WeaponHandBookItem : UiPanelBase, IDynamicScrollItem<WeaponHandBookDynamicData>
{
	// Token: 0x0600E844 RID: 59460 RVA: 0x003ECAC4 File Offset: 0x003EACC4
	public UniTask Init(UUIItem actor)
	{
		WeaponHandBookItem.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<WeaponHandBookItem.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E845 RID: 59461 RVA: 0x003ECB0F File Offset: 0x003EAD0F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E846 RID: 59462 RVA: 0x003ECB48 File Offset: 0x003EAD48
	private UniTask InitChildItem()
	{
		WeaponHandBookItem.<InitChildItem>d__6 <InitChildItem>d__;
		<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildItem>d__.<>4__this = this;
		<InitChildItem>d__.<>1__state = -1;
		<InitChildItem>d__.<>t__builder.Start<WeaponHandBookItem.<InitChildItem>d__6>(ref <InitChildItem>d__);
		return <InitChildItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600E847 RID: 59463 RVA: 0x003ECB8B File Offset: 0x003EAD8B
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(WeaponHandBookDynamicData data)
	{
		if (!string.IsNullOrEmpty(data.TitleId))
		{
			return base.GetItem(0).GetOwner() as AUIBaseActor;
		}
		return base.GetItem(1).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600E848 RID: 59464 RVA: 0x003ECBBD File Offset: 0x003EADBD
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0600E849 RID: 59465 RVA: 0x003ECBC8 File Offset: 0x003EADC8
	public void Update(WeaponHandBookDynamicData data, int gridIndex)
	{
		WeaponHandBookTitleItem weaponHandBookTitleItem = this.WeaponHandBookTitleItem;
		if (weaponHandBookTitleItem != null)
		{
			weaponHandBookTitleItem.SetUiActive(false);
		}
		WeaponHandBookLayoutItem weaponHandBookLayoutItem = this.WeaponHandBookLayoutItem;
		if (weaponHandBookLayoutItem != null)
		{
			weaponHandBookLayoutItem.SetUiActive(false);
		}
		if (string.IsNullOrEmpty(data.TitleId))
		{
			if (data.ItemData != null)
			{
				WeaponHandBookLayoutItem weaponHandBookLayoutItem2 = this.WeaponHandBookLayoutItem;
				if (weaponHandBookLayoutItem2 != null)
				{
					weaponHandBookLayoutItem2.SetUiActive(true);
				}
				WeaponHandBookLayoutItem weaponHandBookLayoutItem3 = this.WeaponHandBookLayoutItem;
				if (weaponHandBookLayoutItem3 == null)
				{
					return;
				}
				weaponHandBookLayoutItem3.Update(data.ItemData);
			}
			return;
		}
		WeaponHandBookTitleItem weaponHandBookTitleItem2 = this.WeaponHandBookTitleItem;
		if (weaponHandBookTitleItem2 != null)
		{
			weaponHandBookTitleItem2.SetUiActive(true);
		}
		WeaponHandBookTitleItem weaponHandBookTitleItem3 = this.WeaponHandBookTitleItem;
		if (weaponHandBookTitleItem3 == null)
		{
			return;
		}
		weaponHandBookTitleItem3.Update(data.TitleId);
	}

	// Token: 0x04006FE7 RID: 28647
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int> OnClickCallBack;

	// Token: 0x04006FE8 RID: 28648
	[Nullable(2)]
	private WeaponHandBookTitleItem WeaponHandBookTitleItem;

	// Token: 0x04006FE9 RID: 28649
	[Nullable(2)]
	private WeaponHandBookLayoutItem WeaponHandBookLayoutItem;

	// Token: 0x020081ED RID: 33261
	[NullableContext(0)]
	private class EWeaponDynamicItemDefine
	{
		// Token: 0x0402C144 RID: 180548
		public const int TitleItem = 0;

		// Token: 0x0402C145 RID: 180549
		public const int LayoutItem = 1;
	}
}
