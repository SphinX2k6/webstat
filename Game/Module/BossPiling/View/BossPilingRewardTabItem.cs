using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005F00 RID: 24320
	public class BossPilingRewardTabItem : GridProxyAbstract<int>
	{
		// Token: 0x0603D184 RID: 250244 RVA: 0x00F846D4 File Offset: 0x00F828D4
		[NullableContext(1)]
		public void SetClickCallBack(Action<BossPilingRewardTabItem> callback)
		{
			this.ClickCallBack = callback;
		}

		// Token: 0x0603D185 RID: 250245 RVA: 0x00F846E0 File Offset: 0x00F828E0
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

		// Token: 0x0603D186 RID: 250246 RVA: 0x00F847C8 File Offset: 0x00F829C8
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.Id = data;
			if (gridIndex == 0)
			{
				Action<BossPilingRewardTabItem> clickCallBack = this.ClickCallBack;
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
			BossPilingLevels? levelInfo = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(data);
			if (levelInfo == null)
			{
				return;
			}
			base.GetText(1).ShowTextNew(levelInfo.Value.LevelName);
			base.SetTextureByPath(levelInfo.Value.TaskIndexTex, base.GetTexture(2), null, null);
			this.RefreshRedDot();
		}

		// Token: 0x0603D187 RID: 250247 RVA: 0x00F84868 File Offset: 0x00F82A68
		public void RefreshRedDot()
		{
			BossPilingActivityData activityData = ModelBase<BossPilingModel>.Instance.GetActivityData();
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(activityData.CheckLevelTaskRedDot(this.Id));
		}

		// Token: 0x0603D188 RID: 250248 RVA: 0x00F8489D File Offset: 0x00F82A9D
		private void OnClickToggle(EToggleState state)
		{
			Action<BossPilingRewardTabItem> clickCallBack = this.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack(this);
		}

		// Token: 0x0603D189 RID: 250249 RVA: 0x00F848B0 File Offset: 0x00F82AB0
		public void SetToggleUnCheck()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603D18A RID: 250250 RVA: 0x00F848C3 File Offset: 0x00F82AC3
		public int GetLevelId()
		{
			return this.Id;
		}

		// Token: 0x04022444 RID: 140356
		private int Id;

		// Token: 0x04022445 RID: 140357
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<BossPilingRewardTabItem> ClickCallBack;

		// Token: 0x0200BF02 RID: 48898
		private enum ETab
		{
			// Token: 0x0403AC98 RID: 240792
			Toggle,
			// Token: 0x0403AC99 RID: 240793
			Text,
			// Token: 0x0403AC9A RID: 240794
			Texture,
			// Token: 0x0403AC9B RID: 240795
			RedDotItem
		}
	}
}
