using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002744 RID: 10052
public class RacingBetsTerrainTip : UiViewBase
{
	// Token: 0x06013DA1 RID: 81313 RVA: 0x0058887A File Offset: 0x00586A7A
	[NullableContext(1)]
	public RacingBetsTerrainTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013DA2 RID: 81314 RVA: 0x00588883 File Offset: 0x00586A83
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06013DA3 RID: 81315 RVA: 0x005888BC File Offset: 0x00586ABC
	protected override void OnBeforeShow()
	{
		object[] array = this.OpenParam as object[];
		if (array == null || array.Length < 3)
		{
			return;
		}
		int organId = (int)array[0];
		int id = (int)array[1];
		RacingBetsOrgan? organConfig = ConfigBase<RacingBetsConfig>.Instance.GetOrganConfig(organId);
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(id);
		base.SetTextureShowUntilLoaded(dangoData.IconAttack, base.GetTexture(0), delegate(bool _)
		{
			UUITexture texture = base.GetTexture(0);
			if (texture == null)
			{
				return;
			}
			texture.SetSizeFromTexture();
		});
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(organConfig.Value.Name);
		string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(organConfig.Value.ActivateDesc);
		string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Dango_InGame_SkillActivated", new string[]
		{
			multiTextByKey,
			multiTextByKey2
		});
		base.GetText(1).SetText(multiText, true);
	}

	// Token: 0x06013DA4 RID: 81316 RVA: 0x00588992 File Offset: 0x00586B92
	protected override void OnAfterPlayStartSequence()
	{
		TimerSystem.Instance.Next(delegate(float _)
		{
			object[] array = this.OpenParam as object[];
			if (array == null || array.Length < 3)
			{
				return;
			}
			base.CloseMe(null);
			CustomPromise<UniTaskVoid> customPromise = array[2] as CustomPromise<UniTaskVoid>;
			if (customPromise == null)
			{
				return;
			}
			customPromise.SetResult(default(UniTaskVoid));
		}, null, null);
	}

	// Token: 0x02008B0C RID: 35596
	private class EComponent
	{
		// Token: 0x0402EE57 RID: 192087
		public const int TerrainIcon = 0;

		// Token: 0x0402EE58 RID: 192088
		public const int TerrainText = 1;
	}
}
