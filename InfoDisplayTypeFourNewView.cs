using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002001 RID: 8193
[NullableContext(1)]
[Nullable(0)]
public class InfoDisplayTypeFourNewView : UiTickViewBase
{
	// Token: 0x0600F767 RID: 63335 RVA: 0x0043BB17 File Offset: 0x00439D17
	public InfoDisplayTypeFourNewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F768 RID: 63336 RVA: 0x0043BB20 File Offset: 0x00439D20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F769 RID: 63337 RVA: 0x0043BC6C File Offset: 0x00439E6C
	protected override void OnStart()
	{
		int configId = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		this.AudioPlayer = new InfoDisplayAudioPlayerWithProgress();
		this.NiagaraSoundWave = base.GetUiNiagara(5);
		this.InitView(configId);
		this.InitAudioPlayer(configId);
	}

	// Token: 0x0600F76A RID: 63338 RVA: 0x0043BCAB File Offset: 0x00439EAB
	protected override void OnTick(float delta)
	{
		InfoDisplayAudioPlayerWithProgress audioPlayer = this.AudioPlayer;
		if (audioPlayer != null)
		{
			audioPlayer.Tick(delta);
		}
		this.TickNiagaraInterp(delta);
	}

	// Token: 0x0600F76B RID: 63339 RVA: 0x0043BCC8 File Offset: 0x00439EC8
	private UniTask InitAudioPlayer(int configId)
	{
		InfoDisplayTypeFourNewView.<InitAudioPlayer>d__14 <InitAudioPlayer>d__;
		<InitAudioPlayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAudioPlayer>d__.<>4__this = this;
		<InitAudioPlayer>d__.configId = configId;
		<InitAudioPlayer>d__.<>1__state = -1;
		<InitAudioPlayer>d__.<>t__builder.Start<InfoDisplayTypeFourNewView.<InitAudioPlayer>d__14>(ref <InitAudioPlayer>d__);
		return <InitAudioPlayer>d__.<>t__builder.Task;
	}

	// Token: 0x0600F76C RID: 63340 RVA: 0x0043BD14 File Offset: 0x00439F14
	private void InitView(int configId)
	{
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(configId);
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText(infoDisplayTitle, true);
		}
		string infoDisplayDesc = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayDesc(configId);
		UUIText text2 = base.GetText(0);
		if (text2 != null)
		{
			text2.SetText(infoDisplayDesc, true);
		}
	}

	// Token: 0x0600F76D RID: 63341 RVA: 0x0043BD5F File Offset: 0x00439F5F
	private void InternalClose()
	{
		InfoDisplayAudioPlayerWithProgress audioPlayer = this.AudioPlayer;
		if (audioPlayer != null)
		{
			audioPlayer.Stop();
		}
		base.CloseMe(null);
	}

	// Token: 0x0600F76E RID: 63342 RVA: 0x0043BD79 File Offset: 0x00439F79
	private void SetNiagaraActive(bool isActive)
	{
		this.NeedInterpNiagara = true;
		this.InterpTime = 0f;
		this.ReverseInterp = !isActive;
	}

	// Token: 0x0600F76F RID: 63343 RVA: 0x0043BD98 File Offset: 0x00439F98
	[NullableContext(2)]
	private void NiagaraInterpImp(UUINiagara niagara, float t)
	{
		if (niagara == null)
		{
			return;
		}
		float value = this.ReverseInterp ? (3f - t * 3f) : (0f + t * 3f);
		niagara.SetNiagaraVarFloat("WPO", value);
		float value2 = this.ReverseInterp ? (1f - t * 1f) : (0f + t * 1f);
		niagara.SetNiagaraVarFloat("Dissolve", value2);
	}

	// Token: 0x0600F770 RID: 63344 RVA: 0x0043BE0C File Offset: 0x0043A00C
	private void TickNiagaraInterp(float deltaTime)
	{
		if (!this.NeedInterpNiagara)
		{
			return;
		}
		this.InterpTime += deltaTime;
		float num = this.InterpTime / 100f;
		if (num >= 1f)
		{
			this.NeedInterpNiagara = false;
			this.InterpTime = 0f;
			num = 1f;
		}
		this.NiagaraInterpImp(this.NiagaraSoundWave, num);
	}

	// Token: 0x0600F771 RID: 63345 RVA: 0x0043BE6A File Offset: 0x0043A06A
	private void OnClickClose()
	{
		this.InternalClose();
	}

	// Token: 0x0600F772 RID: 63346 RVA: 0x0043BE72 File Offset: 0x0043A072
	private void OnAudioEnd()
	{
		this.InternalClose();
	}

	// Token: 0x0600F773 RID: 63347 RVA: 0x0043BE7A File Offset: 0x0043A07A
	private void OnAudioPlay()
	{
		this.SetNiagaraActive(true);
	}

	// Token: 0x0600F774 RID: 63348 RVA: 0x0043BE83 File Offset: 0x0043A083
	private void OnAudioPause()
	{
		this.SetNiagaraActive(false);
	}

	// Token: 0x0400777C RID: 30588
	private const string NIAGARA_PARAM_WPO_KEY = "WPO";

	// Token: 0x0400777D RID: 30589
	private const float NIAGARA_PARAM_WPO_ACTIVE = 3f;

	// Token: 0x0400777E RID: 30590
	private const float NIAGARA_PARAM_WPO_INACTIVE = 0f;

	// Token: 0x0400777F RID: 30591
	private const string NIAGARA_PARAM_DISSOLVE_KEY = "Dissolve";

	// Token: 0x04007780 RID: 30592
	private const float NIAGARA_PARAM_DISSOLVE_ACTIVE = 1f;

	// Token: 0x04007781 RID: 30593
	private const float NIAGARA_PARAM_DISSOLVE_INACTIVE = 0f;

	// Token: 0x04007782 RID: 30594
	private const float NIAGARA_INTERP_TIME = 100f;

	// Token: 0x04007783 RID: 30595
	[Nullable(2)]
	private InfoDisplayAudioPlayerWithProgress AudioPlayer;

	// Token: 0x04007784 RID: 30596
	[Nullable(2)]
	private UUINiagara NiagaraSoundWave;

	// Token: 0x04007785 RID: 30597
	private bool NeedInterpNiagara;

	// Token: 0x04007786 RID: 30598
	private float InterpTime;

	// Token: 0x04007787 RID: 30599
	private bool ReverseInterp;

	// Token: 0x02008382 RID: 33666
	[NullableContext(0)]
	private class EInfoDisplayTypeFourNewView
	{
		// Token: 0x0402C98B RID: 182667
		public const int TextContent = 0;

		// Token: 0x0402C98C RID: 182668
		public const int TextTimer = 1;

		// Token: 0x0402C98D RID: 182669
		public const int AudioItem = 2;

		// Token: 0x0402C98E RID: 182670
		public const int BtnClose = 3;

		// Token: 0x0402C98F RID: 182671
		public const int TextTitle = 4;

		// Token: 0x0402C990 RID: 182672
		public const int NiagaraSoundWave = 5;

		// Token: 0x0402C991 RID: 182673
		public const int NiagaraSoundWaveRe = 6;
	}
}
