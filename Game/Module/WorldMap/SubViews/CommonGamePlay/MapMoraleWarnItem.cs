using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CommonGamePlay
{
	// Token: 0x02004BDA RID: 19418
	public class MapMoraleWarnItem : UiPanelBase
	{
		// Token: 0x06032AC2 RID: 207554 RVA: 0x00CB0D1C File Offset: 0x00CAEF1C
		[NullableContext(1)]
		public UniTask Init(UUIItem parentItem, string resId = "UiItem_MapTipButtom")
		{
			MapMoraleWarnItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.parentItem = parentItem;
			<Init>d__.resId = resId;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MapMoraleWarnItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06032AC3 RID: 207555 RVA: 0x00CB0D70 File Offset: 0x00CAEF70
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032AC4 RID: 207556 RVA: 0x00CB0DB8 File Offset: 0x00CAEFB8
		[NullableContext(1)]
		public void UpdateTitle(string titleId)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(titleId);
		}

		// Token: 0x0200ACC2 RID: 44226
		public static class EChildType
		{
			// Token: 0x04035AA2 RID: 219810
			public const int TxtTitle = 0;
		}
	}
}
