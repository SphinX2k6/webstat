using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006544 RID: 25924
	public class RealmBetweenPhantomCardItem : GridProxyAbstract<int>, IStaticVariableResetter
	{
		// Token: 0x06040CD7 RID: 265431 RVA: 0x0109DDFE File Offset: 0x0109BFFE
		static RealmBetweenPhantomCardItem()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RealmBetweenPhantomCardItem.CreateStaticDefaultValue), new Action(RealmBetweenPhantomCardItem.ResetStaticDefaultValue));
		}

		// Token: 0x06040CD8 RID: 265432 RVA: 0x0109DE1D File Offset: 0x0109C01D
		public static void CreateStaticDefaultValue()
		{
			RealmBetweenPhantomCardItem.LastClickTimestamp = 0.0;
		}

		// Token: 0x06040CD9 RID: 265433 RVA: 0x0109DE2D File Offset: 0x0109C02D
		public static void ResetStaticDefaultValue()
		{
			RealmBetweenPhantomCardItem.LastClickTimestamp = 0.0;
		}

		// Token: 0x06040CDA RID: 265434 RVA: 0x0109DE3D File Offset: 0x0109C03D
		[NullableContext(1)]
		public RealmBetweenPhantomCardItem(ActivityRealmBetweenData activityData)
		{
			this.ActivityData = activityData;
		}

		// Token: 0x06040CDB RID: 265435 RVA: 0x0109DE4C File Offset: 0x0109C04C
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
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickItem))
			};
		}

		// Token: 0x06040CDC RID: 265436 RVA: 0x0109DF24 File Offset: 0x0109C124
		public override void Refresh(int phantomId, bool isSelected, int gridIndex)
		{
			this.PhantomId = phantomId;
			RealmBetweenPhantomGain value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetPhantomConfig(this.PhantomId).Value;
			bool flag;
			this.ActivityData.PhantomDataMap.TryGetValue(phantomId, out flag);
			IReadOnlyList<Aki.Config.PhantomItem> phantomItemConfigListByMonsterId = ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfigListByMonsterId(phantomId);
			Aki.Config.PhantomItem? phantomItem = (phantomItemConfigListByMonsterId != null) ? new Aki.Config.PhantomItem?(phantomItemConfigListByMonsterId[0]) : null;
			if (phantomItem != null)
			{
				PhantomSkill? phantomSkillBySkillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(phantomItem.Value.SkillId);
				base.SetTextureByPath(((phantomSkillBySkillId != null) ? phantomSkillBySkillId.GetValueOrDefault().BattleViewIcon : null) ?? string.Empty, base.GetTexture(5), null, null);
				this.RefreshTexture(phantomItem.Value.Rarity);
			}
			base.GetItem(1).SetUIActive(!flag);
			base.GetItem(2).SetUIActive(flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.Name, Array.Empty<object>());
			UUIText text = base.GetText(6);
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

		// Token: 0x06040CDD RID: 265437 RVA: 0x0109E084 File Offset: 0x0109C284
		private void RefreshTexture(int rarity)
		{
			string resourceId;
			if (!ActivityRealmBetweenDefine.RealmBetweenMonsterTexture.TryGetValue(rarity, out resourceId))
			{
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (string.IsNullOrEmpty(resourcePath))
			{
				return;
			}
			base.SetTextureByPath(resourcePath, base.GetTexture(3), null, null);
		}

		// Token: 0x06040CDE RID: 265438 RVA: 0x0109E0CE File Offset: 0x0109C2CE
		private void TryUnlockItem()
		{
		}

		// Token: 0x06040CDF RID: 265439 RVA: 0x0109E0D0 File Offset: 0x0109C2D0
		private void OnClickItem()
		{
			double systemNow = Singleton<Time>.Instance.SystemNow;
			if (systemNow - RealmBetweenPhantomCardItem.LastClickTimestamp < 3000.0)
			{
				return;
			}
			RealmBetweenPhantomCardItem.LastClickTimestamp = systemNow;
			RealmBetweenPhantomGain? phantomConfig = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetPhantomConfig(this.PhantomId);
			if (phantomConfig == null)
			{
				return;
			}
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
				return;
			}
			ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
			ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.NormalMonster, Array.Empty<int>(), phantomConfig.Value.MonsterInfoId);
		}

		// Token: 0x0402459F RID: 148895
		private const int CLICK_COOLDOWN_MS = 3000;

		// Token: 0x040245A0 RID: 148896
		protected int PhantomId;

		// Token: 0x040245A1 RID: 148897
		private static double LastClickTimestamp;

		// Token: 0x040245A2 RID: 148898
		[Nullable(1)]
		protected ActivityRealmBetweenData ActivityData;
	}
}
