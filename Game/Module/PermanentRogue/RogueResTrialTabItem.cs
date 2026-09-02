using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056A0 RID: 22176
	public class RogueResTrialTabItem : GridProxyAbstract<ERogueResTrialType>
	{
		// Token: 0x06038758 RID: 231256 RVA: 0x00E4DB68 File Offset: 0x00E4BD68
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x06038759 RID: 231257 RVA: 0x00E4DC1A File Offset: 0x00E4BE1A
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<RogueResTrialRoleItem, int>(base.GetGridLayout(2), new Func<RogueResTrialRoleItem>(this.InitRoleGrid), null, false, true);
		}

		// Token: 0x0603875A RID: 231258 RVA: 0x00E4DC40 File Offset: 0x00E4BE40
		public override void Refresh(ERogueResTrialType data, bool isSelected, int gridIndex)
		{
			List<int> trailRole = ModelBase<ActivityPermanentRogueModel>.Instance.GetTrailRole(this.SeasonId, data);
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			List<int> list = new List<int>();
			foreach (int num in trailRole)
			{
				int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(num);
				if (!ModelBase<RoleModel>.Instance.IsMainRole(baseRoleId))
				{
					list.Add(num);
				}
				else if (ConfigBase<RoleConfig>.Instance.GetMainRoleById(baseRoleId).Value.Gender == (int)playerGender)
				{
					list.Add(num);
				}
			}
			GenericLayout<RogueResTrialRoleItem, int> layout = this.Layout;
			if (layout != null)
			{
				layout.RefreshByData(list, null, false);
			}
			FColor color = FColor.FromHex(<RogueResTrialPopView>F29D94ADC41C353A1158DA27AD579C782AE139604B34515B9B14F4E1C6539BDC6__TabColorMap.GetColor(data));
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetColor(color);
			}
			FColor color2 = FColor.FromHex(<RogueResTrialPopView>F29D94ADC41C353A1158DA27AD579C782AE139604B34515B9B14F4E1C6539BDC6__TxtColorMap.GetColor(data));
			base.GetText(1).SetColor(color2);
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			if (data == ERogueResTrialType.Dynamic)
			{
				string trailRemainTime = ModelBase<ActivityPermanentRogueModel>.Instance.GetTrailRemainTime(this.SeasonId);
				UUIText text2 = base.GetText(5);
				if (text2 != null)
				{
					text2.SetText(trailRemainTime, true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), <RogueResTrialPopView>F29D94ADC41C353A1158DA27AD579C782AE139604B34515B9B14F4E1C6539BDC6__TabTextMap.GetText(data), Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), <RogueResTrialPopView>F29D94ADC41C353A1158DA27AD579C782AE139604B34515B9B14F4E1C6539BDC6__TabTextMap.GetText(data), Array.Empty<object>());
		}

		// Token: 0x0603875B RID: 231259 RVA: 0x00E4DDD0 File Offset: 0x00E4BFD0
		[NullableContext(1)]
		private RogueResTrialRoleItem InitRoleGrid()
		{
			return new RogueResTrialRoleItem();
		}

		// Token: 0x040203BB RID: 132027
		public int SeasonId;

		// Token: 0x040203BC RID: 132028
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RogueResTrialRoleItem, int> Layout;
	}
}
