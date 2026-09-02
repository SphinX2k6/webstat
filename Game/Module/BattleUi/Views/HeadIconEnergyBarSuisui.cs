using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006022 RID: 24610
	public class HeadIconEnergyBarSuisui : HeadIconEnergyBarBase
	{
		// Token: 0x0603E04B RID: 254027 RVA: 0x00FD374C File Offset: 0x00FD194C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E04C RID: 254028 RVA: 0x00FD37F7 File Offset: 0x00FD19F7
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagCountChanged(HeadIconEnergyBarSuisui.FeixianCountTagId, new BaseTagComponent.TTagChangedCallback(this.OnFeixianCountChanged));
			base.ListenForTagAddOrRemoveChanged(HeadIconEnergyBarSuisui.FeixianStateTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnFeixianStateChanged));
		}

		// Token: 0x0603E04D RID: 254029 RVA: 0x00FD382D File Offset: 0x00FD1A2D
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			base.RemoveListenTagCountChanged(HeadIconEnergyBarSuisui.FeixianCountTagId);
			base.RemoveListenTagAddOrRemove(HeadIconEnergyBarSuisui.FeixianStateTagId);
		}

		// Token: 0x0603E04E RID: 254030 RVA: 0x00FD384B File Offset: 0x00FD1A4B
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			this.SetState(this.GetCurrentState(), true);
		}

		// Token: 0x0603E04F RID: 254031 RVA: 0x00FD3860 File Offset: 0x00FD1A60
		private HeadIconEnergyBarSuisui.EState GetCurrentState()
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null || !tagComponent.HasTag(HeadIconEnergyBarSuisui.FeixianStateTagId))
			{
				return HeadIconEnergyBarSuisui.EState.Normal;
			}
			return HeadIconEnergyBarSuisui.EState.Feixian;
		}

		// Token: 0x0603E050 RID: 254032 RVA: 0x00FD387E File Offset: 0x00FD1A7E
		private void OnFeixianStateChanged(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? HeadIconEnergyBarSuisui.EState.Feixian : HeadIconEnergyBarSuisui.EState.Normal, false);
		}

		// Token: 0x0603E051 RID: 254033 RVA: 0x00FD3890 File Offset: 0x00FD1A90
		private void SetState(HeadIconEnergyBarSuisui.EState state, bool isForced = false)
		{
			if (this.CurState == state && !isForced)
			{
				return;
			}
			this.CurState = state;
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(this.CurState == HeadIconEnergyBarSuisui.EState.Feixian);
			}
			if (this.CurState == HeadIconEnergyBarSuisui.EState.Feixian)
			{
				this.RefreshFeixianCount(this.GetFeixianCount(), true);
			}
		}

		// Token: 0x0603E052 RID: 254034 RVA: 0x00FD38E2 File Offset: 0x00FD1AE2
		private int GetFeixianCount()
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null)
			{
				return 0;
			}
			return tagComponent.GetTagCount(HeadIconEnergyBarSuisui.FeixianCountTagId);
		}

		// Token: 0x0603E053 RID: 254035 RVA: 0x00FD38FA File Offset: 0x00FD1AFA
		private void OnFeixianCountChanged(int count, int tagId, int exactTagId, int oldCount)
		{
			if (count == oldCount || this.CurState == HeadIconEnergyBarSuisui.EState.Normal)
			{
				return;
			}
			this.RefreshFeixianCount(count, false);
		}

		// Token: 0x0603E054 RID: 254036 RVA: 0x00FD3914 File Offset: 0x00FD1B14
		private void RefreshFeixianCount(int count, bool isForced = false)
		{
			if (this.FeixianCount == count && !isForced)
			{
				return;
			}
			this.FeixianCount = count;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(count >= 1);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(count >= 2);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(count >= 3);
		}

		// Token: 0x04022C6A RID: 142442
		private static readonly int FeixianCountTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1SuisuiMd10011.飞仙.飞仙次数"];

		// Token: 0x04022C6B RID: 142443
		private static readonly int FeixianStateTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1SuisuiMd10011.飞仙.允许飞仙"];

		// Token: 0x04022C6C RID: 142444
		private int FeixianCount;

		// Token: 0x04022C6D RID: 142445
		private HeadIconEnergyBarSuisui.EState CurState;

		// Token: 0x0200C0D1 RID: 49361
		private enum EState
		{
			// Token: 0x0403B5D9 RID: 243161
			Normal,
			// Token: 0x0403B5DA RID: 243162
			Feixian
		}

		// Token: 0x0200C0D2 RID: 49362
		private enum EChildType
		{
			// Token: 0x0403B5DC RID: 243164
			SprPartFg01,
			// Token: 0x0403B5DD RID: 243165
			SprPartFg02,
			// Token: 0x0403B5DE RID: 243166
			SprPartFg03,
			// Token: 0x0403B5DF RID: 243167
			FullBar
		}
	}
}
