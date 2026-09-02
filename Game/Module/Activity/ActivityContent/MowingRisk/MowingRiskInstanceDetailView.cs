using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A7 RID: 26279
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskInstanceDetailView : UiPanelBase
	{
		// Token: 0x06041A08 RID: 268808 RVA: 0x010D3C74 File Offset: 0x010D1E74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.ClickHelper));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041A09 RID: 268809 RVA: 0x010D3E68 File Offset: 0x010D2068
		protected override UniTask OnBeforeStartAsync()
		{
			MowingRiskInstanceDetailView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MowingRiskInstanceDetailView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041A0A RID: 268810 RVA: 0x010D3EAB File Offset: 0x010D20AB
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(7);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06041A0B RID: 268811 RVA: 0x010D3ED2 File Offset: 0x010D20D2
		private void ClickHelper()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId, null);
		}

		// Token: 0x06041A0C RID: 268812 RVA: 0x010D3EF3 File Offset: 0x010D20F3
		private MowingRiskInstanceDetailAttributeGridItem CreateAttributeItem()
		{
			return new MowingRiskInstanceDetailAttributeGridItem();
		}

		// Token: 0x06041A0D RID: 268813 RVA: 0x010D3EFA File Offset: 0x010D20FA
		private void OnClickLeft(int _)
		{
		}

		// Token: 0x06041A0E RID: 268814 RVA: 0x010D3EFC File Offset: 0x010D20FC
		private void OnClickRight(int _)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnClickEnterInstanceSingle);
		}

		// Token: 0x06041A0F RID: 268815 RVA: 0x010D3F10 File Offset: 0x010D2110
		private void RefreshLockItem(IMowingRiskInstanceDetailLockItemData data)
		{
			if (data != null)
			{
				this.RightButton.SetUiActive(false);
				this.LockItem.SetUiActive(true);
				this.LockItem.RefreshExternalByData(data);
				return;
			}
			this.RightButton.SetUiActive(true);
			this.LockItem.SetUiActive(false);
		}

		// Token: 0x06041A10 RID: 268816 RVA: 0x010D3F60 File Offset: 0x010D2160
		public UniTask RefreshExternalByDataAsync(IMowingRiskInstanceDetailData data)
		{
			MowingRiskInstanceDetailView.<RefreshExternalByDataAsync>d__13 <RefreshExternalByDataAsync>d__;
			<RefreshExternalByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshExternalByDataAsync>d__.<>4__this = this;
			<RefreshExternalByDataAsync>d__.data = data;
			<RefreshExternalByDataAsync>d__.<>1__state = -1;
			<RefreshExternalByDataAsync>d__.<>t__builder.Start<MowingRiskInstanceDetailView.<RefreshExternalByDataAsync>d__13>(ref <RefreshExternalByDataAsync>d__);
			return <RefreshExternalByDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041A11 RID: 268817 RVA: 0x010D3FAB File Offset: 0x010D21AB
		public void RefreshLockItemExternalByData(IMowingRiskInstanceDetailLockItemData data)
		{
			this.RefreshLockItem(data);
		}

		// Token: 0x04024A3F RID: 150079
		private GenericLayout<MowingRiskInstanceDetailAttributeGridItem, IMowingRiskInstanceDetailAttributeItemData> AttributeLayout;

		// Token: 0x04024A40 RID: 150080
		private ButtonItem LeftButton;

		// Token: 0x04024A41 RID: 150081
		private ButtonItem RightButton;

		// Token: 0x04024A42 RID: 150082
		private MowingRiskInstanceDetailLockItem LockItem;

		// Token: 0x0200C6CB RID: 50891
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x0403D353 RID: 250707
			public const int TitleText = 0;

			// Token: 0x0403D354 RID: 250708
			public const int RecommendElementItem = 1;

			// Token: 0x0403D355 RID: 250709
			public const int RecommendElementIconItem = 2;

			// Token: 0x0403D356 RID: 250710
			public const int ContentText = 3;

			// Token: 0x0403D357 RID: 250711
			public const int HelperButton = 4;

			// Token: 0x0403D358 RID: 250712
			public const int AttributeLayout = 5;

			// Token: 0x0403D359 RID: 250713
			public const int AttributeGridItem = 6;

			// Token: 0x0403D35A RID: 250714
			public const int LeftButtonItem = 7;

			// Token: 0x0403D35B RID: 250715
			public const int RightButtonItem = 8;

			// Token: 0x0403D35C RID: 250716
			public const int LockItem = 9;

			// Token: 0x0403D35D RID: 250717
			public const int AddRootItem = 10;

			// Token: 0x0403D35E RID: 250718
			public const int RecommendTitleText = 11;
		}
	}
}
