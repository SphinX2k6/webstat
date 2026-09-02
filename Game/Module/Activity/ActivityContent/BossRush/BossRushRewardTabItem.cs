using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069C9 RID: 27081
	internal class BossRushRewardTabItem : GridProxyAbstract<BossRushTaskTab>
	{
		// Token: 0x06043232 RID: 274994 RVA: 0x0113F652 File Offset: 0x0113D852
		[NullableContext(1)]
		public void SetClickCallBack(Action<BossRushRewardTabItem> callback)
		{
			this.ClickCallBack = callback;
		}

		// Token: 0x06043233 RID: 274995 RVA: 0x0113F65C File Offset: 0x0113D85C
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

		// Token: 0x06043234 RID: 274996 RVA: 0x0113F744 File Offset: 0x0113D944
		public override void Refresh(BossRushTaskTab data, bool isSelected, int gridIndex)
		{
			this.Tab = data;
			if (gridIndex == 0)
			{
				Action<BossRushRewardTabItem> clickCallBack = this.ClickCallBack;
				if (clickCallBack != null)
				{
					clickCallBack(this);
				}
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
			else
			{
				this.SetToggleUnCheck();
			}
			BossRushTaskTab bossRushTaskTab = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), bossRushTaskTab.TabTitle, Array.Empty<object>());
			base.SetTextureByPath(bossRushTaskTab.Texture, base.GetTexture(2), null, null);
			this.RefreshRedDot();
		}

		// Token: 0x06043235 RID: 274997 RVA: 0x0113F7CC File Offset: 0x0113D9CC
		public void RefreshRedDot()
		{
			bool tabRedDotState = (ModelBase<ActivityModel>.Instance.GetActivityById(this.Tab.ActivityId) as BossRushData).GetTabRedDotState(this.Tab.TabId);
			this.SetRedDotActive(tabRedDotState);
		}

		// Token: 0x06043236 RID: 274998 RVA: 0x0113F80B File Offset: 0x0113DA0B
		private void OnClickToggle(EToggleState state)
		{
			Action<BossRushRewardTabItem> clickCallBack = this.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack(this);
		}

		// Token: 0x06043237 RID: 274999 RVA: 0x0113F81E File Offset: 0x0113DA1E
		public void SetToggleUnCheck()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06043238 RID: 275000 RVA: 0x0113F831 File Offset: 0x0113DA31
		public BossRushTaskTab GetTab()
		{
			return this.Tab;
		}

		// Token: 0x06043239 RID: 275001 RVA: 0x0113F839 File Offset: 0x0113DA39
		public void SetRedDotActive(bool isShow)
		{
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isShow);
		}

		// Token: 0x0402569B RID: 153243
		private BossRushTaskTab Tab;

		// Token: 0x0402569C RID: 153244
		[Nullable(1)]
		public Action<BossRushRewardTabItem> ClickCallBack;

		// Token: 0x0200C94E RID: 51534
		public class EBossRushRewardTabItemComponent
		{
			// Token: 0x0403DE97 RID: 253591
			public const int Toggle = 0;

			// Token: 0x0403DE98 RID: 253592
			public const int Text = 1;

			// Token: 0x0403DE99 RID: 253593
			public const int Texture = 2;

			// Token: 0x0403DE9A RID: 253594
			public const int RedDotItem = 3;
		}
	}
}
