using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005510 RID: 21776
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CollectBadgeGroupItem : GridProxyAbstract<CollectBadgeGroupData>
	{
		// Token: 0x060378CC RID: 227532 RVA: 0x00E17E90 File Offset: 0x00E16090
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x060378CD RID: 227533 RVA: 0x00E17EEA File Offset: 0x00E160EA
		protected override void OnStart()
		{
			this.LayoutBadge = new GenericLayout<CollectBadgeItem, int>(base.GetGridLayout(1), new Func<CollectBadgeItem>(this.CreateBadgeItem), null, false, true);
		}

		// Token: 0x060378CE RID: 227534 RVA: 0x00E17F0D File Offset: 0x00E1610D
		private CollectBadgeItem CreateBadgeItem()
		{
			return new CollectBadgeItem
			{
				CallbackClickBadge = new Action<int>(this.OnClickBadge),
				CallbackCanChange = new Func<int, EToggleState, bool>(this.OnCanChange)
			};
		}

		// Token: 0x060378CF RID: 227535 RVA: 0x00E17F38 File Offset: 0x00E16138
		public override void Refresh(CollectBadgeGroupData data, bool isSelected, int gridIndex)
		{
			this.GroupId = data.GroupId;
			PhantomBattleBadgeGroup phantomBattleBadgeGroupById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeGroupById(data.GroupId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), phantomBattleBadgeGroupById.Name, Array.Empty<object>());
			this.LayoutBadge.RefreshByData(data.BadgeIdList, null, false);
		}

		// Token: 0x060378D0 RID: 227536 RVA: 0x00E17F92 File Offset: 0x00E16192
		private void OnClickBadge(int badgeId)
		{
			if (this.CallbackClickBadge != null && this.GroupId > 0)
			{
				this.CallbackClickBadge(badgeId, this);
			}
		}

		// Token: 0x060378D1 RID: 227537 RVA: 0x00E17FB2 File Offset: 0x00E161B2
		private bool OnCanChange(int badgeId, EToggleState state)
		{
			return this.CallbackCanChange != null && this.GroupId > 0 && this.CallbackCanChange(badgeId, state);
		}

		// Token: 0x060378D2 RID: 227538 RVA: 0x00E17FD4 File Offset: 0x00E161D4
		public void SetSelect(int badgeId)
		{
			this.LayoutBadge.DeselectCurrentGridProxy();
			this.LayoutBadge.SelectGridProxyByKey(badgeId, false);
		}

		// Token: 0x060378D3 RID: 227539 RVA: 0x00E17FF3 File Offset: 0x00E161F3
		public void SetSelectByIndex(int index)
		{
			this.LayoutBadge.DeselectCurrentGridProxy();
			this.LayoutBadge.SelectGridProxy(index, false);
		}

		// Token: 0x060378D4 RID: 227540 RVA: 0x00E1800D File Offset: 0x00E1620D
		public void SetDeselect()
		{
			this.LayoutBadge.DeselectCurrentGridProxy();
		}

		// Token: 0x060378D5 RID: 227541 RVA: 0x00E1801A File Offset: 0x00E1621A
		public override void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x060378D6 RID: 227542 RVA: 0x00E1801C File Offset: 0x00E1621C
		public override void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x060378D7 RID: 227543 RVA: 0x00E1801E File Offset: 0x00E1621E
		public override object GetKey(CollectBadgeGroupData data, int displayIndex)
		{
			return this.GroupId;
		}

		// Token: 0x0401FDB8 RID: 130488
		private int GroupId;

		// Token: 0x0401FDB9 RID: 130489
		private GenericLayout<CollectBadgeItem, int> LayoutBadge;

		// Token: 0x0401FDBA RID: 130490
		public Action<int, CollectBadgeGroupItem> CallbackClickBadge;

		// Token: 0x0401FDBB RID: 130491
		public Func<int, EToggleState, bool> CallbackCanChange;

		// Token: 0x0200B49F RID: 46239
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037E9B RID: 229019
			public const int TextTypeName = 0;

			// Token: 0x04037E9C RID: 229020
			public const int LayoutBadge = 1;

			// Token: 0x04037E9D RID: 229021
			public const int ItemBadge = 2;
		}
	}
}
