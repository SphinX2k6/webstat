using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200180B RID: 6155
[NullableContext(2)]
[Nullable(0)]
public class VisionRecoverySlotItem : UiPanelBase
{
	// Token: 0x0600AF01 RID: 44801 RVA: 0x002E9A4D File Offset: 0x002E7C4D
	public VisionRecoverySlotItem(Action<bool, PhantomItemData> callBack = null, bool showRemoveBtn = true)
	{
		this.ClickCallBack = callBack;
		this.ShowRemoveBtn = showRemoveBtn;
	}

	// Token: 0x0600AF02 RID: 44802 RVA: 0x002E9A64 File Offset: 0x002E7C64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(0, typeof(UUISpriteTransition)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickAddButton)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickRemoveButton))
		};
	}

	// Token: 0x0600AF03 RID: 44803 RVA: 0x002E9BAC File Offset: 0x002E7DAC
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRecoverySlotItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRecoverySlotItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF04 RID: 44804 RVA: 0x002E9BF0 File Offset: 0x002E7DF0
	protected override void OnStart()
	{
		this.RefreshUi(this.VisionData);
		bool enable = this.ClickCallBack != null;
		base.GetUiSpriteTransition(0).SetEnable(enable);
		base.GetItem(7).SetUIActive(false);
		this.OnAddEvent();
	}

	// Token: 0x0600AF05 RID: 44805 RVA: 0x002E9C33 File Offset: 0x002E7E33
	protected override void OnBeforeDestroy()
	{
		this.OnRemoveEvent();
	}

	// Token: 0x0600AF06 RID: 44806 RVA: 0x002E9C3B File Offset: 0x002E7E3B
	private void OnAddEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnFuncValueChange));
	}

	// Token: 0x0600AF07 RID: 44807 RVA: 0x002E9C59 File Offset: 0x002E7E59
	private void OnRemoveEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnFuncValueChange));
	}

	// Token: 0x0600AF08 RID: 44808 RVA: 0x002E9C77 File Offset: 0x002E7E77
	public void RefreshUi(PhantomItemData data)
	{
		this.VisionData = data;
		if (data == null)
		{
			this.RefreshEmpty();
			return;
		}
		this.RefreshByData(data);
	}

	// Token: 0x0600AF09 RID: 44809 RVA: 0x002E9C94 File Offset: 0x002E7E94
	public void RefreshEmpty()
	{
		base.GetItem(1).SetUIActive(true);
		base.GetTexture(2).SetUIActive(false);
		base.GetSprite(3).SetUIActive(false);
		base.GetButton(5).RootUIComp.Get().SetUIActive(false);
		this.VisionElementItem.SetUiActive(false);
		base.GetItem(7).SetUIActive(false);
		base.GetItem(9).SetUIActive(false);
		base.GetItem(10).SetUIActive(false);
	}

	// Token: 0x0600AF0A RID: 44810 RVA: 0x002E9D18 File Offset: 0x002E7F18
	[NullableContext(1)]
	public void RefreshByData(PhantomItemData data)
	{
		UUITexture icon = base.GetTexture(2);
		UUISprite qualitySprite = base.GetSprite(3);
		string phantomQualityBgSprite = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(data.GetQuality());
		this.SetSpriteByPath(phantomQualityBgSprite, qualitySprite, false, null, delegate(bool _)
		{
			qualitySprite.SetUIActive(true);
		});
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(data.GetUniqueId());
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(phantomBattleData.GetConfigId(true));
		base.SetTextureByPath(itemConfigData.IconMiddle, icon, null, delegate(bool _)
		{
			icon.SetUIActive(true);
			this.GetItem(1).SetUIActive(false);
			this.GetButton(5).RootUIComp.Get().SetUIActive(this.ShowRemoveBtn);
			PhantomFetterGroup? fetterGroupConfig = data.GetFetterGroupConfig();
			if (fetterGroupConfig != null)
			{
				this.VisionElementItem.Update(fetterGroupConfig);
			}
			this.VisionElementItem.SetUiActive(!this.ShowRemoveBtn && fetterGroupConfig != null);
		});
		int rarity = data.GetConfig().As<PhantomItem>().Value.Rarity;
		int cost = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost;
		base.GetItem(7).SetUIActive(true);
		base.GetText(8).SetText(cost.ToString(), true);
		this.RefreshLockAndDeprecate();
	}

	// Token: 0x0600AF0B RID: 44811 RVA: 0x002E9E48 File Offset: 0x002E8048
	private void RefreshLockAndDeprecate()
	{
		AttributeItemData attributeItemData = (this.VisionData != null) ? ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.VisionData.GetUniqueId()) : null;
		if (attributeItemData == null)
		{
			base.GetItem(9).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
			return;
		}
		base.GetItem(9).SetUIActive(attributeItemData.GetIsLock());
		base.GetItem(10).SetUIActive(attributeItemData.GetIsDeprecated());
	}

	// Token: 0x0600AF0C RID: 44812 RVA: 0x002E9EBC File Offset: 0x002E80BC
	private void OnClickAddButton()
	{
		if (this.ClickCallBack != null)
		{
			this.ClickCallBack(true, this.VisionData);
		}
	}

	// Token: 0x0600AF0D RID: 44813 RVA: 0x002E9ED8 File Offset: 0x002E80D8
	private void OnClickRemoveButton()
	{
		if (this.ClickCallBack != null)
		{
			this.ClickCallBack(false, this.VisionData);
		}
	}

	// Token: 0x0600AF0E RID: 44814 RVA: 0x002E9EF4 File Offset: 0x002E80F4
	private void OnFuncValueChange(int uniqueId)
	{
		if (this.VisionData != null && this.VisionData.GetUniqueId() == uniqueId)
		{
			this.RefreshLockAndDeprecate();
		}
	}

	// Token: 0x04005304 RID: 21252
	private PhantomItemData VisionData;

	// Token: 0x04005305 RID: 21253
	private VisionFetterSuitItem VisionElementItem;

	// Token: 0x04005306 RID: 21254
	private readonly Action<bool, PhantomItemData> ClickCallBack;

	// Token: 0x04005307 RID: 21255
	private readonly bool ShowRemoveBtn;

	// Token: 0x02007B83 RID: 31619
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A376 RID: 172918
		ChooseTransition,
		// Token: 0x0402A377 RID: 172919
		EmptyItem,
		// Token: 0x0402A378 RID: 172920
		Icon,
		// Token: 0x0402A379 RID: 172921
		QualitySprite,
		// Token: 0x0402A37A RID: 172922
		AddVisionButton,
		// Token: 0x0402A37B RID: 172923
		RemoveVisionButton,
		// Token: 0x0402A37C RID: 172924
		VisionElementItem,
		// Token: 0x0402A37D RID: 172925
		CostPanel,
		// Token: 0x0402A37E RID: 172926
		CostText,
		// Token: 0x0402A37F RID: 172927
		PanelLock,
		// Token: 0x0402A380 RID: 172928
		PanelDeprecate
	}
}
