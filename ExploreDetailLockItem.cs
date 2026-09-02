using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B86 RID: 7046
public class ExploreDetailLockItem : UiPanelBase
{
	// Token: 0x1700108C RID: 4236
	// (get) Token: 0x0600CCC0 RID: 52416 RVA: 0x00367B0F File Offset: 0x00365D0F
	public int MarkId
	{
		get
		{
			return this.MarkIdInner;
		}
	}

	// Token: 0x0600CCC1 RID: 52417 RVA: 0x00367B18 File Offset: 0x00365D18
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickFunctionButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CCC2 RID: 52418 RVA: 0x00367BE0 File Offset: 0x00365DE0
	public void RefreshExternalByData(int markId)
	{
		this.MarkIdInner = markId;
		this.RootItem.SetUIActive(true);
		MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(this.MarkIdInner);
		UUIText text = base.GetText(1);
		if (((configMark != null) ? configMark.GetValueOrDefault().GameplayLockText : null) != null)
		{
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, configMark.Value.GameplayLockText, Array.Empty<object>());
			return;
		}
		if (text != null)
		{
			text.SetUIActive(false);
		}
	}

	// Token: 0x0600CCC3 RID: 52419 RVA: 0x00367C6A File Offset: 0x00365E6A
	public void Reset(int? markId = null)
	{
		this.MarkIdInner = markId.GetValueOrDefault();
		this.RootItem.SetUIActive(false);
	}

	// Token: 0x0600CCC4 RID: 52420 RVA: 0x00367C88 File Offset: 0x00365E88
	private void OnClickFunctionButton()
	{
		MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(this.MarkIdInner);
		if (configMark != null && configMark.GetValueOrDefault().GameplayLockJumpId > 0)
		{
			SkipTaskManager.RunByConfigId(configMark.Value.GameplayLockJumpId, null);
		}
	}

	// Token: 0x040061E0 RID: 25056
	private int MarkIdInner;

	// Token: 0x02007E66 RID: 32358
	private enum ELockComponent
	{
		// Token: 0x0402B0E6 RID: 176358
		LockSprite,
		// Token: 0x0402B0E7 RID: 176359
		LockDescriptionText,
		// Token: 0x0402B0E8 RID: 176360
		FunctionButton
	}
}
