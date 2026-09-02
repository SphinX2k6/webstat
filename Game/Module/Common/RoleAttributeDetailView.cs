using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common
{
	// Token: 0x02005E46 RID: 24134
	public class RoleAttributeDetailView : UiViewBase
	{
		// Token: 0x0603CBB0 RID: 248752 RVA: 0x00F6C380 File Offset: 0x00F6A580
		[NullableContext(1)]
		public RoleAttributeDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CBB1 RID: 248753 RVA: 0x00F6C38C File Offset: 0x00F6A58C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603CBB2 RID: 248754 RVA: 0x00F6C3E8 File Offset: 0x00F6A5E8
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnBackButtonClick));
			this.CaptionItem.SetTitleLocalText("PrefabTextItem_1302715335_Text");
			List<AttrListScrollData> data = this.OpenParam as List<AttrListScrollData>;
			this.AttrScrollList = new GenericScrollView<RoleAttrListScrollItem>(base.GetScrollViewWithScrollbar(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<RoleAttrListScrollItem>(this.InitAttrItem), null);
			this.AttrScrollList.RefreshByData<AttrListScrollData>(data, null);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.AttributeComponentEvent, true);
		}

		// Token: 0x0603CBB3 RID: 248755 RVA: 0x00F6C47F File Offset: 0x00F6A67F
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem.Destroy(null);
			if (this.AttrScrollList != null)
			{
				this.AttrScrollList.ClearChildren();
				this.AttrScrollList = null;
			}
		}

		// Token: 0x0603CBB4 RID: 248756 RVA: 0x00F6C4A8 File Offset: 0x00F6A6A8
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<RoleAttrListScrollItem> InitAttrItem(object data, UUIItem item, int index)
		{
			AttrListScrollData attrListScrollData = (AttrListScrollData)data;
			RoleAttrListScrollItem roleAttrListScrollItem = new RoleAttrListScrollItem(item, attrListScrollData.AttributeType);
			roleAttrListScrollItem.ShowTemp(attrListScrollData, index);
			return new LayoutItem<RoleAttrListScrollItem>
			{
				Key = index,
				Value = roleAttrListScrollItem
			};
		}

		// Token: 0x0603CBB5 RID: 248757 RVA: 0x00F6C4E9 File Offset: 0x00F6A6E9
		private void OnBackButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402218F RID: 139663
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04022190 RID: 139664
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollView<RoleAttrListScrollItem> AttrScrollList;

		// Token: 0x0200BE72 RID: 48754
		private class EAttributeView
		{
			// Token: 0x0403AA40 RID: 240192
			public const int ItemCaption = 0;

			// Token: 0x0403AA41 RID: 240193
			public const int AttributeContent = 1;

			// Token: 0x0403AA42 RID: 240194
			public const int ItemAttribute = 2;
		}
	}
}
