using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006079 RID: 24697
	public class BattleUiInfoItem : UiPanelBase
	{
		// Token: 0x0603E473 RID: 255091 RVA: 0x00FE67F4 File Offset: 0x00FE49F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E474 RID: 255092 RVA: 0x00FE6880 File Offset: 0x00FE4A80
		protected override UniTask OnBeforeStartAsync()
		{
			BattleUiInfoItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleUiInfoItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E475 RID: 255093 RVA: 0x00FE68C3 File Offset: 0x00FE4AC3
		[NullableContext(1)]
		private static BattleUiDescInfoItem CreateItem()
		{
			return new BattleUiDescInfoItem();
		}

		// Token: 0x0603E476 RID: 255094 RVA: 0x00FE68CC File Offset: 0x00FE4ACC
		[NullableContext(1)]
		public void Refresh(IBattleUiHoverTipsC info)
		{
			this.ContentLayout.RefreshByData(info.DescInfoList, null, false);
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(!string.IsNullOrEmpty(info.TitleKey));
			}
			if (!string.IsNullOrEmpty(info.TitleKey))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, info.TitleKey, Array.Empty<object>());
			}
		}

		// Token: 0x04022E90 RID: 142992
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<BattleUiDescInfoItem, IBattleUiHoverTipsDescInfoC> ContentLayout;

		// Token: 0x0200C148 RID: 49480
		private enum EItemChildType
		{
			// Token: 0x0403B859 RID: 243801
			TxtTitle,
			// Token: 0x0403B85A RID: 243802
			ItemDescInfo,
			// Token: 0x0403B85B RID: 243803
			LayoutContent
		}

		// Token: 0x0200C149 RID: 49481
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403B85C RID: 243804
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Func<BattleUiDescInfoItem> <0>__CreateItem;
		}
	}
}
