using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B6E RID: 19310
	public class QuickNavigateItemPanelB : UiPanelBase
	{
		// Token: 0x06032737 RID: 206647 RVA: 0x00C9ED6C File Offset: 0x00C9CF6C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032738 RID: 206648 RVA: 0x00C9EE14 File Offset: 0x00C9D014
		[NullableContext(1)]
		public void RefreshByData(QuickNavigateDynamicData data)
		{
			this.NavigateDynamicData = data;
			State? config = ConfigStateByStateId.GetConfig(data.StateId, true);
			if (config == null)
			{
				return;
			}
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, config.Value.StateName, Array.Empty<object>());
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				EToggleState state = data.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
				extendToggle.SetToggleState(state, false, false, false);
			}
		}

		// Token: 0x06032739 RID: 206649 RVA: 0x00C9EE8B File Offset: 0x00C9D08B
		private void OnClickToggle(EToggleState toggleState)
		{
			if (this.NavigateDynamicData != null)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				if (instance == null)
				{
					return;
				}
				instance.Emit<QuickNavigateDynamicData>(EEventName.WorldMapFirstNavigateSelect, this.NavigateDynamicData);
			}
		}

		// Token: 0x0401D6F7 RID: 120567
		[Nullable(2)]
		private QuickNavigateDynamicData NavigateDynamicData;

		// Token: 0x0200AC3A RID: 44090
		public static class EComponent
		{
			// Token: 0x040358F3 RID: 219379
			public const int TogList = 0;

			// Token: 0x040358F4 RID: 219380
			public const int TxtList = 1;
		}
	}
}
