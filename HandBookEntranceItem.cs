using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E66 RID: 7782
public class HandBookEntranceItem : GridProxyAbstract<HandBookEntrance>
{
	// Token: 0x0600E62D RID: 58925 RVA: 0x003E1FC8 File Offset: 0x003E01C8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnButtonClicked))
		};
	}

	// Token: 0x0600E62E RID: 58926 RVA: 0x003E2087 File Offset: 0x003E0287
	protected override void OnStart()
	{
	}

	// Token: 0x0600E62F RID: 58927 RVA: 0x003E208C File Offset: 0x003E028C
	public override void Refresh(HandBookEntrance handBookEntrance, bool isSelected, int gridIndex)
	{
		this.HandBookEntrance = new HandBookEntrance?(handBookEntrance);
		base.GetText(0).ShowTextNew(this.HandBookEntrance.Value.Name);
		base.SetTextureByPath(handBookEntrance.Texture, base.GetTexture(1), null, null);
		this.RefreshRedDot();
		this.RefreshCollectProgress();
	}

	// Token: 0x0600E630 RID: 58928 RVA: 0x003E20F0 File Offset: 0x003E02F0
	public void RefreshRedDot()
	{
		if (this.HandBookEntrance == null)
		{
			return;
		}
		bool uiactive = ModelBase<HandBookModel>.Instance.IsShowRedDot((EHandBookTabType)this.HandBookEntrance.Value.Id);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(uiactive);
		}
	}

	// Token: 0x0600E631 RID: 58929 RVA: 0x003E213C File Offset: 0x003E033C
	public void RefreshCollectProgress()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress((EHandBookTabType)this.HandBookEntrance.Value.Id);
		if (this.HandBookEntrance.Value.Id != 3)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "CollectProgress", new <>z__ReadOnlyArray<object>(new object[]
			{
				collectProgress[0],
				collectProgress[1]
			}));
			return;
		}
		UUIText text = base.GetText(5);
		if (text == null)
		{
			return;
		}
		text.SetText(collectProgress[0].ToString(), true);
	}

	// Token: 0x0600E632 RID: 58930 RVA: 0x003E21D4 File Offset: 0x003E03D4
	private void OnButtonClicked()
	{
		switch (this.HandBookEntrance.Value.Id)
		{
		case 0:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MonsterHandBookView, null, null);
			return;
		case 1:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomHandBookView, null, null);
			return;
		case 2:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GeographyHandBookView, null, null);
			return;
		case 3:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponHandBookView, null, null);
			return;
		case 4:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.AnimalHandBookView, null, null);
			return;
		case 5:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemHandBookView, null, null);
			return;
		case 6:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ChipHandBookView, null, null);
			return;
		case 7:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestHandBookView, null, null);
			return;
		case 10:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.HandBookRoleView, null, null);
			return;
		case 11:
			Singleton<UiManager>.Instance.OpenView(EUiViewName.NounHandBookView, null, null);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HandBook;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "没有找到图鉴入口类型，请检查";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("this.HandBookEntrance.Id", this.HandBookEntrance.Value.Id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x04006F01 RID: 28417
	private HandBookEntrance? HandBookEntrance;

	// Token: 0x020081B9 RID: 33209
	private class EHandBookEntranceItemDefine
	{
		// Token: 0x0402C064 RID: 180324
		public const int NameText = 0;

		// Token: 0x0402C065 RID: 180325
		public const int Texture = 1;

		// Token: 0x0402C066 RID: 180326
		public const int CollectCountText = 2;

		// Token: 0x0402C067 RID: 180327
		public const int Button = 3;

		// Token: 0x0402C068 RID: 180328
		public const int RedDotItem = 4;

		// Token: 0x0402C069 RID: 180329
		public const int NewCollectCountText = 5;
	}
}
