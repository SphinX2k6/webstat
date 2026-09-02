using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.View.Components;
using CSharpScript.Game.Module.Kurotato.View.Overview;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005AD3 RID: 23251
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoCommonPopupPanel : UiPanelBase
	{
		// Token: 0x0603AC96 RID: 240790 RVA: 0x00EE85F0 File Offset: 0x00EE67F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AC97 RID: 240791 RVA: 0x00EE86D8 File Offset: 0x00EE68D8
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoCommonPopupPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoCommonPopupPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC98 RID: 240792 RVA: 0x00EE871C File Offset: 0x00EE691C
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.KurotatoOnItemUpdate, new Action<int, bool>(this.OnItemUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnWeaponUpdate, new Action(this.OnWeaponUpdate));
			this.CaptionItem.SetCloseBtnActive(false);
			this.SetCloseBtnVisible(true);
		}

		// Token: 0x0603AC99 RID: 240793 RVA: 0x00EE8774 File Offset: 0x00EE6974
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.KurotatoOnItemUpdate, new Action<int, bool>(this.OnItemUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnWeaponUpdate, new Action(this.OnWeaponUpdate));
		}

		// Token: 0x0603AC9A RID: 240794 RVA: 0x00EE87B0 File Offset: 0x00EE69B0
		private UniTask CreateCaption()
		{
			KurotatoCommonPopupPanel.<CreateCaption>d__10 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<KurotatoCommonPopupPanel.<CreateCaption>d__10>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC9B RID: 240795 RVA: 0x00EE87F4 File Offset: 0x00EE69F4
		private UniTask CreateCostInfoItem()
		{
			KurotatoCommonPopupPanel.<CreateCostInfoItem>d__11 <CreateCostInfoItem>d__;
			<CreateCostInfoItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCostInfoItem>d__.<>4__this = this;
			<CreateCostInfoItem>d__.<>1__state = -1;
			<CreateCostInfoItem>d__.<>t__builder.Start<KurotatoCommonPopupPanel.<CreateCostInfoItem>d__11>(ref <CreateCostInfoItem>d__);
			return <CreateCostInfoItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC9C RID: 240796 RVA: 0x00EE8838 File Offset: 0x00EE6A38
		private UniTask CreateRoleAttributePanel()
		{
			KurotatoCommonPopupPanel.<CreateRoleAttributePanel>d__12 <CreateRoleAttributePanel>d__;
			<CreateRoleAttributePanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRoleAttributePanel>d__.<>4__this = this;
			<CreateRoleAttributePanel>d__.<>1__state = -1;
			<CreateRoleAttributePanel>d__.<>t__builder.Start<KurotatoCommonPopupPanel.<CreateRoleAttributePanel>d__12>(ref <CreateRoleAttributePanel>d__);
			return <CreateRoleAttributePanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC9D RID: 240797 RVA: 0x00EE887C File Offset: 0x00EE6A7C
		private UniTask CreateCurrencyAsync()
		{
			KurotatoCommonPopupPanel.<CreateCurrencyAsync>d__13 <CreateCurrencyAsync>d__;
			<CreateCurrencyAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCurrencyAsync>d__.<>4__this = this;
			<CreateCurrencyAsync>d__.<>1__state = -1;
			<CreateCurrencyAsync>d__.<>t__builder.Start<KurotatoCommonPopupPanel.<CreateCurrencyAsync>d__13>(ref <CreateCurrencyAsync>d__);
			return <CreateCurrencyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC9E RID: 240798 RVA: 0x00EE88BF File Offset: 0x00EE6ABF
		public void SetCloseCb(Action cb)
		{
			this.CloseCb = cb;
		}

		// Token: 0x0603AC9F RID: 240799 RVA: 0x00EE88C8 File Offset: 0x00EE6AC8
		public void SetCloseBtnVisible(bool isVisible)
		{
			UUIItem uuiitem = base.GetButton(1).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(isVisible);
		}

		// Token: 0x0603ACA0 RID: 240800 RVA: 0x00EE88F4 File Offset: 0x00EE6AF4
		public void SetHelpButtonCallBack(Action cb)
		{
			this.CaptionItem.SetHelpCallBack(cb);
		}

		// Token: 0x0603ACA1 RID: 240801 RVA: 0x00EE8902 File Offset: 0x00EE6B02
		public void SetTitleLocalText(string textId)
		{
			this.CaptionItem.SetTitleLocalText(textId);
		}

		// Token: 0x0603ACA2 RID: 240802 RVA: 0x00EE8910 File Offset: 0x00EE6B10
		public void SetCostInfoVisible(bool isVisible)
		{
			this.CostInfoItem.SetUiActive(isVisible);
		}

		// Token: 0x0603ACA3 RID: 240803 RVA: 0x00EE891E File Offset: 0x00EE6B1E
		public void ShowAttrPreview(IReadOnlyList<IKurotatoAttrPreviewDelta> deltas)
		{
			this.RoleAttributePanel.ShowPreview(deltas);
		}

		// Token: 0x0603ACA4 RID: 240804 RVA: 0x00EE892C File Offset: 0x00EE6B2C
		public void ClearAttrPreview()
		{
			this.RoleAttributePanel.ClearPreview();
		}

		// Token: 0x0603ACA5 RID: 240805 RVA: 0x00EE8939 File Offset: 0x00EE6B39
		public void HideAttrChangeFx()
		{
			this.RoleAttributePanel.HideAllChangeFx();
		}

		// Token: 0x0603ACA6 RID: 240806 RVA: 0x00EE8946 File Offset: 0x00EE6B46
		private void OnItemUpdate(int itemId, bool bIsAdd)
		{
			this.RoleAttributePanel.RefreshAttributeList();
		}

		// Token: 0x0603ACA7 RID: 240807 RVA: 0x00EE8953 File Offset: 0x00EE6B53
		private void OnWeaponUpdate()
		{
			this.RoleAttributePanel.RefreshAttributeList();
		}

		// Token: 0x0603ACA8 RID: 240808 RVA: 0x00EE8960 File Offset: 0x00EE6B60
		private void OnClickClose()
		{
			Action closeCb = this.CloseCb;
			if (closeCb == null)
			{
				return;
			}
			closeCb();
		}

		// Token: 0x0402139F RID: 136095
		private readonly PopupCaptionItem CaptionItem = new PopupCaptionItem(null);

		// Token: 0x040213A0 RID: 136096
		private readonly CostInfoItem CostInfoItem = new CostInfoItem();

		// Token: 0x040213A1 RID: 136097
		private readonly KurotatoCurrencyItem CurrencyItem = new KurotatoCurrencyItem();

		// Token: 0x040213A2 RID: 136098
		private readonly KurotatoAttributePanel RoleAttributePanel = new KurotatoAttributePanel();

		// Token: 0x040213A3 RID: 136099
		[Nullable(2)]
		private Action CloseCb;

		// Token: 0x0200BAF8 RID: 47864
		[NullableContext(0)]
		private class EChildComp
		{
			// Token: 0x04039B64 RID: 236388
			public const int Caption = 0;

			// Token: 0x04039B65 RID: 236389
			public const int BtnBack = 1;

			// Token: 0x04039B66 RID: 236390
			public const int CostInfo = 2;

			// Token: 0x04039B67 RID: 236391
			public const int RoleAttr = 3;
		}
	}
}
