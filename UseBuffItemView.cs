using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020017C9 RID: 6089
[NullableContext(1)]
[Nullable(0)]
public class UseBuffItemView : UiTickViewBase
{
	// Token: 0x0600ACBE RID: 44222 RVA: 0x002E103D File Offset: 0x002DF23D
	public UseBuffItemView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600ACBF RID: 44223 RVA: 0x002E1054 File Offset: 0x002DF254
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickedEnsureButton)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickedCancelButton))
		};
	}

	// Token: 0x0600ACC0 RID: 44224 RVA: 0x002E1144 File Offset: 0x002DF344
	private void OnClickedEnsureButton()
	{
		if (this.SelectedUseBuffItemRoleData == null)
		{
			this.CloseUseBuffItemView();
			return;
		}
		int useItemConfigId = this.SelectedUseBuffItemRoleData.UseItemConfigId;
		if ((float)ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(useItemConfigId) > 0f)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("UseBuffCdText", Array.Empty<object>());
			return;
		}
		if (this.SelectedUseBuffItemRoleData.CurrentAttribute <= 0f)
		{
			if (!ConfigBase<BuffItemConfig>.Instance.IsResurrectionItem(useItemConfigId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("UseBuffToDeadRole", Array.Empty<object>());
				return;
			}
		}
		else if (ConfigBase<BuffItemConfig>.Instance.IsResurrectionItem(useItemConfigId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("UseBuffToAliveRole", Array.Empty<object>());
			return;
		}
		float currentAttribute = this.SelectedUseBuffItemRoleData.CurrentAttribute;
		float num = this.SelectedUseBuffItemRoleData.GetAddAttribute();
		float maxAttribute = this.SelectedUseBuffItemRoleData.MaxAttribute;
		if (currentAttribute + num > maxAttribute)
		{
			string roleName = this.SelectedUseBuffItemRoleData.RoleName;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew((currentAttribute >= maxAttribute) ? EConfirmBoxConfigId.UseBuffItemToMaxLifeRoleTips : EConfirmBoxConfigId.UseBuffItemOverflow);
			Action value = delegate()
			{
				this.UiViewSequence.StopSequenceByKey("Popup", false, false);
				this.UiViewSequence.SequencePlayReverseByKey("Popup", false);
				this.EnsureUseItem();
			};
			Action value2 = delegate()
			{
				this.UiViewSequence.StopSequenceByKey("Popup", false, false);
				this.UiViewSequence.SequencePlayReverseByKey("Popup", false);
			};
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				roleName
			});
			confirmBoxDataNew.FunctionMap.Add(2, value);
			confirmBoxDataNew.FunctionMap.Add(1, value2);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			this.UiViewSequence.StopSequenceByKey("Popup", false, false);
			this.UiViewSequence.PlaySequence("Popup", false, null);
			return;
		}
		this.EnsureUseItem();
	}

	// Token: 0x0600ACC1 RID: 44225 RVA: 0x002E12CE File Offset: 0x002DF4CE
	private void OnClickedCancelButton()
	{
		this.CloseUseBuffItemView();
	}

	// Token: 0x0600ACC2 RID: 44226 RVA: 0x002E12D8 File Offset: 0x002DF4D8
	private void InitializeUseBuffItemView(int useItemConfigId)
	{
		this.CreateAllBuffTargetRoleItems();
		this.RefreshAllBuffTargetRoleItems();
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		bool flag = false;
		foreach (BuffTargetRoleItem buffTargetRoleItem in this.BuffTargetRoleItemList)
		{
			UseBuffItemRoleData useBuffItemRoleData = buffTargetRoleItem.GetUseBuffItemRoleData();
			if (useBuffItemRoleData != null && useBuffItemRoleData.GetEntityId() == getCurrentEntity.Id)
			{
				this.SelectedUseBuffTargetRoleItem(buffTargetRoleItem);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			this.SelectedUseBuffTargetRoleItem(this.BuffTargetRoleItemList[0]);
		}
	}

	// Token: 0x0600ACC3 RID: 44227 RVA: 0x002E1378 File Offset: 0x002DF578
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ItemUseCount"), new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x0600ACC4 RID: 44228 RVA: 0x002E1399 File Offset: 0x002DF599
	private void ValueChangeFunction(int selectValue)
	{
		this.SelectedUseBuffItemRoleData.SetUseItemCount(selectValue);
		this.RefreshAttributePreview();
	}

	// Token: 0x0600ACC5 RID: 44229 RVA: 0x002E13B0 File Offset: 0x002DF5B0
	private int GetUseBuffItemMaxNumber()
	{
		int useItemConfigId = this.SelectedUseBuffItemRoleData.UseItemConfigId;
		if (ConfigBase<BuffItemConfig>.Instance.IsResurrectionItem(useItemConfigId))
		{
			return 1;
		}
		if (ConfigBase<BuffItemConfig>.Instance.GetBuffItemTotalCdTime(useItemConfigId) > 0)
		{
			return 1;
		}
		return this.SelectedUseBuffItemRoleData.GetUseItemMaxCount();
	}

	// Token: 0x0600ACC6 RID: 44230 RVA: 0x002E13F4 File Offset: 0x002DF5F4
	private void InitNumberSelect()
	{
		this.NumberSelect = new NumberSelectComponent(base.GetItem(6));
		this.NumberSelectData = new INumberSelectData
		{
			MaxNumber = this.GetUseBuffItemMaxNumber(),
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(this.NumberSelectData);
	}

	// Token: 0x0600ACC7 RID: 44231 RVA: 0x002E1460 File Offset: 0x002DF660
	protected override void OnStart()
	{
		int? num = this.OpenParam as int?;
		if (num == null)
		{
			return;
		}
		this.InitializeUseBuffItemView(num.Value);
		this.InitNumberSelect();
	}

	// Token: 0x0600ACC8 RID: 44232 RVA: 0x002E149B File Offset: 0x002DF69B
	protected override void OnBeforeDestroy()
	{
		this.ResetUseBuffItemView();
		this.NumberSelect.Destroy(null);
		this.NumberSelectData = null;
		this.NumberSelect = null;
		ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
	}

	// Token: 0x0600ACC9 RID: 44233 RVA: 0x002E14C7 File Offset: 0x002DF6C7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, long, int>(EEventName.OnUseBuffItem, new Action<int, long, int>(this.OnUseBuffItem));
	}

	// Token: 0x0600ACCA RID: 44234 RVA: 0x002E14E5 File Offset: 0x002DF6E5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUseBuffItem, new Action<int, long, int>(this.OnUseBuffItem));
	}

	// Token: 0x0600ACCB RID: 44235 RVA: 0x002E1504 File Offset: 0x002DF704
	protected override void OnTick(float delta)
	{
		foreach (BuffTargetRoleItem buffTargetRoleItem in this.BuffTargetRoleItemList)
		{
			buffTargetRoleItem.Tick(delta);
		}
	}

	// Token: 0x0600ACCC RID: 44236 RVA: 0x002E1558 File Offset: 0x002DF758
	private void OnUseBuffItem(int itemConfigId, long endCdTimeStamp, int useCount)
	{
		if (this.SelectedBuffTargetRoleItem == null)
		{
			return;
		}
		this.FinishUseBuffItem();
	}

	// Token: 0x0600ACCD RID: 44237 RVA: 0x002E1569 File Offset: 0x002DF769
	private void CloseUseBuffItemView()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.UseBuffItemView, null);
	}

	// Token: 0x0600ACCE RID: 44238 RVA: 0x002E157C File Offset: 0x002DF77C
	public void ResetUseBuffItemView()
	{
		foreach (BuffTargetRoleItem buffTargetRoleItem in this.BuffTargetRoleItemList)
		{
			buffTargetRoleItem.ResetBuffTargetRoleItem();
		}
		this.BuffTargetRoleItemList.Clear();
		this.SelectedUseBuffItemRoleData = null;
		this.SelectedBuffTargetRoleItem = null;
		ModelBase<BuffItemModel>.Instance.ClearAllUseBuffItemRoleData();
	}

	// Token: 0x0600ACCF RID: 44239 RVA: 0x002E15F0 File Offset: 0x002DF7F0
	private void CreateAllBuffTargetRoleItems()
	{
		foreach (UUIItem uuiitem in new List<UUIItem>
		{
			base.GetItem(1),
			base.GetItem(2),
			base.GetItem(3)
		})
		{
			AActor owner = uuiitem.GetOwner();
			BuffTargetRoleItem buffTargetRoleItem = new BuffTargetRoleItem();
			buffTargetRoleItem.Initialize(owner);
			buffTargetRoleItem.BindOnClickedBuffTargetRoleItem(new Action<BuffTargetRoleItem>(this.OnClickedBuffTargetRoleItem));
			buffTargetRoleItem.BindOnUseItemAnimationFinished(new Action(this.OnUseItemAnimationFinished));
			this.BuffTargetRoleItemList.Add(buffTargetRoleItem);
		}
	}

	// Token: 0x0600ACD0 RID: 44240 RVA: 0x002E16A4 File Offset: 0x002DF8A4
	private void OnClickedBuffTargetRoleItem(BuffTargetRoleItem buffTargetRoleItem)
	{
		this.SelectedUseBuffTargetRoleItem(buffTargetRoleItem);
	}

	// Token: 0x0600ACD1 RID: 44241 RVA: 0x002E16B0 File Offset: 0x002DF8B0
	private void SelectedUseBuffTargetRoleItem(BuffTargetRoleItem buffTargetRoleItem)
	{
		UseBuffItemRoleData useBuffItemRoleData = buffTargetRoleItem.GetUseBuffItemRoleData();
		if (useBuffItemRoleData == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoneRole", Array.Empty<object>());
			return;
		}
		if (buffTargetRoleItem.IsSelected())
		{
			return;
		}
		buffTargetRoleItem.SetSelected(true);
		if (this.SelectedUseBuffItemRoleData != null)
		{
			this.SelectedUseBuffItemRoleData.SetUseItemCount(0);
		}
		if (this.SelectedBuffTargetRoleItem != null)
		{
			this.SelectedBuffTargetRoleItem.SetSelected(false);
		}
		this.SelectedUseBuffItemRoleData = useBuffItemRoleData;
		this.SelectedBuffTargetRoleItem = buffTargetRoleItem;
		useBuffItemRoleData.SetUseItemCount(1);
		this.RefreshAttributePreview();
		this.RefreshTitleText();
		if (this.NumberSelectData != null)
		{
			NumberSelectComponent numberSelect = this.NumberSelect;
			if (numberSelect == null)
			{
				return;
			}
			numberSelect.Init(this.NumberSelectData);
		}
	}

	// Token: 0x0600ACD2 RID: 44242 RVA: 0x002E1753 File Offset: 0x002DF953
	private void OnUseItemAnimationFinished()
	{
		this.FinishUseBuffItem();
	}

	// Token: 0x0600ACD3 RID: 44243 RVA: 0x002E175C File Offset: 0x002DF95C
	private void FinishUseBuffItem()
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		int useItemConfigId = this.SelectedUseBuffItemRoleData.UseItemConfigId;
		if (instance.GetItemCountByConfigId(useItemConfigId, 0) < 1)
		{
			this.CloseUseBuffItemView();
			return;
		}
		int useBuffItemMaxNumber = this.GetUseBuffItemMaxNumber();
		this.NumberSelect.SetLimitMaxValue(useBuffItemMaxNumber);
		this.NumberSelect.Refresh(useBuffItemMaxNumber);
	}

	// Token: 0x0600ACD4 RID: 44244 RVA: 0x002E17AC File Offset: 0x002DF9AC
	private void RefreshAllBuffTargetRoleItems()
	{
		IReadOnlyDictionary<int, UseBuffItemRoleData> allUseBuffItemRole = ModelBase<BuffItemModel>.Instance.GetAllUseBuffItemRole();
		foreach (BuffTargetRoleItem buffTargetRoleItem in this.BuffTargetRoleItemList)
		{
			buffTargetRoleItem.SetActive(false);
		}
		int num = 0;
		for (int i = 0; i < this.BuffTargetRoleItemList.Count; i++)
		{
			int key = i + 1;
			UseBuffItemRoleData useBuffItemRoleData;
			allUseBuffItemRole.TryGetValue(key, out useBuffItemRoleData);
			BuffTargetRoleItem buffTargetRoleItem2 = this.BuffTargetRoleItemList[num];
			if (useBuffItemRoleData != null)
			{
				buffTargetRoleItem2.RefreshBuffTargetRoleItem(useBuffItemRoleData);
				buffTargetRoleItem2.SetActive(true);
				num++;
			}
			else
			{
				buffTargetRoleItem2.RemoveRole();
			}
		}
	}

	// Token: 0x0600ACD5 RID: 44245 RVA: 0x002E1860 File Offset: 0x002DFA60
	private void RefreshAttributePreview()
	{
		if (this.SelectedUseBuffItemRoleData == null)
		{
			return;
		}
		if (this.SelectedBuffTargetRoleItem == null)
		{
			return;
		}
		float currentAttribute = this.SelectedUseBuffItemRoleData.CurrentAttribute;
		float maxAttribute = this.SelectedUseBuffItemRoleData.MaxAttribute;
		float addAttribute = this.SelectedUseBuffItemRoleData.GetAddAttribute();
		this.SelectedBuffTargetRoleItem.RefreshPreviewUseItem(currentAttribute, maxAttribute, addAttribute);
	}

	// Token: 0x0600ACD6 RID: 44246 RVA: 0x002E18B4 File Offset: 0x002DFAB4
	private void RefreshTitleText()
	{
		if (this.SelectedUseBuffItemRoleData == null)
		{
			return;
		}
		string roleName = this.SelectedUseBuffItemRoleData.RoleName;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "UseBuffTitle", new <>z__ReadOnlySingleElementList<object>(roleName));
	}

	// Token: 0x0600ACD7 RID: 44247 RVA: 0x002E18F4 File Offset: 0x002DFAF4
	private void EnsureUseItem()
	{
		if (this.SelectedUseBuffItemRoleData == null)
		{
			this.CloseUseBuffItemView();
			return;
		}
		int useItemConfigId = this.SelectedUseBuffItemRoleData.UseItemConfigId;
		int useItemCount = this.SelectedUseBuffItemRoleData.UseItemCount;
		int roleConfigId = this.SelectedUseBuffItemRoleData.RoleConfigId;
		ControllerBase<BuffItemControl>.Instance.RequestUseBuffItem(useItemConfigId, useItemCount, roleConfigId);
	}

	// Token: 0x040051D3 RID: 20947
	private readonly List<BuffTargetRoleItem> BuffTargetRoleItemList = new List<BuffTargetRoleItem>();

	// Token: 0x040051D4 RID: 20948
	[Nullable(2)]
	private BuffTargetRoleItem SelectedBuffTargetRoleItem;

	// Token: 0x040051D5 RID: 20949
	[Nullable(2)]
	private UseBuffItemRoleData SelectedUseBuffItemRoleData;

	// Token: 0x040051D6 RID: 20950
	[Nullable(2)]
	private NumberSelectComponent NumberSelect;

	// Token: 0x040051D7 RID: 20951
	[Nullable(2)]
	private INumberSelectData NumberSelectData;

	// Token: 0x02007B58 RID: 31576
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402A2B3 RID: 172723
		TitleText,
		// Token: 0x0402A2B4 RID: 172724
		TargetRoleItem1,
		// Token: 0x0402A2B5 RID: 172725
		TargetRoleItem2,
		// Token: 0x0402A2B6 RID: 172726
		TargetRoleItem3,
		// Token: 0x0402A2B7 RID: 172727
		EnsureButton,
		// Token: 0x0402A2B8 RID: 172728
		CancelButton,
		// Token: 0x0402A2B9 RID: 172729
		NumberSelect
	}
}
