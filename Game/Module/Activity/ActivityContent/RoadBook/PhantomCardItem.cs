using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064A2 RID: 25762
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomCardItem : GridProxyAbstract<int>
	{
		// Token: 0x06040980 RID: 264576 RVA: 0x0108EA2A File Offset: 0x0108CC2A
		public PhantomCardItem(ActivityRoadBookData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x06040981 RID: 264577 RVA: 0x0108EA3C File Offset: 0x0108CC3C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickItem))
			};
		}

		// Token: 0x06040982 RID: 264578 RVA: 0x0108EB6C File Offset: 0x0108CD6C
		public override void Refresh(int phantomId, bool isSelected, int gridIndex)
		{
			this.PhantomId = phantomId;
			RoadBookPhantomGain value = ConfigBase<ActivityRoadBookConfig>.Instance.GetPhantomConfig(this.PhantomId).Value;
			bool flag;
			this.ActivityBaseData.PhantomDataMap.TryGetValue(phantomId, out flag);
			IReadOnlyList<Aki.Config.PhantomItem> phantomItemConfigListByMonsterId = ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfigListByMonsterId(phantomId);
			Aki.Config.PhantomItem? phantomItem = (phantomItemConfigListByMonsterId != null) ? new Aki.Config.PhantomItem?(phantomItemConfigListByMonsterId[0]) : null;
			if (phantomItem != null)
			{
				PhantomSkill? phantomSkillBySkillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(phantomItem.Value.SkillId);
				base.SetTextureByPath(((phantomSkillBySkillId != null) ? phantomSkillBySkillId.GetValueOrDefault().BattleViewIcon : null) ?? string.Empty, base.GetTexture(8), null, null);
				this.RefreshTexture(phantomItem.Value.Rarity);
			}
			base.GetItem(1).SetUIActive(!flag);
			base.GetItem(2).SetUIActive(flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), value.Name, Array.Empty<object>());
			UUIText text = base.GetText(9);
			if (text != null)
			{
				text.SetColor(FColor.FromHex(flag ? "#2B2D2E" : "#515155"));
			}
			base.SetTextureShowUntilLoaded(value.TexPhantom, base.GetTexture(4), null);
			if (flag)
			{
				this.TryUnlockItem();
			}
		}

		// Token: 0x06040983 RID: 264579 RVA: 0x0108ECCC File Offset: 0x0108CECC
		private void RefreshTexture(int rarity)
		{
			int cost = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost;
			int num = 0;
			switch (cost)
			{
			case 1:
				num = 0;
				break;
			case 3:
				num = 1;
				break;
			case 4:
				num = 2;
				break;
			}
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("T_TheMeMapChipBg");
			defaultInterpolatedStringHandler.AppendFormatted<int>((num < 2) ? 1 : 2);
			string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
			base.SetTextureByPath(resourcePath, base.GetTexture(3), null, null);
			UiResourceConfig instance2 = ConfigBase<UiResourceConfig>.Instance;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("T_TheMeMapChipTop");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			base.SetTextureByPath(instance2.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear()), base.GetTexture(5), null, null);
			UiResourceConfig instance3 = ConfigBase<UiResourceConfig>.Instance;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("T_TheMeMapDisk");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			base.SetTextureByPath(instance3.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear()), base.GetTexture(6), null, null);
			UiResourceConfig instance4 = ConfigBase<UiResourceConfig>.Instance;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("T_TheMeMapCalipers");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			base.SetTextureByPath(instance4.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear()), base.GetTexture(7), null, null);
			string hexStr;
			ActivityRoadBookDefine.RoadBookPhantomColorText.TryGetValue(num + 1, out hexStr);
			base.GetSprite(10).SetColor(FColor.FromHex(hexStr));
		}

		// Token: 0x06040984 RID: 264580 RVA: 0x0108EE65 File Offset: 0x0108D065
		private void TryUnlockItem()
		{
			this.ActivityBaseData.SaveFirstCheckRedDotState(ERoadBookSaveFlag.PhantomCollectNewUnlock, this.PhantomId);
		}

		// Token: 0x06040985 RID: 264581 RVA: 0x0108EE7C File Offset: 0x0108D07C
		private void OnClickItem()
		{
			double systemNow = Singleton<Time>.Instance.SystemNow;
			if (systemNow - this.LastClickTimestamp < 3000.0)
			{
				return;
			}
			this.LastClickTimestamp = systemNow;
			RoadBookPhantomGain value = ConfigBase<ActivityRoadBookConfig>.Instance.GetPhantomConfig(this.PhantomId).Value;
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
				return;
			}
			ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
			ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.NormalMonster, Array.Empty<int>(), value.MonsterInfoId);
		}

		// Token: 0x040242A0 RID: 148128
		protected int PhantomId;

		// Token: 0x040242A1 RID: 148129
		private double LastClickTimestamp;

		// Token: 0x040242A2 RID: 148130
		protected ActivityRoadBookData ActivityBaseData;
	}
}
