using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006829 RID: 26665
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FishingRoleTechItem : GridProxyAbstract<IFishingTechNode>
	{
		// Token: 0x060427C9 RID: 272329 RVA: 0x01110090 File Offset: 0x0110E290
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060427CA RID: 272330 RVA: 0x01110240 File Offset: 0x0110E440
		protected override void OnStart()
		{
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x060427CB RID: 272331 RVA: 0x01110250 File Offset: 0x0110E450
		[NullableContext(1)]
		public override void Refresh(IFishingTechNode data, bool isSelected, int gridIndex)
		{
			FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(data.ConfigId);
			if (this.Node != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingRoleTechNode, base.GetItem(8), 0);
			}
			this.Node = data;
			base.GetScrollScrollbar(9).SetValue(0f, true);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRedDotRefresh, this.Node.ConfigId);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FishingRoleTechNode, base.GetItem(8), null, this.Node.ConfigId);
			base.SetTextureByPath(fishingTechById.Icon, base.GetTexture(5), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), fishingTechById.Name, Array.Empty<object>());
			int techNodeCurrentLevel = ModelBase<FishingModel>.Instance.GetTechNodeCurrentLevel(data.ConfigId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "PrefabTextItem_3692737534_Text", new <>z__ReadOnlySingleElementList<object>(techNodeCurrentLevel));
			int effectLength = fishingTechById.EffectLength;
			if (techNodeCurrentLevel >= effectLength)
			{
				base.GetItem(4).SetUIActive(true);
				base.GetItem(2).SetUIActive(false);
				int techEffectId = fishingTechById.Effect(effectLength - 1);
				FishingTechEffect fishingTechEffectById = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), fishingTechEffectById.Desc, fishingTechEffectById.ShowParams());
				return;
			}
			base.GetItem(4).SetUIActive(false);
			bool nodePreNodeUnlock = ModelBase<FishingModel>.Instance.GetNodePreNodeUnlock(this.Node.ConfigId);
			base.GetItem(2).SetUIActive(!nodePreNodeUnlock);
			int techEffectId2 = fishingTechById.Effect(techNodeCurrentLevel);
			FishingTechEffect fishingTechEffectById2 = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId2);
			if (techNodeCurrentLevel == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), fishingTechEffectById2.Desc, fishingTechEffectById2.ShowParams());
				return;
			}
			int techEffectId3 = fishingTechById.Effect(techNodeCurrentLevel - 1);
			FishingTechEffect fishingTechEffectById3 = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId3);
			List<string> list = new List<string>();
			int showParamsLength = fishingTechEffectById3.ShowParamsLength;
			for (int i = 0; i < showParamsLength; i++)
			{
				string item = fishingTechEffectById3.ShowParams(i) + "->" + fishingTechEffectById2.ShowParams(i);
				list.Add(item);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), fishingTechEffectById2.Desc, list.ToArray());
		}

		// Token: 0x060427CC RID: 272332 RVA: 0x011104A1 File Offset: 0x0110E6A1
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingRoleTechNode, base.GetItem(8), this.Node.ConfigId);
		}

		// Token: 0x060427CD RID: 272333 RVA: 0x011104C4 File Offset: 0x0110E6C4
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<IFishingTechNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(this.Node, base.GetExtendToggle(6));
		}

		// Token: 0x060427CE RID: 272334 RVA: 0x011104E3 File Offset: 0x0110E6E3
		public void SelectToggle()
		{
			Action<IFishingTechNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack != null)
			{
				onClickToggleBack(this.Node, base.GetExtendToggle(6));
			}
			base.GetExtendToggle(6).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x04025022 RID: 151586
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<IFishingTechNode, UUIExtendToggle> OnClickToggleBack;

		// Token: 0x04025023 RID: 151587
		[Nullable(2)]
		public IFishingTechNode Node;

		// Token: 0x0200C868 RID: 51304
		private class EComponentDefine
		{
			// Token: 0x0403DAE5 RID: 252645
			public const int NameText = 0;

			// Token: 0x0403DAE6 RID: 252646
			public const int DesText = 1;

			// Token: 0x0403DAE7 RID: 252647
			public const int LockItem = 2;

			// Token: 0x0403DAE8 RID: 252648
			public const int EnableItem = 3;

			// Token: 0x0403DAE9 RID: 252649
			public const int MaxItem = 4;

			// Token: 0x0403DAEA RID: 252650
			public const int IconTexture = 5;

			// Token: 0x0403DAEB RID: 252651
			public const int Toggle = 6;

			// Token: 0x0403DAEC RID: 252652
			public const int TechLevelText = 7;

			// Token: 0x0403DAED RID: 252653
			public const int RedDotItem = 8;

			// Token: 0x0403DAEE RID: 252654
			public const int ScrollViewBar = 9;
		}
	}
}
