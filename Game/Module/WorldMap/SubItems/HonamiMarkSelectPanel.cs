using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubItems
{
	// Token: 0x02004BEA RID: 19434
	public class HonamiMarkSelectPanel : UiPanelBase, IWorldMapItemVisibleControlInterface
	{
		// Token: 0x17008717 RID: 34583
		// (get) Token: 0x06032B53 RID: 207699 RVA: 0x00CB3AF7 File Offset: 0x00CB1CF7
		// (set) Token: 0x06032B54 RID: 207700 RVA: 0x00CB3AFF File Offset: 0x00CB1CFF
		public EWorldMapShowMode ShowMode { get; set; }

		// Token: 0x06032B55 RID: 207701 RVA: 0x00CB3B08 File Offset: 0x00CB1D08
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032B56 RID: 207702 RVA: 0x00CB3B74 File Offset: 0x00CB1D74
		protected override UniTask OnBeforeStartAsync()
		{
			HonamiMarkSelectPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiMarkSelectPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032B57 RID: 207703 RVA: 0x00CB3BB7 File Offset: 0x00CB1DB7
		public void SetWorldMapSelfShow(EWorldMapShowMode showMode)
		{
			this.ShowMode = showMode;
		}

		// Token: 0x06032B58 RID: 207704 RVA: 0x00CB3BC0 File Offset: 0x00CB1DC0
		public void RefreshWorldMapSelfShow(EWorldMapShowMode showMode)
		{
			base.SetUiActive(showMode == EWorldMapShowMode.HonamiStory);
		}

		// Token: 0x0401D84D RID: 120909
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<HonamiMarkSelectItem, int> ScrollView;
	}
}
