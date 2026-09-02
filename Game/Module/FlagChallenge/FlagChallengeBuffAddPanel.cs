using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D58 RID: 23896
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeBuffAddPanel : UiPanelBase
	{
		// Token: 0x0603C388 RID: 246664 RVA: 0x00F46744 File Offset: 0x00F44944
		public FlagChallengeBuffAddPanel(int activityId)
		{
			this.ActivityId = activityId;
		}

		// Token: 0x0603C389 RID: 246665 RVA: 0x00F46754 File Offset: 0x00F44954
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnMask))
			};
		}

		// Token: 0x0603C38A RID: 246666 RVA: 0x00F46858 File Offset: 0x00F44A58
		protected override void OnStart()
		{
			UUILayoutBase layoutBase = base.GetLayoutBase(1);
			AUIBaseActor gridActor = base.GetItem(2).GetOwner() as AUIBaseActor;
			this.ItemLayout = new GenericLayout<FlagChallengeBuffAddItem, FlagChallengeBuffAddItemData>(layoutBase, new Func<FlagChallengeBuffAddItem>(this.CreateItem), gridActor, false, true);
			base.GetLayoutBase(6).RootUIComp.Get().SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x0603C38B RID: 246667 RVA: 0x00F468C1 File Offset: 0x00F44AC1
		protected override void OnBeforeShow()
		{
			this.UpdateView();
		}

		// Token: 0x0603C38C RID: 246668 RVA: 0x00F468C9 File Offset: 0x00F44AC9
		protected override void OnBeforeDestroy()
		{
			if (base.GetActive())
			{
				Action closeCallback = this.CloseCallback;
				if (closeCallback == null)
				{
					return;
				}
				closeCallback();
			}
		}

		// Token: 0x0603C38D RID: 246669 RVA: 0x00F468E3 File Offset: 0x00F44AE3
		private void OnBtnMask()
		{
			this.SetActive(false);
			Action closeCallback = this.CloseCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback();
		}

		// Token: 0x0603C38E RID: 246670 RVA: 0x00F468FC File Offset: 0x00F44AFC
		private FlagChallengeBuffAddItem CreateItem()
		{
			return new FlagChallengeBuffAddItem();
		}

		// Token: 0x0603C38F RID: 246671 RVA: 0x00F46903 File Offset: 0x00F44B03
		public void UpdateView()
		{
			this.UpdateTitle();
			this.UpdateLvAddDesc();
			this.UpdateList();
		}

		// Token: 0x0603C390 RID: 246672 RVA: 0x00F46918 File Offset: 0x00F44B18
		public void UpdateTitle()
		{
			string key = "Morale_title_22";
			base.GetText(4).ShowTextNew(key);
			base.GetText(8).SetUIActive(false);
		}

		// Token: 0x0603C391 RID: 246673 RVA: 0x00F46948 File Offset: 0x00F44B48
		public void UpdateList()
		{
			List<FlagChallengeBuffAddItemData> allRoleAttrAddList = ModelBase<FlagChallengeModel>.Instance.GetAllRoleAttrAddList(this.ActivityId);
			this.ItemLayout.RefreshByData(allRoleAttrAddList, null, false);
		}

		// Token: 0x0603C392 RID: 246674 RVA: 0x00F46974 File Offset: 0x00F44B74
		public void UpdateLvAddDesc()
		{
			base.GetText(5).SetText(ModelBase<FlagChallengeModel>.Instance.GetAllRoleAttrAddDesc(this.ActivityId), true);
		}

		// Token: 0x0603C393 RID: 246675 RVA: 0x00F46993 File Offset: 0x00F44B93
		public void SetCloseCallback(Action callback)
		{
			this.CloseCallback = callback;
		}

		// Token: 0x04021D45 RID: 138565
		public int ActivityId;

		// Token: 0x04021D46 RID: 138566
		public GenericLayout<FlagChallengeBuffAddItem, FlagChallengeBuffAddItemData> ItemLayout;

		// Token: 0x04021D47 RID: 138567
		[Nullable(2)]
		private Action CloseCallback;
	}
}
