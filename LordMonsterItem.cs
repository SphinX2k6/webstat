using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002213 RID: 8723
public class LordMonsterItem : UiPanelBase
{
	// Token: 0x06010783 RID: 67459 RVA: 0x0047F66C File Offset: 0x0047D86C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06010784 RID: 67460 RVA: 0x0047F6C8 File Offset: 0x0047D8C8
	public void SetMonsterInfo(int monsterId, int level)
	{
		string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(monsterId);
		base.SetTextureByPath(monsterIcon, base.GetTexture(2), null, null);
		string monsterName = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterName(monsterId);
		base.GetText(0).SetText(monsterName, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_InstanceDungeonRecommendLevel_Text", new <>z__ReadOnlySingleElementList<object>(level));
	}

	// Token: 0x020084F5 RID: 34037
	private class EChildType
	{
		// Token: 0x0402D06C RID: 184428
		public const int NameText = 0;

		// Token: 0x0402D06D RID: 184429
		public const int LevelText = 1;

		// Token: 0x0402D06E RID: 184430
		public const int MonsterTexture = 2;
	}
}
