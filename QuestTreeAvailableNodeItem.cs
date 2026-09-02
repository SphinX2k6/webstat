using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020026B3 RID: 9907
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestTreeAvailableNodeItem : GridProxyAbstract<QuestTreeNodeData>
{
	// Token: 0x06013879 RID: 79993 RVA: 0x005719BC File Offset: 0x0056FBBC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickGoto));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601387A RID: 79994 RVA: 0x00571B4C File Offset: 0x0056FD4C
	public override void Refresh(QuestTreeNodeData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.SetSpriteByPath(data.TypeIconPath, base.GetSprite(7), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Config.Name, Array.Empty<object>());
		base.GetSprite(0).SetUIActive(data.Type.GetValueOrDefault() == EQuest.Branch);
		base.GetSprite(1).SetUIActive(data.Type.GetValueOrDefault() == EQuest.POI);
		base.GetItem(8).SetUIActive(data.HasNewTag());
		base.GetSprite(5).SetUIActive(false);
		base.GetText(6).SetUIActive(false);
		base.GetButton(3).GetRootComponent().SetUIActive(true);
		data.RemoveNewTag();
	}

	// Token: 0x0601387B RID: 79995 RVA: 0x00571C24 File Offset: 0x0056FE24
	private void OnClickGoto()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QuestTreeChapterView))
		{
			ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SelectData(this.Data);
		}
		else
		{
			ControllerBase<QuestTreeController>.Instance.OpenChapterView(this.Data.ChapterId, new int?(this.Data.Id));
		}
		ControllerBase<QuestTreeController>.Instance.OpenNodeDetailView(this.Data);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestTreeAvailableListView, null);
	}

	// Token: 0x04009825 RID: 38949
	private QuestTreeNodeData Data;

	// Token: 0x02008A48 RID: 35400
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402E9F4 RID: 190964
		public const int SpriteBlueBg = 0;

		// Token: 0x0402E9F5 RID: 190965
		public const int SpriteGreenBg = 1;

		// Token: 0x0402E9F6 RID: 190966
		public const int TextName = 2;

		// Token: 0x0402E9F7 RID: 190967
		public const int BtnGoto = 3;

		// Token: 0x0402E9F8 RID: 190968
		public const int BtnGoto2 = 4;

		// Token: 0x0402E9F9 RID: 190969
		public const int SpriteFinish = 5;

		// Token: 0x0402E9FA RID: 190970
		public const int TextInProgress = 6;

		// Token: 0x0402E9FB RID: 190971
		public const int SpriteTypeIcon = 7;

		// Token: 0x0402E9FC RID: 190972
		public const int ItemNew = 8;
	}
}
