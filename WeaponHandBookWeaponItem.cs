using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02001EB0 RID: 7856
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class WeaponHandBookWeaponItem : LoopScrollMediumItemGrid<WeaponHandBookDynamicLayoutItemData>
{
	// Token: 0x0600E855 RID: 59477 RVA: 0x003ECDB0 File Offset: 0x003EAFB0
	protected override void OnRefresh(WeaponHandBookDynamicLayoutItemData data, bool isSelected, int gridIndex)
	{
		this.HandBookId = data.ItemId.GetValueOrDefault();
		this.SetSelected(isSelected, false);
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Weapon, this.HandBookId);
		bool value = handBookInfo == null || !handBookInfo.IsRead;
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = this.HandBookId,
			ItemConfigId = new int?(this.HandBookId),
			IsNewVisible = new bool?(value),
			BottomTextId = (data.IsSkin ? ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(this.HandBookId).Name : ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.HandBookId).Value.WeaponName)
		};
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x0600E856 RID: 59478 RVA: 0x003ECE7B File Offset: 0x003EB07B
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E857 RID: 59479 RVA: 0x003ECE99 File Offset: 0x003EB099
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E858 RID: 59480 RVA: 0x003ECEB7 File Offset: 0x003EB0B7
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, true);
		if (fireEvent)
		{
			this.OnExtendToggleStateChanged(EToggleState.ETT_Checked);
		}
	}

	// Token: 0x0600E859 RID: 59481 RVA: 0x003ECECB File Offset: 0x003EB0CB
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x0600E85A RID: 59482 RVA: 0x003ECED5 File Offset: 0x003EB0D5
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<UUIExtendToggle, int> onClickCallBack = this.OnClickCallBack;
			if (onClickCallBack == null)
			{
				return;
			}
			onClickCallBack(this.GetItemGridExtendToggle(), this.HandBookId);
		}
	}

	// Token: 0x0600E85B RID: 59483 RVA: 0x003ECEF7 File Offset: 0x003EB0F7
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Weapon || id != this.HandBookId)
		{
			return;
		}
		base.SetNewVisible(new bool?(false));
	}

	// Token: 0x04006FEC RID: 28652
	public int HandBookId;

	// Token: 0x04006FED RID: 28653
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int> OnClickCallBack;
}
