using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhoneMessage
{
	// Token: 0x02005459 RID: 21593
	[NullableContext(2)]
	[Nullable(0)]
	internal class PanelFilter : GridProxyAbstract<int>
	{
		// Token: 0x0603702C RID: 225324 RVA: 0x00DF68B1 File Offset: 0x00DF4AB1
		public void SetOnFilterTogItemClick(Action<int, bool> callback)
		{
			this.OnFilterTogItemClick = callback;
		}

		// Token: 0x0603702D RID: 225325 RVA: 0x00DF68BA File Offset: 0x00DF4ABA
		public void SetIsFilterSelected(Func<int, bool> callback)
		{
			this.IsFilterSelected = callback;
		}

		// Token: 0x0603702E RID: 225326 RVA: 0x00DF68C4 File Offset: 0x00DF4AC4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggle))
			};
		}

		// Token: 0x0603702F RID: 225327 RVA: 0x00DF6920 File Offset: 0x00DF4B20
		protected override void OnStart()
		{
			UUIGridLayout gridLayout = base.GetGridLayout(1);
			this.BigFilterTogItemLayout = new GenericLayout<FilterTogItem, int>(gridLayout, new Func<FilterTogItem>(this.CreateFilterTogItem), null, false, true);
		}

		// Token: 0x06037030 RID: 225328 RVA: 0x00DF6950 File Offset: 0x00DF4B50
		public override void Refresh(int filterTypeId, bool isSelected, int gridIndex)
		{
			this.FilterTypeId = new int?(filterTypeId);
			ChatFilterType? chatFilterTypeConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatFilterTypeConfig(this.FilterTypeId.Value);
			if (chatFilterTypeConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), chatFilterTypeConfig.Value.Title ?? "", Array.Empty<object>());
			IEnumerable<ChatPartnerFilter> chatPartnerFilterConfigListByFilterType = ConfigBase<PhoneMsgConfig>.Instance.GetChatPartnerFilterConfigListByFilterType(this.FilterTypeId.Value);
			List<int> list = new List<int>();
			foreach (ChatPartnerFilter chatPartnerFilter in chatPartnerFilterConfigListByFilterType)
			{
				list.Add(chatPartnerFilter.Id);
			}
			GenericLayout<FilterTogItem, int> bigFilterTogItemLayout = this.BigFilterTogItemLayout;
			if (bigFilterTogItemLayout == null)
			{
				return;
			}
			bigFilterTogItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06037031 RID: 225329 RVA: 0x00DF6A28 File Offset: 0x00DF4C28
		[NullableContext(1)]
		private FilterTogItem CreateFilterTogItem()
		{
			FilterTogItem filterTogItem = new FilterTogItem();
			filterTogItem.SetOnFilterTogItemClick(this.OnFilterTogItemClick);
			filterTogItem.SetIsFilterSelected(this.IsFilterSelected);
			return filterTogItem;
		}

		// Token: 0x06037032 RID: 225330 RVA: 0x00DF6A47 File Offset: 0x00DF4C47
		public override void Clear()
		{
		}

		// Token: 0x0401FA62 RID: 129634
		public int? FilterTypeId;

		// Token: 0x0401FA63 RID: 129635
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<FilterTogItem, int> BigFilterTogItemLayout;

		// Token: 0x0401FA64 RID: 129636
		private Action<int, bool> OnFilterTogItemClick;

		// Token: 0x0401FA65 RID: 129637
		private Func<int, bool> IsFilterSelected;
	}
}
