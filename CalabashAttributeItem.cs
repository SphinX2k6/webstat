using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020017FB RID: 6139
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class CalabashAttributeItem : GridProxyAbstract<CalabashAttributeData>
{
	// Token: 0x0600AE62 RID: 44642 RVA: 0x002E61B8 File Offset: 0x002E43B8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600AE63 RID: 44643 RVA: 0x002E62B9 File Offset: 0x002E44B9
	private void OnClickToggle(EToggleState toggleState)
	{
		CalabashAttributeData data = this.Data;
		if (data == null)
		{
			return;
		}
		Action<CalabashAttributeData> clickCallBack = data.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this.Data);
	}

	// Token: 0x0600AE64 RID: 44644 RVA: 0x002E62DC File Offset: 0x002E44DC
	protected override void OnStart()
	{
		base.GetVerticalLayout(7).RootUIComp.Get().SetUIActive(false);
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.TargetLayout = new GenericLayout<CalabashAttributeContentItem, CalabashAttributeContentData>(base.GetVerticalLayout(7), new Func<CalabashAttributeContentItem>(this.InitItem), null, false, true);
	}

	// Token: 0x0600AE65 RID: 44645 RVA: 0x002E6335 File Offset: 0x002E4535
	private CalabashAttributeContentItem InitItem()
	{
		return new CalabashAttributeContentItem();
	}

	// Token: 0x0600AE66 RID: 44646 RVA: 0x002E633C File Offset: 0x002E453C
	private void ShowBasicAbsorptionInfo(CalabashAttributeData data)
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Value.TextKey, data.Value.Params);
		UUIItem item2 = base.GetItem(6);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600AE67 RID: 44647 RVA: 0x002E63A4 File Offset: 0x002E45A4
	private void ShowUpAbsorptionInfo(CalabashAttributeData data)
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		if (data.Value != null)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text, data.Value.TextKey, data.Value.Params);
		}
		List<CalabashAttributeContentData> list = new List<CalabashAttributeContentData>();
		list.Add(new CalabashAttributeContentData
		{
			Type = ECalabashLevelSubShowType.UpgradeTarget,
			StringKey = "UpAbsorptionTarget",
			StringValue = new TableTextArgNew("UpAbsorptionTargetName", Array.Empty<object>())
		});
		CalabashAttributeContentData calabashAttributeContentData = new CalabashAttributeContentData();
		calabashAttributeContentData.Type = ECalabashLevelSubShowType.UpgradeTarget;
		calabashAttributeContentData.StringKey = "UpAbsorptionTimeText";
		int currentSelectLevel = data.CurrentSelectLevel;
		CalabashModel instance = ModelBase<CalabashModel>.Instance;
		int num = (instance != null) ? instance.GetLeftIntensifyCaptureGuarantee() : 0;
		CalabashConfig instance2 = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel = (instance2 != null) ? instance2.GetCalabashConfigByLevel(currentSelectLevel) : null;
		int num2 = (calabashLevel != null) ? calabashLevel.GetValueOrDefault().IntensifyCaptureGuarantee : 0;
		calabashAttributeContentData.StringValue = new TableTextArgNew("UpAbsorptionTimeDescText", new <>z__ReadOnlyArray<object>(new object[]
		{
			num.ToString(),
			num2.ToString()
		}));
		list.Add(calabashAttributeContentData);
		GenericLayout<CalabashAttributeContentItem, CalabashAttributeContentData> targetLayout = this.TargetLayout;
		if (targetLayout == null)
		{
			return;
		}
		targetLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600AE68 RID: 44648 RVA: 0x002E64F0 File Offset: 0x002E46F0
	private void ShowLowCostUpAbsorptionInfo(CalabashAttributeData data)
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		if (data.Value != null)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text, data.Value.TextKey, data.Value.Params);
		}
		List<CalabashAttributeContentData> list = new List<CalabashAttributeContentData>();
		list.Add(new CalabashAttributeContentData
		{
			Type = ECalabashLevelSubShowType.UpgradeTarget,
			StringKey = "UpAbsorptionTarget",
			StringValue = new TableTextArgNew(ECalabashTxt.UpAbsorptionTargetNameJunior.ToString(), Array.Empty<object>())
		});
		CalabashAttributeContentData calabashAttributeContentData = new CalabashAttributeContentData();
		calabashAttributeContentData.Type = ECalabashLevelSubShowType.UpgradeTarget;
		calabashAttributeContentData.StringKey = "UpAbsorptionTimeText";
		int currentSelectLevel = data.CurrentSelectLevel;
		CalabashModel instance = ModelBase<CalabashModel>.Instance;
		int num = (instance != null) ? instance.GetLeftLowCostIntensifyCaptureGuarantee() : 0;
		CalabashConfig instance2 = ConfigBase<CalabashConfig>.Instance;
		CalabashLevel? calabashLevel = (instance2 != null) ? instance2.GetCalabashConfigByLevel(currentSelectLevel) : null;
		int num2 = (calabashLevel != null) ? calabashLevel.GetValueOrDefault().LowCostIntensifyCaptureGuarantee : 0;
		calabashAttributeContentData.StringValue = new TableTextArgNew("UpAbsorptionTimeDescText", new <>z__ReadOnlyArray<object>(new object[]
		{
			num.ToString(),
			num2.ToString()
		}));
		list.Add(calabashAttributeContentData);
		GenericLayout<CalabashAttributeContentItem, CalabashAttributeContentData> targetLayout = this.TargetLayout;
		if (targetLayout == null)
		{
			return;
		}
		targetLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600AE69 RID: 44649 RVA: 0x002E6648 File Offset: 0x002E4848
	private void ShowMaxCostInfo(CalabashAttributeData data)
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText(data.CostCount.ToString(), true);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600AE6A RID: 44650 RVA: 0x002E66AC File Offset: 0x002E48AC
	private void ShowMaxQualityInfo(CalabashAttributeData data)
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Value.TextKey, data.Value.Params);
		int currentSelectLevel = data.CurrentSelectLevel;
		CalabashLevel? calabashConfigByLevel = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(currentSelectLevel);
		Dictionary<int, int> dictionary = (calabashConfigByLevel != null) ? calabashConfigByLevel.GetValueOrDefault().QualityDropWeight() : null;
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		List<CalabashAttributeContentData> list = new List<CalabashAttributeContentData>();
		if (dictionary != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int value = keyValuePair.Value;
				if (value > 0)
				{
					list.Add(new CalabashAttributeContentData
					{
						Type = ECalabashLevelSubShowType.UpgradeQuality,
						Key = keyValuePair.Key,
						Value = value
					});
				}
			}
		}
		GenericLayout<CalabashAttributeContentItem, CalabashAttributeContentData> targetLayout = this.TargetLayout;
		if (targetLayout == null)
		{
			return;
		}
		targetLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600AE6B RID: 44651 RVA: 0x002E67DC File Offset: 0x002E49DC
	private void RefreshLayoutItemShowState()
	{
		CalabashAttributeData data = this.Data;
		if (data != null && data.CurrentSelect)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		else
		{
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
	}

	// Token: 0x0600AE6C RID: 44652 RVA: 0x002E682C File Offset: 0x002E4A2C
	public override void Refresh(CalabashAttributeData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(data.Type == ECalabashAttributeDataType.MaxQuality && data.IsUp);
		}
		this.RefreshLayoutItemShowState();
		this.RefreshToggleRaycastActive(data.IsToggleRaycast);
		switch (data.Type)
		{
		case ECalabashAttributeDataType.BasicAbsorption:
			this.ShowBasicAbsorptionInfo(data);
			break;
		case ECalabashAttributeDataType.UpAbsorption:
			this.ShowUpAbsorptionInfo(data);
			break;
		case ECalabashAttributeDataType.LowCostUpAbsorption:
			this.ShowLowCostUpAbsorptionInfo(data);
			break;
		case ECalabashAttributeDataType.MaxQuality:
			this.ShowMaxQualityInfo(data);
			break;
		case ECalabashAttributeDataType.MaxCost:
			this.ShowMaxCostInfo(data);
			break;
		}
		if (this.CurrentSelectState != data.CurrentSelect)
		{
			this.CurrentSelectState = data.CurrentSelect;
			this.PlaySequenceBySelectState(this.CurrentSelectState);
		}
	}

	// Token: 0x0600AE6D RID: 44653 RVA: 0x002E6908 File Offset: 0x002E4B08
	private void RefreshToggleRaycastActive(bool boolValue)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.RootUIComp.Get().SetRaycastTarget(boolValue);
	}

	// Token: 0x0600AE6E RID: 44654 RVA: 0x002E6934 File Offset: 0x002E4B34
	private void PlaySequenceBySelectState(bool state)
	{
		string sequenceName = state ? "Show" : "Hide";
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
	}

	// Token: 0x040052BC RID: 21180
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<CalabashAttributeContentItem, CalabashAttributeContentData> TargetLayout;

	// Token: 0x040052BD RID: 21181
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040052BE RID: 21182
	[Nullable(2)]
	private CalabashAttributeData Data;

	// Token: 0x040052BF RID: 21183
	private bool CurrentSelectState;
}
