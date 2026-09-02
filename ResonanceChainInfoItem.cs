using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028A1 RID: 10401
[NullableContext(2)]
[Nullable(0)]
public class ResonanceChainInfoItem : UiPanelBase
{
	// Token: 0x06014A44 RID: 84548 RVA: 0x005B7CA4 File Offset: 0x005B5EA4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnBackButtonClick))
		};
	}

	// Token: 0x06014A45 RID: 84549 RVA: 0x005B7DEC File Offset: 0x005B5FEC
	protected override void OnStart()
	{
		this.ConfirmButtonItem = new ButtonItem(base.GetItem(5));
		this.ConfirmButtonItem.SetFunction(new Action<int>(this.OnConfirmButtonClick));
		this.NeedItem = new MediumItemGrid();
		this.NeedItem.Initialize(base.GetItem(4).GetOwner());
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(base.GetText(2), ETermExplanationViewType.Side, ETermExplanationReportType.RoleDeviceList, ETermExplanationViewAttachDirection.Right, null, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
	}

	// Token: 0x06014A46 RID: 84550 RVA: 0x005B7E78 File Offset: 0x005B6078
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(2));
	}

	// Token: 0x06014A47 RID: 84551 RVA: 0x005B7E8C File Offset: 0x005B608C
	private void OnConfirmButtonClick(int _)
	{
		ResonantChain? roleResonanceById = ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceById(this.ResonanceId.Value);
		if (roleResonanceById == null)
		{
			return;
		}
		bool flag = true;
		foreach (KeyValuePair<int, int> keyValuePair in roleResonanceById.Value.ActivateConsume())
		{
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(keyValuePair.Key, 0);
			flag = (flag && commonItemCount >= keyValuePair.Value);
		}
		if (flag)
		{
			ControllerBase<RoleController>.Instance.SendResonanceUnlockRequest(this.RoleId);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ResonanceItemNotEnough", Array.Empty<object>());
	}

	// Token: 0x06014A48 RID: 84552 RVA: 0x005B7F58 File Offset: 0x005B6158
	private void OnBackButtonClick()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRoleInternalViewQuit);
	}

	// Token: 0x06014A49 RID: 84553 RVA: 0x005B7F6C File Offset: 0x005B616C
	public void ShowItem()
	{
		this.SequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x06014A4A RID: 84554 RVA: 0x005B7F94 File Offset: 0x005B6194
	public void HideItem()
	{
		this.SequencePlayer.PlayOrReplaySequenceByName("Close", false, null);
	}

	// Token: 0x06014A4B RID: 84555 RVA: 0x005B7FBC File Offset: 0x005B61BC
	public void Refresh(bool isTrial = false)
	{
		ResonantChain? roleResonanceById = ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceById(this.ResonanceId.Value);
		if (roleResonanceById != null)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleId, true);
			ERoleResonanceNodeState roleResonanceState = ModelBase<RoleModel>.Instance.GetRoleResonanceState(roleDataById, roleResonanceById.Value.GroupIndex);
			this.RefreshResonanceSprite(roleResonanceById.Value.GroupIndex);
			base.GetItem(5).SetUIActive(roleResonanceState == ERoleResonanceNodeState.ToBeActivated && !isTrial);
			base.GetItem(6).SetUIActive(roleResonanceState == ERoleResonanceNodeState.Activated && !isTrial);
			base.GetItem(7).SetUIActive(roleResonanceState == ERoleResonanceNodeState.NeedFrontActivated && !isTrial);
			this.NeedItem.GetRootItem().SetUIActive(roleResonanceState != ERoleResonanceNodeState.Activated && !isTrial);
			base.GetItem(10).SetUIActive(roleResonanceState != ERoleResonanceNodeState.Activated && !isTrial);
			base.GetText(0).ShowTextNew(roleResonanceById.Value.NodeName);
			int attributesDescriptionParamsLength = roleResonanceById.Value.AttributesDescriptionParamsLength;
			object[] array = new object[attributesDescriptionParamsLength];
			for (int i = 0; i < attributesDescriptionParamsLength; i++)
			{
				array[i] = roleResonanceById.Value.AttributesDescriptionParams(i);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), roleResonanceById.Value.AttributesDescription, array);
			base.GetText(8).ShowTextNew(roleResonanceById.Value.BgDescription);
			bool redDotVisible = ModelBase<RoleModel>.Instance.RedDotResonanceTabHoleCondition(this.RoleId, roleResonanceById.Value.GroupIndex);
			this.ConfirmButtonItem.SetRedDotVisible(redDotVisible);
			if (isTrial)
			{
				return;
			}
			using (Dictionary<int, int>.Enumerator enumerator = roleResonanceById.Value.ActivateConsume().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, int> kvp = enumerator.Current;
					PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
					{
						ItemConfigId = new int?(kvp.Key)
					};
					int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(kvp.Key, 0);
					propMediumItemGrid.BottomTextId = "Text_ItemEnoughText_Text";
					if (commonItemCount < kvp.Value)
					{
						propMediumItemGrid.BottomTextId = "Text_ItemNotEnoughText_Text";
					}
					propMediumItemGrid.BottomTextParameter = new object[]
					{
						commonItemCount,
						kvp.Value
					};
					this.NeedItem.Apply<PropMediumItemGrid>(propMediumItemGrid);
					this.NeedItem.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
					this.NeedItem.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
					{
						ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(kvp.Key, true, null);
					});
				}
			}
		}
	}

	// Token: 0x06014A4C RID: 84556 RVA: 0x005B82B8 File Offset: 0x005B64B8
	public void Update(int roleId, int resonanceId, bool isTrial = false)
	{
		this.RoleId = roleId;
		this.ResonanceId = new int?(resonanceId);
		this.Refresh(isTrial);
	}

	// Token: 0x06014A4D RID: 84557 RVA: 0x005B82D4 File Offset: 0x005B64D4
	private void RefreshResonanceSprite(int index)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_DeviceNum");
		defaultInterpolatedStringHandler.AppendFormatted<int>(index);
		string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(11), true, null, null);
	}

	// Token: 0x06014A4E RID: 84558 RVA: 0x005B832D File Offset: 0x005B652D
	public int? GetResonanceId()
	{
		return this.ResonanceId;
	}

	// Token: 0x06014A4F RID: 84559 RVA: 0x005B8335 File Offset: 0x005B6535
	[NullableContext(1)]
	public UUIItem GetUiItemForGuide()
	{
		ButtonItem confirmButtonItem = this.ConfirmButtonItem;
		object obj;
		if (confirmButtonItem == null)
		{
			obj = null;
		}
		else
		{
			UUIButtonComponent btn = confirmButtonItem.GetBtn();
			obj = ((btn != null) ? btn.GetOwner().GetComponentByClass(UUIItem.StaticClass()) : null);
		}
		return obj as UUIItem;
	}

	// Token: 0x04009F46 RID: 40774
	private int RoleId;

	// Token: 0x04009F47 RID: 40775
	private int? ResonanceId;

	// Token: 0x04009F48 RID: 40776
	private ButtonItem ConfirmButtonItem;

	// Token: 0x04009F49 RID: 40777
	private MediumItemGrid NeedItem;

	// Token: 0x04009F4A RID: 40778
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x02008BED RID: 35821
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402F22A RID: 193066
		NameText,
		// Token: 0x0402F22B RID: 193067
		DescriptionScrollView,
		// Token: 0x0402F22C RID: 193068
		SkillDescriptionText,
		// Token: 0x0402F22D RID: 193069
		NeedNode,
		// Token: 0x0402F22E RID: 193070
		NeedItem,
		// Token: 0x0402F22F RID: 193071
		ConfirmButtonItem,
		// Token: 0x0402F230 RID: 193072
		ActivatedItem,
		// Token: 0x0402F231 RID: 193073
		FrontItem,
		// Token: 0x0402F232 RID: 193074
		BgDescriptionText,
		// Token: 0x0402F233 RID: 193075
		BackButton,
		// Token: 0x0402F234 RID: 193076
		NeedItemNode,
		// Token: 0x0402F235 RID: 193077
		ResonanceNumSprite
	}
}
