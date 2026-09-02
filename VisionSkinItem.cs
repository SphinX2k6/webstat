using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02002546 RID: 9542
[NullableContext(1)]
[Nullable(0)]
public class VisionSkinItem : LoopScrollSmallItemGrid<int>
{
	// Token: 0x06012917 RID: 76055 RVA: 0x0051D764 File Offset: 0x0051B964
	protected override void OnRefresh(int data, bool isSelected, int gridIndex)
	{
		this.ItemId = data;
		bool value = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.VisionSkin, data);
		bool value2 = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(data).Value.ParentMonsterId != 0 && !ModelBase<PhantomBattleModel>.Instance.GetSkinIsUnlock(data);
		PhantomSmallItemGrid parameters = new PhantomSmallItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data),
			IsLockVisibleBlack = new bool?(value2),
			IsNewVisible = new bool?(value),
			IsQualityHidden = new bool?(true)
		};
		base.Apply<PhantomSmallItemGrid>(parameters);
		if (this.GetItemGridExtendToggle().ToggleState != EToggleState.ETT_UnChecked)
		{
			this.SetSelected(false, true);
		}
	}

	// Token: 0x06012918 RID: 76056 RVA: 0x0051D814 File Offset: 0x0051BA14
	protected override void OnStart()
	{
		base.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnClickEvent));
		UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
		if (itemGridExtendToggle == null)
		{
			return;
		}
		itemGridExtendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
	}

	// Token: 0x06012919 RID: 76057 RVA: 0x0051D849 File Offset: 0x0051BA49
	public override void OnSelected(bool fireEvent)
	{
		if (this.GetItemGridExtendToggle().ToggleState != EToggleState.ETT_Checked)
		{
			this.SetSelected(true, true);
		}
	}

	// Token: 0x0601291A RID: 76058 RVA: 0x0051D864 File Offset: 0x0051BA64
	private void OnClickEvent(MediumItemGridExtendCallback _)
	{
		Action<int, UUIExtendToggle> onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack != null)
		{
			onClickCallBack(this.ItemId, this.GetItemGridExtendToggle());
		}
		base.SetNewFlagVisible(new bool?(false));
		ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.VisionSkin, this.ItemId);
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.VisionSkin);
	}

	// Token: 0x0601291B RID: 76059 RVA: 0x0051D8BA File Offset: 0x0051BABA
	public void SetClickToggleEvent(Action<int, UUIExtendToggle> call)
	{
		this.OnClickCallBack = call;
	}

	// Token: 0x0601291C RID: 76060 RVA: 0x0051D8C3 File Offset: 0x0051BAC3
	public void BindCanToggleExecuteChange(Func<int, bool> toggle)
	{
		this.OnCanToggleClicked = toggle;
	}

	// Token: 0x0601291D RID: 76061 RVA: 0x0051D8CC File Offset: 0x0051BACC
	private bool CanToggleExecuteChange()
	{
		return this.OnCanToggleClicked == null || this.OnCanToggleClicked(this.ItemId);
	}

	// Token: 0x040090B1 RID: 37041
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle> OnClickCallBack;

	// Token: 0x040090B2 RID: 37042
	[Nullable(2)]
	private Func<int, bool> OnCanToggleClicked;

	// Token: 0x040090B3 RID: 37043
	private int ItemId = -1;
}
