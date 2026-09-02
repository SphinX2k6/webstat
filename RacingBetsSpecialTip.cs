using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002743 RID: 10051
public class RacingBetsSpecialTip : UiViewBase
{
	// Token: 0x06013D9D RID: 81309 RVA: 0x0058872D File Offset: 0x0058692D
	[NullableContext(1)]
	public RacingBetsSpecialTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013D9E RID: 81310 RVA: 0x00588736 File Offset: 0x00586936
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06013D9F RID: 81311 RVA: 0x00588770 File Offset: 0x00586970
	protected override void OnBeforeShow()
	{
		object[] array = this.OpenParam as object[];
		if (array == null || array.Length < 3)
		{
			return;
		}
		int id = (int)array[0];
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(id);
		base.SetTextureShowUntilLoaded(dangoData.Icon, base.GetTexture(0), null);
		int id2 = (int)array[1];
		DangoSkill? dangoSkillById = ConfigBase<DangoConfig>.Instance.GetDangoSkillById(id2);
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(dangoSkillById.Value.Name);
		string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(dangoSkillById.Value.ActivateDesc);
		string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Dango_InGame_SkillActivated", new string[]
		{
			multiTextByKey,
			multiTextByKey2
		});
		base.GetText(1).SetText(multiText, true);
	}

	// Token: 0x06013DA0 RID: 81312 RVA: 0x0058883C File Offset: 0x00586A3C
	protected override void OnAfterPlayStartSequence()
	{
		object[] array = this.OpenParam as object[];
		if (array == null || array.Length < 3)
		{
			return;
		}
		base.CloseMe(null);
		UniTaskCompletionSource<bool> uniTaskCompletionSource = array[2] as UniTaskCompletionSource<bool>;
		if (uniTaskCompletionSource == null)
		{
			return;
		}
		uniTaskCompletionSource.TrySetResult(true);
	}

	// Token: 0x02008B0B RID: 35595
	private class EComponent
	{
		// Token: 0x0402EE55 RID: 192085
		public const int SpecialIcon = 0;

		// Token: 0x0402EE56 RID: 192086
		public const int SpecialText = 1;
	}
}
