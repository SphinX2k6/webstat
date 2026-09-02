using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200570F RID: 22287
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleBuffAddTips : UiViewBase
	{
		// Token: 0x06038B94 RID: 232340 RVA: 0x00E5CC90 File Offset: 0x00E5AE90
		public MoraleBuffAddTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038B95 RID: 232341 RVA: 0x00E5CC9C File Offset: 0x00E5AE9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnMask));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06038B96 RID: 232342 RVA: 0x00E5CDA5 File Offset: 0x00E5AFA5
		private void InitDataParam()
		{
			object openParam = this.OpenParam;
		}

		// Token: 0x06038B97 RID: 232343 RVA: 0x00E5CDB0 File Offset: 0x00E5AFB0
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleBuffAddTips.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleBuffAddTips.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038B98 RID: 232344 RVA: 0x00E5CDF3 File Offset: 0x00E5AFF3
		protected override void OnBeforeShow()
		{
			this.UpdateData();
		}

		// Token: 0x06038B99 RID: 232345 RVA: 0x00E5CDFB File Offset: 0x00E5AFFB
		private void OnBtnMask()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038B9A RID: 232346 RVA: 0x00E5CE04 File Offset: 0x00E5B004
		private MoraleBuffAddItem CreateItem()
		{
			return new MoraleBuffAddItem();
		}

		// Token: 0x06038B9B RID: 232347 RVA: 0x00E5CE0B File Offset: 0x00E5B00B
		public void UpdateData()
		{
			this.UpdatePos();
			this.UpdateTitle();
			this.UpdateList();
		}

		// Token: 0x06038B9C RID: 232348 RVA: 0x00E5CE20 File Offset: 0x00E5B020
		public void UpdatePos()
		{
			MoraleBuffAddTipsParams moraleBuffAddTipsParams = this.OpenParam as MoraleBuffAddTipsParams;
			UUIItem uuiitem = (moraleBuffAddTipsParams != null) ? moraleBuffAddTipsParams.ItemForLocation : null;
			if (uuiitem == null)
			{
				return;
			}
			base.GetItem(3).SetUIRelativeLocation(uuiitem.RelativeLocation);
		}

		// Token: 0x06038B9D RID: 232349 RVA: 0x00E5CE5C File Offset: 0x00E5B05C
		public void UpdateTitle()
		{
			MoraleBuffAddTipsParams moraleBuffAddTipsParams = this.OpenParam as MoraleBuffAddTipsParams;
			string key = ((moraleBuffAddTipsParams != null) ? moraleBuffAddTipsParams.TitleKey : null) ?? "Morale_title_22";
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(key);
		}

		// Token: 0x06038B9E RID: 232350 RVA: 0x00E5CE9C File Offset: 0x00E5B09C
		public void UpdateList()
		{
			MoraleBuffAddTipsParams moraleBuffAddTipsParams = this.OpenParam as MoraleBuffAddTipsParams;
			List<IMoraleBuffAddItemData> data = ((moraleBuffAddTipsParams != null) ? moraleBuffAddTipsParams.DataList : null) ?? ModelBase<MoraleModel>.Instance.GetAllRoleAttrAddList();
			this.ItemLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0402053E RID: 132414
		public GenericLayout<MoraleBuffAddItem, IMoraleBuffAddItemData> ItemLayout;

		// Token: 0x0200B7A8 RID: 47016
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038CE2 RID: 232674
			public const int BtnMask = 0;

			// Token: 0x04038CE3 RID: 232675
			public const int LayoutContainer = 1;

			// Token: 0x04038CE4 RID: 232676
			public const int ItemInfoTemplate = 2;

			// Token: 0x04038CE5 RID: 232677
			public const int ItemRoot = 3;

			// Token: 0x04038CE6 RID: 232678
			public const int TextTitle = 4;
		}
	}
}
