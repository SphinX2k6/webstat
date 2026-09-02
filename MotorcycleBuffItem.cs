using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D41 RID: 7489
public class MotorcycleBuffItem : UiPanelBase
{
	// Token: 0x0600DCB7 RID: 56503 RVA: 0x003B5004 File Offset: 0x003B3204
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x0600DCB8 RID: 56504 RVA: 0x003B5074 File Offset: 0x003B3274
	[NullableContext(1)]
	public void SetDesc(IBuffGateDesc buffInfo)
	{
		MotorFightBuffGate? buffGateConfigById = ConfigBase<MotorcycleArrowConfig>.Instance.GetBuffGateConfigById(buffInfo.BuffGateId);
		if (buffGateConfigById == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), buffGateConfigById.Value.DetailDesc, new <>z__ReadOnlySingleElementList<object>(buffInfo.Desc.Item1));
		MotorFightQuality? config = ConfigMotorFightQualityById.GetConfig(buffGateConfigById.Value.Quality, true);
		base.SetTextureByPath(ConfigBase<MotorcycleArrowConfig>.Instance.GetCollectionTypeConfigById(buffGateConfigById.Value.Type).Value.TextureIcon, base.GetTexture(2), null, null);
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		sprite.SetColor(FColor.FromHex(config.Value.BgColor));
	}

	// Token: 0x020080D8 RID: 32984
	private static class EBuffItemComponentDefine
	{
		// Token: 0x0402BD18 RID: 179480
		public const int Self = 0;

		// Token: 0x0402BD19 RID: 179481
		public const int BgSprite = 1;

		// Token: 0x0402BD1A RID: 179482
		public const int IconTexture = 2;

		// Token: 0x0402BD1B RID: 179483
		public const int DescText = 3;
	}
}
