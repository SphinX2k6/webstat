using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020020B7 RID: 8375
public class GameplayFirstPassView : UiViewBase
{
	// Token: 0x0600FFCE RID: 65486 RVA: 0x004638EF File Offset: 0x00461AEF
	[NullableContext(1)]
	public GameplayFirstPassView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FFCF RID: 65487 RVA: 0x004638F8 File Offset: 0x00461AF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600FFD0 RID: 65488 RVA: 0x00463934 File Offset: 0x00461B34
	protected override void OnStart()
	{
		GameplayFirstPassViewData gameplayFirstPassViewData = this.OpenParam as GameplayFirstPassViewData;
		if (gameplayFirstPassViewData == null)
		{
			return;
		}
		string textById = ConfigBase<TextConfig>.Instance.GetTextById(gameplayFirstPassViewData.InfoId ?? "");
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(gameplayFirstPassViewData.TitleId ?? "");
		this.InitMain(textById, configTextByKey);
	}

	// Token: 0x0600FFD1 RID: 65489 RVA: 0x0046398D File Offset: 0x00461B8D
	[NullableContext(1)]
	private void InitMain([Nullable(2)] string info, string title)
	{
		base.GetText(0).SetText(info ?? "", true);
		base.GetText(1).SetText(title, true);
	}

	// Token: 0x0600FFD2 RID: 65490 RVA: 0x004639B4 File Offset: 0x00461BB4
	protected override void OnAfterPlayStartSequence()
	{
		this.DelayClose();
	}

	// Token: 0x0600FFD3 RID: 65491 RVA: 0x004639BC File Offset: 0x00461BBC
	private void DelayClose()
	{
		this.TimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.CloseView();
		}, 3000f, null, null, true, 1f);
	}

	// Token: 0x0600FFD4 RID: 65492 RVA: 0x004639E7 File Offset: 0x00461BE7
	private void CloseView()
	{
		this.TimerId = null;
		base.CloseMe(null);
	}

	// Token: 0x0600FFD5 RID: 65493 RVA: 0x004639F7 File Offset: 0x00461BF7
	protected override void OnBeforeDestroy()
	{
		if (this.TimerId != null)
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			}
			this.TimerId = null;
		}
	}

	// Token: 0x04007A9C RID: 31388
	[Nullable(2)]
	protected TimerHandle TimerId;

	// Token: 0x02008441 RID: 33857
	private class EGameplayFirstPassViewCom
	{
		// Token: 0x0402CD31 RID: 183601
		public const int InfoText = 0;

		// Token: 0x0402CD32 RID: 183602
		public const int TitleText = 1;
	}
}
