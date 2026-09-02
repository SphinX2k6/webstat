using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002812 RID: 10258
[NullableContext(2)]
[Nullable(0)]
public class RoleDevPhantomHeadItem : UiPanelBase
{
	// Token: 0x060143E6 RID: 82918 RVA: 0x005A2841 File Offset: 0x005A0A41
	public RoleDevPhantomHeadItem(int index)
	{
		this.Index = index;
	}

	// Token: 0x060143E7 RID: 82919 RVA: 0x005A2850 File Offset: 0x005A0A50
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickHeadItem))
		};
	}

	// Token: 0x060143E8 RID: 82920 RVA: 0x005A2968 File Offset: 0x005A0B68
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevPhantomHeadItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevPhantomHeadItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060143E9 RID: 82921 RVA: 0x005A29AB File Offset: 0x005A0BAB
	public void SetRoleId(int roleId)
	{
		this.CurrentRoleId = new int?(roleId);
	}

	// Token: 0x060143EA RID: 82922 RVA: 0x005A29B9 File Offset: 0x005A0BB9
	public void UpdateItem(PhantomDataBase data)
	{
		this.CurrentData = data;
		this.OnUpdateItem(data);
	}

	// Token: 0x060143EB RID: 82923 RVA: 0x005A29CC File Offset: 0x005A0BCC
	protected void OnUpdateItem(PhantomDataBase data)
	{
		if (data != null)
		{
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			this.RefreshIcon(data);
			this.RefreshQuality(data);
			this.RefreshNum(data);
			this.RefreshLevel(data);
			this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(data.GetFetterGroupConfig()));
			return;
		}
		UUIItem item3 = base.GetItem(8);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIItem item4 = base.GetItem(9);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(true);
	}

	// Token: 0x060143EC RID: 82924 RVA: 0x005A2A5C File Offset: 0x005A0C5C
	[NullableContext(1)]
	private void RefreshIcon(PhantomDataBase data)
	{
		UUITexture texture = base.GetTexture(1);
		if (texture != null && data != null)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data.GetConfigId(true));
			string text = (itemConfigData != null) ? itemConfigData.Icon : null;
			if (!string.IsNullOrEmpty(text))
			{
				base.SetTextureByPath(text, texture, null, null);
			}
		}
	}

	// Token: 0x060143ED RID: 82925 RVA: 0x005A2AB0 File Offset: 0x005A0CB0
	[NullableContext(1)]
	private void RefreshQuality(PhantomDataBase data)
	{
		UUISprite sprite = base.GetSprite(2);
		if (sprite != null && data != null)
		{
			int quality = data.GetQuality();
			string phantomQualityBgSprite = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(quality);
			if (!string.IsNullOrEmpty(phantomQualityBgSprite))
			{
				this.SetSpriteByPath(phantomQualityBgSprite, sprite, false, null, null);
			}
		}
	}

	// Token: 0x060143EE RID: 82926 RVA: 0x005A2AFC File Offset: 0x005A0CFC
	[NullableContext(1)]
	private void RefreshNum(PhantomDataBase data)
	{
		UUIText text = base.GetText(4);
		if (text != null && data != null)
		{
			text.SetText(data.GetCost().ToString(), true);
		}
	}

	// Token: 0x060143EF RID: 82927 RVA: 0x005A2B2C File Offset: 0x005A0D2C
	[NullableContext(1)]
	private void RefreshLevel(PhantomDataBase data)
	{
		UUIText text = base.GetText(7);
		if (text != null && data != null)
		{
			text.SetText("+" + data.GetPhantomLevel().ToString(), true);
		}
	}

	// Token: 0x060143F0 RID: 82928 RVA: 0x005A2B66 File Offset: 0x005A0D66
	public PhantomDataBase GetCurrentData()
	{
		return this.CurrentData;
	}

	// Token: 0x060143F1 RID: 82929 RVA: 0x005A2B70 File Offset: 0x005A0D70
	private void OnClickHeadItem()
	{
		if (this.CurrentRoleId == null)
		{
			return;
		}
		int index = this.Index;
		ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex = index;
		int equipByIndex = ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(this.CurrentRoleId.Value, index);
		ModelBase<PhantomBattleModel>.Instance.CurrentSelectUniqueId = equipByIndex;
		PhantomUtil.OpenVisionEquipmentView(this.CurrentRoleId.Value, index, null);
	}

	// Token: 0x04009D83 RID: 40323
	private PhantomDataBase CurrentData;

	// Token: 0x04009D84 RID: 40324
	private int? CurrentRoleId;

	// Token: 0x04009D85 RID: 40325
	private readonly int Index;

	// Token: 0x04009D86 RID: 40326
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02008B99 RID: 35737
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F0B9 RID: 192697
		ButtonHeadItem,
		// Token: 0x0402F0BA RID: 192698
		CircleItemTexture,
		// Token: 0x0402F0BB RID: 192699
		QualitySprite,
		// Token: 0x0402F0BC RID: 192700
		CostItem,
		// Token: 0x0402F0BD RID: 192701
		CostNumText,
		// Token: 0x0402F0BE RID: 192702
		SuitElementItem,
		// Token: 0x0402F0BF RID: 192703
		LevelItem,
		// Token: 0x0402F0C0 RID: 192704
		LevelText,
		// Token: 0x0402F0C1 RID: 192705
		PanelNor,
		// Token: 0x0402F0C2 RID: 192706
		PanelEmpty
	}
}
