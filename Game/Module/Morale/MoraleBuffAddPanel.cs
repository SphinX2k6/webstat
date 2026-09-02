using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200570D RID: 22285
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleBuffAddPanel : UiPanelBase
	{
		// Token: 0x06038B84 RID: 232324 RVA: 0x00E5C998 File Offset: 0x00E5AB98
		public UniTask Init(UUIItem item)
		{
			MoraleBuffAddPanel.<Init>d__4 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleBuffAddPanel.<Init>d__4>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038B85 RID: 232325 RVA: 0x00E5C9E4 File Offset: 0x00E5ABE4
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

		// Token: 0x06038B86 RID: 232326 RVA: 0x00E5CAE8 File Offset: 0x00E5ACE8
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleBuffAddPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleBuffAddPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038B87 RID: 232327 RVA: 0x00E5CB2B File Offset: 0x00E5AD2B
		protected override void OnBeforeShow()
		{
			this.UpdateData();
		}

		// Token: 0x06038B88 RID: 232328 RVA: 0x00E5CB33 File Offset: 0x00E5AD33
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

		// Token: 0x06038B89 RID: 232329 RVA: 0x00E5CB4D File Offset: 0x00E5AD4D
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

		// Token: 0x06038B8A RID: 232330 RVA: 0x00E5CB66 File Offset: 0x00E5AD66
		private MoraleBuffAddItem CreateItem()
		{
			return new MoraleBuffAddItem();
		}

		// Token: 0x06038B8B RID: 232331 RVA: 0x00E5CB6D File Offset: 0x00E5AD6D
		private MoraleBuffAddAreaItem CreateAreaItem()
		{
			return new MoraleBuffAddAreaItem();
		}

		// Token: 0x06038B8C RID: 232332 RVA: 0x00E5CB74 File Offset: 0x00E5AD74
		public void UpdateData()
		{
			this.UpdateTitle();
			this.UpdateLvAddDesc();
			this.UpdateList();
			this.UpdateAreaList();
		}

		// Token: 0x06038B8D RID: 232333 RVA: 0x00E5CB90 File Offset: 0x00E5AD90
		public void UpdateTitle()
		{
			string key = "Morale_title_22";
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(key);
			}
			string key2 = "Morale_title_38";
			UUIText text2 = base.GetText(8);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew(key2);
		}

		// Token: 0x06038B8E RID: 232334 RVA: 0x00E5CBD0 File Offset: 0x00E5ADD0
		public void UpdateList()
		{
			List<IMoraleBuffAddItemData> allRoleAttrAddList = ModelBase<MoraleModel>.Instance.GetAllRoleAttrAddList();
			this.ItemLayout.RefreshByData(allRoleAttrAddList, null, false);
		}

		// Token: 0x06038B8F RID: 232335 RVA: 0x00E5CBF8 File Offset: 0x00E5ADF8
		public void UpdateAreaList()
		{
			List<MoraleAreaData> areaDataList = ModelBase<MoraleModel>.Instance.AreaDataList;
			this.AreaBuffLayout.RefreshByData(areaDataList, null, false);
		}

		// Token: 0x06038B90 RID: 232336 RVA: 0x00E5CC20 File Offset: 0x00E5AE20
		public void UpdateLvAddDesc()
		{
			int moraleLevel = ModelBase<MoraleBattleModel>.Instance.GetMoraleLevel();
			MoraleBattleConfig instance = ConfigBase<MoraleBattleConfig>.Instance;
			MoraleKeepLevel? moraleKeepLevel = (instance != null) ? instance.GetExpConfig(moraleLevel) : null;
			if (moraleKeepLevel == null)
			{
				return;
			}
			base.GetText(5).ShowTextNew(moraleKeepLevel.Value.LvAddDesc);
		}

		// Token: 0x04020538 RID: 132408
		public GenericLayout<MoraleBuffAddItem, IMoraleBuffAddItemData> ItemLayout;

		// Token: 0x04020539 RID: 132409
		public GenericLayout<MoraleBuffAddAreaItem, MoraleAreaData> AreaBuffLayout;

		// Token: 0x0402053A RID: 132410
		[Nullable(2)]
		public Action CloseCallback;

		// Token: 0x0200B7A5 RID: 47013
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038CD0 RID: 232656
			public const int BtnMask = 0;

			// Token: 0x04038CD1 RID: 232657
			public const int LayoutContainer = 1;

			// Token: 0x04038CD2 RID: 232658
			public const int ItemInfoTemplate = 2;

			// Token: 0x04038CD3 RID: 232659
			public const int ItemRoot = 3;

			// Token: 0x04038CD4 RID: 232660
			public const int TextTitle = 4;

			// Token: 0x04038CD5 RID: 232661
			public const int TextSubTitle = 5;

			// Token: 0x04038CD6 RID: 232662
			public const int LayoutAreaBuffRoot = 6;

			// Token: 0x04038CD7 RID: 232663
			public const int ItemAreaBuffTemplate = 7;

			// Token: 0x04038CD8 RID: 232664
			public const int TextAreaTitle = 8;
		}
	}
}
