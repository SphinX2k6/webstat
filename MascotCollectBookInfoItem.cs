using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001F73 RID: 8051
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MascotCollectBookInfoItem : GridProxyAbstract<IMascotCollectInfoData>
{
	// Token: 0x0600F131 RID: 61745 RVA: 0x0041E890 File Offset: 0x0041CA90
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600F132 RID: 61746 RVA: 0x0041E900 File Offset: 0x0041CB00
	protected override void OnStart()
	{
		this.MascotToggleLayout = new GenericLayout<MascotCollectBookMascotToggle, HonamiStoryMascotData>(base.GetHorizontalLayout(1), new Func<MascotCollectBookMascotToggle>(this.CreateMascotToggleItem), null, false, true);
	}

	// Token: 0x0600F133 RID: 61747 RVA: 0x0041E924 File Offset: 0x0041CB24
	private MascotCollectBookMascotToggle CreateMascotToggleItem()
	{
		MascotCollectBookMascotToggle mascotCollectBookMascotToggle = new MascotCollectBookMascotToggle();
		mascotCollectBookMascotToggle.BindMascotToggleClick(this.OnMascotToggleClick);
		this.MascotToggleList.Add(mascotCollectBookMascotToggle);
		return mascotCollectBookMascotToggle;
	}

	// Token: 0x0600F134 RID: 61748 RVA: 0x0041E950 File Offset: 0x0041CB50
	public override void Refresh(IMascotCollectInfoData infoData, bool isSelected, int gridIndex)
	{
		this.InfoData = infoData;
		this.RefreshItem();
	}

	// Token: 0x0600F135 RID: 61749 RVA: 0x0041E960 File Offset: 0x0041CB60
	private void RefreshItem()
	{
		HonamiStoryAreaData areaData = this.InfoData.AreaData;
		bool isAreaUnlock = areaData.IsAreaUnlock;
		base.GetItem(3).SetUIActive(!isAreaUnlock);
		this.MascotToggleLayout.GetRootUiItem().SetUIActive(isAreaUnlock);
		if (isAreaUnlock)
		{
			base.GetText(0).ShowTextNew(areaData.Name);
			List<HonamiStoryMascotData> mascotDataList = this.InfoData.MascotDataList;
			base.GetItem(3).SetActive(mascotDataList.Count == 0, false);
			this.MascotToggleLayout.RefreshByData(mascotDataList, null, false);
			return;
		}
		base.GetText(0).SetText("???", true);
	}

	// Token: 0x0600F136 RID: 61750 RVA: 0x0041E9F9 File Offset: 0x0041CBF9
	public IReadOnlyList<MascotCollectBookMascotToggle> GetMascotToggleList()
	{
		return this.MascotToggleList;
	}

	// Token: 0x0600F137 RID: 61751 RVA: 0x0041EA01 File Offset: 0x0041CC01
	public void BindMascotToggleClick(Action<MascotCollectBookMascotToggle> callback)
	{
		this.OnMascotToggleClick = callback;
	}

	// Token: 0x040073D1 RID: 29649
	private IMascotCollectInfoData InfoData;

	// Token: 0x040073D2 RID: 29650
	private GenericLayout<MascotCollectBookMascotToggle, HonamiStoryMascotData> MascotToggleLayout;

	// Token: 0x040073D3 RID: 29651
	private readonly List<MascotCollectBookMascotToggle> MascotToggleList = new List<MascotCollectBookMascotToggle>();

	// Token: 0x040073D4 RID: 29652
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<MascotCollectBookMascotToggle> OnMascotToggleClick;

	// Token: 0x02008310 RID: 33552
	[NullableContext(0)]
	private enum EMascotCollectBookInfoItemComponent
	{
		// Token: 0x0402C701 RID: 182017
		TitleText,
		// Token: 0x0402C702 RID: 182018
		MascotToggleLayout,
		// Token: 0x0402C703 RID: 182019
		MascotToggleItem,
		// Token: 0x0402C704 RID: 182020
		EmptyPanel
	}
}
