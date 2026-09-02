using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001438 RID: 5176
internal class MowingBuffEntry : UiPanelBase
{
	// Token: 0x06009014 RID: 36884 RVA: 0x0025DCB8 File Offset: 0x0025BEB8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickEntryButton))
		};
	}

	// Token: 0x06009015 RID: 36885 RVA: 0x0025DDB9 File Offset: 0x0025BFB9
	private void OnClickEntryButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MowingTowerBuffView, null, null);
	}

	// Token: 0x06009016 RID: 36886 RVA: 0x0025DDCC File Offset: 0x0025BFCC
	[NullableContext(1)]
	public void Refresh(MowingTowerBuffInfo buff)
	{
		this.CurrentSelectBuff = buff;
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.SetSelectionState(EUISelectableSelectionState.Normal);
		}
		UUIButtonComponent button2 = base.GetButton(0);
		if (button2 != null)
		{
			button2.SetSelfInteractive(true);
		}
		this.RefreshNoneShow();
		this.RefreshBuffInfo();
		this.RefreshLockItemState();
		this.RefreshSwitchButton();
		this.RefreshBuffTips();
	}

	// Token: 0x06009017 RID: 36887 RVA: 0x0025DE24 File Offset: 0x0025C024
	private void RefreshBuffTips()
	{
		string textStringId = "BossRushBuffSelectTips";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId, Array.Empty<object>());
	}

	// Token: 0x06009018 RID: 36888 RVA: 0x0025DE4E File Offset: 0x0025C04E
	private void RefreshLockItemState()
	{
		base.GetItem(8).SetUIActive(false);
	}

	// Token: 0x06009019 RID: 36889 RVA: 0x0025DE5D File Offset: 0x0025C05D
	private void RefreshSwitchButton()
	{
		base.GetItem(7).SetUIActive(this.CurrentSelectBuff.BuffId != 0);
	}

	// Token: 0x0600901A RID: 36890 RVA: 0x0025DE79 File Offset: 0x0025C079
	private void RefreshNoneShow()
	{
		base.GetItem(1).SetUIActive(this.CurrentSelectBuff.BuffId == 0);
		base.GetItem(2).SetUIActive(this.CurrentSelectBuff.BuffId != 0);
	}

	// Token: 0x0600901B RID: 36891 RVA: 0x0025DEAF File Offset: 0x0025C0AF
	private void RefreshBuffInfo()
	{
		if (this.CurrentSelectBuff.BuffId == 0)
		{
			return;
		}
		this.RefreshBuffName();
		this.RefreshBuffDesc();
		this.RefreshBuffTexture();
	}

	// Token: 0x0600901C RID: 36892 RVA: 0x0025DED4 File Offset: 0x0025C0D4
	private void RefreshBuffTexture()
	{
		string texture = ConfigBase<MowingTowerConfig>.Instance.GetMowingTowerBuffById(this.CurrentSelectBuff.BuffId).Value.Texture;
		base.SetTextureByPath(texture, base.GetTexture(4), null, null);
	}

	// Token: 0x0600901D RID: 36893 RVA: 0x0025DF20 File Offset: 0x0025C120
	private void RefreshBuffDesc()
	{
		MowTowerBuffRe? mowingTowerBuffById = ConfigBase<MowingTowerConfig>.Instance.GetMowingTowerBuffById(this.CurrentSelectBuff.BuffId);
		List<string> list = new List<string>();
		int descriptionParamLength = mowingTowerBuffById.Value.DescriptionParamLength;
		for (int i = 0; i < descriptionParamLength; i++)
		{
			string text = mowingTowerBuffById.Value.DescriptionParam(i);
			Match match = new Regex("\\[(.*?)\\]").Match(text ?? "");
			if (match.Success && match.Groups.Count > 1)
			{
				string[] array = match.Groups[1].Value.Split(',', StringSplitOptions.None);
				for (int j = 0; j < array.Length; j++)
				{
					list.Add(array[j]);
				}
			}
		}
		object[] array2 = new object[list.Count];
		for (int k = 0; k < list.Count; k++)
		{
			array2[k] = list[k];
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), mowingTowerBuffById.Value.Description, array2);
	}

	// Token: 0x0600901E RID: 36894 RVA: 0x0025E044 File Offset: 0x0025C244
	private void RefreshBuffName()
	{
		MowTowerBuffRe? mowingTowerBuffById = ConfigBase<MowingTowerConfig>.Instance.GetMowingTowerBuffById(this.CurrentSelectBuff.BuffId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), mowingTowerBuffById.Value.Name, Array.Empty<object>());
	}

	// Token: 0x040042D0 RID: 17104
	public int SlotIndex;

	// Token: 0x040042D1 RID: 17105
	[Nullable(2)]
	private MowingTowerBuffInfo CurrentSelectBuff;

	// Token: 0x02007838 RID: 30776
	private class EBuffEntryComponent
	{
		// Token: 0x0402958B RID: 169355
		public const int EntryButton = 0;

		// Token: 0x0402958C RID: 169356
		public const int NoneItem = 1;

		// Token: 0x0402958D RID: 169357
		public const int NotNoneItem = 2;

		// Token: 0x0402958E RID: 169358
		public const int SelectBuffTipsText = 3;

		// Token: 0x0402958F RID: 169359
		public const int BuffTexture = 4;

		// Token: 0x04029590 RID: 169360
		public const int BuffName = 5;

		// Token: 0x04029591 RID: 169361
		public const int BuffDesc = 6;

		// Token: 0x04029592 RID: 169362
		public const int SwitchButton = 7;

		// Token: 0x04029593 RID: 169363
		public const int LockItem = 8;
	}
}
