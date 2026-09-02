using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016BA RID: 5818
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerScoreItem
{
	// Token: 0x0600A1B4 RID: 41396 RVA: 0x002A84A8 File Offset: 0x002A66A8
	public WheelTowerScoreItem(UiPanelBase contextObject, UUIItem parentItem)
	{
		this.ContextObject = contextObject;
		this.ParentItem = parentItem;
		AUIBaseActor auibaseActor = this.ContextObject.GetRootActor() as AUIBaseActor;
		if (auibaseActor == null)
		{
			return;
		}
		auibaseActor.OnPreDestroyed.Add(new Action<AActor>(this.OnDestroy));
	}

	// Token: 0x0600A1B5 RID: 41397 RVA: 0x002A8518 File Offset: 0x002A6718
	public void Refresh(EScoreLevel scoreLevel)
	{
		if (this.IsLock)
		{
			this.RefreshQueue.Push(scoreLevel);
			return;
		}
		this.IsLock = true;
		EScoreLevel? currentShowLevel = this.CurrentShowLevel;
		if (currentShowLevel.GetValueOrDefault() == scoreLevel & currentShowLevel != null)
		{
			this.Unlock();
			return;
		}
		UUIItem uuiitem;
		if (this.CurrentShowLevel != null && this.CachedScoreItemMap.TryGetValue(this.CurrentShowLevel.Value, out uuiitem))
		{
			uuiitem.SetUIActive(false);
		}
		this.CurrentShowLevel = new EScoreLevel?(scoreLevel);
		if (scoreLevel == EScoreLevel.None)
		{
			this.Unlock();
			return;
		}
		UUIItem uuiitem2;
		if (this.CachedScoreItemMap.TryGetValue(scoreLevel, out uuiitem2))
		{
			uuiitem2.SetUIActive(true);
			LevelSequencePlayer levelSequencePlayer;
			if (this.SeqPlayerMap.TryGetValue(scoreLevel, out levelSequencePlayer))
			{
				levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
			}
			this.Unlock();
			return;
		}
		this.LoadScoreItemAsync(scoreLevel).Forget();
	}

	// Token: 0x0600A1B6 RID: 41398 RVA: 0x002A85FC File Offset: 0x002A67FC
	private UniTask LoadScoreItemAsync(EScoreLevel scoreLevel)
	{
		WheelTowerScoreItem.<LoadScoreItemAsync>d__9 <LoadScoreItemAsync>d__;
		<LoadScoreItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadScoreItemAsync>d__.<>4__this = this;
		<LoadScoreItemAsync>d__.scoreLevel = scoreLevel;
		<LoadScoreItemAsync>d__.<>1__state = -1;
		<LoadScoreItemAsync>d__.<>t__builder.Start<WheelTowerScoreItem.<LoadScoreItemAsync>d__9>(ref <LoadScoreItemAsync>d__);
		return <LoadScoreItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A1B7 RID: 41399 RVA: 0x002A8647 File Offset: 0x002A6847
	private void Unlock()
	{
		this.IsLock = false;
		if (this.RefreshQueue.Size > 0)
		{
			this.Refresh(this.RefreshQueue.Pop());
		}
	}

	// Token: 0x0600A1B8 RID: 41400 RVA: 0x002A8670 File Offset: 0x002A6870
	[NullableContext(2)]
	private void OnDestroy(AActor _)
	{
		foreach (LevelSequencePlayer levelSequencePlayer in this.SeqPlayerMap.Values)
		{
			levelSequencePlayer.Clear();
		}
		this.SeqPlayerMap.Clear();
	}

	// Token: 0x04004BA8 RID: 19368
	private readonly Dictionary<EScoreLevel, UUIItem> CachedScoreItemMap = new Dictionary<EScoreLevel, UUIItem>();

	// Token: 0x04004BA9 RID: 19369
	private readonly Dictionary<EScoreLevel, LevelSequencePlayer> SeqPlayerMap = new Dictionary<EScoreLevel, LevelSequencePlayer>();

	// Token: 0x04004BAA RID: 19370
	private readonly Queue<EScoreLevel> RefreshQueue = new Queue<EScoreLevel>(4);

	// Token: 0x04004BAB RID: 19371
	private readonly UiPanelBase ContextObject;

	// Token: 0x04004BAC RID: 19372
	private readonly UUIItem ParentItem;

	// Token: 0x04004BAD RID: 19373
	private EScoreLevel? CurrentShowLevel;

	// Token: 0x04004BAE RID: 19374
	private bool IsLock;
}
