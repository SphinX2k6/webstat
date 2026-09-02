using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Vision.View
{
	// Token: 0x02005461 RID: 21601
	public class AttributePhantomItem : UiPanelBase
	{
		// Token: 0x0603705B RID: 225371 RVA: 0x00DF7493 File Offset: 0x00DF5693
		[NullableContext(1)]
		public AttributePhantomItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603705C RID: 225372 RVA: 0x00DF74A8 File Offset: 0x00DF56A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.ClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603705D RID: 225373 RVA: 0x00DF75B1 File Offset: 0x00DF57B1
		private void ClickButton()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomBattleFettersObtainView, this.CurrentFetter, null);
		}

		// Token: 0x0603705E RID: 225374 RVA: 0x00DF75D0 File Offset: 0x00DF57D0
		public void Update(int monsterId, PhantomFetter fetterConfig)
		{
			this.CurrentFetter = new PhantomFetter?(fetterConfig);
			if (ModelBase<PhantomBattleModel>.Instance.GetIfHasMonsterInInventory(monsterId))
			{
				base.GetTexture(1).SetUIActive(true);
				CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(monsterId);
				string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(calabashDevelopRewardByMonsterId.Value.MonsterInfoId);
				base.SetTextureByPath(monsterIcon, base.GetTexture(1), new EUiViewName?(EUiViewName.VisionEquipmentView), null);
				RoleInstance curSelectMainRoleInstance = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleInstance();
				base.GetSprite(2).useChangeColor = false;
				base.GetSprite(3).SetUIActive(ControllerBase<PhantomBattleController>.Instance.CheckIsEquipByMonsterId(monsterId, curSelectMainRoleInstance.GetRoleId()));
				return;
			}
			base.GetTexture(1).SetUIActive(false);
			base.GetSprite(2).useChangeColor = true;
		}

		// Token: 0x0401FA7D RID: 129661
		private PhantomFetter? CurrentFetter;

		// Token: 0x0200B3C3 RID: 46019
		private enum EAttributePhantomItem
		{
			// Token: 0x04037AB1 RID: 228017
			EmptySprite,
			// Token: 0x04037AB2 RID: 228018
			Texture,
			// Token: 0x04037AB3 RID: 228019
			BgSprite,
			// Token: 0x04037AB4 RID: 228020
			EquipSprite,
			// Token: 0x04037AB5 RID: 228021
			Button
		}
	}
}
