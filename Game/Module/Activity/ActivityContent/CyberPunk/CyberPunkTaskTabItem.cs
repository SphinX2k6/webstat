using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200697B RID: 27003
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CyberPunkTaskTabItem : GridProxyAbstract<CyberPunkTaskTabData>
	{
		// Token: 0x06042FE6 RID: 274406 RVA: 0x01133468 File Offset: 0x01131668
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickTab));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042FE7 RID: 274407 RVA: 0x01133574 File Offset: 0x01131774
		[NullableContext(1)]
		public override void Refresh(CyberPunkTaskTabData data, bool isSelected, int gridIndex)
		{
			this.TabId = data.TabId;
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(isSelected);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(data.TabName, true);
			}
			this.BindRedDot();
		}

		// Token: 0x06042FE8 RID: 274408 RVA: 0x011335DC File Offset: 0x011317DC
		private void BindRedDot()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotCyberPunkTaskTab, item, null, this.TabId);
			}
		}

		// Token: 0x06042FE9 RID: 274409 RVA: 0x0113360C File Offset: 0x0113180C
		private void UnBindRedDot()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotCyberPunkTaskTab, item, this.TabId);
			}
		}

		// Token: 0x06042FEA RID: 274410 RVA: 0x0113363A File Offset: 0x0113183A
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x06042FEB RID: 274411 RVA: 0x01133642 File Offset: 0x01131842
		public void SetRedDotVisible(bool visible)
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(visible);
		}

		// Token: 0x06042FEC RID: 274412 RVA: 0x01133658 File Offset: 0x01131858
		public void SetSelected(bool selected, bool fireEvent = false)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(selected);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			if (fireEvent)
			{
				Action<int, CyberPunkTaskTabItem> onTabClickCallback = this.OnTabClickCallback;
				if (onTabClickCallback == null)
				{
					return;
				}
				onTabClickCallback(this.TabId, this);
			}
		}

		// Token: 0x06042FED RID: 274413 RVA: 0x011336AE File Offset: 0x011318AE
		public int GetTabId()
		{
			return this.TabId;
		}

		// Token: 0x06042FEE RID: 274414 RVA: 0x011336B8 File Offset: 0x011318B8
		public void SetTabIconByTabId(int tabId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SP_TogTabBg");
			defaultInterpolatedStringHandler.AppendFormatted<int>(tabId);
			string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
			}
		}

		// Token: 0x06042FEF RID: 274415 RVA: 0x01133718 File Offset: 0x01131918
		private void OnClickTab(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int, CyberPunkTaskTabItem> onTabClickCallback = this.OnTabClickCallback;
				if (onTabClickCallback == null)
				{
					return;
				}
				onTabClickCallback(this.TabId, this);
			}
		}

		// Token: 0x04025512 RID: 152850
		private int TabId;

		// Token: 0x04025513 RID: 152851
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, CyberPunkTaskTabItem> OnTabClickCallback;

		// Token: 0x0200C921 RID: 51489
		private static class ETabComponents
		{
			// Token: 0x0403DDDD RID: 253405
			public const int TogTab = 0;

			// Token: 0x0403DDDE RID: 253406
			public const int TogBgSprite = 1;

			// Token: 0x0403DDDF RID: 253407
			public const int TxtTabName = 2;

			// Token: 0x0403DDE0 RID: 253408
			public const int PitchState = 3;

			// Token: 0x0403DDE1 RID: 253409
			public const int Red = 4;
		}
	}
}
