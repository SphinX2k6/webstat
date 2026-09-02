using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FE8 RID: 8168
public class InfluenceDisplayItem : UiPanelBase
{
	// Token: 0x0600F68B RID: 63115 RVA: 0x00438011 File Offset: 0x00436211
	[NullableContext(1)]
	public InfluenceDisplayItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600F68C RID: 63116 RVA: 0x00438028 File Offset: 0x00436228
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.ShowContent));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F68D RID: 63117 RVA: 0x004381FA File Offset: 0x004363FA
	protected override void OnStart()
	{
		base.GetExtendToggle(2).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		this.ContentItem = new ContentItem(base.GetItem(8));
		this.ContentItem.SetActive(false);
	}

	// Token: 0x0600F68E RID: 63118 RVA: 0x00438237 File Offset: 0x00436437
	private bool CanExecuteChange()
	{
		bool flag = this.IsUnLock();
		if (!flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InfluenceLockTips", Array.Empty<object>());
		}
		return flag;
	}

	// Token: 0x0600F68F RID: 63119 RVA: 0x00438256 File Offset: 0x00436456
	private void ShowContent(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SetActiveToggleState();
		}
		else
		{
			this.SetContentDisActive();
		}
		TToggleFunction toggleFunction = this.ToggleFunction;
		if (toggleFunction == null)
		{
			return;
		}
		toggleFunction(state, this.Index);
	}

	// Token: 0x0600F690 RID: 63120 RVA: 0x00438283 File Offset: 0x00436483
	protected override void OnBeforeDestroy()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		extendToggle.CanExecuteChange.Unbind();
		this.UnBindRedDot();
		this.ContentItem.Destroy(null);
		this.ContentItem = null;
	}

	// Token: 0x0600F691 RID: 63121 RVA: 0x004382BC File Offset: 0x004364BC
	public void UpdateItem(int influenceId, int countryId)
	{
		this.InfluenceId = influenceId;
		InfluenceInstance influenceInstance = ModelBase<InfluenceReputationModel>.Instance.GetInfluenceInstance(influenceId);
		if (influenceInstance != null)
		{
			this.Relation = influenceInstance.Relation;
		}
		this.UpdateState(influenceId, countryId);
		this.BindRedDot();
	}

	// Token: 0x0600F692 RID: 63122 RVA: 0x004382F9 File Offset: 0x004364F9
	public void SetToggleState(EToggleState state, bool bFire = false)
	{
		base.GetExtendToggle(2).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x0600F693 RID: 63123 RVA: 0x0043830C File Offset: 0x0043650C
	[NullableContext(1)]
	public void SetToggleFunction(TToggleFunction callback)
	{
		this.ToggleFunction = callback;
	}

	// Token: 0x0600F694 RID: 63124 RVA: 0x00438315 File Offset: 0x00436515
	public void SetIndex(int index)
	{
		this.Index = index;
	}

	// Token: 0x0600F695 RID: 63125 RVA: 0x0043831E File Offset: 0x0043651E
	public void SetActiveToggleState()
	{
		this.ContentItem.SetActive(true);
		this.ContentItem.BindRedDot();
		base.GetItem(10).SetUIActive(false);
	}

	// Token: 0x0600F696 RID: 63126 RVA: 0x00438345 File Offset: 0x00436545
	public void SetDisActiveToggleState()
	{
		this.SetToggleState(EToggleState.ETT_UnChecked, false);
		this.SetContentDisActive();
	}

	// Token: 0x0600F697 RID: 63127 RVA: 0x00438355 File Offset: 0x00436555
	private void SetContentDisActive()
	{
		this.ContentItem.SetActive(false);
		this.BindRedDot();
	}

	// Token: 0x0600F698 RID: 63128 RVA: 0x0043836C File Offset: 0x0043656C
	private void UpdateState(int influenceId, int countryId)
	{
		UUIText text = base.GetText(0);
		UUIText text2 = base.GetText(1);
		UUITexture texture = base.GetTexture(9);
		base.GetItem(5).SetUIActive(this.Relation == EInfluenceRelation.Belong);
		base.GetItem(3).SetUIActive(this.Relation == EInfluenceRelation.Neutral);
		base.GetItem(6).SetUIActive(this.Relation == EInfluenceRelation.Hostility);
		base.GetItem(7).SetUIActive(this.Relation == EInfluenceRelation.None);
		if (this.Relation == EInfluenceRelation.None)
		{
			text.SetUIActive(false);
			texture.SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalText(text2, "InfluenceLockName", Array.Empty<object>());
			return;
		}
		Influence value = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(influenceId).Value;
		UUIText text3 = base.GetText(0);
		if (!string.IsNullOrEmpty(value.ExtraDesc))
		{
			text3.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, value.ExtraDesc, Array.Empty<object>());
		}
		else
		{
			text3.SetUIActive(false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Title, Array.Empty<object>());
		this.ContentItem.UpdateItem(influenceId, countryId, this.Relation);
		if (this.Relation == EInfluenceRelation.Neutral)
		{
			ValueTuple<int, int> reputationProgress = ModelBase<InfluenceReputationModel>.Instance.GetReputationProgress(influenceId);
			base.GetSprite(4).SetFillAmount((float)reputationProgress.Item1 / (float)reputationProgress.Item2);
		}
		texture.SetUIActive(true);
		base.SetTextureByPath(value.Logo, texture, null, null);
	}

	// Token: 0x0600F699 RID: 63129 RVA: 0x004384EB File Offset: 0x004366EB
	private void BindRedDot()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.InfluenceReward, base.GetItem(10), null, this.InfluenceId);
	}

	// Token: 0x0600F69A RID: 63130 RVA: 0x00438508 File Offset: 0x00436708
	private void UnBindRedDot()
	{
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.InfluenceReward);
	}

	// Token: 0x0600F69B RID: 63131 RVA: 0x00438516 File Offset: 0x00436716
	public bool IsUnLock()
	{
		return this.Relation > EInfluenceRelation.None;
	}

	// Token: 0x04007725 RID: 30501
	[Nullable(2)]
	private ContentItem ContentItem;

	// Token: 0x04007726 RID: 30502
	private EInfluenceRelation Relation;

	// Token: 0x04007727 RID: 30503
	private int InfluenceId;

	// Token: 0x04007728 RID: 30504
	[Nullable(2)]
	private TToggleFunction ToggleFunction;

	// Token: 0x04007729 RID: 30505
	private int Index;

	// Token: 0x02008366 RID: 33638
	private enum EInfluenceDisplayItem
	{
		// Token: 0x0402C916 RID: 182550
		CountryName,
		// Token: 0x0402C917 RID: 182551
		InfluenceName,
		// Token: 0x0402C918 RID: 182552
		Toggle,
		// Token: 0x0402C919 RID: 182553
		NeutralState,
		// Token: 0x0402C91A RID: 182554
		Progress,
		// Token: 0x0402C91B RID: 182555
		BelongState,
		// Token: 0x0402C91C RID: 182556
		HostilityState,
		// Token: 0x0402C91D RID: 182557
		LockState,
		// Token: 0x0402C91E RID: 182558
		ContentItem,
		// Token: 0x0402C91F RID: 182559
		TextureBg,
		// Token: 0x0402C920 RID: 182560
		RedDot
	}
}
