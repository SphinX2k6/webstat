using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200205D RID: 8285
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ItemHintItem : ItemHintItemBase<ItemRewardInfo>
{
	// Token: 0x0600FC77 RID: 64631 RVA: 0x00455594 File Offset: 0x00453794
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600FC78 RID: 64632 RVA: 0x00455604 File Offset: 0x00453804
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
	}

	// Token: 0x0600FC79 RID: 64633 RVA: 0x0045562F File Offset: 0x0045382F
	protected override void OnBeforeDestroy()
	{
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
		}
	}

	// Token: 0x0600FC7A RID: 64634 RVA: 0x0045564B File Offset: 0x0045384B
	[NullableContext(1)]
	private void FinishSequenceEvent(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			base.FinishPlayStart();
			return;
		}
		if (sequenceName == "Move")
		{
			base.FinishPlayHalfway();
			return;
		}
		if (sequenceName == "Close")
		{
			base.FinishPlayEnd();
		}
	}

	// Token: 0x0600FC7B RID: 64635 RVA: 0x00455688 File Offset: 0x00453888
	public override UniTask AsyncLoadUiResource()
	{
		ItemHintItem.<AsyncLoadUiResource>d__10 <AsyncLoadUiResource>d__;
		<AsyncLoadUiResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AsyncLoadUiResource>d__.<>4__this = this;
		<AsyncLoadUiResource>d__.<>1__state = -1;
		<AsyncLoadUiResource>d__.<>t__builder.Start<ItemHintItem.<AsyncLoadUiResource>d__10>(ref <AsyncLoadUiResource>d__);
		return <AsyncLoadUiResource>d__.<>t__builder.Task;
	}

	// Token: 0x0600FC7C RID: 64636 RVA: 0x004556CC File Offset: 0x004538CC
	public override void InitData()
	{
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.Data.ItemId.GetValueOrDefault());
		if (itemConfigData != null)
		{
			string name = itemConfigData.Name;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), name, Array.Empty<object>());
			int? itemCount = this.Data.ItemCount;
			base.GetText(2).SetText(itemCount.ToString(), true);
			TItemQualityConfig itemQualityByItemIdAndQuality = ConfigBase<InventoryConfig>.Instance.GetItemQualityByItemIdAndQuality(this.Data.ItemId, itemConfigData.QualityId);
			if (itemQualityByItemIdAndQuality != null)
			{
				FColor color = FColor.FromHex(itemQualityByItemIdAndQuality.TextColor);
				base.GetText(1).SetColor(color);
				base.GetText(3).SetColor(color);
				base.GetText(2).SetColor(color);
				this.ItemAudioQuality = new int?(itemConfigData.QualityId);
			}
		}
		this.CurSequencePlayer = null;
	}

	// Token: 0x0600FC7D RID: 64637 RVA: 0x004557AC File Offset: 0x004539AC
	protected override void PlayStart()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		this.CurSequencePlayer = "Start";
		this.PlayItemHintAudio();
	}

	// Token: 0x0600FC7E RID: 64638 RVA: 0x004557E8 File Offset: 0x004539E8
	private void PlayItemHintAudio()
	{
		if (this.ItemAudioQuality != null)
		{
			int? itemAudioQuality = this.ItemAudioQuality;
			int num = 4;
			if (itemAudioQuality.GetValueOrDefault() >= num & itemAudioQuality != null)
			{
				if (ControllerBase<ItemController>.Instance.LastItemHintAudioPlayedTime != null)
				{
					double? num2 = Singleton<Time>.Instance.Now - ControllerBase<ItemController>.Instance.LastItemHintAudioPlayedTime;
					double num3 = (double)500;
					if (!(num2.GetValueOrDefault() > num3 & num2 != null) && ControllerBase<ItemController>.Instance.LastItemHintAudioLevel >= 2)
					{
						Singleton<Log>.Instance.Info(ELogModule.Audio, ELogAuthor.YJY, "[Item] 物品音效冷却中，不播放音效", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
				}
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_item_hint_in_list_rare");
				ControllerBase<ItemController>.Instance.LastItemHintAudioLevel = 2;
				Singleton<Log>.Instance.Info(ELogModule.Audio, ELogAuthor.YJY, "[Item] 播放高品质物品提示音效", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<ItemController>.Instance.LastItemHintAudioPlayedTime = new double?(Singleton<Time>.Instance.Now);
				return;
			}
		}
		if (ControllerBase<ItemController>.Instance.LastItemHintAudioPlayedTime != null)
		{
			double? num2 = Singleton<Time>.Instance.Now - ControllerBase<ItemController>.Instance.LastItemHintAudioPlayedTime;
			double num3 = (double)500;
			if (!(num2.GetValueOrDefault() > num3 & num2 != null))
			{
				Singleton<Log>.Instance.Info(ELogModule.Audio, ELogAuthor.YJY, "[Item] 物品提示音效冷却中，跳过播放", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_item_hint_in_list_normal");
		ControllerBase<ItemController>.Instance.LastItemHintAudioLevel = 1;
		Singleton<Log>.Instance.Info(ELogModule.Audio, ELogAuthor.YJY, "[Item] 播放普通品质物品提示音效", default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<ItemController>.Instance.LastItemHintAudioPlayedTime = new double?(Singleton<Time>.Instance.Now);
	}

	// Token: 0x0600FC7F RID: 64639 RVA: 0x004559E8 File Offset: 0x00453BE8
	protected override void PlayHalfway()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Move", false, null, false);
		this.CurSequencePlayer = "Move";
	}

	// Token: 0x0600FC80 RID: 64640 RVA: 0x00455A1C File Offset: 0x00453C1C
	public override void PlayEnd()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		this.CurSequencePlayer = "Close";
	}

	// Token: 0x0600FC81 RID: 64641 RVA: 0x00455A4F File Offset: 0x00453C4F
	protected override void OnActiveStatusChange(bool value)
	{
		if (this.CurSequencePlayer != null)
		{
			if (value)
			{
				this.LevelSequencePlayer.PauseSequence();
				return;
			}
			this.LevelSequencePlayer.ResumeSequence();
		}
	}

	// Token: 0x04007919 RID: 31001
	private const int AUDIO_EFFECT_RARE_LEVEL = 4;

	// Token: 0x0400791A RID: 31002
	private const int AUDIO_HINT_CD_MS = 500;

	// Token: 0x0400791B RID: 31003
	protected string CurSequencePlayer;

	// Token: 0x0400791C RID: 31004
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400791D RID: 31005
	private int? ItemAudioQuality;

	// Token: 0x020083F8 RID: 33784
	[NullableContext(0)]
	private enum EItemHintItemCom
	{
		// Token: 0x0402CBC3 RID: 183235
		ItemIcon,
		// Token: 0x0402CBC4 RID: 183236
		ItemNameText,
		// Token: 0x0402CBC5 RID: 183237
		ItemCountText,
		// Token: 0x0402CBC6 RID: 183238
		ItemXText
	}
}
