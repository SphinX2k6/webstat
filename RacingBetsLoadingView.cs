using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020020DE RID: 8414
public class RacingBetsLoadingView : LoadingViewBase
{
	// Token: 0x0601014B RID: 65867 RVA: 0x00469E45 File Offset: 0x00468045
	[NullableContext(1)]
	public RacingBetsLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601014C RID: 65868 RVA: 0x00469E4E File Offset: 0x0046804E
	protected override void OnStart()
	{
		base.OnStart();
		UUIItem item = base.GetItem(1);
		this.FullSize = ((item != null) ? item.Width : 0f);
	}

	// Token: 0x0601014D RID: 65869 RVA: 0x00469E73 File Offset: 0x00468073
	protected override void OnBeforeShow()
	{
		ControllerBase<GameAudioController>.Instance.UpdateLoadingType(new ELoadingPerform?(ELoadingPerform.Loading));
	}

	// Token: 0x0601014E RID: 65870 RVA: 0x00469E88 File Offset: 0x00468088
	protected override void OnBeforeHide()
	{
		ControllerBase<GameAudioController>.Instance.UpdateLoadingType(null);
	}

	// Token: 0x0601014F RID: 65871 RVA: 0x00469EA8 File Offset: 0x004680A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06010150 RID: 65872 RVA: 0x00469F34 File Offset: 0x00468134
	protected override void UpdateProgressRate(float rate)
	{
		base.SetTextureProgressRate(0, rate);
		float anchorOffsetX = this.FullSize * rate;
		UUINiagara uiNiagara = base.GetUiNiagara(2);
		if (uiNiagara == null)
		{
			return;
		}
		uiNiagara.SetAnchorOffsetX(anchorOffsetX);
	}

	// Token: 0x06010151 RID: 65873 RVA: 0x00469F64 File Offset: 0x00468164
	protected override void UpdateProgressValue(float value)
	{
	}

	// Token: 0x06010152 RID: 65874 RVA: 0x00469F66 File Offset: 0x00468166
	protected override void OnLevelSequencePlayerBandStateChange(bool state)
	{
		base.PlaySequence("Start01", null, false);
	}

	// Token: 0x04007B40 RID: 31552
	private float FullSize;

	// Token: 0x0200845A RID: 33882
	private class EChildType
	{
		// Token: 0x0402CD7F RID: 183679
		public const int TextureProgress = 0;

		// Token: 0x0402CD80 RID: 183680
		public const int ItemNiagaraRoot = 1;

		// Token: 0x0402CD81 RID: 183681
		public const int NiagaraProgress = 2;
	}
}
