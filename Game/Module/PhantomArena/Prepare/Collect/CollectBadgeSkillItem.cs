using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005512 RID: 21778
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CollectBadgeSkillItem : GridProxyAbstract<BadgeGroupSkillData>
	{
		// Token: 0x060378E3 RID: 227555 RVA: 0x00E18278 File Offset: 0x00E16478
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x060378E4 RID: 227556 RVA: 0x00E182D4 File Offset: 0x00E164D4
		[NullableContext(1)]
		public override void Refresh(BadgeGroupSkillData data, bool isSelected, int gridIndex)
		{
			int groupId = data.GroupId;
			int skillId = data.SkillId;
			BadgeGroupCollectCountData badgeCollectCountByGroupId = ModelBase<PhantomArenaModel>.Instance.GetBadgeCollectCountByGroupId(groupId);
			bool flag = badgeCollectCountByGroupId.Now >= badgeCollectCountByGroupId.Need;
			PhantomBattleSkill phantomBattleSkillConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleSkillConfig(skillId);
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phantomBattleSkillConfig.Name, Array.Empty<object>());
			UUIItem uuiitem = text;
			bool bUseChangeColor = !flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUIText text2 = base.GetText(2);
			UUIItem uuiitem2 = text2;
			bool bUseChangeColor2 = !flag;
			fcolor = new FColor?(text.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, phantomBattleSkillConfig.Desc, phantomBattleSkillConfig.DescParams());
			base.GetSprite(0).SetUIActive(flag);
		}

		// Token: 0x060378E5 RID: 227557 RVA: 0x00E183A6 File Offset: 0x00E165A6
		public override void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x060378E6 RID: 227558 RVA: 0x00E183A8 File Offset: 0x00E165A8
		public override void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x0200B4A1 RID: 46241
		private static class EComponents
		{
			// Token: 0x04037EA4 RID: 229028
			public const int SpriteAll = 0;

			// Token: 0x04037EA5 RID: 229029
			public const int TextName = 1;

			// Token: 0x04037EA6 RID: 229030
			public const int TextDesc = 2;
		}
	}
}
