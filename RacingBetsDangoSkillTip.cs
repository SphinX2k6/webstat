using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002734 RID: 10036
public class RacingBetsDangoSkillTip : UiViewBase
{
	// Token: 0x06013CCB RID: 81099 RVA: 0x0058300C File Offset: 0x0058120C
	[NullableContext(1)]
	public RacingBetsDangoSkillTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013CCC RID: 81100 RVA: 0x00583015 File Offset: 0x00581215
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06013CCD RID: 81101 RVA: 0x00583050 File Offset: 0x00581250
	protected override void OnBeforeShow()
	{
		object[] array = this.OpenParam as object[];
		if (array == null || array.Length < 2)
		{
			return;
		}
		int id = (int)array[0];
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(id);
		base.SetTextureShowUntilLoaded(dangoData.IconAttack, base.GetTexture(0), null);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(dangoData.GetDangoActiveSkillDesc(), true);
	}

	// Token: 0x06013CCE RID: 81102 RVA: 0x005830B4 File Offset: 0x005812B4
	protected override void OnAfterPlayStartSequence()
	{
		TimerSystem.Instance.Next(delegate(float _)
		{
			object[] array = this.OpenParam as object[];
			if (array == null || array.Length < 2)
			{
				return;
			}
			UniTaskCompletionSource uniTaskCompletionSource = array[1] as UniTaskCompletionSource;
			base.CloseMe(null);
			if (uniTaskCompletionSource == null)
			{
				return;
			}
			uniTaskCompletionSource.TrySetResult();
		}, null, null);
	}

	// Token: 0x02008AE4 RID: 35556
	private enum EComponent
	{
		// Token: 0x0402ED4C RID: 191820
		SkillIcon,
		// Token: 0x0402ED4D RID: 191821
		SkillText
	}
}
