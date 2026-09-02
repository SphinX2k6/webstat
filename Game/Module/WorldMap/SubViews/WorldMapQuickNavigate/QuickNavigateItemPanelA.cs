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
	// Token: 0x02004B6D RID: 19309
	public class QuickNavigateItemPanelA : UiPanelBase
	{
		// Token: 0x06032732 RID: 206642 RVA: 0x00C9EB48 File Offset: 0x00C9CD48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032733 RID: 206643 RVA: 0x00C9EC30 File Offset: 0x00C9CE30
		[NullableContext(1)]
		public void RefreshByData(QuickNavigateDynamicData data)
		{
			this.NavigateDynamicData = data;
			Country? config = ConfigCountryById.GetConfig(data.CountryId, true);
			if (config == null)
			{
				return;
			}
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, config.Value.Title, Array.Empty<object>());
			UUITexture texture = base.GetTexture(2);
			base.SetTextureByPath(config.Value.Logo, texture, null, null);
			bool hasState = this.NavigateDynamicData.HasState;
			this.UpdateToggleSetState();
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(hasState);
		}

		// Token: 0x06032734 RID: 206644 RVA: 0x00C9ECD1 File Offset: 0x00C9CED1
		private void OnClickToggle(EToggleState toggleState)
		{
			this.UpdateToggleSetState();
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

		// Token: 0x06032735 RID: 206645 RVA: 0x00C9ECFC File Offset: 0x00C9CEFC
		private void UpdateToggleSetState()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null || this.NavigateDynamicData == null)
			{
				return;
			}
			if (this.NavigateDynamicData.HasState)
			{
				extendToggle.SetToggleState(this.NavigateDynamicData.IsExpand ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
			extendToggle.SetToggleState(this.NavigateDynamicData.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0401D6F6 RID: 120566
		[Nullable(2)]
		private QuickNavigateDynamicData NavigateDynamicData;

		// Token: 0x0200AC39 RID: 44089
		public static class EComponent
		{
			// Token: 0x040358EF RID: 219375
			public const int UiItemStripF2 = 0;

			// Token: 0x040358F0 RID: 219376
			public const int TxtName = 1;

			// Token: 0x040358F1 RID: 219377
			public const int TexIcon = 2;

			// Token: 0x040358F2 RID: 219378
			public const int SprArrow = 3;
		}
	}
}
